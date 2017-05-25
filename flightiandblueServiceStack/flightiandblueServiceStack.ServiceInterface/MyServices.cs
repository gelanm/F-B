using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using flightiandblueServiceStack.ServiceModel;
using System.Net;
using BLLDALMod.Comm;
using BLLDALMod.BLL;
using BLLDALMod.Model;

namespace flightiandblueServiceStack.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(MessageAdd request)
        {
            Maticsoft.BLL.book objBll = new Maticsoft.BLL.book();
            Maticsoft.Model.book objmode = new Maticsoft.Model.book();

            objmode.liuyantitle = request.liuyantitle;
            objmode.liuyangcontent = request.liuyancontent;
            objmode.phonenum = request.liuyanTelEmail;
            objmode.username = request.lianxiren;
            objmode.liuyantitme = DateTime.Now;

            objBll.Add(objmode);
            return new MessageAddResponse { Result = "留言成功!" };
        }

        public object Any(viewGoods request)
        {
            goodsBLL objBll = new goodsBLL();
            List<Goods> listmode = objBll.GetModelList(" State = '"+request.Type.ToString() + "' and UserId = "+request.RegisterId);
            return listmode;

        }

        public object Any(flightiandblueServiceStack.ServiceModel.WXUser request)
        {
            string url = "https://api.weixin.qq.com/sns/jscode2session?appid=" + "wxfa6ae3a6654c4012"     //Common.weixin.WxPayConfig.APPID
            + "&secret=" + "b2c837bafcbe989666c24f999b499868"
            + "&js_code=" + request.Code
            + "&&grant_type=authorization_code";
            HttpWebRequest request1 = WebRequest.Create(url) as HttpWebRequest;
            request1.Method = "GET";
            string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            request1.UserAgent = DefaultUserAgent;
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request1.GetResponse();
            System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
            string responseText = myreader.ReadToEnd();
            myreader.Close();
            var weixin = JsonHelper.Deserialize<WXjscode2sessionResponseType>(responseText);
            AESHelper.AesIV = request.IV;
            AESHelper.AesKey = weixin.session_key;
            string text = request.EncryptedData;
            string s = AESHelper.AESDecrypt(text);
            var WXUserInfo = JsonHelper.Deserialize<WXGetUserInfoResponseType>(s);

            return new WXUserResponse
            {
                //Id = new ServiceProcess.WX.WXService().InsertWXUserInf(WXUserInfo),
                Id = new ServiceProcess.WXService().InsertMysqlWXUserInf(WXUserInfo),
                OpenId = WXUserInfo.openId,
                UnionId = WXUserInfo.unionId,
                Status = new BaseResponse { IsSuccess = true, ErrorMessage = "" }
            };
            //return new WXUserResponse {Status= new BaseResponse{IsSuccess = true, ErrorMessage="" }};
        }
    }
}