<%@ Page Language="C#" AutoEventWireup="true" CodeFile="modify_profile.aspx.cs" Inherits="user_modify_profile" %>
<%@ Register TagPrefix="WebSession" TagName="CheckSession" Src="UserControls/session.ascx"  %>
<WebSession:CheckSession id="CheckSession" runat="server"></WebSession:CheckSession>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
  <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td height="7"></td>
				</tr>
			</table>
			<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td height="30" class="title_top" align="center">修改我的资料</td>
				</tr>
			</table>
<TABLE cellSpacing="1" cellPadding="3" width="96%" align="center" bgColor="#77aeee" border="0">
   <tr>
    <th style="width:120px;height:30px; background-color:#dfefff;" align="right">用户名：</th>
    <td bgcolor="#ffffff">
        <asp:Label ID="ShowUserAccount" runat="server"></asp:Label></td>
  </tr>
  <tr>
    <th style="height:30px;background-color:#dfefff;" align="right">密码：</th>
    <td bgcolor="#ffffff"><asp:TextBox ID="UserPassword" runat="server" Columns="35" MaxLength="20"></asp:TextBox>
        <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="UserPassword"
            Display="Dynamic" ErrorMessage="请输入密码"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ControlToValidate="UserPassword" Display="Dynamic" ValidationExpression="[a-zA-Z0-9_]{4,20}"
							ErrorMessage="密码输入错误。密码长度为4-20位，可使用的字符为（A-Z a-z 0-9 ）以及下划线“_”，注意不要使用空格。" ID="Regularexpressionvalidator2" />
            </td>
  </tr>
  <tr>
    <th style="height:30px;background-color:#dfefff;" align="right">部门名称：</th>
    <td bgcolor="#ffffff"><asp:TextBox ID="DepartmentName" runat="server" Columns="35" MaxLength="200"></asp:TextBox>
        <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DepartmentName"
            Display="Dynamic" ErrorMessage="请输入部门名称"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <th style="height:30px;background-color:#dfefff;" align="right">联系人：</th>
    <td bgcolor="#ffffff"><asp:TextBox ID="Contactor" runat="server" Columns="35" MaxLength="30"></asp:TextBox>
        <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Contactor"
            Display="Dynamic" ErrorMessage="请输入联系人"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <th style="height:30px;background-color:#dfefff;" align="right">联系电话：</th>
    <td bgcolor="#ffffff"><asp:TextBox ID="Tel" runat="server" Columns="35" MaxLength="50"></asp:TextBox>
        <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Tel"
            Display="Dynamic" ErrorMessage="请输入联系电话"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <th style="height:30px;background-color:#dfefff;" align="right">E-mail：</th>
    <td bgcolor="#ffffff"><asp:TextBox ID="Email" runat="server" Columns="35" MaxLength="50"></asp:TextBox>
        <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Email"
            Display="Dynamic" ErrorMessage="E-mail地址格式不正确" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
  </tr>
  <tr>
    <th style="height:30px;background-color:#dfefff;" align="right">联系地址：</th>
    <td bgcolor="#ffffff"><asp:TextBox ID="Address" runat="server" Columns="35" MaxLength="200"></asp:TextBox>
        <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Address"
            Display="Dynamic" ErrorMessage="请输入联系地址"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <th style="height:30px;background-color:#dfefff;" align="right">&nbsp;</th>
    <td bgcolor="#ffffff">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确认修改" />　<input id="Reset1" type="reset" value="恢复默认" /></td>
  </tr>
</table>
    </form>
</body>
</html>
