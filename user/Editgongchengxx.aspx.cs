using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_Editgongchengxx : System.Web.UI.Page
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
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Maticsoft.BLL.gscontent bll = new Maticsoft.BLL.gscontent();
            Maticsoft.Model.gscontent model = bll.GetModel(id);
            this.TextBox1.Text = model.title;
            this.TextBox2.Text = model.faburen;
            this.txtpic.Text = model.keywords;
            this.myEditor.Value = model.content;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string pic = this.txtpic.Text;
        string title = this.TextBox1.Text;
        string content = this.myEditor.Value;
        string faburen=this.TextBox2.Text;


        string sql = "update [gscontent] set [title]='" + title + "',[faburen]='" + faburen + "',[keywords]='" + pic + "',[content]='" + content + "' where id=" + id + "";

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
