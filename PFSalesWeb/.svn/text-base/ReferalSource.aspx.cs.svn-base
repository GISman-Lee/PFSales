using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mechsoft.PFSales.BusinessManager;
using log4net;
using Mechsoft.PFSales.BusinessEntity;
using Mechsoft.GeneralUtilities;
using System.Data;

public partial class ReferalSource : BasePage
{
    #region Global Variables
    MasterBM objMstBM = new MasterBM();
    clsMaster objMaster = new clsMaster();
    ILog Logger = LogManager.GetLogger(typeof(ReferalSource));
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = "RefSource";
            ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;
            BindGrid();
            txtPrSource.Focus();
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Page Index Changing Event Of Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSource_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvSource.PageIndex = e.NewPageIndex;
            BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ReferalSource.gvSource_PageIndexChanging Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Sorting Event For Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSource_Soring(object sender, GridViewSortEventArgs e)
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
    /// Created Date: 10 June 2013
    /// Description: Row Data Bound Event Of Prospect Source's GridView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSource_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkBtnDelete = (LinkButton)e.Row.FindControl("lnkbtnDelete");
                if (lnkBtnDelete != null)
                {
                    string lblName = ((Label)e.Row.FindControl("lblRefSource")).Text.Trim();
                    if (lblName != null && !string.IsNullOrEmpty(lblName))
                        lnkBtnDelete.Attributes.Add("onclick", "javascript:return confirm('" + Resources.PFSalesResource.PrSrcDeleteConfirm.Trim() + " " + lblName + "?')");
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ReferalSource.gvSource_RowDataBound.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Edit Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            ClearMsg();
            Int32 PSId = Convert.ToInt32(((LinkButton)sender).CommandArgument.Trim());
            ViewState["PSId"] = PSId;
            if (PSId > 0)
            {
                DataTable dt = objMstBM.GetProspSrcDetFromId(PSId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtPropSrc.Text = dt.Rows[0]["RefSource"].ToString().Trim();
                    txtDesc.Text = dt.Rows[0]["RDescription"].ToString().Trim();
                    if (dt.Rows[0]["IsFleetTeamLead"].ToString().Trim().ToUpper() == "YES")
                        chkIsFleetLead.Checked = true;
                    else
                        chkIsFleetLead.Checked = false;
                    txtPropSrc.Focus();
                    lnkbtnSave.Text = Resources.PFSalesResource.update.Trim();
                    lnkbtnSave.ToolTip = Resources.PFSalesResource.UpdtePrsSrcDetails.Trim();
                    lnkbtnFinalClear.Text = Resources.PFSalesResource.Cancel.Trim();
                    lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.BackToSearch.Trim();
                    lblAddSourceHead.Text = Resources.PFSalesResource.UpdtePrsSrcDetails.Trim();
                    pnlAddSource.Visible = true;
                    pnlSearchSource.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ReferalSource.lnkbtnEdit_Click Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Add New Prospect Source Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddSource_Click(object sender, EventArgs e)
    {
        try
        {
            pnlAddSource.Visible = true;
            pnlSearchSource.Visible = false;
            ViewState["PSId"] = 0;
            lnkbtnSave.Text = Resources.PFSalesResource.Save.Trim();
            lnkbtnSave.ToolTip = Resources.PFSalesResource.SavePrSource.Trim();
            lnkbtnFinalClear.Text = Resources.PFSalesResource.Clear.Trim();
            lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.Clear.Trim();
            lblAddSource.Text = Resources.PFSalesResource.AddPrSrc.Trim();
            ClearMsg();
            ClearAll();
            txtPropSrc.Focus();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ReferalSource.lnkbtnAddSource_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Back To Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnBackToSearch_Click(object sender, EventArgs e)
    {
        ViewState["PSId"] = 0;
        BindGrid();
        pnlSearchSource.Visible = true;
        pnlAddSource.Visible = false;
        ClearMsg();
        txtPrSource.Focus();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Delete Prospect Source Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Int32 PSId = Int32.Parse(((LinkButton)sender).CommandArgument.Trim());
            Int64 Result = 0;
            objMaster.ProspSourceId = PSId;
            objMaster.CreatedById = BasePage.UserSession.VirtualRoleId;
            objMaster.IsDeleted = true;
            Result = objMstBM.DeleteProspSource(objMaster);
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
            txtPropSrc.Focus();
            BindGrid();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ReferalSource.lnkbtnDelete_Click.Error:" + ex.StackTrace);
        }

    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Clear Add Prospect Source Panel Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFinalClear_Click(object sender, EventArgs e)
    {
        if (ViewState["PSId"] != null && !string.IsNullOrEmpty(ViewState["PSId"].ToString().Trim()) && Convert.ToInt64(ViewState["PSId"].ToString().Trim()) > 0)
        {
            ClearAll();
            pnlAddSource.Visible = false;
            pnlSearchSource.Visible = true;
        }
        else if (ViewState["PSId"] != null && !string.IsNullOrEmpty(ViewState["PSId"].ToString().Trim()) && Convert.ToInt64(ViewState["PSId"].ToString().Trim()) == 0)
            ClearAll();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
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
    /// Created Date: 10 June 2013
    /// Description: Clear Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnClear_Click(object sender, EventArgs e)
    {
        txtPrSource.Text = string.Empty;
        txtPrSource.Focus();
        BindGrid();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Button Click Event Of Save Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Int64 Result = 0;
            if (ViewState["PSId"] != null && BasePage.UserSession != null)
            {
                objMaster.ProspSourceId = Convert.ToInt32(ViewState["PSId"].ToString().Trim());
                objMaster.ProspSource = txtPropSrc.Text.Trim();
                objMaster.Desc = txtDesc.Text.Trim();
                if (chkIsFleetLead.Checked)
                    objMaster.IsFleetLead = true;
                else
                    objMaster.IsFleetLead = false;
                objMaster.CreatedById = BasePage.UserSession.VirtualRoleId;
                objMaster.IsDeleted = false;
                if (ViewState["PSId"].ToString().Trim() == "0")
                {
                    Result = objMstBM.AddProsSource(objMaster);

                    if (Result > 0)
                    {
                        lblSerSucMsg.Text = Resources.PFSalesResource.PrSrcAddedSucc.Trim();
                        lblSerErrMsg.Text = string.Empty;
                        dvadderror.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvaserSuccess.Visible = true;
                        BindGrid();
                        pnlAddSource.Visible = false;
                        pnlSearchSource.Visible = true;
                        txtPrSource.Focus();
                    }
                    else if (Result == -5)
                    {
                        lblAddErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                        lblAddSucMsg.Text = string.Empty;
                        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvadderror.Visible = true;
                        txtPropSrc.Focus();
                    }
                    else
                    {
                        lblAddErrMsg.Text = Resources.PFSalesResource.PrSrcNotAdded.Trim();
                        lblAddSucMsg.Text = string.Empty;
                        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvadderror.Visible = true;
                        txtPropSrc.Focus();
                    }

                }
                else
                {
                    Result = objMstBM.UpdateProsSource(objMaster);
                    if (Result > 0)
                    {
                        lblSerSucMsg.Text = Resources.PFSalesResource.PrSrcDeatilsUpdated.Trim();
                        lblSerErrMsg.Text = string.Empty;
                        dvadderror.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvaserSuccess.Visible = true;
                        BindGrid();
                        pnlAddSource.Visible = false;
                        pnlSearchSource.Visible = true;
                        txtPrSource.Focus();
                    }
                    else if (Result == -5)
                    {
                        lblAddErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                        lblAddSucMsg.Text = string.Empty;
                        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvadderror.Visible = true;
                        txtPropSrc.Focus();
                    }
                    else
                    {
                        lblAddErrMsg.Text = Resources.PFSalesResource.PrSrcDeatilsNotUpdated.Trim();
                        lblAddSucMsg.Text = string.Empty;
                        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvadderror.Visible = true;
                        txtPropSrc.Focus();
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ReferalSource.lnkbtnSave_Click.Error:" + ex.StackTrace);
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
                gvSource.PageSize = intAllCount;
            }
            else
            {
                gvSource.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue.Trim());
            }
            BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ReferalSource.ddlPageSize_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Bind Grid View Data
    /// </summary>
    private void BindGrid()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllProspectSource(txtPrSource.Text.Trim());
            if (Dt != null & Dt.Rows.Count > 0)
            {
                DataView dV = Dt.DefaultView;
                dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
                gvSource.DataSource = Dt;
                ViewState["TotalCount"] = Dt.Rows.Count;
                gvSource.DataBind();
            }
            else
            {
                gvSource.DataSource = null;
                gvSource.DataBind();
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
    /// Created Date:10 June 2013
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
    /// Created Date: 10 June 2013
    /// Description: Clear Add Employee Panel
    /// </summary>
    private void ClearAll()
    {
        txtPropSrc.Text = txtDesc.Text = string.Empty;
        chkIsFleetLead.Checked = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Clear All Message's Text
    /// </summary>
    private void ClearMsg()
    {
        lblAddErrMsg.Text = lblAddSucMsg.Text = lblSerErrMsg.Text = lblSerSucMsg.Text = string.Empty;
        dvadderror.Visible = dvaddSucc.Visible = dvaserSuccess.Visible = dvsererror.Visible = false;
    }
    #endregion
}
