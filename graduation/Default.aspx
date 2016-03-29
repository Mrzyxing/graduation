﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>文件上传下载系统</title>
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="center">

    <table border="0" cellspacing="7" cellpadding="0" class="bg_login">
        <tr>
          <td width="630" height="300" background="../images/admin/member_login.jpg">
          <!-- 管理员登陆  -->
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr valign="top">
              <td width="280"><img src="images/dqsy.jpg" alt="校徽"/></td>
              <td>
              <!-- 登陆标题 -->
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="20">&nbsp;</td>
                  <td class="font_bold">图书检索系统</td>
                </tr>
              </table>
              <br />
              <!-- 登陆标题 -->
              <!-- Login -->
              <table width="100%" border="0" cellspacing="1" cellpadding="3">
                   <tr>
                      <td width="60" align="right">用户名：</td>
                      <td><asp:TextBox ID="Account" runat="server" MaxLength="20"></asp:TextBox><br />
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Account"
                              ErrorMessage="请输入用户名" Display="Dynamic"></asp:RequiredFieldValidator>
                               <asp:RegularExpressionValidator runat="server" ControlToValidate="Account" Display="Dynamic" ValidationExpression="[a-zA-Z0-9]{4,20}"
							ErrorMessage="用户名输入错误。用户名长度为4-20位，可使用的字符为（A-Z a-z 0-9 ），注意不要使用空格。" ID="Regularexpressionvalidator1" />
                              </td>
                   </tr>
                   <tr>
                      <td align="right">密　码：</td>
                      <td><asp:TextBox ID="Password" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox><br />
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password"
                              Display="Dynamic" ErrorMessage="请输入密码"></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator runat="server" ControlToValidate="Password" Display="Dynamic" ValidationExpression="[a-zA-Z0-9_]{4,20}"
							ErrorMessage="密码输入错误。密码长度为4-20位，可使用的字符为（A-Z a-z 0-9 ）以及下划线“_”，注意不要使用空格。" ID="Regularexpressionvalidator2" /> 
                              </td>
                   </tr>
                   <tr>
                      <td align="right">&nbsp;</td>
                      <td><asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click" />　<input id="Reset1" type="reset" value="重填" /></td>
                   </tr>
              </table>
              <!-- Login -->
              <!-- 技术支持 -->
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="30" valign="top" style="height: 24px"><img src="images/admin/member_register.jpg"></td>
                    <td style="height: 24px"><span class="gray1">Copyright &copy; 2016&nbsp;<asp:Label ID="txtClientIP" runat="server"></asp:Label></span>
                        </td>
                  </tr>
               </table>
               <!-- 技术支持 -->
              </td>
            </tr>
          </table>
          <!-- 管理员登陆  -->
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>
    </form>
</body>
</html>