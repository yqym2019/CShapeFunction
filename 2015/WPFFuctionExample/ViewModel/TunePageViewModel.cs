using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFFuctionExample.Command;
using WPFFuctionExample.Services;

namespace WPFFuctionExample.ViewModel
{
    /// <summary>
    /// Tune Page 视图模型
    /// </summary>
    public class TunePageViewModel:VMNotifyChanged
    {
        #region 界面属性
        #region Source/Gas
        private int cad;
        /// <summary>
        /// 碰撞气
        /// </summary>
        public int CAD
        {
            get { return cad; }
            set { Set(ref cad, value); }
        }

        private int cur;
        /// <summary>
        /// 气帘气
        /// </summary>
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
        /// <summary>
        /// 喷雾气
        /// </summary>
        public int GS1
        {
            get { return gs1; }
            set { Set(ref gs1, value); }
        }

        private int gs2;
        /// <summary>
        /// 辅助加热气
        /// </summary>
        public int GS2
        {
            get { return gs2; }
            set { Set(ref gs2, value); }
        }

        private float iS;
        /// <summary>
        /// 喷雾针高压
        /// </summary>
        public float IS
        {
            get { return iS; }
            set { Set(ref iS, value); }
        }

        private float tem;
        /// <summary>
        /// 温度
        /// </summary>
        public float TEM
        {
            get { return tem; }
            set { Set(ref tem, value); }
        }
        #endregion

        #region Compound
        private float dp;
        /// <summary>
        /// 解离电位
        /// </summary>
        public float DP
        {
            get { return dp; }
            set { Set(ref dp, value); }
        }

        private float ep;
        /// <summary>
        /// 入口电位
        /// </summary>
        public float EP
        {
            get { return ep; }
            set { Set(ref ep, value); }
        }

        #endregion

        #region Resolution
        private float ie1;
        /// <summary>
        /// Q1 电位
        /// </summary>
        public float IE1
        {
            get { return ie1; }
            set { Set(ref ie1, value); }
        }

        private List<string> resolution;
        /// <summary>
        /// 分辨率 数据列表
        /// </summary>
        public List<string> Resolution
        {
            get { return resolution; }
            set { Set(ref resolution, value); }
        }

        private float ie3;

        public float IE3
        {
            get { return ie3; }
            set { Set(ref ie3, value); }
        }

        private string ie1ResolutionValue;
        /// <summary>
        /// Q1 的分辨率 下拉框选中项
        /// </summary>
        public string IE1ResolutionValue
        {
            get { return ie1ResolutionValue; }
            set { Set(ref ie1ResolutionValue, value); }
        }

        private string ie3ResolutionValue;
        /// <summary>
        /// Q3 的分辨率 下拉框选中项
        /// </summary>
        public string IE3ResolutionValue
        {
            get { return ie3ResolutionValue; }
            set { Set(ref ie3ResolutionValue, value); }
        }

        #endregion

        #region Detector
        private float cem;
        /// <summary>
        /// 检测器高压
        /// </summary>
        public float CEM
        {
            get { return cem; }
            set { Set(ref cem, value); }
        }

        private float df;

        public float DF
        {
            get { return df; }
            set { Set(ref df, value); }
        }

        #endregion

        #region MS
        private List<string> scanTypeList;
        /// <summary>
        /// 扫描类别 数据列表
        /// </summary>
        public List<string> ScanTypeList
        {
            get { return scanTypeList; }
            set { Set(ref scanTypeList, value); }
        }
        private List<Action> ScanTypeActionList { get; set; }
        private double duration;
        /// <summary>
        /// 执行间隔 (min)
        /// </summary>
        public double Duration
        {
            get { return duration; }
            set { Set(ref duration, value); }
        }

        private int delayTime;
        /// <summary>
        /// 延时时间 (sec)
        /// </summary>
        public int DelayTime
        {
            get { return delayTime; }
            set { Set(ref delayTime, value); }
        }

        private int cycles;
        /// <summary>
        /// 执行周期
        /// </summary>
        public int Cycles
        {
            get { return cycles; }
            set { Set(ref cycles, value); }
        }

        private double totalScanTime;
        /// <summary>
        /// 总检测时间
        /// </summary>
        public double TotalScanTime
        {
            get { return totalScanTime; }
            set { Set(ref totalScanTime, value); }
        }

        private List<string> gainLossOfList;

