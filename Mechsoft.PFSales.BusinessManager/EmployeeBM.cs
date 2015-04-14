using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using log4net;
using Mechsoft.PFSales.BusinessEntity;
using Mechsoft.PFSales.DataAccess;
namespace Mechsoft.PFSales.BusinessManager
{
    public class EmployeeBM
    {
        #region Global Variables
        ILog logger = LogManager.GetLogger(typeof(EmployeeBM));
        EmployeeDAO objEmpDAO = new EmployeeDAO();
        #endregion

        #region Methods
        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 16 May 2013
        /// Description: Add Update Delete Employee
        /// </summary>
        /// <param name="ObjEmp"></param>
        /// <returns></returns>
        public Int64 AddUpdateDeleteEmployee(Employee ObjEmp)
        {
            try
            {
                return objEmpDAO.AddUpdateDeleteEmployee(ObjEmp);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeBM.AddUpdateDeleteEmployee. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 16 May 2013
        /// Description: Get All Employees
        /// </summary>
        /// <param name="objEmp"></param>
        /// <returns></returns>
        public DataTable GetAllEmployee(Employee objEmp)
        {
            try
            {
                return objEmpDAO.GetAllEmployee(objEmp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeBM.GetAllEmployee. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 16 May 2013
        /// Description: Get Employee Details From Employee Id
        /// </summary>
        /// <param name="objEmp"></param>
        /// <returns></returns>
        public DataTable GetEmployeeFromId(Int64 EmpId)
        {
            try
            {
                return objEmpDAO.GetEmployeeFromId(EmpId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeBM.GetEmployeeFromId. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 13 Aug 2013
        /// Description: Get Employee Details From Virtual RoleId
        /// </summary>
        /// <param name="objEmp"></param>
        /// <returns></returns>
        public DataTable GetEmpDetFromVirId(Int64 EmpId)
        {
            try
            {
                return objEmpDAO.GetEmpDetFromVirId(EmpId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeBM.GetEmpDetFromVirId. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date : 17 May 2013
        /// Desc :Get Login Details Of User.
        /// <param name="ObjUser"></param>
        /// <returns>DataTable</returns>
        /// </summary>
        public DataSet GetLoginDetails(Employee objEmp)
        {
            try
            {
                return objEmpDAO.GetUserLoginDetails(objEmp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeBM.GetLoginDetails. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date : 28 May 2013
        /// Desc :Get Login Details Of User for forgots Password.
        /// <param name="objEmp"></param>
        /// <returns>DataTable</returns>
        /// </summary>
        public DataTable GetForgotLoginDtls(Employee objEmp)
        {
            try
            {
                return objEmpDAO.GetForgotLoginDtls(objEmp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeBM.GetForgotLoginDtls. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date : 12 July 2013
        /// Description :Get All Employees For Allocator's Report
        /// </summary>
        /// <param name="Fname"></param>
        /// <param name="RoleId"></param>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public DataTable GetAllEmpForReport(string Fname, int RoleId, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                return objEmpDAO.GetAllEmpForReport(Fname, RoleId, FromDate, ToDate);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeBM.GetAllEmpForReport. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 1 Aug 2013
        /// Description : For Changing Password Of User When it Changed From Quote 
        /// </summary>
        /// <param name="QuoteUserId"></param>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="CreatedById"></param>
        /// <returns></returns>
        public Int64 ChangePassword(Int64 QuoteUserId, string UserName, string password, Int64 CreatedById)
        {
            try
            {
                return objEmpDAO.ChangePassword(QuoteUserId, UserName, password, CreatedById);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeBM.ChangePassword. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 1 Aug 2013
        /// Description : For Changing Activation Status Of User When it Changed From Quote 
        /// </summary>
        /// <param name="QuoteUserId"></param>
        /// <param name="IsActive"></param>
        /// <param name="CreatedById"></param>
        /// <returns></returns>
        public Int64 ChangeIsActiveStatus(Int64 QuoteUserId, Boolean IsActive, Int64 CreatedById)
        {
            try
            {
                return objEmpDAO.ChangeIsActiveStatus(QuoteUserId, IsActive, CreatedById);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeBM.ChangeIsActiveStatus. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 21 August 2013
        /// Description: Get All Consultants
        /// </summary>
        /// <param name="FName"></param>
        /// <returns></returns>
        public DataTable GetAllConsultants(string FName)
        {
            try
            {
                return objEmpDAO.GetAllConsultants(FName);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeBM.GetAllConsultants. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 04 Feb 2014
        /// Description: Get Employee & User Details From Quote User Id
        /// </summary>
        /// <returns></returns>
        public DataTable GetDetailsFromQuoteUserId(Int64 QuoteUserId)
        {
            try
            {
                return objEmpDAO.GetDetailsFromQuoteUserId(QuoteUserId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeBM.GetDetailsFromQuoteUserId. Error:" + ex.StackTrace);
                return null;
            }
        }
        #endregion
    }
}
