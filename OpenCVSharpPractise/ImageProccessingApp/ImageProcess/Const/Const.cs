using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProccessingApp
{
    public static class Const 
    {
        public const int CntrastLevelMin = 0;

        public const int CntrastLevelMax = 50;


        public const int CannyThresholdMin = 100;

        public const int CannyThresholdMax = 200;
    }
    public enum ProcessExecuteResult 
    {
        SUCCESS = 1,
        INVALID_IMAGE_FORMAT = 2,
        PROCESSING_ERROR = 3,
        OUT_OF_MEMORY = 4,
        INVALID_PARAMETERS = 5,
        TIMEOUT = 6,
        PERMISSION_DENIED = 7,
        FILE_NOT_FOUND = 8,
        FAILED = 9,
        NON_EXECUTEPROCESSES = 10,
    }

    public enum ProcessType
    {
        GrayScale,
        Filter,
        Contrast,
        Saturation,
        Brightness,
        NegaPosi,
    }

    public enum FilterType
    {
        Gaussian,
        Median,
        MovingAverage,
    }


}
