using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using log4net;
using Mechsoft.PFSales.DataAccess;
using Mechsoft.PFSales.BusinessEntity;

namespace Mechsoft.PFSales.BusinessManager
{
    class OrdersBM
    {
        #region Global Variables
        ILog logger = LogManager.GetLogger(typeof(ProspectBM));
        ProspectsDAO objProspDAO = new ProspectsDAO();
        OrdersDAO objOrdersDAO = new OrdersDAO();
        #endregion

        #region Methods

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 27 Feb 2014
        /// Description: Add Order
        /// </summary>
        /// <param name="ObjEmp"></param>
        /// <returns></returns>
        public Int64 AddOrder(clsOrders ObjOrder)
        {
            try
            {
                return objOrdersDAO.AddOrder(ObjOrder);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "OrdersBM.AddOrder. Error:" + ex.StackTrace);
                return 0;
            }
        }

        #endregion

    }
}
