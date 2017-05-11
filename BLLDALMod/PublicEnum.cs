using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// PublicEnum 的摘要说明
/// </summary>
public class PublicEnum
{
    #region 日志错误类型
    /// 类功能描述: 日志错误类型
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// 消息
        /// </summary>
        Msg,
        /// <summary>
        /// 警告
        /// </summary>
        Warning,
        /// <summary>
        /// 逻辑错误
        /// </summary>
        SqlError,
        /// <summary>
        /// 逻辑错误
        /// </summary>
        BLLError,

        ///短信 
        /// 
        SMS,

        ///
        /// 
        /// 
        Sql,
        /// <summary>
        /// 页面错误
        /// </summary>
        PageError,
        /// <summary>  
        /// 系统捕获异常错误
        /// </summary>
        GlobalError

    }
    #endregion
}