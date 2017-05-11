using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;//请先添加引用


namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类user。
	/// </summary>
	public class user
	{
        StringBuilder strSql = null;
       
		public user()
		{}
		#region  成员方法


		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string username, string userpass)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from user");
            strSql.Append(" where username=@username and userpass=@userpass");

            MySqlParameter[] Parameters = {
					new MySqlParameter("@username", MySqlDbType.VarChar, 100),
					new MySqlParameter("@userpass", MySqlDbType.VarChar, 200)};

            Parameters[0].Value = username;
            Parameters[1].Value = userpass;

            return DBhelpmysql.Exists(strSql.ToString(), Parameters);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.user model)
		{
			StringBuilder strSql=new StringBuilder();


            strSql.Append("INSERT INTO user ( username, userpass) VALUES (@username,@userpass)");



            MySqlParameter[] Parameters = {
					new MySqlParameter("@username", MySqlDbType.VarChar, 100),
					new MySqlParameter("@userpass", MySqlDbType.VarChar, 200)};

            Parameters[0].Value = model.admin;
            Parameters[1].Value = model.pass;

            DBhelpmysql.ExecuteSql(strSql.ToString(), Parameters);
			 
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Maticsoft.Model.user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update user set ");
			if (model.id != null)
			{
				strSql.Append("id="+model.id+",");
			}
			if (model.admin != null)
			{
				strSql.Append("username='"+model.admin+"',");
			}
			if (model.pass != null)
			{
				strSql.Append("userpass='"+model.pass+"',");
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
			strSql.Append("delete from user ");
			strSql.Append(" where id="+id+" " );
            DBhelpmysql.ExecuteSql(strSql.ToString(), null);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.user GetModel()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from [user] where id=1 ");
			
			Maticsoft.Model.user model=new Maticsoft.Model.user();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.admin=ds.Tables[0].Rows[0]["username"].ToString();
				model.pass=ds.Tables[0].Rows[0]["userpass"].ToString();
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
			strSql.Append("select id,username,userpass ");
			strSql.Append(" FROM user ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return DBhelpmysql.Query(strSql.ToString());
		}

        public DataTable GetAll()
        {
            strSql = new StringBuilder();
            strSql.Append("select * from [user]");
            return DbHelperOleDb.Fill(strSql.ToString());
        }

		/*
		*/

		#endregion  成员方法
	}
}

