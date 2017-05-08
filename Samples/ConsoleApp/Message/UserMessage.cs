using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fleck.Samples.ConsoleApp.Message
{
    public class FromUserMessage : MessageBase
    {
        public FromUserMessage()
        {
            this.act = "m";
        }
        public int fid { get; set; }
        public int tid { get; set; }
        public string text { get; set; }

    }

    public class ToUserMessage : MessageBase
    {
        public ToUserMessage()
        {
            this.act = "m";
        }
        public int fid { get; set; }
        public string fname { get; set; }
        public string text { get; set; }
        public string date { get; set; }
        public override string ToString()
        {
            return JsonHelper.JsonSerializer<ToUserMessage>(this);
        }
    }

    public class UserMessageData
    {
        public UserMessageData()
        { }
        public int fid { get; set; }
        public string fname { get; set; }
        public string text { get; set; }
        public string date { get; set; }
        public override string ToString()
        {
            return JsonHelper.JsonSerializer<UserMessageData>(this);
        }
    }

    public class UserMessageList : MessageBase
    {
        public UserMessageList()
        {
            this.act = "ml";
            ml = new List<UserMessageData>();
        }
        public int tid { get; set; }
        public List<UserMessageData> ml { get; set; }
        public override string ToString()
        {
            return JsonHelper.JsonSerializer<UserMessageList>(this);
        }
    }

    public class OffLineUserMessage : MessageBase
    {
        public OffLineUserMessage()
        {
            this.act = "um";
            ml = new List<UserMessageData>();
        }
        public int tid { get; set; }
        public List<UserMessageData> ml { get; set; }
        public override string ToString()
        {
            return JsonHelper.JsonSerializer<OffLineUserMessage>(this);
        }
    }
}
