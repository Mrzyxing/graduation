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

public partial class admin_edit_user : System.Web.UI.Page
{
    public string Action;

    protected void Page_Load(object sender, EventArgs e)
    {
        Action = Convert.ToString(Request.QueryString["Action"]);

        switch (Action)
        {
            case "Allowed":
                IsAllow();
                break;

            case "NoAllowed":

                NoAllow();
                break;

            default:
                break;
        }
    }


    /// <summary>
    /// 更新一条数据，设为可用
    /// </summary>
    private void IsAllow()
    {
        UserList userlist = new UserList();
        userlist.UserListID = Convert.ToInt32(Request.QueryString["UserListID"]);

        Hashtable ht = new Hashtable();
        ht.Add("IsAllowed", "0");

        userlist.Update(ht);

        Response.Redirect(Request.UrlReferrer.ToString());
    }

    /// <summary>
    /// 更新一条数据，设为不可用
    /// </summary>
    private void NoAllow()
    {
        UserList userlist = new UserList();
        userlist.UserListID = Convert.ToInt32(Request.QueryString["UserListID"]);

        Hashtable ht = new Hashtable();
        ht.Add("IsAllowed", "1");

        userlist.Update(ht);

        Response.Redirect(Request.UrlReferrer.ToString());
    }
}
