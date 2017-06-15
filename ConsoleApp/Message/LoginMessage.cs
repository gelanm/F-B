using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fleck.Samples.ConsoleApp.Message
{
    public class LoginMessage : MessageBase
    {
        public LoginMessage()
        {
            this.act = "l";
        }
        public int userid { get; set; }
        public string auth { get; set; }
        public override string ToString()
        {
            return JsonHelper.JsonSerializer<LoginMessage>(this);
        }
    }
}
