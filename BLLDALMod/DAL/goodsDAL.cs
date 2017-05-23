using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLLDALMod.DAL
{

    /// <summary>
    /// 数据访问类book。
    /// </summary>
    public class goodsDAL
    {
        public goodsDAL() { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BLLDALMod.Model.Goods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into goods(");
            strSql.Append("Title,MainImage,ContentValidity,PurchaseDate,Price,AddTime,State,type,Remark,UserId)");
            strSql.Append(" values (");
            strSql.Append("@Title,@MainImage,@ContentValidity,@PurchaseDate,@Price,@AddTime,@State,@type,@Remark,@UserId)");
            strSql.Append(";select @@IDENTITY");

            MySqlParameter[] parameters = {
					new MySqlParameter("@Title", MySqlDbType.VarChar,60),
					new MySqlParameter("@MainImage", MySqlDbType.VarChar,200),
					new MySqlParameter("@ContentValidity", MySqlDbType.VarChar,1000),
					new MySqlParameter("@PurchaseDate", MySqlDbType.DateTime),
					new MySqlParameter("@Price", MySqlDbType.Double,9),
					new MySqlParameter("@AddTime", MySqlDbType.DateTime),
					new MySqlParameter("@State", MySqlDbType.VarChar,4),
					new MySqlParameter("@type", MySqlDbType.VarChar,10),
					new MySqlParameter("@Remark", MySqlDbType.VarChar,1000),
                    new MySqlParameter("@UserId", MySqlDbType.Int32,4)                     };
            parameters[0].Value = model.Title;
            parameters[1].Value = model.MainImage;
            parameters[2].Value = model.ContentValidity;
            parameters[3].Value = model.PurchaseDate;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.AddTime;
            parameters[6].Value = model.State;
            parameters[7].Value = model.type;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.UserId;
            object obj = DBhelpmysql.Add(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BLLDALMod.Model.Goods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update goods set ");
            strSql.Append("Title=@Title,");
            strSql.Append("MainImage=@MainImage,");
            strSql.Append("ContentValidity=@ContentValidity,");
            strSql.Append("PurchaseDate=@PurchaseDate,");
            strSql.Append("Price=@Price,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("State=@State,");
            strSql.Append("type=@type,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("UserId=@UserId");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@Title", MySqlDbType.VarChar,60),
					new MySqlParameter("@MainImage", MySqlDbType.VarChar,200),
					new MySqlParameter("@ContentValidity", MySqlDbType.VarChar,1000),
					new MySqlParameter("@PurchaseDate", MySqlDbType.DateTime),
                    new MySqlParameter("@Price", MySqlDbType.Double,9),
					new MySqlParameter("@UpdateTime", MySqlDbType.DateTime),
					new MySqlParameter("@State", MySqlDbType.VarChar,4),
					new MySqlParameter("@type", MySqlDbType.VarChar,10),
                    new MySqlParameter("@Remark", MySqlDbType.VarChar,1000),
                    new MySqlParameter("@UserId", MySqlDbType.Int32,4),
                    new MySqlParameter("@id", MySqlDbType.Int32,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.MainImage;
            parameters[2].Value = model.ContentValidity;
            parameters[3].Value = model.PurchaseDate;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.UpdateTime;
            parameters[6].Value = model.State;
            parameters[7].Value = model.type;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.UserId;
            parameters[10].Value = model.id;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from goods ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32,4)
			};
            parameters[0].Value = id;

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
        public BLLDALMod.Model.Goods GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" id,Title,MainImage,ContentValidity,PurchaseDate,Price,AddTime,UpdateTime,State,type,Remark,UserId ");
            strSql.Append(" from goods ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = { 
                  new MySqlParameter("@id", MySqlDbType.Int32,4)
            };
            parameters[0].Value = id;
            BLLDALMod.Model.Goods model = new BLLDALMod.Model.Goods();
            DataTable ds = DBhelpmysql.Select(strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["id"] != null && ds.Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Rows[0]["id"].ToString());
                }
                if (ds.Rows[0]["Title"] != null && ds.Rows[0]["Title"].ToString() != "")
                {
                    model.Title = ds.Rows[0]["Title"].ToString();
                }
                if (ds.Rows[0]["MainImage"] != null && ds.Rows[0]["MainImage"].ToString() != "")
                {
                    model.MainImage = ds.Rows[0]["MainImage"].ToString();
                }
                if (ds.Rows[0]["ContentValidity"] != null && ds.Rows[0]["ContentValidity"].ToString() != "")
                {
                    model.ContentValidity = ds.Rows[0]["ContentValidity"].ToString();
                }
                if (ds.Rows[0]["PurchaseDate"] != null && ds.Rows[0]["PurchaseDate"].ToString() != "")
                {
                    model.PurchaseDate = DateTime.Parse(ds.Rows[0]["PurchaseDate"].ToString());
                }
                if (ds.Rows[0]["Price"] != null && ds.Rows[0]["Price"].ToString() != "")
                {
                    model.Price = Double.Parse(ds.Rows[0]["Price"].ToString());
                }
                if (ds.Rows[0]["AddTime"] != null && ds.Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Rows[0]["AddTime"].ToString());
                }
                if (ds.Rows[0]["UpdateTime"] != null && ds.Rows[0]["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(ds.Rows[0]["UpdateTime"].ToString());
                }
                if (ds.Rows[0]["State"] != null && ds.Rows[0]["State"].ToString() != "")
                {
                    model.State = ds.Rows[0]["State"].ToString();
                }
                if (ds.Rows[0]["type"] != null && ds.Rows[0]["type"].ToString() != "")
                {
                    model.type = ds.Rows[0]["type"].ToString();
                }
                if (ds.Rows[0]["Remark"] != null && ds.Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Rows[0]["Remark"].ToString();
                }
                if (ds.Rows[0]["UserId"] != null && ds.Rows[0]["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(ds.Rows[0]["UserId"].ToString());
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
            strSql.Append("select id,Title,MainImage,ContentValidity,PurchaseDate,Price,AddTime,UpdateTime,State,type,Remark,UserId ");
            strSql.Append(" FROM goods ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBhelpmysql.Select(strSql.ToString(), null);
        }

        /*
        */

        #endregion  成员方法
    }
}
