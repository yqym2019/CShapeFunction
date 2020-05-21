using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFFuctionExample.Command;
using WPFFuctionExample.Model;
using WPFFuctionExample.Services;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;

namespace WPFFuctionExample.ViewModel
{
    /// <summary>
    /// Tune Page 视图模型
    /// </summary>
    public class TunePageViewModel:VMNotifyChanged
    {
        #region 界面属性
        #region Source/Gas
        private int cad = 4;
        /// <summary>
        /// 碰撞气
        /// </summary>
        public int CAD
        {
            get { return cad; }
            set { Set(ref cad, value); }
        }

        private int cur = 10;
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

        private int gs1 = 20;
        /// <summary>
        /// 喷雾气
        /// </summary>
        public int GS1
        {
            get { return gs1; }
            set { Set(ref gs1, value); }
        }

        private int gs2 = 0;
        /// <summary>
        /// 辅助加热气
        /// </summary>
        public int GS2
        {
            get { return gs2; }
            set { Set(ref gs2, value); }
        }

        private float iS = -4200;
        /// <summary>
        /// 喷雾针高压
        /// </summary>
        public float IS
        {
            get { return iS; }
            set { Set(ref iS, value); }
        }

        private float tem = 0.0F;
        /// <summary>
        /// 温度
        /// </summary>
        public float TEM
        {
            get { return tem; }
            set { Set(ref tem, value); }
        }
        private Visibility cadVisibility = Visibility.Visible;

        public Visibility CADVisibility
        {
            get { return cadVisibility; }
            set { Set(ref cadVisibility, value); }
        }

        #endregion

        #region Compound
        private float dp = 20.0F;
        /// <summary>
        /// 解离电位
        /// </summary>
        public float DP
        {
            get { return dp; }
            set { Set(ref dp, value); }
        }

        private float ep = 35.0F;
        /// <summary>
        /// 入口电位
        /// </summary>
        public float EP
        {
            get { return ep; }
            set { Set(ref ep, value); }
        }

        private float ro2 = 20.0F;
        public float RO2
        {
            get { return ro2; }
            set { Set(ref ro2, value); }
        }

        private float ce = 30.0F;
        public float CE
        {
            get { return ce; }
            set { Set(ref ce, value); }
        }

        private float cxp = -15.0F;
        public float CXP
        {
            get { return cxp; }
            set { Set(ref cxp, value); }
        }

        #region 可视属性
        private Visibility ro2Visibility = Visibility.Collapsed;

        public Visibility RO2Visibility
        {
            get { return ro2Visibility; }
            set { Set(ref ro2Visibility, value); }
        }

        private Visibility ceVisibility = Visibility.Visible;

        public Visibility CEVisibility
        {
            get { return ceVisibility; }
            set { Set(ref ceVisibility, value); }
        }

        private Visibility cxpVisibility = Visibility.Visible;

        public Visibility CXPVisibility
        {
            get { return cxpVisibility; }
            set { Set(ref cxpVisibility, value); }
        }
        #endregion

        #endregion

        #region Resolution
        private float ie1 = 0.8F;
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

        private float ie3 = 0.8F;

        public float IE3
        {
            get { return ie3; }
            set { Set(ref ie3, value); }
        }

        private string ie1ResolutionValue = "Low";
        /// <summary>
        /// Q1 的分辨率 下拉框选中项
        /// </summary>
        public string IE1ResolutionValue
        {
            get { return ie1ResolutionValue; }
            set { Set(ref ie1ResolutionValue, value); }
        }

        private string ie3ResolutionValue = "Low";
        /// <summary>
        /// Q3 的分辨率 下拉框选中项
        /// </summary>
        public string IE3ResolutionValue
        {
            get { return ie3ResolutionValue; }
            set { Set(ref ie3ResolutionValue, value); }
        }
        #region 可视属性
        private Visibility quad1Visibility = Visibility.Visible;

        public Visibility Quad1Visibility
        {
            get { return quad1Visibility; }
            set { Set(ref quad1Visibility, value); }
        }

        private Visibility quad3Visibility = Visibility.Visible;

        public Visibility Quad3Visibility
        {
            get { return quad3Visibility; }
            set { Set(ref quad3Visibility, value); }
        }
        #endregion
        #endregion

