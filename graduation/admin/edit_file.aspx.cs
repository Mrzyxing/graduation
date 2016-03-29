using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using ComputerRepair.BusinessLogicLayer;
using ComputerRepair.DataAccessHelper;
using ComputerRepair.CommonComponent;

public partial class admin_edit_file : System.Web.UI.Page
{
    public string Action;

    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);

        switch (Action)
        {
            case "DelFile":
                DelFile();
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// 更新一条数据，设为可用
    /// </summary>
    private void DelFile()
    {
        int fileListID = Convert.ToInt32(Request.QueryString["FileListID"]);
        FileList filelist = new FileList();

        filelist.LoadData(fileListID);
        filelist.Delete();

        Response.Redirect(Request.UrlReferrer.ToString());
    }


}
