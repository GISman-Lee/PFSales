using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Data.Common;
using Mechsoft.GeneralUtilities;
using System.Data;
using Mechsoft.PFSales.BusinessEntity;

namespace Mechsoft.PFSales.DataAccess
{
    public class DealerDAO
    {
        #region Global Variables
        ILog logger = LogManager.GetLogger(typeof(DealerDAO));
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
            DbCommand objCmd = null;
            Int64 Result = 0;
            DbConnection objConn = null;
            DbTransaction objTran = null;
            try
            {
                objConn = Cls_DataAccess.getInstance().GetConnection();
                objConn.Open();
                objTran = objConn.BeginTransaction();
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddDealers");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objDealer.DealerId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "DKey", DbType.String, objDealer.DKey);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FName", DbType.String, objDealer.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "LName", DbType.String, objDealer.LName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "State", DbType.Int32, objDealer.StateId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SecState", DbType.Int32, objDealer.SecStateId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "City", DbType.Int32, objDealer.CityId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PostalCode", DbType.String, objDealer.PostalCode);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Company", DbType.String, objDealer.Company);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Address1", DbType.String, objDealer.Add1);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email", DbType.String, objDealer.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Fax", DbType.String, objDealer.Fax);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedFax", DbType.Int64, objDealer.formatedFax);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Phone", DbType.String, objDealer.Phone);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedPhone", DbType.Int64, objDealer.formatedPhoNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Mobile", DbType.String, objDealer.Mobile);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedMobile", DbType.Int64, objDealer.formatedMobNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Notes", DbType.String, objDealer.Notes);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objDealer.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objDealer.IsDeleted);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
                    for (int i = 0; i < objDealer.lstDMMapping.Count; i++)
                    {
                        objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddDealerMakeMap");
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, 0);
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "DealerId", DbType.Int64, Result);
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "MakeId", DbType.Int32, objDealer.lstDMMapping[i].MakeId);
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objDealer.CreatedById);
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objDealer.IsDeleted);
                        Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                        if (Result < 0)
                        {
                            objTran.Rollback();
                            return Result;
                        }
                    }
                    if (Result > 0)
                    {
                        objTran.Commit();
                        return Result;
                    }
                    else
                    {
                        objTran.Rollback();
                        return Result;
                    }
                }
                else
                {
                    objTran.Rollback();
                    return Result;
                }
            }
            catch (Exception ex)
            {
                objTran.Rollback();
                logger.Error(ex.Message + "DealerDAO.AddDealers Error:" + ex.StackTrace);
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
            DbCommand objCmd = null;
            Int64 Result = 0;
            DbConnection objConn = null;
            DbTransaction objTran = null;
            try
            {
                objConn = Cls_DataAccess.getInstance().GetConnection();
                objConn.Open();
                objTran = objConn.BeginTransaction();
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateDealers");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objDealer.DealerId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "DKey", DbType.String, objDealer.DKey);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FName", DbType.String, objDealer.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "LName", DbType.String, objDealer.LName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "State", DbType.Int32, objDealer.StateId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SecState", DbType.Int32, objDealer.SecStateId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "City", DbType.Int32, objDealer.CityId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PostalCode", DbType.String, objDealer.PostalCode);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Company", DbType.String, objDealer.Company);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Address1", DbType.String, objDealer.Add1);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email", DbType.String, objDealer.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Fax", DbType.String, objDealer.Fax);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedFax", DbType.Int64, objDealer.formatedFax);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Phone", DbType.String, objDealer.Phone);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedPhone", DbType.Int64, objDealer.formatedPhoNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Mobile", DbType.String, objDealer.Mobile);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedMobile", DbType.Int64, objDealer.formatedMobNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Notes", DbType.String, objDealer.Notes);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objDealer.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objDealer.IsDeleted);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
                    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_HardDeleteDealerMakeMap");
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objDealer.DealerId);
                    Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                    if (Result > 0)
                    {
                        for (int i = 0; i < objDealer.lstDMMapping.Count; i++)
                        {
                            objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddDealerMakeMap");
                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, 0);
                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "DealerId", DbType.Int64, objDealer.DealerId);
                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "MakeId", DbType.Int64, objDealer.lstDMMapping[i].MakeId);
                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objDealer.CreatedById);
                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objDealer.IsDeleted);
                            Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                            if (Result < 0)
                            {
                                objTran.Rollback();
                                return Result;
                            }
                        }
                        if (Result > 0)
                        {
                            objTran.Commit();
                            return Result;
                        }
                        else
                        {
                            objTran.Rollback();
                            return Result;
                        }
                    }
                    else
                    {
                        objTran.Rollback();
                        return Result;
                    }
                }
                else
                {
                    objTran.Rollback();
                    return Result;
                }
            }
            catch (Exception ex)
            {
                objTran.Rollback();
                logger.Error(ex.Message + "DealerDAO.UpdateDealers Error:" + ex.StackTrace);
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
            DbCommand objCmd = null;
            Int64 Result = 0;
            DbConnection objConn = null;
            DbTransaction objTran = null;
            try
            {
                objConn = Cls_DataAccess.getInstance().GetConnection();
                objConn.Open();
                objTran = objConn.BeginTransaction();
                //for (int i = 0; i < objDealer.lstDMMapping.Count; i++)
                //{
                    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_DeleteDealerMakeMap");
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objDealer.DealerId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objDealer.CreatedById);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objDealer.IsDeleted);
                    Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                    if (Result < 0 && Result == -9)
                    {
                        objTran.Rollback();
                        return Result;
                    }
                //}
                if (Result > 0 && objDealer.IsDeleted == true)
                {
                    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_DeleteDealers");
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objDealer.DealerId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objDealer.CreatedById);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objDealer.IsDeleted);
                    Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                    if (Result > 0)
                    {
                        objTran.Commit();
                        return Result;
                    }
                    else
                    {
                        objTran.Rollback();
                        return Result;
                    }
                }
                else
                {
                    objTran.Rollback();
                    return Result;
                }
            }
            catch (Exception ex)
            {
                objTran.Rollback();
                logger.Error(ex.Message + "DealerDAO.DeleteDealers Error:" + ex.StackTrace);
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
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllDealers");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, objDealer.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Make", DbType.Int32, objDealer.CarMake);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Company", DbType.String, objDealer.Company);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "DealerDAO.GetAllDealers Error:" + ex.StackTrace);
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
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetDealerDetFromId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, DealerId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "DealerDAO.GetDealerDetFromId Error:" + ex.StackTrace);
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
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetDeaMakeDetFromDeaId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "DealerId", DbType.Int64, DealerId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "DealerDAO.GetDeaMakeDetFromDeaId Error:" + ex.StackTrace);
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
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetDealerMakeMapDetFromId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspId", DbType.Int64, DealerMMId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "DealerDAO.GetDealerMakeMapDetFromId Error:" + ex.StackTrace);
                return null;
            }
        }
        #endregion
    }
}
