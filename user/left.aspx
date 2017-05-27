<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="user_left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <style type="text/css">
<!--
       BODY
       {	scrollbar-face-color: #45ACE5;
		        scrollbar-shadow-color: #3773C1;
		        scrollbar-highlight-color: #90D0F0;
		        scrollbar-3dlight-color: #45ACE5;
		        scrollbar-darkshadow-color: #EDEDED;
		        scrollbar-track-color: #EDEDED;
		        scrollbar-arrow-color: #FFFFFF;		
	   }
       .style1
       {
           border: 1px solid #f1f1f1;
           padding: 0px 6px;
           BACKGROUND: #f1f1f1;
           CURSOR: hand;
           width: 285px;
       }
       .style2
       {
           text-align: center;
       }
       -->
</style>
<link href="../img/mycss.css" rel="stylesheet" type="text/css">
<link href="../img/Site_Css.css" rel="stylesheet" type="text/css">
</head>
<body bgcolor="#FFFFFF" background="img/le_di.gif" text="#333333" link="#333333" vlink="#333333" alink="#333333" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <table width="174"  border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF">
  <tr>
    <td height="23" bgcolor="#DEDDDD" class="style2"><strong>网站后台管理</strong></td>
  </tr>
  <tr> 
    <td height="23" bgcolor="#3A76AF" align="center"> <strong><font color="#FFFFFF">网站管理</font></strong></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" bgcolor="#DEDDDD"> <div align="center"> 
        <table width="100%" border="0" cellspacing="4" cellpadding="0">        
              <tr> 
                 <td class=style1 onmouseleave="javascript:this.className='lt0';" 
                     onclick="javascript:top.main.location.href='message.aspx'" 
                     onmouseenter="javascript:this.className='lt1';" ><span class="x">联系我们</span></td>
              </tr>
        </table>
      </div></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" align="center" bgcolor="#3A76AF"><strong><font color="#FFFFFF">关于我们</font></strong></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" align="center" bgcolor="#DEDDDD"><table width="100%" border="0" cellspacing="4" cellpadding="0">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                     <td class=style1 onmouseleave="javascript:this.className='lt0';" 
                         onclick="javascript:top.main.location.href='aboutAdd.aspx?id=<%#Eval("id") %>'" 
                         onmouseenter="javascript:this.className='lt1';" ><span class="x"> <%#Eval("classname") %></span></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        </table></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" align="center" bgcolor="#3A76AF"><strong><font color="#FFFFFF">新闻动态</font></strong></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" align="center" bgcolor="#DEDDDD"><table width="100%" border="0" cellspacing="4" cellpadding="0">
        <tr> 
           <td class=style1 onmouseleave="javascript:this.className='lt0';" 
               onclick="javascript:top.main.location.href='newsclass.aspx'" 
               onmouseenter="javascript:this.className='lt1';" ><span class="x">新闻类别管理</span></td>
        </tr>
       <tr> 
            <td class=style1 onmouseleave="javascript:this.className='lt0';" 
                onclick="javascript:top.main.location.href='newscontent.aspx'" 
                onmouseenter="javascript:this.className='lt1';" ><span class="x">新闻管理</span></td>
        </tr>
         
      </table></td>
  </tr>
   <tr bgcolor="#FFFFFF"> 
    <td height="25" align="center" bgcolor="#3A76AF"><strong><font color="#FFFFFF">旗下产品</font></strong></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td align="center" bgcolor="#DEDDDD"><table width="100%" border="0" cellspacing="4" cellpadding="0">
           <tr> 
               <td class=style1 onmouseleave="javascript:this.className='lt0';" 
                   onclick="javascript:top.main.location.href='RegisterWeixinWanJu.aspx'" 
                   onmouseenter="javascript:this.className='lt1';" ><span class="x">微信注册玩具用户</span></td>
            </tr> 
            <tr> 
               <td class=style1 onmouseleave="javascript:this.className='lt0';" 
                   onclick="javascript:top.main.location.href='AuditWeixinWanJu.aspx'" 
                   onmouseenter="javascript:this.className='lt1';" ><span class="x">审批玩具</span></td>
            </tr> 
            <tr> 
               <td class=style1 onmouseleave="javascript:this.className='lt0';" 
                   onclick="javascript:top.main.location.href='AuditWeixinXuexi.aspx'" 
                   onmouseenter="javascript:this.className='lt1';" ><span class="x">审批学习资料</span></td>
            </tr>
          </table></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" align="center" bgcolor="#3A76AF"><strong><font color="#FFFFFF">核心团队</font></strong></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td align="center" bgcolor="#DEDDDD"><table width="100%" border="0" cellspacing="4" cellpadding="0">
        <asp:Repeater ID="Repeater2" runat="server">
            <ItemTemplate>
                <tr> 
                   <td class=style1 onmouseleave="javascript:this.className='lt0';" 
                       onclick="javascript:top.main.location.href='Addgongcheng.aspx?id=<%#Eval("id") %>'" 
                       onmouseenter="javascript:this.className='lt1';" ><span class="x"><%#Eval("classname") %></span></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
      </table></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" align="center" bgcolor="#3A76AF"><strong><font color="#FFFFFF">留言管理</font></strong></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td align="center" bgcolor="#DEDDDD"><table width="100%" border="0" cellspacing="4" cellpadding="0">
        <tr> 
           <td class=style1 onmouseleave="javascript:this.className='lt0';" 
               onclick="javascript:top.main.location.href='book.aspx'" 
               onmouseenter="javascript:this.className='lt1';" ><span class="x">留言信息</span></td>
        </tr>
      </table></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" align="center" bgcolor="#3A76AF"><strong><font color="#FFFFFF">管理员管理</font></strong></td>
  </tr>
  <tr bgcolor="#FFFFFF"> 
    <td height="25" align="center" bgcolor="#DEDDDD"><table width="100%" border="0" cellspacing="4" cellpadding="0">
        <tr> 
         <td class=style1 onmouseleave="javascript:this.className='lt0';" 
             onclick="javascript:top.main.location.href='Edituser.aspx'" 
             onmouseenter="javascript:this.className='lt1';" ><span class="x">管理员管理</span></td>
        </tr>
        <tr> 
          <td align="center"><span class="x"><font color="#FF3300">
              <asp:LinkButton ID="LinkButton1" runat="server" Text="安全退出系统" 
                  onclick="LinkButton1_Click"></asp:LinkButton></font></span></a></td>
        </tr>
      </table></td>
  </tr>
  </table>
    </form>
</body>
</html>
