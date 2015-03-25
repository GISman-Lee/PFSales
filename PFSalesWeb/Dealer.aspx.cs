using System;
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

public partial class Dealer : BasePage
{
    #region Global Variables
    DealerBM objDealerBM = new DealerBM();
    clsDealer objDealer = new clsDealer();
    MasterBM objMstBM = new MasterBM();
    EmployeeBM objEmpBM = new EmployeeBM();
    ContactBM objContBM = new ContactBM();
    ILog Logger = LogManager.GetLogger(typeof(Dealer));
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = "Name";
            ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;
            BindAllMakes();
            BindFormats();
            BindAllCountry();
            BindAllStates();
            BindGrid();
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
    /// Description: Add Prospect Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddDealer_Click(object sender, EventArgs e)
    {
        pnlSearchDealer.Visible = false;
        pnlAddDealer.Visible = true;
        ViewState["DealerId"] = 0;
        ViewState["DealerKey"] = string.Empty;
        lnkbtnSave.Text = Resources.PFSalesResource.Save.Trim();
        lnkbtnSave.ToolTip = Resources.PFSalesResource.SaveDealer.Trim();
        lnkbtnFinalClear.Text = Resources.PFSalesResource.Clear.Trim();
        lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.Clear.Trim();
        lblAddDealerHead.Text = Resources.PFSalesResource.AddDealerDetails.Trim();
        ClearMsg();
        ClearAll();
        //To Enable control
        ddlState.Enabled = ddlPhPopUpCountry.Enabled = ddlCountry.Enabled = ddlSecState.Enabled = ddlPostalCode.Enabled = ddlCity.Enabled = txtFName.Enabled = txtLName.Enabled = txtPhNo.Enabled = txtMobile.Enabled = txtNotes.Enabled = txtAddLine1.Enabled = txtFax.Enabled = txtEmail1.Enabled = true;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
    /// Description: Gridview Page Index Changing Event. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDealer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvDealer.PageIndex = e.NewPageIndex;
            BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Dealer.gvDealer_PageIndexChanging Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
    /// Description: Gridview Page Sorting Event Of GridView. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDealer_Soring(object sender, GridViewSortEventArgs e)
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
            Logger.Error(ex.Message + "Dealer.gvDealer_Soring.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
    /// Description: Row Data Bound Event Of GridView. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDealer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkBtnDelete = (LinkButton)e.Row.FindControl("lnkbtnDelete");
                string lblName = ((Label)e.Row.FindControl("lblDealerName")).Text.Trim();
                lnkBtnDelete.Attributes.Add("onclick", "javascript:return confirm('" + Resources.PFSalesResource.DealerDeleteConfirm.Trim() + " " + lblName + "?')");
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Dealer.gvDealer_RowDataBound.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
    /// Description: Edit Button Click. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            ClearMsg();
            Int64 DealerId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
            ViewState["DealerId"] = DealerId;
            if (DealerId > 0)
            {
                DataTable dt = objDealerBM.GetDealerDetFromId(DealerId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["DKey"].ToString().Trim()))
                        ViewState["DealerKey"] = dt.Rows[0]["DKey"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FName"].ToString().Trim()))
                        txtFName.Text = dt.Rows[0]["FName"].ToString().Trim();//= ddlFName.SelectedValue
                    if (!string.IsNullOrEmpty(dt.Rows[0]["LName"].ToString().Trim()))
                        txtLName.Text = dt.Rows[0]["LName"].ToString().Trim();//= ddlLName.SelectedValue
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
                    txtMobile.Text = dt.Rows[0]["MobileNo"].ToString().Trim();
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
                    txtEmail1.Text = dt.Rows[0]["EmailId"].ToString().Trim();
                    BindAllStates();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["StateId"].ToString().Trim()))
                        ddlState.SelectedValue = dt.Rows[0]["StateId"].ToString().Trim();
                    BindAllPostalCode();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["PostalCode"].ToString().Trim()))
                        ddlPostalCode.SelectedValue = dt.Rows[0]["PostalCode"].ToString().Trim();
                    BindAllCities();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["CityId"].ToString().Trim()))
                        ddlCity.SelectedValue = dt.Rows[0]["CityId"].ToString().Trim();
                    txtCompany.Text = dt.Rows[0]["Company"].ToString().Trim();
                    txtAddLine1.Text = dt.Rows[0]["Address1"].ToString().Trim();
                    ddlSecState.SelectedValue = dt.Rows[0]["SecState"].ToString().Trim();
                    txtNotes.Text = dt.Rows[0]["Notes"].ToString().Trim();
                    lnkbtnSave.Text = Resources.PFSalesResource.update.Trim();
                    lnkbtnSave.ToolTip = Resources.PFSalesResource.UpdteDealerDetails.Trim();
                    lnkbtnFinalClear.Text = Resources.PFSalesResource.Cancel.Trim();
                    lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.BackToSearch.Trim();
                    lblAddDealerHead.Text = Resources.PFSalesResource.UpdteDealerDetails.Trim();

                    /* Modified By: Ayyaj Mujawar on 21 Oct 2013
                     * Desc: List Box Replace with DropDawn List*/
                    /*Start---------------------------------------------------*/
                    DataTable DtProspCont = objDealerBM.GetDeaMakeDetFromDeaId(DealerId);
                    ddlCarMake1.SelectedValue = DtProspCont.Rows[0]["MakeId"].ToString().Trim();
                    //foreach (DataRow dwrow in DtProspCont.Rows)
                    //{
                    //    foreach (ListItem lstRow in ddlCarMake1.Items)
                    //    {
                    //        if (lstRow.Value.Trim() == dwrow["MakeId"].ToString().Trim())
                    //        {
                    //            lstRow.Selected = true;
                    //        }
                    //        else if (lstRow.Value.Trim() == "0")
                    //        {
                    //            lstRow.Selected = false;
                    //        }
                    //    }
                    //}
                    /*End---------------------------------------------------*/
                    pnlAddDealer.Visible = true;
                    pnlSearchDealer.Visible = false;
                    txtFName.Focus();
                    /*Modified By: Ayyaj Mujawar on 19 Oct 2013
                     * Desc: To Enable Control -------------- */
                    ddlState.Enabled = ddlPhPopUpCountry.Enabled = ddlCountry.Enabled = ddlSecState.Enabled = ddlPostalCode.Enabled = ddlCity.Enabled = txtFName.Enabled = txtLName.Enabled = txtPhNo.Enabled = txtMobile.Enabled = txtNotes.Enabled = txtAddLine1.Enabled = txtFax.Enabled = txtEmail1.Enabled = true;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Dealer.lnkbtnEdit_Click Error:" + ex.StackTrace);

        }
    }


    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date: 18 Oct 2013
    /// Description: Duplicate Button Click. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnDuplicate_Click(object sender, EventArgs e)
    {
        try
        {
            ClearMsg();
            Int64 DealerId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
            ViewState["DealerId"] = DealerId;
            if (DealerId > 0)
            {
                DataTable dt = objDealerBM.GetDealerDetFromId(DealerId);
                if (dt != null && dt.Rows.Count > 0)
                {

                    //objDealer.DealerId = Convert.ToInt64(ViewState["DealerId"].ToString().Trim());
                    //if (ViewState["DealerKey"] != null && !string.IsNullOrEmpty(ViewState["DealerKey"].ToString().Trim()))
                    //    objDealer.DKey = ViewState["DealerKey"].ToString().Trim();
                    //else
                    //{
                    //    Guid gi = Guid.NewGuid();
                    //    objDealer.DKey = gi.ToString().Trim();
                    //}
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["DKey"].ToString().Trim()))
                    //    ViewState["DealerKey"] = dt.Rows[0]["DKey"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FName"].ToString().Trim()))
                        txtFName.Text = dt.Rows[0]["FName"].ToString().Trim();//= ddlFName.SelectedValue
                    if (!string.IsNullOrEmpty(dt.Rows[0]["LName"].ToString().Trim()))
                        txtLName.Text = dt.Rows[0]["LName"].ToString().Trim();//= ddlLName.SelectedValue
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
                    txtMobile.Text = dt.Rows[0]["MobileNo"].ToString().Trim();
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
                    txtEmail1.Text = dt.Rows[0]["EmailId"].ToString().Trim();
                    BindAllStates();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["StateId"].ToString().Trim()))
                        ddlState.SelectedValue = dt.Rows[0]["StateId"].ToString().Trim();
                    BindAllPostalCode();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["PostalCode"].ToString().Trim()))
                        ddlPostalCode.SelectedValue = dt.Rows[0]["PostalCode"].ToString().Trim();
                    BindAllCities();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["CityId"].ToString().Trim()))
                        ddlCity.SelectedValue = dt.Rows[0]["CityId"].ToString().Trim();
                    //txtCompany.Text = dt.Rows[0]["Company"].ToString().Trim();
                    txtAddLine1.Text = dt.Rows[0]["Address1"].ToString().Trim();
                    ddlSecState.SelectedValue = dt.Rows[0]["SecState"].ToString().Trim();
                    txtNotes.Text = dt.Rows[0]["Notes"].ToString().Trim();

                    lnkbtnSave.Text = Resources.PFSalesResource.Save.Trim();
                    lnkbtnSave.ToolTip = Resources.PFSalesResource.SaveDealer.Trim();
                    lnkbtnFinalClear.Text = Resources.PFSalesResource.Clear.Trim();
                    lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.Clear.Trim();
                    lblAddDealerHead.Text = Resources.PFSalesResource.AddDuplicateDealerDeatails.Trim();



                    //foreach (ListItem lstRow in lstCarMake.Items)
                    //{
                    //    DealerMake objDealMakeMap = new DealerMake();
                    //    if (lstRow.Selected)
                    //    {
                    //        lstRow.Selected = false;
                    //    }
                    //}

                    /*Desc: According To Requirement When We create Duplicate Dealer
                     * They will Select Make & Company again newly :Ayyaj Mujawar*/
                    /*--Start--*/
                    ddlCarMake1.SelectedValue = "0";
                    txtCompany.Text = string.Empty;
                    /*--End---*/

                    pnlAddDealer.Visible = true;
                    pnlSearchDealer.Visible = false;
                    txtFName.Focus();

                    //To disable controls so they can not edit remaining fields
                    ddlState.Enabled = ddlPhPopUpCountry.Enabled = ddlCountry.Enabled = ddlSecState.Enabled = ddlPostalCode.Enabled = ddlCity.Enabled = txtFName.Enabled = txtLName.Enabled = txtPhNo.Enabled = txtMobile.Enabled = txtNotes.Enabled = txtAddLine1.Enabled = txtFax.Enabled = txtEmail1.Enabled = false;
                    
                }
            }
            objDealer.DealerId = 0;
            ViewState["DealerId"] = 0;// Desc : To Create Duplicate Dealer We have To Clear Dealer Id Only: Ayyaj
            ViewState["DealerKey"] = null;

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Dealer.lnkbtnEdit_Click Error:" + ex.StackTrace);

        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
    /// Description: Delete Button Click. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Int64 DealerId = Int64.Parse(((LinkButton)sender).CommandArgument.Trim());
            Int64 Result = 0;
            objDealer.DealerId = DealerId;
            objDealer.CreatedById = BasePage.UserSession.VirtualRoleId;
            objDealer.IsDeleted = true;
            DealerMake objDealMakeMap = new DealerMake();

            /*---Code For Get All Data Oa Dealer---*/
            DataTable dt = objDealerBM.GetDealerDetFromId(DealerId);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["DKey"].ToString().Trim()))
                    objDealer.DKey = dt.Rows[0]["DKey"].ToString().Trim();
                if (!string.IsNullOrEmpty(dt.Rows[0]["FName"].ToString().Trim()))
                    objDealer.FName = dt.Rows[0]["FName"].ToString().Trim();//= ddlFName.SelectedValue
                if (!string.IsNullOrEmpty(dt.Rows[0]["LName"].ToString().Trim()))
                    objDealer.LName = dt.Rows[0]["LName"].ToString().Trim();//= ddlLName.SelectedValue

                if (!string.IsNullOrEmpty(dt.Rows[0]["FormatedPhone"].ToString().Trim()) && dt.Rows[0]["FormatedPhone"].ToString().Trim() != "0")
                    ddlPhFormat.SelectedValue = dt.Rows[0]["FormatedPhone"].ToString().Trim();

                objDealer.Phone = dt.Rows[0]["Phone"].ToString().Trim();

                if (!string.IsNullOrEmpty(dt.Rows[0]["FormatedMobile"].ToString().Trim()) && dt.Rows[0]["FormatedMobile"].ToString().Trim() != "0")
                    ddlPhFormat.SelectedValue = dt.Rows[0]["FormatedMobile"].ToString().Trim();

                objDealer.Mobile = dt.Rows[0]["MobileNo"].ToString().Trim();

                if (!string.IsNullOrEmpty(dt.Rows[0]["FormatedFax"].ToString().Trim()) && dt.Rows[0]["FormatedFax"].ToString().Trim() != "0")
                    ddlPhFormat.SelectedValue = dt.Rows[0]["FormatedFax"].ToString().Trim();

                objDealer.Fax = dt.Rows[0]["Fax"].ToString().Trim();
                objDealer.Email = dt.Rows[0]["EmailId"].ToString().Trim();

                if (!string.IsNullOrEmpty(dt.Rows[0]["StateId"].ToString().Trim()))
                    objDealer.StateId = Convert.ToInt32(dt.Rows[0]["StateId"]);

                if (!string.IsNullOrEmpty(dt.Rows[0]["PostalCode"].ToString().Trim()))
                    objDealer.PostalCode = dt.Rows[0]["PostalCode"].ToString().Trim();

                if (!string.IsNullOrEmpty(dt.Rows[0]["CityId"].ToString().Trim()))
                    objDealer.CityId = Convert.ToInt16(dt.Rows[0]["CityId"]);
                objDealer.Company = dt.Rows[0]["Company"].ToString().Trim();
                objDealer.Add1 = dt.Rows[0]["Address1"].ToString().Trim();
                objDealer.SecStateId = Convert.ToInt16(dt.Rows[0]["SecState"]);

                /* Modified By: Ayyaj Mujawar on 21 Oct 2013
                 * Desc: List Box Replace with DropDawn List*/
                /*Start---------------------------------------------------*/
                DataTable DtProspCont = objDealerBM.GetDeaMakeDetFromDeaId(DealerId);
                


                objDealMakeMap.MakeId = Convert.ToInt16(DtProspCont.Rows[0]["MakeId"]);


                /*-------------------------------------*/
            }

            Result = objDealerBM.DeleteDealers(objDealer);
            if (Result > 0)
            {
                SyncDataFromCRMToPF.SyncDataFromCRMSoapClient objDealerAdd = new SyncDataFromCRMToPF.SyncDataFromCRMSoapClient();
                objDealerAdd.SaveDealerFromCRM((objDealer.FName + " " + objDealer.LName).Trim(), objDealer.DKey, objDealer.Company, objDealer.Add1, objDealMakeMap.MakeId, objDealer.CityId, objDealer.Phone, objDealer.Mobile, objDealer.Email, objDealer.Fax, objDealer.PostalCode, objDealer.StateId, objDealer.SecStateId, false, false, false, false);
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
            txtserDealerName.Focus();
            BindGrid();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Dealer.lnkbtnDelete_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
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
    /// Created Date: 25 July 2013
    /// Description: Clear Button Click. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnClear_Click(object sender, EventArgs e)
    {
        txtserDealerName.Text = string.Empty;
        ddlCarMake.SelectedValue = "0";
        txtserCompany.Text = string.Empty;
        txtserDealerName.Focus();
        BindGrid();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
    /// Description: Selected Index Changed Event Of Car Make's Drop Down List. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlCarMake_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
    /// Description: Back To Search Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnBackToSearch_Click(object sender, EventArgs e)
    {
        ViewState["DealerId"] = 0;
        BindGrid();
        pnlSearchDealer.Visible = true;
        pnlAddDealer.Visible = false;
        ClearMsg();
        txtserDealerName.Focus();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
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
    /// Created Date: 25 July 2013
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
    /// Created Date: 25 July 2013
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
    /// Created Date: 25 July 2013
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
    /// Created Date: 25 July 2013
    /// Description: Selected Index Changed Event Of State's Drop Down List 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindAllPostalCode();
        ClearMsg();
        ddlPostalCode_SelectedIndexChanged(null, null);
        BindAllCities();
        //ddlPostalCode.Focus();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
    /// Description: Save Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //int cnt = 0;

            //foreach (ListItem lstRow in lstCarMake.Items)
            //{
            //    if (lstRow.Selected)
            //    {
            //        cnt++;
            //    }
            //}
            //if (cnt > 0)
            //{
                Int64 Result = 0;
                if (ViewState["DealerId"] != null && BasePage.UserSession != null)
                {

                    objDealer.DealerId = Convert.ToInt64(ViewState["DealerId"].ToString().Trim());
                    if (ViewState["DealerKey"] != null && !string.IsNullOrEmpty(ViewState["DealerKey"].ToString().Trim()))
                        objDealer.DKey = ViewState["DealerKey"].ToString().Trim();
                    else
                    {
                        Guid gi = Guid.NewGuid();
                        objDealer.DKey = gi.ToString().Trim();
                    }
                    if (!string.IsNullOrEmpty(txtFName.Text.Trim()))
                    {
                        string str = txtFName.Text.Trim().Substring(0, 1);
                        str = str.ToUpper();
                        objDealer.FName = (str.Trim() + txtFName.Text.Trim().Remove(0, 1)).Trim();// ddlFName.SelectedValue.Trim().Replace("  ", " ");
                    }
                    else
                        objDealer.FName = string.Empty;
                    //if (ddlLName.SelectedValue.Trim().ToLower() != Resources.PFSalesResource.ddlSelect.Trim().ToLower())
                    if (!string.IsNullOrEmpty(txtLName.Text.Trim()))
                    {
                        string str = txtLName.Text.Trim().Substring(0, 1);
                        str = str.ToUpper();
                        objDealer.LName = (str.Trim() + txtLName.Text.Trim().Remove(0, 1)).Trim();// ddlLName.SelectedValue.Trim().Replace("  ", " ");
                    }
                    else
                        objDealer.LName = string.Empty;//ddlLName.SelectedValue.Trim().Replace("  ", " ");
                    objDealer.Phone = txtPhNo.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
                    if (!string.IsNullOrEmpty(hdfPhoneFormatId.Value.Trim()))
                        objDealer.formatedPhoNo = Convert.ToInt64(hdfPhoneFormatId.Value.Trim());
                    else
                        objDealer.formatedPhoNo = Convert.ToInt64(ddlPhFormat.SelectedValue.Trim());
                    objDealer.Mobile = txtMobile.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
                    if (!string.IsNullOrEmpty(hdfMobileFormatId.Value.Trim()))
                        objDealer.formatedMobNo = Convert.ToInt64(hdfMobileFormatId.Value.Trim());
                    else
                        objDealer.formatedMobNo = Convert.ToInt64(ddlPhFormat.SelectedValue.Trim());
                    objDealer.Fax = txtFax.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
                    if (!string.IsNullOrEmpty(hdfFaxFormatId.Value.Trim()))
                        objDealer.formatedFax = Convert.ToInt64(hdfFaxFormatId.Value.Trim());
                    else
                        objDealer.formatedFax = Convert.ToInt64(ddlPhFormat.SelectedValue.Trim());
                    objDealer.Email = txtEmail1.Text.Trim();
                    objDealer.StateId = Convert.ToInt32(ddlState.SelectedValue.Trim());
                    objDealer.CityId = Convert.ToInt32(ddlCity.SelectedValue.Trim());
                    objDealer.PostalCode = ddlPostalCode.SelectedValue.Trim();
                    objDealer.SecStateId = Convert.ToInt32(ddlSecState.SelectedValue.Trim());
                    objDealer.Company = txtCompany.Text.Trim();
                    objDealer.Add1 = txtAddLine1.Text.Trim();
                    objDealer.CreatedById = BasePage.UserSession.VirtualRoleId;
                    objDealer.IsDeleted = false;
                    objDealer.Notes = txtNotes.Text.Trim();
                    List<DealerMake> lstDMMapping = new List<DealerMake>();
                    //foreach (ListItem lstRow in lstCarMake.Items)
                    //{
                    DealerMake objDealMakeMap = new DealerMake();
                    //    if (lstRow.Selected)
                    //    {
                    objDealMakeMap.MakeId = Convert.ToInt16(ddlCarMake1.SelectedValue.Trim());
                    lstDMMapping.Add(objDealMakeMap);

                    //    }
                    //}
                    objDealer.lstDMMapping = lstDMMapping;
                    if (objDealer.DealerId == 0)
                    {
                        Result = objDealerBM.AddDealers(objDealer);
                        if (Result > 0)
                        {
                            SyncDataFromCRMToPF.SyncDataFromCRMSoapClient objDealerAdd = new SyncDataFromCRMToPF.SyncDataFromCRMSoapClient();
                            //objDealerAdd.SaveDealerFromCRM((objDealer.FName+" "+objDealer.LName).Trim(), objDealer.DKey, objDealer.Company, , 2, 2, "8087114580", "8087114580", "Akshay@mechsoftgroup.com", "020113355", "2215", 2, 1, true, false, false, DateTime.Now, true);
                             //objDealerAdd.SaveDealerFromCRM((objDealer.FName+" "+objDealer.LName).Trim(), objDealer.DKey, objDealer.Company,objDealer.Add1,objDealer.CarMake,objDealer.CityId,objDealer.Phone,objDealer.Mobile,objDealer.Email,objDealer.Fax,objDealer.PostalCode,objDealer.StateId,objDealer.SecStateId,true,false,false,true);
                            objDealerAdd.SaveDealerFromCRM((objDealer.FName + " " + objDealer.LName).Trim(), objDealer.DKey, objDealer.Company, objDealer.Add1, objDealMakeMap.MakeId, objDealer.CityId, objDealer.Phone, objDealer.Mobile, objDealer.Email, objDealer.Fax, objDealer.PostalCode, objDealer.StateId, objDealer.SecStateId, true, false, false, true);
                            lblSerSucMsg.Text = Resources.PFSalesResource.DealerAddedSuccessfuly.Trim();
                            lblSerErrMsg.Text = string.Empty;
                            dvadderror.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                            dvaserSuccess.Visible = true;
                            BindGrid();
                            pnlAddDealer.Visible = false;
                            pnlSearchDealer.Visible = true;
                            txtserDealerName.Focus();
                        }
                        else if (Result == -5)
                        {
                            lblAddErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                            lblAddSucMsg.Text = string.Empty;
                            dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                            dvadderror.Visible = true;
                            txtFName.Focus();
                        }
                        else
                        {
                            lblAddErrMsg.Text = Resources.PFSalesResource.ProspNotAdded.Trim();
                            lblAddSucMsg.Text = string.Empty;
                            dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                            dvadderror.Visible = true;
                            txtFName.Focus();
                        }
                    }
                    else if (objDealer.DealerId > 0)
                    {
                        Result = objDealerBM.UpdateDealers(objDealer);
                        if (Result > 0)
                        {
                            SyncDataFromCRMToPF.SyncDataFromCRMSoapClient objDealerAdd = new SyncDataFromCRMToPF.SyncDataFromCRMSoapClient();
                            objDealerAdd.SaveDealerFromCRM((objDealer.FName + " " + objDealer.LName).Trim(), objDealer.DKey, objDealer.Company, objDealer.Add1, objDealMakeMap.MakeId, objDealer.CityId, objDealer.Phone, objDealer.Mobile, objDealer.Email, objDealer.Fax, objDealer.PostalCode, objDealer.StateId, objDealer.SecStateId, true, false, false, false);
                            lblSerSucMsg.Text = Resources.PFSalesResource.DealerDetailsUpdated.Trim();
                            lblSerErrMsg.Text = string.Empty;
                            dvadderror.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                            dvaserSuccess.Visible = true;
                            BindGrid();
                            pnlAddDealer.Visible = false;
                            pnlSearchDealer.Visible = true;
                            txtserDealerName.Focus();
                        }
                        else if (Result == -5)
                        {
                            lblAddErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                            lblAddSucMsg.Text = string.Empty;
                            dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                            dvadderror.Visible = true;
                            txtFName.Focus();
                        }
                        else
                        {
                            lblAddErrMsg.Text = Resources.PFSalesResource.DealerDetailsNotUpdate.Trim();
                            lblAddSucMsg.Text = string.Empty;
                            dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                            dvadderror.Visible = true;
                            txtFName.Focus();
                        }
                    }
                }
            //}
            //else
            //{
            //    lblAddErrMsg.Text = Resources.PFSalesResource.SelectMakeVal.Trim();
            //    lblAddSucMsg.Text = string.Empty;
            //    dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
            //    dvadderror.Visible = true;
            //    txtFName.Focus();
            //}
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Dealer.lnkbtnSave_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
    /// Description: Clear Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFinalClear_Click(object sender, EventArgs e)
    {
        if (ViewState["DealerId"] != null && !string.IsNullOrEmpty(ViewState["DealerId"].ToString().Trim()) && Convert.ToInt64(ViewState["DealerId"].ToString().Trim()) > 0)
        {
            ClearAll();
            pnlAddDealer.Visible = false;
            pnlSearchDealer.Visible = true;
        }
        else if (ViewState["DealerId"] != null && !string.IsNullOrEmpty(ViewState["DealerId"].ToString().Trim()) && Convert.ToInt64(ViewState["DealerId"].ToString().Trim()) == 0)
            ClearAll();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
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
    /// Created Date: 25 July 2013
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
    /// Created Date: 25 July 2013
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
        pnlphonePopUp.Visible = false;
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date:25 July 2013
    /// Description: Show Contact Pop Up Button Click.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnNamePopUp_Click(object sender, EventArgs e)
    {
        try
        {
            pnlContactPopUp.Visible = true;
            ClearMsg();

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Dealer.lnkbtnNamePopUp_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date:25 July 2013
    /// Description: Close Contact Name's Pop Up
    /// </summary>
    /// <param name="Sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnNamePopUpClose_Close(object sender, EventArgs e)
    {
        try
        {
            pnlContactPopUp.Visible = false;
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Dealer.lnkbtnPhPopClose_Close.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date:25 July 2013
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
        //if (ddlFName.SelectedValue.Trim() != Resources.PFSalesResource.ddlSelect.Trim() || ddlMName.SelectedValue.Trim() != Resources.PFSalesResource.ddlSelect.Trim() || ddlLName.SelectedValue.Trim() != Resources.PFSalesResource.ddlSelect.Trim())
        //    txtAddName.Text = ((ddlFName.SelectedValue.Trim() != Resources.PFSalesResource.ddlSelect.Trim()) ? ddlFName.SelectedValue.Trim() : string.Empty).Trim().Replace("  ", " ") + " " + ((ddlMName.SelectedValue.Trim() != Resources.PFSalesResource.ddlSelect.Trim()) ? ddlMName.SelectedValue.Trim() : string.Empty).Trim().Replace("  ", " ") + " " + ((ddlLName.SelectedValue.Trim() != Resources.PFSalesResource.ddlSelect.Trim()) ? ddlLName.SelectedValue.Trim() : string.Empty).Trim().Replace("  ", " ");
        //txtAddName.Text = txtAddName.Text.Trim().Replace("  ", " ");
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
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
                Int32 intAllCount = Convert.ToInt32(ViewState["TotalCount"]);
                gvDealer.PageSize = intAllCount;
            }
            else
            {
                gvDealer.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue.Trim());
            }
            BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Dealer.ddlPageSize_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
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
            Logger.Error(ex.Message + "Dealer.ddlPhFormat_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
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
            Logger.Error(ex.Message + "Dealer.ddlPostalCode_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }
    #endregion

    #region Methods

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
    /// Description: Bind Grid View Data
    /// </summary>
    private void BindGrid()
    {
        try
        {
            objDealer.FName = txtserDealerName.Text.Trim();
            objDealer.CarMake = Convert.ToInt16(ddlCarMake.SelectedValue.Trim());
            objDealer.Company = txtserCompany.Text.Trim();
            DataTable Dt = objDealerBM.GetAllDealers(objDealer);
            if (Dt != null & Dt.Rows.Count > 0)
            {
                DataView dV = Dt.DefaultView;
                dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
                gvDealer.DataSource = Dt;
                gvDealer.DataBind();
                ViewState["TotalCount"] = Dt.Rows.Count;
            }
            else
            {
                gvDealer.DataSource = null;
                gvDealer.DataBind();
                ViewState["TotalCount"] = "0";
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Dealer.BindGrid.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Crearted By:Pravin Gholap
    /// Created Date:25 July 2013
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
            Logger.Error(ex.Message + "Dealer.DefineSortDirection.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
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
            Logger.Error(ex.Message + "Dealer.BindAllCountry.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
    /// Description: Get All State
    /// </summary>
    private void BindAllStates()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllState(string.Empty, Convert.ToInt64(ddlCountry.SelectedValue.Trim()));
            Cls_BinderHelper.BindDropdownList(ddlState, "StateName", "Id", Dt);
            Cls_BinderHelper.BindDropdownList(ddlSecState, "StateName", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Dealer.BindAllStates.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
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
            Logger.Error(ex.Message + "Dealer.BindAllPostalCode.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
    /// Description: Get All Cities
    /// </summary>
    private void BindAllCities()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllCitiesFromPCode(ddlPostalCode.SelectedValue.Trim());
            Cls_BinderHelper.BindDropdownList(ddlCity, "CityName", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Dealer.BindAllCities.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
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
            Logger.Error(ex.Message + "Dealer.BindDesignations.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
    /// Description: Clear Add Employee Panel
    /// </summary>
    private void ClearAll()
    {
        ddlPhPopUpCountry.SelectedValue = ddlCountry.SelectedValue = "1";
        ddlCountry_SelectedIndexChanged(null, null);
        ddlSecState.SelectedValue = ddlState.SelectedValue = ddlPostalCode.SelectedValue = "0";
        ddlPostalCode_SelectedIndexChanged(null, null);
        ddlCity.SelectedValue = "0";
        ddlCarMake1.SelectedValue = "0";

        //ddlCarMake1.sele
        ViewState["DealerKey"] = hdfPhPopType.Value = txtFName.Text = txtLName.Text = txtPhNo.Text = txtMobile.Text = txtNotes.Text = txtCompany.Text = txtAddLine1.Text = txtFax.Text = txtEmail1.Text = string.Empty;
        BindFormats();
        SetDefaultFormat();
        //foreach (ListItem lstRow in lstCarMake.Items)
        //{
        //    DealerMake objDealMakeMap = new DealerMake();
        //    if (lstRow.Selected)
        //    {
        //        lstRow.Selected = false;
        //    }
        //}
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
    /// Description: Clear All Message's Text
    /// </summary>
    private void ClearMsg()
    {
        lblAddErrMsg.Text = lblAddSucMsg.Text = lblSerErrMsg.Text = lblSerSucMsg.Text = string.Empty;
        dvadderror.Visible = dvaddSucc.Visible = dvaserSuccess.Visible = dvsererror.Visible = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
    /// Description: Get All Makes
    /// </summary>
    private void BindAllMakes()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllMakes(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlCarMake1, "Make", "Id", Dt);
            Cls_BinderHelper.BindDropdownList(ddlCarMake, "Make", "Id", Dt);
            ddlCarMake1.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Dealer.BindAllMakes.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
    /// Description: Set Default Format For Phone, Mobile & Fax Number
    /// </summary>
    private void SetDefaultFormat()
    {
        if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
        {
            ftePhNo.Enabled = fteMobile.Enabled = fteFax.Enabled = false;
            msePhPopUp.Mask = mseFax.Mask = mseMobile.Mask = msePhNo.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
            msePhPopUp.Enabled = mseFax.Enabled = mseMobile.Enabled = msePhNo.Enabled = true;
        }
        else
        {
            ftePhNo.Enabled = fteMobile.Enabled = fteFax.Enabled = true;
            msePhPopUp.Mask = mseFax.Mask = mseMobile.Mask = msePhNo.Mask = "99999999999999999999";
            msePhPopUp.Enabled = mseFax.Enabled = mseMobile.Enabled = msePhNo.Enabled = false;
        }
    }
    #endregion
}
