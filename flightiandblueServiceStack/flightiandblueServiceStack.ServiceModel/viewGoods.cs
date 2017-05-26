using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLLDALMod.Model;

namespace flightiandblueServiceStack.ServiceModel
{
    [Route("/viewGoods")]
    public class viewGoods : IReturn<Goods>
    {
        public string OpenId { get; set; }
        public int RegisterId { get; set; }
        public int State { get; set; }
        public int start { get; set; }
        public int count { get; set; }
        public int Type { get; set; }
    }
}
