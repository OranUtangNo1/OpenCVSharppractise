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
        /// �I���摜
        /// </summary>
        private Bitmap selectedImage;
        Bitmap SelectedImage
        {
            get { return selectedImage; }
            set
            {
                selectedImage = value;
                // picBox�ɉ摜��ݒ�
                this.PicBox_SelectedImage.Image = ImageFileManager.ResizeImage(this.PicBox_SelectedImage.Size, selectedImage);
            }
        }

        /// <summary>
        /// �����ς݉摜
        /// </summary>
        private Bitmap processedImage;
        Bitmap ProcessedImage
        {
            get { return processedImage; }
            set
            {
                processedImage = value;
                // picBox�ɉ摜��ݒ�
                this.PicBox_ProcessedImage.Image = ImageFileManager.ResizeImage(this.PicBox_ProcessedImage.Size, processedImage);
            }
        }

        /// <summary>
        /// Select Image���݉���������
        /// </summary>
        /// <param name="sender">���s�����</param>
        /// <param name="e">�C�x���g���</param>

        private void Btn_SelectImage_Click(object sender, EventArgs e)
        {
            // �t�@�C���I��
            var selectFilepath = ImageFileManager.ImageFileSelect();
            if (!string.IsNullOrEmpty(selectFilepath))
            {
                // �I���t�@�C����\��
                this.SelectedImage = new Bitmap(selectFilepath);
            }
            else
            {
                //MessageBox.Show("�摜�I���G���[");
            }
        }

        /// <summary>
        /// Clear���݉���������
        /// </summary>
        /// <param name="sender">���s�����</param>
        /// <param name="e">�C�x���g���</param>
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
        /// ProcessImage���݉���������
        /// </summary>
        /// <param name="sender">���s�����</param>
        /// <param name="e">�C�x���g���</param>
        private void Btn_ProcessImage_Click(object sender, EventArgs e)
        {
            // �����Ώۂ��擾
            var targetProcesses = this.GetSelectedProcesses();
            // �ݒ�擾
            var setting = this.CreateImageProcessSetting(targetProcesses);
            // �v���Z�X�쐬
            var processer = new ImageProcessor(targetProcesses, setting);
            // �摜�������s
            var result = processer.ProcessExecute(this.SelectedImage,out Bitmap bitmap);
            // �S�Ă̏����ɐ������Ă���ꍇ�̂݁A�����ς݉摜�G���A�X�V
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
        ///  ��������(SUCCESS)�ȊO�̃n���h�����O���\�b�h
        /// </summary>
        /// <param name="errType">�������s����</param>
        private void ErrorHandling(ProcessExecuteResult errType)
        {
            switch (errType)
            {
                case ProcessExecuteResult.INVALID_PARAMETERS:
                    MessageBox.Show("�I���摜������������܂���");
                    break;
                case ProcessExecuteResult.PROCESSING_ERROR:
                    MessageBox.Show("�������ɃG���[���������܂���");
                    break;
                case ProcessExecuteResult.NON_EXECUTEPROCESSES:
                    MessageBox.Show("���s���鏈����I�����Ă�������");
                    break;
            }
        }

        /// <summary>
        /// �ۑ�����������
        /// </summary>
        /// <param name="sender">���s�����</param>
        /// <param name="e">�C�x���g���</param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            ImageFileManager.ImageFileSave(this.ProcessedImage);
        }

        /// <summary>
        /// �K�p���鏈�����ڎ擾
        /// </summary>
        /// <returns>�K�p���ڂ̃��X�g</returns>
        private IEnumerable<ProcessType> GetSelectedProcesses()
        {
            var selectedMethods = new List<ProcessType>();

            if (this.ChkBox_GrayScale.Checked)
            {
                selectedMethods.Add(ProcessType.GrayScale);
            }
            if (this.ChkBox_Gauss.Checked)
            {
                selectedMethods.Add(ProcessType.Gauss);
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

            return selectedMethods;
        }

        private ImageProcessSetting CreateImageProcessSetting(IEnumerable<ProcessType> processes)
        {
            var setting = new ImageProcessSetting();

            foreach (var process in processes)
            {
                switch (process)
                {
                    // ��ʐݒ�l��ݒ�
                    case ProcessType.Gauss:
                        setting.GaussianKernel = this.ScBar_Gauss.Value;
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

                    // ��ʐݒ�l���s�v�ȏ���
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
