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

public partial class admin_manage_user : System.Web.UI.Page
{
    public string userAccount;

    protected void Page_Load(object sender, EventArgs e)
    {
        userAccount = Convert.ToString(Request.Cookies["pcrepair"].Values["UserAccount"]);

        if (Request.Cookies["pcrepair"] != null)
        {
            //加载
            if (!IsPostBack)
            {
                //绑定数据
                DataView dvlist = UserList.QueryAllUserLists();
                AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
                Session["dvlist"] = dvlist;
                bindData();
            }
        }
    }

    void bindData()
    {
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = AspNetPager1.PageSize;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.DataSource = (DataView)Session["dvlist"];
        GridView1.DataSource = pds;
        GridView1.DataBind();
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bindData();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblIsAllowed = (Label)e.Row.FindControl("lblIsAllowed");
            switch (lblIsAllowed.Text)
            {
                case "0":
                    lblIsAllowed.Text = "可用";
                    break;
                case "1":
                    lblIsAllowed.Text = "<span class='red'>禁用</span>";
                    break;
                default:
                    lblIsAllowed.Text = "未知";
                    break;
            }

            Label lblUserLevel = (Label)e.Row.FindControl("lblUserLevel");
            switch (lblUserLevel.Text)
            {
                case "0":
                    lblUserLevel.Text = "<span class='red'>管理员</span>";
                    break;
                case "1":
                    lblUserLevel.Text = "技术员";
                    break;
                case "2":
                    lblUserLevel.Text = "用户";
                    break;
                default:
                    lblUserLevel.Text = "未知";
                    break;
            }

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string keywords = Convert.ToString(Keywords.Text);
        string strSql = "";
        strSql = "Select UserListID,UserAccount,UserPassword,DepartmentName,Contactor,Tel,Email,Address,UserLevel,IsAllowed From UserLists where UserAccount like \'%" + keywords + "%\' or Contactor like \'%" + keywords + "%\' or DepartmentName like \'%" + keywords + "%\' or Tel like \'%" + keywords + "%\' or Email like \'%" + keywords + "%\'  or Address like \'%" + keywords + "%\' order by UserLevel desc,UserListID desc";

        //绑定数据
        DataView dvlist = UserList.QueryUserLists(strSql);
        AspNetPager1.RecordCount = dvlist.Table.Rows.Count;
        Session["dvlist"] = dvlist;
        bindData();
    }
}
