﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Addabout1.aspx.cs" Inherits="user_Addabout1" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>
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
    <td height="23" colspan="2"><div align="center" class="style3"><font color="#FFFFFF"><strong>企业荣誉添加</strong></font></div></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"><div align="right">标题</div></td>
    <td width="75%" height="25"></a>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"><div align="right">类别：</div></td>
    <td width="75%" height="25">
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="9">企业资质</asp:ListItem>
            <asp:ListItem Value="10">企业荣誉</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"><div align="right">内容：</div></td>
    <td height="25">
        <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor></td>
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
    <td height="25" class="style1">&nbsp;</td>
    <td height="25">
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="· 提交 ·" 
            Width="70px" />
      </td>
  </tr>
  </table>
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
           ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
           DeleteCommand="DELETE FROM [gscontent] WHERE [id] = ?" 
           InsertCommand="INSERT INTO [gscontent] ([id], [title], [faburen], [time], [content], [hit], [keywords], [classid]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)" 
           ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
           SelectCommand="SELECT * FROM [gscontent] WHERE ([id] = ?)" 
           UpdateCommand="UPDATE [gscontent] SET [title] = ?, [content] = ?, [keywords] = ? WHERE [id] = ?">
           <SelectParameters>
               <asp:QueryStringParameter Name="id" QueryStringField="Editabout" Type="Int32" />
           </SelectParameters>
           <DeleteParameters>
               <asp:Parameter Name="id" Type="Int32" />
           </DeleteParameters>
           <UpdateParameters>
               <asp:ControlParameter ControlID="TextBox1" Name="title" PropertyName="Text" Type="String" />
               
               <asp:ControlParameter ControlID="WE_NewsContent" Name="content" PropertyName="Text" Type="String" />
               
               <asp:ControlParameter ControlID="txtpic" Name="keywords" PropertyName="Text" Type="String" />
               
              <asp:QueryStringParameter Name="id" QueryStringField="Editabout" Type="Int32" />
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
    </form>
</body>
</html>
