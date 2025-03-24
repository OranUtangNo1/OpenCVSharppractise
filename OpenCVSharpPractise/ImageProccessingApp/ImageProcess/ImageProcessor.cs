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
        private readonly List<IProcess> processors;
        private readonly ImageProcessSetting setting;

        public ImageProcessor(IEnumerable<ProcessType> processes, ImageProcessSetting setting)
        {
            this.setting = setting;
            processors = new List<IProcess>();

            foreach (var process in processes)
            {
                switch (process)
                {
                    case ProcessType.GrayScale:
                        processors.Add(new GrayScaleProcessor());
                        break;
                    case ProcessType.Filter:
                        processors.Add(new FilterProcessor(this.setting.Kernel,this.setting.FilterType));
                        break;
                    case ProcessType.Contrast:
                        processors.Add(new ContrastProcessor(this.setting.ContrastLevel));
                        break;
                    case ProcessType.Saturation:
                        processors.Add(new SaturationProcessor(this.setting.SaturationLevel));
                        break;
                    case ProcessType.NegaPosi:
                        processors.Add(new NegaPosiProcessor());
                        break;
                    case ProcessType.Brightness:
                        processors.Add(new BrightnessProcessor(this.setting.BrightnessLevel));
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
            if(processors.Count != 0)
            {
                foreach (var processor in processors)
                {
                    if (result == ProcessExecuteResult.SUCCESS)
                    {
                        result = processor.ProcessExecute(inputBitmap, out outputBitmap);
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
