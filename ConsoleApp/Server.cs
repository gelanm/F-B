﻿using Fleck.Samples.ConsoleApp.BLL;
using Fleck.Samples.ConsoleApp.Data;
using Fleck.Samples.ConsoleApp.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BLLDALMod.Model;
using BLLDALMod.BLL;


namespace Fleck.Samples.ConsoleApp
{
    class Server
    {
        static void Main()
        {
            FleckLog.Level = LogLevel.Debug;
            var allSockets = new List<IWebSocketConnection>();
            var server = new WebSocketServer("ws://0.0.0.0:8181");
            MessageBLL bll = new MessageBLL();
            ConnectUsers users = new ConnectUsers();
            //try
            //{
                server.Start(socket =>
                    {
                        socket.OnOpen = () =>
                            {
                                try
                                {
                                    Console.WriteLine("Open!");
                                    allSockets.Add(socket);
                                }
                                catch (Exception ex) {
                                    FleckLog.Error("OnOpen", ex);
                                }
                            };
                        socket.OnClose = () =>
                            {
                                try{
                                    Console.WriteLine("Close!");
                                    allSockets.Remove(socket);
                                }
                                catch (Exception ex)
                                {
                                    FleckLog.Error("OnClose", ex);
                                }
                            };
                        socket.OnMessage = message =>
                            {
                                //try
                                //{
                                    var msg = JsonHelper.JsonDeserialize<FromUserMessage>(message);
                                    if (msg == null)
                                        return;
                                    if (socket == null)
                                        return;
                                    if (msg.act != "l" && socket.UserId == 0)
                                    {
                                        var smsg = new SystemMessage { text = "请先登录" };
                                        socket.Send(smsg.ToString());
                                        return;
                                    }
                                    if (msg.act != "l" && socket.IsLogin == false)
                                    {
                                        var smsg = new SystemMessage { text = "请先登录" };
                                        socket.Send(smsg.ToString());
                                        return;
                                    }
                                    if (msg.act == "l")
                                    {
                                        try
                                        {
                                            //new Logger().Log("act=l");
                                            var lmsg = JsonHelper.JsonDeserialize<LoginMessage>(message);
                                            if (bll.IsLogin(lmsg.auth, lmsg.userid))
                                            {
                                                socket.UserId = lmsg.userid;
                                                //bll.UpdateLogData(lmsg.userid);
                                                socket.IsLogin = true;
                                            }
                                            else
                                            {
                                                var smsg = new SystemMessage { text = "请先登录" };
                                                socket.Send(smsg.ToString());
                                                socket.IsLogin = false;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            FleckLog.Error("OnMessage-l", ex);
                                        }
                                    }
                                    else if (msg.act == "m")//发送消息
                                    {
                                        try
                                        {
                                            var statue = 0;
                                            var fmsg = JsonHelper.JsonDeserialize<FromUserMessage>(message);
                                            if (fmsg == null || fmsg.fid == 0 || fmsg.fid != socket.UserId)
                                                return;
                                            var fuser = users.GetUser(socket.UserId);
                                            if (fuser != null)
                                            {
                                                var tuser = users.GetUser(fmsg.tid);
                                                var tmsg = new ToUserMessage { text = fmsg.text, fid = fmsg.fid, fname = fuser.username, date = DateTime.Now.ToShortTimeString() };
                                                //var tmsg = new ToUserMessage { text = fmsg.text, fid = fmsg.fid, fname = "id"+ fmsg.fid, date = DateTime.Now.ToShortTimeString() };
                                                foreach (IWebSocketConnection a in allSockets)
                                                {
                                                    if (a.UserId == fmsg.tid)
                                                    {
                                                        a.Send(tmsg.ToString());
                                                        statue = 1;
                                                    }
                                                }
                                                bll.SaveMessage(fuser.userid, fuser.username, tuser.userid, tuser.username, fmsg.text, statue);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            FleckLog.Error("OnMessage-m", ex);
                                        }
                                    }
                                    else if (msg.act == "c")//连接用户
                                    {
                                        try
                                        {
                                            var fmsg = JsonHelper.JsonDeserialize<FromConnectUserMessage>(message);
                                            if (fmsg == null || fmsg.fid == 0 || fmsg.fid != socket.UserId)
                                                return;
                                            var fuser = users.GetUser(fmsg.fid);
                                            var tuser = users.GetUser(fmsg.tid);
                                            if (fuser != null && tuser != null)
                                            {
                                                users.Connect(fmsg.fid, fmsg.tid);
                                                var tmsg = new ToConnectUserMessage { fid = fuser.userid, fname = fuser.username };
                                                foreach (IWebSocketConnection a in allSockets)
                                                {
                                                    if (a.UserId == fmsg.fid)
                                                    {
                                                        a.Send(tmsg.ToString());
                                                    }
                                                }
                                                //if (fmsg.tid == 2)
                                                if (true)
                                                {
                                                    //发送离线数据
                                                    var um = bll.GetOffLineUserMessage(fmsg.fid);
                                                    socket.Send(um.ToString());
                                                }
                                                else
                                                {
                                                    ////发送聊天记录
                                                    var ml = bll.GetUserMessage(fmsg.fid, fmsg.tid);
                                                    socket.Send(ml.ToString());
                                                    if (fmsg.tid == 14511)
                                                    {
                                                        var smsg = new SystemMessage { text = "尊敬的客户您好,有什么可以帮助！" };
                                                        socket.Send(smsg.ToString());
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            FleckLog.Error("OnMessage-c", ex);
                                        }
                                    }
                                //}
                                //catch (Exception ex)
                                //{
                                //    FleckLog.Error("OnMessage", ex);
                                //}
                            };
                    });


                var input = Console.ReadLine();
                while (input != "exit")
                {
                    foreach (var socket in allSockets.ToList())
                    {
                        socket.Send(input);
                    }
                    input = Console.ReadLine();
                }
            //}
            //catch (Exception e)
            //{
            //    FleckLog.Error("Server.cs", e);
            //} 
        }   
    }
}
