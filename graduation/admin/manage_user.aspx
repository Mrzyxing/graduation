<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage_user.aspx.cs" Inherits="admin_manage_user" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
					<td height="30" class="title_top" align="center">管理用户</td>
				</tr>
			</table>
<table width="96%" border="1" align="center" cellpadding="0" cellspacing="0" bgcolor="#DFEFFF" bordercolorlight="#77AEEE">
    <tr>
	<td height="32" style="padding-left:8px;">
        <asp:TextBox ID="Keywords" runat="server" Columns="30"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text=" 搜 索 " OnClick="Button1_Click" />&nbsp;<span class="gray">请输入用户名或联系人或联系电话</span></td>
    </tr>
</table>
			<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td>
					<asp:GridView ID="GridView1" runat="server" Width="100%"  DataKeyNames ="UserListID" CellPadding ="4" AutoGenerateColumns="False" BackColor="#77aeee" BorderColor="#77aeee" BorderStyle="Solid" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                              <asp:BoundField DataField="UserListID" HeaderText="用户ID" ></asp:BoundField>
                               <asp:BoundField DataField="UserAccount" HeaderText="用户名" ></asp:BoundField>
                                <asp:BoundField DataField="UserPassword" HeaderText="密码" ></asp:BoundField>
                               <asp:BoundField DataField="DepartmentName" HeaderText="部门名称" ></asp:BoundField>
                               <asp:BoundField DataField="Contactor" HeaderText="联系人" ></asp:BoundField>
                                <asp:BoundField DataField="Tel" HeaderText="联系电话" ></asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="E-mail" ></asp:BoundField>
                                <asp:BoundField DataField="Address" HeaderText="联系地址" ></asp:BoundField>
                                <asp:TemplateField HeaderText="级别">
                                    <ItemTemplate><asp:Label ID="lblUserLevel" runat="server" Text='<%# Bind("UserLevel") %>'></asp:Label></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态">
                                    <ItemTemplate><asp:Label ID="lblIsAllowed" runat="server" Text='<%# Bind("IsAllowed") %>'></asp:Label></ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="编辑">
                                <ItemTemplate>
										<a href='edit_user.aspx?Action=Allowed&UserListID=<%#Eval("UserListID")%>' >可用</a>
										<a href='edit_user.aspx?Action=NoAllowed&UserListID=<%#Eval("UserListID")%>' >禁用</a>
								</ItemTemplate></asp:TemplateField>
                            </Columns>
                            <RowStyle HorizontalAlign="Center" BackColor="White" />
                            <HeaderStyle BackColor="#A5C8F0" Font-Size="13px" />                         
                        </asp:GridView>
					</td>
				</tr>
			</table>
			
			<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td style="height:26px;"><webdiyer:aspnetpager id="AspNetPager1" runat="server" horizontalalign="Center" onpagechanged="AspNetPager1_PageChanged"
        showcustominfosection="Left" width="100%" meta:resourceKey="AspNetPager1" style="font-size:14px" InputBoxStyle="width:19px"
        CustomInfoHTML="一共有<b><font color='red'>%RecordCount%</font></b>条记录 当前页<font color='red'><b>%CurrentPageIndex%/%PageCount%</b></font>   次序 %StartRecordIndex%-%EndRecordIndex%" AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="10" PrevPageText="上一页" CustomInfoStyle="FONT-SIZE: 12px"></webdiyer:aspnetpager></td>
				</tr>
			</table>
			<br /><br />	
    </form>
</body>
</html>
