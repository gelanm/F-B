using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLLDALMod.BLL
{
    public class goodsBLL
    {
        private readonly BLLDALMod.DAL.goodsDAL dal = new BLLDALMod.DAL.goodsDAL();
        public goodsBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(BLLDALMod.Model.Goods model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(BLLDALMod.Model.Goods model)
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
        public BLLDALMod.Model.Goods GetModel(int id)
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
        public List<BLLDALMod.Model.Goods> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BLLDALMod.Model.Goods> DataTableToList(DataTable dt)
        {
            List<BLLDALMod.Model.Goods> modelList = new List<BLLDALMod.Model.Goods>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BLLDALMod.Model.Goods model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new BLLDALMod.Model.Goods();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["Title"] != null && dt.Rows[n]["Title"].ToString() != "")
                    {
                        model.Title = dt.Rows[n]["Title"].ToString();
                    }
                    if (dt.Rows[n]["MainImage"] != null && dt.Rows[n]["MainImage"].ToString() != "")
                    {
                        model.MainImage = dt.Rows[n]["MainImage"].ToString();
                    }
                    if (dt.Rows[n]["ContentValidity"] != null && dt.Rows[n]["ContentValidity"].ToString() != "")
                    {
                        model.ContentValidity = dt.Rows[n]["ContentValidity"].ToString();
                    }
                    if (dt.Rows[n]["PurchaseDate"] != null && dt.Rows[n]["PurchaseDate"].ToString() != "")
                    {
                        model.PurchaseDate = DateTime.Parse(dt.Rows[n]["PurchaseDate"].ToString());
                    }
                    if (dt.Rows[n]["Price"] != null && dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = Double.Parse(dt.Rows[n]["Price"].ToString());
                    }
                    if (dt.Rows[n]["AddTime"] != null && dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
                    if (dt.Rows[n]["UpdateTime"] != null && dt.Rows[n]["UpdateTime"].ToString() != "")
                    {
                        model.UpdateTime = DateTime.Parse(dt.Rows[n]["UpdateTime"].ToString());
                    }
                    if (dt.Rows[n]["State"] != null && dt.Rows[n]["State"].ToString() != "")
                    {
                        model.State = dt.Rows[n]["State"].ToString();
                    }
                    if (dt.Rows[n]["type"] != null && dt.Rows[n]["type"].ToString() != "")
                    {
                        model.type = dt.Rows[n]["type"].ToString();
                    }
                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
                    }
                    if (dt.Rows[n]["UserId"] != null && dt.Rows[n]["UserId"].ToString() != "")
                    {
                        model.UserId = int.Parse(dt.Rows[n]["UserId"].ToString());
                    }
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
