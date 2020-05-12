using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFFuctionExample
{
    /// <summary>
    /// IconButton.xaml 的交互逻辑
    /// </summary>
    public partial class IconButton : UserControl,INotifyPropertyChanged
    {
        // public ImageSource IconImage { get; set; }
        //public string ButtonInfo { get; set; }
        //public ImageSource IconImage
        //{
        //    get { return (ImageSource)GetValue(IconImageProperty); }
        //    set { SetValue(IconImageProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty IconImageProperty =
        //    DependencyProperty.Register("IconImage", typeof(int), typeof(IconButton), 
        //        new FrameworkPropertyMetadata("IconImage",new PropertyChangedCallback(OnPropertChanged)));


        public string BtnInfo
        {
            get { return (string)GetValue(InfoProperty); }
            set {
                SetValue(InfoProperty, value); 
                 
            }
        }

        // Using a DependencyProperty as the backing store for Info.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InfoProperty =
            DependencyProperty.Register("BtnInfo", typeof(string), typeof(IconButton),
                new FrameworkPropertyMetadata(
                "Info", new PropertyChangedCallback(OnPropertChanged)));

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };


        private static void OnPropertChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as IconButton;
            c.Info.Text = e.NewValue as string;
        }

        public IconButton()
        {
            InitializeComponent();
            BtnInfo = "123213";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
