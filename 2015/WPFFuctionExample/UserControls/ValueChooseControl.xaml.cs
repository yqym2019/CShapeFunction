using System;
using System.ComponentModel;
using System.Runtime.Remoting.Channels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using WPFFuctionExample.Model;

namespace WPFFuctionExample.UserControls
{
    /// <summary>
    /// ValueChooseControl.xaml 的交互逻辑
    /// </summary>
    public partial class ValueChooseControl : UserControl
    {         
        #region 通用方法

        /// <summary>
        /// 判别字符串是否是一个数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsNumberic(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$"); //Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }

        /// <summary>
        /// 判别字符串是否是一个整数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*$");
        }

        /// <summary>
        /// 根据对应精度 来 增减数值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string ChangeValue(PrecisionType type,string value,bool IsAdd)
        {
            //1.判别是不是个数值
            bool IsNum = IsNumberic(value);
            string result = null;
            if(IsNum)
            {
                switch(type)
                {
                    case PrecisionType.D00001:
                        double d = double.Parse(value);
                        result = IsAdd==true? (d + 0.0001).ToString("0.0000"): (d - 0.0001).ToString("0.0000");
                        break;
                    case PrecisionType.D0001:
                        double d2 = double.Parse(value);
                        result = IsAdd == true ? (d2 + 0.001).ToString("0.000"): (d2 - 0.001).ToString("0.000");
                        break;
                    case PrecisionType.F001:
                        float f1 = float.Parse(value);
                        result = IsAdd == true ? (f1 + 0.01).ToString("0.00") : (f1 - 0.01).ToString("0.00");
                        break;
                    case PrecisionType.F01:
                        float f2 = float.Parse(value);
                        result = IsAdd == true ? (f2 + 0.1).ToString("0.0"): (f2 - 0.1).ToString("0.0");
                        break;
                    case PrecisionType.I1:
                        int i1 = int.Parse(value);
                        result = IsAdd == true ? (++i1).ToString():(--i1).ToString();
                        break;
                    case PrecisionType.I10:
                        int i2 = int.Parse(value);
                        result = IsAdd == true ? (i2 + 10).ToString(): (i2 - 10).ToString();
                        break;
                    case PrecisionType.I100:
                        int i3 = int.Parse(value);
                        result = IsAdd == true ? (i3 + 100).ToString(): (i3 - 100).ToString();
                        break;              
                }
            }
            else
            {
                MessageBox.Show("非数值,无法增减!");
                Num = "10";
            }

            return result;
        }
        #endregion

        #region 依赖属性
        #region 当前参数
        /// <summary>
        /// 当前参数
        /// </summary>
        public string Num
        {
            get { return (string)GetValue(NumProperty); }
            set { SetValue(NumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumProperty = DependencyProperty.Register("Num", typeof(string), typeof(ValueChooseControl),
            new PropertyMetadata(null, new PropertyChangedCallback(OnValueChanged)));
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as ValueChooseControl;
            sender.Num = (string)e.NewValue;
            sender.txbInfo.Text = sender.Num.ToString();
        }
        #endregion

        #region 精度单位
        /// <summary>
        /// 精度单位 设定 属性
        /// </summary>
        public PrecisionType Precision
        {
            get { return (PrecisionType)GetValue(PrecisionProperty); }
            set { SetValue(PrecisionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PrecisionProperty =
            DependencyProperty.Register("Precision", typeof(PrecisionType), typeof(ValueChooseControl),
                new PropertyMetadata(null));

        private static void OnPrecisionTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }
        #endregion

        #region 默认值
        /*
        public string DefaultValue
        {
            get { return (string)GetValue(DefaultValueProperty); }
            set { SetValue(DefaultValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DefaultValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DefaultValueProperty =
            DependencyProperty.Register("DefaultValue", typeof(string), typeof(ValueChooseControl),
                new PropertyMetadata(null, new PropertyChangedCallback(OnDefaultValueChanged)));

        private static void OnDefaultValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //判别是否默认值设置的不是个数字
            var sender = d as ValueChooseControl;
            string str = sender.DefaultValue;
            if(sender.IsNumberic(str))
            {
                ValueChooseControl.defaultValue = str;
            }
        }
        */

        #endregion
            
        #region Width Height 等比缩放
        public int UCWidth
        {
            get { return (int)GetValue(UCWidthProperty); }
            set { SetValue(UCWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UCWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UCWidthProperty =
            DependencyProperty.Register("UCWidth", typeof(int), typeof(ValueChooseControl), new PropertyMetadata(70,new PropertyChangedCallback(OnWidthChanged)));

        private static void OnWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as ValueChooseControl;            
            int w = (int)e.NewValue;
            // sender.Width = int.Parse((string)e.NewValue);
            sender.UCWidth = w;
            sender.txbInfo.Width = w * 5 / 7;
            sender.Width = w;
        }

        public int UCHeight
        {
            get { return (int)GetValue(UCHeightProperty); }
            set { SetValue(UCHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UCHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UCHeightProperty =
            DependencyProperty.Register("UCHeight", typeof(int), typeof(ValueChooseControl), new PropertyMetadata(30,new PropertyChangedCallback(OnHeightChanged)));

        private static void OnHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as ValueChooseControl;         
            int h = (int)e.NewValue;
            // sender.Width = int.Parse((string)e.NewValue);
            sender.UCHeight = h;
            sender.txbInfo.Height = h * 5 / 7;
            sender.Height = h;
        }


        #endregion

        #endregion

        #region 构造函数
        public ValueChooseControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 触发事件
        private void btnSub_Click(object sender, RoutedEventArgs e)
        {
            if(Num!=null)
                Num = ChangeValue(Precision,Num, true);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(Num!=null)
                Num = ChangeValue(Precision,Num, false);
        }
        #endregion
    }
}
