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
        private Visibility cadVisibility;

        public Visibility CADVisibility
        {
            get { return cadVisibility; }
            set { Set(ref cadVisibility, value); }
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

        private float ro2;
        public float RO2
        {
            get { return ro2; }
            set { Set(ref ro2, value); }
        }

        private float ce;
        public float CE
        {
            get { return ce; }
            set { Set(ref ce, value); }
        }

        private float cxp;
        public float CXP
        {
            get { return cxp; }
            set { Set(ref cxp, value); }
        }

        #region 可视属性
        private Visibility ro2Visibility;

        public Visibility RO2Visibility
        {
            get { return ro2Visibility; }
            set { Set(ref ro2Visibility, value); }
        }

        private Visibility ceVisibility;

        public Visibility CEVisibility
        {
            get { return ceVisibility; }
            set { Set(ref ceVisibility, value); }
        }

        private Visibility cxpVisibility;

        public Visibility CXPVisibility
        {
            get { return cxpVisibility; }
            set { Set(ref cxpVisibility, value); }
        }
        #endregion

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
        #region 可视属性
        private Visibility quad1Visibility;

        public Visibility Quad1Visibility
        {
            get { return quad1Visibility; }
            set { Set(ref quad1Visibility, value); }
        }

        private Visibility quad3Visibility;

        public Visibility Quad3Visibility
        {
            get { return quad3Visibility; }
            set { Set(ref quad3Visibility, value); }
        }
        #endregion
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
        private double gainOfValue;

        public double GainOfValue
        {
            get { return gainOfValue; }
            set { Set(ref gainOfValue, value); }
        }

        private double lossOfValue;

        public double LossOfValue
        {
            get { return lossOfValue; }
            set { Set(ref lossOfValue, value); }
        }

        private double productOfValue;

        public double ProductOfValue
        {
            get { return productOfValue; }
            set { Set(ref productOfValue, value); }
        }

        private double precursorOfValue;

        public double PrecursorOfValue
        {
            get { return precursorOfValue; }
            set { Set(ref precursorOfValue, value); }
        }

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
        private List<Action> LossGainOfActionList { get; set; }
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

        //表格 信息 绑定数据集
        private ObservableCollection <MSConfig> msConfigInfo;
        public ObservableCollection <MSConfig> MSConfigInfo
        {
            get { return msConfigInfo; }
            set {
                Set(ref msConfigInfo, value);
            }
        }


        #endregion

        #endregion

        #region Advanced MS

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

        private int massDefect;

        public int MassDefect
        {
            get { return massDefect; }
            set { Set(ref massDefect, value); }
        }

        private int minPeakWidth;

        public int MinPeakWidth
        {
            get { return minPeakWidth; }
            set { Set(ref minPeakWidth, value); }
        }

        private int minPeakSep;

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
        public ICommand ScanTypeCommand { get; set; }
        public ICommand PositiveCommand { get; set; }
        public ICommand NegativeCommand { get; set; }
        public ICommand ScanModeCommand { get; set; }
        public ICommand StartCommand    { get; set; }
        public ICommand LossGainOfCommand { get; set; }
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
        private void LossGainOfSelectionChanged(object param)
        {
            //int sIndex = (int)param;
            //if(sIndex>=0)
            //{
            //    LossGainOfActionList[sIndex]();
            //}
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
            switch((string)param)
            {
                case "MRM(MRM)":
                    //MRM
                    AllVisibility();
                    RO2Visibility = Visibility.Collapsed;
                    HideThreeValueOf();
                    //构建新表
                    GenerateNewColumnsAndBindingData(_page.dgMSConfig, MRMSourceCollection, MRMColumnsDataList);
                    break;
                case "Neutral Ion(NL)":
                    //NL
                    AllVisibility();
                    HideThreeValueOf();
                    RO2Visibility = Visibility.Collapsed;
                    LossGainVisibility = Visibility.Visible;
                    GenerateNewColumnsAndBindingData(_page.dgMSConfig, NLSourceCollection, NLColumnsDataList);
                    break;
                case "Precursor Ion(MS2)":
                    //Prec
                    AllVisibility();
                    HideThreeValueOf();
                    RO2Visibility = Visibility.Collapsed;
                    PrecVisibility = Visibility.Visible;
                    GenerateNewColumnsAndBindingData(_page.dgMSConfig, PrecSourceCollection, PrecColumnsDataList);
                    break;
                case "Product Ion(MS2)":
                    //MS2 Product
                    AllVisibility();
                    HideThreeValueOf();
                    RO2Visibility = Visibility.Collapsed;
                    ProductVisibility = Visibility.Visible;
                    GenerateNewColumnsAndBindingData(_page.dgMSConfig, ProductSourceCollection, ProductColumnsDataList);
                    break;
                case "Q1 MS(Q1)":
                    //Q1
                    AllVisibility();
                    HideThreeCompound();
                    HideThreeValueOf();
                    CADVisibility = Visibility.Collapsed;
                    Quad3Visibility = Visibility.Collapsed;
                    GenerateNewColumnsAndBindingData(_page.dgMSConfig, Q1SourceCollection, Q1ColumnsDataList);
                    break;
                case "Q1 Multiple Ions(Q1 M1)":
                    //Q1 M1
                    AllVisibility();
                    HideThreeCompound();
                    HideThreeValueOf();
                    CADVisibility = Visibility.Collapsed;
                    Quad3Visibility = Visibility.Collapsed;
                    GenerateNewColumnsAndBindingData(_page.dgMSConfig, Q1M1SourceCollection, Q1M1ColumnsDataList);
                    break;
                case "Q3 MS(Q3)":
                    //Q3
                    AllVisibility();
                    HideThreeValueOf();
                    CEVisibility = Visibility.Collapsed;
                    CADVisibility = Visibility.Collapsed;
                    Quad1Visibility = Visibility.Collapsed;
                    GenerateNewColumnsAndBindingData(_page.dgMSConfig, Q3SourceCollection, Q3ColumnsDataList);
                    break;
                case "Q3 Multiple Ions(Q3 M1)":
                    //Q3 M1
                    AllVisibility();
                    HideThreeValueOf();
                    CEVisibility = Visibility.Collapsed;
                    CADVisibility = Visibility.Collapsed;
                    Quad1Visibility = Visibility.Collapsed;
                    GenerateNewColumnsAndBindingData(_page.dgMSConfig, Q3M1SourceCollection, Q3M1ColumnsDataList);
                    break;
            }
        }
        private void ScanModeSelectionChanged(object param)
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
        private List<Action> LossGainOfActionListInit()
        {
            List<Action> actionList = new List<Action>()
            {
                {
                    ()=>
                    {
                        tbxLossOfVisibility = Visibility.Visible;
                        tbxGainOfVisibility = Visibility.Collapsed;
                    }
                },
                {
                    ()=>
                    {
                        tbxLossOfVisibility = Visibility.Collapsed;
                        tbxGainOfVisibility = Visibility.Visible;
                    }
                }
            };
            return actionList;
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
        List<DGColumnsBindData> PrecColumnsDataList = new List<DGColumnsBindData>()
        {
             new DGColumnsBindData { ColumnsName = "Start(Da)", ColumnsBindName = "Start" },
             new DGColumnsBindData { ColumnsName = "Stop(Da)", ColumnsBindName = "Stop" },
             new DGColumnsBindData { ColumnsName = "Time(sec)", ColumnsBindName = "Time" }
        };
        List<DGColumnsBindData> ProductColumnsDataList = new List<DGColumnsBindData>()
        {
             new DGColumnsBindData { ColumnsName = "Start(Da)", ColumnsBindName = "Start" },
             new DGColumnsBindData { ColumnsName = "Stop(Da)", ColumnsBindName = "Stop" },
             new DGColumnsBindData { ColumnsName = "Time(sec)", ColumnsBindName = "Time" }
        };
        List<DGColumnsBindData> Q1ColumnsDataList = new List<DGColumnsBindData>()
        {
             new DGColumnsBindData { ColumnsName = "Start(Da)", ColumnsBindName = "Start" },
             new DGColumnsBindData { ColumnsName = "Stop(Da)", ColumnsBindName = "Stop" },
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
        List<DGColumnsBindData> Q3M1ColumnsDataList = new List<DGColumnsBindData>()
        {
             new DGColumnsBindData { ColumnsName = "Q3 Mass(Da)", ColumnsBindName = "Q3Mass" },
             new DGColumnsBindData { ColumnsName = "Time(msec)", ColumnsBindName = "Time" }
        };
        #endregion
        #region 8个表格 绑定数据表
        private ObservableCollection<MSConfig> MRMSourceCollection = new ObservableCollection<MSConfig>()
        {
            new MSConfig { Q1Mass=11,Q3Mass=33,Id=44,Time=666 }
        };
        private ObservableCollection<MSConfig> NLSourceCollection = new ObservableCollection<MSConfig>()
        {
            new MSConfig { Start= 1,Stop=2,Time = 3 }
        };
        private ObservableCollection<MSConfig> PrecSourceCollection = new ObservableCollection<MSConfig>()
        {
            new MSConfig { Start= 1,Stop=2,Time = 3 }
        };
        private ObservableCollection<MSConfig> ProductSourceCollection = new ObservableCollection<MSConfig>()
        {
            new MSConfig { Start= 1,Stop=2,Time = 3 }
        };
        private ObservableCollection<MSConfig> Q1SourceCollection = new ObservableCollection<MSConfig>()
        {
            new MSConfig { Start= 1,Stop=2,Time = 3 }
        };
        private ObservableCollection<MSConfig> Q1M1SourceCollection = new ObservableCollection<MSConfig>()
        {
            new MSConfig { Q1Mass=11,Time=666 }
        };
        private ObservableCollection<MSConfig> Q3SourceCollection = new ObservableCollection<MSConfig>()
        {
            new MSConfig { Start= 1,Stop=2,Time = 3 }
        };
        private ObservableCollection<MSConfig> Q3M1SourceCollection = new ObservableCollection<MSConfig>()
        {
            new MSConfig { Q3Mass=33,Time=666 }
        };
        #endregion
        /// <summary>
        /// 根据所选中项 决定在该表格 新建那些项 并且绑定对应列表项
        /// </summary>
        /// <param name="dg">表格对象</param>
        /// <param name="sourceList">初始项数据 也是数据绑定源</param>
        /// <param name="data">新表格的列信息</param>
        private void GenerateNewColumnsAndBindingData<T>(DataGrid dg,ObservableCollection<T> sourceList, params DGColumnsBindData[] data)
        {
            ClearColumnsInfo(dg);
            foreach (var cbData in data)
            {
                dg.Columns.Add(new DataGridTextColumn()
                {
                    Header = cbData.ColumnsName,
                    Binding = new Binding(cbData.ColumnsBindName)
                });              
            }
           
            dg.ItemsSource = sourceList;            
        }
        private void GenerateNewColumnsAndBindingData<T>(DataGrid dg, ObservableCollection<T> sourceList, List<DGColumnsBindData> data)  
        {
            ClearColumnsInfo(dg);
            data.ForEach((cbData) => {
                dg.Columns.Add(new DataGridTextColumn()
                {
                    Header = cbData.ColumnsName,
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
        public TunePageViewModel(Page page)
        {
            this._page = page as TunePage;
            languageTipInfo = "English";
            LanguageChangedCommand = new BaseCommand(ChangeLanguage);
            IHEOffCommand = new BaseCommand(IHEOff);
            IHEOnCommand = new BaseCommand(IHEOn);
            EditRampParamSettingCommand = new BaseCommand(EditRampParamSetting);          
            LossGainOfActionList = LossGainOfActionListInit();
            LossGainOfCommand = new BaseCommand(LossGainOfSelectionChanged);
            ScanTypeCommand = new BaseCommand(ScanTypeSelectionChanged);
            ScanModeCommand = new BaseCommand(ScanModeSelectionChanged);   
            PositiveCommand = new BaseCommand(PolanityChange);
            NegativeCommand = new BaseCommand(PolanityChange);
            TestCommand = new BaseCommand(TestFuc);               
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
            DefaultInit();          
        }

        DispatcherTimer dt = new DispatcherTimer();
      
        /// <summary>
        /// 各个属性的初始值设置
        /// </summary>
        private void DefaultInit()
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                cbxScanTypeIndex = 0;
                cbxLossGainIndex = 0;
                cbxScanModeIndex = 0;
            }
            );                         
        }
        #endregion

        #region 测试
        public ICommand TestCommand { get; set; }
        private void TestFuc(object param)
        {
            foreach(var c in MSConfigInfo)
            {

            }
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
