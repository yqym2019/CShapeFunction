using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFFuctionExample.ViewModel;

namespace WPFFuctionExample
{
    /// <summary>
    /// TunePage.xaml 的交互逻辑
    /// </summary>
    public partial class TunePage : Page
    {
        private TunePageViewModel vm { get; set; }
        public TunePage()
        {
            InitializeComponent();
            vm = new TunePageViewModel(this);
            this.DataContext = vm;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        #region 选中事件
        /// <summary>
        /// TabControl 标签切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tclMSSetting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source.GetType() == typeof(TabControl))
            {
                var tc = sender as TabControl;
                var item = tc.SelectedValue as TabItem;
                vm.TabItemInit(item.Header.ToString());
            }
        }

        /// <summary>
        /// 下拉框改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxGainLossOf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.Source.GetType() == typeof(ComboBox))
            {
                var c = sender as ComboBox;
                var item = c.SelectedValue;
                vm.LossGainOfSelectionChanged(item);
                //禁止路由上传
                e.Handled = true;
            }            
        }

        /// <summary>
        /// 下拉框改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxScanMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source.GetType() == typeof(ComboBox))
            {
                var c = sender as ComboBox;
                var item = c.SelectedValue;
                vm.ScanModeSelectionChanged(item);
                //禁止路由上传 标记为已处理
                e.Handled = true;
            }              
        }

        /// <summary>
        /// 下拉框改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxScanType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source.GetType() == typeof(ComboBox))
            {
                var c = sender as ComboBox;
                var item = c.SelectedValue;
                vm.ScanTypeSelectionChanged(item);
                //禁止路由上传
                e.Handled = true;
            }                
        }
        #endregion
    }
}
