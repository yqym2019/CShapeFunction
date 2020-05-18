using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WPFFuctionExample.Model;

namespace WPFFuctionExample.Services
{
    /// <summary>
    /// 解析XML数据 的 接口实现
    /// </summary>
    class XmlDataService : IDataService
    {
        /// <summary>
        /// 获取所有扫描类型 的 列表
        /// </summary>
        /// <param name="lType">语言类别</param>
        /// <param name="uiCtype">配置类别</param>
        /// <returns></returns>
        public List<string> GetAllType(LanguageType lType,UIConfigType uiCtype)
        {
            List<string> typeList = new List<string>();
            //组合xml 资源文件 路径
            string xmlPath = "";
            switch (lType)
            {
                case LanguageType.chs:
                    xmlPath = System.IO.Path.Combine(Environment.CurrentDirectory+"\\..\\..\\..\\", @"Data\config-cn.xml");
                    break;
                case LanguageType.en:
                    xmlPath = System.IO.Path.Combine(Environment.CurrentDirectory + "\\..\\..\\..\\", @"Data\config-en.xml");
                    break;
                default: break;
            }

            //加载xml文件
            if(File.Exists(xmlPath))
            {
                XDocument xDoc = XDocument.Load(xmlPath);
                string keyName = "";
                switch(uiCtype)
                {
                    case UIConfigType.RampParameterSettings:
                        keyName = "RampParamSetting";
                        break;
                    case UIConfigType.Resolution:
                        keyName = "Resolution";
                        break;
                    case UIConfigType.ScanMode:
                        keyName = "ScanMode";
                        break;
                    case UIConfigType.ScanType:
                        keyName = "ScanType";
                        break;
                    case UIConfigType.MS_OffSet:
                        keyName = "MS_OffSet";
                        break;
                }
                if(keyName!="")
                {
                    //反序列化数据
                    var typeDoc = xDoc.Descendants(keyName);
                    var types = typeDoc.Descendants("Type");
                    foreach( var type in types )
                    {
                        typeList.Add(type.Value);
                    }
                    return typeList;
                }
            }

            return null;
        }
    }
}
