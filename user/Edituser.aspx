<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edituser.aspx.cs" Inherits="user_Edituser" %>
<%--<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>--%>
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
    <td height="23" colspan="2"><div align="center" class="style3"><font color="#FFFFFF"><strong>用户账号管理</strong></font></div></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td width="25%" height="25" colspan="2">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Width="565px">
            <Columns>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </EditItemTemplate>
                    <HeaderTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" 
                            oncheckedchanged="CheckBox2_CheckedChanged" Text="全选" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="username" HeaderText="用户名" />
                <asp:BoundField DataField="userpass" HeaderText="密码" />
                <asp:TemplateField Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <%--<webdiyer:aspnetpager ID="AspNetPager1" runat="server" CssClass="formfield" 
            CustomInfoClass="formbutton" 
            CustomInfoHTML="第&lt;font color='red'&gt;&lt;b&gt;%CurrentPageIndex%&lt;/b&gt;&lt;/font&gt;页 共%PageCount%&nbsp;页 %StartRecordIndex%-%EndRecordIndex%" 
            CustomInfoTextAlign="Center" FirstPageText="首页" horizontalalign="Center" 
            InputBoxStyle="width:19px" LastPageText="尾页" meta:resourceKey="AspNetPager1" 
            NextPageText="下一页" onpagechanged="AspNetPager1_PageChanged" PageSize="3" 
            PrevPageText="前一页" showcustominfosection="Left" ShowInputBox="Always" 
            ShowNavigationToolTip="True" style="FONT-SIZE: 14px" 
            SubmitButtonClass="formfield" SubmitButtonText="GO" width="506px">
        </webdiyer:aspnetpager>--%>
      </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td width="25%" height="25" colspan="2">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="删除" 
            Width="64px" />
      </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"><div align="right">添加用户</div></td>
    <td width="75%" height="25">&nbsp;</td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"><div align="right">用户名：</div></td>
    <td width="75%" height="25"></a>
        <asp:TextBox ID="txtadmin" runat="server" Width="200px"></asp:TextBox>
      </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"><div align="right">密码：</div></td>
    <td height="25">
        <asp:TextBox ID="txtpass" runat="server" Width="200px"></asp:TextBox>
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
</body>
</html>
