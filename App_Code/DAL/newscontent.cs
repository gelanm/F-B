using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;//请先添加引用
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类newscontent。
	/// </summary>
	public class newscontent
	{
		public newscontent()
		{}
		#region  成员方法


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from newscontent");
			strSql.Append(" where id="+id+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.newscontent model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			
			if (model.title != null)
			{
				strSql1.Append("title,");
                strSql2.Append("@title,");
			}
			if (model.faburen != null)
			{
				strSql1.Append("faburen,");
				strSql2.Append("@faburen,");
			}
			if (model.time != null)
			{
				strSql1.Append("time,");
				strSql2.Append("@time,");
			}
			if (model.content != null)
			{
				strSql1.Append("content,");
				strSql2.Append("@content,");
			}
			if (model.hit != null)
			{
				strSql1.Append("hit,");
				strSql2.Append("@hit,");
			}
			
			strSql.Append("insert into newscontent(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");


            MySqlParameter[] Parameters = {
					new MySqlParameter("@title", MySqlDbType.VarChar, 100),
					new MySqlParameter("@faburen", MySqlDbType.VarChar, 100),
                    new MySqlParameter("@time", MySqlDbType.Date),
					new MySqlParameter("@content", MySqlDbType.Text),
                    new MySqlParameter("@hit", MySqlDbType.Int32, 4)};

            Parameters[0].Value = model.title;
            Parameters[1].Value = model.faburen;
            Parameters[2].Value = model.time;
            Parameters[3].Value = model.content;
            Parameters[4].Value = model.hit;

            DBhelpmysql.ExecuteSql(strSql.ToString(), Parameters);
		}




		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Maticsoft.Model.newscontent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update newscontent set ");
			
			if (model.title != null)
			{
				strSql.Append("title=@title,");
			}
			if (model.faburen != null)
			{
				strSql.Append("faburen=@faburen,");
			}
			if (model.time != null)
			{
				strSql.Append("time=@time,");
			}
			if (model.content != null)
			{
				strSql.Append("content=@content,");
			}
			if (model.hit != null)
			{
				strSql.Append("hit=@hit,");
			}
			
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where id="+ model.id+" ");

            MySqlParameter[] Parameters = {
					new MySqlParameter("@title", MySqlDbType.VarChar, 100),
					new MySqlParameter("@faburen", MySqlDbType.VarChar, 100),
                    new MySqlParameter("@time", MySqlDbType.Date, 8),
					new MySqlParameter("@content", MySqlDbType.Text),
                    new MySqlParameter("@hit", MySqlDbType.Int32, 4),
                    new MySqlParameter("@id", MySqlDbType.Int32, 4)};

            Parameters[0].Value = model.title;
            Parameters[1].Value = model.faburen;
            Parameters[2].Value = model.time;
            Parameters[3].Value = model.content;
            Parameters[4].Value = model.hit;
            Parameters[5].Value = model.id;

            DBhelpmysql.ExecuteSql(strSql.ToString(), Parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from newscontent ");
			strSql.Append(" where id="+id+" " );
            DBhelpmysql.ExecuteSql(strSql.ToString(), null);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.newscontent GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" id,title,faburen,time,content,hit,keywords ");
			strSql.Append(" from newscontent ");
			strSql.Append(" where id="+id+" " );
			Maticsoft.Model.newscontent model=new Maticsoft.Model.newscontent();
            DataTable ds = DBhelpmysql.Query(strSql.ToString());
			if(ds.Rows.Count>0)
			{
				if(ds.Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Rows[0]["id"].ToString());
				}
				model.title=ds.Rows[0]["title"].ToString();
				model.faburen=ds.Rows[0]["faburen"].ToString();
				if(ds.Rows[0]["time"].ToString()!="")
				{
					model.time=DateTime.Parse(ds.Rows[0]["time"].ToString());
				}
				model.content=ds.Rows[0]["content"].ToString();
				if(ds.Rows[0]["hit"].ToString()!="")
				{
					model.hit=int.Parse(ds.Rows[0]["hit"].ToString());
				}
				model.keywords=ds.Rows[0]["keywords"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,title,faburen,time,content,hit,keywords ");
			strSql.Append(" FROM newscontent ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return DBhelpmysql.Query(strSql.ToString());
		}
        public DataTable GetAll(int id, int top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql = new StringBuilder();
            strSql.Append("select top " + top + " * from newscontent  ORDER BY [time] DESC");
            return DbHelperOleDb.Fill(strSql.ToString());
        }
        public DataTable GetAllbyid(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql = new StringBuilder();
            strSql.Append("select  * from newscontent where id=" + id + " ORDER BY [time] DESC");
            return DbHelperOleDb.Fill(strSql.ToString());
        }
		/*
		*/

		#endregion  成员方法
	}
}

