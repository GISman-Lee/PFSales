using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using log4net;
using AccessControlUnit;
using System.Data;
using System.Data.Common;
using Mechsoft.GeneralUtilities;
using System.Text;
using System.Configuration;
using System.Collections;



/// <summary>
/// Summary description for SyncDataFromQuote
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class SyncDataFromQuote : System.Web.Services.WebService
{
    #region Global Variables
    ILog logger = LogManager.GetLogger(typeof(SyncDataFromQuote));
    #endregion
    public SyncDataFromQuote()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }




    /* Whenever Changes Done to Dealer In Quote Also Do Related Changes To Same Dealer in CRM*/
    /// <summary>
    /// Created By :Ayyaj Mujawar
    /// Created Date: 28 Oct 2013
    /// Description: Synchronized Data (Dealer) From Quote
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="CreatedDateTime"></param>
    /// <param name="MakeId"></param>
    /// <param name="CityId"></param>
    /// <param name="phone"></param>
    /// <param name="mobile"></param>
    /// <param name="Email"></param>
    /// <param name="PostalCode"></param>
    /// <param name="IsActive"></param>
    /// <param name="StateId"></param>
    /// <returns></returns>
    //[WebMethod]
    //public Int64 SaveDealerFromQuote(string Name, string key, string company, string address, Int16 MakeId, Int32 CityId, string phone, string mobile, string Email, string fax, string PostalCode, Int32 StateId, Int32 SecStateId, Boolean IsActive, Boolean IsHotDealer, Boolean IsColdDealer, Boolean IsNew)
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public Int64 SaveDealerFromQuote(string Name, string key, string company, Int16 MakeId, Int32 CityId, string phone, string Email, string fax, string PostalCode, Int32 StateId, Boolean IsDeleted, Int32 CreatedById, Boolean IsNew)
    {
        DbCommand objCmd = null;
        DbCommand objCmd1 = null;
        Int64 Result = 0;
        //Int64 Result1 = 0;//For Check Update Procedure
        //Int64 UserId = 0;
        DbConnection objConn = null;
        DbTransaction objTran = null;


        try
        {
            objConn = Cls_DataAccess.getInstance().GetConnection();
            objConn.Open();

            if (!string.IsNullOrEmpty(Name.Trim()) && !string.IsNullOrEmpty(key.Trim()))
            {
                objTran = objConn.BeginTransaction();

                /*To Split Name Into Fname And LName*/
                string FName = string.Empty;
                string LName = string.Empty;
                ArrayList str = ShowProspName(Name);
                if (str.Count == 3)
                {
                    FName = (str[0].ToString().Trim().Substring(0, 1).ToUpper() + str[0].ToString().Trim().Remove(0, 1)).Trim();
                    //objProsp.MName = (str[1].ToString().Trim().Substring(0, 1).ToUpper() + str[1].ToString().Trim().Remove(0, 1)).Trim();
                    LName = (str[1].ToString().Trim().Substring(0, 1).ToUpper() + str[1].ToString().Trim().Remove(0, 1)).Trim() + " " + (str[2].ToString().Trim().Substring(0, 1).ToUpper() + str[2].ToString().Trim().Remove(0, 1)).Trim();
                }
                else if (str.Count == 2)
                {
                    FName = (str[0].ToString().Trim().Substring(0, 1).ToUpper() + str[0].ToString().Trim().Remove(0, 1)).Trim();
                    //objProsp.MName = string.Empty;
                    LName = (str[1].ToString().Trim().Substring(0, 1).ToUpper() + str[1].ToString().Trim().Remove(0, 1)).Trim();
                }
                else if (str.Count == 1)
                {
                    FName = (str[0].ToString().Trim().Substring(0, 1).ToUpper() + str[0].ToString().Trim().Remove(0, 1)).Trim();
                    //objProsp.MName = string.Empty;
                    LName = string.Empty;
                }
                /*----------------------------------*/


                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddUpdateDealerFromQuote");
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objEmp.DesigId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FName", DbType.String, FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "LName", DbType.String, LName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Key", DbType.String, key);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Company", DbType.String, company);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Phone", DbType.String, phone);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "Mobile", DbType.String, mobile);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email", DbType.String, Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Fax", DbType.String, fax);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "City", DbType.Int64, CityId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "State", DbType.String, StateId.ToString());
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "SecondaryStateId", DbType.String, SecStateId.ToString());
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PostalCode", DbType.String, PostalCode);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, IsDeleted);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsHotDealer", DbType.Boolean, IsHotDealer);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsColdDealer", DbType.Boolean, IsColdDealer);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedDate", DbType.DateTime, CreatedDateTime);

                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));

                if (Result > 0 && !string.IsNullOrEmpty(Name.Trim()))
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
                return 0;
            }
        }
        catch (Exception ex)
        {
            objTran.Rollback();
            logger.Error(ex.Message + "AddLeadsToPFSales ,SaveDealerFromCRM.error" + ex.StackTrace);
            return 0;
        }
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public Int64 SaveDealerMakeMapFromQuote(string key, Int16 MakeId, Boolean IsDeleted, Int32 CreatedById, Boolean IsNew)
    {
        DbCommand objCmd = null;
        DbCommand objCmd1 = null;
        Int64 Result = 0;
        DbConnection objConn = null;
        DbTransaction objTran = null;
        try
        {
            objConn = Cls_DataAccess.getInstance().GetConnection();
            objConn.Open();

            objCmd1 = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "SpGetDealerIDByKey");
            Cls_DataAccess.getInstance().AddInParameter(objCmd1, "Key", DbType.String, key);
            DataTable DtResult1 = Cls_DataAccess.getInstance().GetDataTable(objCmd1, null);

            Int64 DealerID = 0;
            if (DtResult1.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString((DtResult1.Rows[0]["ID"]))))
                {
                    DealerID = Convert.ToInt64(DtResult1.Rows[0]["ID"]);
                }
                else
                {
                    DealerID = 0;
                }
            }


            if (CreatedById > 0 && !string.IsNullOrEmpty(Convert.ToString(MakeId)) && DealerID > 0)
            {
                objTran = objConn.BeginTransaction();
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_DealerMakeMappingFromQuote");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "DealerID", DbType.Int64, DealerID);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MakeId", DbType.Int64, MakeId);
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
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {

            objTran.Rollback();
            logger.Error(ex.Message + "AddLeadsToPFSales ,SaveMakeDealerMapFromQuote.error" + ex.StackTrace);
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
            logger.Error(ex.Message + "SyncDataFromQuote ,SaveDealerFromQuote.error" + ex.StackTrace);
            return null;
        }
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public Int64 SaveSendEmailDetailsFromQuote(string EmailTo, string EmailFromID, string EmailText, string Status, string Subject, string PageName)
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
            logger.Error(ex.Message + "SyncDataFromQuote, SaveSendEmailDetailsFromQuote.Error:" + ex.StackTrace);
            return 0;
        }


    }


}

