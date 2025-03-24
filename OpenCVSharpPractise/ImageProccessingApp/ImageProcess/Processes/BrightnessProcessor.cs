using ImageProccessingApp.Processes;

namespace ImageProccessingApp.ImageProcess.Processes
{
    internal class BrightnessProcessor : IProcess
    {
        /// <summary>
        /// 画像処理種別
        /// </summary>
        public ProcessType ProcessType { get; } = ProcessType.Brightness;

        /// <summary>
        /// 設定値
        /// </summary>
        public int BrightnessLevel { get; set; } = 25;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="brightnessLevel">設定値</param>
        public BrightnessProcessor(int brightnessLevel)
        {
            this.BrightnessLevel = brightnessLevel;
        }

        /// <summary>
        /// 処理実行
        /// </summary>
        /// <param name="inputImage">入力画像</param>
        /// <returns>出力画像</returns>
        public ProcessExecuteResult ProcessExecute(Bitmap inputImage, out Bitmap outputImage)
        {
            return OpenCVRapper.Brightness(inputImage, out outputImage,this.BrightnessLevel);
        }
    }    
}
