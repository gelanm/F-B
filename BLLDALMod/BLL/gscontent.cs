using System;
using System.Data;
using System.Collections.Generic;
//using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 业务逻辑类gscontent 的摘要说明。
	/// </summary>
	public class gscontent
	{
		private readonly Maticsoft.DAL.gscontent dal=new Maticsoft.DAL.gscontent();
		public gscontent()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.gscontent model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Maticsoft.Model.gscontent model)
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
		public Maticsoft.Model.gscontent GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
        //public Maticsoft.Model.gscontent GetModelByCache(int id)
        //{
			
        //    string CacheKey = "gscontentModel-" + id;
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
        //    return (Maticsoft.Model.gscontent)objModel;
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
		public List<Maticsoft.Model.gscontent> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.gscontent> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.gscontent> modelList = new List<Maticsoft.Model.gscontent>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.gscontent model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.gscontent();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					model.title=dt.Rows[n]["title"].ToString();
					model.faburen=dt.Rows[n]["faburen"].ToString();
					if(dt.Rows[n]["time"].ToString()!="")
					{
						model.time=DateTime.Parse(dt.Rows[n]["time"].ToString());
					}
					model.content=dt.Rows[n]["content"].ToString();
					if(dt.Rows[n]["hit"].ToString()!="")
					{
						model.hit=int.Parse(dt.Rows[n]["hit"].ToString());
					}
					model.keywords=dt.Rows[n]["keywords"].ToString();
					if(dt.Rows[n]["classid"].ToString()!="")
					{
						model.classid=int.Parse(dt.Rows[n]["classid"].ToString());
					}
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
        public DataTable GetAll(int id,int top )
        {
            return dal.GetAll(id,top);
        }

		#endregion  成员方法
	}
}

