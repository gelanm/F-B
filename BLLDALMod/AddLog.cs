using System;
using System.Text;
using System.IO;
using System.Configuration;
using System.Threading;

/// <summary>
/// AddLog 的摘要说明
/// </summary>
public class AddLog
{
    /// <summary>
    /// 定义支持单个写线程和多个读线程的锁
    /// </summary>
    public static ReaderWriterLock m_boolLogLock = new ReaderWriterLock();

    public static void AddSqlLog(PublicEnum.LogType p_enuErrType, string p_strModule, string p_strMsg, string p_strErrorStack)
    {
        // 获取错误信息Txt文本的路径
        string strLogDiv = PublicConfig.LogPath;
        if (!Directory.Exists(strLogDiv))
        {
            Directory.CreateDirectory(strLogDiv);
        }
        //获取Txt文本的路径名称
        string strFilePath = strLogDiv + DateTime.Now.ToString("yyyy-MM-dd") + "sql.txt";

        StreamWriter objStrWriter = null;
        try
        {
            if (m_boolLogLock != null)
            {
                m_boolLogLock.AcquireWriterLock(Timeout.Infinite);
                // 判断该日志文件是否存在
                if (!File.Exists(strFilePath))
                {
                    objStrWriter = File.CreateText(strFilePath);
                }
                else
                {
                    objStrWriter = File.AppendText(strFilePath);
                }
                // 写入当前日志信息
                objStrWriter.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
                objStrWriter.WriteLine("时间: [" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "] ");
                objStrWriter.WriteLine("类型: [" + p_enuErrType.ToString() + "] ");
                objStrWriter.WriteLine("位置: [" + p_strModule + "]");
                objStrWriter.WriteLine("描述: " + p_strMsg + "");
                objStrWriter.WriteLine("堆栈: " + p_strErrorStack.Replace("   ", "").Replace("\r\n", "\r\n          ") + "");
            }
        }
        catch
        {
        }
        finally
        {
            if (m_boolLogLock != null)
            {
                m_boolLogLock.ReleaseWriterLock();
                if (objStrWriter != null)
                {
                    objStrWriter.Close();
                }
            }
        }
    }

    #region 添加错误信息
    /// <summary>
    /// 功能描述: 添加错误信息
    /// </summary>
    /// <param name="p_enuErrType">错误类型</param>
    /// <param name="p_strModule">错误模块，页面。便于定位</param>
    /// <param name="p_strMsg">错误信息注释</param>
    /// <param name="p_strErrorStack">错误信息</param>
    public static void AddMsgLog(PublicEnum.LogType p_enuErrType, string p_strModule, string p_strMsg, string p_strErrorStack)
    {
        // 获取错误信息Txt文本的路径
        string strLogDiv = PublicConfig.LogPath;
        if (!Directory.Exists(strLogDiv))
        {
            Directory.CreateDirectory(strLogDiv);
        }
        //获取Txt文本的路径名称
        string strFilePath = strLogDiv + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

        StreamWriter objStrWriter = null;
        try
        {
            if (m_boolLogLock != null)
            {
                m_boolLogLock.AcquireWriterLock(Timeout.Infinite);
                // 判断该日志文件是否存在
                if (!File.Exists(strFilePath))
                {
                    objStrWriter = File.CreateText(strFilePath);
                }
                else
                {
                    objStrWriter = File.AppendText(strFilePath);
                }
                // 写入当前日志信息
                objStrWriter.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
                objStrWriter.WriteLine("错误时间: [" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "] ");
                objStrWriter.WriteLine("错误类型: [" + p_enuErrType.ToString() + "] ");
                objStrWriter.WriteLine("错误位置: [" + p_strModule + "]");
                objStrWriter.WriteLine("错误描述: " + p_strMsg + "");
                objStrWriter.WriteLine("错误堆栈: " + p_strErrorStack.Replace("   ", "").Replace("\r\n", "\r\n          ") + "");
            }
        }
        catch
        {
        }
        finally
        {
            if (m_boolLogLock != null)
            {
                m_boolLogLock.ReleaseWriterLock();
                if (objStrWriter != null)
                {
                    objStrWriter.Close();
                }
            }
        }
    }

