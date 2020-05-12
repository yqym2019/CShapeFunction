using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WPFFuctionExample.Function;

namespace WPFFuctionExample.ValueConverter
{
    /// <summary>
    /// 通过string传入图片路径 返回图片
    /// </summary>
    [ValueConversion(typeof(string),typeof(ImageBrush))]
    public class ImageConverter : IValueConverter
    {
        public static ImageConverter Instance = new ImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //得到真正的地址
            string path = Environment.CurrentDirectory+"/../../.." + value.ToString();

            BitmapImage bi = ConvertHelper.ConvertImageSource(path);
            return bi;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
