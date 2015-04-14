﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mechsoft.PFSales.BusinessEntity;
using Mechsoft.PFSales.BusinessManager;
using log4net;
using Mechsoft.GeneralUtilities;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Text;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Data.Common;

public partial class UserControls_AddEditContact : System.Web.UI.UserControl
{
    #region Global Variables
    Prospect objProsp = new Prospect();
    ProspectBM objProspBM = new ProspectBM();
    MasterBM objMstBM = new MasterBM();
    EmployeeBM objEmpBM = new EmployeeBM();
    ContactBM objContBM = new ContactBM();
    ILog Logger = LogManager.GetLogger(typeof(UserControls_AddEditContact));
    Activity objActivity = new Activity();
    ActivityBM objActivityBM = new ActivityBM();
    City objCity = new City();
    double TimeSpan1 = Convert.ToDouble(ConfigurationManager.AppSettings["ActInterval"].ToString().Trim());
    string isFc;
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = "status";
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "Name";
            ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;

            //BindAllStatuses();
            //BindGrid();
            //BindAllCountry();
            //BindFormats();
            //BindAllMakes();
            //BindAllSources();
            //BindConsultant();
            //BindFConsultant();
            //BindContacts();
            //BindProfessions();
            //BindFinance();
            //BindWUHValues();
            //BinFinReqFrom();

            txtserprospName.Focus();

            //rfvCarMake.Enabled = Request[ddlCarMake.UniqueID] == "2" ? false : true;
            //int ProspId= ViewState["ProspId"];
            //if (ProspId > 0)
            //{
            //    DataTable dt = objProspBM.GetProspectsFromId(ProspId);
            //    if (dt != null && dt.Rows.Count > 0)
            //    { }
            //}

            if (Session["FromMasterPage"] != null)
            {
                if (Boolean.Parse(Session["FromMasterPage"].ToString().Trim()))
                {
                    Session["FromMasterPage"] = false;
                    lnkbtnAddprosp_Click(null, null);
                }
            }

            if (BasePage.UserSession.RoleId == 1)
                ddlConsultant.Enabled = ddlFConsultant.Enabled = true;
            else
                ddlConsultant.Enabled = ddlFConsultant.Enabled = false;
            Page.MaintainScrollPositionOnPostBack = true;
            /// <summary>
            /// Created By: Ayyaj Mujawar
            /// Created Date: 3 Oct 2013
            /// Description: To disable Required Field Validation On car Make and Model
            /// </summary>

            rfvCarMake.Enabled = false;
            rfvModel.Enabled = false;

            if (BasePage.UserSession.RoleId == 1)
            {
                ddlPostalCode.Visible = rfvStatus.Enabled = rfvCarMake.Enabled = rfvPhone.Enabled = rfvState.Enabled = rfvModel.Enabled = rfvCountry.Enabled = rfvPostalCode.Enabled = rfvReferredBy.Enabled = false;
                rfvPCode.Enabled = txtPostalCode.Visible = true;
            }
            else if (BasePage.UserSession.RoleId == 3)
            {
                //ddlPostalCode.Visible = rfvStatus.Enabled = rfvCarMake.Enabled = rfvPhone.Enabled = rfvState.Enabled = rfvModel.Enabled = rfvCountry.Enabled = rfvPostalCode.Enabled = rfvReferredBy.Enabled = true;
                //rfvPCode.Enabled = txtPostalCode.Visible = false;
                ddlPostalCode.Visible = rfvStatus.Enabled = rfvCarMake.Enabled = rfvPhone.Enabled = rfvState.Enabled = rfvModel.Enabled = rfvCountry.Enabled = rfvPostalCode.Enabled = rfvReferredBy.Enabled = false;
                rfvPCode.Enabled = txtPostalCode.Visible = true;
            }
            else if (BasePage.UserSession.RoleId == 5)
            {
                ddlPostalCode.Visible = rfvStatus.Enabled = rfvCarMake.Enabled = rfvPhone.Enabled = rfvState.Enabled = rfvModel.Enabled = rfvCountry.Enabled = rfvPostalCode.Enabled = rfvReferredBy.Enabled = false;
                rfvPCode.Enabled = txtPostalCode.Visible = true;
            }
            else
            {
                ddlPostalCode.Visible = rfvStatus.Enabled = rfvCarMake.Enabled = rfvPhone.Enabled = rfvState.Enabled = rfvModel.Enabled = rfvCountry.Enabled = rfvPostalCode.Enabled = rfvReferredBy.Enabled = true;
                rfvPCode.Enabled = txtPostalCode.Visible = true;
            }

            /// Description: To check it is PF Or Fc and Enable And disable Required Field Validation On car Make and Model
            //if (Session["isPForFC"] != null)
            //{
            //    string isPFOrFC = Session["isPForFC"].ToString().ToUpper().Trim();
            //    //string isPFOrFC = dt.Rows[0]["isPFOrFC"].ToString().Trim().ToUpper();
            //    if (isPFOrFC == "F")
            //    {
            //        rfvCarMake.Enabled = false;
            //        rfvModel.Enabled = false;
            //    }
            //    else
            //    {
            //        rfvCarMake.Enabled = true;
            //        rfvModel.Enabled = true;
            //    }
            //}

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
        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 3 Oct 2013
        /// Description: To check it is PF Or Fc and Enable And disable Required Field Validation On car Make and Model
        /// </summary>

        //if (Session["isPForFC"] != null)
        //{
        //    string isPFOrFC = Session["isPForFC"].ToString().ToUpper().Trim();
        //    //string isPFOrFC = dt.Rows[0]["isPFOrFC"].ToString().Trim().ToUpper();
        //    if (isPFOrFC == "F")
        //    {
        //        rfvCarMake.Enabled = false;
        //        rfvModel.Enabled = false;
        //    }
        //    else
        //    {
        //        rfvCarMake.Enabled = true;
        //        rfvModel.Enabled = true;
        //    }
        //}
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
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

    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Gridview Page Index Changing Event. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvprosp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvprosp.PageIndex = e.NewPageIndex;
            //BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.gvprosp_PageIndexChanging Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
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
            // BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.gvprosp_Soring.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
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
                HiddenField hdfFinance = (HiddenField)e.Row.FindControl("hdfFinance");
                HiddenField hdfIsFleetTeamLead = (HiddenField)e.Row.FindControl("hdfIsFleetTeamLead");
                string lblName = ((Label)e.Row.FindControl("lblprospName")).Text.Trim();
                lnkBtnDelete.Attributes.Add("onclick", "javascript:return confirm('" + Resources.PFSalesResource.ProspectDeleteConfirm.Trim() + " " + lblName + "?')");
                //if (hdfFinance != null && !string.IsNullOrEmpty(hdfFinance.Value.Trim()))
                //{
                //    if (Convert.ToInt64(hdfFinance.Value.Trim()) == 1)
                //        e.Row.BackColor = System.Drawing.Color.FromName("#D6FFBC");
                //}
                if (hdfIsFleetTeamLead != null && !string.IsNullOrEmpty(hdfIsFleetTeamLead.Value.Trim()))
                {
                    if (hdfIsFleetTeamLead.Value.Trim().ToUpper() == "YES")
                        e.Row.BackColor = System.Drawing.Color.FromName("#FFCDCD");

                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.gvprosp_RowDataBound.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Edit Button Click. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnEdit_Click(object sender, EventArgs e)
    {
        Int64 ProspId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
        EditContact(ProspId);
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
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
                //BindGrid();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.lnkbtnDelete_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Search Button Click. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSearch_Click(object sender, EventArgs e)
    {
        // BindGrid();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Clear Button Click. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnClear_Click(object sender, EventArgs e)
    {
        txtserprospName.Text = string.Empty;
        ddlStatus.SelectedValue = "0";
        txtserprospName.Focus();
        //BindGrid();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Selected Index Changed Event Of Status's Drop Down List. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindGrid();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Back To Search Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnBackToSearch_Click(object sender, EventArgs e)
    {
        ViewState["ProspId"] = 0;
        // BindGrid();
        pnlSearchprosp.Visible = true;
        pnlAddProsp.Visible = false;
        ClearMsg();
        txtserprospName.Focus();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Mobile Format Pop Up Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnMobile_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hdfMobileFormatId.Value.Trim()))
        {
            ddlPhFormat.SelectedValue = hdfMobileFormatId.Value.Trim();
            //ListItem selectedMobileFormatId = ddlPhFormat.Items.FindByValue(hdfMobileFormatId.Value.Trim());
            //if (selectedMobileFormatId != null)
            //    selectedMobileFormatId.Selected = true;
        }
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
    /// Created Date: 24 July 2013
    /// Description: Phone Format Pop Up Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnPhPopUp_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hdfPhoneFormatId.Value.Trim()))
        {
            //ListItem selectedPhoneFormatId = ddlPhFormat.Items.FindByValue(hdfPhoneFormatId.Value.Trim());
            //if (selectedPhoneFormatId != null)
            //    selectedPhoneFormatId.Selected = true;
            ddlPhFormat.SelectedValue = hdfPhoneFormatId.Value.Trim();
        }
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
    /// Created Date: 24 July 2013
    /// Description: Phone Format Pop Up Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFax_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hdfFaxFormatId.Value.Trim()))
        {
            //ListItem selectedFaxFormatId = ddlPhFormat.Items.FindByValue(hdfFaxFormatId.Value.Trim());
            //if (selectedFaxFormatId != null)
            //    selectedFaxFormatId.Selected = true;
            ddlPhFormat.SelectedValue = hdfFaxFormatId.Value.Trim();
        }
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
    /// Created Date: 24 July 2013
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
    /// Created Date: 24 July 2013
    /// Description: Selected Index Changed Event Of State's Drop Down List 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindAllPostalCode();
        ClearMsg();
        Session["StateId"] = ddlState.SelectedValue.Trim();
        ddlPostalCode_SelectedIndexChanged(null, null);
        BindAllCities();
        //ddlPostalCode.Focus();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Save Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ShowEmployeeName();
            Int64 Result = 0;
            if (ViewState["ProspId"] != null && BasePage.UserSession != null)
            {
                objProsp.ProspId = Convert.ToInt64(ViewState["ProspId"].ToString().Trim());
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
                objProsp.AltContact = txtAltContNo.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
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
                objProsp.FConsultant = txtFConsultant.Text.Trim();
                objProsp.FConsultId = Convert.ToInt64(ddlFConsultant.SelectedValue.Trim());
                objProsp.ConsultId = Convert.ToInt64(ddlConsultant.SelectedValue.Trim());
                if (BasePage.UserSession.RoleId == 3 || BasePage.UserSession.RoleId == 1)
                    objProsp.StatusId = Convert.ToInt64(ddlAddStatus.SelectedValue.Trim());
                if (BasePage.UserSession.RoleId == 5)
                    objProsp.StatusId = Convert.ToInt64(ddlAddStatus.SelectedValue.Trim());
                //Commented By:Ayyaj For Time Being on 02 Dec 2014
                //objProsp.FCStatusId = Convert.ToInt64(ddlAddStatus.SelectedValue.Trim());
                objProsp.SourceId = Convert.ToInt64(ddlSource.SelectedValue.Trim());
                objProsp.StateId = Convert.ToInt32(ddlState.SelectedValue.Trim());
                objProsp.CityId = Convert.ToInt64(ddlCity.SelectedValue.Trim());
                if (Session["ForW"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["ForW"]).Trim()))
                {
                    if (Convert.ToString(Session["ForW"]).Trim().ToUpper() == "W")
                    {
                        if (ddlPostalCode.Visible)
                        {
                            objProsp.PostalCode = ddlPostalCode.SelectedValue.Trim();
                        }
                        else
                        {
                            objProsp.PostalCode = txtPostalCode.Text.Trim();
                        }
                    }//objProsp.PostalCode = txtPostalCode.Text.Trim();// ddlPostalCode.SelectedValue.Trim();
                    else if (Convert.ToString(Session["ForW"]).Trim().ToUpper() == "F")
                    {
                        if (ddlPostalCode.Visible)
                        {
                            objProsp.PostalCode = ddlPostalCode.SelectedValue.Trim();
                        }
                        else
                        {
                            objProsp.PostalCode = txtPostalCode.Text.Trim();
                        }
                    }
                    //objProsp.PostalCode = txtPostalCode.Text.Trim();
                }
                else
                    objProsp.PostalCode = txtPostalCode.Text.Trim();//ddlPostalCode.SelectedValue.Trim();
                objProsp.Finance = Convert.ToInt16(ddlFinance.SelectedValue.Trim());
                objProsp.LeadSource = txtReferredBy.Text.Trim();
                objProsp.CreatedById = BasePage.UserSession.VirtualRoleId;
                objProsp.IsDeleted = false;
                objProsp.ModelId = Convert.ToInt32(ddlModel.SelectedValue.Trim());

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
                        }
                        else
                        {
                            objProsp.Model = ddlModel.SelectedItem.Text.Trim();
                        }

                    }
                }
                //----------------------------------------------------------------------------------

