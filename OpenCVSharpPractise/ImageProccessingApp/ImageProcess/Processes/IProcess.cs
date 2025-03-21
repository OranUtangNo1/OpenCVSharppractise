using ImageProccessingApp.ImageProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProccessingApp.Processes
{
    /// <summary>
    /// Process用インターフェース
    /// </summary>
    public interface IProcess
    {

        /// <summary>
        /// 画像処理種別
        /// </summary>
        ProcessType ProcessType { get; }

        /// <summary>
        /// 処理実行
        /// </summary>
        /// <param name="inputImage">入力画像</param>
        /// <param name="outputImage">出力画像</param>
        /// <returns>実行結果</returns>
        ProcessExecuteResult ProcessExecute(Bitmap inputImage, out Bitmap outputImage);
    }
}
