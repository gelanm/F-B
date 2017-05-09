using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_Addcustomer : System.Web.UI.Page
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
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(DB.SQLReplace(Request.QueryString["id"]));
                Maticsoft.BLL.gsclass bll = new Maticsoft.BLL.gsclass();
                Maticsoft.Model.gsclass model = bll.GetModel(id);

                this.Label1.Text = model.classname;

                this.myEditor.Value = model.content;
                if (model.classname == "常见问题")
                {
                    Response.Redirect("Addcustomer1.aspx?id=" + id + "");
                }
            }

        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
       



      

        int id = Convert.ToInt32(DB.SQLReplace(Request.QueryString["id"]));

        string sql = "update gsclass set content ='" + myEditor.Value + "' where id=" + id + "";
        DB.execnonsql(sql);
        MessageBox.Show(this, "更新成功");
    }
}
