<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu.aspx.cs" Inherits="user_menu" %>
<%@ Register TagPrefix="WebSession" TagName="CheckSession" Src="UserControls/session.ascx"  %>
<WebSession:CheckSession id="CheckSession" runat="server"></WebSession:CheckSession>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/dtree.css" rel="stylesheet" type="text/css" />
	<script language="javascript" src="../js/admin/dtree.js"></script>
</head>
<body>
    <form id="form1" runat="server">
		<div class="dtree">
				报修用户：<asp:Label runat="server" ID="UserAccount" /><br>
				<br>
				<a href="javascript: d.openAll();">打开树菜单</a> | <a href="javascript: d.closeAll();">关闭树菜单</a><br>
				<script type="text/javascript">
		<!--

		d = new dTree('d');

		d.add(0,-1,'后台管理菜单');
		//d.add(1,0,'修改密码','modify_password.aspx','修改我的登陆密码','right');
		d.add(30,0,'文件下载');
		d.add(31,30,'文件下载','file_download.aspx','文件下载','right');
		d.add(80,0,'个人信息')
		d.add(81,80,'修改我的资料','modify_profile.aspx','修改我的资料','right');
		d.add(82,80,'查看本机IP','view_local_ip.aspx','查看本机IP','right');
		d.add(100,0,'退出管理','login_out.aspx','退出管理','_parent');

		document.write(d);

		//-->
				</script>
			</div>
    </form>
</body>
</html>
