using System;
using System.Data;
using System.Collections.Generic;
//using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 业务逻辑类gsclass 的摘要说明。
	/// </summary>
	public class gsclass
	{
        protected static Maticsoft.DAL.gsclass DAL_Examples = new Maticsoft.DAL.gsclass();
		private readonly Maticsoft.DAL.gsclass dal=new Maticsoft.DAL.gsclass();
		public gsclass()
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
		public void Add(Maticsoft.Model.gsclass model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.gsclass model)
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
		public Maticsoft.Model.gsclass GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
        //public Maticsoft.Model.gsclass GetModelByCache(int id)
        //{
			
        //    string CacheKey = "gsclassModel-" + id;
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
        //    return (Maticsoft.Model.gsclass)objModel;
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
		public List<Maticsoft.Model.gsclass> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.gsclass> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.gsclass> modelList = new List<Maticsoft.Model.gsclass>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.gsclass model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.gsclass();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					model.classname=dt.Rows[n]["classname"].ToString();
					if(dt.Rows[n]["classid"].ToString()!="")
					{
						model.classid=int.Parse(dt.Rows[n]["classid"].ToString());
					}
					model.content=dt.Rows[n]["content"].ToString();
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
        public static List<Model.gsclass> get_List()
        {
            return DAL_Examples.get_List();
        }

        public static List<Model.gsclass> get_List(string ParentID)
        {
            return DAL_Examples.get_List(ParentID);
        }

        public DataTable GetAll(int id)
        {
            return dal.GetAll(id);
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

