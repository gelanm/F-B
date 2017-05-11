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
using Maticsoft.DBUtility;//请先添加引用
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类productclass。
	/// </summary>
	public class productclass
	{
        public static string connectionString = PubConstant.ConnectionString;  
		public productclass()
		{}
		#region  成员方法


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from productclass");
			strSql.Append(" where id="+id+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.productclass model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.id != null)
			{
				strSql1.Append("id,");
				strSql2.Append(""+model.id+",");
			}
			if (model.productname != null)
			{
				strSql1.Append("productname,");
				strSql2.Append("'"+model.productname+"',");
			}
			if (model.productid != null)
			{
				strSql1.Append("productid,");
				strSql2.Append(""+model.productid+",");
			}
            if (model.content != null)
            {
                strSql1.Append("content,");
                strSql2.Append("'" + model.content + "',");
            }
			strSql.Append("insert into productclass(");
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
		public void Update(Maticsoft.Model.productclass model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update productclass set ");
            strSql.Append("content='" + model.content + "',");
            strSql.Append("propic='" + model.propic + "'");
            strSql.Append(" where ID=" + model.id + "");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from productclass ");
			strSql.Append(" where id="+id+" " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.productclass GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" id,productname,productid,content,propic ");
			strSql.Append(" from productclass ");
			strSql.Append(" where id="+id+" " );
			Maticsoft.Model.productclass model=new Maticsoft.Model.productclass();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.productname=ds.Tables[0].Rows[0]["productname"].ToString();
				if(ds.Tables[0].Rows[0]["productid"].ToString()!="")
				{
					model.productid=int.Parse(ds.Tables[0].Rows[0]["productid"].ToString());
				}
                model.content = ds.Tables[0].Rows[0]["content"].ToString();
                model.propic = ds.Tables[0].Rows[0]["propic"].ToString();
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
			strSql.Append("select id,productname,productid ");
			strSql.Append(" FROM productclass ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}
        public List<Model.productclass> get_List()
        {
            List<Model.productclass> List = new List<Model.productclass>();
            DataTable dt = getDataSet("select * from productclass where productid=0 ").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                Model.productclass model = new Model.productclass();
                model.id = Convert.ToInt32(dr["id"]);
                model.productname = dr["productname"].ToString();
                model.productid = Convert.ToInt32(dr["productid"]);
                List.Add(model);
            }
            return List;
        }

        public List<Model.productclass> get_List(string ParentID)
        {
            List<Model.productclass> List = new List<Model.productclass>();
            DataTable dt = getDataSet("select * from productclass where productid=" + ParentID + " ").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                Model.productclass model = new Model.productclass();
                model.id = Convert.ToInt32(dr["id"]);
                model.productname = dr["productname"].ToString();
                model.productid = Convert.ToInt32(dr["productid"]);
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
            strSql.Append("select * from productclass where productid=" + id + " ORDER BY [id] DESC");
            return DbHelperOleDb.Fill(strSql.ToString());
        }
		/*
		*/

		#endregion  成员方法
	}
}

