﻿using Funq;
using ServiceStack;
using flightiandblueServiceStack.ServiceInterface;


namespace flightiandblueServiceStack
{
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("flightiandblueServiceStack", typeof(MyServices).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());
            base.SetConfig(new HostConfig
    {
        GlobalResponseHeaders = {
            { "Access-Control-Allow-Origin", "*" },
            { "Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS" },
            { "Access-Control-Allow-Headers", "Content-Type" },
                },
    });
        }
    }
}