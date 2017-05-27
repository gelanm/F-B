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


        #endregion

    }
}
