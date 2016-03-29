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

public partial class user_menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["pcrepair"] != null)
        {
            string temp = Convert.ToString(Request.Cookies["pcrepair"].Values["UserAccount"]);     //读全部就用Request.Cookies["pcrepair"].Value)
            string level = Convert.ToString(Request.Cookies["pcrepair"].Values["UserLevel"]);
            if (temp == "" )
            {
                //左边菜单不应该有输出
                Response.End();
            }
            else
            {
                this.UserAccount.Text = HttpUtility.UrlDecode(Convert.ToString(Request.Cookies["pcrepair"].Values["Contactor"])) + "(" + temp + ")";
            }
        }
        else
        {
            //左边菜单不应该有输出
            Response.End();
        }
    }
}
