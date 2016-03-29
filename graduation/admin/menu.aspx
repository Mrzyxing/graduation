<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu.aspx.cs" Inherits="admin_menu" %>
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
				管理员：<asp:Label runat="server" ID="UserAccount" /><br>
				<br>
				<a href="javascript: d.openAll();">打开树菜单</a> | <a href="javascript: d.closeAll();">关闭树菜单</a><br>
				<script type="text/javascript">
		<!--

		d = new dTree('d');

		d.add(0,-1,'后台管理菜单');
		//d.add(1,0,'修改密码','modify_password.aspx','修改我的登陆密码','right');
		d.add(30,0,'下载管理');
		d.add(31,30,'文件上传','file_upload.aspx','文件上传','right');
		d.add(32,30,'管理上传文件','manage_upload_file.aspx','管理上传文件','right');	
		d.add(33,30,'下载历史记录','download_history.aspx','下载历史记录','right');	
		d.add(60,0,'用户管理')
		d.add(61,60,'增加新用户','add_new_user.aspx','增加新用户','right');
		d.add(62,60,'管理用户','manage_user.aspx','管理用户','right');
		d.add(80,0,'个人设置')
		d.add(81,80,'修改我的密码','modify_profile.aspx','修改我的密码','right');
		d.add(100,0,'退出管理','login_out.aspx','退出管理','_parent');

		document.write(d);

		//-->
				</script>
			</div>
    </form>
</body>
</html>
