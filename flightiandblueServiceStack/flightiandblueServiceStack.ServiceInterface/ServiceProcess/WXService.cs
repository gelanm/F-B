using flightiandblueServiceStack.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLLDALMod.BLL;
using BLLDALMod.Model;



namespace flightiandblueServiceStack.ServiceInterface.ServiceProcess
{
    public class WXService : Lazy<WXService>
    {
        /// <summary>
        /// 是否超过 登入错误密码次数
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        //public int InsertWXUserInf(WXGetUserInfoResponseType objWXUserInfo)
        //{
        //    try
        //    {
        //        BLLWXUser objBLLWXUser = new BLLWXUser();
        //        MDWXUser objMDWXUser = new MDWXUser();
        //        objMDWXUser.strOpenId = objWXUserInfo.openId;
        //        objMDWXUser.intSex = objWXUserInfo.gender;
        //        objMDWXUser.strCity = objWXUserInfo.city;
        //        objMDWXUser.strCountry = objWXUserInfo.country;
        //        objMDWXUser.strProvince = objWXUserInfo.province;
        //        objMDWXUser.strUnionId = objWXUserInfo.unionId;
        //        objMDWXUser.strNickName = objWXUserInfo.nickName;
        //        objMDWXUser.strHeadimgUrl = objWXUserInfo.avatarUrl;
        //        objMDWXUser.dtmAddDate = DateTime.Now;

        //        return objBLLWXUser.Add(objMDWXUser);
        //        //return 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }

        //}

        public int InsertMysqlWXUserInf(WXGetUserInfoResponseType objWXUserInfo)
        {
            try
            {
                WXUserBLL objWXUserBLL = new WXUserBLL();
                BLLDALMod.Model.WXUser model = objWXUserBLL.GetModel(objWXUserInfo.openId);
                if (model != null)
                {
                    return model.Id;
                }
                else
                {
                    BLLDALMod.Model.WXUser objWXUser = new BLLDALMod.Model.WXUser();
                    objWXUser.OpenId = objWXUserInfo.openId;
                    objWXUser.Sex = objWXUserInfo.gender;
                    objWXUser.City = objWXUserInfo.city;
                    objWXUser.Country = objWXUserInfo.country;
                    objWXUser.Province = objWXUserInfo.province;
                    objWXUser.UnionId = objWXUserInfo.unionId;
                    objWXUser.NickName = objWXUserInfo.nickName;
                    objWXUser.HeadimgUrl = objWXUserInfo.avatarUrl;
                    objWXUser.AddDate = DateTime.Now;

                    return objWXUserBLL.Add(objWXUser);
                }
                //return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
