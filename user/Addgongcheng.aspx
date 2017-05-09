<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Addgongcheng.aspx.cs" Inherits="user_Addgongcheng" %>
<%--<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>--%>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    <link href="../img/mycss.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 234px;
        }
    </style>
    <script src="ueditor/ueditor.config.js" type="text/javascript"></script>
    <script src="ueditor/ueditor.all.min.js" type="text/javascript"></script>
    <link href="ueditor/themes/default/css/ueditor.css" rel="stylesheet" type="text/css" />
</head>
<body bgcolor="#DEDDDD" text="#333333" link="#333333" vlink="#333333" alink="#333333" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
   <table width="98%"  border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#3A76AF">
  <tr> 
    <td height="28"> <span class="style12"><font color="#FFFFFF">&nbsp;→ 欢迎您的网站</font></span><font color="#FFFFFF"><span class="style12">后台管理系统</span></font></td>
    <td align="left"> <strong><span class="C02"><font color="#FFFFFF"></font></span></strong></td>
  </tr>
</table>
<br>
<hr align="center" width="98%" size="1" noshade>
<table width="98%"  border="0" align="center" cellpadding="4" cellspacing="1" bgcolor="#3A76AF">
  <tr> 
    <td height="23" colspan="2"><div align="center" class="style3"><font color="#FFFFFF"><strong>工程案例</strong></font></div></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"><div align="right">类别：</div></td>
    <td width="75%" height="25">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
      </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"><div align="right">分类：</div></td>
    <td width="75%" height="25">
        <asp:DropDownList ID="DropDownList1" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="classname" DataValueField="id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="SELECT * FROM [gsclass] WHERE ([classid] = ?)">
            <SelectParameters>
                <asp:QueryStringParameter Name="classid" QueryStringField="id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
      </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"><div align="right">标题：</div></td>
    <td width="75%" height="25"></a>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
      </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"><div align="right">内容：</div></td>
    <td height="25">
        <%--<CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
        <textarea id="myEditor" cols="200" rows="8" name="myEditor" runat="server"></textarea>
    </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"><div align="right">图片：</div></td>
    <td height="25">
        <asp:TextBox ID="txtpic" runat="server" Width="130px">Uploads/nopic-2.gif</asp:TextBox>
        <input id="file1" runat="server" class="inputBox" type="file" /><asp:Button 
            ID="Button1" runat="server" CssClass="formbutton" Height="27px" 
            OnClick="Button1_Click" Text="上传文章图片" Width="115px" />
        <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
               </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"><div align="right">发布人：</div></td>
    <td height="25">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1">&nbsp;</td>
    <td height="25">
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="· 提交 ·" 
            Width="70px" />
      </td>
  </tr>
  </table>
    </form>
    <script type="text/javascript">
        var ue = new baidu.editor.ui.Editor();
        ue.render("myEditor");   //这里填写要改变为编辑器的控件id
    </script>
</body>
</html>
