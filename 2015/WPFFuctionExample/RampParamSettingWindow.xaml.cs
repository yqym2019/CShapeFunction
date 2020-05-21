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
using System.Windows.Shapes;
using WPFFuctionExample.Services;

namespace WPFFuctionExample
{
    /// <summary>
    /// Interaction logic for RampParamSetting.xaml
    /// </summary>
    public partial class RampParamSettingWindow : Window
    {
        private string _selectValue = "";
        private List<string> RampParamSettings { get; set; }
        public Dictionary<string, RampParamter> RampParamSettingDicts { get; set; }
        RampParamter rp = new RampParamter();
        public RampParamSettingWindow()
        {
            InitializeComponent();           
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {            
            string startV = tbxStart.Text.ToString().Trim();
            string stopV = tbxStop.Text.ToString().Trim();
            string stepV = tbxStep.Text.ToString().Trim();
            rp.Start_V = int.Parse(startV);
            rp.Stop_V = int.Parse(stopV);
            rp.Step_V = int.Parse(stepV);

            this.DialogResult = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IDataService dataS = new XmlDataService();
            RampParamSettings = dataS.GetAllType(Model.LanguageType.en, Model.UIConfigType.RampParameterSettings);
            cbxParam.ItemsSource = RampParamSettings;
            RampParamSettingDicts = new Dictionary<string, RampParamter>();
            RampParamSettings.ForEach(
                para =>
                {
                    RampParamSettingDicts.Add(para, new RampParamter() {
                        Start_V = -400,
                        Stop_V = 0,
                        Step_V =1
                    });
                }
                );
            cbxParam.SelectedIndex = 0;
        }

        private void cbxParam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var c = sender as ComboBox;
            var item = c.SelectedValue;
            _selectValue = item as string;

            if(_selectValue == "None")
            {
                tbxStart.IsEnabled = false;
                tbxStop.IsEnabled = false;
                tbxStep.IsEnabled = false;
            }
            else
            {
                tbxStart.IsEnabled = true;
                tbxStop.IsEnabled = true;
                tbxStep.IsEnabled = true;
                bool b = RampParamSettingDicts.TryGetValue(_selectValue, out rp);
                if (b)
                {
                    tbxStart.Text = rp.Start_V.ToString();
                    tbxStop.Text = rp.Stop_V.ToString();
                    tbxStep.Text = rp.Step_V.ToString();
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }

    public class RampParamter
    {
        public int Start_V { get; set; }
        public int Stop_V { get; set; }
        public int Step_V { get; set; }
    }
}
