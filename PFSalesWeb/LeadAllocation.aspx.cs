using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mechsoft.GeneralUtilities;
using log4net;
using Mechsoft.PFSales.BusinessManager;
using Mechsoft.PFSales.BusinessEntity;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Globalization;

public partial class LeadAllocation : BasePage
{
    #region Global Variables
    ILog Logger = LogManager.GetLogger(typeof(LeadAllocation));
    EmployeeBM objEmpBM = new EmployeeBM();
    Employee objEmp = new Employee();
    ProspectBM objProspectBM = new ProspectBM();
    Prospect objProsp = new Prospect();
    Activity objActivity = new Activity();
    ActivityBM objActivityBM = new ActivityBM();
    MasterBM objMstBm = new MasterBM();
    DataTable DtResult = new DataTable();
    double TimeSpan1 = Convert.ToDouble(ConfigurationManager.AppSettings["ActInterval"].ToString().Trim());
    int TotlPFTodLead = 0, TotlPF24hrLead = 0, TotlPFWeekLead = 0, TotlPFMonthLead = 0, TotlPF48Lead = 0, TotlPF7DLead = 0, TotlPFCWLoad = 0, TotlPFNYC = 0;
    int TotlFCTodLead = 0, TotlFC24hrLead = 0, TotlFCWeekLead = 0, TotlFCMonthLead = 0, TotlFC48Lead = 0, TotlFC7DLead = 0, TotlFCCWLoad = 0, TotlFCNYC = 0;
    Thread t3 = null;
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hdfAttachmentPath.Value = HttpContext.Current.Server.MapPath("~/Attachment/Private Fleet Trade-In Valuation Form.xls");
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = "Name";
            Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "CreatedDate";
            Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;
            BindFleetLeads();
            BindConsultants();
            //BindFCFleetLeads();
            BindFCConsultants();
            GetOldestEnquiryDate();
            txtFCTotEntToDate1.Text = txtFCUnalocToDate1.Text = txtFCTotEntToDate.Text = txtFCUnalocToDate.Text = txtTotEntToDate1.Text = txtUnalocToDate1.Text = txtTotEntToDate.Text = txtUnalocToDate.Text = DateTime.Today.Date.ToString(Resources.PFSalesResource.dateformat.Trim());
            GetTotalCount();
            GetUnAlocatedEnqCount();
            GetTotalCount1();
            GetUnAlocatedEnqCount1();
            GetFCTotalCount1();
            GetFCUnAlocatedEnqCount1();
            GetTotalFCCount();
            GetUnAlocatedFCEnqCount();
            gvAllocate.Focus();
            //CompValToTodayDate.ValueToCompare = DateTime.Today.Date.ToString(Resources.PFSalesResource.dateformat.Trim());
            if (Session["Flag"] == null)
            {
                Session["Flag"] = "PF";
            }
            if (Session["ConsultantId"] != null && Session["Flag"] != null && Session["Status"] != null)
            {
                int consultantID = Convert.ToInt32(Session["ConsultantId"]);
                string strFlag = Convert.ToString(Session["Flag"]);
                string strStatus = Convert.ToString(Session["Status"]);
                switch (strFlag.ToUpper())
                {
                    case "PF":
                        switch (strStatus.ToUpper())
                        {
                            case "CUR":
                                foreach (GridViewRow gr in gvAllocate.Rows)
                                {
                                    HiddenField hdfConsultantId = (HiddenField)gr.FindControl("hdfConsultantId");
                                    if (Convert.ToInt32(hdfConsultantId.Value) == consultantID)
                                    {
                                        LinkButton lnkbtnCurrWorkLoad = (LinkButton)gr.FindControl("lnkbtnCurrWorkLoad");
                                        lnkbtnCurrWorkLoad_Click(lnkbtnCurrWorkLoad, null);
                                    }
                                }

                                break;
                            case "NYC":
                                foreach (GridViewRow gr in gvAllocate.Rows)
                                {
                                    HiddenField hdfConsultantId = (HiddenField)gr.FindControl("hdfConsultantId");
                                    if (Convert.ToInt32(hdfConsultantId.Value) == consultantID)
                                    {
                                        LinkButton lnkbtnNYCWorkLoad = (LinkButton)gr.FindControl("lnkbtnNYCWorkLoad");
                                        lnkbtnNYCWorkLoad_Click(lnkbtnNYCWorkLoad, null);
                                    }
                                }
                                break;
                            case "U":
                                pnlLeadAllocation.Visible = true;
                                pnlFCleadAllocation.Visible = false;
                                lnkbtnPFAllocation.CssClass = "tablerBtnActive";
                                lnkbtnFCAllocation.CssClass = string.Empty;
                                Session["Flag"] = "PF";
                                lnkbtnUnallocatedEnq1_Click(lnkbtnUnallocatedEnq1, null);
                                break;
                        }
                        break;
                    case "FC":
                        switch (strStatus.ToUpper())
                        {
                            case "CUR":
                                foreach (GridViewRow gr in gvFCAllocate.Rows)
                                {
                                    HiddenField hdfFCConsultantId = (HiddenField)gr.FindControl("hdfFCConsultantId");
                                    if (Convert.ToInt32(hdfFCConsultantId.Value) == consultantID)
                                    {
                                        LinkButton lnkbtnFCCurrWorkLoad = (LinkButton)gr.FindControl("lnkbtnFCCurrWorkLoad");
                                        lnkbtnFCCurrWorkLoad_Click(lnkbtnFCCurrWorkLoad, null);
                                    }
                                }
                                break;
                            case "NYC":
                                foreach (GridViewRow gr in gvFCAllocate.Rows)
                                {
                                    HiddenField hdfFCConsultantId = (HiddenField)gr.FindControl("hdfFCConsultantId");
                                    if (Convert.ToInt32(hdfFCConsultantId.Value) == consultantID)
                                    {
                                        LinkButton lnkbtnFCNotYetCalled = (LinkButton)gr.FindControl("lnkbtnFCNotYetCalled");
                                        lnkbtnFCNotYetCalled_Click(lnkbtnFCNotYetCalled, null);
                                    }
                                }
                                break;

                            case "U":
                                pnlLeadAllocation.Visible = false;
                                pnlFCleadAllocation.Visible = true;
                                lnkbtnPFAllocation.CssClass = string.Empty;
                                lnkbtnFCAllocation.CssClass = "tablerBtnActive";
                                Session["Flag"] = "FC";
                                lnkbtnFCUnallocatedEnq1_Click(lnkbtnFCUnallocatedEnq1, null);
                                break;
                        }
                        break;
                }
            }
            if (Request.QueryString["from"] != null && !string.IsNullOrEmpty(Request.QueryString["from"].ToString().Trim()))
            {
                int consultantID = Convert.ToInt32(Convert.ToString(Request.QueryString["from"]).Substring(2));
                foreach (GridViewRow gr in gvAllocate.Rows)
                {
                    HiddenField hdfConsultantId = (HiddenField)gr.FindControl("hdfConsultantId");
                    if (Convert.ToInt32(hdfConsultantId.Value) == consultantID)
                    {
                        LinkButton lnkbtnCurrWorkLoad = (LinkButton)gr.FindControl("lnkbtnCurrWorkLoad");
                        lnkbtnCurrWorkLoad_Click(lnkbtnCurrWorkLoad, null);
                    }
                }
            }
            if (Convert.ToInt32(lnkbtnUnallocatedEnq1.Text.Trim()) > 0)
                lnkbtnAllocate.Enabled = true;
            else
                lnkbtnAllocate.Enabled = false;
            if (Convert.ToInt32(lnkbtnFCUnallocatedEnq1.Text.Trim()) == 0)
                lnkbtnFCAllocate.Enabled = false;
            else
                lnkbtnFCAllocate.Enabled = true;
        }
    }

    #region "PF Lead Allocation"

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 30 May 2013
    /// Description: Grid view Row Created Event. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAllocate_Created(object sender, GridViewRowEventArgs e)
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
    /// Created Date: 30 May 2013
    /// Description: Gridview Page Sorting Event Of Consultant's GridView. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAllocate_Soring(object sender, GridViewSortEventArgs e)
    {
        try
        {
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = e.SortExpression;
            DefineSortDirection();
            BindConsultants();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.gvprosp_Soring.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 30 May 2013
    /// Description: Check Changed Event Of Header's Check Box. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkSelectAll_CheckChanged(object sender, EventArgs e)
    {
        try
        {
            ClearMsg();
            foreach (GridViewRow grviewrow in gvAllocate.Rows)
            {
                CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkSelect");
                TextBox txtNoOfLeads = (TextBox)grviewrow.FindControl("txtNoOfLeads");
                if (chkbx != null && txtNoOfLeads != null)
                {
                    if (chkbx.Checked)
                    {
                        txtNoOfLeads.Enabled = true;
                        if (!string.IsNullOrEmpty(txtBulkAmt.Text.Trim()))
                            txtNoOfLeads.Text = txtBulkAmt.Text.Trim();
                        else
                            txtNoOfLeads.Text = "0";
                    }
                    else
                    {
                        txtNoOfLeads.Text = "0";
                        txtNoOfLeads.Enabled = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.chkSelectAll_CheckChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 30 May 2013
    /// Description: Check Changed Event Of Select Consultant's Check Box. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkSelect_CheckChanged(object sender, EventArgs e)
    {
        try
        {
            ClearMsg();
            GridViewRow grviewrow = (GridViewRow)(((CheckBox)sender).NamingContainer);
            CheckBox chkbx = (CheckBox)sender;
            TextBox txtNoOfLeads = (TextBox)grviewrow.FindControl("txtNoOfLeads");
            CompareValidator cvNoOfLeadsVal = (CompareValidator)grviewrow.FindControl("cvNoOfLeadsVal");
            if (chkbx != null && txtNoOfLeads != null && cvNoOfLeadsVal != null)
            {
                if (chkbx.Checked)
                {
                    txtNoOfLeads.Enabled = true;
                    cvNoOfLeadsVal.ValidationGroup = "Allocate";
                    if (!string.IsNullOrEmpty(txtBulkAmt.Text.Trim()))
                        txtNoOfLeads.Text = txtBulkAmt.Text.Trim();
                    else
                        txtNoOfLeads.Text = "0";
                }
                else
                {
                    cvNoOfLeadsVal.ValidationGroup = "Other";
                    txtNoOfLeads.Text = "0";
                    txtNoOfLeads.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.chkSelectAll_CheckChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Button Click Event of Get Total Entity Count. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnTotEntGetCount_Click(object sender, EventArgs e)
    {
        GetTotalCount();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Button Click Event of Get Total Entity Count. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnTotEntGetCount1_Click(object sender, EventArgs e)
    {
        GetTotalCount1();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Button Click Event of Get Total Entity Count. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnUnalocGetCount_Click(object sender, EventArgs e)
    {
        GetUnAlocatedEnqCount();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Button Click Event of Get Total Entity Count. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnUnalocGetCount1_Click(object sender, EventArgs e)
    {
        GetUnAlocatedEnqCount1();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Grid view Row Data Bound Event. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAllocate_RowDatabound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblTodaysLeads = (Label)e.Row.FindControl("lblTodaysLeads");
                Label lblTwentyFourHr = (Label)e.Row.FindControl("lblTwentyFourHr");
                Label lblThisWeek = (Label)e.Row.FindControl("lblThisWeek");
                Label lblThisMonth = (Label)e.Row.FindControl("lblThisMonth");
                Label lblContfortyEighthr = (Label)e.Row.FindControl("lblContfortyEighthr");
                Label lblContSevenDays = (Label)e.Row.FindControl("lblContSevenDays");
                LinkButton lnkbtnWorkLoad = (LinkButton)e.Row.FindControl("lnkbtnCurrWorkLoad");
                LinkButton lnkbtnNYCWorkLoad = (LinkButton)e.Row.FindControl("lnkbtnNYCWorkLoad");

                CompareValidator cvNoOfLeadsVal = (CompareValidator)e.Row.FindControl("cvNoOfLeadsVal");
                if (lnkbtnWorkLoad != null && !string.IsNullOrEmpty(lnkbtnWorkLoad.Text.Trim()))
                    if (lnkbtnWorkLoad.Text.Trim() == "0")
                        lnkbtnWorkLoad.Enabled = false;
                if (cvNoOfLeadsVal != null)
                    cvNoOfLeadsVal.ValidationGroup = "NoofLeadsVal" + e.Row.RowIndex.ToString().Trim();

                if (lnkbtnNYCWorkLoad != null && !string.IsNullOrEmpty(lnkbtnNYCWorkLoad.Text.Trim()))
                    if (lnkbtnNYCWorkLoad.Text.Trim() == "0")
                        lnkbtnNYCWorkLoad.Enabled = false;
                if (lblTodaysLeads != null && lblTwentyFourHr != null && lblThisWeek != null && lblThisMonth != null && lblContfortyEighthr != null && lblContSevenDays != null && lnkbtnWorkLoad != null && lnkbtnNYCWorkLoad != null)
                {
                    if (!string.IsNullOrEmpty(lblTodaysLeads.Text.Trim()) && !string.IsNullOrEmpty(lblTwentyFourHr.Text.Trim()) && !string.IsNullOrEmpty(lblThisWeek.Text.Trim()) && !string.IsNullOrEmpty(lblThisMonth.Text.Trim()) && !string.IsNullOrEmpty(lblContfortyEighthr.Text.Trim()) && !string.IsNullOrEmpty(lblContSevenDays.Text.Trim()) && !string.IsNullOrEmpty(lnkbtnWorkLoad.Text.Trim()) && !string.IsNullOrEmpty(lnkbtnNYCWorkLoad.Text.Trim()))
                    {
                        int PFTodLead = Convert.ToInt32(lblTodaysLeads.Text.Trim());
                        int PF24hrLead = Convert.ToInt32(lblTwentyFourHr.Text.Trim());
                        int PFWeekLead = Convert.ToInt32(lblThisWeek.Text.Trim());
                        int PFMonthLead = Convert.ToInt32(lblThisMonth.Text.Trim());
                        int PF48Lead = Convert.ToInt32(lblContfortyEighthr.Text.Trim());
                        int PF7DLead = Convert.ToInt32(lblContSevenDays.Text.Trim());
                        int PFCWLoad = Convert.ToInt32(lnkbtnWorkLoad.Text.Trim());
                        int PFNYC = Convert.ToInt32(lnkbtnNYCWorkLoad.Text.Trim());

                        TotlPFTodLead += PFTodLead;
                        TotlPF24hrLead += PF24hrLead;
                        TotlPFWeekLead += PFWeekLead;
                        TotlPFMonthLead += PFMonthLead;
                        TotlPF48Lead += PF48Lead;
                        TotlPF7DLead += PF7DLead;
                        TotlPFCWLoad += PFCWLoad;
                        TotlPFNYC += PFNYC;
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotlPFTodLead = (Label)e.Row.FindControl("lblTotlPFTodLead");
                Label lblTotlPF24hrLead = (Label)e.Row.FindControl("lblTotlPF24hrLead");
                Label lblTotlPFWeekLead = (Label)e.Row.FindControl("lblTotlPFWeekLead");
                Label lblTotlPFMonthLead = (Label)e.Row.FindControl("lblTotlPFMonthLead");
                Label lblTotlPF48Lead = (Label)e.Row.FindControl("lblTotlPF48Lead");
                Label lblTotlPF7DLead = (Label)e.Row.FindControl("lblTotlPF7DLead");
                Label lblTotlPFCWLoad = (Label)e.Row.FindControl("lblTotlPFCWLoad");
                Label lblTotlPFNYC = (Label)e.Row.FindControl("lblTotlPFNYC");

                if (lblTotlPFTodLead != null && lblTotlPF24hrLead != null && lblTotlPFWeekLead != null && lblTotlPFMonthLead != null && lblTotlPF48Lead != null && lblTotlPF7DLead != null && lblTotlPFCWLoad != null && lblTotlPFNYC != null)
                {
                    lblTotlPFTodLead.Text = Convert.ToString(TotlPFTodLead);
                    lblTotlPF24hrLead.Text = Convert.ToString(TotlPF24hrLead);
                    lblTotlPFWeekLead.Text = Convert.ToString(TotlPFWeekLead);
                    lblTotlPFMonthLead.Text = Convert.ToString(TotlPFMonthLead);
                    lblTotlPF48Lead.Text = Convert.ToString(TotlPF48Lead);
                    lblTotlPF7DLead.Text = Convert.ToString(TotlPF7DLead);
                    lblTotlPFCWLoad.Text = Convert.ToString(TotlPFCWLoad);
                    lblTotlPFNYC.Text = Convert.ToString(TotlPFNYC);
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.gvAllocate_RowDatabound.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Clear All Control Data. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnClear_Click(object sender, EventArgs e)
    {
        ClearAll();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Set Bulk Amount Of Leads To Each Consultant. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSet_Click(object sender, EventArgs e)
    {
        try
        {
            Page.Validate("Reset");
            int Count = 0;
            foreach (GridViewRow grow in gvAllocate.Rows)
            {
                CheckBox chkbx = (CheckBox)grow.FindControl("chkSelect");
                if (chkbx != null)
                {
                    if (chkbx.Checked)
                    {
                        Count++;
                    }
                }
            }
            ClearMsg();
            if ((Convert.ToInt32(txtBulkAmt.Text.Trim()) * Count) <= Convert.ToInt32(lnkbtnUnallocatedEnq.Text.Trim()))
            {
                lblSerErrMsg.Text = string.Empty;
                dvsererror.Visible = false;
                foreach (GridViewRow grviewrow in gvAllocate.Rows)
                {
                    CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkSelect");
                    TextBox txtNoOfLeads = (TextBox)grviewrow.FindControl("txtNoOfLeads");
                    if (chkbx != null && txtNoOfLeads != null)
                    {
                        if (chkbx.Checked)
                        {
                            txtNoOfLeads.Enabled = true;
                            txtNoOfLeads.Text = txtBulkAmt.Text.Trim();
                        }
                    }
                }
                ViewState["LeadsAddjusted"] = false;
            }
            else
            {
                Int32[] arr = AllocateLeads(Count, Convert.ToInt32(txtBulkAmt.Text.Trim()), Convert.ToInt32(lnkbtnUnallocatedEnq.Text.Trim()));
                int i = 0;
                if (arr.Length == Count)
                {
                    foreach (GridViewRow grviewrow in gvAllocate.Rows)
                    {
                        CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkSelect");
                        TextBox txtNoOfLeads = (TextBox)grviewrow.FindControl("txtNoOfLeads");
                        if (chkbx != null && txtNoOfLeads != null)
                        {
                            if (chkbx.Checked)
                            {
                                txtNoOfLeads.Enabled = true;
                                txtNoOfLeads.Text = arr[i].ToString().Trim();
                                i++;
                            }
                        }
                    }
                    ViewState["LeadsAddjusted"] = true;
                    lblSerSucMsg.Text = Resources.PFSalesResource.NotEnough.Trim();
                    dvaserSuccess.Visible = true;
                    lblSerErrMsg.Text = string.Empty;
                    dvsererror.Visible = false;
                }
                else
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.notEnoughLeads.Trim();
                    dvsererror.Visible = true;
                    ClearAll();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnSet_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Text Changed Event Of No Of Lead's Text Box. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtNoOfLeads_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ClearMsg();
            GridViewRow gr = (GridViewRow)((TextBox)sender).NamingContainer;
            if (gr != null)
            {
                CompareValidator cvNoOfLeadsVal = (CompareValidator)gr.FindControl("cvNoOfLeadsVal");
                if (cvNoOfLeadsVal != null)
                {
                    Page.Validate(cvNoOfLeadsVal.ValidationGroup);
                }
            }

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.txtNoOfLeads_TextChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Validation For Checking Sum Of Lead's Assigned to each Consultant & Total Available Leads. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void checkvalidLeadCount(object sender, ServerValidateEventArgs args)
    {
        try
        {
            int val = 0;
            foreach (GridViewRow grviewrow in gvAllocate.Rows)
            {
                CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkSelect");
                TextBox txtNoOfLeads = (TextBox)grviewrow.FindControl("txtNoOfLeads");
                if (chkbx != null && txtNoOfLeads != null)
                {
                    if (chkbx.Checked)
                    {
                        if (!string.IsNullOrEmpty(txtNoOfLeads.Text.Trim()))
                            val += Convert.ToInt32(txtNoOfLeads.Text.Trim());
                    }
                }
            }
            if (val > (Convert.ToInt32(lnkbtnUnallocatedEnq.Text.Trim())))
            {

                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.checkvalidLeadCount.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Assign Leads To Consultants. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAllocate_Click(object sender, EventArgs e)
    {
        try
        {
            Page.Validate("Allocate");
            Thread t3 = null;
            if (Page.IsValid)
            {
                List<LeadAssignment> lstAllocation = new List<LeadAssignment>();
                foreach (GridViewRow grviewrow in gvAllocate.Rows)
                {
                    CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkSelect");
                    TextBox txtNoOfLeads = (TextBox)grviewrow.FindControl("txtNoOfLeads");
                    HiddenField hdfConsultantId = (HiddenField)grviewrow.FindControl("hdfConsultantId");
                    HiddenField hdfFName = (HiddenField)grviewrow.FindControl("hdfFName");
                    Label lblContEmailId = (Label)grviewrow.FindControl("lblContEmailId");
                    Label lblConsultName = (Label)grviewrow.FindControl("lblConsultName");
                    if (chkbx != null && txtNoOfLeads != null && hdfConsultantId != null && lblContEmailId != null && lblConsultName != null)
                    {
                        if (!string.IsNullOrEmpty(hdfConsultantId.Value.Trim()) && !string.IsNullOrEmpty(txtNoOfLeads.Text.Trim()) && Convert.ToInt64(txtNoOfLeads.Text.Trim()) > 0)
                        {
                            LeadAssignment objLAllocation = new LeadAssignment();
                            objLAllocation.ConsultantId = Convert.ToInt64(hdfConsultantId.Value.Trim());
                            objLAllocation.Noofleads = Convert.ToInt32(txtNoOfLeads.Text.Trim());
                            if (!string.IsNullOrEmpty(lblContEmailId.Text.Trim()))
                                objLAllocation.ConsultantEmail = lblContEmailId.Text.Trim();
                            if (!string.IsNullOrEmpty(lblConsultName.Text.Trim()))
                                objLAllocation.ConsultantName = lblConsultName.Text.Trim();
                            if (!string.IsNullOrEmpty(hdfFName.Value.Trim()))
                                objLAllocation.ConsultFName = hdfFName.Value.Trim();
                            lstAllocation.Add(objLAllocation);
                        }
                    }
                }
                objProsp.lstAllocation = lstAllocation;
                objProsp.CreatedById = BasePage.UserSession.VirtualRoleId;
                objProsp.FromDate = Convert.ToDateTime(txtUnAlocFromDate.Text.Trim());
                objProsp.ToDate = Convert.ToDateTime(txtUnalocToDate.Text.Trim());

                DtResult = objProspectBM.AssignLeadsToConsultant(objProsp);
                //double Interval1 = Convert.ToDouble(ConfigurationManager.AppSettings["ActInterval"].ToString().Trim());
                //double Interval = 0;
                BindConsultants();

                if (DtResult != null && DtResult.Rows.Count > 0)
                {
                    ClearAll();
                    t3 = new Thread(sendEmailOnThread);
                    t3.Start();


                    //if (ViewState["LeadsAddjusted"] != null && !string.IsNullOrEmpty(ViewState["LeadsAddjusted"].ToString().Trim()) && Convert.ToBoolean(ViewState["LeadsAddjusted"].ToString().Trim()) == false)
                    //{
                    lblSerSucMsg.Text = Resources.PFSalesResource.LeadsAssignedSuccess.Trim();
                    //}
                    //else if (ViewState["LeadsAddjusted"] != null && !string.IsNullOrEmpty(ViewState["LeadsAddjusted"].ToString().Trim()) && Convert.ToBoolean(ViewState["LeadsAddjusted"].ToString().Trim()) == true)
                    //{
                    //    lblSerSucMsg.Text = Resources.PFSalesResource.LeadsAssignedSuccess.Trim();
                    //}
                    dvaserSuccess.Visible = true;
                    lblSerErrMsg.Text = string.Empty;
                    dvsererror.Visible = false;
                }
                else
                {
                    lblSerSucMsg.Text = string.Empty;
                    dvaserSuccess.Visible = false;
                    lblSerErrMsg.Text = Resources.PFSalesResource.LeadsAssignedError.Trim();
                    dvsererror.Visible = true;
                }
                t3.Join(1000);
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnAllocate_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 June 2013
    /// Description: Gridview Page Index Changing Event. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvprosp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvprosp.PageIndex = e.NewPageIndex;
            if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && ViewState["Flag"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()))
                BindProspGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), ViewState["Flag"].ToString().Trim(), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim());
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.gvprosp_PageIndexChanging Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 June 2013
    /// Description: Gridview Page Sorting Event Of GridView. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvprosp_Soring(object sender, GridViewSortEventArgs e)
    {
        try
        {
            Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = e.SortExpression;
            DefineProspectSortDirection();
            if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && ViewState["Flag"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()))
                BindProspGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), ViewState["Flag"].ToString().Trim(), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim());
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.gvprosp_Soring.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 June 2013
    /// Description: Row Data Bound Event Of GridView. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvprosp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (lblTotLeadView.Text.Trim().ToLower() == Resources.PFSalesResource.TodaysEnquiryDetails.Trim().ToLower())
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hdfConsultantId = (HiddenField)e.Row.FindControl("hdfConsultantId");
                    if (hdfConsultantId != null)
                    {
                        if (hdfConsultantId.Value.Trim() == "0" || hdfConsultantId.Value.Trim() == string.Empty)
                            e.Row.BackColor = System.Drawing.Color.FromName("#FFCDCD");
                        else if (Convert.ToInt64(hdfConsultantId.Value.Trim()) > 0)
                            e.Row.BackColor = System.Drawing.Color.FromName("#D6FFBC");
                    }
                }
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.BackColor = System.Drawing.Color.FromName("#EFF9FF");
                }
            }

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Label LblStatus;
            //    if (BasePage.UserSession.RoleId == 5)
            //        LblStatus = (Label)e.Row.FindControl("lblFCstatus");
            //    else
            //        LblStatus = (Label)e.Row.FindControl("lblstatus");
            //    if (LblStatus != null && !string.IsNullOrEmpty(LblStatus.Text.Trim()))
            //    {
            //        switch (LblStatus.Text.Trim().ToUpper())
            //        {
            //            case "ACTIVE":
            //                e.Row.BackColor = System.Drawing.Color.FromName("#E0FFFF");
            //                break;
            //            case "TENDER":
            //                e.Row.BackColor = System.Drawing.Color.FromName("#FFE4E1");
            //                break;
            //            case "LEAD":
            //                e.Row.BackColor = System.Drawing.Color.FromName("#FFFFFF");
            //                break;
            //            default:
            //                e.Row.BackColor = System.Drawing.Color.FromName("#DCF0FE");
            //                break;
            //        }
            //    }
            //}
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.gvprosp_RowDataBound.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 June 2013
    /// Description: Close Prospect Detail's Pop Up
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnPhPopClose_Click(object sender, EventArgs e)
    {
        Session["ConsultantId"] = null;
        Session["Status"] = null;
        pnlTotLeadViewPopUp.Visible = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 June 2013
    /// Description: View Prospect Detail's From Pop Up
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnView_Click(object sender, EventArgs e)
    {
        try
        {
            ClearMsg();
            Int64 ProspId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());

            GridViewRow gr = (GridViewRow)((LinkButton)sender).NamingContainer;
            HiddenField hdfConsultantId = (HiddenField)gr.FindControl("hdfConsultantId");
            if (ProspId > 0)
            {
                Response.Redirect("ManageActivities.aspx?from=la" + hdfConsultantId.Value + "&ProspectId=" + ProspId, false);
                // Commented on 10 Aug 2013 to redirect it to Full Manage Contact Screen
                //DataTable dt = objProspectBM.GetProspDetAssignedToConsult(0, DateTime.MinValue, DateTime.MaxValue, ProspId);
                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    lblName.Text = dt.Rows[0]["FName"].ToString().Trim() + " " + dt.Rows[0]["MName"].ToString().Trim() + " " + dt.Rows[0]["LName"].ToString().Trim();
                //    lblName.Text = lblName.Text.Trim().Replace("  ", " ");
                //    lblCarMake.Text = dt.Rows[0]["Make"].ToString().Trim();
                //    lblPhNo.Text = dt.Rows[0]["Phone"].ToString().Trim();
                //    lblMobile.Text = dt.Rows[0]["Mobile"].ToString().Trim();
                //    lblAltContNo.Text = dt.Rows[0]["AltContNo"].ToString().Trim();
                //    lblFax.Text = dt.Rows[0]["Fax"].ToString().Trim();
                //    lblEmail1.Text = dt.Rows[0]["Email1"].ToString().Trim();
                //    lblAlterEmail.Text = dt.Rows[0]["Email2"].ToString().Trim();
                //    lblAddLine1.Text = dt.Rows[0]["Add1"].ToString().Trim();
                //    lblAddLine2.Text = dt.Rows[0]["Add2"].ToString().Trim();
                //    lblAddLine3.Text = dt.Rows[0]["Add3"].ToString().Trim();
                //    lblCountry.Text = dt.Rows[0]["Country"].ToString().Trim();
                //    lblState.Text = dt.Rows[0]["StateName"].ToString().Trim();
                //    lblCity.Text = dt.Rows[0]["City"].ToString().Trim();
                //    lblPostalCode.Text = dt.Rows[0]["PostalCode"].ToString().Trim();
                //    if (!string.IsNullOrEmpty(dt.Rows[0]["ConsultantName"].ToString().Trim()))
                //        lblConsultant.Text = dt.Rows[0]["ConsultantName"].ToString().Trim();
                //    else
                //        lblConsultant.Text = "--";
                //    lblAddStatus.Text = dt.Rows[0]["Status"].ToString().Trim();
                //    lblSource.Text = dt.Rows[0]["RefSource"].ToString().Trim();
                //    lblMemNo.Text = dt.Rows[0]["MemberNo"].ToString().Trim();
                //    lblFConsultant.Text = dt.Rows[0]["FConsultant"].ToString().Trim();
                //    lblEnqDate.Text = dt.Rows[0]["EnquiryDate"].ToString().Trim();
                //    lblltrLeadNo.Visible = lblLeadNo.Visible = lnkbtnNext.Visible = lnkbtnPrev.Visible = false;
                //    pnlWorkLoadDetUp.Visible = true;
                //}
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnView_Click.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 June 2013
    /// Description: Selected Index Changed Event Of Page Size's Drop Down List
    /// </summary>
    /// <param name="Sender"></param>
    /// <param name="e"></param>
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ClearMsg();
            if (Convert.ToInt16(ddlPageSize.SelectedValue.Trim()) == 1)
            {
                Int32 intAllCount = Convert.ToInt32(ViewState["TotalCount"]);
                gvprosp.PageSize = intAllCount;
            }
            else
            {
                gvprosp.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue.Trim());
            }
            if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && ViewState["Flag"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()))
                BindProspGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), ViewState["Flag"].ToString().Trim(), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim());
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.ddlPageSize_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 June 2013
    /// Description: Total Enquiry Count's Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnTodTotEnq_Click(object sender, EventArgs e)
    {
        try
        {
            Session["CurrentPageIndex"] = 1;
            Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "CreatedDate";
            Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = Cls_Constant.VIEWSTATE_DESC;
            ViewState["FilteredData"] = ViewState["ProspData"] = null;
            ViewState["FromDate"] = txtTotEntFrmDate.Text.Trim();
            ViewState["ToDate"] = txtTotEntToDate.Text.Trim();
            ViewState["Flag"] = "A";
            ViewState["ConsultantId"] = "0";
            if (Session["Flag"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Flag"])))
                ViewState["FCFlag"] = Convert.ToString(Session["Flag"]);
            else
                ViewState["FCFlag"] = "PF";
            lblTotLeadView.Text = Resources.PFSalesResource.TodaysEnquiryDetails.Trim();
            lblTitle.Text = Resources.PFSalesResource.TodaysEnquiryDetails.Trim();
            if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && ViewState["Flag"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()))
                BindProspGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), ViewState["Flag"].ToString().Trim(), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim());
            pnlTotLeadViewPopUp.Visible = true;
            //BindNYCLeadGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim(), ViewState["Flag"].ToString().Trim());
            //pnlNYCViewPopUp.Visible = true;
            //txtUnAllEnqLegend.Visible =txtAllEnqLegend.Visible = lblUnAlloCateLegend.Visible = lblAllocatedLegend.Visible = false;

            //dvFilterAlloc.Visible = dvFilterUnAlloc.Visible = dvClearFilter.Visible = lnkbtnClearFilter.Visible = lnkbtnFilterUnall.Visible = lnkbtnFilterAlloc.Visible = false;
            //pnlTotLeadViewPopUp.Visible = true;



            dvFilterUnAlloc.Visible = dvFilterAlloc.Visible = lnkbtnFilterAlloc.Visible = lnkbtnFilterUnall.Visible = true;
            dvClearFilter.Visible = lnkbtnClearFilter.Visible = false;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnTodTotEnq_Click.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 June 2013
    /// Description: Total Enquiry Count's Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnTodTotEnq1_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["FilteredData"] = ViewState["ProspData"] = null;
            ViewState["FromDate"] = txtTotEntFrmDate1.Text.Trim();
            ViewState["ToDate"] = txtTotEntToDate1.Text.Trim();
            ViewState["Flag"] = "A";
            ViewState["ConsultantId"] = "0";
            ViewState["FCFlag"] = "PF";
            lblTotLeadView.Text = Resources.PFSalesResource.TodaysEnquiryDetails.Trim();
            if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && ViewState["Flag"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()))
                BindProspGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), ViewState["Flag"].ToString().Trim(), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim());
            pnlTotLeadViewPopUp.Visible = true;
            dvFilterUnAlloc.Visible = dvFilterAlloc.Visible = lnkbtnFilterAlloc.Visible = lnkbtnFilterUnall.Visible = true;
            dvClearFilter.Visible = lnkbtnClearFilter.Visible = false;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnTodTotEnq_Click.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 June 2013
    /// Description: Unallocated Enquiry Count's Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnUnallocatedEnq_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["FilteredData"] = ViewState["ProspData"] = null;
            ViewState["FromDate"] = txtUnAlocFromDate.Text.Trim();
            ViewState["ToDate"] = txtUnalocToDate.Text.Trim();
            ViewState["Flag"] = "U";
            ViewState["ConsultantId"] = 0;
            ViewState["FCFlag"] = "PF";
            lblTotLeadView.Text = Resources.PFSalesResource.UnAlocatedEnqDetails.Trim();
            if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && ViewState["Flag"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()))
                BindProspGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), ViewState["Flag"].ToString().Trim(), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim());
            //txtUnAllEnqLegend.Visible =txtAllEnqLegend.Visible = lblUnAlloCateLegend.Visible = lblAllocatedLegend.Visible = false;
            dvFilterAlloc.Visible = dvFilterUnAlloc.Visible = dvClearFilter.Visible = lnkbtnClearFilter.Visible = lnkbtnFilterUnall.Visible = lnkbtnFilterAlloc.Visible = false;
            pnlTotLeadViewPopUp.Visible = true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnUnallocatedEnq_Click.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 June 2013
    /// Description: Unallocated Enquiry Count's Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnUnallocatedEnq1_Click(object sender, EventArgs e)
    {
        try
        {
            Session["CurrentPageIndex"] = 1;
            Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "CreatedDate";
            Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = Cls_Constant.VIEWSTATE_DESC;
            ClearMsg();
            ViewState["FilteredData"] = ViewState["ProspData"] = null;
            ViewState["FromDate"] = txtUnAlocFromDate1.Text.Trim();
            ViewState["ToDate"] = txtUnalocToDate1.Text.Trim();
            Session["Status"] = ViewState["Flag"] = "U";
            Session["ConsultantId"] = ViewState["ConsultantId"] = 0;
            Session["Flag"] = ViewState["FCFlag"] = "PF";
            lblTotLeadView.Text = Resources.PFSalesResource.UnAlocatedEnqDetails.Trim();
            lblTitle.Text = Resources.PFSalesResource.NewEnquiries.Trim();
            lnkbtnBulkReAssign.Visible = false;
            lnkbtnBulkAssign.Visible = true;
            ddlPageSizeNYC.SelectedValue = "50";
            Session["TotalRecCount"] = "50";
            if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && ViewState["Flag"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()))
                //Comment By Kalpana: Date : 29 Aug 13
                //Des: Show more column
                // BindProspGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), ViewState["Flag"].ToString().Trim(), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim());

                BindNYCLeadGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim(), ViewState["Flag"].ToString().Trim());

            //txtUnAllEnqLegend.Visible =txtAllEnqLegend.Visible = lblUnAlloCateLegend.Visible = lblAllocatedLegend.Visible = false;

            //dvFilterAlloc.Visible = dvFilterUnAlloc.Visible = dvClearFilter.Visible = lnkbtnClearFilter.Visible = lnkbtnFilterUnall.Visible = lnkbtnFilterAlloc.Visible = false;
            //pnlTotLeadViewPopUp.Visible = true;
            dvFilterAlloc.Visible = dvFilterUnAlloc.Visible = dvClearFilter.Visible = lnkbtnClearFilter.Visible = lnkbtnFilterUnall.Visible = lnkbtnFilterAlloc.Visible = false;
            pnlNYCViewPopUp.Visible = true;

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnUnallocatedEnq1_Click.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 June 2013
    /// Description: Close Work Load Details's Close Pop Up.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkWorkLoadClose_Click(object sender, EventArgs e)
    {
        if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && ViewState["Flag"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()))
            BindProspGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), ViewState["Flag"].ToString().Trim(), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim());
        pnlWorkLoadDetUp.Visible = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 June 2013
    /// Description: View Previous Work Load Entry
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnPrev_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hdfCurrentLoadNo.Value.Trim()))
        {
            if ((Convert.ToInt32(hdfCurrentLoadNo.Value)) == 2)
            {
                lnkbtnPrev.Visible = false;
            }
            hdfCurrentLoadNo.Value = Convert.ToString(Convert.ToInt32(hdfCurrentLoadNo.Value) - 1).Trim();
            if (ViewState["WorkLoad"] != null && ((DataTable)(ViewState["WorkLoad"])) != null && ((DataTable)(ViewState["WorkLoad"])).Rows.Count > 0)
            {
                if (Convert.ToInt32(hdfCurrentLoadNo.Value.Trim()) < ((DataTable)(ViewState["WorkLoad"])).Rows.Count)
                    lnkbtnNext.Visible = true;
                DataRow[] dr = ((DataTable)(ViewState["WorkLoad"])).Select("RowNo='" + hdfCurrentLoadNo.Value + "'");
                if (dr != null && dr.Length > 0)
                {
                    lblName.Text = dr[0]["FName"].ToString().Trim() + " " + dr[0]["MName"].ToString().Trim() + " " + dr[0]["LName"].ToString().Trim();
                    lblName.Text = lblName.Text.Trim().Replace("  ", " ");
                    lblCarMake.Text = dr[0]["Make"].ToString().Trim();
                    lblPhNo.Text = dr[0]["Phone"].ToString().Trim();
                    lblMobile.Text = dr[0]["Mobile"].ToString().Trim();
                    lblAltContNo.Text = dr[0]["AltContNo"].ToString().Trim();
                    lblFax.Text = dr[0]["Fax"].ToString().Trim();
                    lblEmail1.Text = dr[0]["Email1"].ToString().Trim();
                    lblAlterEmail.Text = dr[0]["Email2"].ToString().Trim();
                    lblAddLine1.Text = dr[0]["Add1"].ToString().Trim();
                    lblAddLine2.Text = dr[0]["Add2"].ToString().Trim();
                    lblAddLine3.Text = dr[0]["Add3"].ToString().Trim();
                    lblCountry.Text = dr[0]["Country"].ToString().Trim();
                    lblState.Text = dr[0]["StateName"].ToString().Trim();
                    lblCity.Text = dr[0]["City"].ToString().Trim();
                    lblPostalCode.Text = dr[0]["PostalCode"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dr[0]["ConsultantName"].ToString().Trim()))
                        lblConsultant.Text = dr[0]["ConsultantName"].ToString().Trim();
                    else
                        lblConsultant.Text = "--";
                    lblAddStatus.Text = dr[0]["Status"].ToString().Trim();
                    lblSource.Text = dr[0]["RefSource"].ToString().Trim();
                    lblMemNo.Text = dr[0]["MemberNo"].ToString().Trim();
                    lblFConsultant.Text = dr[0]["FConsultant"].ToString().Trim();
                    lblEnqDate.Text = dr[0]["EnquiryDate"].ToString().Trim();
                    lblLeadNo.Text = hdfCurrentLoadNo.Value.Trim();
                }
            }
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 June 2013
    /// Description: View Next Work Load Entry
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(hdfCurrentLoadNo.Value.Trim()))
        {
            if ((Convert.ToInt32(hdfCurrentLoadNo.Value)) >= 1)
            {
                lnkbtnPrev.Visible = true;
            }
            else
            { lnkbtnPrev.Visible = false; }

            hdfCurrentLoadNo.Value = Convert.ToString(Convert.ToInt32(hdfCurrentLoadNo.Value) + 1).Trim();
            if (ViewState["WorkLoad"] != null && ((DataTable)(ViewState["WorkLoad"])) != null && ((DataTable)(ViewState["WorkLoad"])).Rows.Count > 0)
            {
                if (Convert.ToInt32(hdfCurrentLoadNo.Value.Trim()) == ((DataTable)(ViewState["WorkLoad"])).Rows.Count)
                    lnkbtnNext.Visible = false;
                DataRow[] dr = ((DataTable)(ViewState["WorkLoad"])).Select("RowNo='" + hdfCurrentLoadNo.Value + "'");
                if (dr != null && dr.Length > 0)
                {
                    lblName.Text = dr[0]["FName"].ToString().Trim() + " " + dr[0]["MName"].ToString().Trim() + " " + dr[0]["LName"].ToString().Trim();
                    lblName.Text = lblName.Text.Trim().Replace("  ", " ");
                    lblCarMake.Text = dr[0]["Make"].ToString().Trim();
                    lblPhNo.Text = dr[0]["Phone"].ToString().Trim();
                    lblMobile.Text = dr[0]["Mobile"].ToString().Trim();
                    lblAltContNo.Text = dr[0]["AltContNo"].ToString().Trim();
                    lblFax.Text = dr[0]["Fax"].ToString().Trim();
                    lblEmail1.Text = dr[0]["Email1"].ToString().Trim();
                    lblAlterEmail.Text = dr[0]["Email2"].ToString().Trim();
                    lblAddLine1.Text = dr[0]["Add1"].ToString().Trim();
                    lblAddLine2.Text = dr[0]["Add2"].ToString().Trim();
                    lblAddLine3.Text = dr[0]["Add3"].ToString().Trim();
                    lblCountry.Text = dr[0]["Country"].ToString().Trim();
                    lblState.Text = dr[0]["StateName"].ToString().Trim();
                    lblCity.Text = dr[0]["City"].ToString().Trim();
                    lblPostalCode.Text = dr[0]["PostalCode"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dr[0]["ConsultantName"].ToString().Trim()))
                        lblConsultant.Text = dr[0]["ConsultantName"].ToString().Trim();
                    else
                        lblConsultant.Text = "--";
                    lblAddStatus.Text = dr[0]["Status"].ToString().Trim();
                    lblSource.Text = dr[0]["RefSource"].ToString().Trim();
                    lblMemNo.Text = dr[0]["MemberNo"].ToString().Trim();
                    lblFConsultant.Text = dr[0]["FConsultant"].ToString().Trim();
                    lblEnqDate.Text = dr[0]["EnquiryDate"].ToString().Trim();
                    lblLeadNo.Text = hdfCurrentLoadNo.Value.Trim();
                }
            }
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 June 2013
    /// Description: View Work Load Entries
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnCurrWorkLoad_Click(object sender, EventArgs e)
    {
        try
        {
            Session["CurrentPageIndex"] = 1;
            Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "CreatedDate";
            Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = Cls_Constant.VIEWSTATE_DESC;
            ClearMsg();
            Int64 ConsultantId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
            LinkButton lnkbtnCurrWorkLoad = (LinkButton)sender;
            ddlPageSizeNYC.SelectedValue = "50";
            Session["TotalRecCount"] = "50";
            if (ConsultantId > 0)
            {
                lnkbtnBulkReAssign.Visible = true;
                lnkbtnBulkAssign.Visible = false;
                Session["ConsultantId"] = ConsultantId;
                Session["Status"] = "CUR";
                DataTable dt = objProspectBM.GetCountProspDetAssignedToConsult(ConsultantId, Convert.ToDateTime(txtUnAlocFromDate.Text.Trim()), Convert.ToDateTime(txtUnalocToDate.Text.Trim()), 0);
                if (dt != null && dt.Rows.Count > 0 && Convert.ToInt64(dt.Rows[0]["TtlCount"]) > 0)
                {
                    ViewState["FilteredData"] = ViewState["ProspData"] = null;
                    ViewState["FromDate"] = txtUnAlocFromDate.Text.Trim();
                    ViewState["ToDate"] = txtUnalocToDate.Text.Trim();
                    ViewState["Flag"] = "CUR";
                    ViewState["ConsultantId"] = ConsultantId;
                    Session["Flag"] = ViewState["FCFlag"] = "PF";
                    lblTotLeadView.Text = Resources.PFSalesResource.WorkloadDetails.Trim();
                    lblTitle.Text = Resources.PFSalesResource.WorkloadDetails.Trim();
                    if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && ViewState["Flag"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()))
                        BindNYCLeadGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim(), ViewState["Flag"].ToString().Trim());
                    dvFilterAlloc.Visible = dvFilterUnAlloc.Visible = dvClearFilter.Visible = lnkbtnClearFilter.Visible = lnkbtnFilterUnall.Visible = lnkbtnFilterAlloc.Visible = false;
                    pnlNYCViewPopUp.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnCurrWorkLoad_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 7 June 2013
    /// Description: Filter Grid For Unallocated Leads
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFilterUnall_Click(object sender, EventArgs e)
    {
        try
        {
            Session["CurrentPageIndex"] = 1;
            Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "CreatedDate";
            Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = Cls_Constant.VIEWSTATE_DESC;
            ViewState["FilteredData"] = ViewState["ProspData"] = null;
            ViewState["FromDate"] = txtFCTotEntFrmDate.Text.Trim();
            ViewState["ToDate"] = txtFCTotEntToDate.Text.Trim();
            ViewState["Flag"] = "U";
            ViewState["ConsultantId"] = "0";
            if (Session["Flag"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Flag"])))
                ViewState["FCFlag"] = Convert.ToString(Session["Flag"]);
            lblTotLeadView.Text = Resources.PFSalesResource.TodaysEnquiryDetails.Trim();
            lblTitle.Text = Resources.PFSalesResource.TodaysEnquiryDetails.Trim();
            if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && ViewState["Flag"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()))
                BindProspGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), ViewState["Flag"].ToString().Trim(), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim());
            dvClearFilter.Visible = lnkbtnClearFilter.Visible = true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnFilterUnall_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 7 June 2013
    /// Description: Filter Grid For Allocated Leads
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFilterAlloc_Click(object sender, EventArgs e)
    {
        try
        {
            Session["CurrentPageIndex"] = 1;
            Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "CreatedDate";
            Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = Cls_Constant.VIEWSTATE_DESC;
            ViewState["FilteredData"] = ViewState["ProspData"] = null;
            ViewState["FromDate"] = txtFCTotEntFrmDate.Text.Trim();
            ViewState["ToDate"] = txtFCTotEntToDate.Text.Trim();
            ViewState["Flag"] = "D";
            ViewState["ConsultantId"] = "0";
            if (Session["Flag"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Flag"])))
                ViewState["FCFlag"] = Convert.ToString(Session["Flag"]);
            lblTotLeadView.Text = Resources.PFSalesResource.TodaysEnquiryDetails.Trim();
            lblTitle.Text = Resources.PFSalesResource.TodaysEnquiryDetails.Trim();
            if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && ViewState["Flag"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()))
                BindProspGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), ViewState["Flag"].ToString().Trim(), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim());
            dvClearFilter.Visible = lnkbtnClearFilter.Visible = true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnFilterAlloc_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 7 June 2013
    /// Description: Clear Filter Grid For Leads
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnClearFilter_Click(object sender, EventArgs e)
    {
        try
        {
            Session["CurrentPageIndex"] = 1;
            Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "CreatedDate";
            Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = Cls_Constant.VIEWSTATE_DESC;
            ViewState["FilteredData"] = ViewState["ProspData"] = null;
            ViewState["FromDate"] = txtTotEntFrmDate.Text.Trim();
            ViewState["ToDate"] = txtTotEntToDate.Text.Trim();
            ViewState["Flag"] = "A";
            ViewState["ConsultantId"] = "0";
            if (Session["Flag"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Flag"])))
                ViewState["FCFlag"] = Convert.ToString(Session["Flag"]);
            else
                ViewState["FCFlag"] = "PF";
            dvFilterUnAlloc.Visible = dvFilterAlloc.Visible = lnkbtnFilterUnall.Visible = lnkbtnFilterAlloc.Visible = true;
            dvClearFilter.Visible = lnkbtnClearFilter.Visible = false;
            lblTotLeadView.Text = Resources.PFSalesResource.TodaysEnquiryDetails.Trim();
            lblTitle.Text = Resources.PFSalesResource.TodaysEnquiryDetails.Trim();
            if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && ViewState["Flag"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()))
                BindProspGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), ViewState["Flag"].ToString().Trim(), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim());

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnFilterAlloc_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Row Data Bound Event Of Fleet Team Lead's Gridview
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvTeamLead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlTeamLeedConsultant = (DropDownList)e.Row.FindControl("ddlTeamLeedConsultant");
                HiddenField hdfConsultEmail = (HiddenField)e.Row.FindControl("hdfConsultEmail");
                HiddenField hdfConsultFName = (HiddenField)e.Row.FindControl("hdfConsultFName");
                if (ddlTeamLeedConsultant != null)
                {
                    BindFleetTeamConsult(ddlTeamLeedConsultant, hdfConsultEmail, hdfConsultFName);
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.gvTeamLead_RowDataBound.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Clear Fleet Team Lead Allocation's Gridview Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnClearTeamAllocate_Click(object sender, EventArgs e)
    {
        BindFleetLeads();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Allocate Fleet Team Lead Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnLeadTeamAllocate_Click(object sender, EventArgs e)
    {
        try
        {
            Page.Validate("TeamAllocate");
            if (Page.IsValid)
            {
                foreach (GridViewRow grviewrow in gvTeamLead.Rows)
                {
                    DropDownList ddlTeamLeedConsultant = (DropDownList)grviewrow.FindControl("ddlTeamLeedConsultant");
                    HiddenField hdfProspectId = (HiddenField)grviewrow.FindControl("hdfProspectId");
                    HiddenField hdfConsultEmail = (HiddenField)grviewrow.FindControl("hdfConsultEmail");
                    HiddenField hdfConsultFName = (HiddenField)grviewrow.FindControl("hdfConsultFName");
                    //double Interval1 = Convert.ToDouble(ConfigurationManager.AppSettings["ActInterval"].ToString().Trim());
                    //double Interval = 0;
                    if (ddlTeamLeedConsultant != null && hdfProspectId != null && hdfConsultEmail != null && hdfConsultFName != null)
                    {
                        if (!string.IsNullOrEmpty(hdfConsultEmail.Value.Trim()) && !string.IsNullOrEmpty(hdfProspectId.Value.Trim()) && Convert.ToInt64(ddlTeamLeedConsultant.SelectedValue.Trim()) > 0 && !string.IsNullOrEmpty(hdfConsultFName.Value.Trim()))
                        {
                            objProsp.ConsultId = Convert.ToInt64(ddlTeamLeedConsultant.SelectedValue.Trim());
                            objProsp.ProspId = Convert.ToInt64(hdfProspectId.Value.Trim());
                            objProsp.CreatedById = BasePage.UserSession.VirtualRoleId;
                            DataTable DtResult = objProspectBM.AssignFleetTeamLeads(objProsp);
                            if (DtResult != null && DtResult.Rows.Count > 0)
                            {
                                SendMail(hdfConsultEmail.Value.Trim(), 1, hdfConsultFName.Value.Trim(), true);//
                                for (int i = 0; i < DtResult.Rows.Count; i++)
                                {
                                    if (!string.IsNullOrEmpty(Convert.ToString(DtResult.Rows[i]["IsFleetLead"]).Trim()) && Convert.ToBoolean(DtResult.Rows[i]["IsFleetLead"]))
                                        SendMail(hdfConsultEmail.Value.Trim(), 1, hdfConsultFName.Value.Trim(), true);
                                    // SaveDefaultActivity(DtResult.Rows[i]["ProspFName"].ToString().Trim(), Convert.ToInt64(DtResult.Rows[i]["Id"].ToString().Trim()), Convert.ToInt64(DtResult.Rows[i]["ConsultantId"].ToString().Trim()));
                                    SendProspectMail(DtResult.Rows[i]["Email"].ToString().Trim(), DtResult.Rows[i]["ProspFName"].ToString().Trim(), DtResult.Rows[i]["ConsultantName"].ToString().Trim(), DtResult.Rows[i]["ConsultPhone"].ToString().Trim(), DtResult.Rows[i]["ConsultEmail"].ToString().Trim(), DtResult.Rows[i]["EnquiryDate"].ToString().Trim(), DtResult.Rows[i]["Ext"].ToString().Trim(), DtResult.Rows[i]["ConsultName"].ToString().Trim());
                                    //if ((i % 2) > 0)
                                    //    Interval = Interval + Interval1;
                                }
                                BindFleetLeads();
                                lblSerSucMsg.Text = Resources.PFSalesResource.LeadsAssignedSuccess.Trim();
                                dvaserSuccess.Visible = true;
                                lblSerErrMsg.Text = string.Empty;
                                dvsererror.Visible = false;
                            }
                            else
                            {
                                lblSerSucMsg.Text = string.Empty;
                                dvaserSuccess.Visible = false;
                                lblSerErrMsg.Text = Resources.PFSalesResource.LeadsAssignedError.Trim();
                                dvsererror.Visible = true;
                            }
                        }
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnLeadTeamAllocate_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Selected Index Changed Event Of Fleet Team Lead Consultant's Drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlTeamLeedConsultant_SelectedIndexChanged(object sender, EventArgs e)
    {
        HiddenField hdfConsultEmail = (HiddenField)(((GridViewRow)(((DropDownList)sender).NamingContainer)).FindControl("hdfConsultEmail"));
        HiddenField hdfConsultFName = (HiddenField)(((GridViewRow)(((DropDownList)sender).NamingContainer)).FindControl("hdfConsultFName"));
        if (((DropDownList)sender).SelectedValue != "0" && ((DropDownList)sender).SelectedValue != "-1")
        {
            if (hdfConsultEmail != null && hdfConsultFName != null)
            {
                BindConsultDetails(Convert.ToInt64(((DropDownList)sender).SelectedValue.Trim()), hdfConsultEmail, hdfConsultFName);
            }
            fleetTeamLeadAlocate();
        }
        else if (((DropDownList)sender).SelectedValue == "-1")
        {
            if (Session["SelectedIndex"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["SelectedIndex"]).Trim()))
            {
                int index = Convert.ToInt32(Convert.ToString(Session["SelectedIndex"]).Trim());
                int skipIndex = ((DropDownList)sender).Items.IndexOf(((DropDownList)sender).Items.FindByText(Resources.PFSalesResource.ConsultantAway.Trim()));
                if (index + 1 != skipIndex)
                {
                    foreach (ListItem item in ((DropDownList)sender).Items)
                    {
                        item.Attributes.CssStyle["display"] = "none";
                        if (((DropDownList)sender).Items.IndexOf(item) == index + 1 || item.Value == "0" || item.Value == "-1")
                        {
                            item.Attributes.CssStyle["display"] = "block";
                        }
                    }
                    Session["SelectedIndex"] = index + 1;
                    DataTable DtCons = objEmpBM.GetEmpDetFromVirId(Convert.ToInt64(((DropDownList)sender).Items[index + 1].Value.Trim()));
                    if (DtCons != null && DtCons.Rows.Count > 0)
                    {
                        hdfFTCtoAssign.Value = Convert.ToString(DtCons.Rows[0]["UserVID"]).Trim();
                        //ddlConsultants.SelectedValue = hdfFTCtoAssign.Value.Trim();
                        hdfConsultEmail.Value = Convert.ToString(DtCons.Rows[0]["Email1"]).Trim();
                        hdfConsultFName.Value = Convert.ToString(DtCons.Rows[0]["FName"]).Trim();
                    }
                }
                else
                {
                    //DataTable Dt1 = objProspectBM.GetTeamLeadConsultToAssign();
                    //if (Dt1 != null && Dt1.Rows.Count > 0)
                    //{
                    //    hdfFTCtoAssign.Value = Convert.ToString(Dt1.Rows[0]["VirtualRoleId"]).Trim();
                    //    //ddlConsultants.SelectedValue = hdfFTCtoAssign.Value.Trim();
                    //    hdfConsultEmail.Value = Convert.ToString(Dt1.Rows[0]["Email1"]).Trim();
                    //    hdfConsultFName.Value = Convert.ToString(Dt1.Rows[0]["FName"]).Trim();
                    foreach (ListItem item in ((DropDownList)sender).Items)
                    {
                        item.Attributes.CssStyle["display"] = "none";
                        if (item.Value == "0" || item.Value == "-1" || ((DropDownList)sender).Items.IndexOf(item) == 1)
                        {
                            item.Attributes.CssStyle["display"] = "block";
                        }
                    }
                    Session["SelectedIndex"] = 1;//((DropDownList)sender).Items.IndexOf(((DropDownList)sender).Items.FindByValue(Convert.ToString(Dt1.Rows[0]["VirtualRoleId"]).Trim()));
                    //    }
                }
            }
            ((DropDownList)sender).SelectedValue = "0";
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 July 2013
    /// Description: Timer Tick Event For Binding Fleet Leads
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void tmrBindFleet_Tick(object sender, EventArgs e)
    {
        BindFleetLeads();
    }

    #endregion

    #region "FC LEAD ALLOCATION"

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 August 2013
    /// Description: Unallocated Enquiry Count's Button Click Event for FC Consultants
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFCUnallocatedEnq1_Click(object sender, EventArgs e)
    {
        try
        {
            Session["CurrentPageIndex"] = 1;
            Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "CreatedDate";
            Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = Cls_Constant.VIEWSTATE_DESC;
            ClearMsg();
            ViewState["FilteredData"] = ViewState["ProspData"] = null;
            ViewState["FromDate"] = txtUnAlocFromDate1.Text.Trim();
            ViewState["ToDate"] = txtUnalocToDate1.Text.Trim();
            Session["Status"] = ViewState["Flag"] = "U";
            Session["ConsultantId"] = ViewState["ConsultantId"] = 0;
            Session["Flag"] = ViewState["FCFlag"] = "FC";
            lnkbtnBulkReAssign.Visible = false;
            lnkbtnBulkAssign.Visible = true;
            ddlPageSizeNYC.SelectedValue = "50";
            Session["TotalRecCount"] = "50";
            lblTotLeadView.Text = Resources.PFSalesResource.UnAlocatedEnqDetails.Trim();
            lblTitle.Text = Resources.PFSalesResource.NewEnquiries.Trim();
            if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && ViewState["Flag"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()))

                BindNYCLeadGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim(), ViewState["Flag"].ToString().Trim());
            dvFilterAlloc.Visible = dvFilterUnAlloc.Visible = dvClearFilter.Visible = lnkbtnClearFilter.Visible = lnkbtnFilterUnall.Visible = lnkbtnFilterAlloc.Visible = false;
            pnlNYCViewPopUp.Visible = true;
            //    BindProspGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), ViewState["Flag"].ToString().Trim(), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim());
            //dvFilterAlloc.Visible = dvFilterUnAlloc.Visible = dvClearFilter.Visible = lnkbtnClearFilter.Visible = lnkbtnFilterUnall.Visible = lnkbtnFilterAlloc.Visible = false;
            //pnlTotLeadViewPopUp.Visible = true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnFCUnallocatedEnq1_Click.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Selected Index Changed Event Of FC's Fleet Team Lead Consultant's Drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlFCTeamLeedConsultant_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (((DropDownList)sender).SelectedValue != "0")
        {
            HiddenField hdfConsultEmail = (HiddenField)(((GridViewRow)(((DropDownList)sender).NamingContainer)).FindControl("hdfFCConsultEmail"));
            HiddenField hdfConsultFName = (HiddenField)(((GridViewRow)(((DropDownList)sender).NamingContainer)).FindControl("hdfFCConsultFName"));
            if (hdfConsultEmail != null && hdfConsultFName != null)
            {
                BindFCConsultDetails(Convert.ToInt64(((DropDownList)sender).SelectedValue.Trim()), hdfConsultEmail, hdfConsultFName);
            }
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Row Data Bound Event Of FC's Fleet Team Lead's Gridview
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFCTeamLead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlTeamLeedConsultant = (DropDownList)e.Row.FindControl("ddlFCTeamLeedConsultant");
                HiddenField hdfConsultEmail = (HiddenField)e.Row.FindControl("hdfFCConsultEmail");
                HiddenField hdfConsultFName = (HiddenField)e.Row.FindControl("hdfFCConsultFName");
                if (ddlTeamLeedConsultant != null)
                {
                    BindFCFleetTeamConsult(ddlTeamLeedConsultant, hdfConsultEmail, hdfConsultFName);
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.gvTeamLead_RowDataBound.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Clear FC's Fleet Team Lead Allocation's Gridview Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFCClearTeamAllocate_Click(object sender, EventArgs e)
    {
        BindFCFleetLeads();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Allocate Fleet Team Lead Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFCLeadTeamAllocate_Click(object sender, EventArgs e)
    {
        try
        {
            Page.Validate("FCTeamAllocate");
            if (Page.IsValid)
            {
                foreach (GridViewRow grviewrow in gvTeamLead.Rows)
                {
                    DropDownList ddlTeamLeedConsultant = (DropDownList)grviewrow.FindControl("ddlFCTeamLeedConsultant");
                    HiddenField hdfProspectId = (HiddenField)grviewrow.FindControl("hdfFCProspectId");
                    HiddenField hdfConsultEmail = (HiddenField)grviewrow.FindControl("hdfFCConsultEmail");
                    HiddenField hdfConsultFName = (HiddenField)grviewrow.FindControl("hdfFCConsultFName");
                    //double Interval1 = Convert.ToDouble(ConfigurationManager.AppSettings["ActInterval"].ToString().Trim());
                    //double Interval = 0;
                    if (ddlTeamLeedConsultant != null && hdfProspectId != null && hdfConsultEmail != null && hdfConsultFName != null)
                    {
                        if (!string.IsNullOrEmpty(hdfConsultEmail.Value.Trim()) && !string.IsNullOrEmpty(hdfProspectId.Value.Trim()) && Convert.ToInt64(ddlTeamLeedConsultant.SelectedValue.Trim()) > 0 && !string.IsNullOrEmpty(hdfConsultFName.Value.Trim()))
                        {
                            objProsp.ConsultId = Convert.ToInt64(ddlTeamLeedConsultant.SelectedValue.Trim());
                            objProsp.ProspId = Convert.ToInt64(hdfProspectId.Value.Trim());
                            objProsp.CreatedById = BasePage.UserSession.VirtualRoleId;
                            DataTable DtResult = objProspectBM.AssignFCFleetTeamLeads(objProsp);
                            if (DtResult != null && DtResult.Rows.Count > 0)
                            {
                                SendMail(hdfConsultEmail.Value.Trim(), 1, hdfConsultFName.Value.Trim(), false);//
                                for (int i = 0; i < DtResult.Rows.Count; i++)
                                {
                                    SaveDefaultActivity(DtResult.Rows[i]["ProspFName"].ToString().Trim(), Convert.ToInt64(DtResult.Rows[i]["Id"].ToString().Trim()), Convert.ToInt64(DtResult.Rows[i]["ConsultantId"].ToString().Trim()));
                                    // SendProspectMail(DtResult.Rows[i]["Email"].ToString().Trim(), DtResult.Rows[i]["ProspFName"].ToString().Trim(), DtResult.Rows[i]["ConsultantName"].ToString().Trim(), DtResult.Rows[i]["ConsultPhone"].ToString().Trim(), DtResult.Rows[i]["ConsultEmail"].ToString().Trim(), DtResult.Rows[i]["EnquiryDate"].ToString().Trim(), DtResult.Rows[i]["Ext"].ToString().Trim());
                                    //if ((i % 2) > 0)
                                    //    Interval = Interval + Interval1;
                                }
                                BindFCFleetLeads();
                                lblFCSerSuccess.Text = Resources.PFSalesResource.LeadsAssignedSuccess.Trim();
                                dvFCSerSuccess.Visible = true;
                                lblFCSerError.Text = string.Empty;
                                dvFCserError.Visible = false;
                            }
                            else
                            {
                                lblFCSerSuccess.Text = string.Empty;
                                dvFCSerSuccess.Visible = false;
                                lblFCSerError.Text = Resources.PFSalesResource.LeadsAssignedError.Trim();
                                dvFCserError.Visible = true;
                            }
                        }
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnFCLeadTeamAllocate_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: View Work Load Entries
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFCCurrWorkLoad_Click(object sender, EventArgs e)
    {
        try
        {
            Session["CurrentPageIndex"] = 1;
            Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "CreatedDate";
            Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = Cls_Constant.VIEWSTATE_DESC;
            ClearMsg();
            Int64 ConsultantId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
            LinkButton lnkbtnCurrWorkLoad = (LinkButton)sender;
            ddlPageSizeNYC.SelectedValue = "50";
            Session["TotalRecCount"] = "50";
            if (ConsultantId > 0)
            {

                lnkbtnBulkReAssign.Visible = true;
                lnkbtnBulkAssign.Visible = false;
                Session["ConsultantId"] = ConsultantId;

                Session["Status"] = "CUR";
                DataTable dt = objProspectBM.GetFCProspDetAssignedToConsult(ConsultantId, Convert.ToDateTime(txtFCUnAlocFromDate.Text.Trim()), Convert.ToDateTime(txtFCUnalocToDate.Text.Trim()), 0);
                if (dt != null && dt.Rows.Count > 0)
                {
                    ViewState["FilteredData"] = ViewState["ProspData"] = null;
                    ViewState["FromDate"] = txtFCUnAlocFromDate.Text.Trim();
                    ViewState["ToDate"] = txtFCUnalocToDate.Text.Trim();
                    ViewState["Flag"] = "CUR";
                    ViewState["ConsultantId"] = ConsultantId;
                    Session["Flag"] = ViewState["FCFlag"] = "FC";
                    lblTotLeadView.Text = Resources.PFSalesResource.WorkloadDetails.Trim();
                    lblTitle.Text = Resources.PFSalesResource.WorkloadDetails.Trim();
                    if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && ViewState["Flag"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()))
                        BindNYCLeadGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim(), ViewState["Flag"].ToString().Trim());
                    dvFilterAlloc.Visible = dvFilterUnAlloc.Visible = dvClearFilter.Visible = lnkbtnClearFilter.Visible = lnkbtnFilterUnall.Visible = lnkbtnFilterAlloc.Visible = false;
                    pnlNYCViewPopUp.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnFCCurrWorkLoad_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Text Changed Event Of FC's No Of Lead's Text Box. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtFCNoOfLeads_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ClearMsg();
            GridViewRow gr = (GridViewRow)((TextBox)sender).NamingContainer;
            if (gr != null)
            {
                CompareValidator cvNoOfLeadsVal = (CompareValidator)gr.FindControl("cvFCNoOfLeadsVal");
                if (cvNoOfLeadsVal != null)
                {
                    Page.Validate(cvNoOfLeadsVal.ValidationGroup);
                }
            }

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.txtFCNoOfLeads_TextChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Gridview Page Sorting Event Of FC's Consultant's GridView. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFCAllocate_Soring(object sender, GridViewSortEventArgs e)
    {
        try
        {
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION2] = e.SortExpression;
            DefineFCSortDirection();
            BindFCConsultants();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.gvprosp_Soring.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Grid view Row Created Event. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFCAllocate_Created(object sender, GridViewRowEventArgs e)
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
    /// Created Date: 17 Aug 2013
    /// Description: Grid view Row Data Bound Event. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFCAllocate_RowDatabound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblTodaysLeads = (Label)e.Row.FindControl("lblFTodaysLeads");
                Label lblTwentyFourHr = (Label)e.Row.FindControl("lblFTwentyFourHr");
                Label lblThisWeek = (Label)e.Row.FindControl("lblFThisWeek");
                Label lblThisMonth = (Label)e.Row.FindControl("lblFThisMonth");
                Label lblContfortyEighthr = (Label)e.Row.FindControl("lblFCContfortyEighthr");
                Label lblContSevenDays = (Label)e.Row.FindControl("lblFCContSevenDays");
                LinkButton lnkbtnWorkLoad = (LinkButton)e.Row.FindControl("lnkbtnFCCurrWorkLoad");
                LinkButton lnkbtnFCNotYetCalled = (LinkButton)e.Row.FindControl("lnkbtnFCNotYetCalled");
                CompareValidator cvNoOfLeadsVal = (CompareValidator)e.Row.FindControl("cvFCNoOfLeadsVal");
                if (lnkbtnWorkLoad != null && !string.IsNullOrEmpty(lnkbtnWorkLoad.Text.Trim()))
                    if (lnkbtnWorkLoad.Text.Trim() == "0")
                        lnkbtnWorkLoad.Enabled = false;
                if (cvNoOfLeadsVal != null)
                    cvNoOfLeadsVal.ValidationGroup = "NoofLeadsVal" + e.Row.RowIndex.ToString().Trim();

                if (lnkbtnFCNotYetCalled != null && !string.IsNullOrEmpty(lnkbtnFCNotYetCalled.Text.Trim()))
                    if (lnkbtnFCNotYetCalled.Text.Trim() == "0")
                        lnkbtnFCNotYetCalled.Enabled = false;

                if (lblTodaysLeads != null && lblTwentyFourHr != null && lblThisWeek != null && lblThisMonth != null && lblContfortyEighthr != null && lblContSevenDays != null && lnkbtnWorkLoad != null && lnkbtnFCNotYetCalled != null)
                {
                    if (!string.IsNullOrEmpty(lblTodaysLeads.Text.Trim()) && !string.IsNullOrEmpty(lblTwentyFourHr.Text.Trim()) && !string.IsNullOrEmpty(lblThisWeek.Text.Trim()) && !string.IsNullOrEmpty(lblThisMonth.Text.Trim()) && !string.IsNullOrEmpty(lblContfortyEighthr.Text.Trim()) && !string.IsNullOrEmpty(lblContSevenDays.Text.Trim()) && !string.IsNullOrEmpty(lnkbtnWorkLoad.Text.Trim()) && !string.IsNullOrEmpty(lnkbtnFCNotYetCalled.Text.Trim()))
                    {
                        int FCTodLead = Convert.ToInt32(lblTodaysLeads.Text.Trim());
                        int FC24hrLead = Convert.ToInt32(lblTwentyFourHr.Text.Trim());
                        int FCWeekLead = Convert.ToInt32(lblThisWeek.Text.Trim());
                        int FCMonthLead = Convert.ToInt32(lblThisMonth.Text.Trim());
                        int FC48Lead = Convert.ToInt32(lblContfortyEighthr.Text.Trim());
                        int FC7DLead = Convert.ToInt32(lblContSevenDays.Text.Trim());
                        int FCCWLoad = Convert.ToInt32(lnkbtnWorkLoad.Text.Trim());
                        int FCNYC = Convert.ToInt32(lnkbtnFCNotYetCalled.Text.Trim());

                        TotlFCTodLead += FCTodLead;
                        TotlFC24hrLead += FC24hrLead;
                        TotlFCWeekLead += FCWeekLead;
                        TotlFCMonthLead += FCMonthLead;
                        TotlFC48Lead += FC48Lead;
                        TotlFC7DLead += FC7DLead;
                        TotlFCCWLoad += FCCWLoad;
                        TotlFCNYC += FCNYC;
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotlFCTodLead = (Label)e.Row.FindControl("lblTotlFCTodLead");
                Label lblTotlFC24hrLead = (Label)e.Row.FindControl("lblTotlFC24hrLead");
                Label lblTotlFCWeekLead = (Label)e.Row.FindControl("lblTotlFCWeekLead");
                Label lblTotlFCMonthLead = (Label)e.Row.FindControl("lblTotlFCMonthLead");
                Label lblTotlFC48Lead = (Label)e.Row.FindControl("lblTotlFC48Lead");
                Label lblTotlFC7DLead = (Label)e.Row.FindControl("lblTotlFC7DLead");
                Label lblTotlFCCWLoad = (Label)e.Row.FindControl("lblTotlFCCWLoad");
                Label lblTotlFCNYC = (Label)e.Row.FindControl("lblTotlFCNYC");

                if (lblTotlFCTodLead != null && lblTotlFC24hrLead != null && lblTotlFCWeekLead != null && lblTotlFCMonthLead != null && lblTotlFC48Lead != null && lblTotlFC7DLead != null && lblTotlFCCWLoad != null && lblTotlFCNYC != null)
                {
                    lblTotlFCTodLead.Text = Convert.ToString(TotlFCTodLead);
                    lblTotlFC24hrLead.Text = Convert.ToString(TotlFC24hrLead);
                    lblTotlFCWeekLead.Text = Convert.ToString(TotlFCWeekLead);
                    lblTotlFCMonthLead.Text = Convert.ToString(TotlFCMonthLead);
                    lblTotlFC48Lead.Text = Convert.ToString(TotlFC48Lead);
                    lblTotlFC7DLead.Text = Convert.ToString(TotlFC7DLead);
                    lblTotlFCCWLoad.Text = Convert.ToString(TotlFCCWLoad);
                    lblTotlFCNYC.Text = Convert.ToString(TotlFCNYC);
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.gvAllocate_RowDatabound.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Set Bulk Amount Of Leads To Each FC Consultant. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFCSet_Click(object sender, EventArgs e)
    {
        try
        {
            Page.Validate("FCReset");
            int Count = 0;
            foreach (GridViewRow grow in gvFCAllocate.Rows)
            {
                CheckBox chkbx = (CheckBox)grow.FindControl("chkFCSelect");
                if (chkbx != null)
                {
                    if (chkbx.Checked)
                    {
                        Count++;
                    }
                }
            }
            ClearMsg();
            if ((Convert.ToInt32(txtFCBulkAmt.Text.Trim()) * Count) <= Convert.ToInt32(lnkbtnFCUnallocatedEnq.Text.Trim()))
            {
                lblFCSerError.Text = string.Empty;
                dvFCserError.Visible = false;
                foreach (GridViewRow grviewrow in gvFCAllocate.Rows)
                {
                    CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkFCSelect");
                    TextBox txtNoOfLeads = (TextBox)grviewrow.FindControl("txtFCNoOfLeads");
                    if (chkbx != null && txtNoOfLeads != null)
                    {
                        if (chkbx.Checked)
                        {
                            txtNoOfLeads.Enabled = true;
                            txtNoOfLeads.Text = txtFCBulkAmt.Text.Trim();
                        }
                    }
                }
                ViewState["LeadsAddjusted"] = false;
            }
            else
            {
                Int32[] arr = AllocateLeads(Count, Convert.ToInt32(txtFCBulkAmt.Text.Trim()), Convert.ToInt32(lnkbtnFCUnallocatedEnq.Text.Trim()));
                int i = 0;
                if (arr.Length == Count)
                {
                    foreach (GridViewRow grviewrow in gvFCAllocate.Rows)
                    {
                        CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkFCSelect");
                        TextBox txtNoOfLeads = (TextBox)grviewrow.FindControl("txtFCNoOfLeads");
                        if (chkbx != null && txtNoOfLeads != null)
                        {
                            if (chkbx.Checked)
                            {
                                txtNoOfLeads.Enabled = true;
                                txtNoOfLeads.Text = arr[i].ToString().Trim();
                                i++;
                            }
                        }
                    }
                    ViewState["LeadsAddjusted"] = true;
                    lblFCSerSuccess.Text = Resources.PFSalesResource.NotEnough.Trim();
                    dvFCSerSuccess.Visible = true;
                    lblFCSerError.Text = string.Empty;
                    dvFCserError.Visible = false;
                }
                else
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.notEnoughLeads.Trim();
                    dvFCserError.Visible = true;
                    ClearFCAll();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnFCSet_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Assign FC Leads To Consultants. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFCAllocate_Click(object sender, EventArgs e)
    {
        try
        {
            Page.Validate("FCAllocate");
            Thread t4 = null;
            if (Page.IsValid)
            {
                List<LeadAssignment> lstAllocation = new List<LeadAssignment>();
                foreach (GridViewRow grviewrow in gvFCAllocate.Rows)
                {
                    CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkFCSelect");
                    TextBox txtNoOfLeads = (TextBox)grviewrow.FindControl("txtFCNoOfLeads");
                    HiddenField hdfConsultantId = (HiddenField)grviewrow.FindControl("hdfFCConsultantId");
                    HiddenField hdfFName = (HiddenField)grviewrow.FindControl("hdfFCFName");
                    Label lblContEmailId = (Label)grviewrow.FindControl("lblFCContEmailId");
                    Label lblConsultName = (Label)grviewrow.FindControl("lblFCConsultName");
                    if (chkbx != null && txtNoOfLeads != null && hdfConsultantId != null && lblContEmailId != null && lblConsultName != null)
                    {
                        if (!string.IsNullOrEmpty(hdfConsultantId.Value.Trim()) && !string.IsNullOrEmpty(txtNoOfLeads.Text.Trim()) && Convert.ToInt64(txtNoOfLeads.Text.Trim()) > 0)
                        {
                            LeadAssignment objLAllocation = new LeadAssignment();
                            objLAllocation.ConsultantId = Convert.ToInt64(hdfConsultantId.Value.Trim());
                            objLAllocation.Noofleads = Convert.ToInt32(txtNoOfLeads.Text.Trim());
                            if (!string.IsNullOrEmpty(lblContEmailId.Text.Trim()))
                                objLAllocation.ConsultantEmail = lblContEmailId.Text.Trim();
                            if (!string.IsNullOrEmpty(lblConsultName.Text.Trim()))
                                objLAllocation.ConsultantName = lblConsultName.Text.Trim();
                            if (!string.IsNullOrEmpty(hdfFName.Value.Trim()))
                                objLAllocation.ConsultFName = hdfFName.Value.Trim();
                            lstAllocation.Add(objLAllocation);
                        }
                    }
                }
                objProsp.lstAllocation = lstAllocation;
                objProsp.CreatedById = BasePage.UserSession.VirtualRoleId;
                objProsp.FromDate = Convert.ToDateTime(txtFCUnAlocFromDate.Text.Trim());
                objProsp.ToDate = Convert.ToDateTime(txtFCUnalocToDate.Text.Trim());
                DtResult = objProspectBM.AssignLeadsToFCConsultant(objProsp);
                //double Interval1 = Convert.ToDouble(ConfigurationManager.AppSettings["ActInterval"].ToString().Trim());
                //double Interval = 0;
                BindFCConsultants();
                if (DtResult != null && DtResult.Rows.Count > 0)
                {
                    ClearFCAll();
                    t4 = new Thread(SendFCEmailOnThread);
                    t4.Start();

                    lblFCSerSuccess.Text = Resources.PFSalesResource.LeadsAssignedSuccess.Trim();
                    dvFCSerSuccess.Visible = true;
                    lblFCSerError.Text = string.Empty;
                    dvFCserError.Visible = false;
                }
                else
                {
                    lblFCSerSuccess.Text = string.Empty;
                    dvFCSerSuccess.Visible = false;
                    lblFCSerError.Text = Resources.PFSalesResource.LeadsAssignedError.Trim();
                    dvFCserError.Visible = true;
                }
            }
            t4.Join(1000);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnFCAllocate_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: FC Total Enquiry Count's Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFCTodTotEnq_Click(object sender, EventArgs e)
    {
        try
        {
            Session["CurrentPageIndex"] = 1;
            Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "CreatedDate";
            Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = Cls_Constant.VIEWSTATE_DESC;
            ViewState["FilteredData"] = ViewState["ProspData"] = null;
            ViewState["FromDate"] = txtFCTotEntFrmDate.Text.Trim();
            ViewState["ToDate"] = txtFCTotEntToDate.Text.Trim();
            ViewState["Flag"] = "A";
            ViewState["ConsultantId"] = "0";
            ViewState["FCFlag"] = "FC";
            lblTotLeadView.Text = Resources.PFSalesResource.TodaysEnquiryDetails.Trim();
            lblTitle.Text = Resources.PFSalesResource.TodaysEnquiryDetails.Trim();
            if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && ViewState["Flag"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()))
                BindProspGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), ViewState["Flag"].ToString().Trim(), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim());
            pnlTotLeadViewPopUp.Visible = true;
            //BindNYCLeadGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim(), ViewState["Flag"].ToString().Trim());
            //pnlNYCViewPopUp.Visible = true;

            dvFilterUnAlloc.Visible = dvFilterAlloc.Visible = lnkbtnFilterAlloc.Visible = lnkbtnFilterUnall.Visible = true;
            dvClearFilter.Visible = lnkbtnClearFilter.Visible = false;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnTodTotEnq_Click.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 June 2013
    /// Description: Button Click Event of Get Total FC Entity Count. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFCTotEntGetCount_Click(object sender, EventArgs e)
    {
        GetTotalFCCount();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Button Click Event of Get Total FC Entity Count. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFCUnalocGetCount_Click(object sender, EventArgs e)
    {
        GetUnAlocatedFCEnqCount();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description:FC's Unallocated Enquiry Count's Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFCUnallocatedEnq_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["FilteredData"] = ViewState["ProspData"] = null;
            ViewState["FromDate"] = txtFCUnAlocFromDate.Text.Trim();
            ViewState["ToDate"] = txtFCUnalocToDate.Text.Trim();
            ViewState["Flag"] = "U";
            ViewState["ConsultantId"] = 0;
            ViewState["FCFlag"] = "FC";
            lblTotLeadView.Text = Resources.PFSalesResource.UnAlocatedEnqDetails.Trim();
            if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && ViewState["Flag"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()))
                BindProspGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), ViewState["Flag"].ToString().Trim(), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim());
            //txtUnAllEnqLegend.Visible =txtAllEnqLegend.Visible = lblUnAlloCateLegend.Visible = lblAllocatedLegend.Visible = false;
            dvFilterAlloc.Visible = dvFilterUnAlloc.Visible = dvClearFilter.Visible = lnkbtnClearFilter.Visible = lnkbtnFilterUnall.Visible = lnkbtnFilterAlloc.Visible = false;
            pnlTotLeadViewPopUp.Visible = true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnUnallocatedEnq_Click.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Clear All Control Data. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFCClear_Click(object sender, EventArgs e)
    {
        ClearFCAll();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Button Click Event of Get Total Entity Count. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFCTotEntGetCount1_Click(object sender, EventArgs e)
    {
        GetFCTotalCount1();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 June 2013
    /// Description: Total FC's Enquiry Count's Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFCTodTotEnq1_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["FilteredData"] = ViewState["ProspData"] = null;
            ViewState["FromDate"] = txtFCTotEntFrmDate1.Text.Trim();
            ViewState["ToDate"] = txtFCTotEntToDate1.Text.Trim();
            ViewState["Flag"] = "A";
            ViewState["ConsultantId"] = "0";
            ViewState["FCFlag"] = "FC";
            lblTotLeadView.Text = Resources.PFSalesResource.TodaysEnquiryDetails.Trim();
            if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && ViewState["Flag"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()))
                BindProspGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), ViewState["Flag"].ToString().Trim(), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim());
            pnlTotLeadViewPopUp.Visible = true;
            dvFilterUnAlloc.Visible = dvFilterAlloc.Visible = lnkbtnFilterAlloc.Visible = lnkbtnFilterUnall.Visible = true;
            dvClearFilter.Visible = lnkbtnClearFilter.Visible = false;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnTodTotEnq_Click.error:" + ex.StackTrace);
        }
    }
    #endregion

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: View Pf Allocation Panel Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnPFAllocation_Click(object sender, EventArgs e)
    {
        pnlLeadAllocation.Visible = true;
        pnlFCleadAllocation.Visible = false;
        lnkbtnPFAllocation.CssClass = "tablerBtnActive";
        lnkbtnFCAllocation.CssClass = string.Empty;
        Session["Flag"] = "PF";
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: View FC Allocation Panel Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFCAllocation_Click(object sender, EventArgs e)
    {
        pnlLeadAllocation.Visible = false;
        pnlFCleadAllocation.Visible = true;
        lnkbtnPFAllocation.CssClass = string.Empty;
        lnkbtnFCAllocation.CssClass = "tablerBtnActive";
        Session["Flag"] = "FC";
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Button Click Event of Get Total FC Entity Count. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFCUnalocGetCount1_Click(object sender, EventArgs e)
    {
        GetFCUnAlocatedEnqCount1();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 14 Nov 2013
    /// Description: Mark Prospect's Status As Dead
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnMarkAsDead_Click(object sender, EventArgs e)
    {
        try
        {
            Int64 ProspectId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
            Int64 Result = objProspectBM.ChangeStatusToDorN(ProspectId, "D", Convert.ToString(Session["Flag"]).Trim(), BasePage.UserSession.VirtualRoleId);
            if (Result > 0)
            {
                GetFCUnAlocatedEnqCount1();
                GetUnAlocatedEnqCount1();
                if (Session["ConsultantId"] != null && Session["Flag"] != null && Session["Status"] != null)
                {
                    int consultantID = Convert.ToInt32(Session["ConsultantId"]);
                    string strFlag = Convert.ToString(Session["Flag"]);
                    string strStatus = Convert.ToString(Session["Status"]);
                    switch (strFlag.ToUpper())
                    {
                        case "PF":
                            switch (strStatus.ToUpper())
                            {
                                case "CUR":
                                    foreach (GridViewRow gr in gvAllocate.Rows)
                                    {
                                        HiddenField hdfConsultantId = (HiddenField)gr.FindControl("hdfConsultantId");
                                        if (Convert.ToInt32(hdfConsultantId.Value) == consultantID)
                                        {
                                            LinkButton lnkbtnCurrWorkLoad = (LinkButton)gr.FindControl("lnkbtnCurrWorkLoad");
                                            lnkbtnCurrWorkLoad_Click(lnkbtnCurrWorkLoad, null);
                                        }
                                    }

                                    break;
                                case "NYC":
                                    foreach (GridViewRow gr in gvAllocate.Rows)
                                    {
                                        HiddenField hdfConsultantId = (HiddenField)gr.FindControl("hdfConsultantId");
                                        if (Convert.ToInt32(hdfConsultantId.Value) == consultantID)
                                        {
                                            LinkButton lnkbtnNYCWorkLoad = (LinkButton)gr.FindControl("lnkbtnNYCWorkLoad");
                                            lnkbtnNYCWorkLoad_Click(lnkbtnNYCWorkLoad, null);
                                        }
                                    }
                                    break;
                                case "U":
                                    pnlLeadAllocation.Visible = true;
                                    pnlFCleadAllocation.Visible = false;
                                    lnkbtnPFAllocation.CssClass = "tablerBtnActive";
                                    lnkbtnFCAllocation.CssClass = string.Empty;
                                    Session["Flag"] = "PF";
                                    lnkbtnUnallocatedEnq1_Click(lnkbtnUnallocatedEnq1, null);

                                    break;
                            }
                            break;
                        case "FC":
                            switch (strStatus.ToUpper())
                            {
                                case "CUR":
                                    foreach (GridViewRow gr in gvFCAllocate.Rows)
                                    {
                                        HiddenField hdfFCConsultantId = (HiddenField)gr.FindControl("hdfFCConsultantId");
                                        if (Convert.ToInt32(hdfFCConsultantId.Value) == consultantID)
                                        {
                                            LinkButton lnkbtnFCCurrWorkLoad = (LinkButton)gr.FindControl("lnkbtnFCCurrWorkLoad");
                                            lnkbtnFCCurrWorkLoad_Click(lnkbtnFCCurrWorkLoad, null);
                                        }
                                    }

                                    break;
                                case "NYC":
                                    foreach (GridViewRow gr in gvFCAllocate.Rows)
                                    {
                                        HiddenField hdfFCConsultantId = (HiddenField)gr.FindControl("hdfFCConsultantId");
                                        if (Convert.ToInt32(hdfFCConsultantId.Value) == consultantID)
                                        {
                                            LinkButton lnkbtnFCNotYetCalled = (LinkButton)gr.FindControl("lnkbtnFCNotYetCalled");
                                            lnkbtnFCNotYetCalled_Click(lnkbtnFCNotYetCalled, null);
                                        }
                                    }
                                    break;

                                case "U":
                                    pnlLeadAllocation.Visible = false;
                                    pnlFCleadAllocation.Visible = true;
                                    lnkbtnPFAllocation.CssClass = string.Empty;
                                    lnkbtnFCAllocation.CssClass = "tablerBtnActive";
                                    Session["Flag"] = "FC";
                                    lnkbtnFCUnallocatedEnq1_Click(lnkbtnFCUnallocatedEnq1, null);
                                    break;
                            }
                            break;
                    }
                }
                lblAddSucMsg.Text = Resources.PFSalesResource.StatusChanged.Trim();
                lblAddErrMsg.Text = string.Empty;
                dvadderror.Visible = false;
                dvaddSucc.Visible = true;
            }
            else
            {
                lblAddErrMsg.Text = Resources.PFSalesResource.StatusNotChanged.Trim();
                lblAddSucMsg.Text = string.Empty;
                dvaddSucc.Visible = false;
                dvadderror.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnMarkAsDead_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 14 Nov 2013
    /// Description: Mark Prospect's Status As NTU
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnMarkAsNTU_Click(object sender, EventArgs e)
    {
        try
        {
            Int64 ProspectId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
            Int64 Result = objProspectBM.ChangeStatusToDorN(ProspectId, "N", Convert.ToString(Session["Flag"]).Trim(), BasePage.UserSession.VirtualRoleId);
            if (Result > 0)
            {
                GetFCUnAlocatedEnqCount1();
                GetUnAlocatedEnqCount1();
                if (Session["ConsultantId"] != null && Session["Flag"] != null && Session["Status"] != null)
                {
                    int consultantID = Convert.ToInt32(Session["ConsultantId"]);
                    string strFlag = Convert.ToString(Session["Flag"]);
                    string strStatus = Convert.ToString(Session["Status"]);
                    switch (strFlag.ToUpper())
                    {
                        case "PF":
                            switch (strStatus.ToUpper())
                            {
                                case "CUR":
                                    foreach (GridViewRow gr in gvAllocate.Rows)
                                    {
                                        HiddenField hdfConsultantId = (HiddenField)gr.FindControl("hdfConsultantId");
                                        if (Convert.ToInt32(hdfConsultantId.Value) == consultantID)
                                        {
                                            LinkButton lnkbtnCurrWorkLoad = (LinkButton)gr.FindControl("lnkbtnCurrWorkLoad");
                                            lnkbtnCurrWorkLoad_Click(lnkbtnCurrWorkLoad, null);
                                        }
                                    }
                                    break;
                                case "NYC":
                                    foreach (GridViewRow gr in gvAllocate.Rows)
                                    {
                                        HiddenField hdfConsultantId = (HiddenField)gr.FindControl("hdfConsultantId");
                                        if (Convert.ToInt32(hdfConsultantId.Value) == consultantID)
                                        {
                                            LinkButton lnkbtnNYCWorkLoad = (LinkButton)gr.FindControl("lnkbtnNYCWorkLoad");
                                            lnkbtnNYCWorkLoad_Click(lnkbtnNYCWorkLoad, null);
                                        }
                                    }
                                    break;
                                case "U":
                                    pnlLeadAllocation.Visible = true;
                                    pnlFCleadAllocation.Visible = false;
                                    lnkbtnPFAllocation.CssClass = "tablerBtnActive";
                                    lnkbtnFCAllocation.CssClass = string.Empty;
                                    Session["Flag"] = "PF";
                                    lnkbtnUnallocatedEnq1_Click(lnkbtnUnallocatedEnq1, null);

                                    break;
                            }
                            break;
                        case "FC":
                            switch (strStatus.ToUpper())
                            {
                                case "CUR":
                                    foreach (GridViewRow gr in gvFCAllocate.Rows)
                                    {
                                        HiddenField hdfFCConsultantId = (HiddenField)gr.FindControl("hdfFCConsultantId");
                                        if (Convert.ToInt32(hdfFCConsultantId.Value) == consultantID)
                                        {
                                            LinkButton lnkbtnFCCurrWorkLoad = (LinkButton)gr.FindControl("lnkbtnFCCurrWorkLoad");
                                            lnkbtnFCCurrWorkLoad_Click(lnkbtnFCCurrWorkLoad, null);
                                        }
                                    }
                                    break;
                                case "NYC":
                                    foreach (GridViewRow gr in gvFCAllocate.Rows)
                                    {
                                        HiddenField hdfFCConsultantId = (HiddenField)gr.FindControl("hdfFCConsultantId");
                                        if (Convert.ToInt32(hdfFCConsultantId.Value) == consultantID)
                                        {
                                            LinkButton lnkbtnFCNotYetCalled = (LinkButton)gr.FindControl("lnkbtnFCNotYetCalled");
                                            lnkbtnFCNotYetCalled_Click(lnkbtnFCNotYetCalled, null);
                                        }
                                    }
                                    break;
                                case "U":
                                    pnlLeadAllocation.Visible = false;
                                    pnlFCleadAllocation.Visible = true;
                                    lnkbtnPFAllocation.CssClass = string.Empty;
                                    lnkbtnFCAllocation.CssClass = "tablerBtnActive";
                                    Session["Flag"] = "FC";
                                    lnkbtnFCUnallocatedEnq1_Click(lnkbtnFCUnallocatedEnq1, null);
                                    break;
                            }
                            break;
                    }
                }
                lblAddSucMsg.Text = Resources.PFSalesResource.StatusChanged.Trim();
                lblAddErrMsg.Text = string.Empty;
                dvadderror.Visible = false;
                dvaddSucc.Visible = true;
            }
            else
            {
                lblAddErrMsg.Text = Resources.PFSalesResource.StatusNotChanged.Trim();
                lblAddSucMsg.Text = string.Empty;
                dvaddSucc.Visible = false;
                dvadderror.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnMarkAsNTU_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 14 Nov 2013
    /// Description: Assign Leads In Bulk
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnBulkAssign_Click(object sender, EventArgs e)
    {
        try
        {
            lblRalocationHead.Text = Resources.PFSalesResource.BulkAssignmentOfLeads.Trim();
            ClearMsg();
            DataTable Dt = new DataTable();
            Employee objEmp = new Employee();
            StringBuilder strIds = new StringBuilder();
            if (Session["Flag"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Flag"]).Trim()))
            {
                if (Convert.ToString(Session["Flag"]).Trim().ToUpper() == "PF")
                {
                    hdfConsultantType.Value = "PF";
                    objEmp.FName = string.Empty;
                    objEmp.RoleId = 3;//Hard Code For Consultant
                    Dt = objEmpBM.GetAllEmployee(objEmp);
                }
                else if (Convert.ToString(Session["Flag"]).Trim().ToUpper() == "FC")
                {
                    hdfConsultantType.Value = "FC";
                    objEmp.FName = string.Empty;
                    objEmp.RoleId = 5;//Hard Code For Finanace Consultant
                    Dt = objEmpBM.GetAllEmployee(objEmp);
                }
                else
                {
                    hdfConsultantType.Value = "PF";
                    objEmp.FName = string.Empty;
                    objEmp.RoleId = 3;//Hard Code For Consultant
                    Dt = objEmpBM.GetAllEmployee(objEmp);
                }
                //strConsultId = arr[1].Trim();
            }

            if (Dt != null & Dt.Rows.Count > 0)
            {
                gvBulkAllocateConsult.DataSource = Dt;
                gvBulkAllocateConsult.DataBind();
            }
            else
            {
                gvBulkAllocateConsult.DataSource = null;
                gvBulkAllocateConsult.DataBind();
            }

            int cnt = 0;
            for (int i = 0; i < gvNYC.Rows.Count; i++)
            {
                HiddenField hdfId = (HiddenField)gvNYC.Rows[i].FindControl("hdfId");
                //HiddenField hdfConsultantId = (HiddenField)gvNYC.Rows[i].FindControl("hdfConsultantId");
                //HiddenField hdfFinConsultantId = (HiddenField)gvNYC.Rows[i].FindControl("hdfFinConsultantId");
                CheckBox chkSelect = (CheckBox)gvNYC.Rows[i].FindControl("chkSelect");
                if (chkSelect != null && hdfId != null)
                {
                    if (chkSelect.Checked)
                    {
                        //if (strConsultId.Trim() == hdfConsultantId.Value.Trim() || strConsultId.Trim() == hdfFinConsultantId.Value.Trim())
                        //{
                        cnt++;
                        strIds.Append(hdfId.Value.Trim() + ",");
                        //}
                    }
                }
            }
            if (cnt > 0)
                pnlRallocation.Visible = true;
            else
            {
                lblAddErrMsg.Text = Resources.PFSalesResource.SelLeadSelConsultVal.Trim();
                lblAddSucMsg.Text = string.Empty;
                dvadderror.Visible = true;
                dvaddSucc.Visible = false;
            }
            hdfSelectedLeadCount.Value = Convert.ToString(cnt).Trim();
            hdfSelProspIdForReass.Value = Convert.ToString(strIds).TrimEnd(',');
        }
        catch (Exception ex)
        {

            Logger.Error(ex.Message + "LeadAllocation.lnkbtnBulkAssign_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 22 Nov 2013
    /// Description: Mark NTU Status For Bulk Amount Of Leads
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnBulkNTU_Click(object sender, EventArgs e)
    {
        try
        {
            ClearMsg();
            DataTable Dt = new DataTable();
            StringBuilder strIds = new StringBuilder();
            int cnt = 0;
            Int64 Result = 0;

            for (int i = 0; i < gvNYC.Rows.Count; i++)
            {
                HiddenField hdfId = (HiddenField)gvNYC.Rows[i].FindControl("hdfId");
                //HiddenField hdfConsultantId = (HiddenField)gvNYC.Rows[i].FindControl("hdfConsultantId");
                //HiddenField hdfFinConsultantId = (HiddenField)gvNYC.Rows[i].FindControl("hdfFinConsultantId");
                CheckBox chkSelect = (CheckBox)gvNYC.Rows[i].FindControl("chkSelect");
                if (chkSelect != null && hdfId != null)
                {
                    if (chkSelect.Checked)
                    {
                        //if (strConsultId.Trim() == hdfConsultantId.Value.Trim() || strConsultId.Trim() == hdfFinConsultantId.Value.Trim())
                        //{
                        cnt++;
                        strIds.Append(hdfId.Value.Trim() + ",");
                        //}
                    }
                }
            }
            if (Session["Flag"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Flag"]).Trim()))
            {
                if (cnt > 0)
                {
                    if (Convert.ToString(Session["Flag"]).Trim().ToUpper() == "PF")
                    {
                        Result = objProspectBM.BulkNTULeads("PF", strIds.ToString().TrimEnd(','), BasePage.UserSession.VirtualRoleId);
                    }
                    else if (Convert.ToString(Session["Flag"]).Trim().ToUpper() == "FC")
                    {
                        Result = objProspectBM.BulkNTULeads("FC", strIds.ToString().TrimEnd(','), BasePage.UserSession.VirtualRoleId);
                    }
                }
                else
                {
                    lblAddErrMsg.Text = Resources.PFSalesResource.SelLeadForBulkAssVal.Trim();
                    lblAddSucMsg.Text = string.Empty;
                    dvadderror.Visible = true;
                    dvaddSucc.Visible = false;
                }
                if (Result > 0)
                {
                    GetFCUnAlocatedEnqCount1();
                    GetUnAlocatedEnqCount1();
                    if (Session["ConsultantId"] != null && Session["Flag"] != null && Session["Status"] != null)
                    {
                        int consultantID = Convert.ToInt32(Session["ConsultantId"]);
                        string strFlag = Convert.ToString(Session["Flag"]);
                        string strStatus = Convert.ToString(Session["Status"]);
                        switch (strFlag.ToUpper())
                        {
                            case "PF":
                                switch (strStatus.ToUpper())
                                {
                                    case "CUR":
                                        foreach (GridViewRow gr in gvAllocate.Rows)
                                        {
                                            HiddenField hdfConsultantId = (HiddenField)gr.FindControl("hdfConsultantId");
                                            if (Convert.ToInt32(hdfConsultantId.Value) == consultantID)
                                            {
                                                LinkButton lnkbtnCurrWorkLoad = (LinkButton)gr.FindControl("lnkbtnCurrWorkLoad");
                                                lnkbtnCurrWorkLoad_Click(lnkbtnCurrWorkLoad, null);
                                            }
                                        }
                                        break;
                                    case "NYC":
                                        foreach (GridViewRow gr in gvAllocate.Rows)
                                        {
                                            HiddenField hdfConsultantId = (HiddenField)gr.FindControl("hdfConsultantId");
                                            if (Convert.ToInt32(hdfConsultantId.Value) == consultantID)
                                            {
                                                LinkButton lnkbtnNYCWorkLoad = (LinkButton)gr.FindControl("lnkbtnNYCWorkLoad");
                                                lnkbtnNYCWorkLoad_Click(lnkbtnNYCWorkLoad, null);
                                            }
                                        }
                                        break;
                                    case "U":
                                        pnlLeadAllocation.Visible = true;
                                        pnlFCleadAllocation.Visible = false;
                                        lnkbtnPFAllocation.CssClass = "tablerBtnActive";
                                        lnkbtnFCAllocation.CssClass = string.Empty;
                                        Session["Flag"] = "PF";
                                        lnkbtnUnallocatedEnq1_Click(lnkbtnUnallocatedEnq1, null);
                                        break;
                                }
                                break;
                            case "FC":
                                switch (strStatus.ToUpper())
                                {
                                    case "CUR":
                                        foreach (GridViewRow gr in gvFCAllocate.Rows)
                                        {
                                            HiddenField hdfFCConsultantId = (HiddenField)gr.FindControl("hdfFCConsultantId");
                                            if (Convert.ToInt32(hdfFCConsultantId.Value) == consultantID)
                                            {
                                                LinkButton lnkbtnFCCurrWorkLoad = (LinkButton)gr.FindControl("lnkbtnFCCurrWorkLoad");
                                                lnkbtnFCCurrWorkLoad_Click(lnkbtnFCCurrWorkLoad, null);
                                            }
                                        }
                                        break;
                                    case "NYC":
                                        foreach (GridViewRow gr in gvFCAllocate.Rows)
                                        {
                                            HiddenField hdfFCConsultantId = (HiddenField)gr.FindControl("hdfFCConsultantId");
                                            if (Convert.ToInt32(hdfFCConsultantId.Value) == consultantID)
                                            {
                                                LinkButton lnkbtnFCNotYetCalled = (LinkButton)gr.FindControl("lnkbtnFCNotYetCalled");
                                                lnkbtnFCNotYetCalled_Click(lnkbtnFCNotYetCalled, null);
                                            }
                                        }
                                        break;
                                    case "U":
                                        pnlLeadAllocation.Visible = false;
                                        pnlFCleadAllocation.Visible = true;
                                        lnkbtnPFAllocation.CssClass = string.Empty;
                                        lnkbtnFCAllocation.CssClass = "tablerBtnActive";
                                        Session["Flag"] = "FC";
                                        lnkbtnFCUnallocatedEnq1_Click(lnkbtnFCUnallocatedEnq1, null);
                                        break;
                                }
                                break;
                        }
                    }
                    lblAddSucMsg.Text = Resources.PFSalesResource.LeadsBulkNTUSuccess.Trim();
                    lblAddErrMsg.Text = string.Empty;
                    dvaddSucc.Visible = true;
                    dvadderror.Visible = false;
                }
                else
                {
                    lblAddErrMsg.Text = Resources.PFSalesResource.LeadsBulkNTUError.Trim();
                    lblAddSucMsg.Text = string.Empty;
                    dvadderror.Visible = true;
                    dvaddSucc.Visible = false;
                }
            }

        }
        catch (Exception ex)
        {

            Logger.Error(ex.Message + "LeadAllocation.lnkbtnBulkAssign_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 14 Nov 2013
    /// Description: Bul Assign Leads To Selected Consultant 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkBtnBulkAllocate_Click(object sender, EventArgs e)
    {
        try
        {
            int Count = 0;

            if (!string.IsNullOrEmpty(hdfSelProspIdForReass.Value.Trim()))
            {
                foreach (GridViewRow grow in gvBulkAllocateConsult.Rows)
                {
                    CheckBox chkbx = (CheckBox)grow.FindControl("chkSelect");
                    if (chkbx != null)
                    {
                        if (chkbx.Checked)
                        {
                            Count++;
                        }
                    }
                }
                int bulkAmount = Convert.ToInt32(hdfSelectedLeadCount.Value.Trim()) / Count;
                if ((Convert.ToInt32(hdfSelectedLeadCount.Value.Trim()) % Count) > 0 && bulkAmount > 0)
                    bulkAmount = bulkAmount + 1;
                else if (bulkAmount == 0)
                    bulkAmount = 1;
                if ((bulkAmount * Count) <= Convert.ToInt32(hdfSelectedLeadCount.Value.Trim()))
                {
                    foreach (GridViewRow grviewrow in gvBulkAllocateConsult.Rows)
                    {
                        CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkSelect");
                        TextBox txtNoOfLeads = (TextBox)grviewrow.FindControl("txtNoOfLeads");
                        if (chkbx != null && txtNoOfLeads != null)
                        {
                            if (chkbx.Checked)
                            {
                                txtNoOfLeads.Enabled = true;
                                txtNoOfLeads.Text = Convert.ToString(bulkAmount);
                            }
                        }
                    }
                }
                else
                {
                    Int32[] arr = AllocateLeads(Count, bulkAmount, Convert.ToInt32(hdfSelectedLeadCount.Value.Trim()));
                    int i = 0;
                    if (arr.Length == Count)
                    {
                        foreach (GridViewRow grviewrow in gvBulkAllocateConsult.Rows)
                        {
                            CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkSelect");
                            TextBox txtNoOfLeads = (TextBox)grviewrow.FindControl("txtNoOfLeads");
                            if (chkbx != null && txtNoOfLeads != null)
                            {
                                if (chkbx.Checked)
                                {
                                    txtNoOfLeads.Enabled = true;
                                    txtNoOfLeads.Text = arr[i].ToString().Trim();
                                    i++;
                                }
                            }
                        }
                    }
                }
                if (Session["Status"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Status"])) && Convert.ToString(Session["Status"]).Trim().ToUpper() == "U")
                {
                    ReallocateLeads(hdfSelProspIdForReass.Value.Trim(), hdfConsultantType.Value.Trim());
                }
                else if (Session["Status"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Status"])) && ((Convert.ToString(Session["Status"]).Trim().ToUpper() == "CUR") || (Convert.ToString(Session["Status"]).Trim().ToUpper() == "NYC")))
                {
                    ReallocationLeads(hdfSelProspIdForReass.Value.Trim(), hdfConsultantType.Value.Trim());
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkBtnBulkAllocate_Click.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 14 Nov 2013
    /// Description: Close Panel Of Bulk Assignment Of Leads
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnReassClose_Click(object sender, EventArgs e)
    {
        pnlRallocation.Visible = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 26 Nov 2013
    /// Description: Bulk Reassignment of Leads
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnBulkReAssign_Click(object sender, EventArgs e)
    {
        try
        {
            lblRalocationHead.Text = Resources.PFSalesResource.ReassignContacts.Trim();
            DataTable Dt = new DataTable();
            Employee objEmp = new Employee();
            string strConsultId = "0";
            StringBuilder strIds = new StringBuilder();
            if (Session["ConsultantId"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["ConsultantId"]).Trim()) && Convert.ToInt64(Session["ConsultantId"]) > 0)
            {
                if (Session["Flag"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Flag"])) && Convert.ToString(Session["Flag"]).Trim().ToUpper() == "PF")
                {
                    hdfConsultantType.Value = "PF";
                    objEmp.FName = string.Empty;
                    objEmp.RoleId = 3;//Hard Code For Consultant
                    Dt = objEmpBM.GetAllEmployee(objEmp);
                }
                else if (Session["Flag"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Flag"])) && Convert.ToString(Session["Flag"]).Trim().ToUpper() == "FC")
                {
                    hdfConsultantType.Value = "FC";
                    objEmp.FName = string.Empty;
                    objEmp.RoleId = 5;//Hard Code For Finanace Consultant
                    Dt = objEmpBM.GetAllEmployee(objEmp);
                }
                else
                {
                    hdfConsultantType.Value = "PF";
                    objEmp.FName = string.Empty;
                    objEmp.RoleId = 3;//Hard Code For Consultant
                    Dt = objEmpBM.GetAllEmployee(objEmp);
                }
            }
            if (Dt != null & Dt.Rows.Count > 0)
            {
                gvBulkAllocateConsult.DataSource = Dt;
                gvBulkAllocateConsult.DataBind();
            }
            else
            {
                gvBulkAllocateConsult.DataSource = null;
                gvBulkAllocateConsult.DataBind();
            }
            int cnt = 0;
            for (int i = 0; i < gvNYC.Rows.Count; i++)
            {
                HiddenField hdfId = (HiddenField)gvNYC.Rows[i].FindControl("hdfId");
                CheckBox chkSelect = (CheckBox)gvNYC.Rows[i].FindControl("chkSelect");
                if (chkSelect != null && hdfId != null)
                {
                    if (chkSelect.Checked)
                    {
                        cnt++;
                        strIds.Append(hdfId.Value.Trim() + ",");
                    }
                }
            }
            if (cnt > 0)
                pnlRallocation.Visible = true;
            else
            {
                lblAddErrMsg.Text = Resources.PFSalesResource.SelLeadSelConsultVal.Trim();
                lblAddSucMsg.Text = string.Empty;
                dvadderror.Visible = true;
                dvaddSucc.Visible = false;
            }
            hdfSelectedLeadCount.Value = Convert.ToString(cnt).Trim();
            hdfSelProspIdForReass.Value = Convert.ToString(strIds).TrimEnd(',');
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnBulkReAssign_Click.Error:" + ex.StackTrace);
        }
    }

    #region Date 21Aug13 By Kalpana
    /// <summary>
    /// Created By: Kalpana Shinde
    /// Created Date: 21 Aug 2013
    /// Description: View not yet called FC
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFCNotYetCalled_Click(object sender, EventArgs e)
    {
        try
        {
            Session["CurrentPageIndex"] = 1;
            Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "CreatedDate";
            Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = Cls_Constant.VIEWSTATE_DESC;
            ClearMsg();
            Int64 ConsultantId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
            LinkButton lnkbtnCurrWorkLoad = (LinkButton)sender;
            ddlPageSizeNYC.SelectedValue = "50";
            Session["TotalRecCount"] = "50";
            if (ConsultantId > 0)
            {

                Session["ConsultantId"] = ConsultantId;
                lnkbtnBulkReAssign.Visible = true;
                lnkbtnBulkAssign.Visible = false;
                Session["Status"] = "NYC";
                DataTable dt = objProspectBM.GetFCProspDetAssignedToConsult(ConsultantId, Convert.ToDateTime(txtFCUnAlocFromDate.Text.Trim()), Convert.ToDateTime(txtFCUnalocToDate.Text.Trim()), 0);
                if (dt != null && dt.Rows.Count > 0)
                {
                    ViewState["FilteredData"] = ViewState["ProspData"] = null;
                    ViewState["FromDate"] = txtFCUnAlocFromDate.Text.Trim();
                    ViewState["ToDate"] = txtFCUnalocToDate.Text.Trim();
                    ViewState["ConsultantId"] = ConsultantId;
                    Session["Flag"] = ViewState["FCFlag"] = "FC";
                    ViewState["Flag"] = "NYC";
                    lblTotLeadView.Text = Resources.PFSalesResource.WorkloadDetails.Trim();
                    lblTitle.Text = Resources.PFSalesResource.NotYetCalledDetails.Trim();
                    if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()))
                        BindNYCLeadGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim(), ViewState["Flag"].ToString().Trim());
                    dvFilterAlloc.Visible = dvFilterUnAlloc.Visible = dvClearFilter.Visible = lnkbtnClearFilter.Visible = lnkbtnFilterUnall.Visible = lnkbtnFilterAlloc.Visible = false;
                    pnlNYCViewPopUp.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnFCCurrWorkLoad_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Kalpana Shinde
    /// Created Date: 21 Aug 2013
    /// Description: Button Click Event Of Close Manage Activity Pop Up. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnManageAct_Click(object sender, EventArgs e)
    {
        Int64 ProspectId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
        //hdfSelProspId.Value = ProspectId.ToString().Trim();
        Label lblprospName = (Label)(((GridViewRow)((LinkButton)sender).NamingContainer).FindControl("lblprospName"));
        //MethodInfo methods1 = UC_AddActivity1.GetType().GetMethod("BindActStatuses");// ((Page)this.Parent).GetType().GetMethod("BindMangeActivity");
        //if (methods1 != null)
        //{
        //    methods1.Invoke(UC_AddActivity1, null);
        //}
        if (Session["MyProspData"] != null && ((DataTable)Session["MyProspData"]).Rows.Count > 0 && ProspectId > 0)
        {
            DataRow[] dr = ((DataTable)(Session["MyProspData"])).Select("Id='" + ProspectId.ToString().Trim() + "'");
            if (dr != null && dr.Length > 0)
            {
                Int64 RowNum = Convert.ToInt64(Convert.ToString(dr[0]["RowNo"]).Trim());
                Session["MyCurrentProsp"] = Convert.ToString(RowNum).Trim();
            }
        }

        HiddenField hdfForW = (HiddenField)(((GridViewRow)((LinkButton)sender).NamingContainer).FindControl("hdfForW"));
        if (hdfForW != null && !string.IsNullOrEmpty(hdfForW.Value.Trim()))
            Session["ForW"] = hdfForW.Value.Trim();
        else
            Session["ForW"] = "W";

        Response.Redirect("ManageActivities.aspx?ProspectId=" + ProspectId.ToString().Trim());

        //HiddenField hdfPropStatusId = (HiddenField)(((GridViewRow)((LinkButton)sender).NamingContainer).FindControl("hdfPropStatusId"));
        //if (hdfPropStatusId != null && !string.IsNullOrEmpty(hdfPropStatusId.Value.Trim()))
        //{
        //    hdfManProspStatusId.Value = hdfPropStatusId.Value.Trim();
        //}
        //if (lblprospName != null && !string.IsNullOrEmpty(lblprospName.Text.Trim()))
        //{
        //    lblSelectedProsp.Text = lblprospName.Text.Trim();//lblAddActProspect.Text =
        //}
        //BindMangeActivity(ProspectId);
    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date: 3 oct 2013
    /// Description: Button Click Event Of Edit Contact Pop Up. 
    /// </summary>
    protected void lnkbtnReassignAct_Click(object sender, EventArgs e)
    {
        Int64 ProspectId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
        MethodInfo methodsAEC = UC_AddEditContact1.GetType().GetMethod("BindAllStatuses");
        if (methodsAEC != null)
            methodsAEC.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC1 = UC_AddEditContact1.GetType().GetMethod("BindAllCountry");
        if (methodsAEC1 != null)
            methodsAEC1.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC2 = UC_AddEditContact1.GetType().GetMethod("BindFormats");
        if (methodsAEC2 != null)
            methodsAEC2.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC3 = UC_AddEditContact1.GetType().GetMethod("BindAllMakes");
        if (methodsAEC3 != null)
            methodsAEC3.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC4 = UC_AddEditContact1.GetType().GetMethod("BindAllSources");
        if (methodsAEC4 != null)
            methodsAEC4.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC5 = UC_AddEditContact1.GetType().GetMethod("BindConsultant");
        if (methodsAEC5 != null)
            methodsAEC5.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC6 = UC_AddEditContact1.GetType().GetMethod("BindFConsultant");
        if (methodsAEC6 != null)
            methodsAEC6.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC7 = UC_AddEditContact1.GetType().GetMethod("BindContacts");
        if (methodsAEC7 != null)
            methodsAEC7.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC8 = UC_AddEditContact1.GetType().GetMethod("BindProfessions");
        if (methodsAEC8 != null)
            methodsAEC8.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC9 = UC_AddEditContact1.GetType().GetMethod("BindFinance");
        if (methodsAEC9 != null)
            methodsAEC9.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC10 = UC_AddEditContact1.GetType().GetMethod("BindWUHValues");
        if (methodsAEC10 != null)
            methodsAEC10.Invoke(UC_AddEditContact1, null);

        MethodInfo methodsAEC11 = UC_AddEditContact1.GetType().GetMethod("BinFinReqFrom");
        if (methodsAEC11 != null)
            methodsAEC11.Invoke(UC_AddEditContact1, null);

        //hdfSelProspId.Value = ProspectId.ToString().Trim();
        Label lblprospName = (Label)(((GridViewRow)((LinkButton)sender).NamingContainer).FindControl("lblprospName"));
        LinkButton lnkbtnSave = (LinkButton)UC_AddEditContact1.FindControl("lnkbtnSave");
        LinkButton lnkbtnFinalClear = (LinkButton)UC_AddEditContact1.FindControl("lnkbtnFinalClear");
        HiddenField hdfForW = (HiddenField)(((GridViewRow)((LinkButton)sender).NamingContainer).FindControl("hdfForW"));
        if (hdfForW != null && !string.IsNullOrEmpty(hdfForW.Value.Trim()))
            Session["ForW"] = hdfForW.Value.Trim();
        else
            Session["ForW"] = "W";

        TextBox txtPostalCode = (TextBox)UC_AddEditContact1.FindControl("txtPostalCode");
        RequiredFieldValidator rfvPCode = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvPCode");
        DropDownList ddlPostalCode = (DropDownList)UC_AddEditContact1.FindControl("ddlPostalCode");
        RequiredFieldValidator rfvPostalCode = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvPostalCode");
        if (txtPostalCode != null && rfvPCode != null && ddlPostalCode != null && rfvPostalCode != null)
        {
            if (Session["ForW"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["ForW"]).Trim()))
            {
                if (Convert.ToString(Session["ForW"]).Trim().ToUpper() == "W")
                {
                    txtPostalCode.Visible = rfvPCode.Enabled = false;
                    ddlPostalCode.Visible = rfvPostalCode.Enabled = true;
                }
                else if (Convert.ToString(Session["ForW"]).Trim().ToUpper() == "F")
                {
                    txtPostalCode.Visible = rfvPCode.Enabled = true;
                    ddlPostalCode.Visible = rfvPostalCode.Enabled = false;
                }
            }
        }
        RequiredFieldValidator rfvCarMake = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvCarMake");
        RequiredFieldValidator rfvPhone = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvPhone");
        RequiredFieldValidator rfvState = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvState");
        RequiredFieldValidator rfvSource = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvSource");
        RequiredFieldValidator rfvModel = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvModel");
        RequiredFieldValidator rfvCountry = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvCountry");
        RequiredFieldValidator rfvAECPostalCode = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvPostalCode");
        RequiredFieldValidator rfvAECPCode = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvPCode");
        RequiredFieldValidator rfvReferredBy = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvReferredBy");
        RequiredFieldValidator rfvStatus = (RequiredFieldValidator)UC_AddEditContact1.FindControl("rfvStatus");

        if (rfvCarMake != null && rfvPhone != null && rfvState != null && rfvSource != null && rfvModel != null && rfvCountry != null && rfvAECPostalCode != null && rfvReferredBy != null && rfvStatus != null && rfvAECPCode != null)
        {
            if (BasePage.UserSession.RoleId == 1)
            {
                rfvStatus.Enabled = rfvCarMake.Enabled = rfvPhone.Enabled = rfvState.Enabled = rfvModel.Enabled = rfvCountry.Enabled = rfvAECPostalCode.Enabled = rfvAECPCode.Enabled = rfvReferredBy.Enabled = false;
            }
            else if (BasePage.UserSession.RoleId == 3)
            {
                rfvStatus.Enabled = rfvCarMake.Enabled = rfvPhone.Enabled = rfvState.Enabled = rfvModel.Enabled = rfvCountry.Enabled = rfvAECPostalCode.Enabled = rfvReferredBy.Enabled = true;
                rfvAECPCode.Enabled = false;
            }
            else if (BasePage.UserSession.RoleId == 5)
            {
                rfvStatus.Enabled = rfvCarMake.Enabled = rfvPhone.Enabled = rfvState.Enabled = rfvModel.Enabled = rfvCountry.Enabled = rfvAECPostalCode.Enabled = rfvReferredBy.Enabled = false;
                rfvAECPCode.Enabled = true;
            }
            else
            {
                rfvStatus.Enabled = rfvCarMake.Enabled = rfvPhone.Enabled = rfvState.Enabled = rfvModel.Enabled = rfvCountry.Enabled = rfvAECPostalCode.Enabled = rfvAECPCode.Enabled = rfvReferredBy.Enabled = true;
            }
        }


        if (lnkbtnFinalClear != null && lnkbtnSave != null)
        {
            MethodInfo methods = UC_AddEditContact1.GetType().GetMethod("ClearAll");
            if (methods != null)
                methods.Invoke(UC_AddEditContact1, null);
            MethodInfo methods1 = UC_AddEditContact1.GetType().GetMethod("ClearMsg");
            if (methods1 != null)
                methods1.Invoke(UC_AddEditContact1, null);
            MethodInfo methods2 = UC_AddEditContact1.GetType().GetMethod("EditContact");
            if (methods2 != null)
            {
                //if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
                //{
                ////..modified by: Ayyaj
                //Session["isPForFC"] = hdfProspectId.Value.Trim().ToString();
                lblAddContactHead.Text = Resources.PFSalesResource.UpdteProspDetails.Trim();
                object[] objParam = new object[] { ProspectId };
                methods2.Invoke(UC_AddEditContact1, objParam);
                pnlAddContact.Visible = true;
                lnkbtnSave.Text = Resources.PFSalesResource.update.Trim();
                lnkbtnSave.ToolTip = Resources.PFSalesResource.UpdateProspDet.Trim();
                lnkbtnFinalClear.Text = Resources.PFSalesResource.Cancel.Trim();
                lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.Cancel.Trim();
                //}
            }
        }
        //CleraMsg();
    }

    /// <summary>
    /// Created By: Kalpana
    /// Created Date: 21 Aug 2013
    /// Description: View Not yet called lead of PF
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnNYCWorkLoad_Click(object sender, EventArgs e)
    {
        try
        {
            ClearMsg();
            Int64 ConsultantId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
            Session["CurrentPageIndex"] = 1;
            Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "CreatedDate";
            Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = Cls_Constant.VIEWSTATE_DESC;
            LinkButton lnkbtnCurrWorkLoad = (LinkButton)sender;
            ddlPageSizeNYC.SelectedValue = "50";
            Session["TotalRecCount"] = "50";
            if (ConsultantId > 0)
            {
                lnkbtnBulkReAssign.Visible = true;
                lnkbtnBulkAssign.Visible = false;
                Session["ConsultantId"] = ConsultantId;

                Session["Status"] = "NYC";
                DataTable dt = objProspectBM.GetCountProspDetAssignedToConsult(ConsultantId, Convert.ToDateTime(txtUnAlocFromDate.Text.Trim()), Convert.ToDateTime(txtUnalocToDate.Text.Trim()), 0);
                if (dt != null && dt.Rows.Count > 0 && Convert.ToInt64(dt.Rows[0]["TtlCount"])>0)
                {
                    ViewState["FilteredData"] = ViewState["ProspData"] = null;
                    ViewState["FromDate"] = txtUnAlocFromDate.Text.Trim();
                    ViewState["ToDate"] = txtUnalocToDate.Text.Trim();
                    // ViewState["Flag"] = "W";
                    ViewState["ConsultantId"] = ConsultantId;
                    Session["Flag"] = ViewState["FCFlag"] = "PF";
                    ViewState["Flag"] = "NYC";
                    lblTotLeadView.Text = Resources.PFSalesResource.WorkloadDetails.Trim();
                    lblTitle.Text = Resources.PFSalesResource.NotYetCalledDetails.Trim();
                    if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()))
                        BindNYCLeadGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim(), ViewState["Flag"].ToString().Trim());
                    dvFilterAlloc.Visible = dvFilterUnAlloc.Visible = dvClearFilter.Visible = lnkbtnClearFilter.Visible = lnkbtnFilterUnall.Visible = lnkbtnFilterAlloc.Visible = false;
                    pnlNYCViewPopUp.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnCurrWorkLoad_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Kalpana Shinde
    /// Created Date: 21 Aug 2013
    /// Description: Close Not Yet Called Detail's Pop Up
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnNYCPopClose_Click(object sender, EventArgs e)
    {
        Session["ConsultantId"] = null;
        Session["Status"] = null;

        pnlNYCViewPopUp.Visible = false;
    }

    /// <summary>
    /// Created By: Kalpana Shinde
    /// Created Date: 21 Aug 2013
    /// Description: Selected Index Changed Event Of Page Size's Drop Down List of NOt yet called
    /// </summary>
    /// <param name="Sender"></param>
    /// <param name="e"></param>
    protected void ddlPageSizeNYC_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Session["CurrentPageIndex"] = pagerParent.CurrentIndex = 1;
            ClearMsg();
            if (Convert.ToInt16(ddlPageSizeNYC.SelectedValue.Trim()) == 1)
            {
                Int32 intAllCount = Convert.ToInt32(ViewState["TotalNYCCount"]);
                if (Session["TotalRecCount"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["TotalRecCount"])))
                    gvNYC.PageSize = Convert.ToInt32(Session["TotalRecCount"]);
            }
            else
            {
                gvNYC.PageSize = Convert.ToInt32(ddlPageSizeNYC.SelectedValue.Trim());
            }
            if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()))
                BindNYCLeadGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim(), ViewState["Flag"].ToString().Trim());
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.ddlPageSize_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Kalpana Shinde
    /// Created Date: 21 Aug 2013
    /// Description: Gridview Page Index Changing Event of Not yet called
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvNYC_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvNYC.PageIndex = e.NewPageIndex;
            if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()))
                BindNYCLeadGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim(), ViewState["Flag"].ToString().Trim());
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SearchProspect.gvprosp_PageIndexChanging Error:" + ex.StackTrace);
        }
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
        pnlAddContact.Visible = false;
        // ClearMessage();
    }

    /// <summary>
    /// Created By: Kalpana Shinde
    /// Created Date: 21 Aug 2013
    /// Description: Gridview Page Sorting Event Of GridView Not yet called. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvNYC_Soring(object sender, GridViewSortEventArgs e)
    {
        try
        {
            Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = e.SortExpression;
            DefineProspectSortDirection();
            if (ViewState["FromDate"] != null && ViewState["ToDate"] != null && !string.IsNullOrEmpty(ViewState["FromDate"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["ToDate"].ToString().Trim()) && ViewState["ConsultantId"] != null && !string.IsNullOrEmpty(ViewState["ConsultantId"].ToString().Trim()) && ViewState["FCFlag"] != null && !string.IsNullOrEmpty(ViewState["FCFlag"].ToString().Trim()) && !string.IsNullOrEmpty(ViewState["Flag"].ToString().Trim()))
                BindNYCLeadGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim(), ViewState["Flag"].ToString().Trim());

            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SearchProspect.gvprosp_Soring.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 Aug 2013
    /// Description: Row Data Bound Event Of Prospect's Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvNYC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label LblStatus;
                if (BasePage.UserSession.RoleId == 5)
                    LblStatus = (Label)e.Row.FindControl("lblFCstatus");
                else
                    LblStatus = (Label)e.Row.FindControl("lblstatus");
                if (LblStatus != null && !string.IsNullOrEmpty(LblStatus.Text.Trim()))
                {
                    switch (LblStatus.Text.Trim().ToUpper())
                    {
                        case "ACTIVE":
                            e.Row.BackColor = System.Drawing.Color.FromName("#E0FFFF");
                            break;
                        case "APP TAKEN":
                            e.Row.BackColor = System.Drawing.Color.FromName("#E0FFFF");
                            break;
                        case "AA/NP SENT":
                            e.Row.BackColor = System.Drawing.Color.FromName("#E0FFFF");
                            break;
                        case "TENDER":
                            e.Row.BackColor = System.Drawing.Color.FromName("#FFE4E1");
                            break;
                        case "BA/SP REC":
                            e.Row.BackColor = System.Drawing.Color.FromName("#FFE4E1");
                            break;
                        case "LEAD":
                            e.Row.BackColor = System.Drawing.Color.FromName("#FFFFFF");
                            break;
                        case "PRE-TENDER":
                            e.Row.BackColor = System.Drawing.Color.FromName("#00FF00");
                            break;
                        default:
                            e.Row.BackColor = System.Drawing.Color.FromName("#DCF0FE");
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SearchProspect.gvprosp_RowDataBound.Error:" + ex.StackTrace);
        }
    }

    #endregion

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
            Session["CurrentPageIndex"] = gvNYC.PageIndex = Convert.ToInt32(e.CommandArgument);
            BindNYCLeadGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim(), ViewState["Flag"].ToString().Trim());
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message);
            //throw ex;
        }
    }

    public void pagerParentProsp_Command(object sender, CommandEventArgs e)
    {
        try
        {
            pagerParentProsp.CurrentIndex = Convert.ToInt32(e.CommandArgument);
            Session["CurrentPageIndex"] = gvprosp.PageIndex = Convert.ToInt32(e.CommandArgument);
            BindProspGrid(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), ViewState["Flag"].ToString().Trim(), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim());
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message);
            //throw ex;
        }
    }

    #endregion

    #region Methods

    #region  "PF Leads Allocation"
    /// <summary>
    /// Crearted By:Pravin Gholap
    /// Created Date:30 May 2013
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
            Logger.Error(ex.Message + "LeadAllocation.DefineSortDirection.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Crearted By:Pravin Gholap
    /// Created Date:5 June 2013
    /// Description:Define the sort direction for sorting the Prospect's grid view
    /// </summary>
    private void DefineProspectSortDirection()
    {
        try
        {
            if (Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] != null)
            {
                if (Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1].ToString() == Cls_Constant.VIEWSTATE_ASC)
                {
                    Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = Cls_Constant.VIEWSTATE_DESC;
                }
                else
                {
                    Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = Cls_Constant.VIEWSTATE_ASC;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.DefineProspectSortDirection.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Crearted By:Pravin Gholap
    /// Created Date:17 Aug 2013
    /// Description:Define the sort direction for sorting the grid view
    /// </summary>
    private void DefineFCSortDirection()
    {
        try
        {
            if (ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION2] != null)
            {
                if (ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION2].ToString() == Cls_Constant.VIEWSTATE_ASC)
                {
                    ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION2] = Cls_Constant.VIEWSTATE_DESC;
                }
                else
                {
                    ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION2] = Cls_Constant.VIEWSTATE_ASC;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.DefineFCSortDirection.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 30 May 2013
    /// Description: Clear All Message's Text
    /// </summary>
    private void ClearMsg()
    {
        lblFCSerSuccess.Text = lblFCSerError.Text = lblSerErrMsg.Text = lblSerSucMsg.Text = string.Empty;
        dvFCSerSuccess.Visible = dvFCserError.Visible = dvaserSuccess.Visible = dvsererror.Visible = false;
        lblAddErrMsg.Text = lblAddSucMsg.Text = string.Empty;
        dvadderror.Visible = dvaddSucc.Visible = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 30 May 2013
    /// Description: Bind ConsulTants
    /// </summary>
    private void BindConsultants()
    {
        try
        {
            Employee objEmp = new Employee();
            objEmp.FName = string.Empty;
            objEmp.RoleId = 3;//Hard Code For Consultant

            DataTable Dt = objEmpBM.GetAllEmployee(objEmp);
            if (Dt != null & Dt.Rows.Count > 0)
            {
                DataView dV = Dt.DefaultView;
                //dV.RowFilter = "IsInFleetTeam=" + "0";  Added to avoid fleet team consultants in normal lead alocation flow
                dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
                gvAllocate.DataSource = Dt;
                gvAllocate.DataBind();
            }
            else
            {
                gvAllocate.DataSource = null;
                gvAllocate.DataBind();
            }
        }

        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.BindContacts.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 June 2013
    /// Description: Bind Prospect's Grid View Data
    /// </summary>
    private void BindProspGrid(DateTime FromDate, DateTime ToDate, string Flag, Int64 ConsultantId, string FCFlag)
    {
        try
        {
            objProsp.PageSize = gvprosp.PageSize;
            pagerParentProsp.PageSize = gvprosp.PageSize;
            if (Session["CurrentPageIndex"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["CurrentPageIndex"])))
            {
                objProsp.PageIndex = Convert.ToInt64(Session["CurrentPageIndex"]);
                pagerParentProsp.CurrentIndex = Convert.ToInt32(Session["CurrentPageIndex"]);
            }
            else
                Session["CurrentPageIndex"] = objProsp.PageIndex = pagerParentProsp.CurrentIndex;

            DataSet Ds = new DataSet();
            if (Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1] != null && Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] != null && !string.IsNullOrEmpty(Convert.ToString(Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1]).Trim()))
            {
                if (Convert.ToString(Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1]) == Cls_Constant.VIEWSTATE_ASC)
                    Ds = objProspectBM.GetAllNYCForPFAndFC(FromDate, ToDate, ConsultantId, FCFlag, Flag, objProsp.PageIndex, gvprosp.PageSize, Convert.ToString(Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1]).Trim() + " ASC");
                else if (Convert.ToString(Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1]) == Cls_Constant.VIEWSTATE_DESC)
                    Ds = objProspectBM.GetAllNYCForPFAndFC(FromDate, ToDate, ConsultantId, FCFlag, Flag, objProsp.PageIndex, gvprosp.PageSize, Convert.ToString(Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1]).Trim() + " DESC");
                else
                    Ds = objProspectBM.GetAllNYCForPFAndFC(FromDate, ToDate, ConsultantId, FCFlag, Flag, objProsp.PageIndex, gvprosp.PageSize, Convert.ToString(Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1]).Trim() + " ASC");
            }
            else
                Ds = objProspectBM.GetAllNYCForPFAndFC(FromDate, ToDate, ConsultantId, FCFlag, Flag, objProsp.PageIndex, gvprosp.PageSize, string.Empty);
            if (Ds != null && Ds.Tables.Count > 0)
            {
                DataTable Dt = Ds.Tables[0];
                if (Dt != null & Dt.Rows.Count > 0)
                {
                    DataView dV = Dt.DefaultView;
                    dV.Sort = string.Format("{0} {1}", Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1].ToString(), Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1].ToString());
                    gvprosp.DataSource = Dt;
                    gvprosp.DataBind();
                    ViewState["ProspData"] = Dt;
                    ViewState["TotalCount"] = Dt.Rows.Count;
                    t3 = new Thread(saveDataToViewState);
                    t3.Start();
                    if (Session["MyCurrentProsp"] == null && string.IsNullOrEmpty(Convert.ToString(Session["MyCurrentProsp"]).Trim()))
                        Session["MyCurrentProsp"] = "1";
                }
                else
                {
                    Session["MyProspData"] = gvprosp.DataSource = null;
                    gvprosp.DataBind();
                    ViewState["TotalCount"] = "0";
                }
                pagerParentProsp.PageSize = gvprosp.PageSize;
                if (Ds.Tables[1].Rows.Count > 0)
                {
                    pagerParentProsp.ItemCount = Convert.ToDouble(Ds.Tables[1].Rows[0][0]);
                }
                else
                    pagerParentProsp.ItemCount = 0;
            }
            else
            {
                gvprosp.DataSource = null;
                gvprosp.DataBind();
            }
            if (Session["MyCurrentProsp"] == null && string.IsNullOrEmpty(Convert.ToString(Session["MyCurrentProsp"]).Trim()))
                Session["MyCurrentProsp"] = "1";
            t3.Join(10);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.BindProspGrid.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Get Total Enquiries Count
    /// </summary>
    private void GetTotalCount()
    {
        try
        {
            DataTable Dt = objProspectBM.GetTotalLeadCount(Convert.ToDateTime(txtTotEntFrmDate.Text.Trim()), Convert.ToDateTime(txtTotEntToDate.Text.Trim()));
            if (Dt != null && Dt.Rows.Count > 0)
                lnkbtnTodTotEnq.Text = Dt.Rows[0]["LeadCount"].ToString().Trim();
            if (lnkbtnTodTotEnq.Text == "0")
                lnkbtnTodTotEnq.Enabled = false;
            else
                lnkbtnTodTotEnq.Enabled = true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.GetTotalCount.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Get Total Enquiries Count
    /// </summary>
    private void GetTotalCount1()
    {
        try
        {
            DataTable Dt = objProspectBM.GetTotalLeadCount(Convert.ToDateTime(txtTotEntFrmDate1.Text.Trim()), Convert.ToDateTime(txtTotEntToDate1.Text.Trim()));
            if (Dt != null && Dt.Rows.Count > 0)
                lnkbtnTodTotEnq1.Text = Dt.Rows[0]["LeadCount"].ToString().Trim();
            if (lnkbtnTodTotEnq1.Text == "0")
                lnkbtnTodTotEnq1.Enabled = false;
            else
                lnkbtnTodTotEnq1.Enabled = true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.GetTotalCount1.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Get Total Unallocated Enquiries Count
    /// </summary>
    private void GetUnAlocatedEnqCount()
    {
        try
        {
            DataTable Dt = objProspectBM.GetUnAlocatedEnqCount(Convert.ToDateTime(txtUnAlocFromDate.Text.Trim()), Convert.ToDateTime(txtUnalocToDate.Text.Trim()));
            if (Dt != null && Dt.Rows.Count > 0)
                lnkbtnUnallocatedEnq.Text = Dt.Rows[0]["LeadCount"].ToString().Trim();
            if (lnkbtnUnallocatedEnq.Text == "0")
                lnkbtnUnallocatedEnq.Enabled = false;
            else
                lnkbtnUnallocatedEnq.Enabled = true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.GetUnAlocatedEnqCount.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Get Total Unallocated Enquiries Count
    /// </summary>
    private void GetUnAlocatedEnqCount1()
    {
        try
        {
            DataTable Dt = objProspectBM.GetUnAlocatedEnqCount(Convert.ToDateTime(txtUnAlocFromDate1.Text.Trim()), Convert.ToDateTime(txtUnalocToDate1.Text.Trim()));
            if (Dt != null && Dt.Rows.Count > 0)
                lnkbtnUnallocatedEnq1.Text = Dt.Rows[0]["LeadCount"].ToString().Trim();
            if (lnkbtnUnallocatedEnq1.Text == "0")
                lnkbtnUnallocatedEnq1.Enabled = false;
            else
                lnkbtnUnallocatedEnq1.Enabled = true;

            if (Convert.ToInt32(lnkbtnUnallocatedEnq1.Text.Trim()) > 0)
                lnkbtnAllocate.Enabled = true;
            else
                lnkbtnAllocate.Enabled = false;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.GetUnAlocatedEnqCount1.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Get Oldest Enquiry Date
    /// </summary>
    private void GetOldestEnquiryDate()
    {
        try
        {
            DataTable Dt = objProspectBM.GetOldestEnquiryDate();
            if (Dt != null && Dt.Rows.Count > 0)
            {
                txtFCTotEntFrmDate1.Text = txtFCUnAlocFromDate1.Text = txtFCTotEntFrmDate.Text = txtFCUnAlocFromDate.Text = txtTotEntFrmDate1.Text = txtUnAlocFromDate1.Text = txtTotEntFrmDate.Text = txtUnAlocFromDate.Text = Dt.Rows[0]["CreatedDate"].ToString().Trim();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.GetOldestEnquiryDate.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Clear All Control's Values
    /// </summary>
    private void ClearAll()
    {
        try
        {
            GetOldestEnquiryDate();
            txtBulkAmt.Text = string.Empty;
            txtTotEntToDate.Text = txtUnalocToDate.Text = DateTime.Today.Date.ToString(Resources.PFSalesResource.dateformat.Trim());
            GetTotalCount();
            GetUnAlocatedEnqCount();
            GetUnAlocatedEnqCount1();
            GetTotalCount1();
            txtTotEntFrmDate.Focus();
            CheckBox chkheadbx = (CheckBox)gvAllocate.HeaderRow.FindControl("chkSelectAll");
            if (chkheadbx != null)
                chkheadbx.Checked = false;
            foreach (GridViewRow grviewrow in gvAllocate.Rows)
            {
                CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkSelect");
                TextBox txtNoOfLeads = (TextBox)grviewrow.FindControl("txtNoOfLeads");
                if (chkbx != null && txtNoOfLeads != null)
                {
                    if (chkbx.Checked)
                    {
                        chkbx.Checked = false;
                        txtNoOfLeads.Text = "0";
                        //txtNoOfLeads.Enabled = false;
                    }
                    else
                    {
                        txtNoOfLeads.Text = "0";
                        //txtNoOfLeads.Enabled = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.ClearAll.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Send Email To Consultant 
    /// </summary>
    /// <param name="emilToId"></param>
    /// <param name="noOfLeads"></param>
    /// <param name="Name"></param>
    /// <returns></returns>
    private Boolean SendMail(string emilToId, int noOfLeads, string Name, bool IsFleetTeamLead)
    {
        Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
        string FileContent = string.Empty;
        try
        {
            //objEmailHelper.EmailFromID = BasePage.UserSession.EmailFromID;ConfigurationManager.AppSettings["EmailFromID"].ToString();
            objEmailHelper.EmailSubject = "Lead Assignment";
            //objEmailHelper.SMTPServerIP = ConfigurationManager.AppSettings["SMTPServerIP"].ToString();
            // objEmailHelper.SMTPUserID = ConfigurationManager.AppSettings["SMTPUserID"].ToString();
            // objEmailHelper.SMTPUserPwd = ConfigurationManager.AppSettings["SMTPUserPwd"].ToString();
            objEmailHelper.EmailToID = emilToId;
            if (IsFleetTeamLead == true)
                FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + Name.Trim() + "<br /><br /> Please be advised that <b>Fleat Team Leads</b> have been allocated.<br /><br /> Thanks you<br /> Quotacon</span>";
            else
                FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + Name.Trim() + "<br /><br /> Please be advised that leads have been allocated.<br /><br /> Thanks you<br /> Quotacon</span>";

            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBm.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), "EMail sent successfully", "Lead Assignment", "Lead Allocation");
                return true;
            }
            else
            {
                objMstBm.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Lead Assignment", "Lead Allocation");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.SendMail.Error:" + ex.StackTrace);
            objMstBm.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Lead Assignment", "Lead Allocation");
            return false;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
    /// Description: Send Email To Consultant 
    /// </summary>
    /// <param name="emilToId"></param>
    /// <param name="noOfLeads"></param>
    /// <param name="Name"></param>
    /// <returns></returns>
    private Boolean SendConsultMail(string emilToId, string Name, string FCConsultName, string FCEmail, string FCPhone, string ConsultExt)
    {
        Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
        string FileContent = string.Empty;
        try
        {
            objEmailHelper.EmailSubject = "Fincar Lead Assignment";
            objEmailHelper.EmailToID = emilToId;
            FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + Name.Trim() + "<br /><br /> The lead you have refered for finance has been allocated to.&nbsp;&nbsp;" + FCConsultName.Trim() + ".&nbsp;&nbsp;Please find his/her details as given bellow<br /><br /><b>Email:&nbsp;&nbsp;</b>" + FCEmail.Trim() + "<br /><b>Phone:&nbsp;&nbsp;</b>" + FCPhone.Trim() + ((!string.IsNullOrEmpty(ConsultExt.Trim())) ? ("(" + ConsultExt.Trim() + ")") : "") + "<br />Thank you<br /> PFSales Team</span>";
            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBm.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), "EMail sent successfully", "Fincar Lead Assignment", "Lead Allocation");
                return true;
            }
            else
            {
                objMstBm.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Fincar Lead Assignment", "Lead Allocation");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.SendMail.Error:" + ex.StackTrace);
            objMstBm.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Fincar Lead Assignment", "Lead Allocation");
            return false;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
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
        //string repEmail = BasePage.UserSession.EmailFromID;
        Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
        try
        {
            objEmailHelper.EmailFromID = ConsultEmail; //BasePage.UserSession.EmailFromID = "markellis@privatefleet.com.au";
            objEmailHelper.EmailSubject = "Vehicle Enquiry – Private Fleet";
            objEmailHelper.EmailToID = emilToId;
            //objEmailHelper.EmailCcID = "markellis@privatefleet.com.au";//till 1st july 2014
            ArrayList arrAttachments = new ArrayList();
            arrAttachments.Add(hdfAttachmentPath.Value.Trim());
            objEmailHelper.PostedFiles = arrAttachments;
            FileContent = "<div style='font: 12px/17px arial,helvetica,'Liberation Sans',FreeSans,sans-serif;color: #333333;'>"
                               + "Dear " + Name.Trim() + ",<br><br> Thank you for your enquiry, I am pleased to advise that " + consultFullName + ", who is one of our most experienced consultants and will be your dedicated contact. " + ConsultantName + " will be in contact with you shortly and will be more than happy to assist you with your purchase including:"
                               + "<br><ul><li> Initial <b>advice</b> on vehicle selection</li><li> Arranging a <b>test drive</b> if you need this</li><li> <b>Valuation</b> on you current vehicle if you are considering trading it against the new car</li><li>Tendering your requirements to our extensive dealer network to get you the best possible <b>fleet discount pricing</b></li></ul>"
                               //+ "<br><br>If it is more convenient for you to contact us then please call " + ConsultantName.Trim() + " on 1300 303 181 or email " + ConsultEmail
                               + "<br><br>If it is more convenient for you to contact us then please call " + ConsultantName.Trim() + " on 1300 303 181 or email <a href = 'mailto:" + ConsultEmail + "' style=color: Blue; text-decoration: underline;>" + ConsultEmail + "</a>"
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
                               //+ "<br><a href='http://www.linkedin.com/pub/mark-ellis/3/240/3b6'><img src='Images/LinkedIn.png'/></a><br>";
            objEmailHelper.EmailBody = FileContent;
            //objEmailHelper.ImagePath =Server.MapPath("Images/LinkedIn.png");
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBm.SaveEmailDetails(emilToId, ConsultEmail.Trim(), FileContent.Trim(), "EMail sent successfully", "Vehicle Enquiry – Private Fleet", "Add Prospect");
                return true;
            }
            else
            {
                objMstBm.SaveEmailDetails(emilToId, ConsultEmail.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Vehicle Enquiry – Private Fleet", "Add Prospect");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.SendProspectMail.Error:" + ex.StackTrace);
            objMstBm.SaveEmailDetails(emilToId, ConsultEmail.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException), "Vehicle Enquiry – Private Fleet", "Add Prospect");
            return false;
        }
        //finally
        //{
        //    //BasePage.UserSession.EmailFromID = repEmail;
        //}
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 June 2013
    /// Description: Bind Prospect's Grid View Data
    /// </summary>
    private void BindWorkloadGrid(DataTable Dt, Int64 ConsultantId)
    {
        try
        {
            if (Dt != null)
            {
                if (ViewState["ProspData"] != null)
                {
                    Dt = (DataTable)ViewState["ProspData"];
                    if (Dt != null & Dt.Rows.Count > 0)
                    {
                        DataView dV = Dt.DefaultView;
                        dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
                        gvprosp.DataSource = Dt;
                        gvprosp.DataBind();
                    }
                    else
                    {
                        gvprosp.DataSource = null;
                        gvprosp.DataBind();
                    }
                }
                else
                {
                    Dt = objProspectBM.GetProspDetAssignedToConsult(ConsultantId, Convert.ToDateTime(txtUnAlocFromDate.Text.Trim()), Convert.ToDateTime(txtUnalocToDate.Text.Trim()), 0);
                    if (Dt != null & Dt.Rows.Count > 0)
                    {
                        DataView dV = Dt.DefaultView;
                        dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION1].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION1].ToString());
                        gvprosp.DataSource = Dt;
                        gvprosp.DataBind();
                        ViewState["ProspData"] = Dt;
                    }
                    else
                    {
                        gvprosp.DataSource = null;
                        gvprosp.DataBind();
                    }
                }
            }
            else
            {
                Dt = objProspectBM.GetProspDetAssignedToConsult(ConsultantId, Convert.ToDateTime(txtUnAlocFromDate.Text.Trim()), Convert.ToDateTime(txtUnalocToDate.Text.Trim()), 0);
                if (Dt != null & Dt.Rows.Count > 0)
                {
                    DataView dV = Dt.DefaultView;
                    dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION1].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION1].ToString());
                    gvprosp.DataSource = Dt;
                    gvprosp.DataBind();
                    ViewState["ProspData"] = Dt;
                }
                else
                {
                    gvprosp.DataSource = null;
                    gvprosp.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.BindProspGrid.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 July 2013
    /// Description: Save Default Activity For Call When Assignment is done
    /// </summary>
    private void SaveDefaultActivity(string Name, Int64 Id, Int64 ConsultantId)
    {
        try
        {
            Logger.Debug("Start Saving Default Activity..................................................");
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
            Logger.Debug("Start Date:" + DateTime.Today.ToShortDateString());
            Logger.Debug("Start Time:" + DefaultTime);
            DateTime StartTime = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + DefaultTime);
            if (StartTime != null)//!string.IsNullOrEmpty(txtActTime.Text.Trim())
            {
                Logger.Debug("In Inner Loop:");
                objActivity.ActStartTime = StartTime;
                GetCountOfActForStime(objActivity.ActStartTime, TimeSpan1, ConsultantId);
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
            objActResource.ResourceId = ConsultantId;// BasePage.UserSession.VirtualRoleId;
            lstResources.Add(objActResource);
            string[] array = strIds.ToString().TrimEnd(',').Split(',');
            ActAlertDetails objActAlertDetails = new ActAlertDetails();
            // objActAlertDetails.AlertTypeId = Cls_Constant.MailAlert;// Hard Coded For Email
            // objActAlertDetails.AlertValueBefore = 0;// If Zero Minutes Alarm Value Selected
            // objActAlertDetails.SnoozValue = 0;
            // objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// //array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
            // lstActAlerts.Add(objActAlertDetails);
            //ActAlertDetails objActAlertDetails1 = new ActAlertDetails();
            // objActAlertDetails1.AlertTypeId = Cls_Constant.DashBoardAlert;// Hard Coded For Dashboard Alert
            // objActAlertDetails1.AlertValueBefore = 0;// If Zero Minutes Alarm Value Selected
            // objActAlertDetails1.SnoozValue = 0;
            // objActAlertDetails1.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();//array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
            //  lstActAlerts.Add(objActAlertDetails1);
            objActivity.LstAlertDetails = lstActAlerts;
            objActivity.LstReources = lstResources;
            objActivity.CreatedById = BasePage.UserSession.VirtualRoleId;
            objActivity.IsDeleted = false;
            Int64 Result = 0;
            Result = objActivityBM.AddActivity(objActivity);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.saveDefaultActivity.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Bind Fleet Leads
    /// </summary>
    private void BindFleetLeads()
    {
        try
        {
            DataTable Dt = objProspectBM.GetTeamLeadsForAssignments();
            if (Dt != null & Dt.Rows.Count > 0)
            {
                gvTeamLead.DataSource = Dt;
                gvTeamLead.DataBind();
                lnkbtnLeadTeamAllocate.Visible = lnkbtnClearTeamAllocate.Visible = true;
            }
            else
            {
                gvTeamLead.DataSource = null;
                gvTeamLead.DataBind();
                lnkbtnLeadTeamAllocate.Visible = lnkbtnClearTeamAllocate.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.BindContacts.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Bind Fleet Team ConsulTants
    /// </summary>
    /// <param name="ddlConsultants"></param>
    /// <param name="hdfConsultEmail"></param>
    /// <param name="hdfConsultFName"></param>
    private void BindFleetTeamConsult(DropDownList ddlConsultants, HiddenField hdfConsultEmail, HiddenField hdfConsultFName)
    {
        try
        {
            Employee objEmp = new Employee();
            objEmp.FName = string.Empty;
            objEmp.RoleId = 3;//Hard Code For Consultant
            DataTable Dt = objEmpBM.GetAllEmployee(objEmp);
            DataView dV = Dt.DefaultView;
            dV.RowFilter = "IsInFleetTeam=" + "1"; // Added to get fleet team consultants in Fleet Team Lead Alocation Flow
            Cls_BinderHelper.BindDropdownList(ddlConsultants, "Name", "VirtualRoleId", Dt);
            if (!ddlConsultants.Items.Contains(new ListItem(Resources.PFSalesResource.ConsultantAway.Trim())))
            {
                ListItem lst = new ListItem();
                lst.Text = Resources.PFSalesResource.ConsultantAway.Trim();
                lst.Value = "-1";
                ddlConsultants.Items.Add(lst);
            }
            //if (!string.IsNullOrEmpty(hdfFTCtoAssign.Value.Trim()) && Convert.ToInt64(hdfFTCtoAssign.Value.Trim()) > 0)
            //{
            //    ddlConsultants.SelectedValue = hdfFTCtoAssign.Value.Trim();
            //}
            //else
            //{
            DataTable Dt1 = objProspectBM.GetTeamLeadConsultToAssign();
            if (Dt1 != null && Dt1.Rows.Count > 0)
            {
                hdfFTCtoAssign.Value = Convert.ToString(Dt1.Rows[0]["VirtualRoleId"]).Trim();
                //ddlConsultants.SelectedValue = hdfFTCtoAssign.Value.Trim();
                hdfConsultEmail.Value = Convert.ToString(Dt1.Rows[0]["Email1"]).Trim();
                hdfConsultFName.Value = Convert.ToString(Dt1.Rows[0]["FName"]).Trim();
                foreach (ListItem item in ddlConsultants.Items)
                {
                    item.Attributes.CssStyle["display"] = "none";
                    if (item.Value == "0" || item.Value == "-1" || item.Value == Convert.ToString(Dt1.Rows[0]["VirtualRoleId"]).Trim())
                    {
                        item.Attributes.CssStyle["display"] = "block";
                    }
                }
                Session["SelectedIndex"] = ddlConsultants.Items.IndexOf(ddlConsultants.Items.FindByValue(Convert.ToString(Dt1.Rows[0]["VirtualRoleId"]).Trim()));
            }
            //}
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.BindFleetTeamConsult.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 24 July 2013
    /// Description: Bind Fleet Team ConsulTants
    /// </summary>
    /// <param name="ddlConsultants"></param>
    /// <param name="hdfConsultEmail"></param>
    /// <param name="hdfConsultFName"></param>
    private void BindConsultDetails(Int64 ConsultId, HiddenField hdfConsultEmail, HiddenField hdfConsultFName)
    {
        try
        {
            DataTable Dt = objMstBm.ConsultDetailsFromId(ConsultId);
            if (Dt != null && Dt.Rows.Count > 0)
            {
                hdfFCFTCtoAssign.Value = hdfFTCtoAssign.Value = ConsultId.ToString().Trim();
                hdfConsultEmail.Value = Dt.Rows[0]["Email1"].ToString().Trim();
                hdfConsultFName.Value = Dt.Rows[0]["FName"].ToString().Trim();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.BindFleetTeamConsult.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Manoj 
    /// Created Date: 8 Aug 2013
    /// Description: Allocate Leads When Lead Count is less than total leds selected for assignment
    /// </summary>
    /// <param name="ConsultantCount"></param>
    /// <param name="LeadCnt"></param>
    /// <param name="TotalLeads"></param>
    /// <returns></returns>
    private Int32[] AllocateLeads(int ConsultantCount, int LeadCnt, int TotalLeads)
    {
        Int32[] test = new Int32[ConsultantCount];
        try
        {
            if ((ConsultantCount * LeadCnt) <= TotalLeads)
            {
                // assign Normal way - Each consultant will get leads of count LeadCnt
                for (int i = 0; i < ConsultantCount; i++)
                    test[i] = LeadCnt;
            }
            else
            {
                int cnt = TotalLeads / ConsultantCount;
                int mod = TotalLeads % ConsultantCount;
                if (cnt > 0)
                {
                    for (int i = 0; i < ConsultantCount; i++)
                    {
                        test[i] = cnt;
                    }
                }
                if (mod > 0)
                {
                    for (int i = 0; i < mod; i++)
                    {
                        test[i] = test[i] + 1;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.BindFleetTeamConsult.Error:" + ex.StackTrace);
        }
        return test;
    }
    #endregion

    #region "FC LEAD ALLOCATION"

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 15 Aug 2013
    /// Description: Bind FC's Fleet Team ConsulTants
    /// </summary>
    /// <param name="ddlConsultants"></param>
    /// <param name="hdfConsultEmail"></param>
    /// <param name="hdfConsultFName"></param>
    private void BindFCConsultDetails(Int64 ConsultId, HiddenField hdfConsultEmail, HiddenField hdfConsultFName)
    {
        try
        {
            DataTable Dt = objMstBm.ConsultDetailsFromId(ConsultId);
            if (Dt != null && Dt.Rows.Count > 0)
            {
                hdfFCFTCtoAssign.Value = ConsultId.ToString().Trim();
                hdfConsultEmail.Value = Dt.Rows[0]["Email1"].ToString().Trim();
                hdfConsultFName.Value = Dt.Rows[0]["FName"].ToString().Trim();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.BindFleetTeamConsult.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Bind FC's Fleet Team ConsulTants
    /// </summary>
    /// <param name="ddlConsultants"></param>
    /// <param name="hdfConsultEmail"></param>
    /// <param name="hdfConsultFName"></param>
    private void BindFCFleetTeamConsult(DropDownList ddlConsultants, HiddenField hdfConsultEmail, HiddenField hdfConsultFName)
    {
        try
        {
            Employee objEmp = new Employee();
            objEmp.FName = string.Empty;
            objEmp.RoleId = 5;//Hard Code For FC Consultant
            DataTable Dt = objEmpBM.GetAllEmployee(objEmp);
            DataView dV = Dt.DefaultView;
            dV.RowFilter = "IsInFleetTeam=" + "1"; // Added to get fleet team consultants in Fleet Team Lead Alocation Flow
            Cls_BinderHelper.BindDropdownList(ddlConsultants, "Name", "VirtualRoleId", Dt);
            if (!string.IsNullOrEmpty(hdfFCFTCtoAssign.Value.Trim()) && Convert.ToInt64(hdfFCFTCtoAssign.Value.Trim()) > 0)
            {
                ddlConsultants.SelectedValue = hdfFCFTCtoAssign.Value.Trim();
            }
            else
            {
                DataTable Dt1 = objProspectBM.GetFCTeamLeadConsultToAssign();
                if (Dt1 != null && Dt1.Rows.Count > 0)
                {
                    hdfFCFTCtoAssign.Value = Dt1.Rows[0]["VirtualRoleId"].ToString().Trim();
                    ddlConsultants.SelectedValue = hdfFCFTCtoAssign.Value.Trim();
                    hdfConsultEmail.Value = Dt1.Rows[0]["Email1"].ToString().Trim();
                    hdfConsultFName.Value = Dt1.Rows[0]["FName"].ToString().Trim();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.BindFleetTeamConsult.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Bind FC's Fleet Leads
    /// </summary>
    private void BindFCFleetLeads()
    {
        try
        {
            DataTable Dt = objProspectBM.GetFCTeamLeadsForAssignments();
            if (Dt != null & Dt.Rows.Count > 0)
            {
                gvFCTeamLead.DataSource = Dt;
                gvFCTeamLead.DataBind();
                lnkbtnFCLeadTeamAllocate.Visible = lnkbtnFCClearTeamAllocate.Visible = true;
            }
            else
            {
                gvFCTeamLead.DataSource = null;
                gvFCTeamLead.DataBind();
                lnkbtnFCLeadTeamAllocate.Visible = lnkbtnFCClearTeamAllocate.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.BindFCFleetLeads.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Bind FC's ConsulTants
    /// </summary>
    private void BindFCConsultants()
    {
        try
        {
            Employee objEmp = new Employee();
            objEmp.FName = string.Empty;
            objEmp.RoleId = 5;//Hard Code For FC Consultant

            DataTable Dt = objEmpBM.GetAllEmployee(objEmp);
            if (Dt != null & Dt.Rows.Count > 0)
            {
                DataView dV = Dt.DefaultView;
                dV.RowFilter = "IsInFleetTeam=" + "0"; // Added to avoid fleet team consultants in normal lead alocation flow
                dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
                gvFCAllocate.DataSource = Dt;
                gvFCAllocate.DataBind();
            }
            else
            {
                gvFCAllocate.DataSource = null;
                gvFCAllocate.DataBind();
            }
        }

        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.BindFCContacts.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Clear All Control's Values From FC Panel
    /// </summary>
    private void ClearFCAll()
    {
        try
        {
            GetOldestEnquiryDate();
            txtFCBulkAmt.Text = string.Empty;
            txtFCTotEntToDate.Text = txtFCUnalocToDate.Text = DateTime.Today.Date.ToString(Resources.PFSalesResource.dateformat.Trim());
            GetTotalFCCount();
            GetUnAlocatedFCEnqCount();
            GetFCTotalCount1();
            GetFCUnAlocatedEnqCount1();
            txtFCTotEntFrmDate.Focus();
            CheckBox chkheadbx = (CheckBox)gvFCAllocate.HeaderRow.FindControl("chkSelectAll");
            if (chkheadbx != null)
                chkheadbx.Checked = false;
            foreach (GridViewRow grviewrow in gvFCAllocate.Rows)
            {
                CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkFCSelect");
                TextBox txtNoOfLeads = (TextBox)grviewrow.FindControl("txtFCNoOfLeads");
                if (chkbx != null && txtNoOfLeads != null)
                {
                    if (chkbx.Checked)
                    {
                        chkbx.Checked = false;
                        txtNoOfLeads.Text = "0";
                        //txtNoOfLeads.Enabled = false;
                    }
                    else
                    {
                        txtNoOfLeads.Text = "0";
                        //txtNoOfLeads.Enabled = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.ClearFCAll.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Get Total Enquiries Count For FC
    /// </summary>
    private void GetTotalFCCount()
    {
        try
        {
            DataTable Dt = objProspectBM.GetFCTotalEnqCount(Convert.ToDateTime(txtFCTotEntFrmDate.Text.Trim()), Convert.ToDateTime(txtFCTotEntToDate.Text.Trim()));
            if (Dt != null && Dt.Rows.Count > 0)
                lnkbtnFCTodTotEnq.Text = Dt.Rows[0]["LeadCount"].ToString().Trim();
            if (lnkbtnFCTodTotEnq.Text == "0")
                lnkbtnFCTodTotEnq.Enabled = false;
            else
                lnkbtnFCTodTotEnq.Enabled = true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.GetTotalFCCount.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Get Total Unallocated FC Enquiries Count
    /// </summary>
    private void GetUnAlocatedFCEnqCount()
    {
        try
        {
            DataTable Dt = objProspectBM.GetFCUnAlocatedEnqCount(Convert.ToDateTime(txtFCUnAlocFromDate.Text.Trim()), Convert.ToDateTime(txtFCUnalocToDate.Text.Trim()));
            if (Dt != null && Dt.Rows.Count > 0)
                lnkbtnFCUnallocatedEnq.Text = Dt.Rows[0]["LeadCount"].ToString().Trim();
            if (lnkbtnFCUnallocatedEnq.Text == "0")
                lnkbtnFCUnallocatedEnq.Enabled = false;
            else
                lnkbtnFCUnallocatedEnq.Enabled = true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.GetUnAlocatedFCEnqCount.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 Aug 2013
    /// Description: Get Total FC Enquiries Count
    /// </summary>
    private void GetFCTotalCount1()
    {
        try
        {
            DataTable Dt = objProspectBM.GetFCTotalEnqCount(Convert.ToDateTime(txtFCTotEntFrmDate1.Text.Trim()), Convert.ToDateTime(txtFCTotEntToDate1.Text.Trim()));
            if (Dt != null && Dt.Rows.Count > 0)
                lnkbtnFCTodTotEnq1.Text = Dt.Rows[0]["LeadCount"].ToString().Trim();
            if (lnkbtnFCTodTotEnq1.Text == "0")
                lnkbtnFCTodTotEnq1.Enabled = false;
            else
                lnkbtnFCTodTotEnq1.Enabled = true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.GetFCTotalCount1.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 June 2013
    /// Description: Get Total Unallocated FC Enquiries Count
    /// </summary>
    private void GetFCUnAlocatedEnqCount1()
    {
        try
        {
            DataTable Dt = objProspectBM.GetFCUnAlocatedEnqCount(Convert.ToDateTime(txtFCUnAlocFromDate1.Text.Trim()), Convert.ToDateTime(txtFCUnalocToDate1.Text.Trim()));
            if (Dt != null && Dt.Rows.Count > 0)
                lnkbtnFCUnallocatedEnq1.Text = Dt.Rows[0]["LeadCount"].ToString().Trim();
            if (lnkbtnFCUnallocatedEnq1.Text == "0")
                lnkbtnFCUnallocatedEnq1.Enabled = false;
            else
                lnkbtnFCUnallocatedEnq1.Enabled = true;
            if (Convert.ToInt32(lnkbtnFCUnallocatedEnq1.Text.Trim()) == 0)
                lnkbtnFCAllocate.Enabled = false;
            else
                lnkbtnFCAllocate.Enabled = true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.GetFCUnAlocatedEnqCount1.Error:" + ex.StackTrace);
        }
    }
    #endregion

    #region Date 21 Aug 13 By Kalpana
    /// <summary>
    /// Created By: Kalpana Shinde
    /// Created Date: 21 Aug 2013
    /// Description: Bind not Yeyt Called Lead Grid View Data
    /// </summary>
    public void BindNYCLeadGrid(DateTime FromDate, DateTime ToDate, Int64 ConsultantId, string FCFlag, string Flag)
    {
        try
        {
            objProsp.PageSize = gvNYC.PageSize;
            pagerParent.PageSize = gvNYC.PageSize;
            if (Session["CurrentPageIndex"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["CurrentPageIndex"])))
            {
                objProsp.PageIndex = Convert.ToInt64(Session["CurrentPageIndex"]);
                pagerParent.CurrentIndex = Convert.ToInt32(Session["CurrentPageIndex"]);
            }
            else
                Session["CurrentPageIndex"] = objProsp.PageIndex = pagerParent.CurrentIndex;

            DataSet Ds = new DataSet();
            if (Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1] != null && Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] != null && !string.IsNullOrEmpty(Convert.ToString(Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1]).Trim()) && !string.IsNullOrEmpty(Convert.ToString(Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1]).Trim()))
            {
                if (Convert.ToString(Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1]) == Cls_Constant.VIEWSTATE_ASC)
                    Ds = objProspectBM.GetAllNYCForPFAndFC(FromDate, ToDate, ConsultantId, FCFlag, Flag, objProsp.PageIndex, gvNYC.PageSize, Convert.ToString(Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1]).Trim() + " ASC");
                else if (Convert.ToString(Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1]) == Cls_Constant.VIEWSTATE_DESC)
                    Ds = objProspectBM.GetAllNYCForPFAndFC(FromDate, ToDate, ConsultantId, FCFlag, Flag, objProsp.PageIndex, gvNYC.PageSize, Convert.ToString(Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1]).Trim() + " DESC");
                else
                    Ds = objProspectBM.GetAllNYCForPFAndFC(FromDate, ToDate, ConsultantId, FCFlag, Flag, objProsp.PageIndex, gvNYC.PageSize, Convert.ToString(Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1]).Trim() + " ASC");
            }
            else
                Ds = objProspectBM.GetAllNYCForPFAndFC(FromDate, ToDate, ConsultantId, FCFlag, Flag, objProsp.PageIndex, gvNYC.PageSize, string.Empty);
            if (Ds != null && Ds.Tables.Count > 0)
            {
                DataTable Dt = Ds.Tables[0];
                if (Dt != null & Dt.Rows.Count > 0)
                {
                    gvNYC.DataSource = Dt;
                    gvNYC.DataBind();
                    pagerParent.PageSize = gvNYC.PageSize;
                    if (Session["ItemCount"] != null && Convert.ToInt32(Session["ItemCount"]) > 0)
                    {
                        pagerParent.ItemCount = Convert.ToInt32(Session["ItemCount"]);
                        Session["ItemCount"] = Convert.ToInt32(Session["ItemCount"]);
                    }
                    else
                        Session["ItemCount"] = pagerParent.ItemCount = 0;
                    dvClearFilter.Visible = lnkbtnClearFilter.Visible = true;
                    ViewState["FilteredData"] = Dt;
                    ViewState["TotalNYCCount"] = Dt.Rows.Count;
                }
                else
                {
                    gvNYC.DataSource = null;
                    gvNYC.DataBind();
                }
                pagerParent.PageSize = gvNYC.PageSize;
                if (Ds.Tables[1].Rows.Count > 0)
                {
                    Session["TotalRecCount"] = pagerParent.ItemCount = Convert.ToDouble(Ds.Tables[1].Rows[0][0]);
                }
                else
                    pagerParent.ItemCount = 0;
                t3 = new Thread(saveDataToViewState);
                t3.Start();
            }
            else
            {
                gvNYC.DataSource = null;
                gvNYC.DataBind();
            }
            if (Session["MyCurrentProsp"] == null && string.IsNullOrEmpty(Convert.ToString(Session["MyCurrentProsp"]).Trim()))
                Session["MyCurrentProsp"] = "1";
            t3.Join(10);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.BindNYCGrid.Error:" + ex.StackTrace);
        }
    }

    #endregion

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
            Logger.Error(ex.Message + "LeadAllocation.GetCountOfActForStime.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 Oct 2013
    /// Description: Send Email On Other Thread
    /// </summary>
    /// <param name="DtResult"></param>
    /// <param name="objProsp"></param>
    private void sendEmailOnThread()
    {
        try
        {
            for (int i = 0; i < objProsp.lstAllocation.Count; i++)
            {
                if (!string.IsNullOrEmpty(objProsp.lstAllocation[i].ConsultantEmail.Trim()) && !string.IsNullOrEmpty(objProsp.lstAllocation[i].ConsultantName.Trim()))
                    SendMail(objProsp.lstAllocation[i].ConsultantEmail.Trim(), objProsp.lstAllocation[i].Noofleads, objProsp.lstAllocation[i].ConsultFName.Trim(), false);//
            }
            for (int i = 0; i < DtResult.Rows.Count; i++)
            {
                //SaveDefaultActivity(DtResult.Rows[i]["ProspFName"].ToString().Trim(), Convert.ToInt64(DtResult.Rows[i]["Id"].ToString().Trim()), Convert.ToInt64(DtResult.Rows[i]["ConsultantId"].ToString().Trim()));
                SendProspectMail(DtResult.Rows[i]["Email"].ToString().Trim(), DtResult.Rows[i]["ProspFName"].ToString().Trim(), DtResult.Rows[i]["ConsultantName"].ToString().Trim(), DtResult.Rows[i]["ConsultPhone"].ToString().Trim(), DtResult.Rows[i]["ConsultEmail"].ToString().Trim(), DtResult.Rows[i]["EnquiryDate"].ToString().Trim(), DtResult.Rows[i]["Ext"].ToString().Trim(), DtResult.Rows[i]["ConsultName"].ToString().Trim());
                if (!string.IsNullOrEmpty(Convert.ToString(DtResult.Rows[i]["IsFleetLead"])) && Convert.ToBoolean(DtResult.Rows[i]["IsFleetLead"]))
                {
                    SendMail(objProsp.lstAllocation[i].ConsultantEmail.Trim(), objProsp.lstAllocation[i].Noofleads, objProsp.lstAllocation[i].ConsultFName.Trim(), true);
                }
                //if ((i % 2) > 0)
                //    Interval = Interval + Interval1;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.sendEmailOnThread.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 Oct 2013
    /// Description: Send FC Email On Other Thread
    /// </summary>
    /// <param name="DtResult"></param>
    /// <param name="objProsp"></param>
    private void SendFCEmailOnThread()
    {
        try
        {
            for (int i = 0; i < objProsp.lstAllocation.Count; i++)
            {
                if (!string.IsNullOrEmpty(objProsp.lstAllocation[i].ConsultantEmail.Trim()) && !string.IsNullOrEmpty(objProsp.lstAllocation[i].ConsultantName.Trim()))
                    SendMail(objProsp.lstAllocation[i].ConsultantEmail.Trim(), objProsp.lstAllocation[i].Noofleads, objProsp.lstAllocation[i].ConsultFName.Trim(), false);//
            }
            for (int i = 0; i < DtResult.Rows.Count; i++)
            {
                //SaveDefaultActivity(DtResult.Rows[i]["ProspFName"].ToString().Trim(), Convert.ToInt64(DtResult.Rows[i]["Id"].ToString().Trim()), Convert.ToInt64(DtResult.Rows[i]["ConsultantId"].ToString().Trim()));
                // SendProspectMail(DtResult.Rows[i]["Email"].ToString().Trim(), DtResult.Rows[i]["ProspFName"].ToString().Trim(), DtResult.Rows[i]["ConsultantName"].ToString().Trim(), DtResult.Rows[i]["ConsultPhone"].ToString().Trim(), DtResult.Rows[i]["ConsultEmail"].ToString().Trim(), DtResult.Rows[i]["EnquiryDate"].ToString().Trim(), DtResult.Rows[i]["Ext"].ToString().Trim());
                if (DtResult.Rows[i]["IsFinanceSource"].ToString().Trim().ToUpper() == "C")
                    SendConsultMail(DtResult.Rows[i]["RefConsultEmail"].ToString().Trim(), DtResult.Rows[i]["RefConsultName"].ToString().Trim(), DtResult.Rows[i]["ConsultantName"].ToString().Trim(), DtResult.Rows[i]["Email"].ToString().Trim(), DtResult.Rows[i]["ConsultPhone"].ToString().Trim(), DtResult.Rows[i]["Ext"].ToString().Trim());
                ////if ((i % 2) > 0)
                ////    Interval = Interval + Interval1;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.SendFCEmailOnThread.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 14 Nov 2013
    /// Description: Bulk Alocate Leads To Selected Consultants
    /// </summary>
    /// <returns></returns>
    private void ReallocateLeads(string Ids, string flag)
    {
        try
        {
            Thread t3 = null;
            ProspectBM objProspectBM = new ProspectBM();
            List<LeadAssignment> lstAllocation = new List<LeadAssignment>();
            foreach (GridViewRow grviewrow in gvBulkAllocateConsult.Rows)
            {
                CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkSelect");
                TextBox txtNoOfLeads = (TextBox)grviewrow.FindControl("txtNoOfLeads");
                HiddenField hdfConsultantId = (HiddenField)grviewrow.FindControl("hdfConsultantId");
                HiddenField hdfFName = (HiddenField)grviewrow.FindControl("hdfFName");
                Label lblContEmailId = (Label)grviewrow.FindControl("lblContEmailId");
                Label lblConsultName = (Label)grviewrow.FindControl("lblConsultName");
                if (chkbx != null && txtNoOfLeads != null && hdfConsultantId != null && lblContEmailId != null && lblConsultName != null)
                {
                    if (!string.IsNullOrEmpty(hdfConsultantId.Value.Trim()) && !string.IsNullOrEmpty(txtNoOfLeads.Text.Trim()) && Convert.ToInt64(txtNoOfLeads.Text.Trim()) > 0 && chkbx.Checked)
                    {
                        LeadAssignment objLAllocation = new LeadAssignment();
                        objLAllocation.ConsultantId = Convert.ToInt64(hdfConsultantId.Value.Trim());
                        objLAllocation.Noofleads = Convert.ToInt32(txtNoOfLeads.Text.Trim());
                        if (!string.IsNullOrEmpty(lblContEmailId.Text.Trim()))
                            objLAllocation.ConsultantEmail = lblContEmailId.Text.Trim();
                        if (!string.IsNullOrEmpty(lblConsultName.Text.Trim()))
                            objLAllocation.ConsultantName = lblConsultName.Text.Trim();
                        if (!string.IsNullOrEmpty(hdfFName.Value.Trim()))
                            objLAllocation.ConsultFName = hdfFName.Value.Trim();
                        lstAllocation.Add(objLAllocation);
                    }
                }
            }
            objProsp.lstAllocation = lstAllocation;
            objProsp.CreatedById = BasePage.UserSession.VirtualRoleId;
            objProsp.Ids = Ids;
            objProsp.FConsultant = flag;
            //objProsp.FromDate = Convert.ToDateTime(txtUnAlocFromDate.Text.Trim());
            //objProsp.ToDate = Convert.ToDateTime(txtUnalocToDate.Text.Trim());
            //DataTable DtResult = new DataTable();
            DtResult = objProspectBM.BulkAssignLeadsToConsultant(objProsp);
            if (Session["Flag"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Flag"]).Trim()))
            {
                if (Convert.ToString(Session["Flag"]).Trim().ToUpper() == "PF")
                {
                    BindConsultants();
                }
                else if (Convert.ToString(Session["Flag"]).Trim().ToUpper() == "FC")
                {
                    BindFCConsultants();
                }
            }
            if (DtResult != null && DtResult.Rows.Count > 0)
            {
                //ClearAll();

                ClearAll();
                if (Session["Flag"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Flag"]).Trim()))
                {
                    if (Convert.ToString(Session["Flag"]).Trim().ToUpper() == "PF")
                    {
                        t3 = new Thread(sendEmailOnThread);

                    }
                    else if (Convert.ToString(Session["Flag"]).Trim().ToUpper() == "FC")
                    {
                        t3 = new Thread(SendFCEmailOnThread);
                    }
                }
                t3.Start();

                //for (int i = 0; i < objProsp.lstAllocation.Count; i++)
                //{
                //    if (!string.IsNullOrEmpty(objProsp.lstAllocation[i].ConsultantEmail.Trim()) && !string.IsNullOrEmpty(objProsp.lstAllocation[i].ConsultantName.Trim()))
                //        SendMail(objProsp.lstAllocation[i].ConsultantEmail.Trim(), objProsp.lstAllocation[i].Noofleads, objProsp.lstAllocation[i].ConsultFName.Trim());//
                //}
                //if (Session["Flag"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Flag"]).Trim()))
                //{
                //    if (Convert.ToString(Session["Flag"]).Trim().ToUpper() == "PF")
                //    {
                //        for (int i = 0; i < DtResult.Rows.Count; i++)
                //        {
                //            SendProspectMail(DtResult.Rows[i]["Email"].ToString().Trim(), DtResult.Rows[i]["ProspFName"].ToString().Trim(), DtResult.Rows[i]["ConsultName"].ToString().Trim(), DtResult.Rows[i]["ConsultPhone"].ToString().Trim(), DtResult.Rows[i]["ConsultEmail"].ToString().Trim(), DtResult.Rows[i]["EnquiryDate"].ToString().Trim(), DtResult.Rows[i]["Ext"].ToString().Trim());
                //        }
                //    }
                //}


                CheckBox chkAll = (CheckBox)gvBulkAllocateConsult.HeaderRow.FindControl("chkSelectAll");
                CheckBox chkProspAll = (CheckBox)gvNYC.HeaderRow.FindControl("chkSelectAll");
                if (chkAll != null && chkProspAll != null)
                    chkAll.Checked = chkProspAll.Checked = false;
                foreach (GridViewRow gr in gvBulkAllocateConsult.Rows)
                {
                    CheckBox chkConsultant = (CheckBox)gr.FindControl("chkSelect");
                    chkConsultant.Checked = false;
                }
                foreach (GridViewRow gr in gvNYC.Rows)
                {
                    CheckBox chkConsultant = (CheckBox)gr.FindControl("chkSelect");
                    chkConsultant.Checked = false;
                }
                pnlRallocation.Visible = false;
                GetFCUnAlocatedEnqCount1();
                GetUnAlocatedEnqCount1();
                if (Session["ConsultantId"] != null && Session["Flag"] != null && Session["Status"] != null)
                {
                    int consultantID = Convert.ToInt32(Session["ConsultantId"]);
                    string strFlag = Convert.ToString(Session["Flag"]);
                    string strStatus = Convert.ToString(Session["Status"]);
                    switch (strFlag.ToUpper())
                    {
                        case "PF":
                            switch (strStatus.ToUpper())
                            {
                                case "CUR":
                                    foreach (GridViewRow gr in gvAllocate.Rows)
                                    {
                                        HiddenField hdfConsultantId = (HiddenField)gr.FindControl("hdfConsultantId");
                                        if (Convert.ToInt32(hdfConsultantId.Value) == consultantID)
                                        {
                                            LinkButton lnkbtnCurrWorkLoad = (LinkButton)gr.FindControl("lnkbtnCurrWorkLoad");
                                            lnkbtnCurrWorkLoad_Click(lnkbtnCurrWorkLoad, null);
                                        }
                                    }
                                    break;
                                case "NYC":
                                    foreach (GridViewRow gr in gvAllocate.Rows)
                                    {
                                        HiddenField hdfConsultantId = (HiddenField)gr.FindControl("hdfConsultantId");
                                        if (Convert.ToInt32(hdfConsultantId.Value) == consultantID)
                                        {
                                            LinkButton lnkbtnNYCWorkLoad = (LinkButton)gr.FindControl("lnkbtnNYCWorkLoad");
                                            lnkbtnNYCWorkLoad_Click(lnkbtnNYCWorkLoad, null);
                                        }
                                    }
                                    break;
                                case "U":
                                    pnlLeadAllocation.Visible = true;
                                    pnlFCleadAllocation.Visible = false;
                                    lnkbtnPFAllocation.CssClass = "tablerBtnActive";
                                    lnkbtnFCAllocation.CssClass = string.Empty;
                                    Session["Flag"] = "PF";
                                    lnkbtnUnallocatedEnq1_Click(lnkbtnUnallocatedEnq1, null);

                                    break;
                            }
                            break;
                        case "FC":
                            switch (strStatus.ToUpper())
                            {
                                case "CUR":
                                    foreach (GridViewRow gr in gvFCAllocate.Rows)
                                    {
                                        HiddenField hdfFCConsultantId = (HiddenField)gr.FindControl("hdfFCConsultantId");
                                        if (Convert.ToInt32(hdfFCConsultantId.Value) == consultantID)
                                        {
                                            LinkButton lnkbtnFCCurrWorkLoad = (LinkButton)gr.FindControl("lnkbtnFCCurrWorkLoad");
                                            lnkbtnFCCurrWorkLoad_Click(lnkbtnFCCurrWorkLoad, null);
                                        }
                                    }
                                    break;
                                case "NYC":
                                    foreach (GridViewRow gr in gvFCAllocate.Rows)
                                    {
                                        HiddenField hdfFCConsultantId = (HiddenField)gr.FindControl("hdfFCConsultantId");
                                        if (Convert.ToInt32(hdfFCConsultantId.Value) == consultantID)
                                        {
                                            LinkButton lnkbtnFCNotYetCalled = (LinkButton)gr.FindControl("lnkbtnFCNotYetCalled");
                                            lnkbtnFCNotYetCalled_Click(lnkbtnFCNotYetCalled, null);
                                        }
                                    }
                                    break;
                                case "U":
                                    pnlLeadAllocation.Visible = false;
                                    pnlFCleadAllocation.Visible = true;
                                    lnkbtnPFAllocation.CssClass = string.Empty;
                                    lnkbtnFCAllocation.CssClass = "tablerBtnActive";
                                    Session["Flag"] = "FC";
                                    lnkbtnFCUnallocatedEnq1_Click(lnkbtnFCUnallocatedEnq1, null);
                                    break;
                            }
                            break;
                    }
                }
                pnlRallocation.Visible = false;
                lblAddSucMsg.Text = Resources.PFSalesResource.LeadsAssignedSuccess.Trim();
                dvaddSucc.Visible = true;
                lblAddErrMsg.Text = string.Empty;
                dvadderror.Visible = false;
            }
            else
            {
                lblAddSucMsg.Text = string.Empty;
                dvaddSucc.Visible = false;
                lblAddErrMsg.Text = Resources.PFSalesResource.LeadsAssignedError.Trim();
                dvadderror.Visible = true;
            }
            t3.Join(100);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.lnkbtnAllocate_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 26 Nov 2013
    /// Description: Reallocate Leads To Selected Consultants
    /// </summary>
    /// <returns></returns>
    private void ReallocationLeads(string Ids, string flag)
    {
        try
        {
            ProspectBM objProspectBM = new ProspectBM();
            List<LeadAssignment> lstAllocation = new List<LeadAssignment>();
            foreach (GridViewRow grviewrow in gvBulkAllocateConsult.Rows)
            {
                CheckBox chkbx = (CheckBox)grviewrow.FindControl("chkSelect");
                TextBox txtNoOfLeads = (TextBox)grviewrow.FindControl("txtNoOfLeads");
                HiddenField hdfConsultantId = (HiddenField)grviewrow.FindControl("hdfConsultantId");
                HiddenField hdfFName = (HiddenField)grviewrow.FindControl("hdfFName");
                Label lblContEmailId = (Label)grviewrow.FindControl("lblContEmailId");
                Label lblConsultName = (Label)grviewrow.FindControl("lblConsultName");
                if (chkbx != null && txtNoOfLeads != null && hdfConsultantId != null && lblContEmailId != null && lblConsultName != null)
                {
                    if (!string.IsNullOrEmpty(hdfConsultantId.Value.Trim()) && !string.IsNullOrEmpty(txtNoOfLeads.Text.Trim()) && Convert.ToInt64(txtNoOfLeads.Text.Trim()) > 0 && chkbx.Checked)
                    {
                        LeadAssignment objLAllocation = new LeadAssignment();
                        objLAllocation.ConsultantId = Convert.ToInt64(hdfConsultantId.Value.Trim());
                        objLAllocation.Noofleads = Convert.ToInt32(txtNoOfLeads.Text.Trim());
                        if (!string.IsNullOrEmpty(lblContEmailId.Text.Trim()))
                            objLAllocation.ConsultantEmail = lblContEmailId.Text.Trim();
                        if (!string.IsNullOrEmpty(lblConsultName.Text.Trim()))
                            objLAllocation.ConsultantName = lblConsultName.Text.Trim();
                        if (!string.IsNullOrEmpty(hdfFName.Value.Trim()))
                            objLAllocation.ConsultFName = hdfFName.Value.Trim();
                        lstAllocation.Add(objLAllocation);
                    }
                }
            }
            objProsp.lstAllocation = lstAllocation;
            objProsp.CreatedById = BasePage.UserSession.VirtualRoleId;
            objProsp.Ids = Ids;
            objProsp.FConsultant = flag;
            //objProsp.FromDate = Convert.ToDateTime(txtUnAlocFromDate.Text.Trim());
            //objProsp.ToDate = Convert.ToDateTime(txtUnalocToDate.Text.Trim());
            //DataTable DtResult = new DataTable();
            DtResult = objProspectBM.ReassignLeadsToConsultant(objProsp);
            if (Session["Flag"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["Flag"]).Trim()))
            {
                if (Convert.ToString(Session["Flag"]).Trim().ToUpper() == "PF")
                {
                    BindConsultants();
                }
                else if (Convert.ToString(Session["Flag"]).Trim().ToUpper() == "FC")
                {
                    BindFCConsultants();
                }
            }
            if (DtResult != null && DtResult.Rows.Count > 0)
            {
                //ClearAll();

                ClearAll();
                CheckBox chkAll = (CheckBox)gvBulkAllocateConsult.HeaderRow.FindControl("chkSelectAll");
                CheckBox chkProspAll = (CheckBox)gvNYC.HeaderRow.FindControl("chkSelectAll");
                if (chkAll != null && chkProspAll != null)
                    chkAll.Checked = chkProspAll.Checked = false;
                foreach (GridViewRow gr in gvBulkAllocateConsult.Rows)
                {
                    CheckBox chkConsultant = (CheckBox)gr.FindControl("chkSelect");
                    chkConsultant.Checked = false;
                }
                foreach (GridViewRow gr in gvNYC.Rows)
                {
                    CheckBox chkConsultant = (CheckBox)gr.FindControl("chkSelect");
                    chkConsultant.Checked = false;
                }
                pnlRallocation.Visible = false;
                GetFCUnAlocatedEnqCount1();
                GetUnAlocatedEnqCount1();
                if (Session["ConsultantId"] != null && Session["Flag"] != null && Session["Status"] != null)
                {
                    int consultantID = Convert.ToInt32(Session["ConsultantId"]);
                    string strFlag = Convert.ToString(Session["Flag"]);
                    string strStatus = Convert.ToString(Session["Status"]);
                    switch (strFlag.ToUpper())
                    {
                        case "PF":
                            switch (strStatus.ToUpper())
                            {
                                case "CUR":
                                    foreach (GridViewRow gr in gvAllocate.Rows)
                                    {
                                        HiddenField hdfConsultantId = (HiddenField)gr.FindControl("hdfConsultantId");
                                        if (Convert.ToInt32(hdfConsultantId.Value) == consultantID)
                                        {
                                            LinkButton lnkbtnCurrWorkLoad = (LinkButton)gr.FindControl("lnkbtnCurrWorkLoad");
                                            lnkbtnCurrWorkLoad_Click(lnkbtnCurrWorkLoad, null);
                                        }
                                    }
                                    break;
                                case "NYC":
                                    foreach (GridViewRow gr in gvAllocate.Rows)
                                    {
                                        HiddenField hdfConsultantId = (HiddenField)gr.FindControl("hdfConsultantId");
                                        if (Convert.ToInt32(hdfConsultantId.Value) == consultantID)
                                        {
                                            LinkButton lnkbtnNYCWorkLoad = (LinkButton)gr.FindControl("lnkbtnNYCWorkLoad");
                                            lnkbtnNYCWorkLoad_Click(lnkbtnNYCWorkLoad, null);
                                        }
                                    }
                                    break;
                                case "U":
                                    pnlLeadAllocation.Visible = true;
                                    pnlFCleadAllocation.Visible = false;
                                    lnkbtnPFAllocation.CssClass = "tablerBtnActive";
                                    lnkbtnFCAllocation.CssClass = string.Empty;
                                    Session["Flag"] = "PF";
                                    lnkbtnUnallocatedEnq1_Click(lnkbtnUnallocatedEnq1, null);

                                    break;
                            }
                            break;
                        case "FC":
                            switch (strStatus.ToUpper())
                            {
                                case "CUR":
                                    foreach (GridViewRow gr in gvFCAllocate.Rows)
                                    {
                                        HiddenField hdfFCConsultantId = (HiddenField)gr.FindControl("hdfFCConsultantId");
                                        if (Convert.ToInt32(hdfFCConsultantId.Value) == consultantID)
                                        {
                                            LinkButton lnkbtnFCCurrWorkLoad = (LinkButton)gr.FindControl("lnkbtnFCCurrWorkLoad");
                                            lnkbtnFCCurrWorkLoad_Click(lnkbtnFCCurrWorkLoad, null);
                                        }
                                    }
                                    break;
                                case "NYC":
                                    foreach (GridViewRow gr in gvFCAllocate.Rows)
                                    {
                                        HiddenField hdfFCConsultantId = (HiddenField)gr.FindControl("hdfFCConsultantId");
                                        if (Convert.ToInt32(hdfFCConsultantId.Value) == consultantID)
                                        {
                                            LinkButton lnkbtnFCNotYetCalled = (LinkButton)gr.FindControl("lnkbtnFCNotYetCalled");
                                            lnkbtnFCNotYetCalled_Click(lnkbtnFCNotYetCalled, null);
                                        }
                                    }
                                    break;
                                case "U":
                                    pnlLeadAllocation.Visible = false;
                                    pnlFCleadAllocation.Visible = true;
                                    lnkbtnPFAllocation.CssClass = string.Empty;
                                    lnkbtnFCAllocation.CssClass = "tablerBtnActive";
                                    Session["Flag"] = "FC";
                                    lnkbtnFCUnallocatedEnq1_Click(lnkbtnFCUnallocatedEnq1, null);
                                    break;
                            }
                            break;
                    }
                }
                pnlRallocation.Visible = false;
                lblAddSucMsg.Text = Resources.PFSalesResource.LeadsReassSucces.Trim();
                dvaddSucc.Visible = true;
                lblAddErrMsg.Text = string.Empty;
                dvadderror.Visible = false;
            }
            else
            {
                lblAddSucMsg.Text = string.Empty;
                dvaddSucc.Visible = false;
                lblAddErrMsg.Text = Resources.PFSalesResource.LeadsAssignedError.Trim();
                dvadderror.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.ReallocationLeads.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 Nov 2013
    /// Description: Allocation Of Fleet Team Leads To Selected Consultants
    /// </summary>
    private void fleetTeamLeadAlocate()
    {
        try
        {
            //Page.Validate("TeamAllocate");
            //if (Page.IsValid)
            //{
            foreach (GridViewRow grviewrow in gvTeamLead.Rows)
            {
                DropDownList ddlTeamLeedConsultant = (DropDownList)grviewrow.FindControl("ddlTeamLeedConsultant");
                HiddenField hdfProspectId = (HiddenField)grviewrow.FindControl("hdfProspectId");
                HiddenField hdfConsultEmail = (HiddenField)grviewrow.FindControl("hdfConsultEmail");
                HiddenField hdfConsultFName = (HiddenField)grviewrow.FindControl("hdfConsultFName");
                //double Interval1 = Convert.ToDouble(ConfigurationManager.AppSettings["ActInterval"].ToString().Trim());
                //double Interval = 0;
                if (ddlTeamLeedConsultant != null && hdfProspectId != null && hdfConsultEmail != null && hdfConsultFName != null)
                {
                    if (!string.IsNullOrEmpty(hdfConsultEmail.Value.Trim()) && !string.IsNullOrEmpty(hdfProspectId.Value.Trim()) && Convert.ToInt64(ddlTeamLeedConsultant.SelectedValue.Trim()) > 0 && !string.IsNullOrEmpty(hdfConsultFName.Value.Trim()))
                    {
                        objProsp.ConsultId = Convert.ToInt64(ddlTeamLeedConsultant.SelectedValue.Trim());
                        objProsp.ProspId = Convert.ToInt64(hdfProspectId.Value.Trim());
                        objProsp.CreatedById = BasePage.UserSession.VirtualRoleId;
                        DataTable DtResult = objProspectBM.AssignFleetTeamLeads(objProsp);
                        if (DtResult != null && DtResult.Rows.Count > 0)
                        {
                            SendMail(hdfConsultEmail.Value.Trim(), 1, hdfConsultFName.Value.Trim(), true);//
                            for (int i = 0; i < DtResult.Rows.Count; i++)
                            {
                                // SaveDefaultActivity(DtResult.Rows[i]["ProspFName"].ToString().Trim(), Convert.ToInt64(DtResult.Rows[i]["Id"].ToString().Trim()), Convert.ToInt64(DtResult.Rows[i]["ConsultantId"].ToString().Trim()));
                                SendProspectMail(DtResult.Rows[i]["Email"].ToString().Trim(), DtResult.Rows[i]["ProspFName"].ToString().Trim(), DtResult.Rows[i]["ConsultantName"].ToString().Trim(), DtResult.Rows[i]["ConsultPhone"].ToString().Trim(), DtResult.Rows[i]["ConsultEmail"].ToString().Trim(), DtResult.Rows[i]["EnquiryDate"].ToString().Trim(), DtResult.Rows[i]["Ext"].ToString().Trim(), DtResult.Rows[i]["ConsultName"].ToString().Trim());
                                //if ((i % 2) > 0)
                                //    Interval = Interval + Interval1;
                            }
                            BindFleetLeads();
                            lblSerSucMsg.Text = Resources.PFSalesResource.LeadsAssignedSuccess.Trim();
                            dvaserSuccess.Visible = true;
                            lblSerErrMsg.Text = string.Empty;
                            dvsererror.Visible = false;
                        }
                        else
                        {
                            lblSerSucMsg.Text = string.Empty;
                            dvaserSuccess.Visible = false;
                            lblSerErrMsg.Text = Resources.PFSalesResource.LeadsAssignedError.Trim();
                            dvsererror.Visible = true;
                        }
                    }
                }
            }

            //}
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.fleetTeamLeadAlocate.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 26 Oct 2013
    /// Description: Save Data To View State
    /// </summary>
    private void saveDataToViewState()
    {
        try
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            DataTable Dt = new DataTable();
            Dt = objProspectBM.GetAllNYCForPFAndFCForView(Convert.ToDateTime(ViewState["FromDate"].ToString().Trim()), Convert.ToDateTime(ViewState["ToDate"].ToString().Trim()), Convert.ToInt64(ViewState["ConsultantId"].ToString().Trim()), ViewState["FCFlag"].ToString().Trim(), ViewState["Flag"].ToString().Trim());
            if (Dt != null & Dt.Rows.Count > 0)
            {
                Session["TotalRowCount"] = Dt.Rows.Count;
                DataTable dtTemp1 = new DataTable();
                dtTemp1 = Dt.Copy();
                dtTemp1.Columns.Add("RowNo");
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    dtTemp1.Rows[i]["RowNo"] = i + 1;
                }
                DataView dtView = dtTemp1.DefaultView;
                dtView.Sort = string.Format("{0} {1}", Session[Cls_Constant.VIEWSTATE_SORTEXPRESSION1].ToString(), Session[Cls_Constant.VIEWSTATE_SORTDIRECTION1].ToString());
                Session["MyProspData"] = dtTemp1;
                if (Session["MyCurrentProsp"] == null && string.IsNullOrEmpty(Convert.ToString(Session["MyCurrentProsp"]).Trim()))
                    Session["MyCurrentProsp"] = "1";
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "LeadAllocation.saveDataToViewState.Error:" + ex.StackTrace);
        }
    }
    #endregion
}
