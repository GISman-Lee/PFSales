using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Mechsoft.PFSales.BusinessEntity;
using log4net;
using Mechsoft.PFSales.BusinessManager;
using System.Collections;
using System.Text;
using Mechsoft.GeneralUtilities;
using System.Data;
using System.Data.Common;

/// <summary>
/// Summary description for AddLeadsToPFSales
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class AddLeadsToPFSales : System.Web.Services.WebService
{
    #region Gloabal Varriable
    ILog Logger = LogManager.GetLogger(typeof(AddLeadsToPFSales));
    MasterBM objMstBM = new MasterBM();
    #endregion

    public AddLeadsToPFSales()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    /* Whenever Changes Done To Prospect Or This Process Also Do Related Changes To Same Function In Reminder Process*/
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
    [WebMethod]
    public Int64 SaveLeadsToPFSales(string Name, DateTime EnquiryDateTime, string LeadSource, Int16 MakeId, Int32 CityId, string phone, string mobile, string Email, Boolean Finance, Boolean TradeIn, string PostalCode, Boolean IsActive, Int32 StateId, string tradeInMakeModel, string Comment, string Model, string WhereYouHearAbtPF, Boolean UsedOrNew, string IsFinanceSource, Boolean IsNovatedLease)
    {
        try
        {
            Logger.Debug("Calling Add Leads To CRM:");
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
            objProsp.Email = Email.Trim();
            objProsp.CityId = CityId;
            objProsp.StateId = StateId;
            objProsp.PostalCode = PostalCode.Trim();
            objProsp.LeadSource = LeadSource.Trim();
            objProsp.IsFinance = Finance;
            if (IsNovatedLease)
                objProsp.IsFinance = true;
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
            if (!CheckDuplicateLeads(objProsp.Email, objProsp.IsFinanceSource))
            {
                objProsp.IsDuplicate = 43;// Hard Code for Regular
                Result = objProspBM.AddProspectFromServ(objProsp);
                if (Result > 0)
                {
                    if (objProsp.IsFinance && IsNovatedLease)
                        UpdateFinCarLeads("Novated Leases", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Result, 0, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty);
                }
            }
            else
            {
                if (CheckFor24Hrs(objProsp.Email) <= 24)
                {
                    objProsp.IsDuplicate = 44; //Hard Code for Duplicate
                    Result = objProspBM.AddProspectFromServ(objProsp);
                    if (Result > 0)
                    {
                        if (objProsp.IsFinance && IsNovatedLease)
                            UpdateFinCarLeads("Novated Leases", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Result, 0, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty);
                    }
                }
                else
                {
                    objProsp.IsDuplicate = 45; //Hard Code for Duplicate & Notified
                    Result = objProspBM.AddProspectFromServ(objProsp);
                    if (Result > 0)
                    {
                        if (objProsp.IsFinance && IsNovatedLease)
                            UpdateFinCarLeads("Novated Leases", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Result, 0, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty);
                    }
                    DataSet Ds = objMasterBM.GetDupLeadsDetailsForNoti(objProsp.Email, Result);
                    if (Ds != null && Ds.Tables.Count > 0)
                    {
                        DataTable dt1 = Ds.Tables[0];
                        DataTable dt2 = Ds.Tables[1];
                        DataTable dt3 = Ds.Tables[2];
                        if (dt1 != null && dt2 != null && dt1.Rows.Count > 0 && dt2.Rows.Count > 0 && !string.IsNullOrEmpty(Convert.ToString(dt2.Rows[0]["ConsultEmail"]).Trim()))
                            SendConsultMail(dt2.Rows[0]["ConsultEmail"].ToString().Trim(), dt2.Rows[0]["AdminEmail"].ToString().Trim(), dt2.Rows[0]["ConsultName"].ToString().Trim(), dt1.Rows[0]["Name"].ToString().Trim(), dt1.Rows[0]["Email1"].ToString().Trim());
                        if (dt1 != null && dt3 != null && dt1.Rows.Count > 0 && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(Convert.ToString(dt3.Rows[0]["ConsultEmail"]).Trim()))
                            SendFCConsultMail(dt3.Rows[0]["ConsultEmail"].ToString().Trim(), dt3.Rows[0]["AdminEmail"].ToString().Trim(), dt3.Rows[0]["ConsultName"].ToString().Trim(), dt1.Rows[0]["Name"].ToString().Trim(), dt1.Rows[0]["Email1"].ToString().Trim());
                    }
                }
            }
            return Result;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddLeadsToPFSales ,SaveLeadsToPFSales.error" + ex.StackTrace);
            return 0;
        }
    }

    /// <summary>
    /// Created By :Pravin Gholap
    /// Created Date: 13 Sept 2013
    /// Description: Add Leads From Fincar.com.au
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
    /// <param name="Address1"></param>
    /// <param name="Address2"></param>
    /// <returns></returns>
    [WebMethod]
    public Int64 SaveLeadsFrmFinToPFSales(string Name, DateTime EnquiryDateTime, string LeadSource, Int16 MakeId, Int32 CityId, string phone, string mobile, string Email, Boolean Finance, Boolean TradeIn, string PostalCode, Boolean IsActive, Int32 StateId, string tradeInMakeModel, string Comment, string Model, string WhereYouHearAbtPF, Boolean UsedOrNew, string IsFinanceSource, string Address1, string Address2)
    {
        try
        {
            Logger.Debug("In Save Leads From FinCar To PFSales:" + Email);
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
            objProsp.Email = Email.Trim();
            objProsp.CityId = CityId;
            objProsp.StateId = StateId;
            objProsp.PostalCode = PostalCode.Trim();
            objProsp.LeadSource = LeadSource.Trim();
            objProsp.IsFinance = Finance;
            objProsp.TradeIn = TradeIn;
            objProsp.TradeInMkModel = tradeInMakeModel.Trim();
            objProsp.Comment = Comment.Trim();
            objProsp.IsActive = IsActive;
            objProsp.Model = Model;
            objProsp.Add1 = Address1.Trim();
            objProsp.Add2 = Address2.Trim();
            if (!string.IsNullOrEmpty(WhereYouHearAbtPF.Trim()))
                objProsp.ValueforAnswer = WhereYouHearAbtPF;
            else
                objProsp.ValueforAnswer = WhereYouHearAbtPF;
            objProsp.Used = UsedOrNew;//True= Used Car & False= New Car
            objProsp.IsFinanceSource = IsFinanceSource;
            if (!CheckDuplicateLeads(objProsp.Email, objProsp.IsFinanceSource))
            {
                objProsp.IsDuplicate = 43;// Hard Code for Regular
                Result = objProspBM.AddProspectsFromFinCar(objProsp);
            }
            else
            {
                if (CheckFor24Hrs(objProsp.Email) <= 24)
                {
                    objProsp.IsDuplicate = 44; //Hard Code for Duplicate
                    Result = objProspBM.AddProspectsFromFinCar(objProsp);
                }
                else
                {
                    objProsp.IsDuplicate = 45; //Hard Code for Duplicate & Notified
                    Result = objProspBM.AddProspectsFromFinCar(objProsp);
                    DataSet Ds = objMasterBM.GetDupLeadsDetailsForNoti(objProsp.Email, Result);
                    if (Ds != null && Ds.Tables.Count > 0)
                    {
                        DataTable dt1 = Ds.Tables[0];
                        DataTable dt2 = Ds.Tables[1];
                        DataTable dt3 = Ds.Tables[2];
                        if (dt1 != null && dt2 != null && dt1.Rows.Count > 0 && dt2.Rows.Count > 0 && !string.IsNullOrEmpty(Convert.ToString(dt2.Rows[0]["ConsultEmail"]).Trim()))
                            SendConsultMail(dt2.Rows[0]["ConsultEmail"].ToString().Trim(), dt2.Rows[0]["AdminEmail"].ToString().Trim(), dt2.Rows[0]["ConsultName"].ToString().Trim(), dt1.Rows[0]["Name"].ToString().Trim(), dt1.Rows[0]["Email1"].ToString().Trim());
                        if (dt1 != null && dt1.Rows.Count > 0 && dt3 != null && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(Convert.ToString(dt3.Rows[0]["ConsultEmail"]).Trim()))
                            SendFCConsultMail(dt3.Rows[0]["ConsultEmail"].ToString().Trim(), dt3.Rows[0]["AdminEmail"].ToString().Trim(), dt3.Rows[0]["ConsultName"].ToString().Trim(), dt1.Rows[0]["Name"].ToString().Trim(), dt1.Rows[0]["Email1"].ToString().Trim());
                    }
                }
            }
            Logger.Debug("In Save Leads From FinCar To PFSales Result is:" + Result);
            return Result;
        }
        catch (Exception ex)
        {
            Logger.Debug("AddLeadsToPFSales ,SaveLeadsFrmFinToPFSales Inner Exception:" + ex.InnerException);
            Logger.Error(ex.Message + "AddLeadsToPFSales ,SaveLeadsFrmFinToPFSales.error" + ex.StackTrace);
            return 0;
        }
    }

    /// <summary>
    /// Created By :Pravin Gholap
    /// Created Date: 12 June 2013
    /// Description: For User synchronization between Quotes & CRM
    /// </summary>
    /// <param name="Roll"></param>
    /// <param name="Name"></param>
    /// <param name="Phone"></param>
    /// <param name="Ext"></param>
    /// <param name="Email"></param>
    /// <param name="Mobile"></param>
    /// <param name="Address1"></param>
    /// <param name="Address2"></param>
    /// <param name="Address3"></param>
    /// <param name="password"></param>
    /// <param name="key"></param>
    /// <param name="IsInFleetTeam"></param>
    /// <param name="QuoteUserId"></param>
    /// <returns></returns>
    [WebMethod]
    public Int64 SaveEmpToPFSales(Int32 Roll, string Name, string Phone, string Ext, string Email, string Mobile, string Address1, string Address2, string Address3, string password, string key, Boolean IsInFleetTeam, Int64 QuoteUserId)
    {
        try
        {
            Employee objEmp = new Employee();
            EmployeeBM objEmpBm = new EmployeeBM();
            objEmp.EmpId = 0;
            if (QuoteUserId > 0)
            {
                DataTable Dt = new DataTable();
                Dt = objEmpBm.GetDetailsFromQuoteUserId(QuoteUserId);
                if (Dt != null && Dt.Rows.Count > 0)
                {
                    if (Dt.Rows[0]["EmpId"] != null && !string.IsNullOrEmpty(Convert.ToString(Dt.Rows[0]["EmpId"])))
                        objEmp.EmpId = Convert.ToInt64(Dt.Rows[0]["EmpId"]);
                    if (Dt.Rows[0]["UserId"] != null && !string.IsNullOrEmpty(Convert.ToString(Dt.Rows[0]["UserId"])))
                        objEmp.UseId = Convert.ToInt64(Dt.Rows[0]["UserId"]);
                    if (Dt.Rows[0]["VRId"] != null && !string.IsNullOrEmpty(Convert.ToString(Dt.Rows[0]["VRId"])))
                        objEmp.UserVID = Convert.ToInt64(Dt.Rows[0]["VRId"]);
                }
            }

            //Guid gi = Guid.NewGuid();
            objEmp.EmpKey = key;// gi.ToString().Trim();
            Int64 Result = 0;
            ArrayList str = ShowProspName(Name);

            if (str.Count == 3)
            {
                objEmp.FName = (str[0].ToString().Trim().Substring(0, 1).ToUpper() + str[0].ToString().Trim().Remove(0, 1)).Trim();
                objEmp.MName = (str[1].ToString().Trim().Substring(0, 1).ToUpper() + str[1].ToString().Trim().Remove(0, 1)).Trim();
                objEmp.LName = (str[2].ToString().Trim().Substring(0, 1).ToUpper() + str[2].ToString().Trim().Remove(0, 1)).Trim();
            }
            else if (str.Count == 2)
            {
                objEmp.FName = (str[0].ToString().Trim().Substring(0, 1).ToUpper() + str[0].ToString().Trim().Remove(0, 1)).Trim();
                objEmp.MName = string.Empty;
                objEmp.LName = (str[1].ToString().Trim().Substring(0, 1).ToUpper() + str[1].ToString().Trim().Remove(0, 1)).Trim();
            }
            else if (str.Count == 1)
            {
                objEmp.FName = (str[0].ToString().Trim().Substring(0, 1).ToUpper() + str[0].ToString().Trim().Remove(0, 1)).Trim();
                objEmp.MName = string.Empty;
                objEmp.LName = string.Empty;
            }
            objEmp.Phone = Phone.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
            objEmp.Mobile = Mobile.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
            objEmp.Email = Email.Trim();
            objEmp.PhoneExt = Ext.Trim();
            objEmp.RoleId = Roll;
            objEmp.Add1 = Address1.Trim();
            objEmp.Add2 = Address2.Trim();
            objEmp.Add3 = Address3.Trim();
            objEmp.QuoteUserId = QuoteUserId;
            //string strEncPassword = Cls_Encryption.EncryptTripleDES(password);
            objEmp.Password = password.Trim();
            objEmp.DesigId = 0;
            objEmp.Designation = string.Empty;
            objEmp.CreatedById = 1;
            objEmp.IsDeleted = false;
            objEmp.IsActive = true;
            objEmp.IsNewEmployee = true;
            objEmp.IsInFleetTeam = IsInFleetTeam;
            Result = objEmpBm.AddUpdateDeleteEmployee(objEmp);
            return Result;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddLeadsToPFSales ,SaveLeadsToPFSales.error" + ex.StackTrace);
            return 0;
        }
    }

    /// <summary>
    /// Created By :Pravin Gholap
    /// Created Date: 12 June 2013
    /// Description: For Changing Password Of User When it Changed From Quote 
    /// </summary>
    /// <param name="QuoteUserId"></param>
    /// <param name="UserName"></param>
    /// <param name="password"></param>
    /// <param name="CreatedById"></param>
    /// <returns></returns>
    [WebMethod]
    public Int64 ChangePassword(Int64 QuoteUserId, string UserName, string password, Int64 CreatedById)
    {
        try
        {
            Int64 Result = 0;
            EmployeeBM objEmpBm = new EmployeeBM();
            //string strEncPassword = Cls_Encryption.EncryptTripleDES(password);
            Result = objEmpBm.ChangePassword(QuoteUserId, UserName, password.Trim(), CreatedById);
            return Result;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddLeadsToPFSales ,ChangePassword.error" + ex.StackTrace);
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
    [WebMethod]
    public Int64 ChangeIsActiveStatus(Int64 QuoteUserId, Boolean IsActive, Int64 CreatedById)
    {
        try
        {
            Int64 Result = 0;
            EmployeeBM objEmpBm = new EmployeeBM();
            Result = objEmpBm.ChangeIsActiveStatus(QuoteUserId, IsActive, CreatedById);
            return Result;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddLeadsToPFSales ,ChangeIsActiveStatus.error" + ex.StackTrace);
            return 0;
        }
    }

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
    /// <param name="IsFinanceSource"></param>
    /// <param name="AlternateNo"></param>
    /// <returns></returns>
    [WebMethod]
    public Int64 SaveLeadsToCRM(string Name, string LeadSource, string Make, string City, string phone, string mobile, string Email, Boolean Finance, Boolean TradeIn, string PostalCode, Boolean IsActive, string State, string tradeInMakeModel, string Comment, string Model, string WhereYouHearAbtPF, Boolean UsedOrNew, string IsFinanceSource, string AlternateNo)
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
            objProsp.Make = Make;
            objProsp.Phone = phone.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
            objProsp.Mobile = mobile.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
            objProsp.Email = Email.Trim();
            objProsp.City = City;
            objProsp.State = State;
            objProsp.PostalCode = PostalCode.Trim();
            objProsp.LeadSource = LeadSource.Trim();
            objProsp.IsFinance = Finance;
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
            objProsp.AltContact = AlternateNo;
            if (!CheckDuplicateLeads(objProsp.Email, objProsp.IsFinanceSource))
            {
                objProsp.IsDuplicate = 43;// Hard Code for Regular
                Result = objProspBM.AddProspectsFromPFServ(objProsp);
            }
            else
            {
                if (CheckFor24Hrs(objProsp.Email) <= 24)
                {
                    objProsp.IsDuplicate = 44; //Hard Code for Duplicate
                    Result = objProspBM.AddProspectsFromPFServ(objProsp);
                }
                else
                {
                    objProsp.IsDuplicate = 45; //Hard Code for Duplicate & Notified
                    Result = objProspBM.AddProspectsFromPFServ(objProsp);
                    DataSet Ds = objMasterBM.GetDupLeadsDetailsForNoti(objProsp.Email, Result);
                    if (Ds != null && Ds.Tables.Count > 0)
                    {
                        DataTable dt1 = Ds.Tables[0];
                        DataTable dt2 = Ds.Tables[1];
                        DataTable dt3 = Ds.Tables[2];
                        if (dt1 != null && dt2 != null && dt1.Rows.Count > 0 && dt2.Rows.Count > 0 && !string.IsNullOrEmpty(Convert.ToString(dt2.Rows[0]["ConsultEmail"]).Trim()))
                            SendConsultMail(dt2.Rows[0]["ConsultEmail"].ToString().Trim(), dt2.Rows[0]["AdminEmail"].ToString().Trim(), dt2.Rows[0]["ConsultName"].ToString().Trim(), dt1.Rows[0]["Name"].ToString().Trim(), dt1.Rows[0]["Email1"].ToString().Trim());
                        if (dt1 != null && dt3 != null && dt1.Rows.Count > 0 && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(Convert.ToString(dt3.Rows[0]["ConsultEmail"]).Trim()))
                            SendFCConsultMail(dt3.Rows[0]["ConsultEmail"].ToString().Trim(), dt3.Rows[0]["AdminEmail"].ToString().Trim(), dt3.Rows[0]["ConsultName"].ToString().Trim(), dt1.Rows[0]["Name"].ToString().Trim(), dt1.Rows[0]["Email1"].ToString().Trim());
                    }
                }
            }
            return Result;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "PFWebIntegration ,SaveLeadsToCRM.error" + ex.StackTrace);
            return 0;
        }
    }

    [WebMethod]
    public Int64 SaveLeadsToPFSalesFromVW(string Name, string LeadSource, string CarMake, Int32 CityId, string phone, string mobile, string Email, Boolean Finance, Boolean TradeIn, string PostalCode, Boolean IsActive, string StateName, string tradeInMakeModel, string Comment, string Model, string WhereYouHearAbtPF, Boolean UsedOrNew, string IsFinanceSource, Boolean IsNovatedLease)
    {
        try
        {
            DbCommand cmd = null;
            DbCommand objCmd = null;
            Logger.Debug("Calling Add Leads To CRM FROM VW:");

            int StateID = 0;
            int MakeId = 0;

            cmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllStates");
            Cls_DataAccess.getInstance().AddInParameter(cmd, "@StateName", DbType.String, StateName);
            Cls_DataAccess.getInstance().AddInParameter(cmd, "@CountryId", DbType.Int64, 1);
            DataTable dt = Cls_DataAccess.getInstance().GetDataTable(cmd, null);

            if (dt != null && dt.Rows.Count == 1)
                StateID = Convert.ToInt32(dt.Rows[0]["Id"]);

            objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllMakes");
            Cls_DataAccess.getInstance().AddInParameter(objCmd, "Make", DbType.String, CarMake);
            DataTable DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
            if (DtResult != null && DtResult.Rows.Count == 1)
                MakeId = Convert.ToInt32(DtResult.Rows[0]["Id"]);


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
            objProsp.Email = Email.Trim();
            objProsp.CityId = CityId;
            objProsp.StateId = StateID;
            objProsp.PostalCode = PostalCode.Trim();
            objProsp.LeadSource = LeadSource.Trim();
            objProsp.IsFinance = Finance;
            if (IsNovatedLease)
                objProsp.IsFinance = true;
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
            if (!CheckDuplicateLeads(objProsp.Email, objProsp.IsFinanceSource))
            {
                objProsp.IsDuplicate = 43;// Hard Code for Regular
                Result = objProspBM.AddProspectFromServ(objProsp);
                if (Result > 0)
                {
                    if (objProsp.IsFinance && IsNovatedLease)
                        UpdateFinCarLeads("Novated Leases", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Result, 0, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty);
                }
            }
            else
            {
                if (CheckFor24Hrs(objProsp.Email) <= 24)
                {
                    objProsp.IsDuplicate = 44; //Hard Code for Duplicate
                    Result = objProspBM.AddProspectFromServ(objProsp);
                    if (Result > 0)
                    {
                        if (objProsp.IsFinance && IsNovatedLease)
                            UpdateFinCarLeads("Novated Leases", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Result, 0, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty);
                    }
                }
                else
                {
                    objProsp.IsDuplicate = 45; //Hard Code for Duplicate & Notified
                    Result = objProspBM.AddProspectFromServ(objProsp);
                    if (Result > 0)
                    {
                        if (objProsp.IsFinance && IsNovatedLease)
                            UpdateFinCarLeads("Novated Leases", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, Result, 0, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty);
                    }
                    DataSet Ds = objMasterBM.GetDupLeadsDetailsForNoti(objProsp.Email, Result);
                    if (Ds != null && Ds.Tables.Count > 0)
                    {
                        DataTable dt1 = Ds.Tables[0];
                        DataTable dt2 = Ds.Tables[1];
                        DataTable dt3 = Ds.Tables[2];
                        if (dt1 != null && dt2 != null && dt1.Rows.Count > 0 && dt2.Rows.Count > 0 && !string.IsNullOrEmpty(Convert.ToString(dt2.Rows[0]["ConsultEmail"]).Trim()))
                            SendConsultMail(dt2.Rows[0]["ConsultEmail"].ToString().Trim(), dt2.Rows[0]["AdminEmail"].ToString().Trim(), dt2.Rows[0]["ConsultName"].ToString().Trim(), dt1.Rows[0]["Name"].ToString().Trim(), dt1.Rows[0]["Email1"].ToString().Trim());
                        if (dt1 != null && dt3 != null && dt1.Rows.Count > 0 && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(Convert.ToString(dt3.Rows[0]["ConsultEmail"]).Trim()))
                            SendFCConsultMail(dt3.Rows[0]["ConsultEmail"].ToString().Trim(), dt3.Rows[0]["AdminEmail"].ToString().Trim(), dt3.Rows[0]["ConsultName"].ToString().Trim(), dt1.Rows[0]["Name"].ToString().Trim(), dt1.Rows[0]["Email1"].ToString().Trim());
                    }
                }
            }
            return Result;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddLeadsToPFSales ,SaveLeadsToPFSales.error" + ex.StackTrace);
            return 0;
        }
    }

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
    [WebMethod]
    public Int64 SaveLeadsFromPFWeb(string Name, string City, string phone, string mobile, string Email, string Finance, Boolean TradeIn, string PostalCode, string StateName, string tradeInMakeModel, string Comment, string Model, string WhereYouHearAbtPF, Boolean UsedOrNew, string IsFinanceSource, string Make, string alternateNo, string address, string leaseAmount, string employer, string SecurityCode, string Series, string Year, string BodyType, string BodyTypeOther, string Transmission, string Engine_Size_Type, string Budget, string Finance_Type, string KM)
    {
        try
        {
            Logger.Debug("Name:" + Name);
            Logger.Debug("City:" + City);
            Logger.Debug("phone:" + phone);
            Logger.Debug("mobile:" + mobile);
            Logger.Debug("Email:" + Email);
            Logger.Debug("Finance:" + Finance);
            Logger.Debug("TradeIn:" + TradeIn);
            Logger.Debug("PostalCode:" + PostalCode);
            Logger.Debug("StateName:" + StateName);
            Logger.Debug("tradeInMakeModel:" + tradeInMakeModel);
            Logger.Debug("Comment:" + Comment);
            Logger.Debug("WhereYouHearAbtPF:" + WhereYouHearAbtPF);
            Logger.Debug("UsedOrNew:" + UsedOrNew);
            Logger.Debug("IsFinanceSource:" + IsFinanceSource);
            Logger.Debug("Make:" + Make);
            Logger.Debug("alternateNo:" + alternateNo);
            Logger.Debug("address:" + address);
            Logger.Debug("leaseAmount:" + leaseAmount);
            Logger.Debug("employer:" + employer);
            Logger.Debug("SecurityCode:" + SecurityCode);
            Logger.Debug("Series:" + Series);
            Logger.Debug("Year:" + Year);
            Logger.Debug("BodyType:" + BodyType);
            Logger.Debug("BodyTypeOther:" + BodyTypeOther);
            Logger.Debug("Transmission:" + Transmission);
            Logger.Debug("Engine_Size_Type:" + Engine_Size_Type);
            Logger.Debug("Budget:" + Budget);
            Logger.Debug("Finance_Type:" + Finance_Type);
            Logger.Debug("KM:" + KM);


            DbCommand cmd = null;
            DbCommand objCmd = null;
            DbCommand objCmd1 = null;
            Prospect objProsp = new Prospect();
            ProspectBM objProspBM = new ProspectBM();
            MasterBM objMasterBM = new MasterBM();
            Guid gi = Guid.NewGuid();
            objProsp.ProspKey = gi.ToString().Trim();
            Int64 Result = 0;
            Int64 CityId = 0;
            int StateID = 0;
            int MakeId = 0;

            cmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllStates");
            Cls_DataAccess.getInstance().AddInParameter(cmd, "@StateName", DbType.String, StateName);
            Cls_DataAccess.getInstance().AddInParameter(cmd, "@CountryId", DbType.Int64, 1);
            DataTable dt = Cls_DataAccess.getInstance().GetDataTable(cmd, null);

            if (dt != null && dt.Rows.Count == 1)
                StateID = Convert.ToInt32(dt.Rows[0]["Id"]);

            objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllMakes");
            Cls_DataAccess.getInstance().AddInParameter(objCmd, "Make", DbType.String, Make);
            DataTable DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
            if (DtResult != null && DtResult.Rows.Count == 1)
                MakeId = Convert.ToInt32(DtResult.Rows[0]["Id"]);


            cmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllCities");
            Cls_DataAccess.getInstance().AddInParameter(cmd, "@CityName", DbType.String, City);
            Cls_DataAccess.getInstance().AddInParameter(cmd, "@StateId", DbType.Int64, StateID);
            DataTable dtCity = Cls_DataAccess.getInstance().GetDataTable(cmd, null);

            if (dtCity != null && dtCity.Rows.Count == 1)
                CityId = Convert.ToInt32(dtCity.Rows[0]["Id"]);

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
            objProsp.StateId = StateID;
            objProsp.PostalCode = PostalCode.Trim();
            objProsp.LeadSource = "www.privatefleet.com.au";
            if (Finance.Trim().ToUpper() == "YES")
                objProsp.IsFinance = true;
            else
                objProsp.IsFinance = false;
            objProsp.TradeIn = TradeIn;
            objProsp.TradeInMkModel = tradeInMakeModel.Trim();
            objProsp.Comment = Comment.Trim();
            objProsp.IsActive = true;
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
                    //UpdateIsSynchronized("Y", RawPfId);
                    if (!string.IsNullOrEmpty(leaseAmount) || !string.IsNullOrEmpty(employer) || !string.IsNullOrEmpty(Finance_Type))
                        UpdatePFWebFinCarLeads(Finance_Type, string.Empty, string.Empty, string.Empty, leaseAmount, string.Empty, string.Empty, Result, 0, string.Empty, string.Empty, employer, string.Empty, 0, string.Empty);
                    if (!string.IsNullOrEmpty(SecurityCode) || !string.IsNullOrEmpty(Series) || !string.IsNullOrEmpty(Year) || !string.IsNullOrEmpty(BodyType) || !string.IsNullOrEmpty(BodyTypeOther) || !string.IsNullOrEmpty(Transmission) || !string.IsNullOrEmpty(Budget) || !string.IsNullOrEmpty(KM))
                        AddUsedCarDetails(0, Result, SecurityCode, Series, Year, BodyType, BodyTypeOther, Transmission, Engine_Size_Type, Budget, KM, 1);
                }
                //else
                //    UpdateIsSynchronized("F", RawPfId);
            }
            else
            {
                if (CheckFor24Hrs(objProsp.Email) <= 24)
                {
                    objProsp.IsDuplicate = 44; //Hard Code for Duplicate
                    Result = objProspBM.AddProspectsFromPFToCRM(objProsp);
                    if (Result > 0)
                    {
                        //UpdateIsSynchronized("Y", RawPfId);
                        if (!string.IsNullOrEmpty(leaseAmount) || !string.IsNullOrEmpty(employer) || !string.IsNullOrEmpty(Finance_Type))
                            UpdatePFWebFinCarLeads(Finance_Type, string.Empty, string.Empty, string.Empty, leaseAmount, string.Empty, string.Empty, Result, 0, string.Empty, string.Empty, employer, string.Empty, 0, string.Empty);
                        if (!string.IsNullOrEmpty(SecurityCode) || !string.IsNullOrEmpty(Series) || !string.IsNullOrEmpty(Year) || !string.IsNullOrEmpty(BodyType) || !string.IsNullOrEmpty(BodyTypeOther) || !string.IsNullOrEmpty(Transmission) || !string.IsNullOrEmpty(Budget) || !string.IsNullOrEmpty(KM))
                            AddUsedCarDetails(0, Result, SecurityCode, Series, Year, BodyType, BodyTypeOther, Transmission, Engine_Size_Type, Budget, KM, 1);
                    }
                    //else
                    //UpdateIsSynchronized("F", RawPfId);
                }
                else
                {
                    objProsp.IsDuplicate = 45; //Hard Code for Duplicate & Notified
                    Result = objProspBM.AddProspectsFromPFToCRM(objProsp);
                    if (Result > 0)
                    {
                        //UpdateIsSynchronized("Y", RawPfId);
                        if (!string.IsNullOrEmpty(leaseAmount) || !string.IsNullOrEmpty(employer) || !string.IsNullOrEmpty(Finance_Type))
                            UpdatePFWebFinCarLeads(Finance_Type, string.Empty, string.Empty, string.Empty, leaseAmount, string.Empty, string.Empty, Result, 0, string.Empty, string.Empty, employer, string.Empty, 0, string.Empty);
                        if (!string.IsNullOrEmpty(SecurityCode) || !string.IsNullOrEmpty(Series) || !string.IsNullOrEmpty(Year) || !string.IsNullOrEmpty(BodyType) || !string.IsNullOrEmpty(BodyTypeOther) || !string.IsNullOrEmpty(Transmission) || !string.IsNullOrEmpty(Budget) || !string.IsNullOrEmpty(KM))
                            AddUsedCarDetails(0, Result, SecurityCode, Series, Year, BodyType, BodyTypeOther, Transmission, Engine_Size_Type, Budget, KM, 1);
                    }
                    //else
                    //    UpdateIsSynchronized("F", RawPfId);
                    DataSet Ds = objMasterBM.GetDupLeadsDetailsForNoti(objProsp.Email, Result);
                    if (Ds != null && Ds.Tables.Count > 0)
                    {
                        DataTable dt1 = Ds.Tables[0];
                        DataTable dt2 = Ds.Tables[1];
                        DataTable dt3 = Ds.Tables[2];
                        if (dt1 != null && dt2 != null && dt1.Rows.Count > 0 && dt2.Rows.Count > 0 && !string.IsNullOrEmpty(Convert.ToString(dt2.Rows[0]["ConsultEmail"]).Trim()))
                            SendConsultMail(dt2.Rows[0]["ConsultEmail"].ToString().Trim(), dt2.Rows[0]["AdminEmail"].ToString().Trim(), dt2.Rows[0]["ConsultName"].ToString().Trim(), dt1.Rows[0]["Name"].ToString().Trim(), dt1.Rows[0]["Email1"].ToString().Trim());
                        if (dt1 != null && dt3 != null && dt1.Rows.Count > 0 && dt3.Rows.Count > 0 && !string.IsNullOrEmpty(Convert.ToString(dt3.Rows[0]["ConsultEmail"]).Trim()))
                            SendFCConsultMail(dt3.Rows[0]["ConsultEmail"].ToString().Trim(), dt3.Rows[0]["AdminEmail"].ToString().Trim(), dt3.Rows[0]["ConsultName"].ToString().Trim(), dt1.Rows[0]["Name"].ToString().Trim(), dt1.Rows[0]["Email1"].ToString().Trim());
                    }
                }
            }
            return Result;
        }
        catch (Exception ex)
        {
            //UpdateIsSynchronized("F", RawPfId);
            Logger.Error(ex.Message + "AddLeadsToPFSales ,SaveLeadsFromPFWeb.error" + ex.StackTrace);
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
            Logger.Error(ex.Message + "AddLeadsToPFSales ,ShowEmployeeName.error" + ex.StackTrace);
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
            Logger.Error(ex.Message + "AddLeadsToPFSales ,CheckDuplicateLeads.error" + ex.StackTrace);
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
            Logger.Error(ex.Message + "AddLeadsToPFSales ,CheckFor24Hrs.error" + ex.StackTrace);
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
        Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
        string FileContent = string.Empty;
        try
        {

            //objEmailHelper.EmailFromID = BasePage.UserSession.EmailFromID;ConfigurationManager.AppSettings["EmailFromID"].ToString();
            objEmailHelper.EmailSubject = "Duplicate Lead Notified";
            //objEmailHelper.SMTPServerIP = ConfigurationManager.AppSettings["SMTPServerIP"].ToString();
            // objEmailHelper.SMTPUserID = ConfigurationManager.AppSettings["SMTPUserID"].ToString();
            // objEmailHelper.SMTPUserPwd = ConfigurationManager.AppSettings["SMTPUserPwd"].ToString();
            objEmailHelper.EmailToID = emilToId;
            objEmailHelper.EmailCcID = emailCCid;
            //objEmailHelper.EmailCcID = "pravin.gholap@mechsoftgroup.com";
            FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + Name.Trim() + "<br /><br /> Duplicate Lead is reported for the lead which is already allocated to you, Please find the details as given bellow.<br /><br /> Name:" + prospName.Trim() + "<br /><br /> Email:" + prospEmail.Trim() + "<br /><br />Thanks you<br /> PFSales Team</span>";
            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBM.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), "EMail sent successfully", "Duplicate Lead Notified", "Add Leads To PFSales Web Service");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Duplicate Lead Notified", "Add Leads To PFSales Web Service");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.SendMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Duplicate Lead Notified", "Add Leads To PFSales Web Service");
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
        Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
        try
        {

            //objEmailHelper.EmailFromID = BasePage.UserSession.EmailFromID;ConfigurationManager.AppSettings["EmailFromID"].ToString();
            objEmailHelper.EmailSubject = "Duplicate Lead Notified";
            //objEmailHelper.SMTPServerIP = ConfigurationManager.AppSettings["SMTPServerIP"].ToString();
            // objEmailHelper.SMTPUserID = ConfigurationManager.AppSettings["SMTPUserID"].ToString();
            // objEmailHelper.SMTPUserPwd = ConfigurationManager.AppSettings["SMTPUserPwd"].ToString();
            objEmailHelper.EmailToID = emilToId;
            objEmailHelper.EmailCcID = emailCCid;
            //objEmailHelper.EmailCcID = "pravin.gholap@mechsoftgroup.com";
            FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + Name.Trim() + "<br /><br /> Duplicate Lead is reported for the lead which is already allocated to you, Please find the details as given bellow.<br /><br /> Name:" + prospName.Trim() + "<br /><br /> Email:" + prospEmail.Trim() + "<br /><br />Thanks you<br /> PFSales Team</span>";
            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBM.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), "EMail sent successfully", "Duplicate Lead Notified", "Add Leads To PFSales Web Service");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Duplicate Lead Notified", "Add Leads To PFSales Web Service");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.SendMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Duplicate Lead Notified", "Add Leads To PFSales Web Service");
            return false;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 Sept 2013
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
                return "Success";
            }
            return "No Prospect Id";
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddLeadsToPFSales.UpdateFinCarLeads.Error:" + ex.StackTrace);
            return "Error in connection";
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
    private string UpdatePFWebFinCarLeads(string FinanceType, string Message, string CreditHistory, string Terms, string EstimatedFinanced, string Payment, string InitialDeposit, Int64 ProspectID, Int64 FCId, string Employment, string Current_Income, string Employer, string Time_in_Current_Emp, Int16 FinLeadType, string Time_At_Cur_Add)
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
            Logger.Error("Cls_ReminderProcess.UpdateFinCarLeads. Inner Exception:" + ex.InnerException);
            Logger.Error(ex.Message + "Cls_ReminderProcess.UpdateFinCarLeads.Error:" + ex.StackTrace);
            return "Error in connection";
        }
        return "Success";
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
    private Int64 AddUsedCarDetails(Int64 Id, Int64 ProspectId, string SecurityCode, string Series, string Year, string BodyType, string BodyTypeOther, string Transmission, string Engine_Size_Type, string Budget, string KM, Int64 CreatedById)
    {
        try
        {
            ProspectBM objProspBM = new ProspectBM();
            Int64 result = objProspBM.AddUsedCarDetails(Id, ProspectId, SecurityCode, Series, Year, BodyType, BodyTypeOther, Transmission, Engine_Size_Type, Budget, KM, CreatedById);
            return result;
        }
        catch (Exception ex)
        {
            Logger.Error("Cls_ReminderProcess.UpdateFinCarLeads. Inner Exception:" + ex.InnerException);
            Logger.Error(ex.Message + "Cls_ReminderProcess.UpdateFinCarLeads.Error:" + ex.StackTrace);
            return 0;
        }
    }
}

