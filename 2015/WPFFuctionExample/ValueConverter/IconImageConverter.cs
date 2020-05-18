using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using WPFFuctionExample.Function;
using WPFFuctionExample.Model;

namespace WPFFuctionExample.ValueConverter
{
    [ValueConversion(typeof(Model.IconType), typeof(BitmapImage))]
    public class IconImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = Environment.CurrentDirectory+"/../../../Icon/";
            
            switch((IconType)value)
            {
                case IconType.Icon1:
                    path += "Icon1.jpg";
                    break;
                case IconType.Icon2:
                    path += "Icon2.jpg";
                    break;
                case IconType.Icon3:
                    path += "Icon3.jpg";
                    break;
                case IconType.Save:
                    path += "Save.jpg";
                    break;
                case IconType.Open:
                    path += "Open.jpg";
                    break;
                case IconType.SaveAs:
                    path += "SaveAs.jpg";
                    break;
            }

            return ConvertHelper.ConvertImageSource(path);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
