using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProccessingApp
{
    public class ImageFileManager()
    {
        public enum FileFilter
        {
            png,
            jpg,
            jpeg,
            bmp,
        }

        // Const
        const string AstDot = "*";
        const string Dot = ".";
        const string SemiColon = ";";
        const string Colon = ":";
        const string Pipe = "｜";
        const string FileFilterHeader = "Image Files";

        /// <summary>
        /// 画像選択
        /// </summary>
        /// <returns>ファイルパス</returns>
        public static string ImageFileSelect()
        {
            var filePath = String.Empty;
            // ファイル選択
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // カレントディレクトリをbinフォルダの親フォルダまでさかのぼる
            var iniPath  = ImageFileManager.ExtractBinPath(Directory.GetCurrentDirectory());
            if (!string.IsNullOrEmpty(iniPath))
            {
                openFileDialog.InitialDirectory = iniPath;
            }
            openFileDialog.Filter = CreateFileFilter(new FileFilter[] { FileFilter.png, FileFilter.bmp, FileFilter.jpg });
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }

            return filePath;
        }

        /// <summary>
        /// 画像保存
        /// </summary>
        /// <param name="saveImage">保存画像</param>
        /// <returns>実行結果</returns>
        public static bool ImageFileSave(Bitmap saveImage)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = CreateFileFilter(new FileFilter[] { FileFilter.bmp });
            saveFileDialog.CheckFileExists = true;
            saveFileDialog.CheckPathExists = true;
            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                saveImage.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                return true;
            }
            else 
            { 
                return false;
            }
        }

        /// <summary>
        /// 画像リサイズ
        /// </summary>
        /// <param name="size">希望サイズ</param>
        /// <param name="originalImage">元画像</param>
        /// <returns>リサイズ後画像</returns>
        public static Image ResizeImage(Size size, Image originalImage)
        {
            // Gurd
            if (originalImage == null) { return new Bitmap(size.Width, size.Height); }

            var newImage = new Bitmap(size.Width, size.Height);

            // Graphicsオブジェクトを作成して、新しい画像に描画
            using (Graphics g = Graphics.FromImage(newImage))
            {
                // 描画モード設定（アンチエイリアスなど）
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                // newImageをoldImageのサイズに合わせて描画
                g.DrawImage(originalImage, 0, 0, size.Width, size.Height);
            }

            return newImage;
        }

        /// <summary>
        /// ファイルフィルター設定文字列生成
        /// </summary>
        /// <param name="filerTypes">選択可能拡張子</param>
        /// <returns>フィルター文字列</returns>
        private static string CreateFileFilter(IEnumerable<FileFilter> filerTypes)
        {
            var extentions = filerTypes.
                Select(filertype => $"*.{filertype.ToString()};")
                .ToList();
            var filterString = string.Join("", extentions);

            return $"{FileFilterHeader}|{filterString}";
        }

        /// <summary>
        /// 文字列から\\binを見つけ、その後ろの部分を取得するメソッド
        /// </summary>
        /// <param name="path">検索対象のパス</param>
        /// <returns>\\bin以降の文字列</returns>
        static string ExtractBinPath(string path)
        {
            // "\\bin" の位置を探す
            int binIndex = path.IndexOf(@"\bin");

            // 見つかった場合、それより前の部分を抽出
            if (binIndex >= 0)
            {
                return path.Substring(0, binIndex);
            }
            else
            {
                // "\\bin" が見つからなければ、元のパスをそのまま返す
                return path;
            }
        }
    }
}
