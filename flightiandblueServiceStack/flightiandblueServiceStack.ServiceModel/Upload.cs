using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightiandblueServiceStack.ServiceModel
{
    [Route("/upload")]
    public class Upload
    {
        public string Md5 { get; set; }
        public string Card { get; set; }
        public string Address { get; set; }
        public int RegisterId { get; set; }
        public int Status { get; set; }
    }

    [Route("/resize/{Id}")]
    public class Resize
    {
        public string Id { get; set; }
        public string Size { get; set; }
    }
}
