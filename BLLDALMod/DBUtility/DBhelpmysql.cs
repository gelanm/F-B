
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
//Add MySql Library
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Maticsoft.DBUtility
{
    public abstract class DBhelpmysql
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["mysqlconn1"].ConnectionString + ";Charset=utf8";

        //Constructor
        public DBhelpmysql()
        {
           
        }

        public static object Add(string query, MySqlParameter[] Parameters)
        {
            object obj = null;
            DateTime dtStart = DateTime.Now;
            //open connection

            MySqlConnection Connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                Connection.Open();
                cmd.Connection = Connection;
                cmd.CommandText = query;
                cmd.CommandTimeout = 1200;
                //create command and assign the query and connection from the constructor
                //MySqlCommand cmd = new MySqlCommand(query, Connection);
                if (Parameters != null)
                {
                    cmd.Parameters.AddRange(Parameters);
                }
                //Execute command
                //cmd.ExecuteNonQuery();
                obj = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    obj = null;
                }

            }
            catch (Exception e)
            {
                string strErr = string.Empty; //p_CmdParms 参数值                        
                //CommModule.AddLog.AddMsgLog(CommModule.PublicEnum.LogType.SqlError, "SqlBase", e.Message + "\r\nSQL     : " + query + "\r\n参数    : " + strErr, e.StackTrace);
                AddLog.AddMsgLog(PublicEnum.LogType.SqlError, "SqlBase", e.Message + "\r\nSQL     : " + query + "\r\n参数    : " + strErr, e.StackTrace);
                
            }
            finally
            {
                //close connection
                Connection.Close();
                Connection.Dispose();
                cmd.Dispose();
                AddLog.AddSQLLog(query, dtStart.TimeOfDay.ToString(), DateTime.Now.TimeOfDay.ToString(), Convert.ToString(DateTime.Now - dtStart));
            }

            return obj;
        }

        //Insert statement
        public static object Insert(string query, MySqlParameter[] Parameters)
        {
            object obj = null;
            DateTime dtStart = DateTime.Now;
            //open connection
             
                MySqlConnection Connection = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    Connection.Open();
                    cmd.Connection = Connection;
                    cmd.CommandText = query;
                    cmd.CommandTimeout = 1200;
                    //create command and assign the query and connection from the constructor
                    //MySqlCommand cmd = new MySqlCommand(query, Connection);
                    if (Parameters != null)
                    {
                        cmd.Parameters.AddRange(Parameters);
                    }
                    //Execute command
                    //cmd.ExecuteNonQuery();
                    obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        obj = null;
                    }
                }
                catch (Exception e)
                {
                    string strErr = string.Empty; //p_CmdParms 参数值                        
                    AddLog.AddMsgLog(PublicEnum.LogType.SqlError, "SqlBase", e.Message + "\r\nSQL     : " + query + "\r\n参数    : " + strErr, e.StackTrace);
                }
                finally
                {
                    //close connection
                    Connection.Close();
                    Connection.Dispose();
                    cmd.Dispose();
                    AddLog.AddSQLLog(query, dtStart.TimeOfDay.ToString(), DateTime.Now.TimeOfDay.ToString(), Convert.ToString(DateTime.Now - dtStart));
                }
                return obj;
              
        }

        //Update statement
        public static void Update(string query, MySqlParameter[] Parameters)
        {
            DateTime dtStart = DateTime.Now;
            //Open connection
            MySqlConnection Connection = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    Connection.Open();
                    cmd.Connection = Connection;
                    cmd.CommandText = query;
                    cmd.CommandTimeout = 1200;
                    //Assign the query using CommandText
                    if (Parameters != null)
                    {
                        cmd.Parameters.AddRange(Parameters);
                    }
                    
                    //Assign the connection using Connection
                    
                    //Execute query
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string strErr = string.Empty; //p_CmdParms 参数值                        
                    AddLog.AddMsgLog(PublicEnum.LogType.SqlError, "SqlBase", e.Message + "\r\nSQL     : " + query + "\r\n参数    : " + strErr, e.StackTrace);
                }
                finally
                {
                    //close connection
                    Connection.Close();
                    Connection.Dispose();
                    cmd.Dispose();
                    AddLog.AddSQLLog(query, dtStart.TimeOfDay.ToString(), DateTime.Now.TimeOfDay.ToString(), Convert.ToString(DateTime.Now - dtStart));
                }
            
        }

        //Delete statement
        public static void Delete(string query, MySqlParameter[] Parameters)
        {
            DateTime dtStart = DateTime.Now;
            MySqlConnection Connection = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    Connection.Open();
                    cmd.Connection = Connection;
                    cmd.CommandText = query;
                    cmd.CommandTimeout = 1200;
                    
                    if (Parameters != null)
                    {
                        cmd.Parameters.AddRange(Parameters);
                    }
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string strErr = string.Empty; //p_CmdParms 参数值                        
                    AddLog.AddMsgLog(PublicEnum.LogType.SqlError, "SqlBase", e.Message + "\r\nSQL     : " + query + "\r\n参数    : " + strErr, e.StackTrace);
                }
                finally
                {
                    Connection.Close();
                    Connection.Dispose();
                    cmd.Dispose();
                    AddLog.AddSQLLog(query, dtStart.TimeOfDay.ToString(), DateTime.Now.TimeOfDay.ToString(), Convert.ToString(DateTime.Now - dtStart));
                }
           
        }
        /// <summary>
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataTable Query(string SQLString)
        {
            DateTime dtStart = DateTime.Now;
            DataTable dt = new DataTable();
            MySqlConnection Connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(SQLString, Connection);
            try
            {
                Connection.Open();
                cmd.CommandTimeout = 1200;
                MySqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
            catch (Exception e)
            {
                string strErr = string.Empty; //p_CmdParms 参数值                        
                AddLog.AddMsgLog(PublicEnum.LogType.SqlError, "SqlBase", e.Message + "\r\nSQL     : " + SQLString + "\r\n参数    : " + strErr, e.StackTrace);
                return dt;
            }
            finally
            {
                Connection.Close();
                Connection.Dispose();
                cmd.Dispose();
                AddLog.AddSQLLog(SQLString, dtStart.TimeOfDay.ToString(), DateTime.Now.TimeOfDay.ToString(), Convert.ToString(DateTime.Now - dtStart));
            }
        }

        public static bool Exists(string SQLString, MySqlParameter[] Parameters)
        {
            DateTime dtStart = DateTime.Now;
            DataTable dt = new DataTable();
            MySqlConnection Connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(SQLString, Connection);
            try
            {
                Connection.Open();
                cmd.CommandTimeout = 1200;
                if (Parameters != null)
                {
                    cmd.Parameters.AddRange(Parameters);
                }
                MySqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception e)
            {
                string strErr = string.Empty; //p_CmdParms 参数值                        
                AddLog.AddMsgLog(PublicEnum.LogType.SqlError, "SqlBase", e.Message + "\r\nSQL     : " + SQLString + "\r\n参数    : " + strErr, e.StackTrace);
                return false;
            }
            finally
            {
                Connection.Close();
                Connection.Dispose();
                cmd.Dispose();
                AddLog.AddSQLLog(SQLString, dtStart.TimeOfDay.ToString(), DateTime.Now.TimeOfDay.ToString(), Convert.ToString(DateTime.Now - dtStart));
            }
        }


        //Select statement
        public static DataTable Select(string query, MySqlParameter[] Parameters)
        {
            DateTime dtStart = DateTime.Now;
            //Create a list to store the result
            DataTable dt = new DataTable();

            MySqlConnection Connection = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    Connection.Open();
                    cmd.Connection = Connection;
                    cmd.CommandText = query;
                    cmd.CommandTimeout = 1200;
                        //Create a data reader and Execute the command
                        if (Parameters != null)
                        {
                            cmd.Parameters.AddRange(Parameters);
                        }
                        //Read the data and store them in the list
                        MySqlDataReader dr = cmd.ExecuteReader();
                        DataSet ds = new DataSet();
                        DataTable dataTable = new DataTable();
                        ds.Tables.Add(dataTable);
                        ds.EnforceConstraints = false;
                        dataTable.Load(dr);
                        dr.Close();
                        //return list to be displayed
                        return dataTable;
                  }
                  catch (Exception e)
                  {
                      string strErr = string.Empty; //p_CmdParms 参数值                        
                      AddLog.AddMsgLog(PublicEnum.LogType.SqlError, "SqlBase", e.Message + "\r\nSQL     : " + query + "\r\n参数    : " + strErr, e.StackTrace);
                      return dt;
                  }
                  finally
                  {
                      //close connection
                      Connection.Close();
                      Connection.Dispose();
                      cmd.Dispose();
                      AddLog.AddSQLLog(query, dtStart.TimeOfDay.ToString(), DateTime.Now.TimeOfDay.ToString(), Convert.ToString(DateTime.Now - dtStart));
                  }
            
        }

        //Count statement
        public static int Count(string query)
        {
            DateTime dtStart = DateTime.Now;
            int Count = -1;
            //Open Connection
            MySqlConnection Connection = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand();

                try
                {
                    Connection.Open();
                    cmd.Connection = Connection;
                    cmd.CommandText = query;
                    cmd.CommandTimeout = 1200;
                    //ExecuteScalar will return one value
                    Count = int.Parse(cmd.ExecuteScalar()+"");
                }
                catch (Exception e)
                {
                    string strErr = string.Empty; //p_CmdParms 参数值                        
                    AddLog.AddMsgLog(PublicEnum.LogType.SqlError, "SqlBase", e.Message + "\r\nSQL     : " + query + "\r\n参数    : " + strErr, e.StackTrace);
                 
                }
                finally
                {
                    //close connection
                    Connection.Close();
                    Connection.Dispose();
                    cmd.Dispose();
                    AddLog.AddSQLLog(query, dtStart.TimeOfDay.ToString(), DateTime.Now.TimeOfDay.ToString(), Convert.ToString(DateTime.Now - dtStart));
                }
                return Count;
             
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, MySqlParameter[] cmdParms)
        {
            DateTime dtStart = DateTime.Now;
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                int rows = cmd.ExecuteNonQuery();
                cmd.CommandTimeout = 1200;
                cmd.Parameters.Clear();
                return rows;
            }
            catch (Exception e)
            {
                string strErr = string.Empty; //p_CmdParms 参数值
                if (cmdParms != null)
                {
                    foreach (MySqlParameter objParm in cmdParms)
                    {
                        strErr += objParm.ParameterName + " ='" + objParm.Value + "' ";
                    }
                }
                AddLog.AddMsgLog(PublicEnum.LogType.SqlError, "SqlBase", e.Message + "\r\nSQL     : " + SQLString + "\r\n参数    : " + strErr, e.StackTrace);
                throw e;
            }
            finally
            {

                string strErr = string.Empty; //p_CmdParms 参数值
                if (cmdParms != null)
                {
                    foreach (MySqlParameter objParm in cmdParms)
                    {
                        strErr += objParm.ParameterName + " ='" + objParm.Value + "' ";
                    }
                }
                connection.Dispose();
                connection.Close();
                cmd.Dispose();
                AddLog.AddSQLLog(SQLString, dtStart.TimeOfDay.ToString(), DateTime.Now.TimeOfDay.ToString(), Convert.ToString(DateTime.Now - dtStart));
            }
        }
        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, string cmdText, MySqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (MySqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
    }
}
