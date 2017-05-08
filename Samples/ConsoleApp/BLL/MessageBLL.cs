using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CM.BLL.User;
using CM.Module.User;
using System.Data;
using CServiceStack.ServiceHost;
using CServiceStack.ServiceClient;
using CServiceStack.Common.Types;
using CServiceStack.ProtoBuf;
using ServiceContact;
using CM.BLL.Other;
using CM.Module.Other;
using System.Configuration;
using Fleck.Samples.ConsoleApp.Common;
using Fleck.Samples.ConsoleApp.Message;
using Fleck.Samples.ConsoleApp.Data;

namespace Fleck.Samples.ConsoleApp.BLL
{
    public class MessageBLL
    {
        /// <summary>
        /// 判断是否已经登录
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public bool IsLogin(string auth, int uid)
        {
            ///TODO:添加判断是否已经登录 
            //string serviceapi = ConfigurationManager.AppSettings["ServiceApi"];

            //ApiClient.Client client = new ApiClient.Client(serviceapi);
            //string txtRequest = string.Empty;
            //txtRequest = "{\"Head\":{\"name\":\"chat\",\"auth\":\"" + auth + "\",\"id\":" + uid + "}}";
            //BaseResponseType obj = client.CheckLogin(CServiceStack.Text.JsonSerializer.DeserializeFromString<BaseRequestType>(txtRequest));
            //return obj.Status.IsSuccess; 
            return true;
        }
        public void SaveMessage(int fid, string fname, int tid, string tname, string msg)
        {
            BLLChatRoom objBLLChatRoom = new BLLChatRoom();
            MDChatRoom objMDChatRoom = new MDChatRoom();
            objMDChatRoom.intFromID = fid;
            objMDChatRoom.intToID = tid;
            objMDChatRoom.strContent = msg;
            objBLLChatRoom.Add(objMDChatRoom);

            string EmailForm = System.Configuration.ConfigurationManager.AppSettings["EmailForm"];
            string EmailFormPwd = System.Configuration.ConfigurationManager.AppSettings["EmailFormPwd"];
            string SmtpHost = System.Configuration.ConfigurationManager.AppSettings["SmtpHost"];
            string EmailTo = System.Configuration.ConfigurationManager.AppSettings["EmailTo"];

            if (fid == 14511)
            {
                SendEmailObject m = new SendEmailObject
                {
                    Form = EmailForm,
                    //FormPwd = EmailFormPwd,
                    SmtpHost = SmtpHost,
                    Body = "网购部答复(" + tname + "):" + msg,
                    To = EmailTo,
                    IsHtmlStyle = true,
                    Subject = "成谋网购咨询"
                };
                m.SendMail();
            }
            else if (tid == 14511)
            {
                SendEmailObject m = new SendEmailObject
                {
                    Form = EmailForm,
                    //FormPwd = EmailFormPwd,
                    SmtpHost = SmtpHost,
                    Body = "(" + fname + ")咨询网购部:" + msg,
                    To = EmailTo,
                    IsHtmlStyle = true,
                    Subject = "成谋网购咨询"
                };
                m.SendMail();
            }

            return;
        }
        public UserMessageList GetUserMessage(int fid, int tid)
        {
            //发送聊天记录
            UserMessageList ml = new UserMessageList();
            ml.tid = tid;

            BLLChatRoom objBLLChatRoom = new BLLChatRoom();
            MDChatRoom objMDChatRoom = new MDChatRoom();
            objMDChatRoom.intToID = tid;
            objMDChatRoom.intFromID = fid;
            DataTable dt = objBLLChatRoom.GetCurrentMessageList(fid, tid, 5);
            BLLUserRegister objBLLUserRegister = new BLLUserRegister();

            int k = 0;
            if (dt != null)
            {
                DataView dv = new DataView(dt);
                dv.Sort = "CreateDateTime ";
                foreach (DataRowView v in dv)
                {
                    k += 1;
                    MDUserRegister objMDUserRegister = new MDUserRegister();
                    objMDUserRegister.intId = Convert.ToInt32(v["FromID"].ToString());
                    objMDUserRegister = objBLLUserRegister.GetModel(objMDUserRegister);
                    if (objMDUserRegister != null)
                    {
                        string dtime = string.Empty;
                        try
                        {
                            dtime = Convert.ToDateTime(v["CreateDateTime"].ToString()).ToShortTimeString();
                        }
                        catch (Exception ex)
                        {
                            dtime = DateTime.Now.ToShortTimeString();
                        }
                        ml.ml.Add(new UserMessageData
                        {
                            fid = Convert.ToInt32(v["FromID"].ToString()),
                            fname = objMDUserRegister.strLogName,
                            text = v["Content"].ToString(),
                            date = dtime
                        });
                    }
                    if (k > 15)
                    {
                        break;
                    }
                }
            }
            return ml;
        }
        public Dictionary<int, ChatUser> GetAllusers()
        {
            BLLUserRegister objBLLUserRegister = new BLLUserRegister();
            List<MDUserRegister> lstall = new List<MDUserRegister>();
            MDUserRegister objMDUserRegister = new MDUserRegister();
            lstall = objBLLUserRegister.GetModelList(objMDUserRegister);
            Dictionary<int, ChatUser> users = new Dictionary<int, ChatUser>();

            for (int i = 0; i < lstall.Count; i++)
            {
                users.Add(lstall[i].intId, new ChatUser { userid = lstall[i].intId, username = lstall[i].strLogName, auth = string.Empty });

            }
            return users;
        }
        public ChatUser GetChatUser(int id)
        {
            BLLUserRegister objBLLUserRegister = new BLLUserRegister();
            MDUserRegister objMDUserRegister = new MDUserRegister();
            objMDUserRegister = objBLLUserRegister.GetModel(id);

            return new ChatUser
            {
                userid = objMDUserRegister.intId,
                username = objMDUserRegister.strLogName,
                auth = string.Empty
            };
        }
        public void UpdateLogData(int fi)
        {
            BLLUserRegister objBLLUserRegister = new BLLUserRegister();
            MDUserRegister objMDUserRegister = new MDUserRegister();
            objMDUserRegister.intId = fi;
            objMDUserRegister = objBLLUserRegister.GetModel(objMDUserRegister);
            if (objMDUserRegister.dtmChatDateTime == null || objMDUserRegister.dtmChatDateTime == DateTime.MinValue || objMDUserRegister.dtmChatDateTime < DateTime.Now)
            {
                objMDUserRegister.dtmChatDateTime = DateTime.Now;
                objBLLUserRegister.updateUserRegister(objMDUserRegister, "intId,", "dtmChatDateTime");
            }
        }
        public OffLineUserMessage GetOffLineUserMessage(int userid)
        {
            //发送聊天记录
            OffLineUserMessage ml = new OffLineUserMessage();
            ml.tid = userid;

            BLLChatRoom objBLLChatRoom = new BLLChatRoom();
            DataTable dt = objBLLChatRoom.GetCurrentMessageList(userid, 15);
            BLLUserRegister objBLLUserRegister = new BLLUserRegister();

            int k = 0;
            if (dt != null)
            {
                DataView dv = new DataView(dt);
                dv.Sort = "CreateDateTime ";
                foreach (DataRowView v in dv)
                {
                    k += 1;
                    MDUserRegister objMDUserRegister = new MDUserRegister();
                    objMDUserRegister.intId = Convert.ToInt32(v["FromID"].ToString());
                    objMDUserRegister = objBLLUserRegister.GetModel(objMDUserRegister);
                    if (objMDUserRegister != null)
                    {
                        string dtime = string.Empty;
                        try
                        {
                            dtime = Convert.ToDateTime(v["CreateDateTime"].ToString()).ToShortTimeString();
                        }
                        catch (Exception ex)
                        {
                            dtime = DateTime.Now.ToShortTimeString();
                        }

                        ml.ml.Add(new UserMessageData
                        {
                            fid = Convert.ToInt32(v["FromID"].ToString()),
                            fname = objMDUserRegister.strLogName,
                            text = v["Content"].ToString(),
                            date = dtime
                        });
                    }
                    if (k > 15)
                    {
                        break;
                    }
                }
            }
            return ml;
        }
    }
}
