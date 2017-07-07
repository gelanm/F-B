using flightiandblueServiceStack.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLLDALMod.BLL;
using BLLDALMod.Model;
using System.Net;
using BLLDALMod.Comm;



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

        public int InsertMysqlWXUserInf(WXGetUserInfoResponseType objWXUserInfo,string Latitude,string Longitude)
        {
            try
            {
                int Id;
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
                    objWXUser.Latitude = Latitude;
                    objWXUser.Longitude = Longitude;

					string url = "https://apis.map.qq.com/ws/geocoder/v1/?location=" + Latitude + "," + Longitude
						+ "&key=" + "X2DBZ-PH73W-D3XRW-RYGGX-RRVV7-AGBLC";

					HttpWebRequest request1 = WebRequest.Create(url) as HttpWebRequest;
					request1.Method = "GET";
					string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
					request1.UserAgent = DefaultUserAgent;
					System.Net.HttpWebResponse response;
					response = (System.Net.HttpWebResponse)request1.GetResponse();
					System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
					string responseText = myreader.ReadToEnd();
					myreader.Close();
					var weixin = JsonHelper.Deserialize<TXMapResponseType>(responseText);

					objWXUser.Province = weixin.result.address_component.province;
					if (objWXUser.Province.Substring(objWXUser.Province.Length - 1) == "市")
					{
						objWXUser.City = weixin.result.address_component.district;
					}
					else {
						objWXUser.City = weixin.result.address_component.city;
					}
					objWXUser.Memo = weixin.result.address;


                    Id = objWXUserBLL.Add(objWXUser);
                    //if (Id > 0)
                    //{

                    //    string url = "https://apis.map.qq.com/ws/geocoder/v1/?location=" + Latitude + "," + Longitude
                    //    + "&key=" + "X2DBZ-PH73W-D3XRW-RYGGX-RRVV7-AGBLC";        
                        
                    //    HttpWebRequest request1 = WebRequest.Create(url) as HttpWebRequest;
                    //    request1.Method = "GET";
                    //    string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    //    request1.UserAgent = DefaultUserAgent;
                    //    System.Net.HttpWebResponse response;
                    //    response = (System.Net.HttpWebResponse)request1.GetResponse();
                    //    System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
                    //    string responseText = myreader.ReadToEnd();
                    //    myreader.Close();
                    //    var weixin = JsonHelper.Deserialize<TXMapResponseType>(responseText);

                    //}
                    return Id;
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
