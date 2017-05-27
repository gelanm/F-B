using BLLDALMod.Model;
using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLLDALMod.DAL
{
    public partial class WXUserDAL
    {
        public WXUserDAL()
        { }
        #region  Method


        /// <summary>
        /// 增加一条数据
        /// </summary>
        //public int Add(WXUser model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into WXUser(");
        //    strSql.Append("OpenId,UnionId,NickName,Province,City,Country,Sex,HeadimgUrl,AccessToken,RefreshToken,AddDate,Memo,Status)");
        //    strSql.Append(" values (");
        //    strSql.Append("@OpenId,@UnionId,@NickName,@Province,@City,@Country,@Sex,@HeadimgUrl,@AccessToken,@RefreshToken,@AddDate,@Memo,@Status)");
        //    strSql.Append(";select SCOPE_IDENTITY()");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@OpenId", SqlDbType.NVarChar,50),
        //            new SqlParameter("@UnionId", SqlDbType.NVarChar,50),
        //            new SqlParameter("@NickName", SqlDbType.NVarChar,50),
        //            new SqlParameter("@Province", SqlDbType.NVarChar,50),
        //            new SqlParameter("@City", SqlDbType.NVarChar,50),
        //            new SqlParameter("@Country", SqlDbType.NVarChar,50),
        //            new SqlParameter("@Sex", SqlDbType.Int,4),
        //            new SqlParameter("@HeadimgUrl", SqlDbType.NVarChar,250),
        //            new SqlParameter("@AccessToken", SqlDbType.NVarChar,250),
        //            new SqlParameter("@RefreshToken", SqlDbType.NVarChar,250),
        //            new SqlParameter("@AddDate", SqlDbType.DateTime),
        //            new SqlParameter("@Memo", SqlDbType.NVarChar,1000),
        //            new SqlParameter("@Status", SqlDbType.NVarChar,10)};
        //    parameters[0].Value = model.OpenId;
        //    parameters[1].Value = model.UnionId;
        //    parameters[2].Value = model.NickName;
        //    parameters[3].Value = model.Province;
        //    parameters[4].Value = model.City;
        //    parameters[5].Value = model.Country;
        //    parameters[6].Value = model.Sex;
        //    parameters[7].Value = model.HeadimgUrl;
        //    parameters[8].Value = model.AccessToken;
        //    parameters[9].Value = model.RefreshToken;
        //    parameters[10].Value = model.AddDate;
        //    parameters[11].Value = model.Memo;
        //    parameters[12].Value = model.Status;


        //    object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
        //    //object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}

        /// <summary>
        /// 插入MySQL数据
        /// </summary>
        public int InsertMysql(WXUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WXUser(");
            strSql.Append("OpenId,UnionId,NickName,Province,City,Country,Sex,HeadimgUrl,AccessToken,RefreshToken,AddDate,Memo,Status)");
            strSql.Append(" values (");
            strSql.Append("@OpenId,@UnionId,@NickName,@Province,@City,@Country,@Sex,@HeadimgUrl,@AccessToken,@RefreshToken,@AddDate,@Memo,@Status)");
            strSql.Append(";select @@IDENTITY");

            MySqlParameter[] parameters = {
					new MySqlParameter("@OpenId", MySqlDbType.VarChar,100),
					new MySqlParameter("@UnionId", MySqlDbType.VarChar,100),
					new MySqlParameter("@NickName", MySqlDbType.VarChar,50),
					new MySqlParameter("@Province", MySqlDbType.VarChar,50),
					new MySqlParameter("@City", MySqlDbType.VarChar,50),
					new MySqlParameter("@Country", MySqlDbType.VarChar,50),
					new MySqlParameter("@Sex", MySqlDbType.Int16,4),
					new MySqlParameter("@HeadimgUrl", MySqlDbType.VarChar,250),
					new MySqlParameter("@AccessToken", MySqlDbType.VarChar,250),
					new MySqlParameter("@RefreshToken", MySqlDbType.VarChar,250),
					new MySqlParameter("@AddDate", MySqlDbType.DateTime),
					new MySqlParameter("@Memo", MySqlDbType.VarChar,1000),
					new MySqlParameter("@Status", MySqlDbType.VarChar,10)};
            parameters[0].Value = model.OpenId;
            parameters[1].Value = model.UnionId;
            parameters[2].Value = model.NickName;
            parameters[3].Value = model.Province;
            parameters[4].Value = model.City;
            parameters[5].Value = model.Country;
            parameters[6].Value = model.Sex;
            parameters[7].Value = model.HeadimgUrl;
            parameters[8].Value = model.AccessToken;
            parameters[9].Value = model.RefreshToken;
            parameters[10].Value = model.AddDate;
            parameters[11].Value = model.Memo;
            parameters[12].Value = model.Status;

            object obj = DBhelpmysql.Insert(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
            //return 1;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WXUser GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from WXUser ");
            strSql.Append(" where Id=@Id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@Id", MySqlDbType.Int16,4)
			};
            parameters[0].Value = Id;

            WXUser model = new WXUser();
            DataTable dt = DBhelpmysql.Select(strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Id"] != null && dt.Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(dt.Rows[0]["Id"].ToString());
                }
                if (dt.Rows[0]["OpenId"] != null && dt.Rows[0]["OpenId"].ToString() != "")
                {
                    model.OpenId = dt.Rows[0]["OpenId"].ToString();
                }
                if (dt.Rows[0]["UnionId"] != null && dt.Rows[0]["UnionId"].ToString() != "")
                {
                    model.UnionId = dt.Rows[0]["UnionId"].ToString();
                }
                if (dt.Rows[0]["NickName"] != null && dt.Rows[0]["NickName"].ToString() != "")
                {
                    model.NickName = dt.Rows[0]["NickName"].ToString();
                }
                if (dt.Rows[0]["Sex"] != null && dt.Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(dt.Rows[0]["Sex"].ToString());
                }
                if (dt.Rows[0]["Province"] != null && dt.Rows[0]["Province"].ToString() != "")
                {
                    model.Province = dt.Rows[0]["Province"].ToString();
                }
                if (dt.Rows[0]["City"] != null && dt.Rows[0]["City"].ToString() != "")
                {
                    model.City = dt.Rows[0]["City"].ToString();
                }
                if (dt.Rows[0]["Country"] != null && dt.Rows[0]["Country"].ToString() != "")
                {
                    model.Country = dt.Rows[0]["Country"].ToString();
                }
                if (dt.Rows[0]["HeadimgUrl"] != null && dt.Rows[0]["HeadimgUrl"].ToString() != "")
                {
                    model.HeadimgUrl = dt.Rows[0]["HeadimgUrl"].ToString();
                }
                if (dt.Rows[0]["AccessToken"] != null && dt.Rows[0]["AccessToken"].ToString() != "")
                {
                    model.AccessToken = dt.Rows[0]["AccessToken"].ToString();
                }
                if (dt.Rows[0]["RefreshToken"] != null && dt.Rows[0]["RefreshToken"].ToString() != "")
                {
                    model.RefreshToken = dt.Rows[0]["RefreshToken"].ToString();
                }
                if (dt.Rows[0]["AddDate"] != null && dt.Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(dt.Rows[0]["AddDate"].ToString());
                }
                if (dt.Rows[0]["UpdateTime"] != null && dt.Rows[0]["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(dt.Rows[0]["UpdateTime"].ToString());
                }
                if (dt.Rows[0]["Memo"] != null && dt.Rows[0]["Memo"].ToString() != "")
                {
                    model.Memo = dt.Rows[0]["Memo"].ToString();
                }
                if (dt.Rows[0]["Status"] != null && dt.Rows[0]["Status"].ToString() != "")
                {
                    model.Status = dt.Rows[0]["Status"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }



        public DataTable GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from WXUser ");
            DataTable dt = DBhelpmysql.Select(strSql.ToString(), null);

            return dt;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WXUser GetModel(string OpenId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from WXUser ");
            strSql.Append(" where OpenId=@OpenId");
            MySqlParameter[] parameters = {
					new MySqlParameter("@OpenId", MySqlDbType.VarChar,100)
			};
            parameters[0].Value = OpenId;

            WXUser model = new WXUser();
            DataTable dt = DBhelpmysql.Select(strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Id"] != null && dt.Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(dt.Rows[0]["Id"].ToString());
                }
                if (dt.Rows[0]["OpenId"] != null && dt.Rows[0]["OpenId"].ToString() != "")
                {
                    model.OpenId = dt.Rows[0]["OpenId"].ToString();
                }
                if (dt.Rows[0]["UnionId"] != null && dt.Rows[0]["UnionId"].ToString() != "")
                {
                    model.UnionId = dt.Rows[0]["UnionId"].ToString();
                }
                if (dt.Rows[0]["NickName"] != null && dt.Rows[0]["NickName"].ToString() != "")
                {
                    model.NickName = dt.Rows[0]["NickName"].ToString();
                }
                if (dt.Rows[0]["Sex"] != null && dt.Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(dt.Rows[0]["Sex"].ToString());
                }
                if (dt.Rows[0]["Province"] != null && dt.Rows[0]["Province"].ToString() != "")
                {
                    model.Province = dt.Rows[0]["Province"].ToString();
                }
                if (dt.Rows[0]["City"] != null && dt.Rows[0]["City"].ToString() != "")
                {
                    model.City = dt.Rows[0]["City"].ToString();
                }
                if (dt.Rows[0]["Country"] != null && dt.Rows[0]["Country"].ToString() != "")
                {
                    model.Country = dt.Rows[0]["Country"].ToString();
                }
                if (dt.Rows[0]["HeadimgUrl"] != null && dt.Rows[0]["HeadimgUrl"].ToString() != "")
                {
                    model.HeadimgUrl = dt.Rows[0]["HeadimgUrl"].ToString();
                }
                if (dt.Rows[0]["AccessToken"] != null && dt.Rows[0]["AccessToken"].ToString() != "")
                {
                    model.AccessToken = dt.Rows[0]["AccessToken"].ToString();
                }
                if (dt.Rows[0]["RefreshToken"] != null && dt.Rows[0]["RefreshToken"].ToString() != "")
                {
                    model.RefreshToken = dt.Rows[0]["RefreshToken"].ToString();
                }
                if (dt.Rows[0]["AddDate"] != null && dt.Rows[0]["AddDate"].ToString() != "")
                {
                    model.AddDate = DateTime.Parse(dt.Rows[0]["AddDate"].ToString());
                }
                if (dt.Rows[0]["UpdateTime"] != null && dt.Rows[0]["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(dt.Rows[0]["UpdateTime"].ToString());
                }
                if (dt.Rows[0]["Memo"] != null && dt.Rows[0]["Memo"].ToString() != "")
                {
                    model.Memo = dt.Rows[0]["Memo"].ToString();
                }
                if (dt.Rows[0]["Status"] != null && dt.Rows[0]["Status"].ToString() != "")
                {
                    model.Status = dt.Rows[0]["Status"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  Method
    }
}
