using System.Net.NetworkInformation;
using ImageProccessingApp.ImageProcess;
using OpenCvSharp;


namespace ImageProccessingApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 選択画像
        /// </summary>
        private Bitmap selectedImage;
        Bitmap SelectedImage
        {
            get { return selectedImage; }
            set
            {
                selectedImage = value;
                // picBoxに画像を設定
                this.PicBox_SelectedImage.Image = ImageFileManager.ResizeImage(this.PicBox_SelectedImage.Size, selectedImage);
            }
        }

        /// <summary>
        /// 処理済み画像
        /// </summary>
        private Bitmap processedImage;
        Bitmap ProcessedImage
        {
            get { return processedImage; }
            set
            {
                processedImage = value;
                // picBoxに画像を設定
                this.PicBox_ProcessedImage.Image = ImageFileManager.ResizeImage(this.PicBox_ProcessedImage.Size, processedImage);
            }
        }

        /// <summary>
        /// Select Imageﾎﾞﾀﾝ押下時処理
        /// </summary>
        /// <param name="sender">発行元情報</param>
        /// <param name="e">イベント情報</param>

        private void Btn_SelectImage_Click(object sender, EventArgs e)
        {
            // ファイル選択
            var selectFilepath = ImageFileManager.ImageFileSelect();
            if (!string.IsNullOrEmpty(selectFilepath))
            {
                // 選択ファイルを表示
                this.SelectedImage = new Bitmap(selectFilepath);
            }
            else
            {
                //MessageBox.Show("画像選択エラー");
            }
        }

        /// <summary>
        /// Clearﾎﾞﾀﾝ押下時処理
        /// </summary>
        /// <param name="sender">発行元情報</param>
        /// <param name="e">イベント情報</param>
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            if (this.SelectedImage != null)
            {
                this.SelectedImage.Dispose();
                this.SelectedImage = null;
            }
            this.PicBox_SelectedImage.Image = null;

            if (this.ProcessedImage != null)
            {
                this.ProcessedImage.Dispose();
                this.ProcessedImage = null;
            }
            this.PicBox_ProcessedImage.Image = null;
        }


        /// <summary>
        /// ProcessImageﾎﾞﾀﾝ押下時処理
        /// </summary>
        /// <param name="sender">発行元情報</param>
        /// <param name="e">イベント情報</param>
        private void Btn_ProcessImage_Click(object sender, EventArgs e)
        {
            // 処理対象を取得
            var targetProcesses = this.GetSelectedProcesses();
            // 設定取得
            var setting = this.CreateImageProcessSetting(targetProcesses);
            // プロセス作成
            var processer = new ImageProcessor(targetProcesses, setting);
            // 画像処理実行
            var inputBitmap_tmp = new Bitmap(this.SelectedImage);
            var result = processer.ProcessExecute(inputBitmap_tmp,out Bitmap bitmap);
            // 全ての処理に成功している場合のみ、処理済み画像エリア更新
            if(result == ProcessExecuteResult.SUCCESS)
            {
                this.ProcessedImage = bitmap;
            }
            else
            {
                this.ErrorHandling(result);
                bitmap?.Dispose();
            }
        }

        /// <summary>
        ///  処理結果(SUCCESS)以外のハンドリングメソッド
        /// </summary>
        /// <param name="errType">処理実行結果</param>
        private void ErrorHandling(ProcessExecuteResult errType)
        {
            switch (errType)
            {
                case ProcessExecuteResult.INVALID_PARAMETERS:
                    MessageBox.Show("選択画像が正しくありません");
                    break;
                case ProcessExecuteResult.PROCESSING_ERROR:
                    MessageBox.Show("処理中にエラーが発生しました");
                    break;
                case ProcessExecuteResult.NON_EXECUTEPROCESSES:
                    MessageBox.Show("実行する処理を選択してください");
                    break;
            }
        }

        /// <summary>
        /// 保存押下時処理
        /// </summary>
        /// <param name="sender">発行元情報</param>
        /// <param name="e">イベント情報</param>
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            ImageFileManager.ImageFileSave(this.ProcessedImage);
        }

        /// <summary>
        /// 適用する処理項目取得
        /// </summary>
        /// <returns>適用項目のリスト</returns>
        private IEnumerable<ProcessType> GetSelectedProcesses()
        {
            var selectedMethods = new List<ProcessType>();

            if (this.ChkBox_GrayScale.Checked)
            {
                selectedMethods.Add(ProcessType.GrayScale);
            }
            if (this.ChkBox_Filter.Checked)
            {
                selectedMethods.Add(ProcessType.Filter);
            }
            if (this.ChkBox_Contrast.Checked)
            {
                selectedMethods.Add(ProcessType.Contrast);
            }
            if (this.ChkBox_Saturation.Checked)
            {
                selectedMethods.Add(ProcessType.Saturation);
            }
            if (this.ChkBox_NegaPosi.Checked)
            {
                selectedMethods.Add(ProcessType.NegaPosi);
            }
            if (this.ChkBox_Brightness.Checked)
            {
                selectedMethods.Add(ProcessType.Brightness);
            }
            return selectedMethods;
        }

        private ImageProcessSetting CreateImageProcessSetting(IEnumerable<ProcessType> processes)
        {
            var setting = new ImageProcessSetting();

            foreach (var process in processes)
            {
                switch (process)
                {
                    // 画面設定値を設定
                    case ProcessType.Filter:
                        // カーネルサイズ-3段階(3,5,7)
                        setting.Kernel = this.ScBar_Filter.Value　== 1 ? 3:
                            this.ScBar_Filter.Value == 2 ? 5 : 7;
                        // フィルタタイプ(ガウシアン/メディアン/移動平均)
                        setting.FilterType = this.radio_Gauss.Checked ? FilterType.Gaussian : 
                            this.radio_Median.Checked ? FilterType.Median : FilterType.MovingAverage;
                        break;
                    case ProcessType.Contrast:
                        setting.ContrastLevel = this.ScBar_Contrast.Value;
                        break;
                    case ProcessType.Saturation:
                        setting.SaturationLevel = this.ScBar_Saturation.Value;
                        break;
                    case ProcessType.Brightness:
                        setting.BrightnessLevel = this.ScBar_Brightness.Value;
                        break;

                    // 画面設定値が不要な処理
                    case ProcessType.GrayScale:
                    case ProcessType.NegaPosi:
                        break;
                    default:
                        break;
                }
            }

            return setting;
        }
    }
}
