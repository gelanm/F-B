using BLLDALMod.Model;
using Maticsoft.DBUtility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
        #endregion  Method
    }
}
