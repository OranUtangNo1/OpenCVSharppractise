using OpenCvSharp;
using System.Drawing;

namespace ImageProccessingApp
{
    internal static class OpenCVRapper
    {
        #region process
        /// <summary>
        /// グレースケール処理
        /// </summary>
        /// <param name="inputBitmap">入力画像</param>
        /// <param name="outputBitmap">出力画像</param>
        /// <returns>実行結果</returns>
        public static ProcessExecuteResult GrayScale(Bitmap inputBitmap, out Bitmap outputBitmap)
        {
            outputBitmap = null;
            ProcessExecuteResult result = ProcessExecuteResult.SUCCESS;

            // プロセス作成
            Func<Mat, Mat> process = new Func<Mat, Mat>(mat =>
            {
                var grayMat = new Mat();
                // グレースケール
                Cv2.CvtColor(mat, grayMat, ColorConversionCodes.BGR2GRAY);
                return grayMat;
            });
            result = ExecuteImageProcessing(process, inputBitmap, out outputBitmap);
            return result;
        }

        /// <summary>
        /// ガウシアンフィルタ処理
        /// </summary>
        /// <param name="inputBitmap">入力画像</param>
        /// <param name="outputBitmap">出力画像</param>
        /// <param name="kernelSize">カーネルサイズ</param>
        /// <returns>実行結果</returns>
        public static ProcessExecuteResult GaussianFilter(Bitmap bitmap, out Bitmap outputBitmap, int kernelSize)
        {
            outputBitmap = null;
            ProcessExecuteResult result = ProcessExecuteResult.SUCCESS;

            // プロセス作成
            Func<Mat, Mat> process = new Func<Mat, Mat>(mat =>
            {
                Mat blurredImage = new Mat();
                // ガウシアンブラー
                Cv2.GaussianBlur(mat, blurredImage, new OpenCvSharp.Size(kernelSize, kernelSize), 0);
                return blurredImage;
            });

            result = ExecuteImageProcessing(process, bitmap, out outputBitmap);
            return result;
        }

        /// <summary>
        /// 移動平均フィルタ処理
        /// </summary>
        /// <param name="inputBitmap">入力画像</param>
        /// <param name="outputBitmap">出力画像</param>
        /// <param name="kernelSize">カーネルサイズ</param>
        /// <returns>実行結果</returns>
        public static ProcessExecuteResult MovingAverageFilter(Bitmap bitmap, out Bitmap outputBitmap, int kernelSize)
        {
            outputBitmap = null;
            ProcessExecuteResult result = ProcessExecuteResult.SUCCESS;

            // プロセス作成
            Func<Mat, Mat> process = new Func<Mat, Mat>(mat =>
            {
                Mat blurredImage = new Mat();
                // 移動平均ブラー
                Cv2.Blur(mat, blurredImage, new OpenCvSharp.Size(kernelSize, kernelSize));
                return blurredImage;
            });

            result = ExecuteImageProcessing(process, bitmap, out outputBitmap);
            return result;
        }

        /// <summary>
        /// メディアンフィルタ処理
        /// </summary>
        /// <param name="inputBitmap">入力画像</param>
        /// <param name="outputBitmap">出力画像</param>
        /// <param name="kernelSize">カーネルサイズ</param>
        /// <returns>実行結果</returns>
        public static ProcessExecuteResult MedianFilter(Bitmap bitmap, out Bitmap outputBitmap, int kernelSize)
        {
            outputBitmap = null;
            ProcessExecuteResult result = ProcessExecuteResult.SUCCESS;

            // プロセス作成
            Func<Mat, Mat> process = new Func<Mat, Mat>(mat =>
            {
                Mat blurredImage = new Mat();
                // メディアンブラー
                Cv2.MedianBlur(mat, blurredImage, kernelSize);
                return blurredImage;
            });

            result = ExecuteImageProcessing(process, bitmap, out outputBitmap);
            return result;
        }

        /// <summary>
        /// 彩度変更処理
        /// </summary>
        /// <param name="inputBitmap">入力画像</param>
        /// <param name="outputBitmap">出力画像</param>
        /// <param name="saturationLevel">彩度強調ﾚﾍﾞﾙ</param>
        /// <returns>実行結果</returns>
        public static ProcessExecuteResult Saturation(Bitmap bitmap, out Bitmap outputBitmap, int saturationLevel)
        {
            outputBitmap = null;
            ProcessExecuteResult result = ProcessExecuteResult.SUCCESS;
            // 0〜50の範囲の値を0〜2の範囲にスケール
            float scale = saturationLevel / 25.0f;
            // プロセス作成
            Func<Mat, Mat> process = new Func<Mat, Mat>(mat =>
            {
                Mat hsvImage = new Mat();
                // BGRからHSVに変換
                Cv2.CvtColor(mat, hsvImage, ColorConversionCodes.BGR2HSV);

                // HSVの各チャンネルを分割
                Mat[] hsvChannels = new Mat[3];
                Cv2.Split(hsvImage, out hsvChannels);

                // 彩度(S)のチャンネルを取得
                Mat saturationChannel = hsvChannels[1];

                // 彩度の変更: scaleに基づいて彩度を変更します。
                saturationChannel.ConvertTo(saturationChannel, MatType.CV_8U, scale);

                // チャンネルを再結合
                Cv2.Merge(hsvChannels, hsvImage);

                // HSVからBGRに戻す
                Mat resultImage = new Mat();
                Cv2.CvtColor(hsvImage, resultImage, ColorConversionCodes.HSV2BGR);

                return resultImage;
            });

            result = ExecuteImageProcessing(process, bitmap, out outputBitmap);
            return result;
        }

