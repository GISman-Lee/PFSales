using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Mechsoft.GeneralUtilities;


public partial class TestPage : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        Int32[] test1 = AllocateLeads(9, 10, 8);

        System.Media.SystemSounds.Asterisk.Play();
    }
    private Int32[] AllocateLeads(int ConsultantCount, int LeadCnt, int TotalLeads)
    {
        Int32[] test = new Int32[ConsultantCount];
        try
        {
            if ((ConsultantCount * LeadCnt) <= TotalLeads)
            {
                // assign Normal way - Each consultant will get leads of count LeadCnt
                for (int i = 0; i < ConsultantCount; i++)
                    test[i] = LeadCnt;
            }
            else
            {
                int cnt = TotalLeads / ConsultantCount;
                int mod = TotalLeads % ConsultantCount;
                if (cnt > 0)
                {
                    for (int i = 0; i < ConsultantCount; i++)
                    {
                        test[i] = cnt;
                    }
                }
                if (mod > 0)
                {
                    for (int i = 0; i < mod; i++)
                    {
                        test[i] = test[i] + 1;
                    }
                }
            }
        }
        catch (Exception ex)
        {

            throw;
        }
        return test;
    }

    protected void lnkbtnTest_Click(object sender, EventArgs e)
    {
        AddDataToPFSales.AddLeadsToPFSalesSoapClient objadd = new AddDataToPFSales.AddLeadsToPFSalesSoapClient();
        //AddFinCarLeads.FincarLeadsSoapClient objFinAdd = new AddFinCarLeads.FincarLeadsSoapClient();
        //SyncDataFromCRMToPF.SyncDataFromCRMSoapClient objDealerAdd = new SyncDataFromCRMToPF.SyncDataFromCRMSoapClient();
        //objDealerAdd.SaveDealerFromCRM("Akshay", "dfhbddfgddfgfgoooooo", "Mechsoft", "KArad", 2, 2, "8087114580", "8087114580", "Akshay@mechsoftgroup.com", "020113355", "2215", 2, 1, true, false, false, DateTime.Now,true);
        //AddLeadsToPFSales service = new AddLeadsToPFSales();
        // service.Url = "http://180.235.129.33/PFSales/AddLeadsToPFSales.asmx";
        //service.SaveLeadsFromPFWeb();
        //objadd.SaveLeadsToPFSales("Yogesh Balasaheb Gholap", DateTime.Today, "mechsoftgroup.com", 2, 31, "9421006185", "9881392684", "pravin.gholap@mechsoftgroup.com", false, true, "415011", true, 6, "Trade In Make Model", "Commented", "", "", false, "W",true);
        // objadd.SaveLeadsFromPFWeb("Yogesh Balasaheb Gholap", "vwdiscounts.com.au", "Hyundai", 0, "35432543534", "pravin.gholap@mechsoftgroup.com", "65765765756", true, true, "4546", true, "QLD", "", "Commented", "", "", false, "W", false);
        //objadd.SaveLeadsToCRM("Rupali Ashok Divekar","mechsoftgroup.com", "Hundai", "Darwin", "9421006185", "9881392684", "rupali.khande@mechsoftgroup.com", false, true, "800", true, "NT", "Trade In Make Model", "Commented", "Model", "Referred by Existing Client", false, "W","8149362334");
        //objadd.SaveEmpToPFSales(1, "Deepak Madaane", "9421006185", "23243", "deepak.madane@mechsoftgroup.com", "7285618056", "Lonand", "", "", "123456", "57c87db9-768c-4dc5-b033-e9561af14b7d", false, 100);
        //objadd.ChangeIsActiveStatus(100, false, 1);
        //SetLoginDetailsFromQuote();
        //objFinAdd.AddFinCarLeadsWithDet("AM", "test34@mechsoftgroup.com", "54641213", "Personal Finance", "WA", "Message", "", "54654654", "546546", "", "", "www.fincar.com.au", "perth", "", "Full Time", "121312", "mechsoft", "Over 3 years", 6, "perth", "Greater Than 3 years");
        //objFinAdd.AddFinCarLeadsWithDet("testbypravin", "testbypravin@mechsoftgroup.com", "6765765765", "Business Finance", "WA", "This is testing entry please ignore it", string.Empty, "54", "546546", string.Empty, string.Empty, "www.fincar.com.au", "54654654", string.Empty, "Full Time", "3543534", "mechsoft", "Over 3 years", 6, "perth", "Greater Than 3 years");

        //try
        //{
        //    string ert = "";
        //    string ert1 = string.Empty;
        //    string ert2 = null;
        //    ert = ert.Trim();
        //    ert1 = ert1.Trim();
        //    ert2 = ert2.Trim();
        //    if (!ert.Equals(string.Empty))
        //        Response.Write("ert");
        //    if (!ert1.Equals(string.Empty))
        //        Response.Write("ert1");
        //    if (!ert2.Equals(string.Empty))
        //        Response.Write("ert2");
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
    }

    private void SetLoginDetailsFromQuote()
    {
        SqlConnection con = new SqlConnection(@ConfigurationManager.AppSettings["QuoteDB"].ToString().Trim());
        try
        {
            AddDataToPFSales.AddLeadsToPFSalesSoapClient objadd = new AddDataToPFSales.AddLeadsToPFSalesSoapClient();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT B.RoleID, A.ID, A.Username, A.Password, A.Name, A.Email, A.Phone, A.Extension, A.Mobile, A.Address, A.UsernameExpiryDate, A.IsActive FROM ACU_UserMaster AS A INNER JOIN  ACU_UserRoleDetails AS B ON A.ID = B.UserID AND (B.RoleID = 1 OR B.RoleID = 3) AND A.IsActive = 1 AND B.IsActive = 1", con);
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Guid gi = Guid.NewGuid();
                    objadd.SaveEmpToPFSales(Convert.ToInt32(dt.Rows[i]["RoleID"].ToString().Trim()), dt.Rows[i]["Name"].ToString().Trim(), dt.Rows[i]["Phone"].ToString().Trim(), dt.Rows[i]["Extension"].ToString().Trim(), dt.Rows[i]["Email"].ToString().Trim(), dt.Rows[i]["Mobile"].ToString().Trim(), dt.Rows[i]["Address"].ToString().Trim(), string.Empty, string.Empty, dt.Rows[i]["Password"].ToString().Trim(), gi.ToString().Trim(), false, Convert.ToInt64(dt.Rows[i]["ID"].ToString().Trim()));
                }
            }
        }
        catch (Exception ex)
        {
            //Logger.Error(ex.Message + "GotoDashBoard.Error" + ex.StackTrace);
        }
        finally
        {
            con.Close();
        }
    }

    protected void lnkbtnShowDecr_Click(object sender, EventArgs e)
    {
        lblDecrypted.Text = Cls_Encryption.DecryptTripleDES(txtEncrypted.Text.Trim());
    }
}
