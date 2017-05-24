using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightiandblueServiceStack.ServiceModel
{
    [Route("/upload")]
    public class Upload : IReturn<UploadResponse>
    {
        public string Title { get; set; }
        public int RegisterId { get; set; }
    }

    public class UploadResponse : BaseResponseType
    {
        public int id { get; set; }
    }



    [Route("/resize/{Id}")]
    public class Resize
    {
        public string Id { get; set; }
        public string Size { get; set; }
    }
}
