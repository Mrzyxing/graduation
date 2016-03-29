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

public partial class admin_manage_upload_file : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["pcrepair"] != null)
        {
            //加载
            if (!IsPostBack)
            {
                //绑定数据
                DataView dvlist = FileList.QueryFileLists();
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
}
