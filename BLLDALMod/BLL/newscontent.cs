using System;
using System.Data;
using System.Collections.Generic;
//using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 业务逻辑类newscontent 的摘要说明。
	/// </summary>
	public class newscontent
	{
		private readonly Maticsoft.DAL.newscontent dal=new Maticsoft.DAL.newscontent();
		public newscontent()
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
		public void Add(Maticsoft.Model.newscontent model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Maticsoft.Model.newscontent model)
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
		public Maticsoft.Model.newscontent GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
        //public Maticsoft.Model.newscontent GetModelByCache(int id)
        //{
			
        //    string CacheKey = "newscontentModel-" + id;
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
        //    return (Maticsoft.Model.newscontent)objModel;
        //}

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
		public List<Maticsoft.Model.newscontent> GetModelList(string strWhere)
		{
			DataTable ds = dal.GetList(strWhere);
			return DataTableToList(ds);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.newscontent> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.newscontent> modelList = new List<Maticsoft.Model.newscontent>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.newscontent model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.newscontent();
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
        public DataTable GetAll(int id)
        {
            return dal.GetAllbyid(id);
        }

		#endregion  成员方法
	}
}

