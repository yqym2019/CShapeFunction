using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WPFFuctionExample.Command;
using WPFFuctionExample.Model;

namespace WPFFuctionExample.ViewModel
{
    /// <summary>
    /// MenuItem的视图模型层
    /// </summary>
    public class MenuItemViewModel:VMNotifyChanged
    {
        private string infoRecord = ""; 

        private string info = "Test";

        public string Info
        {
            get { return info; }
            set {
                Set(ref info,value);
            }   
        }

        public ObservableCollection<MenuItemModel> Items = new ObservableCollection<MenuItemModel>()
        {
             new MenuItemModel(){ type= IconType.Icon1,info="菜单1",path="/Icon/backgroud1.jpg" },
             new MenuItemModel(){ type= IconType.Icon2,info="菜单2",path="/Icon/backgroud1.jpg" },
             new MenuItemModel(){ type= IconType.Icon3,info="菜单3",path="/Icon/backgroud1.jpg" }
        };

        #region 集合绑定
        /// <summary>
        /// 获取 model 对象中的属性信息 
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="model">对象</param>
        /// <returns></returns>
        List<MenuItemModel> FindDititsInfo<T>(T model)
        {
            List<MenuItemModel> MIMList = new List<MenuItemModel>();
            var newType = model.GetType();
            foreach(var item in newType.GetRuntimeProperties())
            {
                MenuItemModel min = new MenuItemModel();
                min.info = item.Name;
                min.path = item.GetValue(model).ToString();
                MIMList.Add(min);
            }
            return MIMList;
        }
        #endregion

        //这地方注意 不写 {get set 会无效
        public ICommand TestCMD { get; set; }

        public MenuItemViewModel()
        {
          //  TestCMD = new BaseCommand(FuctionTest);
        }

        public void FuctionTest()
        {
            MessageBox.Show(infoRecord);
        }      
    }
}
