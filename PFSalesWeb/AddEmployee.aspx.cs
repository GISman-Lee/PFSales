using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Mechsoft.PFSales.BusinessEntity;
using Mechsoft.PFSales.BusinessManager;
using log4net;
using Mechsoft.GeneralUtilities;
using System.IO;

public partial class AddEmployee : BasePage
{
    #region Global Variables
    Employee objEmp = new Employee();
    EmployeeBM objEmpBm = new EmployeeBM();
    MasterBM objMstBM = new MasterBM();
    ILog Logger = LogManager.GetLogger(typeof(AddEmployee));
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = "Name";
            ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;
            BindRoles();
            BindGrid();
            BindAllCountry();
            BindDesignations();
            BindProfessions();
            BindFormats();
            BindVirtualPersons();
            SetDefaultFormat();
            txtempName.Focus();
            CompValToTodayDate.ValueToCompare = DateTime.Today.Date.ToString(Resources.PFSalesResource.dateformat.Trim());
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 May 2013
    /// Description: Page Index Changing Event Of Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEmp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvEmp.PageIndex = e.NewPageIndex;
            BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddEmployee.gvEmp_PageIndexChanging Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 May 2013
    /// Description: Sorting Event For Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEmp_Soring(object sender, GridViewSortEventArgs e)
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
            Logger.Error(ex.Message + "AddEmployee.gvEmp_Soring Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 May 2013
    /// Description:Edit Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            ClearMsg();
            Int64 EmpId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
            ViewState["EmpId"] = EmpId;
            if (EmpId > 0)
            {
                DataTable dt = objEmpBm.GetEmployeeFromId(EmpId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["EmpKey"].ToString().Trim()))
                        ViewState["EmpKey"] = dt.Rows[0]["EmpKey"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["QuoteUserId"].ToString().Trim()))
                        ViewState["QuoteUserId"] = dt.Rows[0]["QuoteUserId"].ToString().Trim();
                    ddlTitle.SelectedValue = dt.Rows[0]["Title"].ToString().Trim();
                    txtAddName.Text = dt.Rows[0]["FName"].ToString().Trim() + " " + dt.Rows[0]["MName"].ToString().Trim() + " " + dt.Rows[0]["LName"].ToString().Trim();
                    txtAddName.Text = txtAddName.Text.Trim().Replace("  ", " ");
                    ShowEmployeeName();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FName"].ToString().Trim()))
                        txtFName.Text = dt.Rows[0]["FName"].ToString().Trim();//ddlFName.SelectedValue = 
                    if (!string.IsNullOrEmpty(dt.Rows[0]["MName"].ToString().Trim()))
                        txtMName.Text = dt.Rows[0]["MName"].ToString().Trim();//ddlMName.SelectedValue =
                    if (!string.IsNullOrEmpty(dt.Rows[0]["LName"].ToString().Trim()))
                        txtLName.Text = dt.Rows[0]["LName"].ToString().Trim();//ddlLName.SelectedValue = 
                    ddlGender.SelectedValue = dt.Rows[0]["Gender"].ToString().Trim();
                    txtDOB.Text = dt.Rows[0]["DOB"].ToString().Trim();
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
                    if (!string.IsNullOrEmpty(dt.Rows[0]["PhoneExt"].ToString().Trim()))
                        txtExt.Text = dt.Rows[0]["PhoneExt"].ToString().Trim();

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

