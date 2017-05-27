<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditWeixinXuexi.aspx.cs" Inherits="user_AuditWeixinXuexi" %>

<%@ Register Assembly="BLLDALMod" Namespace="BLLDALMod.Comm.UI" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title></title>
    <link href="../img/mycss.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 50px;
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
    <td height="23" colspan="2"><div align="center" class="style3"><font color="#FFFFFF"><strong>留言管理</strong></font></div></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td class="style1" colspan="2">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True" DataKeyNames="id" Width="100%">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" 
                            oncheckedchanged="CheckBox2_CheckedChanged" Text="全选" 
                            AutoPostBack="True" />
                    </HeaderTemplate>
                </asp:TemplateField>
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
        <cc1:ctrlPage ID="ctrlPage" PageSize="5" OnPageGo="AspNetPager1_PageChanged"  OnIndexNumberChanged ="AspNetPager1_PageChanged"
             OnIndexChanged="AspNetPager1_PageChanged" runat="server" IsShowLoading="true"></cc1:ctrlPage>
        
      </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="审核选中" />
        <asp:Button ID="Button2" runat="server" onclick="Del_Click" Text="删除选中" />
      </td>
    <td height="25">
        &nbsp;</td>
  </tr>
  </table>
    </form>
</body>
</html>
