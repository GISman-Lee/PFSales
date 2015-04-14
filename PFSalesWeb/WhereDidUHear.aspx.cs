using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mechsoft.PFSales.BusinessManager;
using Mechsoft.PFSales.BusinessEntity;
using log4net;
using Mechsoft.GeneralUtilities;
using System.Data;

public partial class WhereDidUHear : BasePage
{
    #region Global Variables
    MasterBM objMstBM = new MasterBM();
    clsMaster objMaster = new clsMaster();
    ILog Logger = LogManager.GetLogger(typeof(WhereDidUHear));
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = "ValueforAnswer";
            ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;
            BindGrid();
            txtWhereUHear.Focus();
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
    /// Description: Page Index Changing Event Of Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWhereUHear_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvWhereUHear.PageIndex = e.NewPageIndex;
            BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "WhereDidUHear.gvWhereUHear_PageIndexChanging Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
    /// Description: Sorting Event For Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWhereUHear_Soring(object sender, GridViewSortEventArgs e)
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
            Logger.Error(ex.Message + "WhereDidUHear.gvEmp_Soring Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
    /// Description: Edit Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            ClearMsg();
            Int32 WUHId = Convert.ToInt32(((LinkButton)sender).CommandArgument.Trim());
            ViewState["WUHId"] = WUHId;
            if (WUHId > 0)
            {
                DataTable dt = objMstBM.GetWUHFromId(WUHId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtvalueForAnswer.Text = dt.Rows[0]["ValueforAnswer"].ToString().Trim();
                    if (dt.Rows[0]["IsFleetLead"].ToString().Trim().ToUpper() == "YES")
                        chkIsFleetLead.Checked = true;
                    else
                        chkIsFleetLead.Checked = false;
                    txtFromDate.Text = Convert.ToDateTime(dt.Rows[0]["ActFrDate"].ToString().Trim()).ToString("dd/MM/yyyy").Substring(0, 10);
                    txtToDate.Text = Convert.ToDateTime(dt.Rows[0]["ActToDate"].ToString().Trim()).ToString("dd/MM/yyyy").Substring(0, 10);
                    txtvalueForAnswer.Focus();
                    lnkbtnSave.Text = Resources.PFSalesResource.update.Trim();
                    lnkbtnSave.ToolTip = Resources.PFSalesResource.UpdateWhereUHear.Trim();
                    lnkbtnFinalClear.Text = Resources.PFSalesResource.Cancel.Trim();
                    lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.BackToSearch.Trim();
                    lblAddWhereUHearHead.Text = Resources.PFSalesResource.UpdateWhereUHear.Trim();
                    pnlAddWhereUHear.Visible = true;
                    pnlSearchWhereUHear.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "WhereDidUHear.lnkbtnEdit_Click Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
    /// Description: Add New Prospect Source Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddWhereUHear_Click(object sender, EventArgs e)
    {
        try
        {
            pnlAddWhereUHear.Visible = true;
            pnlSearchWhereUHear.Visible = false;
            ViewState["WUHId"] = 0;
            lnkbtnSave.Text = Resources.PFSalesResource.Save.Trim();
            lnkbtnSave.ToolTip = Resources.PFSalesResource.SaveWhereUHear.Trim();
            lnkbtnFinalClear.Text = Resources.PFSalesResource.Clear.Trim();
            lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.Clear.Trim();
            lblAddWhereUHearHead.Text = Resources.PFSalesResource.AddValueforAnswer.Trim();
            ClearMsg();
            ClearAll();
            txtvalueForAnswer.Focus();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "WhereDidUHear.lnkbtnAddSource_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
    /// Description: Back To Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnBackToSearch_Click(object sender, EventArgs e)
    {
        ViewState["WUHId"] = 0;
        BindGrid();
        pnlSearchWhereUHear.Visible = true;
        pnlAddWhereUHear.Visible = false;
        ClearMsg();
        txtWhereUHear.Focus();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
    /// Description: Delete Prospect Source Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Int32 WUHId = Int32.Parse(((LinkButton)sender).CommandArgument.Trim());
            Int64 Result = 0;
            objMaster.WUHId = WUHId;
            objMaster.CreatedById = BasePage.UserSession.VirtualRoleId;
            objMaster.IsDeleted = true;
            Result = objMstBM.DeleteWUHDetails(objMaster);
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
            txtvalueForAnswer.Focus();
            BindGrid();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "WhereDidUHear.lnkbtnDelete_Click.Error:" + ex.StackTrace);
        }

    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
    /// Description: Clear Add Prospect Source Panel Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFinalClear_Click(object sender, EventArgs e)
    {
        if (ViewState["WUHId"] != null && !string.IsNullOrEmpty(ViewState["WUHId"].ToString().Trim()) && Convert.ToInt64(ViewState["WUHId"].ToString().Trim()) > 0)
        {
            ClearAll();
            pnlAddWhereUHear.Visible = false;
            pnlSearchWhereUHear.Visible = true;
        }
        else if (ViewState["WUHId"] != null && !string.IsNullOrEmpty(ViewState["WUHId"].ToString().Trim()) && Convert.ToInt64(ViewState["WUHId"].ToString().Trim()) == 0)
            ClearAll();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
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
    /// Created Date: 23 July 2013
    /// Description: Clear Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnClear_Click(object sender, EventArgs e)
    {
        txtWhereUHear.Text = string.Empty;
        txtWhereUHear.Focus();
        BindGrid();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
    /// Description: Button Click Event Of Save Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Int64 Result = 0;
            if (ViewState["WUHId"] != null && BasePage.UserSession != null)
            {
                objMaster.WUHId = Convert.ToInt32(ViewState["WUHId"].ToString().Trim());
                objMaster.ValueforAnswer = txtvalueForAnswer.Text.Trim();
                objMaster.FromDate = Convert.ToDateTime(txtFromDate.Text.Trim());
                objMaster.ToDate = Convert.ToDateTime(txtToDate.Text.Trim());
                if (chkIsFleetLead.Checked)
                    objMaster.IsFleetLead = true;
                else
                    objMaster.IsFleetLead = false;
                objMaster.CreatedById = BasePage.UserSession.VirtualRoleId;
                objMaster.IsDeleted = false;
                if (ViewState["WUHId"].ToString().Trim() == "0")
                {
                    Result = objMstBM.AddWUHDetails(objMaster);

                    if (Result > 0)
                    {
                        lblSerSucMsg.Text = Resources.PFSalesResource.WUHAddedSucc.Trim();
                        lblSerErrMsg.Text = string.Empty;
                        dvadderror.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvaserSuccess.Visible = true;
                        BindGrid();
                        pnlAddWhereUHear.Visible = false;
                        pnlSearchWhereUHear.Visible = true;
                        txtWhereUHear.Focus();
                    }
                    else if (Result == -5)
                    {
                        lblAddErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                        lblAddSucMsg.Text = string.Empty;
                        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvadderror.Visible = true;
                        txtvalueForAnswer.Focus();
                    }
                    else
                    {
                        lblAddErrMsg.Text = Resources.PFSalesResource.WUHNotAdded.Trim();
                        lblAddSucMsg.Text = string.Empty;
                        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvadderror.Visible = true;
                        txtvalueForAnswer.Focus();
                    }

                }
                else
                {
                    Result = objMstBM.UpdateWUHDetails(objMaster);
                    if (Result > 0)
                    {
                        lblSerSucMsg.Text = Resources.PFSalesResource.WUHDeatilsUpdated.Trim();
                        lblSerErrMsg.Text = string.Empty;
                        dvadderror.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvaserSuccess.Visible = true;
                        BindGrid();
                        pnlAddWhereUHear.Visible = false;
                        pnlSearchWhereUHear.Visible = true;
                        txtWhereUHear.Focus();
                    }
                    else if (Result == -5)
                    {
                        lblAddErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                        lblAddSucMsg.Text = string.Empty;
                        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvadderror.Visible = true;
                        txtvalueForAnswer.Focus();
                    }
                    else
                    {
                        lblAddErrMsg.Text = Resources.PFSalesResource.WUHDeatilsNotUpdated.Trim();
                        lblAddSucMsg.Text = string.Empty;
                        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvadderror.Visible = true;
                        txtvalueForAnswer.Focus();
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "WhereDidUHear.lnkbtnSave_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
    /// Description: Row Data Bound Event Of Prospect Source's GridView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWhereUHear_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkBtnDelete = (LinkButton)e.Row.FindControl("lnkbtnDelete");
                if (lnkBtnDelete != null)
                {
                    string lblName = ((Label)e.Row.FindControl("lblRefWhereUHear")).Text.Trim();
                    if (lblName != null && !string.IsNullOrEmpty(lblName))
                        lnkBtnDelete.Attributes.Add("onclick", "javascript:return confirm('" + Resources.PFSalesResource.WUHDeleteConfirm.Trim() + " " + lblName + Resources.PFSalesResource.WUHDeleteConfirmRem.Trim() + "?')");
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "WhereDidUHear.gvWhereUHear_RowDataBound.Error:" + ex.StackTrace);
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
                gvWhereUHear.PageSize = intAllCount;
            }
            else
            {
                gvWhereUHear.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue.Trim());
            }
            BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "WhereDidUHear.ddlPageSize_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
    /// Description: Bind Grid View Data
    /// </summary>
    private void BindGrid()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllWUHValues(txtWhereUHear.Text.Trim());
            if (Dt != null & Dt.Rows.Count > 0)
            {
                DataView dV = Dt.DefaultView;
                dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
                gvWhereUHear.DataSource = Dt;
                gvWhereUHear.DataBind();
                ViewState["TotalCount"] = Dt.Rows.Count;
            }
            else
            {
                gvWhereUHear.DataSource = null;
                gvWhereUHear.DataBind();
                ViewState["TotalCount"] = "0";
            }

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "WhereDidUHear.BindGrid.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Crearted By:Pravin Gholap
    /// Created Date:23 July 2013
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
            Logger.Error(ex.Message + "WhereDidUHear.DefineSortDirection.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
    /// Description: Clear Add Employee Panel
    /// </summary>
    private void ClearAll()
    {
        txtvalueForAnswer.Text = txtFromDate.Text = txtToDate.Text = string.Empty;
        chkIsFleetLead.Checked = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 July 2013
    /// Description: Clear All Message's Text
    /// </summary>
    private void ClearMsg()
    {
        lblAddErrMsg.Text = lblAddSucMsg.Text = lblSerErrMsg.Text = lblSerSucMsg.Text = string.Empty;
        dvadderror.Visible = dvaddSucc.Visible = dvaserSuccess.Visible = dvsererror.Visible = false;
    }
    #endregion
}
