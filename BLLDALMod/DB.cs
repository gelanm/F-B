using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using Maticsoft.DBUtility;
/// <summary>
/// DB 的摘要说明
/// </summary>
public class DB
{
    public static string connectionString = PubConstant.ConnectionString;     
	public DB()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static OleDbConnection Getconn()
    {
        OleDbConnection conn = new OleDbConnection(connectionString);
      
        return conn;
    
    }
    //=================================================
    //功能描述：关闭数据库
 
    //=================================================
    private static void closeConnection()
    {
        OleDbConnection conn = DB.Getconn();
        OleDbCommand cmd = new OleDbCommand();
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
            conn.Dispose();
            cmd.Dispose();
        }
    }
    //=================================================
    //功能描述：执行SQL语句
    //输入参数：sql，查询的SQL语句
    //时间：2007.11.10
    //=================================================
    public static  void execnonsql(string sql)
    {
       
            OleDbConnection conn = DB.Getconn();
            conn.Open();
            OleDbCommand com = new OleDbCommand(sql, conn);
            com.ExecuteNonQuery();
            conn.Close();
        
           
        

    }
    //=================================================
    //功能描述：获取DATASET
    //输入参数：sql，查询的SQL语句
    //返回值：DataSet
    //时间：2007.11.10
    //=================================================
    public static DataSet getdataset(string sql)
    {
       
            OleDbConnection conn = DB.Getconn();
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds, "ds");
        closeConnection();
            return ds;
      
        
        
    }
    //=================================================
    //功能描述：获取DATASET1
    //输入参数：sql，查询的SQL语句
    //返回值：DataSet
    //时间：2007.11.10
    //=================================================
    public static DataSet select(string sql,string tablename)
    {
       
            OleDbConnection conn = DB.Getconn();
            OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds, tablename);
            closeConnection();
        
        return ds;
       
            
        
    }
    //=================================================
    //功能描述：获取某个字段数据
    //输入参数：sql，查询的SQL语句
    //返回值：hang
    //时间：2007.11.10
    //=================================================
    public static string FindString(string sql)
    {
        
            OleDbConnection conn = DB.Getconn();
            conn.Open();
            OleDbCommand com = new OleDbCommand(sql, conn);
          
  string hang = Convert.ToString(com.ExecuteScalar());
  conn.Close();
            return hang;
       
            
        

    }
    //=================================================
    //功能描述：对DATAGRIG进行数据绑定，无排序
    //输入参数：sql，查询的SQL语句；dg，需要绑定的DATAGRID控件
    //返回值：无
    //时间：2007.11.10
    //=================================================
    public static void binddatagrid(string sql, DataGrid dg)
    {

        
            DataSet ds = getdataset(sql);
            dg.DataSource = ds.Tables[0].DefaultView;

        closeConnection();
            dg.DataBind();
       
         
        
    }
    //=================================================
    //功能描述：对DropDownList进行数据绑定，无排序
    //输入参数：sql，查询的SQL语句；dg，需要绑定的DATAGRID控件
    //返回值：无
    //时间：2007.11.10
    //=================================================
    public static void bindDropDownList(string sql, DropDownList dl, string class_name, string id)
    {

        
            DataSet ds = getdataset(sql);
            dl.DataSource = ds.Tables[0].DefaultView;
            dl.DataTextField = class_name;
            dl.DataValueField = id;

        closeConnection();
 
            dl.DataBind();
       
           
        
    }
    //=================================================
    //功能描述：对RadioButtonList进行数据绑定，无排序
    //输入参数：sql，查询的SQL语句；dg，需要绑定的DATAGRID控件
    //返回值：无
    //时间：2007.11.10
    //=================================================
    public static void bindRadioButtonList(string sql, RadioButtonList rl, string class_name, string id)
    {

        
            DataSet ds = getdataset(sql);
            rl.DataSource = ds.Tables[0].DefaultView;
            rl.DataTextField = class_name;
            rl.DataValueField = id;
            rl.SelectedIndex = 0; 
        closeConnection();
            rl.DataBind();
       
           
        
    }
    //=================================================
    //功能描述：对GridView进行数据绑定，无排序
    //输入参数：sql，查询的SQL语句；dg，需要绑定的DATAGRID控件
    //返回值：无
    //时间：2007.11.10
    //=================================================
    public static void bindGridView(string sql, GridView dg)
    {
        
            OleDbConnection conn = DB.Getconn();
            DataSet ds = getdataset(sql);
            dg.DataSource = ds.Tables[0].DefaultView;

        closeConnection();
            dg.DataBind();
        
            
        
    }
    //=================================================
    //功能描述：对datalist进行数据绑定，无排序
    //输入参数：sql，查询的SQL语句；dl，需要绑定的datalist控件
    //返回值：无
    //时间：2007.11.10
    //=================================================
    public static void binddatalist(string sql, DataList dl)
    {
        
            OleDbConnection conn = DB.Getconn();
            DataSet ds = getdataset(sql);
            dl.DataSource = ds.Tables[0].DefaultView;

        closeConnection();
            dl.DataBind();
       
            
        
    }
    //=================================================
    //功能描述：对repeater进行数据绑定，无排序
    //输入参数：sql，查询的SQL语句；dl，需要绑定的repeater控件
    //返回值：无
    //时间：2007.11.10
    //=================================================
    public static void bindrepeater(string sql, Repeater rp)
    {
        
            OleDbConnection conn = DB.Getconn();
            DataSet ds = getdataset(sql);
            rp.DataSource = ds.Tables[0].DefaultView;

        closeConnection();
            rp.DataBind();
       
            
        
    }
    //=================================================
    //功能描述：对listbox进行数据绑定
    //输入参数：sql，查询的SQL语句；listb，需要绑定的listbox控件
    //返回值：无
    //时间：2007.11.10
    //=================================================
    public static void bindlistbox(string sql, ListBox listb, string class_name, string id)
    {
        
            OleDbConnection conn = DB.Getconn();
            DataSet ds = getdataset(sql);
            listb.DataSource = ds.Tables[0].DefaultView;
            listb.DataTextField = class_name;
            listb.DataValueField = id;

        closeConnection();
            listb.DataBind();
      
           
        
    }
    /// <summary>
    /// 返回 HTML 字符串的编码结果
    /// </summary>
    /// <param name="str">字符串</param>
    /// <returns>编码结果</returns>
    public static string HtmlEncode(string str)
    {
        return HttpUtility.HtmlEncode(str);
    }

    /// <summary>
    /// 返回 HTML 字符串的解码结果
    /// </summary>
    /// <param name="str">字符串</param>
    /// <returns>解码结果</returns>
    public static string HtmlDecode(string str)
    {
        return HttpUtility.HtmlDecode(str);
    }
    /// <summary>
    /// 检测是否有Sql危险字符
    /// </summary>
    /// <param name="str">要判断字符串</param>
    /// <returns>判断结果</returns>
    public static bool IsSafeSqlString(string str)
    {

        return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
    }

    /// <summary>
    /// 防止输入SQL注入，替换字符
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string SQLReplace(string ParaValue)
    {
        
       
        ParaValue = ParaValue.Replace("+", "").Replace("-", "").Replace("=", "").Replace("%", "").Replace("<", "&gt;").Replace(">", "&lt;").Replace("<>", "").Replace("'", "").Replace("[","").Replace("]","").Replace("!","").Replace("@","").Replace("#","").Replace(",","").Replace(";","");

        return ParaValue;

    }

    /// <summary>
    /// 检测用户登录。
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public static string UserCheck(string username,string userpass)
    {
        string strsql = "select count(*) from Member where mem_Name='" + username + "' and mem_Password='"+userpass+"'";
        OleDbConnection conn = DB.Getconn();
        OleDbCommand com = new OleDbCommand(strsql, conn);
        string hang = Convert.ToString(com.ExecuteScalar());
        return hang;
    }
    /// <summary>
    /// ASCII截取字符串
    /// </summary>
    /// <param name="str"></param>
    /// <param name="len"></param>
    /// <returns></returns>
    public static string cutTitle(string str, int len)
    {
        int intLen = str.Length;
        int start = 0;
        int end = intLen;
        int single = 0;
        char[] chars = str.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            if (Convert.ToInt32(chars[i]) > 255)
            {
                start += 2;
            }
            else
            {
                start += 1;
                single++;
            }
            if (start >= len)
            {

                if (end % 2 == 0)
                {
                    if (single % 2 == 0)
                    {
                        end = i + 1;
                    }
                    else
                    {
                        end = i;
                    }
                }
                else
                {
                    end = i + 1;
                }
                break;
            }
        }
        string temp = str.Substring(0, end);
        if (str.Length > end)
        {
            return temp + "...";
        }
        else
        {
            return temp;
        }
    }
    public static string replace(string str, string str2)
    {
        str = str.Replace(";", str2);
        str = str.Replace("&", str2);
        str = str.Replace("<", str2);
        str = str.Replace(">", str2);
        str = str.Replace("'", str2);
        str = str.Replace("--", str2);
        str = str.Replace("/", str2);
        str = str.Replace("%", str2);
        str = str.Replace("~", str2);
        str = str.Replace(",", str2);
        str = str.Replace("`", str2);
        str = str.Replace("!", str2);
        str = str.Replace("@", str2);
        str = str.Replace("#", str2);
        str = str.Replace("$", str2);
        str = str.Replace("^", str2);
        str = str.Replace("*", str2);
        str = str.Replace("(", str2);
        str = str.Replace(")", str2);
        str = str.Replace("+", str2);
        str = str.Replace(":", str2);
        str = str.Replace("<", str2);
        str = str.Replace(">", str2);
        str = str.Replace("?", str2);
        str = str.Replace("/", str2);
        str = str.Replace("\\", str2);
        str = str.Replace("\"", str2);
        str = str.Replace("{", str2);
        str = str.Replace("}", str2);
        str = str.Replace("[", str2);
        str = str.Replace("]", str2);
        str = str.Replace("-", str2);
        str = str.Replace("_", str2);
        str = str.Replace(" ", str2);
        str = str.Replace("！", str2);
        str = str.Replace("~", str2);
        str = str.Replace("￥", str2);
        str = str.Replace("……", str2);
        str = str.Replace("（", str2);
        str = str.Replace("）", str2);
        str = str.Replace(" ", str2);
        str = str.Replace("——", str2);
        str = str.Replace("、", str2);
        str = str.Replace("select", str2);
        str = str.Replace("update", str2);
        str = str.Replace("insert", str2);
        str = str.Replace("delete", str2);
        str = str.Replace("drop", str2);
        str = str.Replace("delcare", str2);
        str = str.Replace("create", str2);
        str = str.Replace("A", str2);
        str = str.Replace("B", str2);
        str = str.Replace("C", str2);
        str = str.Replace("D", str2);
        str = str.Replace("E", str2);
        str = str.Replace("F", str2);
        str = str.Replace("G", str2);
        str = str.Replace("H", str2);
        str = str.Replace("I", str2);
        str = str.Replace("J", str2);
        str = str.Replace("K", str2);
        str = str.Replace("L", str2);
        str = str.Replace("M", str2);
        str = str.Replace("N", str2);
        str = str.Replace("O", str2);
        str = str.Replace("P", str2);
        str = str.Replace("Q", str2);
        str = str.Replace("R", str2);
        str = str.Replace("S", str2);
        str = str.Replace("T", str2);
        str = str.Replace("U", str2);
        str = str.Replace("V", str2);
        str = str.Replace("W", str2);
        str = str.Replace("X", str2);
        str = str.Replace("Y", str2);
        str = str.Replace("Z", str2);
        str = str.Replace("a", str2);
        str = str.Replace("b", str2);
        str = str.Replace("c", str2);
        str = str.Replace("d", str2);
        str = str.Replace("e", str2);
        str = str.Replace("f", str2);
        str = str.Replace("g", str2);
        str = str.Replace("h", str2);
        str = str.Replace("i", str2);
        str = str.Replace("j", str2);
        str = str.Replace("k", str2);
        str = str.Replace("l", str2);
        str = str.Replace("m", str2);
        str = str.Replace("n", str2);
        str = str.Replace("o", str2);
        str = str.Replace("p", str2);
        str = str.Replace("q", str2);
        str = str.Replace("r", str2);
        str = str.Replace("s", str2);
        str = str.Replace("t", str2);
        str = str.Replace("u", str2);
        str = str.Replace("v", str2);
        str = str.Replace("w", str2);
        str = str.Replace("x", str2);
        str = str.Replace("y", str2);
        str = str.Replace("z", str2);
        return str;
    }

}

