using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace Fleck.Samples.ConsoleApp.Common
{
    public class SendEmailObject
    {
        //发送者邮件地址
        private string _form;
        //发送者邮件密码
        private string _fromPwd;
        //接受者邮件
        private string _to;
        //抄送者
        private string _cc;
        //附件路径
        private string _attachment;
        //发送者邮件的smtp服务器主机名
        private string _smtpHost;
        //邮件主题
        private string _subject;
        //邮件正文
        private string _body;
        //是否识别为html格式
        private bool _isHtmlStyle;

        public bool IsHtmlStyle
        {
            get { return _isHtmlStyle; }
            set { _isHtmlStyle = value; }
        }
        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        public string SmtpHost
        {
            get { return _smtpHost; }
            set { _smtpHost = value; }
        }
        public string Attachment
        {
            get { return _attachment; }
            set { _attachment = value; }
        }
        public string Cc
        {
            get { return _cc; }
            set { _cc = value; }
        }
        public string To
        {
            get { return _to; }
            set { _to = value; }
        }
        public string FormPwd
        {
            get { return _fromPwd; }
            set { _fromPwd = value; }
        }
        public string Form
        {
            get { return _form; }
            set { _form = value; }
        }

        public SendEmailObject(string form, string fromPwd, string to, string cc, string attachments, string smtpHost, string subject, string body)
        {
            _form = form;
            _fromPwd = fromPwd;
            _to = to;
            _cc = cc;
            _attachment = attachments;
            _smtpHost = smtpHost;
            _subject = subject;
            _body = body;
        }
        public SendEmailObject()
        {

        }
        public bool SendMail()
        {
            List<MailAddress> mailaddrs = new List<MailAddress>();
            if (_cc != null && _cc != "")
            {
                foreach (var item in _cc.Split(','))
                {
                    MailAddress mailaddr = new MailAddress(item);
                    mailaddrs.Add(mailaddr);
                }
            }
            List<Attachment> attachments = new List<Attachment>();
            if (_attachment != null & _attachment != "")
            {
                foreach (var item in _attachment.Split(','))
                {
                    Attachment att = new Attachment(item);
                    //MIME协议下的一个对象，用以设置附件的创建时间，修改时间以及读取时间  
                    //System.Net.Mime.ContentDisposition disposition = att.ContentDisposition;
                    //disposition.CreationDate = System.IO.File.GetCreationTime(file);
                    //disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                    //disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
                    attachments.Add(att);
                }
            }
            return SendMail(_form, _fromPwd, _to, _smtpHost, _subject, _body);
        }
        /// <summary>
        /// 发送邮件，返回true表示发送成功
        /// </summary>
        /// <param name="form">发件人邮箱地址；发件人用户名</param>
        /// <param name="fromPwd">密码</param>
        /// <param name="to">接受者邮箱地址</param>
        /// <param name="smtpHost">服务器的主机名</param>
        /// <param name="subject">邮件主题行</param>
        /// <param name="body">邮件主体正文</param>
        /// <returns></returns>
        private bool SendMail(string form, string fromPwd, string to, string smtpHost, string subject, string body)
        {
            System.Net.Mail.SmtpClient client = new SmtpClient();
            client.Host = smtpHost;
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential(form, fromPwd);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                System.Net.Mail.MailMessage message = new MailMessage(form, to);
                message.Subject = subject;
                message.Body = body;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                client.Send(message);
                return true;
            }
            catch (Exception)
            {
                //wirte log
                return false;
            }
        }
        /// <summary>
        /// 发送邮件，带抄送者，返回true表示发送成功
        /// </summary>
        /// <param name="form">发件人邮箱地址；发件人用户名</param>
        /// <param name="fromPwd">密码</param>
        /// <param name="to">接受者邮箱地址</param>
        /// <param name="cc">抄送者邮箱地址</param>
        /// <param name="smtpHost">服务器的主机名</param>
        /// <param name="subject">邮件主题行</param>
        /// <param name="body">邮件主体正文</param>
        /// <returns></returns>
        private bool SendMail(string form, string fromPwd, string to, string cc, string smtpHost, string subject, string body)
        {
            System.Net.Mail.SmtpClient client = new SmtpClient();
            client.Host = smtpHost;
            client.UseDefaultCredentials = true;

            client.Credentials = new System.Net.NetworkCredential(form, fromPwd);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                System.Net.Mail.MailMessage message = new MailMessage(form, to);
                message.Subject = subject;
                message.CC.Add(cc);
                message.Body = body;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                client.Send(message);
                return true;
            }
            catch (Exception)
            {
                //write log
                return false;
            }
        }

        /// <summary>
        /// 发送邮件，带抄送者，带附件，返回true表示发送成功
        /// </summary>
        /// <param name="form">发件人邮箱地址；发件人用户名</param>
        /// <param name="fromPwd">密码</param>
        /// <param name="to">接受者邮箱地址</param>
        /// <param name="cc">抄送者邮箱地址</param>
        /// <param name="smtpHost">服务器的主机名</param>
        /// <param name="subject">邮件主题行</param>
        /// <param name="body">邮件主体正文</param>
        ///  <param name="attachments">附件</param>
        /// <returns></returns>
        private bool SendMail(string form, string fromPwd, string to, List<MailAddress> cc, string smtpHost, string subject, string body, List<Attachment> attachments)
        {
            System.Net.Mail.SmtpClient client = new SmtpClient();
            client.Host = smtpHost;
            client.UseDefaultCredentials = true;

            client.Credentials = new System.Net.NetworkCredential(form, fromPwd);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                System.Net.Mail.MailMessage message = new MailMessage(form, to);
                message.Subject = subject;
                foreach (var ccItem in cc)
                {
                    message.CC.Add(ccItem);
                }
                foreach (var attItem in attachments)
                {
                    message.Attachments.Add(attItem);
                }
                message.Body = body;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = _isHtmlStyle;
                client.Send(message);
                return true;
            }
            catch (Exception)
            {
                //write log
                return false;
            }
        }
    }
}
