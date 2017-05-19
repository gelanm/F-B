using BLLDALMod.DAL;
using BLLDALMod.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLDALMod.BLL
{
    public partial class WXUserBLL
    {
        private readonly WXUserDAL dal = new WXUserDAL();

        public WXUserBLL() { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WXUser model)
        {
            return dal.InsertMysql(model);
        }
        #endregion  Method
    }
}
