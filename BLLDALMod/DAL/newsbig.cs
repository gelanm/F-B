using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;//请先添加引用
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类newsbig。
	/// </summary>
	public class newsbig
	{
        public static string connectionString = PubConstant.ConnectionString;  
		public newsbig()
		{}
		#region  成员方法


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from newsbig");
			strSql.Append(" where id="+id+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.newsbig model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			
			 
				strSql1.Append("newsclass,");
				strSql2.Append("@newsclass,");
			 
				strSql1.Append("newsid,");
				strSql2.Append("@newsid,");
			 
			strSql.Append("insert into newsbig(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");

            MySqlParameter[] Parameters = {
					new MySqlParameter("@newsclass", MySqlDbType.VarChar, 100),
					new MySqlParameter("@newsid", MySqlDbType.Int32, 4)};

            Parameters[0].Value = model.newsclass;
            Parameters[1].Value = model.newsid;

            if (DBhelpmysql.ExecuteSql(strSql.ToString(), Parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Maticsoft.Model.newsbig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update newsbig set ");
			if (model.id != null)
			{
				strSql.Append("id="+model.id+",");
			}
			if (model.newsclass != null)
			{
				strSql.Append("newsclass='"+model.newsclass+"',");
			}
			if (model.newsid != null)
			{
				strSql.Append("newsid="+model.newsid+",");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where id="+ model.id+" ");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from newsbig ");
			strSql.Append(" where id="+id+" " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.newsbig GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" id,newsclass,newsid ");
			strSql.Append(" from newsbig ");
			strSql.Append(" where id="+id+" " );
			Maticsoft.Model.newsbig model=new Maticsoft.Model.newsbig();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.newsclass=ds.Tables[0].Rows[0]["newsclass"].ToString();
				if(ds.Tables[0].Rows[0]["newsid"].ToString()!="")
				{
					model.newsid=int.Parse(ds.Tables[0].Rows[0]["newsid"].ToString());
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
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,newsclass,newsid ");
			strSql.Append(" FROM newsbig ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}
        public List<Model.newsbig> get_List()
        {
            List<Model.newsbig> List = new List<Model.newsbig>();
            DataTable dt = DBhelpmysql.Query("select * from newsbig where newsid=0 ");
            foreach (DataRow dr in dt.Rows)
            {
                Model.newsbig model = new Model.newsbig();
                model.id = Convert.ToInt32(dr["id"]);
                model.newsclass = dr["newsclass"].ToString();
                model.newsid = Convert.ToInt32(dr["newsid"]);
                List.Add(model);
            }
            return List;
        }

        public List<Model.newsbig> get_List(string ParentID)
        {
            List<Model.newsbig> List = new List<Model.newsbig>();
            DataTable dt = DBhelpmysql.Query("select * from newsbig where newsid=" + ParentID + " ");
            foreach (DataRow dr in dt.Rows)
            {
                Model.newsbig model = new Model.newsbig();
                model.id = Convert.ToInt32(dr["id"]);
                model.newsclass = dr["newsclass"].ToString();
                model.newsid = Convert.ToInt32(dr["newsid"]);
                List.Add(model);
            }
            return List;
        }

        protected DataSet getDataSet(string sql)
        {
            OleDbConnection conn = new OleDbConnection(connectionString);
            conn.Open();

            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public DataTable GetAll(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql = new StringBuilder();
            strSql.Append("select * from newsbig where newsid=" + id + "");
            return DbHelperOleDb.Fill(strSql.ToString());
        }
		/*
		*/

		#endregion  成员方法
	}
}

