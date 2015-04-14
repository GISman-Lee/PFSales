using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using log4net;
using System.Net;
using Mechsoft.PFSales.BusinessManager;
using Mechsoft.PFSales.BusinessEntity;
using System.Text;
using System.Data.Common;

/// <summary>
/// Summary description for Cls_ReminderProcess
/// </summary>
/// 
namespace Mechsoft.GeneralUtilities
{
    public class Cls_ReminderProcess : BasePage
    {
        #region Global Variables
        ILog logger = LogManager.GetLogger(typeof(Cls_ReminderProcess));
        ActivityBM objActivityBM = new ActivityBM();
        ActAlertDetails objActAlertDetails = new ActAlertDetails();
        ProspectBM objProspBM = new ProspectBM();
        MasterBM objMstBM = new MasterBM();
        #endregion

        #region Methods
        /// <summary>
        /// Created By : Pravin Gholap
        /// Created Date: 26 June 2013
        /// Description: Bind Email Alerts
        /// </summary>
        public void BindEmailAlerts()
        {
            try
            {
                objActAlertDetails.UserId = 0;
                objActAlertDetails.AlertTypeId = Cls_Constant.MailAlert;
                DataTable dtAlerts = objActivityBM.GetMyAlerts(objActAlertDetails);
                if (dtAlerts.Rows.Count > 0)
                {
                    for (int i = 0; i < dtAlerts.Rows.Count; i++)
                    {
                        GetAlertForDetails(dtAlerts.Rows[i]["AlertForId"].ToString().Trim(), dtAlerts.Rows[i]["Alert"].ToString().Trim(), dtAlerts.Rows[i]["StartDate"].ToString().Trim(), dtAlerts.Rows[i]["EndDate"].ToString().Trim(), dtAlerts.Rows[i]["Priority"].ToString().Trim(), Convert.ToInt64(dtAlerts.Rows[i]["Id"].ToString().Trim()), dtAlerts.Rows[i]["ProspectName"].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "Cls_ReminderProcess:BindEmailAlerts.Error" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 6 Sept 2013
        /// Description: Get NonSynchronized Data To Insert To Main Data Table Of Prospects
        /// </summary>
        /// <returns></returns>
        public void GetPFRawDataToInsert()
        {
            try
            {
                ProspectBM ObjProspBM = new ProspectBM();
                DataTable DtRawPF = ObjProspBM.GetLeadToCRMFromPF();
                if (DtRawPF != null && DtRawPF.Rows.Count > 0)
                {
                    for (int i = 0; i < DtRawPF.Rows.Count; i++)
                    {
                        if (DtRawPF.Rows[i]["mail_to"] != null && !string.IsNullOrEmpty(Convert.ToString(DtRawPF.Rows[i]["mail_to"]).Trim()) && Convert.ToString(DtRawPF.Rows[i]["mail_to"]).Trim().ToUpper().Contains("NOVATED@PRIVATEFLEET.COM.AU"))
                            SaveLeadsToPFSales(DtRawPF.Rows[i]["Name"].ToString().Trim(), DateTime.Now, DtRawPF.Rows[i]["Leadsource"].ToString().Trim(), Convert.ToInt16(DtRawPF.Rows[i]["CarMake"].ToString().Trim()), Convert.ToInt32(DtRawPF.Rows[i]["CityId"].ToString().Trim()), DtRawPF.Rows[i]["Phone"].ToString().Trim(), DtRawPF.Rows[i]["mobile"].ToString().Trim(), DtRawPF.Rows[i]["Email"].ToString().Trim(), DtRawPF.Rows[i]["Finance"].ToString().Trim(), false, DtRawPF.Rows[i]["PostalCode"].ToString().Trim(), true, Convert.ToInt32(DtRawPF.Rows[i]["StateId"].ToString().Trim()), string.Empty, DtRawPF.Rows[i]["Comment"].ToString().Trim(), DtRawPF.Rows[i]["ModelFromBody"].ToString().Trim(), DtRawPF.Rows[i]["WhereDidUHearFromBody"].ToString().Trim(), Convert.ToBoolean(DtRawPF.Rows[i]["Used"].ToString().Trim()), "F", Convert.ToInt64(DtRawPF.Rows[i]["IdFromPF"].ToString().Trim()), Convert.ToString(DtRawPF.Rows[i]["MakeFromBody"].ToString().Trim()), Convert.ToString(DtRawPF.Rows[i]["AlternateNo"].ToString().Trim()), Convert.ToString(DtRawPF.Rows[i]["address"].ToString().Trim()), Convert.ToString(DtRawPF.Rows[i]["leaseamount"].ToString().Trim()), Convert.ToString(DtRawPF.Rows[i]["employer"].ToString().Trim()));
                        else if (DtRawPF.Rows[i]["mail_to"] != null && !string.IsNullOrEmpty(Convert.ToString(DtRawPF.Rows[i]["mail_to"]).Trim()) && Convert.ToString(DtRawPF.Rows[i]["mail_to"]).Trim().ToUpper().Contains("ENQUIRIES@PRIVATEFLEET.COM.AU"))
                            SaveLeadsToPFSales(DtRawPF.Rows[i]["Name"].ToString().Trim(), DateTime.Now, DtRawPF.Rows[i]["Leadsource"].ToString().Trim(), Convert.ToInt16(DtRawPF.Rows[i]["CarMake"].ToString().Trim()), Convert.ToInt32(DtRawPF.Rows[i]["CityId"].ToString().Trim()), DtRawPF.Rows[i]["Phone"].ToString().Trim(), DtRawPF.Rows[i]["mobile"].ToString().Trim(), DtRawPF.Rows[i]["Email"].ToString().Trim(), DtRawPF.Rows[i]["Finance"].ToString().Trim(), false, DtRawPF.Rows[i]["PostalCode"].ToString().Trim(), true, Convert.ToInt32(DtRawPF.Rows[i]["StateId"].ToString().Trim()), string.Empty, DtRawPF.Rows[i]["Comment"].ToString().Trim(), DtRawPF.Rows[i]["ModelFromBody"].ToString().Trim(), DtRawPF.Rows[i]["WhereDidUHearFromBody"].ToString().Trim(), Convert.ToBoolean(DtRawPF.Rows[i]["Used"].ToString().Trim()), "W", Convert.ToInt64(DtRawPF.Rows[i]["IdFromPF"].ToString().Trim()), Convert.ToString(DtRawPF.Rows[i]["MakeFromBody"].ToString().Trim()), Convert.ToString(DtRawPF.Rows[i]["AlternateNo"].ToString().Trim()), Convert.ToString(DtRawPF.Rows[i]["address"].ToString().Trim()), Convert.ToString(DtRawPF.Rows[i]["leaseamount"].ToString().Trim()), Convert.ToString(DtRawPF.Rows[i]["employer"].ToString().Trim()));
                        else
                            SaveLeadsToPFSales(DtRawPF.Rows[i]["Name"].ToString().Trim(), DateTime.Now, DtRawPF.Rows[i]["Leadsource"].ToString().Trim(), Convert.ToInt16(DtRawPF.Rows[i]["CarMake"].ToString().Trim()), Convert.ToInt32(DtRawPF.Rows[i]["CityId"].ToString().Trim()), DtRawPF.Rows[i]["Phone"].ToString().Trim(), DtRawPF.Rows[i]["mobile"].ToString().Trim(), DtRawPF.Rows[i]["Email"].ToString().Trim(), DtRawPF.Rows[i]["Finance"].ToString().Trim(), false, DtRawPF.Rows[i]["PostalCode"].ToString().Trim(), true, Convert.ToInt32(DtRawPF.Rows[i]["StateId"].ToString().Trim()), string.Empty, DtRawPF.Rows[i]["Comment"].ToString().Trim(), DtRawPF.Rows[i]["ModelFromBody"].ToString().Trim(), DtRawPF.Rows[i]["WhereDidUHearFromBody"].ToString().Trim(), Convert.ToBoolean(DtRawPF.Rows[i]["Used"].ToString().Trim()), "W", Convert.ToInt64(DtRawPF.Rows[i]["IdFromPF"].ToString().Trim()), Convert.ToString(DtRawPF.Rows[i]["MakeFromBody"].ToString().Trim()), Convert.ToString(DtRawPF.Rows[i]["AlternateNo"].ToString().Trim()), Convert.ToString(DtRawPF.Rows[i]["address"].ToString().Trim()), Convert.ToString(DtRawPF.Rows[i]["leaseamount"].ToString().Trim()), Convert.ToString(DtRawPF.Rows[i]["employer"].ToString().Trim()));
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "Cls_ReminderProcess:GetPFRawDataToInsert.Error" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Created By : Pravin Gholap
        /// Created Date: 26 June 2013
        /// Description: Bind User Details Foer Sending Email Alerts
        /// </summary>
        /// <param name="AlertForId"></param>
        /// <param name="activity"></param>
        /// <param name="stdateTime"></param>
        /// <param name="endDtTime"></param>
        /// <param name="priority"></param>
        private void GetAlertForDetails(string AlertForId, string activity, string stdateTime, string endDtTime, string priority, Int64 AlertId, string prospectName)
        {
            try
            {
                DataTable Dt = objActivityBM.GetEmpDetFromIdForAlert(AlertForId);
                if (Dt != null && Dt.Rows.Count > 0)
                {
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        if (SendMail(Dt.Rows[i]["Email1"].ToString().Trim(), Dt.Rows[i]["FName"].ToString().Trim(), activity, stdateTime, endDtTime, priority, AlertId, Convert.ToInt64(Dt.Rows[i]["Id"].ToString().Trim()), prospectName))
                        {
                            objActivityBM.UpdateAlertStatus(AlertId, Convert.ToInt64(Dt.Rows[i]["Id"].ToString().Trim()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "Cls_ReminderProcess:GetAlertForDetails.Error" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Created By : Pravin Gholap
        /// Created Date: 26 June 2013
        /// Description:Send Email of Alerts To Users
        /// </summary>
        /// <param name="EmailToId"></param>
        /// <param name="userName"></param>
        /// <param name="activity"></param>
        /// <param name="stdateTime"></param>
        /// <param name="endDtTime"></param>
        /// <param name="priority"></param>
        /// <returns></returns>
        private Boolean SendMail(string EmailToId, string userName, string activity, string stdateTime, string endDtTime, string priority, Int64 AlertId, Int64 UserId, string prospectName)
        {
            string FileContent = string.Empty;
            Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
            try
            {
                objEmailHelper.EmailFromID = Convert.ToString(ConfigurationManager.AppSettings["EmailFromID"]);
                objEmailHelper.EmailSubject = "Alert For An Activity";
                objEmailHelper.SMTPServerIP = ConfigurationManager.AppSettings["SMTPServerIP"].ToString();
                objEmailHelper.SMTPUserID = ConfigurationManager.AppSettings["SMTPUserID"].ToString();
                objEmailHelper.SMTPUserPwd = ConfigurationManager.AppSettings["SMTPUserPwd"].ToString();
                objEmailHelper.EmailContentType = "HTML";
                objEmailHelper.EmailToID = EmailToId;
                FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + userName.Trim() + "<br /><br /> new activity is schedueled for you please find details as per given bellow <br /><br /><b>Prospect Name: </b>" + ((prospectName.Trim() == "") ? "--" : prospectName.Trim()) + "<br /><b>Activity: </b>" + activity.Trim() + "<br/><b>Priority: </b>" + priority.Trim() + "<br/><b>Start Time: </b>" + stdateTime.Trim() + "<br/><b>End Time: </b>" + endDtTime.Trim() + "<br/><br/>Regards <br /> PF Sales</span>";
                objEmailHelper.EmailBody = FileContent;
                if (objEmailHelper.SendEmail().ToLower().Contains("success"))
                {
                    objMstBM.SaveEmailDetails(EmailToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), "EMail sent successfully", "Alert For An Activity", "App Code Reminder Process");
                    return true;
                }
                else
                {
                    objMstBM.SaveEmailDetails(EmailToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Alert For An Activity", "App Code Reminder Process");
                    return false;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "Cls_ReminderProcess:SendMail.Error" + ex.StackTrace);
                objMstBM.SaveEmailDetails(EmailToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Alert For An Activity", "App Code Reminder Process");
                return false;
            }
        }

        /* Whenever Changes Done To Prospect Or This Process Also Do Related Changes To Same Function In Web Service*/
        /// <summary>
        /// Created By :Pravin Gholap
        /// Created Date: 30 May 2013
        /// Description: Add Leads From Lead Generation Application
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="EnquiryDateTime"></param>
        /// <param name="LeadSource"></param>
        /// <param name="MakeId"></param>
        /// <param name="CityId"></param>
        /// <param name="phone"></param>
        /// <param name="mobile"></param>
        /// <param name="Email"></param>
        /// <param name="Finance"></param>
        /// <param name="TradeIn"></param>
        /// <param name="PostalCode"></param>
        /// <param name="IsActive"></param>
        /// <param name="StateId"></param>
        /// <param name="tradeInMakeModel"></param>
        /// <param name="Comment"></param>
        /// <param name="Model"></param>
        /// <param name="WhereYouHearAbtPF"></param>
        /// <param name="UsedOrNew"></param>
        /// <returns></returns>
        public Int64 SaveLeadsToPFSales(string Name, DateTime EnquiryDateTime, string LeadSource, Int16 MakeId, Int32 CityId, string phone, string mobile, string Email, string Finance, Boolean TradeIn, string PostalCode, Boolean IsActive, Int32 StateId, string tradeInMakeModel, string Comment, string Model, string WhereYouHearAbtPF, Boolean UsedOrNew, string IsFinanceSource, Int64 RawPfId, string Make, string alternateNo, string address, string leaseAmount, string employer)
        {
            try
            {
                Prospect objProsp = new Prospect();
                ProspectBM objProspBM = new ProspectBM();
                MasterBM objMasterBM = new MasterBM();
                Guid gi = Guid.NewGuid();
                objProsp.ProspKey = gi.ToString().Trim();
                Int64 Result = 0;
                ArrayList str = ShowProspName(Name);
                if (str.Count == 3)
                {
                    objProsp.FName = (str[0].ToString().Trim().Substring(0, 1).ToUpper() + str[0].ToString().Trim().Remove(0, 1)).Trim();
                    objProsp.MName = (str[1].ToString().Trim().Substring(0, 1).ToUpper() + str[1].ToString().Trim().Remove(0, 1)).Trim();
                    objProsp.LName = (str[2].ToString().Trim().Substring(0, 1).ToUpper() + str[2].ToString().Trim().Remove(0, 1)).Trim();
                }
                else if (str.Count == 2)
                {
                    objProsp.FName = (str[0].ToString().Trim().Substring(0, 1).ToUpper() + str[0].ToString().Trim().Remove(0, 1)).Trim();
                    objProsp.MName = string.Empty;
                    objProsp.LName = (str[1].ToString().Trim().Substring(0, 1).ToUpper() + str[1].ToString().Trim().Remove(0, 1)).Trim();
                }
                else if (str.Count == 1)
                {
                    objProsp.FName = (str[0].ToString().Trim().Substring(0, 1).ToUpper() + str[0].ToString().Trim().Remove(0, 1)).Trim();
                    objProsp.MName = string.Empty;
                    objProsp.LName = string.Empty;
                }
                objProsp.CarMake = MakeId;
                objProsp.Phone = phone.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
                objProsp.Mobile = mobile.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
                objProsp.AltContact = alternateNo.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
                objProsp.Email = Email.Trim();
                objProsp.Make = Make.Trim();
                objProsp.CityId = CityId;
                objProsp.StateId = StateId;
                objProsp.PostalCode = PostalCode.Trim();
                objProsp.LeadSource = LeadSource.Trim();
                if (Finance.Trim().ToUpper() == "YES")
                    objProsp.IsFinance = true;
                else
                    objProsp.IsFinance = false;
                objProsp.TradeIn = TradeIn;
                objProsp.TradeInMkModel = tradeInMakeModel.Trim();
                objProsp.Comment = Comment.Trim();
                objProsp.IsActive = IsActive;
                objProsp.Model = Model;
                if (!string.IsNullOrEmpty(WhereYouHearAbtPF.Trim()))
                    objProsp.ValueforAnswer = WhereYouHearAbtPF;
                else
                    objProsp.ValueforAnswer = WhereYouHearAbtPF;
                objProsp.Used = UsedOrNew;//True= Used Car & False= New Car
                objProsp.IsFinanceSource = IsFinanceSource;
                objProsp.Add1 = address.Trim();
                if (!CheckDuplicateLeads(objProsp.Email, objProsp.IsFinanceSource))
                {
                    objProsp.IsDuplicate = 43;// Hard Code for Regular
                    Result = objProspBM.AddProspectsFromPFToCRM(objProsp);
                    if (Result > 0)
                    {
                        UpdateIsSynchronized("Y", RawPfId);
                        if (!string.IsNullOrEmpty(leaseAmount) || !string.IsNullOrEmpty(employer))
                            UpdateFinCarLeads(string.Empty, string.Empty, string.Empty, string.Empty, leaseAmount, string.Empty, string.Empty, Result, 0, string.Empty, string.Empty, employer, string.Empty, 0, string.Empty);
                    }
                    else
                        UpdateIsSynchronized("F", RawPfId);
                }
                else
                {
                    if (CheckFor24Hrs(objProsp.Email) <= 24)
                    {
                        objProsp.IsDuplicate = 44; //Hard Code for Duplicate
                        Result = objProspBM.AddProspectsFromPFToCRM(objProsp);
                        if (Result > 0)
                        {
                            UpdateIsSynchronized("Y", RawPfId);
                            if (!string.IsNullOrEmpty(leaseAmount) || !string.IsNullOrEmpty(employer))
                                UpdateFinCarLeads(string.Empty, string.Empty, string.Empty, string.Empty, leaseAmount, string.Empty, string.Empty, Result, 0, string.Empty, string.Empty, employer, string.Empty, 0, string.Empty);
                        }
                        else
                            UpdateIsSynchronized("F", RawPfId);
                    }
                    else
                    {
                        objProsp.IsDuplicate = 45; //Hard Code for Duplicate & Notified
                        Result = objProspBM.AddProspectsFromPFToCRM(objProsp);
                        if (Result > 0)
                        {
                            UpdateIsSynchronized("Y", RawPfId);
                            if (!string.IsNullOrEmpty(leaseAmount) || !string.IsNullOrEmpty(employer))
                                UpdateFinCarLeads(string.Empty, string.Empty, string.Empty, string.Empty, leaseAmount, string.Empty, string.Empty, Result, 0, string.Empty, string.Empty, employer, string.Empty, 0, string.Empty);
                        }
                        else
                            UpdateIsSynchronized("F", RawPfId);
                        DataSet Ds = objMasterBM.GetDupLeadsDetailsForNoti(objProsp.Email, Result);
                        if (Ds != null && Ds.Tables.Count > 0)
                        {
                            DataTable dt1 = Ds.Tables[0];
                            DataTable dt2 = Ds.Tables[1];
                            DataTable dt3 = Ds.Tables[2];
                            if (dt1 != null && dt2 != null && dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
                                SendConsultMail(dt2.Rows[0]["ConsultEmail"].ToString().Trim(), dt2.Rows[0]["AdminEmail"].ToString().Trim(), dt2.Rows[0]["ConsultName"].ToString().Trim(), dt1.Rows[0]["Name"].ToString().Trim(), dt1.Rows[0]["Email1"].ToString().Trim());
                            if (dt1 != null && dt3 != null && dt1.Rows.Count > 0 && dt3.Rows.Count > 0)
                                SendFCConsultMail(dt3.Rows[0]["ConsultEmail"].ToString().Trim(), dt3.Rows[0]["AdminEmail"].ToString().Trim(), dt3.Rows[0]["ConsultName"].ToString().Trim(), dt1.Rows[0]["Name"].ToString().Trim(), dt1.Rows[0]["Email1"].ToString().Trim());
                        }
                    }
                }
                return Result;
            }
            catch (Exception ex)
            {
                UpdateIsSynchronized("F", RawPfId);
                logger.Error(ex.Message + "Cls_ReminderProcess ,SaveLeadsToPFSales.error" + ex.StackTrace);
                return 0;
            }
        }

        private ArrayList ShowProspName(string name)
        {
            try
            {
                string[] str = name.Trim().Replace("  ", " ").Split(' ');
                ArrayList strtoReturn = new ArrayList();
                if (str.Length == 3)
                {
                    if (!string.IsNullOrEmpty(str[0].Trim()))
                        strtoReturn.Add(str[0]);
                    if (!string.IsNullOrEmpty(str[1].Trim()))
                        strtoReturn.Add(str[1]);
                    if (!string.IsNullOrEmpty(str[2].Trim()))
                        strtoReturn.Add(str[2]);
                }

                else if (str.Length == 2)
                {
                    if (!string.IsNullOrEmpty(str[0].Trim()))
                        strtoReturn.Add(str[0]);
                    if (!string.IsNullOrEmpty(str[1].Trim()))
                        strtoReturn.Add(str[1]);
                }
                else if (str.Length == 1)
                {
                    if (!string.IsNullOrEmpty(str[0].Trim()))
                        strtoReturn.Add(str[0]);
                }
                else if (str.Length > 3)
                {
                    StringBuilder strbuilder = new StringBuilder("");
                    if (!string.IsNullOrEmpty(str[0].Trim()))
                        strtoReturn.Add(str[0]);
                    for (int i = 1; i < str.Length - 2; i++)
                    {
                        if (strbuilder.ToString() == "")
                            strbuilder.Append(str[i].Trim());
                        else
                            strbuilder.Append(" " + str[i].Trim());
                    }
                    if (!string.IsNullOrEmpty(str[str.Length - 1].Trim()))
                        strtoReturn.Add(str[str.Length - 1]);
                }
                else if (str == null)
                {
                    strtoReturn.Add(name);
                }
                return strtoReturn;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "Cls_ReminderProcess ,ShowEmployeeName.error" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 21 Aug 2013
        /// Description: Check Duplication Of EmailId
        /// </summary>
        /// <returns></returns>
        private Boolean CheckDuplicateLeads(string Email, string Flag)
        {
            try
            {
                MasterBM objMasterBM = new MasterBM();
                int cnt = objMasterBM.CheckDuplicateEmail(Email, Flag);
                if (cnt > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "Cls_ReminderProcess ,CheckDuplicateLeads.error" + ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:21 Aug 2013
        /// Description: To Get Count Of Duplicate Emails
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        private Int64 CheckFor24Hrs(string Email)
        {
            try
            {
                MasterBM objMasterBM = new MasterBM();
                Int64 cnt = objMasterBM.CheckDuplicateFor24hrs(Email);
                return cnt;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "Cls_ReminderProcess ,CheckFor24Hrs.error" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:21 Aug 2013
        /// Description: To Get Count Of Duplicate Emails
        /// </summary>
        /// <param name="emilToId"></param>
        /// <param name="noOfLeads"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        private Boolean SendConsultMail(string emilToId, string emailCCid, string Name, string prospName, string prospEmail)
        {
            string FileContent = string.Empty;
            try
            {
                Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
                //objEmailHelper.EmailFromID = BasePage.UserSession.EmailFromID;ConfigurationManager.AppSettings["EmailFromID"].ToString();
                objEmailHelper.EmailSubject = "Duplicate Lead Notified";
                //objEmailHelper.SMTPServerIP = ConfigurationManager.AppSettings["SMTPServerIP"].ToString();
                // objEmailHelper.SMTPUserID = ConfigurationManager.AppSettings["SMTPUserID"].ToString();
                // objEmailHelper.SMTPUserPwd = ConfigurationManager.AppSettings["SMTPUserPwd"].ToString();
                objEmailHelper.EmailToID = emilToId;
                objEmailHelper.EmailCcID = emailCCid;
                FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + Name.Trim() + "<br /><br /> Duplicate Lead is reported for the lead which is already allocated to you, Please find the details as given bellow.<br /><br /> Name:" + prospName.Trim() + "<br /><br /> Email:" + prospEmail.Trim() + "<br /><br />Thanks you<br /> PFSales Team</span>";
                objEmailHelper.EmailBody = FileContent;
                if (objEmailHelper.SendEmail().ToLower().Contains("success"))
                {
                    objMstBM.SaveEmailDetails(emilToId, Convert.ToString(ConfigurationManager.AppSettings["EmailFromID"]), FileContent.Trim(), "EMail sent successfully", "Duplicate Lead Notified", "App Code Reminder Process");
                    return true;
                }
                else
                {
                    objMstBM.SaveEmailDetails(emilToId, Convert.ToString(ConfigurationManager.AppSettings["EmailFromID"]), FileContent.Trim(), "Error sending mail, Try again later !", "Duplicate Lead Notified", "App Code Reminder Process");
                    return false;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "Cls_ReminderProcess.SendMail.Error:" + ex.StackTrace);
                objMstBM.SaveEmailDetails(emilToId, Convert.ToString(ConfigurationManager.AppSettings["EmailFromID"]), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Duplicate Lead Notified", "App Code Reminder Process");
                return false;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:21 Aug 2013
        /// Description: To Get Count Of Duplicate Emails
        /// </summary>
        /// <param name="emilToId"></param>
        /// <param name="noOfLeads"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        private Boolean SendFCConsultMail(string emilToId, string emailCCid, string Name, string prospName, string prospEmail)
        {
            string FileContent = string.Empty;
            try
            {
                Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
                //objEmailHelper.EmailFromID = BasePage.UserSession.EmailFromID;ConfigurationManager.AppSettings["EmailFromID"].ToString();
                objEmailHelper.EmailSubject = "Duplicate Lead Notified";
                //objEmailHelper.SMTPServerIP = ConfigurationManager.AppSettings["SMTPServerIP"].ToString();
                // objEmailHelper.SMTPUserID = ConfigurationManager.AppSettings["SMTPUserID"].ToString();
                // objEmailHelper.SMTPUserPwd = ConfigurationManager.AppSettings["SMTPUserPwd"].ToString();
                objEmailHelper.EmailToID = emilToId;
                objEmailHelper.EmailCcID = emailCCid;
                FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + Name.Trim() + "<br /><br /> Duplicate Lead is reported for the lead which is already allocated to you, Please find the details as given bellow.<br /><br /> Name:" + prospName.Trim() + "<br /><br /> Email:" + prospEmail.Trim() + "<br /><br />Thanks you<br /> PFSales Team</span>";
                objEmailHelper.EmailBody = FileContent;
                if (objEmailHelper.SendEmail().ToLower().Contains("success"))
                {
                    objMstBM.SaveEmailDetails(emilToId, Convert.ToString(ConfigurationManager.AppSettings["EmailFromID"]), FileContent.Trim(), "EMail sent successfully", "Duplicate Lead Notified", "App Code Reminder Process");
                    return true;
                }
                else
                {
                    objMstBM.SaveEmailDetails(emilToId, Convert.ToString(ConfigurationManager.AppSettings["EmailFromID"]), FileContent.Trim(), "Error sending mail, Try again later !", "Duplicate Lead Notified", "App Code Reminder Process");
                    return false;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "Cls_ReminderProcess.SendMail.Error:" + ex.StackTrace);
                objMstBM.SaveEmailDetails(emilToId, Convert.ToString(ConfigurationManager.AppSettings["EmailFromID"]), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Duplicate Lead Notified", "App Code Reminder Process");
                return false;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date:6 Sep 2013
        /// Description: Update Is Synchronized Flag
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="IdFromPF"></param>
        private void UpdateIsSynchronized(string flag, Int64 IdFromPF)
        {
            try
            {
                ProspectBM objProspBM = new ProspectBM();
                Int64 Result = objProspBM.UpdateIsSynchronized(flag, IdFromPF);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "Cls_ReminderProcess.SendMail.Error:" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 30 Aug 2013
        /// Description: Update Lead's FC details to Data Base
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Email"></param>
        /// <param name="PhoneNo"></param>
        /// <param name="FinanceType"></param>
        /// <param name="State"></param>
        /// <param name="Message"></param>
        /// <param name="CreditHistory"></param>
        /// <param name="Terms"></param>
        /// <param name="EstimatedFinanced"></param>
        /// <param name="Payment"></param>
        /// <param name="InitialDeposit"></param>
        /// <param name="WebSource"></param>
        /// <returns></returns>
        /// <summary>
        private string UpdateFinCarLeads(string FinanceType, string Message, string CreditHistory, string Terms, string EstimatedFinanced, string Payment, string InitialDeposit, Int64 ProspectID, Int64 FCId, string Employment, string Current_Income, string Employer, string Time_in_Current_Emp, Int16 FinLeadType, string Time_At_Cur_Add)
        {
            DbCommand cmd = null;
            try
            {
                if (ProspectID > 0)
                {
                    cmd = null;
                    cmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "usp_UpdateFincarLeads");
                    Cls_DataAccess.getInstance().AddInParameter(cmd, "@Id", DbType.Int64, FCId);
                    Cls_DataAccess.getInstance().AddInParameter(cmd, "@ProspectID", DbType.Int64, ProspectID);
                    if (!string.IsNullOrEmpty(FinanceType))
                        Cls_DataAccess.getInstance().AddInParameter(cmd, "@FinanceType", DbType.String, FinanceType.Trim());
                    if (!string.IsNullOrEmpty(Message))
                        Cls_DataAccess.getInstance().AddInParameter(cmd, "@Message", DbType.String, Message.Trim());
                    if (!string.IsNullOrEmpty(CreditHistory))
                        Cls_DataAccess.getInstance().AddInParameter(cmd, "@CreditHistory", DbType.String, CreditHistory.Trim());
                    if (!string.IsNullOrEmpty(Terms))
                        Cls_DataAccess.getInstance().AddInParameter(cmd, "@Terms", DbType.String, Terms.Trim());
                    if (!string.IsNullOrEmpty(EstimatedFinanced))
                        Cls_DataAccess.getInstance().AddInParameter(cmd, "@EstimatedFinanced", DbType.String, EstimatedFinanced.Trim());
                    if (!string.IsNullOrEmpty(Payment))
                        Cls_DataAccess.getInstance().AddInParameter(cmd, "@Payment", DbType.String, Payment.Trim());
                    if (!string.IsNullOrEmpty(InitialDeposit))
                        Cls_DataAccess.getInstance().AddInParameter(cmd, "@InitialDeposit", DbType.String, InitialDeposit.Trim());
                    if (!string.IsNullOrEmpty(Employment))
                        Cls_DataAccess.getInstance().AddInParameter(cmd, "@Employment", DbType.String, Employment.Trim());
                    if (!string.IsNullOrEmpty(Current_Income))
                        Cls_DataAccess.getInstance().AddInParameter(cmd, "@CurrentIncome", DbType.String, Current_Income.Trim());
                    if (!string.IsNullOrEmpty(Employer))
                        Cls_DataAccess.getInstance().AddInParameter(cmd, "@Employer", DbType.String, Employer.Trim());
                    if (!string.IsNullOrEmpty(Time_in_Current_Emp))
                        Cls_DataAccess.getInstance().AddInParameter(cmd, "@Time_in_Cur_Emp", DbType.String, Time_in_Current_Emp.Trim());
                    if (!FinLeadType.Equals(0))
                        Cls_DataAccess.getInstance().AddInParameter(cmd, "@FinLeadTypeId", DbType.Int16, FinLeadType);
                    if (!string.IsNullOrEmpty(Time_At_Cur_Add))
                        Cls_DataAccess.getInstance().AddInParameter(cmd, "@Time_At_Cur_Add", DbType.String, Time_At_Cur_Add.Trim());
                    Cls_DataAccess.getInstance().AddInParameter(cmd, "@CreatedById ", DbType.String, 1);

                    object obj = Cls_DataAccess.getInstance().ExecuteScaler(cmd, null);
                    int Result = Convert.ToInt32(obj);
                }
            }
            catch (Exception ex)
            {
                logger.Error("Cls_ReminderProcess.UpdateFinCarLeads. Inner Exception:" + ex.InnerException);
                logger.Error(ex.Message + "Cls_ReminderProcess.UpdateFinCarLeads.Error:" + ex.StackTrace);
                return "Error in connection";
            }
            return "Success";
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 26 Oct 2013
        /// Description: For Getting Data For Email To Send Before 3 Working Days Of Each Month
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public void SendEmailBeforeLast3Days()
        {
            try
            {
                DateTime today = DateTime.Today;
                DateTime endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
                string eom = endOfMonth.ToString("ddd");
                DateTime dt = new DateTime();

                switch (eom.ToUpper())
                {
                    case "MON":
                        dt = endOfMonth.AddDays(-5);
                        break;
                    case "TUE":
                        dt = endOfMonth.AddDays(-5);
                        break;
                    case "WED":
                        dt = endOfMonth.AddDays(-5);
                        break;
                    case "THU":
                        dt = endOfMonth.AddDays(-3);
                        break;
                    case "FRI":
                        dt = endOfMonth.AddDays(-3);
                        break;
                    case "SAT":
                        dt = endOfMonth.AddDays(-4);
                        break;
                    case "SUN":
                        dt = endOfMonth.AddDays(-5);
                        break;
                    default:
                        dt = endOfMonth.AddDays(-5);
                        break;
                }
                DataTable Dt = objProspBM.GetDataForAutoEmailBefore3Days();
                if (Dt != null && Dt.Rows.Count > 0)
                {//Updated By :Ayyaj For 3 days before of month end on 07 Oct 2014
                    if (DateTime.Now.Date == dt.Date && DateTime.Now.Hour == 11 && DateTime.Now.Minute == 00)
                    {
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            SendAutoEmail(Convert.ToString(Dt.Rows[i]["Fname"]).Trim(), Convert.ToString(Dt.Rows[i]["ConsultantName"]).Trim(), Convert.ToString(Dt.Rows[i]["Email"]).Trim(), Convert.ToString(Dt.Rows[i]["Email1"]).Trim(), Convert.ToString(Dt.Rows[i]["PhoneExt"]).Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("Cls_ReminderProcess.SendEmailBeforeLast3Days. Inner Exception:" + ex.InnerException);
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 28 Oct 2013
        /// Description: For Sending Email Before 3 Working Days Of Each Month
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        private Boolean SendAutoEmail(string firstName, string consultName, string emilToId, string ConsultEmail, string ConsultExt)
        {
            string FileContent = string.Empty;
            try
            {
                Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
                objEmailHelper.EmailFromID = ConsultEmail;// ConfigurationManager.AppSettings["EmailFromID"].ToString();
                objEmailHelper.EmailSubject = "Better Deal From Private Fleet";
                //objEmailHelper.SMTPServerIP = ConfigurationManager.AppSettings["SMTPServerIP"].ToString();
                // objEmailHelper.SMTPUserID = ConfigurationManager.AppSettings["SMTPUserID"].ToString();
                //objEmailHelper.SMTPUserPwd = ConfigurationManager.AppSettings["SMTPUserPwd"].ToString();
                objEmailHelper.EmailToID = emilToId;
                //Only for test
                //objEmailHelper.EmailBccID = "ayyaj.mujawar@mechsoftgroup.com";
                // string FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + Name.Trim() + "<br /><br /> With reference to your enquiry made on " + EnquiryDate.Trim() + " here we have asigned a consultant for you. Please find the consultant's details as given below<br /><br /><b>&nbsp;&nbsp; Name: </b>" + ConsultantName.Trim() + "<br/><b>&nbsp;&nbsp; Phone No.: </b>" + ConsultPhone.Trim() + "<br/><b>&nbsp;&nbsp; Email: </b>" + ConsultEmail.Trim() + "<br/><br/>Regards <br /> PF Sales</span>";
                FileContent = "<div style='font: 12px/17px arial,helvetica,'Liberation Sans',FreeSans,sans-serif;color: #333333;'>"
                                     + "Dear " + firstName.Trim() + ",<br><br> Just a quick note to let you know, as the end of the month is approaching,"
                                     + "<br>if you haven't yet organised a new car, it would be a good idea to work on"
                                     + "<br>some pricing in the next few days."
                                     + "<br><br>With dealers pushing to meet their end of month targets, it's always a good"
                                     + "<br>time to squeeze a better deal!"
                                     + "<br><br>So please let me know if I can be of assistance!"
                                     + "<br><br>Best regards,"
                                     + "<br><br><h3 style='color:#0000CC'>" + consultName.Trim() + "</h3>"
                                     + "Key Account Manager"
                                     + "<br><h3 style='color:#0000CC'>Private Fleet</h3>" + "<span style='Font:11px'><i style='color:#0000CC'> – Car Buying Made Easy</i></span>"
                                     + "<br><br><span style='Font:11px'>Lvl 2 845 Pacific Hwy </span>" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + " <span style='Font:11px' >Tel: 1300 303 181 " + ((!string.IsNullOrEmpty(ConsultExt.Trim())) ? ("(" + ConsultExt.Trim() + ")") : "") + "</span>"
                                     + "<br><span style='Font:11px'>Chatswood NSW 2067 </span>" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + " <span style='Font:11px' >Fax: 1300 303 981 </span> "
                                     + "<br><span style='Font:11px'>ABN: 70 080 056 408 | Dealer Lic: MD 19913 </span>" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<a href='http://www.privatefleet.com.au' style='Font:11px'>www.PrivateFleet.com.au</a></div> ";
                objEmailHelper.EmailBody = FileContent;
                if (objEmailHelper.SendEmail().ToLower().Contains("success"))
                {
                    objMstBM.SaveEmailDetails(emilToId, Convert.ToString(ConfigurationManager.AppSettings["EmailFromID"]), FileContent.Trim(), "EMail sent successfully", "Better Deal From Private Fleet", "App Code Reminder Process");
                    return true;
                }
                else
                {
                    objMstBM.SaveEmailDetails(emilToId, Convert.ToString(ConfigurationManager.AppSettings["EmailFromID"]), FileContent.Trim(), "Error sending mail, Try again later !", "Better Deal From Private Fleet", "App Code Reminder Process");
                    return false;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Cls_ReminderProcess.SendAutoEmail. Inner Exception:" + ex.InnerException);
                objMstBM.SaveEmailDetails(emilToId, Convert.ToString(ConfigurationManager.AppSettings["EmailFromID"]), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Better Deal From Private Fleet", "App Code Reminder Process");
                return false;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 12 March 2014
        /// Description: For Sending Email after 5 Days of alocation
        /// </summary>
        /// <returns></returns>
        public void GetAllProspAllocatedAft5Days()
        {
            try
            {
                if (DateTime.Now.Hour == 09)
                {
                    DateTime startTime = DateTime.Now;
                    DataTable dtDate = new DataTable();
                    dtDate = objProspBM.GetRemProcessLastRunDate("EmailForFollowUp");
                    DateTime LastRunDate = Convert.ToDateTime(dtDate.Rows[0]["LastRunDate"]);

                    //DataTable Dt = objProspBM.GetAllProspAllocatedBef5Days();
                    //if (Dt != null && Dt.Rows.Count > 0)
                    //{
                    if (DateTime.Now.Hour == 09 && LastRunDate.Date != startTime.Date)
                    {
                        Int64 result = objProspBM.UpdateRemProcessLastRunDate("EmailForFollowUp");
                        
                        DataTable Dt = objProspBM.GetAllProspAllocatedBef5Days();
                        if (Dt != null && Dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < Dt.Rows.Count; i++)
                            {
                                SendFollowUpEmail(Convert.ToString(Dt.Rows[i]["LeadFirstName"]).Trim(), Convert.ToString(Dt.Rows[i]["ConsultantFName"]).Trim(), Convert.ToString(Dt.Rows[i]["ProspectEmail"]).Trim());
                            }
                        }
                        if (result > 0)
                        {
                            logger.Error("Process: EmailForFollowUp Run Successfully ");
                        }
                        
                    }
                    //}
                }
            }
            catch (Exception ex)
            {
                logger.Error("Cls_ReminderProcess.GetAllProspAllocatedAft5Days. Inner Exception:" + ex.InnerException);
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 12 March 2014
        /// Description: For Sending Email after 5 Days of alocation
        /// </summary>
        /// <returns></returns>
        private Boolean SendFollowUpEmail(string firstName, string consultFName, string emilToId)
        {
            string FileContent = string.Empty;
            try
            {
                Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
                objEmailHelper.EmailFromID = "markellis@privatefleet.com.au";// ConfigurationManager.AppSettings["EmailFromID"].ToString();
                objEmailHelper.EmailSubject = "Private Fleet - Follow Up";
                objEmailHelper.EmailToID = emilToId;
                FileContent = "<div style='font: 12px/17px arial,helvetica,'Liberation Sans',FreeSans,sans-serif;color: #333333;'>"
                                  + "Dear " + firstName.Trim() + ","
                                  + "<br><br>I just wanted to follow up on your recent enquiry with us. I trust that by now you have discussed your requirements with " + consultFName.Trim() + " and that, whether you have decided to place an order with Private Fleet or not, you have found our service to have been of value."
                                  + "<br><br>If there is anything further you would like us to do or any outstanding issues, then please let me know and I’ll make sure we attend to it as soon as possible."
                                  + "<br><br>Kind Regards"
                                  + "<br><h3 style='color:#1F497D'> Mark Ellis | Managing Director </h3>"
                                  + "<h3 style='color:Navy'>Private Fleet" + "<i style='color:Navy; Font:11px'> – Car Buying Made Easy</i></h3>"
                                  + "<br><span style='color:#1F497D'>P: 1300 303 181 </span>"
                                  + "<br><span style='color:#1F497D'>E: <a href = 'mailto:markellis@privatefleet.com.au' style=color: Blue; text-decoration: underline;>markellis@privatefleet.com.au</a></span>"
                                  + "<br><span style='color:#1F497D'>W: <a href='http://www.privatefleet.com.au'>www.privatefleet.com.au</a></span>"
                                  + "<br><br><span style='Font:9px; color:#1F497D'>Lvl 2 845 Pacific Hwy </span>"
                                  + "<br><span style='Font:9px; color:#1F497D'>Chatswood</span>"
                                  + "<br><span style='Font:9px; color:#1F497D'>NSW 2067 </span>"
                                  + "<br><br><span style='Font:9px; color:#1F497D'>ABN: 70 080 056 408 | Dealer Lic: MD 19913 </span>";
                objEmailHelper.EmailBody = FileContent;
                if (objEmailHelper.SendEmail().ToLower().Contains("success"))
                {
                    objMstBM.SaveEmailDetails(emilToId, Convert.ToString(ConfigurationManager.AppSettings["EmailFromID"]), FileContent.Trim(), "EMail sent successfully", "Private Fleet - Follow Up", "App Code Reminder Process");
                    return true;
                }
                else
                {
                    objMstBM.SaveEmailDetails(emilToId, Convert.ToString(ConfigurationManager.AppSettings["EmailFromID"]), FileContent.Trim(), "Error sending mail, Try again later !", "Private Fleet - Follow Up", "App Code Reminder Process");
                    return false;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Cls_ReminderProcess.SendFollowUpEmail. Inner Exception:" + ex.InnerException);
                objMstBM.SaveEmailDetails(emilToId, Convert.ToString(ConfigurationManager.AppSettings["EmailFromID"]), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Better Deal From Private Fleet", "App Code Reminder Process");
                return false;
            }
        }
        #endregion
    }
}
