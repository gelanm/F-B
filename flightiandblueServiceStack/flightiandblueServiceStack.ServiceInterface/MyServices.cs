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
using System.Data;

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
            ChatRoomBLL objChatRoomBLL = new ChatRoomBLL();
            if (request.Type == 0)
            {
                goodsBLL objBll = new goodsBLL();
                List<Goods> listmode = objBll.GetModelList(" State = '" + request.State.ToString() + "' and UserId = " + request.RegisterId + " limit " + request.start + "," + request.count);
                foreach (Goods g in listmode) {
                    int a = objChatRoomBLL.getChatCount(g.UserId);
                    g.Remark = a.ToString();
                }
                return listmode;
            }
            else if (request.Type == 1)
            {
                techsBLL objBll = new techsBLL();
                List<techs> listmode = objBll.GetModelList(" 1=1 limit " + request.start + "," + request.count);
                return listmode;
            }
            else {
                goodsBLL objBll = new goodsBLL();
                List<Goods> listmode = objBll.GetModelList(" State in ( '" + request.State.ToString() + "','2') and UserId != " + request.RegisterId + " limit " + request.start + "," + request.count);
                return listmode;
            }
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
                avatarUrl = WXUserInfo.avatarUrl,
                Status = new BaseResponse { IsSuccess = true, ErrorMessage = "" }
            };
            //return new WXUserResponse {Status= new BaseResponse{IsSuccess = true, ErrorMessage="" }};
        }


        // 添加订单 
        public object Any(flightiandblueServiceStack.ServiceModel.Orders request)
        {

            BLLDALMod.BLL.OrdersBLL objorders = new BLLDALMod.BLL.OrdersBLL();
            BLLDALMod.Model.orders modeorder = new BLLDALMod.Model.orders();
            BLLDALMod.BLL.goodsBLL objgood = new BLLDALMod.BLL.goodsBLL();
            BLLDALMod.Model.Goods modegood = new BLLDALMod.Model.Goods();


            modegood = objgood.GetModel(request.Bid);

            if (modegood.State == "2")
            {
                return new OrdersResponse
                {
                    Status = new BaseResponse { IsSuccess = false, ErrorMessage = modegood.Title + ", 该商品已经共享了" }
                };
            }
            modegood.State = "2";
            modegood.UpdateTime = DateTime.Now;
            objgood.Update(modegood);

            modegood = objgood.GetModel(request.Aid);

            if (modegood.State == "2")
            {
                return new OrdersResponse
                {
                    Status = new BaseResponse { IsSuccess = false, ErrorMessage = modegood.Title + ", 该商品已经共享了" }
                };
            }
            modegood.State = "2";
            modegood.UpdateTime = DateTime.Now;
            objgood.Update(modegood);

            modeorder.OrderNumber = "";
            modeorder.Status = "01";
            modeorder.AGoodId = request.Aid;
            modeorder.BGoodId = request.Bid;
            modeorder.Aid = modegood.UserId;
            modeorder.Bid = request.Head.id;
            modeorder.CreateDate = DateTime.Now;
            modeorder.UpdateTime = DateTime.Now;
            modeorder.Memo = "----memo----";
            objorders.Add(modeorder);





            return new OrdersResponse
            {
                Status = new BaseResponse { IsSuccess = true, ErrorMessage = "" }
            };
        
        }


        // 结束订单 
        public object Any(flightiandblueServiceStack.ServiceModel.EndOrders request)
        {
            BLLDALMod.BLL.OrdersBLL objorders = new BLLDALMod.BLL.OrdersBLL();
            BLLDALMod.Model.orders modeorder = new BLLDALMod.Model.orders();
            BLLDALMod.BLL.goodsBLL objgood = new BLLDALMod.BLL.goodsBLL();
            BLLDALMod.Model.Goods modegood = new BLLDALMod.Model.Goods();
            BLLDALMod.Model.Goods modegood2 = new BLLDALMod.Model.Goods();
            int otherId;

            modegood = objgood.GetModel(request.Id);

            if (modegood.State != "2")
            {
                return new OrdersResponse
                {
                    Status = new BaseResponse { IsSuccess = false, ErrorMessage = modegood.Title + ", 该商品不存在正在共享的订单" }
                };
            }
            modegood.State = "1";
            modegood.UpdateTime = DateTime.Now;

            DataTable dt = objorders.GetList("  (AGoodId = " + request.Id + " or  AGoodId = " + request.Id + " ) and  Status = '01' order by CreateDate desc limit 0,1 ");
            if (dt.Rows.Count == 0)
            {
                return new OrdersResponse
                {
                    Status = new BaseResponse { IsSuccess = false, ErrorMessage = modegood.Title + ", 该商品不存在正在共享的订单" }
                };
            }
            

            if ((DateTime.Now.AddDays(-7) < DateTime.Parse(dt.Rows[0]["CreateDate"].ToString()))
                && (DateTime.Now.AddDays(-2) > DateTime.Parse(dt.Rows[0]["CreateDate"].ToString())))
            {
                return new OrdersResponse
                {
                    Status = new BaseResponse { IsSuccess = false, ErrorMessage = "请于"+ DateTime.Parse(dt.Rows[0]["CreateDate"].ToString()).AddDays(7).ToString()+"后，再结束订单。" }
                };
            }
            //if (int.Parse(dt.Rows[0]["AGoodId"].ToString()) == request.Id)
            //{
            //    otherId = int.Parse(dt.Rows[0]["BGoodId"].ToString());
            //}
            //else {
            //    otherId = int.Parse(dt.Rows[0]["AGoodId"].ToString());
            //}

            //modegood2 = objgood.GetModel(otherId);

            //if (modegood2.State != "2")
            //{
            //    return new OrdersResponse
            //    {
            //        Status = new BaseResponse { IsSuccess = false, ErrorMessage = modegood2.Title + ", 该商品不存在正在共享的订单" }
            //    };
            //}
            //modegood2.State = "1";
            //modegood2.UpdateTime = DateTime.Now;
            


            //modeorder = objorders.GetModel(int.Parse(dt.Rows[0]["Id"].ToString()));
            //modeorder.Status = "06";
            //modeorder.UpdateTime = DateTime.Now;

            objgood.Update(modegood);
            //objgood.Update(modegood2);
            objorders.Update(modeorder);


            //modeorder.OrderNumber = "";
            //modeorder.Status = "01";
            //modeorder.AGoodId = request.Aid;
            //modeorder.BGoodId = request.Bid;
            //modeorder.Aid = modegood.UserId;
            //modeorder.Bid = request.Head.id;
            //modeorder.CreateDate = DateTime.Now;
            //modeorder.UpdateTime = DateTime.Now;
            //modeorder.Memo = "----memo----";
            //objorders.Add(modeorder);





            return new OrdersResponse
            {
                Status = new BaseResponse { IsSuccess = true, ErrorMessage = "" }
            };

        }
    }
}