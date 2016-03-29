/**********************************************************
 * 说明：下载历史记录类DownloadHistory
 * 作者：chshnren1
 * 创建日期：02/16/2009
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
    /// DownloadHistory 的摘要说明。
    /// </summary>
    public class DownloadHistory
    {
        #region 私有成员

        private int _downloadHistoryID;		//下载历史记录ID
        private string _userAccount;	    //发布人帐号
        private string _contactor;	        //发布人
        private string _upFileName;	        //文件名称
        private DateTime _downDatetime;     //下载时间

        private bool _exist;		//是否存在标志

        #endregion 私有成员

        #region 属性

        public int DownloadHistoryID
        {
            set
            {
                this._downloadHistoryID = value;
            }
            get
            {
                return this._downloadHistoryID;
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
        public string UpFileName
        {
            set
            {
                this._upFileName = value;
            }
            get
            {
                return this._upFileName;
            }
        }
        public DateTime DownDatetime
        {
            set
            {
                this._downDatetime = value;
            }
            get
            {
                return this._downDatetime;
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
        /// 根据参数downloadHistoryID，获取详细信息
        /// </summary>
        /// <param name="downloadHistoryID">下载历史记录ID</param>
        public void LoadData(int downloadHistoryID)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select DownloadHistoryID,UserAccount,Contactor,UpFileName,DownDatetime From DownloadHistory where DownloadHistoryID = "
                + Convert.ToInt32(downloadHistoryID);

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._downloadHistoryID = GetSafeData.ValidateDataRow_N(dr, "DownloadHistoryID");
                this._userAccount = GetSafeData.ValidateDataRow_S(dr, "UserAccount");
                this._contactor = GetSafeData.ValidateDataRow_S(dr, "Contactor");
                this._upFileName = GetSafeData.ValidateDataRow_S(dr, "UpFileName");
                this._downDatetime = GetSafeData.ValidateDataRow_T(dr, "DownDatetime");

                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 按DownloadHistoryID排序,读取所有下载历史记录
        /// </summary>
        /// <return></return>
        public static DataView QueryDownloadHistory(string strSql)
        {
            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 按DownloadHistoryID排序,读取所有下载历史记录
        /// </summary>
        /// <return></return>
        public static DataView QueryDownloadHistory()
        {

            string strSql = "";
            strSql = "Select DownloadHistoryID,UserAccount,Contactor,UpFileName,DownDatetime From DownloadHistory order by DownloadHistoryID desc";

            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 按DownloadHistoryID排序,读取所有下载历史记录
        /// </summary>
        /// <return></return>
        public static DataView QueryDownloadHistoryView()
        {

            string strSql = "";
            strSql = "Select DownloadHistoryID,UserAccount,Contactor,UpFileName,DownDatetime,FileListID,FileContent From DownloadHistory_View order by DownloadHistoryID desc";

            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }


        /// <summary>
        /// 增加新的下载历史记录
        /// </summary>
        /// <return></return>
        public void Add(Hashtable downloadHistory)
        {
            Database db = new Database();           //实例化一个Database类
            db.Insert("DownloadHistory", downloadHistory);
        }

        /// <summary>
        /// 修改下载历史记录
        /// </summary>
        /// <param name="downloadHistoryID"></param>
        public void Update(Hashtable downloadHistory)
        {
            Database db = new Database();           //实例化一个Database类
            string strCond = "where DownloadHistoryID = " + this._downloadHistoryID;
            db.Update("DownloadHistory", downloadHistory, strCond);
        }

        /// <summary>
        /// 删除下载历史记录
        /// </summary>
        /// <param name="downloadHistoryID"></param>
        public void Delete()
        {
            string sql = "";
            sql = "Delete from DownloadHistory where DownloadHistoryID = " + this._downloadHistoryID;

            Database db = new Database();
            db.ExecuteSQL(sql);
        }

        #endregion 方法
    }
}