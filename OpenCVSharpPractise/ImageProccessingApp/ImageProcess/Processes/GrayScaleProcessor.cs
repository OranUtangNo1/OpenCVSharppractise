using ImageProccessingApp.ImageProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProccessingApp.Processes
{
    /// <summary>
    /// グレースケール処理
    /// </summary>
    public class GrayScaleProcessor : IProcess
    {
        public ProcessType ProcessType { get; } = ProcessType.GrayScale;

        /// <summary>
        /// 処理実行
        /// </summary>
        /// <param name="inputImage">入力画像</param>
        /// <returns>出力画像</returns>
        public ProcessExecuteResult ProcessExecute(Bitmap inputImage, out Bitmap outputImage)
        {
            return OpenCVRapper.GrayScale(inputImage, out outputImage);
        }
    }
}
