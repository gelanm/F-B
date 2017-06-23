using BLLDALMod.Model;
using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLLDALMod.DAL
{
    public partial class ordersDAL
    {
        public ordersDAL()
        { }

        #region  成员方法

        /// <summary>
        /// 插入MySQL数据
        /// </summary>
        public int InsertMysql(orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into orders(");
            strSql.Append("OrderNumber, AId, BId, AGoodId, BGoodId, CreateDate, UpdateDate, Memo, Status)");
            strSql.Append(" values (");
            strSql.Append("@OrderNumber, @AId, @BId, @AGoodId, @BGoodId, @CreateDate, @UpdateDate, @Memo, @Status)");
            strSql.Append(";select @@IDENTITY");

            MySqlParameter[] parameters = {
					new MySqlParameter("@OrderNumber", MySqlDbType.VarChar,100),
					new MySqlParameter("@AId", MySqlDbType.Int16,4),
					new MySqlParameter("@BId", MySqlDbType.Int16,4),
					new MySqlParameter("@AGoodId", MySqlDbType.Int16,4),
					new MySqlParameter("@BGoodId", MySqlDbType.Int16,4),
					new MySqlParameter("@CreateDate", MySqlDbType.DateTime, 8),
                    new MySqlParameter("@UpdateDate", MySqlDbType.DateTime, 8),
					new MySqlParameter("@Memo", MySqlDbType.VarChar,1000),
					new MySqlParameter("@Status", MySqlDbType.VarChar,10)};
            parameters[0].Value = model.OrderNumber;
            parameters[1].Value = model.Aid;
            parameters[2].Value = model.Bid;
            parameters[3].Value = model.AGoodId;
            parameters[4].Value = model.BGoodId;
            parameters[5].Value = model.CreateDate;
            parameters[6].Value = model.UpdateTime;
            parameters[7].Value = model.Memo;
            parameters[8].Value = model.Status;

            object obj = DBhelpmysql.Insert(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
            //return 1;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BLLDALMod.Model.orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update orders set ");
            strSql.Append("OrderNumber=@OrderNumber,");
            strSql.Append("AId=@AId,");
            strSql.Append("BId=@BId,");
            strSql.Append("AGoodId=@AGoodId,");
            strSql.Append("BGoodId=@BGoodId,");
            strSql.Append("UpdateDate=@UpdateDate,");
            strSql.Append("Memo=@Memo,");
            strSql.Append("Status=@Status ");
            strSql.Append(" where Id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@OrderNumber", MySqlDbType.VarChar,100),
					new MySqlParameter("@AId", MySqlDbType.Int16,4),
					new MySqlParameter("@BId", MySqlDbType.Int16,4),
					new MySqlParameter("@AGoodId", MySqlDbType.Int16,4),
					new MySqlParameter("@BGoodId", MySqlDbType.Int16,4),
                    new MySqlParameter("@UpdateDate", MySqlDbType.DateTime, 8),
					new MySqlParameter("@Memo", MySqlDbType.VarChar,1000),
					new MySqlParameter("@Status", MySqlDbType.VarChar,10),
                    new MySqlParameter("@id", MySqlDbType.Int32,4)};
            parameters[0].Value = model.OrderNumber;
            parameters[1].Value = model.Aid;
            parameters[2].Value = model.Bid;
            parameters[3].Value = model.AGoodId;
            parameters[4].Value = model.BGoodId;
            parameters[5].Value = model.UpdateTime;
            parameters[6].Value = model.Memo;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.Id;

            int rows = DBhelpmysql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BLLDALMod.Model.orders GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" * ");
            strSql.Append(" from orders ");
            strSql.Append(" where Id=@id");
            MySqlParameter[] parameters = { 
                  new MySqlParameter("@id", MySqlDbType.Int32,4)
            };
            parameters[0].Value = id;
            BLLDALMod.Model.orders model = new BLLDALMod.Model.orders();
            DataTable ds = DBhelpmysql.Select(strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["Id"] != null && ds.Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Rows[0]["Id"].ToString());
                }
                if (ds.Rows[0]["OrderNumber"] != null && ds.Rows[0]["OrderNumber"].ToString() != "")
                {
                    model.OrderNumber = ds.Rows[0]["OrderNumber"].ToString();
                }
                if (ds.Rows[0]["AId"] != null && ds.Rows[0]["AId"].ToString() != "")
                {
                    model.Aid = int.Parse(ds.Rows[0]["AId"].ToString());
                }
                if (ds.Rows[0]["BId"] != null && ds.Rows[0]["BId"].ToString() != "")
                {
                    model.Bid = int.Parse(ds.Rows[0]["BId"].ToString());
                }
                if (ds.Rows[0]["AGoodId"] != null && ds.Rows[0]["AGoodId"].ToString() != "")
                {
                    model.AGoodId = int.Parse(ds.Rows[0]["AGoodId"].ToString());
                }
                if (ds.Rows[0]["BGoodId"] != null && ds.Rows[0]["BGoodId"].ToString() != "")
                {
                    model.BGoodId = int.Parse(ds.Rows[0]["BGoodId"].ToString());
                }
                if (ds.Rows[0]["CreateDate"] != null && ds.Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Rows[0]["CreateDate"].ToString());
                }
                if (ds.Rows[0]["UpdateDate"] != null && ds.Rows[0]["UpdateDate"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(ds.Rows[0]["UpdateDate"].ToString());
                }
                if (ds.Rows[0]["Status"] != null && ds.Rows[0]["Status"].ToString() != "")
                {
                    model.Status = ds.Rows[0]["Status"].ToString();
                }
                if (ds.Rows[0]["Memo"] != null && ds.Rows[0]["Memo"].ToString() != "")
                {
                    model.Memo = ds.Rows[0]["Memo"].ToString();
                }

                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM orders ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBhelpmysql.Select(strSql.ToString(), null);
        }

        //public int getOtherGoodId(int id)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select * ");
        //    strSql.Append(" FROM orders ");
        //    strSql.Append(" Where  AGoodId ");
        //    return 1;
        //}

        public DataTable GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from orders ");
            DataTable dt = DBhelpmysql.Select(strSql.ToString(), null);

            return dt;
        }
        #endregion

    }
}
