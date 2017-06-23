using BLLDALMod.DAL;
using BLLDALMod.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLLDALMod.BLL
{
    public partial class OrdersBLL
    {
        private readonly ordersDAL dal = new ordersDAL();

        public OrdersBLL() { }


        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(orders model)
        {
            return dal.InsertMysql(model);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BLLDALMod.Model.orders GetModel(int id)
        {

            return dal.GetModel(id);
        }

        //public int getOtherGoodId(int id)
        //{
        //    return dal.getOtherGoodId(id);
        //}
        

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(BLLDALMod.Model.orders model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BLLDALMod.Model.orders> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BLLDALMod.Model.orders> DataTableToList(DataTable dt)
        {
            List<BLLDALMod.Model.orders> modelList = new List<BLLDALMod.Model.orders>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BLLDALMod.Model.orders model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new BLLDALMod.Model.orders();
                    if (dt.Rows[n]["Id"] != null && dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["OrderNumber"] != null && dt.Rows[n]["OrderNumber"].ToString() != "")
                    {
                        model.OrderNumber = dt.Rows[n]["OrderNumber"].ToString();
                    }
                    if (dt.Rows[n]["AId"] != null && dt.Rows[n]["AId"].ToString() != "")
                    {
                        model.Aid = int.Parse(dt.Rows[n]["AId"].ToString());
                    }
                    if (dt.Rows[n]["AGoodId"] != null && dt.Rows[n]["AGoodId"].ToString() != "")
                    {
                        model.AGoodId = int.Parse(dt.Rows[n]["AGoodId"].ToString());
                    }
                    if (dt.Rows[n]["BId"] != null && dt.Rows[n]["BId"].ToString() != "")
                    {
                        model.Bid = int.Parse(dt.Rows[n]["BId"].ToString());
                    }
                    if (dt.Rows[n]["BGoodId"] != null && dt.Rows[n]["BGoodId"].ToString() != "")
                    {
                        model.BGoodId = int.Parse(dt.Rows[n]["BGoodId"].ToString());
                    }
                    if (dt.Rows[n]["CreateDate"] != null && dt.Rows[n]["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    }
                    if (dt.Rows[n]["UpdateDate"] != null && dt.Rows[n]["UpdateDate"].ToString() != "")
                    {
                        model.UpdateTime = DateTime.Parse(dt.Rows[n]["UpdateDate"].ToString());
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = dt.Rows[n]["Status"].ToString();
                    }
                    if (dt.Rows[n]["Memo"] != null && dt.Rows[n]["Memo"].ToString() != "")
                    {
                        model.Memo = dt.Rows[n]["Memo"].ToString();
                    }
                    
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        public DataTable GetAllList()
        {
            return dal.GetAllList();
        }

        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        #endregion

    }
}
