using System;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using Mechsoft.GeneralUtilities;
using Mechsoft.PFSales.BusinessEntity;
using Mechsoft.PFSales.BusinessManager;

public partial class ViewMyContacts : BasePage
{
    #region Global Variables
    Prospect objProsp = new Prospect();
    ProspectBM objProspBM = new ProspectBM();
    MasterBM objMstBM = new MasterBM();
    EmployeeBM objEmpBM = new EmployeeBM();
    Activity objActivity = new Activity();
    ActivityBM objActivityBM = new ActivityBM();
    ClearActivity objclrActivity = new ClearActivity();
    ILog Logger = LogManager.GetLogger(typeof(ViewMyContacts));
    bool IsLastRec = false;
    int cnt = 0;
    Thread t3 = null;
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = "CreatedDate";
            //ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "Name";
            //ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION2] = "start";
            //ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION2] = ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;
            BindAllStatuses();
            BindAllMakes();
            BindAllStates();
            BindConsultants();
            ViewState["Contacts"] = "Current";
            if (BasePage.UserSession != null && BasePage.UserSession.VirtualRoleId != 0)
            {
                if (BasePage.UserSession.RoleId == 3)
                {
                    ddlserConsultant.SelectedValue = "PF-" + BasePage.UserSession.VirtualRoleId.ToString();
                }
                else if (BasePage.UserSession.RoleId == 5)
                {
                    ddlserConsultant.SelectedValue = "FC-" + BasePage.UserSession.VirtualRoleId.ToString();
                }
            }
            lblSerConsultant.Visible = ddlserConsultant.Visible = false;
            lblserCity.Visible = ddlserCity.Visible = true;
            //}

            /******************************** Restore Search Filter ********************************/