        /// <summary>
        /// コントラスト変更処理
        /// </summary>
        /// <param name="inputBitmap">入力画像</param>
        /// <param name="outputBitmap">出力画像</param>
        /// <param name="contrastLevel">コントラストレベル</param>
        /// <returns>実行結果</returns>
        public static ProcessExecuteResult Contrast(Bitmap bitmap, out Bitmap outputBitmap, int contrastLevel)
        {
            outputBitmap = null;
            ProcessExecuteResult result = ProcessExecuteResult.SUCCESS;

            // プロセス作成
            Func<Mat, Mat> process = new Func<Mat, Mat>(mat =>
            {
                Mat convertedMat = new Mat();
                // ユーザー設定値を0~2にスケーリング
                float alpha = (float)contrastLevel / 25.0f;

                // 明るさは変更しない
                float beta = 0;

                mat.ConvertTo(convertedMat, -1, alpha, beta);
                return convertedMat;
            });
            result = ExecuteImageProcessing(process, bitmap, out outputBitmap);
            return result;
        }

        public static ProcessExecuteResult Brightness(Bitmap bitmap, out Bitmap outputBitmap, int brightnessLevel)
        {
            outputBitmap = null;
            ProcessExecuteResult result = ProcessExecuteResult.SUCCESS;

            // プロセス作成
            Func<Mat, Mat> process = new Func<Mat, Mat>(mat =>
            {
                Mat adjustedMat = new Mat();
                // 明るさ調整のためのスケール（brightnessLevelは-50〜50の範囲）
                float alpha = 1.0f; // 明るさは変更しない（コントラスト用）
                float beta = brightnessLevel; // 明るさを調整するバイアス値

                // 明るさ調整
                mat.ConvertTo(adjustedMat, -1, alpha, beta);
                return adjustedMat;
            });
            result = ExecuteImageProcessing(process, bitmap, out outputBitmap);
            return result;
        }

        /// <summary>
        /// ネガポジ処理
        /// </summary>
        /// <param name="inputBitmap">入力画像</param>
        /// <param name="outputBitmap">出力画像</param>
        /// <returns>実行結果</returns>
        public static ProcessExecuteResult NegaPosi(Bitmap bitmap, out Bitmap outputBitmap)
        {
            outputBitmap = null;
            ProcessExecuteResult result = ProcessExecuteResult.SUCCESS;

            // プロセス作成
            Func<Mat, Mat> process = new Func<Mat, Mat>(mat =>
            {
                Mat bitwisedMat = new Mat();
                //画素値反転
                Cv2.BitwiseNot(mat, bitwisedMat);
                return bitwisedMat;
            });
            result = ExecuteImageProcessing(process, bitmap, out outputBitmap);
            return result;
        }

        public static ProcessExecuteResult CannyEdge(Bitmap bitmap, out Bitmap outputBitmap)
        {
            outputBitmap = null;
            ProcessExecuteResult result = ProcessExecuteResult.SUCCESS;

            // プロセス作成
            Func<Mat, Mat> process = new Func<Mat, Mat>(mat =>
            {
                Mat grayMat = new Mat();
                Mat cannyEdgeMat = new Mat();
                //前処理
                //グレースケール
                Cv2.CvtColor(mat, grayMat, ColorConversionCodes.BGR2GRAY);
                // エッジ検出(Cannyエッジ)
                Cv2.Canny(grayMat, cannyEdgeMat, Const.CannyThresholdMin, Const.CannyThresholdMax);
                return cannyEdgeMat;
            });
            result = ExecuteImageProcessing(process, bitmap, out outputBitmap);
            return result;
        }

        #endregion process

        /// <summary>
        /// 画像処理プロセス実行用関数
        /// </summary>
        /// <param name="proseccing">画像処理プロセス</param>
        /// <param name="inputBitmap">入力画像</param>
        /// <param name="outputBitmap">出力画像</param>
        /// <returns>実行結果</returns>
        private static ProcessExecuteResult ExecuteImageProcessing(Func<Mat, Mat> proseccing, Bitmap inputBitmap, out Bitmap outputBitmap)
        {
            outputBitmap = null;
            ProcessExecuteResult result = ProcessExecuteResult.SUCCESS;

            try
            {
                using (Mat mat = BitmapToMat(inputBitmap))
                {
                    // 画像処理を実行
                    Mat processedMat = proseccing(mat);

                    // 処理結果をBitmapに変換
                    outputBitmap = MatToBitmap(processedMat);
                }
            }
            catch (ArgumentNullException ex)
            {
                // 引数がnullの場合
                result = ProcessExecuteResult.INVALID_PARAMETERS;
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                // 不正な引数
                result = ProcessExecuteResult.INVALID_PARAMETERS;
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (NotSupportedException ex)
            {
                // 処理できない形式の場合
                result = ProcessExecuteResult.PROCESSING_ERROR;
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // その他のエラー
                result = ProcessExecuteResult.FAILED;
                Console.WriteLine($"Error: {ex.Message}");
            }
            return result;
        }

        #region converter

        /// <summary>
        /// Bitmap→Mat変換処理
        /// </summary>
        /// <param name="bitmap">入力</param>
        /// <returns>出力</returns>
        public static Mat BitmapToMat(Bitmap bitmap)
        {
            Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);
            return mat;
        }

        /// <summary>
        /// Mat→Bitmap変換処理
        /// </summary>
        /// <param name="mat">入力</param>
        /// <returns>出力</returns>
        public static Bitmap MatToBitmap(Mat mat)
        {
            Bitmap bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(mat);
            return bitmap;
        }

        #endregion converter
    }
}
