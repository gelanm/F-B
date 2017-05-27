using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class user_left : System.Web.UI.Page
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
            int id=1;
            Maticsoft.BLL.gsclass bll = new Maticsoft.BLL.gsclass();
            DataTable dt = bll.GetAll(id);
            this.Repeater1.DataSource = dt;
            this.Repeater1.DataBind();
            int careeasid = 6;
            //Maticsoft.BLL.gsclass bll1 = new Maticsoft.BLL.gsclass();
            //DataTable dt1 = bll1.GetAll(careeasid);
            //this.Repeater4.DataSource = dt1;
            //this.Repeater4.DataBind();
            //int customerid = 5;
            //Maticsoft.BLL.gsclass bll2 = new Maticsoft.BLL.gsclass();
            //DataTable dt2 = bll1.GetAll(customerid);
            //this.Repeater3.DataSource = dt2;
            //this.Repeater3.DataBind();
            //int dailiid = 3;
            //Maticsoft.BLL.gsclass bll3 = new Maticsoft.BLL.gsclass();
            //DataTable dt3 = bll1.GetAll(dailiid);
            //this.Repeater5.DataSource = dt3;
            //this.Repeater5.DataBind();
            int gongchengid = 4;
            Maticsoft.BLL.gsclass bll4 = new Maticsoft.BLL.gsclass();
            DataTable dt4 = bll4.GetAll(gongchengid);
            this.Repeater2.DataSource = dt4;
            this.Repeater2.DataBind();
 
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        memcached.Logout();
        Response.Redirect("index.aspx");
    }
}
