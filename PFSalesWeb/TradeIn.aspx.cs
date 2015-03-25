﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mechsoft.PFSales.BusinessEntity;
using Mechsoft.PFSales.BusinessManager;
using Mechsoft.GeneralUtilities;
using log4net;
using System.Data;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Data.Common;

public partial class AddProspects : BasePage
{
    #region Global Variables
    Prospect objProsp = new Prospect();
    TradeIn objTradeIn = new TradeIn();
    ProspectBM objProspBM = new ProspectBM();
    MasterBM objMstBM = new MasterBM();
    EmployeeBM objEmpBM = new EmployeeBM();
    ContactBM objContBM = new ContactBM();
    ILog Logger = LogManager.GetLogger(typeof(AddProspects));
    Activity objActivity = new Activity();
    ActivityBM objActivityBM = new ActivityBM();
    double TimeSpan1 = Convert.ToDouble(ConfigurationManager.AppSettings["ActInterval"].ToString().Trim());
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string str = string.Empty;
            if (Session["ProspectTradeId"].ToString()!=null)
            {
                 str = Session["ProspectTradeId"].ToString();
            }
            
            if (ViewState["ProspectId"] == null)
            {
                ViewState["ProspectId"] = str;
            }
           
            BindAllStatuses();
            lnkbtnSave.Visible = true;
            lnkbtnUpdate.Visible = false;
            
            addDate();
            BindGridTradeIn();
            BindProspData();
            BindAllCountry();
            BindFormats();
            BindAllMakes();
            
            BindProfessions();
            
            SetDefaultFormat();
            #region Hide
            //    ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = "status";
            //    ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "Name";
            //    ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;
            //BindGrid();
            //    BindAllSources();
            //    BindConsultant();
            //    BindContacts();
            //    //BindFinance();
            //    BindWUHValues();
            //    BinFinReqFrom();
            //    txtserprospName.Focus();

            //    if (BasePage.UserSession.RoleId == 3 || BasePage.UserSession.RoleId == 5)
            //        ddlConsultant.SelectedValue = BasePage.UserSession.VirtualRoleId.ToString().Trim();
            //    else
            //        ddlConsultant.SelectedValue = "0";
            //    if (Session["EmailFromClaim101"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["EmailFromClaim101"]).Trim()))
            //    {
            //        txtEmail1.Text = Convert.ToString(Session["EmailFromClaim101"]).Trim();
            //        Session["EmailFromClaim101"] = string.Empty;
            //    }
            //    if (Session["FromMasterPage"] != null)
            //    {
            //        if (Boolean.Parse(Session["FromMasterPage"].ToString().Trim()))
            //        {
            //            Session["FromMasterPage"] = false;
            //            lnkbtnAddprosp_Click(null, null);
            //        }
            //    }
            //    if (BasePage.UserSession.RoleId == 1)
            //        ddlConsultant.Enabled = true;//ddlFConsultant.Enabled = ayyaj
            //    else
            //        ddlConsultant.Enabled = false;//ddlFConsultant.Enabled =ayyaj
            //    Page.MaintainScrollPositionOnPostBack = true;

