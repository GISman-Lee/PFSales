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
    public class ProspectBM
    {
        #region Global Variables
        ILog logger = LogManager.GetLogger(typeof(ProspectBM));
        ProspectsDAO objProspDAO = new ProspectsDAO();
        #endregion

        #region Methods
        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 May 2013
        /// Description: Add Prospects
        /// </summary>
        /// <param name="ObjEmp"></param>
        /// <returns></returns>
        public Int64 AddProspect(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.AddProspect(ObjProsp);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.AddProspect. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 18 Feb 2014
        /// Description: Add Trade In
        /// </summary>
        /// <param name="ObjEmp"></param>
        /// <returns></returns>
        public Int64 AddTradeIn(TradeIn  ObjTradeIn)
        {
            try
            {
                return objProspDAO.AddTradeIn(ObjTradeIn);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.AddTradeIn. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 21 Feb 2014
        /// Description: Update Trade In
        /// </summary>
        /// <param name="ObjEmp"></param>
        /// <returns></returns>
        public Int64 UpdateTradeIn(TradeIn ObjTradeIn)
        {
            try
            {
                return objProspDAO.UpdateTradeIn(ObjTradeIn);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.AddTradeIn. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 20 Feb 2014
        /// Description: Get Total TradeIn Count Of Prospect
        /// </summary>
        /// <param name="ProspectId"></param>
        /// <returns></returns>
        public DataTable GetTradeInCount(Int64 ProspectId)
        {
            try
            {
                return objProspDAO.GetTradeInCount(ProspectId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetTradeInCount. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 20 Feb 2014
        /// Description: Get All Trade in of Prospect
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable GetAllTradeInProspect(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.GetAllTradeInProspect(ObjProsp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetAllTradeInProspect. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 19 Feb 2014
        /// Description: Add Prospect & Trade In
        /// </summary>
        /// <param name="ObjEmp"></param>
        /// <returns></returns>
        public Int64 AddProspectTradeIn(Prospect ObjProsp,TradeIn ObjTradeIn)
        {
            try
            {
                return objProspDAO.AddProspectTradeIn(ObjProsp,ObjTradeIn);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.AddProspectTradeIn. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 20 Feb 2014
        /// Description: Get All Trade in of Prospect
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable GetTradeInFromId(Int64 TradeInId)
        {
            try
            {
                return objProspDAO.GetTradeInFromId(TradeInId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetTradeInFromId. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 May 2013
        /// Description: Update Prospects
        /// </summary>
        /// <param name="ObjEmp"></param>
        /// <returns></returns>
        public Int64 UpdateProspect(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.UpdateProspect(ObjProsp);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.UpdateProspect. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 May 2013
        /// Description: Delete Prospects
        /// </summary>
        /// <param name="ObjEmp"></param>
        /// <returns></returns>
        public Int64 DeleteProspect(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.DeleteProspect(ObjProsp);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.DeleteProspect. Error:" + ex.StackTrace);
                return 0;
            }
        }

        ///// <summary>
        ///// Created By: Pravin Gholap
        ///// Created Date: 23 May 2013
        ///// Description: Get All Prospects
        ///// </summary>
        ///// <param name="objProsp"></param>
        ///// <returns></returns>
        //public DataTable GetAllProspects(Prospect ObjProsp)
        //{
        //    try
        //    {
        //        return objProspDAO.GetAllProspects(ObjProsp);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex.Message + "ProspectBM.GetAllProspects. Error:" + ex.StackTrace);
        //        return null;
        //    }
        //}


        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 May 2013
        /// Description: Get All Prospects
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataSet GetAllProspects(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.GetAllProspects(ObjProsp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetAllProspects. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Chetan Shejole
        /// Created Date: 26 Sep 2014
        /// Description: Get All Prospects to bind dropdown
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataSet GetAllProspects_BindDrop(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.GetAllProspects_BindDrop(ObjProsp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetAllProspects_BindDrop. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 May 2013
        /// Description: Get Prospect Details From Prospect Id
        /// </summary>
        /// <param name="ProspId"></param>
        /// <returns></returns>
        public DataTable GetProspectsFromId(Int64 ProspId)
        {
            try
            {
                return objProspDAO.GetProspectsFromId(ProspId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetProspectsFromId. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 24 May 2013
        /// Description: Get Prospect Contact Details From Prospect Id
        /// </summary>
        /// <param name="ProspId"></param>
        /// <returns></returns>
        public DataTable GetProspConDetailFromProspId(Int64 ProspId)
        {
            try
            {
                return objProspDAO.GetProspConDetailFromProspId(ProspId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetProspConDetailFromProspId. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 30 May 2013
        /// Description: Add Prospects Details From Service
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Int64 AddProspectFromServ(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.AddProspectFromServ(ObjProsp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.AddProspectFromServ. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 3 June 2013
        /// Description: Get Total Enquiry Count From Date Range
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public DataTable GetTotalLeadCount(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                return objProspDAO.GetTotalLeadCount(FromDate, ToDate);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetTotalLeadCount. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 3 June 2013
        /// Description: Get Total Unallocated Enquiry Count From Date Range
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public DataTable GetUnAlocatedEnqCount(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                return objProspDAO.GetUnAlocatedEnqCount(FromDate, ToDate);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetUnAlocatedEnqCount. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 3 June 2013
        /// Description: Get Oldest Enquiry Date
        /// </summary>
        public DataTable GetOldestEnquiryDate()
        {
            try
            {
                return objProspDAO.GetOldestEnquiryDate();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetOldestEnquiryDate. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 3 June 2013
        /// Description: Assign Leads To Consultant In Bulk
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable AssignLeadsToConsultant(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.AssignLeadsToConsultant(ObjProsp);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.AssignLeadsToConsultant. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 4 June 2013
        /// Description: Get Unallocated Enquiry Details
        /// </summary>
        public DataTable GetUnalocatedProspDet(DateTime FromDate, DateTime ToDate, string Flag, Int64 ConsultantId, string FCFlag)
        {
            try
            {
                return objProspDAO.GetUnalocatedProspDet(FromDate, ToDate, Flag, ConsultantId, FCFlag);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetUnalocatedProspDet. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 4 June 2013
        /// Description: Get Prospects Details which are assigned to given consultant
        /// <param name="VirtualRoleId"></param>
        /// </summary>
        public DataTable GetProspDetAssignedToConsult(Int64 VirtualRoleId, DateTime FromDate, DateTime ToDate, Int64 ProspectId)
        {
            try
            {
                return objProspDAO.GetProspDetAssignedToConsult(VirtualRoleId, FromDate, ToDate, ProspectId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetProspDetAssignedToConsult. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 10 June 2013
        /// Description: Get All Prospects For Consult View
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataSet GetAllProspForConsult(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.GetAllProspForConsult(ObjProsp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetAllProspForConsult. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 July 2013
        /// Description: Update Prospect's Is Mail Sent's Field's Status
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="CreatedById"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public Int64 UpdateOneTimeMailStatus(Int64 Id, Int64 CreatedById, Boolean Status, string mailContent, Boolean MailSuccess)
        {
            try
            {
                return objProspDAO.UpdateOneTimeMailStatus(Id, CreatedById, Status, mailContent, MailSuccess);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.UpdateOneTimeMailStatus. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 24 July 2013
        /// Description: Get All Fleet Team Leads For Assignments
        /// </summary>
        /// <returns></returns>
        public DataTable GetTeamLeadsForAssignments()
        {
            try
            {
                return objProspDAO.GetTeamLeadsForAssignments();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetTeamLeadsForAssignments. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 24 July 2013
        /// Description: To Get Fleet Team Lead Consultant To Assign
        /// </summary>
        /// <returns></returns>
        public DataTable GetTeamLeadConsultToAssign()
        {
            try
            {
                return objProspDAO.GetTeamLeadConsultToAssign();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetTeamLeadConsultToAssign. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 24 June 2013
        /// Description: Assign Fleet Team Leads To Consultant
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable AssignFleetTeamLeads(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.AssignFleetTeamLeads(ObjProsp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.AssignFleetTeamLeads. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 5 Aug 2013
        /// Description: Remove Prospect Details From Allocation 
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public Int64 RemoveFromAllocation(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.RemoveFromAllocation(ObjProsp);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.RemoveFromAllocation. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Manoj Mahagaonkar
        /// Created Date: 10 Aug 2013
        /// Description: Allocate lead to consultant through Clain Process
        /// </summary>
        /// <param name="ObjEmp"></param>
        /// <returns></returns>
        public Int64 AllocateLeadThroughClaim(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.AllocateLeadThroughClaim(ObjProsp);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.AllocateLeadThroughClaim. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 18 Aug 2013
        /// Description: Allocate lead to consultant through Clain Process
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="FinConvienceNotes"></param>
        /// <param name="CreatedById"></param>
        /// <returns></returns>
        public Int64 SetFinanceRequired(Int64 Id, string FinConvienceNotes, Int64 CreatedById)
        {
            try
            {
                return objProspDAO.SetFinanceRequired(Id, FinConvienceNotes, CreatedById);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.SetFinanceRequired. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 17 Aug 2013
        /// Description: To Get FC's Fleet Team Lead Consultant To Assign
        /// </summary>
        /// <returns></returns>
        public DataTable GetFCTeamLeadConsultToAssign()
        {
            try
            {
                return objProspDAO.GetFCTeamLeadConsultToAssign();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetFCTeamLeadConsultToAssign. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 17 Aug 2013
        /// Description: Get All FC's Fleet Team Leads For Assignments
        /// </summary>
        /// <returns></returns>
        public DataTable GetFCTeamLeadsForAssignments()
        {
            try
            {
                return objProspDAO.GetFCTeamLeadsForAssignments();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetFCTeamLeadsForAssignments. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 17 Aug 2013
        /// Description: Get Total FC Enquiry Count From Date Range
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public DataTable GetFCTotalEnqCount(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                return objProspDAO.GetFCTotalEnqCount(FromDate, ToDate);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetFCTotalEnqCount. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 17 June 2013
        /// Description: Get Total Unallocated FC Enquiry Count From Date Range
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public DataTable GetFCUnAlocatedEnqCount(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                return objProspDAO.GetFCUnAlocatedEnqCount(FromDate, ToDate);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetFCUnAlocatedEnqCount. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 17 Aug 2013
        /// Description: Assign FC's Fleet Team Leads To Consultant
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable AssignFCFleetTeamLeads(Prospect objProsp)
        {
            try
            {
                return objProspDAO.AssignFCFleetTeamLeads(objProsp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.AssignFCFleetTeamLeads. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 17 Aug 2013
        /// Description: Get Prospects Details which are assigned to given FC consultant
        /// <param name="VirtualRoleId"></param>
        /// </summary>
        public DataTable GetFCProspDetAssignedToConsult(Int64 VirtualRoleId, DateTime FromDate, DateTime ToDate, Int64 ProspectId)
        {
            try
            {
                return objProspDAO.GetFCProspDetAssignedToConsult(VirtualRoleId, FromDate, ToDate, ProspectId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetFCProspDetAssignedToConsult. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 17 August 2013
        /// Description: Assign Leads To FC Consultant In Bulk
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable AssignLeadsToFCConsultant(Prospect objProsp)
        {
            try
            {
                return objProspDAO.AssignLeadsToFCConsultant(objProsp);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.AssignLeadsToFCConsultant. Error:" + ex.StackTrace);
                return null;
            }
        }

        public DataTable IsQuoteExist(Prospect prospect)
        {
            try
            {
                return objProspDAO.IsQuoteExist(prospect);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.IsQuoteExist. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 18 Aug 2013
        /// Description: Get Prospect's FC Details From Prospect Id
        /// </summary>
        /// <param name="ProspId"></param>
        /// <returns></returns>
        public DataTable GetProspFCDetFromProId(Int64 ProspId)
        {
            try
            {
                return objProspDAO.GetProspFCDetFromProId(ProspId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetProspFCDetFromProId. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Kalpana Shinde
        /// Created Date: 21 Aug 2013
        /// Description: Get all not yet called PF and FC
        /// </summary>
        public DataSet GetAllNYCForPFAndFC(DateTime FromDate, DateTime ToDate, Int64 ConsultantId, string FCFlag, string Flag, Int64 PageIndex, Int64 PageSize, string SortColumn)
        {
            try
            {
                return objProspDAO.GetAllNYCForPFAndFC(FromDate, ToDate, ConsultantId, FCFlag, Flag, PageIndex, PageSize, SortColumn);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetAllNYCForPFAndFC. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 27 Aug 2013
        /// Description: Add Prospects Details From Service From PrivateFleet.com.au
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public Int64 AddProspectsFromPFServ(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.AddProspectsFromPFServ(ObjProsp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.AddProspectsFromPFServ. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Kalpana Shinde
        /// Created Date: 29 Aug 2013
        /// Description: Get All Lead Details for View
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable GetProspectStats(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.GetProspectStats(ObjProsp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetProspectStats. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 2 Sept 2013
        /// Description: Save Details Of SMS Sending 
        /// </summary>
        /// <param name="SMSTo"></param>
        /// <param name="SMSText"></param>
        /// <param name="SMSFrom"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool sendSMS(string SMSTo, string SMSText, Int64 SMSFrom, string status)
        {
            try
            {
                return objProspDAO.sendSMS(SMSTo, SMSText, SMSFrom, status);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.sendSMS. Error:" + ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 3 Sept 2013
        /// Description: Get Value Of the Key from Config Table
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DataTable GetConfigValues(string key)
        {
            try
            {
                return objProspDAO.GetConfigValues(key);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetConfigValues. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 6 Sept 2013
        /// Description: Get NonSynchronized Data To Insert To Main Data Table Of Prospects
        /// </summary>
        /// <returns></returns>
        public DataTable GetLeadToCRMFromPF()
        {
            try
            {
                return objProspDAO.GetLeadToCRMFromPF();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetLeadToCRMFromPF. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 5 Sep 2013
        /// Description: Add Prospects Details From PrivateFleet.Com.Au
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Int64 AddProspectsFromPFToCRM(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.AddProspectsFromPFToCRM(ObjProsp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.AddProspectsFromPFToCRM. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 6 Sep 2013
        /// Description: For Updation of Synchroniztion Flag In Raw Data Table
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="IdFromPF"></param>
        /// <returns></returns>
        public Int64 UpdateIsSynchronized(string flag, Int64 IdFromPF)
        {
            try
            {
                return objProspDAO.UpdateIsSynchronized(flag, IdFromPF);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.UpdateIsSynchronized. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 13 Sept 2013
        /// Description: Add Prospects Details From Fincar
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public Int64 AddProspectsFromFinCar(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.AddProspectsFromFinCar(ObjProsp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.AddProspectsFromFinCar. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 12 Oct 2013
        /// Description: Get All Prospects For Admin View
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataSet GetAllProspForAdmin(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.GetAllProspForAdmin(ObjProsp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetAllProspForAdmin. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 21 Oct 2013
        /// Description: Resssign Leads To Consultant In Bulk
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable ReassignLeadsToConsultant(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.ReassignLeadsToConsultant(ObjProsp);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.ReassignLeadsToConsultant. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 25 Oct 2013
        /// Description: Get All Prospects For Admin View for export
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable GetAllProspForAdminExport(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.GetAllProspForAdminExport(ObjProsp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetAllProspForAdminExport. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 28 Oct 2013
        /// Description: For Getting Data For Email To Send Before 3 Working Days Of Month
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable GetDataForAutoEmailBefore3Days()
        {
            try
            {
                return objProspDAO.GetDataForAutoEmailBefore3Days();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetDataForAutoEmailBefore3Days. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 14 Nov 2013
        /// Description: For Marking Lead Status as Dead or NTU
        /// </summary>
        /// <param name="ProspectId"></param>
        /// <param name="Status"></param>
        /// <param name="Leadtype"></param>
        /// <param name="CreatedById"></param>
        /// <returns></returns>
        public Int64 ChangeStatusToDorN(Int64 ProspectId, string Status, string Leadtype, Int64 CreatedById)
        {
            try
            {
                return objProspDAO.ChangeStatusToDorN(ProspectId, Status, Leadtype, CreatedById);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.ChangeStatusToDorN. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 14 Nov 2013
        /// Description: Assign Leads To Consultant In Bulk
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable BulkAssignLeadsToConsultant(Prospect objProsp)
        {
            try
            {
                return objProspDAO.BulkAssignLeadsToConsultant(objProsp);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.BulkAssignLeadsToConsultant. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 25 Oct 2013
        /// Description: Get All Prospects For Admin View for export
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable GetAllProspForConsultExport(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.GetAllProspForConsultExport(ObjProsp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetAllProspForConsultExport. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 22 Nov 2013
        /// Description: For Updation of Synchroniztion Flag In Raw Data Table
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="IdFromPF"></param>
        /// <returns></returns>
        public Int64 BulkNTULeads(string flag, string Ids, Int64 CreatedById)
        {
            try
            {
                return objProspDAO.BulkNTULeads(flag, Ids, CreatedById);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.BulkNTULeads. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 2 Dec 2013
        /// Description: For addition fleet team Leads
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public Int64 AddFleetTeamLeads(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.AddFleetTeamLeads(ObjProsp);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.AddFleetTeamLeads. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Kalpana Shinde
        /// Created Date: 21 Aug 2013
        /// Description: Get all not yet called PF and FC
        /// </summary>
        public DataTable GetAllNYCForPFAndFCForView(DateTime FromDate, DateTime ToDate, Int64 ConsultantId, string FCFlag, string Flag)
        {
            try
            {
                return objProspDAO.GetAllNYCForPFAndFCForView(FromDate, ToDate, ConsultantId, FCFlag, Flag);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetAllNYCForPFAndFCForView. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 15 Jan 2014
        /// Description: For Addition/Updation of Used Car Details
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="ProspectId"></param>
        /// <param name="SecurityCode"></param>
        /// <param name="Series"></param>
        /// <param name="Year"></param>
        /// <param name="BodyType"></param>
        /// <param name="BodyTypeOther"></param>
        /// <param name="Transmission"></param>
        /// <param name="Engine_Size_Type"></param>
        /// <param name="Budget"></param>
        /// <param name="KM"></param>
        /// <param name="CreatedById"></param>
        /// <returns>Int64</returns>
        public Int64 AddUsedCarDetails(Int64 Id, Int64 ProspectId, string SecurityCode, string Series, string Year, string BodyType, string BodyTypeOther, string Transmission, string Engine_Size_Type, string Budget, string KM, Int64 CreatedById)
        {
            try
            {
                return objProspDAO.AddUsedCarDetails(Id,ProspectId, SecurityCode, Series, Year, BodyType, BodyTypeOther, Transmission, Engine_Size_Type, Budget, KM, CreatedById);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.AddUsedCarDetails. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 12 March 2014
        /// Description: Get All Prospects which were allocated before 5 days
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllProspAllocatedBef5Days()
        {
            try
            {
                return objProspDAO.GetAllProspAllocatedBef5Days();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetAllProspAllocatedBef5Days. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 7 March 2014
        /// Description: Get All Fleet Team Leads
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataSet GetAllFleetTeamProspects(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.GetAllFleetTeamProspects(ObjProsp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetAllFleetTeamProspects. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 19 March 2014
        /// Description: Get All Leads For Report
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataSet GetProspectsForReport(Prospect ObjProsp)
        {
            try
            {
                return objProspDAO.GetProspectsForReport(ObjProsp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetProspectsForReport. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 March 2014
        /// Description: Get All Leads For Report to Export to excel
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable GetProspectsForReportToExcel(Prospect objProsp)
        {
            try
            {
                return objProspDAO.GetProspectsForReportToExcel(objProsp);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetProspectsForReportToExcel. Error:" + ex.StackTrace);
                return null;
            }
        }


        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 21 Oct 2014
        /// Description: Get Get Process Last RunDate
        /// </summary>
        public DataTable GetRemProcessLastRunDate(string Process)
        {
           
            try
            {
                return objProspDAO.GetRemProcessLastRunDate(Process);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetProcessLastRunDate. Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 22 Oct 2014
        /// Description: For Updation of RemProcess Time
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Int64</returns>
        public Int64 UpdateRemProcessLastRunDate(string Process)
        {
            try
            {
                return objProspDAO.UpdateRemProcessLastRunDate(Process);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.UpdateRemProcessLastRunDate. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date:02 Dec 2014
        /// Description: To Count Check IS lead added by Fc Consultant
        /// </summary>
        /// <param name="EmailId"></param>
        /// <param name="Flag"></param>
        /// <returns></returns>
        public int CheckIsAddedByFC(Int64 ProspID)
        {
            try
            {
                return objProspDAO.CheckIsAddedByFC(ProspID);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspBM.CheckIsAddedByFC. Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 4 June 2013
        /// Description: Get count Prospects Details which are assigned to given consultant
        /// <param name="VirtualRoleId"></param>
        /// </summary>
        public DataTable GetCountProspDetAssignedToConsult(Int64 VirtualRoleId, DateTime FromDate, DateTime ToDate, Int64 ProspectId)
        {
            try
            {
                return objProspDAO.GetCountProspDetAssignedToConsult(VirtualRoleId, FromDate, ToDate, ProspectId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectBM.GetProspDetAssignedToConsult. Error:" + ex.StackTrace);
                return null;
            }
        }
        #endregion
    }
}