        #region Detector
        private float cem = 2200.0F;
        /// <summary>
        /// 检测器高压
        /// </summary>
        public float CEM
        {
            get { return cem; }
            set { Set(ref cem, value); }
        }

        private float df = -100.0F;

        public float DF
        {
            get { return df; }
            set { Set(ref df, value); }
        }

        #endregion

        #region MS
        #region 基础属性
        private double gainOfValue = 30.000;
        public double GainOfValue
        {
            get { return gainOfValue; }
            set { Set(ref gainOfValue, value); }
        }

        private double lossOfValue = 30.000;
        public double LossOfValue
        {
            get { return lossOfValue; }
            set { Set(ref lossOfValue, value); }
        }

        private double productOfValue = 30.000;
        public double ProductOfValue
        {
            get { return productOfValue; }
            set { Set(ref productOfValue, value); }
        }

        private double precursorOfValue = 30.000;
        public double PrecursorOfValue
        {
            get { return precursorOfValue; }
            set { Set(ref precursorOfValue, value); }
        }

        private double duration = 0.000;
        /// <summary>
        /// 执行间隔 (min)
        /// </summary>
        public double Duration
        {
            get { return duration; }
            set { Set(ref duration, value); }
        }

        private int delayTime = 0;
        /// <summary>
        /// 延时时间 (sec)
        /// </summary>
        public int DelayTime
        {
            get { return delayTime; }
            set { Set(ref delayTime, value); }
        }

        private int cycles = 0;
        /// <summary>
        /// 执行周期
        /// </summary>
        public int Cycles
        {
            get { return cycles; }
            set { Set(ref cycles, value); }
        }

        private double totalScanTime = 0.000;
        /// <summary>
        /// 总检测时间
        /// </summary>
        public double TotalScanTime
        {
            get { return totalScanTime; }
            set { Set(ref totalScanTime, value); }
        }

        private string ScanTypeSelectedValue { get; set; }
        #endregion
        #region 可视属性 & 数据集 & 方法集
        private List<string> scanTypeList;
        /// <summary>
        /// 扫描类别 数据列表
        /// </summary>
        public List<string> ScanTypeList
        {
            get { return scanTypeList; }
            set { Set(ref scanTypeList, value); }
        }

        private List<string> gainLossOfList;
        public List<string> GainLossOfList
        {
            get { return gainLossOfList; }
            set { Set(ref gainLossOfList, value); }
        }

        private Visibility precVisibility;
        public Visibility PrecVisibility
        {
            get { return precVisibility; }
            set { Set(ref precVisibility, value); }
        }

        private Visibility productVisibility;
        public Visibility ProductVisibility
        {
            get { return productVisibility; }
            set { Set(ref productVisibility, value); }
        }

        //Loss Gain of value 部分
        private Visibility lossGainVisibility;
        public Visibility LossGainVisibility 
        {
            get { return lossGainVisibility; }
            set { Set(ref lossGainVisibility, value); }
        }

        private Visibility lossOfVisibility;
        public Visibility tbxLossOfVisibility
        {
            get { return lossOfVisibility; }
            set { Set(ref lossOfVisibility, value); }
        }

        private Visibility gainOfVisibility;
        public Visibility tbxGainOfVisibility
        {
            get { return gainOfVisibility; }
            set { Set(ref gainOfVisibility, value); }
        }

        private Visibility _splSMRMVisibilty;
        public Visibility splSMRMVisibility
        {
            get { return _splSMRMVisibilty; }
            set { Set(ref _splSMRMVisibilty, value); }
        }

        private Visibility _splMSSet1Visbility;
        public Visibility splMSSet1Visibility
        {
            get { return _splMSSet1Visbility; }
            set { Set(ref _splMSSet1Visbility, value); }
        }

        #endregion

        #endregion

        #region Advanced MS

        private float stepSize = 0.1F;
        /// <summary>
        /// 步长
        /// </summary>
        public float StepSize
        {
            get { return stepSize; }
            set { Set(ref stepSize, value); }
        }

        private int intensityThreshold = 0;
        /// <summary>
        /// 强度阈值
        /// </summary>
        public int IntensityThreshold
        {
            get { return intensityThreshold; }
            set { Set(ref intensityThreshold, value); }
        }

