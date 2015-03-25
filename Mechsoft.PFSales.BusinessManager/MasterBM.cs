using System;
using System.Collections.Generic;
using Mechsoft.PFSales.DataAccess;
using System.Linq;
using System.Text;
using log4net;
using System.Data;
using Mechsoft.PFSales.BusinessEntity;

namespace Mechsoft.PFSales.BusinessManager
{
    public partial class MasterBM
    {

        #region Global Variables
        ILog logger = LogManager.GetLogger(typeof(MasterBM));
        MasterDAO objMstDAO = new MasterDAO();
        #endregion

        #region Methods
        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 20 May 2013
        /// Description: Get All Professions
        /// </summary>
        /// <param name="professions"></param>
        /// <returns></returns>
        public DataTable GetAllProfessions(string professions)
        {
            try
            {
                return objMstDAO.GetAllProfessions(professions);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllProfessions. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.GetAllRoles(RoleName);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllRoles. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 20 May 2013
        /// Description: Get All Country
        /// </summary>
        /// <param name="CountryName"></param>
        /// <returns></returns>
        public DataTable GetAllCountry(string CountryName)
        {
            try
            {
                return objMstDAO.GetAllCountry(CountryName);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllCountry. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 20 May 2013
        /// Description: Get All States
        /// </summary>
        /// <param name="StateName"></param>
        /// <param name="CountryId"></param>
        /// <returns></returns>
        public DataTable GetAllState(string StateName, Int64 CountryId)
        {
            try
            {
                return objMstDAO.GetAllState(StateName, CountryId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllState. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 20 May 2013
        /// Description: Get All Cities
        /// </summary>
        /// <param name="CityName"></param>
        /// <param name="StateId"></param>
        /// <returns></returns>
        public DataTable GetAllCity(string CityName, Int64 StateId)
        {
            try
            {
                return objMstDAO.GetAllCity(CityName, StateId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllCity. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.GetAllDesignations(Designation);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllDesignations. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 21 May 2013
        /// Description: Get All Farmats
        /// </summary>
        /// <param name="CountryId"></param>
        /// <returns></returns>
        public DataTable GetAllFormats(Int64 CountryId)
        {
            try
            {
                return objMstDAO.GetAllFormats(CountryId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllFormats. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 21 May 2013
        /// Description: Get All Farmats
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable GetAllVirtualPersons(Int64 RoleId, string userName)
        {
            try
            {
                return objMstDAO.GetAllVirtualPersons(RoleId, userName);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllVirtualPersons. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:22 May 2013
        /// Description: Get User Id From Virtual RoleId
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable GetUserIdFromVRId(Int64 VRId)
        {
            try
            {
                return objMstDAO.GetUserIdFromVRId(VRId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetUserIdFromVRId. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 20 May 2013
        /// Description: Get All Makes
        /// </summary>
        /// <param name="Make"></param>
        /// <returns></returns>
        public DataTable GetAllMakes(string Make)
        {
            try
            {
                return objMstDAO.GetAllMakes(Make);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllMakes. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.GetAllStatus(EntityId, ProcessId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllStatus Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.GetAllSources(Source);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllSources Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date:27 Oct 2014
        /// Description: Get All Reference Sources for FC
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public DataTable GetAllSourcesForFC(string Source)
        {
            try
            {
                return objMstDAO.GetAllSourcesForFC(Source);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllSourcesForFC Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.GetMenu(ParentId, RoleId, AccessTypeId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetMenu Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 29 May 2013
        /// Description: Get City Details From City Id
        /// </summary>
        /// <param name="RoleID"></param>
        /// <param name="PageUrl"></param>
        /// <returns></returns>
        public DataSet CheckPageAccess(Int64 RoleID, String PageUrl)
        {
            return objMstDAO.CheckPageAccess(RoleID, PageUrl);
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:30 May 2013
        /// Description: Get City Details From City Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable GetCityDetFromId(Int64 VRId)
        {
            try
            {
                return objMstDAO.GetCityDetFromId(VRId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetCityDetFromId. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.GetAllCitiesFromPCode(PCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllCitiesFromPCode. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.AddProsSource(objMaster);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.AddProsSource. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.UpdateProsSource(objMaster);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.UpdateProsSource. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.DeleteProspSource(objMaster);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.DeleteProspSource. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.GetProspSrcDetFromId(PSId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetProspSrcDetFromId. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.GetAllProspectSource(PrSource);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllProspectSource. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.GetAllFinance(Finance);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllFinance. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.GetFinanceDetFromId(FSId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetFinanceDetFromId. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.DeleteFinance(objMaster);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.DeleteFinance. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.AddFinance(objMaster);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.AddFinance. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.UpdateFinance(objMaster);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.UpdateFinance. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 18 June 2013
        /// Description: Get Activity Types
        /// </summary>
        /// <param name="ActivityType"></param>
        /// <returns></returns>
        public DataTable GetAllActivityTypes(string ActivityType)
        {
            try
            {
                return objMstDAO.GetAllActivityTypes(ActivityType);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllActivityTypes. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.GetAllRegardings(Regarding, ActivityTypeId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllRegardings. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.GetAllActPriorities(ActPriority);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllActPriorities. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.GetRoleList(objRole);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetRoleList. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.AddUpdateRoles(objRole);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.AddUpdateRoles. Error:" + ex.StackTrace);
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

            try
            {
                return objMstDAO.GetModelFromMakeId(MakeId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetModelFromMakeId Error:" + ex.StackTrace);
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

            try
            {
                return objMstDAO.GetWUHFromId(WUHId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetWUHFromId Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.DeleteWUHDetails(objMaster);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.DeleteWUHDetails. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.AddWUHDetails(objMaster);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.AddWUHDetails. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.UpdateWUHDetails(objMaster);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.UpdateWUHDetails. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.GetAllWUHValues(WHUValue);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllWUHValues. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.ConsultDetailsFromId(VirtualRoleId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.ConsultDetailsFromId. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.CheckDuplicateEmail(EmailId, Flag);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.CheckDuplicateEmail. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:21 Aug 2013
        /// Description: To Get Count Of Duplicate Emails
        /// </summary>
        /// <param name="EmailId"></param>
        /// <returns></returns>
        public Int64 CheckDuplicateFor24hrs(string EmailId)
        {
            try
            {
                return objMstDAO.CheckDuplicateFor24hrs(EmailId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.CheckDuplicateFor24hrs. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.GetDupLeadsDetailsForNoti(EmailId, LeadId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetDupLeadsDetailsForNoti. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.GetFinReqFrom();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetFinReqFrom Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 16 Oct 2013
        /// Description: Get All PCodes
        /// </summary>
        /// <param name="CityName"></param>
        /// <param name="StateId"></param>
        /// <returns></returns>
        public DataTable GetAllPCodes(string CityName, Int64 StateId)
        {
            try
            {
                return objMstDAO.GetAllPCodes(CityName, StateId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllPCodes. Error:" + ex.StackTrace);
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

            try
            {
                return objMstDAO.SaveEmailDetails(EmailTo, EmailFromID, EmailText, Status, Subject, PageName);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GeSaveEmailDetailstAllPCodes. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.AddCity(objCity);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.AddCity. Error:" + ex.StackTrace);
                return 0;
            }
        }


        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 09 Oct 2014
        /// Description: Add Resource Details
        /// </summary>
        /// <param name="objMaster"></param>
        /// <returns></returns>
        public Int64 AddResource(clsResource objResource)
        {
            try
            {
                return objMstDAO.AddResource(objResource);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.AddResource. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.UpdateReource(objResource);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.UpdateReource. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.DeleteResource(objResource);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.DeleteResource. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 10 June 2013
        /// Description: Get All ReSources
        /// </summary>
        /// <param name="PrSource"></param>
        /// <returns></returns>
        public DataTable GetAllResource(string Resource)
        {
            try
            {
                return objMstDAO.GetAllResource(Resource);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetAllResource. Error:" + ex.StackTrace);
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
            try
            {
                return objMstDAO.GetResrcDetFromId(PSId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "MasterBM.GetResrcDetFromId. Error:" + ex.StackTrace);
                return null;
            }
        }


        #endregion
    }
}
