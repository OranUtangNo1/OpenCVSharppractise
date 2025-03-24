namespace ImageProccessingApp.Processes
{
    /// <summary>
    /// ガアウシアンフィルター(ぼかし)処理
    /// </summary>
    public class FilterProcessor : IProcess
    {
        /// <summary>
        /// 画像処理種別
        /// </summary>
        public ProcessType ProcessType { get; } = ProcessType.Filter;

        public FilterType FilterType { get; } = FilterType.Gaussian;

        /// <summary>
        /// 設定値
        /// </summary>
        public int Kernel { get; set; } = 3;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="kernel">設定値</param>
        public FilterProcessor(int kernel,FilterType filterType) 
        {
            this.Kernel = kernel;
            this.FilterType = filterType;
        }

        /// <summary>
        /// 処理実行
        /// </summary>
        /// <param name="inputImage">入力画像</param>
        /// <returns>出力画像</returns>
        public ProcessExecuteResult ProcessExecute(Bitmap inputImage, out Bitmap outputImage)
        {
            ProcessExecuteResult result = ProcessExecuteResult.SUCCESS;
            outputImage = null;
            switch (this.FilterType)
            {
                case FilterType.Gaussian:
                    result =  OpenCVRapper.GaussianFilter(inputImage, out outputImage, this.Kernel);
                    break;
                case FilterType.Median:
                    result = OpenCVRapper.MedianFilter(inputImage, out outputImage, this.Kernel);
                    break;
                case FilterType.MovingAverage:
                    result = OpenCVRapper.MovingAverageFilter(inputImage, out outputImage, this.Kernel);
                    break;
            }
            return result;
        }
    }
}
