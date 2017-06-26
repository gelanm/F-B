using BLLDALMod.DAL;
using BLLDALMod.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WXUser model)
        {
            return dal.Update(model);
        }

        public DataTable GetAllList()
        {
            return dal.GetAllList();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WXUser GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WXUser GetModel(string OpenId)
        {

            return dal.GetModel(OpenId);
        }

        #endregion  Method
    }
}
