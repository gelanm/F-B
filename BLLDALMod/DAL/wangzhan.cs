using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;//请先添加引用
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类wangzhan。
	/// </summary>
	public class wangzhan
	{
		public wangzhan()
		{}
		#region  成员方法


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.wangzhan model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.id != null)
			{
				strSql1.Append("id,");
				strSql2.Append(""+model.id+",");
			}
			if (model.gsname != null)
			{
				strSql1.Append("gsname,");
				strSql2.Append("'"+model.gsname+"',");
			}
			if (model.zongbu != null)
			{
				strSql1.Append("zongbu,");
				strSql2.Append("'"+model.zongbu+"',");
			}
			if (model.jidi != null)
			{
				strSql1.Append("jidi,");
				strSql2.Append("'"+model.jidi+"',");
			}
			if (model.dianhua != null)
			{
				strSql1.Append("dianhua,");
				strSql2.Append("'"+model.dianhua+"',");
			}
			if (model.chuanzheng != null)
			{
				strSql1.Append("chuanzheng,");
				strSql2.Append("'"+model.chuanzheng+"',");
			}
			if (model.youbian != null)
			{
				strSql1.Append("youbian,");
				strSql2.Append("'"+model.youbian+"',");
			}
			if (model.dizhi != null)
			{
				strSql1.Append("dizhi,");
				strSql2.Append("'"+model.dizhi+"',");
			}
			strSql.Append("insert into wangzhan(");
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
		public bool Update(Maticsoft.Model.wangzhan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wangzhan set ");
			
			if (model.gsname != null)
			{
				strSql.Append("gsname=@gsname,");
			}
			if (model.zongbu != null)
			{
				strSql.Append("zongbu=@zongbu,");
			}
			if (model.jidi != null)
			{
				strSql.Append("jidi=@jidi,");
			}
			if (model.dianhua != null)
			{
				strSql.Append("dianhua=@dianhua,");
			}
			if (model.chuanzheng != null)
			{
				strSql.Append("chuanzheng=@chuanzheng,");
			}
			if (model.youbian != null)
			{
				strSql.Append("youbian=@youbian,");
			}
			if (model.dizhi != null)
			{
				strSql.Append("dizhi=@dizhi,");
			}
            if (model.lianxiwm != null)
            {
                strSql.Append("lianxiwm=@lianxiwm,");
            }
            
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where id="+ model.id+" ");


            MySqlParameter[] Parameters = {
					new MySqlParameter("@gsname", MySqlDbType.VarChar, 100),
					new MySqlParameter("@zongbu", MySqlDbType.VarChar, 100),
                    new MySqlParameter("@jidi", MySqlDbType.VarChar, 100),
					new MySqlParameter("@dianhua", MySqlDbType.VarChar, 100),
                    new MySqlParameter("@chuanzheng", MySqlDbType.VarChar, 100),
					new MySqlParameter("@youbian", MySqlDbType.VarChar, 100),
                    new MySqlParameter("@dizhi", MySqlDbType.VarChar, 100),
                    new MySqlParameter("@lianxiwm", MySqlDbType.VarChar, 500)

                  };

            Parameters[0].Value = model.gsname;
            Parameters[1].Value = model.zongbu;
            Parameters[2].Value = model.jidi;
            Parameters[3].Value = model.dianhua;
            Parameters[4].Value = model.chuanzheng;
            Parameters[5].Value = model.youbian;
            Parameters[6].Value = model.dizhi;
            Parameters[7].Value = model.lianxiwm;


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
			strSql.Append("delete from wangzhan ");
			strSql.Append(" where id="+id+" " );
            DbHelperOleDb.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.wangzhan GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" id,gsname,zongbu,jidi,dianhua,chuanzheng,youbian,dizhi,lianxiwm ");
			strSql.Append(" from wangzhan ");
			strSql.Append(" where id="+id+" " );
            Maticsoft.Model.wangzhan model = new Maticsoft.Model.wangzhan();
            DataTable ds = DBhelpmysql.Query(strSql.ToString());
			if(ds.Rows.Count>0)
			{
				if(ds.Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Rows[0]["id"].ToString());
				}
				model.gsname=ds.Rows[0]["gsname"].ToString();
				model.zongbu=ds.Rows[0]["zongbu"].ToString();
				model.jidi=ds.Rows[0]["jidi"].ToString();
				model.dianhua=ds.Rows[0]["dianhua"].ToString();
				model.chuanzheng=ds.Rows[0]["chuanzheng"].ToString();
				model.youbian=ds.Rows[0]["youbian"].ToString();
				model.dizhi=ds.Rows[0]["dizhi"].ToString();
                model.lianxiwm = ds.Rows[0]["lianxiwm"].ToString();
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
			strSql.Append("select id,gsname,zongbu,jidi,dianhua,chuanzheng,youbian,dizhi ");
			strSql.Append(" FROM wangzhan ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return DbHelperOleDb.Query(strSql.ToString());
		}

		/*
		*/

		#endregion  成员方法
	}
}

