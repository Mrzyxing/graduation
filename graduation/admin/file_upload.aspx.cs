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

public partial class admin_file_upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
        ht.Add("UserAccount", SqlStringConstructor.GetQuotedString(Convert.ToString(Request.Cookies["pcrepair"].Values["UserAccount"])));
        ht.Add("Contactor", SqlStringConstructor.GetQuotedString(HttpUtility.UrlDecode(Convert.ToString(Request.Cookies["pcrepair"].Values["Contactor"]))));
        ht.Add("FileContent", SqlStringConstructor.GetQuotedString(FileContent.Text));

        //附件名,以当前时间为文件名前缀,确保文件名没有重复
        string affixFileName = InputAffixFile.FileName.Trim();
        int ShowFileSize = Convert.ToInt32(InputAffixFile.PostedFile.ContentLength.ToString())/1024;
        string ShowFileType = affixFileName.Substring(affixFileName.LastIndexOf(".") + 1).ToLower();
        int idx = affixFileName.LastIndexOf('\\');
        affixFileName = affixFileName.Substring(idx + 1);
        string fileName = "";
        if (affixFileName != "")
        {
            if (ShowFileType == "jpg" || ShowFileType == "swf" || ShowFileType == "gif " || ShowFileType == "bmp " || ShowFileType == "png " || ShowFileType == "xls" || ShowFileType == "doc" || ShowFileType == "pdf" || ShowFileType == "rar" || ShowFileType == "zip" || ShowFileType == "txt")
            {
                //Ticks属性的值为自 0001 年 1 月 1 日午夜 12:00 以来所经过时间以 100 毫微秒为间隔表示时的数字。
                //fileName = System.DateTime.Now.Ticks.ToString() + affixFileName;
                //fileName = affixFileName;
                fileName = System.DateTime.Now.Ticks.ToString() + "." + ShowFileType;
                ht.Add("UpFileName", SqlStringConstructor.GetQuotedString(fileName));
                ht.Add("FileSize", SqlStringConstructor.GetQuotedString(Convert.ToString(ShowFileSize)));
                ht.Add("FileType", SqlStringConstructor.GetQuotedString(ShowFileType));

                InputAffixFile.PostedFile.SaveAs(Server.MapPath("~//upfile//affix//") + fileName);


                FileList filelist = new FileList();
                filelist.Add(ht);

                Response.Redirect("file_upload_prs.aspx");
            }
            else
            {
                Response.Write("<Script Language=JavaScript>alert(\"该文件不允许上传！\")</Script>");
            }
        }
        else
        {
            Response.Write("<Script Language=JavaScript>alert(\"请选择上传文件！\")</Script>");
        }

    }
}
