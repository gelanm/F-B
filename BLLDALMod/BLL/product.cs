using System;
using System.Data;
using System.Collections.Generic;
//using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 业务逻辑类product 的摘要说明。
	/// </summary>
	public class product
	{
		private readonly Maticsoft.DAL.product dal=new Maticsoft.DAL.product();
		public product()
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
		public void Add(Maticsoft.Model.product model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Maticsoft.Model.product model)
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
		public Maticsoft.Model.product GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
        //public Maticsoft.Model.product GetModelByCache(int id)
        //{
			
        //    string CacheKey = "productModel-" + id;
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
        //    return (Maticsoft.Model.product)objModel;
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
		public List<Maticsoft.Model.product> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.product> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.product> modelList = new List<Maticsoft.Model.product>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.product model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.product();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					model.protitle=dt.Rows[n]["protitle"].ToString();
					model.projianjie=dt.Rows[n]["projianjie"].ToString();
					model.projiage=dt.Rows[n]["projiage"].ToString();
					model.proxinhao=dt.Rows[n]["proxinhao"].ToString();
					model.proleibei=dt.Rows[n]["proleibei"].ToString();
					model.procontent=dt.Rows[n]["procontent"].ToString();
					if(dt.Rows[n]["fabutime"].ToString()!="")
					{
						model.fabutime=DateTime.Parse(dt.Rows[n]["fabutime"].ToString());
					}
					model.propic=dt.Rows[n]["propic"].ToString();
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
        public DataTable GetAll(int top)
        {
            return dal.GetAll(top);
        }
     
		#endregion  成员方法
	}
}

