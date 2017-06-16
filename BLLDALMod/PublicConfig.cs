using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;

/// <summary>
/// PublicConfig 的摘要说明
/// </summary>
public class PublicConfig
{
	#region 获取WebConfig中的配置信息
        /// <summary>
        /// 导出Excel临时存放目录
        /// </summary>
        public static string ExportExcelTmpPath = GetConfigNodeValue("ExportExcelTmpPath");
        /// <summary>
        /// 记录登录角色权限配置文件路径
        /// </summary>
        public static string AuthPath = GetConfigNodeValue("AuthPath");
        /// <summary>
        /// 日志地址
        /// </summary>
        public static string LogPath = GetConfigNodeValue("LogPath");
        /// <summary>
        /// 日志地址
        /// </summary>
        public static string LogPathPay = GetConfigNodeValue("LogPathPay");
        /// <summary>
        /// Xml地址
        /// </summary>
        public static string XmlPath = GetConfigNodeValue("XmlPath");
        /// <summary>
        /// 图片地址
        /// </summary>
        public static string ImgPath = GetConfigNodeValue("ImgPath");
        /// <summary>
        /// 日志地址
        /// </summary>
        public static string uploadPath = GetConfigNodeValue("uploadPath");
        /// <summary>
        /// 
        /// </summary>
        public static string IsSQLLog = GetConfigNodeValue("IsSQLLog");
        /// <summary>
        /// ReportTimeDaysSpan1 获取报表 时间配置
        /// </summary>
        public static int ReportTimeDaysSpan = Convert.ToInt32(GetConfigNodeValue("ReportTimeDaysSpan"));

        /// <summary>
        /// memoryip
        /// </summary>
        public static string MemoryIP = GetConfigNodeValue("memoryip");
        #endregion

        #region 取Webconfig节点
        /// </summary>
        /// <param name="p_strConfigNode">节点名字</param>
        /// <returns>返回节点的Value值</returns>
        private static string GetConfigNodeValue(string p_strConfigNode)
        {
            if (ConfigurationManager.AppSettings[p_strConfigNode] == null)
            {
                return string.Empty;
            }
            return ConfigurationManager.AppSettings[p_strConfigNode].ToString();
        }
        #endregion
}