        public List<string> GainLossOfList
        {
            get { return gainLossOfList; }
            set { Set(ref gainLossOfList, value); }
        }

        #endregion

        #region Advanced MS
        private List<string> scanModeList;
        /// <summary>
        /// 扫描模式列表
        /// </summary>
        public List<string> ScanModeList
        {
            get { return scanModeList; }
            set { Set(ref scanModeList, value); }
        }

        private float stepSize;
        /// <summary>
        /// 步长
        /// </summary>
        public float StepSize
        {
            get { return stepSize; }
            set { Set(ref stepSize, value); }
        }

        private int intensityThreshold;
        /// <summary>
        /// 强度阈值
        /// </summary>
        public int IntensityThreshold
        {
            get { return intensityThreshold; }
            set { Set(ref intensityThreshold, value); }
        }

        private int settingTime;
        /// <summary>
        /// 设置时间 (ms
        /// </summary>
        public int SettingTime
        {
            get { return settingTime; }
            set { Set(ref settingTime, value); }
        }

        private double mrPauseTime;
        /// <summary>
        /// 质量间隔之间的暂停时间 (ms
        /// </summary>
        public double MRPauseTime
        {
            get { return mrPauseTime; }
            set { Set(ref mrPauseTime, value); }
        }

        #endregion

        #region else
        private string languageTipInfo;
        /// <summary>
        /// 语言切换按钮 显示语
        /// </summary>
        public string LanguageTipInfo
        {
            get { return languageTipInfo; }
            set { Set(ref languageTipInfo, value); }
        }

        private List<string> rampParamSettings;

        public List<string> RampParamSettings
        {
            get { return rampParamSettings; }
            set { Set(ref rampParamSettings, value); }
        }

        #endregion

        #endregion

        #region Command
        public ICommand LanguageChangedCommand{ get; set; }
        public ICommand IHEOffCommand { get; set; }
        public ICommand IHEOnCommand { get; set; }
        public ICommand EditRampParamSettingCommand { get; set; }
        public ICommand ScanTypeCommand { get; set; }

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
        /// <summary>
        /// 编辑属性设置的窗口事件
        /// </summary>
        /// <param name="param"></param>
        private void EditRampParamSetting(object param)
        {
            RampParamSettingWindow rpsw = new RampParamSettingWindow();
            bool? b = rpsw.ShowDialog();
            if(b??true)
            {

            }
        }
        /// <summary>
        /// 选择类别的选项变更事件
        /// </summary>
        /// <param name="param"></param>
        private void ScanTypeSelectionChanged(object param)
        {
            //比对传入的属性 看是那个被选中了 改变页面
            int sIndex = (int)param;
            if(sIndex>=0)
                ScanTypeActionList[(int)param]();
        }

        private void AllVisibility()
        {
            _page.wplCAD.Visibility = Visibility.Visible;
            _page.wplRO2.Visibility = Visibility.Visible;
            _page.wplCE.Visibility = Visibility.Visible;
            _page.wplCXP.Visibility = Visibility.Visible;
            _page.gbxQuad1.Visibility = Visibility.Visible;
            _page.gbxQuad3.Visibility = Visibility.Visible;
            _page.wplLossGain.Visibility = Visibility.Visible;
            _page.wplPrec.Visibility = Visibility.Visible;
            _page.wplProduct.Visibility = Visibility.Visible;
        }

