using System;
using System.Configuration;
namespace Maticsoft.DBUtility
{
    
    public class PubConstant
    {
        static string appPath = System.Web.HttpContext.Current.Request.ApplicationPath;
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {           
            get 
            {
                string _connectionString = ConfigurationManager.ConnectionStrings["AccessConnStr1"].ToString() + System.Web.HttpContext.Current.Server.MapPath(appPath + "/App_Data/access.mdb");      
                //string _connectionString = ConfigurationManager.ConnectionStrings["mysqlconn"].ConnectionString + ";Charset=utf8";
               
                return _connectionString; 
            }
        }

      
    }
}