            //    if (BasePage.UserSession.RoleId == 1)
            //    {
            //        //ddlPostalCode.Visible = rfvStatus.Enabled = rfvCarMake.Enabled = rfvPhone.Enabled = rfvState.Enabled = rfvModel.Enabled = rfvCountry.Enabled = rfvPostalCode.Enabled = rfvReferredBy.Enabled = false;ayyaj
            //        rfvPCode.Enabled = txtPostalCode.Visible = true;
            //    }
            //    else if (BasePage.UserSession.RoleId == 3)
            //    {
            //        //ddlPostalCode.Visible = rfvStatus.Enabled = rfvCarMake.Enabled = rfvPhone.Enabled = rfvState.Enabled = rfvModel.Enabled = rfvCountry.Enabled = rfvPostalCode.Enabled = rfvReferredBy.Enabled = true;ayyaj
            //        rfvPCode.Enabled = txtPostalCode.Visible = false;
            //    }
            //    else if (BasePage.UserSession.RoleId == 5)
            //    {
            //       //ddlPostalCode.Visible = rfvStatus.Enabled = rfvCarMake.Enabled = rfvPhone.Enabled = rfvState.Enabled = rfvModel.Enabled = rfvCountry.Enabled = rfvPostalCode.Enabled = rfvReferredBy.Enabled = false;ayyaj
            //        rfvPCode.Enabled = txtPostalCode.Visible = true;
            //    }
            //    else
            //    {
            //        //ddlPostalCode.Visible = rfvStatus.Enabled = rfvCarMake.Enabled = rfvPhone.Enabled = rfvState.Enabled = rfvModel.Enabled = rfvCountry.Enabled = rfvPostalCode.Enabled = rfvReferredBy.Enabled = true;ayyaj
            //        rfvPCode.Enabled = txtPostalCode.Visible = true;
            //    }
            #endregion
            ddlTitle.Focus();
        }
        else
        {
            /// <summary>
            /// Created By: Ayyaj Mujawar
            /// Created Date: 10 Oct 2013
            /// Description: To Maintain Focus during PostBack
            /// </summary>

            Control cont = this.Page.FindControl(Request.Form["__EVENTTARGET"]);
            if (cont != null)
                cont.Focus();

        }

        //CompValToTodayDate.ValueToCompare = DateTime.Today.Date.ToString(Resources.PFSalesResource.dateformat.Trim());
        //Page.Form.Attributes.Add("enctype", "multipart/form-data");
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Add Prospect Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddprosp_Click(object sender, EventArgs e)
    {
        pnlSearchprosp.Visible = false;
        pnlAddProsp.Visible = true;
        ViewState["ProspId"] = 0;
        lnkbtnSave.Text = Resources.PFSalesResource.Save.Trim();
        lnkbtnSave.ToolTip = Resources.PFSalesResource.SaveProspect.Trim();
        lnkbtnFinalClear.Text = Resources.PFSalesResource.Clear.Trim();
        lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.Clear.Trim();
        lblAddProspHead.Text = Resources.PFSalesResource.AddProspectDetails.Trim();
        ClearMsg();
        ClearAll();
        ddlTitle.Focus();
        dlSendMail.Visible = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 2 Jan 2014
    /// Description: Text Changed Event Of Postal Code's Text Box 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtPostalCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            BindAllCities();
            ClearMsg();
            // ddlCity.Focus();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.txtPostalCode_TextChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Gridview Page Index Changing Event. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvprosp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvprosp.PageIndex = e.NewPageIndex;
            BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.gvprosp_PageIndexChanging Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
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
            BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.gvprosp_Soring.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Row Data Bound Event Of GridView. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvprosp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkBtnDelete = (LinkButton)e.Row.FindControl("lnkbtnDelete");
                LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkbtnEdit");
                HiddenField hdfFinance = (HiddenField)e.Row.FindControl("hdfFinance");
                HiddenField hdfIsFleetTeamLead = (HiddenField)e.Row.FindControl("hdfIsFleetTeamLead");
                //string lblName = ((Label)e.Row.FindControl("lblprospName")).Text.Trim();
                //lnkBtnDelete.Attributes.Add("onclick", "javascript:return confirm('" + Resources.PFSalesResource.ProspectDeleteConfirm.Trim() + " " + lblName + "?')");
                //if (hdfFinance != null && !string.IsNullOrEmpty(hdfFinance.Value.Trim()))
                //{
                //    if (Convert.ToInt64(hdfFinance.Value.Trim()) == 1)
                //        e.Row.BackColor = System.Drawing.Color.FromName("#D6FFBC");
                //}
                //HiddenField hdfConsultant = (HiddenField)e.Row.FindControl("hdfConsultant");

                //if (hdfIsFleetTeamLead != null && !string.IsNullOrEmpty(hdfIsFleetTeamLead.Value.Trim()))
                //{
                //    if (hdfIsFleetTeamLead.Value.Trim().ToUpper() == "YES")
                //        e.Row.BackColor = System.Drawing.Color.FromName("#FFCDCD");

                //}
                //if (hdfConsultant != null && lnkbtnEdit != null)
                //{
                //    if (hdfConsultant.Value.ToString().Trim() == BasePage.UserSession.VirtualRoleId.ToString().Trim())
                //    {
                //        lnkbtnEdit.Visible = true;
                //    }
                //}
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.gvprosp_RowDataBound.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Edit Button Click. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            ClearMsg();
            Int64 TradeId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
            ViewState["TradeId"] = TradeId;
            if (TradeId > 0 && !string.IsNullOrEmpty(TradeId.ToString()))
            {
                DataTable dt1 = objProspBM.GetTradeInFromId(TradeId);
                Int64 ProspId = Convert.ToInt64(dt1.Rows[0]["ProspectId"].ToString().Trim());
                ViewState["ProspId"] = ProspId;
                DataTable dt = objProspBM.GetProspectsFromId(ProspId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    #region  Prospect
                    //if (BasePage.UserSession.RoleId != 1)
                    //    ddlFinance.Enabled = false;
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Title"].ToString().Trim()))
                        ddlTitle.SelectedValue = dt.Rows[0]["Title"].ToString().Trim();
                    txtAddName.Text = dt.Rows[0]["FName"].ToString().Trim() + " " + dt.Rows[0]["MName"].ToString().Trim() + " " + dt.Rows[0]["LName"].ToString().Trim();
                    txtAddName.Text = txtAddName.Text.Trim().Replace("  ", " ");
                    ShowEmployeeName();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FName"].ToString().Trim()))
                        txtFName.Text = dt.Rows[0]["FName"].ToString().Trim();//= ddlFName.SelectedValue
                    if (!string.IsNullOrEmpty(dt.Rows[0]["MName"].ToString().Trim()))
                        txtMName.Text = dt.Rows[0]["MName"].ToString().Trim();//= ddlMName.SelectedValue 
                    if (!string.IsNullOrEmpty(dt.Rows[0]["LName"].ToString().Trim()))
                        txtLName.Text = dt.Rows[0]["LName"].ToString().Trim();//= ddlLName.SelectedValue
                    //ddlCarMake.SelectedValue = dt.Rows[0]["CarMake"].ToString().Trim();
                    //ddlCarMake_SelectedIndexChanged(null, null);
                    hdfPhoneFormatId.Value = dt.Rows[0]["FormatedPhone"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FormatedPhone"].ToString().Trim()) && dt.Rows[0]["FormatedPhone"].ToString().Trim() != "0")
                        ddlPhFormat.SelectedValue = dt.Rows[0]["FormatedPhone"].ToString().Trim();
                    if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
                    {
                        ftePhNo.Enabled = false;
                        msePhNo.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
                        msePhNo.MaskType = AjaxControlToolkit.MaskedEditType.None;
                        msePhNo.Enabled = true;
                    }
                    else
                    {
                        ftePhNo.Enabled = true;
                        msePhNo.MaskType = AjaxControlToolkit.MaskedEditType.None;
                        msePhNo.Enabled = false;
                        msePhNo.Mask = "999999999999999999999999999999";
                    }
                    txtPhNo.Text = dt.Rows[0]["Phone"].ToString().Trim();
                    hdfMobileFormatId.Value = dt.Rows[0]["FormatedMobile"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FormatedMobile"].ToString().Trim()) && dt.Rows[0]["FormatedMobile"].ToString().Trim() != "0")
                        ddlPhFormat.SelectedValue = dt.Rows[0]["FormatedMobile"].ToString().Trim();
                    if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
                    {
                        fteMobile.Enabled = false;
                        mseMobile.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
                        mseMobile.MaskType = AjaxControlToolkit.MaskedEditType.None;
                        mseMobile.Enabled = true;
                    }
                    else
                    {
                        fteMobile.Enabled = true;
                        mseMobile.Mask = "999999999999999999999999999999";
                        mseMobile.MaskType = AjaxControlToolkit.MaskedEditType.None;
                        mseMobile.Enabled = false;
                    }
                    txtMobile.Text = dt.Rows[0]["Mobile"].ToString().Trim();
                    hdfAltContactId.Value = dt.Rows[0]["FormatedAltNo"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FormatedAltNo"].ToString().Trim()) && dt.Rows[0]["FormatedAltNo"].ToString().Trim() != "0")
                        ddlPhFormat.SelectedValue = dt.Rows[0]["FormatedAltNo"].ToString().Trim();
                    #region Hide
                    //if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")ayyaj
                    //{
                    //    fteAlteContNo.Enabled = false;
                    //    meeAltContNo.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
                    //    meeAltContNo.MaskType = AjaxControlToolkit.MaskedEditType.None;
                    //    meeAltContNo.Enabled = true;
                    //}
                    //else
                    //{
                    //    fteAlteContNo.Enabled = true;
                    //    meeAltContNo.Mask = "999999999999999999999999999999";
                    //    meeAltContNo.MaskType = AjaxControlToolkit.MaskedEditType.None;
                    //    meeAltContNo.Enabled = false;
                    //}
                    //txtAltContNo.Text = dt.Rows[0]["AltContNo"].ToString().Trim();
                    #endregion
                    hdfFaxFormatId.Value = dt.Rows[0]["FormatedFax"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FormatedFax"].ToString().Trim()) && dt.Rows[0]["FormatedFax"].ToString().Trim() != "0")
                        ddlPhFormat.SelectedValue = dt.Rows[0]["FormatedFax"].ToString().Trim();
                    if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
                    {
                        fteFax.Enabled = false;
                        mseFax.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
                        mseFax.MaskType = AjaxControlToolkit.MaskedEditType.None;
                        mseFax.Enabled = true;
                    }
                    else
                    {
                        fteFax.Enabled = true;
                        mseFax.Mask = "999999999999999999999999999999";
                        mseFax.MaskType = AjaxControlToolkit.MaskedEditType.None;
                        mseFax.Enabled = false;
                    }
                    txtFax.Text = dt.Rows[0]["Fax"].ToString().Trim();
                    txtEmail1.Text = dt.Rows[0]["Email1"].ToString().Trim();
                    txtAlterEmail.Text = dt.Rows[0]["Email2"].ToString().Trim();
                    txtAddLine1.Text = dt.Rows[0]["Add1"].ToString().Trim();
                    txtAddLine2.Text = dt.Rows[0]["Add2"].ToString().Trim();
                    txtAddLine3.Text = dt.Rows[0]["Add3"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["CountryId"].ToString().Trim()))
                        ddlCountry.SelectedValue = dt.Rows[0]["CountryId"].ToString().Trim();
                    #region Hide
                    //BindAllStates();
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["StateId"].ToString().Trim()))
                    //    ddlState.SelectedValue = dt.Rows[0]["StateId"].ToString().Trim();
                    //BindAllPostalCode();
                    ////if (!string.IsNullOrEmpty(dt.Rows[0]["PostalCode"].ToString().Trim()))
                    ////    ddlPostalCode.SelectedValue = dt.Rows[0]["PostalCode"].ToString().Trim();ayyaj
                    //BindAllCities();
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["CityId"].ToString().Trim()))
                    //    ddlCity.SelectedValue = dt.Rows[0]["CityId"].ToString().Trim();
                    ////txtPostalCode.Text = dt.Rows[0]["PostalCode"].ToString().Trim();
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["ConsultantId"].ToString().Trim()))
                    //{
                    //    ddlConsultant.SelectedValue = dt.Rows[0]["ConsultantId"].ToString().Trim();
                    //    hdfConsultID.Value = dt.Rows[0]["ConsultantId"].ToString().Trim();
                    //}
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["StatusId"].ToString().Trim()))
                    //    ddlAddStatus.SelectedValue = dt.Rows[0]["StatusId"].ToString().Trim();
                    ////if (!string.IsNullOrEmpty(dt.Rows[0]["SourceId"].ToString().Trim()))ayyaj
                    ////    ddlSource.SelectedValue = dt.Rows[0]["SourceId"].ToString().Trim();
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["MemberNo"].ToString().Trim()))
                    //    txtMemNo.Text = dt.Rows[0]["MemberNo"].ToString().Trim();
                    ////txtFConsultant.Text = dt.Rows[0]["FConsultant"].ToString().Trim();ayyaj
                    ////if (!string.IsNullOrEmpty(dt.Rows[0]["FinanceConsultantId"].ToString().Trim()))
                    ////{
                    ////    ddlFConsultant.SelectedValue = dt.Rows[0]["FinanceConsultantId"].ToString().Trim();
                    ////    hdfFConsultID.Value = dt.Rows[0]["FinanceConsultantId"].ToString().Trim();
                    ////}
                    //hdfEnquryDate.Value = dt.Rows[0]["EnquiryDate"].ToString().Trim();
                    ////txtReferredBy.Text = dt.Rows[0]["Leadsource"].ToString().Trim();ayyaj
                    ////if (!string.IsNullOrEmpty(dt.Rows[0]["Finance"].ToString().Trim()))ayyaj
                    ////    ddlFinance.SelectedValue = dt.Rows[0]["Finance"].ToString().Trim();

                    ////if (dt.Rows[0]["Finance"].ToString().Trim() == "1")
                    ////    pnlFCDetails.Visible = true;
                    ////else
                    ////    pnlFCDetails.Visible = false;

                    ////if (dt.Rows[0]["TradeIn"] != null && !string.IsNullOrEmpty(dt.Rows[0]["TradeIn"].ToString().Trim()))ayyaj
                    ////    chkTradeIn.Checked = Convert.ToBoolean(dt.Rows[0]["TradeIn"].ToString().Trim());
                    ////else
                    ////    chkTradeIn.Checked = false;
                    ////if (dt.Rows[0]["ModelId"] != null && !string.IsNullOrEmpty(dt.Rows[0]["ModelId"].ToString().Trim()))
                    ////    ddlModel.SelectedValue = dt.Rows[0]["ModelId"].ToString().Trim();
                    ////txtComments.Text = dt.Rows[0]["Comment"].ToString().Trim();ayyaj
                    //txtTradeInMakeModel.Text = dt.Rows[0]["TradeInMkModel"].ToString().Trim();
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["IsFleetLead"].ToString().Trim()))
                    //{
                    //    if (dt.Rows[0]["IsFleetLead"].ToString().Trim().ToUpper() == "YES")
                    //        hdfIsFleetLead.Value = "true";
                    //    else
                    //        hdfIsFleetLead.Value = "false";
                    //}
                    //else
                    //    hdfIsFleetLead.Value = "false";
                    ////if (!string.IsNullOrEmpty(dt.Rows[0]["WhereDidUHear"].ToString().Trim()))ayyaj
                    ////    ddlWhereDidUHear.SelectedValue = dt.Rows[0]["WhereDidUHear"].ToString().Trim();
                    ////if (!string.IsNullOrEmpty(dt.Rows[0]["Used"].ToString().Trim()))
                    ////{
                    ////    if (dt.Rows[0]["Used"].ToString().Trim().ToUpper() == "YES")
                    ////        rbtnUsed.Checked = true;
                    ////    else
                    //        rbtnNew.Checked = true;
                    //}
                    //else
                    //    rbtnNew.Checked = true;
                    //if (dt.Rows[0]["IsMailSent"].ToString().Trim().ToUpper() == "YES")
                    //    dlSendMail.Visible = false;
                    //else
                    //{
                    //    dlSendMail.Visible = true;
                    //    SetContent(dt.Rows[0]["FName"].ToString().Trim());
                    //}
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["Make"].ToString().Trim().Replace("--", "")) && ((dt.Rows[0]["MakeFromId"].ToString().Trim().ToUpper() == "OTHER") || (Convert.ToInt64(dt.Rows[0]["CarMake"].ToString().Trim())) == 0))
                    //    lblActualMakeInput.Text = "(" + dt.Rows[0]["Make"].ToString().Trim() + ")";
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["Model"].ToString().Trim().Replace("--", "")) && dt.Rows[0]["ModelFromId"].ToString().Trim().ToUpper() == "OTHER")
                    //    lblActualModelInput.Text = "(" + dt.Rows[0]["Model"].ToString().Trim() + ")";
                    #endregion

                    #endregion
                    #region  TradeIn

                    if (dt1.Rows[0]["BuildPlateDate"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["BuildPlateDate"].ToString().Trim()))
                    {
                        ddlMonthBuild.SelectedValue = Convert.ToDateTime(dt1.Rows[0]["BuildPlateDate"].ToString()).Month.ToString();
                        ddlYearBuild.SelectedValue = Convert.ToDateTime(dt1.Rows[0]["BuildPlateDate"].ToString()).Year.ToString(); ;
                    }
                    else
                    {
                        ddlMonthBuild.SelectedValue = "0";
                        ddlYearBuild.SelectedValue = "0";
                    }

                    if (dt1.Rows[0]["ComplianceDate"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["ComplianceDate"].ToString().Trim()))
                    {
                        ddlComplianceMonth.SelectedValue = Convert.ToDateTime(dt1.Rows[0]["ComplianceDate"].ToString()).Month.ToString();
                        ddlComplianceYear.SelectedValue = Convert.ToDateTime(dt1.Rows[0]["ComplianceDate"].ToString()).Year.ToString();
                    }
                    else
                    {
                        ddlComplianceMonth.SelectedValue = "0";
                        ddlComplianceYear.SelectedValue = "0";
                    }
                    
                     


                    ddlCarMake.SelectedValue = dt1.Rows[0]["MakeId"].ToString().Trim();
                    ddlCarMake_SelectedIndexChanged(null, null);
                    if (dt1.Rows[0]["ModelId"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["ModelId"].ToString().Trim()))
                        ddlModel.SelectedValue = dt1.Rows[0]["ModelId"].ToString().Trim();
                    txtSeries.Text = dt1.Rows[0]["Series"].ToString().Trim();


                    //DataTable DtT = objProspBM.GetTradeInCount(objProsp.ProspId);
                    //if (DtT != null && DtT.Rows.Count > 0)
                    //    objTradeIn.TradeInNo = Convert.ToInt32(DtT.Rows[0]["TradeInCount"]) + 1;
                    txtSeries.Text = dt1.Rows[0]["Series"].ToString().Trim();
                    txtEngineType.Text = dt1.Rows[0]["EngineType"].ToString().Trim();
                    txtOdometer.Text = dt1.Rows[0]["Odometer"].ToString().Trim();
                    txtTransmission.Text = dt1.Rows[0]["Transmission"].ToString().Trim();
                    txtBodyStyle.Text = dt1.Rows[0]["BodyStyle"].ToString().Trim();
                    txtExtColor.Text = dt1.Rows[0]["ExteriorColor"].ToString().Trim();
                    txtIntTrimColor.Text = dt1.Rows[0]["InteriorColor"].ToString().Trim();
                    txtRegoExpires.Text = dt1.Rows[0]["RegoExpires"].ToString().Trim();
                    txtOtherOptions.Text = dt1.Rows[0]["OtherOptions"].ToString().Trim();
                    ddlGlasswork.SelectedValue = dt1.Rows[0]["GlassWork"].ToString().Trim();
                    ddlEngine.SelectedValue = dt1.Rows[0]["Engine"].ToString().Trim();
                    ddlBodyPanels.SelectedValue = dt1.Rows[0]["BodyPanels"].ToString().Trim();
                    ddlTransmission.SelectedValue = dt1.Rows[0]["TransmissionDetails"].ToString().Trim();
                    ddlPaint.SelectedValue = dt1.Rows[0]["Paint"].ToString().Trim();
                    ddlBrakes.SelectedValue = dt1.Rows[0]["Breaks"].ToString().Trim();
                    ddlTyres.SelectedValue = dt1.Rows[0]["Tyres"].ToString().Trim();
                    ddlAC.SelectedValue = dt1.Rows[0]["ACDetails"].ToString().Trim();
                    ddlRimsAlloys.SelectedValue = dt1.Rows[0]["RimAlloysDetails"].ToString().Trim();
                    ddlHeadlights.SelectedValue = dt1.Rows[0]["Headlights"].ToString().Trim();
                    ddlUpholstery.SelectedValue = dt1.Rows[0]["Upholstery"].ToString().Trim();
                    ddlSpareTyre.SelectedValue = dt1.Rows[0]["SpareTyre"].ToString().Trim();
                    txtDescDent.Text = dt1.Rows[0]["VehicleCondition"].ToString().Trim();
                    txtAccident.Text = dt1.Rows[0]["DamageDetails"].ToString().Trim();
                    txtRepalce.Text = dt1.Rows[0]["TyreHistory"].ToString().Trim();
                    ddlLogBook.SelectedValue = dt1.Rows[0]["ServiceHistory"].ToString().Trim();
                    txtPayout.Text = dt1.Rows[0]["Payout"].ToString().Trim();
                    txtAnything.Text = dt1.Rows[0]["OtherDescription"].ToString().Trim();
                    ddlWheelsAlloys.SelectedValue = dt1.Rows[0]["WheelsAlloys"].ToString().Trim();
                    ddlFuelType.SelectedValue = dt1.Rows[0]["FuelType"].ToString().Trim();
                    ddlDoor.SelectedValue = dt1.Rows[0]["Door"].ToString().Trim();
                    ddlRating.SelectedValue = dt1.Rows[0]["RateCondition"].ToString().Trim();
                    ddlOwners.SelectedValue = dt1.Rows[0]["Owners"].ToString().Trim();
                    if (dt1.Rows[0]["IsReverseSensor"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsReverseSensor"].ToString().Trim()))
                        chkRevSensor.Checked = Convert.ToBoolean(dt1.Rows[0]["IsReverseSensor"].ToString().Trim());
                    else
                        chkRevSensor.Checked = false;
                    

                    if (dt1.Rows[0]["IsXenonLights"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsXenonLights"].ToString().Trim()))
                        chkXenonLights.Checked = Convert.ToBoolean(dt1.Rows[0]["IsXenonLights"].ToString().Trim());
                    else
                        chkXenonLights.Checked = false;

                    if (dt1.Rows[0]["IsProtectionProduct"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsProtectionProduct"].ToString().Trim()))
                        chkProtectProduct.Checked = Convert.ToBoolean(dt1.Rows[0]["IsProtectionProduct"].ToString().Trim());
                    else
                        chkProtectProduct.Checked = false;

                    if (dt1.Rows[0]["IsActiveCruiseControl"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsActiveCruiseControl"].ToString().Trim()))
                        chkActCruiseControl.Checked = Convert.ToBoolean(dt1.Rows[0]["IsActiveCruiseControl"].ToString().Trim());
                    else
                        chkActCruiseControl.Checked = false;

                    if (dt1.Rows[0]["IsTowBar"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsTowBar"].ToString().Trim()))
                        chkTowBar.Checked = Convert.ToBoolean(dt1.Rows[0]["IsTowBar"].ToString().Trim());
                    else
                        chkTowBar.Checked = false;

                    if (dt1.Rows[0]["IsElectricSeats"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsElectricSeats"].ToString().Trim()))
                        chkElectricSeats.Checked = Convert.ToBoolean(dt1.Rows[0]["IsElectricSeats"].ToString().Trim());
                    else
                        chkElectricSeats.Checked = false;


                    if (dt1.Rows[0]["IsBullBar"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsBullBar"].ToString().Trim()))
                        chkBullBar.Checked = Convert.ToBoolean(dt1.Rows[0]["IsBullBar"].ToString().Trim());
                    else
                        chkBullBar.Checked = false;

                    if (dt1.Rows[0]["IsTint"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsTint"].ToString().Trim()))
                        chkTint.Checked = Convert.ToBoolean(dt1.Rows[0]["IsTint"].ToString().Trim());
                    else
                        chkTint.Checked = false;

                    if (dt1.Rows[0]["IsSunroof"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsSunroof"].ToString().Trim()))
                        chkSunroof.Checked = Convert.ToBoolean(dt1.Rows[0]["IsSunroof"].ToString().Trim());
                    else
                        chkSunroof.Checked = false;

                    if (dt1.Rows[0]["IsPanoramic"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsPanoramic"].ToString().Trim()))
                        chkPanoramic.Checked = Convert.ToBoolean(dt1.Rows[0]["IsPanoramic"].ToString().Trim());
                    else
                        chkPanoramic.Checked = false;

                    if (dt1.Rows[0]["IsRoofRacks"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsRoofRacks"].ToString().Trim()))
                        chkRoofRacks.Checked = Convert.ToBoolean(dt1.Rows[0]["IsRoofRacks"].ToString().Trim());
                    else
                        chkRoofRacks.Checked = false;

                    if (dt1.Rows[0]["IsTV"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsTV"].ToString().Trim()))
                        chkTV.Checked = Convert.ToBoolean(dt1.Rows[0]["IsTV"].ToString().Trim());
                    else
                        chkTV.Checked = false;

                    if (dt1.Rows[0]["IsLeather"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsLeather"].ToString().Trim()))
                        chkLeather.Checked = Convert.ToBoolean(dt1.Rows[0]["IsLeather"].ToString().Trim());
                    else
                        chkLeather.Checked = false;

                    if (dt1.Rows[0]["IsSideSteps"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsSideSteps"].ToString().Trim()))
                        chkSideSteps.Checked = Convert.ToBoolean(dt1.Rows[0]["IsSideSteps"].ToString().Trim());
                    else
                        chkSideSteps.Checked = false;

                    if (dt1.Rows[0]["IsSatNav"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsSatNav"].ToString().Trim()))
                        chkSatNav.Checked = Convert.ToBoolean(dt1.Rows[0]["IsSatNav"].ToString().Trim());
                    else
                        chkSatNav.Checked = false;

                    if (dt1.Rows[0]["IsThirdRowSeats"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsThirdRowSeats"].ToString().Trim()))
                        chkThirdRowSeats.Checked = Convert.ToBoolean(dt1.Rows[0]["IsThirdRowSeats"].ToString().Trim());
                    else
                        chkThirdRowSeats.Checked = false;

                    if (dt1.Rows[0]["IsTimingBeltChanged"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsTimingBeltChanged"].ToString().Trim()))
                        chkTimingBeltChange.Checked = Convert.ToBoolean(dt1.Rows[0]["IsTimingBeltChanged"].ToString().Trim());
                    else
                        chkTimingBeltChange.Checked = false;

                    if (dt1.Rows[0]["IsLaneChangeAssist"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsLaneChangeAssist"].ToString().Trim()))
                        chkLaneChangeAssist.Checked = Convert.ToBoolean(dt1.Rows[0]["IsLaneChangeAssist"].ToString().Trim());
                    else
                        chkLaneChangeAssist.Checked = false;

                    if (dt1.Rows[0]["IsBluetoothFactory"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsBluetoothFactory"].ToString().Trim()))
                        chkBluetoothFactory.Checked = Convert.ToBoolean(dt1.Rows[0]["IsBluetoothFactory"].ToString().Trim());
                    else
                        chkBluetoothFactory.Checked = false;


                    if (dt1.Rows[0]["IsReverseCamera"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsReverseCamera"].ToString().Trim()))
                        chkReverseCamera.Checked = Convert.ToBoolean(dt1.Rows[0]["IsReverseCamera"].ToString().Trim());
                    else
                        chkReverseCamera.Checked = false;


                    if (dt1.Rows[0]["IsFourByFour"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsFourByFour"].ToString().Trim()))
                        chkFourByFour.Checked = Convert.ToBoolean(dt1.Rows[0]["IsFourByFour"].ToString().Trim());
                    else
                        chkFourByFour.Checked = false;


                    if (dt1.Rows[0]["IsTwoByTwo"] != null && !string.IsNullOrEmpty(dt1.Rows[0]["IsTwoByTwo"].ToString().Trim()))
                        chkTwoByTwo.Checked = Convert.ToBoolean(dt1.Rows[0]["IsTwoByTwo"].ToString().Trim());
                    else
                        chkTwoByTwo.Checked = false;
                    

                    #endregion

                    lnkbtnSave.Visible = false;
                    lnkbtnUpdate.Visible = true;
                   
                    lnkbtnFinalClear.Text = Resources.PFSalesResource.Cancel.Trim();
                    lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.BackToSearch.Trim();
                    lblAddProspHead.Text = Resources.PFSalesResource.UpdateTradeInDet.Trim();
                    #region Hide
                    //lnkbtnSave.Text = Resources.PFSalesResource.update.Trim();
                    //lnkbtnSave.ToolTip = Resources.PFSalesResource.UpdteProspDetails.Trim();
                    //ddlFinance.Enabled = false;

                    //DataTable DtProspCont = objProspBM.GetProspConDetailFromProspId(EmpId);
                    //foreach (DataRow dwrow in DtProspCont.Rows)
                    //{
                    //    foreach (GridViewRow grviewrow in gvContact.Rows)
                    //    {
                    //        CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkSelect");
                    //        RadioButton rbtn = (RadioButton)grviewrow.FindControl("rbtnIsPrimary");
                    //        HiddenField hdfContactId = (HiddenField)grviewrow.FindControl("hdfContactId");
                    //        HiddenField hdfProspContId = (HiddenField)grviewrow.FindControl("hdfProspContId");
                    //        if (chkbx != null && rbtn != null && hdfProspContId != null && hdfContactId != null)
                    //        {
                    //            if (Convert.ToInt64(hdfContactId.Value.Trim()) == Convert.ToInt64(dwrow["ContactId"].ToString().Trim()))
                    //            {
                    //                chkbx.Checked = true;
                    //                if (Boolean.Parse(dwrow["IsPrimary"].ToString().Trim()))
                    //                    rbtn.Enabled = rbtn.Checked = true;

                    //                else
                    //                    rbtn.Enabled = rbtn.Checked = false;
                    //            }
                    //            else
                    //            {
                    //                rbtn.Checked = chkbx.Checked = false;
                    //                rbtn.Enabled = false;
                    //            }
                    //        }
                    //    }
                    //}
                    #endregion
                    pnlAddProsp.Visible = true;
                    pnlSearchprosp.Visible = false;
                    ddlTitle.Focus();

                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.lnkbtnEdit_Click Error:" + ex.StackTrace);

        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Delete Button Click. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Int64 ProspId = Int64.Parse(((LinkButton)sender).CommandArgument.Trim());
            Int64 Result = 0;
            DataTable dt = objProspBM.GetProspectsFromId(ProspId);
            if (dt != null && dt.Rows.Count > 0)
            {
                objProsp.ProspId = ProspId;
                objProsp.ProspKey = dt.Rows[0]["ProspKey"].ToString().Trim();
                objProsp.Title = Convert.ToInt32(dt.Rows[0]["Title"].ToString().Trim());
                objProsp.FName = dt.Rows[0]["FName"].ToString().Trim();
                objProsp.MName = dt.Rows[0]["MName"].ToString().Trim();
                objProsp.LName = dt.Rows[0]["LName"].ToString().Trim();
                objProsp.CarMake = Convert.ToInt32(dt.Rows[0]["CarMake"].ToString().Trim());
                objProsp.Phone = dt.Rows[0]["Phone"].ToString().Trim();
                objProsp.Mobile = dt.Rows[0]["Mobile"].ToString().Trim();
                objProsp.AltContact = dt.Rows[0]["AltContNo"].ToString().Trim();
                objProsp.Fax = dt.Rows[0]["Fax"].ToString().Trim();
                objProsp.Email = dt.Rows[0]["Email1"].ToString().Trim();
                objProsp.Email1 = dt.Rows[0]["Email2"].ToString().Trim();
                objProsp.Add1 = dt.Rows[0]["Add1"].ToString().Trim();
                objProsp.Add2 = dt.Rows[0]["Add2"].ToString().Trim();
                objProsp.Add3 = dt.Rows[0]["Add3"].ToString().Trim();
                objProsp.CityId = Convert.ToInt64(dt.Rows[0]["CityId"].ToString().Trim());
                objProsp.PostalCode = dt.Rows[0]["PostalCode"].ToString().Trim();
                objProsp.ConsultId = Convert.ToInt64(dt.Rows[0]["ConsultantId"].ToString().Trim());
                objProsp.MemberNo = dt.Rows[0]["MemberNo"].ToString().Trim();
                objProsp.FConsultant = dt.Rows[0]["FConsultant"].ToString().Trim();
                objProsp.StatusId = Convert.ToInt64(dt.Rows[0]["StatusId"].ToString().Trim());
                objProsp.SourceId = Convert.ToInt64(dt.Rows[0]["SourceId"].ToString().Trim());
                objProsp.CreatedById = BasePage.UserSession.VirtualRoleId;
                objProsp.IsDeleted = true;
                //List<ProspectContacts> lstprospCont = new List<ProspectContacts>();
                //DataTable DtProspCont = objProspBM.GetProspConDetailFromProspId(ProspId);
                //foreach (DataRow grviewrow in DtProspCont.Rows)
                //{
                //    ProspectContacts objProspContact = new ProspectContacts();

                //    objProspContact.ProspContactId = Convert.ToInt64(grviewrow["Id"].ToString().Trim());
                //    if (Boolean.Parse(grviewrow["IsPrimary"].ToString().Trim()))
                //        objProspContact.IsPrimary = true;
                //    else
                //        objProspContact.IsPrimary = false;
                //    objProspContact.ContactId = Convert.ToInt64(grviewrow["ContactId"].ToString().Trim());
                //    lstprospCont.Add(objProspContact);
                //}
                //objProsp.LstProspContact = lstprospCont;
                Result = objProspBM.DeleteProspect(objProsp);
                if (Result > 0)
                {
                    lblSerSucMsg.Text = Resources.PFSalesResource.RecordDeleted.Trim();
                    lblSerErrMsg.Text = string.Empty;
                    dvadderror.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                    dvaserSuccess.Visible = true;
                }
                else if (Result == -9)
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.refrentialIntegrity.Trim();
                    lblSerSucMsg.Text = string.Empty;
                    dvaserSuccess.Visible = dvadderror.Visible = dvaddSucc.Visible = false;
                    dvsererror.Visible = true;
                }
                else
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.RecordNotDeleted.Trim();
                    lblSerSucMsg.Text = string.Empty;
                    dvaserSuccess.Visible = dvadderror.Visible = dvaddSucc.Visible = false;
                    dvsererror.Visible = true;
                }
                txtserprospName.Focus();
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.lnkbtnDelete_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Search Button Click. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Clear Button Click. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnClear_Click(object sender, EventArgs e)
    {
        txtserprospName.Text = string.Empty;
        ddlStatus.SelectedValue = "0";
        txtserprospName.Focus();
        BindGrid();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Selected Index Changed Event Of Status's Drop Down List. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
        ClearMsg();

    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Back To Search Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnBackToSearch_Click(object sender, EventArgs e)
    {
        //ViewState["ProspId"] = 0;
        //BindGrid();
        //pnlSearchprosp.Visible = true;
        //pnlAddProsp.Visible = false;
        ClearMsg();
        //txtserprospName.Focus();
       Int64 ProspectId=Convert.ToInt64(ViewState["ProspectId"].ToString());
        Response.Redirect("ManageActivities.aspx?ProspectId=" + ProspectId.ToString().Trim());
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Mobile Format Pop Up Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnMobile_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hdfMobileFormatId.Value.Trim()))
            ddlPhFormat.SelectedValue = hdfMobileFormatId.Value.Trim();
        else
            BindFormats();
        ClearMsg();
        if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
        {
            ftePhPopUpPhNo.Enabled = false;
            msePhPopUp.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
            msePhPopUp.MaskType = AjaxControlToolkit.MaskedEditType.None;
            msePhPopUp.Enabled = true;
        }
        else
        {
            ftePhPopUpPhNo.Enabled = true;
            msePhPopUp.MaskType = AjaxControlToolkit.MaskedEditType.None;
            msePhPopUp.Mask = "999999999999999999999999999999";
            msePhPopUp.Enabled = false;
        }
        ddlPhPopUpCountry.Focus();
        txtPhPopUpPhoNo.Text = txtMobile.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
        pnlphonePopUp.Visible = true;
        hdfPhPopType.Value = "MOBILE";
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Phone Format Pop Up Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnPhPopUp_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hdfPhoneFormatId.Value.Trim()))
            ddlPhFormat.SelectedValue = hdfPhoneFormatId.Value.Trim();
        else
            BindFormats();
        if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
        {
            ftePhPopUpPhNo.Enabled = false;
            msePhPopUp.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
            msePhPopUp.MaskType = AjaxControlToolkit.MaskedEditType.None;
            msePhPopUp.Enabled = true;
        }
        else
        {
            ftePhPopUpPhNo.Enabled = true;
            msePhPopUp.MaskType = AjaxControlToolkit.MaskedEditType.None;
            msePhPopUp.Mask = "999999999999999999999999999999";
            msePhPopUp.Enabled = false;
        }
        ddlPhPopUpCountry.Focus();
        txtPhPopUpPhoNo.Text = txtPhNo.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", ""); ;
        pnlphonePopUp.Visible = true;
        ClearMsg();
        hdfPhPopType.Value = "PHONE";
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Phone Format Pop Up Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFax_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hdfFaxFormatId.Value.Trim()))
            ddlPhFormat.SelectedValue = hdfFaxFormatId.Value.Trim();
        else
            BindFormats();
        if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
        {
            ftePhPopUpPhNo.Enabled = false;
            msePhPopUp.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
            msePhPopUp.MaskType = AjaxControlToolkit.MaskedEditType.None;
            msePhPopUp.Enabled = true;
        }
        else
        {
            ftePhPopUpPhNo.Enabled = true;
            msePhPopUp.MaskType = AjaxControlToolkit.MaskedEditType.None;
            msePhPopUp.Mask = "999999999999999999999999999999";
            msePhPopUp.Enabled = false;
        }
        ddlPhPopUpCountry.Focus();
        txtPhPopUpPhoNo.Text = txtFax.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
        pnlphonePopUp.Visible = true;
        ClearMsg();
        hdfPhPopType.Value = "FAX";
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Selected Index Changed Event Of Country's Drop Down List 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindAllStates();
        BindAllPostalCode();
        ddlPostalCode_SelectedIndexChanged(null, null);
        BindAllCities();
        ClearMsg();
        //ddlState.Focus();

    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Selected Index Changed Event Of State's Drop Down List 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindAllPostalCode();
        ClearMsg();
        //ddlPostalCode_SelectedIndexChanged(null, null);
        BindAllCities();
        //ddlPostalCode.Focus();

    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// 
    /// Created Date: 22 Feb 2014
    /// Description: Save Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["ProspId"] = 0;
            //ShowEmployeeName();
            Int64 Result = 0;
           
            if (ViewState["ProspectId"] != null && BasePage.UserSession != null)
            {
                objProsp.ProspId = Convert.ToInt64(ViewState["ProspectId"].ToString().Trim());
                objTradeIn.ProspectId = Convert.ToInt64(ViewState["ProspectId"].ToString().Trim());
                Guid gi = Guid.NewGuid();
                objProsp.ProspKey = gi.ToString().Trim();
                objProsp.Title = Convert.ToInt32(ddlTitle.SelectedValue.Trim());
                //if (ddlFName.SelectedValue.Trim().ToLower() != Resources.PFSalesResource.ddlSelect.Trim().ToLower())
                if (!string.IsNullOrEmpty(txtFName.Text.Trim()))
                {
                    string str = txtFName.Text.Trim().Substring(0, 1);
                    str = str.ToUpper();
                    objProsp.FName = (str.Trim() + txtFName.Text.Trim().Remove(0, 1)).Trim();// ddlFName.SelectedValue.Trim().Replace("  ", " ");
                }
                else
                    objProsp.FName = string.Empty;
                //if (ddlMName.SelectedValue.Trim().ToLower() != Resources.PFSalesResource.ddlSelect.Trim().ToLower())
                if (!string.IsNullOrEmpty(txtMName.Text.Trim()))
                {
                    string str = txtMName.Text.Trim().Substring(0, 1);
                    str = str.ToUpper();
                    objProsp.MName = (str.Trim() + txtMName.Text.Trim().Remove(0, 1)).Trim();// ddlMName.SelectedValue.Trim().Replace("  ", " ");
                }
                else
                    objProsp.MName = string.Empty;
                //if (ddlLName.SelectedValue.Trim().ToLower() != Resources.PFSalesResource.ddlSelect.Trim().ToLower())
                if (!string.IsNullOrEmpty(txtLName.Text.Trim()))
                {
                    string str = txtLName.Text.Trim().Substring(0, 1);
                    str = str.ToUpper();
                    objProsp.LName = (str.Trim() + txtLName.Text.Trim().Remove(0, 1)).Trim();// ddlLName.SelectedValue.Trim().Replace("  ", " ");
                }
                else
                    objProsp.LName = string.Empty;//ddlLName.SelectedValue.Trim().Replace("  ", " ");
                objProsp.CarMake = Convert.ToInt32(ddlCarMake.SelectedValue.Trim());
                objTradeIn.Make = ddlCarMake.SelectedItem.Text.Trim();
                objTradeIn.MakeId = Convert.ToInt32(ddlCarMake.SelectedValue.Trim());
                objProsp.Phone = txtPhNo.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
                if (!string.IsNullOrEmpty(hdfPhoneFormatId.Value.Trim()))
                    objProsp.formatedPhoNo = Convert.ToInt64(hdfPhoneFormatId.Value.Trim());
                else
                    objProsp.formatedPhoNo = Convert.ToInt64(ddlPhFormat.SelectedValue.Trim());
                objProsp.Mobile = txtMobile.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
                if (!string.IsNullOrEmpty(hdfMobileFormatId.Value.Trim()))
                    objProsp.formatedMobNo = Convert.ToInt64(hdfMobileFormatId.Value.Trim());
                else
                    objProsp.formatedMobNo = Convert.ToInt64(ddlPhFormat.SelectedValue.Trim());
                //objProsp.AltContact = txtAltContNo.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");ayyaj
                if (!string.IsNullOrEmpty(hdfAltContactId.Value.Trim()))
                    objProsp.formatedAltCon = Convert.ToInt64(hdfAltContactId.Value.Trim());
                else
                    objProsp.formatedAltCon = Convert.ToInt64(ddlPhFormat.SelectedValue.Trim());
                objProsp.Fax = txtFax.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
                if (!string.IsNullOrEmpty(hdfFaxFormatId.Value.Trim()))
                    objProsp.formatedFax = Convert.ToInt64(hdfFaxFormatId.Value.Trim());
                else
                    objProsp.formatedFax = Convert.ToInt64(ddlPhFormat.SelectedValue.Trim());
                objProsp.Email = txtEmail1.Text.Trim();
                objProsp.Email1 = txtAlterEmail.Text.Trim();
                objProsp.Add1 = txtAddLine1.Text.Trim();
                objProsp.Add2 = txtAddLine2.Text.Trim();
                objProsp.Add3 = txtAddLine3.Text.Trim();
                objProsp.MemberNo = txtMemNo.Text.Trim();
                objProsp.FConsultant = "FConsultant";//ayyajtxtFConsultant.Text.Trim()
                objProsp.FConsultId = 111;//ayyajConvert.ToInt64(ddlFConsultant.SelectedValue.Trim())
                objProsp.ConsultId = Convert.ToInt64(ddlConsultant.SelectedValue.Trim());
                objProsp.StatusId = Convert.ToInt64(ddlAddStatus.SelectedValue.Trim());
                objProsp.StateId = Convert.ToInt32(ddlState.SelectedValue.Trim());
                objProsp.SourceId = 11;//ayyajConvert.ToInt64(ddlSource.SelectedValue.Trim())
                objProsp.CityId = Convert.ToInt64(ddlCity.SelectedValue.Trim());
                objProsp.PostalCode = "4500";//ayyajddlPostalCode.SelectedValue.Trim()
                objProsp.Finance = 2;//ayyajConvert.ToInt16(ddlFinance.SelectedValue.Trim())
                objProsp.LeadSource = "ReferredBy";//ayyajtxtReferredBy.Text.Trim();
                objProsp.CreatedById = BasePage.UserSession.VirtualRoleId;
                objProsp.IsDeleted = false;
                objTradeIn.IsDeleted = false;
                objProsp.ModelId = Convert.ToInt32(ddlModel.SelectedValue.Trim());
                objTradeIn.ModelId = Convert.ToInt32(ddlModel.SelectedValue.Trim());
                objProsp.Model = ddlModel.SelectedItem.Text.Trim();//ayyajddlModel.SelectedItem.Text.Trim()
                objTradeIn.Model = ddlModel.SelectedItem.Text.Trim();
                //Desc:When CarMake And Model Not Selected Then Assign 'Other' :Ayyaj---------
                ListItem lst = ddlCarMake.Items.FindByText("OTHER");
                string lstVal = lst.Value;
                if (!string.IsNullOrEmpty(lst.Value.Trim()))
                {
                    if (objProsp.CarMake == 0)
                    {
                        //ListItem lst = ddlCarMake.Items.FindByText("OTHER");
                        //string lstVal = lst.Value;
                        DataTable Dt = objMstBM.GetModelFromMakeId(Convert.ToInt32(lstVal.Trim()));
                        DataView Dv = Dt.DefaultView;
                        Dv.RowFilter = "Model='OTHER'";
                        int valModelId = Convert.ToInt32((Dv.ToTable().Rows[0][0]));
                        string valModel = Convert.ToString((Dv.ToTable().Rows[0][1]));
                        objProsp.CarMake = Convert.ToInt32(lstVal.Trim());
                        objProsp.ModelId = valModelId;
                        objProsp.Model = valModel;
                        objTradeIn.ModelId = valModelId;
                        objTradeIn.Model = valModel;


                    }
                    else
                    {
                        if (objProsp.ModelId == 0)
                        {

                            DataTable Dt = objMstBM.GetModelFromMakeId(Convert.ToInt32(lstVal.Trim()));
                            DataView Dv = Dt.DefaultView;
                            Dv.RowFilter = "Model='Other'";
                            int valModelId = Convert.ToInt32((Dv.ToTable().Rows[0][0]));
                            string valModel = Convert.ToString((Dv.ToTable().Rows[0][1]));
                            objProsp.ModelId = valModelId;
                            objProsp.Model = valModel;
                            objTradeIn.ModelId = valModelId;
                            objTradeIn.Model = valModel;
                        }
                        else
                        {
                            objProsp.Model = ddlModel.SelectedItem.Text.Trim();
                            objTradeIn.Model = ddlModel.SelectedItem.Text.Trim();

                        }

                    }
                }
                //if (!string.IsNullOrEmpty(txtBuildPlateDate.Text.Replace("__/__/____", "")))
                //    objTradeIn.BuildPlateDate = Convert.ToDateTime(txtBuildPlateDate.Text.Trim());
                //if (!string.IsNullOrEmpty(txtComplianceDate.Text.Replace("__/__/____", "")))
                //    objTradeIn.ComplianceDate = Convert.ToDateTime(txtComplianceDate.Text.Trim());
                string BuildDt = null;
                string ComplianceDt = null;

                if (ddlComplianceMonth.SelectedIndex <= 9)
                    ComplianceDt = "0" + ddlComplianceMonth.SelectedIndex.ToString();
                else
                    ComplianceDt = ddlComplianceMonth.SelectedIndex.ToString();
                ComplianceDt = Convert.ToString(ComplianceDt + "/" + ddlComplianceYear.SelectedItem);
                objTradeIn.ComplianceDate = Convert.ToDateTime(ComplianceDt); 


                if (ddlMonthBuild.SelectedIndex <= 9)
                    BuildDt = "0" + ddlMonthBuild.SelectedIndex.ToString();
                else
                    BuildDt = ddlMonthBuild.SelectedIndex.ToString();

                BuildDt = Convert.ToString(BuildDt + "/" + ddlYearBuild.SelectedItem);
                objTradeIn.BuildPlateDate = Convert.ToDateTime(BuildDt); 

                DataTable DtT = objProspBM.GetTradeInCount(objProsp.ProspId);
                if (DtT != null && DtT.Rows.Count > 0)
                    objTradeIn.TradeInNo = Convert.ToInt32(DtT.Rows[0]["TradeInCount"]) + 1;
                objTradeIn.Series = txtSeries.Text.Trim();
                objTradeIn.EngineType = txtEngineType.Text.Trim();
                objTradeIn.Odometer = txtOdometer.Text.Trim();
                objTradeIn.Transmission = txtTransmission.Text.Trim();
                objTradeIn.BodyStyle = txtBodyStyle.Text.Trim();
                objTradeIn.ExteriorColor = txtExtColor.Text.Trim();
                objTradeIn.InteriorColor = txtIntTrimColor.Text.Trim();
                objTradeIn.RegoExpires = txtRegoExpires.Text.Trim();
                objTradeIn.OtherOptions = txtOtherOptions.Text.Trim();
                objTradeIn.GlassWork = ddlGlasswork.SelectedValue.Trim();
                objTradeIn.Engine = ddlEngine.SelectedValue.Trim();
                objTradeIn.BodyPanels = ddlBodyPanels.SelectedValue.Trim();
                objTradeIn.TransmissionDetails = ddlTransmission.SelectedValue.Trim();
                objTradeIn.Paint = ddlPaint.SelectedValue.Trim();
                objTradeIn.Breaks = ddlBrakes.SelectedValue.Trim();
                objTradeIn.Tyres = ddlTyres.SelectedValue.Trim();
                objTradeIn.ACDetails = ddlAC.SelectedValue.Trim();
                objTradeIn.RimAlloysDetails = ddlRimsAlloys.SelectedValue.Trim();
                objTradeIn.Headlights = ddlHeadlights.SelectedValue.Trim();
                objTradeIn.Upholstery = ddlUpholstery.SelectedValue.Trim();
                objTradeIn.SpareTyre = ddlSpareTyre.SelectedValue.Trim();
                objTradeIn.VehicleCondition = txtDescDent.Text.Trim();
                objTradeIn.DamageDetails = txtAccident.Text.Trim();
                objTradeIn.TyreHistory = txtRepalce.Text.Trim();
                objTradeIn.ServiceHistory = ddlLogBook.SelectedValue.Trim();
                objTradeIn.Payout = txtPayout.Text.Trim();
                objTradeIn.OtherDescription = txtAnything.Text.Trim();
                objTradeIn.WheelsAlloys = ddlWheelsAlloys.SelectedValue.Trim();
                objTradeIn.FuelType = ddlFuelType.SelectedValue.Trim();
                objTradeIn.Door = ddlDoor.SelectedValue.Trim();
                objTradeIn.RateCondition = Convert.ToInt32(ddlRating.SelectedValue.Trim());
                objTradeIn.Owners = Convert.ToInt32(ddlOwners.SelectedValue.Trim());

                if (chkRevSensor.Checked)
                    objTradeIn.IsReverseSensor = true;
                else
                    objTradeIn.IsReverseSensor = false;

                if (chkXenonLights.Checked)
                    objTradeIn.IsXenonLights = true;
                else
                    objTradeIn.IsXenonLights = false;

                if (chkProtectProduct.Checked)
                    objTradeIn.IsProtectionProduct = true;
                else
                    objTradeIn.IsProtectionProduct = false;

                if (chkActCruiseControl.Checked)
                    objTradeIn.IsActiveCruiseControl = true;
                else
                    objTradeIn.IsActiveCruiseControl = false;

                if (chkTowBar.Checked)
                    objTradeIn.IsTowBar = true;
                else
                    objTradeIn.IsTowBar = false;

                if (chkElectricSeats.Checked)
                    objTradeIn.IsElectricSeats = true;
                else
                    objTradeIn.IsElectricSeats = false;

                if (chkBullBar.Checked)
                    objTradeIn.IsBullBar = true;
                else
                    objTradeIn.IsBullBar = false;

                if (chkTint.Checked)
                    objTradeIn.IsTint = true;
                else
                    objTradeIn.IsTint = false;

                if (chkSunroof.Checked)
                    objTradeIn.IsSunroof = true;
                else
                    objTradeIn.IsSunroof = false;

                if (chkPanoramic.Checked)
                    objTradeIn.IsPanoramic = true;
                else
                    objTradeIn.IsPanoramic = false;

                if (chkRoofRacks.Checked)
                    objTradeIn.IsRoofRacks = true;
                else
                    objTradeIn.IsRoofRacks = false;

                if (chkTV.Checked)
                    objTradeIn.IsTV = true;
                else
                    objTradeIn.IsTV = false;

                if (chkLeather.Checked)
                    objTradeIn.IsLeather = true;
                else
                    objTradeIn.IsLeather = false;

                if (chkSideSteps.Checked)
                    objTradeIn.IsSideSteps = true;
                else
                    objTradeIn.IsSideSteps = false;

                if (chkSatNav.Checked)
                    objTradeIn.IsSatNav = true;
                else
                    objTradeIn.IsSatNav = false;

                if (chkThirdRowSeats.Checked)
                    objTradeIn.IsThirdRowSeats = true;
                else
                    objTradeIn.IsThirdRowSeats = false;

                if (chkTimingBeltChange.Checked)
                    objTradeIn.IsTimingBeltChanged = true;
                else
                    objTradeIn.IsTimingBeltChanged = false;

                if (chkLaneChangeAssist.Checked)
                    objTradeIn.IsLaneChangeAssist = true;
                else
                    objTradeIn.IsLaneChangeAssist = false;

                if (chkBluetoothFactory.Checked)
                    objTradeIn.IsBluetoothFactory = true;
                else
                    objTradeIn.IsBluetoothFactory = false;

                if (chkReverseCamera.Checked)
                    objTradeIn.IsReverseCamera = true;
                else
                    objTradeIn.IsReverseCamera = false;

                if (chkFourByFour.Checked)
                    objTradeIn.IsFourByFour = true;
                else
                    objTradeIn.IsFourByFour = false;

                if (chkTwoByTwo.Checked)
                    objTradeIn.IsTwoByTwo = true;
                else
                    objTradeIn.IsTwoByTwo = false;
                #region Hide
                //objTradeIn.IsAC;--Removed
                //objTradeIn.IsReverseSensor;
                //objTradeIn.IsABS;--Removed
                //objTradeIn.IsXenonLights;
                //objTradeIn.IsPowerSteer;--Removed
                //objTradeIn.IsProtectionProduct;
                //objTradeIn.IsActiveCruiseControl;
                //objTradeIn.IsTowBar;
                //objTradeIn.IsPowerWindows;--Removed
                //objTradeIn.IsElectricSeats;
                //objTradeIn.IsBullBar;
                //objTradeIn.IsCentralLocking;--Removed
                //objTradeIn.IsTint;
                //objTradeIn.IsSunroof;
                //objTradeIn.IsRoofRacks;
                //objTradeIn.IsPanoramic;
                //objTradeIn.IsTV;
                //objTradeIn.IsLeather;
                //objTradeIn.IsSideSteps;
                //objTradeIn.IsSatNav;
                //objTradeIn.IsAlarm;--Removed
                //objTradeIn.IsThirdRowSeats;
                ////objTradeIn.IsDeleted;--
                //objTradeIn.IsPanoramic;
                //objTradeIn.IsTimingBeltChanged;
                //objTradeIn.IsLaneChangeAssist;
                //objTradeIn.IsBluetoothFactory;
                //objTradeIn.IsReverseCamera;
                //objTradeIn.IsFourByFour;
                //objTradeIn.IsTwoByTwo;







                //objTradeIn.BuildPlateDate;
                //objTradeIn.ComplianceDate;
                //objTradeIn.Make;
                //objTradeIn.MakeId;
                //objTradeIn.Model;
                //objTradeIn.ModelId;
                //objTradeIn.Series;
                //objTradeIn.EngineType;
                //objTradeIn.Odometer;
                //objTradeIn.Transmission;
                //objTradeIn.BodyStyle;
                //objTradeIn.ExteriorColor;
                //objTradeIn.InteriorColor;
                //objTradeIn.RegoExpires;
                //objTradeIn.AirBags;
                //objTradeIn.OtherOptions;
                //objTradeIn.GlassWork;
                //objTradeIn.Engine;
                //objTradeIn.BodyPanels;
                //objTradeIn.TransmissionDetails;
                //objTradeIn.Paint;
                //objTradeIn.Breaks;
                //objTradeIn.Tyres;
                //objTradeIn.ACDetails;
                //objTradeIn.AlloysDetails;
                //objTradeIn.Headlights;
                //objTradeIn.Upholstery;
                //objTradeIn.SpareTyre;
                //objTradeIn.VehicleCondition;
                //objTradeIn.DamageDetails;
                //objTradeIn.TyreHistory;
                //objTradeIn.ServiceHistory;
                //objTradeIn.Payout;
                //objTradeIn.OtherDescription;
                //objTradeIn.WheelsAlloys;
                //objTradeIn.FuelType;
                //objTradeIn.Door;




                //objTradeIn.Id;
                //objTradeIn.ProspectId;
                //objTradeIn.CD;--removed
                //objTradeIn.RateCondition;--
                //objTradeIn.Owners;--


                //----------------------------------------------------------------------------------

                //objProsp.Comment = txtComments.Text.Trim();ayyaj
                //if (chkTradeIn.Checked)
                //    objProsp.TradeIn = true;
                //else
                //    objProsp.TradeIn = false;
                //objProsp.TradeInMkModel = txtTradeInMakeModel.Text.Trim();
                //objProsp.IsFleetLead = Convert.ToBoolean(hdfIsFleetLead.Value.Trim());
                ////if (rbtnNew.Checked)ayyaj
                ////    objProsp.Used = true;
                ////else if (rbtnUsed.Checked)
                ////    objProsp.Used = false;
                ////else
                ////    objProsp.Used = false;
                ////objProsp.WhereDidUHear = Convert.ToInt32(ddlWhereDidUHear.SelectedValue.Trim());
                ////double Interval = 0;
                //List<ProspectContacts> lstprospCont = new List<ProspectContacts>();
                //foreach (GridViewRow grviewrow in gvContact.Rows)
                //{
                //    ProspectContacts objProspContact = new ProspectContacts();
                //    CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkSelect");
                //    RadioButton rbtn = (RadioButton)grviewrow.FindControl("rbtnIsPrimary");
                //    HiddenField hdfContactId = (HiddenField)grviewrow.FindControl("hdfContactId");
                //    HiddenField hdfProspContId = (HiddenField)grviewrow.FindControl("hdfProspContId");
                //    if (chkbx != null && rbtn != null && hdfProspContId != null && hdfContactId != null)
                //    {
                //        if (chkbx.Checked)
                //        {
                //            objProspContact.ContactId = Convert.ToInt64(hdfContactId.Value.Trim());
                //            if (rbtn.Checked)
                //                objProspContact.IsPrimary = true;
                //            else
                //                objProspContact.IsPrimary = false;
                //            objProspContact.ProspContactId = Convert.ToInt64(hdfProspContId.Value.Trim());
                //            objProspContact.IsDeleted = false;
                //        }
                //        else if (chkbx.Checked == false && Convert.ToInt64(hdfProspContId.Value.Trim()) > 0)
                //        {
                //            objProspContact.ContactId = Convert.ToInt64(hdfContactId.Value.Trim());
                //            objProspContact.IsPrimary = false;
                //            objProspContact.ProspContactId = Convert.ToInt64(hdfProspContId.Value.Trim());
                //            objProspContact.IsDeleted = true;
                //        }
                //        lstprospCont.Add(objProspContact);
                //    }
                //}
                //--------------------------------till not use
                //objProsp.LstProspContact = lstprospCont;
                //if (objProsp.ProspId == 0)ayyaj
                //{
                //    if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) == 0)
                //        objProsp.IsFinanceSource = "W";
                //    else if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) == 0)
                //        objProsp.IsFinanceSource = "F";
                //    else
                //        objProsp.IsFinanceSource = "W";
                //Result = objProspBM.AddProspect(objProsp);
                //    if (!CheckDuplicateLeads(objProsp.Email, objProsp.IsFinanceSource))
                //    {
                //        if (Convert.ToInt16(ddlFinance.SelectedValue.Trim()) == 1)
                //            objProsp.IsFinanceSource = "C";
                //        else
                //        {
                //            if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) == 0)
                //                objProsp.IsFinanceSource = "W";
                //            else if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) == 0)
                //                objProsp.IsFinanceSource = "F";
                //            else
                //                objProsp.IsFinanceSource = "W";
                //        }
                //        objProsp.IsDuplicate = 43;// Hard Code for Regular
                //        Result = objProspBM.AddProspect(objProsp);
                //    }
                //    else
                //    {
                //        if (CheckFor24Hrs(objProsp.Email) <= 24)
                //        {
                //            if (Convert.ToInt16(ddlFinance.SelectedValue.Trim()) == 1)
                //                objProsp.IsFinanceSource = "C";
                //            else
                //            {
                //                if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) == 0)
                //                    objProsp.IsFinanceSource = "W";
                //                else if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) == 0)
                //                    objProsp.IsFinanceSource = "F";
                //                else
                //                    objProsp.IsFinanceSource = "W";
                //            }
                //            objProsp.IsDuplicate = 44; //Hard Code for Duplicate
                //            Result = objProspBM.AddProspect(objProsp);
                //        }
                //        else
                //        {
                //            if (Convert.ToInt16(ddlFinance.SelectedValue.Trim()) == 1)
                //                objProsp.IsFinanceSource = "C";
                //            else
                //            {
                //                if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) == 0)
                //                    objProsp.IsFinanceSource = "W";
                //                else if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) == 0)
                //                    objProsp.IsFinanceSource = "F";
                //                else
                //                    objProsp.IsFinanceSource = "W";
                //            }
                //            objProsp.IsDuplicate = 45; //Hard Code for Duplicate & Notified
                //            Result = objProspBM.AddProspect(objProsp);
                //            DataSet Ds = objMstBM.GetDupLeadsDetailsForNoti(objProsp.Email, Result);
                //            if (Ds != null && Ds.Tables.Count > 0)
                //            {
                //                DataTable dt1 = Ds.Tables[0];
                //                DataTable dt2 = Ds.Tables[1];
                //                DataTable dt3 = Ds.Tables[2];
                //                SendConsultMail(dt2.Rows[0]["ConsultEmail"].ToString().Trim(), dt2.Rows[0]["AdminEmail"].ToString().Trim(), dt2.Rows[0]["ConsultName"].ToString().Trim(), dt1.Rows[0]["Name"].ToString().Trim(), dt1.Rows[0]["Email1"].ToString().Trim());
                //                SendFCConsultMail(dt3.Rows[0]["ConsultEmail"].ToString().Trim(), dt3.Rows[0]["AdminEmail"].ToString().Trim(), dt3.Rows[0]["ConsultName"].ToString().Trim(), dt1.Rows[0]["Name"].ToString().Trim(), dt1.Rows[0]["Email1"].ToString().Trim());
                //            }
                //        }
                //    }
#endregion
                if (objTradeIn.TradeInNo>0)
                {
                    Result = objProspBM.AddTradeIn(objTradeIn);
                }
                else
                {
                    lblAddErrMsg.Text = Resources.PFSalesResource.TradeInNotAdded.Trim();
                    lblAddSucMsg.Text = string.Empty;
                    dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                    dvadderror.Visible = true;
                    txtAddName.Focus();
                }
               
                BindGridTradeIn();
                if (Result > 0)
                {
                    #region Hide
                    //       Result = objProspBM.AddTradeIn(objTradeIn);
                    //        if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0)
                    //        {
                    //            DataTable dt = objEmpBM.GetEmpDetFromVirId(Convert.ToInt64(ddlConsultant.SelectedValue.Trim()));
                    //            if (dt != null && dt.Rows.Count > 0)
                    //            {
                    //                // SaveDefaultActivity(txtFName.Text.Trim(), Result, Interval);
                    //                SetAllocatedDate(Convert.ToInt64(ddlConsultant.SelectedValue.Trim()), Result, BasePage.UserSession.VirtualRoleId);
                    //                SendMail(dt.Rows[0]["Email1"].ToString().Trim(), 1, dt.Rows[0]["FName"].ToString().Trim());
                    //                SendProspectMail(txtEmail1.Text.Trim(), txtFName.Text.Trim(), ddlConsultant.SelectedItem.Text.Trim(), dt.Rows[0]["Phone"].ToString().Trim(), dt.Rows[0]["Email1"].ToString().Trim(), DateTime.Today.ToString("D"), dt.Rows[0]["PhoneExt"].ToString().Trim());
                    //            }
                    //        }
                    //        if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0)
                    //        {
                    //            DataTable dt = objEmpBM.GetEmpDetFromVirId(Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()));
                    //            if (dt != null && dt.Rows.Count > 0)
                    //            {
                    //                // SaveDefaultActivity(txtFName.Text.Trim(), Result, 0);
                    //                SetFAllocatedDate(Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()), Result, BasePage.UserSession.VirtualRoleId);
                    //                SendMail(dt.Rows[0]["Email1"].ToString().Trim(), 1, dt.Rows[0]["FName"].ToString().Trim());
                    //                //SendProspectMail(txtEmail1.Text.Trim(), txtFName.Text.Trim(), ddlFConsultant.SelectedItem.Text.Trim(), dt.Rows[0]["Phone"].ToString().Trim(), dt.Rows[0]["Email1"].ToString().Trim(), DateTime.Today.ToString("D"), dt.Rows[0]["PhoneExt"].ToString().Trim());
                    //            }
                    //        }
                    #endregion

                    ClearAll();
                    lblAddSucMsg.Text = Resources.PFSalesResource.TradeInAddedSucc.Trim();
                    lblAddErrMsg.Text = lblSerErrMsg.Text = string.Empty;
                    dvaddSucc.Visible = true;
                    dvaserSuccess.Visible = dvadderror.Visible = dvsererror.Visible = false;
                    //pnlAddProsp.Visible = false;
                    //pnlSearchprosp.Visible = true;
                    //txtserprospName.Focus();
                    ddlTitle.Focus();
                }
                else if (Result == -5)
                {
                    lblAddErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                    lblAddSucMsg.Text = string.Empty;
                    dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                    dvadderror.Visible = true;
                    //txtAddName.Focus();
                    ddlTitle.Focus();
                }
                else
                {
                    lblAddErrMsg.Text = Resources.PFSalesResource.TradeInNotAdded.Trim();
                    lblAddSucMsg.Text = string.Empty;
                    dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                    dvadderror.Visible = true;
                    //txtAddName.Focus();
                    ddlTitle.Focus();
                }
                #region Hide
                //}
                //else if (objProsp.ProspId > 0)
                //{
                //    Result = objProspBM.UpdateProspect(objProsp);
                //    if (Result > 0)
                //    {
                //        UpdateFinCarLeads(ddlfinReq.SelectedValue.Trim(), txtFCMessage.Text.Trim(), ddlCredHistory.SelectedValue.Trim(), ddlTermYears.SelectedValue.Trim(), txtEstFin.Text.Trim(), txtResBaloon.Text.Trim(), txtInitialDep.Text.Trim(), objProsp.ProspId, Convert.ToInt64(hdfFCId.Value.Trim()), ddlEmployment.SelectedValue.Trim(), txtCurrentIncome.Text.Trim(), txtEmployer.Text.Trim(), ddlTimeinCurEmp.SelectedValue.Trim(), Convert.ToInt16(ddlFinReqFrom.SelectedValue.Trim()), ddlTimeAtCurAdd.SelectedValue.Trim());

                //        if (hdfConsultID.Value != ddlConsultant.SelectedValue.Trim() && !string.IsNullOrEmpty(hdfEnquryDate.Value.Trim()))
                //        {
                //            if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0)
                //            {
                //                DataTable dt = objEmpBM.GetEmpDetFromVirId(Convert.ToInt64(ddlConsultant.SelectedValue.Trim()));
                //                if (dt != null && dt.Rows.Count > 0)
                //                {
                //                    // SaveDefaultActivity(txtFName.Text.Trim(), objProsp.ProspId, Interval);
                //                    SetAllocatedDate(Convert.ToInt64(ddlConsultant.SelectedValue.Trim()), objProsp.ProspId, BasePage.UserSession.VirtualRoleId);
                //                    SendMail(dt.Rows[0]["Email1"].ToString().Trim(), 1, dt.Rows[0]["FName"].ToString().Trim());
                //                    SendProspectMail(txtEmail1.Text.Trim(), txtFName.Text.Trim(), ddlConsultant.SelectedItem.Text.Trim(), dt.Rows[0]["Phone"].ToString().Trim(), dt.Rows[0]["Email1"].ToString().Trim(), DateTime.Today.ToString("D"), dt.Rows[0]["PhoneExt"].ToString().Trim());
                //                }
                //            }
                //        }
                //        if (hdfFConsultID.Value != ddlFConsultant.SelectedValue.Trim() && !string.IsNullOrEmpty(hdfEnquryDate.Value.Trim()))
                //        {
                //            if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0)
                //            {
                //                DataTable dt = objEmpBM.GetEmpDetFromVirId(Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()));
                //                if (dt != null && dt.Rows.Count > 0)
                //                {
                //                    // SaveDefaultActivity(txtFName.Text.Trim(), objProsp.ProspId, 0);
                //                    SetFAllocatedDate(Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()), objProsp.ProspId, BasePage.UserSession.VirtualRoleId);
                //                    SendMail(dt.Rows[0]["Email1"].ToString().Trim(), 1, dt.Rows[0]["FName"].ToString().Trim());
                //                    //SendProspectMail(txtEmail1.Text.Trim(), txtFName.Text.Trim(), ddlConsultant.SelectedItem.Text.Trim(), dt.Rows[0]["Phone"].ToString().Trim(), dt.Rows[0]["Email1"].ToString().Trim(), DateTime.Today.ToString("D"), dt.Rows[0]["PhoneExt"].ToString().Trim());
                //                }
                //            }
                //        }
                //        ClearAll();
                //        lblSerSucMsg.Text = Resources.PFSalesResource.ProspDeatilsUpdated.Trim();
                //        lblSerErrMsg.Text = string.Empty;
                //        dvadderror.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                //        dvaserSuccess.Visible = true;
                //        pnlAddProsp.Visible = false;
                //        pnlSearchprosp.Visible = true;
                //        txtserprospName.Focus();
                //    }
                //    else if (Result == -5)
                //    {
                //        lblAddErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                //        lblAddSucMsg.Text = string.Empty;
                //        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                //        dvadderror.Visible = true;
                //        txtAddName.Focus();
                //    }
                //    else
                //    {
                //        lblAddErrMsg.Text = Resources.PFSalesResource.ProspDeatilsNotUpdated.Trim();
                //        lblAddSucMsg.Text = string.Empty;
                //        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                //        dvadderror.Visible = true;
                //        txtAddName.Focus();
                //    }
                //}
                #endregion
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.lnkbtnSave_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// 
    /// Created Date: 22 Feb 2014
    /// Description: Update Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["ProspId"] = 0;
            //ShowEmployeeName();
            Int64 Result = 0;

            if (ViewState["ProspectId"] != null && BasePage.UserSession != null && ViewState["TradeId"]!=null)
            {
                objTradeIn.Id= Convert.ToInt64(ViewState["TradeId"].ToString().Trim());
                objProsp.ProspId = Convert.ToInt64(ViewState["ProspectId"].ToString().Trim());
                objTradeIn.ProspectId = Convert.ToInt64(ViewState["ProspectId"].ToString().Trim());
                Guid gi = Guid.NewGuid();
                objProsp.ProspKey = gi.ToString().Trim();
                objProsp.Title = Convert.ToInt32(ddlTitle.SelectedValue.Trim());
                //if (ddlFName.SelectedValue.Trim().ToLower() != Resources.PFSalesResource.ddlSelect.Trim().ToLower())
                if (!string.IsNullOrEmpty(txtFName.Text.Trim()))
                {
                    string str = txtFName.Text.Trim().Substring(0, 1);
                    str = str.ToUpper();
                    objProsp.FName = (str.Trim() + txtFName.Text.Trim().Remove(0, 1)).Trim();// ddlFName.SelectedValue.Trim().Replace("  ", " ");
                }
                else
                    objProsp.FName = string.Empty;
                //if (ddlMName.SelectedValue.Trim().ToLower() != Resources.PFSalesResource.ddlSelect.Trim().ToLower())
                if (!string.IsNullOrEmpty(txtMName.Text.Trim()))
                {
                    string str = txtMName.Text.Trim().Substring(0, 1);
                    str = str.ToUpper();
                    objProsp.MName = (str.Trim() + txtMName.Text.Trim().Remove(0, 1)).Trim();// ddlMName.SelectedValue.Trim().Replace("  ", " ");
                }
                else
                    objProsp.MName = string.Empty;
                //if (ddlLName.SelectedValue.Trim().ToLower() != Resources.PFSalesResource.ddlSelect.Trim().ToLower())
                if (!string.IsNullOrEmpty(txtLName.Text.Trim()))
                {
                    string str = txtLName.Text.Trim().Substring(0, 1);
                    str = str.ToUpper();
                    objProsp.LName = (str.Trim() + txtLName.Text.Trim().Remove(0, 1)).Trim();// ddlLName.SelectedValue.Trim().Replace("  ", " ");
                }
                else
                    objProsp.LName = string.Empty;//ddlLName.SelectedValue.Trim().Replace("  ", " ");
                objProsp.CarMake = Convert.ToInt32(ddlCarMake.SelectedValue.Trim());
                objTradeIn.Make = ddlCarMake.SelectedItem.Text.Trim();
                objTradeIn.MakeId = Convert.ToInt32(ddlCarMake.SelectedValue.Trim());
                objProsp.Phone = txtPhNo.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
                if (!string.IsNullOrEmpty(hdfPhoneFormatId.Value.Trim()))
                    objProsp.formatedPhoNo = Convert.ToInt64(hdfPhoneFormatId.Value.Trim());
                else
                    objProsp.formatedPhoNo = Convert.ToInt64(ddlPhFormat.SelectedValue.Trim());
                objProsp.Mobile = txtMobile.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
                if (!string.IsNullOrEmpty(hdfMobileFormatId.Value.Trim()))
                    objProsp.formatedMobNo = Convert.ToInt64(hdfMobileFormatId.Value.Trim());
                else
                    objProsp.formatedMobNo = Convert.ToInt64(ddlPhFormat.SelectedValue.Trim());
                //objProsp.AltContact = txtAltContNo.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");ayyaj
                if (!string.IsNullOrEmpty(hdfAltContactId.Value.Trim()))
                    objProsp.formatedAltCon = Convert.ToInt64(hdfAltContactId.Value.Trim());
                else
                    objProsp.formatedAltCon = Convert.ToInt64(ddlPhFormat.SelectedValue.Trim());
                objProsp.Fax = txtFax.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
                if (!string.IsNullOrEmpty(hdfFaxFormatId.Value.Trim()))
                    objProsp.formatedFax = Convert.ToInt64(hdfFaxFormatId.Value.Trim());
                else
                    objProsp.formatedFax = Convert.ToInt64(ddlPhFormat.SelectedValue.Trim());
                objProsp.Email = txtEmail1.Text.Trim();
                objProsp.Email1 = txtAlterEmail.Text.Trim();
                objProsp.Add1 = txtAddLine1.Text.Trim();
                objProsp.Add2 = txtAddLine2.Text.Trim();
                objProsp.Add3 = txtAddLine3.Text.Trim();
                objProsp.MemberNo = txtMemNo.Text.Trim();
                objProsp.FConsultant = "FConsultant";//ayyajtxtFConsultant.Text.Trim()
                objProsp.FConsultId = 111;//ayyajConvert.ToInt64(ddlFConsultant.SelectedValue.Trim())
                objProsp.ConsultId = Convert.ToInt64(ddlConsultant.SelectedValue.Trim());
                objProsp.StatusId = Convert.ToInt64(ddlAddStatus.SelectedValue.Trim());
                objProsp.StateId = Convert.ToInt32(ddlState.SelectedValue.Trim());
                objProsp.SourceId = 11;//ayyajConvert.ToInt64(ddlSource.SelectedValue.Trim())
                objProsp.CityId = Convert.ToInt64(ddlCity.SelectedValue.Trim());
                objProsp.PostalCode = "4500";//ayyajddlPostalCode.SelectedValue.Trim()
                objProsp.Finance = 2;//ayyajConvert.ToInt16(ddlFinance.SelectedValue.Trim())
                objProsp.LeadSource = "ReferredBy";//ayyajtxtReferredBy.Text.Trim();
                objProsp.CreatedById = BasePage.UserSession.VirtualRoleId;
                objProsp.IsDeleted = false;
                objTradeIn.IsDeleted = false;
                objProsp.ModelId = Convert.ToInt32(ddlModel.SelectedValue.Trim());
                objTradeIn.ModelId = Convert.ToInt32(ddlModel.SelectedValue.Trim());
                objProsp.Model = ddlModel.SelectedItem.Text.Trim();//ayyajddlModel.SelectedItem.Text.Trim()
                objTradeIn.Model = ddlModel.SelectedItem.Text.Trim();
                //Desc:When CarMake And Model Not Selected Then Assign 'Other' :Ayyaj---------
                ListItem lst = ddlCarMake.Items.FindByText("OTHER");
                string lstVal = lst.Value;
                if (!string.IsNullOrEmpty(lst.Value.Trim()))
                {
                    if (objProsp.CarMake == 0)
                    {
                        //ListItem lst = ddlCarMake.Items.FindByText("OTHER");
                        //string lstVal = lst.Value;
                        DataTable Dt = objMstBM.GetModelFromMakeId(Convert.ToInt32(lstVal.Trim()));
                        DataView Dv = Dt.DefaultView;
                        Dv.RowFilter = "Model='OTHER'";
                        int valModelId = Convert.ToInt32((Dv.ToTable().Rows[0][0]));
                        string valModel = Convert.ToString((Dv.ToTable().Rows[0][1]));
                        objProsp.CarMake = Convert.ToInt32(lstVal.Trim());
                        objProsp.ModelId = valModelId;
                        objProsp.Model = valModel;
                        objTradeIn.ModelId = valModelId;
                        objTradeIn.Model = valModel;


                    }
                    else
                    {
                        if (objProsp.ModelId == 0)
                        {

                            DataTable Dt = objMstBM.GetModelFromMakeId(Convert.ToInt32(lstVal.Trim()));
                            DataView Dv = Dt.DefaultView;
                            Dv.RowFilter = "Model='Other'";
                            int valModelId = Convert.ToInt32((Dv.ToTable().Rows[0][0]));
                            string valModel = Convert.ToString((Dv.ToTable().Rows[0][1]));
                            objProsp.ModelId = valModelId;
                            objProsp.Model = valModel;
                            objTradeIn.ModelId = valModelId;
                            objTradeIn.Model = valModel;
                        }
                        else
                        {
                            objProsp.Model = ddlModel.SelectedItem.Text.Trim();
                            objTradeIn.Model = ddlModel.SelectedItem.Text.Trim();

                        }

                    }
                }
                //if (!string.IsNullOrEmpty(txtBuildPlateDate.Text.Replace("__/__/____", "")))
                //    objTradeIn.BuildPlateDate = Convert.ToDateTime(txtBuildPlateDate.Text.Trim());
                //if (!string.IsNullOrEmpty(txtComplianceDate.Text.Replace("__/__/____", "")))
                //    objTradeIn.ComplianceDate = Convert.ToDateTime(txtComplianceDate.Text.Trim());
                //DataTable DtT = objProspBM.GetTradeInCount(objProsp.ProspId);
                //if (DtT != null && DtT.Rows.Count > 0)
                //    objTradeIn.TradeInNo = Convert.ToInt32(DtT.Rows[0]["TradeInCount"]);

                string BuildDt = null;
                string ComplianceDt = null;

                if (ddlComplianceMonth.SelectedIndex <= 9)
                    ComplianceDt = "0" + ddlComplianceMonth.SelectedIndex.ToString();
                else
                    ComplianceDt = ddlComplianceMonth.SelectedIndex.ToString();
                ComplianceDt = Convert.ToString(ComplianceDt + "/" + ddlComplianceYear.SelectedItem);
                objTradeIn.ComplianceDate = Convert.ToDateTime(ComplianceDt);


                if (ddlMonthBuild.SelectedIndex <= 9)
                    BuildDt = "0" + ddlMonthBuild.SelectedIndex.ToString();
                else
                    BuildDt = ddlMonthBuild.SelectedIndex.ToString();

                BuildDt = Convert.ToString(BuildDt + "/" + ddlYearBuild.SelectedItem);
                objTradeIn.BuildPlateDate = Convert.ToDateTime(BuildDt); 


                objTradeIn.Series = txtSeries.Text.Trim();
                objTradeIn.EngineType = txtEngineType.Text.Trim();
                objTradeIn.Odometer = txtOdometer.Text.Trim();
                objTradeIn.Transmission = txtTransmission.Text.Trim();
                objTradeIn.BodyStyle = txtBodyStyle.Text.Trim();
                objTradeIn.ExteriorColor = txtExtColor.Text.Trim();
                objTradeIn.InteriorColor = txtIntTrimColor.Text.Trim();
                objTradeIn.RegoExpires = txtRegoExpires.Text.Trim();
                objTradeIn.OtherOptions = txtOtherOptions.Text.Trim();
                objTradeIn.GlassWork = ddlGlasswork.SelectedValue.Trim();
                objTradeIn.Engine = ddlEngine.SelectedValue.Trim();
                objTradeIn.BodyPanels = ddlBodyPanels.SelectedValue.Trim();
                objTradeIn.TransmissionDetails = ddlTransmission.SelectedValue.Trim();
                objTradeIn.Paint = ddlPaint.SelectedValue.Trim();
                objTradeIn.Breaks = ddlBrakes.SelectedValue.Trim();
                objTradeIn.Tyres = ddlTyres.SelectedValue.Trim();
                objTradeIn.ACDetails = ddlAC.SelectedValue.Trim();
                objTradeIn.RimAlloysDetails = ddlRimsAlloys.SelectedValue.Trim();
                objTradeIn.Headlights = ddlHeadlights.SelectedValue.Trim();
                objTradeIn.Upholstery = ddlUpholstery.SelectedValue.Trim();
                objTradeIn.SpareTyre = ddlSpareTyre.SelectedValue.Trim();
                objTradeIn.VehicleCondition = txtDescDent.Text.Trim();
                objTradeIn.DamageDetails = txtAccident.Text.Trim();
                objTradeIn.TyreHistory = txtRepalce.Text.Trim();
                objTradeIn.ServiceHistory = ddlLogBook.SelectedValue.Trim();
                objTradeIn.Payout = txtPayout.Text.Trim();
                objTradeIn.OtherDescription = txtAnything.Text.Trim();
                objTradeIn.WheelsAlloys = ddlWheelsAlloys.SelectedValue.Trim();
                objTradeIn.FuelType = ddlFuelType.SelectedValue.Trim();
                objTradeIn.Door = ddlDoor.SelectedValue.Trim();
                objTradeIn.RateCondition = Convert.ToInt32(ddlRating.SelectedValue.Trim());
                objTradeIn.Owners = Convert.ToInt32(ddlOwners.SelectedValue.Trim());

                if (chkRevSensor.Checked)
                    objTradeIn.IsReverseSensor = true;
                else
                    objTradeIn.IsReverseSensor = false;

                if (chkXenonLights.Checked)
                    objTradeIn.IsXenonLights = true;
                else
                    objTradeIn.IsXenonLights = false;

                if (chkProtectProduct.Checked)
                    objTradeIn.IsProtectionProduct = true;
                else
                    objTradeIn.IsProtectionProduct = false;

                if (chkActCruiseControl.Checked)
                    objTradeIn.IsActiveCruiseControl = true;
                else
                    objTradeIn.IsActiveCruiseControl = false;

                if (chkTowBar.Checked)
                    objTradeIn.IsTowBar = true;
                else
                    objTradeIn.IsTowBar = false;

                if (chkElectricSeats.Checked)
                    objTradeIn.IsElectricSeats = true;
                else
                    objTradeIn.IsElectricSeats = false;

                if (chkBullBar.Checked)
                    objTradeIn.IsBullBar = true;
                else
                    objTradeIn.IsBullBar = false;

                if (chkTint.Checked)
                    objTradeIn.IsTint = true;
                else
                    objTradeIn.IsTint = false;

                if (chkSunroof.Checked)
                    objTradeIn.IsSunroof = true;
                else
                    objTradeIn.IsSunroof = false;

                if (chkPanoramic.Checked)
                    objTradeIn.IsPanoramic = true;
                else
                    objTradeIn.IsPanoramic = false;

                if (chkRoofRacks.Checked)
                    objTradeIn.IsRoofRacks = true;
                else
                    objTradeIn.IsRoofRacks = false;

                if (chkTV.Checked)
                    objTradeIn.IsTV = true;
                else
                    objTradeIn.IsTV = false;

                if (chkLeather.Checked)
                    objTradeIn.IsLeather = true;
                else
                    objTradeIn.IsLeather = false;

                if (chkSideSteps.Checked)
                    objTradeIn.IsSideSteps = true;
                else
                    objTradeIn.IsSideSteps = false;

                if (chkSatNav.Checked)
                    objTradeIn.IsSatNav = true;
                else
                    objTradeIn.IsSatNav = false;

                if (chkThirdRowSeats.Checked)
                    objTradeIn.IsThirdRowSeats = true;
                else
                    objTradeIn.IsThirdRowSeats = false;

                if (chkTimingBeltChange.Checked)
                    objTradeIn.IsTimingBeltChanged = true;
                else
                    objTradeIn.IsTimingBeltChanged = false;

                if (chkLaneChangeAssist.Checked)
                    objTradeIn.IsLaneChangeAssist = true;
                else
                    objTradeIn.IsLaneChangeAssist = false;

                if (chkBluetoothFactory.Checked)
                    objTradeIn.IsBluetoothFactory = true;
                else
                    objTradeIn.IsBluetoothFactory = false;

                if (chkReverseCamera.Checked)
                    objTradeIn.IsReverseCamera = true;
                else
                    objTradeIn.IsReverseCamera = false;

                if (chkFourByFour.Checked)
                    objTradeIn.IsFourByFour = true;
                else
                    objTradeIn.IsFourByFour = false;

                if (chkTwoByTwo.Checked)
                    objTradeIn.IsTwoByTwo = true;
                else
                    objTradeIn.IsTwoByTwo = false;
                #region Hide
                //objTradeIn.IsAC;--Removed
                //objTradeIn.IsReverseSensor;
                //objTradeIn.IsABS;--Removed
                //objTradeIn.IsXenonLights;
                //objTradeIn.IsPowerSteer;--Removed
                //objTradeIn.IsProtectionProduct;
                //objTradeIn.IsActiveCruiseControl;
                //objTradeIn.IsTowBar;
                //objTradeIn.IsPowerWindows;--Removed
                //objTradeIn.IsElectricSeats;
                //objTradeIn.IsBullBar;
                //objTradeIn.IsCentralLocking;--Removed
                //objTradeIn.IsTint;
                //objTradeIn.IsSunroof;
                //objTradeIn.IsRoofRacks;
                //objTradeIn.IsPanoramic;
                //objTradeIn.IsTV;
                //objTradeIn.IsLeather;
                //objTradeIn.IsSideSteps;
                //objTradeIn.IsSatNav;
                //objTradeIn.IsAlarm;--Removed
                //objTradeIn.IsThirdRowSeats;
                ////objTradeIn.IsDeleted;--
                //objTradeIn.IsPanoramic;
                //objTradeIn.IsTimingBeltChanged;
                //objTradeIn.IsLaneChangeAssist;
                //objTradeIn.IsBluetoothFactory;
                //objTradeIn.IsReverseCamera;
                //objTradeIn.IsFourByFour;
                //objTradeIn.IsTwoByTwo;







                //objTradeIn.BuildPlateDate;
                //objTradeIn.ComplianceDate;
                //objTradeIn.Make;
                //objTradeIn.MakeId;
                //objTradeIn.Model;
                //objTradeIn.ModelId;
                //objTradeIn.Series;
                //objTradeIn.EngineType;
                //objTradeIn.Odometer;
                //objTradeIn.Transmission;
                //objTradeIn.BodyStyle;
                //objTradeIn.ExteriorColor;
                //objTradeIn.InteriorColor;
                //objTradeIn.RegoExpires;
                //objTradeIn.AirBags;
                //objTradeIn.OtherOptions;
                //objTradeIn.GlassWork;
                //objTradeIn.Engine;
                //objTradeIn.BodyPanels;
                //objTradeIn.TransmissionDetails;
                //objTradeIn.Paint;
                //objTradeIn.Breaks;
                //objTradeIn.Tyres;
                //objTradeIn.ACDetails;
                //objTradeIn.AlloysDetails;
                //objTradeIn.Headlights;
                //objTradeIn.Upholstery;
                //objTradeIn.SpareTyre;
                //objTradeIn.VehicleCondition;
                //objTradeIn.DamageDetails;
                //objTradeIn.TyreHistory;
                //objTradeIn.ServiceHistory;
                //objTradeIn.Payout;
                //objTradeIn.OtherDescription;
                //objTradeIn.WheelsAlloys;
                //objTradeIn.FuelType;
                //objTradeIn.Door;




                //objTradeIn.Id;
                //objTradeIn.ProspectId;
                //objTradeIn.CD;--removed
                //objTradeIn.RateCondition;--
                //objTradeIn.Owners;--


                //----------------------------------------------------------------------------------

                //objProsp.Comment = txtComments.Text.Trim();ayyaj
                //if (chkTradeIn.Checked)
                //    objProsp.TradeIn = true;
                //else
                //    objProsp.TradeIn = false;
                //objProsp.TradeInMkModel = txtTradeInMakeModel.Text.Trim();
                //objProsp.IsFleetLead = Convert.ToBoolean(hdfIsFleetLead.Value.Trim());
                ////if (rbtnNew.Checked)ayyaj
                ////    objProsp.Used = true;
                ////else if (rbtnUsed.Checked)
                ////    objProsp.Used = false;
                ////else
                ////    objProsp.Used = false;
                ////objProsp.WhereDidUHear = Convert.ToInt32(ddlWhereDidUHear.SelectedValue.Trim());
                ////double Interval = 0;
                //List<ProspectContacts> lstprospCont = new List<ProspectContacts>();
                //foreach (GridViewRow grviewrow in gvContact.Rows)
                //{
                //    ProspectContacts objProspContact = new ProspectContacts();
                //    CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkSelect");
                //    RadioButton rbtn = (RadioButton)grviewrow.FindControl("rbtnIsPrimary");
                //    HiddenField hdfContactId = (HiddenField)grviewrow.FindControl("hdfContactId");
                //    HiddenField hdfProspContId = (HiddenField)grviewrow.FindControl("hdfProspContId");
                //    if (chkbx != null && rbtn != null && hdfProspContId != null && hdfContactId != null)
                //    {
                //        if (chkbx.Checked)
                //        {
                //            objProspContact.ContactId = Convert.ToInt64(hdfContactId.Value.Trim());
                //            if (rbtn.Checked)
                //                objProspContact.IsPrimary = true;
                //            else
                //                objProspContact.IsPrimary = false;
                //            objProspContact.ProspContactId = Convert.ToInt64(hdfProspContId.Value.Trim());
                //            objProspContact.IsDeleted = false;
                //        }
                //        else if (chkbx.Checked == false && Convert.ToInt64(hdfProspContId.Value.Trim()) > 0)
                //        {
                //            objProspContact.ContactId = Convert.ToInt64(hdfContactId.Value.Trim());
                //            objProspContact.IsPrimary = false;
                //            objProspContact.ProspContactId = Convert.ToInt64(hdfProspContId.Value.Trim());
                //            objProspContact.IsDeleted = true;
                //        }
                //        lstprospCont.Add(objProspContact);
                //    }
                //}
                //--------------------------------till not use
                //objProsp.LstProspContact = lstprospCont;
                //if (objProsp.ProspId == 0)ayyaj
                //{
                //    if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) == 0)
                //        objProsp.IsFinanceSource = "W";
                //    else if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) == 0)
                //        objProsp.IsFinanceSource = "F";
                //    else
                //        objProsp.IsFinanceSource = "W";
                //Result = objProspBM.AddProspect(objProsp);
                //    if (!CheckDuplicateLeads(objProsp.Email, objProsp.IsFinanceSource))
                //    {
                //        if (Convert.ToInt16(ddlFinance.SelectedValue.Trim()) == 1)
                //            objProsp.IsFinanceSource = "C";
                //        else
                //        {
                //            if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) == 0)
                //                objProsp.IsFinanceSource = "W";
                //            else if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) == 0)
                //                objProsp.IsFinanceSource = "F";
                //            else
                //                objProsp.IsFinanceSource = "W";
                //        }
                //        objProsp.IsDuplicate = 43;// Hard Code for Regular
                //        Result = objProspBM.AddProspect(objProsp);
                //    }
                //    else
                //    {
                //        if (CheckFor24Hrs(objProsp.Email) <= 24)
                //        {
                //            if (Convert.ToInt16(ddlFinance.SelectedValue.Trim()) == 1)
                //                objProsp.IsFinanceSource = "C";
                //            else
                //            {
                //                if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) == 0)
                //                    objProsp.IsFinanceSource = "W";
                //                else if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) == 0)
                //                    objProsp.IsFinanceSource = "F";
                //                else
                //                    objProsp.IsFinanceSource = "W";
                //            }
                //            objProsp.IsDuplicate = 44; //Hard Code for Duplicate
                //            Result = objProspBM.AddProspect(objProsp);
                //        }
                //        else
                //        {
                //            if (Convert.ToInt16(ddlFinance.SelectedValue.Trim()) == 1)
                //                objProsp.IsFinanceSource = "C";
                //            else
                //            {
                //                if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) == 0)
                //                    objProsp.IsFinanceSource = "W";
                //                else if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) == 0)
                //                    objProsp.IsFinanceSource = "F";
                //                else
                //                    objProsp.IsFinanceSource = "W";
                //            }
                //            objProsp.IsDuplicate = 45; //Hard Code for Duplicate & Notified
                //            Result = objProspBM.AddProspect(objProsp);
                //            DataSet Ds = objMstBM.GetDupLeadsDetailsForNoti(objProsp.Email, Result);
                //            if (Ds != null && Ds.Tables.Count > 0)
                //            {
                //                DataTable dt1 = Ds.Tables[0];
                //                DataTable dt2 = Ds.Tables[1];
                //                DataTable dt3 = Ds.Tables[2];
                //                SendConsultMail(dt2.Rows[0]["ConsultEmail"].ToString().Trim(), dt2.Rows[0]["AdminEmail"].ToString().Trim(), dt2.Rows[0]["ConsultName"].ToString().Trim(), dt1.Rows[0]["Name"].ToString().Trim(), dt1.Rows[0]["Email1"].ToString().Trim());
                //                SendFCConsultMail(dt3.Rows[0]["ConsultEmail"].ToString().Trim(), dt3.Rows[0]["AdminEmail"].ToString().Trim(), dt3.Rows[0]["ConsultName"].ToString().Trim(), dt1.Rows[0]["Name"].ToString().Trim(), dt1.Rows[0]["Email1"].ToString().Trim());
                //            }
                //        }
                //    }
                #endregion

                Result = objProspBM.UpdateTradeIn(objTradeIn);
                BindGridTradeIn();
                if (Result > 0)
                {
                    #region Hide
                    //       Result = objProspBM.AddTradeIn(objTradeIn);
                    //        if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0)
                    //        {
                    //            DataTable dt = objEmpBM.GetEmpDetFromVirId(Convert.ToInt64(ddlConsultant.SelectedValue.Trim()));
                    //            if (dt != null && dt.Rows.Count > 0)
                    //            {
                    //                // SaveDefaultActivity(txtFName.Text.Trim(), Result, Interval);
                    //                SetAllocatedDate(Convert.ToInt64(ddlConsultant.SelectedValue.Trim()), Result, BasePage.UserSession.VirtualRoleId);
                    //                SendMail(dt.Rows[0]["Email1"].ToString().Trim(), 1, dt.Rows[0]["FName"].ToString().Trim());
                    //                SendProspectMail(txtEmail1.Text.Trim(), txtFName.Text.Trim(), ddlConsultant.SelectedItem.Text.Trim(), dt.Rows[0]["Phone"].ToString().Trim(), dt.Rows[0]["Email1"].ToString().Trim(), DateTime.Today.ToString("D"), dt.Rows[0]["PhoneExt"].ToString().Trim());
                    //            }
                    //        }
                    //        if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0)
                    //        {
                    //            DataTable dt = objEmpBM.GetEmpDetFromVirId(Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()));
                    //            if (dt != null && dt.Rows.Count > 0)
                    //            {
                    //                // SaveDefaultActivity(txtFName.Text.Trim(), Result, 0);
                    //                SetFAllocatedDate(Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()), Result, BasePage.UserSession.VirtualRoleId);
                    //                SendMail(dt.Rows[0]["Email1"].ToString().Trim(), 1, dt.Rows[0]["FName"].ToString().Trim());
                    //                //SendProspectMail(txtEmail1.Text.Trim(), txtFName.Text.Trim(), ddlFConsultant.SelectedItem.Text.Trim(), dt.Rows[0]["Phone"].ToString().Trim(), dt.Rows[0]["Email1"].ToString().Trim(), DateTime.Today.ToString("D"), dt.Rows[0]["PhoneExt"].ToString().Trim());
                    //            }
                    //        }
                    #endregion

                    ClearAll();
                    lblAddSucMsg.Text = Resources.PFSalesResource.TradeInDeatilsUpdated.Trim();
                    lblAddErrMsg.Text = lblSerErrMsg.Text = string.Empty;
                    dvaddSucc.Visible = true;
                    dvaserSuccess.Visible = dvadderror.Visible = dvsererror.Visible = false;
                    lblAddProspHead.Text = Resources.PFSalesResource.AddTradeInDet.Trim();
                    //pnlAddProsp.Visible = false;
                    //pnlSearchprosp.Visible = true;
                    //txtserprospName.Focus();
                    ddlTitle.Focus();
                }
                else if (Result == -5)
                {
                    lblAddErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                    lblAddSucMsg.Text = string.Empty;
                    dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                    dvadderror.Visible = true;
                    ddlTitle.Focus();
                }
                else
                {
                    lblAddErrMsg.Text = Resources.PFSalesResource.TradeInDeatilsNotUpdated.Trim();
                    lblAddSucMsg.Text = string.Empty;
                    dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                    dvadderror.Visible = true;
                    ddlTitle.Focus();
                }
                #region Hide
                //}
                //else if (objProsp.ProspId > 0)
                //{
                //    Result = objProspBM.UpdateProspect(objProsp);
                //    if (Result > 0)
                //    {
                //        UpdateFinCarLeads(ddlfinReq.SelectedValue.Trim(), txtFCMessage.Text.Trim(), ddlCredHistory.SelectedValue.Trim(), ddlTermYears.SelectedValue.Trim(), txtEstFin.Text.Trim(), txtResBaloon.Text.Trim(), txtInitialDep.Text.Trim(), objProsp.ProspId, Convert.ToInt64(hdfFCId.Value.Trim()), ddlEmployment.SelectedValue.Trim(), txtCurrentIncome.Text.Trim(), txtEmployer.Text.Trim(), ddlTimeinCurEmp.SelectedValue.Trim(), Convert.ToInt16(ddlFinReqFrom.SelectedValue.Trim()), ddlTimeAtCurAdd.SelectedValue.Trim());

                //        if (hdfConsultID.Value != ddlConsultant.SelectedValue.Trim() && !string.IsNullOrEmpty(hdfEnquryDate.Value.Trim()))
                //        {
                //            if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0)
                //            {
                //                DataTable dt = objEmpBM.GetEmpDetFromVirId(Convert.ToInt64(ddlConsultant.SelectedValue.Trim()));
                //                if (dt != null && dt.Rows.Count > 0)
                //                {
                //                    // SaveDefaultActivity(txtFName.Text.Trim(), objProsp.ProspId, Interval);
                //                    SetAllocatedDate(Convert.ToInt64(ddlConsultant.SelectedValue.Trim()), objProsp.ProspId, BasePage.UserSession.VirtualRoleId);
                //                    SendMail(dt.Rows[0]["Email1"].ToString().Trim(), 1, dt.Rows[0]["FName"].ToString().Trim());
                //                    SendProspectMail(txtEmail1.Text.Trim(), txtFName.Text.Trim(), ddlConsultant.SelectedItem.Text.Trim(), dt.Rows[0]["Phone"].ToString().Trim(), dt.Rows[0]["Email1"].ToString().Trim(), DateTime.Today.ToString("D"), dt.Rows[0]["PhoneExt"].ToString().Trim());
                //                }
                //            }
                //        }
                //        if (hdfFConsultID.Value != ddlFConsultant.SelectedValue.Trim() && !string.IsNullOrEmpty(hdfEnquryDate.Value.Trim()))
                //        {
                //            if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0)
                //            {
                //                DataTable dt = objEmpBM.GetEmpDetFromVirId(Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()));
                //                if (dt != null && dt.Rows.Count > 0)
                //                {
                //                    // SaveDefaultActivity(txtFName.Text.Trim(), objProsp.ProspId, 0);
                //                    SetFAllocatedDate(Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()), objProsp.ProspId, BasePage.UserSession.VirtualRoleId);
                //                    SendMail(dt.Rows[0]["Email1"].ToString().Trim(), 1, dt.Rows[0]["FName"].ToString().Trim());
                //                    //SendProspectMail(txtEmail1.Text.Trim(), txtFName.Text.Trim(), ddlConsultant.SelectedItem.Text.Trim(), dt.Rows[0]["Phone"].ToString().Trim(), dt.Rows[0]["Email1"].ToString().Trim(), DateTime.Today.ToString("D"), dt.Rows[0]["PhoneExt"].ToString().Trim());
                //                }
                //            }
                //        }
                //        ClearAll();
                //        lblSerSucMsg.Text = Resources.PFSalesResource.ProspDeatilsUpdated.Trim();
                //        lblSerErrMsg.Text = string.Empty;
                //        dvadderror.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                //        dvaserSuccess.Visible = true;
                //        pnlAddProsp.Visible = false;
                //        pnlSearchprosp.Visible = true;
                //        txtserprospName.Focus();
                //    }
                //    else if (Result == -5)
                //    {
                //        lblAddErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                //        lblAddSucMsg.Text = string.Empty;
                //        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                //        dvadderror.Visible = true;
                //        txtAddName.Focus();
                //    }
                //    else
                //    {
                //        lblAddErrMsg.Text = Resources.PFSalesResource.ProspDeatilsNotUpdated.Trim();
                //        lblAddSucMsg.Text = string.Empty;
                //        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                //        dvadderror.Visible = true;
                //        txtAddName.Focus();
                //    }
                //}
                #endregion
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.lnkbtnUpdate_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Clear Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFinalClear_Click(object sender, EventArgs e)
    {
        if (ViewState["ProspId"] != null && !string.IsNullOrEmpty(ViewState["ProspId"].ToString().Trim()) && Convert.ToInt64(ViewState["ProspId"].ToString().Trim()) > 0)
        {
            ClearAll();
            //pnlAddProsp.Visible = false;
            //pnlSearchprosp.Visible = true;
        }
        else if (ViewState["ProspId"] != null && !string.IsNullOrEmpty(ViewState["ProspId"].ToString().Trim()) && Convert.ToInt64(ViewState["ProspId"].ToString().Trim()) == 0)
            ClearAll();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Alternate Contact Number Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAlterContNo_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hdfPhoneFormat.Value.Trim()))
            ddlPhFormat.SelectedValue = hdfPhoneFormat.Value.Trim();
        else
            BindFormats();

        if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
        {
            ftePhPopUpPhNo.Enabled = false;
            msePhPopUp.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
            msePhPopUp.MaskType = AjaxControlToolkit.MaskedEditType.None;
            msePhPopUp.Enabled = true;
        }
        else
        {
            ftePhPopUpPhNo.Enabled = true;
            msePhPopUp.MaskType = AjaxControlToolkit.MaskedEditType.None;
            msePhPopUp.Mask = "999999999999999999999999999999";
            msePhPopUp.Enabled = false;
        }
        ddlPhPopUpCountry.Focus();
        //txtPhPopUpPhoNo.Text = txtAltContNo.Text.Trim();ayyaj
        pnlphonePopUp.Visible = true;
        ClearMsg();
        hdfPhPopType.Value = "ALTERCONT";
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Phone Format Close Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnPhPopClose_Click(object sender, EventArgs e)
    {
        pnlphonePopUp.Visible = false;
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Selected Index Changed Event Of Phone Format's Country Drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlPhPopUpCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFormats();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Phone Format Ok Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnPhPoUpOk_Click(object sender, EventArgs e)
    {
        if (hdfPhPopType.Value.Trim().ToUpper() == "MOBILE")
        {
            if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
            {
                fteMobile.Enabled = false;
                mseMobile.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
                mseMobile.MaskType = AjaxControlToolkit.MaskedEditType.None;
                mseMobile.Enabled = true;
                txtMobile.Text = txtPhPopUpPhoNo.Text.Trim();
                hdfMobileFormatId.Value = ddlPhFormat.SelectedValue.Trim();

            }
            else
            {
                fteMobile.Enabled = true;
                mseMobile.Mask = "999999999999999999999999999999";
                mseMobile.MaskType = AjaxControlToolkit.MaskedEditType.None;
                mseMobile.Enabled = false;
                txtMobile.Text = txtPhPopUpPhoNo.Text.Trim();
                hdfMobileFormatId.Value = ddlPhFormat.SelectedValue.Trim();
            }
            txtMobile.Focus();
        }
        else if (hdfPhPopType.Value.Trim().ToUpper() == "PHONE")
        {
            if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
            {
                ftePhNo.Enabled = false;
                msePhNo.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
                msePhNo.MaskType = AjaxControlToolkit.MaskedEditType.None;
                msePhNo.Enabled = true;
                txtPhNo.Text = txtPhPopUpPhoNo.Text.Trim();
                hdfPhoneFormatId.Value = ddlPhFormat.SelectedValue.Trim();
            }
            else
            {
                ftePhNo.Enabled = true;
                msePhNo.MaskType = AjaxControlToolkit.MaskedEditType.None;
                msePhNo.Enabled = false;
                txtPhNo.Text = txtPhPopUpPhoNo.Text.Trim();
                hdfPhoneFormatId.Value = ddlPhFormat.SelectedValue.Trim();
                msePhNo.Mask = "999999999999999999999999999999";
            }
            txtPhNo.Focus();
        }
        else if (hdfPhPopType.Value.Trim().ToUpper() == "FAX")
        {
            if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
            {
                fteFax.Enabled = false;
                mseFax.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
                mseFax.MaskType = AjaxControlToolkit.MaskedEditType.None;
                mseFax.Enabled = true;
                txtFax.Text = txtPhPopUpPhoNo.Text.Trim();
                hdfFaxFormatId.Value = ddlPhFormat.SelectedValue.Trim();
            }
            else
            {
                fteFax.Enabled = true;
                mseFax.Mask = "999999999999999999999999999999";
                mseFax.MaskType = AjaxControlToolkit.MaskedEditType.None;
                mseFax.Enabled = false;
                txtFax.Text = txtPhPopUpPhoNo.Text.Trim();
                hdfFaxFormatId.Value = ddlPhFormat.SelectedValue.Trim();
            }
            txtFax.Focus();
        }
        else if (hdfPhPopType.Value.Trim().ToUpper() == "ALTERCONT")
        {
            //if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")ayyaj
            //{
            //    fteAlteContNo.Enabled = false;
            //    meeAltContNo.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
            //    meeAltContNo.MaskType = AjaxControlToolkit.MaskedEditType.None;
            //    meeAltContNo.Enabled = true;
            //    txtAltContNo.Text = txtPhPopUpPhoNo.Text.Trim();
            //    hdfAltContactId.Value = ddlPhFormat.SelectedValue.Trim();
            //}
            //else
            //{
            //    fteAlteContNo.Enabled = true;
            //    meeAltContNo.Mask = "999999999999999999999999999999";
            //    meeAltContNo.MaskType = AjaxControlToolkit.MaskedEditType.None;
            //    meeAltContNo.Enabled = false;
            //    txtAltContNo.Text = txtPhPopUpPhoNo.Text.Trim();
            //    hdfAltContactId.Value = ddlPhFormat.SelectedValue.Trim();
            //}
            //txtAltContNo.Focus();
        }
        pnlphonePopUp.Visible = false;
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Grid view Row Created Event. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvContact_Created(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
        //{
        //    CheckBox chkSelect = (CheckBox)e.Row.Cells[1].FindControl("chkSelect");
        //    CheckBox chkSelectAll = (CheckBox)this.gvContact.HeaderRow.FindControl("chkSelectAll");
        //    chkSelect.Attributes["onclick"] = string.Format(
        //                                              "javascript:alertChildClick(this,'{0}');",
        //                                              chkSelectAll.ClientID
        //                                           );
        //}
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Gridview Page Sorting Event Of Contact's GridView. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvContact_Soring(object sender, GridViewSortEventArgs e)
    {
        try
        {
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = e.SortExpression;
            DefineContSortDirection();
            BindContacts();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.gvprosp_Soring.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Check Changed Event Of Select Contact's Check Box. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkSelect_CheckChanged(object sender, EventArgs e)
    {
        //GridViewRow grviewrow = (GridViewRow)(((CheckBox)sender).NamingContainer);
        //CheckBox chkbx = (CheckBox)sender;
        //RadioButton rbtn = (RadioButton)grviewrow.FindControl("rbtnIsPrimary");
        //if (chkbx != null && rbtn != null)
        //{
        //    if (chkbx.Checked)
        //    {
        //        rbtn.Enabled = true;
        //    }
        //    else
        //    {
        //        rbtn.Checked = false;
        //        rbtn.Enabled = false;
        //    }
        //}
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 May 2013
    /// Description: Check Changed Event Of Select All Contact's Check Box. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkSelectAll_CheckChanged(object sender, EventArgs e)
    {
        //foreach (GridViewRow grviewrow in gvContact.Rows)
        //{
        //    CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkSelect");
        //    RadioButton rbtn = (RadioButton)grviewrow.FindControl("rbtnIsPrimary");
        //    if (chkbx != null && rbtn != null)
        //    {
        //        if (chkbx.Checked)
        //        {
        //            rbtn.Enabled = true;
        //        }
        //        else
        //        {
        //            rbtn.Checked = false;
        //            rbtn.Enabled = false;
        //        }
        //    }
        //}
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 May 2013
    /// Description: Check Changed Event Of Is Primary's Radio Button. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rbtnIsPrimary_CheckChanged(object sender, EventArgs e)
    {
        //foreach (GridViewRow grviewrow in gvContact.Rows)
        //{
        //    CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkSelect");
        //    RadioButton rbtn = (RadioButton)grviewrow.FindControl("rbtnIsPrimary");
        //    if (chkbx != null && rbtn != null)
        //    {
        //        if (chkbx.Checked)
        //        {
        //            rbtn.Checked = false;
        //            rbtn.Enabled = true;
        //        }
        //        else
        //        {
        //            rbtn.Checked = false;
        //            rbtn.Enabled = false;
        //        }
        //    }
        //}
        //RadioButton rbtnCont = (RadioButton)sender;
        //rbtnCont.Checked = true;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 May 2013
    /// Description: Show Contact Pop Up Button Click.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnNamePopUp_Click(object sender, EventArgs e)
    {
        try
        {
            ShowEmployeeName();
            pnlContactPopUp.Visible = true;
            ClearMsg();

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.lnkbtnNamePopUp_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 May 2013
    /// Description: Close Contact Name's Pop Up
    /// </summary>
    /// <param name="Sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnNamePopUpClose_Close(object sender, EventArgs e)
    {
        try
        {
            ShowEmployeeName();
            pnlContactPopUp.Visible = false;
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.lnkbtnPhPopClose_Close.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 May 2013
    /// Description: Close Contact Name's Pop Up
    /// </summary>
    /// <param name="Sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnNamePopUpOk_Click(object sender, EventArgs e)
    {
        pnlContactPopUp.Visible = false;
        hdfFName.Value = ddlFName.SelectedItem.Text.Trim();
        hdfMName.Value = ddlMName.SelectedItem.Text.Trim();
        hdfLName.Value = ddlLName.SelectedItem.Text.Trim();
        ClearMsg();
        if (ddlFName.SelectedValue.Trim() != Resources.PFSalesResource.ddlSelect.Trim() || ddlMName.SelectedValue.Trim() != Resources.PFSalesResource.ddlSelect.Trim() || ddlLName.SelectedValue.Trim() != Resources.PFSalesResource.ddlSelect.Trim())
            txtAddName.Text = ((ddlFName.SelectedValue.Trim() != Resources.PFSalesResource.ddlSelect.Trim()) ? ddlFName.SelectedValue.Trim() : string.Empty).Trim().Replace("  ", " ") + " " + ((ddlMName.SelectedValue.Trim() != Resources.PFSalesResource.ddlSelect.Trim()) ? ddlMName.SelectedValue.Trim() : string.Empty).Trim().Replace("  ", " ") + " " + ((ddlLName.SelectedValue.Trim() != Resources.PFSalesResource.ddlSelect.Trim()) ? ddlLName.SelectedValue.Trim() : string.Empty).Trim().Replace("  ", " ");
        txtAddName.Text = txtAddName.Text.Trim().Replace("  ", " ");
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 30 May 2013
    /// Description: Selected Index Changed Event Of City's Drop Down List
    /// </summary>
    /// <param name="Sender"></param>
    /// <param name="e"></param>
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlCity.SelectedValue != "0")
        //{
        //    DataTable Dt = objMstBM.GetCityDetFromId(Convert.ToInt64(ddlCity.SelectedValue.Trim()));
        //    if (Dt != null && Dt.Rows.Count > 0)
        //        txtPostalCode.Text = Dt.Rows[0]["PCode"].ToString().Trim();
        //}
        //else
        //    txtPostalCode.Text = string.Empty;
        //txtAddLine1.Focus();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Selected Index Changed Event Of Page Size's Drop Down List
    /// </summary>
    /// <param name="Sender"></param>
    /// <param name="e"></param>
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (Convert.ToInt16(ddlPageSize.SelectedValue.Trim()) == 1)
            {
                Int32 intAllCount = Convert.ToInt32(ViewState["TotalRowCount"]);
                gvprosp.PageSize = intAllCount;
            }
            else
            {
                gvprosp.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue.Trim());
            }
            BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.ddlPageSize_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 28 May 2013
    /// Description: Add Role's Selected Index Changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlPhFormat_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
            {
                ftePhPopUpPhNo.Enabled = false;
                msePhPopUp.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
                msePhPopUp.MaskType = AjaxControlToolkit.MaskedEditType.None;
                msePhPopUp.Enabled = true;
                txtPhPopUpPhoNo.Text = txtPhPopUpPhoNo.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
            }
            else
            {
                ftePhPopUpPhNo.Enabled = true;
                msePhPopUp.MaskType = AjaxControlToolkit.MaskedEditType.None;
                msePhPopUp.Mask = "999999999999999999999999999999";
                msePhPopUp.Enabled = false;
                txtPhPopUpPhoNo.Text = txtPhPopUpPhoNo.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
            }
            pnlphonePopUp.Visible = true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.ddlPhFormat_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 7 June 2013
    /// Description: Postal Code's Selected Index Changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlPostalCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindAllCities();
            ClearMsg();
            // ddlCity.Focus();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.ddlPostalCode_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 19 July 2013
    /// Description: Postal Code's Selected Index Changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlCarMake_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindModels();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 July 2013
    /// Description: Selected Index Changed Event Referal Source's Drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlSource_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetIsFleetLead();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
    /// Description: Selected Index Changed Event Of Where Did You Hear about PF's Drop Down List 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void ddlWhereDidUHear_SelectedIndexChanged(object sender, EventArgs e)ayyaj
    //{
    //    SetIsFleetLead();
    //}

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
    /// Description: Click Event Of Send Email Button 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSendEmail_Click(object sender, EventArgs e)
    {
        if (SendOneTimeMail(txtEmail1.Text.Trim()))
        {
            //Int64 result = objProspBM.UpdateOneTimeMailStatus(Convert.ToInt64(ViewState["ProspId"].ToString().Trim()), BasePage.UserSession.VirtualRoleId, true, EdSendEmail.Content.Trim(), true);
            //if (result > 0)
            //{
            //    lblAddSucMsg.Text = Resources.PFSalesResource.EmailSentSuccessfully.Trim();
            //    lblAddErrMsg.Text = string.Empty;
            //    dlSendMail.Visible = dvaserSuccess.Visible = dvadderror.Visible = dvsererror.Visible = false;
            //    dvaddSucc.Visible = true;
            //    lblAddSucMsg.Focus();
            //}
            //else
            //{
            //    lblAddSucMsg.Text = string.Empty;
            //    lblAddErrMsg.Text = Resources.PFSalesResource.EmailNotSent.Trim();
            //    dvaddSucc.Visible = dvaserSuccess.Visible = dvsererror.Visible = false;
            //    dlSendMail.Visible = dvadderror.Visible = true;
            //    lblAddErrMsg.Focus();
            //}
        }
        else
        {
            //Int64 result = objProspBM.UpdateOneTimeMailStatus(Convert.ToInt64(ViewState["ProspId"].ToString().Trim()), BasePage.UserSession.VirtualRoleId, false, EdSendEmail.Content.Trim(), false);
            //if (result > 0)
            //{
            //    lblAddSucMsg.Text = string.Empty;
            //    lblAddErrMsg.Text = Resources.PFSalesResource.EmailNotSent.Trim();
            //    dvaddSucc.Visible = dvaserSuccess.Visible = dvsererror.Visible = false;
            //    dlSendMail.Visible = dvadderror.Visible = true;
            //    lblAddErrMsg.Focus();
            //}
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 27 July 2013
    /// Description: Selected Index Changed Event Of Finance's Drop Down List 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void ddlFinance_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (ddlFinance.SelectedValue.Trim() != "1")
    //        {
    //            ddlFConsultant.SelectedValue = "0";
    //            ddlFConsultant.Enabled = false;
    //        }
    //        else
    //        {
    //            ddlFConsultant.SelectedValue = hdfFConsultID.Value.Trim();
    //            ddlFConsultant.Enabled = true;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Logger.Error(ex.Message + "UserControls_AddEditContact.ddlFinance_SelectedIndexChanged.Error:" + ex.StackTrace);
    //    }
    //}
    #endregion

    #region Methods

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Bind Grid View Data
    /// </summary>
    private void BindGrid()
    {
        //try
        //{
        //    objProsp.FName = txtserprospName.Text.Trim();
        //    objProsp.StatusId = Convert.ToInt64(ddlStatus.SelectedValue.Trim());
        //    objProsp.Email = txtEmailId.Text.Trim();
        //    DataTable Dt = objProspBM.GetAllProspects(objProsp);
        //    if (Dt != null & Dt.Rows.Count > 0)
        //    {
        //        DataView dV = Dt.DefaultView;
        //        dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
        //        gvprosp.DataSource = Dt;
        //        gvprosp.DataBind();
        //        ViewState["TotalRowCount"] = Dt.Rows.Count;
        //    }
        //    else
        //    {
        //        gvprosp.DataSource = null;
        //        gvprosp.DataBind();
        //        ViewState["TotalRowCount"] = "0";
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Logger.Error(ex.Message + "Prospects.BindGrid.Error:" + ex.StackTrace);
        //}
    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date: 20 Feb 2014
    /// Description: Bind Grid View Trade In Data
    /// </summary>
    private void BindGridTradeIn()
    {
        try
        {
            objProsp.ProspId =Convert.ToInt64( ViewState["ProspectId"].ToString());

            DataTable Dt = objProspBM.GetAllTradeInProspect(objProsp);
            if (Dt != null & Dt.Rows.Count > 0)
            {
                //DataView dV = Dt.DefaultView;
                //dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
                gvTradein.DataSource = Dt;
                gvTradein.DataBind();
                ViewState["TotalRowCount"] = Dt.Rows.Count;
            }
            else
            {
                gvTradein.DataSource = null;
                gvTradein.DataBind();
                ViewState["TotalRowCount"] = "0";
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindGrid.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date: 20 Feb 2014
    /// Description: Date
    /// </summary>
    private void addDate()
    {
        //txtEstimatedTimeOfDelivery.Text = "";
        ddlComplianceMonth.SelectedIndex = 0;
        ddlMonthBuild.SelectedIndex = 0;

        //ddlYearBuild.Items.Add("");
        ddlYearBuild.Items.Add("-Year-");
        for (int i = (System.DateTime.Now.Year) - 10; i <= (System.DateTime.Now.Year) + 2; i++)
        {
            //ddlYearBuild.Items.Add(i.ToString());
            ddlYearBuild.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }

        //ddlComplianceYear.Items.Add("");
        ddlComplianceYear.Items.Add("-Year-");
        for (int i = (System.DateTime.Now.Year) - 10; i <= (System.DateTime.Now.Year) + 2; i++)
        {
            //ddlComplianceYear.Items.Add(i.ToString());
            ddlComplianceYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date: 21 Feb 2014
    /// Description: Bind Grid View Trade In Data
    /// </summary>
    private void BindProspData()
    {
        try
        {
            ClearMsg();
            objProsp.ProspId = Convert.ToInt64(ViewState["ProspectId"].ToString());

            //DataTable Dt = objProspBM.GetAllTradeInProspect(objProsp);

            Int64 ProspId = Convert.ToInt64(objProsp.ProspId);
            //ViewState["ProspId"] = TradeId;
            if (ProspId > 0 && !string.IsNullOrEmpty(ProspId.ToString()))
            {
                //DataTable dt1 = objProspBM.GetTradeInFromId(TradeId);
                //Int64 ProspId = Convert.ToInt64(dt1.Rows[0]["ProspectId"].ToString().Trim());
                ViewState["ProspId"] = ProspId;
                DataTable dt = objProspBM.GetProspectsFromId(ProspId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    #region  Prospect
                    //if (BasePage.UserSession.RoleId != 1)
                    //    ddlFinance.Enabled = false;
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Title"].ToString().Trim()))
                        ddlTitle.SelectedValue = dt.Rows[0]["Title"].ToString().Trim();
                    txtAddName.Text = dt.Rows[0]["FName"].ToString().Trim() + " " + dt.Rows[0]["MName"].ToString().Trim() + " " + dt.Rows[0]["LName"].ToString().Trim();
                    txtAddName.Text = txtAddName.Text.Trim().Replace("  ", " ");
                    ShowEmployeeName();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FName"].ToString().Trim()))
                        txtFName.Text = dt.Rows[0]["FName"].ToString().Trim();//= ddlFName.SelectedValue
                    if (!string.IsNullOrEmpty(dt.Rows[0]["MName"].ToString().Trim()))
                        txtMName.Text = dt.Rows[0]["MName"].ToString().Trim();//= ddlMName.SelectedValue 
                    if (!string.IsNullOrEmpty(dt.Rows[0]["LName"].ToString().Trim()))
                        txtLName.Text = dt.Rows[0]["LName"].ToString().Trim();//= ddlLName.SelectedValue
                    //ddlCarMake.SelectedValue = dt.Rows[0]["CarMake"].ToString().Trim();
                    //ddlCarMake_SelectedIndexChanged(null, null);
                    hdfPhoneFormatId.Value = dt.Rows[0]["FormatedPhone"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FormatedPhone"].ToString().Trim()) && dt.Rows[0]["FormatedPhone"].ToString().Trim() != "0")
                        ddlPhFormat.SelectedValue = dt.Rows[0]["FormatedPhone"].ToString().Trim();
                    if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
                    {
                        ftePhNo.Enabled = false;
                        msePhNo.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
                        msePhNo.MaskType = AjaxControlToolkit.MaskedEditType.None;
                        msePhNo.Enabled = true;
                    }
                    else
                    {
                        ftePhNo.Enabled = true;
                        msePhNo.MaskType = AjaxControlToolkit.MaskedEditType.None;
                        msePhNo.Enabled = false;
                        msePhNo.Mask = "999999999999999999999999999999";
                    }
                    txtPhNo.Text = dt.Rows[0]["Phone"].ToString().Trim();
                    hdfMobileFormatId.Value = dt.Rows[0]["FormatedMobile"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FormatedMobile"].ToString().Trim()) && dt.Rows[0]["FormatedMobile"].ToString().Trim() != "0")
                        ddlPhFormat.SelectedValue = dt.Rows[0]["FormatedMobile"].ToString().Trim();
                    if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
                    {
                        fteMobile.Enabled = false;
                        mseMobile.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
                        mseMobile.MaskType = AjaxControlToolkit.MaskedEditType.None;
                        mseMobile.Enabled = true;
                    }
                    else
                    {
                        fteMobile.Enabled = true;
                        mseMobile.Mask = "999999999999999999999999999999";
                        mseMobile.MaskType = AjaxControlToolkit.MaskedEditType.None;
                        mseMobile.Enabled = false;
                    }
                    txtMobile.Text = dt.Rows[0]["Mobile"].ToString().Trim();
                    hdfAltContactId.Value = dt.Rows[0]["FormatedAltNo"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FormatedAltNo"].ToString().Trim()) && dt.Rows[0]["FormatedAltNo"].ToString().Trim() != "0")
                        ddlPhFormat.SelectedValue = dt.Rows[0]["FormatedAltNo"].ToString().Trim();
                    //if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")ayyaj
                    //{
                    //    fteAlteContNo.Enabled = false;
                    //    meeAltContNo.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
                    //    meeAltContNo.MaskType = AjaxControlToolkit.MaskedEditType.None;
                    //    meeAltContNo.Enabled = true;
                    //}
                    //else
                    //{
                    //    fteAlteContNo.Enabled = true;
                    //    meeAltContNo.Mask = "999999999999999999999999999999";
                    //    meeAltContNo.MaskType = AjaxControlToolkit.MaskedEditType.None;
                    //    meeAltContNo.Enabled = false;
                    //}
                    //txtAltContNo.Text = dt.Rows[0]["AltContNo"].ToString().Trim();
                    hdfFaxFormatId.Value = dt.Rows[0]["FormatedFax"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FormatedFax"].ToString().Trim()) && dt.Rows[0]["FormatedFax"].ToString().Trim() != "0")
                        ddlPhFormat.SelectedValue = dt.Rows[0]["FormatedFax"].ToString().Trim();
                    if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
                    {
                        fteFax.Enabled = false;
                        mseFax.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
                        mseFax.MaskType = AjaxControlToolkit.MaskedEditType.None;
                        mseFax.Enabled = true;
                    }
                    else
                    {
                        fteFax.Enabled = true;
                        mseFax.Mask = "999999999999999999999999999999";
                        mseFax.MaskType = AjaxControlToolkit.MaskedEditType.None;
                        mseFax.Enabled = false;
                    }
                    txtFax.Text = dt.Rows[0]["Fax"].ToString().Trim();
                    txtEmail1.Text = dt.Rows[0]["Email1"].ToString().Trim();
                    txtAlterEmail.Text = dt.Rows[0]["Email2"].ToString().Trim();
                    txtAddLine1.Text = dt.Rows[0]["Add1"].ToString().Trim();
                    txtAddLine2.Text = dt.Rows[0]["Add2"].ToString().Trim();
                    txtAddLine3.Text = dt.Rows[0]["Add3"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["CountryId"].ToString().Trim()))
                        ddlCountry.SelectedValue = dt.Rows[0]["CountryId"].ToString().Trim();
#region Hide
                    //BindAllStates();
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["StateId"].ToString().Trim()))
                    //    ddlState.SelectedValue = dt.Rows[0]["StateId"].ToString().Trim();
                    //BindAllPostalCode();
                    ////if (!string.IsNullOrEmpty(dt.Rows[0]["PostalCode"].ToString().Trim()))
                    ////    ddlPostalCode.SelectedValue = dt.Rows[0]["PostalCode"].ToString().Trim();ayyaj
                    //BindAllCities();
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["CityId"].ToString().Trim()))
                    //    ddlCity.SelectedValue = dt.Rows[0]["CityId"].ToString().Trim();
                    ////txtPostalCode.Text = dt.Rows[0]["PostalCode"].ToString().Trim();
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["ConsultantId"].ToString().Trim()))
                    //{
                    //    ddlConsultant.SelectedValue = dt.Rows[0]["ConsultantId"].ToString().Trim();
                    //    hdfConsultID.Value = dt.Rows[0]["ConsultantId"].ToString().Trim();
                    //}


                    //if (!string.IsNullOrEmpty(dt.Rows[0]["SourceId"].ToString().Trim()))ayyaj
                    //    ddlSource.SelectedValue = dt.Rows[0]["SourceId"].ToString().Trim();
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["MemberNo"].ToString().Trim()))
                    //    txtMemNo.Text = dt.Rows[0]["MemberNo"].ToString().Trim();
                    //txtFConsultant.Text = dt.Rows[0]["FConsultant"].ToString().Trim();ayyaj
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["FinanceConsultantId"].ToString().Trim()))
                    //{
                    //    ddlFConsultant.SelectedValue = dt.Rows[0]["FinanceConsultantId"].ToString().Trim();
                    //    hdfFConsultID.Value = dt.Rows[0]["FinanceConsultantId"].ToString().Trim();
                    //}
                    //hdfEnquryDate.Value = dt.Rows[0]["EnquiryDate"].ToString().Trim();
                    //txtReferredBy.Text = dt.Rows[0]["Leadsource"].ToString().Trim();ayyaj
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["Finance"].ToString().Trim()))ayyaj
                    //    ddlFinance.SelectedValue = dt.Rows[0]["Finance"].ToString().Trim();

                    //if (dt.Rows[0]["Finance"].ToString().Trim() == "1")
                    //    pnlFCDetails.Visible = true;
                    //else
                    //    pnlFCDetails.Visible = false;

                    //if (dt.Rows[0]["TradeIn"] != null && !string.IsNullOrEmpty(dt.Rows[0]["TradeIn"].ToString().Trim()))ayyaj
                    //    chkTradeIn.Checked = Convert.ToBoolean(dt.Rows[0]["TradeIn"].ToString().Trim());
                    //else
                    //    chkTradeIn.Checked = false;
                    //if (dt.Rows[0]["ModelId"] != null && !string.IsNullOrEmpty(dt.Rows[0]["ModelId"].ToString().Trim()))
                    //    ddlModel.SelectedValue = dt.Rows[0]["ModelId"].ToString().Trim();
                    //txtComments.Text = dt.Rows[0]["Comment"].ToString().Trim();ayyaj
                    //txtTradeInMakeModel.Text = dt.Rows[0]["TradeInMkModel"].ToString().Trim();
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["IsFleetLead"].ToString().Trim()))
                    //{
                    //    if (dt.Rows[0]["IsFleetLead"].ToString().Trim().ToUpper() == "YES")
                    //        hdfIsFleetLead.Value = "true";
                    //    else
                    //        hdfIsFleetLead.Value = "false";
                    //}
                    //else
                    //    hdfIsFleetLead.Value = "false";
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["WhereDidUHear"].ToString().Trim()))ayyaj
                    //    ddlWhereDidUHear.SelectedValue = dt.Rows[0]["WhereDidUHear"].ToString().Trim();
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["Used"].ToString().Trim()))
                    //{
                    //    if (dt.Rows[0]["Used"].ToString().Trim().ToUpper() == "YES")
                    //        rbtnUsed.Checked = true;
                    //    else
                    //        rbtnNew.Checked = true;
                    //}
                    //else
                    //    rbtnNew.Checked = true;
                    //if (dt.Rows[0]["IsMailSent"].ToString().Trim().ToUpper() == "YES")
                    //    dlSendMail.Visible = false;
                    //else
                    //{
                    //    dlSendMail.Visible = true;
                    //    SetContent(dt.Rows[0]["FName"].ToString().Trim());
                    //}
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["Make"].ToString().Trim().Replace("--", "")) && ((dt.Rows[0]["MakeFromId"].ToString().Trim().ToUpper() == "OTHER") || (Convert.ToInt64(dt.Rows[0]["CarMake"].ToString().Trim())) == 0))
                    //    lblActualMakeInput.Text = "(" + dt.Rows[0]["Make"].ToString().Trim() + ")";
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["Model"].ToString().Trim().Replace("--", "")) && dt.Rows[0]["ModelFromId"].ToString().Trim().ToUpper() == "OTHER")
                    //    lblActualModelInput.Text = "(" + dt.Rows[0]["Model"].ToString().Trim() + ")";

#endregion
                    #endregion
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindGrid.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Crearted By:Pravin Gholap
    /// Created Date:23 May 2013
    /// Description:Define the sort direction for sorting the grid view
    /// </summary>
    private void DefineSortDirection()
    {
        try
        {
            if (ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] != null)
            {
                if (ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString() == Cls_Constant.VIEWSTATE_ASC)
                {
                    ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;
                }
                else
                {
                    ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_ASC;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.DefineSortDirection.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Crearted By:Pravin Gholap
    /// Created Date:23 May 2013
    /// Description:Define the sort direction for sorting the Contact's grid view
    /// </summary>
    private void DefineContSortDirection()
    {
        try
        {
            if (ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] != null)
            {
                if (ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION1].ToString() == Cls_Constant.VIEWSTATE_ASC)
                {
                    ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = Cls_Constant.VIEWSTATE_DESC;
                }
                else
                {
                    ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = Cls_Constant.VIEWSTATE_ASC;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.DefineContSortDirection.Error:" + ex.StackTrace);
        }
    }
    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Get All Countries
    /// </summary>
    private void BindAllCountry()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllCountry(string.Empty);
            if (Dt != null && Dt.Rows.Count > 0)
            {
                Cls_BinderHelper.BindDropdownList(ddlCountry, "CountryName", "Id", Dt);
                Cls_BinderHelper.BindDropdownList(ddlPhPopUpCountry, "CountryName", "Id", Dt);
                ddlCountry.SelectedValue = "1";
                ddlCountry_SelectedIndexChanged(null, null);
            }
            else
            {
                Cls_BinderHelper.BindDropdownList(ddlCountry, "CountryName", "Id", null);
                Cls_BinderHelper.BindDropdownList(ddlPhPopUpCountry, "CountryName", "Id", null);
                ddlCountry_SelectedIndexChanged(null, null);
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindAllCountry.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Get All State
    /// </summary>
    private void BindAllStates()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllState(string.Empty, Convert.ToInt64(ddlCountry.SelectedValue.Trim()));
            Cls_BinderHelper.BindDropdownList(ddlState, "StateName", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindAllStates.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 7 June 2013
    /// Description: Get All Postal Codes
    /// </summary>
    private void BindAllPostalCode()
    {
        //try
        //{
        //    DataTable Dt = objMstBM.GetAllCity(string.Empty, Convert.ToInt64(ddlState.SelectedValue.Trim()));
        //    Cls_BinderHelper.BindDropdownList(ddlPostalCode, "PCode", "PCode", Dt);
        //}
        //catch (Exception ex)
        //{
        //    Logger.Error(ex.Message + "Prospects.BindAllPostalCode.Error:" + ex.StackTrace);
        //}
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 7 June 2013
    /// Description: Get All Cities
    /// </summary>
    private void BindAllCities()
    {
        try
        {
            //DataTable Dt = objMstBM.GetAllCitiesFromPCode(ddlPostalCode.SelectedValue.Trim());
            //Cls_BinderHelper.BindDropdownList(ddlCity, "CityName", "Id", Dt);

            DataTable Dt = new DataTable();
            //if (ddlPostalCode.Visible)
            //    Dt = objMstBM.GetAllCitiesFromPCode(ddlPostalCode.SelectedValue.Trim());
            //else
            //if (txtPostalCode.Visible)
            Dt = objMstBM.GetAllCitiesFromPCode(txtPostalCode.Text.Trim());
            Cls_BinderHelper.BindDropdownList(ddlCity, "CityName", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindAllCities.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Bind All Cantact Format
    /// </summary>
    private void BindFormats()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllFormats(Convert.ToInt64(ddlPhPopUpCountry.SelectedValue.Trim()));
            if (Dt != null && Dt.Rows.Count > 0)
            {
                Cls_BinderHelper.BindDropdownList(ddlPhFormat, "Format", "Id", Dt);
                DataRow[] Dr = Dt.Select("IsDefault=1");
                if (Dr != null && Dr.Count() > 0)
                {
                    ddlPhFormat.SelectedValue = Dr[0]["Id"].ToString().Trim();
                }
            }
            else
            {
                Cls_BinderHelper.BindDropdownList(ddlPhFormat, "Format", "Id", null);
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindDesignations.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Clear Add Employee Panel
    /// </summary>
    private void ClearAll()
    {
        lnkbtnSave.Visible = true;
        lnkbtnUpdate.Visible = false;
        ddlConsultant.SelectedValue = ddlCarMake.SelectedValue = "0";//ddlWhereDidUHear.SelectedValue = ayyajddlTitle.SelectedValue = 
        //ddlPhPopUpCountry.SelectedValue = ddlCountry.SelectedValue = "1";
        ddlCountry_SelectedIndexChanged(null, null);
        ddlState.SelectedValue = ddlGlasswork.SelectedValue = ddlEngine.SelectedValue = ddlBodyPanels.SelectedValue = ddlTransmission.SelectedValue = ddlPaint.SelectedValue = ddlBrakes.SelectedValue = ddlTyres.SelectedValue = ddlAC.SelectedValue = ddlRimsAlloys.SelectedValue = ddlHeadlights.SelectedValue = ddlUpholstery.SelectedValue = ddlSpareTyre.SelectedValue =  ddlWheelsAlloys.SelectedValue = ddlFuelType.SelectedValue = ddlDoor.SelectedValue =  "0";//ddlPostalCode.SelectedValue  = 
        ddlRating.SelectedIndex = ddlLogBook.SelectedIndex = ddlOwners.SelectedIndex= 0;
        ddlPostalCode_SelectedIndexChanged(null, null);
        ddlCarMake_SelectedIndexChanged(null, null);
        ddlModel.SelectedValue = "0";
        ddlCity.SelectedValue = "0";
        ddlComplianceMonth.SelectedIndex = -1;
        ddlComplianceYear.SelectedIndex = -1;
        ddlMonthBuild.SelectedIndex = -1;
        ddlYearBuild.SelectedIndex = -1;
        txtOdometer.Text = txtTransmission.Text = txtBodyStyle.Text = txtExtColor.Text = txtIntTrimColor.Text = txtRegoExpires.Text = txtOtherOptions.Text = txtDescDent.Text = txtAccident.Text = txtRepalce.Text = txtPayout.Text = txtAnything.Text = txtEngineType.Text = txtSeries.Text = string.Empty;//txtPostalCode.Text =ayyajtxtAltContNo.Text =txtComments.Text = txtReferredBy.Text = txtFName.Text = txtMName.Text = txtLName.Text = txtMemNo.Text = txtAddName.Text = txtPhNo.Text = txtMobile.Text = txtAddLine1.Text = txtAddLine2.Text = txtAddLine3.Text =txtFax.Text = txtEmail1.Text = txtAlterEmail.Text = 
        hdfPhPopType.Value = "";
        chkRevSensor.Checked = chkXenonLights.Checked = chkProtectProduct.Checked = chkActCruiseControl.Checked = chkTowBar.Checked = chkElectricSeats.Checked = chkBullBar.Checked = chkTint.Checked = chkSunroof.Checked = chkPanoramic.Checked = chkRoofRacks.Checked = chkTV.Checked = chkLeather.Checked = chkSideSteps.Checked = chkSatNav.Checked = chkThirdRowSeats.Checked = chkTimingBeltChange.Checked = chkLaneChangeAssist.Checked = chkBluetoothFactory.Checked = chkReverseCamera.Checked = chkFourByFour.Checked = chkTwoByTwo.Checked = false;
        BindFormats();
        SetDefaultFormat();
        //ddlAddStatus.SelectedValue = "1";
        //rbtnNew.Checked = true;ayyaj
        //rbtnUsed.Checked = false;
        //foreach (GridViewRow Row in gvContact.Rows)
        //{
        //    CheckBox chkbx = (CheckBox)Row.FindControl("chkSelect");
        //    RadioButton rbtn = (RadioButton)Row.FindControl("rbtnIsPrimary");
        //    if (chkbx != null && rbtn != null)
        //    {
        //        chkbx.Checked = false;
        //        rbtn.Checked = false;
        //        rbtn.Enabled = false;
        //    }
        //}
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Clear All Message's Text
    /// </summary>
    private void ClearMsg()
    {
        lblAddErrMsg.Text = lblAddSucMsg.Text = lblSerErrMsg.Text = lblSerSucMsg.Text = string.Empty;
        dvadderror.Visible = dvaddSucc.Visible = dvaserSuccess.Visible = dvsererror.Visible = false;
    }


    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Get All Makes
    /// </summary>
    private void BindAllMakes()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllMakes(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlCarMake, "Make", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindAllMakes.Error:" + ex.StackTrace);
        }
    }
    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Get All Statuses
    /// </summary>
    private void BindAllStatuses()
    {
        try
        {
            DataTable Dt = new DataTable();
            if (BasePage.UserSession.RoleId == 3 || BasePage.UserSession.RoleId == 1)
                Dt = objMstBM.GetAllStatus(1, 1);// Hard Coded Entity Id & Process Id
            if (BasePage.UserSession.RoleId == 5)
                Dt = objMstBM.GetAllStatus(6, 1);// Hard Coded Entity Id & Process I
            Cls_BinderHelper.BindDropdownList(ddlStatus, "Status", "Id", Dt);
            Cls_BinderHelper.BindDropdownList(ddlAddStatus, "Status", "Id", Dt);
            ddlAddStatus.SelectedValue = "1";
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindAllStatuses.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Bind Contact Grid View Data
    /// </summary>
    private void BindContacts()
    {
        //try
        //{
        //    DataTable Dt = objContBM.GetAllContacts(string.Empty, 0, BasePage.UserSession.VirtualRoleId);
        //    if (Dt != null & Dt.Rows.Count > 0)
        //    {
        //        DataView dV = Dt.DefaultView;
        //        dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION1].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION1].ToString());
        //        gvContact.DataSource = Dt;
        //        gvContact.DataBind();
        //    }
        //    else
        //    {
        //        gvContact.DataSource = null;
        //        gvContact.DataBind();
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Logger.Error(ex.Message + "Prospects.BindContacts.Error:" + ex.StackTrace);
        //}
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Get All Sources
    /// </summary>
    private void BindAllSources()
    {
        //try ayyaj
        //{
        //    DataTable Dt = objMstBM.GetAllSources(string.Empty);
        //    Cls_BinderHelper.BindDropdownList(ddlSource, "RefSource", "Id", Dt);
        //}
        //catch (Exception ex)
        //{
        //    Logger.Error(ex.Message + "Prospects.BindAllSources.Error:" + ex.StackTrace);
        //}
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Get All Consultants
    /// </summary>
    private void BindConsultant()
    {
        try
        {
            Employee objEmp = new Employee();
            objEmp.FName = string.Empty;
            objEmp.RoleId = 3;//Hard Code For Consultant
            DataTable Dt = objEmpBM.GetAllEmployee(objEmp);
            //Cls_BinderHelper.BindDropdownList(ddlConsultant, "Name", "VirtualRoleId", Dt);ayyaj
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindConsultant.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 May 2013
    /// Description: Show Prospect Name In Pop Up;
    /// </summary>
    private void ShowEmployeeName()
    {
        try
        {
            ArrayList arr = new ArrayList();
            arr.Add(Resources.PFSalesResource.ddlSelect.Trim());
            string[] names = txtAddName.Text.Trim().Split(' ');
            for (int i = 0; i < names.Length; i++)
            {
                if (!string.IsNullOrEmpty(names[i].Trim()) && !arr.Contains(names[i].Trim()))
                    arr.Add(names[i].Trim());
            }
            if (names.Length == 3)
            {
                if (!arr.Contains((names[0].Trim() + " " + names[1].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[0].Trim() + " " + names[1].Trim()))
                    arr.Add(names[0].Trim() + " " + names[1].Trim());
                if (!arr.Contains((names[1].Trim() + " " + names[0].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[1].Trim() + " " + names[0].Trim()))
                    arr.Add(names[1].Trim() + " " + names[0].Trim());
                if (!arr.Contains((names[0].Trim() + " " + names[2].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[0].Trim() + " " + names[2].Trim()))
                    arr.Add(names[0].Trim() + " " + names[2].Trim());
                if (!arr.Contains((names[2].Trim() + " " + names[0].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[2].Trim() + " " + names[0].Trim()))
                    arr.Add(names[2].Trim() + " " + names[0].Trim());
                if (!arr.Contains((names[1].Trim() + " " + names[2].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[1].Trim() + " " + names[2].Trim()))
                    arr.Add(names[1].Trim() + " " + names[2].Trim());
                if (!arr.Contains((names[2].Trim() + " " + names[1].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[2].Trim() + " " + names[1].Trim()))
                    arr.Add(names[2].Trim() + " " + names[1].Trim());
                if (!arr.Contains((names[0].Trim() + " " + names[1].Trim() + " " + names[2].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[0].Trim() + " " + names[1].Trim() + " " + names[2].Trim()))
                    arr.Add(names[0].Trim() + " " + names[1].Trim() + " " + names[2].Trim());
                if (!arr.Contains((names[0].Trim() + " " + names[2].Trim() + " " + names[1].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[0].Trim() + " " + names[2].Trim() + " " + names[1].Trim()))
                    arr.Add(names[0].Trim() + " " + names[2].Trim() + " " + names[1].Trim());
                if (!arr.Contains((names[1].Trim() + " " + names[0].Trim() + " " + names[2].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[1].Trim() + " " + names[0].Trim() + " " + names[2].Trim()))
                    arr.Add(names[1].Trim() + " " + names[0].Trim() + " " + names[2].Trim());
                if (!arr.Contains((names[1].Trim() + " " + names[2].Trim() + " " + names[0].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[1].Trim() + " " + names[2].Trim() + " " + names[0].Trim()))
                    arr.Add(names[1].Trim() + " " + names[2].Trim() + " " + names[0].Trim());
                if (!arr.Contains((names[2].Trim() + " " + names[1].Trim() + " " + names[0].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[2].Trim() + " " + names[1].Trim() + " " + names[0].Trim()))
                    arr.Add(names[2].Trim() + " " + names[1].Trim() + " " + names[0].Trim());
                if (!arr.Contains((names[2].Trim() + " " + names[0].Trim() + " " + names[1].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[2].Trim() + " " + names[0].Trim() + " " + names[1].Trim()))
                    arr.Add(names[2].Trim() + " " + names[0].Trim() + " " + names[1].Trim());
            }
            else if (names.Length == 2)
            {
                if (!arr.Contains((names[0].Trim() + " " + names[1].Trim()).Trim()) && !string.IsNullOrEmpty(names[0].Trim() + " " + names[1].Trim().Replace("  ", " ")))
                    arr.Add(names[0].Trim() + " " + names[1].Trim());
                if (!arr.Contains((names[1].Trim() + " " + names[0].Trim()).Trim()) && !string.IsNullOrEmpty(names[1].Trim() + " " + names[0].Trim().Replace("  ", " ")))
                    arr.Add(names[1].Trim() + " " + names[0].Trim());
            }
            ddlMName.DataSource = ddlFName.DataSource = ddlLName.DataSource = arr;
            txtPopUpName.Text = txtAddName.Text.Trim();
            ddlFName.DataBind();
            ddlMName.DataBind();
            ddlLName.DataBind();
            if (names.Length >= 3)
            {
                if (string.IsNullOrEmpty(hdfFName.Value))
                    ddlFName.SelectedIndex = 1;
                else
                    ddlFName.SelectedValue = hdfFName.Value.Trim();
                if (string.IsNullOrEmpty(hdfMName.Value))
                    ddlMName.SelectedIndex = 2;
                else
                    ddlMName.SelectedValue = hdfMName.Value.Trim();
                if (string.IsNullOrEmpty(hdfLName.Value))
                    ddlLName.SelectedIndex = 3;
                else
                    ddlLName.SelectedValue = hdfLName.Value.Trim();
            }
            else if (names.Length == 2)
            {
                if (string.IsNullOrEmpty(hdfFName.Value))
                    ddlFName.SelectedIndex = 1;
                else
                    ddlFName.SelectedValue = hdfFName.Value.Trim();
                if (!string.IsNullOrEmpty(hdfMName.Value))
                    ddlMName.SelectedValue = hdfMName.Value.Trim();
                else
                    ddlMName.SelectedValue = Resources.PFSalesResource.ddlSelect.Trim();
                if (string.IsNullOrEmpty(hdfLName.Value))
                    ddlLName.SelectedIndex = 2;
                else
                    ddlLName.SelectedValue = hdfLName.Value.Trim();
            }
            else if (names.Length == 1)
            {
                if (!string.IsNullOrEmpty(hdfFName.Value))
                    ddlFName.SelectedValue = hdfFName.Value;
                else
                    ddlFName.SelectedValue = Resources.PFSalesResource.ddlSelect.Trim();
                if (!string.IsNullOrEmpty(hdfMName.Value))
                    ddlMName.SelectedValue = hdfMName.Value.Trim();
                else
                    ddlMName.SelectedValue = Resources.PFSalesResource.ddlSelect.Trim();
                if (string.IsNullOrEmpty(hdfLName.Value))
                    ddlLName.SelectedIndex = 1;
                else
                    ddlLName.SelectedValue = hdfLName.Value.Trim();
            }

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindDesignations.SavePhoto.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 May 2013
    /// Description: Bind Professions To Drop Down List
    /// </summary>
    private void BindProfessions()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllProfessions(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlTitle, "Abbrivation", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.GetProfessions.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 14 June 2013
    /// Description: Get All Finance
    /// </summary>
    //private void BindFinance()
    //{
    //    try
    //    {
    //        DataTable Dt = objMstBM.GetAllFinance(string.Empty);
    //        Cls_BinderHelper.BindDropdownList(ddlFinance, "Finance", "Id", Dt);
    //    }
    //    catch (Exception ex)
    //    {
    //        Logger.Error(ex.Message + "Prospects.BindFinance.Error:" + ex.StackTrace);
    //    }
    //}

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 30 May 2013
    /// Description: Set Default Format For Phone, Mobile & Fax Number
    /// </summary>
    private void SetDefaultFormat()
    {
        if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
        {
            ftePhNo.Enabled = fteMobile.Enabled = fteFax.Enabled = false;//fteAlteContNo.Enabled = 
            msePhPopUp.Mask = mseFax.Mask = mseMobile.Mask = msePhNo.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");//meeAltContNo.Mask =
            msePhPopUp.Enabled = mseFax.Enabled = mseMobile.Enabled = msePhNo.Enabled = true;//meeAltContNo.Enabled =
        }
        else
        {
            ftePhNo.Enabled = fteMobile.Enabled = fteFax.Enabled = true;//fteAlteContNo.Enabled =
            msePhPopUp.Mask = mseFax.Mask = mseMobile.Mask = msePhNo.Mask = "99999999999999999999";//meeAltContNo.Mask = 
            msePhPopUp.Enabled = mseFax.Enabled = mseMobile.Enabled = msePhNo.Enabled = false;//meeAltContNo.Enabled =
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 14 June 2013
    /// Description: Send Email To Consultant 
    /// </summary>
    /// <param name="emilToId"></param>
    /// <param name="noOfLeads"></param>
    /// <param name="Name"></param>
    /// <returns></returns>
    private Boolean SendMail(string emilToId, int noOfLeads, string Name, bool IsFleetTeamLead)
    {
        string FileContent = string.Empty;
        try
        {
            Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
            //objEmailHelper.EmailFromID = ConfigurationManager.AppSettings["EmailFromID"].ToString();
            objEmailHelper.EmailSubject = "Lead Assignment";
            //objEmailHelper.SMTPServerIP = ConfigurationManager.AppSettings["SMTPServerIP"].ToString();
            //objEmailHelper.SMTPUserID = ConfigurationManager.AppSettings["SMTPUserID"].ToString();
            //objEmailHelper.SMTPUserPwd = ConfigurationManager.AppSettings["SMTPUserPwd"].ToString();
            objEmailHelper.EmailToID = emilToId;
            //objEmailHelper.EmailCcID = "pravin.gholap@mechsoftgroup.com";
            if (IsFleetTeamLead == false)
                FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + Name.Trim() + "<br /><br /> Please be advised that leads have been allocated.<br /><br /> Thanks you<br /> Quotacon</span>";
            else
                FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + Name.Trim() + "<br /><br /> Please be advised that <b>Fleat Team Leads</b> have been allocated.<br /><br /> Thanks you<br /> Quotacon</span>";

            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "EMail sent successfully", "Lead Assignment", "Add Prospect");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Lead Assignment", "Add Prospect");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.SendMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Lead Assignment", "Add Prospect");
            return false;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 14 June 2013
    /// Description: Send Email To Prospects 
    /// </summary>
    /// <param name="emilToId"></param>
    /// <param name="Name"></param>
    /// <param name="ConsultantName"></param>
    /// <param name="ConsultMobile"></param>
    /// <param name="ConsultEmail"></param>
    /// <param name="EnquiryDate"></param>
    /// <returns></returns>
    private Boolean SendProspectMail(string emilToId, string Name, string ConsultantName, string ConsultPhone, string ConsultEmail, string EnquiryDate, string ConsultExt)
    {
        string FileContent = string.Empty;
        string repEmail = BasePage.UserSession.EmailFromID;
        try
        {
            BasePage.UserSession.EmailFromID = ConsultEmail;
            Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
            //objEmailHelper.EmailFromID = ConfigurationManager.AppSettings["EmailFromID"].ToString();
            objEmailHelper.EmailSubject = "Private Fleet Introduction";
            //objEmailHelper.SMTPServerIP = ConfigurationManager.AppSettings["SMTPServerIP"].ToString();
            // objEmailHelper.SMTPUserID = ConfigurationManager.AppSettings["SMTPUserID"].ToString();
            //objEmailHelper.SMTPUserPwd = ConfigurationManager.AppSettings["SMTPUserPwd"].ToString();
            objEmailHelper.EmailToID = emilToId;
            ArrayList arrAttachments = new ArrayList();
            arrAttachments.Add(HttpContext.Current.Server.MapPath("~/Attachment/Private Fleet Trade-In Valuation Form.xls"));
            objEmailHelper.PostedFiles = arrAttachments;
            //objEmailHelper.EmailCcID = "pravin.gholap@mechsoftgroup.com";
            // string FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + Name.Trim() + "<br /><br /> With reference to your enquiry made on " + EnquiryDate.Trim() + " here we have asigned a consultant for you. Please find the consultant's details as given below<br /><br /><b>&nbsp;&nbsp; Name: </b>" + ConsultantName.Trim() + "<br/><b>&nbsp;&nbsp; Phone No.: </b>" + ConsultPhone.Trim() + "<br/><b>&nbsp;&nbsp; Email: </b>" + ConsultEmail.Trim() + "<br/><br/>Regards <br /> PF Sales</span>";
            FileContent = "<div style='font: 12px/17px arial,helvetica,'Liberation Sans',FreeSans,sans-serif;color: #333333;'>"
                                 + "Dear " + Name.Trim() + ",<br><br> My name is " + ConsultantName + ".  I am delighted to let you know that I have been assigned as your dedicated new vehicle purchasing officer, I am responsible for assisting you with your car purchase from start to finish.  This includes"
                                 + "<br><br><ul><li> Initial <b>advice</b> as to vehicle selection,</li><li>arranging <b>test-drives</b> if you so wish, </li><li> <b>Valuation</b> of your trade-in vehicle if applicable, and</li><li>tendering out to our extensive dealer network to get you the best possible <b>fleet discount pricing</b>.</li></ul>"
                                 + "<br><br>To provide this service effectively, I need a very clear and specific idea of what exactly you are looking for - not just in terms of the vehicle specifications, but also when delivery is required, preferred financial arrangements etc."
                                 + "<br><br>if you want to find out more about who we are and who we are associated with please refer to the <a href='http://www.privatefleet.com.au/about-us/'>About Us</a> section on our website, view our <a href='http://www.youtube.com/watch?v=OPAFGKn8p4Y'>How it Works</a> video on Youtube or visit the <a href='http://www.more4members.com.au/offer/Private-Fleet.html'>NRMA website</a>."
                                 + "<br><br>Below are my contact details so please don't hesitate to call if you have any queries. Otherwise, I will be in touch with you in the very near future."
                                 + "<br><br>Please be aware we are very busy at the moment, If your vehicle requirements are <span style='color:Red'>URGENT</span> please call me so that I can grab the details and get it underway for you."
                                 + "<br><br>Thank you again for your enquiry - I very much look forward to being of assistance."
                                 + "<br><br><h3 style='color:#0000CC'>" + ConsultantName.Trim() + "</h3>"
                                 + "Key Account Manager"
                                 + "<br><h3 style='color:#0000CC'>Private Fleet</h3>" + "<span style='Font:11px'><i style='color:#0000CC'> – Car Buying Made Easy</i></span>"
                                 + "<br><br><span style='Font:11px'>Lvl 2 845 Pacific Hwy </span>" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + " <span style='Font:11px' >Tel: 1300 303 181 " + ((!string.IsNullOrEmpty(ConsultExt.Trim())) ? ("(" + ConsultExt.Trim() + ")") : "") + "</span>"
                                 + "<br><span style='Font:11px'>Chatswood NSW 2067 </span>" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + " <span style='Font:11px' >Fax: 1300 303 981 </span> "
                                 + "<br><span style='Font:11px'>ABN: 70 080 056 408 | Dealer Lic: MD 19913 </span>" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "<a href='http://www.privatefleet.com.au' style='Font:11px'>www.PrivateFleet.com.au</a></div> ";
            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBM.SaveEmailDetails(emilToId, ConsultEmail.Trim(), FileContent.Trim(), "EMail sent successfully", "Private Fleet Introduction", "Add Prospect");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails(emilToId, ConsultEmail.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Private Fleet Introduction", "Add Prospect");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.SendProspectMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, ConsultEmail.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException), "Private Fleet Introduction", "Add Prospect");
            return false;
        }
        finally
        {
            BasePage.UserSession.EmailFromID = repEmail;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Get All Makes
    /// </summary>
    private void BindModels()
    {
        try
        {
            DataTable Dt = objMstBM.GetModelFromMakeId(Convert.ToInt32(ddlCarMake.SelectedValue.Trim()));
            Cls_BinderHelper.BindDropdownList(ddlModel, "Model", "ID", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindAllMakes.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
    /// Description: Bind Where You Hear About PF Values
    /// </summary>
    private void BindWUHValues()
    {
        try
        {
            //DataTable Dt = objMstBM.GetAllWUHValues(string.Empty);ayyaj
            //Cls_BinderHelper.BindDropdownList(ddlWhereDidUHear, "ValueforAnswer", "ID", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindWUHValues.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
    /// Description: Set Whether Prospect is fleet Lead Or Not
    /// </summary>
    private void SetIsFleetLead()
    {
        //if (ddlSource.SelectedValue.Trim() != "0") ayyaj
        //{
        //    DataTable dt = objMstBM.GetProspSrcDetFromId(Convert.ToInt32(ddlSource.SelectedValue.Trim()));
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        if (!string.IsNullOrEmpty(dt.Rows[0]["IsFleetTeamLead"].ToString().Trim()))
        //        {
        //            if (dt.Rows[0]["IsFleetTeamLead"].ToString().Trim().ToLower() == "yes")
        //                hdfIsFleetLead.Value = "true";
        //            else
        //                hdfIsFleetLead.Value = "false";
        //        }
        //        else
        //            hdfIsFleetLead.Value = "false";
        //    }
        //    else
        //        hdfIsFleetLead.Value = "false";
        //}
        //else
        //    hdfIsFleetLead.Value = "false";

        if (hdfIsFleetLead.Value.ToUpper() == "FALSE")
        {
            //if (ddlWhereDidUHear.SelectedValue.Trim() != "0")ayyaj
            //{
            //    DataTable dt = objMstBM.GetWUHFromId(Convert.ToInt32(ddlWhereDidUHear.SelectedValue.Trim()));
            //    if (dt != null && dt.Rows.Count > 0)
            //    {
            //        if (!string.IsNullOrEmpty(dt.Rows[0]["IsFleetLead"].ToString().Trim()))
            //        {
            //            if (dt.Rows[0]["IsFleetLead"].ToString().Trim().ToLower() == "yes")
            //                hdfIsFleetLead.Value = "true";
            //            else
            //                hdfIsFleetLead.Value = "false";
            //        }
            //        else
            //            hdfIsFleetLead.Value = "false";
            //    }
            //    else
            //        hdfIsFleetLead.Value = "false";
            //}
            //else
            //    hdfIsFleetLead.Value = "false";
        }
        else
            hdfIsFleetLead.Value = "true";
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
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
            BasePage.UserSession.EmailFromID = txtEmail1.Text.Trim();
            Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
            objEmailHelper.EmailSubject = "Trouble contacting by phone";
            objEmailHelper.EmailToID = emilToId;
            //FileContent = EdSendEmail.Content.Trim();ayyaj
            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "EMail sent successfully", "Trouble contacting by phone", "Add Prospect");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Trouble contacting by phone", "Add Prospect");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.SendOneTimeMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Trouble contacting by phone", "Add Prospect");
            return false;
        }
        finally
        {
            BasePage.UserSession.EmailFromID = repEmail;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
    /// Description: Send Email To Consultant 
    /// </summary>
    private void SetContent(string ProspectName)
    {
        try
        {
            string FileContent = string.Empty;
            if (BasePage.UserSession.FName != null && BasePage.UserSession.UserEmail != null && BasePage.UserSession.PhExtension != null && BasePage.UserSession.MobileNo != null && !string.IsNullOrEmpty(BasePage.UserSession.FName.Trim()) && !string.IsNullOrEmpty(BasePage.UserSession.UserEmail.Trim()) && !string.IsNullOrEmpty(BasePage.UserSession.MobileNo.Trim()) && !string.IsNullOrEmpty(BasePage.UserSession.PhExtension.Trim()))
            {
                FileContent = "<div style='font: 12px/17px arial,helvetica,'Liberation Sans',FreeSans,sans-serif;color: #333333;'>"
                                        + "Hi " + ProspectName.Trim() + "<br /><br />Thank you for your enquiry. I have just tried to contact you with no success."
                                        + "<br /><br />In any event, I am intending to go forward and organise a great deal for you on your new car, though I need to ask you some questions before we can get this started."
                                        + "<br /><br />When you have a minute would you mind giving me a call on (1300 303 181) -my extension is." + BasePage.UserSession.PhExtension.Trim()
                                        + "<br /><br />I look forward to being able to help you when you have a minute to talk."
                                        + "<br /><br />Kind regards,"
                    // + "<br /><br />" + BasePage.UserSession.FName.Trim() 
                                        + "<br /><br />" + ((!string.IsNullOrEmpty(BasePage.UserSession.FullName.Trim())) ? (BasePage.UserSession.FullName.Trim()) : BasePage.UserSession.FName.Trim())
                                        + "<br />Senior Purchasing Officer"
                                        + "<br />Private Fleet - Car Buying Made Easy"
                                        + "<br><span style='Font:11px'>Lvl 2 845 Pacific Hwy </span>" + "<br /><br /><span style='Font:11px' >Tel: 1300 303 181 " + ((!string.IsNullOrEmpty(BasePage.UserSession.PhExtension.Trim())) ? ("(" + BasePage.UserSession.PhExtension.Trim() + ")") : "") + ((!string.IsNullOrEmpty(BasePage.UserSession.MobileNo.Trim())) ? (" (M)" + BasePage.UserSession.MobileNo.Trim() + ")") : " ") + "</span>"
                                        + "<br><br /><span style='Font:11px'>Chatswood NSW 2067 </span><br /><br /><span style='Font:11px' >Fax: 1300 303 981 </span> "
                                        + "<br><br /><span style='Font:11px'>ABN: 70 080 056 408 | Dealer Lic: MD 19913 </span><br /><br /><a href='http://www.privatefleet.com.au' style='Font:11px'>www.PrivateFleet.com.au</a></div> ";
                //+ "<br />Private Fleet - Car Buying Made Easy"
                //+ "<br />Lvl 2 845 Pacific Hwy"
                //+ "<br />Tel: 1300 303 181" + ((!string.IsNullOrEmpty(BasePage.UserSession.PhExtension.Trim())) ? ("(" + BasePage.UserSession.PhExtension.Trim() + ")") : " ") + ((!string.IsNullOrEmpty(BasePage.UserSession.MobileNo.Trim())) ? (" (M)" + BasePage.UserSession.MobileNo.Trim() + ")") : " ")
                //+ "<br/>Chatswood NSW 2067"
                //+ "<br/>Fax: 1300 303 981"
                //+ "<br/>ABN: 70 080 056 408 | Dealer Lic: MD 19913"
                //+ "<br/>www.privatefleet.com.au<http://www.privatefleet.com.au></div>";
                //EdSendEmail.Content = FileContent.Trim();ayyaj
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.SetContent.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 July 2013
    /// Description: Save Default Activity For Call When Assignment is done
    /// </summary>
    private void SaveDefaultActivity(string Name, Int64 Id, double noOfMinutes)
    {
        try
        {
            string DefaultTime = ConfigurationManager.AppSettings["DefualtActStartTime"].ToString().Trim();
            StringBuilder strIds = new StringBuilder();
            objActivity.Id = 0;
            objActivity.ParrentActId = 0;
            objActivity.ActivityTypeId = 1;//Hard code for Activity Type "Call"
            objActivity.Regarding = "Assignment Call To: " + Name.Trim();
            objActivity.Regardings = "Assignment Call To: " + Name.Trim();
            objActivity.PriorityId = 2;//Hard code for Priority "Moderate"
            if (Id > 0)
                objActivity.ProspectId = Id;
            else
                objActivity.ProspectId = 0;

            DateTime StartTime = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + DefaultTime);
            objActivity.ActStartTime = StartTime;//DateTime.Now.AddMinutes(noOfMinutes);// Deafult Start Time 10 Min After Lead Assignment
            objActivity.ActEndTime = StartTime.AddMinutes(2);// Deafult End Time 2 Min After Start Time

            if (StartTime != null)//!string.IsNullOrEmpty(txtActTime.Text.Trim())
            {
                objActivity.ActStartTime = StartTime;
                GetCountOfActForStime(objActivity.ActStartTime, TimeSpan1, Convert.ToInt64(ddlConsultant.SelectedValue.Trim()));
                DateTime dt;
                if (ViewState["NewStartDate"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["NewStartDate"]).Trim()))
                    dt = objActivity.ActStartTime = Convert.ToDateTime(Convert.ToString(ViewState["NewStartDate"]).Trim());
                else
                    dt = StartTime;//txtActTime.Text.Trim()
                objActivity.ActEndTime = dt.AddMinutes(2);//Convert.ToDateTime(txtEndDate.Text.Trim() + " " + txtEndTime.Text.Trim());
            }


            objActivity.IsTimeLess = false;
            objActivity.IsPrivate = false;
            objActivity.Status = 0;
            objActivity.Duration = 2;
            objActivity.ActivityDocId = 0;
            objActivity.ActivityDocRemark = string.Empty;
            objActivity.ActivityDocFilePath = string.Empty;
            objActivity.Location = string.Empty;
            List<ActResources> lstResources = new List<ActResources>();
            List<ActAlertDetails> lstActAlerts = new List<ActAlertDetails>();
            ActResources objActResource = new ActResources();
            objActResource.ResourceId = Convert.ToInt64(ddlConsultant.SelectedValue.Trim());// BasePage.UserSession.VirtualRoleId;
            lstResources.Add(objActResource);
            string[] array = strIds.ToString().TrimEnd(',').Split(',');
            ActAlertDetails objActAlertDetails = new ActAlertDetails();
            //  objActAlertDetails.AlertTypeId = Cls_Constant.MailAlert;// Hard Coded For Email
            //  objActAlertDetails.AlertValueBefore = 0;// If Zero Minutes Alarm Value Selected
            //   objActAlertDetails.SnoozValue = 0;
            // objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// //array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
            // lstActAlerts.Add(objActAlertDetails);
            // ActAlertDetails objActAlertDetails1 = new ActAlertDetails();
            //  objActAlertDetails1.AlertTypeId = Cls_Constant.DashBoardAlert;// Hard Coded For Dashboard Alert
            //   objActAlertDetails1.AlertValueBefore = 0;// If Zero Minutes Alarm Value Selected
            //  objActAlertDetails1.SnoozValue = 0;
            // objActAlertDetails1.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();//array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
            // lstActAlerts.Add(objActAlertDetails1);
            objActivity.LstAlertDetails = lstActAlerts;
            objActivity.LstReources = lstResources;
            objActivity.CreatedById = BasePage.UserSession.VirtualRoleId;
            objActivity.IsDeleted = false;
            Int64 Result = 0;
            Result = objActivityBM.AddActivity(objActivity);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.saveDefaultActivity.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 13 Aug 2013
    /// Description: Set Allocated Date Time For Prospect Id
    /// </summary>
    /// <param name="ConsultantId"></param>
    /// <param name="ProspId"></param>
    /// <param name="CreatedById"></param>
    /// <returns></returns>
    private void SetAllocatedDate(Int64 ConsultantId, Int64 ProspId, Int64 CreatedById)
    {
        try
        {
            objActivityBM.SetAllocatedDate(ConsultantId, ProspId, CreatedById);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.saveDefaultActivity.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 13 Aug 2013
    /// Description: Set Allocated Date Time For Prospect Id
    /// </summary>
    /// <param name="ConsultantId"></param>
    /// <param name="ProspId"></param>
    /// <param name="CreatedById"></param>
    /// <returns></returns>
    private void SetFAllocatedDate(Int64 ConsultantId, Int64 ProspId, Int64 CreatedById)
    {
        try
        {
            objActivityBM.SetFAllocatedDate(ConsultantId, ProspId, CreatedById);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.SetFAllocatedDate.Error:" + ex.StackTrace);
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
            //objEmailHelper.EmailCcID = "pravin.gholap@mechsoftgroup.com";
            FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + Name.Trim() + "<br /><br /> Duplicate Lead is reported for the lead which is already allocated to you, Please find the details as given bellow.<br /><br /> Name:" + prospName.Trim() + "<br /><br /> Email:" + prospEmail.Trim() + "<br /><br />Thanks you<br /> PFSales Team</span>";
            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "EMail sent successfully", "Duplicate Lead Notified", "Add Prospect");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Duplicate Lead Notified", "Add Prospect");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.SendMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Duplicate Lead Notified", "Add Prospect");
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
            //objEmailHelper.EmailCcID = "pravin.gholap@mechsoftgroup.com";
            FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + Name.Trim() + "<br /><br /> Duplicate Lead is reported for the lead which is already allocated to you, Please find the details as given bellow.<br /><br /> Name:" + prospName.Trim() + "<br /><br /> Email:" + prospEmail.Trim() + "<br /><br />Thanks you<br /> PFSales Team</span>";
            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "EMail sent successfully", "Duplicate Lead Notified", "Add Prospect");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Duplicate Lead Notified", "Add Prospect");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.SendMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Duplicate Lead Notified", "Add Prospect");
            return false;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 30 Aug 2013
    /// Description: Get Number Of Activities Added for Only Notes
    /// </summary>
    /// <param name="startTime"></param>
    /// <returns></returns>
    private void GetCountOfActForStime(DateTime startTime, double interval, Int64 ConsultantId)
    {
        try
        {
            DateTime dt = startTime;
            Int64 ACount = objActivityBM.GetCountOfActForStime(ConsultantId, startTime);
            if (ACount >= 2)
            {
                GetCountOfActForStime(startTime.AddMinutes(interval), interval, ConsultantId);
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
                Cls_DataAccess.getInstance().AddInParameter(cmd, "@CreatedById ", DbType.String, BasePage.UserSession.VirtualRoleId);

                object obj = Cls_DataAccess.getInstance().ExecuteScaler(cmd, null);
                int Result = Convert.ToInt32(obj);
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.UpdateFinCarLeads.Error:" + ex.StackTrace);
            return "Error in connection";
        }
        return "Success";
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 15 Sept 2013
    /// Description: Bind Finance Request Came From Drop Down List
    /// </summary>
    private void BinFinReqFrom()
    {
        try
        {
            //DataTable Dt = objMstBM.GetFinReqFrom();
            //Cls_BinderHelper.BindDropdownList(ddlFinReqFrom, "FinFor", "ID", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.BinFinReqFrom.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 9 Sep 2013
    /// Description: Get All Finance Consultants
    /// </summary>
    //private void BindFConsultant()
    //{
    //    try
    //    {
    //        Employee objEmp = new Employee();
    //        objEmp.FName = string.Empty;
    //        objEmp.RoleId = 5;//Hard Code For Finance Consultant
    //        DataTable Dt = objEmpBM.GetAllEmployee(objEmp);
    //        Cls_BinderHelper.BindDropdownList(ddlFConsultant, "Name", "VirtualRoleId", Dt);
    //        if (BasePage.UserSession.RoleId == 5)
    //            ddlFConsultant.SelectedValue = BasePage.UserSession.VirtualRoleId.ToString().Trim();
    //    }
    //    catch (Exception ex)
    //    {
    //        Logger.Error(ex.Message + "UserControls_AddEditContact.BindFConsultant.Error:" + ex.StackTrace);
    //    }
    //}
    #endregion
}
