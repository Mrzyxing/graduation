/**********************************************************
 * 说明：使用者列表类FileList
 * 作者：zyxing
 * 创建日期：02/13/2016
 * E-mail：zyxing@Ctrip.com
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
    /// FileList 的摘要说明。
    /// </summary>
    public class FileList
    {
        #region 私有成员

        private int _fileListID;		    //文件列表ID
        private string _userAccount;	    //发布人帐号
        private string _contactor;	        //发布人
        private string _upFileName;	        //文件名称
        private string _fileContent;	    //文件说明
        private string _fileSize;	        //文件大小
        private string _fileType;	        //文件类型
        private string _fileClasses;	    //文件分类 
        private int _downloadTimes;		    //下载次数
        private DateTime _addTime;          //上传时间

        private bool _exist;		//是否存在标志

        #endregion 私有成员

        #region 属性

        public int FileListID
        {
            set
            {
                this._fileListID = value;
            }
            get
            {
                return this._fileListID;
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
        public string FileContent
        {
            set
            {
                this._fileContent = value;
            }
            get
            {
                return this._fileContent;
            }
        }
        public string FileSize
        {
            set
            {
                this._fileSize = value;
            }
            get
            {
                return this._fileSize;
            }
        }
        public string FileType
        {
            set
            {
                this._fileType = value;
            }
            get
            {
                return this._fileType;
            }
        }
        public string FileClasses
        {
            set
            {
                this._fileClasses = value;
            }
            get
            {
                return this._fileClasses;
            }
        }
        public int DownloadTimes
        {
            set
            {
                this._downloadTimes = value;
            }
            get
            {
                return this._downloadTimes;
            }
        }
        public DateTime AddTime
        {
            set
            {
                this._addTime = value;
            }
            get
            {
                return this._addTime;
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
        /// 根据参数fileListID，获取文件详细信息
        /// </summary>
        /// <param name="fileListID">使用者用户名</param>
        public void LoadData(int fileListID)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select FileListID,UserAccount,Contactor,UpFileName,FileContent,FileSize,FileType,FileClasses,DownloadTimes,AddTime From FileLists where FileListID = "
                + Convert.ToInt32(fileListID);

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._fileListID = GetSafeData.ValidateDataRow_N(dr, "FileListID");
                this._userAccount = GetSafeData.ValidateDataRow_S(dr, "UserAccount");
                this._contactor = GetSafeData.ValidateDataRow_S(dr, "Contactor");
                this._upFileName = GetSafeData.ValidateDataRow_S(dr, "UpFileName");
                this._fileContent = GetSafeData.ValidateDataRow_S(dr, "FileContent");
                this._fileSize = GetSafeData.ValidateDataRow_S(dr, "FileSize");
                this._fileType = GetSafeData.ValidateDataRow_S(dr, "FileType");
                this._fileClasses = GetSafeData.ValidateDataRow_S(dr, "FileClasses");
                this._downloadTimes = GetSafeData.ValidateDataRow_N(dr, "DownloadTimes");
                this._addTime = GetSafeData.ValidateDataRow_T(dr, "AddTime");

                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 按FileListID排序,读取所有文件列表
        /// </summary>
        /// <return></return>
        public static DataView QueryFileLists(string strSql)
        {
            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 按FileListID排序,读取所有文件列表
        /// </summary>
        /// <return></return>
        public static DataView QueryFileLists()
        {

            string strSql = "";
            strSql = "Select FileListID,UserAccount,Contactor,UpFileName,FileContent,FileSize,FileType,FileClasses,DownloadTimes,AddTime From FileLists order by FileListID desc";

            //绑定数据
            Database db = new Database();
            return db.GetDataView(strSql);
        }

        /// <summary>
        /// 增加新的下载文件
        /// </summary>
        /// <return></return>
        public void Add(Hashtable fileLists)
        {
            Database db = new Database();           //实例化一个Database类
            db.Insert("FileLists", fileLists);
        }

        /// <summary>
        /// 修改下载文件数据
        /// </summary>
        /// <param name="fileListID"></param>
        public void Update(Hashtable fileLists)
        {
            Database db = new Database();           //实例化一个Database类
            string strCond = "where FileListID = " + this._fileListID;
            db.Update("FileLists", fileLists, strCond);
        }

        /// <summary>
        /// 删除下载文件
        /// </summary>
        /// <param name="fileListID"></param>
        public void Delete()
        {
            string sql = "";
            sql = "Delete from FileLists where FileListID = " + this._fileListID;

            Database db = new Database();
            db.ExecuteSQL(sql);
        }

        #endregion 方法
    }
}