        private void HideThreeCompound()
        {
            _page.wplRO2.Visibility = Visibility.Collapsed;
            _page.wplCXP.Visibility = Visibility.Collapsed;
            _page.wplCE.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// 隐藏 Loss/GainOf PreOf / ProductOf
        /// </summary>
        private void HideThreeValueOf()
        {
            _page.wplLossGain.Visibility = Visibility.Hidden;
            _page.wplPrec.Visibility = Visibility.Hidden;
            _page.wplProduct.Visibility = Visibility.Hidden;
        }

        private List<Action> ScanTypeActionInit()
        {
            List<Action> stActionList = new List<Action>()
            {
                {
                    ()=>
                    {
                       AllVisibility();
                       _page.wplRO2.Visibility = Visibility.Collapsed;
                       HideThreeValueOf();                      
                    }
                },
                {
                    ()=>
                    {
                       _page.wplCAD.Visibility = Visibility.Visible;
                       _page.wplRO2.Visibility = Visibility.Collapsed;
                       _page.wplCE.Visibility = Visibility.Visible;
                       _page.wplCXP.Visibility = Visibility.Visible;
                       _page.gbxQuad1.Visibility = Visibility.Visible;
                       _page.gbxQuad3.Visibility = Visibility.Visible;
                    }
                },
                 {
                    ()=>
                    {
                       _page.wplCAD.Visibility = Visibility.Visible;
                       _page.wplRO2.Visibility = Visibility.Collapsed;
                       _page.wplCE.Visibility = Visibility.Visible;
                       _page.wplCXP.Visibility = Visibility.Visible;
                       _page.gbxQuad1.Visibility = Visibility.Visible;
                       _page.gbxQuad3.Visibility = Visibility.Visible;
                    }
                },
                  {
                    ()=>
                    {
                       _page.wplCAD.Visibility = Visibility.Visible;
                       _page.wplRO2.Visibility = Visibility.Collapsed;
                       _page.wplCE.Visibility = Visibility.Visible;
                       _page.wplCXP.Visibility = Visibility.Visible;
                       _page.gbxQuad1.Visibility = Visibility.Visible;
                       _page.gbxQuad3.Visibility = Visibility.Visible;
                    }
                },
                   {
                    ()=>
                    {
                       _page.wplCAD.Visibility = Visibility.Visible;
                       _page.wplRO2.Visibility = Visibility.Collapsed;
                       _page.wplCE.Visibility = Visibility.Visible;
                       _page.wplCXP.Visibility = Visibility.Visible;
                       _page.gbxQuad1.Visibility = Visibility.Visible;
                       _page.gbxQuad3.Visibility = Visibility.Visible;
                    }
                },
                    {
                    ()=>
                    {
                       _page.wplCAD.Visibility = Visibility.Visible;
                       _page.wplRO2.Visibility = Visibility.Collapsed;
                       _page.wplCE.Visibility = Visibility.Visible;
                       _page.wplCXP.Visibility = Visibility.Visible;
                       _page.gbxQuad1.Visibility = Visibility.Visible;
                       _page.gbxQuad3.Visibility = Visibility.Visible;
                    }
                },
                     {
                    ()=>
                    {
                       _page.wplCAD.Visibility = Visibility.Visible;
                       _page.wplRO2.Visibility = Visibility.Collapsed;
                       _page.wplCE.Visibility = Visibility.Visible;
                       _page.wplCXP.Visibility = Visibility.Visible;
                       _page.gbxQuad1.Visibility = Visibility.Visible;
                       _page.gbxQuad3.Visibility = Visibility.Visible;
                    }
                },
                      {
                    ()=>
                    {
                       _page.wplCAD.Visibility = Visibility.Visible;
                       _page.wplRO2.Visibility = Visibility.Collapsed;
                       _page.wplCE.Visibility = Visibility.Visible;
                       _page.wplCXP.Visibility = Visibility.Visible;
                       _page.gbxQuad1.Visibility = Visibility.Visible;
                       _page.gbxQuad3.Visibility = Visibility.Visible;
                    }
                },
            };
            return stActionList;
        }
        #endregion

        #endregion

        #region 构造函数
        private TunePage _page { get; set; }
        public TunePageViewModel(Page page)
        {
            this._page = page as TunePage;
            languageTipInfo = "English";
            LanguageChangedCommand = new BaseCommand(ChangeLanguage);
            IHEOffCommand = new BaseCommand(IHEOff);
            IHEOnCommand = new BaseCommand(IHEOn);
            EditRampParamSettingCommand = new BaseCommand(EditRampParamSetting);
            ScanTypeCommand = new BaseCommand(ScanTypeSelectionChanged);
            ScanTypeActionList = ScanTypeActionInit();
            LoadData();
        }
        #endregion

        #region 数据加载
        private void LoadData()
        {
            IDataService dataS = new XmlDataService();
            ScanTypeList = dataS.GetAllType(Model.LanguageType.en, Model.UIConfigType.ScanType);
            Resolution = dataS.GetAllType(Model.LanguageType.en, Model.UIConfigType.Resolution);
            ScanModeList = dataS.GetAllType(Model.LanguageType.en, Model.UIConfigType.ScanMode);
            GainLossOfList = dataS.GetAllType(Model.LanguageType.en, Model.UIConfigType.MS_OffSet);
            RampParamSettings = dataS.GetAllType(Model.LanguageType.en, Model.UIConfigType.RampParameterSettings);
        }
        #endregion
    }
}
