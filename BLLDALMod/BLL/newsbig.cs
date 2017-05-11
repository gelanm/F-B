using System;
using System.Data;
using System.Collections.Generic;
//using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 业务逻辑类newsbig 的摘要说明。
	/// </summary>
	public class newsbig
	{
        protected static Maticsoft.DAL.newsbig DAL_Examples = new Maticsoft.DAL.newsbig();
		private readonly Maticsoft.DAL.newsbig dal=new Maticsoft.DAL.newsbig();
		public newsbig()
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
		public bool Add(Maticsoft.Model.newsbig model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Maticsoft.Model.newsbig model)
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
		public Maticsoft.Model.newsbig GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
        //public Maticsoft.Model.newsbig GetModelByCache(int id)
        //{
			
        //    string CacheKey = "newsbigModel-" + id;
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
        //    return (Maticsoft.Model.newsbig)objModel;
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
		public List<Maticsoft.Model.newsbig> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.newsbig> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.newsbig> modelList = new List<Maticsoft.Model.newsbig>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.newsbig model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.newsbig();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					model.newsclass=dt.Rows[n]["newsclass"].ToString();
					if(dt.Rows[n]["newsid"].ToString()!="")
					{
						model.newsid=int.Parse(dt.Rows[n]["newsid"].ToString());
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
        public static List<Model.newsbig> get_List()
        {
            return DAL_Examples.get_List();
        }

        public static List<Model.newsbig> get_List(string ParentID)
        {
            return DAL_Examples.get_List(ParentID);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataTable GetAll(int id)
        {

            return dal.GetAll(id);
        }

		#endregion  成员方法
	}
}

