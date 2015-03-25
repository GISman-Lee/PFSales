using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DayPilot.Web.Ui.Events;
using log4net;
using Mechsoft.PFSales.BusinessManager;
using DayPilot.Web.Ui.Events.Calendar;
using Mechsoft.GeneralUtilities;
using Mechsoft.PFSales.BusinessEntity;
using System.Text;
using System.Configuration;
using System.IO;
using System.Reflection;
using DayPilot.Web.Ui;

public partial class ActivityCall : BasePage
{
    #region Global Variables
    ILog Logger = LogManager.GetLogger(typeof(ActivityCall));
    Prospect objProsp = new Prospect();
    ProspectBM objProspBM = new ProspectBM();
    MasterBM objMstBM = new MasterBM();
    EmployeeBM objEmpBM = new EmployeeBM();
    Activity objActivity = new Activity();
    ActivityBM objActivityBM = new ActivityBM();
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "Name";
            ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = Cls_Constant.VIEWSTATE_DESC;
            DateTime dtSelected = firstDayOfWeek(DateTime.Now, DayOfWeek.Sunday);// DateTime.Today;
            lblSelectedDate.Text = dtSelected.ToString("D");
            pnlCallendar.Visible = true;
            pnlCallDetails.Visible = true;
            BindConsultant();
            //DayPilotCalendar1.TimeFormat = DayPilot.Web.Ui.Enums.TimeFormat.Clock24Hours;
            DayPilotCalendar1.BusinessBeginsHour = 8;
            DayPilotCalendar1.BusinessEndsHour = 20;
            //DayPilotCalendar1.BusinessEndsHour = 10;
            DayPilotCalendar1.StartDate = dtSelected;// dtSelected.ToString("D"); //DateTime.Now;
            DayPilotCalendar1.DataSource = BindActivities(BasePage.UserSession.VirtualRoleId);// getData();
            DayPilotCalendar1.CellHeight = 30;
            DayPilotCalendar1.DataBind();
            //DataBind();

