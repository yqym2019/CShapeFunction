using System;
using System.IO;
using System.Linq;
using WPFFuctionExample.Model;

namespace WPFFuctionExample.Function
{
    /// <summary>
    /// IO 文件读写等 工厂模式
    /// </summary>
   public class IOFileHelper
    {
        #region 构造函数
        /// <summary>
        /// 默认构造方法 <see cref="IOFileHelper"/>
        /// </summary>
        private IOFileHelper()
        {

        }
        #endregion

        #region 读

        /// <summary>
        /// 一次性获取文件全部内容 <see cref="GetFileData(string)"/>
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="data"> 输出的数据 </param>
        /// <returns></returns>
        public static bool ReadFileData(string filePath,out string data)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    data = File.ReadAllText(filePath);
                    return true;
                }
                data = "路径文件不存在";
                return false;
            }
            catch(Exception e)
            {
                //LogsHelper.WriteExLogInfo(FunctionType.IOFile,e.Message,e);
                data = null;
                return false;
            }          
        }

        /// <summary>
        /// 分行获取文件内容 <see cref="GetFileLinesData(string, string[])"/>
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="linesData">输出内容</param>
        /// <returns></returns>
        public static bool ReadFileData(string filePath,out string[] linesData)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    linesData = File.ReadAllLines(filePath);
                    return true;
                }
                linesData = null;
                return false;
            }
            catch(Exception e)
            {
                ////LogsHelper.WriteExLogInfo(FunctionType.IOFile,e.Message,e);
                linesData = null;
                return false;
            }          
        }
    
        /// <summary>
        /// 获取文件信息 <see cref="GetFileInfo(string, out FileInfo)"/>
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileInfo">输出文件信息</param>
        /// <returns></returns>
        public static bool ReadFileInfo(string filePath,out FileInfo fileInfo)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    fileInfo = new FileInfo(filePath);
                    return true;
                }
                fileInfo = null;
                return false;
            }
            catch(Exception e)
            {
                ////LogsHelper.WriteExLogInfo(FunctionType.IOFile,e.Message,e);
                fileInfo = null;
                return false;
            }               
        }

        public static string ReadFileType(string filePath)
        {
            string lastType = filePath.Substring(filePath.LastIndexOf("."));
            return lastType;
        }

        #endregion

        #region 写
        /// <summary>
        /// 写入文件内容 <see cref="WriteFileData(string, string, bool)"/>
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="data">文件数据</param>
        /// <param name="IsOverWrited">是否覆盖原文件</param>
        /// <returns></returns>
        public static bool WriteFileData(string filePath,string data,bool IsOverWrited = false)
        {
            try
            {
                //覆盖原文件
                if (IsOverWrited)
                {
                    File.WriteAllText(filePath, data);                    
                }
                else //若是存在的 则加到后面去 否则创建新文件
                {
                    File.AppendAllText(filePath, data);                    
                }
                return true;
            }
            catch(Exception e)
            {
                ////LogsHelper.WriteExLogInfo(FunctionType.IOFile, e.Message,e);
                return false;
            }
        }

        /// <summary>
        /// 写入文件所有行内容 <see cref="WriteFileLinesData(string, string, bool)"/>
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="data">文件数据</param>
        /// <param name="IsOverWrited">是否覆盖原文件</param>
        /// <returns></returns>
        public static bool WriteFileData(string filePath, string[] data, bool IsOverWrited = false)
        {
            try
            {
                //覆盖原文件
                if(IsOverWrited)
                {
                    File.WriteAllLines(filePath, data);
                }
                else //若是存在的 则加到后面去 否则创建新文件
                {
                    File.AppendAllLines(filePath, data);
                }
                return true;
            }
            catch (Exception e)
            {
                //LogsHelper.WriteExLogInfo(FunctionType.IOFile, e.Message,e);
                return false;
            }
        }

        #endregion

        #region 判别
        public static bool IsPicture(string filePath)
        {
            //判别是否是图片 { }
            string type = ReadFileType(filePath);
            var result = ImageType.Type.Where(t => t == type);           

            return result!=null;
        }
        #endregion
    }
}
