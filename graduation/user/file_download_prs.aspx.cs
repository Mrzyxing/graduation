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
using System.IO;

using ComputerRepair.BusinessLogicLayer;
using ComputerRepair.DataAccessHelper;
using ComputerRepair.CommonComponent;

public partial class user_file_download_prs : System.Web.UI.Page
{
    public string filePath, showFilePath;
    public int fileListID;

    protected void Page_Load(object sender, EventArgs e)
    {
        filePath = Convert.ToString(Request.QueryString["FilePath"]);
        fileListID = Convert.ToInt32(Request.QueryString["FileListID"]);

        if (!IsPostBack)
        {
            AddDownloadHistory();
            UpdateDownloadTimes();
        }

        Response.Redirect(filePath);
    }

    /// <summary>
    /// 增加下载历史记录
    /// </summary>
    private void AddDownloadHistory()
    {

        showFilePath = Path.GetFileName(filePath);

        Hashtable ht = new Hashtable();
        ht.Add("FileListID",fileListID);
        ht.Add("UserAccount", SqlStringConstructor.GetQuotedString(Convert.ToString(Request.Cookies["pcrepair"].Values["UserAccount"])));
        ht.Add("Contactor", SqlStringConstructor.GetQuotedString(HttpUtility.UrlDecode(Convert.ToString(Request.Cookies["pcrepair"].Values["Contactor"]))));
        ht.Add("UpFileName", SqlStringConstructor.GetQuotedString(showFilePath));

        DownloadHistory downloadHistory = new DownloadHistory();
        downloadHistory.Add(ht);
    }

    /// <summary>
    /// 增加下载次数
    /// </summary>
    private void UpdateDownloadTimes()
    {
        FileList filelist = new FileList();
        filelist.FileListID = fileListID;

        Hashtable ht = new Hashtable();
        ht.Add("DownloadTimes", "DownloadTimes+1");

        filelist.Update(ht);
    }

}
