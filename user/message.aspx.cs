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

public partial class user_message : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = memcached.Find("userName" + memcached.GetIP().ToString());

        if (userName == "")
        {
            Response.Redirect("index.aspx");
        }
        if (!IsPostBack)
        {
            Maticsoft.BLL.wangzhan bll = new Maticsoft.BLL.wangzhan();
            Maticsoft.Model.wangzhan model = bll.GetModel(1);
            this.myEditor.Value = model.lianxiwm;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Maticsoft.BLL.wangzhan bll = new Maticsoft.BLL.wangzhan();
        Maticsoft.Model.wangzhan model = bll.GetModel(1);
        model.lianxiwm = this.myEditor.Value;
        if (bll.Update(model))
        {
            MessageBox.Show(this, "更新成功");
        }
        else
        {
            MessageBox.Show(this, "更新失败");
        }
        return;
    }
}
