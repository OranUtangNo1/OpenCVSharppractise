using ImageProccessingApp.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProccessingApp.ImageProcess.Processes
{
    internal class NegaPosiProcessor : IProcess
    {
        /// <summary>
        /// 画像処理種別
        /// </summary>
        public ProcessType ProcessType { get; } = ProcessType.NegaPosi;

        /// <summary>
        /// 処理実行
        /// </summary>
        /// <param name="inputImage">入力画像</param>
        /// <returns>出力画像</returns>
        public ProcessExecuteResult ProcessExecute(Bitmap inputImage, out Bitmap outputImage)
        {
            return OpenCVRapper.NegaPosi(inputImage,out outputImage);
        }

    }
}
