using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFFuctionExample.Model
{
    /// <summary>
    /// 菜单子项的模型
    /// </summary>
    public class MenuItemModel
    {
        public string info { get; set; }
        public IconType type { get; set; }

        public string path { get; set; }
    }
}