        private int settingTime = 0;
        /// <summary>
        /// 设置时间 (ms
        /// </summary>
        public int SettingTime
        {
            get { return settingTime; }
            set { Set(ref settingTime, value); }
        }

        private double mrPauseTime = 5.007;
        /// <summary>
        /// 质量间隔之间的暂停时间 (ms
        /// </summary>
        public double MRPauseTime
        {
            get { return mrPauseTime; }
            set { Set(ref mrPauseTime, value); }
        }

        private int massDefect = 55;
        public int MassDefect
        {
            get { return massDefect; }
            set { Set(ref massDefect, value); }
        }

        private int minPeakWidth = 1;
        public int MinPeakWidth
        {
            get { return minPeakWidth; }
            set { Set(ref minPeakWidth, value); }
        }

        private int minPeakSep = 1;
        public int MinPeakSep
        {
            get { return minPeakSep; }
            set { Set(ref minPeakSep, value); }
        }

        #region 可视属性&数据集
        private List<string> scanModeList;
        /// <summary>
        /// 扫描模式列表
        /// </summary>
        public List<string> ScanModeList
        {
            get { return scanModeList; }
            set { Set(ref scanModeList, value); }
        }

        private Visibility massDefectVisibility;

        public Visibility MassDefectVisibility
        {
            get { return massDefectVisibility; }
            set { Set(ref massDefectVisibility, value); }
        }

        private Visibility minPeakSepVisibility;

        public Visibility MinPeakSepVisibility
        {
            get { return minPeakSepVisibility; }
            set { Set(ref minPeakSepVisibility, value); }
        }

        private Visibility minPeakWidthVisibility;

        public Visibility MinPeakWidthVisibility
        {
            get { return minPeakWidthVisibility; }
            set { Set(ref minPeakWidthVisibility, value); }
        }
        #endregion
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

        #endregion

        #endregion

