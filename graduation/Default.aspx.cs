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

public partial class _Default : System.Web.UI.Page 
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

    /// <summary>
    /// 用户单击“登录”按钮事件方法
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        //获取用户在页面上的输入
        string userAccount = Account.Text;          //用户登陆名
        string userPassword = Password.Text;        //用户登陆密码

        UserList userlist = new UserList();
        userlist.LoadData(userAccount);

        if (userlist.Exist)
        {
            if (userlist.UserPassword == userPassword)	        //如果密码正确，转入管理员页面
            {
                HttpCookie cookie = new HttpCookie("pcrepair");                             //定义cookie对象以及名为Info的项
                DateTime dt = DateTime.Now;                                                 //定义时间对象
                TimeSpan ts = new TimeSpan(1, 0, 0, 0);                                     //cookie有效作用时间，具体查msdn
                cookie.Expires = dt.Add(ts);                                                //添加作用时间
                cookie.Values.Add("UserListID", userlist.UserListID.ToString());             //增加属性
                cookie.Values.Add("UserAccount", userlist.UserAccount.ToString());          //增加属性
                cookie.Values.Add("DepartmentName", HttpUtility.UrlEncode(userlist.DepartmentName.ToString()));    //增加属性
                cookie.Values.Add("Contactor", HttpUtility.UrlEncode(userlist.Contactor.ToString()));              //增加属性
                cookie.Values.Add("Tel", HttpUtility.UrlEncode(userlist.Tel.ToString()));                          //增加属性
                cookie.Values.Add("Address", HttpUtility.UrlEncode(userlist.Address.ToString()));                  //增加属性
                cookie.Values.Add("UserLevel", userlist.UserLevel.ToString());              //增加属性

                Response.AppendCookie(cookie);                          //确定写入cookie中

                switch (userlist.UserLevel.ToString())
                {
                    case "0":
                        Response.Redirect("admin/admin.aspx");
                        break;
                    case "1":
                        Response.Redirect("tech/admin.aspx");
                        break;
                    case "2":
                        Response.Redirect("user/admin.aspx");
                        break;
                    default:
                        break;
                }

            }
            else //如果密码错误，给出提示，光标停留在密码框中
            {
                Response.Write("<Script Language=JavaScript>alert(\"密码错误，请重新输入密码！\")</Script>");
            }
        }
        else
        {
            Response.Write("<Script Language=JavaScript>alert(\"您输入的用户名不存在！\")</Script>");
        }
    }
}