                objProsp.Comment = txtComments.Text.Trim();
                if (chkTradeIn.Checked)
                    objProsp.TradeIn = true;
                else
                    objProsp.TradeIn = false;
                objProsp.TradeInMkModel = txtTradeInMakeModel.Text.Trim();
                objProsp.IsFleetLead = Convert.ToBoolean(hdfIsFleetLead.Value.Trim());
                //Old Commented By:Ayyaj On 3 Dec 2014
                //if (rbtnNew.Checked)
                //    objProsp.Used = true;
                //else if (rbtnUsed.Checked)
                //    objProsp.Used = false;
                //else
                //    objProsp.Used = false;

                //New Added By:Ayyaj On 3 Dec 2014
                if (rbtnNew.Checked)
                    objProsp.Used = false;
                else if (rbtnUsed.Checked)
                    objProsp.Used = true;
                else
                    objProsp.Used = false;

                objProsp.WhereDidUHear = Convert.ToInt32(ddlWhereDidUHear.SelectedValue.Trim());
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
                //objProsp.LstProspContact = lstprospCont;
                if (objProsp.ProspId == 0)
                {
                    #region Old Commented By: Ayyaj On 1 Dec 2014
                    //if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) == 0)
                    //    objProsp.IsFinanceSource = "W";
                    //else if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) == 0)
                    //    objProsp.IsFinanceSource = "F";
                    //else
                    //    objProsp.IsFinanceSource = "W";
                    #endregion

                    #region New Modified By Ayyaj On 1 Dec 2014
                    if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) == 0)
                        objProsp.IsFinanceSource = "W";
                    else if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) == 0)
                    {
                        if (Convert.ToInt16(ddlFinance.SelectedValue.Trim()) == 1)
                            objProsp.IsFinanceSource = "F";
                        else
                            objProsp.IsFinanceSource = "W";
                    }
                    else
                        objProsp.IsFinanceSource = "W";
                    #endregion
                    if (!CheckDuplicateLeads(objProsp.Email, objProsp.IsFinanceSource))
                    {
                        #region Old
                        //if (Convert.ToInt16(ddlFinance.SelectedValue.Trim()) == 1)
                        //    objProsp.IsFinanceSource = "C";
                        //else
                        //{
                        //    if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) == 0)
                        //        objProsp.IsFinanceSource = "W";
                        //    else if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) == 0)
                        //        objProsp.IsFinanceSource = "F";
                        //    else
                        //        objProsp.IsFinanceSource = "W";
                        //}
                        #endregion
                        #region New Modified By Ayyaj On 1 Dec 2014
                        if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) == 0)
                            objProsp.IsFinanceSource = "W";
                        else if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) == 0)
                        {
                            if (Convert.ToInt16(ddlFinance.SelectedValue.Trim()) == 1)
                                objProsp.IsFinanceSource = "F";
                            else
                                objProsp.IsFinanceSource = "W";
                        }
                        else
                            objProsp.IsFinanceSource = "W";
                        #endregion
                        objProsp.IsDuplicate = 43;// Hard Code for Regular
                        Result = objProspBM.AddProspect(objProsp);
                    }
                    else
                    {
                        if (CheckFor24Hrs(objProsp.Email) <= 24)
                        {
                            #region Old
                            //if (Convert.ToInt16(ddlFinance.SelectedValue.Trim()) == 1)
                            //    objProsp.IsFinanceSource = "C";
                            //else
                            //{
                            //    if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) == 0)
                            //        objProsp.IsFinanceSource = "W";
                            //    else if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) == 0)
                            //        objProsp.IsFinanceSource = "F";
                            //    else
                            //        objProsp.IsFinanceSource = "W";
                            //}
                            #endregion
                            #region New Modified By Ayyaj On 1 Dec 2014
                            if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) == 0)
                                objProsp.IsFinanceSource = "W";
                            else if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) == 0)
                            {
                                if (Convert.ToInt16(ddlFinance.SelectedValue.Trim()) == 1)
                                    objProsp.IsFinanceSource = "F";
                                else
                                    objProsp.IsFinanceSource = "W";
                            }
                            else
                                objProsp.IsFinanceSource = "W";
                            #endregion
                            objProsp.IsDuplicate = 44; //Hard Code for Duplicate
                            Result = objProspBM.AddProspect(objProsp);
                        }
                        else
                        {
                            #region old
                            //if (Convert.ToInt16(ddlFinance.SelectedValue.Trim()) == 1)
                            //    objProsp.IsFinanceSource = "C";
                            //else
                            //{
                            //    if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) == 0)
                            //        objProsp.IsFinanceSource = "W";
                            //    else if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) == 0)
                            //        objProsp.IsFinanceSource = "F";
                            //    else
                            //        objProsp.IsFinanceSource = "W";
                            //}
                            #endregion
                            #region New Modified By Ayyaj On 1 Dec 2014
                            if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) == 0)
                                objProsp.IsFinanceSource = "W";
                            else if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) == 0)
                            {
                                if (Convert.ToInt16(ddlFinance.SelectedValue.Trim()) == 1)
                                    objProsp.IsFinanceSource = "F";
                                else
                                    objProsp.IsFinanceSource = "W";
                            }
                            else
                                objProsp.IsFinanceSource = "W";
                            #endregion
                            objProsp.IsDuplicate = 45; //Hard Code for Duplicate & Notified
                            Result = objProspBM.AddProspect(objProsp);
                            DataSet Ds = objMstBM.GetDupLeadsDetailsForNoti(objProsp.Email, Result);
                            if (Ds != null && Ds.Tables.Count > 0)
                            {
                                DataTable dt1 = Ds.Tables[0];
                                DataTable dt2 = Ds.Tables[1];
                                DataTable dt3 = Ds.Tables[2];
                                SendConsultMail(dt2.Rows[0]["ConsultEmail"].ToString().Trim(), dt2.Rows[0]["AdminEmail"].ToString().Trim(), dt2.Rows[0]["ConsultName"].ToString().Trim(), dt1.Rows[0]["Name"].ToString().Trim(), dt1.Rows[0]["Email1"].ToString().Trim());
                                SendFCConsultMail(dt3.Rows[0]["ConsultEmail"].ToString().Trim(), dt3.Rows[0]["AdminEmail"].ToString().Trim(), dt3.Rows[0]["ConsultName"].ToString().Trim(), dt1.Rows[0]["Name"].ToString().Trim(), dt1.Rows[0]["Email1"].ToString().Trim());
                            }
                        }
                    }

                    if (Result > 0)
                    {
                        //lblAddSucMsg.Text = Resources.PFSalesResource.ProspAddedSucc.Trim();
                        //lblAddErrMsg.Text = string.Empty;
                        //dvadderror.Visible = dvaserSuccess.Visible = dvsererror.Visible = false;
                        //dvaddSucc.Visible = true;
                        if (Convert.ToInt16(ddlFinance.SelectedValue.Trim()) == 1)
                            UpdateFinCarLeads(ddlfinReq.SelectedValue.Trim(), txtFCMessage.Text.Trim(), ddlCredHistory.SelectedValue.Trim(), ddlTermYears.SelectedValue.Trim(), txtEstFin.Text.Trim(), txtResBaloon.Text.Trim(), txtInitialDep.Text.Trim(), Result, Convert.ToInt64(hdfFCId.Value.Trim()), ddlEmployment.SelectedValue.Trim(), txtCurrentIncome.Text.Trim(), txtEmployer.Text.Trim(), ddlTimeinCurEmp.SelectedValue.Trim(), Convert.ToInt16(ddlFinReqFrom.SelectedValue.Trim()), ddlTimeAtCurAdd.SelectedValue.Trim());
                        /////////////////////////////////////////////////////////////
                        Panel pnl = (Panel)this.Parent.FindControl("pnlAddContact");
                        HtmlGenericControl DivdvaddSucc = (HtmlGenericControl)pnl.Parent.FindControl("dvaddSucc");
                        HtmlGenericControl Divdvadderror = (HtmlGenericControl)pnl.Parent.FindControl("dvadderror");
                        Label lbl_lblAddErrMsg = (Label)pnl.Parent.FindControl("lblAddErrMsg");
                        Label lbl_lblAddSucMsg = (Label)pnl.Parent.FindControl("lblAddSucMsg");
                        if (pnl != null && DivdvaddSucc != null && Divdvadderror != null && lbl_lblAddErrMsg != null && lbl_lblAddSucMsg != null)
                        {


                            if (objProsp.IsDuplicate != 44 && objProsp.IsDuplicate != 45)
                            {
                                Divdvadderror.Visible = pnl.Visible = false;
                                DivdvaddSucc.Visible = true;
                                lbl_lblAddErrMsg.Text = string.Empty;
                                lbl_lblAddSucMsg.Text = Resources.PFSalesResource.ProspAddedSucc.Trim();
                            }
                            else if (objProsp.IsDuplicate == 44)
                            {
                                DivdvaddSucc.Visible = pnl.Visible = false;
                                Divdvadderror.Visible = true;
                                lbl_lblAddErrMsg.Text = "Lead Exists With Same Email ID, Please Use " + "<b><a href='Claim101.aspx'>Claim 101</a></b>" + " Function";
                                lbl_lblAddSucMsg.Text = string.Empty;
                            }
                            else if (objProsp.IsDuplicate == 45)
                            {
                                DivdvaddSucc.Visible = pnl.Visible = false;
                                Divdvadderror.Visible = true;
                                lbl_lblAddErrMsg.Text = "Lead Exists With Same Email ID, Please Use " + "<b><a href='Claim101.aspx'>Claim 101</a></b>" + " Function";
                                lbl_lblAddSucMsg.Text = string.Empty;
                            }
                        }
                        ///////////////////////////////////////////////////////

                        // BindGrid();
                        if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0)
                        {
                            DataTable dt = objEmpBM.GetEmpDetFromVirId(Convert.ToInt64(ddlConsultant.SelectedValue.Trim()));
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                // SaveDefaultActivity(txtFName.Text.Trim(), Result, 0);
                                SetAllocatedDate(Convert.ToInt64(ddlConsultant.SelectedValue.Trim()), Result, BasePage.UserSession.VirtualRoleId);
                                SendMail(dt.Rows[0]["Email1"].ToString().Trim(), 1, dt.Rows[0]["FName"].ToString().Trim());
                                //Commented on: 27 Aug 2014, Commented By: Ayyaj, Suggested By:Mark
                                //SendProspectMail(txtEmail1.Text.Trim(), txtFName.Text.Trim(), Convert.ToString(dt.Rows[0]["FName"]).Trim(), dt.Rows[0]["Phone"].ToString().Trim(), dt.Rows[0]["Email1"].ToString().Trim(), DateTime.Today.ToString("D"), dt.Rows[0]["PhoneExt"].ToString().Trim(), (Convert.ToString(dt.Rows[0]["FName"]).Trim() + " " + Convert.ToString(dt.Rows[0]["MName"]).Trim() + " " + Convert.ToString(dt.Rows[0]["LName"]).Trim()).Trim());
                            }
                        }
                        if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0)
                        {
                            DataTable dt = objEmpBM.GetEmpDetFromVirId(Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()));
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                // SaveDefaultActivity(txtFName.Text.Trim(), Result, 0);
                                SetFAllocatedDate(Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()), Result, BasePage.UserSession.VirtualRoleId);
                                SendMail(dt.Rows[0]["Email1"].ToString().Trim(), 1, dt.Rows[0]["FName"].ToString().Trim());
                                //SendProspectMail(txtEmail1.Text.Trim(), txtFName.Text.Trim(), ddlFConsultant.SelectedItem.Text.Trim(), dt.Rows[0]["Phone"].ToString().Trim(), dt.Rows[0]["Email1"].ToString().Trim(), DateTime.Today.ToString("D"), dt.Rows[0]["PhoneExt"].ToString().Trim());
                            }
                        }
                    }
                    else if (Result == -5)
                    {
                        //lblAddErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                        //lblAddSucMsg.Text = string.Empty;
                        //dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        //dvadderror.Visible = true;
                        txtAddName.Focus();


                        /////////////////////////////////////////////////////////////
                        Panel pnl = (Panel)this.Parent.FindControl("pnlAddContact");
                        HtmlGenericControl DivdvaddSucc = (HtmlGenericControl)pnl.Parent.FindControl("dvaddSucc");
                        HtmlGenericControl Divdvadderror = (HtmlGenericControl)pnl.Parent.FindControl("dvadderror");
                        Label lbl_lblAddErrMsg = (Label)pnl.Parent.FindControl("lblAddErrMsg");
                        Label lbl_lblAddSucMsg = (Label)pnl.Parent.FindControl("lblAddSucMsg");
                        if (pnl != null && DivdvaddSucc != null && Divdvadderror != null && lbl_lblAddErrMsg != null && lbl_lblAddSucMsg != null)
                        {
                            DivdvaddSucc.Visible = pnl.Visible = false;
                            Divdvadderror.Visible = true;
                            lbl_lblAddErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                            lbl_lblAddSucMsg.Text = string.Empty;
                        }
                        ///////////////////////////////////////////////////////

                    }
                    else
                    {
                        //lblAddErrMsg.Text = Resources.PFSalesResource.ProspNotAdded.Trim();
                        //lblAddSucMsg.Text = string.Empty;
                        //dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        //dvadderror.Visible = true;
                        txtAddName.Focus();


                        /////////////////////////////////////////////////////////////
                        Panel pnl = (Panel)this.Parent.FindControl("pnlAddContact");
                        HtmlGenericControl DivdvaddSucc = (HtmlGenericControl)pnl.Parent.FindControl("dvaddSucc");
                        HtmlGenericControl Divdvadderror = (HtmlGenericControl)pnl.Parent.FindControl("dvadderror");
                        Label lbl_lblAddErrMsg = (Label)pnl.Parent.FindControl("lblAddErrMsg");
                        Label lbl_lblAddSucMsg = (Label)pnl.Parent.FindControl("lblAddSucMsg");
                        if (pnl != null && DivdvaddSucc != null && Divdvadderror != null && lbl_lblAddErrMsg != null && lbl_lblAddSucMsg != null)
                        {
                            DivdvaddSucc.Visible = pnl.Visible = false;
                            Divdvadderror.Visible = true;
                            lbl_lblAddErrMsg.Text = Resources.PFSalesResource.ProspNotAdded.Trim();
                            lbl_lblAddSucMsg.Text = string.Empty;
                        }
                        ///////////////////////////////////////////////////////
                    }
                }
                else if (objProsp.ProspId > 0)
                {
                    Result = objProspBM.UpdateProspect(objProsp);
                    if (Result > 0)
                    {
                        UpdateFinCarLeads(ddlfinReq.SelectedValue.Trim(), txtFCMessage.Text.Trim(), ddlCredHistory.SelectedValue.Trim(), ddlTermYears.SelectedValue.Trim(), txtEstFin.Text.Trim(), txtResBaloon.Text.Trim(), txtInitialDep.Text.Trim(), objProsp.ProspId, Convert.ToInt64(hdfFCId.Value.Trim()), ddlEmployment.SelectedValue.Trim(), txtCurrentIncome.Text.Trim(), txtEmployer.Text.Trim(), ddlTimeinCurEmp.SelectedValue.Trim(), Convert.ToInt16(ddlFinReqFrom.SelectedValue.Trim()), ddlTimeAtCurAdd.SelectedValue.Trim());
                        //lblAddSucMsg.Text = Resources.PFSalesResource.ProspDeatilsUpdated.Trim();
                        //lblAddErrMsg.Text = string.Empty;
                        //dvaserSuccess.Visible = dvadderror.Visible = dvsererror.Visible = false;
                        //dvaddSucc.Visible = true;


                        /////////////////////////////////////////////////////////////
                        Panel pnl = (Panel)this.Parent.FindControl("pnlAddContact");
                        HtmlGenericControl DivdvaddSucc = (HtmlGenericControl)pnl.Parent.FindControl("dvaddSucc");
                        HtmlGenericControl Divdvadderror = (HtmlGenericControl)pnl.Parent.FindControl("dvadderror");
                        Label lbl_lblAddErrMsg = (Label)pnl.Parent.FindControl("lblAddErrMsg");
                        Label lbl_lblAddSucMsg = (Label)pnl.Parent.FindControl("lblAddSucMsg");
                        if (pnl != null && DivdvaddSucc != null && Divdvadderror != null && lbl_lblAddErrMsg != null && lbl_lblAddSucMsg != null)
                        {
                            pnl.Visible = false;
                            DivdvaddSucc.Visible = true;
                            lbl_lblAddErrMsg.Text = string.Empty;
                            lbl_lblAddSucMsg.Text = Resources.PFSalesResource.ProspDeatilsUpdated.Trim();
                            Divdvadderror.Visible = false;
                        }
                        ///////////////////////////////////////////////////////

                        //BindGrid();
                        BindMangeData();
                        if (hdfConsultID.Value != ddlConsultant.SelectedValue.Trim() && !string.IsNullOrEmpty(hdfEnquryDate.Value.Trim()))
                        {
                            if (Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) > 0)
                            {
                                DataTable dt = objEmpBM.GetEmpDetFromVirId(Convert.ToInt64(ddlConsultant.SelectedValue.Trim()));
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    // SaveDefaultActivity(txtFName.Text.Trim(), objProsp.ProspId, 0);
                                    SetAllocatedDate(Convert.ToInt64(ddlConsultant.SelectedValue.Trim()), objProsp.ProspId, BasePage.UserSession.VirtualRoleId);
                                    SendMail(dt.Rows[0]["Email1"].ToString().Trim(), 1, dt.Rows[0]["FName"].ToString().Trim());
                                    //SendProspectMail(txtEmail1.Text.Trim(), txtFName.Text.Trim(), ddlConsultant.SelectedItem.Text.Trim(), dt.Rows[0]["Phone"].ToString().Trim(), dt.Rows[0]["Email1"].ToString().Trim(), DateTime.Today.ToString("D"), dt.Rows[0]["PhoneExt"].ToString().Trim());
                                }
                            }
                        }
                        if (hdfFConsultID.Value != ddlFConsultant.SelectedValue.Trim() && !string.IsNullOrEmpty(hdfEnquryDate.Value.Trim()))
                        {
                            if (Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0)
                            {
                                DataTable dt = objEmpBM.GetEmpDetFromVirId(Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()));
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    // SaveDefaultActivity(txtFName.Text.Trim(), objProsp.ProspId, 0);
                                    SetFAllocatedDate(Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()), objProsp.ProspId, BasePage.UserSession.VirtualRoleId);
                                    SendMail(dt.Rows[0]["Email1"].ToString().Trim(), 1, dt.Rows[0]["FName"].ToString().Trim());
                                    //SendProspectMail(txtEmail1.Text.Trim(), txtFName.Text.Trim(), ddlConsultant.SelectedItem.Text.Trim(), dt.Rows[0]["Phone"].ToString().Trim(), dt.Rows[0]["Email1"].ToString().Trim(), DateTime.Today.ToString("D"), dt.Rows[0]["PhoneExt"].ToString().Trim());
                                }
                            }
                        }
                    }
                    else if (Result == -5)
                    {
                        Panel pnl = (Panel)this.Parent.FindControl("pnlAddContact");
                        pnl.Visible = false;
                        HtmlGenericControl Divdvadderror = (HtmlGenericControl)pnl.Parent.FindControl("dvadderror");
                        Divdvadderror.Visible = true;
                        Label lbl_lblAddErrMsg = (Label)pnl.Parent.FindControl("lblAddErrMsg");
                        lbl_lblAddErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                        Label lbl_lblAddSucMsg = (Label)pnl.Parent.FindControl("lblAddSucMsg");
                        lbl_lblAddSucMsg.Text = string.Empty;
                        HtmlGenericControl DivdvaserSuccess = (HtmlGenericControl)pnl.Parent.FindControl("dvaserSuccess");
                        HtmlGenericControl DivdvaddSucc = (HtmlGenericControl)pnl.Parent.FindControl("dvaddSucc");
                        HtmlGenericControl Divdvsererror = (HtmlGenericControl)pnl.Parent.FindControl("dvsererror");
                        DivdvaserSuccess.Visible = DivdvaddSucc.Visible = Divdvsererror.Visible = false;
                        txtAddName.Focus();
                    }
                    else
                    {

                        lblAddErrMsg.Text = Resources.PFSalesResource.ProspDeatilsNotUpdated.Trim();
                        lblAddSucMsg.Text = string.Empty;
                        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvadderror.Visible = true;

                        /////////////////////////////////////////////////////////////
                        Panel pnl = (Panel)this.Parent.FindControl("pnlAddContact");
                        HtmlGenericControl DivdvaddSucc = (HtmlGenericControl)pnl.Parent.FindControl("dvaddSucc");
                        HtmlGenericControl Divdvadderror = (HtmlGenericControl)pnl.Parent.FindControl("dvadderror");
                        Label lbl_lblAddErrMsg = (Label)pnl.Parent.FindControl("lblAddErrMsg");
                        Label lbl_lblAddSucMsg = (Label)pnl.Parent.FindControl("lblAddSucMsg");
                        if (pnl != null && DivdvaddSucc != null && Divdvadderror != null && lbl_lblAddErrMsg != null && lbl_lblAddSucMsg != null)
                        {
                            DivdvaddSucc.Visible = pnl.Visible = false;
                            Divdvadderror.Visible = true;
                            lbl_lblAddErrMsg.Text = Resources.PFSalesResource.ProspDeatilsNotUpdated.Trim();
                            lbl_lblAddSucMsg.Text = string.Empty;
                        }
                        ///////////////////////////////////////////////////////
                        txtAddName.Focus();
                    }
                }
            }
            ClearAll();
            MethodInfo methods1 = (this.Parent.Page).GetType().GetMethod("BindGrid");// ((Page)this.Parent).GetType().GetMethod("BindMangeActivity");
            if (methods1 != null)
            {
                methods1.Invoke((this.Parent.Page), null);
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.lnkbtnSave_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Clear Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFinalClear_Click(object sender, EventArgs e)
    {
        if (ViewState["ProspId"] != null && !string.IsNullOrEmpty(ViewState["ProspId"].ToString().Trim()) && Convert.ToInt64(ViewState["ProspId"].ToString().Trim()) > 0)
        {
            BindMangeData();
            this.Parent.Visible = false;
            ClearAll();
        }
        else if (ViewState["ProspId"] != null && !string.IsNullOrEmpty(ViewState["ProspId"].ToString().Trim()) && Convert.ToInt64(ViewState["ProspId"].ToString().Trim()) == 0)
            ClearAll();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Alternate Contact Number Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAlterContNo_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hdfPhoneFormat.Value.Trim()))
        {
            //ListItem selectedPhoneFormat = ddlPhFormat.Items.FindByValue(hdfPhoneFormat.Value.Trim());
            //if (selectedPhoneFormat != null)
            //    selectedPhoneFormat.Selected = true;
            ddlPhFormat.SelectedValue = hdfPhoneFormat.Value.Trim();
        }
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
        txtPhPopUpPhoNo.Text = txtAltContNo.Text.Trim();
        pnlphonePopUp.Visible = true;
        ClearMsg();
        hdfPhPopType.Value = "ALTERCONT";
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
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
    /// Created Date: 24 July 2013
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
    /// Created Date: 24 July 2013
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
            if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
            {
                fteAlteContNo.Enabled = false;
                meeAltContNo.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
                meeAltContNo.MaskType = AjaxControlToolkit.MaskedEditType.None;
                meeAltContNo.Enabled = true;
                txtAltContNo.Text = txtPhPopUpPhoNo.Text.Trim();
                hdfAltContactId.Value = ddlPhFormat.SelectedValue.Trim();
            }
            else
            {
                fteAlteContNo.Enabled = true;
                meeAltContNo.Mask = "999999999999999999999999999999";
                meeAltContNo.MaskType = AjaxControlToolkit.MaskedEditType.None;
                meeAltContNo.Enabled = false;
                txtAltContNo.Text = txtPhPopUpPhoNo.Text.Trim();
                hdfAltContactId.Value = ddlPhFormat.SelectedValue.Trim();
            }
            txtAltContNo.Focus();
        }
        pnlphonePopUp.Visible = false;
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
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
    /// Created Date: 24 July 2013
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
            Logger.Error(ex.Message + "UserControls_AddEditContact.gvprosp_Soring.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
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
    /// Created Date: 24 July 2013
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
    /// Created Date: 24 July 2013
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
    /// Created Date:24 July 2013
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
            Logger.Error(ex.Message + "UserControls_AddEditContact.lnkbtnNamePopUp_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date:24 July 2013
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
            Logger.Error(ex.Message + "UserControls_AddEditContact.lnkbtnPhPopClose_Close.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date:24 July 2013
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
    /// Created Date: 24 July 2013
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
    /// Created Date: 24 July 2013
    /// Description: Selected Index Changed Event Of Page Size's Drop Down List
    /// </summary>
    /// <param name="Sender"></param>
    /// <param name="e"></param>
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvprosp.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue.Trim());
            //BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.ddlPageSize_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
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
            Logger.Error(ex.Message + "UserControls_AddEditContact.ddlPhFormat_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
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
            Logger.Error(ex.Message + "UserControls_AddEditContact.ddlPostalCode_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
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
    /// Created Date: 24 July 2013
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
    /// Created Date: 24 July 2013
    /// Description: Selected Index Changed Event Of Where Did You Hear about PF's Drop Down List 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlWhereDidUHear_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetIsFleetLead();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 27 July 2013
    /// Description: Selected Index Changed Event Of Finance's Drop Down List 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlFinance_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (BasePage.UserSession.RoleId == 5 || BasePage.UserSession.RoleId == 1)
            {
                if (ddlFinance.SelectedValue.Trim() == "1" && Convert.ToInt64(ddlFConsultant.SelectedValue.Trim()) > 0 && Convert.ToInt64(ddlConsultant.SelectedValue.Trim()) == 0)
                {
                    BindAllSourcesForFC();
                }
                else
                {
                    BindAllSources();
                }
            }

            //Commented By: Ayyaj Desc: It is already commented from design selecetd index changed
            //if (ddlFinance.SelectedValue.Trim() != "1")
            //{
            //    ddlFConsultant.SelectedValue = "0";
            //    ddlFConsultant.Enabled = false;
            //}
            //else
            //{
            //    //ListItem selectedFConsultID = ddlFConsultant.Items.FindByValue(hdfFConsultID.Value.Trim());
            //    //if (selectedFConsultID != null)
            //    //    selectedFConsultID.Selected = true;
            //    ddlFConsultant.SelectedValue = hdfFConsultID.Value.Trim();
            //    ddlFConsultant.Enabled = true;
            //}
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.ddlFinance_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date: 8 Dec 2014
    /// Description: Selected Index Changed Event Of ddlFConsultant Drop Down List 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlFConsultant_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlFinance_SelectedIndexChanged(null, null);
    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date: 8 Dec 2014
    /// Description: Selected Index Changed Event Of ddlConsultant Drop Down List 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlConsultant_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlFinance_SelectedIndexChanged(null, null);
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
            Logger.Error(ex.Message + "UserControls_AddEditContact.txtPostalCode_TextChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date: 19 Sept 2014
    /// Description: To Open Popup of city add
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnCityPop_Click(object sender, EventArgs e)
    {
        DataTable Dt = objMstBM.GetAllState(string.Empty, Convert.ToInt64(ddlCountry.SelectedValue.Trim()));
        Cls_BinderHelper.BindDropdownList(ddlStateCityPop, "StateName", "Id", Dt);
        ClearMsg();
        txtPostalPopup.Text = txtCityPopup.Text = string.Empty;
        ddlStateCityPop.Focus();
        pnlPostalCityPopUp.Visible = true;
    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date:19 Sept 2014
    /// Description: To save City 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnCityPoUpSave_Click(object sender, EventArgs e)
    {
        try
        {
            Int64 Result = 0;
            if (BasePage.UserSession != null)
            {
                objCity.StateId = Convert.ToInt64(ddlStateCityPop.SelectedValue.Trim());
                objCity.PCode = txtPostalPopup.Text.Trim();
                objCity.Suburb = txtCityPopup.Text.Trim();
                objCity.IsDeleted = false;
                objCity.CreatedById = BasePage.UserSession.VirtualRoleId;
                Result = objMstBM.AddCity(objCity);
                if (Result > 0)
                {

                    lblAddSucMsg.Text = Resources.PFSalesResource.CityAddedSucc.Trim();
                    lblAddErrMsg.Text = string.Empty;
                    dvaddSucc.Visible = true;
                    dvadderror.Visible = false;
                }
                else if (Result == -5)
                {

                    lblAddErrMsg.Text = Resources.PFSalesResource.CityAlreadyExist.Trim();
                    lblAddSucMsg.Text = string.Empty;
                    dvaddSucc.Visible = false;
                    dvadderror.Visible = true;
                }
                else
                {

                    lblAddErrMsg.Text = Resources.PFSalesResource.CityNotAdded.Trim();
                    lblAddSucMsg.Text = string.Empty;
                    dvaddSucc.Visible = false;
                    dvadderror.Visible = true;
                }

                BindAllCities();
                //ClearMsg();
                pnlPostalCityPopUp.Visible = false;
                //ClearMsg();

            }

        }
        catch (Exception ex)
        {

            Logger.Error(ex.Message + "AddProspects.lnkbtnCityPoUpSave_Click.Error:" + ex.StackTrace);
        }

    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date: 19 Sept 2014
    /// Description: City Pop up Close Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnCityPopClose_Click(object sender, EventArgs e)
    {
        pnlPostalCityPopUp.Visible = false;
        ClearMsg();
    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date: 19 Sept 2014
    /// Description: City Pop up Close Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnCityPoUpClose_Click(object sender, EventArgs e)
    {
        pnlPostalCityPopUp.Visible = false;
        ClearMsg();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Bind Grid View Data
    /// </summary>
    private void BindGrid()
    {
        try
        {
            //objProsp.FName = txtserprospName.Text.Trim();
            //objProsp.StatusId = Convert.ToInt64(ddlStatus.SelectedValue.Trim());
            //DataSet Ds = objProspBM.GetAllProspects(objProsp);
            //if (Ds != null && Ds.Tables.Count > 0)
            //{
            //    DataTable Dt = Ds.Tables[0];
            //    if (Dt != null & Dt.Rows.Count > 0)
            //    {
            //        DataView dV = Dt.DefaultView;
            //        dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
            //        gvprosp.DataSource = Dt;
            //        gvprosp.DataBind();
            //    }
            //    else
            //    {
            //        gvprosp.DataSource = null;
            //        gvprosp.DataBind();
            //    }
            //}
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.BindGrid.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Crearted By:Pravin Gholap
    /// Created Date:24 July 2013
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
            Logger.Error(ex.Message + "UserControls_AddEditContact.DefineSortDirection.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Crearted By:Pravin Gholap
    /// Created Date:24 July 2013
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
            Logger.Error(ex.Message + "UserControls_AddEditContact.DefineContSortDirection.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Get All Countries
    /// </summary>
    public void BindAllCountry()
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
            Logger.Error(ex.Message + "UserControls_AddEditContact.BindAllCountry.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
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
            Logger.Error(ex.Message + "UserControls_AddEditContact.BindAllStates.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Get All Postal Codes
    /// </summary>
    private void BindAllPostalCode()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllCity(string.Empty, Convert.ToInt64(ddlState.SelectedValue.Trim()));
            Cls_BinderHelper.BindDropdownList(ddlPostalCode, "PCode", "PCode", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.BindAllPostalCode.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Get All Cities
    /// </summary>
    private void BindAllCities()
    {
        try
        {
            DataTable Dt = new DataTable();
            if (ddlPostalCode.Visible)
                Dt = objMstBM.GetAllCitiesFromPCode(ddlPostalCode.SelectedValue.Trim());
            else if (txtPostalCode.Visible)
                Dt = objMstBM.GetAllCitiesFromPCode(txtPostalCode.Text.Trim());
            Cls_BinderHelper.BindDropdownList(ddlCity, "CityName", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.BindAllCities.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Bind All Cantact Format
    /// </summary>
    public void BindFormats()
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
                    //ListItem selectedId = ddlPhFormat.Items.FindByValue(Convert.ToString(Dr[0]["Id"]).Trim());
                    //if (selectedId != null)
                    //    selectedId.Selected = true;
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
            Logger.Error(ex.Message + "UserControls_AddEditContact.BindDesignations.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Clear Add Employee Panel
    /// </summary>
    public void ClearAll()
    {
        try
        {
            ddlFConsultant.SelectedValue = ddlWhereDidUHear.SelectedValue = ddlFinance.SelectedValue = ddlTitle.SelectedValue = ddlConsultant.SelectedValue = ddlSource.SelectedValue = ddlCarMake.SelectedValue = "0";
            ddlPhPopUpCountry.SelectedValue = ddlCountry.SelectedValue = "1";
            ddlCountry_SelectedIndexChanged(null, null);
            ddlState.SelectedValue = ddlPostalCode.SelectedValue = "0";
            txtPostalCode.Text = string.Empty;
            txtPostalCode_TextChanged(null, null);
            ddlPostalCode_SelectedIndexChanged(null, null);
            ddlCarMake_SelectedIndexChanged(null, null);
            ddlModel.SelectedValue = "0";
            ddlCity.SelectedValue = "0";
            txtComments.Text = txtReferredBy.Text = txtFName.Text = txtMName.Text = txtLName.Text = txtFConsultant.Text = txtMemNo.Text = txtAddName.Text = txtPhNo.Text = txtMobile.Text = txtAddLine1.Text = txtAddLine2.Text = txtAddLine3.Text = txtFax.Text = txtEmail1.Text = txtAlterEmail.Text = txtAltContNo.Text = string.Empty;//txtPostalCode.Text =
            hdfPhPopType.Value = "";
            chkTradeIn.Checked = false;
            BindFormats();
            SetDefaultFormat();
            ddlAddStatus.SelectedIndex = 1;
            rbtnNew.Checked = true;
            rbtnUsed.Checked = false;
            ViewState["ProspId"] = 0;
            BindConsultant();
            BindFConsultant();
            if (BasePage.UserSession.RoleId == 3)
                ddlConsultant.SelectedValue = BasePage.UserSession.VirtualRoleId.ToString().Trim();
            else if (BasePage.UserSession.RoleId == 5)
                ddlFConsultant.SelectedValue = BasePage.UserSession.VirtualRoleId.ToString().Trim();
            else
                ddlConsultant.SelectedValue = "0";
            txtCurrentIncome.Text = txtEmployer.Text = txtEstFin.Text = txtInitialDep.Text = txtResBaloon.Text = txtFCMessage.Text = string.Empty;
            ddlFinReqFrom.SelectedValue = ddlTimeAtCurAdd.SelectedValue = ddlTimeinCurEmp.SelectedValue = ddlEmployment.SelectedValue = ddlfinReq.SelectedValue = ddlTermYears.SelectedValue = ddlCredHistory.SelectedValue = "0";
            //dlSendMail.Visible = false;
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
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.ClearAll.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Clear All Message's Text
    /// </summary>
    public void ClearMsg()
    {
        lblAddErrMsg.Text = lblAddSucMsg.Text = lblSerErrMsg.Text = lblSerSucMsg.Text = string.Empty;
        dvadderror.Visible = dvaddSucc.Visible = dvaserSuccess.Visible = dvsererror.Visible = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Get All Makes
    /// </summary>
    public void BindAllMakes()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllMakes(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlCarMake, "Make", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.BindAllMakes.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Get All Statuses
    /// </summary>
    public void BindAllStatuses()
    {
        try
        {
            DataTable Dt = new DataTable();
            if (BasePage.UserSession.RoleId == 3 || BasePage.UserSession.RoleId == 1)
            {
                Dt = objMstBM.GetAllStatus(1, 1);// Hard Coded Entity Id & Process Id
                Cls_BinderHelper.BindDropdownList(ddlStatus, "Status", "Id", Dt);
                Cls_BinderHelper.BindDropdownList(ddlAddStatus, "Status", "Id", Dt);
                ddlAddStatus.SelectedValue = "1";
            }
            else
                if (BasePage.UserSession.RoleId == 5)
                {
                    //Commented For Time Being Purpose By:Ayyaj On 2 Dec 20014 have to solve status issue
                    //Dt = objMstBM.GetAllStatus(6, 1);// Hard Coded Entity Id & Process I
                    //Cls_BinderHelper.BindDropdownList(ddlStatus, "Status", "Id", Dt);
                    //Cls_BinderHelper.BindDropdownList(ddlAddStatus, "Status", "Id", Dt);
                    //ddlAddStatus.SelectedValue = "35";

                    //Added For Time Being Purpose By:Ayyaj On 2 Dec 20014 have to solve status issue
                    Dt = objMstBM.GetAllStatus(1, 1);// Hard Coded Entity Id & Process Id
                    Cls_BinderHelper.BindDropdownList(ddlStatus, "Status", "Id", Dt);
                    Cls_BinderHelper.BindDropdownList(ddlAddStatus, "Status", "Id", Dt);
                    ddlAddStatus.SelectedValue = "1";
                }
                else
                {
                    Dt = objMstBM.GetAllStatus(1, 1);// Hard Coded Entity Id & Process Id
                    Cls_BinderHelper.BindDropdownList(ddlStatus, "Status", "Id", Dt);
                    Cls_BinderHelper.BindDropdownList(ddlAddStatus, "Status", "Id", Dt);
                    ddlAddStatus.SelectedValue = "1";
                }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.BindAllStatuses.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Bind Contact Grid View Data
    /// </summary>
    public void BindContacts()
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
    /// Created Date: 24 July 2013
    /// Description: Get All Sources
    /// </summary>
    public void BindAllSources()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllSources(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlSource, "RefSource", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.BindAllSources.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Get All Consultants
    /// </summary>
    public void BindConsultant()
    {
        try
        {
            Employee objEmp = new Employee();
            objEmp.FName = string.Empty;
            objEmp.RoleId = 3;//Hard Code For Consultant
            DataTable Dt = objEmpBM.GetAllEmployee(objEmp);
            Cls_BinderHelper.BindDropdownList(ddlConsultant, "Name", "VirtualRoleId", Dt);
            if (BasePage.UserSession.RoleId == 3)
                ddlConsultant.SelectedValue = BasePage.UserSession.VirtualRoleId.ToString().Trim();

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.BindConsultant.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date: 27 Oct 2014
    /// Description: Get All Sources For FC
    /// </summary>
    private void BindAllSourcesForFC()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllSourcesForFC(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlSource, "RefSource", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindAllSources.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 9 Sep 2013
    /// Description: Get All Finance Consultants
    /// </summary>
    public void BindFConsultant()
    {
        try
        {
            Employee objEmp = new Employee();
            objEmp.FName = string.Empty;
            objEmp.RoleId = 5;//Hard Code For Finance Consultant
            DataTable Dt = objEmpBM.GetAllEmployee(objEmp);
            Cls_BinderHelper.BindDropdownList(ddlFConsultant, "Name", "VirtualRoleId", Dt);
            if (BasePage.UserSession.RoleId == 5)
                ddlFConsultant.SelectedValue = BasePage.UserSession.VirtualRoleId.ToString().Trim();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.BindFConsultant.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date:24 July 2013
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
                {
                    //ListItem selectedFName = ddlFName.Items.FindByValue(hdfFName.Value.Trim());
                    //if (selectedFName != null)
                    //    selectedFName.Selected = true;
                    ddlFName.SelectedValue = hdfFName.Value.Trim();
                }
                if (string.IsNullOrEmpty(hdfMName.Value))
                    ddlMName.SelectedIndex = 2;
                else
                {
                    //ListItem selectedMName = ddlMName.Items.FindByValue(hdfMName.Value.Trim());
                    //if (selectedMName != null)
                    //    selectedMName.Selected = true;
                    ddlMName.SelectedValue = hdfMName.Value.Trim();
                }
                if (string.IsNullOrEmpty(hdfLName.Value))
                    ddlLName.SelectedIndex = 3;
                else
                {
                    //ListItem selectedLName = ddlLName.Items.FindByValue(hdfLName.Value.Trim());
                    //if (selectedLName != null)
                    //    selectedLName.Selected = true;
                    ddlLName.SelectedValue = hdfLName.Value.Trim();
                }
            }
            else if (names.Length == 2)
            {
                if (string.IsNullOrEmpty(hdfFName.Value))
                    ddlFName.SelectedIndex = 1;
                else
                {
                    //ListItem selectedFName = ddlFName.Items.FindByValue(hdfFName.Value.Trim());
                    //if (selectedFName != null)
                    //    selectedFName.Selected = true;
                    ddlFName.SelectedValue = hdfFName.Value.Trim();
                }
                if (!string.IsNullOrEmpty(hdfMName.Value))
                {
                    //ListItem selectedMName = ddlMName.Items.FindByValue(hdfMName.Value.Trim());
                    //if (selectedMName != null)
                    //    selectedMName.Selected = true;
                    ddlMName.SelectedValue = hdfMName.Value.Trim();
                }
                else
                    ddlMName.SelectedValue = Resources.PFSalesResource.ddlSelect.Trim();
                if (string.IsNullOrEmpty(hdfLName.Value))
                    ddlLName.SelectedIndex = 2;
                else
                {
                    //ListItem selectedLName = ddlLName.Items.FindByValue(hdfLName.Value.Trim());
                    //if (selectedLName != null)
                    //    selectedLName.Selected = true;
                    ddlLName.SelectedValue = hdfLName.Value.Trim();
                }
            }
            else if (names.Length == 1)
            {
                if (!string.IsNullOrEmpty(hdfFName.Value))
                {
                    //ListItem selectedFName = ddlFName.Items.FindByValue(hdfFName.Value.Trim());
                    //if (selectedFName != null)
                    //    selectedFName.Selected = true;
                    ddlFName.SelectedValue = hdfFName.Value;
                }
                else
                    ddlFName.SelectedValue = Resources.PFSalesResource.ddlSelect.Trim();
                if (!string.IsNullOrEmpty(hdfMName.Value))
                {
                    //ListItem selectedMName = ddlMName.Items.FindByValue(hdfMName.Value.Trim());
                    //if (selectedMName != null)
                    //    selectedMName.Selected = true;
                    ddlMName.SelectedValue = hdfMName.Value.Trim();
                }
                else
                    ddlMName.SelectedValue = Resources.PFSalesResource.ddlSelect.Trim();
                if (string.IsNullOrEmpty(hdfLName.Value))
                    ddlLName.SelectedIndex = 1;
                else
                {
                    //ListItem selectedLName = ddlLName.Items.FindByValue(hdfLName.Value.Trim());
                    //if (selectedLName != null)
                    //    selectedLName.Selected = true;
                    ddlLName.SelectedValue = hdfLName.Value.Trim();
                }
            }

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.BindDesignations.SavePhoto.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date:24 July 2013
    /// Description: Bind Professions To Drop Down List
    /// </summary>
    public void BindProfessions()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllProfessions(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlTitle, "Abbrivation", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.GetProfessions.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Get All Finance
    /// </summary>
    public void BindFinance()
    {
        try
        {
            DataTable Dt;
            if (BasePage.UserSession.RoleId == 5)
            {
                Dt = objMstBM.GetAllFinance("Fincar");
                Cls_BinderHelper.BindDropdownList(ddlFinance, "Finance", "Id", Dt);
                //ddlFinance.SelectedValue = "1";
                //ddlFinance_SelectedIndexChanged(null, null);
            }
            else
            {
                Dt = objMstBM.GetAllFinance(string.Empty);
                Cls_BinderHelper.BindDropdownList(ddlFinance, "Finance", "Id", Dt);
            }

            //DataTable Dt = objMstBM.GetAllFinance(string.Empty);
            //Cls_BinderHelper.BindDropdownList(ddlFinance, "Finance", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.BindFinance.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Set Default Format For Phone, Mobile & Fax Number
    /// </summary>
    private void SetDefaultFormat()
    {
        if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
        {
            fteAlteContNo.Enabled = ftePhNo.Enabled = fteMobile.Enabled = fteFax.Enabled = false;
            msePhPopUp.Mask = meeAltContNo.Mask = mseFax.Mask = mseMobile.Mask = msePhNo.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
            meeAltContNo.Enabled = msePhPopUp.Enabled = mseFax.Enabled = mseMobile.Enabled = msePhNo.Enabled = true;
        }
        else
        {
            fteAlteContNo.Enabled = ftePhNo.Enabled = fteMobile.Enabled = fteFax.Enabled = true;
            msePhPopUp.Mask = meeAltContNo.Mask = mseFax.Mask = mseMobile.Mask = msePhNo.Mask = "99999999999999999999";
            msePhPopUp.Enabled = meeAltContNo.Enabled = mseFax.Enabled = mseMobile.Enabled = msePhNo.Enabled = false;
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
    private Boolean SendMail(string emilToId, int noOfLeads, string Name)
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
            FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + Name.Trim() + "<br /><br />" + noOfLeads.ToString().Trim() + " new lead is assigned to you. Please check the details by login into your account<br /><br /> Thanks & Regards <br /> PF Sales Team </span>";
            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "Email Sent Successfully", "Lead Assignment", "Add-Edit Contact User Control");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Lead Assignment", "Add-Edit Contact User Control");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.SendMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Lead Assignment", "Add-Edit Contact User Control");
            return false;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Send Email To Prospects 
    /// </summary>
    /// <param name="emilToId"></param>
    /// <param name="Name"></param>
    /// <param name="ConsultantName"></param>
    /// <param name="ConsultMobile"></param>
    /// <param name="ConsultEmail"></param>
    /// <param name="EnquiryDate"></param>
    /// <returns></returns>
    private Boolean SendProspectMail(string emilToId, string Name, string ConsultantName, string ConsultPhone, string ConsultEmail, string EnquiryDate, string ConsultExt, string consultFullName)
    {
        string FileContent = string.Empty;
        Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
        string repEmail = BasePage.UserSession.EmailFromID;
        try
        {
            BasePage.UserSession.EmailFromID = "markellis@privatefleet.com.au";

            objEmailHelper.EmailSubject = "Vehicle Enquiry – Private Fleet";
            objEmailHelper.EmailToID = emilToId;
            ArrayList arrAttachments = new ArrayList();
            arrAttachments.Add(HttpContext.Current.Server.MapPath("~/Attachment/Private Fleet Trade-In Valuation Form.xls"));
            objEmailHelper.PostedFiles = arrAttachments;
            FileContent = "<div style='font: 12px/17px arial,helvetica,'Liberation Sans',FreeSans,sans-serif;color: #333333;'>"
                                          + "Dear " + Name.Trim() + ",<br><br> Thank you for your enquiry, I am pleased to advise that " + consultFullName + ", who is one of our most experienced consultants and will be your dedicated contact. " + ConsultantName + " will be in contact with you shortly and will be more than happy to assist you with your purchase including:"
                                          + "<br><ul><li> Initial <b>advice</b> on vehicle selection</li><li> Arranging a <b>test drive</b> if you need this</li><li> <b>Valuation</b> on you current vehicle if you are considering trading it against the new car</li><li>Tendering your requirements to our extensive dealer network to get you the best possible <b>fleet discount pricing</b></li></ul>"
                                          + "<br>To help us achieve the very best results for you, it would be really helpful if you could tell us what you are looking for - not just in terms of the vehicle specification, but also when you want delivery, any colour choice and any preferred financial arrangements."
                                          + "<br><br>In the meantime if you want to find out more about us please refer to the <a href='http://www.privatefleet.com.au/about-us/'>About Us</a> section on our website or view our <a href='http://www.youtube.com/watch?v=OPAFGKn8p4Y'>How it Works</a> video on YouTube."
                                          + "<br><br>Once again, thanks for your enquiry and I am sure we will be able to provide you with a fantastic and rewarding service from this point on. Please feel free to contact me directly, if you have any questions or concerns."
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
                objMstBM.SaveEmailDetails(emilToId, ConsultEmail.Trim(), FileContent.Trim(), "EMail sent successfully", "Vehicle Enquiry – Private Fleet", "Add Prospect");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails(emilToId, ConsultEmail.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Vehicle Enquiry – Private Fleet", "Add Prospect");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.SendProspectMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, ConsultEmail.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException), "Vehicle Enquiry – Private Fleet", "Add Prospect");
            return false;
        }
        finally
        {
            BasePage.UserSession.EmailFromID = repEmail;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
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
            Logger.Error(ex.Message + "UserControls_AddEditContact.BindAllMakes.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Bind Where You Hear About PF Values
    /// </summary>
    public void BindWUHValues()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllWUHValues(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlWhereDidUHear, "ValueforAnswer", "ID", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.BindWUHValues.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Set Whether Prospect is fleet Lead Or Not
    /// </summary>
    private void SetIsFleetLead()
    {
        if (ddlSource.SelectedValue.Trim() != "0")
        {
            DataTable dt = objMstBM.GetProspSrcDetFromId(Convert.ToInt32(ddlSource.SelectedValue.Trim()));
            if (dt != null && dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["IsFleetTeamLead"].ToString().Trim()))
                {
                    if (dt.Rows[0]["IsFleetTeamLead"].ToString().Trim().ToLower() == "yes")
                        hdfIsFleetLead.Value = "true";
                    else
                        hdfIsFleetLead.Value = "false";
                }
                else
                    hdfIsFleetLead.Value = "false";
            }
            else
                hdfIsFleetLead.Value = "false";
        }
        else
            hdfIsFleetLead.Value = "false";

        if (hdfIsFleetLead.Value.ToUpper() == "FALSE")
        {
            if (ddlWhereDidUHear.SelectedValue.Trim() != "0")
            {
                DataTable dt = objMstBM.GetWUHFromId(Convert.ToInt32(ddlWhereDidUHear.SelectedValue.Trim()));
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["IsFleetLead"].ToString().Trim()))
                    {
                        if (dt.Rows[0]["IsFleetLead"].ToString().Trim().ToLower() == "yes")
                            hdfIsFleetLead.Value = "true";
                        else
                            hdfIsFleetLead.Value = "false";
                    }
                    else
                        hdfIsFleetLead.Value = "false";
                }
                else
                    hdfIsFleetLead.Value = "false";
            }
            else
                hdfIsFleetLead.Value = "false";
        }
        else
            hdfIsFleetLead.Value = "true";
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Edit Contact Details
    /// </summary>
    /// <param name="ProspId"></param>
    public void EditContact(Int64 ProspId)
    {
        try
        {
            ClearMsg();
            ViewState["ProspId"] = ProspId;
            if (ProspId > 0)
            {
                DataTable dt = objProspBM.GetProspectsFromId(ProspId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Title"].ToString().Trim()))
                    {
                        //ListItem selectedTitle = ddlTitle.Items.FindByValue(Convert.ToString(dt.Rows[0]["Title"]).Trim());
                        //if (selectedTitle != null)
                        //    selectedTitle.Selected = true;
                        ddlTitle.SelectedValue = dt.Rows[0]["Title"].ToString().Trim();
                    }
                    txtAddName.Text = dt.Rows[0]["FName"].ToString().Trim() + " " + dt.Rows[0]["MName"].ToString().Trim() + " " + dt.Rows[0]["LName"].ToString().Trim();
                    txtAddName.Text = txtAddName.Text.Trim().Replace("  ", " ");
                    ShowEmployeeName();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FName"].ToString().Trim()))
                        txtFName.Text = dt.Rows[0]["FName"].ToString().Trim();//= ddlFName.SelectedValue
                    if (!string.IsNullOrEmpty(dt.Rows[0]["MName"].ToString().Trim()))
                        txtMName.Text = dt.Rows[0]["MName"].ToString().Trim();//= ddlMName.SelectedValue 
                    if (!string.IsNullOrEmpty(dt.Rows[0]["LName"].ToString().Trim()))
                        txtLName.Text = dt.Rows[0]["LName"].ToString().Trim();//= ddlLName.SelectedValue
                    //ListItem selectedCarMake = ddlCarMake.Items.FindByValue(Convert.ToString(dt.Rows[0]["CarMake"]).Trim());
                    //if (selectedCarMake != null)
                    //    selectedCarMake.Selected = true;
                    ddlCarMake.SelectedValue = dt.Rows[0]["CarMake"].ToString().Trim();
                    ddlCarMake_SelectedIndexChanged(null, null);
                    hdfPhoneFormatId.Value = dt.Rows[0]["FormatedPhone"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FormatedPhone"].ToString().Trim()) && dt.Rows[0]["FormatedPhone"].ToString().Trim() != "0")
                    {
                        //ListItem selectedFormatedPhone = ddlPhFormat.Items.FindByValue(Convert.ToString(dt.Rows[0]["FormatedPhone"]).Trim());
                        //if (selectedFormatedPhone != null)
                        //    selectedFormatedPhone.Selected = true;
                        ddlPhFormat.SelectedValue = dt.Rows[0]["FormatedPhone"].ToString().Trim();
                    }
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
                    {
                        //ListItem SelectedMob = ddlPhFormat.Items.FindByValue(Convert.ToString(dt.Rows[0]["FormatedMobile"]).Trim());
                        //if (SelectedMob != null)
                        //{
                        //    SelectedMob.Selected = true;
                        //}
                        ddlPhFormat.SelectedValue = dt.Rows[0]["FormatedMobile"].ToString().Trim();
                    }
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
                    {
                        //ListItem selectedFormatedAltNo = ddlPhFormat.Items.FindByValue(Convert.ToString(dt.Rows[0]["FormatedAltNo"]).Trim());
                        //if (selectedFormatedAltNo != null)
                        //    selectedFormatedAltNo.Selected = true;
                        ddlPhFormat.SelectedValue = dt.Rows[0]["FormatedAltNo"].ToString().Trim();
                    }
                    if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
                    {
                        fteAlteContNo.Enabled = false;
                        meeAltContNo.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
                        meeAltContNo.MaskType = AjaxControlToolkit.MaskedEditType.None;
                        meeAltContNo.Enabled = true;
                    }
                    else
                    {
                        fteAlteContNo.Enabled = true;
                        meeAltContNo.Mask = "999999999999999999999999999999";
                        meeAltContNo.MaskType = AjaxControlToolkit.MaskedEditType.None;
                        meeAltContNo.Enabled = false;
                    }
                    txtAltContNo.Text = dt.Rows[0]["AltContNo"].ToString().Trim();
                    hdfFaxFormatId.Value = dt.Rows[0]["FormatedFax"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FormatedFax"].ToString().Trim()) && dt.Rows[0]["FormatedFax"].ToString().Trim() != "0")
                    {
                        //ListItem selectedFormatedFax = ddlPhFormat.Items.FindByValue(Convert.ToString(dt.Rows[0]["FormatedFax"]).Trim());
                        //if (selectedFormatedFax != null)
                        //    selectedFormatedFax.Selected = true;
                        ddlPhFormat.SelectedValue = dt.Rows[0]["FormatedFax"].ToString().Trim();
                    }
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
                    {
                        //ListItem selectedCountryId = ddlCountry.Items.FindByValue(Convert.ToString(dt.Rows[0]["CountryId"]).Trim());
                        //if (selectedCountryId != null)
                        //    selectedCountryId.Selected = true;
                        ddlCountry.SelectedValue = dt.Rows[0]["CountryId"].ToString().Trim();
                    }
                    BindAllStates();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["StateId"].ToString().Trim()))
                    {
                        ListItem SelectedState = ddlState.Items.FindByValue(Convert.ToString(dt.Rows[0]["StateId"]).Trim());
                        if (SelectedState != null)
                        {
                            Session["StateId"] = dt.Rows[0]["StateId"].ToString().Trim(); SelectedState.Selected = true;
                        }
                    }

                    BindAllPostalCode();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["PostalCode"].ToString().Trim()))
                    {
                        txtPostalCode.Text = dt.Rows[0]["PostalCode"].ToString().Trim();
                        ListItem SelectedPostalCode = ddlPostalCode.Items.FindByValue(Convert.ToString(dt.Rows[0]["PostalCode"]).Trim());
                        if (SelectedPostalCode != null)
                        {
                            SelectedPostalCode.Selected = true;
                        }
                    }
                    BindAllCities();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["CityId"].ToString().Trim()))
                    {
                        //ddlCity.SelectedValue = dt.Rows[0]["CityId"].ToString().Trim();
                        ListItem SelectedCity = ddlCity.Items.FindByValue(Convert.ToString(dt.Rows[0]["CityId"]).Trim());
                        if (SelectedCity != null)
                        {
                            SelectedCity.Selected = true;
                        }
                    }
                    //txtPostalCode.Text = dt.Rows[0]["PostalCode"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["ConsultantId"].ToString().Trim()))
                    {
                        //ListItem selectedConsultantId = ddlConsultant.Items.FindByValue(Convert.ToString(dt.Rows[0]["ConsultantId"]).Trim());
                        //if (selectedConsultantId != null)
                        //    selectedConsultantId.Selected = true;
                        ddlConsultant.SelectedValue = dt.Rows[0]["ConsultantId"].ToString().Trim();
                        hdfConsultID.Value = dt.Rows[0]["ConsultantId"].ToString().Trim();
                    }
                    //Added By Ayyaj On 2 Dec 2014
                    BindAllStatuses();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["StatusId"].ToString().Trim()))
                    {
                        //ListItem selectedStatusId = ddlAddStatus.Items.FindByValue(Convert.ToString(dt.Rows[0]["StatusId"]).Trim());
                        //if (selectedStatusId != null)
                        //    selectedStatusId.Selected = true;

                        //Added By Ayyaj On 2 Dec 2014
                        //if (BasePage.UserSession.RoleId == 3 || BasePage.UserSession.RoleId == 1)
                        //    ddlAddStatus.SelectedValue = dt.Rows[0]["StatusId"].ToString().Trim();
                        //else
                        //    if (BasePage.UserSession.RoleId == 5 && !string.IsNullOrEmpty(dt.Rows[0]["FCStatusId"].ToString().Trim()))
                        //    {
                        //        ddlAddStatus.SelectedValue = dt.Rows[0]["FCStatusId"].ToString().Trim();
                        //    }
                        //Commented By : Ayyaj On 2 Dec 2014
                        ddlAddStatus.SelectedValue = dt.Rows[0]["StatusId"].ToString().Trim();
                    }
                    //Added by : Ayyaj On 3 Dec 2014
                    if (BasePage.UserSession.RoleId == 5)
                        ddlAddStatus.Enabled = false;

                    if (!string.IsNullOrEmpty(dt.Rows[0]["MemberNo"].ToString().Trim()))
                        txtMemNo.Text = dt.Rows[0]["MemberNo"].ToString().Trim();
                    txtFConsultant.Text = dt.Rows[0]["FConsultant"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FinanceConsultantId"].ToString().Trim()))
                    {
                        //ListItem selectedFConsultantId = ddlFConsultant.Items.FindByValue(Convert.ToString(dt.Rows[0]["FinanceConsultantId"]).Trim());
                        //if (selectedFConsultantId != null)
                        //    selectedFConsultantId.Selected = true;
                        ddlFConsultant.SelectedValue = dt.Rows[0]["FinanceConsultantId"].ToString().Trim();
                        hdfFConsultID.Value = dt.Rows[0]["FinanceConsultantId"].ToString().Trim();
                    }
                    hdfEnquryDate.Value = dt.Rows[0]["EnquiryDate"].ToString().Trim();
                    txtReferredBy.Text = dt.Rows[0]["Leadsource"].ToString().Trim();

                    //Added By :Ayyaj On 2 Dec 2014
                    DataTable Dt = objMstBM.GetAllFinance(string.Empty);
                    Cls_BinderHelper.BindDropdownList(ddlFinance, "Finance", "Id", Dt);

                    if (!string.IsNullOrEmpty(dt.Rows[0]["Finance"].ToString().Trim()))
                    {
                        //ListItem selectedFinance = ddlFinance.Items.FindByValue(Convert.ToString(dt.Rows[0]["Finance"]).Trim());
                        //if (selectedFinance != null)
                        //    selectedFinance.Selected = true;

                        ddlFinance.SelectedValue = dt.Rows[0]["Finance"].ToString().Trim();
                    }
                    //Added By :Ayyaj On 3 Dec 2014
                    if (dt.Rows[0]["Finance"].ToString().Trim() == "1" && (BasePage.UserSession.RoleId == 5 || BasePage.UserSession.RoleId == 1))
                    {
                        if (CheckIsAddedByFC(ProspId) == true)
                        {
                            ddlFinance_SelectedIndexChanged(null, null);
                        }

                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["SourceId"].ToString().Trim()))
                    {
                        //ListItem selectedSourceId = ddlSource.Items.FindByValue(Convert.ToString(dt.Rows[0]["SourceId"]).Trim());
                        //if (selectedSourceId != null)
                        //    selectedSourceId.Selected = true;
                        ddlSource.SelectedValue = dt.Rows[0]["SourceId"].ToString().Trim();
                    }
                    if (dt.Rows[0]["Finance"].ToString().Trim() == "1")
                        pnlFCDetails.Visible = true;
                    else
                        pnlFCDetails.Visible = false;

                    if (dt.Rows[0]["TradeIn"] != null && !string.IsNullOrEmpty(dt.Rows[0]["TradeIn"].ToString().Trim()))
                        chkTradeIn.Checked = Convert.ToBoolean(dt.Rows[0]["TradeIn"].ToString().Trim());
                    else
                        chkTradeIn.Checked = false;
                    if (dt.Rows[0]["ModelId"] != null && !string.IsNullOrEmpty(dt.Rows[0]["ModelId"].ToString().Trim()))
                    {
                        //ListItem selectedModelId = ddlModel.Items.FindByValue(Convert.ToString(dt.Rows[0]["ModelId"]).Trim());
                        //if (selectedModelId != null)
                        //    selectedModelId.Selected = true;
                        ddlModel.SelectedValue = dt.Rows[0]["ModelId"].ToString().Trim();
                    }
                    txtComments.Text = dt.Rows[0]["Comment"].ToString().Trim();
                    txtTradeInMakeModel.Text = dt.Rows[0]["TradeInMkModel"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["IsFleetLead"].ToString().Trim()))
                    {
                        if (dt.Rows[0]["IsFleetLead"].ToString().Trim().ToUpper() == "YES")
                            hdfIsFleetLead.Value = "true";
                        else
                            hdfIsFleetLead.Value = "false";
                    }
                    else
                        hdfIsFleetLead.Value = "false";
                    if (!string.IsNullOrEmpty(dt.Rows[0]["WhereDidUHear"].ToString().Trim()))
                    {
                        //ListItem selectedWhereDidUHear = ddlWhereDidUHear.Items.FindByValue(Convert.ToString(dt.Rows[0]["WhereDidUHear"]).Trim());
                        //if (selectedWhereDidUHear != null)
                        //    selectedWhereDidUHear.Selected = true;
                        ddlWhereDidUHear.SelectedValue = dt.Rows[0]["WhereDidUHear"].ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Used"].ToString().Trim()))
                    {
                        if (dt.Rows[0]["Used"].ToString().Trim().ToUpper() == "YES")
                            rbtnUsed.Checked = true;
                        else
                            rbtnNew.Checked = true;
                    }
                    else
                        rbtnNew.Checked = true;
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Make"].ToString().Trim().Replace("--", "")) && ((dt.Rows[0]["MakeFromId"].ToString().Trim().ToUpper() == "OTHER") || (Convert.ToInt64(dt.Rows[0]["CarMake"].ToString().Trim())) == 0))
                        lblActualMakeInput.Text = "(" + dt.Rows[0]["Make"].ToString().Trim() + ")";
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Model"].ToString().Trim().Replace("--", "")) && dt.Rows[0]["ModelFromId"].ToString().Trim().ToUpper() == "OTHER")
                        lblActualModelInput.Text = "(" + dt.Rows[0]["Model"].ToString().Trim() + ")";

                    lnkbtnSave.Text = Resources.PFSalesResource.update.Trim();
                    lnkbtnSave.ToolTip = Resources.PFSalesResource.UpdteProspDetails.Trim();
                    lnkbtnFinalClear.Text = Resources.PFSalesResource.Cancel.Trim();
                    lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.BackToSearch.Trim();
                    lblAddProspHead.Text = Resources.PFSalesResource.UpdateProspDet.Trim();
                    pnlAddProsp.Visible = true;
                    pnlSearchprosp.Visible = false;
                    ddlTitle.Focus();
                    if (BasePage.UserSession.RoleId != 1)
                        ddlFinance.Enabled = false;
                    DataTable dtFC = objProspBM.GetProspFCDetFromProId(ProspId);
                    if (dtFC != null && dtFC.Rows.Count > 0)
                    {
                        hdfFCId.Value = dtFC.Rows[0]["Id"].ToString().Trim();
                        if (!string.IsNullOrEmpty(dtFC.Rows[0]["CreditHistory"].ToString().Trim()) && dtFC.Rows[0]["CreditHistory"].ToString().Trim() != "--")
                        {
                            //ListItem selectedCreditHistory = ddlCredHistory.Items.FindByValue(Convert.ToString(dtFC.Rows[0]["CreditHistory"]).Trim());
                            //if (selectedCreditHistory != null)
                            //    selectedCreditHistory.Selected = true;
                            ddlCredHistory.SelectedValue = dtFC.Rows[0]["CreditHistory"].ToString().Trim();
                        }
                        if (!string.IsNullOrEmpty(dtFC.Rows[0]["EstimatedFinance"].ToString().Trim()) && dtFC.Rows[0]["EstimatedFinance"].ToString().Trim() != "--")
                            txtEstFin.Text = dtFC.Rows[0]["EstimatedFinance"].ToString().Trim();
                        if (!string.IsNullOrEmpty(dtFC.Rows[0]["InitialDeposite"].ToString().Trim()) && dtFC.Rows[0]["InitialDeposite"].ToString().Trim() != "--")
                            txtInitialDep.Text = dtFC.Rows[0]["InitialDeposite"].ToString().Trim();
                        if (!string.IsNullOrEmpty(dtFC.Rows[0]["Term"].ToString().Trim()) && dtFC.Rows[0]["Term"].ToString().Trim() != "--")
                        {
                            //ListItem selectedTerm = ddlTermYears.Items.FindByValue(Convert.ToString(dtFC.Rows[0]["Term"]).Trim());
                            //if (selectedTerm != null)
                            //    selectedTerm.Selected = true;
                            ddlTermYears.SelectedValue = dtFC.Rows[0]["Term"].ToString().Trim();
                        }
                        if (!string.IsNullOrEmpty(dtFC.Rows[0]["Payment"].ToString().Trim()) && dtFC.Rows[0]["Payment"].ToString().Trim() != "--")
                            txtResBaloon.Text = dtFC.Rows[0]["Payment"].ToString().Trim();
                        if (!string.IsNullOrEmpty(dtFC.Rows[0]["Message"].ToString().Trim()) && dtFC.Rows[0]["Message"].ToString().Trim() != "--")
                            txtFCMessage.Text = dtFC.Rows[0]["Message"].ToString().Trim();
                        if (!string.IsNullOrEmpty(dtFC.Rows[0]["FinanceType"].ToString().Trim()) && dtFC.Rows[0]["FinanceType"].ToString().Trim() != "--")
                        {
                            //ListItem selectedFinanceType = ddlfinReq.Items.FindByValue(Convert.ToString(dtFC.Rows[0]["FinanceType"]).Trim());
                            //if (selectedFinanceType != null)
                            //    selectedFinanceType.Selected = true;
                            ddlfinReq.SelectedValue = dtFC.Rows[0]["FinanceType"].ToString().Trim();
                        }
                        if (!string.IsNullOrEmpty(dtFC.Rows[0]["Employment"].ToString().Trim()) && dtFC.Rows[0]["Employment"].ToString().Trim() != "--")
                        {
                            //ListItem selecteEmployment = ddlEmployment.Items.FindByValue(Convert.ToString(dtFC.Rows[0]["Employment"]).Trim());
                            //if (selecteEmployment != null)
                            //    selecteEmployment.Selected = true;
                            ddlEmployment.SelectedValue = dtFC.Rows[0]["Employment"].ToString().Trim();
                        }
                        if (!string.IsNullOrEmpty(dtFC.Rows[0]["Employer"].ToString().Trim()) && dtFC.Rows[0]["Employer"].ToString().Trim() != "--")
                            txtEmployer.Text = dtFC.Rows[0]["Employer"].ToString().Trim();
                        if (!string.IsNullOrEmpty(dtFC.Rows[0]["CurrentIncome"].ToString().Trim()) && dtFC.Rows[0]["CurrentIncome"].ToString().Trim() != "--")
                            txtCurrentIncome.Text = dtFC.Rows[0]["CurrentIncome"].ToString().Trim();
                        if (!string.IsNullOrEmpty(dtFC.Rows[0]["Time_in_Cur_Emp"].ToString().Trim()) && dtFC.Rows[0]["Time_in_Cur_Emp"].ToString().Trim() != "--")
                        {
                            //ListItem selecteTime_in_Cur_Emp = ddlTimeinCurEmp.Items.FindByValue(Convert.ToString(dtFC.Rows[0]["Time_in_Cur_Emp"]).Trim());
                            //if (selecteTime_in_Cur_Emp != null)
                            //    selecteTime_in_Cur_Emp.Selected = true;
                            ddlTimeinCurEmp.SelectedValue = dtFC.Rows[0]["Time_in_Cur_Emp"].ToString().Trim();
                        }
                        if (!string.IsNullOrEmpty(dtFC.Rows[0]["Time_At_Cur_Add"].ToString().Trim()) && dtFC.Rows[0]["Time_At_Cur_Add"].ToString().Trim() != "--")
                        {
                            //ListItem selecteTime_At_Cur_Add = ddlTimeAtCurAdd.Items.FindByValue(Convert.ToString(dtFC.Rows[0]["Time_At_Cur_Add"]).Trim());
                            //if (selecteTime_At_Cur_Add != null)
                            //    selecteTime_At_Cur_Add.Selected = true;
                            ddlTimeAtCurAdd.SelectedValue = dtFC.Rows[0]["Time_At_Cur_Add"].ToString().Trim();
                        }
                        if (!string.IsNullOrEmpty(dtFC.Rows[0]["FinLeadTypeId"].ToString().Trim()) && dtFC.Rows[0]["FinLeadTypeId"].ToString().Trim() != "--" && dtFC.Rows[0]["FinLeadTypeId"].ToString().Trim() != "0")
                        {
                            //ListItem selecteFinReqFrom = ddlFinReqFrom.Items.FindByValue(Convert.ToString(dtFC.Rows[0]["FinLeadTypeId"]).Trim());
                            //if (selecteFinReqFrom != null)
                            //    selecteFinReqFrom.Selected = true;
                            ddlFinReqFrom.SelectedValue = dtFC.Rows[0]["FinLeadTypeId"].ToString().Trim();
                        }
                    }
                    else
                    {
                        txtCurrentIncome.Text = txtEmployer.Text = txtEstFin.Text = txtInitialDep.Text = txtResBaloon.Text = txtFCMessage.Text = string.Empty;
                        ddlFinReqFrom.SelectedValue = ddlTimeAtCurAdd.SelectedValue = ddlTimeinCurEmp.SelectedValue = ddlEmployment.SelectedValue = ddlfinReq.SelectedValue = ddlTermYears.SelectedValue = ddlCredHistory.SelectedValue = "0";
                    }
                    //Add By : Ayyaj Mujawar
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["ConsultantId"].ToString().Trim()))
                    //{
                    //    string isPFOrFC = dt.Rows[0]["isPFOrFC"].ToString().Trim().ToUpper();
                    //    if (isPFOrFC == "F")
                    //    {
                    //        rfvCarMake.Enabled = false;
                    //    }
                    //    else
                    //    {
                    //        rfvCarMake.Enabled = true;
                    //    }
                    //}

                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.lnkbtnEdit_Click Error:" + ex.StackTrace);

        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Bind Cantact Details Data of Parrent Page
    /// </summary>
    public void BindMangeData()
    {
        if (Convert.ToInt64(ViewState["ProspId"].ToString().Trim()) > 0)
        {
            MethodInfo methods1 = (this.Page).GetType().GetMethod("BidDataProsp");// ((Page)this.Parent).GetType().GetMethod("BindMangeActivity");
            if (methods1 != null)
            {
                object[] objParam = new object[] { Convert.ToInt64(ViewState["ProspId"].ToString().Trim()) };
                methods1.Invoke((this.Page), objParam);
            }
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
            //objActivity.ActStartTime = StartTime;//DateTime.Now.AddMinutes(noOfMinutes);// Deafult Start Time 10 Min After Lead Assignment
            //objActivity.ActEndTime = StartTime.AddMinutes(2);// Deafult End Time 2 Min After Start Time

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
            //objActAlertDetails.AlertTypeId = Cls_Constant.MailAlert;// Hard Coded For Email
            //objActAlertDetails.AlertValueBefore = 0;// If Zero Minutes Alarm Value Selected
            //objActAlertDetails.SnoozValue = 0;
            //objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// //array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
            //lstActAlerts.Add(objActAlertDetails);
            //ActAlertDetails objActAlertDetails1 = new ActAlertDetails();
            //objActAlertDetails1.AlertTypeId = Cls_Constant.DashBoardAlert;// Hard Coded For Dashboard Alert
            //objActAlertDetails1.AlertValueBefore = 0;// If Zero Minutes Alarm Value Selected
            //objActAlertDetails1.SnoozValue = 0;
            //objActAlertDetails1.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();//array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
            //lstActAlerts.Add(objActAlertDetails1);
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
            Logger.Error(ex.Message + "Prospects.SetAllocatedDate.Error:" + ex.StackTrace);
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
    /// Created By: Ayyaj mUjawar
    /// Created Date: 02 Dec 2014
    /// Description: Check IS lead added by Fc Consultant
    /// </summary>
    /// <returns></returns>
    private Boolean CheckIsAddedByFC(Int64 ProspID)
    {
        try
        {
            ProspectBM objProspectBM = new ProspectBM();
            int cnt = objProspectBM.CheckIsAddedByFC(ProspID);
            if (cnt > 0)
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddEditcontact ,CheckIsAddedByFC.error" + ex.StackTrace);
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
            FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + Name.Trim() + "<br /><br /> Duplicate Lead is reported for the lead which is already allocated to you, Please find the details as given bellow.<br /><br /> Name:" + prospName.Trim() + "<br /><br /> Email:" + prospEmail.Trim() + "<br /><br />Thanks you<br /> PFSales Team</span>";
            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "Email Sent Successfully", "Duplicate Lead Notified", "Add-Edit Contact User Control");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Duplicate Lead Notified", "Add-Edit Contact User Control");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.SendMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Duplicate Lead Notified", "Add-Edit Contact User Control");
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
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "Email Sent Successfully", "Duplicate Lead Notified", "Add-Edit Contact User Control");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Duplicate Lead Notified", "Add-Edit Contact User Control");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.SendMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Duplicate Lead Notified", "Add-Edit Contact User Control");
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
                return "Success";
            }
            return "No Prospect Id";
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.UpdateFinCarLeads.Error:" + ex.StackTrace);
            return "Error in connection";
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 15 Sept 2013
    /// Description: Bind Finance Request Came From Drop Down List
    /// </summary>
    public void BinFinReqFrom()
    {
        try
        {
            DataTable Dt = objMstBM.GetFinReqFrom();
            Cls_BinderHelper.BindDropdownList(ddlFinReqFrom, "FinFor", "ID", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_AddEditContact.BinFinReqFrom.Error:" + ex.StackTrace);
        }
    }
    #endregion
}