using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_Adddaili : System.Web.UI.Page
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
                Maticsoft.Model.gsclass model1 = bll.GetModel(id);
                this.Label1.Text = model1.classname;
                
            
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        
            string strErr = "";

           

            if (this.TextBox1.Text == "")
            {
                strErr += "内容不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }


            string content = this.myEditor.Value;


            int classid = Convert.ToInt32(DB.SQLReplace(Request.QueryString["id"]));
            string title = this.TextBox1.Text;
            string jianjie = this.TextBox2.Text;
            string keywords = this.txtpic.Text;
        DateTime dtt=DateTime.Now;
        string sql = "insert into [gscontent]([title],[jianjie],[content],[keywords],[time],[classid])values('" + title + "','" + jianjie + "','" + content + "','" + keywords + "','" + dtt + "','" + classid + "')";
        DB.execnonsql(sql);
        MessageBox.Show(this, "插入成功");
          
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
