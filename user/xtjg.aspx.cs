using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;
using System.Text;
using System.Data;

public partial class user_xtjg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    private void bind()
    {
         
        //DataTable dt = GetAllbyid( DropDownList1.SelectedValue);
        //if (dt.Rows.Count != 0)
        //{
        //    WE_NewsContent.Text = dt.Rows[0]["cont"].ToString();
        //}
    }
    public DataTable GetAll()
    {
        StringBuilder strSql = new StringBuilder();
        strSql = new StringBuilder();
        strSql.Append("select  * from qxcp ");
        return DbHelperOleDb.Fill(strSql.ToString());
    }
    public DataTable GetAllbyid(string id)
    {
        StringBuilder strSql = new StringBuilder();
        strSql = new StringBuilder();
        strSql.Append("select  * from xtjg where cpid='" + id + "'");
        return DbHelperOleDb.Fill(strSql.ToString());
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    { 

        StringBuilder strSql = new StringBuilder();
        StringBuilder strSql1 = new StringBuilder();
        StringBuilder strSql2 = new StringBuilder();
        string _cpid = DropDownList1.SelectedValue.ToString();
        string _cont = myEditor.Value;
        if (_cpid != null)
        {
            strSql1.Append("cpid,");
            strSql2.Append("'" + _cpid + "',");
        }
        if (_cont != null)
        {
            strSql1.Append("cont,");
            strSql2.Append("'" + _cont + "',");
        }
        strSql.Append("insert into xtjg(");
        strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
        strSql.Append(")");
        strSql.Append(" values (");
        strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
        strSql.Append(")");
        DbHelperOleDb.ExecuteSql(strSql.ToString());

    }

    
    protected void Button1_Click(object sender, EventArgs e)
    {
        bind();
    }
}