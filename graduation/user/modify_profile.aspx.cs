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

public partial class user_modify_profile : System.Web.UI.Page
{
    public string userAccount;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["pcrepair"] != null)
        {
            userAccount = Convert.ToString(Request.Cookies["pcrepair"].Values["UserAccount"]);

            //加载
            if (!IsPostBack)
            {
                //绑定数据
                bindData();
            }
        }
    }

    void bindData()
    {
        UserList userlist = new UserList();
        userlist.LoadData(userAccount);

        if (userlist.Exist)
        {
            this.ShowUserAccount.Text = userlist.UserAccount;
            this.UserPassword.Text = userlist.UserPassword;
            this.DepartmentName.Text = userlist.DepartmentName;
            this.Contactor.Text = userlist.Contactor;
            this.Tel.Text = userlist.Tel;
            this.Email.Text = userlist.Email;
            this.Address.Text = userlist.Address;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["pcrepair"] != null)
        {
            UserList userlist = new UserList();
            userlist.UserListID = Convert.ToInt32(Request.Cookies["pcrepair"].Values["UserListID"]);

            Hashtable ht = new Hashtable();
            ht.Add("UserPassword",SqlStringConstructor.GetQuotedString(UserPassword.Text));
            ht.Add("DepartmentName",SqlStringConstructor.GetQuotedString(DepartmentName.Text));
            ht.Add("Contactor",SqlStringConstructor.GetQuotedString(Contactor.Text));
            ht.Add("Tel",SqlStringConstructor.GetQuotedString(Tel.Text));
            ht.Add("Email",SqlStringConstructor.GetQuotedString(Email.Text));
            ht.Add("Address",SqlStringConstructor.GetQuotedString(Address.Text));

            userlist.Update(ht);

            Response.Redirect("modify_profile_prs.aspx");
        }
        
    }
}
