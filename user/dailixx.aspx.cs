using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_dailixx : System.Web.UI.Page
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
            int id =Convert.ToInt32( Request.QueryString["id"]);
            this.TextBox1.Text = DB.FindString("select title from gscontent where id=" + id + "");
            this.TextBox2.Text = DB.FindString("select jianjie from gscontent where id=" + id + "");
            this.myEditor.Value = DB.FindString("select content from gscontent where id=" + id + "");
            this.txtpic.Text = DB.FindString("select keywords from gscontent where id=" + id + "");
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int id=Convert.ToInt32(Request.QueryString["id"]);
        string title = this.TextBox1.Text;
        string jianjie = this.TextBox2.Text;
        string content = this.myEditor.Value;
        string pic = txtpic.Text;
        DateTime dtt = DateTime.Now;
        string sql = "update [gscontent]set [title]='" + title + "',[jianjie]='" + jianjie + "',[content]='" + content + "',[keywords]='" + pic + "',[time]='" + dtt + "'where id=" + id + "";
        DB.execnonsql(sql);
        MessageBox.Show(this, "更新成功");
        return;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string res;
        upload up = new upload();
        res = up.Up(file1, "../Uploads/");
        this.Label2.Visible = true;
        this.Label2.Text = up.Resup[Convert.ToInt32(res)];
        this.txtpic.Text = up.s;
    }
}
