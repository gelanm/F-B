using System;
using System.Data;
using System.Collections.Generic;
//using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 业务逻辑类wangzhan 的摘要说明。
	/// </summary>
	public class wangzhan
	{
		private readonly Maticsoft.DAL.wangzhan dal=new Maticsoft.DAL.wangzhan();
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
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.wangzhan model)
		{
			return dal.Update(model);
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
		public Maticsoft.Model.wangzhan GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
        //public Maticsoft.Model.wangzhan GetModelByCache(int id)
        //{
			
        //    string CacheKey = "wangzhanModel-" + id;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(id);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (Maticsoft.Model.wangzhan)objModel;
        //}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.wangzhan> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.wangzhan> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.wangzhan> modelList = new List<Maticsoft.Model.wangzhan>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.wangzhan model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.wangzhan();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					model.gsname=dt.Rows[n]["gsname"].ToString();
					model.zongbu=dt.Rows[n]["zongbu"].ToString();
					model.jidi=dt.Rows[n]["jidi"].ToString();
					model.dianhua=dt.Rows[n]["dianhua"].ToString();
					model.chuanzheng=dt.Rows[n]["chuanzheng"].ToString();
					model.youbian=dt.Rows[n]["youbian"].ToString();
					model.dizhi=dt.Rows[n]["dizhi"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

