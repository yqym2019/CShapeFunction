using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using WPFFuctionExample.ViewModel;

namespace WPFFuctionExample
{
    /// <summary>
    /// BindingExampleWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BindingExampleWindow : Window
    {
        class person
        {
           public string Name { get; set; }
           public int Age { get; set; }

            public person()
            {

            }
        }

        public BindingExampleWindow()
        {
            InitializeComponent();

            BindingExample be = new BindingExample();
            be.Name = "绑定测试";
            be.Age = 100;
            be.Height = 188;

            sp.DataContext = be;

            List<person> pList = new List<person>();
            pList.Add(new person() { Name = "测试1", Age = 123 });
            pList.Add(new person() { Name = "测试2", Age = 23 });
            pList.Add(new person() { Name = "测试3", Age = 13 });
            pList.Add(new person() { Name = "测试4", Age = 12 });

            lbx1.ItemsSource = pList; 
        }

        private void lbx1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var c = sender;
        }
    }
}
