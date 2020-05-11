using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace WPFFuctionExample.Function
{
    public class SQLiteHelper
    {
        #region
        /// <summary>
        /// 构造函数
        /// </summary>
        private SQLiteHelper()
        {

        }
        #endregion

        #region 创建表 与 数据库
        /// <summary>
        /// 创建数据库 
        /// </summary>
        /// <param name="name">数据库的路径(名字)</param>
        public static void CreateDB(string name)
        {
            var filename = name + ".db";
            SQLiteConnection.CreateFile(filename);       
        }

        public static void CreataTable(string tableName)
        {
            string sql = string.Format("create table {0} (name varchar(20) , score int)", tableName);
            int eNum = ExecuteNonQuery("data source=D:/Test.db", sql, null);
        }
        #endregion

        #region 创建执行语句
        /// <summary>
        /// 创建数据库执行语句 <see cref="CreateCommand(SQLiteConnection, string, SQLiteParameter[])"/>
        /// </summary>
        /// <param name="con">连接信息</param>
        /// <param name="commandText">执行字段</param>
        /// <param name="sqlParams">执行条件</param>
        /// <returns></returns>
        public static SQLiteCommand CreateCommand(SQLiteConnection con, string commandText, params SQLiteParameter[] sqlParams)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(commandText, con);
                if (sqlParams.Length > 0)
                {
                    foreach (var para in sqlParams)
                    {
                        cmd.Parameters.Add(para);
                    }
                    return cmd;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                LogsHelper.WriteExLogInfo(FunctionType.SQLite, e.Message, e);
                return null;
            }
        }

        /// <summary>
        /// 创建数据库执行语句 <see cref="CreateCommand(string, string, SQLiteParameter[])"/>
        /// </summary>
        /// <param name="conText">连接信息</param>
        /// <param name="commandText">执行字段</param>
        /// <param name="sqlParams">执行条件</param>
        /// <returns></returns>
        public static SQLiteCommand CreateCommand(string conText, string commandText, params SQLiteParameter[] sqlParams)
        {
            try
            {
                SQLiteConnection con = new SQLiteConnection(conText);
                SQLiteCommand cmd = new SQLiteCommand(commandText, con);
                if (sqlParams.Length > 0)
                {
                    foreach (var para in sqlParams)
                    {
                        cmd.Parameters.Add(para);
                    }
                    return cmd;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                LogsHelper.WriteExLogInfo(FunctionType.SQLite, e.Message, e);
                return null;
            }
        }

        /// <summary>
        /// 创建数据库语句 子选项
        /// </summary>
        /// <param name="name">选项名字</param>
        /// <param name="type">选项类别</param>
        /// <param name="value">选项内容</param>
        /// <returns></returns>
        public static SQLiteParameter CreateParamter(string name, System.Data.DbType type, object value)
        {
            SQLiteParameter para = new SQLiteParameter()
            {
                DbType = type,
                ParameterName = name,
                Value = value
            };

            return para;
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取数据库数据 通过一定的条件
        /// </summary>
        /// <param name="connectionString">数据库连接信息</param>
        /// <param name="commandText">执行信息</param>
        /// <param name="paramList">选项列表</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string connectionString, string commandText, object[] paramList)
        {
            try
            {
                SQLiteConnection cn = new SQLiteConnection(connectionString);
                SQLiteCommand cmd = cn.CreateCommand();

                cmd.CommandText = commandText;
                if (paramList != null)
                {
                    AttachParameters(cmd, commandText, paramList);
                }
                DataSet ds = new DataSet();
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(ds);
                da.Dispose();
                cmd.Dispose();
                cn.Close();
                return ds;
            }
            catch (Exception e)
            {
                LogsHelper.WriteExLogInfo(FunctionType.SQLite, e.Message, e);
                return null;
            }
        }
        /// <summary>
        /// Shortcut method to execute dataset from SQL Statement and object[] arrray of  parameter values
        /// </summary>
        /// <param name="cn">Connection.</param>
        /// <param name="commandText">Command text.</param>
        /// <param name="paramList">Param list.</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(SQLiteConnection cn, string commandText, object[] paramList)
        {
            try
            {
                SQLiteCommand cmd = cn.CreateCommand();

                cmd.CommandText = commandText;
                if (paramList != null)
                {
                    AttachParameters(cmd, commandText, paramList);
                }
                DataSet ds = new DataSet();
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(ds);
                da.Dispose();
                cmd.Dispose();
                cn.Close();
                return ds;
            }
            catch(Exception e)
            {
                LogsHelper.WriteExLogInfo(FunctionType.SQLite, e.Message, e);
                return null;
            }          
        }
        /// <summary>
        /// Executes the dataset from a populated Command object.
        /// </summary>
        /// <param name="cmd">Fully populated SQLiteCommand</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataset(SQLiteCommand cmd)
        {
            try
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                DataSet ds = new DataSet();
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(ds);
                da.Dispose();
                cmd.Connection.Close();
                cmd.Dispose();
                return ds;
            }
            catch (Exception e)
            {
                LogsHelper.WriteExLogInfo(FunctionType.SQLite, e.Message, e);
                return null;
            }         
        }

        /// <summary>
        /// Executes the dataset in a SQLite Transaction
        /// </summary>
        /// <param name="transaction">SQLiteTransaction. Transaction consists of Connection, Transaction,  /// and Command, all of which must be created prior to making this method call. </param>
        /// <param name="commandText">Command text.</param>
        /// <param name="commandParameters">Sqlite Command parameters.</param>
        /// <returns>DataSet</returns>
        /// <remarks>user must examine Transaction Object and handle transaction.connection .Close, etc.</remarks>
        public static DataSet ExecuteDataset(SQLiteTransaction transaction, string commandText, params SQLiteParameter[] commandParameters)
        {
            try
            {
                if (transaction == null) throw new ArgumentNullException("transaction");
                if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rolled back or committed, please provide an open transaction.", "transaction");
                IDbCommand cmd = transaction.Connection.CreateCommand();
                cmd.CommandText = commandText;
                foreach (SQLiteParameter parm in commandParameters)
                {
                    cmd.Parameters.Add(parm);
                }
                if (transaction.Connection.State == ConnectionState.Closed)
                    transaction.Connection.Open();
                DataSet ds = ExecuteDataset((SQLiteCommand)cmd);
                return ds;
            }
            catch (Exception e)
            {
                LogsHelper.WriteExLogInfo(FunctionType.SQLite, e.Message, e);
                return null;
            }          
        }

        /// <summary>
        /// Executes the dataset with Transaction and object array of parameter values.
        /// </summary>
        /// <param name="transaction">SQLiteTransaction. Transaction consists of Connection, Transaction,    /// and Command, all of which must be created prior to making this method call. </param>
        /// <param name="commandText">Command text.</param>
        /// <param name="commandParameters">object[] array of parameter values.</param>
        /// <returns>DataSet</returns>
        /// <remarks>user must examine Transaction Object and handle transaction.connection .Close, etc.</remarks>
        public static DataSet ExecuteDataset(SQLiteTransaction transaction, string commandText, object[] commandParameters)
        {
            try
            {
                if (transaction == null) throw new ArgumentNullException("transaction");
                if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rolled back or committed,                                                          please provide an open transaction.", "transaction");
                IDbCommand cmd = transaction.Connection.CreateCommand();
                cmd.CommandText = commandText;
                AttachParameters((SQLiteCommand)cmd, cmd.CommandText, commandParameters);
                if (transaction.Connection.State == ConnectionState.Closed)
                    transaction.Connection.Open();

                DataSet ds = ExecuteDataset((SQLiteCommand)cmd);
                return ds;
            }
            catch (Exception e)
            {
                LogsHelper.WriteExLogInfo(FunctionType.SQLite, e.Message, e);
                return null;
            }
          
        }
        #endregion

        #region 更新数据
        /// <summary>
        /// 更新数据库数据 <see cref="UpdateDataset(SQLiteCommand, SQLiteCommand, SQLiteCommand, DataSet, string)"/>
        /// </summary>
        /// <param name="insertCommand">插入语句 可以为空</param>
        /// <param name="deleteCommand">删除语句 可以为空</param>
        /// <param name="updateCommand">更新语句 可以为空</param>
        /// <param name="dataSet">数据集合</param>
        /// <param name="tableName">变更的表名</param>
        public static void UpdateDataset(SQLiteCommand insertCommand, SQLiteCommand deleteCommand, SQLiteCommand updateCommand, DataSet dataSet, string tableName)
        {
            if (insertCommand == null) throw new ArgumentNullException("insertCommand");
            if (deleteCommand == null) throw new ArgumentNullException("deleteCommand");
            if (updateCommand == null) throw new ArgumentNullException("updateCommand");
            if (tableName == null || tableName.Length == 0) throw new ArgumentNullException("tableName");

            // Create a SQLiteDataAdapter, and dispose of it after we are done
            using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter())
            {
                // Set the data adapter commands
                dataAdapter.UpdateCommand = updateCommand;
                dataAdapter.InsertCommand = insertCommand;
                dataAdapter.DeleteCommand = deleteCommand;

                // Update the dataset changes in the data source
                dataAdapter.Update(dataSet, tableName);

                // Commit all the changes made to the DataSet
                dataSet.AcceptChanges();
            }
        }
        #endregion

        #region 连接数据选项
        /// <summary>
        /// 连接选项条件与执行语句 返回选项组 <see cref="AttachParameters(SQLiteCommand, string, object[])"/>
        /// </summary>
        /// <param name="commandText">执行语句</param>
        /// <param name="paramList">选项列表</param>    
        private static SQLiteParameterCollection AttachParameters(SQLiteCommand cmd, string commandText, params object[] paramList)
        {
            if (paramList == null || paramList.Length == 0) return null;

            SQLiteParameterCollection coll = cmd.Parameters;
            string parmString = commandText.Substring(commandText.IndexOf("@"));
            // pre-process the string so always at least 1 space after a comma.
            parmString = parmString.Replace(",", " ,");
            // get the named parameters into a match collection
            string pattern = @"(@)\S*(.*?)\b";
            Regex ex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection mc = ex.Matches(parmString);
            string[] paramNames = new string[mc.Count];
            int i = 0;
            foreach (Match m in mc)
            {
                paramNames[i] = m.Value;
                i++;
            }

            // now let's type the parameters
            int j = 0;
            Type t ;
            
            foreach (object o in paramList)
            {
                t = o.GetType();

                SQLiteParameter parm = new SQLiteParameter();
                //因为直接的Type类型 无法用于case
                switch (t.ToString())
                {
                    case ("DBNull"):
                    case ("Char"):
                    case ("SByte"):
                    case ("UInt16"):
                    case ("UInt32"):
                    case ("UInt64"):
                        throw new SystemException("Invalid data type");

                    case ("System.String"):
                        parm.DbType = DbType.String;
                        parm.ParameterName = paramNames[j];
                        parm.Value = (string)paramList[j];
                        coll.Add(parm);
                        break;

                    case ("System.Byte[]"):
                        parm.DbType = DbType.Binary;
                        parm.ParameterName = paramNames[j];
                        parm.Value = (byte[])paramList[j];
                        coll.Add(parm);
                        break;

                    case ("System.Int32"):
                        parm.DbType = DbType.Int32;
                        parm.ParameterName = paramNames[j];
                        parm.Value = (int)paramList[j];
                        coll.Add(parm);
                        break;

                    case ("System.Boolean"):
                        parm.DbType = DbType.Boolean;
                        parm.ParameterName = paramNames[j];
                        parm.Value = (bool)paramList[j];
                        coll.Add(parm);
                        break;

                    case ("System.DateTime"):
                        parm.DbType = DbType.DateTime;
                        parm.ParameterName = paramNames[j];
                        parm.Value = Convert.ToDateTime(paramList[j]);
                        coll.Add(parm);
                        break;

                    case ("System.Double"):
                        parm.DbType = DbType.Double;
                        parm.ParameterName = paramNames[j];
                        parm.Value = Convert.ToDouble(paramList[j]);
                        coll.Add(parm);
                        break;

                    case ("System.Decimal"):
                        parm.DbType = DbType.Decimal;
                        parm.ParameterName = paramNames[j];
                        parm.Value = Convert.ToDecimal(paramList[j]);
                        break;

                    case ("System.Guid"):
                        parm.DbType = DbType.Guid;
                        parm.ParameterName = paramNames[j];
                        parm.Value = (System.Guid)(paramList[j]);
                        break;

                    case ("System.Object"):

                        parm.DbType = DbType.Object;
                        parm.ParameterName = paramNames[j];
                        parm.Value = paramList[j];
                        coll.Add(parm);
                        break;

                    default:
                        throw new SystemException("Value is of unknown data type");

                } // end switch

                j++;
            }
            return coll;
        }

        /// <summary>     
        /// 将表格的列值 传递给 IDataParameterCollection <see cref="AssignParameterValues(IDataParameterCollection, DataRow)"/>
        /// </summary>
        /// <param name="commandParameters">执行条件组</param>
        /// <param name="dataRow">表格</param>
        /// <exception cref="System.InvalidOperationException">Thrown if any of the parameter names are invalid.</exception>
        protected internal static void AssignParameterValues(IDataParameterCollection commandParameters, DataRow dataRow)
        {
            if (commandParameters == null || dataRow == null)
            {
                // Do nothing if we get no data
                return;
            }

            DataColumnCollection columns = dataRow.Table.Columns;

            int i = 0;
            // Set the parameters values
            foreach (IDataParameter commandParameter in commandParameters)
            {
                // Check the parameter name
                if (commandParameter.ParameterName == null ||
                 commandParameter.ParameterName.Length <= 1)
                    throw new InvalidOperationException(string.Format(
                           "Please provide a valid parameter name on the parameter #{0},                            the ParameterName property has the following value: '{1}'.",
                     i, commandParameter.ParameterName));

                if (columns.Contains(commandParameter.ParameterName))
                    commandParameter.Value = dataRow[commandParameter.ParameterName];
                else if (columns.Contains(commandParameter.ParameterName.Substring(1)))
                    commandParameter.Value = dataRow[commandParameter.ParameterName.Substring(1)];

                i++;
            }
        }

        /// <summary>
        /// 将表格的列值 传递给 IDataParameter <see cref="AssignParameterValues(IDataParameter[], DataRow)"/>
        /// </summary>
        /// <param name="commandParameters">执行条件组</param>
        /// <param name="dataRow">表格</param>
        /// <exception cref="System.InvalidOperationException">Thrown if any of the parameter names are invalid.</exception>
        protected void AssignParameterValues(IDataParameter[] commandParameters, DataRow dataRow)
        {
            if ((commandParameters == null) || (dataRow == null))
            {
                // Do nothing if we get no data
                return;
            }

            DataColumnCollection columns = dataRow.Table.Columns;

            int i = 0;
            // Set the parameters values
            foreach (IDataParameter commandParameter in commandParameters)
            {
                // Check the parameter name
                if (commandParameter.ParameterName == null ||
                 commandParameter.ParameterName.Length <= 1)
                    throw new InvalidOperationException(string.Format(
                     "Please provide a valid parameter name on the parameter #{0}, the ParameterName property has the following value: '{1}'.",
                     i, commandParameter.ParameterName));

                if (columns.Contains(commandParameter.ParameterName))
                    commandParameter.Value = dataRow[commandParameter.ParameterName];
                else if (columns.Contains(commandParameter.ParameterName.Substring(1)))
                    commandParameter.Value = dataRow[commandParameter.ParameterName.Substring(1)];

                i++;
            }
        }

        /// <summary>
        /// 将任意条件组转化给 IDataParameter 
        /// </summary>
        /// <param name="commandParameters">执行选项组</param>
        /// <param name="parameterValues">选项列表</param>
        /// <exception cref="System.ArgumentException">Thrown if an incorrect number of parameters are passed.</exception>
        protected void AssignParameterValues(IDataParameter[] commandParameters, params object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
            {
                // Do nothing if we get no data
                return;
            }

            // We must have the same number of values as we pave parameters to put them in
            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("参数数目不等");
            }

            // Iterate through the IDataParameters, assigning the values from the corresponding position in the 
            // value array
            for (int i = 0, j = commandParameters.Length, k = 0; i < j; i++)
            {
                if (commandParameters[i].Direction != ParameterDirection.ReturnValue)
                {
                    // If the current array value derives from IDataParameter, then assign its Value property
                    if (parameterValues[k] is IDataParameter)
                    {
                        IDataParameter paramInstance;
                        paramInstance = (IDataParameter)parameterValues[k];
                        if (paramInstance.Direction == ParameterDirection.ReturnValue)
                        {
                            paramInstance = (IDataParameter)parameterValues[++k];
                        }
                        if (paramInstance.Value == null)
                        {
                            commandParameters[i].Value = DBNull.Value;
                        }
                        else
                        {
                            commandParameters[i].Value = paramInstance.Value;
                        }
                    }
                    else if (parameterValues[k] == null)
                    {
                        commandParameters[i].Value = DBNull.Value;
                    }
                    else
                    {
                        commandParameters[i].Value = parameterValues[k];
                    }
                    k++;
                }
            }
        }
        
        #endregion

        #region 执行
        /// <summary>
        /// 获取数据读取器接口      
        /// </summary>
        /// <param name="cmd">执行对象</param>
        /// <param name="commandText">执行语句</param>
        /// <param name="paramList">参数列表</param>
        /// <returns>IDataReader</returns>
        public static IDataReader ExecuteReader(SQLiteCommand cmd, string commandText, object[] paramList)
        {
            if (cmd.Connection == null)
                throw new ArgumentException("Command must have live connection attached.", "cmd");
            cmd.CommandText = commandText;
            AttachParameters(cmd, commandText, paramList);
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            IDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return rdr;
        }

        /// <summary>
        /// 执行数据库语句
        /// </summary>
        /// <param name="connectionString">连接语句</param>
        /// <param name="commandText">执行语句</param>
        /// <param name="paramList">参数列表</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, string commandText, params object[] paramList)
        {
            try
            {
                SQLiteConnection cn = new SQLiteConnection(connectionString);
                SQLiteCommand cmd = cn.CreateCommand();
                cmd.CommandText = commandText;
                AttachParameters(cmd, commandText, paramList);
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                int result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                cn.Close();

                return result;
            }
            catch(Exception e)
            {
                LogsHelper.WriteExLogInfo(FunctionType.SQLite, e.Message, e);
                return -1;
            }           
        }

        /// <summary>
        /// 执行数据库语句
        /// </summary>
        /// <param name="cn">连接类</param>
        /// <param name="commandText">执行语句</param>
        /// <param name="paramList">参数列表</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(SQLiteConnection cn, string commandText, params object[] paramList)
        {
            try
            {
                SQLiteCommand cmd = cn.CreateCommand();
                cmd.CommandText = commandText;
                AttachParameters(cmd, commandText, paramList);
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                int result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                cn.Close();

                return result;
            }
            catch(Exception e)
            {
                LogsHelper.WriteExLogInfo(FunctionType.SQLite, e.Message, e);
                return -1;
            }            
        }

        /// <summary>
        /// 执行数据库语句
        /// </summary>
        /// <param name="transaction">数据库 事务 </param>
        /// <param name="commandText">执行语句</param>
        /// <param name="paramList">参数列表</param>
        /// <returns>Integer</returns>       
        public static int ExecuteNonQuery(SQLiteTransaction transaction, string commandText, params object[] paramList)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rolled back or committed,please provide an open transaction.", "transaction");
            IDbCommand cmd = transaction.Connection.CreateCommand();
            cmd.CommandText = commandText;
            AttachParameters((SQLiteCommand)cmd, cmd.CommandText, paramList);
            if (transaction.Connection.State == ConnectionState.Closed)
                transaction.Connection.Open();
            int result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return result;
        }

        /// <summary>
        /// 执行数据库语句
        /// </summary>
        /// <param name="cmd">执行语句组合</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(IDbCommand cmd)
        {
            try
            {
                if(cmd!=null)
                {
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    cmd.Dispose();
                    return result;
                }
                return -1;
            }
            catch(Exception e)
            {
                LogsHelper.WriteExLogInfo(FunctionType.SQLite, e.Message,e);
                return -1;
            }            
        }

        /// <summary>
        /// 获取查询结果的第一行第一列信息
        /// </summary>
        /// <param name="connectionString">连接语句</param>
        /// <param name="commandText">执行语句</param>
        /// <param name="paramList">参数列表</param>
        /// <returns></returns>
        public static object ExecuteScalar(string connectionString, string commandText, params object[] paramList)
        {
            try
            {
                SQLiteConnection cn = new SQLiteConnection(connectionString);
                SQLiteCommand cmd = cn.CreateCommand();
                cmd.CommandText = commandText;
                AttachParameters(cmd, commandText, paramList);
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                object result = cmd.ExecuteScalar();
                cmd.Dispose();
                cn.Close();

                return result;
            }
            catch(Exception e)
            {
                LogsHelper.WriteExLogInfo(FunctionType.SQLite, e.Message, e);
                return null;
            }            
        }

        /// <summary>
        /// 得到XML读取器接口
        /// </summary>
        /// <param name="command">数据库命令</param>
        /// <returns>XmlReader</returns>
        public static XmlReader ExecuteXmlReader(IDbCommand command)
        {
            try
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }

                // get a data adapter  
                SQLiteDataAdapter da = new SQLiteDataAdapter((SQLiteCommand)command);
                DataSet ds = new DataSet();
                // fill the data set, and return the schema information
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                da.Fill(ds);
                // convert our dataset to XML
                StringReader stream = new StringReader(ds.GetXml());
                command.Connection.Close();
                // convert our stream of text to an XmlReader
                return new XmlTextReader(stream);
            }
            catch(Exception e)
            {
                LogsHelper.WriteExLogInfo(FunctionType.SQLite, e.Message, e);
                return null;
            }
        }

        /// <summary>
        /// 从表格中执行数据库语句
        /// </summary>
        /// <param name="command">数据库指令</param>
        /// <param name="dataRow">表格行</param>
        /// <returns>Integer result code</returns>
        public static int ExecuteNonQueryTypedParams(IDbCommand command, DataRow dataRow)
        {
            int retVal = 0;

            // If the row has values, the store procedure parameters must be initialized
            if (dataRow != null && dataRow.ItemArray.Length > 0)
            {
                // Set the parameters values
                AssignParameterValues(command.Parameters, dataRow);

                retVal = ExecuteNonQuery(command);
            }
            else
            {
                retVal = ExecuteNonQuery(command);
            }

            return retVal;
        }

        #endregion
    }
}
