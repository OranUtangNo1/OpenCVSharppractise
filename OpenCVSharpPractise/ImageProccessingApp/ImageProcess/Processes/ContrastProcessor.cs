using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProccessingApp.Processes
{
    /// <summary>
    /// 明るさ変更プロセス
    /// </summary>
    public class ContrastProcessor : IProcess
    {
        /// <summary>
        /// 画像処理種別
        /// </summary>
       public ProcessType ProcessType { get; } = ProcessType.Contrast;

        /// <summary>
        /// 設定値
        /// </summary>
        public int ContrastLevel {  get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="contrastLevel">設定値</param>
        public ContrastProcessor(int contrastLevel)
        {
            this.ContrastLevel = contrastLevel;
        }

        /// <summary>
        /// 処理実行
        /// </summary>
        /// <param name="inputImage">入力画像</param>
        /// <returns>出力画像</returns>
        public ProcessExecuteResult ProcessExecute(Bitmap inputImage, out Bitmap outputImage)
        {
            return OpenCVRapper.Contrast(inputImage, out outputImage,this.ContrastLevel);
        }
    }
}
