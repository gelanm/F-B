using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_Addgongcheng2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = memcached.Find("userName" + memcached.GetIP().ToString()); 
        //Convert.ToString(Session["userName"]);

        //=Convert.ToString(Session["qx"]);
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
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
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
