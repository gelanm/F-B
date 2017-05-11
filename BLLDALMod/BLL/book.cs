using System;
using System.Data;
using System.Collections.Generic;
//using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
    /// <summary>
    /// 业务逻辑类book 的摘要说明。
    /// </summary>
    public class book
    {
        private readonly Maticsoft.DAL.bookDAL dal = new Maticsoft.DAL.bookDAL();
        public book()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Maticsoft.Model.book model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Maticsoft.Model.book model)
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
        public Maticsoft.Model.book GetModel(int id)
        {

            return dal.GetModel(id);
        }

       

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
        public List<Maticsoft.Model.book> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.book> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.book> modelList = new List<Maticsoft.Model.book>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.book model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.book();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.liuyantitle = dt.Rows[n]["liuyantitle"].ToString();
                    model.liuyangcontent = dt.Rows[n]["liuyangcontent"].ToString();
                    if (dt.Rows[n]["liuyantitme"].ToString() != "")
                    {
                        model.liuyantitme = DateTime.Parse(dt.Rows[n]["liuyantitme"].ToString());
                    }
                    model.hueifu = dt.Rows[n]["hueifu"].ToString();
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
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法
    }
}

