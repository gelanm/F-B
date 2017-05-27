using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_RegisterWeixinWanJu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!memcached.CheckLogin())
        {
            Response.Redirect("index.aspx");
        }

        if (!IsPostBack)
        {
            BLLDALMod.BLL.WXUserBLL objWXUser = new BLLDALMod.BLL.WXUserBLL();
            DataView dv = objWXUser.GetAllList().DefaultView;
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
        BLLDALMod.BLL.WXUserBLL objWXUser = new BLLDALMod.BLL.WXUserBLL();
        DataView dv = objWXUser.GetAllList().DefaultView;
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

