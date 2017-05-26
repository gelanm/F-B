using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLLDALMod.BLL
{
    public class techsBLL
    {
        private readonly BLLDALMod.DAL.techsDAL dal = new BLLDALMod.DAL.techsDAL();
        public techsBLL()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BLLDALMod.Model.techs model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(BLLDALMod.Model.techs model)
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
        public BLLDALMod.Model.techs GetModel(int id)
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
        public List<BLLDALMod.Model.techs> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BLLDALMod.Model.techs> DataTableToList(DataTable dt)
        {
            List<BLLDALMod.Model.techs> modelList = new List<BLLDALMod.Model.techs>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BLLDALMod.Model.techs model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new BLLDALMod.Model.techs();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["Title"] != null && dt.Rows[n]["Title"].ToString() != "")
                    {
                        model.Title = dt.Rows[n]["Title"].ToString();
                    }
                    if (dt.Rows[n]["URL"] != null && dt.Rows[n]["URL"].ToString() != "")
                    {
                        model.Url = dt.Rows[n]["URL"].ToString();
                    }
                    if (dt.Rows[n]["ContentValidity"] != null && dt.Rows[n]["ContentValidity"].ToString() != "")
                    {
                        model.ContentValidity = dt.Rows[n]["ContentValidity"].ToString();
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
