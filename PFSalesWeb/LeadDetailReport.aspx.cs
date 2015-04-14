using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using System.Data;
using Mechsoft.GeneralUtilities;
using iTextSharp.text;
using System.Data.OleDb;
using Mechsoft.PFSales.BusinessEntity;
using Mechsoft.PFSales.BusinessManager;

public partial class LeadDetailReport : BasePage

{
    #region Private Variables
    ILog Logger = LogManager.GetLogger(typeof(LeadDetailReport));
    Prospect objProsp = new Prospect();
    ProspectBM objProspBM = new ProspectBM();
    MasterBM objMstBM = new MasterBM();
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = "Make";
        ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;      
        BindGrid();
        Page.MaintainScrollPositionOnPostBack = true;
        txtFromDate.Focus();
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
        BindGrid();
    }
    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 July 2013
    /// Description: Page Index Changing Event of Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvprosp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvprosp.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 July 2013
    /// Description: Sorting Event of Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvprosp_Soring(object sender, GridViewSortEventArgs e)
    {
        ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = e.SortExpression;
        DefineSortDirection();
        BindGrid();
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
            if (Convert.ToInt16(ddlPageSize.SelectedValue.Trim()) == 1)
            {
                Int32 intAllCount = Convert.ToInt32(ViewState["TotalCount"]);
                gvprosp.PageSize = intAllCount;
            }
            else
            {
                gvprosp.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue.Trim());
            }
            BindGrid();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Reports_ProspectReport.ddlPageSize_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
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

        txtToDate.Text = string.Empty;
        txtFromDate.Text = string.Empty;
        BindGrid();
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
            if (!string.IsNullOrEmpty(txtFromDate.Text.Replace("__/__/____", "")))
            {
                objProsp.FromDate = Convert.ToDateTime(txtFromDate.Text.Trim());
            }
            else
            {
                objProsp.FromDate = null;
            }

            if (!string.IsNullOrEmpty(txtToDate.Text.Replace("__/__/____", "")))
            {
                objProsp.ToDate = Convert.ToDateTime(txtToDate.Text.Trim());
            }
            else
            {
                objProsp.ToDate = null;
            }
           
       
          

            DataTable Dt = objProspBM.GetProspectStats(objProsp);

            if (Dt != null & Dt.Rows.Count > 0)
            {
                DataView dV = Dt.DefaultView;
                //if (BasePage.UserSession.RoleId == 3)
                //{
                //    dV.RowFilter = "ConsultantId=" + BasePage.UserSession.VirtualRoleId.ToString().Trim();
                //}
                dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
                ViewState["MainData"] = gvprosp.DataSource = Dt;
                gvprosp.DataBind();
                ViewState["TotalCount"] = Dt.Rows.Count;
            }
            else
            {
                gvprosp.DataSource = null;
                gvprosp.DataBind();
                ViewState["TotalCount"] = "0";
            }

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Reports_ProspectReport.BindGrid.Error:" + ex.StackTrace);
        }
    }


    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 July 2013
    /// Description: Define Sort Direction For Sorting.
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
            Logger.Error(ex.Message + "Reports_ProspectReport.DefineSortDirection.Error:" + ex.StackTrace);
        }
    }

    #endregion
}
   