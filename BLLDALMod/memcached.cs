using System;
using System.Collections.Generic;
using System.Web;
using Memcached.ClientLibrary;
using System.Net;

/// <summary>
/// memcached 的摘要说明
/// </summary>
public class memcached
{

		//
		// TODO: 在此处添加构造函数逻辑
		//
		/// <summary>
		/// Arguments: 
		///		arg[0] = the number of runs to do
		///		arg[1] = the run at which to start benchmarking
		/// </summary>
		/// <param name="args"></param>        
        /// 
        public static string GetIP()
        {
            string strHostName = Dns.GetHostName();//得到本机的主机名
            IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP 
            string strAddr = ipEntry.AddressList[0].ToString();//假设本地主机为单网卡  
            return strHostName + "|" + strAddr;
        }

        public static string GetuserNameIP()
        {
            string strHostName = Dns.GetHostName();//得到本机的主机名
            IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP 
            string strAddr = ipEntry.AddressList[0].ToString();//假设本地主机为单网卡  
            return "userName" + strHostName + "|" + strAddr;
        }

        public static bool CheckLogin()
        {
            if (string.IsNullOrEmpty(memcached.Find(GetuserNameIP())))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

		[STAThread]
        public static void Add(string key, string value) 
		{
            // Memcached服务器列表
            // 如果有多台服务器，则以逗号分隔，例如："192.168.80.10:11211","192.168.80.11:11211"
            // string[] serverList = { "192.168.80.10:11211","192.168.80.11:11211" };

            string[] serverList = { PublicConfig.MemoryIP };  
            // 初始化SocketIO池
            string poolName = "MyPool";
            SockIOPool sockIOPool = SockIOPool.GetInstance(poolName);
            // 添加服务器列表
            sockIOPool.SetServers(serverList);
            // 设置连接池初始数目
            sockIOPool.InitConnections = 3;
            // 设置连接池最小连接数目
            sockIOPool.MinConnections = 3;
            // 设置连接池最大连接数目
            sockIOPool.MaxConnections = 5;
            // 设置连接的套接字超时时间（单位：毫秒）
            sockIOPool.SocketConnectTimeout = 1000;
            // 设置套接字超时时间（单位：毫秒）
            sockIOPool.SocketTimeout = 3000;
            // 设置维护线程运行的睡眠时间：如果设置为0，那么维护线程将不会启动
            sockIOPool.MaintenanceSleep = 30;
            // 设置SockIO池的故障标志
            sockIOPool.Failover = true;
            // 是否用nagle算法启动
            sockIOPool.Nagle = false;
            // 正式初始化容器
            sockIOPool.Initialize();

            // 获取Memcached客户端实例
            MemcachedClient memClient = new MemcachedClient();
            // 指定客户端访问的SockIO池
            memClient.PoolName = poolName;
            // 是否启用压缩数据：如果启用了压缩，数据压缩长于门槛的数据将被储存在压缩的形式
            memClient.EnableCompression = false;
            memClient.Set(key, value); 
            // 05.设置数据过期时间：5秒后过期 
            System.Threading.Thread.Sleep(6000);
            
            // 06.自定义对象存储 
            // 关闭SockIO池
            SockIOPool.GetInstance().Shutdown();
            
            //string[] serverlist = { "192.168.6.222:11211" };
            //SockIOPool pool = SockIOPool.GetInstance("flightingandblue");
            //pool.SetServers(serverlist);
            //pool.InitConnections = 3;
            //pool.MinConnections = 3;
            //pool.MaxConnections = 5;
            //pool.SocketConnectTimeout = 1000;
            //pool.SocketTimeout = 3000;
            //pool.MaintenanceSleep = 30;
            //pool.Failover = true;
            //pool.Nagle = false;
            //pool.Initialize();
            //MemcachedClient mc = new MemcachedClient();
            //mc.EnableCompression = false;
            //mc.Set(key, value); 
            ////SockIOPool.GetInstance().Shutdown();
            //pool.Shutdown();



            //get(key);
            //GC.SuppressFinalize(this);
		}

        [STAThread]
        public static void Logout()
        {

            string[] serverList = { PublicConfig.MemoryIP };
            // 初始化SocketIO池
            string poolName = "MyPool";
            SockIOPool sockIOPool1 = SockIOPool.GetInstance(poolName);
            // 添加服务器列表
            sockIOPool1.SetServers(serverList);
            // 设置连接池初始数目
            sockIOPool1.InitConnections = 3;
            // 设置连接池最小连接数目
            sockIOPool1.MinConnections = 3;
            // 设置连接池最大连接数目
            sockIOPool1.MaxConnections = 5;
            // 设置连接的套接字超时时间（单位：毫秒）
            sockIOPool1.SocketConnectTimeout = 1000;
            // 设置套接字超时时间（单位：毫秒）
            sockIOPool1.SocketTimeout = 3000;
            // 设置维护线程运行的睡眠时间：如果设置为0，那么维护线程将不会启动
            sockIOPool1.MaintenanceSleep = 30;
            // 设置SockIO池的故障标志
            sockIOPool1.Failover = true;
            // 是否用nagle算法启动
            sockIOPool1.Nagle = false;
            // 正式初始化容器
            sockIOPool1.Initialize();
            // 关闭SockIO池

            MemcachedClient memClient1 = new MemcachedClient();
            // 指定客户端访问的SockIO池
            memClient1.PoolName = poolName;
            // 是否启用压缩数据：如果启用了压缩，数据压缩长于门槛的数据将被储存在压缩的形式
            memClient1.EnableCompression = false;

            memcached.Add("userName" + GetIP(), "");

            SockIOPool.GetInstance().Shutdown();

            //string[] serverlist = { "192.168.6.222:11211" };
            //SockIOPool pool = SockIOPool.GetInstance("flightingandblue");
            //pool.SetServers(serverlist);
            //pool.InitConnections = 3;
            //pool.MinConnections = 3;
            //pool.MaxConnections = 5;
            //pool.SocketConnectTimeout = 1000;
            //pool.SocketTimeout = 3000;
            //pool.MaintenanceSleep = 30;
            //pool.Failover = true;
            //pool.Nagle = false;
            //pool.Initialize();
            //MemcachedClient mc = new MemcachedClient();
            //mc.EnableCompression = false;
            //string str = (string)mc.Get(key);
            ////SockIOPool.GetInstance().Shutdown();
            //pool.Shutdown();
            //GC.SuppressFinalize(this);
            
        }

        [STAThread]
        public static string Find(string key)
        {

            string[] serverList = { "192.168.6.222:11211" };
            // 初始化SocketIO池
            string poolName = "MyPool";
            SockIOPool sockIOPool1 = SockIOPool.GetInstance(poolName);
            // 添加服务器列表
            sockIOPool1.SetServers(serverList);
            // 设置连接池初始数目
            sockIOPool1.InitConnections = 3;
            // 设置连接池最小连接数目
            sockIOPool1.MinConnections = 3;
            // 设置连接池最大连接数目
            sockIOPool1.MaxConnections = 5;
            // 设置连接的套接字超时时间（单位：毫秒）
            sockIOPool1.SocketConnectTimeout = 1000;
            // 设置套接字超时时间（单位：毫秒）
            sockIOPool1.SocketTimeout = 3000;
            // 设置维护线程运行的睡眠时间：如果设置为0，那么维护线程将不会启动
            sockIOPool1.MaintenanceSleep = 30;
            // 设置SockIO池的故障标志
            sockIOPool1.Failover = true;
            // 是否用nagle算法启动
            sockIOPool1.Nagle = false;
            // 正式初始化容器
            sockIOPool1.Initialize();
            // 关闭SockIO池

            MemcachedClient memClient1 = new MemcachedClient();
            // 指定客户端访问的SockIO池
            memClient1.PoolName = poolName;
            // 是否启用压缩数据：如果启用了压缩，数据压缩长于门槛的数据将被储存在压缩的形式
            memClient1.EnableCompression = false;
            string str = (string)memClient1.Get(key);
            SockIOPool.GetInstance().Shutdown();

            //string[] serverlist = { "192.168.6.222:11211" };
            //SockIOPool pool = SockIOPool.GetInstance("flightingandblue");
            //pool.SetServers(serverlist);
            //pool.InitConnections = 3;
            //pool.MinConnections = 3;
            //pool.MaxConnections = 5;
            //pool.SocketConnectTimeout = 1000;
            //pool.SocketTimeout = 3000;
            //pool.MaintenanceSleep = 30;
            //pool.Failover = true;
            //pool.Nagle = false;
            //pool.Initialize();
            //MemcachedClient mc = new MemcachedClient();
            //mc.EnableCompression = false;
            //string str = (string)mc.Get(key);
            ////SockIOPool.GetInstance().Shutdown();
            //pool.Shutdown();
            //GC.SuppressFinalize(this);
            return str;
        }
 
}