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
public partial class user_productleibei : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string userName = Convert.ToString(Session["userName"]);

            //=Convert.ToString(Session["qx"]);
            if (userName == "")
            {
                Response.Redirect("index.aspx");
            }
            BindClass();
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string strErr = "";



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

        int id = Convert.ToInt32(this.DropDownList1.SelectedValue);
        string pic = this.txtpic.Text;
        string content = this.myEditor.Value;
        Maticsoft.Model.productclass model = new Maticsoft.Model.productclass();

        model.id = id;
        model.propic = pic;
      
        model.content = content;
       

        

        Maticsoft.BLL.productclass bll = new Maticsoft.BLL.productclass();
        bll.Update(model);
        MessageBox.Show(this, "提交成功");


        return;
    }
}
