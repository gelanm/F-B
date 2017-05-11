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
	/// 数据访问类gsclass。
	/// </summary>
	public class gsclass
	{
        public static string connectionString = PubConstant.ConnectionString;  
		public gsclass()
		{}
		#region  成员方法


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from gsclass");
			strSql.Append(" where id="+id+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.gsclass model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.id != null)
			{
				strSql1.Append("id,");
				strSql2.Append(""+model.id+",");
			}
			if (model.classname != null)
			{
				strSql1.Append("classname,");
				strSql2.Append("'"+model.classname+"',");
			}
			if (model.classid != null)
			{
				strSql1.Append("classid,");
				strSql2.Append(""+model.classid+",");
			}
			if (model.content != null)
			{
				strSql1.Append("content,");
				strSql2.Append("'"+model.content+"',");
			}
			strSql.Append("insert into gsclass(");
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
		public bool Update(Maticsoft.Model.gsclass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update gsclass set ");
			 
			if (model.content != null)
			{
				strSql.Append("content=@content, ");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where id = @id ");


            MySqlParameter[] Parameters = {
					new MySqlParameter("@content", MySqlDbType.VarChar, 200),
					new MySqlParameter("@id", MySqlDbType.Int32, 4)};

            Parameters[0].Value = model.content;
            Parameters[1].Value = model.id;

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
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from gsclass ");
			strSql.Append(" where id="+id+" " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.gsclass GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" id,classname,classid,   content  ");
			strSql.Append(" from gsclass ");
			strSql.Append(" where id="+id+" " );
			Maticsoft.Model.gsclass model=new Maticsoft.Model.gsclass();
            DataTable ds = DBhelpmysql.Query(strSql.ToString());
			if(ds.Rows.Count>0)
			{
				if(ds.Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Rows[0]["id"].ToString());
				}
				model.classname=ds.Rows[0]["classname"].ToString();
				if(ds.Rows[0]["classid"].ToString()!="")
				{
					model.classid=int.Parse(ds.Rows[0]["classid"].ToString());
				}
				model.content=ds.Rows[0]["content"].ToString();
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
			strSql.Append("select id,classname,classid,content ");
			strSql.Append(" FROM gsclass ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

        public List<Model.gsclass> get_List()
        {
            List<Model.gsclass> List = new List<Model.gsclass>();
            DataTable dt = getDataSet("select * from gsclass where classid=0 ").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                Model.gsclass model = new Model.gsclass();
                model.id = Convert.ToInt32(dr["id"]);
                model.classname = dr["classname"].ToString();
                model.classid = Convert.ToInt32(dr["classid"]);
                List.Add(model);
            }
            return List;
        }

        public List<Model.gsclass> get_List(string ParentID)
        {
            List<Model.gsclass> List = new List<Model.gsclass>();
            DataTable dt = getDataSet("select * from gsclass where classid=" + ParentID + " ").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                Model.gsclass model = new Model.gsclass();
                model.id = Convert.ToInt32(dr["id"]);
                model.classname = dr["classname"].ToString();
                model.classid = Convert.ToInt32(dr["classid"]);
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
            strSql.Append("select * from gsclass where classid=" + id + "");
            return DBhelpmysql.Select(strSql.ToString(), null);
        }
        

		/*
		*/

		#endregion  成员方法
	}
}