    public static void AddWebLog(PublicEnum.LogType p_enuErrType, string p_strModule, string p_strMsg, string p_strErrorStack)
    {
        // 获取错误信息Txt文本的路径
        string strLogDiv = PublicConfig.LogPath;
        if (!Directory.Exists(strLogDiv))
        {
            Directory.CreateDirectory(strLogDiv);
        }
        //获取Txt文本的路径名称
        string strFilePath = strLogDiv + DateTime.Now.ToString("yyyy-MM-dd") + "Web.txt";

        StreamWriter objStrWriter = null;
        try
        {
            if (m_boolLogLock != null)
            {
                m_boolLogLock.AcquireWriterLock(Timeout.Infinite);
                // 判断该日志文件是否存在
                if (!File.Exists(strFilePath))
                {
                    objStrWriter = File.CreateText(strFilePath);
                }
                else
                {
                    objStrWriter = File.AppendText(strFilePath);
                }
                // 写入当前日志信息
                objStrWriter.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
                objStrWriter.WriteLine("错误时间: [" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "] ");
                objStrWriter.WriteLine("错误类型: [" + p_enuErrType.ToString() + "] ");
                objStrWriter.WriteLine("错误位置: [" + p_strModule + "]");
                objStrWriter.WriteLine("错误描述: " + p_strMsg + "");
                objStrWriter.WriteLine("错误堆栈: " + p_strErrorStack.Replace("   ", "").Replace("\r\n", "\r\n          ") + "");
            }
        }
        catch
        {
        }
        finally
        {
            if (m_boolLogLock != null)
            {
                m_boolLogLock.ReleaseWriterLock();
                if (objStrWriter != null)
                {
                    objStrWriter.Close();
                }
            }
        }
    }

    #endregion

    #region 添加错误信息
    /// <summary>
    /// 功能描述: 添加错误信息
    /// </summary>
    /// <param name="p_enuErrType">错误类型</param>
    /// <param name="p_strModule">错误模块，页面。便于定位</param>
    /// <param name="p_strMsg">错误信息注释</param>
    /// <param name="p_strErrorStack">错误信息</param>
    public static void AddSmsLog(PublicEnum.LogType p_enuErrType, string p_strModule, string p_strMsg, string p_strErrorStack)
    {
        // 获取错误信息Txt文本的路径
        string strLogDiv = PublicConfig.LogPath;
        if (!Directory.Exists(strLogDiv))
        {
            Directory.CreateDirectory(strLogDiv);
        }
        //获取Txt文本的路径名称
        string strFilePath = strLogDiv + DateTime.Now.ToString("yyyy-MM-dd") + "SMS.txt";

        StreamWriter objStrWriter = null;
        try
        {
            if (m_boolLogLock != null)
            {
                m_boolLogLock.AcquireWriterLock(Timeout.Infinite);
                // 判断该日志文件是否存在
                if (!File.Exists(strFilePath))
                {
                    objStrWriter = File.CreateText(strFilePath);
                }
                else
                {
                    objStrWriter = File.AppendText(strFilePath);
                }
                // 写入当前日志信息
                objStrWriter.WriteLine("----------------------------------------------------------------------------------------------------------------------------");
                objStrWriter.WriteLine("发送时间: [" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "] ");
                objStrWriter.WriteLine("发送类型: [" + p_enuErrType.ToString() + "] ");
                objStrWriter.WriteLine("发送位置: [" + p_strModule + "]");
                objStrWriter.WriteLine("发送描述: " + p_strMsg + "");
                objStrWriter.WriteLine("发送结果: " + p_strErrorStack.Replace("   ", "").Replace("\r\n", "\r\n          ") + "");
            }
        }
        catch
        {
        }
        finally
        {
            if (m_boolLogLock != null)
            {
                m_boolLogLock.ReleaseWriterLock();
                if (objStrWriter != null)
                {
                    objStrWriter.Close();
                }
            }
        }
    }
    #endregion

