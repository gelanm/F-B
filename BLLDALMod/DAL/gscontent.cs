using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//请先添加引用
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类gscontent。
	/// </summary>
	public class gscontent
	{
		public gscontent()
		{}
		#region  成员方法


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from gscontent");
			strSql.Append(" where id="+id+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.gscontent model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			
			if (model.title != null)
			{
				strSql1.Append("[title],");
				strSql2.Append("'"+model.title+"',");
			}
			if (model.faburen != null)
			{
				strSql1.Append("[faburen],");
				strSql2.Append("'"+model.faburen+"',");
			}
			if (model.time != null)
			{
				strSql1.Append("[time],");
				strSql2.Append("'"+model.time+"',");
			}
			if (model.content != null)
			{
				strSql1.Append("[content],");
				strSql2.Append("'"+model.content+"',");
			}
            if (model.keywords != null)
            {
                strSql1.Append("[keywords],");
                strSql2.Append("'" + model.keywords + "',");
            }
			
			if (model.classid != null)
			{
				strSql1.Append("[classid],");
				strSql2.Append(""+model.classid+",");
			}
			strSql.Append("insert into [gscontent](");
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
		public void Update(Maticsoft.Model.gscontent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [gscontent] set ");
			
			if (model.title != null)
			{
				strSql.Append("[title]='"+model.title+"',");
			}
			if (model.faburen != null)
			{
				strSql.Append("[faburen]='"+model.faburen+"',");
			}
			if (model.time != null)
			{
				strSql.Append("[time]='"+model.time+"',");
			}
			if (model.content != null)
			{
				strSql.Append("[content]='"+model.content+"',");
			}

            if (model.keywords != null)
            {
               
                strSql.Append("'" + model.keywords + "'");
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
			strSql.Append("delete from gscontent ");
			strSql.Append(" where id="+id+" " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.gscontent GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" id,title,faburen,time,content,hit,keywords,classid ");
			strSql.Append(" from gscontent ");
			strSql.Append(" where id="+id+" " );
			Maticsoft.Model.gscontent model=new Maticsoft.Model.gscontent();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				model.faburen=ds.Tables[0].Rows[0]["faburen"].ToString();
				if(ds.Tables[0].Rows[0]["time"].ToString()!="")
				{
					model.time=DateTime.Parse(ds.Tables[0].Rows[0]["time"].ToString());
				}
				model.content=ds.Tables[0].Rows[0]["content"].ToString();
				if(ds.Tables[0].Rows[0]["hit"].ToString()!="")
				{
					model.hit=int.Parse(ds.Tables[0].Rows[0]["hit"].ToString());
				}
				model.keywords=ds.Tables[0].Rows[0]["keywords"].ToString();
				if(ds.Tables[0].Rows[0]["classid"].ToString()!="")
				{
					model.classid=int.Parse(ds.Tables[0].Rows[0]["classid"].ToString());
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
        public DataTable GetAll(int id,int top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql = new StringBuilder();
            strSql.Append("select top " + top + " * from gscontent where classid=" + id + " ORDER BY [time] DESC");
            return DbHelperOleDb.Fill(strSql.ToString());
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,faburen,time,content,hit,keywords,classid ");
            strSql.Append(" FROM gscontent ");
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