                    hdfFaxFormatId.Value = dt.Rows[0]["FormatedFax"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["FormatedFax"].ToString().Trim()) && dt.Rows[0]["FormatedPhone"].ToString().Trim() != "0")
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
                    txtEmail2.Text = dt.Rows[0]["Email2"].ToString().Trim();
                    txtAddLine1.Text = dt.Rows[0]["Add1"].ToString().Trim();
                    txtAddLine2.Text = dt.Rows[0]["Add2"].ToString().Trim();
                    txtAddLine3.Text = dt.Rows[0]["Add3"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["CountryId"].ToString().Trim()))
                        ddlCountry.SelectedValue = dt.Rows[0]["CountryId"].ToString().Trim();
                    BindAllStates();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["StateId"].ToString().Trim()))
                        ddlState.SelectedValue = dt.Rows[0]["StateId"].ToString().Trim();
                    BindAllPostalCode();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["PostalCode"].ToString().Trim()))
                        ddlPostalCode.SelectedValue = dt.Rows[0]["PostalCode"].ToString().Trim();
                    BindAllCities();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["CityId"].ToString().Trim()))
                        ddlCity.SelectedValue = dt.Rows[0]["CityId"].ToString().Trim();
                    //txtPostalCode.Text = dt.Rows[0]["PostalCode"].ToString().Trim();
                    txtDOJ.Text = dt.Rows[0]["DOJ"].ToString().Trim();
                    ddlAddRole.SelectedValue = dt.Rows[0]["Role"].ToString().Trim();
                    ddlAddRole_SelectedIndexChanged(null, null);
                    ddlDesig.SelectedValue = dt.Rows[0]["DesignationId"].ToString().Trim();
                    hdnEmployeePhoto.Value = dt.Rows[0]["PhotoFilePath"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["PhotoFilePath"].ToString().Trim()))
                    {
                        imgEmpPhoto.ImageUrl = dt.Rows[0]["PhotoFilePath"].ToString().Trim();
                        lnkbtnRemove.Visible = true;
                    }
                    else
                    {
                        imgEmpPhoto.ImageUrl = "~/Images/NoPhoto.png";
                        lnkbtnRemove.Visible = false;
                    }
                    if (!Convert.ToBoolean(dt.Rows[0]["IsNewEmployee"].ToString().Trim()))
                    {
                        chkRepExisting.Checked = true;
                        chkRepExisting_CheckChanged(null, null);
                        //lblRepPerUserName.Text = "Replaced Employee Name: " + dt.Rows[0]["RepPerUserName"].ToString().Trim();
                        ddlVirtualPersons.Items.Remove(ddlVirtualPersons.Items.FindByValue(dt.Rows[0]["ReplacedVId"].ToString().Trim()));
                        ddlVirtualPersons.Items.Add(new ListItem(dt.Rows[0]["RepPerUserName"].ToString().Trim(), dt.Rows[0]["ReplacedVId"].ToString().Trim()));
                        ddlVirtualPersons.SelectedValue = dt.Rows[0]["ReplacedVId"].ToString().Trim();
                    }
                    if (Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString().Trim()))
                        chkIsActive.Checked = true;
                    else
                        chkIsActive.Checked = false;
                    hdfUserId.Value = dt.Rows[0]["UserId"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["IsInFleetTeam"].ToString().Trim()) && dt.Rows[0]["IsInFleetTeam"].ToString().Trim().ToUpper() == "YES")
                        chkIsInFleetLead.Checked = true;
                    else
                        chkIsInFleetLead.Checked = false;
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Password"].ToString().Trim()))
                        ViewState["Password"] = dt.Rows[0]["Password"].ToString().Trim();
                    lnkbtnSave.Text = Resources.PFSalesResource.update.Trim();
                    lnkbtnSave.ToolTip = Resources.PFSalesResource.UpdteEmpDetails.Trim();
                    lnkbtnFinalClear.Text = Resources.PFSalesResource.Cancel.Trim();
                    lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.BackToSearch.Trim();
                    lblAddEmpHead.Text = Resources.PFSalesResource.UpdteEmpDetails.Trim();
                    pnlAddEmployee.Visible = true;
                    pnlSearchEmployee.Visible = false;
                    ddlTitle.Focus();
                    hdfUserVRId.Value = dt.Rows[0]["UserVID"].ToString().Trim();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddEmployee.lnkbtnEdit_Click Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 May 2013
    ///  Description: Country's Drop Down Selected Index Changed 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindAllStates();
        BindAllPostalCode();
        BindAllCities();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap   
    /// Created Date: 20 May 2013
    /// Description: Selected Index Changed Event Of State's Drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindAllPostalCode();
        BindAllCities();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 May 2013
    /// Description: Button Click Event of Upload Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnUpload_Click(object sender, EventArgs e)
    {
        SaveEmpPhoto();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 21 May 2013
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
            Logger.Error(ex.Message + "AddEmployee.lnkbtnNamePopUp_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 21 May 2013
    /// Description: Close Phone Number's Pop Up
    /// </summary>
    /// <param name="Sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnPhPopClose_Close(object Sender, EventArgs e)
    {
        pnlphonePopUp.Visible = false;
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 21 May 2013
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
            Logger.Error(ex.Message + "AddEmployee.lnkbtnPhPopClose_Close.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 21 May 2013
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
    /// Created Date: 21 May 2013
    /// Description: Show Phone Number's Pop Up
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
        txtPhPopUpPhoNo.Text = txtPhNo.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
        pnlphonePopUp.Visible = true;
        ClearMsg();
        hdfPhPopType.Value = "PHONE";
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 21 May 2013
    /// Description: Close Phone Number Format's Pop Up 
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
    /// Created Date: 21 May 2013
    /// Description: Selected Index Changed Event Of Countries Drop Down List
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
    /// Created Date: 21 May 2013
    /// Description: Show Contact Format's Pop Up For Mobile 
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
    /// Created Date: 21 May 2013
    /// Description: Show Contact Format's Pop Up For Fax 
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
    /// Created Date: 21 May 2013
    /// Description: Check Changed Event Of Existing Employee Replacement
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkRepExisting_CheckChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkRepExisting.Checked)
                dtvirtualPerson.Visible = ddvirtualPerson.Visible = true;
            else
                dtvirtualPerson.Visible = ddvirtualPerson.Visible = false;
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddEmployee.chkRepExisting_CheckChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 21 May 2013
    /// Description: Add New Employee Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddEmp_Click(object sender, EventArgs e)
    {
        try
        {
            pnlAddEmployee.Visible = true;
            pnlSearchEmployee.Visible = false;
            ViewState["EmpId"] = 0;
            ViewState["EmpKey"] = string.Empty;
            ViewState["QuoteUserId"] = 0;
            hdfUserId.Value = "0";
            lnkbtnSave.Text = Resources.PFSalesResource.Save.Trim();
            lnkbtnSave.ToolTip = Resources.PFSalesResource.SaveEmployee.Trim();
            lnkbtnFinalClear.Text = Resources.PFSalesResource.Clear.Trim();
            lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.Clear.Trim();
            lblAddEmpHead.Text = Resources.PFSalesResource.AddEmpDetails.Trim();
            ClearMsg();
            ClearAll();
            ddlTitle.Focus();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddEmployee.lnkbtnAddEmp_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 21 May 2013
    /// Description: Back To Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnBackToSearch_Click(object sender, EventArgs e)
    {
        ViewState["EmpId"] = 0;
        BindGrid();
        pnlSearchEmployee.Visible = true;
        pnlAddEmployee.Visible = false;
        ClearMsg();
        txtempName.Focus();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 21 May 2013
    /// Description: Delete Employee Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Int64 EmpId = Int64.Parse(((LinkButton)sender).CommandArgument.Trim());
            Int64 Result = 0;
            objEmp.EmpId = EmpId;
            DataTable dt = objEmpBm.GetEmployeeFromId(EmpId);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["Title"].ToString().Trim()))
                    objEmp.Title = Convert.ToInt32(dt.Rows[0]["Title"].ToString().Trim());
                objEmp.QuoteUserId =Convert.ToInt64(dt.Rows[0]["QuoteUserId"].ToString().Trim());
                objEmp.EmpKey = dt.Rows[0]["EmpKey"].ToString().Trim();
                objEmp.FName = dt.Rows[0]["FName"].ToString().Trim();
                if (!string.IsNullOrEmpty(dt.Rows[0]["MName"].ToString().Trim()))
                    objEmp.MName = dt.Rows[0]["MName"].ToString().Trim();
                if (!string.IsNullOrEmpty(dt.Rows[0]["LName"].ToString().Trim()))
                    objEmp.LName = dt.Rows[0]["LName"].ToString().Trim();
                if (!string.IsNullOrEmpty(dt.Rows[0]["DOB"].ToString().Trim()))
                    objEmp.DOB = Convert.ToDateTime(dt.Rows[0]["DOB"].ToString().Trim());
                objEmp.Phone = dt.Rows[0]["Phone"].ToString().Trim();
                objEmp.PhoneExt = dt.Rows[0]["PhoneExt"].ToString().Trim();
                objEmp.Mobile = dt.Rows[0]["Mobile"].ToString().Trim();
                objEmp.Fax = dt.Rows[0]["Fax"].ToString().Trim();
                objEmp.Email = dt.Rows[0]["Email1"].ToString().Trim();
                objEmp.Email1 = dt.Rows[0]["Email2"].ToString().Trim();
                objEmp.Add1 = dt.Rows[0]["Add1"].ToString().Trim();
                objEmp.Add2 = dt.Rows[0]["Add2"].ToString().Trim();
                objEmp.Add3 = dt.Rows[0]["Add3"].ToString().Trim();
                if (!string.IsNullOrEmpty(dt.Rows[0]["CityId"].ToString().Trim()))
                    objEmp.CityId = Convert.ToInt64(dt.Rows[0]["CityId"].ToString().Trim());
                if (!string.IsNullOrEmpty(dt.Rows[0]["PostalCode"].ToString().Trim()))
                    objEmp.PostalCode = dt.Rows[0]["PostalCode"].ToString().Trim();
                if (!string.IsNullOrEmpty(dt.Rows[0]["DOJ"].ToString().Trim()))
                    objEmp.DOJ = Convert.ToDateTime(dt.Rows[0]["DOJ"].ToString().Trim());
                if (!string.IsNullOrEmpty(dt.Rows[0]["Role"].ToString().Trim()))
                    objEmp.RoleId = Convert.ToInt32(dt.Rows[0]["Role"].ToString().Trim());
                if (!string.IsNullOrEmpty(dt.Rows[0]["DesignationId"].ToString().Trim()))
                    objEmp.DesigId = Convert.ToInt64(dt.Rows[0]["DesignationId"].ToString().Trim());
                objEmp.Designation = string.Empty;
                objEmp.PhotoPath = dt.Rows[0]["PhotoFilePath"].ToString().Trim();
                objEmp.CreatedById = BasePage.UserSession.VirtualRoleId;
                objEmp.IsNewEmployee = Convert.ToBoolean(dt.Rows[0]["IsNewEmployee"].ToString().Trim());
                objEmp.RepUserId = Convert.ToInt64(dt.Rows[0]["RepUserId"].ToString().Trim());
                objEmp.IsDeleted = true;
                Result = objEmpBm.AddUpdateDeleteEmployee(objEmp);
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
                txtempName.Focus();
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddEmployee.lnkbtnDelete_Click.Error:" + ex.StackTrace);
        }

    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 22 May 2013
    /// Description: Clear Add Employee Panel Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFinalClear_Click(object sender, EventArgs e)
    {
        if (ViewState["EmpId"] != null && !string.IsNullOrEmpty(ViewState["EmpId"].ToString().Trim()) && Convert.ToInt64(ViewState["EmpId"].ToString().Trim()) > 0)
        {
            ClearAll();
            pnlAddEmployee.Visible = false;
            pnlSearchEmployee.Visible = true;
        }
        else if (ViewState["EmpId"] != null && !string.IsNullOrEmpty(ViewState["EmpId"].ToString().Trim()) && Convert.ToInt64(ViewState["EmpId"].ToString().Trim()) == 0)
            ClearAll();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 22 May 2013
    /// Description: Search Button Click Event
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
    /// Created Date: 22 May 2013
    /// Description: Clear Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnClear_Click(object sender, EventArgs e)
    {
        txtempName.Text = string.Empty;
        ddlRoles.SelectedValue = "0";
        txtempName.Focus();
        BindGrid();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 22 May 2013
    /// Description: Selected Index Changed Event Of Search Filter's Role's Drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 22 May 2013
    /// Description: Button Click Event Of Save Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ShowEmployeeName();
            Int64 Result = 0;
            if (ViewState["EmpId"] != null && BasePage.UserSession != null)
            {
                objEmp.EmpId = Convert.ToInt64(ViewState["EmpId"].ToString().Trim());
                if (ViewState["EmpKey"] != null && !string.IsNullOrEmpty(ViewState["EmpKey"].ToString().Trim()))
                    objEmp.EmpKey = ViewState["EmpKey"].ToString().Trim();
                else
                {
                    Guid gi = Guid.NewGuid();
                    objEmp.EmpKey = gi.ToString().Trim();
                }

                if (ViewState["QuoteUserId"] != null && !string.IsNullOrEmpty(ViewState["QuoteUserId"].ToString().Trim()))
                    objEmp.QuoteUserId = Convert.ToInt64(ViewState["QuoteUserId"].ToString().Trim());
                else
                {
                    objEmp.QuoteUserId = 0;
                }
                objEmp.Title = Convert.ToInt32(ddlTitle.SelectedValue.Trim());
                //if (ddlFName.SelectedValue.Trim().ToLower() != Resources.PFSalesResource.ddlSelect.Trim().ToLower())
                if (!string.IsNullOrEmpty(txtFName.Text.Trim()))
                {
                    string str = txtFName.Text.Trim().Substring(0, 1);
                    str = str.ToUpper();
                    objEmp.FName = (str.Trim() + txtFName.Text.Trim().Remove(0, 1)).Trim();// ddlFName.SelectedValue.Trim().Replace("  ", " ");
                }
                else
                    objEmp.FName = string.Empty;
                //if (ddlMName.SelectedValue.Trim().ToLower() != Resources.PFSalesResource.ddlSelect.Trim().ToLower())
                if (!string.IsNullOrEmpty(txtMName.Text.Trim()))
                {
                    string str = txtMName.Text.Trim().Substring(0, 1);
                    str = str.ToUpper();
                    objEmp.MName = (str.Trim() + txtMName.Text.Trim().Remove(0, 1)).Trim();// ddlFName.SelectedValue.Trim().Replace("  ", " ");
                }
                else
                    objEmp.MName = string.Empty;
                //if (ddlLName.SelectedValue.Trim().ToLower() != Resources.PFSalesResource.ddlSelect.Trim().ToLower())
                if (!string.IsNullOrEmpty(txtLName.Text.Trim()))
                {
                    string str = txtLName.Text.Trim().Substring(0, 1);
                    str = str.ToUpper();
                    objEmp.LName = (str.Trim() + txtLName.Text.Trim().Remove(0, 1)).Trim();// ddlFName.SelectedValue.Trim().Replace("  ", " ");
                }
                else
                    objEmp.LName = string.Empty;
                if (!string.IsNullOrEmpty(ddlGender.SelectedValue.Trim()))
                    objEmp.Gender = Convert.ToInt16(ddlGender.SelectedValue.Trim());
                if (!string.IsNullOrEmpty(txtDOB.Text.Trim()))
                    objEmp.DOB = Convert.ToDateTime(txtDOB.Text.Trim());
                else
                    objEmp.DOB = DateTime.MinValue;
                objEmp.Designation = txtDesig.Text.Trim();
                objEmp.Phone = txtPhNo.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
                if (!string.IsNullOrEmpty(hdfPhoneFormatId.Value.Trim()))
                    objEmp.formatedPhoNo = Convert.ToInt64(hdfPhoneFormatId.Value.Trim());
                else
                    objEmp.formatedPhoNo = Convert.ToInt64(ddlPhFormat.SelectedValue.Trim());
                objEmp.PhoneExt = txtExt.Text.Trim();
                objEmp.Mobile = txtMobile.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
                if (!string.IsNullOrEmpty(hdfMobileFormatId.Value.Trim()))
                    objEmp.formatedMobNo = Convert.ToInt64(hdfMobileFormatId.Value.Trim());
                else
                    objEmp.formatedMobNo = Convert.ToInt64(ddlPhFormat.SelectedValue.Trim());
                objEmp.Fax = txtFax.Text.Trim().Replace(" ", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("_", "");
                if (!string.IsNullOrEmpty(hdfFaxFormatId.Value.Trim()))
                    objEmp.formatedFax = Convert.ToInt64(hdfFaxFormatId.Value.Trim());
                else
                    objEmp.formatedFax = Convert.ToInt64(ddlPhFormat.SelectedValue.Trim());
                objEmp.Email = txtEmail1.Text.Trim();
                objEmp.Email1 = txtEmail2.Text.Trim();
                objEmp.Add1 = txtAddLine1.Text.Trim();
                objEmp.Add2 = txtAddLine2.Text.Trim();
                objEmp.Add3 = txtAddLine3.Text.Trim();
                if (!string.IsNullOrEmpty(ddlCity.SelectedValue.Trim()))
                    objEmp.CityId = Convert.ToInt64(ddlCity.SelectedValue.Trim());
                objEmp.PostalCode = ddlPostalCode.SelectedValue.Trim();
                if (!string.IsNullOrEmpty(txtDOJ.Text.Trim()))
                    objEmp.DOJ = Convert.ToDateTime(txtDOJ.Text.Trim());
                else
                    objEmp.DOJ = DateTime.MinValue;
                objEmp.RoleId = Convert.ToInt32(ddlAddRole.SelectedValue.Trim());
                if (!string.IsNullOrEmpty(ddlDesig.SelectedValue.Trim()))
                    objEmp.DesigId = Convert.ToInt64(ddlDesig.SelectedValue.Trim());
                objEmp.PhotoPath = hdnEmployeePhoto.Value.Trim();
                if (!string.IsNullOrEmpty(hdfUserVRId.Value.Trim()))
                    objEmp.UserVID = Convert.ToInt64(hdfUserVRId.Value.Trim());
                else
                    objEmp.UserVID = 0;
                if (!string.IsNullOrEmpty(hdfUserId.Value.Trim()))
                    objEmp.UseId = Convert.ToInt64(hdfUserId.Value.Trim());
                else
                    objEmp.UseId = 0;
                if (chkRepExisting.Checked)
                {
                    objEmp.IsNewEmployee = false;
                    if (!string.IsNullOrEmpty(ddlVirtualPersons.SelectedValue.Trim()) && ddlVirtualPersons.SelectedValue.Trim() != "0")
                    {
                        objEmp.VirtualRoleId = Convert.ToInt64(ddlVirtualPersons.SelectedValue.Trim());
                        DataTable dtVUser = objMstBM.GetUserIdFromVRId(Convert.ToInt64(ddlVirtualPersons.SelectedValue.Trim()));
                        if (dtVUser != null && dtVUser.Rows.Count > 0)
                            objEmp.RepUserId = Convert.ToInt64(dtVUser.Rows[0]["UserId"].ToString().Trim());
                    }
                }
                else
                    objEmp.IsNewEmployee = true;
                if (chkIsActive.Checked)
                    objEmp.IsActive = true;
                else
                    objEmp.IsActive = false;
                objEmp.CreatedById = BasePage.UserSession.VirtualRoleId;
                objEmp.IsDeleted = false;
                if (ViewState["Password"] != null && !string.IsNullOrEmpty(ViewState["Password"].ToString().Trim()))
                    objEmp.Password = ViewState["Password"].ToString().Trim();
                else
                {
                    string password = Cls_Common.GeneratePassword(true);
                    string strEncPassword = Cls_Encryption.EncryptTripleDES(password);
                    objEmp.Password = strEncPassword.Trim();
                }

                if (chkIsInFleetLead.Checked)
                    objEmp.IsInFleetTeam = true;
                else
                    objEmp.IsInFleetTeam = false;
                Result = objEmpBm.AddUpdateDeleteEmployee(objEmp);
                if (ViewState["EmpId"].ToString().Trim() == "0")
                {
                    if (Result > 0)
                    {
                        lblSerSucMsg.Text = Resources.PFSalesResource.EmpAddedSucc.Trim();
                        lblSerErrMsg.Text = string.Empty;
                        dvadderror.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvaserSuccess.Visible = true;
                        BindGrid();
                        SendMail(txtEmail1.Text.Trim(), txtEmail1.Text.Trim(), objEmp.Password, txtFName.Text.Trim());//Cls_Encryption.DecryptTripleDES(strEncPassword.Trim()).Trim()
                        pnlAddEmployee.Visible = false;
                        pnlSearchEmployee.Visible = true;
                        txtempName.Focus();
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
                        lblAddErrMsg.Text = Resources.PFSalesResource.EmpNotAdded.Trim();
                        lblAddSucMsg.Text = string.Empty;
                        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvadderror.Visible = true;
                        ddlTitle.Focus();
                    }

                }
                else
                {
                    if (Result > 0)
                    {
                        lblSerSucMsg.Text = Resources.PFSalesResource.EmpDeatilsUpdated.Trim();
                        lblSerErrMsg.Text = string.Empty;
                        dvadderror.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvaserSuccess.Visible = true;
                        BindGrid();
                        pnlAddEmployee.Visible = false;
                        pnlSearchEmployee.Visible = true;
                        txtempName.Focus();
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
                        lblAddErrMsg.Text = Resources.PFSalesResource.EmpDeatilsNotUpdated.Trim();
                        lblAddSucMsg.Text = string.Empty;
                        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvadderror.Visible = true;
                        ddlTitle.Focus();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddEmployee.lnkbtnSave_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Row Data Bound Event Of Employee's GridView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvEmp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdfUserId = (HiddenField)e.Row.FindControl("hdfUserId");
                LinkButton lnkBtnDelete = (LinkButton)e.Row.FindControl("lnkbtnDelete");
                if (hdfUserId != null && lnkBtnDelete != null)
                    if (!string.IsNullOrEmpty(hdfUserId.Value.Trim()))
                        if (hdfUserId.Value.Trim() == "1")
                            lnkBtnDelete.Visible = false;
                string lblName = ((Label)e.Row.FindControl("lblEmpName")).Text.Trim();
                lnkBtnDelete.Attributes.Add("onclick", "javascript:return confirm('" + Resources.PFSalesResource.EmpDeleteConfirm.Trim() + " " + lblName + "?')");
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddEmployee.gvEmp_RowDataBound.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 May 2013
    /// Description: Add Role's Selected Index Changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlAddRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindVirtualPersons();
        // ddlDesig.Focus();
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
        if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
        {
            ftePhPopUpPhNo.Enabled = false;
            msePhPopUp.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
            msePhPopUp.MaskType = AjaxControlToolkit.MaskedEditType.None;
            msePhPopUp.Enabled = true;
            txtPhPopUpPhoNo.Text = txtPhPopUpPhoNo.Text.Trim();
        }
        else
        {
            ftePhPopUpPhNo.Enabled = true;
            msePhPopUp.MaskType = AjaxControlToolkit.MaskedEditType.None;
            msePhPopUp.Mask = "999999999999999999999999999999";
            msePhPopUp.Enabled = false;
            txtPhPopUpPhoNo.Text = txtPhPopUpPhoNo.Text.Trim();
        }
        pnlphonePopUp.Visible = true;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 May 2013
    /// Description: Add New Designation Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddDesig_Click(object sender, EventArgs e)
    {
        lnkbtnMinusDesig.Visible = txtDesig.Visible = true;
        lnkbtnAddDesig.Visible = ddlDesig.Visible = false;
        ddlDesig.SelectedValue = "0";
        // txtDesig.Focus();
        rfvNewDesig.Enabled = true;
        //rfvDesig.Enabled = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 May 2013
    /// Description: Cancel Add New Designation Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnMinusDesig_Click(object sender, EventArgs e)
    {
        lnkbtnMinusDesig.Visible = txtDesig.Visible = false;
        lnkbtnAddDesig.Visible = ddlDesig.Visible = true;
        //ddlDesig.Focus();
        rfvNewDesig.Enabled = false;
        //rfvDesig.Enabled = true;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 May 2013
    /// Description: Remove Uploaded Image Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnRemove_click(object sender, EventArgs e)
    {
        try
        {
            if (!String.IsNullOrEmpty(hdnEmployeePhoto.Value))
            {
                if (File.Exists(Server.MapPath(ConfigurationManager.AppSettings["Photos"]) + hdnEmployeePhoto.Value))
                {
                    File.Delete(Server.MapPath(ConfigurationManager.AppSettings["Photos"]) + hdnEmployeePhoto.Value);
                }
            }
            hdnEmployeePhoto.Value = string.Empty;
            imgEmpPhoto.ImageUrl = "~/Images/NoPhoto.png";
            lnkbtnRemove.Visible = false;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddEmployee.lnkbtnRemove_click.Error:" + ex.StackTrace);
        }
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
                Int32 intAllCount = Convert.ToInt32(ViewState["TotalCount"]);
                gvEmp.PageSize = intAllCount;
            }
            else
            {
                gvEmp.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue.Trim());
            }
            BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddEmployee.ddlPageSize_SelectedIndexChanged.Error:" + ex.StackTrace);
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
            //ddlCity.Focus();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.ddlPostalCode_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 May 2013
    /// Description: Bind Grid View Data
    /// </summary>
    private void BindGrid()
    {
        try
        {
            objEmp.FName = txtempName.Text.Trim();
            objEmp.RoleId = Convert.ToInt32(ddlRoles.SelectedValue.Trim());
            DataTable Dt = objEmpBm.GetAllEmployee(objEmp);
            if (Dt != null & Dt.Rows.Count > 0)
            {
                DataView dV = Dt.DefaultView;
                dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
                gvEmp.DataSource = Dt;
                ViewState["TotalCount"] = Dt.Rows.Count;
                gvEmp.DataBind();
            }
            else
            {
                gvEmp.DataSource = null;
                gvEmp.DataBind();
                ViewState["TotalCount"] = "0";
            }

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddEmployee.BindGrid.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Crearted By:Pravin Gholap
    /// Created Date:18 May 2013
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
            Logger.Error(ex.Message + "AddEmployee.DefineSortDirection.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 May 2013
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
            Logger.Error(ex.Message + "AddEmployee.GetProfessions.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 May 2013
    /// Description: Bind Professions To Drop Down List
    /// </summary>
    private void BindRoles()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllRoles(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlRoles, "Role", "RoleId", Dt);
            Cls_BinderHelper.BindDropdownList(ddlAddRole, "Role", "RoleId", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddEmployee.GetRoles.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 May 2013
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
                ddlPhPopUpCountry.SelectedValue = ddlCountry.SelectedValue = "1";
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
            Logger.Error(ex.Message + "AddEmployee.BindAllCountry.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 May 2013
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
            Logger.Error(ex.Message + "AddEmployee.BindAllStates.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 7 June 2013
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
            Logger.Error(ex.Message + "Prospects.BindAllPostalCode.Error:" + ex.StackTrace);
        }
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
            DataTable Dt = objMstBM.GetAllCitiesFromPCode(ddlPostalCode.SelectedValue.Trim());
            Cls_BinderHelper.BindDropdownList(ddlCity, "CityName", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindAllCities.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 May 2013
    /// Description: Bind All Designations
    /// </summary>
    private void BindDesignations()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllDesignations(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlDesig, "Designation", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddEmployee.BindDesignations.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 May 2013
    /// Description: Save Employees Photo
    /// </summary>
    private void SaveEmpPhoto()
    {
        try
        {
            if (fupEmpPhoto.HasFile)
            {
                if (!String.IsNullOrEmpty(hdnEmployeePhoto.Value))
                {
                    if (File.Exists(Server.MapPath(ConfigurationManager.AppSettings["Photos"]) + hdnEmployeePhoto.Value))
                    {
                        File.Delete(Server.MapPath(ConfigurationManager.AppSettings["Photos"]) + hdnEmployeePhoto.Value);
                    }
                }
                int intLastIndexOfDot = 0;
                string strFileExtension = "";

                /// check whether the browse file size is exeeds the allowed limit.
                double intBroseFileSizeInKB = fupEmpPhoto.PostedFile.ContentLength / 0x400;
                double dAllowFileSizeLimitInKB = Convert.ToDouble(ConfigurationManager.AppSettings["FileSize"]) * 1024;
                if (intBroseFileSizeInKB >= dAllowFileSizeLimitInKB)
                {
                    //Response.Write("<Script>alert(\"Cannot Upload File. Max size allowed is 100 Kb.\");</Script>");
                    lblAddErrMsg.Text = Resources.PFSalesResource.MaxSizeValidation.Trim();
                    return;
                }
                //Allowed File Extentions
                intLastIndexOfDot = fupEmpPhoto.FileName.LastIndexOf(".");
                strFileExtension = fupEmpPhoto.FileName.Substring(intLastIndexOfDot + 1, fupEmpPhoto.FileName.Length - intLastIndexOfDot - 1);
                if (strFileExtension != "")
                {
                    bool IsTrue = false;
                    string ext;
                    char[] sep = { ',' };
                    String[] strExt = Convert.ToString(ConfigurationManager.AppSettings["AllowedImgFileTypes"]).Split(sep);
                    string fileName = fupEmpPhoto.FileName;
                    ext = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();
                    for (int i = 0; i < strExt.Length; i++)
                    {
                        if (ext == "")
                        {
                            IsTrue = false;
                        }
                        if (ext.ToLower() == strExt[i].ToLower())
                        {
                            IsTrue = true;
                            break;
                        }
                        else
                        {
                            IsTrue = false;
                        }
                    }
                    if (!IsTrue)
                    {
                        lblAddErrMsg.Text = Resources.PFSalesResource.InvalidFileExtention.Trim();
                        return;
                    }
                }
                string strFileName = System.IO.Path.GetFileNameWithoutExtension(fupEmpPhoto.PostedFile.FileName) + Guid.NewGuid() + System.IO.Path.GetExtension(fupEmpPhoto.PostedFile.FileName);
                fupEmpPhoto.PostedFile.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["Photos"]) + strFileName);
                //After u[dating show photo in image.
                imgEmpPhoto.ImageUrl = ConfigurationManager.AppSettings["Photos"] + strFileName;
                hdnEmployeePhoto.Value = ConfigurationManager.AppSettings["Photos"] + strFileName;
                lnkbtnRemove.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddEmployee.BindDesignations.SavePhoto.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 21 May 2013
    /// Description: Show Employee Name In Pop Up;
    /// </summary>
    private void ShowEmployeeName()
    {
        try
        {
            ArrayList arr = new ArrayList();
            arr.Add(Resources.PFSalesResource.ddlSelect.Trim());
            string[] names = txtAddName.Text.Trim().Replace("  ", " ").Split(' ');
            for (int i = 0; i < names.Length; i++)
            {
                //if (!string.IsNullOrEmpty(names[i].Trim()) && !arr.Contains(names[i].Trim()))
                arr.Add(names[i].Trim());
            }
            if (names.Length == 1)
            {
                ddlFName.DataSource = ddlLName.DataSource = ddlMName.DataSource = arr;
                ddlFName.DataBind();
                ddlMName.DataBind();
            }
            //if (names.Length == 3)
            //{
            //    if (!arr.Contains((names[0].Trim() + " " + names[1].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[0].Trim() + " " + names[1].Trim()))
            //        arr.Add(names[0].Trim() + " " + names[1].Trim());
            //    if (!arr.Contains((names[1].Trim() + " " + names[0].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[1].Trim() + " " + names[0].Trim()))
            //        arr.Add(names[1].Trim() + " " + names[0].Trim());
            //    if (!arr.Contains((names[0].Trim() + " " + names[2].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[0].Trim() + " " + names[2].Trim()))
            //        arr.Add(names[0].Trim() + " " + names[2].Trim());
            //    if (!arr.Contains((names[2].Trim() + " " + names[0].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[2].Trim() + " " + names[0].Trim()))
            //        arr.Add(names[2].Trim() + " " + names[0].Trim());
            //    if (!arr.Contains((names[1].Trim() + " " + names[2].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[1].Trim() + " " + names[2].Trim()))
            //        arr.Add(names[1].Trim() + " " + names[2].Trim());
            //    if (!arr.Contains((names[2].Trim() + " " + names[1].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[2].Trim() + " " + names[1].Trim()))
            //        arr.Add(names[2].Trim() + " " + names[1].Trim());
            //    if (!arr.Contains((names[0].Trim() + " " + names[1].Trim() + " " + names[2].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[0].Trim() + " " + names[1].Trim() + " " + names[2].Trim()))
            //        arr.Add(names[0].Trim() + " " + names[1].Trim() + " " + names[2].Trim());
            //    if (!arr.Contains((names[0].Trim() + " " + names[2].Trim() + " " + names[1].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[0].Trim() + " " + names[2].Trim() + " " + names[1].Trim()))
            //        arr.Add(names[0].Trim() + " " + names[2].Trim() + " " + names[1].Trim());
            //    if (!arr.Contains((names[1].Trim() + " " + names[0].Trim() + " " + names[2].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[1].Trim() + " " + names[0].Trim() + " " + names[2].Trim()))
            //        arr.Add(names[1].Trim() + " " + names[0].Trim() + " " + names[2].Trim());
            //    if (!arr.Contains((names[1].Trim() + " " + names[2].Trim() + " " + names[0].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[1].Trim() + " " + names[2].Trim() + " " + names[0].Trim()))
            //        arr.Add(names[1].Trim() + " " + names[2].Trim() + " " + names[0].Trim());
            //    if (!arr.Contains((names[2].Trim() + " " + names[1].Trim() + " " + names[0].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[2].Trim() + " " + names[1].Trim() + " " + names[0].Trim()))
            //        arr.Add(names[2].Trim() + " " + names[1].Trim() + " " + names[0].Trim());
            //    if (!arr.Contains((names[2].Trim() + " " + names[0].Trim() + " " + names[1].Trim()).Trim().Replace("  ", " ")) && !string.IsNullOrEmpty(names[2].Trim() + " " + names[0].Trim() + " " + names[1].Trim()))
            //        arr.Add(names[2].Trim() + " " + names[0].Trim() + " " + names[1].Trim());
            //}
            //else if (names.Length == 2)
            //{
            //    if (!arr.Contains((names[0].Trim() + " " + names[1].Trim()).Trim()) && !string.IsNullOrEmpty(names[0].Trim() + " " + names[1].Trim().Replace("  ", " ")))
            //        arr.Add(names[0].Trim() + " " + names[1].Trim());
            //    if (!arr.Contains((names[1].Trim() + " " + names[0].Trim()).Trim()) && !string.IsNullOrEmpty(names[1].Trim() + " " + names[0].Trim().Replace("  ", " ")))
            //        arr.Add(names[1].Trim() + " " + names[0].Trim());
            //}
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
            Logger.Error(ex.Message + "AddEmployee.BindDesignations.SavePhoto.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 21 May 2013
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
            Logger.Error(ex.Message + "AddEmployee.BindDesignations.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 21 May 2013
    /// Description: Bind All Virtual Persons
    /// </summary>
    private void BindVirtualPersons()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllVirtualPersons(Convert.ToInt64(ddlAddRole.SelectedValue.Trim()), string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlVirtualPersons, "Name", "VirtualRoleId", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddEmployee.BindVirtualPersons.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 22 May 2013
    /// Description: Clear Add Employee Panel
    /// </summary>
    private void ClearAll()
    {
        ddlVirtualPersons.SelectedValue = ddlTitle.SelectedValue = ddlGender.SelectedValue = ddlAddRole.SelectedValue = ddlDesig.SelectedValue = "0";
        ddlCountry.SelectedValue = "1";
        BindAllStates();
        ddlState.SelectedValue = "0";
        BindAllPostalCode();
        ddlPostalCode.SelectedValue = "0";
        BindAllCities();
        ddlCity.SelectedValue = "0";
        txtExt.Text = txtFName.Text = txtMName.Text = txtLName.Text = txtAddName.Text = txtDOB.Text = txtPhNo.Text = txtMobile.Text = txtAddLine1.Text = txtAddLine2.Text = txtAddLine3.Text = txtFax.Text = txtEmail1.Text = txtEmail2.Text = txtDOJ.Text = string.Empty;
        chkIsActive.Checked = true;
        chkRepExisting.Checked = false;
        chkRepExisting_CheckChanged(null, null);
        imgEmpPhoto.ImageUrl = "~/Images/NoPhoto.png";
        hdfPhPopType.Value = "";
        hdfFaxFormatId.Value = hdfPhoneFormatId.Value = hdfMobileFormatId.Value = "";
        BindFormats();
        SetDefaultFormat();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 22 May 2013
    /// Description: Clear All Message's Tex
    /// </summary>
    private void ClearMsg()
    {
        lblAddErrMsg.Text = lblAddSucMsg.Text = lblSerErrMsg.Text = lblSerSucMsg.Text = string.Empty;
        dvadderror.Visible = dvaddSucc.Visible = dvaserSuccess.Visible = dvsererror.Visible = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 28 May 2013
    /// Description: Send Email After Successfull Registration
    /// </summary>
    /// <param name="emilToId"></param>
    /// <param name="UserName"></param>
    /// <param name="Password"></param>
    /// <param name="Name"></param>
    /// <returns></returns>
    private Boolean SendMail(string emilToId, string UserName, string Password, string Name)
    {
        string FileContent = string.Empty;
        try
        {

            Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
            //objEmailHelper.EmailFromID = ConfigurationManager.AppSettings["EmailFromID"].ToString();
            objEmailHelper.EmailSubject = "User Registration Details";
            // objEmailHelper.SMTPServerIP = ConfigurationManager.AppSettings["SMTPServerIP"].ToString();
            // objEmailHelper.SMTPUserID = ConfigurationManager.AppSettings["SMTPUserID"].ToString();
            //objEmailHelper.SMTPUserPwd = ConfigurationManager.AppSettings["SMTPUserPwd"].ToString();
            objEmailHelper.EmailToID = emilToId;
            //objEmailHelper.EmailCcID = "pravin.gholap@mechsoftgroup.com";
             FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + Name.Trim() + "<br /><br />Welcome to PF Sales. Your Login Details are as bellow <br />Login Name :" + UserName.Trim() + "<br />Password : " + Password.Trim() + "<br /><br />Log In Link :<a href='" + ConfigurationManager.AppSettings["LoginUrl"].ToString() + "'>Click Here To Login<br /><br /> Regards<br /> PF Sales</span></a>";
            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "EMail sent successfully", "User Registration Details","Add Employee");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "User Registration Details", "Add Employee");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddEmployee.SendMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "User Registration Details", "Add Employee");
            return false;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 30 May 2013
    /// Description: Set Default Format For Phone, Mobile & Fax Number
    /// </summary>
    private void SetDefaultFormat()
    {
        if (ddlPhFormat.SelectedItem.Text.Trim().ToUpper() != "FREE FORM")
        {
            ftePhNo.Enabled = fteMobile.Enabled = fteFax.Enabled = false;
            msePhPopUp.Mask = mseFax.Mask = mseMobile.Mask = msePhNo.Mask = ddlPhFormat.SelectedItem.Text.Replace("%", "9");
            msePhPopUp.MaskType = mseFax.MaskType = mseMobile.MaskType = msePhNo.MaskType = AjaxControlToolkit.MaskedEditType.Date;
            msePhPopUp.Enabled = mseFax.Enabled = mseMobile.Enabled = msePhNo.Enabled = true;
        }
        else
        {
            msePhPopUp.MaskType = mseFax.MaskType = mseMobile.MaskType = msePhNo.MaskType = AjaxControlToolkit.MaskedEditType.None;
            msePhPopUp.Mask = mseFax.Mask = mseMobile.Mask = msePhNo.Mask = "999999999999999999999999999999";
            msePhPopUp.Enabled = mseFax.Enabled = mseMobile.Enabled = msePhNo.Enabled = false;
            ftePhNo.Enabled = fteMobile.Enabled = fteFax.Enabled = true;
        }
    }
    #endregion
}
