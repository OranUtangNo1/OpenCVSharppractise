namespace ImageProccessingApp.ImageProcess
{
    public class ImageProcessSetting
    {
     
        /// <summary>
        /// コントラスト設定値
        /// </summary>
        public int ContrastLevel { get; set; } = 25;

        /// <summary>
        /// 彩度設定値
        /// </summary>
        public int SaturationLevel { get; set; } = 25;

        /// <summary>
        /// 明るさ設定値
        /// </summary>
        public int BrightnessLevel { get; set; } = 25;


        /// <summary>
        /// フィルタ処理設定値
        /// </summary>
        public int Kernel { get; set; } = 3;

        public FilterType FilterType { get; set; }


    }
}
