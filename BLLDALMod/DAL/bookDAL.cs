using System;
using System.Collections.Generic;
using System.Web;
using Maticsoft.DBUtility;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;//请先添加引用

namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类book。
    /// </summary>
    public class bookDAL
    {
        public bookDAL(){}
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.book model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into book(");
            strSql.Append("liuyantitle,liuyangcontent,lianxiren,lianxidianhua,liuyantitme,hueifu)");
            strSql.Append(" values (");
            strSql.Append("@liuyantitle,@liuyangcontent,@lianxiren,@lianxidianhua,@liuyantitme,@hueifu)");
            strSql.Append(";select @@IDENTITY");

            MySqlParameter[] parameters = {
					new MySqlParameter("@liuyantitle", MySqlDbType.VarChar,50),
					new MySqlParameter("@liuyangcontent", MySqlDbType.VarChar,1000),
					new MySqlParameter("@lianxiren", MySqlDbType.VarChar,255),
					new MySqlParameter("@lianxidianhua", MySqlDbType.VarChar,255),
					new MySqlParameter("@liuyantitme", MySqlDbType.DateTime),
					new MySqlParameter("@hueifu", MySqlDbType.VarChar,1000)};
            parameters[0].Value = model.liuyantitle;
            parameters[1].Value = model.liuyangcontent;
            parameters[2].Value = model.username;
            parameters[3].Value = model.phonenum;
            parameters[4].Value = model.liuyantitme;
            parameters[5].Value = model.hueifu;

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
        public bool Update(Maticsoft.Model.book model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update book set ");
            strSql.Append("liuyantitle=@liuyantitle,");
            strSql.Append("liuyangcontent=@liuyangcontent,");
            strSql.Append("liuyantitme=@liuyantitme,");
            strSql.Append("hueifu=@hueifu");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@liuyantitle", MySqlDbType.VarChar,50),
					new MySqlParameter("@liuyangcontent", MySqlDbType.VarChar,1000),
					new MySqlParameter("@liuyantitme", MySqlDbType.DateTime),
					new MySqlParameter("@hueifu", MySqlDbType.VarChar,1000),
                    new MySqlParameter("@id", MySqlDbType.Int32,4)};
            parameters[0].Value = model.liuyantitle;
            parameters[1].Value = model.liuyangcontent;
            parameters[2].Value = model.liuyantitme;
            parameters[3].Value = model.hueifu;
            parameters[4].Value = model.id;

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
            strSql.Append("delete from book ");
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
        public Maticsoft.Model.book GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" id,liuyantitle,liuyangcontent,liuyantitme,hueifu ");
            strSql.Append(" from book ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = { 
                  new MySqlParameter("@id", MySqlDbType.Int32,4)
            };
            parameters[0].Value = id;
            Maticsoft.Model.book model = new Maticsoft.Model.book();
            DataTable ds = DBhelpmysql.Select(strSql.ToString(), parameters);
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows[0]["id"] != null && ds.Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Rows[0]["id"].ToString());
                }
                if (ds.Rows[0]["liuyantitle"] != null && ds.Rows[0]["liuyantitle"].ToString() != "")
                {
                    model.liuyantitle = ds.Rows[0]["liuyantitle"].ToString();
                }
                if (ds.Rows[0]["liuyantitme"] != null && ds.Rows[0]["liuyantitme"].ToString() != "")
                {
                    model.liuyantitme = DateTime.Parse(ds.Rows[0]["liuyantitme"].ToString());
                }
                if (ds.Rows[0]["hueifu"] != null && ds.Rows[0]["hueifu"].ToString() != "")
                {
                    model.hueifu = ds.Rows[0]["hueifu"].ToString();
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
            strSql.Append("select id,liuyantitle,liuyangcontent,liuyantitme,hueifu ");
            strSql.Append(" FROM book ");
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