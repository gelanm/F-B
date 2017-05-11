using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//请先添加引用
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类book。
    /// </summary>
    public class book
    {
        public book()
        { }
        #region  成员方法


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Maticsoft.Model.book model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.id != null)
            {
                strSql1.Append("id,");
                strSql2.Append("" + model.id + ",");
            }
            if (model.liuyantitle != null)
            {
                strSql1.Append("liuyantitle,");
                strSql2.Append("'" + model.liuyantitle + "',");
            }
            if (model.liuyangcontent != null)
            {
                strSql1.Append("liuyangcontent,");
                strSql2.Append("'" + model.liuyangcontent + "',");
            }
            if (model.username != null)
            {
                strSql1.Append("lianxiren,");
                strSql2.Append("'" + model.username + "',");
            }
            if (model.phonenum != null)
            {
                strSql1.Append("lianxidianhua,");
                strSql2.Append("'" + model.phonenum + "',");
            }
            if (model.liuyantitme != null)
            {
                strSql1.Append("liuyantitme,");
                strSql2.Append("'" + model.liuyantitme + "',");
            }
            if (model.hueifu != null)
            {
                strSql1.Append("hueifu,");
                strSql2.Append("'" + model.hueifu + "',");
            }
            strSql.Append("insert into book(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Maticsoft.Model.book model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update book set ");
            if (model.id != null)
            {
                strSql.Append("id=" + model.id + ",");
            }
            if (model.liuyantitle != null)
            {
                strSql.Append("liuyantitle='" + model.liuyantitle + "',");
            }
            if (model.liuyangcontent != null)
            {
                strSql.Append("liuyangcontent='" + model.liuyangcontent + "',");
            }
            if (model.liuyantitme != null)
            {
                strSql.Append("liuyantitme='" + model.liuyantitme + "',");
            }
            if (model.hueifu != null)
            {
                strSql.Append("hueifu='" + model.hueifu + "',");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where id=" + model.id + "");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from book ");
            strSql.Append(" where id=" + id + " ");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
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
            strSql.Append(" where id=" + id + " ");
            Maticsoft.Model.book model = new Maticsoft.Model.book();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.liuyantitle = ds.Tables[0].Rows[0]["liuyantitle"].ToString();
                model.liuyangcontent = ds.Tables[0].Rows[0]["liuyangcontent"].ToString();
                if (ds.Tables[0].Rows[0]["liuyantitme"].ToString() != "")
                {
                    model.liuyantitme = DateTime.Parse(ds.Tables[0].Rows[0]["liuyantitme"].ToString());
                }
                model.hueifu = ds.Tables[0].Rows[0]["hueifu"].ToString();
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,liuyantitle,liuyangcontent,liuyantitme,hueifu ");
            strSql.Append(" FROM book ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /*
        */

        #endregion  成员方法
    }
}