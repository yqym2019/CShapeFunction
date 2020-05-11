using System.Windows;
using System.Data.SQLite;
using WPFFuctionExample.Function;
using WPFFuctionExample.Test;

namespace WPFFuctionExample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            sqliteTest tt = new sqliteTest();
          
        }
    }
}
