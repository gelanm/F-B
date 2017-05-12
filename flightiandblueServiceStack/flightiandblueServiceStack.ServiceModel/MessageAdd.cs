using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;

namespace flightiandblueServiceStack.ServiceModel
{
    [Route("/MessageAdd")]
    public class MessageAdd : IReturn<MessageAddResponse>
    {
        public string liuyantitle { get; set; }
        public string liuyancontent { get; set; }
        public string liuyanTelEmail { get; set; }
        public string lianxiren { get; set; }
    }

    public class MessageAddResponse
    {
        public string Result { get; set; }
    }

}