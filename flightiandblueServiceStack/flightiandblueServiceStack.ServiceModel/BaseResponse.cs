using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace flightiandblueServiceStack.ServiceModel
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class BaseResponseType
    {
        public BaseResponse Status { get; set; }
    }

    public class AuthHead
    {
        public string name { get; set; }
        public string auth { get; set; }
        public int id { get; set; }
    }

    public class BaseRequestType
    {
        public AuthHead Head { get; set; }
    }


}
