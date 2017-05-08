using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Fleck.Samples.ConsoleApp
{
    public class Logger
    {
        public bool LogEvents { get; set; }
        private ILog log = log4net.LogManager.GetLogger("Logger");

        public Logger()
        {
            LogEvents = false;
        }

        public void Log(string text)
        {
            if (LogEvents)
                Console.WriteLine(text);
            else
                log.Info(text);
        }

        public void Fail(Exception ex)
        {
            log.Error("", ex);
            return;
        }
    }
}
