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

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(BLLDALMod.Model.orders model)
        {
            dal.Update(model);
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
