using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LTP.Common;
using System.Data;
public partial class user_Edituser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!memcached.CheckLogin())
        {
            Response.Redirect("index.aspx");
        }
        if (!IsPostBack)
        {
   
            Maticsoft.BLL.user objuser = new Maticsoft.BLL.user();

            DataView dv = objuser.GetAllList().DefaultView;
            PagedDataSource pds = new PagedDataSource();

            //AspNetPager1.RecordCount = dv.Count;
            pds.DataSource = dv;
            pds.AllowPaging = true;
            //pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            //pds.PageSize = AspNetPager1.PageSize;
            this.GridView1.DataSource = pds;
            this.GridView1.DataBind();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string strErr = "";
       
        if (this.txtadmin.Text == "")
        {
            strErr += "用户名不能为空！\\n";
        }
        if (this.txtpass.Text == "")
        {
            strErr += "密码不能为空！\\n";
        }

        if (strErr != "")
        {
            MessageBox.Show(this, strErr);
            return;
        }
        
        string admin = this.txtadmin.Text;
        string pass = MD5.Hash(this.txtpass.Text.Trim());

        Maticsoft.Model.user model = new Maticsoft.Model.user();
     
        model.admin = admin;
        model.pass = pass;

        Maticsoft.BLL.user bll = new Maticsoft.BLL.user();
        bll.Add(model);
        MessageBox.Show(this, "添加成功");
        Maticsoft.BLL.user objuser = new Maticsoft.BLL.user();

        DataView dv = objuser.GetAllList().DefaultView;
        PagedDataSource pds = new PagedDataSource();

        //AspNetPager1.RecordCount = dv.Count;
        pds.DataSource = dv;
        pds.AllowPaging = true;
        //pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        //pds.PageSize = AspNetPager1.PageSize;
        this.GridView1.DataSource = pds;
        this.GridView1.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gr in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gr.Cells[0].FindControl("CheckBox1");
            if (chk.Checked)
            {
                int id = Convert.ToInt32(((Label)gr.Cells[3].FindControl("Label1")).Text);
                Maticsoft.BLL.user bll = new Maticsoft.BLL.user();
                bll.Delete(id);
                MessageBox.Show(this, "删除成功");
                

            }
            
        }
        Maticsoft.BLL.user objuser = new Maticsoft.BLL.user();

        DataView dv = objuser.GetAllList().DefaultView;
        PagedDataSource pds = new PagedDataSource();

        //AspNetPager1.RecordCount = dv.Count;
        pds.DataSource = dv;
        pds.AllowPaging = true;
        //pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        //pds.PageSize = AspNetPager1.PageSize;
        this.GridView1.DataSource = pds;
        this.GridView1.DataBind();
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow gr in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gr.Cells[0].FindControl("CheckBox1");
            if (chk.Checked)
            {
                chk.Checked = false;
            }
            else
            {
                chk.Checked = true;
            }
        }
    }
}
