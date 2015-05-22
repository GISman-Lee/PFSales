using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Mechsoft.PFSales.BusinessEntity;
using Mechsoft.PFSales.BusinessManager;
using log4net;
using System.Reflection;
using Mechsoft.GeneralUtilities;
using System.Configuration;
using ServiceReference1;
using System.Web.UI.HtmlControls;
using System.Data.Common;

public partial class UserControls_UC_ProspectDetails : System.Web.UI.UserControl
{
    #region Global Variables
    ProspectBM objProspBM = new ProspectBM();
    ILog Logger = LogManager.GetLogger(typeof(UserControls_UC_ProspectDetails));
    ActivityBM objActivityBM = new ActivityBM();
    MasterBM objMstBM = new MasterBM();
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // 5 for fincar consultant
            if (BasePage.UserSession.RoleId == 5)
            {
                lnkCreateQuote.Visible = false;
            }
            else
            {
                if (IsQuoteExist())
                {
                    lnkCreateQuote.Visible = false;
                    lnkViewQuoteRequest.Visible = true;
                }
                else
                    lnkCreateQuote.Visible = true;
            }
        }

        if(BasePage.UserSession.RoleName == "Admin")
        {
            this.lblCreateContract.Visible = true;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Close Panel Of Add/ Edit Contact
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddContactClose_Click(object sender, EventArgs e)
    {
        pnlAddContact.Visible = false;
        CleraMsg();
    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date: 21 Feb 2014
    /// Description: To Redirect to Trade In Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnTradeIn_Click(object sender, EventArgs e)
    {
       // Session["ProspectTradeId"] = username.ToString();
        Response.Redirect("TradeIn.aspx");
    }
    

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Open Panel Of Add/ Edit Contact for Edit
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnEditContact_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtnSave = (LinkButton)UC_AddEditContact1.FindControl("lnkbtnSave");
        LinkButton lnkbtnFinalClear = (LinkButton)UC_AddEditContact1.FindControl("lnkbtnFinalClear");

        MethodInfo methodsAEC = UC_AddEditContact1.GetType().GetMethod("BindAllStatuses");
        if (methodsAEC != null)
            methodsAEC.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC1 = UC_AddEditContact1.GetType().GetMethod("BindAllCountry");
        if (methodsAEC1 != null)
            methodsAEC1.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC2 = UC_AddEditContact1.GetType().GetMethod("BindFormats");
        if (methodsAEC2 != null)
            methodsAEC2.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC3 = UC_AddEditContact1.GetType().GetMethod("BindAllMakes");
        if (methodsAEC3 != null)
            methodsAEC3.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC4 = UC_AddEditContact1.GetType().GetMethod("BindAllSources");
        if (methodsAEC4 != null)
            methodsAEC4.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC5 = UC_AddEditContact1.GetType().GetMethod("BindConsultant");
        if (methodsAEC5 != null)
            methodsAEC5.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC6 = UC_AddEditContact1.GetType().GetMethod("BindFConsultant");
        if (methodsAEC6 != null)
            methodsAEC6.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC7 = UC_AddEditContact1.GetType().GetMethod("BindContacts");
        if (methodsAEC7 != null)
            methodsAEC7.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC8 = UC_AddEditContact1.GetType().GetMethod("BindProfessions");
        if (methodsAEC8 != null)
            methodsAEC8.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC9 = UC_AddEditContact1.GetType().GetMethod("BindFinance");
        if (methodsAEC9 != null)
            methodsAEC9.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC10 = UC_AddEditContact1.GetType().GetMethod("BindWUHValues");
        if (methodsAEC10 != null)
            methodsAEC10.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC11 = UC_AddEditContact1.GetType().GetMethod("BinFinReqFrom");
        if (methodsAEC11 != null)
            methodsAEC11.Invoke(UC_AddEditContact1, null);

        if (lnkbtnFinalClear != null && lnkbtnSave != null)
        {
            pnlAddContact.Visible = true;
            TextBox txtPostalCode = (TextBox)UC_AddEditContact1.FindControl("txtPostalCode");
            RequiredFieldValidator rfvPCode = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvPCode");
            DropDownList ddlPostalCode = (DropDownList)UC_AddEditContact1.FindControl("ddlPostalCode");
            RequiredFieldValidator rfvPostalCode = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvPostalCode");
            if (txtPostalCode != null && rfvPCode != null && ddlPostalCode != null && rfvPostalCode != null)
            {
                if (Session["ForW"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["ForW"]).Trim()))
                {
                    if (Convert.ToString(Session["ForW"]).Trim().ToUpper() == "W")
                    {
                        txtPostalCode.Visible = rfvPCode.Enabled = false;
                        ddlPostalCode.Visible = rfvPostalCode.Enabled = true;
                    }
                    else if (Convert.ToString(Session["ForW"]).Trim().ToUpper() == "F")
                    {
                        txtPostalCode.Visible = rfvPCode.Enabled = true;
                        ddlPostalCode.Visible = rfvPostalCode.Enabled = false;
                    }
                }
            }
           // pnlAddContact.Visible = false;

            RequiredFieldValidator rfvCarMake = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvCarMake");
            RequiredFieldValidator rfvPhone = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvPhone");
            RequiredFieldValidator rfvState = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvState");
            RequiredFieldValidator rfvSource = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvSource");
            RequiredFieldValidator rfvModel = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvModel");
            RequiredFieldValidator rfvCountry = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvCountry");
            RequiredFieldValidator rfvAECPostalCode = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvPostalCode");
            RequiredFieldValidator rfvAECPCode = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvPCode");
            RequiredFieldValidator rfvReferredBy = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvReferredBy");
            RequiredFieldValidator rfvStatus = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvStatus");

            if (rfvCarMake != null && rfvPhone != null && rfvState != null && rfvSource != null && rfvModel != null && rfvCountry != null && rfvAECPostalCode != null && rfvReferredBy != null && rfvStatus != null && rfvAECPCode != null)
            {
                if (BasePage.UserSession.RoleId == 1)
                {
                    rfvStatus.Enabled = rfvCarMake.Enabled = rfvPhone.Enabled = rfvState.Enabled = rfvModel.Enabled = rfvCountry.Enabled = rfvAECPostalCode.Enabled = rfvAECPCode.Enabled = rfvReferredBy.Enabled = false;
                }
                else if (BasePage.UserSession.RoleId == 3)
                {
                    rfvStatus.Enabled = rfvCarMake.Enabled = rfvPhone.Enabled = rfvState.Enabled = rfvModel.Enabled = rfvCountry.Enabled = rfvAECPostalCode.Enabled = rfvReferredBy.Enabled = true;
                    rfvAECPCode.Enabled = false;
                }
                else if (BasePage.UserSession.RoleId == 5)
                {
                    rfvStatus.Enabled = rfvCarMake.Enabled = rfvPhone.Enabled = rfvState.Enabled = rfvModel.Enabled = rfvCountry.Enabled = rfvAECPostalCode.Enabled = rfvReferredBy.Enabled = false;
                    rfvAECPCode.Enabled = true;
                }
                else
                {
                    rfvStatus.Enabled = rfvCarMake.Enabled = rfvPhone.Enabled = rfvState.Enabled = rfvModel.Enabled = rfvCountry.Enabled = rfvAECPostalCode.Enabled = rfvAECPCode.Enabled = rfvReferredBy.Enabled = true;
                }
            }


            MethodInfo methods = UC_AddEditContact1.GetType().GetMethod("ClearAll");
            if (methods != null)
                methods.Invoke(UC_AddEditContact1, null);
            MethodInfo methods1 = UC_AddEditContact1.GetType().GetMethod("ClearMsg");
            if (methods1 != null)
                methods1.Invoke(UC_AddEditContact1, null);
            MethodInfo methods2 = UC_AddEditContact1.GetType().GetMethod("EditContact");
            if (methods2 != null)
            {
                if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
                {
                    ////..modified by: Ayyaj
                    //Session["isPForFC"] = hdfProspectId.Value.Trim().ToString();
                    lblAddContactHead.Text = Resources.PFSalesResource.UpdteProspDetails.Trim();
                    object[] objParam = new object[] { Convert.ToInt64(hdfProspectId.Value.Trim()) };
                    methods2.Invoke(UC_AddEditContact1, objParam);
                    pnlAddContact.Visible = true;
                    lnkbtnSave.Text = Resources.PFSalesResource.update.Trim();
                    lnkbtnSave.ToolTip = Resources.PFSalesResource.UpdteProspDetails.Trim();
                    lnkbtnFinalClear.Text = Resources.PFSalesResource.Cancel.Trim();
                    lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.Cancel.Trim();
                }
            }
        }
        CleraMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Open Panel Of Add/ Edit Contact for adding new contact
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddNewContact_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtnSave = (LinkButton)UC_AddEditContact1.FindControl("lnkbtnSave");
        LinkButton lnkbtnFinalClear = (LinkButton)UC_AddEditContact1.FindControl("lnkbtnFinalClear");
        if (lnkbtnFinalClear != null && lnkbtnSave != null)
        {
            MethodInfo methods = UC_AddEditContact1.GetType().GetMethod("ClearAll");
            if (methods != null)
                methods.Invoke(UC_AddEditContact1, null);
            MethodInfo methods1 = UC_AddEditContact1.GetType().GetMethod("ClearMsg");
            if (methods1 != null)
                methods1.Invoke(UC_AddEditContact1, null);
            pnlAddContact.Visible = true;
            lblAddContactHead.Text = Resources.PFSalesResource.AddProspectDetails.Trim();
            lnkbtnSave.Text = Resources.PFSalesResource.Save.Trim();
            lnkbtnSave.ToolTip = Resources.PFSalesResource.SaveProspect.Trim();
            lnkbtnFinalClear.Text = Resources.PFSalesResource.Clear.Trim();
            lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.Clear.Trim();
        }
        CleraMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Click Event Of Send Email Button 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSendEmail_Click(object sender, EventArgs e)
    {
        CleraMsg();
        if (SendOneTimeMail(lblEmail1.Text.Trim()))
        {
            Int64 result = 0;

            result = objProspBM.UpdateOneTimeMailStatus(Convert.ToInt64(hdfProspectId.Value.Trim()), BasePage.UserSession.VirtualRoleId, true, EdSendEmail.Content.Trim(), true);
            if (result > 0)
            {
                if (BasePage.UserSession.RoleId == 5)
                    result = objActivityBM.AddContactNotes(Convert.ToInt64(hdfProspectId.Value.Trim()), "No Contact Email Send To Contact", BasePage.UserSession.VirtualRoleId, false, 33, 0, Convert.ToInt32(hdfProspStatus.Value.Trim())); // 33 - Hard Code Id For Sent Email for FC Process
                else
                    result = objActivityBM.AddContactNotes(Convert.ToInt64(hdfProspectId.Value.Trim()), "No Contact Email Send To Contact", BasePage.UserSession.VirtualRoleId, false, 11, 0, Convert.ToInt32(hdfProspStatus.Value.Trim())); // 11 - Hard Code Id For Sent Email For PF Process
                if (result > 0)
                {
                    lblAddSucMsg.Text = Resources.PFSalesResource.EmailSentSuccessfully.Trim();
                    lblAddErrMsg.Text = string.Empty;
                    lnkbtnSendUnableToConMail.Visible = pnlSendMail.Visible = dvadderror.Visible = false;
                    dvaddSucc.Visible = true;
                    lblAddSucMsg.Focus();
                }
                else
                {
                    lblAddErrMsg.Text = Resources.PFSalesResource.EmailSentButNotAddedInNotes.Trim();
                    lblAddSucMsg.Text = string.Empty;
                    lnkbtnSendUnableToConMail.Visible = pnlSendMail.Visible = dvaddSucc.Visible = false;
                    dvadderror.Visible = true;
                    lblAddErrMsg.Focus();
                }

            }
            else
            {
                lblAddSucMsg.Text = string.Empty;
                lblAddErrMsg.Text = Resources.PFSalesResource.EmailNotSent.Trim();
                dvaddSucc.Visible = false;
                lnkbtnSendUnableToConMail.Visible = pnlSendMail.Visible = dvadderror.Visible = true;
                lblAddErrMsg.Focus();
            }
        }
        else
        {
            Int64 result = objProspBM.UpdateOneTimeMailStatus(Convert.ToInt64(hdfProspectId.Value.Trim()), BasePage.UserSession.VirtualRoleId, false, EdSendEmail.Content.Trim(), false);
            if (result > 0)
            {
                if (BasePage.UserSession.RoleId == 5)
                    result = objActivityBM.AddContactNotes(Convert.ToInt64(hdfProspectId.Value.Trim()), "No Contact Email Send To Contact", BasePage.UserSession.VirtualRoleId, false, 33, 0, Convert.ToInt32(hdfProspStatus.Value.Trim())); // 33 - Hard Code Id For Sent Email for FC Process
                else
                    result = objActivityBM.AddContactNotes(Convert.ToInt64(hdfProspectId.Value.Trim()), "No Contact Email Send To Contact", BasePage.UserSession.VirtualRoleId, false, 11, 0, Convert.ToInt32(hdfProspStatus.Value.Trim())); // 11 - Hard Code Id For Sent Email For PF Process
                lblAddSucMsg.Text = string.Empty;
                lblAddErrMsg.Text = Resources.PFSalesResource.EmailNotSent.Trim();
                pnlSendMail.Visible = dvaddSucc.Visible = false;
                lnkbtnSendUnableToConMail.Visible = dvadderror.Visible = true;
                lblAddErrMsg.Focus();
            }
        }
        BindMangeData();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 Aug 2013
    /// Description: View Unable to Contact Email
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSendUnableToConMail_Click(object sender, EventArgs e)
    {
        pnlSendMail.Visible = true; CleraMsg();
    }

    private DataTable SearchConsultandIdByProspectId(string ProspectId)
    {
        DbCommand objCmd = null;
        DataTable dt = null;
        try
        {
            objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "SpSearchConsultantIdbyProspectId");
            Cls_DataAccess.getInstance().AddInParameter(objCmd, "@ProspectId", DbType.Int64, Convert.ToInt64(ProspectId));
            dt = Cls_DataAccess.getInstance().GetDataTable(objCmd);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    protected void lnkbtnConfirmOrder_Click(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlclrStatus = (DropDownList)this.FindControl("ddlclrStatus");
            if (ddlclrStatus.SelectedItem.Text == "Client")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Check function Successful')</script>");
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Check function unsuccessful')</script>");
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void lnkbtnChooseQuote_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable ProspectInfo = SearchConsultandIdByProspectId(Convert.ToString(hdfProspectId.Value));
            Response.Redirect("http://quotes.privatefleet.com.au/ViewSentRequests.aspx?" + "ProspectID=" + Convert.ToString(hdfProspectId.Value) + 
               "&QuoteID=" + Convert.ToString(ViewState["QuoteRequestID"]) + "&ConsID=" + ProspectInfo.Rows[0]["ConsultantId"].ToString());
        }
        catch (Exception ex)
        {

        }
    }

    protected void lnkbtnCreateContract_Click(object sender, EventArgs e)
    {

    }

    protected void lnkCreateQuote_Click(object sender, EventArgs e)
    {
        try
        {
            CleraMsg();
            // Restrict for fincar consultant i.e 5
            if (BasePage.UserSession.RoleId != 5)
            {
                string link = Convert.ToString(ConfigurationManager.AppSettings["QuoteLink"]);
                // Quotecon ConsultentID
                string QryString = "q=" + Cls_Encryption.EncryptTripleDES(Convert.ToString(BasePage.UserSession.UserEntityId));
                // Prospect ID
                QryString += "&p=" + Cls_Encryption.EncryptTripleDES(Convert.ToString(hdfProspectId.Value));
                // Make 
                QryString += "&M=" + Cls_Encryption.EncryptTripleDES(Convert.ToString(hdfMakeId.Value));
                // Model
                QryString += "&mo=" + Cls_Encryption.EncryptTripleDES(Convert.ToString(lblModel.Text));
                // Postal Code
                QryString += "&pc=" + Cls_Encryption.EncryptTripleDES(Convert.ToString(lblPostalCode.Text));
                QryString += "&frm=" + Cls_Encryption.EncryptTripleDES(Convert.ToString("pfsales"));
                QryString += "&qr=" + Cls_Encryption.EncryptTripleDES(Convert.ToString(ViewState["QuoteRequestID"]));
                QryString += "&em=" + Cls_Encryption.EncryptTripleDES(lblEmail1.Text.Trim());

                Response.Redirect(link + "?" + QryString, false);
                
 
            }
        }
        catch (Exception ex)
        {
            Logger.Error("UserControls_UC_ProspectDetails lnkCreateQuote_Click Error - " + ex.Message);
        }
    }

    private bool IsQuoteExist()
    {
        Prospect prospect = new Prospect();
        ProspectBM prospectBM = new ProspectBM();
        try
        {
            prospect.ProspId = Convert.ToInt64(hdfProspectId.Value);
            DataTable dt = prospectBM.IsQuoteExist(prospect);
            if (dt != null && dt.Rows.Count == 1)
            {
                ViewState["QuoteRequestID"] = dt.Rows[0]["QuoteRequestId"];
                return Convert.ToBoolean(dt.Rows[0]["IsQuoteCreated"]);
            }
            else
            {
                ViewState["QuoteRequestID"] = 0;
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error("UserControls_UC_ProspectDetails IsQuoteExist Error - " + ex.Message);
            return false;
        }

    }

    protected void lnkViewQuoteRequest_Click(object sender, EventArgs e)
    {
        try
        {
            CleraMsg();
        }
        catch (Exception ex)
        {
            Logger.Error("UserControls_UC_ProspectDetails lnkViewQuoteRequest_Click Error - " + ex.Message);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 Aug 2013
    /// Description: Close Unable to Contact Email
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSendMailClose_Click(object sender, EventArgs e)
    {

        pnlSendMail.Visible = false; CleraMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Set Refer to finance Yes For the Contact
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnReferToFinance_Click(object sender, EventArgs e)
    {
        txtFCNotes.Text = string.Empty;
        pnlReftoFinance.Visible = true; CleraMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Close the Set Refer to finance panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnCloaseReferToFin_Click(object sender, EventArgs e)
    {
        pnlReftoFinance.Visible = false; CleraMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Close the Set Refer to finance panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSavetoFC_Click(object sender, EventArgs e)
    {
        try
        {
            CleraMsg();
            Int64 Result = objProspBM.SetFinanceRequired(Convert.ToInt64(hdfProspectId.Value.Trim()), txtFCNotes.Text.Trim(), BasePage.UserSession.VirtualRoleId);
            if (Result > 0)
            {
                SendReferenceSuccessEmail();
                Result = SaveOnlyNotes(Convert.ToInt64(hdfProspectId.Value.Trim()), "Referred For Finance", 50, Convert.ToInt32(hdfProspStatus.Value.Trim()));// 50- Hard code Id for status of Referred For Finance for PF/FC process
                if (Result > 0)
                {
                    lblAddSucMsg.Text = Resources.PFSalesResource.ReferSuccess.Trim();
                    lblAddErrMsg.Text = string.Empty;
                    dvadderror.Visible = false; //lnkbtnReferToFinance.Visible = pnlReftoFinance.Visible = 
                    dvaddSucc.Visible = true;
                    lblAddSucMsg.Focus();
                }
                else
                {
                    lblAddSucMsg.Text = string.Empty;
                    lblAddErrMsg.Text = Resources.PFSalesResource.ReferFail.Trim();
                    dvaddSucc.Visible = false;
                    dvadderror.Visible = true; //lnkbtnReferToFinance.Visible = pnlReftoFinance.Visible =
                    lblAddErrMsg.Focus();
                }
            }
            else
            {
                lblAddSucMsg.Text = string.Empty;
                lblAddErrMsg.Text = Resources.PFSalesResource.ReferFail.Trim();
                dvaddSucc.Visible = false;
                dvadderror.Visible = true;//lnkbtnReferToFinance.Visible = pnlReftoFinance.Visible = 
                lblAddErrMsg.Focus();
            }
            BidData(Convert.ToInt64(hdfProspectId.Value.Trim()));
            txtFCNotes.Text = string.Empty;
            lnkbtnReferToFinance.Visible = pnlReftoFinance.Visible = false;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_ProspectDetails.lnkbtnSavetoFC_Click.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 2 September 2013
    /// Description: Close the Send SMS panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSendSmsClose_Click(object sender, EventArgs e)
    {
        pnlSendSmS.Visible = false; txtSMS.Text = string.Empty;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 2 September 2013
    /// Description: Send SMS To Given Number
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSendSMS_Click(object sender, EventArgs e)
    {
        try
        {
            string msg = "";
            try
            {
                Entity objSendSMS = new Entity();
                ProspectBM objmstr = new ProspectBM();
                string senderID = "";
                string msgcontent = txtSMS.Text.Trim();
                DataTable dt = null;
                //"FINCAR_SENDER_ID"
                if (BasePage.UserSession.RoleId == 3)
                    dt = objmstr.GetConfigValues("SENDER_ID");
                else if (BasePage.UserSession.RoleId == 5)
                    dt = objmstr.GetConfigValues("FINCAR_SENDER_ID");
                else
                    dt = objmstr.GetConfigValues("SENDER_ID");
                if (dt.Rows.Count > 0)
                {
                    senderID = dt.Rows[0]["Value"].ToString();
                }

                //string[] no = { lblCountryCode.Text.Trim() + txtSMSTo_1.Text.Trim('0') + txtSMSTo.Text };
                string pno = txtSmsMobNum.Text.Trim();
                if (pno.Substring(0, 1) == "0")
                    pno = pno.Substring(1);

                string[] no = { Convert.ToString(ConfigurationManager.AppSettings["CountryCode"]) + pno };
                //string[] no = { pno };
                //no[0] = "919730766774";
                ServiceReference1.PushServerWSPortTypeClient ws = new PushServerWSPortTypeClient();
                //  string[] data = ws.sendmsg("", 3334477, "ashishlathi82", "P@ssw0rd", no, "Private Fleet", "Wel Come", 0, 1, 0, 0, 3, 0, 3, 0, 0, "abc123", 0, "SMS_TEXT", "", "", 1440);
                string[] data = ws.sendmsg("", 3336013, ConfigurationManager.AppSettings["ClickatellUN"].ToString(), ConfigurationManager.AppSettings["ClickatellPwd"].ToString(), no, senderID, msgcontent, 0, 1, 0, 0, 3, 0, 3, 0, 0, no.ToString().Trim(), 0, "SMS_TEXT", "", "", 1440);
                string output = data[0].Substring(0, 8);

                #region Chk clickatell Exception
                switch (output)
                {
                    case "ERR: 001":
                        msg = "Authentication failed.";
                        break;
                    case "ERR: 002":
                        msg = "Unknown username or password.";
                        break;
                    case "ERR: 003":
                        msg = "Session ID expired.";
                        break;
                    case "ERR: 004":
                        msg = "Account frozen.";
                        break;
                    case "ERR: 005":
                        msg = "Missing session ID.";
                        break;
                    case "ERR: 007":
                        msg = "IP Lockdown violation.";
                        break;
                    case "ERR: 101":
                        msg = "Invalid or missing parameters.";
                        break;
                    case "ERR: 102":
                        msg = "Invalid user data header.";
                        break;
                    case "ERR: 103":
                        msg = "Unknown API message ID.";
                        break;
                    case "ERR: 104":
                        msg = "Unknown client message ID.";
                        break;
                    case "ERR: 105":
                        msg = "Invalid destination address.";
                        break;
                    case "ERR: 106":
                        msg = "Invalid source address.";
                        break;
                    case "ERR: 107":
                        msg = "Empty message.";
                        break;
                    case "ERR: 108":
                        msg = "Invalid or missing API ID.";
                        break;
                    case "ERR: 109":
                        msg = "Missing message ID.";
                        break;
                    case "ERR: 110":
                        msg = "Error with email message.";
                        break;
                    case "ERR: 111":
                        msg = "Invalid protocol.";
                        break;
                    case "ERR: 112":
                        msg = "Invalid message type.";
                        break;
                    case "ERR: 113":
                        msg = "Maximum message parts exceeded.";
                        break;
                    case "ERR: 114":
                        msg = "Cannot route message.";
                        break;
                    case "ERR: 115":
                        msg = "Message expired.";
                        break;
                    case "ERR: 116":
                        msg = "Invalid Unicode data.";
                        break;
                    case "ERR: 120":
                        msg = "Invalid delivery time.";
                        break;
                    case "ERR: 121":
                        msg = "Destination mobile number blocked.";
                        break;
                    case "ERR: 122":
                        msg = "Destination mobile opted out.";
                        break;
                    case "ERR: 123":
                        msg = "Invalid Sender ID.";
                        break;
                    case "ERR: 128":
                        msg = "Number delisted.";
                        break;
                    case "ERR: 301":
                        msg = "No credit left.";
                        break;
                    case "ERR: 302":
                        msg = "Max allowed credit.";
                        break;
                    default:
                        msg = "SMS Send Successfully.";
                        break;

                }

                //SAVE sms details to DB
                objSendSMS.SMSTo = Convert.ToString(no[0]);
                Logger.Error("SMS to - " + objSendSMS.SMSTo);
                objSendSMS.SMSFrom = BasePage.UserSession.VirtualRoleId;
                //if (BasePage.UserSession.UserId != null)
                //    objSendSMS.SMSFrom = BasePage.UserSession.UserId;
                //else
                //    Response.Redirect("Login.aspx");

                objSendSMS.SMSText = msgcontent.Trim();
                objmstr.sendSMS(objSendSMS.SMSTo, objSendSMS.SMSText, objSendSMS.SMSFrom, msg);
                Int64 Result = 0;
                if (BasePage.UserSession.RoleId == 5)
                    Result = SaveOnlyNotes(Convert.ToInt64(hdfProspectId.Value.Trim()), "SMS Sent", 51, Convert.ToInt32(hdfProspStatus.Value.Trim()));// 51- Hard code Id for status of SMS Sent for FC process
                else
                    Result = SaveOnlyNotes(Convert.ToInt64(hdfProspectId.Value.Trim()), "SMS Sent", 49, Convert.ToInt32(hdfProspStatus.Value.Trim()));// 49- Hard code Id for status of SMS Sent for PF process
                lblAddSucMsg.Text = msg;
                lblAddErrMsg.Text = string.Empty;
                pnlSendSmS.Visible = dvadderror.Visible = false;
                dvaddSucc.Visible = true;
                lblAddSucMsg.Focus();
                #endregion
                txtSMS.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Logger.Error("Cls_RemindProcess sendSMS Error - " + ex.Message + " ::" + ex.StackTrace);
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_ProspectDetails.lnkbtnSendSMS_Click.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 2 September 2013
    /// Description: Close the Set Refer to finance panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lblMobile_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(lblMobile.Text.Trim().Replace("--", "")))
        {
            pnlSendSmS.Visible = true;
            if (lblMobile.Text.Trim() != "--")
                txtSmsMobNum.Text = lblMobile.Text.Trim();
            else if (lblPhNo.Text.Trim() != "--")
                txtSmsMobNum.Text = lblPhNo.Text.Trim();
            else if (lblAltContNo.Text.Trim() != "--")
                txtSmsMobNum.Text = lblAltContNo.Text.Trim();
            else
                txtSmsMobNum.Text = string.Empty;

            //string strMob = lblMobile.Text.Substring(0, 2);
            //string strPhno = lblMobile.Text.Substring(0, 2);
            //string strAltno = lblMobile.Text.Substring(0, 2);


        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 Sept 2013
    /// Description: Select the Message To Be Send
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void radioPreset_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSMS.Text = Convert.ToString(radioPreset.SelectedItem);
        txtSMS.Text += "\nBest no. is " + (!string.IsNullOrEmpty(hdfConsultPhone.Value.Trim()) ? (hdfConsultPhone.Value.Trim()) : "1300 303 181") + "    " + (!string.IsNullOrEmpty(hdfConsultExt.Value.Trim()) ? ("(" + hdfConsultExt.Value.Trim() + ")") : "(" + BasePage.UserSession.PhExtension.Trim() + ")") + "\nThanks\n" + (lblConsultant.Text.Trim() == "--" ? (BasePage.UserSession.FullName) : lblConsultant.Text.Trim()) + "\nPrivate Fleet";
        lblSMS.Text = Convert.ToString(txtSMS.Text.Length);
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 22 Oct 2013
    /// Description: Select the Message To Be Send For FC Consultant
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void radiobtnlstFC_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSMS.Text = Convert.ToString(radiobtnlstFC.SelectedItem);
        txtSMS.Text += "\nBest no. is 1300 346 227\nThanks\n" + (lblFConsultant.Text.Trim() == "--" ? (BasePage.UserSession.FullName) : lblFConsultant.Text.Trim()) + "\nFinCar Finance";
        lblSMS.Text = Convert.ToString(txtSMS.Text.Length);
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 7 Sept 2013
    /// Description: Open a Pop Up To Be Send
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSMSSend_Click(object sender, EventArgs e)
    {
        if (BasePage.UserSession.RoleId == 3)
        {
            radioPreset.Visible = true;
            radiobtnlstFC.Visible = false;
        }
        else if (BasePage.UserSession.RoleId == 5)
        {
            radioPreset.Visible = false;
            radiobtnlstFC.Visible = true;
        }
        else if (BasePage.UserSession.RoleId == 1)
        {
            radioPreset.Visible = radiobtnlstFC.Visible = true;
        }
        else
        {
            radioPreset.Visible = true;
            radiobtnlstFC.Visible = false;
        }
        pnlSendSmS.Visible = true;
        txtSMS.Text = string.Empty;
        foreach (ListItem item in radioPreset.Items)
        {
            if (item.Selected)
                item.Selected = false;
        }
        foreach (ListItem item in radiobtnlstFC.Items)
        {
            if (item.Selected)
                item.Selected = false;
        }
        //if (lblMobile.Text.Trim() != "--")
        //    txtSmsMobNum.Text = lblMobile.Text.Replace(" ", "").Trim();
        //else if (lblPhNo.Text.Trim() != "--")
        //    txtSmsMobNum.Text = lblPhNo.Text.Replace(" ", "").Trim();
        //else if (lblAltContNo.Text.Trim() != "--")
        //    txtSmsMobNum.Text = lblAltContNo.Text.Replace(" ", "").Trim();
        //else
        //    txtSmsMobNum.Text = string.Empty;

        if (!string.IsNullOrEmpty(lblMobile.Text.Trim().Replace("--", "")) && !string.IsNullOrEmpty(lblPhNo.Text.Trim().Replace("--", "")) && !string.IsNullOrEmpty(lblAltContNo.Text.Trim().Replace("--", "")))
        {
            string strMob = lblMobile.Text.Substring(0, 2);
            string strPhno = lblPhNo.Text.Substring(0, 2);
            string strAltno = lblAltContNo.Text.Substring(0, 2);
            if (strMob == "04")
            {
                txtSmsMobNum.Text = lblMobile.Text.Replace(" ", "").Trim();
            }
            else if (strPhno == "04")
            {
                txtSmsMobNum.Text = lblPhNo.Text.Replace(" ", "").Trim();
            }
            else if (strAltno == "04")
            {
                txtSmsMobNum.Text = lblAltContNo.Text.Replace(" ", "").Trim();
            }
            else
                txtSmsMobNum.Text = lblMobile.Text.Replace(" ", "").Trim();

        }
        else if (!string.IsNullOrEmpty(lblMobile.Text.Trim().Replace("--", "")) && !string.IsNullOrEmpty(lblPhNo.Text.Trim().Replace("--", "")))
        {
            string strMob = lblMobile.Text.Substring(0, 2);
            string strPhno = lblPhNo.Text.Substring(0, 2);

            if (strMob == "04")
            {
                txtSmsMobNum.Text = lblMobile.Text.Replace(" ", "").Trim();
            }
            else if (strPhno == "04")
            {
                txtSmsMobNum.Text = lblPhNo.Text.Replace(" ", "").Trim();
            }
            else
                txtSmsMobNum.Text = lblMobile.Text.Replace(" ", "").Trim();

        }
        else if (!string.IsNullOrEmpty(lblMobile.Text.Trim().Replace("--", "")) && !string.IsNullOrEmpty(lblAltContNo.Text.Trim().Replace("--", "")))
        {
            string strMob = lblMobile.Text.Substring(0, 2);
            string strAltno = lblAltContNo.Text.Substring(0, 2);
            if (strMob == "04")
            {
                txtSmsMobNum.Text = lblMobile.Text.Replace(" ", "").Trim();
            }
            else if (strAltno == "04")
            {
                txtSmsMobNum.Text = lblAltContNo.Text.Replace(" ", "").Trim();
            }
            else
                txtSmsMobNum.Text = lblMobile.Text.Replace(" ", "").Trim();

        }
        else if (!string.IsNullOrEmpty(lblPhNo.Text.Trim().Replace("--", "")) && !string.IsNullOrEmpty(lblAltContNo.Text.Trim().Replace("--", "")))
        {

            string strPhno = lblPhNo.Text.Substring(0, 2);
            string strAltno = lblAltContNo.Text.Substring(0, 2);

            if (strPhno == "04")
            {
                txtSmsMobNum.Text = lblPhNo.Text.Replace(" ", "").Trim();
            }
            else if (strAltno == "04")
            {
                txtSmsMobNum.Text = lblAltContNo.Text.Replace(" ", "").Trim();
            }
            else
                txtSmsMobNum.Text = lblPhNo.Text.Replace(" ", "").Trim();

        }
        else if (!string.IsNullOrEmpty(lblMobile.Text.Trim().Replace("--", "")) && lblMobile.Text.Substring(0, 2) == "04")
        {
            txtSmsMobNum.Text = lblMobile.Text.Replace(" ", "").Trim();
        }
        else if (!string.IsNullOrEmpty(lblPhNo.Text.Trim().Replace("--", "")) && lblPhNo.Text.Substring(0, 2) == "04")
        {
            txtSmsMobNum.Text = lblPhNo.Text.Replace(" ", "").Trim();
        }
        else if (!string.IsNullOrEmpty(lblAltContNo.Text.Trim().Replace("--", "")) && lblAltContNo.Text.Substring(0, 2) == "04")
        {
            txtSmsMobNum.Text = lblAltContNo.Text.Replace(" ", "").Trim();
        }
        else if (!string.IsNullOrEmpty(lblMobile.Text.Trim().Replace("--", "")))
        {
            txtSmsMobNum.Text = lblMobile.Text.Replace(" ", "").Trim();
        }
        else if (!string.IsNullOrEmpty(lblPhNo.Text.Trim().Replace("--", "")))
        {
            txtSmsMobNum.Text = lblPhNo.Text.Replace(" ", "").Trim();
        }
        else if (!string.IsNullOrEmpty(lblAltContNo.Text.Trim().Replace("--", "")))
        {
            txtSmsMobNum.Text = lblAltContNo.Text.Replace(" ", "").Trim();
        }
        else
            txtSmsMobNum.Text = string.Empty;


    }
    #endregion

    #region Methods
    public void BidData(Int64 ProspId)
    {
        try
        {
            if (ProspId > 0)
            {
                if (Session["MyProspData"] != null)
                {
                    LinkButton lnkbtnNext = (LinkButton)this.Parent.FindControl("lnkbtnNext");
                    LinkButton lnkbtnPrevious = (LinkButton)this.Parent.FindControl("lnkbtnPrevious");
                    if (lnkbtnPrevious != null && lnkbtnNext != null)
                    {
                        if (((DataTable)(Session["MyProspData"])).Rows.Count > 1 && (Convert.ToInt64(Convert.ToString(Session["MyCurrentProsp"]).Trim())) != ((DataTable)(Session["MyProspData"])).Rows.Count)
                        {
                            lnkbtnNext.Visible = true;
                            if ((Convert.ToInt64(Convert.ToString(Session["MyCurrentProsp"]).Trim())) > 1)
                                lnkbtnPrevious.Visible = true;
                            else
                                lnkbtnPrevious.Visible = false;
                        }
                        else if (((DataTable)(Session["MyProspData"])).Rows.Count > 1 && (Convert.ToInt32(Convert.ToString(Session["MyCurrentProsp"]).Trim())) == ((DataTable)(Session["MyProspData"])).Rows.Count)
                        {
                            lnkbtnNext.Visible = false;
                            if ((Convert.ToInt64(Convert.ToString(Session["MyCurrentProsp"]).Trim())) > 1)
                                lnkbtnPrevious.Visible = true;
                            else
                                lnkbtnPrevious.Visible = false;
                        }
                        else
                        {
                            lnkbtnPrevious.Visible = lnkbtnNext.Visible = false;
                        }
                    }
                }

                DataTable dt = objProspBM.GetProspDetAssignedToConsult(0, DateTime.MinValue, DateTime.MaxValue, ProspId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    hdfProspectId.Value = Convert.ToString(ProspId).Trim();
                    lblName.Text = Convert.ToString(dt.Rows[0]["FName"]).Trim() + " " + Convert.ToString(dt.Rows[0]["MName"]).Trim() + " " + Convert.ToString(dt.Rows[0]["LName"]).Trim();
                    lblName.Text = lblName.Text.Trim().Replace("  ", " ");
                    lblCarMake.Text = Convert.ToString(dt.Rows[0]["Make"]).Trim();
                    hdfMakeId.Value = Convert.ToString(dt.Rows[0]["CarMake"]).Trim();
                    lblPhNo.Text = Convert.ToString(dt.Rows[0]["Phone"]).Trim();
                    //..modified by: Ayyaj
                    //Desc: For disable validation on UC_AddEditContact
                    Session["isPForFC"] = Convert.ToString(dt.Rows[0]["isPForFC"]).Trim();
                    //...................
                    if (lblPhNo.Text.Trim() != "--")
                    {
                        if (Convert.ToString(dt.Rows[0]["Phone"]).Trim().Length == 10)
                            lblPhNo.Text = Convert.ToString(dt.Rows[0]["Phone"]).Trim().Substring(0, 4) + " " + Convert.ToString(dt.Rows[0]["Phone"]).Trim().Substring(4, 3) + " " + Convert.ToString(dt.Rows[0]["Phone"]).Trim().Substring(7, 3);
                    }
                    lblMobile.Text = Convert.ToString(dt.Rows[0]["Mobile"]).Trim();
                    if (lblMobile.Text.Trim() == "--")
                        lblMobile.Enabled = false;
                    else
                    {
                        lblMobile.Enabled = true;
                        if (Convert.ToString(dt.Rows[0]["Mobile"]).Trim().Length == 10)
                            lblMobile.Text = Convert.ToString(dt.Rows[0]["Mobile"]).Trim().Substring(0, 4) + " " + Convert.ToString(dt.Rows[0]["Mobile"]).Trim().Substring(4, 3) + " " + Convert.ToString(dt.Rows[0]["Mobile"]).Trim().Substring(7, 3);
                    }
                    lblAltContNo.Text = Convert.ToString(dt.Rows[0]["AltContNo"]).Trim();
                    if (lblAltContNo.Text.Trim() != "--")
                    {
                        if (Convert.ToString(dt.Rows[0]["AltContNo"]).Trim().Length == 10)
                            lblAltContNo.Text = Convert.ToString(dt.Rows[0]["AltContNo"]).Trim().Substring(0, 4) + " " + Convert.ToString(dt.Rows[0]["AltContNo"]).Trim().Substring(4, 3) + " " + Convert.ToString(dt.Rows[0]["AltContNo"]).Trim().Substring(7, 3);
                    }
                    lblFax.Text = Convert.ToString(dt.Rows[0]["Fax"]).Trim();
                    lblEmail1.Text = Convert.ToString(dt.Rows[0]["Email1"]).Trim();
                    aEmail.HRef = "mailto:" + lblEmail1.Text.Trim(); ;
                    lblAlterEmail.Text = Convert.ToString(dt.Rows[0]["Email2"]).Trim();
                    lblAddLine1.Text = Convert.ToString(dt.Rows[0]["Add1"]).Trim();
                    lblAddLine2.Text = Convert.ToString(dt.Rows[0]["Add2"]).Trim();
                    lblAddLine3.Text = Convert.ToString(dt.Rows[0]["Add3"]).Trim();
                    lblCountry.Text = Convert.ToString(dt.Rows[0]["Country"]).Trim();
                    lblState.Text = Convert.ToString(dt.Rows[0]["StateName"]).Trim();
                    lblCity.Text = Convert.ToString(dt.Rows[0]["City"]).Trim();
                    lblPostalCode.Text = Convert.ToString(dt.Rows[0]["PostalCode"]).Trim();
                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ConsultantName"]).Trim()))
                        lblConsultant.Text = Convert.ToString(dt.Rows[0]["ConsultantName"]).Trim();
                    else
                        lblConsultant.Text = "--";
                    //Commented By: Ayyaj On: 4 Nov 2014 Suggested By : Catherine
                    //if (BasePage.UserSession.RoleId == 5)
                    //    lblAddStatus.Text = Convert.ToString(dt.Rows[0]["FCStatus"]).Trim();
                    //else
                        lblAddStatus.Text = Convert.ToString(dt.Rows[0]["Status"]).Trim();
                    if (BasePage.UserSession.RoleId == 3)
                        hdfProspStatus.Value = Convert.ToString(dt.Rows[0]["StatusId"]).Trim();
                    else if (BasePage.UserSession.RoleId == 5)
                        hdfProspStatus.Value = Convert.ToString(dt.Rows[0]["FCStatusId"]).Trim();
                    else if (BasePage.UserSession.RoleId == 1)
                    {
                        if (dt.Rows[0]["isPFOrFC"] != null && !string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["isPFOrFC"]).Trim()))
                        {
                            if (Convert.ToString(dt.Rows[0]["isPFOrFC"]).Trim().ToUpper() == "W")
                                hdfProspStatus.Value = Convert.ToString(dt.Rows[0]["StatusId"]).Trim();
                            else if (Convert.ToString(dt.Rows[0]["isPFOrFC"]).Trim().ToUpper() == "F")
                                hdfProspStatus.Value = Convert.ToString(dt.Rows[0]["FCStatusId"]).Trim();
                            else
                                hdfProspStatus.Value = Convert.ToString(dt.Rows[0]["StatusId"]).Trim();
                        }
                        else
                            hdfProspStatus.Value = Convert.ToString(dt.Rows[0]["StatusId"]).Trim();
                    }
                    lblSource.Text = Convert.ToString(dt.Rows[0]["RefSource"]).Trim() + " " + ((!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Leadsource"]).Trim().Replace("--", ""))) ? ("(" + Convert.ToString(dt.Rows[0]["Leadsource"]).Trim() + ")") : "");
                    lblMemNo.Text = Convert.ToString(dt.Rows[0]["MemberNo"]).Trim();
                    lblFConsultant.Text = Convert.ToString(dt.Rows[0]["FConsultant"]).Trim();
                    lblEnqDate.Text = Convert.ToString(dt.Rows[0]["EnquiryDate"]).Trim();
                    lblModel.Text = Convert.ToString(dt.Rows[0]["Model"]).Trim();
                    lblComments.Text = Convert.ToString(dt.Rows[0]["Comment"]).Trim();
                    lblTradeIn.Text = Convert.ToString(dt.Rows[0]["TradeIn"]).Trim();
                    lblFinance.Text = Convert.ToString(dt.Rows[0]["Finance"]).Trim();
                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["FCStatus"]).Trim()))
                        lblFCStatus.Text = Convert.ToString(dt.Rows[0]["FCStatus"]).Trim();
                    else
                        lblFCStatus.Text = "--";
                    lblPFAllocationDate.Text = Convert.ToString(dt.Rows[0]["PFAllocatedDate"]).Trim();
                    lblFCAllocationDate.Text = Convert.ToString(dt.Rows[0]["FCAllocatedDate"]).Trim();
                    lblWDHAPF.Text = Convert.ToString(dt.Rows[0]["WhereDidYouHear"]).Trim();
                    if (Convert.ToString(dt.Rows[0]["Finance"]).Trim().ToUpper() == "NO")
                    {
                        lnkbtnReferToFinance.Visible = true;
                        pnlFCDetails.Visible = false;
                    }
                    else
                    {
                        lnkbtnReferToFinance.Visible = false;
                        pnlFCDetails.Visible = true;
                    }
                    if (Convert.ToString(dt.Rows[0]["IsMailSent"]).Trim().ToUpper() == "YES")
                        lnkbtnSendUnableToConMail.Visible = false;
                    #region Hide
                    // Added for logic to implement mandatory process of "unable to contact". Need to uncomment this when it asks to implement
                    //else
                    //{
                    //    if (BasePage.UserSession.RoleId == 3)
                    //    {
                    //        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PFAlocationDate"]).Trim()) && Convert.ToString(dt.Rows[0]["PFAlocationDate"]).Trim().ToUpper() != "NOT AVAILABLE" && !string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PFCalledLeftMsgCount"]).Trim()))
                    //        {
                    //            if (Convert.ToDateTime(Convert.ToString(dt.Rows[0]["PFAlocationDate"]).Trim()) <= DateTime.Now.AddHours(-24) && Convert.ToInt32(dt.Rows[0]["PFCalledLeftMsgCount"])>=2)
                    //                lnkbtnSendUnableToConMail.Visible = true;
                    //            else
                    //                lnkbtnSendUnableToConMail.Visible = false;
                    //        }
                    //        else
                    //            lnkbtnSendUnableToConMail.Visible = false;
                    //    }
                    //    else if (BasePage.UserSession.RoleId == 5)
                    //    {
                    //        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["FCAlocationDate"]).Trim()) && Convert.ToString(dt.Rows[0]["FCAlocationDate"]).Trim().ToUpper() != "NOT AVAILABLE" && !string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["FCCalledLeftMsgCount"]).Trim()))
                    //        {
                    //            if (Convert.ToDateTime(Convert.ToString(dt.Rows[0]["FCAlocationDate"]).Trim()) <= DateTime.Now.AddHours(-24) && Convert.ToInt32(dt.Rows[0]["FCCalledLeftMsgCount"]) >= 2)
                    //                lnkbtnSendUnableToConMail.Visible = true;
                    //            else
                    //                lnkbtnSendUnableToConMail.Visible = false;
                    //        }
                    //        else
                    //            lnkbtnSendUnableToConMail.Visible = false;
                    //    }
                    //    else if (BasePage.UserSession.RoleId == 1)
                    //    {
                    //        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PFAlocationDate"]).Trim()) && Convert.ToString(dt.Rows[0]["PFAlocationDate"]).Trim().ToUpper() != "NOT AVAILABLE" && !string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PFCalledLeftMsgCount"]).Trim()))
                    //        {
                    //            if (Convert.ToDateTime(Convert.ToString(dt.Rows[0]["PFAlocationDate"]).Trim()) <= DateTime.Now.AddHours(-24) && Convert.ToInt32(dt.Rows[0]["PFCalledLeftMsgCount"]) >= 2)
                    //                lnkbtnSendUnableToConMail.Visible = true;
                    //            else
                    //                lnkbtnSendUnableToConMail.Visible = false;
                    //        }
                    //        else
                    //            lnkbtnSendUnableToConMail.Visible = false;
                    //    }
                    //    else
                    //        lnkbtnSendUnableToConMail.Visible = false;
                    //}
                    #endregion
                    else
                        lnkbtnSendUnableToConMail.Visible = true;
                    SetContent(Convert.ToString(dt.Rows[0]["FName"]).Trim());
                    hdfConsultPhone.Value = Convert.ToString(dt.Rows[0]["ConsultPhone"]).Trim();
                    hdfConsultExt.Value = Convert.ToString(dt.Rows[0]["ConsultExt"]).Trim();
                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ActualMake"]).Trim().Replace("--", "")) && ((Convert.ToString(dt.Rows[0]["MakeFromId"]).Trim().ToUpper() == "OTHER") || (Convert.ToInt64(Convert.ToString(dt.Rows[0]["CarMake"]).Trim())) == 0))
                        lblActualMakeInput.Text = "(" + Convert.ToString(dt.Rows[0]["ActualMake"]).Trim() + ")";
                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Model"]).Trim().Replace("--", "")) && Convert.ToString(dt.Rows[0]["ModelFromId"]).Trim().ToUpper() == "OTHER")
                        lblActualModelInput.Text = "(" + Convert.ToString(dt.Rows[0]["Model"]).Trim() + ")";

                    DataTable dtFC = objProspBM.GetProspFCDetFromProId(ProspId);
                    if (dtFC != null && dtFC.Rows.Count > 0)
                    {
                        lblCreditHistory.Text = Convert.ToString(dtFC.Rows[0]["CreditHistory"]).Trim();
                        lblEstFin.Text = Convert.ToString(dtFC.Rows[0]["EstimatedFinance"]).Trim();
                        lblInitialDeposit.Text = Convert.ToString(dtFC.Rows[0]["InitialDeposite"]).Trim();
                        lblTermyears.Text = Convert.ToString(dtFC.Rows[0]["Term"]).Trim();
                        lblResidualBallonPaymen.Text = Convert.ToString(dtFC.Rows[0]["Payment"]).Trim();
                        lblMessage.Text = Convert.ToString(dtFC.Rows[0]["Message"]).Trim();
                        lblFinanceRequired.Text = Convert.ToString(dtFC.Rows[0]["FinanceType"]).Trim();
                        lblEmployment.Text = Convert.ToString(dtFC.Rows[0]["Employment"]).Trim();
                        lblEmployer.Text = Convert.ToString(dtFC.Rows[0]["Employer"]).Trim();
                        lblCurrentIncome.Text = Convert.ToString(dtFC.Rows[0]["CurrentIncome"]).Trim();
                        lblTimeinCurEmp.Text = Convert.ToString(dtFC.Rows[0]["Time_in_Cur_Emp"]).Trim();
                        lblTimeAtCurAdd.Text = Convert.ToString(dtFC.Rows[0]["Time_At_Cur_Add"]).Trim();
                        lblFinFrom.Text = Convert.ToString(dtFC.Rows[0]["FinFor"]).Trim();
                        hdfFinLeadTypeID.Value = Convert.ToString(dtFC.Rows[0]["FinLeadTypeId"]).Trim();
                        hdfFCId.Value = Convert.ToString(dtFC.Rows[0]["Id"]).Trim();
                    }
                    else
                    {
                        lblFinFrom.Text = lblTimeAtCurAdd.Text = lblTimeinCurEmp.Text = lblCurrentIncome.Text = lblEmployer.Text = lblEmployment.Text = lblFinanceRequired.Text = lblCreditHistory.Text = lblEstFin.Text = lblInitialDeposit.Text = lblTermyears.Text = lblResidualBallonPaymen.Text = lblMessage.Text = "--";
                    }
                    // Modified By: Ayyaj Mujawar. Date:05 Oct 2013
                    //Desc:To Add New HyperLink Button For To Search On  RedBook Site
                    if (dt != null && dt.Rows.Count > 0)
                    {

                        string SeachCarUrl = string.Empty;
                        string txt1 = "http://www.redbook.com.au/cars/research-new";
                        string txt3 = ""; string txt2 = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Make"]).Trim().Replace("--", "")))
                            txt2 = "/" + Convert.ToString(dt.Rows[0]["Make"]).Trim().Replace("--", "");
                        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Model"]).Trim().Replace("--", "")))
                            txt3 = "/" + Convert.ToString(dt.Rows[0]["Model"]).Trim().Replace("--", "");
                        //Modified By: Ayyaj Mujawar. Date:03 January 2014
                        //Desc:To Add Hard Code Year for Timebeing untill redbook get updated.
                        //string txt4 = "/" + Convert.ToString(System.DateTime.Now.Year);
                        string txt4 = "/2014";
                        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Model"]).Trim()))
                        {
                            SeachCarUrl = txt1 + txt2 + txt3 + txt4;
                        }
                        else
                        {
                            SeachCarUrl = txt1 + txt2 + txt4;
                        }


                        hplnkbtnSearchCar.Text = "Red Book";
                        hplnkbtnSearchCar.NavigateUrl = SeachCarUrl;
                        hplnkbtnSearchCar.Target = "_blank";

                    }
                }
                //Added By: Ayyaj Mujawar. Date:01 OCT 2014
                if (BasePage.UserSession.RoleId != 5)
                {
                    IsQuoteExist();
                    string link = Convert.ToString(ConfigurationManager.AppSettings["QuoteLink"]);
                    // Quotecon ConsultentID
                    string QryString = "q=" + Cls_Encryption.EncryptTripleDES(Convert.ToString(BasePage.UserSession.UserEntityId));
                    // Prospect ID
                    QryString += "&p=" + Cls_Encryption.EncryptTripleDES(Convert.ToString(hdfProspectId.Value));
                    // Make 
                    QryString += "&M=" + Cls_Encryption.EncryptTripleDES(Convert.ToString(hdfMakeId.Value));
                    // Model
                    QryString += "&mo=" + Cls_Encryption.EncryptTripleDES(Convert.ToString(lblModel.Text));
                    // Postal Code
                    QryString += "&pc=" + Cls_Encryption.EncryptTripleDES(Convert.ToString(lblPostalCode.Text));
                    QryString += "&frm=" + Cls_Encryption.EncryptTripleDES(Convert.ToString("pfsales"));
                    QryString += "&qr=" + Cls_Encryption.EncryptTripleDES(Convert.ToString(ViewState["QuoteRequestID"]));
                    QryString += "&em=" + Cls_Encryption.EncryptTripleDES(lblEmail1.Text.Trim());


                    //string link = Convert.ToString(ConfigurationManager.AppSettings["QuoteLink"]);
                    //// Quotecon ConsultentID
                    //string QryString = "q=" + Convert.ToString(BasePage.UserSession.UserEntityId);
                    //// Prospect ID
                    //QryString += "&p=" + Convert.ToString(hdfProspectId.Value);
                    //// Make 
                    //QryString += "&M=" + Convert.ToString(hdfMakeId.Value);
                    //// Model
                    //QryString += "&mo=" + Convert.ToString(lblModel.Text);
                    //// Postal Code
                    //QryString += "&pc=" + Convert.ToString(lblPostalCode.Text);
                    //QryString += "&frm=" + Convert.ToString("pfsales");
                    //QryString += "&qr=" + Convert.ToString(ViewState["QuoteRequestID"]);
                    //QryString += "&em=" + lblEmail1.Text.Trim();

                    //Response.Redirect(link + "?" + QryString, false);
                    //lnkCreateQuote.Text = "Red Book";
                    lnkCreateQuote.NavigateUrl = link + "?" + QryString;
                    lnkCreateQuote.Target = "_blank";
                }
                else
                {
                    lnkCreateQuote.Visible = false;
                }

            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_ProspectDetails.BidData.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Send Email To Consultant 
    /// </summary>
    /// <param name="emilToId"></param>
    /// <param name="noOfLeads"></param>
    /// <param name="Name"></param>
    /// <returns></returns>
    private Boolean SendOneTimeMail(string emilToId)
    {
        string repEmail = string.Empty;
        if (BasePage.UserSession.UserEmail != null && !string.IsNullOrEmpty(Convert.ToString(BasePage.UserSession.UserEmail)))
            repEmail = BasePage.UserSession.UserEmail;
        else
            repEmail = "admin@privatefleet.com.au";

        string FileContent = string.Empty;
        try
        {
            BasePage.UserSession.EmailFromID = repEmail;
            Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
            objEmailHelper.EmailSubject = "Trouble contacting by phone";
            objEmailHelper.EmailToID = emilToId;
            FileContent = EdSendEmail.Content.Trim();
            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "Email Sent Successfully", "Trouble contacting by phone", "Prospect Details User Control");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Trouble contacting by phone", "Prospect Details User Control");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_ProspectDetails.SendOneTimeMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Trouble contacting by phone", "Prospect Details User Control");
            return false;
        }
        finally
        {
            BasePage.UserSession.EmailFromID = repEmail.Trim();
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Send Email To Consultant 
    /// </summary>
    private void SetContent(string ProspectName)
    {
        try
        {
            string FileContent = string.Empty;
            if (BasePage.UserSession.FName != null && BasePage.UserSession.UserEmail != null && !string.IsNullOrEmpty(BasePage.UserSession.FName.Trim()) && !string.IsNullOrEmpty(BasePage.UserSession.UserEmail.Trim()))
            {
                FileContent = "<div style='font: 12px/17px arial,helvetica,'Liberation Sans',FreeSans,sans-serif;color: #333333;'>"
                                         + "Hi " + ProspectName.Trim() + "<br /><br />Thank you for your enquiry. I have just tried to contact you with no success."
                                         + "<br /><br />In any event, I am intending to go forward and organise a great deal for you on your new car, though I need to ask you some questions before we can get this started."
                                         + "<br /><br />When you have a minute would you mind giving me a call on (1300 303 181) -my extension is." + BasePage.UserSession.PhExtension.Trim()
                                         + "<br /><br />I look forward to being able to help you when you have a minute to talk.";
                if (BasePage.UserSession.RoleId == 3)
                {
                    FileContent = FileContent + "<br /><br />Kind regards,"
                                   + "<br /><br />" + ((!string.IsNullOrEmpty(BasePage.UserSession.FullName.Trim())) ? (BasePage.UserSession.FullName.Trim()) : BasePage.UserSession.FName.Trim())
                                   + "<br />Senior Purchasing Officer"
                                   + "<br />Private Fleet - Car Buying Made Easy"
                                   + "<br><span style='Font:11px'>Lvl 2 845 Pacific Hwy </span>" + "<br /><br /><span style='Font:11px' >Tel: 1300 303 181 " + ((!string.IsNullOrEmpty(BasePage.UserSession.PhExtension.Trim())) ? ("(" + BasePage.UserSession.PhExtension.Trim() + ")") : "") + ((!string.IsNullOrEmpty(BasePage.UserSession.MobileNo.Trim())) ? (" (M)" + BasePage.UserSession.MobileNo.Trim() + ")") : " ") + "</span>"
                                   + "<br><br /><span style='Font:11px'>Chatswood NSW 2067 </span><br /><br /><span style='Font:11px' >Fax: 1300 303 981 </span> "
                                   + "<br><br /><span style='Font:11px'>ABN: 70 080 056 408 | Dealer Lic: MD 19913 </span><br /><br /><a href='http://www.privatefleet.com.au' style='Font:11px'>www.PrivateFleet.com.au</a></div> ";
                }
                if (BasePage.UserSession.RoleId == 5)
                {
                    string strmailto = "mailto:" + BasePage.UserSession.UserEmail.Trim();
                    FileContent = FileContent + "<br /><br /></div><div style='font: 10px Verdana'><span style='color:blue;'>Regards,</span>"
                                   + "<br /><b><span style='color:blue;'>" + ((!string.IsNullOrEmpty(BasePage.UserSession.FullName.Trim())) ? (BasePage.UserSession.FullName.Trim()) : BasePage.UserSession.FName.Trim()) + "</span></b><span style='color:blue;'>&nbsp;&nbsp;|&nbsp;&nbsp;Business Manager</span>"
                                   + "<br /><b><span style='color:#FF9900;'>Fincar – <i>Automotive Finance Solutions</i></span></b>"
                                   + "<br><br><span style='color:#5F5F5F;'>T: 1300 346 227</span>" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<span style='color:#5F5F5F;'>Level 2, 845 Pacific Hwy</span>"
                                   + "<br><span style='color:#5F5F5F;'>D: (02) 9406 4021</span>" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<span style='color:#5F5F5F;'>Chatswood NSW 2067</span>"
                                   + "<br><span style='color:#5F5F5F;'>F: (02) 9411 8032</span>" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<span style='color:#5F5F5F;'>(PO Box 5214 Chatswood West NSW 1515)</span>"
                                   + "<br><span style='color:#5F5F5F;'>E: <a href='" + strmailto + "' style='color: Blue; text-decoration: underline;'>" + BasePage.UserSession.UserEmail.Trim() + "</a></span>"
                                   + "<br><span style='color:#5F5F5F;'><a href='http://www.fincar.com.au/' style='color: Blue; text-decoration: underline;'>www.fincar.com.au</a></span>" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<span style='color:#5F5F5F;'>ABN: 67 107 751 931 | Australian Credit Licence: 387894</span></div>";
                }
                //+ "<br />Private Fleet - Car Buying Made Easy"
                //+ "<br />Lvl 2 845 Pacific Hwy"
                //+ "<br />Tel: 1300 303 181" + ((!string.IsNullOrEmpty(BasePage.UserSession.PhExtension.Trim())) ? ("(" + BasePage.UserSession.PhExtension.Trim() + ")") : " ") + ((!string.IsNullOrEmpty(BasePage.UserSession.MobileNo.Trim())) ? (" (M)" + BasePage.UserSession.MobileNo.Trim() + ")") : " ")
                //+ "<br/>Chatswood NSW 2067"
                //+ "<br/>Fax: 1300 303 981"
                //+ "<br/>ABN: 70 080 056 408 | Dealer Lic: MD 19913"
                //+ "<br/>www.privatefleet.com.au<http://www.privatefleet.com.au></div>";
                EdSendEmail.Content = FileContent.Trim();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_ProspectDetails.SetContent.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 22 Aug 2013
    /// Description: Clear All Message Labels  
    /// </summary>
    private void CleraMsg()
    {
        dvadderror.Visible = dvaddSucc.Visible = false;
        lblAddErrMsg.Text = lblAddSucMsg.Text = string.Empty;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Send Email To Consultant 
    /// </summary>
    /// <param name="emilToId"></param>
    /// <param name="noOfLeads"></param>
    /// <param name="Name"></param>
    /// <returns></returns>
    private Boolean SendReferenceSuccessEmail()
    {
        string FileContent = string.Empty;
        string repEmail = BasePage.UserSession.EmailFromID;
        try
        {
            BasePage.UserSession.EmailFromID = lblEmail1.Text.Trim();
            Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
            objEmailHelper.EmailSubject = "Finance Referral";
            objEmailHelper.EmailToID = "markellis@privatefleet.com.au";
            FileContent = "<div style='font: 12px/17px arial,helvetica,'Liberation Sans',FreeSans,sans-serif;color: #333333;'>"
                                        + "Hi Admin,<br /><br /> I have contacted the client " + lblName.Text.Trim()
                                        + "and he/she is now agree for the finance from fincar."
                                        + "<br /><br />Kind regards,"
                                        + "<br /><br />" + ((!string.IsNullOrEmpty(BasePage.UserSession.FullName.Trim())) ? (BasePage.UserSession.FullName.Trim()) : BasePage.UserSession.FName.Trim())
                                        + "<br />Senior Purchasing Officer"
                                        + "<br />Private Fleet - Car Buying Made Easy"
                                        + "<br><span style='Font:11px'>Lvl 2 845 Pacific Hwy </span>" + "<br /><br /><span style='Font:11px' >Tel: 1300 303 181 " + ((!string.IsNullOrEmpty(BasePage.UserSession.PhExtension.Trim())) ? ("(" + BasePage.UserSession.PhExtension.Trim() + ")") : "") + ((!string.IsNullOrEmpty(BasePage.UserSession.MobileNo.Trim())) ? (" (M)" + BasePage.UserSession.MobileNo.Trim() + ")") : " ") + "</span>"
                                        + "<br><br /><span style='Font:11px'>Chatswood NSW 2067 </span><br /><br /><span style='Font:11px' >Fax: 1300 303 981 </span> "
                                        + "<br><br /><span style='Font:11px'>ABN: 70 080 056 408 | Dealer Lic: MD 19913 </span><br /><br /><a href='http://www.privatefleet.com.au' style='Font:11px'>www.PrivateFleet.com.au</a></div> ";
            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBM.SaveEmailDetails("markellis@privatefleet.com.au", BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "Email Sent Successfully", "Finance Referral", "Prospect Details User Control");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails("markellis@privatefleet.com.au", BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Finance Referral", "Prospect Details User Control");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_ProspectDetails.SendOneTimeMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails("markellis@privatefleet.com.au", BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Finance Referral", "Prospect Details User Control");
            return false;
        }
        finally
        {
            BasePage.UserSession.EmailFromID = repEmail.Trim();
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 Sept 2013
    /// Description: Save Notes Only
    /// </summary>
    private Int64 SaveOnlyNotes(Int64 ProspectId, string Remarks, Int32 ActivityStatus, Int32 LeadStatus)
    {
        try
        {
            Activity objActivity = new Activity();
            if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
                objActivity.ProspectId = Convert.ToInt64(hdfProspectId.Value.Trim());
            Int64 Result = objActivityBM.AddContactNotes(ProspectId, Remarks.Trim(), BasePage.UserSession.VirtualRoleId, false, ActivityStatus, 0, LeadStatus);
            BindMangeData();
            return Result;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_ProspectDetails.SaveOnlyNotes.Error:" + ex.StackTrace);
            return 0;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 Sept 2013
    /// Description: Bind Managed Activity Data of Parrent Page
    /// </summary>
    public void BindMangeData()
    {
        MethodInfo methods1 = (this.Parent.Parent.Page).GetType().GetMethod("BindMangeActivity");// ((Page)this.Parent).GetType().GetMethod("BindMangeActivity");
        if (methods1 != null)
        {
            object[] objParam = new object[] { Convert.ToInt64(hdfProspectId.Value.Trim()) };
            methods1.Invoke((this.Parent.Parent.Page), objParam);
        }
    }
    #endregion
}
