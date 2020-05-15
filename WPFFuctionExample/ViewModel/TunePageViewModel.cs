using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFFuctionExample.Command;

namespace WPFFuctionExample.ViewModel
{
    /// <summary>
    /// Tune Page 视图模型
    /// </summary>
    public class TunePageViewModel:VMNotifyChanged
    {
        #region 属性
        private int cur;

        public int CUR
        {
            get { 
                return cur; 
            }
            set {
                Set(ref cur, value); 
            }
        }

        private int gs1;

        public int GS1
        {
            get { return gs1; }
            set { Set(ref gs1, value); }
        }

        private int gs2;

        public int GS2
        {
            get { return gs2; }
            set { Set(ref gs2, value); }
        }

        private float iS;

        public float IS
        {
            get { return iS; }
            set { Set(ref iS, value); }
        }

        private float tem;

        public float TEM
        {
            get { return tem; }
            set { Set(ref tem, value); }
        }

        private string languageTipInfo;

        public string LanguageTipInfo
        {
            get { return languageTipInfo; }
            set { Set(ref languageTipInfo, value); }
        }

        #endregion

        #region Command
        public ICommand LanguageChangedCommand{ get; set; }
        public ICommand IHEOffCommand { get; set; }
        public ICommand IHEOnCommand { get; set; }

        #region 对应方法
        private void ChangeLanguage(object IsZh)
        {
            List<ResourceDictionary> dictionaryList = new List<ResourceDictionary>();
            foreach (ResourceDictionary dictionary in Application.Current.Resources.MergedDictionaries)
            {
                dictionaryList.Add(dictionary);
            }
            string requestedCulture = (bool)IsZh? @"Resources/zh-cn.xaml": @"Resources/en-us.xaml";
            LanguageTipInfo = (bool)IsZh ? "English" : "中文";
            ResourceDictionary resourceDictionary = dictionaryList.FirstOrDefault(d => d.Source.OriginalString.Equals(requestedCulture));
            Application.Current.Resources.MergedDictionaries.Remove(resourceDictionary);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void IHEOff(object param)
        {

        }

        private void IHEOn(object param)
        {

        }
        #endregion

        #endregion

        #region 构造函数
        public TunePageViewModel()
        {
            languageTipInfo = "English";
            LanguageChangedCommand = new BaseCommand(ChangeLanguage);
            IHEOffCommand = new BaseCommand(IHEOff);
            IHEOnCommand = new BaseCommand(IHEOn);
        }
        #endregion
    }
}