    #region 添加一条sql日志
    /// 功能描述: 添加一条sql日志
    /// </summary>
    /// <param name="p_strSQL">sql语句</param>
    /// <param name="p_strStrat">开始时间</param>
    /// <param name="p_strEnd">结束时间</param>
    /// <param name="p_strSpace">花费时间</param>
    /// <returns>添加是否成功</returns>
    public static bool AddSQLLog(string p_strSQL, string p_strStrat, string p_strEnd, string p_strSpace)
    {
        if (PublicConfig.IsSQLLog.ToUpper() == "N")
        {
            return false;
        }
        // 获取SQL存储Txt文本的路径
        string strLogDiv = PublicConfig.LogPath;
        if (!Directory.Exists(strLogDiv))
        {
            Directory.CreateDirectory(strLogDiv);
        }
        //获取Txt文本的路径名称
        string strFilePath = strLogDiv + DateTime.Now.ToString("yyyy-MM-dd") + "SQL.txt";

        StreamWriter objStrWriter = null;
        try
        {
            if (m_boolLogLock != null)
            {
                m_boolLogLock.AcquireWriterLock(System.Threading.Timeout.Infinite);
                // 判断该日志文件是否存在
                if (!File.Exists(strFilePath))
                {
                    objStrWriter = File.CreateText(strFilePath);
                }
                else
                {
                    objStrWriter = File.AppendText(strFilePath);
                }

                // 写入当前日志信息
                objStrWriter.WriteLine("<Log>");
                objStrWriter.WriteLine("   <SQL>" + p_strSQL.Replace("<", "《").Replace(">", "》") + "</SQL>");
                objStrWriter.WriteLine("    <Start>" + p_strStrat + "</Start>");
                objStrWriter.WriteLine("    <End>" + p_strEnd + "</End>");
                objStrWriter.WriteLine("    <Space>" + p_strSpace + "</Space>");
                objStrWriter.WriteLine("</Log>");
            }

        }
        catch
        {
        }
        finally
        {
            if (m_boolLogLock != null)
            {
                m_boolLogLock.ReleaseWriterLock();
                if (objStrWriter != null)
                {
                    objStrWriter.Close();
                }
            }
        }
        return true;
    }
    #endregion

    #region 存在文件就从新生成，不存在创建
    /// <summary>
    /// 作者:     杨韦庚
    /// 创建时间: 2009-04-16
    /// 功能描述: 存在文件就从新生成，不存在创建
    /// </summary>
    /// <param name="p_strFilePath">文件路径</param>
    /// <param name="p_strFileName">文件名称</param>
    /// <param name="p_strFileValue">文件内容</param>
    /// <param name="p_boolIsDeleteOldFile">是否存在文件</param>
    /// <returns>添加是否成功</returns>
    public static bool AddFile(string p_strFilePath, string p_strFileName, string p_strFileValue, bool p_boolIsDeleteOldFile)
    {
        string strFile = p_strFilePath + "/" + p_strFileName;

        StreamWriter objStrWriter = null;
        try
        {
            //判断文件路径是否存在，不存在创建路径
            if (!Directory.Exists(p_strFilePath))
            {
                Directory.CreateDirectory(p_strFilePath);
            }
            if (p_boolIsDeleteOldFile)
            {
                if (File.Exists(strFile))
                {
                    //删除原来的文件
                    File.Delete(strFile);
                }
            }
            // 判断该文件是否存在
            if (!File.Exists(strFile))
            {
                objStrWriter = File.CreateText(strFile);
            }
            else
            {
                objStrWriter = File.AppendText(strFile);
            }
            // 写入当前日志信息
            objStrWriter.WriteLine(p_strFileValue);
        }
        catch
        {
            return false;
        }
        finally
        {
            objStrWriter.Close();
        }
        return true;
    }
    #endregion

    #region 获取文件全部内容，如果不存在返回p_boolIsHasFile为false
    /// <summary>
    /// 作者:     杨韦庚
    /// 创建时间: 2009-04-16
    /// 功能描述: 获取文件全部内容，如果不存在返回p_boolIsHasFile为false
    /// </summary>
    /// <param name="p_strFilePath">文件路径</param>
    /// <param name="p_strFileName">文件名称</param>
    /// <param name="p_boolIsHasFile">返回是否存在文件</param>
    /// <returns>文件内容</returns>
    public static string GetFile(string p_strFilePath, string p_strFileName, ref bool p_boolIsHasFile)
    {
        string strFile = p_strFilePath + "/" + p_strFileName;
        if (!File.Exists(strFile))
        {
            p_boolIsHasFile = false;
            return "";
        }
        else
        {
            p_boolIsHasFile = true;
        }
        using (TextReader streamReader = new StreamReader(strFile))
        {
            return streamReader.ReadToEnd();
        }

    }
    #endregion
}