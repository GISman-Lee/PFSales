using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Mechsoft.PFSales.DataAccess;
using System.Data;

namespace Mechsoft.PFSales.BusinessManager
{
    public class ContactBM
    {
        #region Global Variables
        ILog logger = LogManager.GetLogger(typeof(ContactBM));
        ContactDAO objContDAO = new ContactDAO();
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
        public DataTable GetAllContacts(string Name, Int64 ProspectId, Int64 UserVirtualId)
        {
            try
            {
                return objContDAO.GetAllContacts(Name, ProspectId, UserVirtualId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ContactBM.GetAllContacts Error:" + ex.StackTrace);
                return null;
            }
        }
        #endregion
    }
}
