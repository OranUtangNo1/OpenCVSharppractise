using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProccessingApp.Processes
{
    /// <summary>
    /// ガアウシアンフィルター(ぼかし)処理
    /// </summary>
    public class GaussProcessor : IProcess
    {
        /// <summary>
        /// 画像処理種別
        /// </summary>
        public ProcessType ProcessType { get; } = ProcessType.Gauss;

        /// <summary>
        /// 設定値
        /// </summary>
        public int GaussianKernel { get; set; } = 3;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="kernel">設定値</param>
        public GaussProcessor(int kernel) 
        {
            this.GaussianKernel = kernel;
        }

        /// <summary>
        /// 処理実行
        /// </summary>
        /// <param name="inputImage">入力画像</param>
        /// <returns>出力画像</returns>
        public ProcessExecuteResult ProcessExecute(Bitmap inputImage, out Bitmap outputImage)
        {
            return OpenCVRapper.GaussianBlur(inputImage,out outputImage, this.GaussianKernel);
        }
    }
}
