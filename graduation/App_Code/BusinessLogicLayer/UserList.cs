/**********************************************************
 * 说明：使用者列表类UserList
 * 作者：chshnren1
 * 创建日期：02/06/2009
 * E-mail：chshnren@163.com
 *********************************************************/

using System;
using System.Collections;
using System.Data;

using ComputerRepair.DataAccessLayer;
using ComputerRepair.DataAccessHelper;
using ComputerRepair.CommonComponent;

namespace ComputerRepair.BusinessLogicLayer
{
    /// <summary>
    /// UserList 的摘要说明。
    /// </summary>
    public class UserList
    {
        #region 私有成员

        private int _userListID;		    //使用者ID
        private string _userAccount;	    //使用者帐号
        private string _userPassword;	    //使用者密码
        private string _departmentName;	    //部门名称
        private string _contactor;	        //联系人
        private string _tel;	            //联系电话
        private string _email;	            //E-mail
        private string _address;	        //联系地址 
        private int _userLevel;		        //使用者级别

        private bool _exist;		//是否存在标志

        #endregion 私有成员

        #region 属性

        public int UserListID
        {
            set
            {
                this._userListID = value;
            }
            get
            {
                return this._userListID;
            }
        }
        public string UserAccount
        {
            set
            {
                this._userAccount = value;
            }
            get
            {
                return this._userAccount;
            }
        }
        public string UserPassword
        {
            set
            {
                this._userPassword = value;
            }
            get
            {
                return this._userPassword;
            }
        }
        public string DepartmentName
        {
            set
            {
                this._departmentName = value;
            }
            get
            {
                return this._departmentName;
            }
        }
        public string Contactor
        {
            set
            {
                this._contactor = value;
            }
            get
            {
                return this._contactor;
            }
        }
        public string Tel
        {
            set
            {
                this._tel = value;
            }
            get
            {
                return this._tel;
            }
        }
        public string Email
        {
            set
            {
                this._email = value;
            }
            get
            {
                return this._email;
            }
        }
        public string Address
        {
            set
            {
                this._address = value;
            }
            get
            {
                return this._address;
            }
        }
        public int UserLevel
        {
            set
            {
                this._userLevel = value;
            }
            get
            {
                return this._userLevel;
            }
        }
        public bool Exist
        {
            get
            {
                return this._exist;
            }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 根据参数userAccount，获取使用者详细信息IsAllowed=0
        /// </summary>
        /// <param name="userAccount">使用者用户名</param>
        public void LoadData(string userAccount)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select UserListID,UserAccount,UserPassword,DepartmentName,Contactor,Tel,Email,Address,UserLevel From UserLists where IsAllowed=0 and UserAccount = "
                + SqlStringConstructor.GetQuotedString(userAccount);

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._userListID = GetSafeData.ValidateDataRow_N(dr, "UserListID");
                this._userAccount = GetSafeData.ValidateDataRow_S(dr, "UserAccount");
                this._userPassword = GetSafeData.ValidateDataRow_S(dr, "UserPassword");
                this._departmentName = GetSafeData.ValidateDataRow_S(dr, "DepartmentName");
                this._contactor = GetSafeData.ValidateDataRow_S(dr, "Contactor");
                this._tel = GetSafeData.ValidateDataRow_S(dr, "Tel");
                this._email = GetSafeData.ValidateDataRow_S(dr, "Email");
                this._address = GetSafeData.ValidateDataRow_S(dr, "Address");
                this._userLevel = GetSafeData.ValidateDataRow_N(dr, "UserLevel");

                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 按UserListID排序,读取所有用户
        /// </summary>
        /// <return></return>
        public static DataView QueryUserLists(string strSql)
        {
            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 按UserListID排序,读取所有用户
        /// </summary>
        /// <return></return>
        public static DataView QueryAllUserLists()
        {

            string strSql = "";
            strSql = "Select UserListID,UserAccount,UserPassword,DepartmentName,Contactor,Tel,Email,Address,UserLevel,IsAllowed From UserLists order by UserLevel desc,UserListID desc";

            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 按UserListID排序,读取所有用户UserLevel=2
        /// </summary>
        /// <return></return>
        public static DataView QueryUserLists()
        {

            string strSql = "";
            strSql = "Select UserListID,UserAccount,UserPassword,DepartmentName,Contactor,Tel,Email,Address,UserLevel From UserLists where UserLevel=2 order by UserListID desc";

            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 按UserListID排序,读取所有用户UserLevel=1
        /// </summary>
        /// <return></return>
        public static DataView QueryUserLists1()
        {

            string strSql = "";
            strSql = "Select UserListID,UserAccount,UserPassword,DepartmentName,Contactor,Tel,Email,Address,UserLevel From UserLists where UserLevel=1 order by UserListID desc";

            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 增加新的用户
        /// </summary>
        /// <return></return>
        public void Add(Hashtable userLists)
        {
            Database db = new Database();           //实例化一个Database类
            db.Insert("UserLists", userLists);
        }

        /// <summary>
        /// 修改用户数据
        /// </summary>
        /// <param name="userListID"></param>
        public void Update(Hashtable userLists)
        {
            Database db = new Database();           //实例化一个Database类
            string strCond = "where UserListID = " + this._userListID;
            db.Update("UserLists", userLists, strCond);
        }

        /// <summary>
        /// 删除用户数据
        /// </summary>
        /// <param name="userListID"></param>
        public void Delete()
        {
            string sql = "";
            sql = "Delete from UserLists where UserListID = " + this._userListID;

            Database db = new Database();
            db.ExecuteSQL(sql);
        }

        #endregion 方法
    }
}