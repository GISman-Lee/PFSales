using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Mechsoft.PFSales.DataAccess;
using Mechsoft.PFSales.BusinessEntity;
using System.Data;

namespace Mechsoft.PFSales.BusinessManager
{
    public class DealerBM
    {
        #region Global Variables
        ILog logger = LogManager.GetLogger(typeof(DealerBM));
        DealerDAO objDealerDAO = new DealerDAO();
        #endregion

        #region Methods
        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:25 July 2013
        /// Description: Add Dealer Details
        /// </summary>
        /// <param name="objDealer"></param>
        /// <returns></returns>
        public Int64 AddDealers(clsDealer objDealer)
        {
            try
            {
                return objDealerDAO.AddDealers(objDealer);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "DealerBM.AddDealers. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:25 July 2013
        /// Description: Update Dealers Details
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Int64 UpdateDealers(clsDealer objDealer)
        {
            try
            {
                return objDealerDAO.UpdateDealers(objDealer);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "DealerBM.UpdateDealers. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:25 July 2013
        /// Description: Delete Dealer Details
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Int64 DeleteDealers(clsDealer objDealer)
        {
            try
            {
                return objDealerDAO.DeleteDealers(objDealer);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "DealerBM.DeleteDealers. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:25 July 2013
        /// Description: Get All Dealers
        /// </summary>
        /// <param name="objDealer"></param>
        /// <returns></returns>
        public DataTable GetAllDealers(clsDealer objDealer)
        {
            try
            {
                return objDealerDAO.GetAllDealers(objDealer);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "DealerBM.GetAllDealers. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:25 July 2013
        /// Description: Get Dealer Details From Dealer Id
        /// </summary>
        /// <param name="DealerId"></param>
        /// <returns></returns>
        public DataTable GetDealerDetFromId(Int64 DealerId)
        {
            try
            {
                return objDealerDAO.GetDealerDetFromId(DealerId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "DealerBM.GetDealerDetFromId. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:25 July 2013
        /// Description: Get Prospect Make Mapping Details From Dealer Id
        /// </summary>
        /// <param name="DealerId"></param>
        /// <returns></returns>
        public DataTable GetDeaMakeDetFromDeaId(Int64 DealerId)
        {
            try
            {
                return objDealerDAO.GetDeaMakeDetFromDeaId(DealerId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "DealerBM.GetDeaMakeDetFromDeaId. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:25 July 2013
        /// Description: Get Prospect Make Mapping Details From Id
        /// </summary>
        /// <param name="DealerMMId"></param>
        /// <returns></returns>
        public DataTable GetDealerMakeMapDetFromId(Int64 DealerMMId)
        {
            try
            {
                return objDealerDAO.GetDealerMakeMapDetFromId(DealerMMId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "DealerBM.GetDealerMakeMapDetFromId. Error:" + ex.StackTrace);
                return null;
            }
        }

        #endregion
    }
}
