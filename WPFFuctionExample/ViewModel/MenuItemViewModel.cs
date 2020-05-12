using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFFuctionExample.Model;

namespace WPFFuctionExample.ViewModel
{
    /// <summary>
    /// MenuItem的视图模型层
    /// </summary>
    public class MenuItemViewModel
    {
        public ObservableCollection<MenuItemModel> Items { get; set; }

        public MenuItemViewModel()
        {
            Items = new ObservableCollection<MenuItemModel>()
            {
                new MenuItemModel(){ type= IconType.Icon1,info="菜单1",path="/Icon/backgroud1.jpg" },
                new MenuItemModel(){ type= IconType.Icon2,info="菜单2",path="/Icon/backgroud1.jpg" },
                new MenuItemModel(){ type= IconType.Icon3,info="菜单3",path="/Icon/backgroud1.jpg" }
            };
        }
    }
}
