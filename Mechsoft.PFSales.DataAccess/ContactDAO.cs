using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Data.Common;
using System.Data;
using Mechsoft.GeneralUtilities;

namespace Mechsoft.PFSales.DataAccess
{
    public class ContactDAO
    {
        #region Global Variables
        ILog logger = LogManager.GetLogger(typeof(ContactDAO));
        #endregion

        #region Methods

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 24 May 2013
        /// Description: Get All Contacts.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="ProspectId"></param>
        /// <returns></returns>
        public DataTable GetAllContacts(string Name, Int64 ProspectId,Int64 UserVirtualId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllContacts");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, Name);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId ", DbType.Int64, ProspectId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "UserVirtualId ", DbType.Int64, UserVirtualId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ContactDAO.GetAllContacts Error:" + ex.StackTrace);
                return null;
            }
        }
        #endregion
    }
}
