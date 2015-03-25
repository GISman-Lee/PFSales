using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mechsoft.GeneralUtilities;
using System.Data;
using System.Data.Common;
using log4net;
using Mechsoft.PFSales.BusinessEntity;

namespace Mechsoft.PFSales.DataAccess
{
    public class ActivityDAO
    {
        #region Global Variables
        ILog logger = LogManager.GetLogger(typeof(ActivityDAO));
        #endregion

        #region Methods
        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 19 June 2013
        /// Description: Add Activity
        /// </summary>
        /// <param name="objActivity"></param>
        /// <returns></returns>
        public Int64 AddActivity(Activity objActivity)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            Int64 ActivityId = 0;
            DbConnection objConn = null;
            DbTransaction objTran = null;
            Int64 ActiId = 0;
            try
            {
                objConn = Cls_DataAccess.getInstance().GetConnection();
                objConn.Open();
                objTran = objConn.BeginTransaction();

                //if (objActivity.RegardingsId == 0 && !string.IsNullOrEmpty(objActivity.Regardings.Trim()))
                //{
                //    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddRegardings");
                //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int16, objActivity.RegardingsId);
                //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityTypeId", DbType.Int16, objActivity.ActivityTypeId);
                //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, objActivity.Regardings);
                //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Description", DbType.String, string.Empty);
                //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsCustom", DbType.Boolean, true);
                //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objActivity.CreatedById);
                //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objActivity.IsDeleted);
                //    Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                //    if (Result < 0)
                //    {
                //        objTran.Rollback();
                //        return Result;
                //    }
                //    else
                //    {
                //        objActivity.RegardingsId = (int)Result;
                //    }
                //}
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddActivity");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objActivity.Id);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityTypeId", DbType.Int16, objActivity.ActivityTypeId);
                if (objActivity.ParrentActId != 0)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ParrentActivityId", DbType.Int64, objActivity.ParrentActId);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "RegardingsId", DbType.Int32, objActivity.RegardingsId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Regarding", DbType.String, objActivity.Regarding);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityPriorityId", DbType.Int16, objActivity.PriorityId);
                if (objActivity.ProspectId != 0)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId", DbType.Int64, objActivity.ProspectId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StartDateTime", DbType.DateTime, objActivity.ActStartTime);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "EndDateTime", DbType.DateTime, objActivity.ActEndTime);
                if (!string.IsNullOrEmpty(objActivity.Location))
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Location", DbType.String, objActivity.Location);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTimeLess", DbType.Boolean, objActivity.IsTimeLess);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsPrivate", DbType.Boolean, objActivity.IsPrivate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Status", DbType.Int32, objActivity.Status);
                if (objActivity.Duration > 0)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Duration", DbType.Int32, objActivity.Duration);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objActivity.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objActivity.IsDeleted);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
                    ActiId = Result;
                    ActivityId = Result;
                    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddActivityDocument");
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objActivity.ActivityDocId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityId", DbType.Int64, ActivityId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Remark", DbType.String, objActivity.ActivityDocRemark);
                    if (!string.IsNullOrEmpty(objActivity.ActivityDocFilePath))
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "Filepath", DbType.String, objActivity.ActivityDocFilePath);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objActivity.CreatedById);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objActivity.IsDeleted);
                    Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                    if (Result > 0)
                    {
                        for (int i = 0; i < objActivity.LstReources.Count; i++)
                        {
                            objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddActivityResources");
                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, 0);
                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityId", DbType.Int64, ActivityId);
                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "ResourceId", DbType.Int64, objActivity.LstReources[i].ResourceId);
                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objActivity.CreatedById);
                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objActivity.IsDeleted);
                            Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                            if (Result < 0)
                            {
                                objTran.Rollback();
                                return Result;
                            }
                        }
                        if (Result > 0)
                        {
                            for (int i = 0; i < objActivity.LstAlertDetails.Count; i++)
                            {
                                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddActivityAlertDetails");
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, 0);
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityId", DbType.Int64, ActivityId);
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "AlertTypeId", DbType.Int16, objActivity.LstAlertDetails[i].AlertTypeId);
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "AlertValueBefore", DbType.Int32, objActivity.LstAlertDetails[i].AlertValueBefore);
                                if (objActivity.LstAlertDetails[i].SnoozValue > 0)
                                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "SnoozValue", DbType.Int32, objActivity.LstAlertDetails[i].SnoozValue);
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "AlertForId", DbType.String, objActivity.LstAlertDetails[i].AlertForId);
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objActivity.CreatedById);
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objActivity.IsDeleted);
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
                                return ActiId;
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
                        objTran.Commit();
                        return ActiId;
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
                logger.Error(ex.Message + "ActivityDAO.AddActivity Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 22 June 2013
        /// Description: Get Notifications For Consultant
        /// </summary>
        /// <param name="virtualRoleId"></param>
        /// <returns></returns>
        public DataTable GetNotifications(Int64 virtualRoleId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllNotifications");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "UserVirtualId", DbType.Int64, virtualRoleId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "DateNow", DbType.DateTime, DateTime.Now);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetNotifications Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 24 June 2013
        /// Description: Get Today's Activities For Consultant
        /// </summary>
        /// <param name="virtualRoleId"></param>
        /// <returns></returns>
        public DataTable GetTodaysActivity(Int64 virtualRoleId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetTodaysActivity");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "UserVirtualId", DbType.Int64, virtualRoleId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "DateNow", DbType.DateTime, DateTime.Now);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetTodaysActivity Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 24 June 2013
        /// Description: Get Prospect Details From Dashboard link click
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable GetProspDetFromDash(Prospect objProsp)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetProspDetFromDash");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Ids", DbType.String, objProsp.Ids);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, objProsp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Status", DbType.Int64, objProsp.StatusId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MemNo", DbType.String, objProsp.MemberNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Make", DbType.Int32, objProsp.CarMake);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email", DbType.String, objProsp.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StateId", DbType.Int32, objProsp.StateId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CityId", DbType.Int32, objProsp.CityId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetProspDetFromDash Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 26 June 2013
        /// Description: Get Prospect Details From Dashboard link click
        /// </summary>
        /// <param name="objActivity"></param>
        /// <returns></returns>
        public DataTable GetMyAlerts(ActAlertDetails objActivity)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetMyAlerts");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "UserId", DbType.Int64, objActivity.UserId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "AlertTypeId", DbType.Int16, objActivity.AlertTypeId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetMyAlerts Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 26 June 2013
        /// Description: Update Alert Status To Close
        /// </summary>
        /// <param name="AlertId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Int64 UpdateAlertStatus(Int64 AlertId, Int64 UserId)
        {
            DbCommand objCmd = null;
            Int64 result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateAlertStatus");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "AlertId", DbType.Int64, AlertId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, UserId);
                result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.UpdateAlertStatus Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 26 June 2013
        /// Description: Getting Emp Details Of Given Ids For Sending Email Alerts
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public DataTable GetEmpDetFromIdForAlert(string Ids)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetEmpDetFromIdForAlert");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Ids", DbType.String, Ids);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetEmpDetFromIdForAlert Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 29 June 2013
        /// Description: Get All Activities For Consultant
        /// </summary>
        /// <param name="virtualRoleId"></param>
        /// <returns></returns>
        public DataTable GetMyActivities(Int64 virtualRoleId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetMyActivities");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "UserVirtualId", DbType.Int64, virtualRoleId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetMyActivities Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 29 June 2013
        /// Description: Get Activity Details From Id
        /// </summary>
        /// <param name="AlertId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable GetActivityDetFromId(Int64 AlertId, Int64 UserId)
        {
            DbCommand objCmd = null;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetActivityDetFromId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityId", DbType.Int64, AlertId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ResourceId", DbType.Int64, UserId);
                DataTable DataTable = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DataTable;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetActivityDetFromId Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 29 June 2013
        /// Description: Get Activity Alert Details From Activity Id
        /// </summary>
        /// <param name="AlertId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable GetActivityAlertDetailsFromId(Int64 AlertId, Int64 UserId)
        {
            DbCommand objCmd = null;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetActivityAlertDetailsFromId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityId", DbType.Int64, AlertId);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "ResourceId", DbType.Int64, UserId);
                DataTable DataTable = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DataTable;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetActivityAlertDetailsFromId Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 1 July 2013
        /// Description: Update Activity
        /// </summary>
        /// <param name="objActivity"></param>
        /// <returns></returns>
        public Int64 UpdateActivity(Activity objActivity)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            Int64 ActivityId = 0;
            DbConnection objConn = null;
            DbTransaction objTran = null;
            try
            {
                objConn = Cls_DataAccess.getInstance().GetConnection();
                objConn.Open();
                objTran = objConn.BeginTransaction();

                //if (objActivity.RegardingsId == 0 && !string.IsNullOrEmpty(objActivity.Regardings.Trim()))
                //{
                //    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddRegardings");
                //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int16, objActivity.RegardingsId);
                //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityTypeId", DbType.Int16, objActivity.ActivityTypeId);
                //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, objActivity.Regardings);
                //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Description", DbType.String, string.Empty);
                //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsCustom", DbType.Boolean, true);
                //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objActivity.CreatedById);
                //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objActivity.IsDeleted);
                //    Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                //    if (Result < 0)
                //    {
                //        objTran.Rollback();
                //        return Result;
                //    }
                //    else
                //    {
                //        objActivity.RegardingsId = (int)Result;
                //    }
                //}
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateActivity");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objActivity.Id);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityTypeId", DbType.Int32, objActivity.ActivityTypeId);
                if (objActivity.ParrentActId != 0)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ParrentActivityId", DbType.Int64, objActivity.ParrentActId);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "RegardingsId", DbType.Int32, objActivity.RegardingsId);Regarding
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Regarding", DbType.String, objActivity.Regarding);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityPriorityId", DbType.Int16, objActivity.PriorityId);
                if (objActivity.ProspectId != 0)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId", DbType.Int64, objActivity.ProspectId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StartDateTime", DbType.DateTime, objActivity.ActStartTime);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "EndDateTime", DbType.DateTime, objActivity.ActEndTime);
                if (!string.IsNullOrEmpty(objActivity.Location))
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Location", DbType.String, objActivity.Location);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTimeLess", DbType.Boolean, objActivity.IsTimeLess);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsPrivate", DbType.Boolean, objActivity.IsPrivate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Status", DbType.Int32, objActivity.Status);
                if (objActivity.Duration > 0)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Duration", DbType.Int32, objActivity.Duration);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objActivity.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objActivity.IsDeleted);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
                    ActivityId = objActivity.Id;
                    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateActivityDocument");
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objActivity.ActivityDocId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityId", DbType.Int64, ActivityId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Remark", DbType.String, objActivity.ActivityDocRemark);
                    if (!string.IsNullOrEmpty(objActivity.ActivityDocFilePath))
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "Filepath", DbType.String, objActivity.ActivityDocFilePath);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objActivity.CreatedById);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objActivity.IsDeleted);
                    Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                    if (Result > 0)
                    {
                        for (int i = 0; i < objActivity.LstReources.Count; i++)
                        {
                            objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateActivityResources");
                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objActivity.LstReources[i].ActResourceId);
                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityId", DbType.Int64, ActivityId);
                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "ResourceId", DbType.Int64, objActivity.LstReources[i].ResourceId);
                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objActivity.CreatedById);
                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objActivity.LstReources[i].IsDeleted);
                            Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                            if (Result < 0)
                            {
                                objTran.Rollback();
                                return Result;
                            }
                        }
                        if (Result > 0)
                        {
                            for (int i = 0; i < objActivity.LstAlertDetails.Count; i++)
                            {
                                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateActivityAlertDetails");
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objActivity.LstAlertDetails[i].ActAlertId);
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityId", DbType.Int64, ActivityId);
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "AlertTypeId", DbType.Int16, objActivity.LstAlertDetails[i].AlertTypeId);
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "AlertValueBefore", DbType.Int32, objActivity.LstAlertDetails[i].AlertValueBefore);
                                if (objActivity.LstAlertDetails[i].SnoozValue > 0)
                                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "SnoozValue", DbType.Int32, objActivity.LstAlertDetails[i].SnoozValue);
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "AlertForId", DbType.String, objActivity.LstAlertDetails[i].AlertForId);
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objActivity.CreatedById);
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objActivity.LstAlertDetails[i].IsDeleted);
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
                        objTran.Commit();
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
                logger.Error(ex.Message + "ActivityDAO.UpdateActivity Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 1 July 2013
        /// Description: For Getting All Consultants Details For Update Activity 
        /// </summary>
        /// <param name="FName"></param>
        /// <param name="ActivityId"></param>
        /// <returns></returns>
        public DataTable GetAllConsultForActivity(string FName, Int64 ActivityId)
        {
            DbCommand objCmd = null;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllConsultForActivity");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FName", DbType.String, FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityId", DbType.Int64, ActivityId);
                DataTable DataTable = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DataTable;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetAllConsultForActivity Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 2 July 2013
        /// Description: Get All Activities From Prospect Id
        /// </summary>
        /// <param name="ProspectId"></param>
        /// <returns></returns>
        public DataTable GetActivityOfProspect(Int64 ProspectId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetActivityOfProspect");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId", DbType.Int64, ProspectId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetActivityOfProspect Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 2 July 2013
        /// Description: Add Clear Activity
        /// </summary>
        /// <param name="objActivity"></param>
        /// <returns></returns>
        public Int64 AddClearActivity(ClearActivity objActivity)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddClearActivityData");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objActivity.Id);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityId", DbType.Int64, objActivity.ActivityId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Remark", DbType.String, objActivity.Remark);
                if (!string.IsNullOrEmpty(objActivity.FilePath))
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Filepath", DbType.String, objActivity.FilePath);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActStatus", DbType.Int32, objActivity.ActStatus);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Status", DbType.Int32, objActivity.Status);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId", DbType.Int64, objActivity.ProspectId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objActivity.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objActivity.IsDeleted);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.AddClearActivity Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 4 July 2013
        /// Description: Get Notifications For Admin
        /// </summary>
        /// <returns></returns>
        public DataTable GetAdminNotifications()
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAdminNotifications");
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetAdminNotifications Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 4 July 2013
        /// Description: Get Today's Activities For Admin
        /// </summary>
        /// <returns></returns>
        public DataTable GetTodaysAdminActivity()
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetTodaysAdminActivity");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "DateNow", DbType.DateTime, DateTime.Now);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetTodaysAdminActivity Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 4 July 2013
        /// Description: Get Ids Of Prospects When Click On Count Of Today's Activity On Admin Dashboard
        /// </summary>
        /// <param name="ActivityTypeId"></param>
        /// <returns></returns>
        public DataTable GetProspIdForTodayAct(Int16 ActivityTypeId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetProspIdForTodayAct");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "DateNow", DbType.DateTime, DateTime.Now);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityTypeId", DbType.Int16, ActivityTypeId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetProspIdForTodayAct Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 6 July 2013
        /// Description: Get Activity Details From Activity Id
        /// </summary>
        /// <param name="ActivityId"></param>
        /// <returns></returns>
        public DataTable GetDetailsOfActivity(Int64 ActivityId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetDetailsOfActivity");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityId", DbType.Int64, ActivityId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetDetailsOfActivity Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 11 July 2013
        /// Description: Get Activity Details From Activity Id
        /// </summary>
        /// <param name="UserVirtualId"></param>
        /// <returns></returns>
        public DataTable GetUpcomingSchedular(Int64 UserVirtualId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetUpcomingSchedular");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "UserVirtualId", DbType.Int64, UserVirtualId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "DateNow", DbType.DateTime, DateTime.Now);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetUpcomingSchedular Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 9 Aug 2013
        /// Description: Add Contact Notes
        /// </summary>
        /// <param name="ContactId"></param>
        /// <param name="Notes"></param>
        /// <param name="CreatedById"></param>
        /// <param name="IsDeleted"></param>
        /// <param name="ActivityStatus"></param>
        /// <param name="ActivityId"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public Int64 AddContactNotes(Int64 ContactId, string Notes, Int64 CreatedById, Boolean IsDeleted, Int32 ActivityStatus, Int64 ActivityId, Int32 Status)
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
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddContactNotes");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ContactId ", DbType.Int64, ContactId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityStatus ", DbType.Int32, ActivityStatus);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Status ", DbType.Int32, Status);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Notes", DbType.String, Notes);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityId", DbType.Int64, ActivityId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, IsDeleted);
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
            catch (Exception ex)
            {
                objTran.Rollback();
                logger.Error(ex.Message + "ActivityDAO.AddContactNotes Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 10 Aug 2013
        /// Description: Update Contact Notes
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="ContactId"></param>
        /// <param name="Notes"></param>
        /// <param name="CreatedById"></param>
        /// <param name="IsDeleted"></param>
        /// <param name="ActivityStatus"></param>
        /// <param name="ActivityId"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public Int64 UpdateContactNotes(Int64 Id, Int64 ContactId, string Notes, Int64 CreatedById, Boolean IsDeleted, Int32 ActivityStatus, Int64 ActivityId, Int32 Status)
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
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateContactNotes");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id ", DbType.Int64, Id);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ContactId ", DbType.Int64, ContactId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityStatus ", DbType.Int32, ActivityStatus);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Status ", DbType.Int32, Status);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Notes", DbType.String, Notes);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityId", DbType.Int64, ActivityId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, IsDeleted);
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
            catch (Exception ex)
            {
                objTran.Rollback();
                logger.Error(ex.Message + "ActivityDAO.UpdateContactNotes Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 10 Aug 2013
        /// Description: Get All Notes From Prospect Id
        /// </summary>
        /// <param name="ProspectId"></param>
        /// <returns></returns>
        public DataTable GetAllContactNotes(Int64 ProspectId,Int64 VirtualRoleId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllContactNotes");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId", DbType.Int64, ProspectId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "VirtualRoleId", DbType.Int64, VirtualRoleId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetAllContactNotes Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 10 Aug 2013
        /// Description: Get Max Activity Start Date For A Prospect
        /// </summary>
        /// <param name="ProspectId"></param>
        /// <returns></returns>
        public DataTable GetMinDateForFutureAct(Int64 ProspectId, Int64 VirtualRoleId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetMinDateForFutureAct");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId", DbType.Int64, ProspectId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "VirtualRoleId", DbType.Int64, VirtualRoleId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetMinDateForFutureAct Error:" + ex.StackTrace);
                return null;
            }
        }
        
        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 12 Aug 2013
        /// Description: Get Max Activity Start Date For A Prospect
        /// </summary>
        /// <param name="UserVirtualId"></param>
        /// <param name="SDateTime"></param>
        /// <returns></returns>
        public Int64 GetCountOfActForStime(Int64 UserVirtualId, DateTime SDateTime)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetCountOfActForStime");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "UserVirtualId", DbType.Int64, UserVirtualId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SDateTime", DbType.DateTime, SDateTime);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetCountOfActForStime Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 13 Aug 2013
        /// Description: Get Contact Notes Details From Prospect Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataTable GetContactNotesFromId(Int64 Id)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetContactNotesFromId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, Id);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.GetContactNotesFromId Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 13 Aug 2013
        /// Description: Set Allocated Date Time For Prospect Id
        /// </summary>
        /// <param name="ConsultantId"></param>
        /// <param name="ProspId"></param>
        /// <param name="CreatedById"></param>
        /// <returns></returns>
        public Int64 SetAllocatedDate(Int64 ConsultantId, Int64 ProspId, Int64 CreatedById)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_SetAllocatedDate");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultantId", DbType.Int64, ConsultantId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspId", DbType.Int64, ProspId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, CreatedById);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.SetAllocatedDate Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 9 Sep 2013
        /// Description: Set Allocated Date Time For Prospect Id In FC Lead Alocation
        /// </summary>
        /// <param name="ConsultantId"></param>
        /// <param name="ProspId"></param>
        /// <param name="CreatedById"></param>
        /// <returns></returns>
        public Int64 SetFAllocatedDate(Int64 ConsultantId, Int64 ProspId, Int64 CreatedById)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_SetFAllocatedDate");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultantId", DbType.Int64, ConsultantId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspId", DbType.Int64, ProspId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, CreatedById);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityDAO.SetAllocatedDate Error:" + ex.StackTrace);
                return 0;
            }
        }
        #endregion
    }
}
