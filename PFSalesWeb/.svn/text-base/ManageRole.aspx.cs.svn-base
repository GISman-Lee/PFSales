using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Mechsoft.GeneralUtilities;
using log4net;
using Mechsoft.PFSales.BusinessManager;
using Mechsoft.PFSales.BusinessEntity;

public partial class ManageRole : BasePage
{
    #region Global Variables
    MasterBM objManager = new MasterBM();
    Roles objRole = new Roles();
    ILog logger = LogManager.GetLogger(typeof(ManageRole));
    private Int32 _LastRoleId
    {
        get
        {
            Int32 intRoleId = 0;
            Int32.TryParse(ViewState["RoleId"].ToString(), out intRoleId);
            return intRoleId;
        }
        set
        {
            ViewState["RoleId"] = value.ToString();
        }
    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = "Role";
            ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_ASC;
            BindRoleList();
            txtSearchRole.Focus();
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 July 2013
    /// Description: Search Roles
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkSearchRole_Click(object sender, EventArgs e)
    {
        BindRoleList();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 July 2013
    /// Description: Clear Search Role Filter Criteria
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkClearRole_Click(object sender, EventArgs e)
    {
        txtSearchRole.Text = "";
        BindRoleList();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 July 2013
    /// Description: Add Role's Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddRole_Click(object sender, EventArgs e)
    {
        pnlView.Visible = false;
        pnlAdd.Visible = true;
        _LastRoleId = 0;
        txtRoleName.Text = txtDescription.Text = txtCode.Text = "";
        txtCode.Enabled = true;
        lnkSaveRole.ToolTip = lnkSaveRole.Text = Resources.PFSalesResource.Save.Trim();
        lblAddManageRoleHeader.Text = Resources.PFSalesResource.AddRoleDet.Trim();
        lnkCancelRole.ToolTip = lnkCancelRole.Text = Resources.PFSalesResource.Clear.Trim();
        txtRoleName.Focus();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 July 2013
    /// Description: Save Role Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkSaveRole_Click(object sender, EventArgs e)
    {
        try
        {
            objRole.Id = _LastRoleId;
            objRole.RoleName = txtRoleName.Text.Trim();
            objRole.Description = txtDescription.Text.Trim();
            objRole.IsActive = true;
            objRole.IsDeleted = false;
            objRole.CreatedById = 0;
            objRole.Code = txtCode.Text.Trim();
            Int64 Result = objManager.AddUpdateRoles(objRole);
            if (Result > 0)
            {
                txtDescription.Text = txtRoleName.Text = string.Empty;
                pnlView.Visible = true;
                pnlAdd.Visible = false;
                BindRoleList();
                if (_LastRoleId > 0)
                {
                    lblSerSucMsg.Text = Resources.PFSalesResource.RoleUpdate.Trim();
                    dvaserSuccess.Visible = true;
                    dvsererror.Visible = false;
                    lblSerErrMsg.Text = string.Empty;
                    pnlAdd.Visible = false;
                    pnlView.Visible = true;
                }
                else
                {

                    lblAddSucMsg.Text = Resources.PFSalesResource.RoleAdded.Trim();
                    dvaddSucc.Visible = true;
                    dvadderror.Visible = false;
                    lblAddErrMsg.Text = string.Empty;
                    pnlAdd.Visible = true;
                    pnlView.Visible = false;
                }
            }
            else if (Result == -5)
            {
                lblSerErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                dvaserSuccess.Visible = false;
                dvsererror.Visible = true;
                lblSerSucMsg.Text = string.Empty;
                pnlAdd.Visible = true;
                pnlView.Visible = false;
            }
            else
            {
                if (_LastRoleId > 0)
                {
                    lblAddErrMsg.Text = Resources.PFSalesResource.Rolenotadded.Trim();
                    dvaddSucc.Visible = false;
                    dvadderror.Visible = true;
                    lblAddSucMsg.Text = string.Empty;
                    pnlAdd.Visible = true;
                    pnlView.Visible = false;
                }
                else
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.RoleNotUpdated.Trim();
                    dvaserSuccess.Visible = false;
                    dvsererror.Visible = true;
                    lblSerSucMsg.Text = string.Empty;
                    pnlAdd.Visible = false;
                    pnlView.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "ManageRole.lnkSaveRole_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 July 2013
    /// Description:Add Role Panel's Cancel Button Click Event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCancelRole_Click(object sender, EventArgs e)
    {
        if (_LastRoleId > 0)
        {
            txtDescription.Text = txtRoleName.Text = string.Empty;
            pnlAdd.Visible = false;
            pnlView.Visible = true;
            ClearMsg();
        }
        else
        {
            txtDescription.Text = txtRoleName.Text = string.Empty; ClearMsg();
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 July 2013
    /// Description: Go Back to Search Role Panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkGotoSearch_Click(object sender, EventArgs e)
    {
        pnlView.Visible = true;
        pnlAdd.Visible = false;
        ClearMsg();
        txtSearchRole.Focus();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 July 2013
    /// Description: Edit Role Button's Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkEditRole_Click(object sender, EventArgs e)
    {
        try
        {
            ClearMsg();
            pnlView.Visible = false;
            pnlAdd.Visible = true;
            lnkSaveRole.ToolTip = lnkSaveRole.Text = Resources.PFSalesResource.update.Trim();
            lblAddManageRoleHeader.Text = Resources.PFSalesResource.UpdateRoleDet.Trim();
            lnkCancelRole.ToolTip = lnkCancelRole.Text = Resources.PFSalesResource.Cancel.Trim();
            Int32 RoleId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            objRole.RoleId = RoleId;
            objRole.RoleName = string.Empty;
            DataTable dtRoles = objManager.GetRoleList(objRole);
            if (dtRoles.Rows.Count > 0)
            {
                txtRoleName.Text = dtRoles.Rows[0]["Role"].ToString();
                txtDescription.Text = dtRoles.Rows[0]["Description"].ToString();
                txtCode.Text = dtRoles.Rows[0]["Code"].ToString();
                txtCode.Enabled = false;
                _LastRoleId = RoleId;
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "ManageRole.lnkEditRole_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 July 2013
    /// Description: Delete Role Button's Click Event  
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkDeleteRole_Click(object sender, EventArgs e)
    {
        try
        {
            Int32 RoleId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            objRole.RoleId = RoleId;
            objRole.RoleName = "";
            DataTable dtRoles = objManager.GetRoleList(objRole);
            if (dtRoles.Rows.Count > 0)
            {
                objRole.Id = RoleId;
                objRole.RoleName = dtRoles.Rows[0]["Role"].ToString();
                objRole.Description = dtRoles.Rows[0]["Description"].ToString();
                objRole.IsActive = Convert.ToBoolean(dtRoles.Rows[0]["IsActive"]);
                objRole.IsDeleted = true;
                objRole.CreatedById = 0;
                Int64 Result = objManager.AddUpdateRoles(objRole);
                if (Result > 0)
                {
                    lblSerSucMsg.Text = Resources.PFSalesResource.RoleDeleted.Trim();
                    dvaserSuccess.Visible = true;
                    dvsererror.Visible = false;
                    lblSerErrMsg.Text = string.Empty;
                    pnlAdd.Visible = false;
                    pnlView.Visible = true;
                    BindRoleList();
                }
                else if (Result == -9)
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.refrentialIntegrity.Trim();
                    dvaserSuccess.Visible = false;
                    dvsererror.Visible = true;
                    lblSerSucMsg.Text = string.Empty;
                }
                else
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.RoleNotDeleted.Trim();
                    dvaserSuccess.Visible = false;
                    dvsererror.Visible = true;
                    lblSerSucMsg.Text = string.Empty;
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "ManageRole.ddlPageSize_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 July 2013
    /// Description: Page Index Changing Event Of Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRoleList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRoleList.PageIndex = e.NewPageIndex;
        BindRoleList();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 July 2013
    /// Description: Sorting Event Of Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRoleList_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = e.SortExpression;
        DefineSortDirection();
        BindRoleList();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 July 2013
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
                gvRoleList.PageSize = intAllCount;
            }
            else
            {
                gvRoleList.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue.Trim());
            }
            BindRoleList();
            ClearMsg();
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "ManageRole.ddlPageSize_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 July 2013
    /// Description: Bind Role List
    /// </summary>
    private void BindRoleList()
    {
        try
        {
            objRole.RoleName = txtSearchRole.Text.Trim();
            DataTable dtRoles = objManager.GetRoleList(objRole);
            if (dtRoles.Rows.Count > 0)
            {
                DataView dtView = dtRoles.DefaultView;
                dtView.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
                gvRoleList.DataSource = dtRoles;
                gvRoleList.DataBind();
                ViewState["TotalCount"] = dtRoles.Rows.Count;
            }
            else
            {
                ViewState["TotalCount"] = "0";
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "ManageRole.BindRoleList: Error" + ex.StackTrace); throw ex;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 July 2013
    /// Description: Define Sort Direction
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
            logger.Error(ex.Message + "ManageRole.DefineSortDirection: Error" + ex.StackTrace); throw ex;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 July 2013
    /// Description: Clear All Messages
    /// </summary>
    private void ClearMsg()
    {
        lblSerErrMsg.Text = lblSerSucMsg.Text = lblAddErrMsg.Text = lblAddSucMsg.Text = string.Empty;
        dvadderror.Visible = dvaddSucc.Visible = dvaserSuccess.Visible = dvsererror.Visible = false;
    }
    #endregion
}
