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
    public class ActivityBM
    {
        #region Global Variables
        ILog logger = LogManager.GetLogger(typeof(ActivityBM));
        ActivityDAO objActDAO = new ActivityDAO();
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
            try
            {
                return objActDAO.AddActivity(objActivity);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.AddActivity Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.GetNotifications(virtualRoleId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetNotifications Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.GetTodaysActivity(virtualRoleId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetTodaysActivity Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.GetProspDetFromDash(objProsp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetProspDetFromDash Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.GetMyAlerts(objActivity);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetMyAlerts Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.UpdateAlertStatus(AlertId, UserId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.UpdateAlertStatus Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.GetEmpDetFromIdForAlert(Ids);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetEmpDetFromIdForAlert Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 24 June 2013
        /// Description: Get All Activities For Consultant
        /// </summary>
        /// <param name="virtualRoleId"></param>
        /// <returns></returns>
        public DataTable GetMyActivities(Int64 virtualRoleId)
        {
            try
            {
                return objActDAO.GetMyActivities(virtualRoleId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetMyActivities Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.GetActivityDetFromId(AlertId, UserId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetActivityDetFromId Error:" + ex.StackTrace);
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
        public DataTable GetActivityAlertDetailsFromId(Int64 AlertId, Int64 UserId)
        {
            try
            {
                return objActDAO.GetActivityAlertDetailsFromId(AlertId, UserId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetActivityAlertDetailsFromId Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.UpdateActivity(objActivity);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.UpdateActivity Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.GetAllConsultForActivity(FName, ActivityId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetAllConsultForActivity Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.GetActivityOfProspect(ProspectId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetActivityOfProspect Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.AddClearActivity(objActivity);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.AddClearActivity Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.GetAdminNotifications();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetAdminNotifications Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.GetTodaysAdminActivity();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetTodaysAdminActivity Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.GetProspIdForTodayAct(ActivityTypeId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetProspIdForTodayAct Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.GetDetailsOfActivity(ActivityId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetDetailsOfActivity Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.GetUpcomingSchedular(UserVirtualId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetUpcomingSchedular Error:" + ex.StackTrace);
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
        /// <param name="Status"></param>
        /// <returns></returns>
        public Int64 AddContactNotes(Int64 ContactId, string Notes, Int64 CreatedById, Boolean IsDeleted, Int32 ActivityStatus, Int64 ActivityId, Int32 Status)
        {
            try
            {
                return objActDAO.AddContactNotes(ContactId, Notes, CreatedById, IsDeleted, ActivityStatus, ActivityId, Status);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.AddContactNotes Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.UpdateContactNotes(Id, ContactId, Notes, CreatedById, IsDeleted, ActivityStatus, ActivityId, Status);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.UpdateContactNotes Error:" + ex.StackTrace);
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
        public DataTable GetAllContactNotes(Int64 ProspectId, Int64 VirtualRoleId)
        {
            try
            {
                return objActDAO.GetAllContactNotes(ProspectId, VirtualRoleId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetAllContactNotes Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.GetMinDateForFutureAct(ProspectId, VirtualRoleId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetMinDateForFutureAct Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.GetCountOfActForStime(UserVirtualId, SDateTime);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetCountOfActForStime Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.GetContactNotesFromId(Id);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.GetContactNotesFromId Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.SetAllocatedDate(ConsultantId, ProspId, CreatedById);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.SetAllocatedDate Error:" + ex.StackTrace);
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
            try
            {
                return objActDAO.SetFAllocatedDate(ConsultantId, ProspId, CreatedById);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ActivityBM.SetFAllocatedDate Error:" + ex.StackTrace);
                return 0;
            }
        }
        #endregion
    }
}
