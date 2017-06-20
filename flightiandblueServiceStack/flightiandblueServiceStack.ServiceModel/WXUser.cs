using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightiandblueServiceStack.ServiceModel
{
    [Route("/WXUser")]
    public class WXUser : IReturn<WXUserResponse>
    {
        public string Code { get; set; }
        public string IV { get; set; }
        public string EncryptedData { get; set; }
    }

    public class WXUserResponse //: BaseResponseType
    {
        public int Id { get; set; }
        public string OpenId { get; set; }
        public string UnionId { get; set; }
        public string avatarUrl { get; set; }
    }

    public class WXjscode2sessionResponseType
    {
        public string openid { get; set; }
        public string session_key { get; set; }
        public string errcode { get; set; }
        public string errmsg { get; set; }
    }

    public class WXGetUserInfoResponseType
    {
        public string openId { get; set; }
        public string nickName { get; set; }
        public int gender { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string avatarUrl { get; set; }
        public string unionId { get; set; }
    }
}
