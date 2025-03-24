using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProccessingApp.ImageProcess;
using ImageProccessingApp.ImageProcess.Processes;
using ImageProccessingApp.Processes;

namespace ImageProccessingApp
{
    /// <summary>
    /// 画像処理モジュールインターフェース
    /// </summary>
    public interface IImageProcessor
    {
        ProcessExecuteResult ProcessExecute(Bitmap inputBitmap, out Bitmap outputBitmap);
    }

    /// <summary>
    /// 画像処理モジュール
    /// </summary>
    public class ImageProcessor: IImageProcessor
    {
        /// <summary>
        /// プロセスリスト
        /// </summary>
        private readonly List<IProcess> processes;

        /// <summary>
        /// 画像処理設定
        /// </summary>
        private readonly ImageProcessSetting setting;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="processes">実行するプロセスリスト</param>
        /// <param name="setting">設定値</param>
        public ImageProcessor(IEnumerable<ProcessType> processes, ImageProcessSetting setting)
        {
            this.setting = setting;
            this.processes = new List<IProcess>();

            foreach (var process in processes)
            {
                switch (process)
                {
                    case ProcessType.GrayScale:
                        this.processes.Add(new GrayScaleProcessor());
                        break;
                    case ProcessType.Filter:
                        this.processes.Add(new FilterProcessor(this.setting.Kernel,this.setting.FilterType));
                        break;
                    case ProcessType.Contrast:
                        this.processes.Add(new ContrastProcessor(this.setting.ContrastLevel));
                        break;
                    case ProcessType.Saturation:
                        this.processes.Add(new SaturationProcessor(this.setting.SaturationLevel));
                        break;
                    case ProcessType.NegaPosi:
                        this.processes.Add(new NegaPosiProcessor());
                        break;
                    case ProcessType.Brightness:
                        this.processes.Add(new BrightnessProcessor(this.setting.BrightnessLevel));
                        break;
                }
            }
        }

        /// <summary>
        /// プロセス実行
        /// </summary>
        /// <param name="inputBitmap">入力画像</param>
        /// <param name="outputBitmap">出力画像</param>
        /// <returns>実行結果</returns>
        public ProcessExecuteResult ProcessExecute(Bitmap inputBitmap, out Bitmap outputBitmap)
        {
            ProcessExecuteResult result = ProcessExecuteResult.SUCCESS;
            outputBitmap = null;
            //初回は入力画像に対して処理実行
            var targetBitmap = inputBitmap;

            if (processes.Count != 0)
            {
                foreach (var processor in processes)
                {
                    if (result == ProcessExecuteResult.SUCCESS)
                    {
                        result = processor.ProcessExecute(targetBitmap, out outputBitmap);
                        // ターゲット更新
                        targetBitmap?.Dispose();
                        targetBitmap = (Bitmap)outputBitmap?.Clone();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                result = ProcessExecuteResult.NON_EXECUTEPROCESSES;
            }
            return result;
        }
    }
}
