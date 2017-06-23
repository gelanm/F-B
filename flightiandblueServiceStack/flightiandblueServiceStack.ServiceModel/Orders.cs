using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLLDALMod.Model;

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
    public class OrderGoodsResponse
    {
        public orders objorders { get; set; }
        public Goods objGoodsA { get; set; }
        public Goods objGoodsB { get; set; }
    }

    [Route("/EndExchange")]
    public class EndOrders : IReturn<OrdersResponse>
    {
        public int RegisterId { get; set; }
        public string OpenId { get; set; }
        public int Id { get; set; }
        public AuthHead Head { get; set; }
    }
}
