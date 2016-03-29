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

public partial class admin_add_new_user : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //获取用户在页面上的输入
        string userAccount = UserAccount.Text;          //用户登陆名

        UserList userlist = new UserList();
        userlist.LoadData(userAccount);

        if (userlist.Exist)
        {
            Response.Write("<Script Language=JavaScript>alert(\"您登记的用户名已经存在！\")</Script>");
        }
        else
        {
            Hashtable ht = new Hashtable();
            ht.Add("UserAccount", SqlStringConstructor.GetQuotedString(UserAccount.Text));
            ht.Add("UserPassword", SqlStringConstructor.GetQuotedString(UserPassword.Text));
            ht.Add("DepartmentName", SqlStringConstructor.GetQuotedString(DepartmentName.Text));
            ht.Add("Contactor", SqlStringConstructor.GetQuotedString(Contactor.Text));
            ht.Add("Tel", SqlStringConstructor.GetQuotedString(Tel.Text));
            ht.Add("Email", SqlStringConstructor.GetQuotedString(Email.Text));
            ht.Add("Address", SqlStringConstructor.GetQuotedString(Address.Text));
            ht.Add("UserLevel", SqlStringConstructor.GetQuotedString(UserLevel.SelectedItem.Value));

            UserList adduserlist = new UserList();
            adduserlist.Add(ht);

            Response.Redirect("add_new_user_prs.aspx");
        }
    }
}
