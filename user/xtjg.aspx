﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xtjg.aspx.cs" Inherits="user_xtjg" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <td height="23" colspan="2"><div align="center" class="style3"><font color="#FFFFFF"><strong>
        信托结构</strong></font></div></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"><div align="right">产品名称：</div></td>
    <td width="75%" height="25"></a>
        <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="cpmc" DataValueField="id" >
        </asp:DropDownList>
      
        <asp:Button ID="Button1" runat="server" Text="查询" onclick="Button1_Click" />
      </td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"><div align="right">内容：</div></td>
    <td height="25">
        <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1">&nbsp;</td>
    <td height="25">
        <asp:Button ID="btnAdd" runat="server"  Text="提交" 
            Width="70px" onclick="btnAdd_Click" />
      </td>
  </tr>
  </table>
    </form>
</body>
</html>
