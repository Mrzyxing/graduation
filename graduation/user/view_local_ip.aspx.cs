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

public partial class user_view_local_ip : System.Web.UI.Page
{
    public string showUserIP;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.ServerVariables["HTTP_VIA"] != null)
            {
                showUserIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else
            {
                showUserIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            this.txtClientIP.Text = "本机IP地址：" + showUserIP;
        }
    }
}
