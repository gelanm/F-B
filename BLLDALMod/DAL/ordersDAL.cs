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
