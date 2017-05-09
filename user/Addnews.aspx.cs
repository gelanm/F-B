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

public partial class user_Addnews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {   
            if (!memcached.CheckLogin())
            {
                Response.Redirect("index.aspx");
            }
            btnDel.Visible = false;
            if (Request.QueryString["editnews"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["editnews"]);
                Maticsoft.BLL.newscontent bll = new Maticsoft.BLL.newscontent();
                Maticsoft.Model.newscontent model = bll.GetModel(id);
                this.TextBox1.Text = model.faburen;
                this.TextBox2.Text = model.title;
                this.myEditor.Value = model.content;
                btnDel.Visible = true;                
            }
            BindClass();
        }
    }


    protected void btnDel_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["editnews"]);
        
        Maticsoft.BLL.newscontent bll = new Maticsoft.BLL.newscontent();
        bll.Delete(id);
        MessageBox.Show(this, "删除成功");
        return;
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["editnews"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["editnews"]);
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
            int hit = Convert.ToInt32(this.DropDownList1.SelectedValue);


            Maticsoft.Model.newscontent model = new Maticsoft.Model.newscontent();
            model.id = id;
            model.title = title;
            model.faburen = faburen;
            model.time = time;
            model.content = content;
            model.hit = hit;

            Maticsoft.BLL.newscontent bll = new Maticsoft.BLL.newscontent();
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
            int hit = Convert.ToInt32(this.DropDownList1.SelectedValue);


            Maticsoft.Model.newscontent model = new Maticsoft.Model.newscontent();
           
            model.title = title;
            model.faburen = faburen;
            model.time = time;
            model.content = content;
            model.hit = hit;

            Maticsoft.BLL.newscontent bll = new Maticsoft.BLL.newscontent();
            bll.Add(model);
            MessageBox.Show(this, "添加成功");
            return;
        }
    }
    void BindClass()
    {
        List<newsbig> list = Maticsoft.BLL.newsbig.get_List();
        foreach (newsbig model in list)
        {
            ListItem li = new ListItem();
            li.Text = "╋" + model.newsclass;
            li.Value = model.id.ToString();
            DropDownList1.Items.Add(li);
            BindChild(model.id.ToString(), "├──");
        }
    }

    void BindChild(string ParentID, string separator)
    {
        List<newsbig> list = Maticsoft.BLL.newsbig.get_List(ParentID);
        foreach (newsbig model in list)
        {
            ListItem li = new ListItem();
            li.Text = separator + model.newsclass;
            li.Value = model.id.ToString();
            DropDownList1.Items.Add(li);
            string separator_ = separator + "───";
            BindChild(model.id.ToString(), separator_);
        }
    }
}
