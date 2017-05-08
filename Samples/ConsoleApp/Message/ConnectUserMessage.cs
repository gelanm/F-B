using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fleck.Samples.ConsoleApp.Message
{
    public class FromConnectUserMessage : MessageBase
    {
        public FromConnectUserMessage()
        {
            this.act = "c";
        }
        public int fid { get; set; }
        public int tid { get; set; }
    }

    public class ToConnectUserMessage : MessageBase
    {
        public ToConnectUserMessage()
        {
            this.act = "c";
        }
        public int fid { get; set; }
        public string fname { get; set; }
        public override string ToString()
        {
            return JsonHelper.JsonSerializer<ToConnectUserMessage>(this);
        }
    }
}
