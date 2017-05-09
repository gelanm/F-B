using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Maticsoft.Model;

public partial class user_Addjishu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = Convert.ToString(Session["userName"]);

        //=Convert.ToString(Session["qx"]);
        if (userName == "")
        {
            Response.Redirect("index.aspx");
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["jishu"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["jishu"]);
                Maticsoft.BLL.gscontent bll = new Maticsoft.BLL.gscontent();
                Maticsoft.Model.gscontent model = bll.GetModel(id);
                this.TextBox2.Text = model.title;
                this.myEditor.Value = Server.HtmlDecode(model.content.ToString());
            }
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["jishu"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["jishu"]);
            string strErr = "";

            if (this.TextBox2.Text == "")
            {
                strErr += "标题不能为空！\\n";
            }


            if (this.myEditor.Value == "")
            {
                strErr += "内容不能为空！\\n";
            }
            if (this.TextBox3.Text=="")
            {
                strErr += "发布人不能为空~\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }


            string title = this.TextBox2.Text;
            string faburen = this.TextBox3.Text;
            DateTime time = DateTime.Now;
            string content = Server.HtmlEncode(this.myEditor.Value.ToString().Replace("'", "!"));



            Maticsoft.Model.gscontent model = new Maticsoft.Model.gscontent();
            model.id = id;
            model.title = title;

            model.time = time;
            model.content = content;
            model.faburen = faburen;

            Maticsoft.BLL.gscontent bll = new Maticsoft.BLL.gscontent();
            bll.Update(model);
        }
        else
        {
            string strErr = "";

            if (this.TextBox2.Text == "")
            {
                strErr += "标题不能为空！\\n";
            }


            if (this.myEditor.Value == "")
            {
                strErr += "内容不能为空！\\n";
            }
            if (this.TextBox3.Text == "")
            {
                strErr += "发布人不能为空~\\n";
            }


            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            string title = this.TextBox2.Text;
            
            DateTime time = DateTime.Now;
            string content = this.myEditor.Value;
            string faburen = this.TextBox3.Text;

            int classid = 22;

            Maticsoft.Model.gscontent model = new Maticsoft.Model.gscontent();

            model.title = title;
            model.faburen = faburen;
            model.time = time;
            model.content = content;


            model.classid = classid;

            Maticsoft.BLL.gscontent bll = new Maticsoft.BLL.gscontent();
            bll.Add(model);
            MessageBox.Show(this, "添加成功");
            this.TextBox2.Text = "";
            this.myEditor.Value = "";
            return;
        }
    }
}
