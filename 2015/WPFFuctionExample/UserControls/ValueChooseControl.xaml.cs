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
        public object Num
        {
            get { return GetValue(NumProperty); }
            set { SetValue(NumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumProperty = DependencyProperty.Register("Num", typeof(object), typeof(ValueChooseControl),
            new PropertyMetadata(null, new PropertyChangedCallback(OnValueChanged)));
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as ValueChooseControl;
            sender.Num = e.NewValue;
            //进行超界判断
            if (!sender.IsOverLimit())
            {                
                sender.txbInfo.Text = sender.Num.ToString();
            }
            else
            {                
                sender.Num = e.OldValue;
                MessageBox.Show(string.Format("Min:{0} Max:{1} Value:{2}", sender.MinValue.ToString(), sender.MaxValue.ToString(), e.NewValue), "超出范围!");
            }
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

        #region 取值范围       

        public object MinValue
        {
            get { return (object)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(object), typeof(ValueChooseControl), new PropertyMetadata(null,new PropertyChangedCallback(OnMinValuePropertyChanged)));

        private static void OnMinValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as ValueChooseControl;           
            sender.MinValue = sender.IsNumberic(e.NewValue.ToString())? e.NewValue:e.OldValue;
        }

        public object MaxValue
        {
            get { return GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(object), typeof(ValueChooseControl), new PropertyMetadata(null,new PropertyChangedCallback(OnMaxValuePropertyChanged)));

        private static void OnMaxValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as ValueChooseControl;
            sender.MaxValue = sender.IsNumberic(e.NewValue.ToString()) ? e.NewValue : e.OldValue;
            bool IsMax_Min = false;
            //根据进制 判断是否比 最小值大
            switch (sender.Precision)
            {
                case PrecisionType.D00001:                   
                case PrecisionType.D0001:
                    IsMax_Min = double.Parse(sender.MinValue.ToString()) < double.Parse(e.NewValue.ToString());
                    break;
                  
                case PrecisionType.F001:                   
                case PrecisionType.F01:
                    IsMax_Min = float.Parse(sender.MinValue.ToString()) < float.Parse(e.NewValue.ToString());
                    break;
                case PrecisionType.I1:                   
                case PrecisionType.I10:                 
                case PrecisionType.I100:
                    IsMax_Min = int.Parse(sender.MinValue.ToString()) < int.Parse(e.NewValue.ToString());
                    break;
            }
            sender.MaxValue = IsMax_Min ? e.NewValue : e.OldValue;
        }

        #endregion
        #endregion

        #region 构造函数
        public ValueChooseControl()
        {
            InitializeComponent();
            Init();
        }
        #endregion

        #region 部分配置的初始化设定
        private void Init()
        {
            Precision = PrecisionType.I1;
            MinValue = -1;
            MaxValue = 100000;
            Num = 0;
        }
        #endregion

        #region 触发事件
        private void btnSub_Click(object sender, RoutedEventArgs e)
        {
            if (Num != null)
            {
                Num = ChangeValue(Precision, Num.ToString(), true);                
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(Num!=null)
                Num = ChangeValue(Precision,Num.ToString(), false);
        }
        /// <summary>
        /// 检测 文本框里面内容 有没有超界
        /// </summary>
        /// <returns></returns>
        private bool IsOverLimit()
        {
            if (Num == null) return true;
            if (!IsNumberic(Num.ToString())) return true;
            bool IsLimit = false;
            //根据当前 进制 转换进行比较
            switch (Precision)
            {
                case PrecisionType.D00001:
                case PrecisionType.D0001:
                    IsLimit = (double.Parse(MinValue.ToString()) <= double.Parse( Num.ToString()) && double.Parse(Num.ToString()) <=  double.Parse(MaxValue.ToString()) );
                    break;

                case PrecisionType.F001:
                case PrecisionType.F01:
                    IsLimit = (float.Parse(MinValue.ToString()) <= float.Parse(Num.ToString()) && float.Parse(Num.ToString()) <= float.Parse(MaxValue.ToString()));
                    break;
                case PrecisionType.I1:
                case PrecisionType.I10:
                case PrecisionType.I100:
                    IsLimit = (int.Parse(MinValue.ToString()) <= int.Parse(Num.ToString()) && int.Parse(Num.ToString()) <= int.Parse(MaxValue.ToString()));
                    break;
            }

            return !IsLimit;
        }
        private void txbInfo_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Enter)
            {
                var tb = sender as TextBox;
                Num = tb.Text;
                //if (IsOverLimit())
                //{
                //    Num = 0;
                //    MessageBox.Show("超出范围!", string.Format("Min:{0} Max:{1} ", MinValue.ToString(), MaxValue.ToString()));
                //}
            }          
        }

        #endregion
    }
}
