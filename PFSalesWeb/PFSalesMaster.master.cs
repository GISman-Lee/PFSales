using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using Mechsoft.GeneralUtilities;
using System.Configuration;
using System.Data;
using Mechsoft.PFSales.BusinessManager;
using Mechsoft.PFSales.BusinessEntity;
using System.Reflection;

public partial class PFSalesMaster : System.Web.UI.MasterPage
{
    #region Private Varriables
    ILog Logger = LogManager.GetLogger(typeof(PFSalesMaster));
    ActivityBM objActivityBM = new ActivityBM();
    ActAlertDetails objActAlertDetails = new ActAlertDetails();
    MasterBM objMstBM = new MasterBM();
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblDate.Text = DateTime.Now.ToString("D");
            if (BasePage.UserSession != null)
            {
                lblUser.Text = Resources.PFSalesResource.Welcome.Trim() + " " + BasePage.UserSession.FName.Trim() + " ( " + BasePage.UserSession.RoleName.Trim() + " )";
                BindAlerts();
                //BindEmailAlerts();
                //if (BasePage.UserSession.RoleId == 3)
                //{
                //    //lnkbtnAddProspect.Visible = true;
                //    //lnkbtnGotoDashBoard.Visible = true;
                //}
                //else
                //lnkbtnGotoDashBoard.Visible = true;
                //lnkbtnProspectList.Visible = true;
            }
        }
    }

    /// <summary>
    /// Created By : Pravin Gholap
    /// Created Date: 28 May 2013
    /// Description: View Prospect List Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnProspectList_Click(object sender, EventArgs e)
    {
        try
        {
            Session["FromMasterPage"] = false;
            Response.Redirect("Prospects.aspx", false);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "PFSalesMaster:lnkbtnProspectList_Click.Error" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By : Pravin Gholap
    /// Created Date: 28 May 2013
    /// Description: Add Prospect Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddProspect_Click(object sender, EventArgs e)
    {
        try
        {
            Session["FromMasterPage"] = true;
            Response.Redirect("Prospects.aspx", false);
            //LinkButton lnkbtnSave = (LinkButton)((UserControl)ContentPlaceHolder1.FindControl("UC_AddEditContact1")).FindControl("lnkbtnSave");
            //LinkButton lnkbtnFinalClear = (LinkButton)((UserControl)ContentPlaceHolder1.FindControl("UC_AddEditContact1")).FindControl("lnkbtnFinalClear");
            //if (lnkbtnFinalClear != null && lnkbtnSave != null)
            //{
            //    MethodInfo methods = ((UserControl)ContentPlaceHolder1.FindControl("UC_AddEditContact1")).GetType().GetMethod("ClearAll");
            //    if (methods != null)
            //        methods.Invoke(((UserControl)ContentPlaceHolder1.FindControl("UC_AddEditContact1")), null);
            //    MethodInfo methods1 = ((UserControl)ContentPlaceHolder1.FindControl("UC_AddEditContact1")).GetType().GetMethod("ClearMsg");
            //    if (methods1 != null)
            //        methods1.Invoke(((UserControl)ContentPlaceHolder1.FindControl("UC_AddEditContact1")), null);
            //    ((Label)ContentPlaceHolder1.FindControl("lblAddContactHead")).Text = Resources.PFSalesResource.AddProspectDetails.Trim();
            //    //lblAddContactHead.Text = Resources.PFSalesResource.AddProspectDetails.Trim();
            //    lnkbtnSave.Text = Resources.PFSalesResource.Save.Trim();
            //    lnkbtnSave.ToolTip = Resources.PFSalesResource.SaveProspect.Trim();
            //    lnkbtnFinalClear.Text = Resources.PFSalesResource.Clear.Trim();
            //    lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.Clear.Trim();
            //}
            //((Panel)ContentPlaceHolder1.FindControl("pnlAddContact")).Visible = true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "PFSalesMaster:lnkbtnAddProspect_Click.Error" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By : Pravin Gholap
    /// Created Date: 25 June 2013
    /// Description: Go To Home Page Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnDashBoard_Click(object sender, EventArgs e)
    {
        if (BasePage.UserSession != null && BasePage.UserSession.RoleId > 0)
        {
            if (BasePage.UserSession.RoleId == 3)
                Response.Redirect("SearchProspect.aspx", false);
            else if (BasePage.UserSession.RoleId == 1)
                Response.Redirect("LeadAllocation.aspx", false);
        }
    }

    /// <summary>
    /// Created By : Pravin Gholap
    /// Created Date: 26 June 2013
    /// Description:Close Dash Board Alert's Pop Up
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkClose_Click(object sender, EventArgs e)
    {
        Int64 AlertId = Int64.Parse(((LinkButton)sender).CommandArgument);
       // DataListItem item = (DataListItem)((Control)sender).NamingContainer;
       // HiddenField alerttypeid = (HiddenField)item.FindControl("hdfAlertType");
        Int64 result = 0;
        result = objActivityBM.UpdateAlertStatus(AlertId, BasePage.UserSession.VirtualRoleId);
        if (result > 0)
        {
            BindAlerts();
        }
    }

    /// <summary>
    /// Created By : Pravin Gholap
    /// Created Date: 26 June 2013
    /// Description:Minimize Dash Board Alert's Pop Up
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnMinimize_Click(object sender, EventArgs e)
    {
        Int64 AlertId = Int64.Parse(((LinkButton)sender).CommandArgument);
       // DataListItem item = (DataListItem)((Control)sender).NamingContainer;
       // Image imgMinimise = (Image)item.FindControl("imgMinimise");
      //  LinkButton lnkbtnMinimize = (LinkButton)item.FindControl("lnkbtnMinimize");
       // Panel pnldiv = (Panel)item.FindControl("pnldiv");
        if (pnldiv.Visible == false)
        {
            pnldiv.Visible = true;
            imgMinimise.ImageUrl = "~/Images/minimizePop.png";
            lnkbtnMinimize.ToolTip = Resources.PFSalesResource.minimize.Trim();
        }
        else
        {
            pnldiv.Visible = false;
            imgMinimise.ImageUrl = "~/Images/minimizePopUp2.png";
            lnkbtnMinimize.ToolTip = Resources.PFSalesResource.Maximize.Trim();
        }

    }

    /// <summary>
    /// Created By : Pravin Gholap
    /// Created Date: 27 June 2013
    /// Description:Go to Dash Board 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnGotoDashBoard_Click(object sender, EventArgs e)
    {
        if (BasePage.UserSession != null && BasePage.UserSession.RoleId > 0)
        {
            if (BasePage.UserSession.RoleId == 3)
                Response.Redirect("SearchProspect.aspx", false);
            else if (BasePage.UserSession.RoleId == 1)
                Response.Redirect("LeadAllocation.aspx", false);
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
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 Aug 2013
    /// Description: View Prospect Details On Prospect Name Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkBtnProspName_Click(object sender, EventArgs e)
    {
        try
        {
            Int64 ProspectId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
            Response.Redirect("ManageActivities.aspx?ProspectId=" + ProspectId.ToString().Trim());
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "PFSalesMaster:lnkBtnProspName_Click.Error" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Kalpana Shinde
    /// Created Date: 28 Aug 2013
    /// Description: View previous alert on Previous  Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkPrevAlert_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(ViewState["CurrentAlertNo"].ToString().Trim()))
            {
                if ((Convert.ToInt32(ViewState["CurrentAlertNo"].ToString().Trim())) == 2)
                {
                    lnkPrevAlert.Visible = false;
                }
                ViewState["CurrentAlertNo"] = Convert.ToString(Convert.ToInt32(ViewState["CurrentAlertNo"].ToString().Trim()) - 1).Trim();
                if (ViewState["dtAlerts"] != null && ((DataTable)(ViewState["dtAlerts"])) != null && ((DataTable)(ViewState["dtAlerts"])).Rows.Count > 0)
                {
                    if (Convert.ToInt32(ViewState["CurrentAlertNo"].ToString().Trim()) < ((DataTable)(ViewState["dtAlerts"])).Rows.Count)
                        lnkNextAlert.Visible = true;
                    DataRow[] dr = ((DataTable)(ViewState["dtAlerts"])).Select("RowNo='" + ViewState["CurrentAlertNo"].ToString().Trim() + "'");
                    if (dr != null && dr.Length > 0)
                    {
                        dvAlert.Visible = true;
                        lnkBtnProspName.Text = dr[0]["ProspectName"].ToString().Trim();
                        lnkBtnProspName.CommandArgument = dr[0]["ProspectId"].ToString().Trim();
                        lnkbtnMinimize.CommandArgument = dr[0]["Id"].ToString().Trim();
                        lnkbtnClose.CommandArgument = dr[0]["Id"].ToString().Trim();
                        ActivityName.Text = dr[0]["Alert"].ToString().Trim();
                        lblActDesc.Text = dr[0]["Description"].ToString().Trim();
                        lblStartTime.Text = dr[0]["StartDate"].ToString().Trim();
                        lblEndTime.Text = dr[0]["EndDate"].ToString().Trim();
                        hdfAlertType.Value = dr[0]["alerttypeid"].ToString().Trim();
                        hdfActivityId.Value = dr[0]["ActivityId"].ToString().Trim();

                    }
                }
                else
                {
                    dvAlert.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "PFSalesMaster:lnkPrevAlert_Click.Error" + ex.StackTrace);
        }
    }
    protected void lnkNextAlert_Click(object sender, EventArgs e)
    {
        try
        {

            if (!string.IsNullOrEmpty(ViewState["CurrentAlertNo"].ToString().Trim()))
            {
                if ((Convert.ToInt32(ViewState["CurrentAlertNo"].ToString().Trim())) >= 1)
                {
                    lnkPrevAlert.Visible = true;
                }
                else
                { lnkPrevAlert.Visible = false; }

                ViewState["CurrentAlertNo"] = Convert.ToString(Convert.ToInt32(ViewState["CurrentAlertNo"].ToString().Trim()) + 1).Trim();
                if (ViewState["dtAlerts"] != null && ((DataTable)(ViewState["dtAlerts"])) != null && ((DataTable)(ViewState["dtAlerts"])).Rows.Count > 0)
                {
                    if (Convert.ToInt32(ViewState["CurrentAlertNo"].ToString().Trim()) == ((DataTable)(ViewState["dtAlerts"])).Rows.Count)
                        lnkNextAlert.Visible = false;
                    DataRow[] dr = ((DataTable)(ViewState["dtAlerts"])).Select("RowNo='" + ViewState["CurrentAlertNo"].ToString().Trim() + "'");
                    if (dr != null && dr.Length > 0)
                    {
                        dvAlert.Visible = true;
                        lnkBtnProspName.Text = dr[0]["ProspectName"].ToString().Trim();
                        lnkBtnProspName.CommandArgument = dr[0]["ProspectId"].ToString().Trim();
                        lnkbtnMinimize.CommandArgument = dr[0]["Id"].ToString().Trim();
                        lnkbtnClose.CommandArgument = dr[0]["Id"].ToString().Trim();
                        ActivityName.Text = dr[0]["Alert"].ToString().Trim();
                        lblActDesc.Text = dr[0]["Description"].ToString().Trim();
                        lblStartTime.Text = dr[0]["StartDate"].ToString().Trim();
                        lblEndTime.Text = dr[0]["EndDate"].ToString().Trim();
                        hdfAlertType.Value = dr[0]["alerttypeid"].ToString().Trim();
                        hdfActivityId.Value = dr[0]["ActivityId"].ToString().Trim();

                        // lblLeadNo.Text = hdfCurrentLoadNo.Value.Trim();
                    }
                }
                else
                {
                    dvAlert.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "PFSalesMaster:lnkNextAlert_Click.Error" + ex.StackTrace);
        }

    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 Sept 2013
    /// Description: Just for the sake of postback from master page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnRefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.ToString().Trim());
    }
    #endregion

    #region Methods
    /// <summary>
    /// Created By : Pravin Gholap
    /// Created Date: 26 June 2013
    /// Description: Bind Dashboard Alerts
    /// </summary>
    private void BindAlerts()
    {
        try
        {
            if (BasePage.UserSession.RoleId != 1)
            {
                objActAlertDetails.UserId = BasePage.UserSession.VirtualRoleId;
                objActAlertDetails.AlertTypeId = Cls_Constant.DashBoardAlert;
                DataTable dt = objActivityBM.GetMyAlerts(objActAlertDetails);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataTable Dt1 = new DataTable();
                    Dt1 = dt.Copy();
                    Dt1.Columns.Add("RowNo");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Dt1.Rows[i]["RowNo"] = i + 1;
                    }
                    ViewState["dtAlerts"] = Dt1;
                    if (Dt1 != null && Dt1.Rows.Count > 0)
                    {
                        dvAlert.Visible = true;
                        lnkBtnProspName.Text = dt.Rows[0]["ProspectName"].ToString().Trim();
                        lnkBtnProspName.CommandArgument = dt.Rows[0]["ProspectId"].ToString().Trim();
                        lnkbtnMinimize.CommandArgument = dt.Rows[0]["Id"].ToString().Trim();
                        lnkbtnClose.CommandArgument = dt.Rows[0]["Id"].ToString().Trim();
                        ActivityName.Text = dt.Rows[0]["Alert"].ToString().Trim();
                        lblActDesc.Text = dt.Rows[0]["Description"].ToString().Trim();
                        lblStartTime.Text = dt.Rows[0]["StartDate"].ToString().Trim();
                        lblEndTime.Text = dt.Rows[0]["EndDate"].ToString().Trim();
                        hdfAlertType.Value = dt.Rows[0]["alerttypeid"].ToString().Trim();
                        hdfActivityId.Value = dt.Rows[0]["ActivityId"].ToString().Trim();
                        lnkPrevAlert.Visible = false;
                        if (Dt1.Rows.Count > 1)
                        {
                            lnkNextAlert.Visible = true;
                        }
                        else
                        {
                            lnkNextAlert.Visible = false;
                        }
                        //if (lnkbtnCurrWorkLoad != null)
                        //{
                        //    if (Convert.ToInt32(lnkbtnCurrWorkLoad.Text.Trim()) > 1)
                        //        lnkbtnNext.Visible = true;
                        //    else
                        //        lnkbtnNext.Visible = false;
                        //}
                        // lblltrLeadNo.Visible = lblLeadNo.Visible = pnlWorkLoadDetUp.Visible = true;
                        //  lblLeadNo.Text = 
                        ViewState["CurrentAlertNo"] = "1";
                    }
                }
                else
                {
                    dvAlert.Visible = false;
                }


                //if (dtAlerts != null && dtAlerts.Rows.Count > 0)
                //{
                //    dlAlerts.DataSource = dtAlerts;
                //    dlAlerts.DataBind();
                //    System.Media.SystemSounds.Asterisk.Play();
                //}
                //else
                //{
                //    dlAlerts.DataSource = null;
                //    dlAlerts.DataBind();
                //}
            }
            else
            {
                dvAlert.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "PFSalesMaster: BindAlerts Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By : Pravin Gholap
    /// Created Date: 26 June 2013
    /// Description: Get Email Notifications
    /// </summary>
    /// <param name="ActivityTitle"></param>
    /// <param name="ActivityDesc"></param>
    /// <param name="Owner"></param>
    /// <param name="Account"></param>
    /// <param name="ContactName"></param>
    /// <param name="ContactDetails"></param>
    /// <returns></returns>
    private string GetEmailContent(string ActivityTitle, string ActivityDesc, string Owner, string Account, string ContactName, string ContactDetails)
    {
        //EmailTemplateBLL objEmailTempManager = new EmailTemplateBLL();
        //EmailTemplate objtemplate = new EmailTemplate();
        //objtemplate.EmailTempId = 4; // TempalteId for upcomming activity alert
        //DataTable dt = objEmailTempManager.GetEmailTempDetailsFromId(objtemplate);
        //string strEmailContent = "";
        //if (dt.Rows.Count > 0)
        //{
        //    strEmailContent = dt.Rows[0]["TempContent"].ToString();
        //    if (strEmailContent.Contains("#PersonName#"))
        //    {
        //        strEmailContent = strEmailContent.Replace("#PersonName#", BasePage.UserSession.FullName);
        //    }
        //    if (strEmailContent.Contains("#Activity#"))
        //    {
        //        strEmailContent = strEmailContent.Replace("#Activity#", ActivityTitle);
        //    }
        //    if (strEmailContent.Contains("#Description#"))
        //    {
        //        strEmailContent = strEmailContent.Replace("#Description#", ActivityDesc);
        //    }
        //    if (strEmailContent.Contains("#Owner#"))
        //    {
        //        strEmailContent = strEmailContent.Replace("#Owner#", BasePage.UserSession.FullName);
        //    }
        //    if (strEmailContent.Contains("#Account#"))
        //    {

        //        strEmailContent = strEmailContent.Replace("#Account#", Account);
        //    }
        //    if (strEmailContent.Contains("#Contact#"))
        //    {

        //        strEmailContent = strEmailContent.Replace("#Contact#", ContactName);
        //    }
        //    if (strEmailContent.Contains("#ContactDetails#"))
        //    {

        //        strEmailContent = strEmailContent.Replace("#ContactDetails#", ContactDetails);
        //    }

        //    if (strEmailContent.Contains("#CompanyName#"))
        //    {
        //        Cls_Organization objCls_Orgnization = new Cls_Organization();
        //        DataTable dtCompany = objCls_Orgnization.GetCompanyDetailsFromID(1); //Since Only One Organization Will Be Present
        //        if (dtCompany.Rows.Count >= 1)
        //        {
        //            strEmailContent = strEmailContent.Replace("#CompanyName#", dtCompany.Rows[0]["CompanyName"].ToString());
        //        }
        //    }
        //    if (strEmailContent.Contains("#LoginUrl#"))
        //    {
        //        strEmailContent = strEmailContent.Replace("#LoginUrl#", "http://" + Request.Url.Authority + Request.Url.Segments[0] + Request.Url.Segments[1] + "Login.aspx");
        //    }
        //    if (strEmailContent.Contains("#TeamName#"))
        //    {
        //        strEmailContent = strEmailContent.Replace("#TeamName#", "Ladder's Sales Team");
        //    }

        //}
        // return strEmailContent;
        return string.Empty;
    }

    /// <summary>
    /// Created By : Pravin Gholap
    /// Created Date: 26 June 2013
    /// Description: Send Email For Notifications
    /// </summary>
    /// <param name="ActivityTitle"></param>
    /// <param name="ActivityDesc"></param>
    /// <param name="Owner"></param>
    /// <param name="Account"></param>
    /// <param name="ContactName"></param>
    /// <param name="ContactDetails"></param>
    private void SendAlertMail(string ActivityTitle, string ActivityDesc, string Owner, string Account, string ContactName, string ContactDetails)
    {
        try
        {
            string strbody = GetEmailContent(ActivityTitle, ActivityDesc, Owner, Account, ContactName, ContactDetails);
            string subject = "Alert for upcoming activity!!!";
            SendMail(strbody.ToString(), BasePage.UserSession.UserEmail, subject);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    /// <summary>
    /// Created By : Pravin Gholap
    /// Created Date: 26 June 2013
    /// Description: Send Email For Notifications
    /// </summary>
    /// <param name="Content"></param>
    /// <param name="emilToId"></param>
    /// <param name="subject"></param>
    private Boolean SendMail(string Content, String emilToId, string subject)
    {
        Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
        try
        {
            //Send Email to EndUser 
           
            objEmailHelper.EmailFromID = ConfigurationManager.AppSettings["EmailFromID"].ToString();
            objEmailHelper.EmailSubject = subject;
            objEmailHelper.SMTPServerIP = ConfigurationManager.AppSettings["SMTPServerIP"].ToString();
            objEmailHelper.SMTPUserID = ConfigurationManager.AppSettings["SMTPUserID"].ToString();
            objEmailHelper.SMTPUserPwd = ConfigurationManager.AppSettings["SMTPUserPwd"].ToString();
            objEmailHelper.EmailToID = emilToId;
            objEmailHelper.EmailBody = Content;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBM.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), Content.Trim(), "EMail sent successfully", subject, "Forgot Password");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), Content.Trim(), "Error sending mail, Try again later !", subject, "Forgot Password");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "PFSalesMaster:SendMail.Error" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), Content.Trim(), Convert.ToString(ex.InnerException).Trim(), subject, "Forgot Password");
            return false;
        }
    }

   
    #endregion
}
