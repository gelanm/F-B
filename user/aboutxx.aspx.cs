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

public partial class user_aboutxx : System.Web.UI.Page
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
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Maticsoft.BLL.gscontent bll = new Maticsoft.BLL.gscontent();
                Maticsoft.Model.gscontent model = bll.GetModel(id);
                this.TextBox1.Text = model.title;
                this.txtpic.Text = model.keywords;
                this.myEditor.Value = model.content;
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {



        string strErr = "";

       
        if (this.TextBox1.Text == "")
        {
            strErr += "标题不能为空！\\n";
        }

        if (this.myEditor.Value == "")
        {
            strErr += "内容不能为空！\\n";
        }

        if (strErr != "")
        {
            MessageBox.Show(this, strErr);
            return;
        }

        int id = Convert.ToInt32(Request.QueryString["id"]);
        string title = this.TextBox1.Text;
        string pic = this.txtpic.Text;
        string content = this.myEditor.Value;
        DateTime dtt = DateTime.Now;


        string sql = "update [gscontent] set [title]='" + title + "',[keywords]='" + pic + "',[content]='" + content + "',[time]='" + dtt + "' where id=" + id + "";
        DB.execnonsql(sql);
        MessageBox.Show(this, "修改成功");
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
