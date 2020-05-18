using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFFuctionExample.Services
{
    /// <summary>
    /// 数据获取服务的接口
    /// </summary>
    interface IDataService
    {
        List<string> GetAllScanType();
    }
}
