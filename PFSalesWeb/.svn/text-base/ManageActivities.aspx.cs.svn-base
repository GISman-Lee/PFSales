using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mechsoft.PFSales.BusinessEntity;
using Mechsoft.PFSales.BusinessManager;
using log4net;
using System.Reflection;
using System.Data;
using Mechsoft.GeneralUtilities;
using System.Text;
using System.Configuration;

public partial class ManageActivities : BasePage
{
    #region Global Variables
    Prospect objProsp = new Prospect();
    ProspectBM objProspBM = new ProspectBM();
    MasterBM objMstBM = new MasterBM();
    EmployeeBM objEmpBM = new EmployeeBM();
    Activity objActivity = new Activity();
    ActivityBM objActivityBM = new ActivityBM();
    ClearActivity objclrActivity = new ClearActivity();
    ILog Logger = LogManager.GetLogger(typeof(ManageActivities));
    double Interval1 = Convert.ToDouble(ConfigurationManager.AppSettings["ActInterval"].ToString().Trim());
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION2] = "StartDateTime";
            ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION2] = Cls_Constant.VIEWSTATE_DESC;
            if (Request.QueryString["ProspectId"] != null && !string.IsNullOrEmpty(Request.QueryString["ProspectId"].ToString().Trim()))
            {
                hdfProspectId.Value = Request.QueryString["ProspectId"].ToString().Trim();
                Session["ProspectTradeId"] = Request.QueryString["ProspectId"].ToString().Trim();
                Int64 ProspId = Convert.ToInt64(hdfProspectId.Value.Trim());
                BindMangeActivity(ProspId);
                MethodInfo methods1 = UC_ProspectDetails1.GetType().GetMethod("BidData");
                if (methods1 != null)
                {
                    object[] objParam = new object[] { ProspId };
                    methods1.Invoke(UC_ProspectDetails1, objParam);
                }

                ClearAll();
                ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = "CreatedDate";
                ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "Name";
                //ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION2] = "start";
                //ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION2] = ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;
                BindActivityTypes();
                BindPriorities();
                BindActStatuses();
                BindAllStatuses();
                BindConsultants();
                BindProspects();
                Page.MaintainScrollPositionOnPostBack = true;
                Page.Form.Attributes.Add("enctype", "multipart/form-data");
                GetMinStartDate();
                Label prospName = (Label)UC_ProspectDetails1.FindControl("lblName");
                if (hdfActivityId != null && hdfActivityDoc != null && hdfProspectId != null && pnlDetails != null && pnlGeneral != null && lnkbtnGeneralInfo != null && lnkbtnDetailsInfo != null && lnkbtnUpdate != null && lnkbtnSaveAct != null && lblAddActProspect != null && prospName != null && ddlProspect != null)
                {
                    BidData(ProspId);
                    pnlDetails.Visible = lnkbtnUpdate.Visible = false;
                    lblAddActProspect.Visible = pnlGeneral.Visible = lnkbtnSaveAct.Visible = true;
                    lnkbtnGeneralInfo.CssClass = "tablerBtnActive";
                    lnkbtnDetailsInfo.CssClass = "";
                    hdfActivityId.Value = "0";
                    if (ProspId > 0)
                        hdfProspectId.Value = Convert.ToString(ProspId);
                    if (prospName != null && !string.IsNullOrEmpty(prospName.Text.Trim()))
                        lblAddActProspect.Text = prospName.Text.Trim();
                    ddlProspect.Visible = false;
                }
                hdfActivityDoc.Value = string.Empty;
                if (hdfisUpdateNotes != null)
                    hdfisUpdateNotes.Value = "0";
            }
            else
            {
                if (ddlProspect != null && lblAddActProspect != null)
                {
                    ddlProspect.Visible = true;
                    lblAddActProspect.Visible = false;
                }
                if (Request.QueryString["TimeRange"] != null && !string.IsNullOrEmpty(Request.QueryString["TimeRange"].ToString().Trim()))
                {
                    hdfProspectId.Value = "0";
                    Int64 ProspId = 0;
                    ClearAll();
                    clearMsg();
                    Label prospName = (Label)UC_ProspectDetails1.FindControl("lblName");
                    if (hdfActivityId != null && hdfActivityDoc != null && hdfProspectId != null && pnlDetails != null && pnlGeneral != null && lnkbtnGeneralInfo != null && lnkbtnDetailsInfo != null && lnkbtnUpdate != null && lnkbtnSaveAct != null && lblAddActProspect != null && prospName != null && ddlProspect != null && ddlclrStatus != null && ddlActTime != null)
                    {

                        lblAddActProspect.Visible = pnlDetails.Visible = lnkbtnUpdate.Visible = false;
                        ddlProspect.Visible = pnlGeneral.Visible = lnkbtnSaveAct.Visible = true;
                        lnkbtnGeneralInfo.CssClass = "tablerBtnActive";
                        lnkbtnDetailsInfo.CssClass = "";
                        hdfActivityId.Value = "0";
                        if (ProspId > 0)
                            hdfProspectId.Value = Convert.ToString(ProspId);
                        if (prospName != null && !string.IsNullOrEmpty(prospName.Text.Trim()))
                            lblAddActProspect.Text = prospName.Text.Trim();
                        ddlProspect.Focus();
                    }
                    hdfActivityDoc.Value = string.Empty;
                }
                else if (Request.QueryString["EventId"] != null && !string.IsNullOrEmpty(Request.QueryString["EventId"].ToString().Trim()))
                {
                    hdfProspectId.Value = "0";
                    ClearAll();
                    clearMsg();
                    if (pnlDetails != null && pnlGeneral != null && lnkbtnGeneralInfo != null && lnkbtnDetailsInfo != null && lnkbtnUpdate != null && lnkbtnSaveAct != null && lblAddActivity != null && ddlAddActType != null && hdfActivityId != null)
                    {

                        hdfActivityId.Value = Request.QueryString["EventId"].ToString().Trim();
                        ddlProspect.Visible = lnkbtnUpdate.Visible = true;
                        lblAddActProspect.Visible = pnlDetails.Visible = lnkbtnSaveAct.Visible = false;
                        lnkbtnGeneralInfo.CssClass = "tablerBtnActive";
                        lnkbtnDetailsInfo.CssClass = "";
                        lblAddActivity.Text = Resources.PFSalesResource.updateactivity.Trim();
                        EditFromCalendar();
                        ddlProspect.Focus();
                    }
                }
                if (hdfisUpdateNotes != null)
                    hdfisUpdateNotes.Value = "0";
            }

        }
    }

    public void BidDataProsp(Int64 ProspId)
    {
        UC_ProspectDetails1.BidData(ProspId);
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 15 July 2013
    /// Description: Row Data Bound Event Of Manage Activity's Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvActivity_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdfClrId = (HiddenField)e.Row.FindControl("hdfClrId");
                HiddenField hdfActId = (HiddenField)e.Row.FindControl("hdfActId");
                LinkButton lnkbtnClearActDet = (LinkButton)e.Row.FindControl("lnkbtnClearActDet");
                if (hdfClrId != null && lnkbtnClearActDet != null && hdfActId != null)
                {
                    if (!string.IsNullOrEmpty(hdfClrId.Value) && Convert.ToInt64(hdfClrId.Value) > 0)
                    {
                        lnkbtnClearActDet.Enabled = false;
                        lnkbtnClearActDet.ToolTip = Resources.PFSalesResource.ClearedActivity.Trim();
                    }
                    else if (string.IsNullOrEmpty(hdfActId.Value.Trim()))
                    {
                        lnkbtnClearActDet.Enabled = false;
                        lnkbtnClearActDet.ToolTip = Resources.PFSalesResource.ClearedActivity.Trim();
                    }
                    else if (!string.IsNullOrEmpty(hdfActId.Value.Trim()) && Convert.ToInt64(hdfActId.Value.Trim()) == 0)
                    {
                        lnkbtnClearActDet.Enabled = false;
                        lnkbtnClearActDet.ToolTip = Resources.PFSalesResource.ClearedActivity.Trim();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ManageActivities.gvActivity_RowDataBound.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 2 July 2013
    /// Description: Show the pop up for clearing the activity
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnClearActDet_Click(object sender, EventArgs e)
    {
        try
        {
            HiddenField hdfclrActId = (HiddenField)UC_ClearActivity1.FindControl("hdfclrActId");
            HiddenField hdfclrActProsp = (HiddenField)UC_ClearActivity1.FindControl("hdfclrActProsp");
            Label lblName = (Label)UC_ProspectDetails1.FindControl("lblName");
            HiddenField hdfProspStatus = (HiddenField)UC_ProspectDetails1.FindControl("hdfProspStatus");
            if (hdfclrActId != null && hdfclrActProsp != null && lblName != null && hdfProspStatus != null)
            {
                hdfclrActId.Value = ((LinkButton)sender).CommandArgument.Trim();
                hdfclrActProsp.Value = hdfProspectId.Value.Trim();
                MethodInfo methods1 = UC_ClearActivity1.GetType().GetMethod("BindClearData");
                if (methods1 != null)
                {
                    object[] objParam = new object[] { lblName.Text.Trim(), hdfProspStatus };
                    methods1.Invoke(UC_ClearActivity1, objParam);
                    pnlClearAct.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ManageActivities.lnkbtnClearActDet_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 15 July 2013
    /// Description: Close the pop up of clearing the activity
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkClearActClose_Click(object sender, EventArgs e)
    {
        pnlClearAct.Visible = false;
        MethodInfo methods = UC_ClearActivity1.GetType().GetMethod("ClearAll");
        if (methods != null)
            methods.Invoke(UC_ClearActivity1, null);
        BindMangeActivity(Convert.ToInt64(hdfProspectId.Value.Trim()));
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 16 July 2013
    /// Description: Button Click Event Of Close Manage Activity Pop Up. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnViewActDet_Click(object sender, EventArgs e)
    {
        try
        {
            hdfActivityId.Value = ((LinkButton)sender).CommandArgument.Trim();
            HiddenField hdfClrId = (HiddenField)(((GridViewRow)((LinkButton)sender).NamingContainer).FindControl("hdfClrId"));
            Label prospName = (Label)UC_ProspectDetails1.FindControl("lblName");
            HiddenField hdfNotesId = (HiddenField)((GridViewRow)((LinkButton)sender).NamingContainer).FindControl("hdfNotesId");
            if (hdfContactNotesId != null && hdfNotesId != null && !string.IsNullOrEmpty(hdfNotesId.Value.Trim()))
                hdfContactNotesId.Value = hdfNotesId.Value.Trim();
            if (hdfClrId != null && !string.IsNullOrEmpty(hdfClrId.Value.Trim()) && Convert.ToInt64(hdfClrId.Value.Trim()) > 0 && prospName != null && hdfisUpdateNotes != null)
            {
                hdfisUpdateNotes.Value = "1";
                MethodInfo methods1 = UC_ClearActivityDetails1.GetType().GetMethod("Binddata");
                if (methods1 != null)
                {
                    object[] objParam = new object[] { Convert.ToInt64(hdfActivityId.Value.Trim()), prospName.Text };
                    methods1.Invoke(UC_ClearActivityDetails1, objParam);
                    pnlClearActDeatils.Visible = true;
                }
            }
            else
            {
                hdfisUpdateNotes.Value = "1";
                clearMsg();
                ClearAll();
                if (pnlDetails != null && pnlGeneral != null && lnkbtnGeneralInfo != null && lnkbtnDetailsInfo != null && lnkbtnUpdate != null && lnkbtnSaveAct != null && lblAddActivity != null && ddlAddActType != null)
                {
                    GridViewRow GrRow = ((GridViewRow)((LinkButton)sender).NamingContainer);
                    lnkbtnUpdate.Visible = true;
                    pnlDetails.Visible = lnkbtnSaveAct.Visible = false;
                    lnkbtnGeneralInfo.CssClass = "tablerBtnActive";
                    lnkbtnDetailsInfo.CssClass = "";
                    lblAddActivity.Text = Resources.PFSalesResource.updateactivity.Trim();
                    lblAddActProspect.Text = prospName.Text.Trim();
                    EditData();
                    ddlAddActType.Focus();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ManageActivities.lnkbtnViewActDet_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 16 July 2013
    /// Description: Close Clear Activity Details Pop Up
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnClearActDetClose_Click(object sender, EventArgs e)
    {
        pnlClearAct.Visible = pnlClearActDeatils.Visible = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 16 July 2013
    /// Description: Close Clear Activity Details Pop Up
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnBack_Click(object sender, EventArgs e)
    {
        Session["BackFromManageActivity"] = "true";

        if (Session["ConsultantId"] != null && Session["Flag"] != null && Session["Status"] != null)
        {
            Response.Redirect("LeadAllocation.aspx");
        }
        if (Request.QueryString["from"] != null && !string.IsNullOrEmpty(Request.QueryString["from"].ToString().Trim()))
        {
            int consultantID = Convert.ToInt32(Convert.ToString(Request.QueryString["from"]).Substring(2));
            Response.Redirect("LeadAllocation.aspx?from=ma" + consultantID);
        }
        else if (Request.QueryString["ProspectId"] != null && !string.IsNullOrEmpty(Request.QueryString["ProspectId"].ToString().Trim()))
        {
            if (BasePage.UserSession.RoleId == 3 || BasePage.UserSession.RoleId == 5)

                Response.Redirect("ViewMyContacts.aspx");

            else

                Response.Redirect("SearchProspect.aspx");


        }
        else if (Request.QueryString["TimeRange"] != null && !string.IsNullOrEmpty(Request.QueryString["TimeRange"].ToString().Trim()))
        {
            Response.Redirect("ActivityCall.aspx");
        }
        else if (Request.QueryString["EventId"] != null && !string.IsNullOrEmpty(Request.QueryString["EventId"].ToString().Trim()))
        {
            Response.Redirect("ActivityCall.aspx");
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 4 Sept 2013
    /// Description: View Next Prospect Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(Session["MyCurrentProsp"].ToString().Trim()))
            {
                if ((Convert.ToInt32(Session["MyCurrentProsp"].ToString().Trim())) == 2)
                {
                    lnkbtnPrevious.Visible = false;
                }
                Session["MyCurrentProsp"] = Convert.ToString(Convert.ToInt32(Session["MyCurrentProsp"].ToString().Trim()) + 1).Trim();
                if (Session["MyProspData"] != null && ((DataTable)(Session["MyProspData"])) != null && ((DataTable)(Session["MyProspData"])).Rows.Count > 0)
                {
                    if (Convert.ToInt32(Session["MyCurrentProsp"].ToString().Trim()) < ((DataTable)(Session["MyProspData"])).Rows.Count)
                        lnkbtnNext.Visible = false;
                    DataRow[] dr = ((DataTable)(Session["MyProspData"])).Select("RowNo='" + Session["MyCurrentProsp"].ToString().Trim() + "'");
                    if (dr != null && dr.Length > 0)
                    {
                        Int64 ProspId = Convert.ToInt64(Convert.ToString(dr[0]["RowNo"]).Trim());
                        if (ProspId > 0)
                            Response.Redirect("ManageActivities.aspx?ProspectId=" + Convert.ToString(dr[0]["Id"]).Trim());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ManageActivities.lnkbtnNext_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 4 Sept 2013
    /// Description: View Previous Prospect Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnPrevious_Click(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(Session["MyCurrentProsp"].ToString().Trim()))
            {
                if ((Convert.ToInt32(Session["MyCurrentProsp"].ToString().Trim())) >= 1)
                {
                    lnkbtnPrevious.Visible = true;
                }
                else
                { lnkbtnPrevious.Visible = false; }

                Session["MyCurrentProsp"] = Convert.ToString(Convert.ToInt32(Session["MyCurrentProsp"].ToString().Trim()) - 1).Trim();
                if (Session["MyProspData"] != null && ((DataTable)(Session["MyProspData"])) != null && ((DataTable)(Session["MyProspData"])).Rows.Count > 0)
                {
                    if (Convert.ToInt32(Session["MyCurrentProsp"].ToString().Trim()) == ((DataTable)(Session["MyProspData"])).Rows.Count)
                        lnkbtnNext.Visible = false;
                    DataRow[] dr = ((DataTable)(Session["MyProspData"])).Select("RowNo='" + Session["MyCurrentProsp"].ToString().Trim() + "'");
                    if (dr != null && dr.Length > 0)
                    {
                        Int64 ProspId = Convert.ToInt64(Convert.ToString(dr[0]["Id"]).Trim());
                        if (ProspId > 0)
                            Response.Redirect("ManageActivities.aspx?ProspectId=" + Convert.ToString(dr[0]["Id"]).Trim());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ManageActivities.lnkbtnNext_Click.Error:" + ex.StackTrace);
        }

    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 June 2013
    /// Description: Save Activity For Selected Lead
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlAddActType_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 June 2013
    /// Description: Selected Index Changed Event Of Select Alarm Value's Drop Down List. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlAlarm_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 19 June 2013
    /// Description: Clear Button Click of Add Activity Pop Up. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnPhPopUpCancel_Click(object sender, EventArgs e)
    {
        ClearpopUp();
        clearMsg();
        hdfActivityDoc.Value = string.Empty;
        lnkbtnSaveAct.Visible = true;
        lnkbtnUpdate.Visible = false;
        lblAddActivity.Text = Resources.PFSalesResource.AddNewActivity.Trim();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 2 July 2013
    /// Description: Update Activity For Selected Lead
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            clearMsg();
            if (Page.IsValid)
            {
                if (ddlclrActStatus.SelectedValue.Trim() != "0" && !string.IsNullOrEmpty(hdfProspectId.Value.Trim()) && Convert.ToInt64(hdfProspectId.Value.Trim()) > 0 && ddlAddActType.SelectedValue.Trim() != "0" && !string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlActTime.SelectedValue.Trim() != "0" && ddlPriority.SelectedValue.Trim() != "0")
                {
                    if (hdfisUpdateNotes.Value.Trim() == "1")
                    {
                        UpdateActiNotes();
                    }
                    else
                    {
                        UpdateOnlyActivity();
                        SaveViewState();
                    }
                    ClearAll();
                }
                else if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()) && Convert.ToInt64(hdfProspectId.Value.Trim()) > 0 && ddlAddActType.SelectedValue.Trim() != "0" && !string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlActTime.SelectedValue.Trim() != "0" && ddlPriority.SelectedValue.Trim() != "0" && string.IsNullOrEmpty(txtclrRemark.Text.Trim()) && ddlclrActStatus.SelectedValue.Trim() == "0")
                {
                    UpdateOnlyActivity();
                    ClearAll();
                }
                else if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()) && Convert.ToInt64(hdfProspectId.Value.Trim()) > 0 && ddlclrActStatus.SelectedValue.Trim() != "0" && string.IsNullOrEmpty(txtActDate.Text.Trim()))
                {
                    if (hdfisUpdateNotes.Value.Trim() == "1")
                        UpdateOnlyNotes();
                    else
                        SaveOnlyNotes();
                    ClearAll();
                }
                else if (string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlclrActStatus.SelectedValue.Trim() == "0" && string.IsNullOrEmpty(txtclrRemark.Text.Trim()))
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.NotesOrActVal.Trim();
                    dvaserSuccess.Visible = false;
                    lblSerSucMsg.Text = string.Empty;
                    dvsererror.Visible = true;
                }
                else if (string.IsNullOrEmpty(hdfProspectId.Value.Trim()) || Convert.ToInt64(hdfProspectId.Value.Trim()) == 0)
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.ContactSelVal.Trim();
                    dvaserSuccess.Visible = false;
                    lblSerSucMsg.Text = string.Empty;
                    dvsererror.Visible = true;
                }
                else if (!string.IsNullOrEmpty(txtActDate.Text.Trim()))
                {
                    if (ddlAddActType.SelectedValue.Trim() == "0")
                    {
                        rfvActPriority.Enabled = rvActTime.Enabled = rfvclrActStatus.Enabled = rfvNotes.Enabled = rfvAddActType.IsValid = false;
                        rfvActPriority.IsValid = rvActTime.IsValid = rfvclrActStatus.IsValid = rfvNotes.IsValid = rfvAddActType.Enabled = true;
                        ddlAddActType.Focus();
                        Page.Validate("Save");
                    }
                    else if (ddlActTime.SelectedValue.Trim() == "0")
                    {
                        rfvActPriority.Enabled = rfvAddActType.Enabled = rfvclrActStatus.Enabled = rfvNotes.Enabled = rvActTime.IsValid = false;
                        rfvActPriority.IsValid = rfvAddActType.IsValid = rfvclrActStatus.IsValid = rfvNotes.IsValid = rvActTime.Enabled = true;
                        ddlActTime.Focus();
                        Page.Validate("Save");
                    }
                    else if (ddlPriority.SelectedValue.Trim() == "0")
                    {
                        rvActTime.Enabled = rfvAddActType.Enabled = rfvclrActStatus.Enabled = rfvNotes.Enabled = rfvActPriority.IsValid = false;
                        rvActTime.IsValid = rfvAddActType.IsValid = rfvclrActStatus.IsValid = rfvNotes.IsValid = rfvActPriority.Enabled = true;
                        ddlPriority.Focus();
                        Page.Validate("Save");
                    }
                }
                pnlGeneral.Visible = true;
                pnlDetails.Visible = false;
                lnkbtnGeneralInfo.CssClass = "tablerBtnActive";
                lnkbtnDetailsInfo.CssClass = "";
                BindMangeData();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_AddActivity.lnkbtnUpdate_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 June 2013
    /// Description: Save Activity For Selected Lead
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSaveAct_Click(object sender, EventArgs e)
    {
        try
        {
            clearMsg();
            if (Page.IsValid)
            {
                if (ddlclrActStatus.SelectedValue.Trim() != "0" && !string.IsNullOrEmpty(hdfProspectId.Value.Trim()) && Convert.ToInt64(hdfProspectId.Value.Trim()) > 0 && ddlAddActType.SelectedValue.Trim() != "0" && !string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlActTime.SelectedValue.Trim() != "0" && ddlPriority.SelectedValue.Trim() != "0")
                {
                    SaveActiNotes();
                    ClearAll();
                }
                else if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()) && Convert.ToInt64(hdfProspectId.Value.Trim()) > 0 && ddlAddActType.SelectedValue.Trim() != "0" && !string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlActTime.SelectedValue.Trim() != "0" && ddlPriority.SelectedValue.Trim() != "0" && string.IsNullOrEmpty(txtclrRemark.Text.Trim()) && ddlclrActStatus.SelectedValue.Trim() == "0")
                {
                    SaveOnlyActivity();
                    ClearAll();
                }
                else if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()) && Convert.ToInt64(hdfProspectId.Value.Trim()) > 0 && ddlclrActStatus.SelectedValue.Trim() != "0" && string.IsNullOrEmpty(txtActDate.Text.Trim()))
                {
                    SaveOnlyNotes();
                    ClearAll();
                }
                else if (string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlclrActStatus.SelectedValue.Trim() == "0" && string.IsNullOrEmpty(txtclrRemark.Text.Trim()))
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.NotesOrActVal.Trim();
                    dvaserSuccess.Visible = false;
                    lblSerSucMsg.Text = string.Empty;
                    dvsererror.Visible = true;
                }
                else if (string.IsNullOrEmpty(hdfProspectId.Value.Trim()) || Convert.ToInt64(hdfProspectId.Value.Trim()) == 0)
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.ContactSelVal.Trim();
                    dvaserSuccess.Visible = false;
                    lblSerSucMsg.Text = string.Empty;
                    dvsererror.Visible = true;
                }
                else if (!string.IsNullOrEmpty(txtActDate.Text.Trim()))
                {
                    if (ddlAddActType.SelectedValue.Trim() == "0")
                    {
                        rfvActPriority.Enabled = rvActTime.Enabled = rfvclrActStatus.Enabled = rfvNotes.Enabled = rfvAddActType.IsValid = false;
                        rfvActPriority.IsValid = rvActTime.IsValid = rfvclrActStatus.IsValid = rfvNotes.IsValid = rfvAddActType.Enabled = true;
                        ddlAddActType.Focus();
                        Page.Validate("Save");
                    }
                    else if (ddlActTime.SelectedValue.Trim() == "0")
                    {
                        rfvActPriority.Enabled = rfvAddActType.Enabled = rfvclrActStatus.Enabled = rfvNotes.Enabled = rvActTime.IsValid = false;
                        rfvActPriority.IsValid = rfvAddActType.IsValid = rfvclrActStatus.IsValid = rfvNotes.IsValid = rvActTime.Enabled = true;
                        ddlActTime.Focus();
                        Page.Validate("Save");
                    }
                    else if (ddlPriority.SelectedValue.Trim() == "0")
                    {
                        rvActTime.Enabled = rfvAddActType.Enabled = rfvclrActStatus.Enabled = rfvNotes.Enabled = rfvActPriority.IsValid = false;
                        rvActTime.IsValid = rfvAddActType.IsValid = rfvclrActStatus.IsValid = rfvNotes.IsValid = rfvActPriority.Enabled = true;
                        ddlPriority.Focus();
                        Page.Validate("Save");
                    }
                }
            }
            GetMinStartDate();
            if (ViewState["ContactStatus"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["ContactStatus"]).Trim()))
            {
                if (BasePage.UserSession.RoleId == 3)
                {
                    if (ddlclrStatus.SelectedValue.Trim().ToUpper() != Convert.ToString(ViewState["ContactStatus"]).Trim().ToUpper())
                    {
                        if (ddlclrStatus.SelectedValue.Trim() == "25" || ddlclrStatus.SelectedValue.Trim() == "27")
                        {
                            if (ViewState["FConsultEmail"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["FConsultEmail"]).Trim()) && ViewState["FConsultant"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["FConsultant"]).Trim()))
                                SendMail(Convert.ToString(ViewState["FConsultEmail"]).Trim(), ddlclrStatus.SelectedItem.Text.Trim(), Convert.ToString(ViewState["FConsultant"]).Trim(), Convert.ToString(ViewState["Name"]).Trim());
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_AddActivity.lnkbtnSaveAct_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 21 June 2013
    /// Description: Selected Index Changed Event Of Select Duration Value's Drop Down List. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlDuration_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DateTime dtnew = new DateTime();
            if (ddlDuration.SelectedValue.Trim() != "0")
            {
                DateTime StartDate = Convert.ToDateTime(txtActDate.Text.Trim() + " " + txtActTime.Text.Trim());
                if (ddlDuration.SelectedValue.Trim() == "1")
                    dtnew = StartDate.AddMinutes(0);
                else
                    dtnew = StartDate.AddMinutes(Convert.ToDouble(ddlDuration.SelectedValue.Trim()));
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_AddActivity.ddlDuration_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 Aug 2013
    /// Description: Custom Validation For Minimum Start Date For Activity
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cvSdateTime_Validate(object sender, ServerValidateEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtActDate.Text) && !string.IsNullOrEmpty(hdfMinSDate.Value) && ddlActTime.SelectedValue != "0")
            {
                DateTime dt = Convert.ToDateTime(txtActDate.Text.Trim() + " " + ddlActTime.SelectedValue.Trim());
                DateTime Dt1 = Convert.ToDateTime(hdfMinSDate.Value.Trim());
                if (dt > Dt1)
                    e.IsValid = true;
                else
                    e.IsValid = false;
            }
            else
                e.IsValid = true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_AddActivity.cvSdateTime_Validate.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 Aug 2013
    /// Description: Set Reminder for next Working Day
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnCallTommarrow_Click(object sender, EventArgs e)
    {
        try
        {
            int DayofTheWeek = Convert.ToInt32(DateTime.Today.DayOfWeek);
            DateTime Dt1 = DateTime.Today;
            switch (DayofTheWeek)
            {
                case 5://friday
                    Dt1 = Dt1.AddDays(3);
                    break;
                case 6://Saturday
                    Dt1 = Dt1.AddDays(2);
                    break;
                default:
                    Dt1 = Dt1.AddDays(1);
                    break;
            }
            SetCallTomorrow(Dt1);
            GetMinStartDate();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_AddActivity.lnkbtnCallTommarrow_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 June 2013
    /// Description: Details Info Button Click of Add Activity Pop Up. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnDetailsInfo_Click(object sender, EventArgs e)
    {
        clearMsg();
        pnlGeneral.Visible = false;
        pnlDetails.Visible = true;
        lnkbtnGeneralInfo.CssClass = "";
        lnkbtnDetailsInfo.CssClass = "tablerBtnActive";
        GetMinStartDate();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 16 June 2013
    /// Description: Selected Index Changed Event Of Prospect's Drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlProspect_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            hdfProspectId.Value = ddlProspect.SelectedValue.Trim();
            BidData(Convert.ToInt64(hdfProspectId.Value.Trim()));
            lblAddActProspect.Text = ddlProspect.SelectedItem.Text.Trim();
            MethodInfo methods1 = (UC_ProspectDetails1).GetType().GetMethod("BidData");// ((Page)this.Parent).GetType().GetMethod("BindMangeActivity");
            if (methods1 != null)
            {
                object[] objParam = new object[] { Convert.ToInt64(ddlProspect.SelectedValue.Trim()) };
                methods1.Invoke((UC_ProspectDetails1), objParam);
            }
            BindMangeData();
            GetMinStartDate();
            //}
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_AddActivity.ddlProspect_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 June 2013
    /// Description: General Info Button Click of Add Activity Pop Up. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnGeneralInfo_Click(object sender, EventArgs e)
    {
        clearMsg();
        pnlGeneral.Visible = true;
        pnlDetails.Visible = false;
        lnkbtnGeneralInfo.CssClass = "tablerBtnActive";
        lnkbtnDetailsInfo.CssClass = "";
    }
    #endregion

    #region Methods

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 June 2013
    /// Description: Bind All Priorities
    /// </summary>
    public void BindPriorities()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllActPriorities(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlPriority, "Name", "Id", Dt);
            ddlPriority.SelectedValue = "2";
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_AddActivity.BindPriorities.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 June 2013
    /// Description: Bind All Activity Types
    /// </summary>
    public void BindActivityTypes()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllActivityTypes(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlAddActType, "Name", "Id", Dt);
            ddlAddActType.SelectedValue = "1";
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_AddActivity.BindActivityTypes.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 15 July 2013
    /// Description: Bind Managed Activity Data
    /// </summary>
    /// <param name="ProspectId"></param>
    public void BindMangeActivity(Int64 ProspectId)
    {
        try
        {
            if (ProspectId > 0)
            {
                DataTable Dt = objActivityBM.GetAllContactNotes(ProspectId, BasePage.UserSession.VirtualRoleId);
                if (Dt != null & Dt.Rows.Count > 0)
                {
                    DataView dV = Dt.DefaultView;
                    dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION2].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION2].ToString());
                    gvActivity.DataSource = Dt;
                    gvActivity.DataBind();
                }
                else
                {
                    gvActivity.DataSource = null;
                    gvActivity.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SearchProspect.lnkbtnManageAct_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 Aug 2013
    /// Description: Bind Act Status Id
    /// </summary>
    /// <param name="ProspId"></param>
    public void BidData(Int64 ProspId)
    {
        try
        {
            if (ProspId > 0)
            {
                DataTable dt = objProspBM.GetProspDetAssignedToConsult(0, DateTime.MinValue, DateTime.MaxValue, ProspId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (BasePage.UserSession.RoleId == 5)
                        ViewState["ContactStatus"] = ddlclrStatus.SelectedValue = Convert.ToString(dt.Rows[0]["FCStatusId"]).Trim();
                    else
                        ViewState["ContactStatus"] = ddlclrStatus.SelectedValue = Convert.ToString(dt.Rows[0]["StatusId"]).Trim();

                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["FConsultant"]).Trim()))
                        ViewState["FConsultant"] = ddlclrStatus.SelectedValue = Convert.ToString(dt.Rows[0]["FConsultant"]).Trim();
                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["FConsultEmail"]).Trim()))
                        ViewState["FConsultEmail"] = ddlclrStatus.SelectedValue = Convert.ToString(dt.Rows[0]["FConsultEmail"]).Trim();
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
    /// Created Date: 20 June 2013
    /// Description: Clear All Controls Inside Add Activity PopUp
    /// </summary>
    public void ClearAll()
    {
        try
        {
            ViewState["SelectedStatus"] = ddlAlarm.SelectedValue = ddlclrStatus.SelectedValue = ddlclrActStatus.SelectedValue = ddlProspect.SelectedValue = ddlDuration.SelectedValue = "0"; //ddlRegarding.SelectedValue = 
            txtActDate.Text = txtLocation.Text = string.Empty;
            dtAlertType.Visible = ddAlertType.Visible = false;
            txtclrRemark.Text = txtRegarding.Text = string.Empty;
            txtRemark.Text = string.Empty;
            ddlAddActType.SelectedValue = "1";
            ddlPriority.SelectedValue = "2";
            BindConsultants();
            ddlActTime.SelectedValue = txtActTime.Text = "09:00";
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_AddActivity.ClearpopUp.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 June 2013
    /// Description: Bind ConsulTants
    /// </summary>
    public void BindConsultants()
    {
        try
        {
            Int64 ActId = 0;
            if (hdfActivityId != null && !string.IsNullOrEmpty(hdfActivityId.Value.Trim()))
                ActId = Convert.ToInt64(hdfActivityId.Value.Trim());
            DataTable Dt = objActivityBM.GetAllConsultForActivity(string.Empty, ActId);
            if (Dt != null & Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0]["ActSMSAlertId"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["ActSMSAlertId"].ToString().Trim()))
                    hdfActSMSAlertId.Value = Dt.Rows[0]["ActSMSAlertId"].ToString().Trim();
                if (Dt.Rows[0]["ActMailAlertId"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["ActMailAlertId"].ToString().Trim()))
                    hdfActMailAlertId.Value = Dt.Rows[0]["ActMailAlertId"].ToString().Trim();
                if (Dt.Rows[0]["ActDashAlertId"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["ActDashAlertId"].ToString().Trim()))
                    hdfActDashAlertId.Value = Dt.Rows[0]["ActDashAlertId"].ToString().Trim();
                if (Dt.Rows[0]["ActDashAlertId"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["ActDashAlertId"].ToString().Trim()))
                    hdfActResId.Value = Dt.Rows[0]["ActResId"].ToString().Trim();
            }
        }

        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_AddActivity.BindConsultants.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 May 2013
    /// Description: Clear All Messages
    /// </summary>
    public void clearMsg()
    {
        lblSerErrMsg.Text = lblSerSucMsg.Text = string.Empty;
        dvaserSuccess.Visible = dvsererror.Visible = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 19 June 2013
    /// Description: Clear Controls Inside Add Activity PopUp
    /// </summary>
    public void ClearpopUp()
    {
        try
        {
            ViewState["SelectedStatus"] = ddlAlarm.SelectedValue = ddlclrStatus.SelectedValue = ddlAddActType.SelectedValue = ddlPriority.SelectedValue = ddlDuration.SelectedValue = ddlAlarm.SelectedValue = "0";//ddlRegarding.SelectedValue =
            txtRegarding.Text = txtActDate.Text = txtActTime.Text = txtLocation.Text = string.Empty; //txtEndDate.Text = txtEndTime.Text =
            ddlActTime.SelectedValue = "09:00";
            txtclrRemark.Text = txtRemark.Text = string.Empty;
            ddlAddActType.SelectedValue = "1";
            ddlAddActType_SelectedIndexChanged(null, null);
            ddlPriority.SelectedValue = "2";
            ddlclrActStatus.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_AddActivity.ClearpopUp.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 May 2013
    /// Description: Bind Grid View Data
    /// </summary>
    public void BindProspects()
    {
        try
        {
            Int64 ProspId = 0;
            //if (hdfProspectId.Value != null && !string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
            //    ProspId = Convert.ToInt64(hdfActivityId.Value.Trim());
            //Change on 11 Sept 2014 For rendering from Calender By Ayyaj Added Part: && hdfActivityId.Value != "0"
            if (hdfActivityId.Value != null && !string.IsNullOrEmpty(hdfActivityId.Value.Trim()) && hdfActivityId.Value != "0")
            {
                ProspId = Convert.ToInt64(hdfActivityId.Value.Trim());

                objProsp.FName = string.Empty;
                objProsp.StatusId = 0;
                if (BasePage.UserSession.RoleId == 3)
                {
                    objProsp.ConsultId = Convert.ToInt64(BasePage.UserSession.VirtualRoleId.ToString());
                }
                else
                    objProsp.ConsultId = 0;
                DataSet Ds = objProspBM.GetAllProspects_BindDrop(objProsp);
                if (Ds != null && Ds.Tables.Count > 0)
                {
                    DataTable Dt = Ds.Tables[0];
                    if (Dt != null && Dt.Rows.Count > 0)
                    {
                        Cls_BinderHelper.BindDropdownList(ddlProspect, "Name", "Id", Dt);
                        if (ProspId > 0)
                        {
                            ddlProspect.SelectedValue = hdfProspectId.Value.Trim();
                        }
                    }
                }
                //DataSet Ds = objProspBM.GetAllProspects(objProsp);
                //DataTable Dt = Ds.Tables[0];
                //DataView Dv = Dt.DefaultView;
                //if (BasePage.UserSession.RoleId == 3)
                //{
                //    Dv.RowFilter = "ConsultantId=" + BasePage.UserSession.VirtualRoleId.ToString().Trim();
                //    DataTable Dttemp = Dv.ToTable();
                //}

                //Cls_BinderHelper.BindDropdownList(ddlProspect, "Name", "Id", Dt);
                //if (ProspId > 0)
                //{
                //    ddlProspect.SelectedValue = hdfProspectId.Value.Trim();
                //}

            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_AddActivity.BindProspects.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 July 2013
    /// Description: Get Activity Statuses
    /// </summary>
    /// <param name="ProsessId"></param>
    public void BindActStatuses()
    {
        try
        {
            DataTable Dt;
            if (BasePage.UserSession.RoleId == 5)
                Dt = objMstBM.GetAllStatus(6, 2);// Hard Coded Entity Id for FC Consultants & Process Id
            else
                Dt = objMstBM.GetAllStatus(2, 2);// Hard Coded Entity Id & Process Id
            Cls_BinderHelper.BindDropdownList(ddlclrActStatus, "Status", "Id", Dt);
            if (ViewState["SelectedStatus"] != null && !string.IsNullOrEmpty(ViewState["SelectedStatus"].ToString().Trim()) && Convert.ToInt32(ViewState["SelectedStatus"].ToString().Trim()) > 0)
                ddlclrActStatus.SelectedValue = ViewState["SelectedStatus"].ToString().Trim();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_AddActivity.BindActStatuses.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 Aug 2013
    /// Description: Get All Statuses
    /// </summary>
    private void BindAllStatuses()
    {
        try
        {
            DataTable Dt;
            if (BasePage.UserSession.RoleId == 5)
                Dt = objMstBM.GetAllStatus(6, 1);// Hard Coded Entity Id for FC Consultants & Process Id
            else if (BasePage.UserSession.RoleId == 3)
                Dt = objMstBM.GetAllStatus(1, 1);// Hard Coded Entity Id & Process Id
            else if (BasePage.UserSession.RoleId == 1)
            {
                if (Session["ForW"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["ForW"]).Trim()))
                {
                    if (Convert.ToString(Session["ForW"]).Trim().ToUpper() == "W")
                        Dt = objMstBM.GetAllStatus(1, 1);
                    else if (Convert.ToString(Session["ForW"]).Trim().ToUpper() == "F")
                        Dt = objMstBM.GetAllStatus(6, 1);
                    else
                        Dt = objMstBM.GetAllStatus(1, 1);
                }
                else
                    Dt = objMstBM.GetAllStatus(1, 1);
            }
            else
                Dt = objMstBM.GetAllStatus(1, 1);

            Cls_BinderHelper.BindDropdownList(ddlclrStatus, "Status", "Id", Dt);
            if (ViewState["ContactStatus"] != null && !string.IsNullOrEmpty(ViewState["ContactStatus"].ToString().Trim()) && Convert.ToInt32(ViewState["ContactStatus"].ToString().Trim()) > 0)
                ddlclrStatus.SelectedValue = ViewState["ContactStatus"].ToString().Trim();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SearchProspect.BindAllStatuses.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 Aug 2013
    /// Description: Get Minimum StartDate For A Prospect
    /// </summary>
    public void GetMinStartDate()
    {
        try
        {
            Int64 ProspId = 0;
            if (hdfProspectId != null && !string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
                ProspId = Convert.ToInt64(hdfProspectId.Value.Trim());
            DataTable Dt = objActivityBM.GetMinDateForFutureAct(ProspId, BasePage.UserSession.VirtualRoleId);
            if (Dt != null && Dt.Rows.Count > 0)
            {
                hdfMinSDate.Value = Dt.Rows[0]["MinDate"].ToString().Trim();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_AddActivity.GetMinStartDate.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 16 July 2013
    /// Description: Bind Managed Activity Data of Parrent Page
    /// </summary>
    public void BindMangeData()
    {
        try
        {
            BindMangeActivity(Convert.ToInt64(hdfProspectId.Value.Trim()));
            MethodInfo methods2 = UC_ProspectDetails1.GetType().GetMethod("BidData");// ((Page)this.Parent).GetType().GetMethod("BindMangeActivity");
            if (methods2 != null)
            {
                object[] objParam = new object[] { Convert.ToInt64(hdfProspectId.Value.Trim()) };
                methods2.Invoke((UC_ProspectDetails1), objParam);
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_AddActivity.BindMangeData.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 22 Aug 2013
    /// Description: Show Old Activity Details 
    /// </summary>
    public void EditFromCalendar()
    {
        try
        {
            DataTable Dt = objActivityBM.GetActivityDetFromId(Convert.ToInt64(hdfActivityId.Value.Trim()), BasePage.UserSession.VirtualRoleId);
            if (Dt != null && Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0]["ProspectId"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["ProspectId"].ToString().Trim()))
                {
                    BindProspects();
                    ddlProspect.SelectedValue = Dt.Rows[0]["ProspectId"].ToString().Trim();
                    hdfProspectId.Value = Dt.Rows[0]["ProspectId"].ToString().Trim();
                }
                BindActStatuses();
                BindAllStatuses();
                if (BasePage.UserSession.RoleId == 5)
                    ViewState["ContactStatus"] = ddlclrStatus.SelectedValue = Dt.Rows[0]["FCStatusId"].ToString().Trim();
                else
                    ViewState["ContactStatus"] = ddlclrStatus.SelectedValue = Dt.Rows[0]["ContactStatus"].ToString().Trim();
                hdfActivityDocId.Value = Dt.Rows[0]["DocId"].ToString().Trim();
                hdfActivityDoc.Value = Dt.Rows[0]["Filepath"].ToString().Trim();
                hdfContactNotesId.Value = Dt.Rows[0]["CNId"].ToString().Trim();
                ddlAlarm_SelectedIndexChanged(null, null);
                BindConsultants();
                DataTable dtAlertDet = objActivityBM.GetActivityAlertDetailsFromId(Convert.ToInt64(hdfActivityId.Value.Trim()), BasePage.UserSession.VirtualRoleId);
                if (Convert.ToInt64(ddlProspect.SelectedValue.Trim()) > 0)
                    ddlProspect_SelectedIndexChanged(null, null);
                GetMinStartDate();
            }
            else if (!string.IsNullOrEmpty(hdfContactNotesId.Value.Trim()) && Convert.ToInt64(hdfContactNotesId.Value.Trim()) > 0)
            {
                Dt = objActivityBM.GetContactNotesFromId(Convert.ToInt64(hdfContactNotesId.Value.Trim()));
                if (Dt.Rows[0]["ContactId"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["ContactId"].ToString().Trim()))
                {
                    BindProspects();
                    ddlProspect.SelectedValue = Dt.Rows[0]["ContactId"].ToString().Trim();
                    hdfProspectId.Value = Dt.Rows[0]["ContactId"].ToString().Trim();
                }
                ViewState["ContactStatus"] = ddlclrStatus.SelectedValue = Dt.Rows[0]["ContactStatus"].ToString().Trim();
                txtclrRemark.Text = Dt.Rows[0]["Notes"].ToString().Trim();
                if (Dt.Rows[0]["NotesStatus"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["NotesStatus"].ToString().Trim()))
                {
                    ViewState["SelectedStatus"] = ddlclrActStatus.SelectedValue = Dt.Rows[0]["NotesStatus"].ToString().Trim();
                    BindAllStatuses();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_AddActivity.EditData.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 July 2013
    /// Description: Show Old Activity Details 
    /// </summary>
    public void EditData()
    {
        try
        {
            DataTable Dt = objActivityBM.GetActivityDetFromId(Convert.ToInt64(hdfActivityId.Value.Trim()), BasePage.UserSession.VirtualRoleId);
            if (Dt != null && Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0]["ProspectId"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["ProspectId"].ToString().Trim()))
                {
                    BindProspects();
                    ddlProspect.SelectedValue = Dt.Rows[0]["ProspectId"].ToString().Trim();
                    hdfProspectId.Value = Dt.Rows[0]["ProspectId"].ToString().Trim();
                }
                ddlAddActType.SelectedValue = Dt.Rows[0]["ActivityTypeId"].ToString().Trim();
                BindActStatuses();
                if (Dt.Rows[0]["NotesStatus"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["NotesStatus"].ToString().Trim()))
                {
                    ViewState["SelectedStatus"] = ddlclrActStatus.SelectedValue = Dt.Rows[0]["NotesStatus"].ToString().Trim();
                    BindAllStatuses();
                }
                if (BasePage.UserSession.RoleId == 5)
                    ViewState["ContactStatus"] = ddlclrStatus.SelectedValue = Dt.Rows[0]["FCStatusId"].ToString().Trim();
                else
                    ViewState["ContactStatus"] = ddlclrStatus.SelectedValue = Dt.Rows[0]["ContactStatus"].ToString().Trim();
                txtclrRemark.Text = Dt.Rows[0]["Notes"].ToString().Trim();
                ddlAddActType_SelectedIndexChanged(null, null);
                txtRegarding.Text = Dt.Rows[0]["name"].ToString().Trim();
                ddlPriority.SelectedValue = Dt.Rows[0]["ActivityPriorityId"].ToString().Trim();
                txtActDate.Text = Convert.ToDateTime(Dt.Rows[0]["start"].ToString().Trim()).ToString("dd/MM/yyyy").Substring(0, 10);
                ddlActTime.SelectedValue = Convert.ToDateTime(Dt.Rows[0]["start"].ToString().Trim()).ToString("HH:mm:ss").Substring(0, 5);
                hdfOldActStartTime.Value = Dt.Rows[0]["start"].ToString().Trim();
                txtLocation.Text = Dt.Rows[0]["Location"].ToString().Trim();
                hdfActivityDocId.Value = Dt.Rows[0]["DocId"].ToString().Trim();
                hdfActivityDoc.Value = Dt.Rows[0]["Filepath"].ToString().Trim();
                hdfContactNotesId.Value = Dt.Rows[0]["CNId"].ToString().Trim();
                txtRemark.Text = Dt.Rows[0]["Remark"].ToString().Trim();
                if (Dt.Rows[0]["AlertValueBefore"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["AlertValueBefore"].ToString().Trim()))
                    ddlAlarm.SelectedValue = Dt.Rows[0]["AlertValueBefore"].ToString().Trim();
                ddlAlarm_SelectedIndexChanged(null, null);
                BindConsultants();
                DataTable dtAlertDet = objActivityBM.GetActivityAlertDetailsFromId(Convert.ToInt64(hdfActivityId.Value.Trim()), BasePage.UserSession.VirtualRoleId);
                if (Convert.ToInt64(ddlProspect.SelectedValue.Trim()) > 0)
                    ddlProspect_SelectedIndexChanged(null, null);
                GetMinStartDate();
            }
            else if (!string.IsNullOrEmpty(hdfContactNotesId.Value.Trim()) && Convert.ToInt64(hdfContactNotesId.Value.Trim()) > 0)
            {
                Dt = objActivityBM.GetContactNotesFromId(Convert.ToInt64(hdfContactNotesId.Value.Trim()));
                if (Dt.Rows[0]["ContactId"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["ContactId"].ToString().Trim()))
                {
                    BindProspects();
                    //Change on 11 Sept 2014 For rendering from Calender By Ayyaj Added Part: If Conditon
                    if (hdfActivityId.Value != null && !string.IsNullOrEmpty(hdfActivityId.Value.Trim()) && ddlProspect.Visible==true)
                    {
                        ddlProspect.SelectedValue = Dt.Rows[0]["ContactId"].ToString().Trim();
                    }
                    hdfProspectId.Value = Dt.Rows[0]["ContactId"].ToString().Trim();
                }
                ViewState["ContactStatus"] = ddlclrStatus.SelectedValue = Dt.Rows[0]["ContactStatus"].ToString().Trim();
                txtclrRemark.Text = Dt.Rows[0]["Notes"].ToString().Trim();
                if (Dt.Rows[0]["NotesStatus"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["NotesStatus"].ToString().Trim()))
                {
                    ViewState["SelectedStatus"] = ddlclrActStatus.SelectedValue = Dt.Rows[0]["NotesStatus"].ToString().Trim();
                    BindAllStatuses();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_AddActivity.EditData.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 12 Aug 2013
    /// Description: Update Acttvity & Notes
    /// </summary>
    private void UpdateActiNotes()
    {
        Int64 Result = 0;
        if (!string.IsNullOrEmpty(hdfActivityId.Value.Trim()) && Convert.ToInt64(hdfActivityId.Value.Trim()) > 0)
        {
            StringBuilder strIds = new StringBuilder();
            objActivity.Id = Convert.ToInt64(hdfActivityId.Value.Trim());
            objActivity.ParrentActId = 0;
            objActivity.ActivityTypeId = Convert.ToInt16(ddlAddActType.SelectedValue.Trim());
            objActivity.Regarding = ddlAddActType.SelectedItem.Text.Trim() + " : to " + lblAddActProspect.Text.Trim();//txtRegarding.Text.Trim();
            if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
                objActivity.ProspectId = Convert.ToInt64(hdfProspectId.Value.Trim());
            else
                objActivity.ProspectId = 0;
            if (!string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlActTime.SelectedValue.Trim() != "0") //!string.IsNullOrEmpty(txtActTime.Text.Trim())
            {
                objActivity.ActStartTime = Convert.ToDateTime(txtActDate.Text.Trim() + " " + ddlActTime.SelectedValue.Trim());//txtActTime.Text.Trim()
                GetCountOfActForStime(objActivity.ActStartTime, Interval1);
                DateTime dt;
                if (ViewState["NewStartDate"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["NewStartDate"]).Trim()))
                    dt = objActivity.ActStartTime = Convert.ToDateTime(Convert.ToString(ViewState["NewStartDate"]).Trim());
                else
                    dt = Convert.ToDateTime(txtActDate.Text.Trim() + " " + ddlActTime.SelectedValue.Trim());//txtActTime.Text.Trim()
                objActivity.ActEndTime = dt.AddMinutes(2);
            }
            objActivity.IsTimeLess = false;
            objActivity.IsPrivate = false;
            objActivity.Status = Convert.ToInt32(ddlActStatus.SelectedValue.Trim());
            objActivity.Duration = Convert.ToInt32(ddlDuration.SelectedValue.Trim());
            objActivity.ActivityDocId = Convert.ToInt64(hdfActivityDocId.Value.Trim());
            objActivity.ActivityDocRemark = txtRemark.Text.Trim();
            objActivity.ActivityDocFilePath = hdfActivityDoc.Value.Trim();
            objActivity.Location = txtLocation.Text.Trim();
            List<ActResources> lstResources = new List<ActResources>();
            List<ActAlertDetails> lstActAlerts = new List<ActAlertDetails>();
            ActResources objActResource = new ActResources();
            objActResource.ResourceId = BasePage.UserSession.VirtualRoleId;//Convert.ToInt64(hdfConsultantId.Value.Trim());
            objActResource.ActResourceId = Convert.ToInt64(hdfActResId.Value.Trim());
            objActResource.IsDeleted = false;
            if (Convert.ToInt64(hdfActResId.Value.Trim()) > 0)//!chkSelect.Checked && Convert.ToInt64(hdfConsultantId.Value.Trim()) > 0 && (
            {
                objActResource.IsDeleted = true;
            }
            lstResources.Add(objActResource);

            if (ddlAlarm.SelectedValue.Trim() != "0")
            {
                objActivity.PriorityId = 1;//Hard Code For High Priority Convert.ToInt16(ddlPriority.SelectedValue.Trim());
                if (chkSms.Checked)
                {
                    ActAlertDetails objActAlertDetails = new ActAlertDetails();
                    if (Convert.ToInt64(hdfActSMSAlertId.Value.Trim()) > 0)
                    {
                        objActAlertDetails.IsDeleted = true;
                    }
                    else
                        objActAlertDetails.IsDeleted = false;
                    objActAlertDetails.ActAlertId = Convert.ToInt64(hdfActSMSAlertId.Value.Trim());
                    objActAlertDetails.AlertTypeId = Cls_Constant.SMSAlert;// Hard Coded For SMS
                    if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                        objActAlertDetails.AlertValueBefore = 0;
                    else
                        objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                    objActAlertDetails.SnoozValue = 0;
                    objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// hdfConsultantId.Value.Trim(); //strIds.ToString().TrimEnd(',');
                    lstActAlerts.Add(objActAlertDetails);
                }
                if (chkEmail.Checked)
                {
                    ActAlertDetails objActAlertDetails = new ActAlertDetails();
                    if (Convert.ToInt64(hdfActMailAlertId.Value.Trim()) > 0)//!chkSelect.Checked && Convert.ToInt64(hdfConsultantId.Value.Trim()) > 0 && 
                    {
                        objActAlertDetails.IsDeleted = true;
                    }
                    else
                        objActAlertDetails.IsDeleted = false;
                    objActAlertDetails.ActAlertId = Convert.ToInt64(hdfActMailAlertId.Value.Trim());
                    objActAlertDetails.AlertTypeId = Cls_Constant.MailAlert;// Hard Coded For Email
                    if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                        objActAlertDetails.AlertValueBefore = 0;
                    else
                        objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                    objActAlertDetails.SnoozValue = 0;
                    objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();//hdfConsultantId.Value.Trim(); //strIds.ToString().TrimEnd(',');
                    lstActAlerts.Add(objActAlertDetails);
                }
                if (chkDashBoard.Checked)
                {
                    ActAlertDetails objActAlertDetails = new ActAlertDetails();
                    if (Convert.ToInt64(hdfActDashAlertId.Value.Trim()) > 0)
                    {
                        objActAlertDetails.IsDeleted = true;
                    }
                    else
                        objActAlertDetails.IsDeleted = false;
                    objActAlertDetails.ActAlertId = Convert.ToInt64(hdfActDashAlertId.Value.Trim());
                    objActAlertDetails.AlertTypeId = Cls_Constant.DashBoardAlert;// Hard Coded For Dashboard Alert
                    if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                        objActAlertDetails.AlertValueBefore = 0;
                    else
                        objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                    objActAlertDetails.SnoozValue = 0;
                    objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();//hdfConsultantId.Value.Trim(); //strIds.ToString().TrimEnd(',');
                    lstActAlerts.Add(objActAlertDetails);
                }
            }
            else
                objActivity.PriorityId = 2;//Hard Code For Moderate Convert.ToInt16(ddlPriority.SelectedValue.Trim());
            objActivity.LstAlertDetails = lstActAlerts;
            objActivity.LstReources = lstResources;
            objActivity.CreatedById = BasePage.UserSession.VirtualRoleId;
            objActivity.IsDeleted = false;
            Result = objActivityBM.UpdateActivity(objActivity);
        }
        else
        {
            Result = SaveOnlyActivity();
        }
        if (Result > 0)
        {
            if (!string.IsNullOrEmpty(hdfContactNotesId.Value.Trim()) && Convert.ToInt64(hdfContactNotesId.Value.Trim()) > 0)
                Result = objActivityBM.UpdateContactNotes(Convert.ToInt64(hdfContactNotesId.Value.Trim()), objActivity.ProspectId, "Changed to" + ddlActStatus.SelectedValue.Trim() + ":" + txtclrRemark.Text.Trim(), BasePage.UserSession.VirtualRoleId, false, Convert.ToInt32(ddlclrActStatus.SelectedValue.Trim()), Convert.ToInt64(hdfActivityId.Value.Trim()), Convert.ToInt32(ddlclrStatus.SelectedValue.Trim()));
            else
                Result = SaveOnlyNotes();
            lblSerSucMsg.Text = Resources.PFSalesResource.ActivityUpdated.Trim();
            dvaserSuccess.Visible = true;
            lblSerErrMsg.Text = string.Empty;
            dvsererror.Visible = false;
            hdfActivityDoc.Value = string.Empty;
            lnkbtnUpdate.Visible = false;
            lnkbtnSaveAct.Visible = true;
            lblAddActivity.Text = Resources.PFSalesResource.AddNewActivity.Trim();
        }
        else if (Result == -5)
        {
            lblSerErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
            dvsererror.Visible = true;
        }
        else
        {
            lblSerErrMsg.Text = Resources.PFSalesResource.ActivityNotUpdated.Trim();
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
            dvsererror.Visible = true;
        }
        BindMangeData();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 12 Aug 2013
    /// Description: Get Number Of Activities Added for Only Notes
    /// </summary>
    /// <param name="startTime"></param>
    /// <returns></returns>
    private void GetCountOfActForStime(DateTime startTime, double interval)
    {
        try
        {
            DateTime dt = startTime;
            Int64 ACount = objActivityBM.GetCountOfActForStime(BasePage.UserSession.VirtualRoleId, startTime);
            if (ACount >= 2)
            {
                GetCountOfActForStime(startTime.AddMinutes(interval), interval);
                dt = startTime.AddMinutes(interval);
            }
            else
                ViewState["NewStartDate"] = dt;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_ProspectDetails.GetCountOfActForStime.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 Aug 2013
    /// Description: Save Acttvity Only
    /// </summary>
    private Int64 SaveOnlyActivity()
    {
        StringBuilder strIds = new StringBuilder();
        objActivity.Id = 0;
        objActivity.ParrentActId = 0;
        objActivity.ActivityTypeId = Convert.ToInt16(ddlAddActType.SelectedValue.Trim());
        objActivity.Regarding = ddlAddActType.SelectedItem.Text.Trim() + " : to " + lblAddActProspect.Text.Trim();//txtRegarding.Text.Trim();
        objActivity.Regardings = ddlAddActType.SelectedItem.Text.Trim() + " : to " + lblAddActProspect.Text.Trim();//txtRegarding.Text.Trim();
        if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
            objActivity.ProspectId = Convert.ToInt64(hdfProspectId.Value.Trim());
        else
            objActivity.ProspectId = 0;
        if (!string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlActTime.SelectedValue.Trim() != "0")//!string.IsNullOrEmpty(txtActTime.Text.Trim())
        {
            objActivity.ActStartTime = Convert.ToDateTime(txtActDate.Text.Trim() + " " + ddlActTime.SelectedValue.Trim());//txtActTime.Text.Trim()
            GetCountOfActForStime(objActivity.ActStartTime, Interval1);
            DateTime dt;
            if (ViewState["NewStartDate"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["NewStartDate"]).Trim()))
                dt = objActivity.ActStartTime = Convert.ToDateTime(Convert.ToString(ViewState["NewStartDate"]).Trim());
            else
                dt = Convert.ToDateTime(txtActDate.Text.Trim() + " " + ddlActTime.SelectedValue.Trim());//txtActTime.Text.Trim()
            objActivity.ActEndTime = dt.AddMinutes(2);//Convert.ToDateTime(txtEndDate.Text.Trim() + " " + txtEndTime.Text.Trim());
        }
        objActivity.IsTimeLess = false;
        objActivity.IsPrivate = false;
        objActivity.Status = Convert.ToInt32(ddlActStatus.SelectedValue.Trim());
        objActivity.Duration = Convert.ToInt32(ddlDuration.SelectedValue.Trim());
        objActivity.ActivityDocId = 0;
        objActivity.ActivityDocRemark = txtRemark.Text.Trim();
        objActivity.ActivityDocFilePath = hdfActivityDoc.Value.Trim();
        objActivity.Location = txtLocation.Text.Trim();
        List<ActResources> lstResources = new List<ActResources>();
        List<ActAlertDetails> lstActAlerts = new List<ActAlertDetails>();
        ActResources objActResource = new ActResources();
        objActResource.ResourceId = BasePage.UserSession.VirtualRoleId;
        lstResources.Add(objActResource);
        if (ddlAlarm.SelectedValue.Trim() != "0")
        {
            objActivity.PriorityId = 1;//Hard Code For High Convert.ToInt16(ddlPriority.SelectedValue.Trim());
            if (chkSms.Checked)
            {
                string[] array = strIds.ToString().TrimEnd(',').Split(',');
                if (array.Length > 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        ActAlertDetails objActAlertDetails = new ActAlertDetails();
                        objActAlertDetails.AlertTypeId = Cls_Constant.SMSAlert;// Hard Coded For SMS
                        if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                            objActAlertDetails.AlertValueBefore = 0;
                        else
                            objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                        objActAlertDetails.SnoozValue = 0;
                        objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
                        lstActAlerts.Add(objActAlertDetails);
                    }
                }
            }
            if (chkEmail.Checked)
            {
                string[] array = strIds.ToString().TrimEnd(',').Split(',');
                if (array.Length > 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        ActAlertDetails objActAlertDetails = new ActAlertDetails();
                        objActAlertDetails.AlertTypeId = Cls_Constant.MailAlert;// Hard Coded For Email
                        if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                            objActAlertDetails.AlertValueBefore = 0;
                        else
                            objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                        objActAlertDetails.SnoozValue = 0;
                        objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// //array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
                        lstActAlerts.Add(objActAlertDetails);
                    }
                }
            }
            if (chkDashBoard.Checked)
            {
                string[] array = strIds.ToString().TrimEnd(',').Split(',');
                if (array.Length > 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        ActAlertDetails objActAlertDetails = new ActAlertDetails();
                        objActAlertDetails.AlertTypeId = Cls_Constant.DashBoardAlert;// Hard Coded For Dashboard Alert
                        if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                            objActAlertDetails.AlertValueBefore = 0;
                        else
                            objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                        objActAlertDetails.SnoozValue = 0;
                        objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();//array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
                        lstActAlerts.Add(objActAlertDetails);
                    }
                }
            }
        }
        else
            objActivity.PriorityId = 2;//Hard Code For Moderate Convert.ToInt16(ddlPriority.SelectedValue.Trim());
        objActivity.LstAlertDetails = lstActAlerts;
        objActivity.LstReources = lstResources;
        objActivity.CreatedById = BasePage.UserSession.VirtualRoleId;
        objActivity.IsDeleted = false;
        Int64 Result = 0;
        Result = objActivityBM.AddActivity(objActivity);
        if (Result > 0)
        {
            lblSerSucMsg.Text = Resources.PFSalesResource.ActivityAddedSuccessfully.Trim();
            dvaserSuccess.Visible = true;
            lblSerErrMsg.Text = string.Empty;
            dvsererror.Visible = false;
            hdfActivityDoc.Value = string.Empty;
        }
        else if (Result == -5)
        {
            lblSerErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
            dvsererror.Visible = true;
        }
        else
        {
            lblSerErrMsg.Text = Resources.PFSalesResource.ActivityNotAdded.Trim();
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
            dvsererror.Visible = true;
        }
        pnlGeneral.Visible = true;
        pnlDetails.Visible = false;
        lnkbtnGeneralInfo.CssClass = "tablerBtnActive";
        lnkbtnDetailsInfo.CssClass = "";
        BindMangeData();
        return Result;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 Aug 2013
    /// Description: Save Notes Only
    /// </summary>
    private Int64 SaveOnlyNotes()
    {
        if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
            objActivity.ProspectId = Convert.ToInt64(hdfProspectId.Value.Trim());
        Int64 Result = objActivityBM.AddContactNotes(objActivity.ProspectId, "Changed to " + ddlclrActStatus.SelectedItem.Text.Trim() + " :" + txtclrRemark.Text.Trim(), BasePage.UserSession.VirtualRoleId, false, Convert.ToInt32(ddlclrActStatus.SelectedValue.Trim()), 0, Convert.ToInt32(ddlclrStatus.SelectedValue.Trim()));
        if (Result > 0)
        {
            lblSerSucMsg.Text = Resources.PFSalesResource.NotesAdded.Trim();
            dvaserSuccess.Visible = true;
            lblSerErrMsg.Text = string.Empty;
            dvsererror.Visible = false;
            hdfActivityDoc.Value = string.Empty;
        }
        else
        {
            lblSerErrMsg.Text = Resources.PFSalesResource.NotesNotAdded.Trim();
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
            dvsererror.Visible = true;
        }
        BindMangeData();
        return Result;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 12 Aug 2013
    /// Description: Update only Acttvity
    /// </summary>
    private void UpdateOnlyActivity()
    {
        if (!string.IsNullOrEmpty(hdfActivityId.Value.Trim()) && !string.IsNullOrEmpty(hdfActivityDocId.Value.Trim()))
        {
            StringBuilder strIds = new StringBuilder();
            objActivity.Id = Convert.ToInt64(hdfActivityId.Value.Trim());
            objActivity.ParrentActId = 0;
            objActivity.ActivityTypeId = Convert.ToInt16(ddlAddActType.SelectedValue.Trim());
            objActivity.Regarding = ddlAddActType.SelectedItem.Text.Trim() + " : to " + lblAddActProspect.Text.Trim();//txtRegarding.Text.Trim();

            if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
                objActivity.ProspectId = Convert.ToInt64(hdfProspectId.Value.Trim());
            else
                objActivity.ProspectId = 0;
            if (!string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlActTime.SelectedValue.Trim() != "0") //!string.IsNullOrEmpty(txtActTime.Text.Trim())
            {
                objActivity.ActStartTime = Convert.ToDateTime(txtActDate.Text.Trim() + " " + ddlActTime.SelectedValue.Trim());//txtActTime.Text.Trim()
                GetCountOfActForStime(objActivity.ActStartTime, Interval1);
                DateTime dt;
                if (ViewState["NewStartDate"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["NewStartDate"]).Trim()))
                    dt = objActivity.ActStartTime = Convert.ToDateTime(Convert.ToString(ViewState["NewStartDate"]).Trim());
                else
                    dt = Convert.ToDateTime(txtActDate.Text.Trim() + " " + ddlActTime.SelectedValue.Trim());//txtActTime.Text.Trim()
                objActivity.ActEndTime = dt.AddMinutes(2);
            }
            objActivity.IsTimeLess = false;
            objActivity.IsPrivate = false;
            objActivity.Status = Convert.ToInt32(ddlActStatus.SelectedValue.Trim());
            objActivity.Duration = Convert.ToInt32(ddlDuration.SelectedValue.Trim());
            objActivity.ActivityDocId = Convert.ToInt64(hdfActivityDocId.Value.Trim());
            objActivity.ActivityDocRemark = txtRemark.Text.Trim();
            objActivity.ActivityDocFilePath = hdfActivityDoc.Value.Trim();
            objActivity.Location = txtLocation.Text.Trim();
            List<ActResources> lstResources = new List<ActResources>();
            List<ActAlertDetails> lstActAlerts = new List<ActAlertDetails>();
            ActResources objActResource = new ActResources();
            objActResource.ResourceId = BasePage.UserSession.VirtualRoleId;//Convert.ToInt64(hdfConsultantId.Value.Trim());
            objActResource.ActResourceId = Convert.ToInt64(hdfActResId.Value.Trim());
            objActResource.IsDeleted = false;
            if (Convert.ToInt64(hdfActResId.Value.Trim()) > 0)//!chkSelect.Checked && Convert.ToInt64(hdfConsultantId.Value.Trim()) > 0 && (
            {
                objActResource.IsDeleted = true;
            }
            lstResources.Add(objActResource);

            if (ddlAlarm.SelectedValue.Trim() != "0")
            {
                objActivity.PriorityId = 1;//Hard Code For High Priority Convert.ToInt16(ddlPriority.SelectedValue.Trim());
                if (chkSms.Checked)
                {
                    ActAlertDetails objActAlertDetails = new ActAlertDetails();
                    if (Convert.ToInt64(hdfActSMSAlertId.Value.Trim()) > 0)
                    {
                        objActAlertDetails.IsDeleted = true;
                    }
                    else
                        objActAlertDetails.IsDeleted = false;
                    objActAlertDetails.ActAlertId = Convert.ToInt64(hdfActSMSAlertId.Value.Trim());
                    objActAlertDetails.AlertTypeId = Cls_Constant.SMSAlert;// Hard Coded For SMS
                    if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                        objActAlertDetails.AlertValueBefore = 0;
                    else
                        objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                    objActAlertDetails.SnoozValue = 0;
                    objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// hdfConsultantId.Value.Trim(); //strIds.ToString().TrimEnd(',');
                    lstActAlerts.Add(objActAlertDetails);
                }
                if (chkEmail.Checked)
                {
                    ActAlertDetails objActAlertDetails = new ActAlertDetails();
                    if (Convert.ToInt64(hdfActMailAlertId.Value.Trim()) > 0)//!chkSelect.Checked && Convert.ToInt64(hdfConsultantId.Value.Trim()) > 0 && 
                    {
                        objActAlertDetails.IsDeleted = true;
                    }
                    else
                        objActAlertDetails.IsDeleted = false;
                    objActAlertDetails.ActAlertId = Convert.ToInt64(hdfActMailAlertId.Value.Trim());
                    objActAlertDetails.AlertTypeId = Cls_Constant.MailAlert;// Hard Coded For Email
                    if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                        objActAlertDetails.AlertValueBefore = 0;
                    else
                        objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                    objActAlertDetails.SnoozValue = 0;
                    objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();//hdfConsultantId.Value.Trim(); //strIds.ToString().TrimEnd(',');
                    lstActAlerts.Add(objActAlertDetails);
                }
                if (chkDashBoard.Checked)
                {
                    ActAlertDetails objActAlertDetails = new ActAlertDetails();
                    if (Convert.ToInt64(hdfActDashAlertId.Value.Trim()) > 0)
                    {
                        objActAlertDetails.IsDeleted = true;
                    }
                    else
                        objActAlertDetails.IsDeleted = false;
                    objActAlertDetails.ActAlertId = Convert.ToInt64(hdfActDashAlertId.Value.Trim());
                    objActAlertDetails.AlertTypeId = Cls_Constant.DashBoardAlert;// Hard Coded For Dashboard Alert
                    if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                        objActAlertDetails.AlertValueBefore = 0;
                    else
                        objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                    objActAlertDetails.SnoozValue = 0;
                    objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();//hdfConsultantId.Value.Trim(); //strIds.ToString().TrimEnd(',');
                    lstActAlerts.Add(objActAlertDetails);
                }
            }
            else
                objActivity.PriorityId = 2;//Hard Code For Moderate Convert.ToInt16(ddlPriority.SelectedValue.Trim());
            objActivity.LstAlertDetails = lstActAlerts;
            objActivity.LstReources = lstResources;
            objActivity.CreatedById = BasePage.UserSession.VirtualRoleId;
            objActivity.IsDeleted = false;
            Int64 Result = 0;
            Result = objActivityBM.UpdateActivity(objActivity);
            if (Result > 0)
            {
                lblSerSucMsg.Text = Resources.PFSalesResource.ActivityUpdated.Trim();
                dvaserSuccess.Visible = true;
                lblSerErrMsg.Text = string.Empty;
                dvsererror.Visible = false;
                hdfActivityDoc.Value = string.Empty;
                lnkbtnUpdate.Visible = false;
                lnkbtnSaveAct.Visible = true;
                lblAddActivity.Text = Resources.PFSalesResource.AddNewActivity.Trim();
            }
            else if (Result == -5)
            {
                lblSerErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                dvaserSuccess.Visible = false;
                lblSerSucMsg.Text = string.Empty;
                dvsererror.Visible = true;
            }
            else
            {
                lblSerErrMsg.Text = Resources.PFSalesResource.ActivityNotUpdated.Trim();
                dvaserSuccess.Visible = false;
                lblSerSucMsg.Text = string.Empty;
                dvsererror.Visible = true;
            }
        }
        BindMangeData();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 12 Aug 2013
    /// Description: Update Only Notes
    /// </summary>
    private void UpdateOnlyNotes()
    {
        if (!string.IsNullOrEmpty(hdfActivityId.Value.Trim()) && !string.IsNullOrEmpty(hdfActivityDocId.Value.Trim()))
        {
            if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
                objActivity.ProspectId = Convert.ToInt64(hdfProspectId.Value.Trim());
            Int64 Result = objActivityBM.UpdateContactNotes(Convert.ToInt64(hdfContactNotesId.Value.Trim()), objActivity.ProspectId, "Changed to" + ddlActStatus.SelectedValue.Trim() + ":" + txtclrRemark.Text.Trim(), BasePage.UserSession.VirtualRoleId, false, Convert.ToInt32(ddlclrActStatus.SelectedValue.Trim()), Convert.ToInt64(hdfActivityId.Value.Trim()), Convert.ToInt32(ddlclrStatus.SelectedValue.Trim()));
            if (Result > 0)
            {
                lblSerSucMsg.Text = Resources.PFSalesResource.NotesUpdated.Trim();
                dvaserSuccess.Visible = true;
                lblSerErrMsg.Text = string.Empty;
                dvsererror.Visible = false;
                hdfActivityDoc.Value = string.Empty;
                lnkbtnUpdate.Visible = false;
                lnkbtnSaveAct.Visible = true;
                lblAddActivity.Text = Resources.PFSalesResource.AddNewActivity.Trim();
            }
            else if (Result == -5)
            {
                lblSerErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                dvaserSuccess.Visible = false;
                lblSerSucMsg.Text = string.Empty;
                dvsererror.Visible = true;
            }
            else
            {
                lblSerErrMsg.Text = Resources.PFSalesResource.NotesNotUpdated.Trim();
                dvaserSuccess.Visible = false;
                lblSerSucMsg.Text = string.Empty;
                dvsererror.Visible = true;
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
                objActivity.ProspectId = Convert.ToInt64(hdfProspectId.Value.Trim());
            Int64 Result = objActivityBM.UpdateContactNotes(Convert.ToInt64(hdfContactNotesId.Value.Trim()), objActivity.ProspectId, "Activity Status Changed:-" + txtclrRemark.Text.Trim(), BasePage.UserSession.VirtualRoleId, false, Convert.ToInt32(ddlclrActStatus.SelectedValue.Trim()), 0, Convert.ToInt32(ddlclrStatus.SelectedValue.Trim()));
            if (Result > 0)
            {
                lblSerSucMsg.Text = Resources.PFSalesResource.NotesUpdated.Trim();
                dvaserSuccess.Visible = true;
                lblSerErrMsg.Text = string.Empty;
                dvsererror.Visible = false;
                hdfActivityDoc.Value = string.Empty;
                lnkbtnUpdate.Visible = false;
                lnkbtnSaveAct.Visible = true;
                lblAddActivity.Text = Resources.PFSalesResource.AddNewActivity.Trim();
            }
            else if (Result == -5)
            {
                lblSerErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                dvaserSuccess.Visible = false;
                lblSerSucMsg.Text = string.Empty;
                dvsererror.Visible = true;
            }
            else
            {
                lblSerErrMsg.Text = Resources.PFSalesResource.NotesNotUpdated.Trim();
                dvaserSuccess.Visible = false;
                lblSerSucMsg.Text = string.Empty;
                dvsererror.Visible = true;
            }
        }
        BindMangeData();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 Aug 2013
    /// Description: Save Acttvity & Notes
    /// </summary>
    private void SaveActiNotes()
    {
        StringBuilder strIds = new StringBuilder();
        objActivity.Id = 0;
        objActivity.ParrentActId = 0;
        objActivity.ActivityTypeId = Convert.ToInt16(ddlAddActType.SelectedValue.Trim());
        objActivity.Regarding = ddlAddActType.SelectedItem.Text.Trim() + " : to " + lblAddActProspect.Text.Trim();//txtRegarding.Text.Trim();
        objActivity.Regardings = ddlAddActType.SelectedItem.Text.Trim() + " : to " + lblAddActProspect.Text.Trim();//txtRegarding.Text.Trim();
        if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
            objActivity.ProspectId = Convert.ToInt64(hdfProspectId.Value.Trim());
        else
            objActivity.ProspectId = 0;
        if (!string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlActTime.SelectedValue.Trim() != "0")//!string.IsNullOrEmpty(txtActTime.Text.Trim())
        {
            objActivity.ActStartTime = Convert.ToDateTime(txtActDate.Text.Trim() + " " + ddlActTime.SelectedValue.Trim());//txtActTime.Text.Trim()
            GetCountOfActForStime(objActivity.ActStartTime, Interval1);
            DateTime dt;
            if (ViewState["NewStartDate"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["NewStartDate"]).Trim()))
                dt = objActivity.ActStartTime = Convert.ToDateTime(Convert.ToString(ViewState["NewStartDate"]).Trim());
            else
                dt = Convert.ToDateTime(txtActDate.Text.Trim() + " " + ddlActTime.SelectedValue.Trim());//txtActTime.Text.Trim()
            objActivity.ActEndTime = dt.AddMinutes(2);//Convert.ToDateTime(txtEndDate.Text.Trim() + " " + txtEndTime.Text.Trim());
        }
        objActivity.IsTimeLess = false;
        objActivity.IsPrivate = false;
        objActivity.Status = Convert.ToInt32(ddlActStatus.SelectedValue.Trim());
        objActivity.Duration = Convert.ToInt32(ddlDuration.SelectedValue.Trim());
        objActivity.ActivityDocId = 0;
        objActivity.ActivityDocRemark = txtRemark.Text.Trim();
        objActivity.ActivityDocFilePath = hdfActivityDoc.Value.Trim();
        objActivity.Location = txtLocation.Text.Trim();
        List<ActResources> lstResources = new List<ActResources>();
        List<ActAlertDetails> lstActAlerts = new List<ActAlertDetails>();
        ActResources objActResource = new ActResources();
        objActResource.ResourceId = BasePage.UserSession.VirtualRoleId;
        lstResources.Add(objActResource);
        if (ddlPriority.SelectedValue.Trim() == "0")
        {
            objActivity.PriorityId = 1;//Hard Code For High Convert.ToInt16(ddlPriority.SelectedValue.Trim());
            if (chkSms.Checked)
            {
                string[] array = strIds.ToString().TrimEnd(',').Split(',');
                if (array.Length > 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        ActAlertDetails objActAlertDetails = new ActAlertDetails();
                        objActAlertDetails.AlertTypeId = Cls_Constant.SMSAlert;// Hard Coded For SMS
                        if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                            objActAlertDetails.AlertValueBefore = 0;
                        else
                            objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                        objActAlertDetails.SnoozValue = 0;
                        objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
                        lstActAlerts.Add(objActAlertDetails);
                    }
                }
            }
            if (chkEmail.Checked)
            {
                string[] array = strIds.ToString().TrimEnd(',').Split(',');
                if (array.Length > 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        ActAlertDetails objActAlertDetails = new ActAlertDetails();
                        objActAlertDetails.AlertTypeId = Cls_Constant.MailAlert;// Hard Coded For Email
                        if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                            objActAlertDetails.AlertValueBefore = 0;
                        else
                            objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                        objActAlertDetails.SnoozValue = 0;
                        objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// //array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
                        lstActAlerts.Add(objActAlertDetails);
                    }
                }
            }
            if (chkDashBoard.Checked)
            {
                string[] array = strIds.ToString().TrimEnd(',').Split(',');
                if (array.Length > 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        ActAlertDetails objActAlertDetails = new ActAlertDetails();
                        objActAlertDetails.AlertTypeId = Cls_Constant.DashBoardAlert;// Hard Coded For Dashboard Alert
                        if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                            objActAlertDetails.AlertValueBefore = 0;
                        else
                            objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                        objActAlertDetails.SnoozValue = 0;
                        objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();//array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
                        lstActAlerts.Add(objActAlertDetails);
                    }
                }
            }
        }
        else
            objActivity.PriorityId = 2;//Hard Code For Modrate Convert.ToInt16(ddlPriority.SelectedValue.Trim());
        objActivity.LstAlertDetails = lstActAlerts;
        objActivity.LstReources = lstResources;
        objActivity.CreatedById = BasePage.UserSession.VirtualRoleId;
        objActivity.IsDeleted = false;
        Int64 Result = 0;
        Result = objActivityBM.AddActivity(objActivity);
        if (Result > 0)
        {
            Result = objActivityBM.AddContactNotes(objActivity.ProspectId, "Changed to " + ddlclrActStatus.SelectedItem.Text.Trim() + " :" + txtclrRemark.Text.Trim(), BasePage.UserSession.VirtualRoleId, false, Convert.ToInt32(ddlclrActStatus.SelectedValue.Trim()), Result, Convert.ToInt32(ddlclrStatus.SelectedValue.Trim()));
            if (Result > 0)
            {
                lblSerSucMsg.Text = Resources.PFSalesResource.ActivityAddedSuccessfully.Trim();
                dvaserSuccess.Visible = true;
                lblSerErrMsg.Text = string.Empty;
                dvsererror.Visible = false;
                hdfActivityDoc.Value = string.Empty;
            }
            else
            {
                lblSerErrMsg.Text = Resources.PFSalesResource.NotesNotAdded.Trim();
                dvaserSuccess.Visible = false;
                lblSerSucMsg.Text = string.Empty;
                dvsererror.Visible = true;
            }
        }
        else if (Result == -5)
        {
            lblSerErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
            dvsererror.Visible = true;
        }
        else
        {
            lblSerErrMsg.Text = Resources.PFSalesResource.ActivityNotAdded.Trim();
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
            dvsererror.Visible = true;
        }
        pnlGeneral.Visible = true;
        pnlDetails.Visible = false;
        lnkbtnGeneralInfo.CssClass = "tablerBtnActive";
        lnkbtnDetailsInfo.CssClass = "";
        BindMangeData();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 Oct 2013
    /// Description: Send Email To FC Consultant When Status Becomes Tender OR NTU
    /// </summary>
    /// <param name="emilToId"></param>
    /// <param name="noOfLeads"></param>
    /// <param name="Name"></param>
    /// <returns></returns>
    private Boolean SendMail(string emilToId, string Status, string Name, string Lead)
    {
        string FileContent = string.Empty;
        try
        {
            Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
            objEmailHelper.EmailSubject = "PF Status Changed";
            objEmailHelper.EmailToID = emilToId;
            FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + Name.Trim() + "<br /><br />Please be advised that,PF Status for the lead " + Lead.Trim() + ", which is assigned to you has been made to" + Status.Trim() + ".<br /><br /> Thanks you<br /> PFSales Team</span>";
            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "EMail sent successfully", "PF Status Changed", "Add-Edit Activity User Control");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "PF Status Changed", "Add-Edit Activity User Control");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.SendMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "PF Status Changed", "Add-Edit Activity User Control");
            return false;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 Aug 2013
    /// Description: Save Acttvity for next working day
    /// </summary>
    private Int64 SetCallTomorrow(DateTime dtNewDay)
    {
        StringBuilder strIds = new StringBuilder();
        objActivity.Id = 0;
        objActivity.ParrentActId = 0;
        objActivity.ActivityTypeId = Convert.ToInt16(ddlAddActType.SelectedValue.Trim());
        objActivity.Regarding = ddlAddActType.SelectedItem.Text.Trim() + " : to " + lblAddActProspect.Text.Trim();//txtRegarding.Text.Trim();
        objActivity.Regardings = ddlAddActType.SelectedItem.Text.Trim() + " : to " + lblAddActProspect.Text.Trim();//txtRegarding.Text.Trim();
        objActivity.PriorityId = Convert.ToInt16(ddlPriority.SelectedValue.Trim());
        if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
            objActivity.ProspectId = Convert.ToInt64(hdfProspectId.Value.Trim());
        else
            objActivity.ProspectId = 0;
        objActivity.ActStartTime = Convert.ToDateTime(dtNewDay.ToShortDateString() + " " + "09:00");//txtActTime.Text.Trim()
        GetCountOfActForStime(objActivity.ActStartTime, Interval1);
        DateTime dt;
        if (ViewState["NewStartDate"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["NewStartDate"]).Trim()))
            dt = objActivity.ActStartTime = Convert.ToDateTime(Convert.ToString(ViewState["NewStartDate"]).Trim());
        else
            dt = Convert.ToDateTime(dtNewDay.ToShortDateString() + " " + "09:00");//txtActTime.Text.Trim()
        objActivity.ActEndTime = dt.AddMinutes(2);//Convert.ToDateTime(txtEndDate.Text.Trim() + " " + txtEndTime.Text.Trim());
        //}
        objActivity.IsTimeLess = false;
        objActivity.IsPrivate = false;
        objActivity.Status = Convert.ToInt32(ddlActStatus.SelectedValue.Trim());
        objActivity.Duration = Convert.ToInt32(ddlDuration.SelectedValue.Trim());
        objActivity.ActivityDocId = 0;
        objActivity.ActivityDocRemark = txtRemark.Text.Trim();
        objActivity.ActivityDocFilePath = hdfActivityDoc.Value.Trim();
        objActivity.Location = txtLocation.Text.Trim();
        List<ActResources> lstResources = new List<ActResources>();
        List<ActAlertDetails> lstActAlerts = new List<ActAlertDetails>();
        ActResources objActResource = new ActResources();
        objActResource.ResourceId = BasePage.UserSession.VirtualRoleId;
        lstResources.Add(objActResource);
        ddlAlarm.SelectedValue = "0";
        if (chkSms.Checked)
        {
            string[] array = strIds.ToString().TrimEnd(',').Split(',');
            if (array.Length > 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    ActAlertDetails objActAlertDetails = new ActAlertDetails();
                    objActAlertDetails.AlertTypeId = Cls_Constant.SMSAlert;// Hard Coded For SMS
                    if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                        objActAlertDetails.AlertValueBefore = 0;
                    else
                        objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                    objActAlertDetails.SnoozValue = 0;
                    objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
                    lstActAlerts.Add(objActAlertDetails);
                }
            }
        }
        if (chkEmail.Checked)
        {
            string[] array = strIds.ToString().TrimEnd(',').Split(',');
            if (array.Length > 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    ActAlertDetails objActAlertDetails = new ActAlertDetails();
                    objActAlertDetails.AlertTypeId = Cls_Constant.MailAlert;// Hard Coded For Email
                    if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                        objActAlertDetails.AlertValueBefore = 0;
                    else
                        objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                    objActAlertDetails.SnoozValue = 0;
                    objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// //array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
                    lstActAlerts.Add(objActAlertDetails);
                }
            }
        }
        if (chkDashBoard.Checked)
        {
            string[] array = strIds.ToString().TrimEnd(',').Split(',');
            if (array.Length > 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    ActAlertDetails objActAlertDetails = new ActAlertDetails();
                    objActAlertDetails.AlertTypeId = Cls_Constant.DashBoardAlert;// Hard Coded For Dashboard Alert
                    if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                        objActAlertDetails.AlertValueBefore = 0;
                    else
                        objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                    objActAlertDetails.SnoozValue = 0;
                    objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();//array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
                    lstActAlerts.Add(objActAlertDetails);
                }
            }
        }
        objActivity.LstAlertDetails = lstActAlerts;
        objActivity.LstReources = lstResources;
        objActivity.CreatedById = BasePage.UserSession.VirtualRoleId;
        objActivity.IsDeleted = false;
        Int64 Result = 0;
        Result = objActivityBM.AddActivity(objActivity);
        if (Result > 0)
        {
            lblSerSucMsg.Text = Resources.PFSalesResource.ActivityAddedSuccessfully.Trim();
            dvaserSuccess.Visible = true;
            lblSerErrMsg.Text = string.Empty;
            dvsererror.Visible = false;
            hdfActivityDoc.Value = string.Empty;
        }
        else if (Result == -5)
        {
            lblSerErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
            dvsererror.Visible = true;
        }
        else
        {
            lblSerErrMsg.Text = Resources.PFSalesResource.ActivityNotAdded.Trim();
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
            dvsererror.Visible = true;
        }
        pnlGeneral.Visible = true;
        pnlDetails.Visible = false;
        lnkbtnGeneralInfo.CssClass = "tablerBtnActive";
        lnkbtnDetailsInfo.CssClass = "";
        BindMangeData();
        return Result;
    }
    #endregion
}
