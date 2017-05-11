using System;
using System.Data;
using System.Collections.Generic;
//using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// ҵ���߼���wangzhan ��ժҪ˵����
	/// </summary>
	public class wangzhan
	{
		private readonly Maticsoft.DAL.wangzhan dal=new Maticsoft.DAL.wangzhan();
		public wangzhan()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Maticsoft.Model.wangzhan model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Maticsoft.Model.wangzhan model)
		{
			return dal.Update(model);
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
		public Maticsoft.Model.wangzhan GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.wangzhan> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}

