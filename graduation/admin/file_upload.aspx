<%@ Page Language="C#" AutoEventWireup="true" CodeFile="file_upload.aspx.cs" Inherits="admin_file_upload" %>
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
					<td height="30" class="title_top" align="center">上传文件</td>
				</tr>
			</table>
			<TABLE cellSpacing="1" cellPadding="3" width="96%" align="center" bgColor="#77aeee" border="0">
                <tr>
                    <th align="right" bgcolor="#dfefff" width="140" style="height:25px">选取要上传的文件：</th>
                     
                    <td bgcolor="#ffffff"><asp:FileUpload ID="InputAffixFile" runat="server" />
                    
                    </td>
                </tr>
                 <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:3px;" valign="top">对上传文件的说明：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="FileContent" runat="server" Columns="45" Rows="6" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" style="height:30px"></th>
                    <td bgcolor="#ffffff">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确认上传" /></td>
                </tr>
              </TABLE>
    </form>
</body>
</html>
