using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_Addgongcheng : System.Web.UI.Page
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

            if (Request.QueryString["edgongcheng"] != null)
            {
                int id = Convert.ToInt32(DB.SQLReplace(Request.QueryString["edgongcheng"]));
                Maticsoft.BLL.gscontent bll = new Maticsoft.BLL.gscontent();
                Maticsoft.Model.gscontent model = bll.GetModel(id);
                this.TextBox2.Text = model.title;
                this.TextBox1.Text = model.faburen;
                this.myEditor.Value = model.content;
                

            }
            else
            {
                int id1 = Convert.ToInt32(Request.QueryString["id"]);
                Maticsoft.BLL.gsclass bll = new Maticsoft.BLL.gsclass();
                Maticsoft.Model.gsclass model1 = bll.GetModel(id1);
                this.Label1.Text = model1.classname;
                if (Label1.Text != "吊顶效果图")
                {
                     if (Label1.Text == "精品案例")
                    {
                        Response.Redirect("Addgongcheng1.aspx?id=" + id1 + "");
                    }
                    Response.Redirect("Addgongcheng2.aspx?id=" + id1 + "");
                }

               
              

            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["edgongcheng"] == null)
        {
            string strErr = "";

            if (this.TextBox2.Text == "")
            {
                strErr += "标题不能为空！\\n";
            }
            if (this.TextBox1.Text == "")
            {
                strErr += "发布人不能为空！\\n";
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

            string title = this.TextBox2.Text;
            string faburen = this.TextBox1.Text;
            DateTime time = DateTime.Now;
            string content = this.myEditor.Value;
            string pic = this.txtpic.Text;
           
            int classid = Convert.ToInt32(DropDownList1.SelectedValue);
           

            Maticsoft.Model.gscontent model = new Maticsoft.Model.gscontent();

            model.title = title;
            model.faburen = faburen;
            model.time = time;
            model.content = content;
            model.keywords = pic;

            model.classid = classid;

            Maticsoft.BLL.gscontent bll = new Maticsoft.BLL.gscontent();
            bll.Add(model);
            MessageBox.Show(this, "添加成功");
            this.TextBox1.Text = "";
            this.TextBox2.Text = "";
            this.myEditor.Value = "";
            return;

        }
        else
        {
           

            int id = Convert.ToInt32(Request.QueryString["edgs"]);
            string title = this.TextBox2.Text;
            string faburen = this.TextBox1.Text;
            DateTime time = DateTime.Now;
            string content = this.myEditor.Value;

            string pic = this.txtpic.Text;

            Maticsoft.Model.gscontent model = new Maticsoft.Model.gscontent();
            model.id = id;
            model.title = title;
            model.faburen = faburen;
            model.time = time;
            model.content = content;
            model.keywords = pic;

            Maticsoft.BLL.gscontent bll = new Maticsoft.BLL.gscontent();
            bll.Update(model);
            MessageBox.Show(this, "更新成功");
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