            if (Session["BackFromManageActivity"] != null && Convert.ToString(Session["BackFromManageActivity"]).Trim().ToUpper() == "TRUE" && Session["Contact"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Contact"]).Trim()))
            {
                if (Session["Name"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Name"]).Trim()))
                {
                    txtserprospName.Text = Convert.ToString(Session["Name"]).Trim();
                }
                if (Session["CarMake"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["CarMake"]).Trim()))
                {
                    //ddlCarMake.SelectedValue = Convert.ToString(Session["CarMake"]).Trim();
                    ListItem selectedCarMake = ddlCarMake.Items.FindByValue(Convert.ToString(Session["CarMake"]).Trim());
                    if (selectedCarMake != null)
                        selectedCarMake.Selected = true;
                }
                if (Session["FromDate"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["FromDate"]).Trim()))
                {
                    txtTotEntFrmDate.Text = Convert.ToString(Session["FromDate"]).Trim();
                }
                if (Session["Consultant"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Consultant"]).Trim()))
                {
                    //ddlserConsultant.SelectedValue = Convert.ToString(Session["Consultant"]).Trim();
                    ListItem selectedConsultant = ddlserConsultant.Items.FindByValue(Convert.ToString(Session["Consultant"]).Trim());
                    if (selectedConsultant != null)
                        selectedConsultant.Selected = true;
                }
                if (Session["ToDate"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["ToDate"]).Trim()))
                {
                    txtTotEntToDate.Text = Convert.ToString(Session["ToDate"]).Trim();
                }
                if (Session["State"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["State"]).Trim()))
                {
                    ListItem selectedState = ddlserState.Items.FindByValue(Convert.ToString(Session["State"]).Trim());
                    if (selectedState != null)
                        selectedState.Selected = true;
                    //ddlserState.SelectedValue = Convert.ToString(Session["State"]).Trim();
                }
                if (Session["City"] != null && !string.IsNullOrEmpty(Session["City"].ToString().Trim()))
                {
                    ListItem selectedCity = ddlserCity.Items.FindByValue(Convert.ToString(Session["City"]).Trim());
                    if (selectedCity != null)
                        selectedCity.Selected = true;
                    //ddlserCity.SelectedValue = Convert.ToString(Session["City"]).Trim();
                }
                if (Session["Status"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Status"]).Trim()))
                {
                    ListItem selectedStatus = ddlStatus.Items.FindByValue(Convert.ToString(Session["Status"]).Trim());
                    if (selectedStatus != null)
                        selectedStatus.Selected = true;
                    //ddlStatus.SelectedValue = Convert.ToString(Session["Status"]).Trim();
                }
                if (Session["Email"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Email"]).Trim()))
                {
                    txtEmail1.Text = Convert.ToString(Session["Email"]).Trim();
                }
                if (Session["PhNo"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["PhNo"]).Trim()))
                {
                    txtSerPhNo.Text = Convert.ToString(Session["PhNo"]).Trim();
                }
                if (Session["PCode"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["PCode"]).Trim()))
                {
                    txtPCode.Text = Convert.ToString(Session["PCode"]).Trim();
                }
                if (Session["PageIndex"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["PageIndex"]).Trim()))
                {
                    pagerParent.CurrentIndex = Convert.ToInt32(Session["PageIndex"]);
                }
                else
                    pagerParent.CurrentIndex = 1;
                if (Session["PageSize"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["PageSize"]).Trim()))
                {
                    ddlPageSize.SelectedValue = Convert.ToString(Session["PageSize"]).Trim();
                }
                if (Session["SortExpression"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["SortExpression"]).Trim()))
                {
                    ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = Convert.ToString(Session["SortExpression"]).Trim();
                }
                if (Session["SortDirection"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["SortDirection"]).Trim()))
                {
                    ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Convert.ToString(Session["SortDirection"]).Trim();
                }
                ViewState["Contacts"] = Convert.ToString(Session["Contact"]).Trim();
                Session["BackFromManageActivity"] = "false";
            }
            else
                pagerParent.CurrentIndex = 1;
            /******************************************* END *******************************************/
            BindDefaultGrid();
            lnkbtnAddNewContact.Focus();
            Page.MaintainScrollPositionOnPostBack = true;
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
        }

    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Gridview Page Index Changing Event. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvprosp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvprosp.PageIndex = e.NewPageIndex;
            if (Session["FromNotification"] == null || Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == false)
            {
                BindGrid();
            }
            else if (Session["FromNotification"] != null && Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == true)
            {
                txtMemNo.Text = Session["FromDashMemNo"].ToString().Trim();
                BindGridFromDash();
            }
            ClearMessage();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ViewMyContacts.gvprosp_PageIndexChanging Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Gridview Page Sorting Event Of GridView. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvprosp_Soring(object sender, GridViewSortEventArgs e)
    {
        try
        {
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = e.SortExpression;
            DefineSortDirection();
            if (Session["FromNotification"] == null || Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == false)
            {

                BindGrid();
            }
            else if (Session["FromNotification"] != null && Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == true)
            {
                txtMemNo.Text = Session["FromDashMemNo"].ToString().Trim();
                BindGridFromDash();
            }
            ClearMessage();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ViewMyContacts.gvprosp_Soring.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Search Button Click. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSearch_Click(object sender, EventArgs e)
    {
        gvprosp.PageIndex = 0;
        pagerParent.CurrentIndex = 1;
        ViewState["Contacts"] = "AllContacts";
        if (Session["FromNotification"] == null || Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == false)
        {
            BindGrid();
        }
        else if (Session["FromNotification"] != null && Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == true)
        {
            txtMemNo.Text = Session["FromDashMemNo"].ToString().Trim();
            BindGridFromDash();
        }
        ClearMessage();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Clear Button Click. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnClear_Click(object sender, EventArgs e)
    {
        //gvprosp.PageIndex = 0;
        //pagerParent.CurrentIndex = 1;
        ViewState["Contacts"] = string.Empty;
        if (Session["FromDashMemNo"] != null && !string.IsNullOrEmpty(Session["FromDashMemNo"].ToString().Trim()) && Session["FromDashProspectId"] != null && !string.IsNullOrEmpty(Session["FromDashProspectId"].ToString().Trim()))
        {
            Session["FromDashMemNo"] = string.Empty;
        }
        else if (Session["FromDashMemNo"] != null && (string.IsNullOrEmpty(Session["FromDashProspectId"].ToString().Trim()) || Session["FromDashProspectId"] == null))
        {
            Session["FromDashMemNo"] = string.Empty;
            Session["FromNotification"] = null;
        }
        txtPCode.Text = txtSerPhNo.Text = txtEmail1.Text = txtserprospName.Text = txtMemNo.Text = string.Empty;
        ddlserState.SelectedValue = ddlserCity.SelectedValue = ddlCarMake.SelectedValue = ddlStatus.SelectedValue = "0";
        txtserprospName.Focus();
        if (Session["FromNotification"] == null || Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == false)
        {
            BindGrid();
        }
        else if (Session["FromNotification"] != null && Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == true)
        {
            BindGridFromDash();
        }
        //txtTotEntFrmDate.Text = DateTime.Now.AddDays(-15).ToString();
        //txtTotEntToDate.Text = DateTime.Now.ToString();
        txtTotEntFrmDate.Text = txtTotEntToDate.Text = string.Empty; ClearMessage();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 Sept 2013
    /// Description: Clear Button Click. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAdClear_Click(object sender, EventArgs e)
    {
        ViewState["Contacts"] = string.Empty;
        if (Session["FromDashMemNo"] != null && !string.IsNullOrEmpty(Session["FromDashMemNo"].ToString().Trim()) && Session["FromDashProspectId"] != null && !string.IsNullOrEmpty(Session["FromDashProspectId"].ToString().Trim()))
        {
            Session["FromDashMemNo"] = string.Empty;
        }
        else if (Session["FromDashMemNo"] != null && (string.IsNullOrEmpty(Session["FromDashProspectId"].ToString().Trim()) || Session["FromDashProspectId"] == null))
        {
            Session["FromDashMemNo"] = string.Empty;
            Session["FromNotification"] = null;
        }
        //txtAdPCode.Text = txtAdSerPhNo.Text = txtAdEmail1.Text = txtAdserprospName.Text = txtAdMemNo.Text = string.Empty;
        //ddlAdserConsultant.SelectedValue = ddlAdserState.SelectedValue = ddlAdserCity.SelectedValue = ddlAdCarMake.SelectedValue = ddlAdStatus.SelectedValue = "0";
        //txtAdserprospName.Focus();
        if (Session["FromNotification"] == null || Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == false)
        {
            BindGrid();
        }
        else if (Session["FromNotification"] != null && Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == true)
        {
            BindGridFromDash();
        }
        //txtTotEntFrmDate.Text = DateTime.Now.AddDays(-15).ToString();
        //txtTotEntToDate.Text = DateTime.Now.ToString();
        //txtAdTotEntFrmDate.Text = txtAdTotEntToDate.Text = string.Empty; 
        ClearMessage();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Selected Index Changed Event Of Page Size's Drop Down List
    /// </summary>
    /// <param name="Sender"></param>
    /// <param name="e"></param>
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvprosp.PageIndex = 0;
            pagerParent.CurrentIndex = 1;
            if (Convert.ToInt16(ddlPageSize.SelectedValue.Trim()) == 1)
            {
                Int32 intAllCount = Convert.ToInt32(ViewState["TotalRowCount"]);
                gvprosp.PageSize = intAllCount;
            }
            else
            {
                gvprosp.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue.Trim());
            }
            if (Session["FromNotification"] == null || Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == false)
            {
                BindGrid();
            }
            else if (Session["FromNotification"] != null && Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == true)
            {
                txtMemNo.Text = Session["FromDashMemNo"].ToString().Trim();
                BindGridFromDash();
            }
            ClearMessage();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ViewMyContacts.ddlPageSize_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Selected Index Changed Event Of Prospect Status's Drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["Contacts"] = string.Empty;
        if (Session["FromNotification"] == null || Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == false)
        {
            BindGrid();
        }
        else if (Session["FromNotification"] != null && Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == true)
        {
            txtMemNo.Text = Session["FromDashMemNo"].ToString().Trim();
            BindGridFromDash();
        }
        ClearMessage();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Selected Index Changed Event Of Car Make's Drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlCarMake_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["Contacts"] = string.Empty;
        if (Session["FromNotification"] == null || Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == false)
        {
            BindGrid();
        }
        else if (Session["FromNotification"] != null && Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == true)
        {
            txtMemNo.Text = Session["FromDashMemNo"].ToString().Trim();
            BindGridFromDash();
        }
        ClearMessage();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 2 July 2013
    /// Description: Button Click Event Of Close Manage Activity Pop Up. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvActivity_Soring(object sender, GridViewSortEventArgs e)
    {
        ClearMessage();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 2 July 2013
    /// Description: Button Click Event Of Close Manage Activity Pop Up. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnManageAct_Click(object sender, EventArgs e)
    {
        Int64 ProspectId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
        hdfSelProspId.Value = ProspectId.ToString().Trim();
        Label lblprospName = (Label)(((GridViewRow)((LinkButton)sender).NamingContainer).FindControl("lblprospName"));
        Session["Name"] = txtserprospName.Text.Trim();
        Session["CarMake"] = ddlCarMake.SelectedValue.Trim();
        Session["FromDate"] = txtTotEntFrmDate.Text.Trim();
        Session["ToDate"] = txtTotEntToDate.Text.Trim();
        Session["State"] = ddlserState.SelectedValue.Trim();
        Session["City"] = ddlserCity.SelectedValue.Trim();
        Session["Status"] = ddlStatus.SelectedValue.Trim();
        Session["Email"] = txtEmail1.Text.Trim();
        Session["PhNo"] = txtSerPhNo.Text.Trim();
        Session["PCode"] = txtPCode.Text.Trim();
        Session["PageIndex"] = pagerParent.CurrentIndex;
        Session["PageSize"] = ddlPageSize.SelectedValue.Trim();
        Session["SortExpression"] = Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION]).Trim();
        Session["SortDirection"] = Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION]).Trim();

        //}
        Session["Contact"] = Convert.ToString(ViewState["Contacts"]).Trim();
        if (Session["MyProspData"] != null && ((DataTable)Session["MyProspData"]).Rows.Count > 0 && ProspectId > 0)
        {
            DataRow[] dr = ((DataTable)(Session["MyProspData"])).Select("Id='" + ProspectId.ToString().Trim() + "'");
            if (dr != null && dr.Length > 0)
            {
                Int64 RowNum = Convert.ToInt64(Convert.ToString(dr[0]["RowNo"]).Trim());
                Session["MyCurrentProsp"] = Convert.ToString(RowNum).Trim();
            }
        }
        Response.Redirect("ManageActivities.aspx?ProspectId=" + ProspectId.ToString().Trim());
    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date: 3 oct 2013
    /// Description: Button Click Event Of Edit Contact Pop Up. 
    /// </summary>
    protected void lnkbtnReassignAct_Click(object sender, EventArgs e)
    {
        Int64 ProspectId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
        hdfSelProspId.Value = ProspectId.ToString().Trim();
        Label lblprospName = (Label)(((GridViewRow)((LinkButton)sender).NamingContainer).FindControl("lblprospName"));
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
            MethodInfo methods2 = UC_AddEditContact1.GetType().GetMethod("EditContact");
            if (methods2 != null)
            {
                //if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
                //{
                ////..modified by: Ayyaj
                //Session["isPForFC"] = hdfProspectId.Value.Trim().ToString();
                lblAddContactHead.Text = Resources.PFSalesResource.UpdteProspDetails.Trim();
                object[] objParam = new object[] { ProspectId };
                methods2.Invoke(UC_AddEditContact1, objParam);
                pnlAddContact.Visible = true;
                lnkbtnSave.Text = Resources.PFSalesResource.update.Trim();
                lnkbtnSave.ToolTip = Resources.PFSalesResource.UpdateProspDet.Trim();
                lnkbtnFinalClear.Text = Resources.PFSalesResource.Cancel.Trim();
                lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.Cancel.Trim();
                //}
            }
        }
        //CleraMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 July 2013
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
                LinkButton lnkbtnClearActDet = (LinkButton)e.Row.FindControl("lnkbtnClearActDet");
                if (hdfClrId != null && lnkbtnClearActDet != null)
                {
                    if (!string.IsNullOrEmpty(hdfClrId.Value) && Convert.ToInt64(hdfClrId.Value) > 0)
                    {
                        lnkbtnClearActDet.Enabled = false;
                        lnkbtnClearActDet.ToolTip = Resources.PFSalesResource.ClearedActivity.Trim();
                    }
                }



            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ViewMyContacts.gvActivity_RowDataBound.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 9 July 2013
    /// Description: Selected Index Changed Event Of State's Drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlserState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["FromNotification"] == null || Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == false)
        {
            BindAllCities();
        }
        else if (Session["FromNotification"] != null && Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == true)
        {
            BindAllCities();
            txtMemNo.Text = Session["FromDashMemNo"].ToString().Trim();
        }
        ClearMessage();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 Sept 2013
    /// Description: Selected Index Changed Event Of State's Drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlAdserState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["FromNotification"] == null || Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == false)
        {
            BindAllCities();
            //BindGrid();
        }
        else if (Session["FromNotification"] != null && Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == true)
        {
            BindAllCities();
            //txtAdMemNo.Text = Session["FromDashMemNo"].ToString().Trim();
            // BindGridFromDash();
        }
        ClearMessage();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 9 July 2013
    /// Description: Selected Index Changed Event Of City's Drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlserCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["FromNotification"] == null || Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == false)
        {
            BindGrid();
        }
        else if (Session["FromNotification"] != null && Convert.ToBoolean(Session["FromNotification"].ToString().Trim()) == true)
        {
            txtMemNo.Text = Session["FromDashMemNo"].ToString().Trim();
            BindGridFromDash();
        }
        ClearMessage();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 28 July 2013
    /// Description: Open Panel Of Add/ Edit Contact for adding new contact
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddNewContact_Click(object sender, EventArgs e)
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
            MethodInfo methods = UC_AddEditContact1.GetType().GetMethod("ClearAll");
            if (methods != null)
                methods.Invoke(UC_AddEditContact1, null);
            MethodInfo methods1 = UC_AddEditContact1.GetType().GetMethod("ClearMsg");
            if (methods1 != null)
                methods1.Invoke(UC_AddEditContact1, null);
            pnlAddContact.Visible = true;
            UC_AddEditContact1.FindControl("pnlFCDetails").Visible = true;
            lblAddContactHead.Text = Resources.PFSalesResource.AddProspectDetails.Trim();
            lnkbtnSave.Text = Resources.PFSalesResource.Save.Trim();
            lnkbtnSave.ToolTip = Resources.PFSalesResource.SaveProspect.Trim();
            lnkbtnFinalClear.Text = Resources.PFSalesResource.Clear.Trim();
            lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.Clear.Trim();
        }
        ClearMessage();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 28 July 2013
    /// Description: Close Panel Of Add/ Edit Contact
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddContactClose_Click(object sender, EventArgs e)
    {
        BindGrid();
        pnlAddContact.Visible = false;
        ClearMessage();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 Aug 2013
    /// Description: Close Panel Of Add/ Edit Contact
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnRemovefromAllo_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow Gr in gvprosp.Rows)
            {
                CheckBox chkRemove = (CheckBox)Gr.FindControl("chkSelect");
                HiddenField hdfId = (HiddenField)Gr.FindControl("hdfId");
                if (chkRemove != null && hdfId != null && chkRemove.Checked && BasePage.UserSession.VirtualRoleId != null)
                {
                    objProsp.ProspId = Convert.ToInt64(hdfId.Value.Trim());
                    objProsp.CreatedById = BasePage.UserSession.VirtualRoleId;
                    objProsp.IsDeleted = true;
                    Int64 Result = objProspBM.RemoveFromAllocation(objProsp);
                    if (Result > 0)
                    {
                        lblAddSucMsg.Text = "Prospects Successfully Removed From Allocation";
                        lblAddErrMsg.Text = string.Empty;
                        dvadderror.Visible = false;
                        dvaddSucc.Visible = true;
                    }
                    else
                    {
                        lblAddErrMsg.Text = "Prospects Not Removed From Allocation, Please Try Later";
                        lblAddSucMsg.Text = string.Empty;
                        dvadderror.Visible = true;
                        dvaddSucc.Visible = false;
                    }
                    BindGrid();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ViewMyContacts.gvActivity_RowDataBound.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 8 Aug 2013
    /// Description: Fillter All Contact
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAllContacts_Click(object sender, EventArgs e)
    {
        pagerParent.CurrentIndex = 1;
        ViewState["Contacts"] = "AllContacts";
        BindGrid();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 8 Aug 2013
    /// Description: Fillter All Deals
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAllDeals_Click(object sender, EventArgs e)
    {
        pagerParent.CurrentIndex = 1;
        ViewState["Contacts"] = "AllDeals";
        BindGrid();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 Aug 2013
    /// Description: Fillter Current Contacts
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnCurrent_Click(object sender, EventArgs e)
    {
        pagerParent.CurrentIndex = 1;
        ViewState["Contacts"] = "Current";
        BindGrid();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 Aug 2013
    /// Description: Row Data Bound Event Of Prospect's Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvprosp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label LblStatus;
                HiddenField _hdfTotActCnt = (HiddenField)e.Row.FindControl("_hdfTotCount");
                HiddenField _hdfIsTender = (HiddenField)e.Row.FindControl("_hdfIsTender");
                HiddenField hdfStateId = (HiddenField)e.Row.FindControl("hdfStateId");
                Image imgWALead = (Image)e.Row.FindControl("imgWALead");
                HiddenField hdfFTLead = (HiddenField)e.Row.FindControl("hdfFTLead");
                Image imgFTLead = (Image)e.Row.FindControl("imgFTLead");
                if (BasePage.UserSession.RoleId == 5)
                    LblStatus = (Label)e.Row.FindControl("lblFCstatus");
                else
                    LblStatus = (Label)e.Row.FindControl("lblstatus");
                if (LblStatus != null && !string.IsNullOrEmpty(LblStatus.Text.Trim()))
                {
                    switch (LblStatus.Text.Trim().ToUpper())
                    {
                        case "ACTIVE":
                            e.Row.BackColor = System.Drawing.Color.FromName("#E0FFFF");
                            break;
                        case "APP TAKEN":
                            e.Row.BackColor = System.Drawing.Color.FromName("#E0FFFF");
                            break;
                        case "AA/NP SENT":
                            e.Row.BackColor = System.Drawing.Color.FromName("#E0FFFF");
                            break;
                        case "TENDER":
                            e.Row.BackColor = System.Drawing.Color.FromName("#FFE4E1");
                            break;
                        case "BA/SP REC":
                            e.Row.BackColor = System.Drawing.Color.FromName("#FFE4E1");
                            break;
                        case "LEAD":
                            e.Row.BackColor = System.Drawing.Color.FromName("#FFFFFF");
                            break;
                        case "PRE-TENDER":
                            e.Row.BackColor = System.Drawing.Color.FromName("#00FF00");
                            break;
                        default:
                            e.Row.BackColor = System.Drawing.Color.FromName("#DCF0FE");
                            break;
                    }
                }
                if (_hdfTotActCnt != null && _hdfIsTender != null)
                {
                    if (Convert.ToInt32(_hdfTotActCnt.Value.Trim()) == 0 && Convert.ToInt32(_hdfIsTender.Value.Trim()) == 0)
                    {
                        IsLastRec = true;
                        cnt = cnt + 1;

                    }

                    if (IsLastRec && cnt == 1)
                    {
                        //e.Row.BorderWidth = Unit.Parse("10");
                        e.Row.Style.Add("border-top", "10px solid ");
                        //if (Convert.ToInt32(_hdfTotActCnt.Value.Trim()) == 0)
                        //{
                        //    e.Row.Style.Add("border-top", "1px solid ");
                        //}
                        //border-bottom: 10px solid red;
                        IsLastRec = false;

                    }

                }
                if (hdfStateId != null && !string.IsNullOrEmpty(hdfStateId.Value.Trim()) && imgWALead != null)
                {
                    if (Convert.ToInt16(hdfStateId.Value.Trim()) == 7) //7=State Id Of WA State
                    {
                        imgWALead.Visible = true;
                    }
                }
                if (hdfFTLead != null && !string.IsNullOrEmpty(hdfFTLead.Value.Trim()) && imgFTLead != null)
                {
                    if (Convert.ToBoolean(hdfFTLead.Value))
                        imgFTLead.Visible = true;
                }
                if (BasePage.UserSession.RoleId == 5)
                {
                    HiddenField hdfIsPForFC = (HiddenField)e.Row.FindControl("hdfIsPForFC");
                    Label lblstatus = (Label)e.Row.FindControl("lblstatus");
                    Image imgPureFCLead = (Image)e.Row.FindControl("imgPureFCLead");
                    if (imgPureFCLead != null && hdfIsPForFC != null && lblstatus != null)
                    {
                        if (hdfIsPForFC.Value.Trim().ToUpper() == "F")
                        {
                            lblstatus.Visible = false;
                            imgPureFCLead.Visible = true;
                        }
                    }
                    HiddenField hdfRefsource = (HiddenField)e.Row.FindControl("hdfRefSource");
                    Image imgIM = (Image)e.Row.FindControl("imgIM");
                    Image imgE = (Image)e.Row.FindControl("imgE");
                    if (hdfRefsource.Value.Trim().ToUpper() == "EMPLOYER")
                    {
                        e.Row.BackColor = System.Drawing.Color.FromName("#00FF00");
                        imgE.Visible = true;


                    }
                    else if (hdfRefsource.Value.Trim().ToUpper() == "IM")
                    {
                        e.Row.BackColor = System.Drawing.Color.FromName("#00FF00");
                        imgIM.Visible = true;
                    }


                }
                if (BasePage.UserSession.RoleId == 3)
                {
                    HiddenField hdfIsFinanceSource = (HiddenField)e.Row.FindControl("hdfIsFinanceSource");
                    Label lblFCstatus = (Label)e.Row.FindControl("lblFCstatus");
                    Image imgPurePfLead = (Image)e.Row.FindControl("imgPurePfLead");
                    if (imgPurePfLead != null && hdfIsFinanceSource != null && lblFCstatus != null)
                    {
                        if (hdfIsFinanceSource.Value.Trim().ToUpper() == "0")
                        {
                            lblFCstatus.Visible = false;
                            imgPurePfLead.Visible = true;
                        }
                    }
                }
            }
            //if (ViewState["Contacts"] != null && !string.IsNullOrEmpty(ViewState["Contacts"].ToString().Trim()) && ViewState["Contacts"].ToString().Trim().ToUpper() != "ALLCONTACTS")
            //{


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvprosp, "Select$" + e.Row.RowIndex);
            }
            //}
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ViewMyContacts.gvprosp_RowDataBound.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 Aug 2013
    /// Description: Selected Index changed Event Of Consultant's Drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlserConsultant_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 Aug 2013
    /// Description: View All FC Leads
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAllFC_Click(object sender, EventArgs e)
    {
        try
        {
            pagerParent.CurrentIndex = 1;
            ViewState["Contacts"] = "FCLeads";
            BindGrid();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ViewMyContacts.lnkbtnAllFC_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 Sept 2013
    /// Description: Page Unload Events
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_UnLoad(object sender, EventArgs e)
    {  // Clear Session Values Which Were Used For Storing Filter Criteria
        //Session["PCode"] = Session["PhNo"] = Session["Email"] = Session["Status"] = Session["City"] = Session["State"] = Session["ToDate"] = Session["FromDate"] = Session["CarMake"] = Session["Name"] = string.Empty;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 Sept 2013
    /// Description: Export To Excel Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnExport_Click(object sender, EventArgs e)
    {
        ExportToExcelsheet();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 Sept 2013
    /// Description:Selected Index Changed Event Of Gridview
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvprosp_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow Gr = gvprosp.SelectedRow;
            Int64 ProspectId = Convert.ToInt64(((LinkButton)Gr.FindControl("lnkbtnManageAct")).CommandArgument.Trim());
            hdfSelProspId.Value = ProspectId.ToString().Trim();
            Label lblprospName = (Label)(Gr.FindControl("lblprospName"));
            Session["Name"] = txtserprospName.Text.Trim();
            Session["CarMake"] = ddlCarMake.SelectedValue.Trim();
            Session["FromDate"] = txtTotEntFrmDate.Text.Trim();
            Session["ToDate"] = txtTotEntToDate.Text.Trim();
            Session["State"] = ddlserState.SelectedValue.Trim();
            Session["City"] = ddlserCity.SelectedValue.Trim();
            Session["Status"] = ddlStatus.SelectedValue.Trim();
            Session["Email"] = txtEmail1.Text.Trim();
            Session["PhNo"] = txtSerPhNo.Text.Trim();
            Session["PCode"] = txtPCode.Text.Trim();
            Session["PageIndex"] = pagerParent.CurrentIndex;
            Session["PageSize"] = ddlPageSize.SelectedValue.Trim();
            Session["SortExpression"] = Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION]).Trim();
            Session["SortDirection"] = Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION]).Trim();
            Session["Contact"] = Convert.ToString(ViewState["Contacts"]).Trim();
            if (Session["MyProspData"] != null && ((DataTable)Session["MyProspData"]).Rows.Count > 0 && ProspectId > 0)
            {
                DataRow[] dr = ((DataTable)(Session["MyProspData"])).Select("Id='" + ProspectId.ToString().Trim() + "'");
                if (dr != null && dr.Length > 0)
                {
                    Int64 RowNum = Convert.ToInt64(Convert.ToString(dr[0]["RowNo"]).Trim());
                    Session["MyCurrentProsp"] = Convert.ToString(RowNum).Trim();
                }
            }
            Response.Redirect("ManageActivities.aspx?ProspectId=" + ProspectId.ToString().Trim());
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ViewMyContacts.gvprosp_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// =============================================
    /// Author:	Mechsoft
    /// Created by:	Sachin
    /// Create date: 22-oct-2013
    /// Description:Handleing custom paging events
    /// =============================================
    public void pagerParent_Command(object sender, CommandEventArgs e)
    {

        try
        {
            pagerParent.CurrentIndex = Convert.ToInt32(e.CommandArgument);

            gvprosp.PageIndex = Convert.ToInt32(e.CommandArgument);

            BindGrid();

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message);
            //throw ex;
        }
    }
    #endregion

    #region Methods

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Bind Grid View Data
    /// </summary>

    public void BindGrid()
    {

        try
        {
            if (ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] != null && ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION]).Trim()))
            {
                if (Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION]) == Cls_Constant.VIEWSTATE_ASC)
                    objProsp = Setobject(Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION]).Trim() + " ASC");
                else if (Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION]) == Cls_Constant.VIEWSTATE_DESC)
                    objProsp = Setobject(Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION]).Trim() + " DESC");
                else
                    objProsp = Setobject(Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION]).Trim() + " ASC");
            }
            else
                objProsp = Setobject(string.Empty);
            DataTable Dt = new DataTable();
            DataSet DS = objProspBM.GetAllProspForConsult(objProsp);
            if (DS != null && DS.Tables.Count > 0)
            {
                Dt = DS.Tables[0];
                if (Dt != null & Dt.Rows.Count > 0)
                {
                    ViewState["MainData"] = Dt;

                    gvprosp.DataSource = Dt;
                    gvprosp.DataBind();
                    DataTable dtTemp1 = new DataTable();
                    dtTemp1 = Dt.Copy();
                    dtTemp1.Columns.Add("RowNo");
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dtTemp1.Rows[i]["RowNo"] = i + 1;
                    }
                    Session["MyProspData"] = dtTemp1;
                    if (Session["MyCurrentProsp"] == null && string.IsNullOrEmpty(Convert.ToString(Session["MyCurrentProsp"]).Trim()))
                        Session["MyCurrentProsp"] = "1";

                    pagerParent.PageSize = gvprosp.PageSize;
                    if (DS.Tables[1].Rows.Count > 0)
                    {
                        pagerParent.ItemCount = Convert.ToDouble(DS.Tables[1].Rows[0][0]);
                    }
                    else
                        pagerParent.ItemCount = 0;

                    t3 = new Thread(saveDataToViewState);
                    t3.Start();
                }
                else
                {
                    Session["MyProspData"] = gvprosp.DataSource = null;
                    if (Session["MyCurrentProsp"] == null && string.IsNullOrEmpty(Convert.ToString(Session["MyCurrentProsp"]).Trim()))
                        Session["MyCurrentProsp"] = "1";
                    gvprosp.DataBind();
                    ViewState["TotalRowCount"] = "0";
                    pagerParent.ItemCount = 0;
                }
            }
            else
            {
                Session["MyProspData"] = gvprosp.DataSource = null;
                if (Session["MyCurrentProsp"] == null && string.IsNullOrEmpty(Convert.ToString(Session["MyCurrentProsp"]).Trim()))
                    Session["MyCurrentProsp"] = "1";
                gvprosp.DataBind();
                ViewState["TotalRowCount"] = "0";
                pagerParent.ItemCount = 0;
            }
            // Clear Session Values Which Were Used For Storing Filter Criteria
            Session["PCode"] = Session["PhNo"] = Session["Email"] = Session["Status"] = Session["City"] = Session["State"] = Session["ToDate"] = Session["FromDate"] = Session["CarMake"] = Session["Name"] = string.Empty;
            t3.Join(10);
            if (BasePage.UserSession.RoleId == 3)
                gvprosp.Columns[8].Visible = false;
            else if (BasePage.UserSession.RoleId == 5)
                gvprosp.Columns[8].Visible = true;

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ViewMyContacts.BindGrid.Error:" + ex.StackTrace);
        }

    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 14 Aug 2013
    /// Description: Bind Default Grid View Data
    /// </summary>
    private void BindDefaultGrid()
    {
        try
        {
            if (ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] != null && ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION]).Trim()))
            {
                if (Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION]) == Cls_Constant.VIEWSTATE_ASC)
                    objProsp = Setobject(Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION]).Trim() + " ASC");
                else if (Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION]) == Cls_Constant.VIEWSTATE_DESC)
                    objProsp = Setobject(Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION]).Trim() + " DESC");
                else
                    objProsp = Setobject(Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION]).Trim() + " ASC");
            }
            else
                objProsp = Setobject(string.Empty);
            DataTable Dt = new DataTable();
            DataSet DS = objProspBM.GetAllProspForConsult(objProsp);
            if (DS != null && DS.Tables.Count > 0)
            {
                Dt = DS.Tables[0];
                if (Dt != null & Dt.Rows.Count > 0)
                {
                    gvprosp.DataSource = Dt;
                    gvprosp.DataBind();
                    DataTable dtTemp1 = new DataTable();
                    dtTemp1 = Dt.Copy();
                    dtTemp1.Columns.Add("RowNo");
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dtTemp1.Rows[i]["RowNo"] = i + 1;
                    }
                    Session["MyProspData"] = dtTemp1;
                    if (Session["MyCurrentProsp"] == null && string.IsNullOrEmpty(Convert.ToString(Session["MyCurrentProsp"]).Trim()))
                        Session["MyCurrentProsp"] = "1";

                    pagerParent.PageSize = gvprosp.PageSize;
                    if (DS.Tables[1].Rows.Count > 0)
                    {
                        pagerParent.ItemCount = Convert.ToDouble(DS.Tables[1].Rows[0][0]);
                    }
                    else
                        pagerParent.ItemCount = 0;
                    t3 = new Thread(saveDataToViewState);
                    t3.Start();
                }
                else
                {
                    Session["MyProspData"] = gvprosp.DataSource = null;
                    if (Session["MyCurrentProsp"] == null && string.IsNullOrEmpty(Convert.ToString(Session["MyCurrentProsp"]).Trim()))
                        Session["MyCurrentProsp"] = "1";
                    gvprosp.DataBind();
                    ViewState["TotalRowCount"] = "0";
                    pagerParent.ItemCount = 0;
                }
            }
            else
            {
                Session["MyProspData"] = gvprosp.DataSource = null;
                if (Session["MyCurrentProsp"] == null && string.IsNullOrEmpty(Convert.ToString(Session["MyCurrentProsp"]).Trim()))
                    Session["MyCurrentProsp"] = "1";
                gvprosp.DataBind();
                ViewState["TotalRowCount"] = "0";
                pagerParent.ItemCount = 0;
            }
            // Clear Session Values Which Were Used For Storing Filter Criteria
            Session["PCode"] = Session["PhNo"] = Session["Email"] = Session["Status"] = Session["City"] = Session["State"] = Session["ToDate"] = Session["FromDate"] = Session["CarMake"] = Session["Name"] = string.Empty;
            t3.Join(10);

            if (BasePage.UserSession.RoleId == 3)
                gvprosp.Columns[8].Visible = false;
            else if (BasePage.UserSession.RoleId == 5)
                gvprosp.Columns[8].Visible = true;

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ViewMyContacts.BindGrid.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Crearted By:Pravin Gholap
    /// Created Date:10 June 2013
    /// Description:Define the sort direction for sorting the grid view
    /// </summary>
    private void DefineSortDirection()
    {
        try
        {
            if (ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] != null)
            {
                if (ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] != null && Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION]).Trim() == Cls_Constant.VIEWSTATE_ASC)
                {
                    ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;
                }
                else
                {
                    ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_ASC;
                }
            }
            else
                ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_ASC;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SearchProspect.DefineSortDirection.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Get All Makes
    /// </summary>
    private void BindAllMakes()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllMakes(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlCarMake, "Make", "Id", Dt);
            //Cls_BinderHelper.BindDropdownList(ddlAdCarMake, "Make", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ViewMyContacts.BindAllMakes.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Get All Statuses
    /// </summary>
    private void BindAllStatuses()
    {
        try
        {
            DataTable Dt = new DataTable();
            if (BasePage.UserSession.RoleId == 3)
                Dt = objMstBM.GetAllStatus(1, 1);// Hard Coded Entity Id & Process Id
            else if (BasePage.UserSession.RoleId == 5)
                Dt = objMstBM.GetAllStatus(6, 1);// Hard Coded Entity Id & Process Id
            else
                Dt = objMstBM.GetAllStatus(1, 1);// Hard Coded Entity Id & Process Id
            Cls_BinderHelper.BindDropdownList(ddlStatus, "Status", "Id", Dt);
            //Cls_BinderHelper.BindDropdownList(ddlAdStatus, "Status", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ViewMyContacts.BindAllStatuses.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Bind Grid View Data When Clicked From Dash Board
    /// </summary>
    private void BindGridFromDash()
    {
        try
        {
            if ((Session["FromDashProspectId"] != null && !string.IsNullOrEmpty(Session["FromDashProspectId"].ToString().Trim())) || (Session["FromDashMemNo"] != null))
            {
                if (ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] != null && ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION]).Trim()))
                {
                    if (Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION]) == Cls_Constant.VIEWSTATE_ASC)
                        objProsp = Setobject(Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION]).Trim() + " ASC");
                    else if (Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION]) == Cls_Constant.VIEWSTATE_DESC)
                        objProsp = Setobject(Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION]).Trim() + " DESC");
                    else
                        objProsp = Setobject(Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION]).Trim() + " ASC");
                }
                else
                    objProsp = Setobject(string.Empty);
                DataTable Dt = objActivityBM.GetProspDetFromDash(objProsp);
                if (Dt != null & Dt.Rows.Count > 0)
                {
                    DataView dV = Dt.DefaultView;
                    dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
                    gvprosp.DataSource = Dt;
                    gvprosp.DataBind();
                    ViewState["TotalRowCount"] = Dt.Rows.Count;

                }
                else
                {
                    gvprosp.DataSource = null;
                    gvprosp.DataBind();
                    ViewState["TotalRowCount"] = "0";
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ViewMyContacts.BindGrid.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 2 July 2013
    /// Description: Bind Managed Activity Data
    /// </summary>
    /// <param name="ProspectId"></param>
    private void BindMangeActivity(Int64 ProspectId)
    {
        try
        {
            //if (ProspectId > 0)
            //{
            //    DataTable Dt = objActivityBM.GetActivityOfProspect(ProspectId);
            //    if (Dt != null & Dt.Rows.Count > 0)
            //    {
            //        DataView dV = Dt.DefaultView;
            //        dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION2].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION2].ToString());
            //        //gvActivity.DataSource = Dt;
            //        //gvActivity.DataBind();
            //    }
            //    else
            //    {
            //        //gvActivity.DataSource = null;
            //        //gvActivity.DataBind();
            //    }
            //    pnlMangeAct.Visible = true;
            //}
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ViewMyContacts.lnkbtnManageAct_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 9 July 2013
    /// Description: Get All State
    /// </summary>
    private void BindAllStates()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllState(string.Empty, 1);
            Cls_BinderHelper.BindDropdownList(ddlserState, "StateName", "Id", Dt);
            //Cls_BinderHelper.BindDropdownList(ddlAdserState, "StateName", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ViewMyContacts.BindAllStates.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 9 July 2013
    /// Description: Get All Cities
    /// </summary>
    private void BindAllCities()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllCity(string.Empty, Convert.ToInt64(ddlserState.SelectedValue.Trim()));
            Cls_BinderHelper.BindDropdownList(ddlserCity, "CityName", "Id", Dt);
            //Cls_BinderHelper.BindDropdownList(ddlAdserCity, "CityName", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindAllCities.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 Aug 2013
    /// Description: Clear Messages
    /// </summary>
    private void ClearMessage()
    {
        lblAddErrMsg.Text = lblAddSucMsg.Text = string.Empty;
        dvaddSucc.Visible = dvadderror.Visible = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 Aug 2013
    /// Description: Bind ConsulTants
    /// </summary>
    private void BindConsultants()
    {
        try
        {
            DataTable Dt = objEmpBM.GetAllConsultants(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlserConsultant, "Name", "ConsultnatId", Dt);
            //Cls_BinderHelper.BindDropdownList(ddlAdserConsultant, "Name", "ConsultnatId", Dt);
        }

        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ViewMyContacts.BindContacts.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 Sept 2013
    /// Description: Export to excel function.
    /// </summary>
    public void ExportToExcelsheet()
    {
        try
        {
            if (ViewState["MainData"] != null)
            {

                string path = Server.MapPath("Reports") + "\\ENewsLetter.xls";
                string szConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=No'";
                OleDbConnection conn = new OleDbConnection(szConn);
                conn.Open();

                // Select
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", conn);
                OleDbDataAdapter adpt = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                int TotalCnt = ds.Tables[0].Rows.Count - 11;
                DataTable dt = (DataTable)ViewState["MainData"];
                int cnt = 3;
                foreach (DataRow dr in dt.Rows)
                {
                    string lblLeadFirstName = dr["LeadFirstName"].ToString().Trim().Replace("'", "\'");
                    lblLeadFirstName = lblLeadFirstName.Replace("'", "");
                    string lblEmailId = dr["EmailId"].ToString().Trim();
                    string lblPFstatus = dr["Status"].ToString().Trim();
                    string lblFCStatus = dr["FCStatus"].ToString().Trim();
                    //modified by:Ayyaj
                    string lblPFConsultant = dr["PfConsultant"].ToString().Trim();
                    string lblFCConsultant = dr["FCconsultant"].ToString().Trim();
                    //................
                    string lblEnquiryDate = dr["EnquiryDate"].ToString().Trim();
                    string lblAllocatedDate = dr["AllocatedDate"].ToString().Trim();
                    string lblName = dr["Name"].ToString().Trim().Replace("'", "\'");
                    lblName = lblName.Replace("'", "");
                    string lblMake = dr["Make"].ToString().Trim();
                    string lblModel = dr["Model"].ToString().Trim();
                    string lblState = dr["StateName"].ToString().Trim();
                    //modified by:Ayyaj
                    //cmd = new OleDbCommand("UPDATE [Sheet1$B" + cnt + ":L" + cnt + "] SET F1='" + lblLeadFirstName + "',F2='" + lblEmailId + "',F3='" + lblPFstatus + "',F4='" + lblFCStatus + "',F5='" + lblEnquiryDate + "',F6='" + lblAllocatedDate + "',F7='" + lblName + "',F8='" + lblMake + "',F9='" + lblModel + "',F10='" + lblState + "'", conn);
                    cmd = new OleDbCommand("UPDATE [Sheet1$B" + cnt + ":N" + cnt + "] SET F1='" + lblLeadFirstName + "',F2='" + lblEmailId + "',F3='" + lblPFConsultant + "',F4='" + lblPFstatus + "',F5='" + lblFCConsultant + "',F6='" + lblFCStatus + "',F7='" + lblEnquiryDate + "',F8='" + lblAllocatedDate + "',F9='" + lblName + "',F10='" + lblMake + "',F11='" + lblModel + "',F12='" + lblState + "'", conn);
                    cmd.ExecuteNonQuery();
                    cnt++;
                }

                for (int i = cnt; i < TotalCnt + 3; i++)
                {
                    //modified by:Ayyaj
                    // cmd = new OleDbCommand("UPDATE [Sheet1$B" + i + ":K" + i + "] SET F1='',F2='',F3='',F4='',F5='',F6='',F7='',F8='',F9='',F10=''", conn);
                    cmd = new OleDbCommand("UPDATE [Sheet1$B" + i + ":M" + i + "] SET F1='',F2='',F3='',F4='',F5='',F6='',F7='',F8='',F9='',F10=''", conn);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();

                System.IO.FileInfo file = new System.IO.FileInfo(path);

                Response.ContentType = "application/Excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=ENewsLetter.xls");
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.WriteFile(file.FullName);
                Response.End();
                Response.Clear();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ViewMyContacts.ExportToExcelsheet.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 Sept 2013
    /// Description: Set Properties of Prospect's Object
    /// </summary>
    /// <returns></returns>
    private Prospect Setobject(string sortcolumn)
    {
        try
        {
            string strActive = "24", strTender = "25", strNTU = "27", strDead = "26", strClient = "2", strLead = "1", strFallOver = "4", strInDispute = "3", strFCActive = "39", strFCTender = "40", strFCNTU = "42", strFCDead = "41", strFCLead = "35", strFCFallOver = "38", strFCInDispute = "37", strFCClient = "36", strFCAppTaken = "46", strAASent = "47", strBASPRec = "48", strPretender = "52";
            objProsp.FName = txtserprospName.Text.Trim();
            objProsp.Finance = 0;
            if (ViewState["Contacts"] != null && !string.IsNullOrEmpty(ViewState["Contacts"].ToString().Trim()) && ViewState["Contacts"].ToString().Trim().ToUpper() == "ALLCONTACTS" && ddlStatus.SelectedValue.Trim() == "0")
                objProsp.Ids = "";
            else if (ViewState["Contacts"] != null && !string.IsNullOrEmpty(ViewState["Contacts"].ToString().Trim()) && ViewState["Contacts"].ToString().Trim().ToUpper() == "ALLDEALS" && ddlStatus.SelectedValue.Trim() == "0")
                objProsp.Ids = strClient + "," + strFCClient;
            else if (ViewState["Contacts"] != null && !string.IsNullOrEmpty(ViewState["Contacts"].ToString().Trim()) && ViewState["Contacts"].ToString().Trim().ToUpper() == "CURRENT" && ddlStatus.SelectedValue.Trim() == "0")
            {
                if (BasePage.UserSession.RoleId == 5)
                {
                    objProsp.Ids = strTender + "," + strActive + "," + strLead + "," + strFCTender + "," + strFCActive + "," + strFCLead + "," + strPretender + "," + strFCAppTaken + "," + strAASent + "," + strBASPRec;
                }
                else
                {
                    objProsp.Ids = strTender + "," + strActive + "," + strLead + "," + strFCTender + "," + strFCActive + "," + strFCLead + "," + strPretender;
                }
            }
            else if (ViewState["Contacts"] != null && !string.IsNullOrEmpty(ViewState["Contacts"].ToString().Trim()) && ViewState["Contacts"].ToString().Trim().ToUpper() == "FCLEADS" && ddlStatus.SelectedValue.Trim() == "0")
            {
                objProsp.Ids = "";
                objProsp.Finance = 1;
            }
            else if (ddlStatus.SelectedValue.Trim() != "0")
                objProsp.Ids = ddlStatus.SelectedValue.Trim();
            objProsp.MemberNo = txtMemNo.Text.Trim();
            objProsp.CarMake = Convert.ToInt32(ddlCarMake.SelectedValue.Trim());
            objProsp.Email = txtEmail1.Text.Trim();
            objProsp.StateId = Convert.ToInt32(ddlserState.SelectedValue.Trim());
            objProsp.CityId = Convert.ToInt32(ddlserCity.SelectedValue.Trim());
            if (!string.IsNullOrEmpty(txtTotEntFrmDate.Text.Replace("__/__/____", "")))
                objProsp.FromDate = Convert.ToDateTime(txtTotEntFrmDate.Text.Trim());
            else
                objProsp.FromDate = DateTime.MinValue;
            if (!string.IsNullOrEmpty(txtTotEntToDate.Text.Replace("__/__/____", "")))
                objProsp.ToDate = Convert.ToDateTime(txtTotEntToDate.Text.Trim());
            else
                objProsp.ToDate = DateTime.MinValue;

            objProsp.PageSize = gvprosp.PageSize;
            objProsp.PageIndex = pagerParent.CurrentIndex;
            pagerParent.PageSize = gvprosp.PageSize;
            if (ddlserConsultant.SelectedValue != "0")
            {
                string[] arr = ddlserConsultant.SelectedValue.Trim().Split('-');
                if (arr != null && arr.Length > 0)
                {
                    objProsp.ValueforAnswer = arr[0].Trim();
                    objProsp.CreatedById = Convert.ToInt64(arr[1].Trim());
                }
                else
                {
                    objProsp.ValueforAnswer = string.Empty;
                    objProsp.CreatedById = Convert.ToInt64(ddlserConsultant.SelectedValue.Trim());
                }
            }
            else
            {
                objProsp.ValueforAnswer = string.Empty;
                objProsp.CreatedById = Convert.ToInt64(ddlserConsultant.SelectedValue.Trim());
            }
            objProsp.Phone = txtSerPhNo.Text.Trim();
            objProsp.PostalCode = txtPCode.Text.Trim();
            objProsp.Comment = sortcolumn;
            return objProsp;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ViewMyContacts.Setobject.Error:" + ex.StackTrace);
            return null;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 26 Oct 2013
    /// Description: Save Data To View State
    /// </summary>
    private void saveDataToViewState()
    {
        try
        {
            DataTable Dt = new DataTable();
            Dt = objProspBM.GetAllProspForConsultExport(objProsp);
            if (Dt != null & Dt.Rows.Count > 0)
            {
                Session["TotalRowCount"] = Dt.Rows.Count;
                DataTable dtTemp1 = new DataTable();
                dtTemp1 = Dt.Copy();
                dtTemp1.Columns.Add("RowNo");
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    dtTemp1.Rows[i]["RowNo"] = i + 1;
                }
                Session["MyProspData"] = dtTemp1;
                if (Session["MyCurrentProsp"] == null && string.IsNullOrEmpty(Convert.ToString(Session["MyCurrentProsp"]).Trim()))
                    Session["MyCurrentProsp"] = "1";
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.saveDataToViewState.Error:" + ex.StackTrace);
        }
    }
    #endregion
}
