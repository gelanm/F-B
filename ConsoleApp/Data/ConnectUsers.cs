using Fleck.Samples.ConsoleApp.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fleck.Samples.ConsoleApp.Data
{
    public class ConnectUsers
    {
        private object objLock = new object();
        private Dictionary<int, Dictionary<int, int>> connects = new Dictionary<int, Dictionary<int, int>>();
        private Dictionary<int, ChatUser> users = new Dictionary<int, ChatUser>();
        MessageBLL bll = new MessageBLL();

        public ConnectUsers()
        {
            InitUsers();
        }

        private void InitUsers()
        {
            users = bll.GetAllusers();
        }

        public void Connect(int fromUser, int toUser)
        {
            lock (objLock)
            {
                try
                {
                    if (!connects.ContainsKey(fromUser))
                        connects.Add(fromUser, new Dictionary<int, int>());
                    if (!connects[fromUser].Keys.Contains(toUser))
                        connects[fromUser].Add(toUser, toUser);

                    if (!connects.ContainsKey(toUser))
                        connects.Add(toUser, new Dictionary<int, int>());
                    if (!connects[toUser].Keys.Contains(fromUser))
                        connects[toUser].Add(fromUser, fromUser);
                }
                catch (Exception ex)
                {
                    new Logger().Fail(ex);
                }
            }
        }
        public void DisConnect(int user)
        {
            lock (objLock)
            {
                try
                {
                    if (!connects.ContainsKey(user))
                        return;

                    List<int> u = connects[user].Keys.ToList();

                    for (int i = 0; i < u.Count; i++)
                    {
                        connects[u[i]].Remove(user);
                    }

                    connects.Remove(user);
                }
                catch (Exception ex)
                {
                    new Logger().Fail(ex);
                }
            }
        }
        public List<int> GetConnects(int user)
        {
            var lst = new List<int>();
            lock (objLock)
            {
                try
                {
                    if (!connects.ContainsKey(user))
                        return new List<int>();
                    lst = connects[user].Keys.ToList<int>();
                }
                catch (Exception ex)
                {
                    new Logger().Fail(ex);
                }
            }
            return lst;
        }
        public ChatUser GetUser(int id)
        {
            try
            {
                if (users.ContainsKey(id))
                    return users[id];
                else
                {
                    ChatUser objChatUser = bll.GetChatUser(id);
                    if (objChatUser != null)
                        //users.Add(objChatUser.userid, objChatUser);
                        return objChatUser;
                }
            }
            catch (Exception ex)
            {
                new Logger().Fail(ex);
            }
            return null;
            //ChatUser objChatUser = new ChatUser();
            //objChatUser.userid = 1;
            //objChatUser.username = "aaa";
            //objChatUser.auth = "a";
            //return objChatUser;
        }
    }
}
