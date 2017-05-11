using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using System.Collections.Generic;
using Maticsoft.DBUtility;//请先添加引用
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类product。
	/// </summary>
	public class product
	{
		public product()
		{}
		#region  成员方法


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from product");
			strSql.Append(" where id="+id+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.product model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			
			if (model.protitle != null)
			{
				strSql1.Append("protitle,");
				strSql2.Append("'"+model.protitle+"',");
			}
			
			
			
			
			if (model.procontent != null)
			{
				strSql1.Append("procontent,");
				strSql2.Append("'"+model.procontent+"',");
			}
			if (model.fabutime != null)
			{
				strSql1.Append("fabutime,");
				strSql2.Append("'"+model.fabutime+"',");
			}
			if (model.propic != null)
			{
				strSql1.Append("propic,");
				strSql2.Append("'"+model.propic+"',");
			}
            if (model.classid != null)
            {
                strSql1.Append("classid,");
                strSql2.Append("" + model.classid + ",");
            }
			strSql.Append("insert into product(");
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
		public void Update(Maticsoft.Model.product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update product set ");
			
			if (model.protitle != null)
			{
				strSql.Append("protitle='"+model.protitle+"',");
			}
			
			
			
			
			if (model.procontent != null)
			{
				strSql.Append("procontent='"+model.procontent+"',");
			}
			if (model.fabutime != null)
			{
				strSql.Append("fabutime='"+model.fabutime+"',");
			}
			if (model.propic != null)
			{
				strSql.Append("propic='"+model.propic+"',");
			}
            if (model.classid != null)
            {
                strSql.Append("classid=" + model.classid + ",");
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
			strSql.Append("delete from product ");
			strSql.Append(" where id="+id+" " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.product GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" id,protitle,projianjie,projiage,proxinhao,proleibei,procontent,fabutime,propic,classid ");
			strSql.Append(" from product ");
			strSql.Append(" where id="+id+" " );
			Maticsoft.Model.product model=new Maticsoft.Model.product();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.protitle=ds.Tables[0].Rows[0]["protitle"].ToString();
				model.projianjie=ds.Tables[0].Rows[0]["projianjie"].ToString();
				model.projiage=ds.Tables[0].Rows[0]["projiage"].ToString();
				model.proxinhao=ds.Tables[0].Rows[0]["proxinhao"].ToString();
				model.proleibei=ds.Tables[0].Rows[0]["proleibei"].ToString();
				model.procontent=ds.Tables[0].Rows[0]["procontent"].ToString();
                if (ds.Tables[0].Rows[0]["classid"].ToString() != "")
                {
                    model.classid = int.Parse(ds.Tables[0].Rows[0]["classid"].ToString());
                }
				if(ds.Tables[0].Rows[0]["fabutime"].ToString()!="")
				{
					model.fabutime=DateTime.Parse(ds.Tables[0].Rows[0]["fabutime"].ToString());
				}
				model.propic=ds.Tables[0].Rows[0]["propic"].ToString();
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
			strSql.Append("select top 6 id,protitle,projianjie,projiage,proxinhao,proleibei,procontent,fabutime,propic ");
			strSql.Append(" FROM product ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}
        public DataTable GetAll( int top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql = new StringBuilder();
            strSql.Append("select top " + top + " * from product");
            return DbHelperOleDb.Fill(strSql.ToString());
        }

      

		#endregion  成员方法
	}
}

