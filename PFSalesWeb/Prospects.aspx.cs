using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mechsoft.PFSales.BusinessEntity;
using Mechsoft.PFSales.BusinessManager;
using log4net;
using System.Data;
using Mechsoft.GeneralUtilities;
using System.Collections;
using System.Configuration;
using System.Text;
using System.Data.Common;

public partial class Prospects : BasePage
{
    #region Global Variables
    Prospect objProsp = new Prospect();
    ProspectBM objProspBM = new ProspectBM();
    MasterBM objMstBM = new MasterBM();
    EmployeeBM objEmpBM = new EmployeeBM();
    ContactBM objContBM = new ContactBM();
    ILog Logger = LogManager.GetLogger(typeof(Prospects));
    Activity objActivity = new Activity();
    ActivityBM objActivityBM = new ActivityBM();
    double TimeSpan1 = Convert.ToDouble(ConfigurationManager.AppSettings["ActInterval"].ToString().Trim());
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["IsFleetTeamLead"] = 0;
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = "status";
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "Name";
            ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION2] = "StartDateTime";
            ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION2] = Cls_Constant.VIEWSTATE_DESC;
            BindAllStatuses();
            BindGrid();
            Page.MaintainScrollPositionOnPostBack = true;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Gridview Page Index Changing Event. 
    /// Modified By: Ayyaj Mujawar
    /// Modified Date: 15 Oct 2013
    /// Description: Gridview Page Index Changing Event Handling on Proper Bind Method. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvprosp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            if (ViewState["IsFleetTeamLead"] != null)
            {
                if (Convert.ToInt32(ViewState["IsFleetTeamLead"]) == 1)
                {
                    gvprosp.PageIndex = e.NewPageIndex;
                    BindGridFleetLead();
                }
                else
                {
                    gvprosp.PageIndex = e.NewPageIndex;
                    BindGrid();
                    lnkbtnClearFilter.Visible = false;
                }

            }
            else
            {
                gvprosp.PageIndex = e.NewPageIndex;
                BindGrid();
                lnkbtnClearFilter.Visible = false;
            }


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
                //LinkButton lnkBtnDelete = (LinkButton)e.Row.FindControl("lnkbtnDelete");
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
                HiddenField hdfConsultant = (HiddenField)e.Row.FindControl("hdfConsultant");
                HiddenField hdfFCConsultant = (HiddenField)e.Row.FindControl("hdfFCConsultant");
                if (hdfIsFleetTeamLead != null && !string.IsNullOrEmpty(hdfIsFleetTeamLead.Value.Trim()))
                {
                    if (hdfIsFleetTeamLead.Value.Trim().ToUpper() == "YES")
                        e.Row.BackColor = System.Drawing.Color.FromName("#FFCDCD");

                }
                if (BasePage.UserSession.RoleId != 1)
                {
                    if (hdfConsultant != null && lnkbtnEdit != null && hdfFCConsultant != null)
                    {
                        if (hdfConsultant.Value.ToString().Trim() == BasePage.UserSession.VirtualRoleId.ToString().Trim() || hdfFCConsultant.Value.ToString().Trim() == BasePage.UserSession.VirtualRoleId.ToString().Trim())
                        {
                            lnkbtnEdit.Visible = true;
                        }
                    }
                }
                else
                    lnkbtnEdit.Visible = true;
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
    /// Description: Search Button Click. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSearch_Click(object sender, EventArgs e)
    {
        pagerParent.CurrentIndex = 1;
        BindGrid();
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
        txtEmailId.Text = txtserprospName.Text = string.Empty;
        ddlStatus.SelectedValue = "0";
        txtserprospName.Focus();
        pagerParent.CurrentIndex = 1;
        BindGrid();
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
            if (Convert.ToInt16(ddlPageSize.SelectedValue.Trim()) == 1)
            {
                Int32 intAllCount = Convert.ToInt32(ViewState["TotalRowCount"]);
                gvprosp.PageSize = intAllCount;
            }
            else
            {
                gvprosp.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue.Trim());
            }
            if (ViewState["IsFleetTeamLead"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["IsFleetTeamLead"])) && Convert.ToString(ViewState["IsFleetTeamLead"]).Trim() == "1")
                BindGridFleetLead();
            else
                BindGrid();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.ddlPageSize_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date: 15 Oct 2013
    /// Description: Click Event Of lnkbtnFleetTeamLead For Search IsTeamLeadFleet 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFleetTeamLead_Click(object sender, EventArgs e)
    {
        gvprosp.PageIndex = 0;
        BindGridFleetLead();
        lnkbtnClearFilter.Visible = true;
        ViewState["IsFleetTeamLead"] = 1;
    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date: 15 Oct 2013
    /// Description: Click Event Of  Clear Filter For IsTeamLeadFleet 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnClearFilter_Click(object sender, EventArgs e)
    {
        gvprosp.PageIndex = 0;
        pagerParent.CurrentIndex = 1;
        BindGrid();
        lnkbtnClearFilter.Visible = false;
        ViewState["IsFleetTeamLead"] = 0;
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
            if (ViewState["IsFleetTeamLead"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["IsFleetTeamLead"])) && Convert.ToString(ViewState["IsFleetTeamLead"]).Trim() == "1")
                BindGridFleetLead();
            else
                BindGrid();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message);
            //throw ex;
        }
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
        //Added By: Ayyaj For Prospect Manage Redirect session
        //Session["FromProspect"] = "true";
        //Int64 ProspectId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
        //hdfSelProspId.Value = ProspectId.ToString().Trim();
        //Label lblprospName = (Label)(((GridViewRow)((LinkButton)sender).NamingContainer).FindControl("lblprospName"));
        //Session["Name"] = txtserprospName.Text.Trim();
        
        //Session["Status"] = ddlStatus.SelectedValue.Trim();
        //Session["Email"] = txtEmailId.Text.Trim();

        //Session["PageIndex"] = pagerParent.CurrentIndex;
        //Session["PageSize"] = ddlPageSize.SelectedValue.Trim();
        //Session["SortExpression"] = Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION]).Trim();
        //Session["SortDirection"] = Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION]).Trim();

        ////}
        //Session["Contact"] = Convert.ToString(ViewState["Contacts"]).Trim();
        //if (Session["MyProspData"] != null && ((DataTable)Session["MyProspData"]).Rows.Count > 0 && ProspectId > 0)
        //{
        //    DataRow[] dr = ((DataTable)(Session["MyProspData"])).Select("Id='" + ProspectId.ToString().Trim() + "'");
        //    if (dr != null && dr.Length > 0)
        //    {
        //        Int64 RowNum = Convert.ToInt64(Convert.ToString(dr[0]["RowNo"]).Trim());
        //        Session["MyCurrentProsp"] = Convert.ToString(RowNum).Trim();
        //    }
        //}
        //Response.Redirect("ManageActivities.aspx?ProspectId=" + ProspectId.ToString().Trim());
        pnlViewContact.Visible = true;
        Int64 ProspId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
        BidData(ProspId);
        BindMangeActivity(ProspId);



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
        pnlViewContact.Visible = false;
        
    }

    #endregion

    #region Methods

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Bind Grid View Data
    /// </summary>
    private void BindGrid()
    {
        try
        {
            objProsp.FName = txtserprospName.Text.Trim();
            objProsp.StatusId = Convert.ToInt64(ddlStatus.SelectedValue.Trim());
            objProsp.Email = txtEmailId.Text.Trim();
            objProsp.PageSize = gvprosp.PageSize;
            objProsp.PageIndex = pagerParent.CurrentIndex;
            pagerParent.PageSize = gvprosp.PageSize;
            DataSet Ds = objProspBM.GetAllProspects(objProsp);
            if (Ds != null && Ds.Tables.Count > 0)
            {
                DataTable Dt = Ds.Tables[0];
                if (Dt != null & Dt.Rows.Count > 0)
                {
                    DataView dV = Dt.DefaultView;
                    dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
                    gvprosp.DataSource = Dt;
                    gvprosp.DataBind();
                    pagerParent.PageSize = gvprosp.PageSize;
                    if (Ds.Tables[1].Rows.Count > 0)
                    {
                        pagerParent.ItemCount = Convert.ToDouble(Ds.Tables[1].Rows[0][0]);
                        ViewState["TotalRowCount"] = Ds.Tables[1].Rows.Count;
                    }
                    else
                        pagerParent.ItemCount = 0;
                }
                else
                {
                    gvprosp.DataSource = null;
                    gvprosp.DataBind();
                    ViewState["TotalRowCount"] = "0";
                }
            }
            else
            {
                gvprosp.DataSource = null;
                gvprosp.DataBind();
                ViewState["TotalRowCount"] = "0";
            }
            //Desc:When Default Data Bind lnkbtnClearFilter will vanish: Ayyaj
            lnkbtnClearFilter.Visible = false;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindGrid.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date: 25 Oct 2013
    /// Description: Bind Grid View Data For Fleet Lead
    /// </summary>
    private void BindGridFleetLead()
    {
        try
        {
            objProsp.FName = txtserprospName.Text.Trim();
            objProsp.StatusId = Convert.ToInt64(ddlStatus.SelectedValue.Trim());
            objProsp.Email = txtEmailId.Text.Trim();
            objProsp.PageSize = gvprosp.PageSize;
            objProsp.PageIndex = pagerParent.CurrentIndex;
            pagerParent.PageSize = gvprosp.PageSize;
            DataSet Ds = objProspBM.GetAllFleetTeamProspects(objProsp);
            if (Ds != null && Ds.Tables.Count > 0)
            {
                DataTable Dt = Ds.Tables[0];
                if (Dt != null & Dt.Rows.Count > 0)
                {
                    DataView dV = Dt.DefaultView;
                    dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
                    gvprosp.DataSource = Dt;
                    gvprosp.DataBind();
                    ViewState["TotalRowCount"] = Dt.Rows.Count;
                    pagerParent.PageSize = gvprosp.PageSize;
                    if (Ds.Tables[1].Rows.Count > 0)
                    {
                        pagerParent.ItemCount = Convert.ToDouble(Ds.Tables[1].Rows[0][0]);
                        ViewState["TotalRowCount"] = Ds.Tables[1].Rows.Count;
                    }
                    else
                        pagerParent.ItemCount = 0;
                }
                else
                {
                    gvprosp.DataSource = null;
                    gvprosp.DataBind();
                    ViewState["TotalRowCount"] = "0";
                }
            }
            else
            {
                gvprosp.DataSource = null;
                gvprosp.DataBind();
                ViewState["TotalRowCount"] = "0";
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindGrid.Error:" + ex.StackTrace);
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
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Get All Statuses
    /// </summary>
    private void BindAllStatuses()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllStatus(1, 1);// Hard Coded Entity Id & Process Id
            Cls_BinderHelper.BindDropdownList(ddlStatus, "Status", "Id", Dt);
            //Cls_BinderHelper.BindDropdownList(ddlAddStatus, "Status", "Id", Dt);
            //ddlAddStatus.SelectedValue = "1";
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindAllStatuses.Error:" + ex.StackTrace);
        }
    }
    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 15 July 2013
    /// Description: Bind Managed Activity Data
    /// </summary>
    /// <param name="ProspectId"></param>
    public void BindMangeActivity(Int64 ProspectId)
    {
        try
        {
            if (ProspectId > 0)
            {
                DataTable Dt = objActivityBM.GetAllContactNotes(ProspectId, BasePage.UserSession.VirtualRoleId);
                if (Dt != null & Dt.Rows.Count > 0)
                {
                    DataView dV = Dt.DefaultView;
                    dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION2].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION2].ToString());
                    gvActivity.DataSource = Dt;
                    gvActivity.DataBind();
                }
                else
                {
                    gvActivity.DataSource = null;
                    gvActivity.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SearchProspect.lnkbtnManageAct_Click.Error:" + ex.StackTrace);
        }
    }

    public void BidData(Int64 ProspId)
    {
        try
        {
            if (ProspId > 0)
            {
                //if (Session["MyProspData"] != null)
                //{
                //    LinkButton lnkbtnNext = (LinkButton)this.Parent.FindControl("lnkbtnNext");
                //    LinkButton lnkbtnPrevious = (LinkButton)this.Parent.FindControl("lnkbtnPrevious");
                //    if (lnkbtnPrevious != null && lnkbtnNext != null)
                //    {
                //        if (((DataTable)(Session["MyProspData"])).Rows.Count > 1 && (Convert.ToInt64(Convert.ToString(Session["MyCurrentProsp"]).Trim())) != ((DataTable)(Session["MyProspData"])).Rows.Count)
                //        {
                //            lnkbtnNext.Visible = true;
                //            if ((Convert.ToInt64(Convert.ToString(Session["MyCurrentProsp"]).Trim())) > 1)
                //                lnkbtnPrevious.Visible = true;
                //            else
                //                lnkbtnPrevious.Visible = false;
                //        }
                //        else if (((DataTable)(Session["MyProspData"])).Rows.Count > 1 && (Convert.ToInt32(Convert.ToString(Session["MyCurrentProsp"]).Trim())) == ((DataTable)(Session["MyProspData"])).Rows.Count)
                //        {
                //            lnkbtnNext.Visible = false;
                //            if ((Convert.ToInt64(Convert.ToString(Session["MyCurrentProsp"]).Trim())) > 1)
                //                lnkbtnPrevious.Visible = true;
                //            else
                //                lnkbtnPrevious.Visible = false;
                //        }
                //        else
                //        {
                //            lnkbtnPrevious.Visible = lnkbtnNext.Visible = false;
                //        }
                //    }
                //}

                DataTable dt = objProspBM.GetProspDetAssignedToConsult(0, DateTime.MinValue, DateTime.MaxValue, ProspId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    hdfProspectId.Value = Convert.ToString(ProspId).Trim();
                    lblName.Text = Convert.ToString(dt.Rows[0]["FName"]).Trim() + " " + Convert.ToString(dt.Rows[0]["MName"]).Trim() + " " + Convert.ToString(dt.Rows[0]["LName"]).Trim();
                    lblName.Text = lblName.Text.Trim().Replace("  ", " ");
                    lblCarMake.Text = Convert.ToString(dt.Rows[0]["Make"]).Trim();
                    hdfMakeId.Value = Convert.ToString(dt.Rows[0]["CarMake"]).Trim();
                    lblPhNo.Text = Convert.ToString(dt.Rows[0]["Phone"]).Trim();
                    //..modified by: Ayyaj
                    //Desc: For disable validation on UC_AddEditContact
                    Session["isPForFC"] = Convert.ToString(dt.Rows[0]["isPForFC"]).Trim();
                    //...................
                    if (lblPhNo.Text.Trim() != "--")
                    {
                        if (Convert.ToString(dt.Rows[0]["Phone"]).Trim().Length == 10)
                            lblPhNo.Text = Convert.ToString(dt.Rows[0]["Phone"]).Trim().Substring(0, 4) + " " + Convert.ToString(dt.Rows[0]["Phone"]).Trim().Substring(4, 3) + " " + Convert.ToString(dt.Rows[0]["Phone"]).Trim().Substring(7, 3);
                    }
                    lblMobile.Text = Convert.ToString(dt.Rows[0]["Mobile"]).Trim();
                    if (lblMobile.Text.Trim() == "--")
                        lblMobile.Enabled = false;
                    else
                    {
                        lblMobile.Enabled = true;
                        if (Convert.ToString(dt.Rows[0]["Mobile"]).Trim().Length == 10)
                            lblMobile.Text = Convert.ToString(dt.Rows[0]["Mobile"]).Trim().Substring(0, 4) + " " + Convert.ToString(dt.Rows[0]["Mobile"]).Trim().Substring(4, 3) + " " + Convert.ToString(dt.Rows[0]["Mobile"]).Trim().Substring(7, 3);
                    }
                    lblAltContNo.Text = Convert.ToString(dt.Rows[0]["AltContNo"]).Trim();
                    if (lblAltContNo.Text.Trim() != "--")
                    {
                        if (Convert.ToString(dt.Rows[0]["AltContNo"]).Trim().Length == 10)
                            lblAltContNo.Text = Convert.ToString(dt.Rows[0]["AltContNo"]).Trim().Substring(0, 4) + " " + Convert.ToString(dt.Rows[0]["AltContNo"]).Trim().Substring(4, 3) + " " + Convert.ToString(dt.Rows[0]["AltContNo"]).Trim().Substring(7, 3);
                    }
                    lblFax.Text = Convert.ToString(dt.Rows[0]["Fax"]).Trim();
                    lblEmail1.Text = Convert.ToString(dt.Rows[0]["Email1"]).Trim();
                    aEmail.HRef = "mailto:" + lblEmail1.Text.Trim(); ;
                    lblAlterEmail.Text = Convert.ToString(dt.Rows[0]["Email2"]).Trim();
                    lblAddLine1.Text = Convert.ToString(dt.Rows[0]["Add1"]).Trim();
                    lblAddLine2.Text = Convert.ToString(dt.Rows[0]["Add2"]).Trim();
                    lblAddLine3.Text = Convert.ToString(dt.Rows[0]["Add3"]).Trim();
                    lblCountry.Text = Convert.ToString(dt.Rows[0]["Country"]).Trim();
                    lblState.Text = Convert.ToString(dt.Rows[0]["StateName"]).Trim();
                    lblCity.Text = Convert.ToString(dt.Rows[0]["City"]).Trim();
                    lblPostalCode.Text = Convert.ToString(dt.Rows[0]["PostalCode"]).Trim();
                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ConsultantName"]).Trim()))
                        lblConsultant.Text = Convert.ToString(dt.Rows[0]["ConsultantName"]).Trim();
                    else
                        lblConsultant.Text = "--";
                    if (BasePage.UserSession.RoleId == 5)
                        lblAddStatus.Text = Convert.ToString(dt.Rows[0]["FCStatus"]).Trim();
                    else
                        lblAddStatus.Text = Convert.ToString(dt.Rows[0]["Status"]).Trim();
                    if (BasePage.UserSession.RoleId == 3)
                        hdfProspStatus.Value = Convert.ToString(dt.Rows[0]["StatusId"]).Trim();
                    else if (BasePage.UserSession.RoleId == 5)
                        hdfProspStatus.Value = Convert.ToString(dt.Rows[0]["FCStatusId"]).Trim();
                    else if (BasePage.UserSession.RoleId == 1)
                    {
                        if (dt.Rows[0]["isPFOrFC"] != null && !string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["isPFOrFC"]).Trim()))
                        {
                            if (Convert.ToString(dt.Rows[0]["isPFOrFC"]).Trim().ToUpper() == "W")
                                hdfProspStatus.Value = Convert.ToString(dt.Rows[0]["StatusId"]).Trim();
                            else if (Convert.ToString(dt.Rows[0]["isPFOrFC"]).Trim().ToUpper() == "F")
                                hdfProspStatus.Value = Convert.ToString(dt.Rows[0]["FCStatusId"]).Trim();
                            else
                                hdfProspStatus.Value = Convert.ToString(dt.Rows[0]["StatusId"]).Trim();
                        }
                        else
                            hdfProspStatus.Value = Convert.ToString(dt.Rows[0]["StatusId"]).Trim();
                    }
                    lblSource.Text = Convert.ToString(dt.Rows[0]["RefSource"]).Trim() + " " + ((!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Leadsource"]).Trim().Replace("--", ""))) ? ("(" + Convert.ToString(dt.Rows[0]["Leadsource"]).Trim() + ")") : "");
                    lblMemNo.Text = Convert.ToString(dt.Rows[0]["MemberNo"]).Trim();
                    lblFConsultant.Text = Convert.ToString(dt.Rows[0]["FConsultant"]).Trim();
                    lblEnqDate.Text = Convert.ToString(dt.Rows[0]["EnquiryDate"]).Trim();
                    lblModel.Text = Convert.ToString(dt.Rows[0]["Model"]).Trim();
                    lblComments.Text = Convert.ToString(dt.Rows[0]["Comment"]).Trim();
                    lblTradeIn.Text = Convert.ToString(dt.Rows[0]["TradeIn"]).Trim();
                    lblFinance.Text = Convert.ToString(dt.Rows[0]["Finance"]).Trim();
                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["FCStatus"]).Trim()))
                        lblFCStatus.Text = Convert.ToString(dt.Rows[0]["FCStatus"]).Trim();
                    else
                        lblFCStatus.Text = "--";
                    lblPFAllocationDate.Text = Convert.ToString(dt.Rows[0]["PFAllocatedDate"]).Trim();
                    lblFCAllocationDate.Text = Convert.ToString(dt.Rows[0]["FCAllocatedDate"]).Trim();
                    lblWDHAPF.Text = Convert.ToString(dt.Rows[0]["WhereDidYouHear"]).Trim();
                    

                        // Added for logic to implement mandatory process of "unable to contact". Need to uncomment this when it asks to implement
                    //else
                    //{
                    //    if (BasePage.UserSession.RoleId == 3)
                    //    {
                    //        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PFAlocationDate"]).Trim()) && Convert.ToString(dt.Rows[0]["PFAlocationDate"]).Trim().ToUpper() != "NOT AVAILABLE" && !string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PFCalledLeftMsgCount"]).Trim()))
                    //        {
                    //            if (Convert.ToDateTime(Convert.ToString(dt.Rows[0]["PFAlocationDate"]).Trim()) <= DateTime.Now.AddHours(-24) && Convert.ToInt32(dt.Rows[0]["PFCalledLeftMsgCount"])>=2)
                    //                lnkbtnSendUnableToConMail.Visible = true;
                    //            else
                    //                lnkbtnSendUnableToConMail.Visible = false;
                    //        }
                    //        else
                    //            lnkbtnSendUnableToConMail.Visible = false;
                    //    }
                    //    else if (BasePage.UserSession.RoleId == 5)
                    //    {
                    //        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["FCAlocationDate"]).Trim()) && Convert.ToString(dt.Rows[0]["FCAlocationDate"]).Trim().ToUpper() != "NOT AVAILABLE" && !string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["FCCalledLeftMsgCount"]).Trim()))
                    //        {
                    //            if (Convert.ToDateTime(Convert.ToString(dt.Rows[0]["FCAlocationDate"]).Trim()) <= DateTime.Now.AddHours(-24) && Convert.ToInt32(dt.Rows[0]["FCCalledLeftMsgCount"]) >= 2)
                    //                lnkbtnSendUnableToConMail.Visible = true;
                    //            else
                    //                lnkbtnSendUnableToConMail.Visible = false;
                    //        }
                    //        else
                    //            lnkbtnSendUnableToConMail.Visible = false;
                    //    }
                    //    else if (BasePage.UserSession.RoleId == 1)
                    //    {
                    //        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PFAlocationDate"]).Trim()) && Convert.ToString(dt.Rows[0]["PFAlocationDate"]).Trim().ToUpper() != "NOT AVAILABLE" && !string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PFCalledLeftMsgCount"]).Trim()))
                    //        {
                    //            if (Convert.ToDateTime(Convert.ToString(dt.Rows[0]["PFAlocationDate"]).Trim()) <= DateTime.Now.AddHours(-24) && Convert.ToInt32(dt.Rows[0]["PFCalledLeftMsgCount"]) >= 2)
                    //                lnkbtnSendUnableToConMail.Visible = true;
                    //            else
                    //                lnkbtnSendUnableToConMail.Visible = false;
                    //        }
                    //        else
                    //            lnkbtnSendUnableToConMail.Visible = false;
                    //    }
                    //    else
                    //        lnkbtnSendUnableToConMail.Visible = false;
                    //}
                    
                    //SetContent(Convert.ToString(dt.Rows[0]["FName"]).Trim());
                    hdfConsultPhone.Value = Convert.ToString(dt.Rows[0]["ConsultPhone"]).Trim();
                    hdfConsultExt.Value = Convert.ToString(dt.Rows[0]["ConsultExt"]).Trim();
                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ActualMake"]).Trim().Replace("--", "")) && ((Convert.ToString(dt.Rows[0]["MakeFromId"]).Trim().ToUpper() == "OTHER") || (Convert.ToInt64(Convert.ToString(dt.Rows[0]["CarMake"]).Trim())) == 0))
                        lblActualMakeInput.Text = "(" + Convert.ToString(dt.Rows[0]["ActualMake"]).Trim() + ")";
                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Model"]).Trim().Replace("--", "")) && Convert.ToString(dt.Rows[0]["ModelFromId"]).Trim().ToUpper() == "OTHER")
                        lblActualModelInput.Text = "(" + Convert.ToString(dt.Rows[0]["Model"]).Trim() + ")";

                    DataTable dtFC = objProspBM.GetProspFCDetFromProId(ProspId);
                    if (dtFC != null && dtFC.Rows.Count > 0)
                    {
                        lblCreditHistory.Text = Convert.ToString(dtFC.Rows[0]["CreditHistory"]).Trim();
                        lblEstFin.Text = Convert.ToString(dtFC.Rows[0]["EstimatedFinance"]).Trim();
                        lblInitialDeposit.Text = Convert.ToString(dtFC.Rows[0]["InitialDeposite"]).Trim();
                        lblTermyears.Text = Convert.ToString(dtFC.Rows[0]["Term"]).Trim();
                        lblResidualBallonPaymen.Text = Convert.ToString(dtFC.Rows[0]["Payment"]).Trim();
                        lblMessage.Text = Convert.ToString(dtFC.Rows[0]["Message"]).Trim();
                        lblFinanceRequired.Text = Convert.ToString(dtFC.Rows[0]["FinanceType"]).Trim();
                        lblEmployment.Text = Convert.ToString(dtFC.Rows[0]["Employment"]).Trim();
                        lblEmployer.Text = Convert.ToString(dtFC.Rows[0]["Employer"]).Trim();
                        lblCurrentIncome.Text = Convert.ToString(dtFC.Rows[0]["CurrentIncome"]).Trim();
                        lblTimeinCurEmp.Text = Convert.ToString(dtFC.Rows[0]["Time_in_Cur_Emp"]).Trim();
                        lblTimeAtCurAdd.Text = Convert.ToString(dtFC.Rows[0]["Time_At_Cur_Add"]).Trim();
                        lblFinFrom.Text = Convert.ToString(dtFC.Rows[0]["FinFor"]).Trim();
                        hdfFinLeadTypeID.Value = Convert.ToString(dtFC.Rows[0]["FinLeadTypeId"]).Trim();
                        hdfFCId.Value = Convert.ToString(dtFC.Rows[0]["Id"]).Trim();
                    }
                    else
                    {
                        lblFinFrom.Text = lblTimeAtCurAdd.Text = lblTimeinCurEmp.Text = lblCurrentIncome.Text = lblEmployer.Text = lblEmployment.Text = lblFinanceRequired.Text = lblCreditHistory.Text = lblEstFin.Text = lblInitialDeposit.Text = lblTermyears.Text = lblResidualBallonPaymen.Text = lblMessage.Text = "--";
                    }
                    // Modified By: Ayyaj Mujawar. Date:05 Oct 2013
                    //Desc:To Add New HyperLink Button For To Search On  RedBook Site
                    if (dt != null && dt.Rows.Count > 0)
                    {

                        string SeachCarUrl = string.Empty;
                        string txt1 = "http://www.redbook.com.au/cars/research-new";
                        string txt3 = ""; string txt2 = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Make"]).Trim().Replace("--", "")))
                            txt2 = "/" + Convert.ToString(dt.Rows[0]["Make"]).Trim().Replace("--", "");
                        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Model"]).Trim().Replace("--", "")))
                            txt3 = "/" + Convert.ToString(dt.Rows[0]["Model"]).Trim().Replace("--", "");
                        //Modified By: Ayyaj Mujawar. Date:03 January 2014
                        //Desc:To Add Hard Code Year for Timebeing untill redbook get updated.
                        //string txt4 = "/" + Convert.ToString(System.DateTime.Now.Year);
                        string txt4 = "/2014";
                        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Model"]).Trim()))
                        {
                            SeachCarUrl = txt1 + txt2 + txt3 + txt4;
                        }
                        else
                        {
                            SeachCarUrl = txt1 + txt2 + txt4;
                        }

                       

                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "UserControls_UC_ProspectDetails.BidData.error:" + ex.StackTrace);
        }
    }
    #endregion
}
