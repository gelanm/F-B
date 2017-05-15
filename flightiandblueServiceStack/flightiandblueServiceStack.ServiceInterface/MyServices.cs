using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using flightiandblueServiceStack.ServiceModel;

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
    }
}