using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fleck.Samples.ConsoleApp.Message
{
    public class SystemMessage : MessageBase
    {
        public SystemMessage()
        {
            this.act = "s";
            this.date = DateTime.Now.ToShortTimeString();
        }
        public string text { get; set; }
        public string date { get; set; }
        public override string ToString()
        {
            return JsonHelper.JsonSerializer<SystemMessage>(this);
        }
    }
}
