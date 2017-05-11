using System;
using System.Data;
using System.Collections.Generic;
//using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// ҵ���߼���newsbig ��ժҪ˵����
	/// </summary>
	public class newsbig
	{
        protected static Maticsoft.DAL.newsbig DAL_Examples = new Maticsoft.DAL.newsbig();
		private readonly Maticsoft.DAL.newsbig dal=new Maticsoft.DAL.newsbig();
		public newsbig()
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
		public bool Add(Maticsoft.Model.newsbig model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Maticsoft.Model.newsbig model)
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
		public Maticsoft.Model.newsbig GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.newsbig> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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
		/// ��������б�
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
		/// ��������б�
		/// </summary>
        public DataTable GetAll(int id)
        {

            return dal.GetAll(id);
        }

		#endregion  ��Ա����
	}
}

