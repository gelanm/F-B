using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class user_aboutAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = memcached.Find("userName" + memcached.GetIP().ToString());

        if (userName == "")
        {
            Response.Redirect("index.aspx");
        }
        if (!IsPostBack)
        {
            int id = Convert.ToInt32(DB.SQLReplace(Request.QueryString["id"]));
            Maticsoft.BLL.gsclass bll = new Maticsoft.BLL.gsclass();
            Maticsoft.Model.gsclass model = bll.GetModel(id);
            
            this.Label1.Text = model.classname;

            this.myEditor.Value = model.content;
            if (Label1.Text == "企业荣誉")
            {
                Response.Redirect("Editbout1.aspx");
            }
            if (Label1.Text == "企业资质")
            {
                Response.Redirect("Editbout1.aspx");
            }
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string strErr = "";



        if (this.myEditor.Value == "")
        {
            strErr += "请输入内容！\\n";
        }

        if (strErr != "")
        {
            MessageBox.Show(this, strErr);
            return;
        }

        int id = Convert.ToInt32(DB.SQLReplace(Request.QueryString["id"]));

        string content = this.myEditor.Value;


        Maticsoft.Model.gsclass model = new Maticsoft.Model.gsclass();
        model.id = id;
        model.content = content;

        Maticsoft.BLL.gsclass bll = new Maticsoft.BLL.gsclass();
        bll.Update(model);
        MessageBox.Show(this, "更新成功");
        return;
    }
}
