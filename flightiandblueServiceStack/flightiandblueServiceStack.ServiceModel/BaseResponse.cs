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
}
