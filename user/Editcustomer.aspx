﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Editcustomer.aspx.cs" Inherits="user_Editcustomer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    <link href="../img/mycss.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
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
    <td height="23" colspan="2"><div align="center" class="style3"><font color="#FFFFFF"><strong>客服中心</strong></font></div></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1" colspan="2">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="100%">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="title" HeaderText="标题" SortExpression="title" />
                <asp:BoundField DataField="faburen" HeaderText="发布人" SortExpression="faburen" />
                <asp:BoundField DataField="time" HeaderText="发布时间" SortExpression="time" />
                <asp:HyperLinkField DataNavigateUrlFields="id" 
                    DataNavigateUrlFormatString="Addcustomer1.aspx?edgs={0}" Text="编辑" />
                <asp:TemplateField HeaderText="id" InsertVisible="False" SortExpression="id" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            DeleteCommand="DELETE FROM [gscontent] WHERE [id] = ?" 
            InsertCommand="INSERT INTO [gscontent] ([id], [title], [faburen], [time], [content], [hit], [keywords], [classid]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="SELECT * FROM [gscontent] WHERE ([classid] = ?)" 
            UpdateCommand="UPDATE [gscontent] SET [title] = ?, [faburen] = ?, [time] = ?, [content] = ?, [hit] = ?, [keywords] = ?, [classid] = ? WHERE [id] = ?">
            <SelectParameters>
                <asp:Parameter DefaultValue="24" Name="classid" Type="Int32" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="faburen" Type="String" />
                <asp:Parameter Name="time" Type="DateTime" />
                <asp:Parameter Name="content" Type="String" />
                <asp:Parameter Name="hit" Type="Int32" />
                <asp:Parameter Name="keywords" Type="String" />
                <asp:Parameter Name="classid" Type="Int32" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="id" Type="Int32" />
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="faburen" Type="String" />
                <asp:Parameter Name="time" Type="DateTime" />
                <asp:Parameter Name="content" Type="String" />
                <asp:Parameter Name="hit" Type="Int32" />
                <asp:Parameter Name="keywords" Type="String" />
                <asp:Parameter Name="classid" Type="Int32" />
            </InsertParameters>
        </asp:SqlDataSource>
      </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="删除选中" />
      </td>
    <td height="25">
        &nbsp;</td>
  </tr>
  </table>
    </form>
</body>
</html>
