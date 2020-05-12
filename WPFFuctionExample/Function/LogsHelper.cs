
using System;
using WPFFuctionExample.Model;

namespace WPFFuctionExample.Function
{
    public class LogsHelper
    {
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");//这里的名字要和配置文件里面一样
        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");//这里的名字要和配置文件里面一样

        private LogsHelper()
        {

        }

        public static void WriteLogInfo(FunctionType ftype,string info)
        {
            if(loginfo.IsInfoEnabled)
            {
                string str = "";
                switch(ftype)
                {
                    case FunctionType.IOFile:
                        str = string.Format("IOFile --> {0}", info);
                        break;
                    case FunctionType.Logs:
                        str = string.Format("Logs --> {0}", info);
                        break;
                    case FunctionType.SQLite:
                        str = string.Format("SQLite --> {0}", info);
                        break;
                    case FunctionType.TCPIP:
                        str = string.Format("TCPIP --> {0}", info);
                        break;
                    default:break;
                }
                loginfo.Info(str);
            }
        }

        public static void WriteExLogInfo(FunctionType ftype,string info, Exception ex)
        {
            if(logerror.IsErrorEnabled)
            {
                string str = "";
                switch (ftype)
                {
                    case FunctionType.IOFile:
                        str = string.Format("IOFile --> {0}", info);
                        break;
                    case FunctionType.Logs:
                        str = string.Format("Logs --> {0}", info);
                        break;
                    case FunctionType.SQLite:
                        str = string.Format("SQLite --> {0}", info);
                        break;
                    case FunctionType.TCPIP:
                        str = string.Format("TCPIP --> {0}", info);
                        break;
                    default: break;
                }
                logerror.Error(str, ex);
            }
        }
    }
}
