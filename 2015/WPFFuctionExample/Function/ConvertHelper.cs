using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPFFuctionExample.Function
{
    public class ConvertHelper
    {
        /// <summary>
        /// 通过文件路径获取图片
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static BitmapImage ConvertImageSource(string path)
        {
            //判别是否存在这文件信息
            FileInfo fInfo;
            bool b = IOFileHelper.ReadFileInfo(path,out fInfo);
            if(!b)
            {
                return null;
            }

            if(! IOFileHelper.IsPicture(path) )
            {
                return null;
            }
           
            BitmapImage bi = new BitmapImage(new System.Uri(path, System.UriKind.RelativeOrAbsolute));
            return bi;
        }

        /// <summary>
        /// 转换Bitmap 到 图片源
        /// </summary>
        /// <param name="bp">Bitmap图片</param>
        /// <returns></returns>
        public static BitmapImage ConvertImageSource(Bitmap bp)
        {
            if (bp == null) return null;

            MemoryStream stream = new MemoryStream();
            bp.Save(stream, ImageFormat.Png);
            ImageBrush brush = new ImageBrush();
            ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
            var bi = imageSourceConverter.ConvertFrom(stream) as BitmapImage;
            return bi;
        }
    }
}
