using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Mechsoft.GeneralUtilities;
using log4net;
using Mechsoft.PFSales.BusinessEntity;

namespace Mechsoft.PFSales.DataAccess
{
    public class MasterDAO
    {
        #region Global Variables
        ILog logger = LogManager.GetLogger(typeof(MasterDAO));
        #endregion

        #region Methods

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 20 May 2013
        /// Description: Get All Professions
        /// </summary>
        /// <param name="profession"></param>
        /// <returns></returns>
        public DataTable GetAllProfessions(string profession)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllProfessions");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Proffessions", DbType.String, profession);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllProfessions Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 20 May 2013
        /// Description: Get All Roles
        /// </summary>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        public DataTable GetAllRoles(string RoleName)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllRoles");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "RoleName", DbType.String, RoleName);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllRoles Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 20 May 2013
        /// Description: Get All Counrtries.
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        public DataTable GetAllCountry(string countryName)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllCountry");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CountryName", DbType.String, countryName);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllCountry Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 20 May 2013
        /// Description: Get All States.
        /// </summary>
        /// <param name="StateName"></param>
        /// <param name="CountryId"></param>
        /// <returns></returns>
        public DataTable GetAllState(string StateName, Int64 CountryId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllStates");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StateName", DbType.String, StateName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CountryId", DbType.Int64, CountryId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllState Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 20 May 2013
        /// Description: Get All Cities.
        /// </summary>
        /// <param name="CityName"></param>
        /// <param name="StateId"></param>
        /// <returns></returns>
        public DataTable GetAllCity(string CityName, Int64 StateId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllCities");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CityName", DbType.String, CityName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StateId", DbType.Int64, StateId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllCity Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 20 May 2013
        /// Description: Get All Designations
        /// </summary>
        /// <param name="Designation"></param>
        /// <returns></returns>
        public DataTable GetAllDesignations(string Designation)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllDesignations");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Designation", DbType.String, Designation);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllDesignations Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 21 May 2013
        /// Description: Get All Formats
        /// </summary>
        /// <param name="Designation"></param>
        /// <returns></returns>
        public DataTable GetAllFormats(Int64 CountryId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllFormats");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CountryId", DbType.Int64, CountryId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllFormats Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:21 May 2013
        /// Description: Get All Virtual Persons
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable GetAllVirtualPersons(Int64 RoleId, string userName)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetVirtualPersons");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "UserName", DbType.String, userName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "RoleId", DbType.Int64, RoleId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllVirtualPersons Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:22 May 2013
        /// Description: Get User Id From Virtual RoleId
        /// </summary>
        /// <param name="VRId"></param>
        /// <returns></returns>
        public DataTable GetUserIdFromVRId(Int64 VRId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetUserIdFromVRId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "VRId", DbType.Int64, VRId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetUserIdFromVRId Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 May 2013
        /// Description: Get All Makes
        /// </summary>
        /// <param name="Make"></param>
        /// <returns></returns>
        public DataTable GetAllMakes(string Make)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllMakes");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Make", DbType.String, Make);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllMakes Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:23 May 2013
        /// Description: Get All Statuses
        /// </summary>
        /// <param name="EntityId"></param>
        /// <param name="ProcessId"></param>
        /// <returns></returns>
        public DataTable GetAllStatus(Int16 EntityId, Int16 ProcessId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllStatuses");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "EntityId", DbType.Int16, EntityId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProcessId", DbType.Int16, ProcessId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllStatus Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:24 May 2013
        /// Description: Get All Reference Sources
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public DataTable GetAllSources(string Source)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllSources");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Source", DbType.String, Source);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllSources Error:" + ex.StackTrace);
                return null;
            }
        }


        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date:27 Oct 2014
        /// Description: Get All Reference Sources For Fc 
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public DataTable GetAllSourcesForFC(string Source)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllSourcesForFC");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Source", DbType.String, Source);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllSourcesForFC Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 27 May 2013
        /// Description: Get Menu According To Access
        /// </summary>
        /// <param name="ParentId"></param>
        /// <param name="RoleId"></param>
        /// <param name="AccessTypeId"></param>
        /// <returns></returns>
        public DataTable GetMenu(Int64 ParentId, Int64 RoleId, Int64 AccessTypeId)
        {
            DbCommand objCmd = null;
            DataTable DtWebPage = null;
            try
            {
                string strCulture = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "getMenuItem");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ParentId", DbType.Int64, ParentId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "RoleId", DbType.Int64, RoleId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "AccessTypeId", DbType.Int64, AccessTypeId);

                DtWebPage = Cls_DataAccess.getInstance().GetDataTable(objCmd);
                return DtWebPage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (DtWebPage != null)
                    DtWebPage = null;
            }
        }

        /// <summary>
        /// Method To check that whether the User have access to current webpage or not
        /// Created by - Pravin Gare. Date - 9 Apr 2013
        /// </summary>
        /// <param name="RoleID"></param>
        /// <param name="PageUrl"></param>
        /// <returns></returns>
        public DataSet CheckPageAccess(Int64 RoleID, String PageUrl)
        {
            DbCommand objCmd = null;
            DataSet Result = null;
            try
            {
                string strCulture = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "usp_checkPageAccess");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "RoleID", DbType.Int64, RoleID);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageUrl", DbType.String, PageUrl);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CULTURE", DbType.String, strCulture);
                Result = Cls_DataAccess.getInstance().GetDataSet(objCmd);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objCmd != null)
                    objCmd.Dispose();
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:30 May 2013
        /// Description: Get City Details From City Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable GetCityDetFromId(Int64 Id)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetCityDetFromId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, Id);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetCityDetFromId Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 7 June 2013
        /// Description: Get Cities From Postal Code
        /// </summary>
        /// <param name="PCode"></param>
        /// <returns></returns>
        public DataTable GetAllCitiesFromPCode(string PCode)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllCitiesFromPCode");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Pcode", DbType.String, PCode);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllCitiesFromPCode Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 10 June 2013
        /// Description: Add Prospects Source Details
        /// </summary>
        /// <param name="objMaster"></param>
        /// <returns></returns>
        public Int64 AddProsSource(clsMaster objMaster)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddProsSource");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int32, objMaster.ProspSourceId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "RefSource", DbType.String, objMaster.ProspSource);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "RDescription", DbType.String, objMaster.Desc);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsFleetTeamLead", DbType.Boolean, objMaster.IsFleetLead);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objMaster.CreatedById);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterDAO.AddProsSource Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 10 June 2013
        /// Description: Update Prospects Source Details
        /// </summary>
        /// <param name="objMaster"></param>
        /// <returns></returns>
        public Int64 UpdateProsSource(clsMaster objMaster)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateProsSource");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int32, objMaster.ProspSourceId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "RefSource", DbType.String, objMaster.ProspSource);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "RDescription", DbType.String, objMaster.Desc);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsFleetTeamLead", DbType.Boolean, objMaster.IsFleetLead);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objMaster.CreatedById);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterDAO.UpdateProsSource Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 10 June 2013
        /// Description: Delete Prospects Source Details
        /// </summary>
        /// <param name="objMaster"></param>
        /// <returns></returns>
        public Int64 DeleteProspSource(clsMaster objMaster)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_DeleteProspSource");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int32, objMaster.ProspSourceId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objMaster.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objMaster.IsDeleted);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterDAO.DeleteProspSource Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:10 June 2013
        /// Description: Get Prospect Source Details From Id
        /// </summary>
        /// <param name="PSId"></param>
        /// <returns></returns>
        public DataTable GetProspSrcDetFromId(Int32 PSId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetProspSrcDetFromId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int32, PSId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetProspSrcDetFromId Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 10 June 2013
        /// Description: Get All Prospect Source
        /// </summary>
        /// <param name="PrSource"></param>
        /// <returns></returns>
        public DataTable GetAllProspectSource(string PrSource)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllProspectSource");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PrSource", DbType.String, PrSource);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllProspectSource Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 14 June 2013
        /// Description: Get All Finance
        /// </summary>
        /// <param name="Finance"></param>
        /// <returns></returns>
        public DataTable GetAllFinance(string Finance)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllFinance");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Finance", DbType.String, Finance);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllFinance Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:17 June 2013
        /// Description: Get Finance Details From Id
        /// </summary>
        /// <param name="FSId"></param>
        /// <returns></returns>
        public DataTable GetFinanceDetFromId(Int32 FSId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetFinanceDetFromId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int32, FSId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetFinanceDetFromId Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 17 June 2013
        /// Description: Delete Finance Details
        /// </summary>
        /// <param name="objMaster"></param>
        /// <returns></returns>
        public Int64 DeleteFinance(clsMaster objMaster)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_DeleteFinance");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int32, objMaster.FinanceId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objMaster.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objMaster.IsDeleted);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterDAO.DeleteFinance Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 17 June 2013
        /// Description: Add Finance Details
        /// </summary>
        /// <param name="objMaster"></param>
        /// <returns></returns>
        public Int64 AddFinance(clsMaster objMaster)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddFinance");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int32, objMaster.FinanceId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Finance", DbType.String, objMaster.Finance);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FDescription", DbType.String, objMaster.Desc);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objMaster.CreatedById);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterDAO.AddFinance Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 17 June 2013
        /// Description: Update Finance Details
        /// </summary>
        /// <param name="objMaster"></param>
        /// <returns></returns>
        public Int64 UpdateFinance(clsMaster objMaster)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateFinance");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int32, objMaster.FinanceId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Finance", DbType.String, objMaster.Finance);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FDescription", DbType.String, objMaster.Desc);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objMaster.CreatedById);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterDAO.UpdateFinance Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 18 June 2013
        /// Description: Get All Activity Types
        /// </summary>
        /// <param name="ActivityType"></param>
        /// <returns></returns>
        public DataTable GetAllActivityTypes(string ActivityType)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllActivityTypes");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, ActivityType);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllActivityTypes Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 18 June 2013
        /// Description: Get All Regardings
        /// </summary>
        /// <param name="Regarding"></param>
        /// <returns></returns>
        public DataTable GetAllRegardings(string Regarding, Int16 ActivityTypeId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllRegardings");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, Regarding);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActivityTypeId", DbType.Int16, ActivityTypeId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllRegardings Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 18 June 2013
        /// Description: Get All Activity Priorities
        /// </summary>
        /// <param name="ActPriority"></param>
        /// <returns></returns>
        public DataTable GetAllActPriorities(string ActPriority)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllActPriorities");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, ActPriority);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllActPriorities Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 5 July 2013
        /// Description: Get All Roles
        /// </summary>
        /// <param name="objRole"></param>
        /// <returns></returns>
        public DataTable GetRoleList(Roles objRole)
        {
            DbCommand objCmd = null;
            DataTable dtRoleList = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "Acu_GetAllRoles");
                if (objRole.RoleId > 0)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "RoleId", DbType.Int32, objRole.RoleId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "RoleName", DbType.String, objRole.RoleName);
                dtRoleList = Cls_DataAccess.getInstance().GetDataTable(objCmd);
                return dtRoleList;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetRoleList Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 5 July 2013
        /// Description: Add/ Update/ Delete Roles
        /// </summary>
        /// <param name="objRole"></param>
        /// <returns></returns>
        public Int64 AddUpdateRoles(Roles objRole)
        {
            Int64 Result = 0;
            try
            {
                DbCommand objcmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "Acu_AddUpdateRoleDetails");
                Cls_DataAccess.getInstance().AddInParameter(objcmd, "Id", DbType.Int64, objRole.Id);
                Cls_DataAccess.getInstance().AddInParameter(objcmd, "RoleName", DbType.String, objRole.RoleName);
                Cls_DataAccess.getInstance().AddInParameter(objcmd, "Description", DbType.String, objRole.Description);
                Cls_DataAccess.getInstance().AddInParameter(objcmd, "IsActive", DbType.Boolean, objRole.IsActive);
                Cls_DataAccess.getInstance().AddInParameter(objcmd, "CreatedById", DbType.Int64, objRole.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objcmd, "IsDeleted", DbType.Boolean, objRole.IsDeleted);
                Cls_DataAccess.getInstance().AddInParameter(objcmd, "Code", DbType.String, objRole.Code);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objcmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.AddUpdateRoles Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:19 July 2013
        /// Description: Get Model Details From Make Id
        /// </summary>
        /// <param name="MakeId"></param>
        /// <returns></returns>
        public DataTable GetModelFromMakeId(Int32 MakeId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetModelFromMakeId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MakeId", DbType.Int32, MakeId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetModelFromMakeId Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:23 July 2013
        /// Description: Get Where Did You Hear About Values From Id
        /// </summary>
        /// <param name="WUHId"></param>
        /// <returns></returns>
        public DataTable GetWUHFromId(Int32 WUHId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetWUHFromId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int32, WUHId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetWUHFromId Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 July 2013
        /// Description: For Updation of Where You Hear About PF Data
        /// </summary>
        /// <param name="objMaster"></param>
        /// <returns></returns>
        public Int64 DeleteWUHDetails(clsMaster objMaster)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_DeleteWUHDetails");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int32, objMaster.WUHId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objMaster.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objMaster.IsDeleted);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterDAO.DeleteProspSource Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 July 2013
        /// Description: For Addition of Where Did You Hear About PF 
        /// </summary>
        /// <param name="objMaster"></param>
        /// <returns></returns>
        public Int64 AddWUHDetails(clsMaster objMaster)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddWUHDetails");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int32, objMaster.WUHId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ValueforAnswer", DbType.String, objMaster.ValueforAnswer);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActiveFromDate", DbType.DateTime, objMaster.FromDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActiveToDate", DbType.DateTime, objMaster.ToDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsFleetLead", DbType.Boolean, objMaster.IsFleetLead);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objMaster.CreatedById);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterDAO.AddWUHDetails Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 July 2013
        /// Description: For Updation of Where Did You Hear About PF's Data
        /// </summary>
        /// <param name="objMaster"></param>
        /// <returns></returns>
        public Int64 UpdateWUHDetails(clsMaster objMaster)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateWUHDetails");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int32, objMaster.WUHId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ValueforAnswer", DbType.String, objMaster.ValueforAnswer);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActiveFromDate", DbType.DateTime, objMaster.FromDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActiveToDate", DbType.DateTime, objMaster.ToDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsFleetLead", DbType.Boolean, objMaster.IsFleetLead);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objMaster.CreatedById);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterDAO.UpdateWUHDetails Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 July 2013
        /// Description: Get All Where You Hear About PF Values
        /// </summary>
        /// <param name="WHUValue"></param>
        /// <returns></returns>
        public DataTable GetAllWUHValues(string WHUValue)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllWUHValues");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "WHUValue", DbType.String, WHUValue);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllWUHValues Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:24 July 2013
        /// Description: To Get Details Of Consultant From virtual Role Id
        /// </summary>
        /// <param name="VirtualRoleId"></param>
        /// <returns></returns>
        public DataTable ConsultDetailsFromId(Int64 VirtualRoleId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_ConsultDetailsFromId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "VirtualRoleId", DbType.Int64, VirtualRoleId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.ConsultDetailsFromId Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:21 Aug 2013
        /// Description: To Get Count Of Duplicate Emails
        /// </summary>
        /// <param name="EmailId"></param>
        /// <param name="Flag"></param>
        /// <returns></returns>
        public int CheckDuplicateEmail(string EmailId, string Flag)
        {
            DbCommand objCmd = null;
            int Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_CheckDuplicateEmail");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email", DbType.String, EmailId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Flag", DbType.String, Flag);
                Result = Convert.ToInt32(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterDAO.DeleteProspSource Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:21 Aug 2013
        /// Description: To Get Difference of duplicate lead entry in hours
        /// </summary>
        /// <param name="EmailId"></param>
        /// <returns></returns>
        public Int64 CheckDuplicateFor24hrs(string EmailId)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_CheckDuplicateFor24hrs");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email", DbType.String, EmailId);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterDAO.CheckDuplicateFor24hrs Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:21 Aug 2013
        /// Description: To Get Difference of duplicate lead entry in hours
        /// </summary>
        /// <param name="EmailId"></param>
        /// <returns></returns>
        public DataSet GetDupLeadsDetailsForNoti(string EmailId, Int64 LeadId)
        {
            DbCommand objCmd = null;
            DataSet DtResult = new DataSet();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetDupLeadsDetailsForNoti");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "LeadId", DbType.Int64, LeadId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email", DbType.String, EmailId);
                DtResult = Cls_DataAccess.getInstance().GetDataSet(objCmd);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetDupLeadsDetailsForNoti Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:15 Sep 2013
        /// Description: Get Finance Request Came From List
        /// </summary>
        /// <returns></returns>
        public DataTable GetFinReqFrom()
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetFinReqFrom");
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetFinReqFrom Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 16 Oct 2013
        /// Description: Get All Cities.
        /// </summary>
        /// <param name="CityName"></param>
        /// <param name="StateId"></param>
        /// <returns></returns>
        public DataTable GetAllPCodes(string CityName, Int64 StateId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllPCodes");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Pcode", DbType.String, CityName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StateId", DbType.Int64, StateId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllPCodes Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:29 Aug 2013
        /// Description: To Save Email Send Details
        /// </summary>
        /// <param name="EmailId"></param>
        /// <returns></returns>
        public Int64 SaveEmailDetails(string EmailTo, string EmailFromID, string EmailText, string Status, string Subject, string PageName)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_SendEmailDetails");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Subject", DbType.String, Subject);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "EmailTo", DbType.String, EmailTo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "EmailFromID", DbType.String, EmailFromID);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "EmailText", DbType.String, EmailText);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Status", DbType.String, Status);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageName", DbType.String, PageName);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterDAO.SaveEmailDetails Error:" + ex.StackTrace);
                return 0;
            }
        }


        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 24 Sept 2014
        /// Description: Add City Details
        /// </summary>
        /// <param name="objCity"></param>
        /// <returns></returns>
        public Int64 AddCity(City objCity)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddCity");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StateID", DbType.Int32, objCity.StateId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PCode", DbType.String, objCity.PCode);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Suburb", DbType.String, objCity.Suburb);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objCity.IsDeleted);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objCity.CreatedById);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterDAO.AddCity Error:" + ex.StackTrace);
                return 0;
            }
        }


        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 09 Oct 2014
        /// Description: Add ReSource Details
        /// </summary>
        /// <param name="objMaster"></param>
        /// <returns></returns>
        public Int64 AddResource(clsResource objResource)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddResource");
               // Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objResource.ResourceId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ReDocName", DbType.String, objResource.Resource);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ReDocDesc", DbType.String, objResource.Desc);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ReDocPath", DbType.String, objResource.ResourcePath);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ReDocFor", DbType.String, objResource.ReDocFor);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objResource.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActive", DbType.Boolean, objResource.IsActive);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objResource.IsDeleted);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterDAO.AddResource Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 09 Oct 2014
        /// Description: Update ReSource Details
        /// </summary>
        /// <param name="objMaster"></param>
        /// <returns></returns>
        public Int64 UpdateReource(clsResource objResource)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateResource");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objResource.ResourceId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ReDocName", DbType.String, objResource.Resource);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ReDocDesc", DbType.String, objResource.Desc);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ReDocFor", DbType.String, objResource.ReDocFor);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActive", DbType.Boolean, objResource.IsActive);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objResource.IsDeleted);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ModifiedById", DbType.Int64, objResource.ModifiedById);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterDAO.UpdateReource Error:" + ex.StackTrace);
                return 0;
            }
        }


        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 09 Oct 2014
        /// Description: Delete ReSource Details
        /// </summary>
        /// <param name="objMaster"></param>
        /// <returns></returns>
        public Int64 DeleteResource(clsResource objResource)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_DeleteResource");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objResource.ResourceId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objResource.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objResource.IsDeleted);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterDAO.DeleteResource Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 09 Oct All ReSources
        /// </summary>
        /// <param name="PrSource"></param>
        /// <returns></returns>
        public DataTable GetAllResource(string Resource)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllResource");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Resource", DbType.String, Resource);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetAllProspectSource Error:" + ex.StackTrace);
                return null;
            }
        }


        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date:10 Oct 2014
        /// Description: Get ReSource Details From Id
        /// </summary>
        /// <param name="PSId"></param>
        /// <returns></returns>
        public DataTable GetResrcDetFromId(Int64 PSId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetResourceDetFromId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, PSId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MastedDAO.GetResrcDetFromId Error:" + ex.StackTrace);
                return null;
            }
        }

        #endregion
    }
}
