using System;
using System.Data;
using System.IO;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Common 的摘要说明


/// </summary>
public class Common
{
  
     
    public Common()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    } 
     
       

    public static object getLength(object Text, int len)
    {
        string str = Text.ToString();
        len *= 2;
        int newLength = 0;
        string newStr = "";
        for (int i = 0; i < str.Length; i++)
        {
            string singleStr = str.Substring(i, 1);
            byte[] bytes = System.Text.Encoding.Default.GetBytes(singleStr);
            newLength += bytes.Length;

            if (newLength > len)
            {
                break;
            }
            newStr += str.Substring(i, 1);
        }
        if (newLength > len)
        {
            newStr += "...";
        }

        return newStr;
    }
     
}
