using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLDALMod.Model
{
    /// <summary>
    /// 表[goods]的实体类
    /// </summary>
    public class Goods
    {

        #region 成员变量、构造函数
        string m_strTableName;
        long m_id;
        string m_Title;
        string m_MainImage;
        string m_ContentValidity;
        DateTime m_PurchaseDate;
        double m_Price;
        DateTime m_AddTime;
        DateTime m_UpdateTime;
        string m_State;
        string m_type;
        string m_Remark;

        /// <summary>
        /// 初始化类 Goods 的新实例。
        /// </summary>
        public Goods()
        {
            m_strTableName = "goods";
        }
        #endregion

        #region 字段属性
        /// <summary>
        /// 获取实体类对应的数据库表名。
        /// </summary>
        public string TableName
        {
            get
            {
                return m_strTableName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public long id
        {
            get
            {
                return m_id;
            }
            set
            {
                m_id = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string MainImage
        {
            get
            {
                return m_MainImage;
            }
            set
            {
                m_MainImage = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ContentValidity
        {
            get
            {
                return m_ContentValidity;
            }
            set
            {
                m_ContentValidity = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime PurchaseDate
        {
            get
            {
                return m_PurchaseDate;
            }
            set
            {
                m_PurchaseDate = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Price
        {
            get
            {
                return m_Price;
            }
            set
            {
                m_Price = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            get
            {
                return m_AddTime;
            }
            set
            {
                m_AddTime = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime
        {
            get
            {
                return m_UpdateTime;
            }
            set
            {
                m_UpdateTime = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string State
        {
            get
            {
                return m_State;
            }
            set
            {
                m_State = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string type
        {
            get
            {
                return m_type;
            }
            set
            {
                m_type = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            get
            {
                return m_Remark;
            }
            set
            {
                m_Remark = value;
            }
        }

        #endregion

    }
}
