using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
//using LTP.Common;
using Maticsoft.Model;
//using Wuqi.Webdiyer;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 业务逻辑类user 的摘要说明。
	/// </summary>
	public class user
	{
		private readonly Maticsoft.DAL.user dal=new Maticsoft.DAL.user();
		public user()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string username, string userpass)
        {
            return dal.Exists(username, userpass);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.user model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Maticsoft.Model.user model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			dal.Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.user GetModel()
		{
			
			return dal.GetModel();
		}

		

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.user> GetModelList(string strWhere)
		{
			DataTable ds = dal.GetList(strWhere);
			return DataTableToList(ds);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.user> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.user> modelList = new List<Maticsoft.Model.user>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.user model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.user();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					model.admin=dt.Rows[n]["admin"].ToString();
					model.pass=dt.Rows[n]["pass"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		
        public DataTable GetAll()
        {
            return dal.GetAll();
        }
        //public void BindAll(WebControl wc, AspNetPager asper)
        //{
        //    DataTable dt = dal.GetAll();
        //    PagedDataSource pds = new PagedDataSource();
        //    pds.AllowPaging = true;
        //    pds.PageSize = asper.PageSize;
        //    pds.CurrentPageIndex = asper.CurrentPageIndex - 1;
        //    pds.DataSource = dt.DefaultView;
        //    Maticsoft.Utility.DataControlHelper.Bind(wc, pds);
           
           
        //}

		#endregion  成员方法
	}
}

