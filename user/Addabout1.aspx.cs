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

public partial class user_Addabout1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = Convert.ToString(Session["userName"]);

        //=Convert.ToString(Session["qx"]);
        if (userName == "")
        {
            Response.Redirect("index.aspx");
        }
        if (Request.QueryString["Editabout"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["Editabout"]);
            this.TextBox1.Text = DB.FindString("select title from gscontent where id=" + id + "");
            this.myEditor.Value = DB.FindString("select content from gscontent where id=" + id + "");
            this.txtpic.Text = DB.FindString("select keywords from gscontent where id=" + id + "");

        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Editabout"] == null)
        {
            string strErr = "";

            if (this.TextBox1.Text == "")
            {
                strErr += "请输入标题！\\n";
            }

            if (this.myEditor.Value == "")
            {
                strErr += "请输入内容！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            string biaoti = this.TextBox1.Text;
            string neirong = this.myEditor.Value;
            string txtpic = this.txtpic.Text;
            int classid = Convert.ToInt32(this.DropDownList1.SelectedValue);
            DateTime dtt = DateTime.Now;
            string sql = "insert into gscontent([title],[content],[keywords],[classid],[time])values('" + biaoti + "','" + neirong + "','" + txtpic + "'," + classid + ",'" + dtt + "')";
            DB.execnonsql(sql);
            MessageBox.Show(this, "提交成功");
            return;
        }


        if (Request.QueryString["Editabout"] != null)
            {
                SqlDataSource1.Update();

                MessageBox.Show(this, "提交成功");
                return;
        }
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

