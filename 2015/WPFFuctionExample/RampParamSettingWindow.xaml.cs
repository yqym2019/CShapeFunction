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
        private List<string> rampParamSettings;

        public List<string> RampParamSettings
        {
            get { return rampParamSettings; }
            set { rampParamSettings = value; }
        }
        public RampParamSettingWindow()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {         
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IDataService dataS = new XmlDataService();
            RampParamSettings = dataS.GetAllType(Model.LanguageType.en, Model.UIConfigType.RampParameterSettings);
            cbxParam.ItemsSource = RampParamSettings;
        }
    }
}
