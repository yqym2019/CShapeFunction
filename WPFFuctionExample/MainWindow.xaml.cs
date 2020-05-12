using System.Windows;
using System.Data.SQLite;
using WPFFuctionExample.Function;
using WPFFuctionExample.Test;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WPFFuctionExample.ViewModel;

namespace WPFFuctionExample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public ImageSource IconSource { get; set; }

        public string info1 { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            //sqliteTest tt = new sqliteTest();
            this.DataContext = new MenuItemViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            iBtn.BtnInfo = "改变属性";            
        }
    }
}
