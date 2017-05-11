using System;
using System.Data;
using System.Collections.Generic;
//using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// ҵ���߼���productclass ��ժҪ˵����
	/// </summary>
	public class productclass
	{
        protected static Maticsoft.DAL.productclass DAL_Examples = new Maticsoft.DAL.productclass();
		private readonly Maticsoft.DAL.productclass dal=new Maticsoft.DAL.productclass();
		public productclass()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Maticsoft.Model.productclass model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Maticsoft.Model.productclass model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int id)
		{
			
			dal.Delete(id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Maticsoft.Model.productclass GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

        ///// <summary>
        ///// �õ�һ������ʵ�壬�ӻ����С�
        ///// </summary>
        //public Maticsoft.Model.productclass GetModelByCache(int id)
        //{
			
        //    string CacheKey = "productclassModel-" + id;
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
        //    return (Maticsoft.Model.productclass)objModel;
        //}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.productclass> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.productclass> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.productclass> modelList = new List<Maticsoft.Model.productclass>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.productclass model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.productclass();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					model.productname=dt.Rows[n]["productname"].ToString();
					if(dt.Rows[n]["productid"].ToString()!="")
					{
						model.productid=int.Parse(dt.Rows[n]["productid"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
        public static List<Model.productclass> get_List()
        {
            return DAL_Examples.get_List();
        }

        public static List<Model.productclass> get_List(string ParentID)
        {
            return DAL_Examples.get_List(ParentID);
        }

		/// <summary>
		/// ��������б�
		/// </summary>
        public DataTable GetAll(int id)
        {
            return dal.GetAll(id);
        }
		#endregion  ��Ա����
	}
}