            if (BasePage.UserSession.RoleId == 1)
                DlSearch.Visible = true;
            else
                DlSearch.Visible = false;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 Jun 2013
    /// Descreption: Selection Changed Event For Activity Callendar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void calActivity_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            DateTime dtSelected = calActivity.SelectedDate;
            lblSelectedDate.Text = dtSelected.ToString("D");
            pnlCallendar.Visible = true;
            pnlCallDetails.Visible = true;
            DateTime dtSelected1 = firstDayOfWeek(dtSelected, DayOfWeek.Sunday);// DateTime.Today;
            DayPilotCalendar1.StartDate = dtSelected1;// dtSelected.ToString("D"); //DateTime.Now;
            DayPilotCalendar1.DataSource = BindActivities(Convert.ToInt64(ddlConsultant.SelectedValue.Trim()));// getData();
            DayPilotCalendar1.DataBind();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ActivityCallendar.calActivity_SelectionChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 June 2013
    /// Description: View Activity Details on Calender
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void calActivity_DayRender(object sender, DayRenderEventArgs e)
    {
        try
        {
            if (BasePage.UserSession != null)
            {
                if (sender != null)
                {
                    // Do not work for past date
                    //if (e.Day.Date >= DateTime.Now.Date)
                    //{
                    DataTable objDates = BindActivities(Convert.ToInt64(ddlConsultant.SelectedValue.Trim()));
                    string s = e.Day.Date.ToShortDateString();
                    if (objDates != null)
                    {
                        if (objDates.Rows.Count > 0)
                        {
                            foreach (DataRow row in objDates.Rows)
                            {
                                string scheduledDate = Convert.ToDateTime(row["start"]).ToString("g").Substring(0, 10);//.ToShortDateString();
                                if (scheduledDate.Equals(s))
                                {
                                    e.Cell.ForeColor = System.Drawing.Color.Black;
                                    if (e.Day.IsOtherMonth == true)
                                    { }
                                    else
                                    {
                                        e.Cell.BackColor = System.Drawing.Color.FromName(row["Color"].ToString().Trim()); //System.Drawing.Color.FromName("#DCF0FE");
                                        e.Cell.BorderColor = System.Drawing.Color.FromName("#5B8BC9");
                                        e.Cell.BorderStyle = BorderStyle.Solid;
                                        e.Cell.BorderWidth = Unit.Parse("1px");
                                        e.Cell.ForeColor = System.Drawing.Color.FromName("#367CAD");
                                        e.Cell.Width = Unit.Parse("14%");
                                        e.Cell.ToolTip = row["name"].ToString().Trim();
                                    }
                                }
                            }
                        }
                        if (e.Day.IsOtherMonth == true)
                        {
                            e.Cell.Text = "";

                        }
                    }
                    //}
                    //else
                    //{
                    //    if (e.Day.IsOtherMonth == true)
                    //    {
                    //        // If previous or next day are there
                    //        e.Cell.Text = "";

                    //    }
                    //    else
                    //    {
                    //        // If past date disable day link

                    //    }
                    //}
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ActivityCallendar.calActivity_DayRender.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 June 2013
    /// Description: Before Event Render Event of DayPilot Control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DayPilotCalendar1_BeforeEventRender(object sender, BeforeEventRenderEventArgs e)
    {
        if (BasePage.UserSession != null)
        {
            if (e.DataItem.Source != null)
            {
                if (e.DataItem["color"] != null)
                {
                    string color = e.DataItem["color"] as string;
                    if (!String.IsNullOrEmpty(color))
                    {
                        e.BackgroundColor = color;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 June 2013
    /// Description: On Event Click Event of DayPilot Control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DayPilotCalendar1_OnEventClick(object sender, EventClickEventArgs e)
    {
        try
        {
            Response.Redirect("ManageActivities.aspx?EventId=" + e.Value.ToString().Trim());
            //DataTable DtDet = objActivityBM.GetDetailsOfActivity(Convert.ToInt64(e.Value.Trim()));
            //if (DtDet != null && DtDet.Rows.Count > 0)
            //{
            //    HiddenField hdfActivityId = (HiddenField)UC_AddActivity1.FindControl("hdfActivityId");
            //    hdfActivityId.Value = ((LinkButton)sender).CommandArgument.Trim();
            //    if (!string.IsNullOrEmpty(DtDet.Rows[0]["ClearId"].ToString().Trim()))
            //    {
            //        if (Convert.ToInt64(DtDet.Rows[0]["ClearId"].ToString().Trim()) > 0)
            //        {

            //            MethodInfo methods1 = UC_ClearActivityDetails1.GetType().GetMethod("Binddata");
            //            if (methods1 != null)
            //            {
            //                object[] objParam = new object[] { Convert.ToInt64(e.Value.Trim()), DtDet.Rows[0]["Fname"].ToString().Trim() + " " + DtDet.Rows[0]["Mname"].ToString().Trim() + " " + DtDet.Rows[0]["Lname"].ToString().Trim() };
            //                methods1.Invoke(UC_ClearActivityDetails1, objParam);
            //                pnlClearActDeatils.Visible = true;
            //            }
            //        }
            //        else
            //        {
            //            MethodInfo methods = UC_AddActivity1.GetType().GetMethod("ClearAll");
            //            if (methods != null)
            //                methods.Invoke(UC_AddActivity1, null);
            //            MethodInfo methods2 = UC_AddActivity1.GetType().GetMethod("clearMsg");
            //            if (methods2 != null)
            //                methods2.Invoke(UC_AddActivity1, null);
            //            pnlAddAct.Visible = true;
            //            Panel pnlDetails = (Panel)UC_AddActivity1.FindControl("pnlDetails");
            //            Panel pnlGeneral = (Panel)UC_AddActivity1.FindControl("pnlGeneral");
            //            LinkButton lnkbtnGeneralInfo = (LinkButton)UC_AddActivity1.FindControl("lnkbtnGeneralInfo");
            //            LinkButton lnkbtnDetailsInfo = (LinkButton)UC_AddActivity1.FindControl("lnkbtnDetailsInfo");
            //            LinkButton lnkbtnUpdate = (LinkButton)UC_AddActivity1.FindControl("lnkbtnUpdate");
            //            LinkButton lnkbtnSaveAct = (LinkButton)UC_AddActivity1.FindControl("lnkbtnSaveAct");
            //            LinkButton lnkbtnDownload = (LinkButton)UC_AddActivity1.FindControl("lnkbtnDownload");
            //            Label lblAddActProspect = (Label)UC_AddActivity1.FindControl("lblAddActProspect");
            //            DropDownList ddlProspect = (DropDownList)UC_AddActivity1.FindControl("ddlProspect");
            //            if (hdfActivityId != null && pnlDetails != null && pnlGeneral != null && lnkbtnGeneralInfo != null && lnkbtnDetailsInfo != null && lnkbtnUpdate != null && lnkbtnSaveAct != null && lnkbtnDownload != null && lblAddActProspect != null && ddlProspect != null)
            //            {
            //                hdfActivityId.Value = e.Value;
            //                lblAddActProspect.Visible = pnlDetails.Visible = lnkbtnSaveAct.Visible = false;
            //                ddlProspect.Visible = pnlGeneral.Visible = lnkbtnUpdate.Visible = true;
            //                lnkbtnGeneralInfo.CssClass = "tablerBtnActive";
            //                lnkbtnDetailsInfo.CssClass = "";
            //                lblAddActPopUp.Text = Resources.PFSalesResource.updateactivity.Trim();
            //                pnlAddAct.Visible = true;
            //                MethodInfo methods1 = UC_AddActivity1.GetType().GetMethod("EditData");
            //                if (methods1 != null)
            //                    methods1.Invoke(UC_AddActivity1, null);
            //            }
            //        }
            //    }
            //}
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ActivityCallendar.DayPilotCalendar1_OnEventClick.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 June 2013
    /// Description: Time Range Selected Event of DayPilot Control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DayPilotCalendar1_TimeRangeSelected(object sender, TimeRangeSelectedEventArgs e)
    {
        try
        {
            Response.Redirect("ManageActivities.aspx?TimeRange=" + e.Start.ToString().Trim());
            //MethodInfo methods = UC_AddActivity1.GetType().GetMethod("ClearAll");
            //if (methods != null)
            //    methods.Invoke(UC_AddActivity1, null);
            //MethodInfo methods2 = UC_AddActivity1.GetType().GetMethod("clearMsg");
            //if (methods2 != null)
            //    methods2.Invoke(UC_AddActivity1, null);
            //pnlAddAct.Visible = true;
            //HiddenField hdfActivityId = (HiddenField)UC_AddActivity1.FindControl("hdfActivityId");
            //HiddenField hdfActivityDoc = (HiddenField)UC_AddActivity1.FindControl("hdfActivityDoc");
            //HiddenField hdfProspectId = (HiddenField)UC_AddActivity1.FindControl("hdfProspectId");
            //Panel pnlDetails = (Panel)UC_AddActivity1.FindControl("pnlDetails");
            //Panel pnlGeneral = (Panel)UC_AddActivity1.FindControl("pnlGeneral");
            //LinkButton lnkbtnGeneralInfo = (LinkButton)UC_AddActivity1.FindControl("lnkbtnGeneralInfo");
            //LinkButton lnkbtnDetailsInfo = (LinkButton)UC_AddActivity1.FindControl("lnkbtnDetailsInfo");
            //LinkButton lnkbtnUpdate = (LinkButton)UC_AddActivity1.FindControl("lnkbtnUpdate");
            //LinkButton lnkbtnSaveAct = (LinkButton)UC_AddActivity1.FindControl("lnkbtnSaveAct");
            //LinkButton lnkbtnDownload = (LinkButton)UC_AddActivity1.FindControl("lnkbtnDownload");
            //LinkButton lnkbtnRemove = (LinkButton)UC_AddActivity1.FindControl("lnkbtnRemove");
            //FileUpload fpattachment = (FileUpload)UC_AddActivity1.FindControl("fpattachment");
            //Label lblAddActProspect = (Label)UC_AddActivity1.FindControl("lblAddActProspect");
            //DropDownList ddlProspect = (DropDownList)UC_AddActivity1.FindControl("ddlProspect");
            //TextBox txtActDate = (TextBox)UC_AddActivity1.FindControl("txtActDate");
            //TextBox txtActTime = (TextBox)UC_AddActivity1.FindControl("txtActTime");
            //TextBox txtEndDate = (TextBox)UC_AddActivity1.FindControl("txtEndDate");
            //TextBox txtEndTime = (TextBox)UC_AddActivity1.FindControl("txtEndTime");
            //if (hdfActivityId != null && hdfActivityDoc != null && hdfProspectId != null && pnlDetails != null && pnlGeneral != null && lnkbtnGeneralInfo != null && lnkbtnDetailsInfo != null && lnkbtnUpdate != null && lnkbtnSaveAct != null && lnkbtnDownload != null && lnkbtnRemove != null && lblAddActProspect != null && ddlProspect != null && txtActDate != null && txtActTime != null && txtEndDate != null && txtEndTime != null)
            //{
            //    lnkbtnRemove.Visible = lnkbtnDownload.Visible = lblAddActProspect.Visible = pnlDetails.Visible = lnkbtnUpdate.Visible = false;
            //    ddlProspect.Visible = fpattachment.Enabled = lblAddActProspect.Visible = pnlGeneral.Visible = lnkbtnSaveAct.Visible = true;
            //    lnkbtnGeneralInfo.CssClass = "tablerBtnActive";
            //    lnkbtnDetailsInfo.CssClass = "";
            //    hdfActivityId.Value = "0";
            //    MethodInfo methods1 = UC_AddActivity1.GetType().GetMethod("BindConsultants");
            //    if (methods1 != null)
            //        methods1.Invoke(UC_AddActivity1, null);
            //    hdfActivityDoc.Value = string.Empty;
            //    lnkbtnDownload.CommandArgument = lnkbtnRemove.CommandArgument = string.Empty;
            //    txtActDate.Text = txtEndDate.Text = (Convert.ToDateTime(lblSelectedDate.Text)).ToString().Trim().Substring(0, 10);
            //    txtActTime.Text = e.Start.ToString().Substring(11, 5);
            //    txtEndTime.Text = e.End.ToString().Substring(11, 5);
            //}
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SearchProspect.lnkbtnAddActivity_Click.Error:" + ex.StackTrace);
        }

    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 June 2013
    /// Description: View Add Activity Details Pop Up 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddActPopUpClose_Click(object sender, EventArgs e)
    {
        pnlAddAct.Visible = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 June 2013
    /// Description: Back Button Click. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnBack_Click(object sender, EventArgs e)
    {
        pnlCallendar.Visible = true;
        pnlCallDetails.Visible = true;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 4 July 2013
    /// Description: Close Clear Activity Details Pop Up
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnClearActDetClose_Click(object sender, EventArgs e)
    {
        pnlClearActDeatils.Visible = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 6 Aug 2013
    /// Description: Clear Selected Consultant's Calendar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnClear_Click(object sender, EventArgs e)
    {
        ddlConsultant.SelectedValue = "0";
        DayPilotCalendar1.StartDate = DateTime.Today;
        DayPilotCalendar1.DataSource = BindActivities(BasePage.UserSession.VirtualRoleId);
        DayPilotCalendar1.DataBind();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 6 Aug 2013
    /// Description: Search Calendar For Selected Consultant
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSearch_Click(object sender, EventArgs e)
    {
        DayPilotCalendar1.StartDate = DateTime.Today;
        DayPilotCalendar1.DataSource = BindActivities(Convert.ToInt64(ddlConsultant.SelectedValue.Trim()));
        DayPilotCalendar1.DataBind();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 6 Aug 2013
    /// Description: Selected Index Changed Event Of Consultant's Dropdownlist
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlConsultant_SelectedIndexChanged(object sender, EventArgs e)
    {
        DayPilotCalendar1.StartDate = DateTime.Today;
        DayPilotCalendar1.DataSource = BindActivities(Convert.ToInt64(ddlConsultant.SelectedValue.Trim()));
        DayPilotCalendar1.DataBind();
    }

    #endregion

    #region Methods
    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 Jun 2013
    /// Descreption: Bind Activities To Callendar
    /// </summary>
    private DataTable BindActivities(Int64 VirtualRoleId)
    {
        try
        {
            if (VirtualRoleId == 0)
                VirtualRoleId = BasePage.UserSession.VirtualRoleId;
            DataTable Dt = objActivityBM.GetMyActivities(VirtualRoleId);
            return Dt;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ActivityCallendar.BindActivities.Error:" + ex.StackTrace);
            return null;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 6 Aug 2013
    /// Description: Get All Consultants
    /// </summary>
    private void BindConsultant()
    {
        try
        {
            Employee objEmp = new Employee();
            objEmp.FName = string.Empty;
            objEmp.RoleId = 3;//Hard Code For Consultant
            DataTable Dt = objEmpBM.GetAllEmployee(objEmp);
            Cls_BinderHelper.BindDropdownList(ddlConsultant, "Name", "VirtualRoleId", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ActivityCall.BindConsultant.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Gets the first day of a week where day (parameter) belongs. weekStart (parameter) specifies the starting day of week.
    /// </summary>
    /// <returns></returns> 
    private static DateTime firstDayOfWeek(DateTime day, DayOfWeek weekStarts)
    {
        DateTime d = day;
        while (d.DayOfWeek != weekStarts)
        {
            d = d.AddDays(-1);
        }

        return d;
    }
    #endregion
}
