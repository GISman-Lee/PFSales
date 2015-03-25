using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Mechsoft.GeneralUtilities;
using Mechsoft.PFSales.BusinessManager;
using Mechsoft.PFSales.BusinessEntity;
using log4net;

public partial class FinanceMaster : BasePage
{
    #region Global Variables
    MasterBM objMstBM = new MasterBM();
    clsMaster objMaster = new clsMaster();
    ILog Logger = LogManager.GetLogger(typeof(FinanceMaster));
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = "Finance";
            ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;
            BindGrid();
            txtFinance.Focus();
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 June 2013
    /// Description: Page Index Changing Event Of Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFinance_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvFinance.PageIndex = e.NewPageIndex;
            BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "FinanceMaster.gvFinance_PageIndexChanging Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 June 2013
    /// Description: Sorting Event For Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFinance_Soring(object sender, GridViewSortEventArgs e)
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
            Logger.Error(ex.Message + "FinanceMaster.gvEmp_Soring Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 June 2013
    /// Description: Edit Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            ClearMsg();
            Int32 FSId = Convert.ToInt32(((LinkButton)sender).CommandArgument.Trim());
            ViewState["FSId"] = FSId;
            if (FSId > 0)
            {
                DataTable dt = objMstBM.GetFinanceDetFromId(FSId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtAddFinance.Text = dt.Rows[0]["Finance"].ToString().Trim();
                    txtDesc.Text = dt.Rows[0]["FDescription"].ToString().Trim();
                    txtAddFinance.Focus();
                    lnkbtnSave.Text = Resources.PFSalesResource.update.Trim();
                    lnkbtnSave.ToolTip = Resources.PFSalesResource.UpdateFinanceDetails.Trim();
                    lnkbtnFinalClear.Text = Resources.PFSalesResource.Cancel.Trim();
                    lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.BackToSearch.Trim();
                    lblAddFinanceHead.Text = Resources.PFSalesResource.UpdateFinanceDetails.Trim();
                    pnlAddFinance.Visible = true;
                    pnlSearchFinance.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "FinanceMaster.lnkbtnEdit_Click Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 June 2013
    /// Description: Add New Prospect Finance Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddFinance_Click(object sender, EventArgs e)
    {
        try
        {
            pnlAddFinance.Visible = true;
            pnlSearchFinance.Visible = false;
            ViewState["FSId"] = 0;
            lnkbtnSave.Text = Resources.PFSalesResource.Save.Trim();
            lnkbtnSave.ToolTip = Resources.PFSalesResource.SaveFinance.Trim();
            lnkbtnFinalClear.Text = Resources.PFSalesResource.Clear.Trim();
            lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.Clear.Trim();
            lblAddFinance.Text = Resources.PFSalesResource.AddFinance.Trim();
            ClearMsg();
            ClearAll();
            txtAddFinance.Focus();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "FinanceMaster.lnkbtnAddFinance_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 June 2013
    /// Description: Back To Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnBackToSearch_Click(object sender, EventArgs e)
    {
        ViewState["FSId"] = 0;
        BindGrid();
        pnlSearchFinance.Visible = true;
        pnlAddFinance.Visible = false;
        ClearMsg();
        txtFinance.Focus();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 June 2013
    /// Description: Delete Prospect Finance Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Int32 FSId = Int32.Parse(((LinkButton)sender).CommandArgument.Trim());
            Int64 Result = 0;
            objMaster.FinanceId = FSId;
            objMaster.CreatedById = BasePage.UserSession.VirtualRoleId;
            objMaster.IsDeleted = true;
            Result = objMstBM.DeleteFinance(objMaster);
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
            txtFinance.Focus();
            BindGrid();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "FinanceMaster.lnkbtnDelete_Click.Error:" + ex.StackTrace);
        }

    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 June 2013
    /// Description: Clear Add Prospect Finance Panel Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFinalClear_Click(object sender, EventArgs e)
    {
        if (ViewState["FSId"] != null && !string.IsNullOrEmpty(ViewState["FSId"].ToString().Trim()) && Convert.ToInt64(ViewState["FSId"].ToString().Trim()) > 0)
        {
            ClearAll();
            pnlAddFinance.Visible = false;
            pnlSearchFinance.Visible = true;
        }
        else if (ViewState["FSId"] != null && !string.IsNullOrEmpty(ViewState["FSId"].ToString().Trim()) && Convert.ToInt64(ViewState["FSId"].ToString().Trim()) == 0)
            ClearAll();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 June 2013
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
    /// Created Date: 17 June 2013
    /// Description: Clear Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnClear_Click(object sender, EventArgs e)
    {
        txtFinance.Text = string.Empty;
        txtFinance.Focus();
        BindGrid();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 June 2013
    /// Description: Button Click Event Of Save Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Int64 Result = 0;
            if (ViewState["FSId"] != null && BasePage.UserSession != null)
            {
                objMaster.FinanceId = Convert.ToInt32(ViewState["FSId"].ToString().Trim());
                objMaster.Finance = txtAddFinance.Text.Trim();
                objMaster.Desc = txtDesc.Text.Trim();
                objMaster.CreatedById = BasePage.UserSession.VirtualRoleId;
                objMaster.IsDeleted = false;
                if (ViewState["FSId"].ToString().Trim() == "0")
                {
                    Result = objMstBM.AddFinance(objMaster);

                    if (Result > 0)
                    {
                        lblSerSucMsg.Text = Resources.PFSalesResource.FinanceAddedSucc.Trim();
                        lblSerErrMsg.Text = string.Empty;
                        dvadderror.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvaserSuccess.Visible = true;
                        BindGrid();
                        pnlAddFinance.Visible = false;
                        pnlSearchFinance.Visible = true;
                        txtFinance.Focus();
                    }
                    else if (Result == -5)
                    {
                        lblAddErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                        lblAddSucMsg.Text = string.Empty;
                        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvadderror.Visible = true;
                        txtAddFinance.Focus();
                    }
                    else
                    {
                        lblAddErrMsg.Text = Resources.PFSalesResource.FinanceNotAdded.Trim();
                        lblAddSucMsg.Text = string.Empty;
                        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvadderror.Visible = true;
                        txtAddFinance.Focus();
                    }

                }
                else
                {
                    Result = objMstBM.UpdateFinance(objMaster);
                    if (Result > 0)
                    {
                        lblSerSucMsg.Text = Resources.PFSalesResource.FinanceDeatilsUpdated.Trim();
                        lblSerErrMsg.Text = string.Empty;
                        dvadderror.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvaserSuccess.Visible = true;
                        BindGrid();
                        pnlAddFinance.Visible = false;
                        pnlSearchFinance.Visible = true;
                        txtFinance.Focus();
                    }
                    else if (Result == -5)
                    {
                        lblAddErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                        lblAddSucMsg.Text = string.Empty;
                        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvadderror.Visible = true;
                        txtAddFinance.Focus();
                    }
                    else
                    {
                        lblAddErrMsg.Text = Resources.PFSalesResource.FinanceDeatilsNotUpdated.Trim();
                        lblAddSucMsg.Text = string.Empty;
                        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvadderror.Visible = true;
                        txtAddFinance.Focus();
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "FinanceMaster.lnkbtnSave_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 June 2013
    /// Description: Row Data Bound Event Of Prospect Finance's GridView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFinance_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkBtnDelete = (LinkButton)e.Row.FindControl("lnkbtnDelete");
                LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkbtnEdit");
                HiddenField hdfFinanceId = (HiddenField)e.Row.FindControl("hdfFinanceId");
                if (lnkBtnDelete != null)
                {
                    string lblName = ((Label)e.Row.FindControl("lblSerFinance")).Text.Trim();
                    if (lblName != null && !string.IsNullOrEmpty(lblName))
                        lnkBtnDelete.Attributes.Add("onclick", "javascript:return confirm('" + Resources.PFSalesResource.FinanceDeleteConfirm.Trim() + " " + lblName + "?')");
                }
                if (lnkBtnDelete != null && lnkbtnEdit != null && hdfFinanceId != null)
                {
                    if (!string.IsNullOrEmpty(hdfFinanceId.Value.Trim()))
                        if (hdfFinanceId.Value.Trim() == "1" || hdfFinanceId.Value.Trim() == "2")
                            lnkBtnDelete.Visible = lnkbtnEdit.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "FinanceMaster.gvFinance_RowDataBound.Error:" + ex.StackTrace);
        }
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
                gvFinance.PageSize = intAllCount;
            }
            else
            {
                gvFinance.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue.Trim());
            }
            BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "FinanceMaster.ddlPageSize_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 June 2013
    /// Description: Bind Grid View Data
    /// </summary>
    private void BindGrid()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllFinance(txtFinance.Text.Trim());
            if (Dt != null & Dt.Rows.Count > 0)
            {
                DataView dV = Dt.DefaultView;
                dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
                gvFinance.DataSource = Dt;
                gvFinance.DataBind();
                ViewState["TotalCount"] = Dt.Rows.Count;
            }
            else
            {
                gvFinance.DataSource = null;
                gvFinance.DataBind();
                ViewState["TotalCount"] = "0";
            }

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "FinanceMaster.BindGrid.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Crearted By:Pravin Gholap
    /// Created Date:17 June 2013
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
            Logger.Error(ex.Message + "FinanceMaster.DefineSortDirection.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 June 2013
    /// Description: Clear Add Employee Panel
    /// </summary>
    private void ClearAll()
    {
        txtAddFinance.Text = txtDesc.Text = string.Empty;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 June 2013
    /// Description: Clear All Message's Text
    /// </summary>
    private void ClearMsg()
    {
        lblAddErrMsg.Text = lblAddSucMsg.Text = lblSerErrMsg.Text = lblSerSucMsg.Text = string.Empty;
        dvadderror.Visible = dvaddSucc.Visible = dvaserSuccess.Visible = dvsererror.Visible = false;
    }
    #endregion
}
