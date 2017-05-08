using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_Addgongcheng1 : System.Web.UI.Page
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

            int id1 = Convert.ToInt32(Request.QueryString["id"]);
            Maticsoft.BLL.gsclass bll = new Maticsoft.BLL.gsclass();
            Maticsoft.Model.gsclass model1 = bll.GetModel(id1);
            this.Label1.Text = model1.classname;
            
            
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        
          

            int id = Convert.ToInt32(Request.QueryString["id"]);
            string pic = this.txtpic.Text;
            string title = this.TextBox1.Text;
            string content = this.WE_NewsContent.Text;



            Maticsoft.Model.gscontent model = new Maticsoft.Model.gscontent();
            model.classid = id;
            model.keywords = pic;
            model.title = title;
            model.time = DateTime.Now;
            model.content = content;
            model.faburen = this.TextBox2.Text;


            Maticsoft.BLL.gscontent bll = new Maticsoft.BLL.gscontent();
            bll.Add(model);
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
