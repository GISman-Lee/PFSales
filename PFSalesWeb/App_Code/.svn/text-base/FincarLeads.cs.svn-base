using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using log4net;
using System.Data.Common;
using Mechsoft.GeneralUtilities;
using System.Data;

/// <summary>
/// Summary description for FincarLeads
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class FincarLeads : System.Web.Services.WebService
{
    #region Gloabal Varriable

    ILog Logger = LogManager.GetLogger(typeof(FincarLeads));

    #endregion

    #region Constructor

    public FincarLeads()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    #endregion

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public string AddFinCarLeads(string Name, string Email, string PhoneNo, string FinanceType, string State, string Message, string CreditHistory, string Terms, string EstimatedFinanced, string Payment, string InitialDeposit, string WebSource, Int16 FinLeadType)
    {
        DbCommand cmd = null;
        try
        {

            int StateID = 0;
            cmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllStates");
            Cls_DataAccess.getInstance().AddInParameter(cmd, "@StateName", DbType.String, State);
            Cls_DataAccess.getInstance().AddInParameter(cmd, "@CountryId", DbType.Int64, 1);
            DataTable dt = Cls_DataAccess.getInstance().GetDataTable(cmd, null);

            if (dt != null && dt.Rows.Count == 1)
                StateID = Convert.ToInt32(dt.Rows[0]["Id"]);

            AddLeadsToPFSales addProspect = new AddLeadsToPFSales();
            Int64 ProspectID = addProspect.SaveLeadsToPFSales(Name, System.DateTime.Now, WebSource.Trim(), 0, 0, PhoneNo.Trim(), string.Empty, Email.Trim(), true, false, string.Empty, true, StateID, string.Empty, string.Empty, string.Empty, string.Empty, false, "F",false);

            if (ProspectID > 0)
            {
                cmd = null;
                cmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "usp_SaveFincarLeads");
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
                if (FinLeadType != 0)
                    Cls_DataAccess.getInstance().AddInParameter(cmd, "@FinLeadTypeId", DbType.Int16, FinLeadType);

                object obj = Cls_DataAccess.getInstance().ExecuteScaler(cmd, null);
                int Result = Convert.ToInt32(obj); 
                return "Success";
            }
            return "No ProspectId Found";
        }
        catch (Exception ex)
        {
            Logger.Error("Fincar lead add error - " + ex.Message);
            return "Error in connection";
        }
       
    }

    [WebMethod]
    public string AddFinCarLeadsWithDet(string Name, string Email, string PhoneNo, string FinanceType, string State, string Message, string CreditHistory, string Terms, string EstimatedFinanced, string Payment, string InitialDeposit, string WebSource, string address1, string address2, string Employment, string Current_Income, string Employer, string Time_in_Current_Emp, Int16 FinLeadType, string city, string Time_At_Cur_Add)
    {
        DbCommand cmd = null;
        try
        {
            Logger.Debug("In Add FinCar Leads With Name:" + Name);
            Logger.Debug("In Add FinCar Leads With Email:" + Email);
            Logger.Debug("In Add FinCar Leads With PhoneNo:" + PhoneNo);
            Logger.Debug("In Add FinCar Leads With FinanceType:" + FinanceType);
            Logger.Debug("In Add FinCar Leads With State:" + State);
            Logger.Debug("In Add FinCar Leads With Message:" + Message);
            Logger.Debug("In Add FinCar Leads With CreditHistory:" + CreditHistory);
            Logger.Debug("In Add FinCar Leads With Terms:" + Terms);
            Logger.Debug("In Add FinCar Leads With EstimatedFinanced:" + EstimatedFinanced);
            Logger.Debug("In Add FinCar Leads With Payment:" + Payment);
            Logger.Debug("In Add FinCar Leads With InitialDeposit:" + InitialDeposit);
            Logger.Debug("In Add FinCar Leads With WebSource:" + WebSource);
            Logger.Debug("In Add FinCar Leads With address1:" + address1);
            Logger.Debug("In Add FinCar Leads With address2:" + address2);
            Logger.Debug("In Add FinCar Leads With Employment:" + Employment);
            Logger.Debug("In Add FinCar Leads With Current_Income:" + Current_Income);
            Logger.Debug("In Add FinCar Leads With Employer:" + Employer);
            Logger.Debug("In Add FinCar Leads With Time_in_Current_Emp:" + Time_in_Current_Emp);
            Logger.Debug("In Add FinCar Leads With FinLeadType:" + FinLeadType);
            Logger.Debug("In Add FinCar Leads With city:" + city);
            Logger.Debug("In Add FinCar Leads With Time_At_Cur_Add:" + Time_At_Cur_Add);
            int StateID = 0;
            cmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllStates");
            Cls_DataAccess.getInstance().AddInParameter(cmd, "@StateName", DbType.String, State.Trim());
            Cls_DataAccess.getInstance().AddInParameter(cmd, "@CountryId", DbType.Int64, 1);
            DataTable dt = Cls_DataAccess.getInstance().GetDataTable(cmd, null);

            if (dt != null && dt.Rows.Count == 1)
                StateID = Convert.ToInt32(dt.Rows[0]["Id"]);

            int CityID = 0;
            cmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllCities");
            Cls_DataAccess.getInstance().AddInParameter(cmd, "@CityName", DbType.String, city.Trim());
            Cls_DataAccess.getInstance().AddInParameter(cmd, "@StateId", DbType.Int64, StateID);
            DataTable dtCity = Cls_DataAccess.getInstance().GetDataTable(cmd, null);

            if (dtCity != null && dtCity.Rows.Count > 0)
                CityID = Convert.ToInt32(dtCity.Rows[0]["Id"]);

            AddLeadsToPFSales addProspect = new AddLeadsToPFSales();
            Int64 ProspectID = addProspect.SaveLeadsFrmFinToPFSales(Name, System.DateTime.Now, WebSource.Trim(), 0, CityID, PhoneNo.Trim(), string.Empty, Email.Trim(), true, false, string.Empty, true, StateID, string.Empty, string.Empty, string.Empty, string.Empty, false, "F", address1.Trim(), address2.Trim());
            Logger.Debug("In Add FinCar Leads With Det Results From SaveLeadsFrmFinToPFSales is:" + ProspectID);

            if (ProspectID > 0)
            {
                Logger.Debug("In Save Fincar Leads With Prospect ID=" + ProspectID);

                cmd = null;
                cmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "usp_SaveFincarLeads");
                Cls_DataAccess.getInstance().AddInParameter(cmd, "@ProspectID", DbType.Int64, ProspectID);
                Logger.Debug("Prospect Id:" + ProspectID);
                if (!string.IsNullOrEmpty(FinanceType))
                {

                    Cls_DataAccess.getInstance().AddInParameter(cmd, "@FinanceType", DbType.String, FinanceType.Trim());
                    Logger.Debug("Finance Type:" + FinanceType.Trim());
                }
                if (!string.IsNullOrEmpty(Message))
                {
                    Cls_DataAccess.getInstance().AddInParameter(cmd, "@Message", DbType.String, Message.Trim());
                    Logger.Debug("Message:" + Message.Trim());
                }
                if (!string.IsNullOrEmpty(CreditHistory))
                {
                    Cls_DataAccess.getInstance().AddInParameter(cmd, "@CreditHistory", DbType.String, CreditHistory.Trim());
                    Logger.Debug("Credit History:" + CreditHistory.Trim());
                }
                if (!string.IsNullOrEmpty(Terms))
                {
                    Cls_DataAccess.getInstance().AddInParameter(cmd, "@Terms", DbType.String, Terms.Trim());
                    Logger.Debug("Terms:" + Terms.Trim());
                }
                if (!string.IsNullOrEmpty(EstimatedFinanced))
                {
                    Cls_DataAccess.getInstance().AddInParameter(cmd, "@EstimatedFinanced", DbType.String, EstimatedFinanced.Trim());
                    Logger.Debug("Estimated Financed:" + EstimatedFinanced.Trim());
                }
                if (!string.IsNullOrEmpty(Payment))
                {
                    Cls_DataAccess.getInstance().AddInParameter(cmd, "@Payment", DbType.String, Payment.Trim());
                    Logger.Debug("Payment:" + Payment.Trim());
                }
                if (!string.IsNullOrEmpty(InitialDeposit))
                {
                    Cls_DataAccess.getInstance().AddInParameter(cmd, "@InitialDeposit", DbType.String, InitialDeposit.Trim());
                    Logger.Debug("Initial Deposit:" + InitialDeposit.Trim());
                }
                if (!string.IsNullOrEmpty(Employment))
                {
                    Cls_DataAccess.getInstance().AddInParameter(cmd, "@Employment", DbType.String, Employment.Trim());
                    Logger.Debug("Employment:" + Employment.Trim());
                }
                if (!string.IsNullOrEmpty(Current_Income))
                {
                    Cls_DataAccess.getInstance().AddInParameter(cmd, "@CurrentIncome", DbType.String, Current_Income.Trim());
                    Logger.Debug("Current_Income:" + Current_Income.Trim());
                }
                if (!string.IsNullOrEmpty(Employer))
                {
                    Cls_DataAccess.getInstance().AddInParameter(cmd, "@Employer", DbType.String, Employer.Trim());
                    Logger.Debug("Employer:" + Employer.Trim());
                }
                if (!string.IsNullOrEmpty(Time_in_Current_Emp))
                {
                    Cls_DataAccess.getInstance().AddInParameter(cmd, "@Time_in_Cur_Emp", DbType.String, Time_in_Current_Emp.Trim());
                    Logger.Debug("Time_in_Cur_Emp:" + Time_in_Current_Emp.Trim());
                }
                if (FinLeadType != 0)
                {
                    Cls_DataAccess.getInstance().AddInParameter(cmd, "@FinLeadTypeId", DbType.Int16, FinLeadType);
                    Logger.Debug("Fin Lead Type:" + FinLeadType);
                }
                if (!string.IsNullOrEmpty(Time_At_Cur_Add))
                {
                    Cls_DataAccess.getInstance().AddInParameter(cmd, "@Time_At_Cur_Add", DbType.String, Time_At_Cur_Add.Trim());
                    Logger.Debug("Time_At_Cur_Add:" + Time_At_Cur_Add);
                }
                object obj = Cls_DataAccess.getInstance().ExecuteScaler(cmd, null);
                Logger.Debug("In Add Fincar Details With Object Value:" + obj.ToString());
                int Result = Convert.ToInt32(obj);
                Logger.Debug("In Save Fincar Leads With Result=" + Result);
            }
        }
        catch (Exception ex)
        {
            Logger.Error("Fincar lead add inner exception - " + ex.StackTrace);
            Logger.Error("Fincar lead add inner exception - " + ex.InnerException);
            Logger.Error("Fincar lead add error - " + ex.Message);
            return "Error in connection";
        }
        return "Success";
    }

}

