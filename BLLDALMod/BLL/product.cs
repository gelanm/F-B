using System;
using System.Data;
using System.Collections.Generic;
//using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// ҵ���߼���product ��ժҪ˵����
	/// </summary>
	public class product
	{
		private readonly Maticsoft.DAL.product dal=new Maticsoft.DAL.product();
		public product()
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
		public void Add(Maticsoft.Model.product model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Maticsoft.Model.product model)
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
		public Maticsoft.Model.product GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.product> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
        public DataTable GetAll(int top)
        {
            return dal.GetAll(top);
        }
     
		#endregion  ��Ա����
	}
}