        #region Command
        #region 声明
        public ICommand LanguageChangedCommand{ get; set; }
        public ICommand IHEOffCommand { get; set; }
        public ICommand IHEOnCommand { get; set; }
        public ICommand EditRampParamSettingCommand { get; set; }
        public ICommand PositiveCommand { get; set; }
        public ICommand NegativeCommand { get; set; }
        public ICommand StartCommand    { get; set; }
        public ICommand Center_WidthCommand { get; set; }
        public ICommand ParamRangeCommand { get; set; }
        public ICommand ScheduledMRMCommand { get; set; }
        #endregion
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
        private void PolanityChange(object IsPositive)
        {
           
        }
        /// <summary>
        /// 加热器 关
        /// </summary>
        /// <param name="param"></param>
        private void IHEOff(object param)
        {

        }
        /// <summary>
        /// 加热器 开
        /// </summary>
        /// <param name="param"></param>
        private void IHEOn(object param)
        {

        }
        /// <summary>
        /// 开启调谐 检测
        /// </summary>
        private void StartCheck()
        {

        }
        public void LossGainOfSelectionChanged(object param)
        {
            switch((string)param)
            {
                case "Loss Of":
                    tbxLossOfVisibility = Visibility.Visible;
                    tbxGainOfVisibility = Visibility.Collapsed;
                    break;
                case "Gain Of":
                    tbxLossOfVisibility = Visibility.Collapsed;
                    tbxGainOfVisibility = Visibility.Visible;
                    break;
            }
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
                var c = rpsw.RampParamSettingDicts;
            }
        }
        /// <summary>
        /// 选择类别的选项变更事件
        /// </summary>
        /// <param name="param"></param>
        public void ScanTypeSelectionChanged(object param)
        {
            //比对传入的属性 看是那个被选中了 改变页面
            ScanTypeSelectedValue = (string)param;
            switch ((string)param)
            {
                case "MRM(MRM)":
                    //MRM
                    AllVisibility();
                    RO2Visibility = Visibility.Collapsed;
                    HideThreeValueOf();
                    //构建新表
                    GenerateNewColumnsAndBindingData(_page.dgMSConfig, MRMSourceCollection, MRMColumnsDataList);
                    cbxScheMRMVisibility = Visibility.Visible;
                    cbxCW_PRVisibility = Visibility.Collapsed;
                    tbxTotalScanTimeEnabled = false;
                    break;
                case "Neutral Ion(NL)":
                    //NL
                    AllVisibility();
                    HideThreeValueOf();
                    RO2Visibility = Visibility.Collapsed;
                    LossGainVisibility = Visibility.Visible;                  
                    GenerateNewColumnsAndBindingData(_page.dgMSConfig, NLSourceCollection, NLColumnsDataList);
                    cbxScheMRMVisibility = Visibility.Collapsed;
                    cbxCW_PRVisibility = Visibility.Visible;
                    tbxTotalScanTimeEnabled = false;
                    break;
                case "Precursor Ion(Prec)":
                    //Prec
                    AllVisibility();
                    HideThreeValueOf();
                    RO2Visibility = Visibility.Collapsed;
                    PrecVisibility = Visibility.Visible;
                    GenerateNewColumnsAndBindingData(_page.dgMSConfig, PrecSourceCollection, PrecColumnsDataList);
                    cbxScheMRMVisibility = Visibility.Collapsed;                   
                    cbxCW_PRVisibility = Visibility.Visible;
                    tbxTotalScanTimeEnabled = false;
                    break;
                case "Product Ion(MS2)":
                    //MS2 Product
                    AllVisibility();
                    HideThreeValueOf();
                    RO2Visibility = Visibility.Collapsed;
                    ProductVisibility = Visibility.Visible;
                    GenerateNewColumnsAndBindingData(_page.dgMSConfig, ProductSourceCollection, ProductColumnsDataList);
                    cbxScheMRMVisibility = Visibility.Collapsed;
                    cbxCW_PRVisibility = Visibility.Visible;
                    tbxTotalScanTimeEnabled = false;
                    break;
                case "Q1 MS(Q1)":
                    //Q1
                    AllVisibility();
                    HideThreeCompound();
                    HideThreeValueOf();
                    CADVisibility = Visibility.Collapsed;
                    Quad3Visibility = Visibility.Collapsed;
                    GenerateNewColumnsAndBindingData(_page.dgMSConfig, Q1SourceCollection, Q1ColumnsDataList);
                    cbxScheMRMVisibility = Visibility.Collapsed;
                    cbxCW_PRVisibility = Visibility.Visible;
                    tbxTotalScanTimeEnabled = false;
                    break;
                case "Q1 Multiple Ions(Q1 M1)":
                    //Q1 M1
                    AllVisibility();
                    HideThreeCompound();
                    HideThreeValueOf();
                    CADVisibility = Visibility.Collapsed;
                    Quad3Visibility = Visibility.Collapsed;
                    GenerateNewColumnsAndBindingData(_page.dgMSConfig, Q1M1SourceCollection, Q1M1ColumnsDataList);
                    cbxScheMRMVisibility = Visibility.Collapsed;
                    cbxCW_PRVisibility = Visibility.Collapsed;
                    tbxTotalScanTimeEnabled = false;
                    break;
                case "Q3 MS(Q3)":
                    //Q3
                    AllVisibility();
                    HideThreeValueOf();
                    CEVisibility = Visibility.Collapsed;
                    CADVisibility = Visibility.Collapsed;
                    Quad1Visibility = Visibility.Collapsed;
                    GenerateNewColumnsAndBindingData(_page.dgMSConfig, Q3SourceCollection, Q3ColumnsDataList);
                    cbxScheMRMVisibility = Visibility.Collapsed;
                    cbxCW_PRVisibility = Visibility.Visible;
                    tbxTotalScanTimeEnabled = false;
                    break;
                case "Q3 Multiple Ions(Q3 M1)":
                    //Q3 M1
                    AllVisibility();
                    HideThreeValueOf();
                    CEVisibility = Visibility.Collapsed;
                    CADVisibility = Visibility.Collapsed;
                    Quad1Visibility = Visibility.Collapsed;
                    GenerateNewColumnsAndBindingData(_page.dgMSConfig, Q3M1SourceCollection, Q3M1ColumnsDataList);
                    cbxScheMRMVisibility = Visibility.Collapsed;
                    cbxCW_PRVisibility = Visibility.Collapsed;
                    tbxTotalScanTimeEnabled = false;
                    break;
            }
        }
        public void ScanModeSelectionChanged(object param)
        {
            switch((string)param)
            {
                case "Profile":
                    MinPeakSepVisibility = Visibility.Hidden;
                    MinPeakWidthVisibility = Visibility.Hidden;
                    MassDefectVisibility = Visibility.Hidden;
                    break;
                case "Fast Profile":
                    MinPeakSepVisibility = Visibility.Hidden;
                    MinPeakWidthVisibility = Visibility.Hidden;
                    MassDefectVisibility = Visibility.Hidden;
                    break;
                case "Centroid":
                    MinPeakSepVisibility = Visibility.Visible;
                    MinPeakWidthVisibility = Visibility.Visible;
                    MassDefectVisibility = Visibility.Hidden;
                    break;
                case "Peak Hopping":
                    MassDefectVisibility = Visibility.Visible;
                    MinPeakSepVisibility = Visibility.Hidden;
                    MinPeakWidthVisibility = Visibility.Hidden;
                    break;
            }
        }
        /// <summary>
        /// 显示手动调谐左右面板上 大部分元素
        /// </summary>
        private void AllVisibility()
        {
            CADVisibility = Visibility.Visible;
            RO2Visibility = Visibility.Visible;
            CEVisibility = Visibility.Visible;
            CXPVisibility = Visibility.Visible;
            Quad1Visibility = Visibility.Visible;
            Quad3Visibility = Visibility.Visible;
            LossGainVisibility = Visibility.Visible;
            PrecVisibility = Visibility.Visible;
            ProductVisibility = Visibility.Visible;
        }
        /// <summary>
        /// 隐藏RO2 CXP CE
        /// </summary>
        private void HideThreeCompound()
        {
            RO2Visibility = Visibility.Collapsed;
            CXPVisibility = Visibility.Collapsed;
            CEVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// 隐藏 Loss/GainOf PreOf / ProductOf
        /// </summary>
        private void HideThreeValueOf()
        {
            LossGainVisibility = Visibility.Hidden;
            PrecVisibility = Visibility.Hidden;
            ProductVisibility = Visibility.Hidden;
        }
        private void Center_WidthCheckedChanged(object param)
        {
            bool b = (bool)param;

            switch (ScanTypeSelectedValue)
            {               
                case "Neutral Ion(NL)":
                    if(b)
                        GenerateNewColumnsAndBindingData(_page.dgMSConfig, NLSourceCollection_CW, NLColumnsDataList_CW);
                    else
                        GenerateNewColumnsAndBindingData(_page.dgMSConfig, NLSourceCollection, NLColumnsDataList);
                    break;
                case "Precursor Ion(Prec)":
                    if(b)
                        GenerateNewColumnsAndBindingData(_page.dgMSConfig, PrecSourceCollection_CW, PrecColumnsDataList_CW);
                    else
                        GenerateNewColumnsAndBindingData(_page.dgMSConfig, PrecSourceCollection, PrecColumnsDataList);
                    break;
                case "Product Ion(MS2)":
                    if(b)
                        GenerateNewColumnsAndBindingData(_page.dgMSConfig, ProductSourceCollection_CW, ProductColumnsDataList_CW);
                    else
                        GenerateNewColumnsAndBindingData(_page.dgMSConfig, ProductSourceCollection, ProductColumnsDataList);
                    break;
                case "Q1 MS(Q1)":
                    if(b)
                        GenerateNewColumnsAndBindingData(_page.dgMSConfig, Q1SourceCollection_CW, Q1ColumnsDataList_CW);
                    else
                        GenerateNewColumnsAndBindingData(_page.dgMSConfig, Q1SourceCollection, Q1ColumnsDataList);
                    break;
               
                case "Q3 MS(Q3)":
                    if(b)
                        GenerateNewColumnsAndBindingData(_page.dgMSConfig, Q3SourceCollection_CW, Q3ColumnsDataList_CW);
                    else
                        GenerateNewColumnsAndBindingData(_page.dgMSConfig, Q3SourceCollection, Q3ColumnsDataList);
                    break;             
            }            
        }
        private void ParamRangeCheckedChanged(object param)
        {
            bool b = (bool)param;
            if (b)
            {

            }
            else
            {

            }
        }
        private void ScheduledMRMCheckedChanged(object param)
        {
            bool b = (bool)param;
            if(b)
            {
                splMSSet1Visibility = Visibility.Collapsed;
                splSMRMVisibility = Visibility.Visible;
                Cycles = 1;
                Duration = 0.017;
            }
            else
            {
                splMSSet1Visibility = Visibility.Visible;
                splSMRMVisibility = Visibility.Collapsed;
                Cycles = 0;
                Duration = 0;
            }
        }
        #endregion
        #endregion

        #region 界面操作
        #region 8个表格 列 信息
        List<DGColumnsBindData> MRMColumnsDataList = new List<DGColumnsBindData>()
        {
             new DGColumnsBindData { ColumnsName = "Q1 Mass(Da)", ColumnsBindName = "Q1Mass" },
             new DGColumnsBindData { ColumnsName = "Q3 Mass(Da)", ColumnsBindName = "Q3Mass" },
             new DGColumnsBindData { ColumnsName = "Time(msec)", ColumnsBindName = "Time" },
             new DGColumnsBindData { ColumnsName = "ID" ,ColumnsBindName = "Id"}
        };
        List<DGColumnsBindData> NLColumnsDataList = new List<DGColumnsBindData>()
        {
             new DGColumnsBindData { ColumnsName = "Start(Da)", ColumnsBindName = "Start" },
             new DGColumnsBindData { ColumnsName = "Stop(Da)", ColumnsBindName = "Stop" },
             new DGColumnsBindData { ColumnsName = "Time(sec)", ColumnsBindName = "Time" }
        };
        List<DGColumnsBindData> NLColumnsDataList_CW = new List<DGColumnsBindData>()
        {
             new DGColumnsBindData { ColumnsName = "Center(Da)", ColumnsBindName = "Center" },
             new DGColumnsBindData { ColumnsName = "Width(Da)", ColumnsBindName = "Width" },
             new DGColumnsBindData { ColumnsName = "Time(sec)", ColumnsBindName = "Time" }
        };
        List<DGColumnsBindData> PrecColumnsDataList = new List<DGColumnsBindData>()
        {
             new DGColumnsBindData { ColumnsName = "Start(Da)", ColumnsBindName = "Start" },
             new DGColumnsBindData { ColumnsName = "Stop(Da)", ColumnsBindName = "Stop" },
             new DGColumnsBindData { ColumnsName = "Time(sec)", ColumnsBindName = "Time" }
        };
        List<DGColumnsBindData> PrecColumnsDataList_CW = new List<DGColumnsBindData>()
        {
             new DGColumnsBindData { ColumnsName = "Center(Da)", ColumnsBindName = "Center" },
             new DGColumnsBindData { ColumnsName = "Width(Da)", ColumnsBindName = "Width" },
             new DGColumnsBindData { ColumnsName = "Time(sec)", ColumnsBindName = "Time" }
        };
        List<DGColumnsBindData> ProductColumnsDataList = new List<DGColumnsBindData>()
        {
             new DGColumnsBindData { ColumnsName = "Start(Da)", ColumnsBindName = "Start" },
             new DGColumnsBindData { ColumnsName = "Stop(Da)", ColumnsBindName = "Stop" },
             new DGColumnsBindData { ColumnsName = "Time(sec)", ColumnsBindName = "Time" }
        };
        List<DGColumnsBindData> ProductColumnsDataList_CW = new List<DGColumnsBindData>()
        {
             new DGColumnsBindData { ColumnsName = "Center(Da)", ColumnsBindName = "Center" },
             new DGColumnsBindData { ColumnsName = "Width(Da)", ColumnsBindName = "Width" },
             new DGColumnsBindData { ColumnsName = "Time(sec)", ColumnsBindName = "Time" }
        };
        List<DGColumnsBindData> Q1ColumnsDataList = new List<DGColumnsBindData>()
        {
             new DGColumnsBindData { ColumnsName = "Start(Da)", ColumnsBindName = "Start" },
             new DGColumnsBindData { ColumnsName = "Stop(Da)", ColumnsBindName = "Stop" },
             new DGColumnsBindData { ColumnsName = "Time(sec)", ColumnsBindName = "Time" }
        };
        List<DGColumnsBindData> Q1ColumnsDataList_CW = new List<DGColumnsBindData>()
        {
             new DGColumnsBindData { ColumnsName = "Center(Da)", ColumnsBindName = "Center" },
             new DGColumnsBindData { ColumnsName = "Width(Da)", ColumnsBindName = "Width" },
             new DGColumnsBindData { ColumnsName = "Time(sec)", ColumnsBindName = "Time" }
        };
        List<DGColumnsBindData> Q1M1ColumnsDataList = new List<DGColumnsBindData>()
        {
             new DGColumnsBindData { ColumnsName = "Q1 Mass(Da)", ColumnsBindName = "Q1Mass" },
             new DGColumnsBindData { ColumnsName = "Time(msec)", ColumnsBindName = "Time" }
        };
        List<DGColumnsBindData> Q3ColumnsDataList = new List<DGColumnsBindData>()
        {
             new DGColumnsBindData { ColumnsName = "Start(Da)", ColumnsBindName = "Start" },
             new DGColumnsBindData { ColumnsName = "Stop(Da)", ColumnsBindName = "Stop" },
             new DGColumnsBindData { ColumnsName = "Time(sec)", ColumnsBindName = "Time" }
        };
        List<DGColumnsBindData> Q3ColumnsDataList_CW = new List<DGColumnsBindData>()
        {
             new DGColumnsBindData { ColumnsName = "Center(Da)", ColumnsBindName = "Center" },
             new DGColumnsBindData { ColumnsName = "Width(Da)", ColumnsBindName = "Width" },
             new DGColumnsBindData { ColumnsName = "Time(sec)", ColumnsBindName = "Time" }
        };
        List<DGColumnsBindData> Q3M1ColumnsDataList = new List<DGColumnsBindData>()
        {
             new DGColumnsBindData { ColumnsName = "Q3 Mass(Da)", ColumnsBindName = "Q3Mass" },
             new DGColumnsBindData { ColumnsName = "Time(msec)", ColumnsBindName = "Time" }
        };
        #endregion
        #region 8个表格 绑定数据表
        private ObservableCollection<MSConfig> MRMSourceCollection = new ObservableCollection<MSConfig>();
        private ObservableCollection<MSConfig> NLSourceCollection = new ObservableCollection<MSConfig>();
        private ObservableCollection<MSConfig> NLSourceCollection_CW = new ObservableCollection<MSConfig>();
        private ObservableCollection<MSConfig> PrecSourceCollection = new ObservableCollection<MSConfig>();
        private ObservableCollection<MSConfig> PrecSourceCollection_CW = new ObservableCollection<MSConfig>();
        private ObservableCollection<MSConfig> ProductSourceCollection = new ObservableCollection<MSConfig>();
        private ObservableCollection<MSConfig> ProductSourceCollection_CW = new ObservableCollection<MSConfig>();
        private ObservableCollection<MSConfig> Q1SourceCollection = new ObservableCollection<MSConfig>();
        private ObservableCollection<MSConfig> Q1SourceCollection_CW = new ObservableCollection<MSConfig>();
        private ObservableCollection<MSConfig> Q1M1SourceCollection = new ObservableCollection<MSConfig>();
        private ObservableCollection<MSConfig> Q3SourceCollection = new ObservableCollection<MSConfig>();
        private ObservableCollection<MSConfig> Q3SourceCollection_CW = new ObservableCollection<MSConfig>();
        private ObservableCollection<MSConfig> Q3M1SourceCollection = new ObservableCollection<MSConfig>();
        #endregion
        /// <summary>
        /// 根据所选中项 决定在该表格 新建那些项 并且绑定对应列表项
        /// </summary>
        /// <param name="dg">表格对象</param>
        /// <param name="sourceList">初始项数据 也是数据绑定源</param>
        /// <param name="data">新表格的列信息</param>
        private void GenerateNewColumnsAndBindingData<T>(DataGrid dg,ObservableCollection<T> sourceList, params DGColumnsBindData[] data)
        {
            sourceList.Clear();
            ClearColumnsInfo(dg);
            foreach (var cbData in data)
            {
                dg.Columns.Add(new DataGridTextColumn()
                {
                    Header = cbData.ColumnsName,
                    Width = 100,
                    Binding = new Binding(cbData.ColumnsBindName)
                });              
            }
           
            dg.ItemsSource = sourceList;            
        }
        private void GenerateNewColumnsAndBindingData<T>(DataGrid dg, ObservableCollection<T> sourceList, List<DGColumnsBindData> data)  
        {
            sourceList.Clear();
            ClearColumnsInfo(dg);
            data.ForEach((cbData) => {
                dg.Columns.Add(new DataGridTextColumn()
                {
                    Header = cbData.ColumnsName,
                    Width = 100,
                    Binding = new Binding(cbData.ColumnsBindName)
                });
            });
        
            dg.ItemsSource = sourceList;
        }
        private void ClearColumnsInfo(DataGrid dg)
        {
            dg.Columns.Clear();
            dg.ItemsSource = null;
        }
        #endregion

        #region 构造函数
        private TunePage _page { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="page">传入的页面</param>
        public TunePageViewModel(Page page)
        {
            this._page = page as TunePage;
            languageTipInfo = "English";
            LanguageChangedCommand = new BaseCommand(ChangeLanguage);
            IHEOffCommand = new BaseCommand(IHEOff);
            IHEOnCommand = new BaseCommand(IHEOn);
            EditRampParamSettingCommand = new BaseCommand(EditRampParamSetting);            
            PositiveCommand = new BaseCommand(PolanityChange);
            NegativeCommand = new BaseCommand(PolanityChange);
            AcquireCommand = new BaseCommand(AcquireFuc);
            Center_WidthCommand = new BaseCommand(Center_WidthCheckedChanged);
            LoadData();        
        }
        #endregion

        #region 数据加载 与 默认值初始化
        #region 控制属性
        private int cbxlossgainIndex = -1;
        public int cbxLossGainIndex
        {
            get { return cbxlossgainIndex; }
            set { Set(ref cbxlossgainIndex, value); }
        } 

        private int cbxscantypeIndex = -1;
        public int cbxScanTypeIndex
        {
            get { return cbxscantypeIndex; }
            set { Set(ref cbxscantypeIndex, value); }
        }

        private int cbxscanmodeIndex = -1;
        public int cbxScanModeIndex
        {
            get { return cbxscanmodeIndex; }
            set { Set(ref cbxscanmodeIndex, value); }
        }

        private Visibility CW_PRVisibility = Visibility.Collapsed;
        public Visibility cbxCW_PRVisibility
        {
            get { return CW_PRVisibility; }
            set { Set(ref CW_PRVisibility, value); }
        }

        private Visibility ScheMRMVisibility = Visibility.Visible;
        public Visibility cbxScheMRMVisibility
        {
            get { return ScheMRMVisibility; }
            set { Set(ref ScheMRMVisibility, value); }
        }

        private bool TotalScanTimeEnabled = false;
        public bool tbxTotalScanTimeEnabled
        {
            get { return TotalScanTimeEnabled; }
            set { Set(ref TotalScanTimeEnabled, value); }
        }

        #endregion
        /// <summary>
        /// 列表数据 加载
        /// </summary>
        private void LoadData()
        {            
            IDataService dataS = new XmlDataService();
            ScanTypeList = dataS.GetAllType(Model.LanguageType.en, Model.UIConfigType.ScanType);
            Resolution = dataS.GetAllType(Model.LanguageType.en, Model.UIConfigType.Resolution);
            ScanModeList = dataS.GetAllType(Model.LanguageType.en, Model.UIConfigType.ScanMode);
            GainLossOfList = dataS.GetAllType(Model.LanguageType.en, Model.UIConfigType.MS_OffSet);               
        }
        #region TabItem 每块 触发事件 的初始值
        public void TabItemInit(string header)
        {
            switch(header)
            {
                case "MS":
                    cbxScanTypeIndex = 0;
                    cbxLossGainIndex = 0;
                    break;
                case "Advanced MS":
                    cbxScanModeIndex = 0;
                    break;
            }
        }
        #endregion
        #endregion

        #region 测试
        public ICommand AcquireCommand { get; set; }
        private void AcquireFuc(object param)
        {
            AcquireToDiskWindow atdW = new AcquireToDiskWindow();
            atdW.ShowDialog();
        }
        #endregion
    }

    /// <summary>
    /// 表格 数据绑定 数据样式
    /// </summary>
    public class DGColumnsBindData
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnsName { get; set; }
        /// <summary>
        /// 列 对应绑定的 属性名字
        /// </summary>
        public string ColumnsBindName { get; set; }
    }
}
