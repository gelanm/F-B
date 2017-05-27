using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_AuditWeixinWanJu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!memcached.CheckLogin())
        {
            Response.Redirect("index.aspx");
        }

        if (!IsPostBack)
        {
            BLLDALMod.BLL.goodsBLL objgoods = new BLLDALMod.BLL.goodsBLL();
            DataView dv = objgoods.GetAllList().DefaultView;
            PagedDataSource pds = new PagedDataSource();

            ctrlPage.TotalRecords = dv.Count;
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = ctrlPage.PageIndex - 1;
            pds.PageSize = ctrlPage.PageSize;
            this.GridView1.DataSource = pds;
            this.GridView1.DataBind();
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BLLDALMod.BLL.goodsBLL objgoods = new BLLDALMod.BLL.goodsBLL();
        DataView dv = objgoods.GetAllList().DefaultView;
        PagedDataSource pds = new PagedDataSource();

        ctrlPage.TotalRecords = dv.Count;
        pds.DataSource = dv;
        pds.AllowPaging = true;
        pds.CurrentPageIndex = ctrlPage.PageIndex - 1;
        pds.PageSize = ctrlPage.PageSize;
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gr in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gr.Cells[0].FindControl("CheckBox1");
            if (chk.Checked)
            {
                BLLDALMod.Model.Goods objGoods = new BLLDALMod.Model.Goods();
                int id = Convert.ToInt32(((Label)gr.Cells[6].FindControl("Label1")).Text);

                //string sql = "UPDATE book SET [qx] = '1' WHERE (book.id = " + id + ")";
                //DB.execnonsql(sql);
                BLLDALMod.BLL.goodsBLL objgoods = new BLLDALMod.BLL.goodsBLL();
                objGoods = objgoods.GetModel(id);
                objGoods.State = "1";
                objgoods.Update(objGoods);

                MessageBox.Show(this,"审核成功");
                return;

            }
        }
    }

    protected void Del_Click(object sender, EventArgs e)
    {
        //foreach (GridViewRow gr in GridView1.Rows)
        //{
            //CheckBox chk = (CheckBox)gr.Cells[0].FindControl("CheckBox1");
            //if (chk.Checked)
            //{
            //    Maticsoft.BLL.book objbook = new Maticsoft.BLL.book();
            //    int id = Convert.ToInt32(((Label)gr.Cells[5].FindControl("Label1")).Text);
 
            //    objbook.Delete(id);

            //    MessageBox.Show(this, "删除成功");
                 
            //    DataView dv = objbook.GetAllList().DefaultView;
            //    PagedDataSource pds = new PagedDataSource();

            //    //AspNetPager1.RecordCount = dv.Count;
            //    pds.DataSource = dv;
            //    pds.AllowPaging = true;
            //    //pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            //    //pds.PageSize = AspNetPager1.PageSize;
            //    this.GridView1.DataSource = pds;
            //    this.GridView1.DataBind();
            //    return;               
            //}
        //}


        MessageBox.Show(this, "未开放功能");
        return;


    }
    

}
