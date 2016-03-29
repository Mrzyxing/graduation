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

public partial class admin_UserControls_session : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["pcrepair"] != null)
        {
            string temp = Convert.ToString(Request.Cookies["pcrepair"].Values["UserAccount"]);     //读全部就用Request.Cookies["pcrepair"].Value)
            string level = Convert.ToString(Request.Cookies["pcrepair"].Values["UserLevel"]); 
            if (temp == null || temp == "")
            {
                Response.Write("您还没有登陆！<a href=\"..\\Default.aspx\">点击此处登陆</a>");
                Response.End();
            }
            else if (!level.Equals("0"))//管理员特殊权限限制
            {
                Response.Write(" 您的账号没有此权限！<a href=\"..\\Default.aspx\">点击此处登陆</a>");
                Response.End();
            }
        }
        else
        {
            Response.Write("您还没有登陆！<a href=\"..\\Default.aspx\">点击此处登陆</a>");
            Response.End();
        }
    }
}
