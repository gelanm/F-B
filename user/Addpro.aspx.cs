using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Maticsoft.Model;

public partial class user_Addpro : System.Web.UI.Page
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
            if (Request.QueryString["editpro"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["editpro"]);
                Maticsoft.BLL.product bll = new Maticsoft.BLL.product();
                Maticsoft.Model.product model = bll.GetModel(id);
                this.TextBox2.Text = model.protitle;
                this.myEditor.Value = model.procontent;
                this.DropDownList1.SelectedValue = Convert.ToString(model.classid);
                this.txtpic.Text = model.propic;

            }
            BindClass();

        }
    }
    void BindClass()
    {
        List<productclass> list = Maticsoft.BLL.productclass.get_List();
        foreach (productclass model in list)
        {
            ListItem li = new ListItem();
            li.Text = "╋" + model.productname;
            li.Value = model.id.ToString();
            DropDownList1.Items.Add(li);
            BindChild(model.id.ToString(), "├──");
        }
    }

    void BindChild(string ParentID, string separator)
    {
        List<productclass> list = Maticsoft.BLL.productclass.get_List(ParentID);
        foreach (productclass model in list)
        {
            ListItem li = new ListItem();
            li.Text = separator + model.productname;
            li.Value = model.id.ToString();
            DropDownList1.Items.Add(li);
            string separator_ = separator + "───";
            BindChild(model.id.ToString(), separator_);
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["editpro"] != null)
        {
            string strErr = "";

            if (this.TextBox2.Text == "")
            {
                strErr += "标题不能为空！\\n";
            }


            if (this.myEditor.Value == "")
            {
                strErr += "内容不能为空！\\n";
            }
            if (this.txtpic.Text == "")
            {
                strErr +="请插入图片！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            int id=Convert.ToInt32(Request.QueryString["editpro"]);
            string title = this.TextBox2.Text;
           string pic=this.txtpic.Text;
            DateTime time = DateTime.Now;
            string content = this.myEditor.Value;


            int classid = Convert.ToInt32(this.DropDownList1.SelectedValue);

            Maticsoft.Model.product model = new Maticsoft.Model.product();

            model.protitle = title;
            model.propic = pic;
            model.fabutime = time;
            model.procontent = content;
            model.id=id;

            model.classid = classid;

            Maticsoft.BLL.product bll = new Maticsoft.BLL.product();
            bll.Update(model);
            MessageBox.Show(this, "更新成功");
           
            
            return;
        }
        else
        {
            string strErr = "";

            if (this.TextBox2.Text == "")
            {
                strErr += "标题不能为空！\\n";
            }


            if (this.myEditor.Value == "")
            {
                strErr += "内容不能为空！\\n";
            }
            if (this.txtpic.Text == "")
            {
                strErr += "请插入图片！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            
            string title = this.TextBox2.Text;
           string pic=this.txtpic.Text;
            DateTime time = DateTime.Now;
            string content = this.myEditor.Value;


            int classid = Convert.ToInt32(this.DropDownList1.SelectedValue);

            Maticsoft.Model.product model = new Maticsoft.Model.product();

            model.protitle = title;
            model.propic = pic;
            model.fabutime = time;
            model.procontent = content;


            model.classid = classid;

            Maticsoft.BLL.product bll = new Maticsoft.BLL.product();
            bll.Add(model);
            MessageBox.Show(this, "添加成功");
           
            this.TextBox2.Text = "";
            this.myEditor.Value = "";
            return;
        }
    }
}
