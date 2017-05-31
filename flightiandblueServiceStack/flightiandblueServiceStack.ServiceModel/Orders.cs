using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightiandblueServiceStack.ServiceModel
{
    [Route("/AddOrder")]
    public class Orders : IReturn<OrdersResponse>
    {
        public int RegisterId { get; set; }
        public string OpenId { get; set; }
        public int Aid { get; set; }
        public int Bid { get; set; }
        public AuthHead Head { get; set; }
    }

    public class OrdersResponse : BaseResponseType
    {
              
    }
}
