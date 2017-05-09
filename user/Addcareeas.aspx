<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Addcareeas.aspx.cs" Inherits="user_Addcareeas" %>
<%--<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../img/mycss.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {            text-align: left;
        }
        .style2
        {
            width: 168px;
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
<table width="100%"  border="0" align="center" cellpadding="4" cellspacing="1" bgcolor="#3A76AF">
  <tr> 
    <td height="23" colspan="2"><div align="center" class="style3"><font color="#FFFFFF"><strong>旗下产品</strong></font></div></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1" colspan="2"> 
      
         
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True"   
            AutoGenerateColumns="False" 
            Width="100%" CellPadding="4" EnableModelValidation="True" 
            ForeColor="#333333" GridLines="None" HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
          

                <asp:BoundField DataField="cpmc" HeaderText="产品名称" 
                    SortExpression="cpmc" />
                <asp:BoundField DataField="jjjl" HeaderText="基金经理" 
                    SortExpression="jjjl" />
                <asp:BoundField DataField="clrq" HeaderText="成立日期" 
                    SortExpression="clrq" />
                <asp:BoundField DataField="gxrq" HeaderText="更新日期" 
                    SortExpression="gxrq" />
                <asp:BoundField DataField="jnzzl" HeaderText="今年增长率" SortExpression="jnzzl" />
                <asp:BoundField DataField="jz" HeaderText="净值1" SortExpression="jz" />
                <asp:BoundField DataField="jz1" HeaderText="净值2" SortExpression="jz1" />
                <asp:BoundField DataField="ljzzl" HeaderText="累计增长率1" SortExpression="ljzzl" />
                <asp:BoundField DataField="ljzzl1" HeaderText="累计增长率2" SortExpression="ljzzl1" />
               <asp:BoundField DataField="bz" HeaderText="备注" SortExpression="jz" /> 
        
           <asp:BoundField DataField="xtmc" HeaderText="信托名称" 
                    SortExpression="xtmc" />
                <asp:BoundField DataField="xtlx" HeaderText="信托类型" 
                    SortExpression="xtlx" />
                <asp:BoundField DataField="xtjg" HeaderText="信托监管机构" 
                    SortExpression="xtjg" />
                <asp:BoundField DataField="str" HeaderText="受托人" 
                    SortExpression="str" />
                <asp:BoundField DataField="xtyh" HeaderText="信托保管银行" SortExpression="xtyh" />
                <asp:BoundField DataField="xtzh" HeaderText="信托认购帐户" SortExpression="xtzh" />
                <asp:BoundField DataField="zqjjs" HeaderText="证券经纪商" SortExpression="zqjjs" />
                <asp:BoundField DataField="tzgw" HeaderText="投资顾问" SortExpression="tzgw" />
                <asp:BoundField DataField="xtkh" HeaderText="信托客户对象" SortExpression="xtkh" />
               <asp:BoundField DataField="rgje" HeaderText="最低认购金额" SortExpression="rgje" /> 
               <asp:BoundField DataField="rgfl" HeaderText="最低费率" SortExpression="rgfl" /> 

                  <asp:BoundField DataField="fbq" HeaderText="资金封闭期" 
                    SortExpression="fbq" />
                <asp:BoundField DataField="kfq" HeaderText="开放日" 
                    SortExpression="kfq" />
                <asp:BoundField DataField="zjje" HeaderText="最低追加金额" 
                    SortExpression="zjje" />
                <asp:BoundField DataField="glfl" HeaderText="管理费率" 
                    SortExpression="glfl" />
                <asp:BoundField DataField="shfl" HeaderText="赎回费率" SortExpression="shfl" />
                <asp:BoundField DataField="fdglfl" HeaderText="浮动管理费率" SortExpression="fdglfl" />
                <asp:BoundField DataField="wddm" HeaderText="万德代码" SortExpression="wddm" />
                <asp:BoundField DataField="pbdm" HeaderText="彭博代码" SortExpression="pbdm" />
           

                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:TemplateField HeaderText="id" InsertVisible="False" SortExpression="id" 
                    Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" VerticalAlign="Middle" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>        
       
      </td>
  </tr>

  
  </table>
  <table width="100%"  align="center"  >
    <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"> 产品名称： </td>
    <td height="25" class="style2">
        <asp:TextBox ID="cpmctxt" runat="server"></asp:TextBox></td>
      <td height="25" class="style1"> 信托名称： </td>
    <td height="25">
        <asp:TextBox ID="xtmctxt" runat="server"></asp:TextBox></td>
            <td height="25" class="style1"> 最低认购金额： </td>
    <td height="25">
        <asp:TextBox ID="rgjgtxt" runat="server"></asp:TextBox></td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr>
    <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"> 基金经理： </td>
    <td height="25" class="style2">
        <asp:TextBox ID="jjjltxt" runat="server"></asp:TextBox></td>
        <td height="25" class="style1"> 信托类型： </td>
    <td height="25">
        <asp:TextBox ID="xtlxtxt" runat="server"></asp:TextBox></td>
            <td height="25" class="style1"> 认购费率： </td>
    <td height="25">
        <asp:TextBox ID="rgfltxt" runat="server"></asp:TextBox></td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr>
   <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"> 成立日期： </td>
    <td height="25" class="style2">
        <asp:TextBox ID="clrqtxt" runat="server"></asp:TextBox></td>
       <td height="25" class="style1"> 信托监管机构： </td>
    <td height="25">
        <asp:TextBox ID="xtjg" runat="server"></asp:TextBox></td>
         <td height="25" class="style1"> 资金封闭期： </td>
    <td height="25">
        <asp:TextBox ID="fbq" runat="server"></asp:TextBox></td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr>
    <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"> 更新日期： </td>
    <td height="25" class="style2">
        <asp:TextBox ID="gxrqtxt" runat="server"></asp:TextBox></td>
        <td height="25" class="style1"> 受托人： </td>
    <td height="25">
        <asp:TextBox ID="str" runat="server"></asp:TextBox></td>
            <td height="25" class="style1"> 开放日： </td>
    <td height="25">
        <asp:TextBox ID="kfr" runat="server"></asp:TextBox></td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr>
     <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"> 今年增长率： </td>
    <td height="25" class="style2">
        <asp:TextBox ID="jnzzltxt" runat="server"></asp:TextBox></td>
      <td height="25" class="style1"> 信托保管银行： </td>
    <td height="25">
        <asp:TextBox ID="xtyh" runat="server"></asp:TextBox></td>
            <td height="25" class="style1"> 最低追加金额： </td>
    <td height="25">
        <asp:TextBox ID="zjje" runat="server"></asp:TextBox></td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr>
    <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"> 净值1： </td>
    <td height="25" class="style2">
        <asp:TextBox ID="jztxt1" runat="server"></asp:TextBox></td>
      <td height="25" class="style1"> 信托认购帐户： </td>
    <td height="25">
        <asp:TextBox ID="xtzh" runat="server"></asp:TextBox></td>
            <td height="25" class="style1"> 管理费率： </td>
    <td height="25">
        <asp:TextBox ID="glfl" runat="server"></asp:TextBox></td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr>
    <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"> 净值2： </td>
    <td height="25" class="style2">
        <asp:TextBox ID="jztxt2" runat="server"></asp:TextBox></td>
         <td height="25" class="style1"> 证券经纪商： </td>
       <td height="25">
        <asp:TextBox ID="zqjjs" runat="server"></asp:TextBox></td>
            <td height="25" class="style1"> 赎回费率： </td>
    <td height="25">
        <asp:TextBox ID="shfl" runat="server"></asp:TextBox></td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr>
    <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"> 累计增长率1： </td>
    <td height="25" class="style2">
        <asp:TextBox ID="ljzzltxt1" runat="server"></asp:TextBox></td>
      <td height="25" class="style1"> 投资顾问： </td>
    <td height="25">
        <asp:TextBox ID="tzgw" runat="server"></asp:TextBox></td>
            <td height="25" class="style1"> 浮动管理费率： </td>
    <td height="25">
        <asp:TextBox ID="fdglfl" runat="server"></asp:TextBox></td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr>
    <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"> 累计增长率2： </td>
    <td height="25" class="style2">
        <asp:TextBox ID="ljzzltxt2" runat="server"></asp:TextBox></td>
       <td height="25" class="style1"> 信托客户对象： </td>
    <td height="25">
        <asp:TextBox ID="xtkh" runat="server"></asp:TextBox></td>
            <td height="25" class="style1"> 万德代码： </td>
    <td height="25">
        <asp:TextBox ID="wddm" runat="server"></asp:TextBox></td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr>
    <tr bgcolor="#FFFFFF"> 
    <td height="25" class="style1"> 备注： </td>
    <td height="25" class="style2">
        <asp:TextBox ID="bztxt" runat="server" Height="58px" TextMode="MultiLine" 
            Width="287px"></asp:TextBox></td>
       <td height="25" class="style1"> 彭博代码：</td>
    <td height="25">
        <asp:TextBox ID="pbdm" runat="server"></asp:TextBox></td>
                <td height="25" class="style1"> &nbsp;<asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="提交" 
            Width="70px" />
        </td>
    <td height="25">
        &nbsp;</td>
     <%--   <CE:Editor id="WE_NewsContent" runat="server" AutoConfigure="Simple" 
                    BreakElement="Br" Width="580px" ></CE:Editor>--%>
  </tr> 
  
  </table>
    </form>
</body>
</html>
