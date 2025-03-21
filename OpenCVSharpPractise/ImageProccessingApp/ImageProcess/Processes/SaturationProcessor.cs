using ImageProccessingApp.ImageProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProccessingApp.Processes
{

    /// <summary>
    /// 彩度変更プロセス
    /// </summary>
    public class SaturationProcessor : IProcess
    {
        /// <summary>
        /// 画像処理種別
        /// </summary>
        public ProcessType ProcessType { get; } = ProcessType.Saturation;

        public int SaturationLevel { get; set; } = 25;

        public SaturationProcessor(int saturationLevel)
        {
            this.SaturationLevel = saturationLevel;
        }

        /// <summary>
        /// 処理実行
        /// </summary>
        /// <param name="inputImage">入力画像</param>
        /// <returns>出力画像</returns>
        public ProcessExecuteResult ProcessExecute(Bitmap inputImage, out Bitmap outputImage)
        {
            return OpenCVRapper.Saturation(inputImage, out outputImage, this.SaturationLevel);
        }
    }
}
