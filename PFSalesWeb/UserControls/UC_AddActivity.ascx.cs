using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mechsoft.PFSales.BusinessEntity;
using Mechsoft.PFSales.BusinessManager;
using log4net;
using System.Configuration;
using System.Data;
using Mechsoft.GeneralUtilities;
using System.Text;
using System.IO;
using AjaxControlToolkit.HTMLEditor;
using System.Reflection;
using AjaxControlToolkit;

public partial class UserControls_UC_AddActivity : System.Web.UI.UserControl
{
    #region Global Variables
    Prospect objProsp = new Prospect();
    ProspectBM objProspBM = new ProspectBM();
    MasterBM objMstBM = new MasterBM();
    EmployeeBM objEmpBM = new EmployeeBM();
    Activity objActivity = new Activity();
    ActivityBM objActivityBM = new ActivityBM();
    ClearActivity objclrActivity = new ClearActivity();
    ILog logger = LogManager.GetLogger(typeof(UserControls_UC_AddActivity));
    double Interval1 = Convert.ToDouble(ConfigurationManager.AppSettings["ActInterval"].ToString().Trim());
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = "CreatedDate";
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] = "Name";
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION2] = "start";
            ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION2] = ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;
            BindActivityTypes();
            BindPriorities();
            BindActStatuses();
            BindAllStatuses();
            BindConsultants();
            BindProspects();
            Page.MaintainScrollPositionOnPostBack = true;
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            //  txtActTime.Text = "10:00";
            GetMinStartDate();

        }
        ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkbtnUpdate);
        ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkbtnSaveAct);
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 19 June 2013
    /// Description: Clear Button Click of Add Activity Pop Up. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnPhPopUpCancel_Click(object sender, EventArgs e)
    {
        ClearpopUp();
        clearMsg();
        hdfActivityDoc.Value = string.Empty;
        lnkbtnSaveAct.Visible = true;
        lnkbtnUpdate.Visible = false;
        lblAddActivity.Text = Resources.PFSalesResource.AddNewActivity.Trim();
        //lnkbtnDownload.CommandArgument = lnkbtnRemove.CommandArgument = string.Empty;
        //lnkbtnRemove.Visible = lnkbtnDownload.Visible = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 June 2013
    /// Description: General Info Button Click of Add Activity Pop Up. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnGeneralInfo_Click(object sender, EventArgs e)
    {
        clearMsg();
        pnlGeneral.Visible = true;
        pnlDetails.Visible = false;
        lnkbtnGeneralInfo.CssClass = "tablerBtnActive";
        lnkbtnDetailsInfo.CssClass = "";
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 June 2013
    /// Description: Details Info Button Click of Add Activity Pop Up. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnDetailsInfo_Click(object sender, EventArgs e)
    {
        clearMsg();
        pnlGeneral.Visible = false;
        pnlDetails.Visible = true;
        lnkbtnGeneralInfo.CssClass = "";
        lnkbtnDetailsInfo.CssClass = "tablerBtnActive";
        GetMinStartDate();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 June 2013
    /// Description: Selected Index Changed Event Of Select Alarm Value's Drop Down List. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlAlarm_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlAlarm.SelectedValue.Trim() == "0")
        //{
        //    lnkbtnSaveAct.Attributes["OnClientClick"] = "javascript:return TestCheckBox();";
        //    chkSms.Checked = chkEmail.Checked = chkDashBoard.Checked = false;
        //    dtAlertType.Visible = ddAlertType.Visible = false;
        //    hdfIsAlarmNeeded.Value = "0";
        //}
        //else
        //{
        //    lnkbtnSaveAct.Attributes["OnClientClick"] = "javascript:return TestSecCheckBox();";
        //    dtAlertType.Visible = ddAlertType.Visible = true;
        //    hdfIsAlarmNeeded.Value = "1";
        //}
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 21 June 2013
    /// Description: Selected Index Changed Event Of Select Duration Value's Drop Down List. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlDuration_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DateTime dtnew = new DateTime();
            if (ddlDuration.SelectedValue.Trim() != "0")
            {
                DateTime StartDate = Convert.ToDateTime(txtActDate.Text.Trim() + " " + txtActTime.Text.Trim());
                if (ddlDuration.SelectedValue.Trim() == "1")
                    dtnew = StartDate.AddMinutes(0);
                else
                    dtnew = StartDate.AddMinutes(Convert.ToDouble(ddlDuration.SelectedValue.Trim()));
                if (dtnew != DateTime.MinValue)
                {
                    //txtEndDate.Text = dtnew.ToString().Trim().Substring(0, 10);
                    //txtEndTime.Text = dtnew.ToString().Trim().Substring(11, 5);
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.ddlDuration_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 21 June 2013
    /// Description: Text Changed Event Of End Date's Text Box. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtEndDate_TextChanged(object sender, EventArgs e)
    {
        //try
        //{
        //    if (!string.IsNullOrEmpty(txtEndDate.Text.Trim().Replace("__", "").Replace("/", "")) && !string.IsNullOrEmpty(txtEndTime.Text.Trim().Replace("__", "").Replace(":", "")) && !string.IsNullOrEmpty(txtActDate.Text.Trim().Replace("__", "").Replace("/", "")) && !string.IsNullOrEmpty(txtActTime.Text.Trim().Replace("__", "").Replace(":", "")))
        //    {
        //        ListItem lstnew;
        //        int diff = 0, NoOfHrs = 0, NoOfMins = 0, NoOfDays = 0;
        //        DateTime dtStartdate = Convert.ToDateTime(txtActDate.Text.Trim() + " " + txtActTime.Text.Trim());
        //        DateTime dtEndDate = Convert.ToDateTime(txtEndDate.Text.Trim() + " " + txtEndTime.Text.Trim());
        //        if (dtEndDate > dtStartdate)
        //        {
        //            TimeSpan differnce = dtEndDate.Subtract(dtStartdate);
        //            double totalMinutes = differnce.TotalMinutes;
        //            if (totalMinutes > 60)
        //            {
        //                if (totalMinutes > 1440)
        //                {
        //                    NoOfDays = (int)totalMinutes / (int)1440;
        //                    if ((totalMinutes % 1440) > 60)
        //                    {
        //                        diff = (int)totalMinutes % 1440;
        //                        NoOfHrs = diff / 60;
        //                        NoOfMins = diff % 60;
        //                    }
        //                    else
        //                    {
        //                        NoOfMins = (int)totalMinutes % 1440;
        //                    }
        //                }
        //                else
        //                {
        //                    NoOfHrs = diff / 60;
        //                    NoOfMins = diff % 60;
        //                }
        //                if (NoOfDays > 0)
        //                {
        //                    if (NoOfHrs > 0)
        //                    {
        //                        if (NoOfMins > 0)
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfHrs).Trim() + " " + ((NoOfHrs > 1) ? Resources.PFSalesResource.Hours.Trim() : Resources.PFSalesResource.Hour.Trim()) + " " + Convert.ToString(NoOfMins).Trim() + " " + ((NoOfMins > 1) ? Resources.PFSalesResource.Minutes.Trim() : Resources.PFSalesResource.Minute.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                        else
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfHrs).Trim() + " " + ((NoOfHrs > 1) ? Resources.PFSalesResource.Hours.Trim() : Resources.PFSalesResource.Hour.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (NoOfMins > 0)
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfMins).Trim() + " " + ((NoOfMins > 1) ? Resources.PFSalesResource.Minutes.Trim() : Resources.PFSalesResource.Minute.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                        else
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    if (NoOfHrs > 0)
        //                    {
        //                        if (NoOfMins > 0)
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfHrs).Trim() + " " + ((NoOfHrs > 1) ? Resources.PFSalesResource.Hours.Trim() : Resources.PFSalesResource.Hour.Trim()) + " " + Convert.ToString(NoOfMins).Trim() + " " + ((NoOfMins > 1) ? Resources.PFSalesResource.Minutes.Trim() : Resources.PFSalesResource.Minute.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                        else
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfHrs).Trim() + " " + ((NoOfHrs > 1) ? Resources.PFSalesResource.Hours.Trim() : Resources.PFSalesResource.Hour.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (NoOfMins > 0)
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfMins).Trim() + " " + ((NoOfMins > 1) ? Resources.PFSalesResource.Minutes.Trim() : Resources.PFSalesResource.Minute.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                        else
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                lstnew = new ListItem(Convert.ToString(totalMinutes).Trim() + " " + Resources.PFSalesResource.Minutes.Trim(), Convert.ToString(totalMinutes).Trim());
        //            }
        //            ddlDuration.Items.Add(lstnew);
        //            ddlDuration.SelectedValue = totalMinutes.ToString().Trim();
        //        }
        //        else
        //        {
        //            //cvStrEndDate.Validate();
        //        }
        //    }
        //    //txtEndTime.Focus();

        //}
        //catch (Exception ex)
        //{
        //    logger.Error(ex.Message + "UserControls_UC_AddActivity.txtEndDate_TextChanged.Error:" + ex.StackTrace);
        //}
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 21 June 2013
    /// Description: Text Changed Event Of End Time's Text Box. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtEndTime_TextChanged(object sender, EventArgs e)
    {
        //try
        //{
        //    if (!string.IsNullOrEmpty(txtEndDate.Text.Trim().Replace("__", "").Replace("/", "")) && !string.IsNullOrEmpty(txtEndTime.Text.Trim().Replace("__", "").Replace(":", "")) && !string.IsNullOrEmpty(txtActDate.Text.Trim().Replace("__", "").Replace("/", "")) && !string.IsNullOrEmpty(txtActTime.Text.Trim().Replace("__", "").Replace(":", "")))
        //    {
        //        ListItem lstnew;
        //        int diff = 0, NoOfHrs = 0, NoOfMins = 0, NoOfDays = 0;
        //        DateTime dtStartdate = Convert.ToDateTime(txtActDate.Text.Trim() + " " + txtActTime.Text.Trim());
        //        DateTime dtEndDate = Convert.ToDateTime(txtEndDate.Text.Trim() + " " + txtEndTime.Text.Trim());
        //        if (dtEndDate > dtStartdate)
        //        {
        //            TimeSpan differnce = dtEndDate.Subtract(dtStartdate);
        //            double totalMinutes = differnce.TotalMinutes;
        //            if (totalMinutes > 60)
        //            {
        //                if (totalMinutes > 1440)
        //                {
        //                    NoOfDays = (int)totalMinutes / (int)1440;
        //                    if ((totalMinutes % 1440) > 60)
        //                    {
        //                        diff = (int)totalMinutes % 1440;
        //                        NoOfHrs = diff / 60;
        //                        NoOfMins = diff % 60;
        //                    }
        //                    else
        //                    {
        //                        NoOfMins = (int)totalMinutes % 1440;
        //                    }
        //                }
        //                else
        //                {
        //                    NoOfHrs = diff / 60;
        //                    NoOfMins = diff % 60;
        //                }
        //                if (NoOfDays > 0)
        //                {
        //                    if (NoOfHrs > 0)
        //                    {
        //                        if (NoOfMins > 0)
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfHrs).Trim() + " " + ((NoOfHrs > 1) ? Resources.PFSalesResource.Hours.Trim() : Resources.PFSalesResource.Hour.Trim()) + " " + Convert.ToString(NoOfMins).Trim() + " " + ((NoOfMins > 1) ? Resources.PFSalesResource.Minutes.Trim() : Resources.PFSalesResource.Minute.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                        else
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfHrs).Trim() + " " + ((NoOfHrs > 1) ? Resources.PFSalesResource.Hours.Trim() : Resources.PFSalesResource.Hour.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (NoOfMins > 0)
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfMins).Trim() + " " + ((NoOfMins > 1) ? Resources.PFSalesResource.Minutes.Trim() : Resources.PFSalesResource.Minute.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                        else
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    if (NoOfHrs > 0)
        //                    {
        //                        if (NoOfMins > 0)
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfHrs).Trim() + " " + ((NoOfHrs > 1) ? Resources.PFSalesResource.Hours.Trim() : Resources.PFSalesResource.Hour.Trim()) + " " + Convert.ToString(NoOfMins).Trim() + " " + ((NoOfMins > 1) ? Resources.PFSalesResource.Minutes.Trim() : Resources.PFSalesResource.Minute.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                        else
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfHrs).Trim() + " " + ((NoOfHrs > 1) ? Resources.PFSalesResource.Hours.Trim() : Resources.PFSalesResource.Hour.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (NoOfMins > 0)
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfMins).Trim() + " " + ((NoOfMins > 1) ? Resources.PFSalesResource.Minutes.Trim() : Resources.PFSalesResource.Minute.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                        else
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                lstnew = new ListItem(Convert.ToString(totalMinutes).Trim() + " " + Resources.PFSalesResource.Minutes.Trim(), Convert.ToString(totalMinutes).Trim());
        //            }
        //            ddlDuration.Items.Add(lstnew);
        //            ddlDuration.SelectedValue = totalMinutes.ToString().Trim();
        //        }
        //        else
        //        {
        //            //cvStrEndDate.Validate();
        //        }
        //    }
        //    //txtLocation.Focus();
        //}
        //catch (Exception ex)
        //{
        //    logger.Error(ex.Message + "UserControls_UC_AddActivity.txtEndTime_TextChanged.Error:" + ex.StackTrace);
        //}
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 21 June 2013
    /// Description: Text Changed Event Of Start Date's Text Box. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtActDate_textChanged(object sender, EventArgs e)
    {
        //try
        //{
        //    if (!string.IsNullOrEmpty(txtEndDate.Text.Trim().Replace("__", "").Replace("/", "")) && !string.IsNullOrEmpty(txtEndTime.Text.Trim().Replace("__", "").Replace(":", "")) && !string.IsNullOrEmpty(txtActDate.Text.Trim().Replace("__", "").Replace("/", "")) && !string.IsNullOrEmpty(txtActTime.Text.Trim().Replace("__", "").Replace(":", "")))
        //    {
        //        ListItem lstnew;
        //        int diff = 0, NoOfHrs = 0, NoOfMins = 0, NoOfDays = 0;
        //        DateTime dtStartdate = Convert.ToDateTime(txtActDate.Text.Trim() + " " + txtActTime.Text.Trim());
        //        DateTime dtEndDate = Convert.ToDateTime(txtEndDate.Text.Trim() + " " + txtEndTime.Text.Trim());
        //        if (dtEndDate > dtStartdate)
        //        {
        //            TimeSpan differnce = dtEndDate.Subtract(dtStartdate);
        //            double totalMinutes = differnce.TotalMinutes;
        //            if (totalMinutes > 60)
        //            {
        //                if (totalMinutes > 1440)
        //                {
        //                    NoOfDays = (int)totalMinutes / (int)1440;
        //                    if ((totalMinutes % 1440) > 60)
        //                    {
        //                        diff = (int)totalMinutes % 1440;
        //                        NoOfHrs = diff / 60;
        //                        NoOfMins = diff % 60;
        //                    }
        //                    else
        //                    {
        //                        NoOfMins = (int)totalMinutes % 1440;
        //                    }
        //                }
        //                else
        //                {
        //                    NoOfHrs = diff / 60;
        //                    NoOfMins = diff % 60;
        //                }
        //                if (NoOfDays > 0)
        //                {
        //                    if (NoOfHrs > 0)
        //                    {
        //                        if (NoOfMins > 0)
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfHrs).Trim() + " " + ((NoOfHrs > 1) ? Resources.PFSalesResource.Hours.Trim() : Resources.PFSalesResource.Hour.Trim()) + " " + Convert.ToString(NoOfMins).Trim() + " " + ((NoOfMins > 1) ? Resources.PFSalesResource.Minutes.Trim() : Resources.PFSalesResource.Minute.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                        else
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfHrs).Trim() + " " + ((NoOfHrs > 1) ? Resources.PFSalesResource.Hours.Trim() : Resources.PFSalesResource.Hour.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (NoOfMins > 0)
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfMins).Trim() + " " + ((NoOfMins > 1) ? Resources.PFSalesResource.Minutes.Trim() : Resources.PFSalesResource.Minute.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                        else
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    if (NoOfHrs > 0)
        //                    {
        //                        if (NoOfMins > 0)
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfHrs).Trim() + " " + ((NoOfHrs > 1) ? Resources.PFSalesResource.Hours.Trim() : Resources.PFSalesResource.Hour.Trim()) + " " + Convert.ToString(NoOfMins).Trim() + " " + ((NoOfMins > 1) ? Resources.PFSalesResource.Minutes.Trim() : Resources.PFSalesResource.Minute.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                        else
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfHrs).Trim() + " " + ((NoOfHrs > 1) ? Resources.PFSalesResource.Hours.Trim() : Resources.PFSalesResource.Hour.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (NoOfMins > 0)
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfMins).Trim() + " " + ((NoOfMins > 1) ? Resources.PFSalesResource.Minutes.Trim() : Resources.PFSalesResource.Minute.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                        else
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                lstnew = new ListItem(Convert.ToString(totalMinutes).Trim() + " " + Resources.PFSalesResource.Minutes.Trim(), Convert.ToString(totalMinutes).Trim());
        //            }
        //            ddlDuration.Items.Add(lstnew);
        //            ddlDuration.SelectedValue = totalMinutes.ToString().Trim();
        //        }
        //        else
        //        {
        //            // cvStrEndDate.Validate();
        //        }
        //    }
        //    //txtActTime.Focus();
        //}
        //catch (Exception ex)
        //{
        //    logger.Error(ex.Message + "UserControls_UC_AddActivity.txtActDate_textChanged.Error:" + ex.StackTrace);
        //}
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 21 June 2013
    /// Description: Text Changed Event Of Start Time's Text Box. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtActTime_TextChanged(object sender, EventArgs e)
    {
        //try
        //{
        //    if (!string.IsNullOrEmpty(txtEndDate.Text.Trim().Replace("__", "").Replace("/", "")) && !string.IsNullOrEmpty(txtEndTime.Text.Trim().Replace("__", "").Replace(":", "")) && !string.IsNullOrEmpty(txtActDate.Text.Trim().Replace("__", "").Replace("/", "")) && !string.IsNullOrEmpty(txtActTime.Text.Trim().Replace("__", "").Replace(":", "")))
        //    {
        //        ListItem lstnew;
        //        int diff = 0, NoOfHrs = 0, NoOfMins = 0, NoOfDays = 0;
        //        DateTime dtStartdate = Convert.ToDateTime(txtActDate.Text.Trim() + " " + txtActTime.Text.Trim());
        //        DateTime dtEndDate = Convert.ToDateTime(txtEndDate.Text.Trim() + " " + txtEndTime.Text.Trim());
        //        if (dtEndDate > dtStartdate)
        //        {
        //            TimeSpan differnce = dtEndDate.Subtract(dtStartdate);
        //            double totalMinutes = differnce.TotalMinutes;
        //            if (totalMinutes > 60)
        //            {
        //                if (totalMinutes > 1440)
        //                {
        //                    NoOfDays = (int)totalMinutes / (int)1440;
        //                    if ((totalMinutes % 1440) > 60)
        //                    {
        //                        diff = (int)totalMinutes % 1440;
        //                        NoOfHrs = diff / 60;
        //                        NoOfMins = diff % 60;
        //                    }
        //                    else
        //                    {
        //                        NoOfMins = (int)totalMinutes % 1440;
        //                    }
        //                }
        //                else
        //                {
        //                    NoOfHrs = diff / 60;
        //                    NoOfMins = diff % 60;
        //                }
        //                if (NoOfDays > 0)
        //                {
        //                    if (NoOfHrs > 0)
        //                    {
        //                        if (NoOfMins > 0)
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfHrs).Trim() + " " + ((NoOfHrs > 1) ? Resources.PFSalesResource.Hours.Trim() : Resources.PFSalesResource.Hour.Trim()) + " " + Convert.ToString(NoOfMins).Trim() + " " + ((NoOfMins > 1) ? Resources.PFSalesResource.Minutes.Trim() : Resources.PFSalesResource.Minute.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                        else
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfHrs).Trim() + " " + ((NoOfHrs > 1) ? Resources.PFSalesResource.Hours.Trim() : Resources.PFSalesResource.Hour.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (NoOfMins > 0)
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfMins).Trim() + " " + ((NoOfMins > 1) ? Resources.PFSalesResource.Minutes.Trim() : Resources.PFSalesResource.Minute.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                        else
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    if (NoOfHrs > 0)
        //                    {
        //                        if (NoOfMins > 0)
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfHrs).Trim() + " " + ((NoOfHrs > 1) ? Resources.PFSalesResource.Hours.Trim() : Resources.PFSalesResource.Hour.Trim()) + " " + Convert.ToString(NoOfMins).Trim() + " " + ((NoOfMins > 1) ? Resources.PFSalesResource.Minutes.Trim() : Resources.PFSalesResource.Minute.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                        else
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfHrs).Trim() + " " + ((NoOfHrs > 1) ? Resources.PFSalesResource.Hours.Trim() : Resources.PFSalesResource.Hour.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (NoOfMins > 0)
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()) + " " + Convert.ToString(NoOfMins).Trim() + " " + ((NoOfMins > 1) ? Resources.PFSalesResource.Minutes.Trim() : Resources.PFSalesResource.Minute.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                        else
        //                        {
        //                            lstnew = new ListItem(Convert.ToString(NoOfDays).Trim() + " " + ((NoOfDays > 1) ? Resources.PFSalesResource.Days.Trim() : Resources.PFSalesResource.Day.Trim()), Convert.ToString(totalMinutes).Trim());
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                lstnew = new ListItem(Convert.ToString(totalMinutes).Trim() + " " + Resources.PFSalesResource.Minutes.Trim(), Convert.ToString(totalMinutes).Trim());
        //            }
        //            ddlDuration.Items.Add(lstnew);
        //            ddlDuration.SelectedValue = totalMinutes.ToString().Trim();
        //        }
        //        else
        //        {
        //            //cvStrEndDate.Validate();
        //        }
        //    }
        //    //ddlDuration.Focus();
        //}
        //catch (Exception ex)
        //{
        //    logger.Error(ex.Message + "UserControls_UC_AddActivity.txtActTime_TextChanged.Error:" + ex.StackTrace);
        //}
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 June 2013
    /// Description: Button Click Event Of Add Regardings Button. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddReg_Click(object sender, EventArgs e)
    {
        //ddlRegarding.SelectedValue = "0";
        //lnkbtnAddReg.Visible = ddlRegarding.Visible = false;
        //lnkbtnMinusReg.Visible = txtRegarding.Visible = true;
        txtRegarding.Focus();
        //rfvNewReg.Enabled = true;
        //rfvRegardings.Enabled = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 June 2013
    /// Description: Button Click Event Of Cancel Add Regardings Button. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnMinusReg_Click(object sender, EventArgs e)
    {
        txtRegarding.Text = string.Empty;
        //lnkbtnAddReg.Visible = ddlRegarding.Visible = true;
        //lnkbtnMinusReg.Visible = txtRegarding.Visible = false;
        //rfvNewReg.Enabled = false;
        //rfvRegardings.Enabled = true;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 2 July 2013
    /// Description: Button Click Event Of Close Manage Activity Pop Up. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnCloseManAct_Click(object sender, EventArgs e)
    {

        hdfActivityDoc.Value = string.Empty;
        //lnkbtnDownload.CommandArgument = lnkbtnRemove.CommandArgument = string.Empty;
        //lnkbtnRemove.Visible = lnkbtnDownload.Visible = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 2 July 2013
    /// Description: Button Click Event Of Close Manage Activity Pop Up. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvActivity_Soring(object sender, GridViewSortEventArgs e)
    {

    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 2 July 2013
    /// Description: Button Click Event Of Close Manage Activity Pop Up. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnViewActDet_Click(object sender, EventArgs e)
    {
        try
        {
            hdfActivityId.Value = ((LinkButton)sender).CommandArgument.Trim();
            pnlDetails.Visible = lnkbtnSaveAct.Visible = false;
            pnlGeneral.Visible = lnkbtnUpdate.Visible = true;
            lnkbtnGeneralInfo.CssClass = "tablerBtnActive";
            lnkbtnDetailsInfo.CssClass = "";
            //lblAddActPopUp.Text = Resources.PFSalesResource.updateactivity.Trim();
            //pnlAddAct.Visible = true;
            //lblAddActProspect.Text = lblSelectedProsp.Text.Trim();
            DataTable Dt = objActivityBM.GetActivityDetFromId(Convert.ToInt64(hdfActivityId.Value.Trim()), BasePage.UserSession.VirtualRoleId);
            if (Dt != null && Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0]["ProspectId"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["ProspectId"].ToString().Trim()))
                {
                    // ddlProspect.SelectedValue = Dt.Rows[0]["ProspectId"].ToString().Trim();
                    hdfProspectId.Value = Dt.Rows[0]["ProspectId"].ToString().Trim();
                }
                ddlAddActType.SelectedValue = Dt.Rows[0]["ActivityTypeId"].ToString().Trim();
                ddlAddActType_SelectedIndexChanged(null, null);
                //ddlRegarding.SelectedValue = Dt.Rows[0]["RegId"].ToString().Trim();
                ddlPriority.SelectedValue = Dt.Rows[0]["ActivityPriorityId"].ToString().Trim();
                txtActDate.Text = Convert.ToDateTime(Dt.Rows[0]["start"].ToString().Trim()).ToString("g").Substring(0, 10);
                //txtActTime.Text = Dt.Rows[0]["start"].ToString().Trim().Substring(11, 5);
                ddlActTime.SelectedValue = Dt.Rows[0]["start"].ToString().Trim().Substring(11, 5);
                hdfOldActStartTime.Value = Dt.Rows[0]["start"].ToString().Trim();
                //txtEndDate.Text = Convert.ToDateTime(Dt.Rows[0]["end"].ToString().Trim()).ToString("g").Substring(0, 10);
                //txtEndTime.Text = Dt.Rows[0]["end"].ToString().Trim().Substring(11, 5);
                txtLocation.Text = Dt.Rows[0]["Location"].ToString().Trim();
                hdfActivityDocId.Value = Dt.Rows[0]["DocId"].ToString().Trim();
                hdfActivityDoc.Value = Dt.Rows[0]["Filepath"].ToString().Trim();
                //if (!string.IsNullOrEmpty(Dt.Rows[0]["Filepath"].ToString().Trim()))
                //{
                //    fpattachment.Enabled = false;
                //    lnkbtnDownload.CommandArgument = lnkbtnRemove.CommandArgument = Dt.Rows[0]["Filepath"].ToString().Trim();
                //    lnkbtnRemove.Visible = lnkbtnDownload.Visible = true;
                //}
                txtRemark.Text = Dt.Rows[0]["Remark"].ToString().Trim();
                if (Dt.Rows[0]["AlertValueBefore"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["AlertValueBefore"].ToString().Trim()))
                    ddlAlarm.SelectedValue = Dt.Rows[0]["AlertValueBefore"].ToString().Trim();
                ddlAlarm_SelectedIndexChanged(null, null);
                BindConsultants();
                DataTable dtAlertDet = objActivityBM.GetActivityAlertDetailsFromId(Convert.ToInt64(hdfActivityId.Value.Trim()), BasePage.UserSession.VirtualRoleId);
                //if (dtAlertDet != null && dtAlertDet.Rows.Count > 0)
                //{
                //foreach (GridViewRow Gr in gvAllocate.Rows)
                //{
                //HiddenField hdfConsultantId = (HiddenField)Gr.FindControl("hdfConsultantId");
                //CheckBox chkSelect = (CheckBox)Gr.FindControl("chkSelect");
                //for (int i = 0; i < dtAlertDet.Rows.Count; i++)
                //{
                //    if (hdfConsultantId != null && chkSelect != null)
                //    {
                //        if (hdfConsultantId.Value.Trim() == dtAlertDet.Rows[i]["AlertForId"].ToString().Trim() && Convert.ToBoolean(dtAlertDet.Rows[i]["IsDeleted"].ToString().Trim()) == false)
                //        {
                //            chkSelect.Checked = true;
                //        }
                //    }
                //if (dtAlertDet.Rows[i]["AlertTypeId"].ToString().Trim() == Cls_Constant.DashBoardAlert.ToString().Trim())
                //    chkDashBoard.Checked = true;
                //if (dtAlertDet.Rows[i]["AlertTypeId"].ToString().Trim() == Cls_Constant.MailAlert.ToString().Trim())
                //    chkEmail.Checked = true;
                //if (dtAlertDet.Rows[i]["AlertTypeId"].ToString().Trim() == Cls_Constant.SMSAlert.ToString().Trim())
                //    chkSms.Checked = true;
                //}
                //}
                //}
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.lnkbtnViewActDet_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 2 July 2013
    /// Description: Update Activity For Selected Lead
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            clearMsg();
            // Page.Validate("Custom");
            if (Page.IsValid)
            {
                //if ((Convert.ToDateTime(hdfOldActStartTime.Value.Trim())) > DateTime.Now)
                //{
                if (ddlclrActStatus.SelectedValue.Trim() != "0" && !string.IsNullOrEmpty(hdfProspectId.Value.Trim()) && Convert.ToInt64(hdfProspectId.Value.Trim()) > 0 && ddlAddActType.SelectedValue.Trim() != "0" && !string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlActTime.SelectedValue.Trim() != "0" && ddlPriority.SelectedValue.Trim() != "0")
                {
                    if (hdfisUpdateNotes.Value.Trim() == "1")
                    {
                        UpdateActiNotes();
                    }
                    else
                    {
                        UpdateOnlyActivity();
                        SaveViewState();
                    }
                    ClearAll();
                }
                else if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()) && Convert.ToInt64(hdfProspectId.Value.Trim()) > 0 && ddlAddActType.SelectedValue.Trim() != "0" && !string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlActTime.SelectedValue.Trim() != "0" && ddlPriority.SelectedValue.Trim() != "0" && string.IsNullOrEmpty(txtclrRemark.Text.Trim()) && ddlclrActStatus.SelectedValue.Trim() == "0")
                {
                    UpdateOnlyActivity();
                    ClearAll();
                }
                else if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()) && Convert.ToInt64(hdfProspectId.Value.Trim()) > 0 && ddlclrActStatus.SelectedValue.Trim() != "0" && string.IsNullOrEmpty(txtActDate.Text.Trim()))
                {
                    if (hdfisUpdateNotes.Value.Trim() == "1")
                        UpdateOnlyNotes();
                    else
                        SaveOnlyNotes();
                    ClearAll();
                }
                else if (string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlclrActStatus.SelectedValue.Trim() == "0" && string.IsNullOrEmpty(txtclrRemark.Text.Trim()))
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.NotesOrActVal.Trim();
                    dvaserSuccess.Visible = false;
                    lblSerSucMsg.Text = string.Empty;
                    dvsererror.Visible = true;
                }
                else if (string.IsNullOrEmpty(hdfProspectId.Value.Trim()) || Convert.ToInt64(hdfProspectId.Value.Trim()) == 0)
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.ContactSelVal.Trim();
                    dvaserSuccess.Visible = false;
                    lblSerSucMsg.Text = string.Empty;
                    dvsererror.Visible = true;
                }
                //else if (ddlclrActStatus.SelectedValue.Trim() != "0" && string.IsNullOrEmpty(txtclrRemark.Text.Trim()))
                //{
                //    rfvclrActStatus.Enabled = rfvAddActType.Enabled = rvActTime.Enabled = rfvActPriority.Enabled = rfvNotes.IsValid = false;
                //    rfvclrActStatus.IsValid = rfvActPriority.IsValid = rvActTime.IsValid = rfvAddActType.IsValid = rfvNotes.Enabled = true;
                //    txtclrRemark.Focus();
                //    Page.Validate();
                //}
                //else if (ddlclrActStatus.SelectedValue.Trim() == "0" && !string.IsNullOrEmpty(txtclrRemark.Text.Trim()))
                //{
                //    rfvNotes.Enabled = rfvAddActType.Enabled = rvActTime.Enabled = rfvActPriority.Enabled = rfvclrActStatus.IsValid = false;
                //    rfvNotes.IsValid = rfvActPriority.IsValid = rvActTime.IsValid = rfvAddActType.IsValid = rfvclrActStatus.Enabled = true;
                //    ddlclrActStatus.Focus();
                //    Page.Validate("Save");
                //}
                else if (!string.IsNullOrEmpty(txtActDate.Text.Trim()))
                {
                    if (ddlAddActType.SelectedValue.Trim() == "0")
                    {
                        rfvActPriority.Enabled = rvActTime.Enabled = rfvclrActStatus.Enabled = rfvNotes.Enabled = rfvAddActType.IsValid = false;
                        rfvActPriority.IsValid = rvActTime.IsValid = rfvclrActStatus.IsValid = rfvNotes.IsValid = rfvAddActType.Enabled = true;
                        ddlAddActType.Focus();
                        Page.Validate("Save");
                    }
                    else if (ddlActTime.SelectedValue.Trim() == "0")
                    {
                        rfvActPriority.Enabled = rfvAddActType.Enabled = rfvclrActStatus.Enabled = rfvNotes.Enabled = rvActTime.IsValid = false;
                        rfvActPriority.IsValid = rfvAddActType.IsValid = rfvclrActStatus.IsValid = rfvNotes.IsValid = rvActTime.Enabled = true;
                        ddlActTime.Focus();
                        Page.Validate("Save");
                    }
                    else if (ddlPriority.SelectedValue.Trim() == "0")
                    {
                        rvActTime.Enabled = rfvAddActType.Enabled = rfvclrActStatus.Enabled = rfvNotes.Enabled = rfvActPriority.IsValid = false;
                        rvActTime.IsValid = rfvAddActType.IsValid = rfvclrActStatus.IsValid = rfvNotes.IsValid = rfvActPriority.Enabled = true;
                        ddlPriority.Focus();
                        Page.Validate("Save");
                    }
                }
                //}
                //else
                //{
                //    lblSerErrMsg.Text = Resources.PFSalesResource.CantUpdateActivity.Trim();
                //    dvaserSuccess.Visible = false;
                //    lblSerSucMsg.Text = string.Empty;
                //    dvsererror.Visible = true;
                //}
                pnlGeneral.Visible = true;
                pnlDetails.Visible = false;
                lnkbtnGeneralInfo.CssClass = "tablerBtnActive";
                lnkbtnDetailsInfo.CssClass = "";
                BindMangeData();
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.lnkbtnUpdate_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 July 2013
    /// Description: Row Data Bound Event Of Manage Activity's Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvActivity_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdfClrId = (HiddenField)e.Row.FindControl("hdfClrId");
                LinkButton lnkbtnClearActDet = (LinkButton)e.Row.FindControl("lnkbtnClearActDet");
                if (hdfClrId != null && lnkbtnClearActDet != null)
                {
                    if (!string.IsNullOrEmpty(hdfClrId.Value) && Convert.ToInt64(hdfClrId.Value) > 0)
                    {
                        lnkbtnClearActDet.Enabled = false;
                        lnkbtnClearActDet.ToolTip = Resources.PFSalesResource.ClearedActivity.Trim();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.gvActivity_RowDataBound.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 July 2013
    /// Description: Remove Attachment Which Was Added While Adding Activity
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnRemove_click(object sender, EventArgs e)
    {
        try
        {
            if ((Convert.ToDateTime(hdfOldActStartTime.Value.Trim())) > DateTime.Now)
            {
                string path = ((LinkButton)sender).CommandArgument.Trim();
                if (!string.IsNullOrEmpty(path))
                {
                    if (File.Exists(Server.MapPath(path.Trim())))
                    {
                        File.Delete(Server.MapPath(path.Trim()));
                        //lnkbtnRemove.Visible = lnkbtnDownload.Visible = false;
                        //fpattachment.Enabled = true;
                    }
                }
            }
            else
            {
                lblSerErrMsg.Text = Resources.PFSalesResource.CantUpdateActivity.Trim();
                dvaserSuccess.Visible = false;
                lblSerSucMsg.Text = string.Empty;
                dvsererror.Visible = true;
                lnkbtnGeneralInfo.CssClass = "tablerBtnActive";
                lnkbtnDetailsInfo.CssClass = "";
                pnlGeneral.Visible = true;
                pnlDetails.Visible = false;
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.lnkbtnRemove_click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 July 2013
    /// Description: Remove Attachment Which Was Added While Adding Activity
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            DownloadFile(((LinkButton)sender).CommandArgument.ToString());
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.lnkbtnDownload_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 June 2013
    /// Description: Save Activity For Selected Lead
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlAddActType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlAddActType.SelectedValue != "0")
        //    BindRegardings();
        //else
        //{
        //    ddlRegarding.Items.Clear();
        //    ddlRegarding.DataSource = null;
        //    ddlRegarding.DataBind();
        //    ListItem lst = new ListItem();
        //    lst.Text = Resources.PFSalesResource.ddlSelect.Trim();
        //    lst.Value = "0";
        //    ddlRegarding.Items.Add(lst);
        //}
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 June 2013
    /// Description: Save Activity For Selected Lead
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSaveAct_Click(object sender, EventArgs e)
    {
        try
        {
            clearMsg();
            //Page.Validate("Custom");
            if (Page.IsValid)
            {
                if (ddlclrActStatus.SelectedValue.Trim() != "0" && !string.IsNullOrEmpty(hdfProspectId.Value.Trim()) && Convert.ToInt64(hdfProspectId.Value.Trim()) > 0 && ddlAddActType.SelectedValue.Trim() != "0" && !string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlActTime.SelectedValue.Trim() != "0" && ddlPriority.SelectedValue.Trim() != "0")
                {
                    SaveActiNotes();
                    ClearAll();
                }
                else if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()) && Convert.ToInt64(hdfProspectId.Value.Trim()) > 0 && ddlAddActType.SelectedValue.Trim() != "0" && !string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlActTime.SelectedValue.Trim() != "0" && ddlPriority.SelectedValue.Trim() != "0" && string.IsNullOrEmpty(txtclrRemark.Text.Trim()) && ddlclrActStatus.SelectedValue.Trim() == "0")
                {
                    SaveOnlyActivity();
                    ClearAll();
                }
                else if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()) && Convert.ToInt64(hdfProspectId.Value.Trim()) > 0 && ddlclrActStatus.SelectedValue.Trim() != "0" && string.IsNullOrEmpty(txtActDate.Text.Trim()))
                {
                    SaveOnlyNotes();
                    ClearAll();
                }
                else if (string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlclrActStatus.SelectedValue.Trim() == "0" && string.IsNullOrEmpty(txtclrRemark.Text.Trim()))
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.NotesOrActVal.Trim();
                    dvaserSuccess.Visible = false;
                    lblSerSucMsg.Text = string.Empty;
                    dvsererror.Visible = true;
                }
                else if (string.IsNullOrEmpty(hdfProspectId.Value.Trim()) || Convert.ToInt64(hdfProspectId.Value.Trim()) == 0)
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.ContactSelVal.Trim();
                    dvaserSuccess.Visible = false;
                    lblSerSucMsg.Text = string.Empty;
                    dvsererror.Visible = true;
                }
                //else if (ddlclrActStatus.SelectedValue.Trim() != "0" && string.IsNullOrEmpty(txtclrRemark.Text.Trim()))
                //{
                //    rfvclrActStatus.Enabled = rfvAddActType.Enabled = rvActTime.Enabled = rfvActPriority.Enabled = rfvNotes.IsValid = false;
                //    rfvclrActStatus.IsValid = rfvActPriority.IsValid = rvActTime.IsValid = rfvAddActType.IsValid = rfvNotes.Enabled = true;
                //    txtclrRemark.Focus();
                //    Page.Validate();
                //}
                //else if (ddlclrActStatus.SelectedValue.Trim() == "0" && !string.IsNullOrEmpty(txtclrRemark.Text.Trim()))
                //{
                //    rfvNotes.Enabled = rfvAddActType.Enabled = rvActTime.Enabled = rfvActPriority.Enabled = rfvclrActStatus.IsValid = false;
                //    rfvNotes.IsValid = rfvActPriority.IsValid = rvActTime.IsValid = rfvAddActType.IsValid = rfvclrActStatus.Enabled = true;
                //    ddlclrActStatus.Focus();
                //    Page.Validate("Save");
                //}
                else if (!string.IsNullOrEmpty(txtActDate.Text.Trim()))
                {
                    if (ddlAddActType.SelectedValue.Trim() == "0")
                    {
                        rfvActPriority.Enabled = rvActTime.Enabled = rfvclrActStatus.Enabled = rfvNotes.Enabled = rfvAddActType.IsValid = false;
                        rfvActPriority.IsValid = rvActTime.IsValid = rfvclrActStatus.IsValid = rfvNotes.IsValid = rfvAddActType.Enabled = true;
                        ddlAddActType.Focus();
                        Page.Validate("Save");
                    }
                    else if (ddlActTime.SelectedValue.Trim() == "0")
                    {
                        rfvActPriority.Enabled = rfvAddActType.Enabled = rfvclrActStatus.Enabled = rfvNotes.Enabled = rvActTime.IsValid = false;
                        rfvActPriority.IsValid = rfvAddActType.IsValid = rfvclrActStatus.IsValid = rfvNotes.IsValid = rvActTime.Enabled = true;
                        ddlActTime.Focus();
                        Page.Validate("Save");
                    }
                    else if (ddlPriority.SelectedValue.Trim() == "0")
                    {
                        rvActTime.Enabled = rfvAddActType.Enabled = rfvclrActStatus.Enabled = rfvNotes.Enabled = rfvActPriority.IsValid = false;
                        rvActTime.IsValid = rfvAddActType.IsValid = rfvclrActStatus.IsValid = rfvNotes.IsValid = rfvActPriority.Enabled = true;
                        ddlPriority.Focus();
                        Page.Validate("Save");
                    }
                }
            }
            GetMinStartDate();
            if (ViewState["ContactStatus"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["ContactStatus"]).Trim()))
            {
                if (BasePage.UserSession.RoleId == 3)
                {
                    if (ddlclrStatus.SelectedValue.Trim().ToUpper() != Convert.ToString(ViewState["ContactStatus"]).Trim().ToUpper())
                    {
                        if (ddlclrStatus.SelectedValue.Trim() == "25" || ddlclrStatus.SelectedValue.Trim() == "27")
                        {
                            if (ViewState["FConsultEmail"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["FConsultEmail"]).Trim()) && ViewState["FConsultant"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["FConsultant"]).Trim()))
                                SendMail(Convert.ToString(ViewState["FConsultEmail"]).Trim(), ddlclrStatus.SelectedItem.Text.Trim(), Convert.ToString(ViewState["FConsultant"]).Trim(), Convert.ToString(ViewState["Name"]).Trim());
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.lnkbtnSaveAct_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 16 June 2013
    /// Description: Selected Index Changed Event Of Prospect's Drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlProspect_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (ddlProspect.SelectedValue != "0")
            //{
            hdfProspectId.Value = ddlProspect.SelectedValue.Trim();
            BidData(Convert.ToInt64(hdfProspectId.Value.Trim()));
            lblAddActProspect.Text = ddlProspect.SelectedItem.Text.Trim();
            UserControl ucDetails = (UserControl)(this.Parent).FindControl("UC_ProspectDetails1");
            if (ucDetails != null)
            {
                MethodInfo methods1 = (ucDetails).GetType().GetMethod("BidData");// ((Page)this.Parent).GetType().GetMethod("BindMangeActivity");
                if (methods1 != null)
                {
                    object[] objParam = new object[] { Convert.ToInt64(ddlProspect.SelectedValue.Trim()) };
                    methods1.Invoke((ucDetails), objParam);
                }
            }
            BindMangeData();
            GetMinStartDate();
            //}
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.ddlProspect_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 Aug 2013
    /// Description: Set Reminder for next Working Day
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnCallTommarrow_Click(object sender, EventArgs e)
    {
        try
        {
            int DayofTheWeek = Convert.ToInt32(DateTime.Today.DayOfWeek);
            DateTime Dt1 = DateTime.Today;
            switch (DayofTheWeek)
            {
                case 5://friday
                    Dt1 = Dt1.AddDays(3);
                    break;
                case 6://Saturday
                    Dt1 = Dt1.AddDays(2);
                    break;
                default:
                    Dt1 = Dt1.AddDays(1);
                    break;
            }
            SetCallTomorrow(Dt1);
            GetMinStartDate();
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.lnkbtnCallTommarrow_Click.Error:" + ex.StackTrace);
        }
    }
    #endregion

    #region Methods

    /// <summary>
    /// Crearted By:Pravin Gholap
    /// Created Date:10 June 2013
    /// Description:Define the sort direction for sorting the grid view
    /// </summary>
    public void DefineSortDirection()
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
            logger.Error(ex.Message + "UserControls_UC_AddActivity.DefineSortDirection.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 June 2013
    /// Description: Bind All Activity Types
    /// </summary>
    public void BindActivityTypes()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllActivityTypes(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlAddActType, "Name", "Id", Dt);
            ddlAddActType.SelectedValue = "1";
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.BindActivityTypes.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 June 2013
    /// Description: Bind All Regardings
    /// </summary>
    public void BindRegardings()
    {
        try
        {
            //DataTable Dt = objMstBM.GetAllRegardings(string.Empty, Convert.ToInt16(ddlAddActType.SelectedValue.Trim()));
            //Cls_BinderHelper.BindDropdownList(ddlRegarding, "Name", "Id", Dt);
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.BindRegardings.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 June 2013
    /// Description: Bind All Priorities
    /// </summary>
    public void BindPriorities()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllActPriorities(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlPriority, "Name", "Id", Dt);
            ddlPriority.SelectedValue = "2";
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.BindPriorities.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Crearted By:Pravin Gholap
    /// Created Date:19 June 2013
    /// Description:Define the sort direction for sorting the Consultant's grid view
    /// </summary>
    public void DefineConsultSortDirection()
    {
        try
        {
            if (ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION1] != null)
            {
                if (ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION1].ToString() == Cls_Constant.VIEWSTATE_ASC)
                {
                    ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = Cls_Constant.VIEWSTATE_DESC;
                }
                else
                {
                    ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION1] = Cls_Constant.VIEWSTATE_ASC;
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.DefineConsultSortDirection.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 June 2013
    /// Description: Bind ConsulTants
    /// </summary>
    public void BindConsultants()
    {
        try
        {
            Int64 ActId = 0;
            if (hdfActivityId != null && !string.IsNullOrEmpty(hdfActivityId.Value.Trim()))
                ActId = Convert.ToInt64(hdfActivityId.Value.Trim());
            DataTable Dt = objActivityBM.GetAllConsultForActivity(string.Empty, ActId);
            if (Dt != null & Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0]["ActSMSAlertId"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["ActSMSAlertId"].ToString().Trim()))
                    hdfActSMSAlertId.Value = Dt.Rows[0]["ActSMSAlertId"].ToString().Trim();
                if (Dt.Rows[0]["ActMailAlertId"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["ActMailAlertId"].ToString().Trim()))
                    hdfActMailAlertId.Value = Dt.Rows[0]["ActMailAlertId"].ToString().Trim();
                if (Dt.Rows[0]["ActDashAlertId"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["ActDashAlertId"].ToString().Trim()))
                    hdfActDashAlertId.Value = Dt.Rows[0]["ActDashAlertId"].ToString().Trim();
                if (Dt.Rows[0]["ActDashAlertId"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["ActDashAlertId"].ToString().Trim()))
                    hdfActResId.Value = Dt.Rows[0]["ActResId"].ToString().Trim();
                //DataView dV = Dt.DefaultView;
                //dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION1].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION1].ToString());
                //gvAllocate.DataSource = Dt;
                //gvAllocate.DataBind();
            }
            else
            {
                //gvAllocate.DataSource = null;
                //gvAllocate.DataBind();
            }
        }

        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.BindConsultants.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 19 June 2013
    /// Description: Clear Controls Inside Add Activity PopUp
    /// </summary>
    public void ClearpopUp()
    {
        try
        {
            //if (pnlGeneral.Visible)
            //{
            ViewState["SelectedStatus"] = ddlAlarm.SelectedValue = ddlclrStatus.SelectedValue = ddlAddActType.SelectedValue = ddlPriority.SelectedValue = ddlDuration.SelectedValue = ddlAlarm.SelectedValue = "0";//ddlRegarding.SelectedValue =
            txtRegarding.Text = txtActDate.Text = txtActTime.Text = txtLocation.Text = string.Empty; //txtEndDate.Text = txtEndTime.Text =
            //chkSms.Checked = chkEmail.Checked = chkDashBoard.Checked = false;
            //CheckBox chkheadbx = (CheckBox)gvAllocate.HeaderRow.FindControl("chkSelectAll");
            //if (chkheadbx != null)
            //    chkheadbx.Checked = false;
            //foreach (GridViewRow Gr in gvAllocate.Rows)
            //{
            //    CheckBox chkSelect = (CheckBox)Gr.FindControl("chkSelect");
            //    if (chkSelect != null)
            //        chkSelect.Checked = false;
            //} 
            ddlActTime.SelectedValue = "09:00";
            txtclrRemark.Text = txtRemark.Text = string.Empty;
            ddlAddActType.SelectedValue = "1";
            ddlAddActType_SelectedIndexChanged(null, null);
            ddlPriority.SelectedValue = "2";
            ddlclrActStatus.SelectedValue = "0";
            //}
            //else if (pnlDetails.Visible)
            //{

            //}
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.ClearpopUp.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 May 2013
    /// Description: Save Employees Photo
    /// </summary>
    public void SaveActDoc(FileUpload fpAttachmt)
    {
        try
        {
            clearMsg();
            if (fpAttachmt.HasFile)
            {
                if (!String.IsNullOrEmpty(hdfActivityDoc.Value))
                {
                    if (File.Exists(Server.MapPath(ConfigurationManager.AppSettings["ActivityDoc"]) + hdfActivityDoc.Value))
                    {
                        File.Delete(Server.MapPath(ConfigurationManager.AppSettings["ActivityDoc"]) + hdfActivityDoc.Value);
                    }
                }
                int intLastIndexOfDot = 0;
                string strFileExtension = "";
                /// check whether the browse file size is exeeds the allowed limit.
                double intBroseFileSizeInKB = fpAttachmt.PostedFile.ContentLength / 0x400;
                double dAllowFileSizeLimitInKB = Convert.ToDouble(ConfigurationManager.AppSettings["FileSize"]) * 1024;
                if (intBroseFileSizeInKB >= dAllowFileSizeLimitInKB)
                {
                    //Response.Write("<Script>alert(\"Cannot Upload File. Max size allowed is 100 Kb.\");</Script>");
                    lblSerErrMsg.Text = Resources.PFSalesResource.MaxSizeValidation.Trim();
                    dvaserSuccess.Visible = true;
                    return;
                }
                //Allowed File Extentions
                intLastIndexOfDot = fpAttachmt.FileName.LastIndexOf(".");
                strFileExtension = fpAttachmt.FileName.Substring(intLastIndexOfDot + 1, fpAttachmt.FileName.Length - intLastIndexOfDot - 1);
                //if (strFileExtension != "")
                //{
                //    bool IsTrue = false;
                //    string ext;
                //    char[] sep = { ',' };
                //    String[] strExt = Convert.ToString(ConfigurationManager.AppSettings["AllowedImgFileTypes"]).Split(sep);
                //    string fileName = fpattachment.FileName;
                //    ext = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();
                //    for (int i = 0; i < strExt.Length; i++)
                //    {
                //        if (ext == "")
                //        {
                //            IsTrue = false;
                //        }
                //        if (ext.ToLower() == strExt[i].ToLower())
                //        {
                //            IsTrue = true;
                //            break;
                //        }
                //        else
                //        {
                //            IsTrue = false;
                //        }
                //    }
                //    if (!IsTrue)
                //    {
                //        lblSerErrMsg.Text = Resources.PFSalesResource.InvalidFileExtention.Trim();
                //        dvaserSuccess.Visible = true;
                //        return;
                //    }
                //}
                string strFileName = System.IO.Path.GetFileNameWithoutExtension(fpAttachmt.PostedFile.FileName) + Guid.NewGuid() + System.IO.Path.GetExtension(fpAttachmt.PostedFile.FileName);
                fpAttachmt.PostedFile.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["ActivityDoc"]) + strFileName);
                //After u[dating show photo in image.
                hdfActivityDoc.Value = ConfigurationManager.AppSettings["ActivityDoc"] + strFileName;
                //lnkbtnRemove.Visible = true;
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.BindDesignations.SavePhoto.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 May 2013
    /// Description: Clear All Messages
    /// </summary>
    public void clearMsg()
    {
        lblSerErrMsg.Text = lblSerSucMsg.Text = string.Empty;
        dvaserSuccess.Visible = dvsererror.Visible = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 20 June 2013
    /// Description: Clear All Controls Inside Add Activity PopUp
    /// </summary>
    public void ClearAll()
    {
        try
        {
            ViewState["SelectedStatus"] = ddlAlarm.SelectedValue = ddlclrStatus.SelectedValue = ddlclrActStatus.SelectedValue = ddlProspect.SelectedValue = ddlDuration.SelectedValue = "0"; //ddlRegarding.SelectedValue = 
            txtActDate.Text = txtLocation.Text = string.Empty;//txtEndDate.Text = txtEndTime.Text =
            //chkSms.Checked = chkEmail.Checked = chkDashBoard.Checked = false;
            //chkSms.Checked = chkEmail.Checked = chkDashBoard.Checked = false;
            dtAlertType.Visible = ddAlertType.Visible = false;
            txtclrRemark.Text = txtRegarding.Text = string.Empty;
            //lnkbtnAddReg.Visible = ddlRegarding.Visible = true;
            //lnkbtnMinusReg.Visible = txtRegarding.Visible = false;
            //foreach (GridViewRow Gr in gvAllocate.Rows)
            //{
            //    CheckBox chkSelect = (CheckBox)Gr.FindControl("chkSelect");
            //    if (chkSelect != null)
            //        chkSelect.Checked = false;
            //}
            txtRemark.Text = string.Empty;
            ddlAddActType.SelectedValue = "1";
            ddlAddActType_SelectedIndexChanged(null, null);
            ddlPriority.SelectedValue = "2";
            ddlAlarm_SelectedIndexChanged(null, null);
            BindConsultants();
            ddlActTime.SelectedValue = txtActTime.Text = "09:00";

            //CheckBox chkheadbx = (CheckBox)gvAllocate.HeaderRow.FindControl("chkSelectAll");
            //if (chkheadbx != null)
            //    chkheadbx.Checked = false;

        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.ClearpopUp.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 4 July 2013
    /// Description: Download Files
    /// </summary>
    /// <param name="FileName"></param>
    public void DownloadFile(string FileName)
    {
        if (File.Exists(Server.MapPath(FileName)))
        {
            FileInfo fi = new FileInfo(Server.MapPath(FileName));
            long sz = fi.Length;
            Response.ClearContent();
            Response.ContentType = MimeType(Path.GetExtension(Server.MapPath(FileName)));
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(Server.MapPath(FileName)).Replace(" ", "%20")));
            Response.AddHeader("Content-Length", sz.ToString("F0"));
            Response.TransmitFile(Server.MapPath(FileName));
            Response.End();
            // HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 5 July 2013
    /// Description: Show Old Activity Details 
    /// </summary>
    public void EditData()
    {
        try
        {
            DataTable Dt = objActivityBM.GetActivityDetFromId(Convert.ToInt64(hdfActivityId.Value.Trim()), BasePage.UserSession.VirtualRoleId);
            if (Dt != null && Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0]["ProspectId"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["ProspectId"].ToString().Trim()))
                {
                    BindProspects();
                    ddlProspect.SelectedValue = Dt.Rows[0]["ProspectId"].ToString().Trim();
                    hdfProspectId.Value = Dt.Rows[0]["ProspectId"].ToString().Trim();
                }
                ddlAddActType.SelectedValue = Dt.Rows[0]["ActivityTypeId"].ToString().Trim();
                BindActStatuses();
                if (Dt.Rows[0]["NotesStatus"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["NotesStatus"].ToString().Trim()))
                {
                    ViewState["SelectedStatus"] = ddlclrActStatus.SelectedValue = Dt.Rows[0]["NotesStatus"].ToString().Trim();
                    BindAllStatuses();
                }
                if (BasePage.UserSession.RoleId == 5)
                    ViewState["ContactStatus"] = ddlclrStatus.SelectedValue = Dt.Rows[0]["FCStatusId"].ToString().Trim();
                else
                    ViewState["ContactStatus"] = ddlclrStatus.SelectedValue = Dt.Rows[0]["ContactStatus"].ToString().Trim();
                txtclrRemark.Text = Dt.Rows[0]["Notes"].ToString().Trim();
                ddlAddActType_SelectedIndexChanged(null, null);
                //ddlRegarding.SelectedValue = Dt.Rows[0]["RegId"].ToString().Trim();
                txtRegarding.Text = Dt.Rows[0]["name"].ToString().Trim();
                ddlPriority.SelectedValue = Dt.Rows[0]["ActivityPriorityId"].ToString().Trim();
                txtActDate.Text = Convert.ToDateTime(Dt.Rows[0]["start"].ToString().Trim()).ToString("dd/MM/yyyy").Substring(0, 10);
                //txtActTime.Text = Convert.ToDateTime(Dt.Rows[0]["start"].ToString().Trim()).ToString("HH:mm:ss").Substring(0, 5);
                ddlActTime.SelectedValue = Convert.ToDateTime(Dt.Rows[0]["start"].ToString().Trim()).ToString("HH:mm:ss").Substring(0, 5);
                hdfOldActStartTime.Value = Dt.Rows[0]["start"].ToString().Trim();
                //txtEndDate.Text = Convert.ToDateTime(Dt.Rows[0]["end"].ToString().Trim()).ToString("g").Substring(0, 10);
                //txtEndTime.Text = Dt.Rows[0]["end"].ToString().Trim().Substring(11, 5);
                txtLocation.Text = Dt.Rows[0]["Location"].ToString().Trim();
                hdfActivityDocId.Value = Dt.Rows[0]["DocId"].ToString().Trim();
                hdfActivityDoc.Value = Dt.Rows[0]["Filepath"].ToString().Trim();
                hdfContactNotesId.Value = Dt.Rows[0]["CNId"].ToString().Trim();
                //if (!string.IsNullOrEmpty(Dt.Rows[0]["Filepath"].ToString().Trim()))
                //{
                //    fpattachment.Enabled = false;
                //    lnkbtnDownload.CommandArgument = lnkbtnRemove.CommandArgument = Dt.Rows[0]["Filepath"].ToString().Trim();
                //    lnkbtnRemove.Visible = lnkbtnDownload.Visible = true;
                //}
                //else
                //{
                //    fpattachment.Enabled = true;
                //    lnkbtnDownload.CommandArgument = lnkbtnRemove.CommandArgument = string.Empty;
                //    lnkbtnRemove.Visible = lnkbtnDownload.Visible = false;
                //}
                txtRemark.Text = Dt.Rows[0]["Remark"].ToString().Trim();
                if (Dt.Rows[0]["AlertValueBefore"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["AlertValueBefore"].ToString().Trim()))
                    ddlAlarm.SelectedValue = Dt.Rows[0]["AlertValueBefore"].ToString().Trim();
                ddlAlarm_SelectedIndexChanged(null, null);
                BindConsultants();
                DataTable dtAlertDet = objActivityBM.GetActivityAlertDetailsFromId(Convert.ToInt64(hdfActivityId.Value.Trim()), BasePage.UserSession.VirtualRoleId);
                //if (dtAlertDet != null && dtAlertDet.Rows.Count > 0)
                //{
                //foreach (GridViewRow Gr in gvAllocate.Rows)
                //{
                //HiddenField hdfConsultantId = (HiddenField)Gr.FindControl("hdfConsultantId");
                //CheckBox chkSelect = (CheckBox)Gr.FindControl("chkSelect");
                //for (int i = 0; i < dtAlertDet.Rows.Count; i++)
                //{
                //if (hdfConsultantId != null && chkSelect != null)
                //{
                //    if (hdfConsultantId.Value.Trim() == dtAlertDet.Rows[i]["AlertForId"].ToString().Trim() && Convert.ToBoolean(dtAlertDet.Rows[i]["IsDeleted"].ToString().Trim()) == false)
                //    {
                //        chkSelect.Checked = true;
                //    }
                //}
                //if (dtAlertDet.Rows[i]["AlertTypeId"].ToString().Trim() == Cls_Constant.DashBoardAlert.ToString().Trim())
                //    chkDashBoard.Checked = true;
                //if (dtAlertDet.Rows[i]["AlertTypeId"].ToString().Trim() == Cls_Constant.MailAlert.ToString().Trim())
                //    chkEmail.Checked = true;
                //if (dtAlertDet.Rows[i]["AlertTypeId"].ToString().Trim() == Cls_Constant.SMSAlert.ToString().Trim())
                //    chkSms.Checked = true;
                // }
                //}
                //}
                if (Convert.ToInt64(ddlProspect.SelectedValue.Trim()) > 0)
                    ddlProspect_SelectedIndexChanged(null, null);
                GetMinStartDate();
            }
            else if (!string.IsNullOrEmpty(hdfContactNotesId.Value.Trim()) && Convert.ToInt64(hdfContactNotesId.Value.Trim()) > 0)
            {
                Dt = objActivityBM.GetContactNotesFromId(Convert.ToInt64(hdfContactNotesId.Value.Trim()));
                if (Dt.Rows[0]["ContactId"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["ContactId"].ToString().Trim()))
                {
                    BindProspects();
                    ddlProspect.SelectedValue = Dt.Rows[0]["ContactId"].ToString().Trim();
                    hdfProspectId.Value = Dt.Rows[0]["ContactId"].ToString().Trim();
                }
                ViewState["ContactStatus"] = ddlclrStatus.SelectedValue = Dt.Rows[0]["ContactStatus"].ToString().Trim();
                txtclrRemark.Text = Dt.Rows[0]["Notes"].ToString().Trim();
                if (Dt.Rows[0]["NotesStatus"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["NotesStatus"].ToString().Trim()))
                {
                    ViewState["SelectedStatus"] = ddlclrActStatus.SelectedValue = Dt.Rows[0]["NotesStatus"].ToString().Trim();
                    BindAllStatuses();
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.EditData.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 4 July 2013
    /// Description: Get Mime Type
    /// </summary>
    /// <param name="Extension"></param>
    /// <returns></returns>
    public static string MimeType(string Extension)
    {
        string mime = "application/octetstream";
        if (string.IsNullOrEmpty(Extension))
            return mime;

        string ext = Extension.ToLower();
        Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
        if (rk != null && rk.GetValue("Content Type") != null)
            mime = rk.GetValue("Content Type").ToString();
        return mime;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 May 2013
    /// Description: Bind Grid View Data
    /// </summary>
    public void BindProspects()
    {
        try
        {
            Int64 ProspId = 0;
            if (hdfProspectId != null && !string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
                ProspId = Convert.ToInt64(hdfActivityId.Value.Trim());

            objProsp.FName = string.Empty;
            objProsp.PageIndex = 1;
            objProsp.PageSize = 0;
            objProsp.StatusId = 0;
            DataSet Ds = objProspBM.GetAllProspects(objProsp);
            if (Ds != null && Ds.Tables.Count > 0)
            {
                DataTable Dt = Ds.Tables[0];
                if (Dt != null && Dt.Rows.Count > 0)
                {
                    DataView Dv = Dt.DefaultView;
                    if (BasePage.UserSession.RoleId == 3)
                    {
                        Dv.RowFilter = "ConsultantId=" + BasePage.UserSession.VirtualRoleId.ToString().Trim();
                        DataTable Dttemp = Dv.ToTable();
                    }
                    Cls_BinderHelper.BindDropdownList(ddlProspect, "Name", "Id", Dt);
                    if (ProspId > 0)
                    {
                        ddlProspect.SelectedValue = hdfProspectId.Value.Trim();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.BindProspects.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 16 July 2013
    /// Description: Bind Managed Activity Data of Parrent Page
    /// </summary>
    public void BindMangeData()
    {
        try
        {
            MethodInfo methods1 = (this.Parent.Parent.Page).GetType().GetMethod("BindMangeActivity");// ((Page)this.Parent).GetType().GetMethod("BindMangeActivity");
            if (methods1 != null)
            {
                object[] objParam = new object[] { Convert.ToInt64(hdfProspectId.Value.Trim()) };
                methods1.Invoke((this.Parent.Parent.Page), objParam);
            }
            UserControl ucDetails = (UserControl)(this.Parent).FindControl("UC_ProspectDetails1");
            if (ucDetails != null)
            {
                MethodInfo methods2 = (ucDetails).GetType().GetMethod("BidData");// ((Page)this.Parent).GetType().GetMethod("BindMangeActivity");
                if (methods2 != null)
                {
                    object[] objParam = new object[] { Convert.ToInt64(hdfProspectId.Value.Trim()) };
                    methods2.Invoke((ucDetails), objParam);
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.BindMangeData.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 July 2013
    /// Description: Get Activity Statuses
    /// </summary>
    /// <param name="ProsessId"></param>
    public void BindActStatuses()
    {
        try
        {
            DataTable Dt;
            if (BasePage.UserSession.RoleId == 5)
                Dt = objMstBM.GetAllStatus(6, 2);// Hard Coded Entity Id for FC Consultants & Process Id
            else
                Dt = objMstBM.GetAllStatus(2, 2);// Hard Coded Entity Id & Process Id
            Cls_BinderHelper.BindDropdownList(ddlclrActStatus, "Status", "Id", Dt);
            if (ViewState["SelectedStatus"] != null && !string.IsNullOrEmpty(ViewState["SelectedStatus"].ToString().Trim()) && Convert.ToInt32(ViewState["SelectedStatus"].ToString().Trim()) > 0)
                ddlclrActStatus.SelectedValue = ViewState["SelectedStatus"].ToString().Trim();
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.BindActStatuses.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 Aug 2013
    /// Description: Get Minimum StartDate For A Prospect
    /// </summary>
    public void GetMinStartDate()
    {
        try
        {
            Int64 ProspId = 0;
            if (hdfProspectId != null && !string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
                ProspId = Convert.ToInt64(hdfProspectId.Value.Trim());

            DataTable Dt = objActivityBM.GetMinDateForFutureAct(ProspId, BasePage.UserSession.VirtualRoleId);
            if (Dt != null && Dt.Rows.Count > 0)
            {
                hdfMinSDate.Value = Dt.Rows[0]["MinDate"].ToString().Trim();
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.GetMinStartDate.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 Aug 2013
    /// Description: Custom Validation For Minimum Start Date For Activity
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cvSdateTime_Validate(object sender, ServerValidateEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtActDate.Text) && !string.IsNullOrEmpty(hdfMinSDate.Value) && ddlActTime.SelectedValue != "0")
            {
                DateTime dt = Convert.ToDateTime(txtActDate.Text.Trim() + " " + ddlActTime.SelectedValue.Trim());
                DateTime Dt1 = Convert.ToDateTime(hdfMinSDate.Value.Trim());
                if (dt > Dt1)
                    e.IsValid = true;
                else
                    e.IsValid = false;
            }
            else
                e.IsValid = true;
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.cvSdateTime_Validate.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 Aug 2013
    /// Description: Get All Statuses
    /// </summary>
    private void BindAllStatuses()
    {
        try
        {
            DataTable Dt;
            if (BasePage.UserSession.RoleId == 5)
                Dt = objMstBM.GetAllStatus(6, 1);// Hard Coded Entity Id for FC Consultants & Process Id
            else if (BasePage.UserSession.RoleId == 3)
                Dt = objMstBM.GetAllStatus(1, 1);// Hard Coded Entity Id & Process Id
            else if (BasePage.UserSession.RoleId == 1)
            {
                if (Session["ForW"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["ForW"]).Trim()))
                {
                    if (Convert.ToString(Session["ForW"]).Trim().ToUpper() == "W")
                        Dt = objMstBM.GetAllStatus(1, 1);
                    else if (Convert.ToString(Session["ForW"]).Trim().ToUpper() == "F")
                        Dt = objMstBM.GetAllStatus(6, 1);
                    else
                        Dt = objMstBM.GetAllStatus(1, 1);
                }
                else
                    Dt = objMstBM.GetAllStatus(1, 1);
            }
            else
                Dt = objMstBM.GetAllStatus(1, 1);

            Cls_BinderHelper.BindDropdownList(ddlclrStatus, "Status", "Id", Dt);
            if (ViewState["ContactStatus"] != null && !string.IsNullOrEmpty(ViewState["ContactStatus"].ToString().Trim()) && Convert.ToInt32(ViewState["ContactStatus"].ToString().Trim()) > 0)
                ddlclrStatus.SelectedValue = ViewState["ContactStatus"].ToString().Trim();
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "SearchProspect.BindAllStatuses.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 Aug 2013
    /// Description: Bind Act Status Id
    /// </summary>
    /// <param name="ProspId"></param>
    public void BidData(Int64 ProspId)
    {
        try
        {
            if (ProspId > 0)
            {
                DataTable dt = objProspBM.GetProspDetAssignedToConsult(0, DateTime.MinValue, DateTime.MaxValue, ProspId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (BasePage.UserSession.RoleId == 5)
                        ViewState["ContactStatus"] = ddlclrStatus.SelectedValue = Convert.ToString(dt.Rows[0]["FCStatusId"]).Trim();
                    else
                        ViewState["ContactStatus"] = ddlclrStatus.SelectedValue = Convert.ToString(dt.Rows[0]["StatusId"]).Trim();

                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["FConsultant"]).Trim()))
                        ViewState["FConsultant"] = ddlclrStatus.SelectedValue = Convert.ToString(dt.Rows[0]["FConsultant"]).Trim();
                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["FConsultEmail"]).Trim()))
                        ViewState["FConsultEmail"] = ddlclrStatus.SelectedValue = Convert.ToString(dt.Rows[0]["FConsultEmail"]).Trim();
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_ProspectDetails.BidData.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 Aug 2013
    /// Description: Save Acttvity & Notes
    /// </summary>
    private void SaveActiNotes()
    {
        StringBuilder strIds = new StringBuilder();
        objActivity.Id = 0;
        objActivity.ParrentActId = 0;
        objActivity.ActivityTypeId = Convert.ToInt16(ddlAddActType.SelectedValue.Trim());
        objActivity.Regarding = ddlAddActType.SelectedItem.Text.Trim() + " : to " + lblAddActProspect.Text.Trim();//txtRegarding.Text.Trim();
        objActivity.Regardings = ddlAddActType.SelectedItem.Text.Trim() + " : to " + lblAddActProspect.Text.Trim();//txtRegarding.Text.Trim();
        //objActivity.PriorityId = Convert.ToInt16(ddlPriority.SelectedValue.Trim());
        if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
            objActivity.ProspectId = Convert.ToInt64(hdfProspectId.Value.Trim());
        else
            objActivity.ProspectId = 0;
        if (!string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlActTime.SelectedValue.Trim() != "0")//!string.IsNullOrEmpty(txtActTime.Text.Trim())
        {
            objActivity.ActStartTime = Convert.ToDateTime(txtActDate.Text.Trim() + " " + ddlActTime.SelectedValue.Trim());//txtActTime.Text.Trim()
            GetCountOfActForStime(objActivity.ActStartTime, Interval1);
            DateTime dt;
            if (ViewState["NewStartDate"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["NewStartDate"]).Trim()))
                dt = objActivity.ActStartTime = Convert.ToDateTime(Convert.ToString(ViewState["NewStartDate"]).Trim());
            else
                dt = Convert.ToDateTime(txtActDate.Text.Trim() + " " + ddlActTime.SelectedValue.Trim());//txtActTime.Text.Trim()
            objActivity.ActEndTime = dt.AddMinutes(2);//Convert.ToDateTime(txtEndDate.Text.Trim() + " " + txtEndTime.Text.Trim());
        }
        objActivity.IsTimeLess = false;
        objActivity.IsPrivate = false;
        objActivity.Status = Convert.ToInt32(ddlActStatus.SelectedValue.Trim());
        objActivity.Duration = Convert.ToInt32(ddlDuration.SelectedValue.Trim());
        objActivity.ActivityDocId = 0;
        objActivity.ActivityDocRemark = txtRemark.Text.Trim();
        objActivity.ActivityDocFilePath = hdfActivityDoc.Value.Trim();
        objActivity.Location = txtLocation.Text.Trim();
        List<ActResources> lstResources = new List<ActResources>();
        List<ActAlertDetails> lstActAlerts = new List<ActAlertDetails>();
        ActResources objActResource = new ActResources();
        objActResource.ResourceId = BasePage.UserSession.VirtualRoleId;
        lstResources.Add(objActResource);
        if (ddlPriority.SelectedValue.Trim() == "0")
        {
            objActivity.PriorityId = 1;//Hard Code For High Convert.ToInt16(ddlPriority.SelectedValue.Trim());
            if (chkSms.Checked)
            {
                string[] array = strIds.ToString().TrimEnd(',').Split(',');
                if (array.Length > 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        ActAlertDetails objActAlertDetails = new ActAlertDetails();
                        objActAlertDetails.AlertTypeId = Cls_Constant.SMSAlert;// Hard Coded For SMS
                        if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                            objActAlertDetails.AlertValueBefore = 0;
                        else
                            objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                        objActAlertDetails.SnoozValue = 0;
                        objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
                        lstActAlerts.Add(objActAlertDetails);
                    }
                }
            }
            if (chkEmail.Checked)
            {
                string[] array = strIds.ToString().TrimEnd(',').Split(',');
                if (array.Length > 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        ActAlertDetails objActAlertDetails = new ActAlertDetails();
                        objActAlertDetails.AlertTypeId = Cls_Constant.MailAlert;// Hard Coded For Email
                        if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                            objActAlertDetails.AlertValueBefore = 0;
                        else
                            objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                        objActAlertDetails.SnoozValue = 0;
                        objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// //array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
                        lstActAlerts.Add(objActAlertDetails);
                    }
                }
            }
            if (chkDashBoard.Checked)
            {
                string[] array = strIds.ToString().TrimEnd(',').Split(',');
                if (array.Length > 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        ActAlertDetails objActAlertDetails = new ActAlertDetails();
                        objActAlertDetails.AlertTypeId = Cls_Constant.DashBoardAlert;// Hard Coded For Dashboard Alert
                        if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                            objActAlertDetails.AlertValueBefore = 0;
                        else
                            objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                        objActAlertDetails.SnoozValue = 0;
                        objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();//array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
                        lstActAlerts.Add(objActAlertDetails);
                    }
                }
            }
        }
        else
            objActivity.PriorityId = 2;//Hard Code For Modrate Convert.ToInt16(ddlPriority.SelectedValue.Trim());
        objActivity.LstAlertDetails = lstActAlerts;
        objActivity.LstReources = lstResources;
        objActivity.CreatedById = BasePage.UserSession.VirtualRoleId;
        objActivity.IsDeleted = false;
        Int64 Result = 0;
        Result = objActivityBM.AddActivity(objActivity);
        if (Result > 0)
        {
            Result = objActivityBM.AddContactNotes(objActivity.ProspectId, "Changed to " + ddlclrActStatus.SelectedItem.Text.Trim() + " :" + txtclrRemark.Text.Trim(), BasePage.UserSession.VirtualRoleId, false, Convert.ToInt32(ddlclrActStatus.SelectedValue.Trim()), Result, Convert.ToInt32(ddlclrStatus.SelectedValue.Trim()));
            if (Result > 0)
            {
                lblSerSucMsg.Text = Resources.PFSalesResource.ActivityAddedSuccessfully.Trim();
                dvaserSuccess.Visible = true;
                lblSerErrMsg.Text = string.Empty;
                dvsererror.Visible = false;
                hdfActivityDoc.Value = string.Empty;
            }
            else
            {
                lblSerErrMsg.Text = Resources.PFSalesResource.NotesNotAdded.Trim();
                dvaserSuccess.Visible = false;
                lblSerSucMsg.Text = string.Empty;
                dvsererror.Visible = true;
            }
        }
        else if (Result == -5)
        {
            lblSerErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
            dvsererror.Visible = true;
        }
        else
        {
            lblSerErrMsg.Text = Resources.PFSalesResource.ActivityNotAdded.Trim();
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
            dvsererror.Visible = true;
        }
        pnlGeneral.Visible = true;
        pnlDetails.Visible = false;
        lnkbtnGeneralInfo.CssClass = "tablerBtnActive";
        lnkbtnDetailsInfo.CssClass = "";
        BindMangeData();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 Aug 2013
    /// Description: Save Acttvity Only
    /// </summary>
    private Int64 SaveOnlyActivity()
    {
        StringBuilder strIds = new StringBuilder();
        objActivity.Id = 0;
        objActivity.ParrentActId = 0;
        objActivity.ActivityTypeId = Convert.ToInt16(ddlAddActType.SelectedValue.Trim());
        objActivity.Regarding = ddlAddActType.SelectedItem.Text.Trim() + " : to " + lblAddActProspect.Text.Trim();//txtRegarding.Text.Trim();
        objActivity.Regardings = ddlAddActType.SelectedItem.Text.Trim() + " : to " + lblAddActProspect.Text.Trim();//txtRegarding.Text.Trim();
        //objActivity.PriorityId = Convert.ToInt16(ddlPriority.SelectedValue.Trim());
        if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
            objActivity.ProspectId = Convert.ToInt64(hdfProspectId.Value.Trim());
        else
            objActivity.ProspectId = 0;
        if (!string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlActTime.SelectedValue.Trim() != "0")//!string.IsNullOrEmpty(txtActTime.Text.Trim())
        {
            objActivity.ActStartTime = Convert.ToDateTime(txtActDate.Text.Trim() + " " + ddlActTime.SelectedValue.Trim());//txtActTime.Text.Trim()
            GetCountOfActForStime(objActivity.ActStartTime, Interval1);
            DateTime dt;
            if (ViewState["NewStartDate"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["NewStartDate"]).Trim()))
                dt = objActivity.ActStartTime = Convert.ToDateTime(Convert.ToString(ViewState["NewStartDate"]).Trim());
            else
                dt = Convert.ToDateTime(txtActDate.Text.Trim() + " " + ddlActTime.SelectedValue.Trim());//txtActTime.Text.Trim()
            objActivity.ActEndTime = dt.AddMinutes(2);//Convert.ToDateTime(txtEndDate.Text.Trim() + " " + txtEndTime.Text.Trim());
        }
        objActivity.IsTimeLess = false;
        objActivity.IsPrivate = false;
        objActivity.Status = Convert.ToInt32(ddlActStatus.SelectedValue.Trim());
        objActivity.Duration = Convert.ToInt32(ddlDuration.SelectedValue.Trim());
        objActivity.ActivityDocId = 0;
        objActivity.ActivityDocRemark = txtRemark.Text.Trim();
        objActivity.ActivityDocFilePath = hdfActivityDoc.Value.Trim();
        objActivity.Location = txtLocation.Text.Trim();
        List<ActResources> lstResources = new List<ActResources>();
        List<ActAlertDetails> lstActAlerts = new List<ActAlertDetails>();
        ActResources objActResource = new ActResources();
        objActResource.ResourceId = BasePage.UserSession.VirtualRoleId;
        lstResources.Add(objActResource);
        if (ddlAlarm.SelectedValue.Trim() != "0")
        {
            objActivity.PriorityId = 1;//Hard Code For High Convert.ToInt16(ddlPriority.SelectedValue.Trim());
            if (chkSms.Checked)
            {
                string[] array = strIds.ToString().TrimEnd(',').Split(',');
                if (array.Length > 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        ActAlertDetails objActAlertDetails = new ActAlertDetails();
                        objActAlertDetails.AlertTypeId = Cls_Constant.SMSAlert;// Hard Coded For SMS
                        if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                            objActAlertDetails.AlertValueBefore = 0;
                        else
                            objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                        objActAlertDetails.SnoozValue = 0;
                        objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
                        lstActAlerts.Add(objActAlertDetails);
                    }
                }
            }
            if (chkEmail.Checked)
            {
                string[] array = strIds.ToString().TrimEnd(',').Split(',');
                if (array.Length > 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        ActAlertDetails objActAlertDetails = new ActAlertDetails();
                        objActAlertDetails.AlertTypeId = Cls_Constant.MailAlert;// Hard Coded For Email
                        if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                            objActAlertDetails.AlertValueBefore = 0;
                        else
                            objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                        objActAlertDetails.SnoozValue = 0;
                        objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// //array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
                        lstActAlerts.Add(objActAlertDetails);
                    }
                }
            }
            if (chkDashBoard.Checked)
            {
                string[] array = strIds.ToString().TrimEnd(',').Split(',');
                if (array.Length > 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        ActAlertDetails objActAlertDetails = new ActAlertDetails();
                        objActAlertDetails.AlertTypeId = Cls_Constant.DashBoardAlert;// Hard Coded For Dashboard Alert
                        if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                            objActAlertDetails.AlertValueBefore = 0;
                        else
                            objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                        objActAlertDetails.SnoozValue = 0;
                        objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();//array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
                        lstActAlerts.Add(objActAlertDetails);
                    }
                }
            }
        }
        else
            objActivity.PriorityId = 2;//Hard Code For Moderate Convert.ToInt16(ddlPriority.SelectedValue.Trim());
        objActivity.LstAlertDetails = lstActAlerts;
        objActivity.LstReources = lstResources;
        objActivity.CreatedById = BasePage.UserSession.VirtualRoleId;
        objActivity.IsDeleted = false;
        Int64 Result = 0;
        Result = objActivityBM.AddActivity(objActivity);
        if (Result > 0)
        {
            lblSerSucMsg.Text = Resources.PFSalesResource.ActivityAddedSuccessfully.Trim();
            dvaserSuccess.Visible = true;
            lblSerErrMsg.Text = string.Empty;
            dvsererror.Visible = false;
            hdfActivityDoc.Value = string.Empty;
        }
        else if (Result == -5)
        {
            lblSerErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
            dvsererror.Visible = true;
        }
        else
        {
            lblSerErrMsg.Text = Resources.PFSalesResource.ActivityNotAdded.Trim();
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
            dvsererror.Visible = true;
        }
        pnlGeneral.Visible = true;
        pnlDetails.Visible = false;
        lnkbtnGeneralInfo.CssClass = "tablerBtnActive";
        lnkbtnDetailsInfo.CssClass = "";
        BindMangeData();
        return Result;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 Aug 2013
    /// Description: Save Notes Only
    /// </summary>
    private Int64 SaveOnlyNotes()
    {
        if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
            objActivity.ProspectId = Convert.ToInt64(hdfProspectId.Value.Trim());
        Int64 Result = objActivityBM.AddContactNotes(objActivity.ProspectId, "Changed to " + ddlclrActStatus.SelectedItem.Text.Trim() + " :" + txtclrRemark.Text.Trim(), BasePage.UserSession.VirtualRoleId, false, Convert.ToInt32(ddlclrActStatus.SelectedValue.Trim()), 0, Convert.ToInt32(ddlclrStatus.SelectedValue.Trim()));
        if (Result > 0)
        {
            lblSerSucMsg.Text = Resources.PFSalesResource.NotesAdded.Trim();
            dvaserSuccess.Visible = true;
            lblSerErrMsg.Text = string.Empty;
            dvsererror.Visible = false;
            hdfActivityDoc.Value = string.Empty;
        }
        else
        {
            lblSerErrMsg.Text = Resources.PFSalesResource.NotesNotAdded.Trim();
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
            dvsererror.Visible = true;
        }
        BindMangeData();
        return Result;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 12 Aug 2013
    /// Description: Update Acttvity & Notes
    /// </summary>
    private void UpdateActiNotes()
    {
        //if (!string.IsNullOrEmpty(hdfActivityId.Value.Trim()) && !string.IsNullOrEmpty(hdfActivityDocId.Value.Trim()))
        //{
        Int64 Result = 0;
        if (!string.IsNullOrEmpty(hdfActivityId.Value.Trim()) && Convert.ToInt64(hdfActivityId.Value.Trim()) > 0)
        {
            StringBuilder strIds = new StringBuilder();
            objActivity.Id = Convert.ToInt64(hdfActivityId.Value.Trim());
            objActivity.ParrentActId = 0;
            objActivity.ActivityTypeId = Convert.ToInt16(ddlAddActType.SelectedValue.Trim());
            objActivity.Regarding = ddlAddActType.SelectedItem.Text.Trim() + " : to " + lblAddActProspect.Text.Trim();//txtRegarding.Text.Trim();
            //objActivity.PriorityId = Convert.ToInt16(ddlPriority.SelectedValue.Trim());
            if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
                objActivity.ProspectId = Convert.ToInt64(hdfProspectId.Value.Trim());
            else
                objActivity.ProspectId = 0;
            if (!string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlActTime.SelectedValue.Trim() != "0") //!string.IsNullOrEmpty(txtActTime.Text.Trim())
            {
                objActivity.ActStartTime = Convert.ToDateTime(txtActDate.Text.Trim() + " " + ddlActTime.SelectedValue.Trim());//txtActTime.Text.Trim()
                GetCountOfActForStime(objActivity.ActStartTime, Interval1);
                DateTime dt;
                if (ViewState["NewStartDate"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["NewStartDate"]).Trim()))
                    dt = objActivity.ActStartTime = Convert.ToDateTime(Convert.ToString(ViewState["NewStartDate"]).Trim());
                else
                    dt = Convert.ToDateTime(txtActDate.Text.Trim() + " " + ddlActTime.SelectedValue.Trim());//txtActTime.Text.Trim()
                objActivity.ActEndTime = dt.AddMinutes(2);
            }
            objActivity.IsTimeLess = false;
            objActivity.IsPrivate = false;
            objActivity.Status = Convert.ToInt32(ddlActStatus.SelectedValue.Trim());
            objActivity.Duration = Convert.ToInt32(ddlDuration.SelectedValue.Trim());
            objActivity.ActivityDocId = Convert.ToInt64(hdfActivityDocId.Value.Trim());
            objActivity.ActivityDocRemark = txtRemark.Text.Trim();
            objActivity.ActivityDocFilePath = hdfActivityDoc.Value.Trim();
            objActivity.Location = txtLocation.Text.Trim();
            List<ActResources> lstResources = new List<ActResources>();
            List<ActAlertDetails> lstActAlerts = new List<ActAlertDetails>();
            ActResources objActResource = new ActResources();
            objActResource.ResourceId = BasePage.UserSession.VirtualRoleId;//Convert.ToInt64(hdfConsultantId.Value.Trim());
            objActResource.ActResourceId = Convert.ToInt64(hdfActResId.Value.Trim());
            objActResource.IsDeleted = false;
            if (Convert.ToInt64(hdfActResId.Value.Trim()) > 0)//!chkSelect.Checked && Convert.ToInt64(hdfConsultantId.Value.Trim()) > 0 && (
            {
                objActResource.IsDeleted = true;
            }
            lstResources.Add(objActResource);

            if (ddlAlarm.SelectedValue.Trim() != "0")
            {
                objActivity.PriorityId = 1;//Hard Code For High Priority Convert.ToInt16(ddlPriority.SelectedValue.Trim());
                if (chkSms.Checked)
                {
                    ActAlertDetails objActAlertDetails = new ActAlertDetails();
                    if (Convert.ToInt64(hdfActSMSAlertId.Value.Trim()) > 0)
                    {
                        objActAlertDetails.IsDeleted = true;
                    }
                    else
                        objActAlertDetails.IsDeleted = false;
                    objActAlertDetails.ActAlertId = Convert.ToInt64(hdfActSMSAlertId.Value.Trim());
                    objActAlertDetails.AlertTypeId = Cls_Constant.SMSAlert;// Hard Coded For SMS
                    if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                        objActAlertDetails.AlertValueBefore = 0;
                    else
                        objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                    objActAlertDetails.SnoozValue = 0;
                    objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// hdfConsultantId.Value.Trim(); //strIds.ToString().TrimEnd(',');
                    lstActAlerts.Add(objActAlertDetails);
                }
                if (chkEmail.Checked)
                {
                    ActAlertDetails objActAlertDetails = new ActAlertDetails();
                    if (Convert.ToInt64(hdfActMailAlertId.Value.Trim()) > 0)//!chkSelect.Checked && Convert.ToInt64(hdfConsultantId.Value.Trim()) > 0 && 
                    {
                        objActAlertDetails.IsDeleted = true;
                    }
                    else
                        objActAlertDetails.IsDeleted = false;
                    objActAlertDetails.ActAlertId = Convert.ToInt64(hdfActMailAlertId.Value.Trim());
                    objActAlertDetails.AlertTypeId = Cls_Constant.MailAlert;// Hard Coded For Email
                    if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                        objActAlertDetails.AlertValueBefore = 0;
                    else
                        objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                    objActAlertDetails.SnoozValue = 0;
                    objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();//hdfConsultantId.Value.Trim(); //strIds.ToString().TrimEnd(',');
                    lstActAlerts.Add(objActAlertDetails);
                }
                if (chkDashBoard.Checked)
                {
                    ActAlertDetails objActAlertDetails = new ActAlertDetails();
                    if (Convert.ToInt64(hdfActDashAlertId.Value.Trim()) > 0)
                    {
                        objActAlertDetails.IsDeleted = true;
                    }
                    else
                        objActAlertDetails.IsDeleted = false;
                    objActAlertDetails.ActAlertId = Convert.ToInt64(hdfActDashAlertId.Value.Trim());
                    objActAlertDetails.AlertTypeId = Cls_Constant.DashBoardAlert;// Hard Coded For Dashboard Alert
                    if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                        objActAlertDetails.AlertValueBefore = 0;
                    else
                        objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                    objActAlertDetails.SnoozValue = 0;
                    objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();//hdfConsultantId.Value.Trim(); //strIds.ToString().TrimEnd(',');
                    lstActAlerts.Add(objActAlertDetails);
                }
            }
            else
                objActivity.PriorityId = 2;//Hard Code For Moderate Convert.ToInt16(ddlPriority.SelectedValue.Trim());
            objActivity.LstAlertDetails = lstActAlerts;
            objActivity.LstReources = lstResources;
            objActivity.CreatedById = BasePage.UserSession.VirtualRoleId;
            objActivity.IsDeleted = false;
            Result = objActivityBM.UpdateActivity(objActivity);
        }
        else
        {
            Result = SaveOnlyActivity();
        }
        if (Result > 0)
        {
            if (!string.IsNullOrEmpty(hdfContactNotesId.Value.Trim()) && Convert.ToInt64(hdfContactNotesId.Value.Trim()) > 0)
                Result = objActivityBM.UpdateContactNotes(Convert.ToInt64(hdfContactNotesId.Value.Trim()), objActivity.ProspectId, "Changed to" + ddlActStatus.SelectedValue.Trim() + ":" + txtclrRemark.Text.Trim(), BasePage.UserSession.VirtualRoleId, false, Convert.ToInt32(ddlclrActStatus.SelectedValue.Trim()), Convert.ToInt64(hdfActivityId.Value.Trim()), Convert.ToInt32(ddlclrStatus.SelectedValue.Trim()));
            else
                Result = SaveOnlyNotes();
            lblSerSucMsg.Text = Resources.PFSalesResource.ActivityUpdated.Trim();
            dvaserSuccess.Visible = true;
            lblSerErrMsg.Text = string.Empty;
            dvsererror.Visible = false;
            hdfActivityDoc.Value = string.Empty;
            lnkbtnUpdate.Visible = false;
            lnkbtnSaveAct.Visible = true;
            lblAddActivity.Text = Resources.PFSalesResource.AddNewActivity.Trim();
        }
        else if (Result == -5)
        {
            lblSerErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
            dvsererror.Visible = true;
        }
        else
        {
            lblSerErrMsg.Text = Resources.PFSalesResource.ActivityNotUpdated.Trim();
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
            dvsererror.Visible = true;
        }
        //}
        BindMangeData();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 12 Aug 2013
    /// Description: Update only Acttvity
    /// </summary>
    private void UpdateOnlyActivity()
    {
        if (!string.IsNullOrEmpty(hdfActivityId.Value.Trim()) && !string.IsNullOrEmpty(hdfActivityDocId.Value.Trim()))
        {
            StringBuilder strIds = new StringBuilder();
            objActivity.Id = Convert.ToInt64(hdfActivityId.Value.Trim());
            objActivity.ParrentActId = 0;
            objActivity.ActivityTypeId = Convert.ToInt16(ddlAddActType.SelectedValue.Trim());
            objActivity.Regarding = ddlAddActType.SelectedItem.Text.Trim() + " : to " + lblAddActProspect.Text.Trim();//txtRegarding.Text.Trim();

            if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
                objActivity.ProspectId = Convert.ToInt64(hdfProspectId.Value.Trim());
            else
                objActivity.ProspectId = 0;
            if (!string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlActTime.SelectedValue.Trim() != "0") //!string.IsNullOrEmpty(txtActTime.Text.Trim())
            {
                objActivity.ActStartTime = Convert.ToDateTime(txtActDate.Text.Trim() + " " + ddlActTime.SelectedValue.Trim());//txtActTime.Text.Trim()
                GetCountOfActForStime(objActivity.ActStartTime, Interval1);
                DateTime dt;
                if (ViewState["NewStartDate"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["NewStartDate"]).Trim()))
                    dt = objActivity.ActStartTime = Convert.ToDateTime(Convert.ToString(ViewState["NewStartDate"]).Trim());
                else
                    dt = Convert.ToDateTime(txtActDate.Text.Trim() + " " + ddlActTime.SelectedValue.Trim());//txtActTime.Text.Trim()
                objActivity.ActEndTime = dt.AddMinutes(2);
            }
            objActivity.IsTimeLess = false;
            objActivity.IsPrivate = false;
            objActivity.Status = Convert.ToInt32(ddlActStatus.SelectedValue.Trim());
            objActivity.Duration = Convert.ToInt32(ddlDuration.SelectedValue.Trim());
            objActivity.ActivityDocId = Convert.ToInt64(hdfActivityDocId.Value.Trim());
            objActivity.ActivityDocRemark = txtRemark.Text.Trim();
            objActivity.ActivityDocFilePath = hdfActivityDoc.Value.Trim();
            objActivity.Location = txtLocation.Text.Trim();
            List<ActResources> lstResources = new List<ActResources>();
            List<ActAlertDetails> lstActAlerts = new List<ActAlertDetails>();
            ActResources objActResource = new ActResources();
            objActResource.ResourceId = BasePage.UserSession.VirtualRoleId;//Convert.ToInt64(hdfConsultantId.Value.Trim());
            objActResource.ActResourceId = Convert.ToInt64(hdfActResId.Value.Trim());
            objActResource.IsDeleted = false;
            if (Convert.ToInt64(hdfActResId.Value.Trim()) > 0)//!chkSelect.Checked && Convert.ToInt64(hdfConsultantId.Value.Trim()) > 0 && (
            {
                objActResource.IsDeleted = true;
            }
            lstResources.Add(objActResource);

            if (ddlAlarm.SelectedValue.Trim() != "0")
            {
                objActivity.PriorityId = 1;//Hard Code For High Priority Convert.ToInt16(ddlPriority.SelectedValue.Trim());
                if (chkSms.Checked)
                {
                    ActAlertDetails objActAlertDetails = new ActAlertDetails();
                    if (Convert.ToInt64(hdfActSMSAlertId.Value.Trim()) > 0)
                    {
                        objActAlertDetails.IsDeleted = true;
                    }
                    else
                        objActAlertDetails.IsDeleted = false;
                    objActAlertDetails.ActAlertId = Convert.ToInt64(hdfActSMSAlertId.Value.Trim());
                    objActAlertDetails.AlertTypeId = Cls_Constant.SMSAlert;// Hard Coded For SMS
                    if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                        objActAlertDetails.AlertValueBefore = 0;
                    else
                        objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                    objActAlertDetails.SnoozValue = 0;
                    objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// hdfConsultantId.Value.Trim(); //strIds.ToString().TrimEnd(',');
                    lstActAlerts.Add(objActAlertDetails);
                }
                if (chkEmail.Checked)
                {
                    ActAlertDetails objActAlertDetails = new ActAlertDetails();
                    if (Convert.ToInt64(hdfActMailAlertId.Value.Trim()) > 0)//!chkSelect.Checked && Convert.ToInt64(hdfConsultantId.Value.Trim()) > 0 && 
                    {
                        objActAlertDetails.IsDeleted = true;
                    }
                    else
                        objActAlertDetails.IsDeleted = false;
                    objActAlertDetails.ActAlertId = Convert.ToInt64(hdfActMailAlertId.Value.Trim());
                    objActAlertDetails.AlertTypeId = Cls_Constant.MailAlert;// Hard Coded For Email
                    if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                        objActAlertDetails.AlertValueBefore = 0;
                    else
                        objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                    objActAlertDetails.SnoozValue = 0;
                    objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();//hdfConsultantId.Value.Trim(); //strIds.ToString().TrimEnd(',');
                    lstActAlerts.Add(objActAlertDetails);
                }
                if (chkDashBoard.Checked)
                {
                    ActAlertDetails objActAlertDetails = new ActAlertDetails();
                    if (Convert.ToInt64(hdfActDashAlertId.Value.Trim()) > 0)
                    {
                        objActAlertDetails.IsDeleted = true;
                    }
                    else
                        objActAlertDetails.IsDeleted = false;
                    objActAlertDetails.ActAlertId = Convert.ToInt64(hdfActDashAlertId.Value.Trim());
                    objActAlertDetails.AlertTypeId = Cls_Constant.DashBoardAlert;// Hard Coded For Dashboard Alert
                    if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                        objActAlertDetails.AlertValueBefore = 0;
                    else
                        objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                    objActAlertDetails.SnoozValue = 0;
                    objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();//hdfConsultantId.Value.Trim(); //strIds.ToString().TrimEnd(',');
                    lstActAlerts.Add(objActAlertDetails);
                }
            }
            else
                objActivity.PriorityId = 2;//Hard Code For Moderate Convert.ToInt16(ddlPriority.SelectedValue.Trim());
            objActivity.LstAlertDetails = lstActAlerts;
            objActivity.LstReources = lstResources;
            objActivity.CreatedById = BasePage.UserSession.VirtualRoleId;
            objActivity.IsDeleted = false;
            Int64 Result = 0;
            Result = objActivityBM.UpdateActivity(objActivity);
            if (Result > 0)
            {
                lblSerSucMsg.Text = Resources.PFSalesResource.ActivityUpdated.Trim();
                dvaserSuccess.Visible = true;
                lblSerErrMsg.Text = string.Empty;
                dvsererror.Visible = false;
                hdfActivityDoc.Value = string.Empty;
                lnkbtnUpdate.Visible = false;
                lnkbtnSaveAct.Visible = true;
                lblAddActivity.Text = Resources.PFSalesResource.AddNewActivity.Trim();
            }
            else if (Result == -5)
            {
                lblSerErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                dvaserSuccess.Visible = false;
                lblSerSucMsg.Text = string.Empty;
                dvsererror.Visible = true;
            }
            else
            {
                lblSerErrMsg.Text = Resources.PFSalesResource.ActivityNotUpdated.Trim();
                dvaserSuccess.Visible = false;
                lblSerSucMsg.Text = string.Empty;
                dvsererror.Visible = true;
            }
        }
        BindMangeData();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 12 Aug 2013
    /// Description: Update Only Notes
    /// </summary>
    private void UpdateOnlyNotes()
    {
        if (!string.IsNullOrEmpty(hdfActivityId.Value.Trim()) && !string.IsNullOrEmpty(hdfActivityDocId.Value.Trim()))
        {
            if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
                objActivity.ProspectId = Convert.ToInt64(hdfProspectId.Value.Trim());
            Int64 Result = objActivityBM.UpdateContactNotes(Convert.ToInt64(hdfContactNotesId.Value.Trim()), objActivity.ProspectId, "Changed to" + ddlActStatus.SelectedValue.Trim() + ":" + txtclrRemark.Text.Trim(), BasePage.UserSession.VirtualRoleId, false, Convert.ToInt32(ddlclrActStatus.SelectedValue.Trim()), Convert.ToInt64(hdfActivityId.Value.Trim()), Convert.ToInt32(ddlclrStatus.SelectedValue.Trim()));
            if (Result > 0)
            {
                lblSerSucMsg.Text = Resources.PFSalesResource.NotesUpdated.Trim();
                dvaserSuccess.Visible = true;
                lblSerErrMsg.Text = string.Empty;
                dvsererror.Visible = false;
                hdfActivityDoc.Value = string.Empty;
                lnkbtnUpdate.Visible = false;
                lnkbtnSaveAct.Visible = true;
                lblAddActivity.Text = Resources.PFSalesResource.AddNewActivity.Trim();
            }
            else if (Result == -5)
            {
                lblSerErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                dvaserSuccess.Visible = false;
                lblSerSucMsg.Text = string.Empty;
                dvsererror.Visible = true;
            }
            else
            {
                lblSerErrMsg.Text = Resources.PFSalesResource.NotesNotUpdated.Trim();
                dvaserSuccess.Visible = false;
                lblSerSucMsg.Text = string.Empty;
                dvsererror.Visible = true;
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
                objActivity.ProspectId = Convert.ToInt64(hdfProspectId.Value.Trim());
            Int64 Result = objActivityBM.UpdateContactNotes(Convert.ToInt64(hdfContactNotesId.Value.Trim()), objActivity.ProspectId, "Activity Status Changed:-" + txtclrRemark.Text.Trim(), BasePage.UserSession.VirtualRoleId, false, Convert.ToInt32(ddlclrActStatus.SelectedValue.Trim()), 0, Convert.ToInt32(ddlclrStatus.SelectedValue.Trim()));
            if (Result > 0)
            {
                lblSerSucMsg.Text = Resources.PFSalesResource.NotesUpdated.Trim();
                dvaserSuccess.Visible = true;
                lblSerErrMsg.Text = string.Empty;
                dvsererror.Visible = false;
                hdfActivityDoc.Value = string.Empty;
                lnkbtnUpdate.Visible = false;
                lnkbtnSaveAct.Visible = true;
                lblAddActivity.Text = Resources.PFSalesResource.AddNewActivity.Trim();
            }
            else if (Result == -5)
            {
                lblSerErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                dvaserSuccess.Visible = false;
                lblSerSucMsg.Text = string.Empty;
                dvsererror.Visible = true;
            }
            else
            {
                lblSerErrMsg.Text = Resources.PFSalesResource.NotesNotUpdated.Trim();
                dvaserSuccess.Visible = false;
                lblSerSucMsg.Text = string.Empty;
                dvsererror.Visible = true;
            }
        }
        BindMangeData();
    }

    /// To Set Ajax callout for validators by using validators ID
    //private void CreateAjaxCallout(string controlID, string validatorClientID)
    //{
    //    ValidatorCalloutExtender valExtender = new ValidatorCalloutExtender();
    //    valExtender.TargetControlID = controlID;
    //    valExtender.BehaviorID = "AjaxCallouts_" + validatorClientID;
    //    valExtender.ID = controlID + "_ValExtender";
    //    valExtender.HighlightCssClass = "validatorCalloutHighlight";
    //    valExtender.Width = new Unit(250);
    //    validatorPlaceHolder.Controls.Add(valExtender);
    //}

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 12 Aug 2013
    /// Description: Get Number Of Activities Added for Only Notes
    /// </summary>
    /// <param name="startTime"></param>
    /// <returns></returns>
    private void GetCountOfActForStime(DateTime startTime, double interval)
    {
        try
        {
            DateTime dt = startTime;
            Int64 ACount = objActivityBM.GetCountOfActForStime(BasePage.UserSession.VirtualRoleId, startTime);
            if (ACount >= 2)
            {
                GetCountOfActForStime(startTime.AddMinutes(interval), interval);
                dt = startTime.AddMinutes(interval);
            }
            else
                ViewState["NewStartDate"] = dt;
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_ProspectDetails.GetCountOfActForStime.error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 Aug 2013
    /// Description: Save Acttvity for next working day
    /// </summary>
    private Int64 SetCallTomorrow(DateTime dtNewDay)
    {
        StringBuilder strIds = new StringBuilder();
        objActivity.Id = 0;
        objActivity.ParrentActId = 0;
        objActivity.ActivityTypeId = Convert.ToInt16(ddlAddActType.SelectedValue.Trim());
        objActivity.Regarding = ddlAddActType.SelectedItem.Text.Trim() + " : to " + lblAddActProspect.Text.Trim();//txtRegarding.Text.Trim();
        objActivity.Regardings = ddlAddActType.SelectedItem.Text.Trim() + " : to " + lblAddActProspect.Text.Trim();//txtRegarding.Text.Trim();
        objActivity.PriorityId = Convert.ToInt16(ddlPriority.SelectedValue.Trim());
        if (!string.IsNullOrEmpty(hdfProspectId.Value.Trim()))
            objActivity.ProspectId = Convert.ToInt64(hdfProspectId.Value.Trim());
        else
            objActivity.ProspectId = 0;
        //if (!string.IsNullOrEmpty(txtActDate.Text.Trim()) && ddlActTime.SelectedValue.Trim() != "0")//!string.IsNullOrEmpty(txtActTime.Text.Trim())
        //{
        objActivity.ActStartTime = Convert.ToDateTime(dtNewDay.ToShortDateString() + " " + "09:00");//txtActTime.Text.Trim()
        GetCountOfActForStime(objActivity.ActStartTime, Interval1);
        DateTime dt;
        if (ViewState["NewStartDate"] != null && !string.IsNullOrEmpty(Convert.ToString(ViewState["NewStartDate"]).Trim()))
            dt = objActivity.ActStartTime = Convert.ToDateTime(Convert.ToString(ViewState["NewStartDate"]).Trim());
        else
            dt = Convert.ToDateTime(dtNewDay.ToShortDateString() + " " + "09:00");//txtActTime.Text.Trim()
        objActivity.ActEndTime = dt.AddMinutes(2);//Convert.ToDateTime(txtEndDate.Text.Trim() + " " + txtEndTime.Text.Trim());
        //}
        objActivity.IsTimeLess = false;
        objActivity.IsPrivate = false;
        objActivity.Status = Convert.ToInt32(ddlActStatus.SelectedValue.Trim());
        objActivity.Duration = Convert.ToInt32(ddlDuration.SelectedValue.Trim());
        objActivity.ActivityDocId = 0;
        objActivity.ActivityDocRemark = txtRemark.Text.Trim();
        objActivity.ActivityDocFilePath = hdfActivityDoc.Value.Trim();
        objActivity.Location = txtLocation.Text.Trim();
        List<ActResources> lstResources = new List<ActResources>();
        List<ActAlertDetails> lstActAlerts = new List<ActAlertDetails>();
        ActResources objActResource = new ActResources();
        objActResource.ResourceId = BasePage.UserSession.VirtualRoleId;
        lstResources.Add(objActResource);
        ddlAlarm.SelectedValue = "0";
        if (chkSms.Checked)
        {
            string[] array = strIds.ToString().TrimEnd(',').Split(',');
            if (array.Length > 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    ActAlertDetails objActAlertDetails = new ActAlertDetails();
                    objActAlertDetails.AlertTypeId = Cls_Constant.SMSAlert;// Hard Coded For SMS
                    if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                        objActAlertDetails.AlertValueBefore = 0;
                    else
                        objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                    objActAlertDetails.SnoozValue = 0;
                    objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
                    lstActAlerts.Add(objActAlertDetails);
                }
            }
        }
        if (chkEmail.Checked)
        {
            string[] array = strIds.ToString().TrimEnd(',').Split(',');
            if (array.Length > 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    ActAlertDetails objActAlertDetails = new ActAlertDetails();
                    objActAlertDetails.AlertTypeId = Cls_Constant.MailAlert;// Hard Coded For Email
                    if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                        objActAlertDetails.AlertValueBefore = 0;
                    else
                        objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                    objActAlertDetails.SnoozValue = 0;
                    objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();// //array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
                    lstActAlerts.Add(objActAlertDetails);
                }
            }
        }
        if (chkDashBoard.Checked)
        {
            string[] array = strIds.ToString().TrimEnd(',').Split(',');
            if (array.Length > 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    ActAlertDetails objActAlertDetails = new ActAlertDetails();
                    objActAlertDetails.AlertTypeId = Cls_Constant.DashBoardAlert;// Hard Coded For Dashboard Alert
                    if (Convert.ToInt32(ddlAlarm.SelectedValue.Trim()) == 1) // If Zero Minutes Alarm Value Selected
                        objActAlertDetails.AlertValueBefore = 0;
                    else
                        objActAlertDetails.AlertValueBefore = Convert.ToInt32(ddlAlarm.SelectedValue.Trim());
                    objActAlertDetails.SnoozValue = 0;
                    objActAlertDetails.AlertForId = BasePage.UserSession.VirtualRoleId.ToString();//array[i].ToString().Trim(); //strIds.ToString().TrimEnd(',');
                    lstActAlerts.Add(objActAlertDetails);
                }
            }
        }
        objActivity.LstAlertDetails = lstActAlerts;
        objActivity.LstReources = lstResources;
        objActivity.CreatedById = BasePage.UserSession.VirtualRoleId;
        objActivity.IsDeleted = false;
        Int64 Result = 0;
        Result = objActivityBM.AddActivity(objActivity);
        if (Result > 0)
        {
            lblSerSucMsg.Text = Resources.PFSalesResource.ActivityAddedSuccessfully.Trim();
            dvaserSuccess.Visible = true;
            lblSerErrMsg.Text = string.Empty;
            dvsererror.Visible = false;
            hdfActivityDoc.Value = string.Empty;
        }
        else if (Result == -5)
        {
            lblSerErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
            dvsererror.Visible = true;
        }
        else
        {
            lblSerErrMsg.Text = Resources.PFSalesResource.ActivityNotAdded.Trim();
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
            dvsererror.Visible = true;
        }
        pnlGeneral.Visible = true;
        pnlDetails.Visible = false;
        lnkbtnGeneralInfo.CssClass = "tablerBtnActive";
        lnkbtnDetailsInfo.CssClass = "";
        BindMangeData();
        return Result;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 22 Aug 2013
    /// Description: Show Old Activity Details 
    /// </summary>
    public void EditFromCalendar()
    {
        try
        {
            DataTable Dt = objActivityBM.GetActivityDetFromId(Convert.ToInt64(hdfActivityId.Value.Trim()), BasePage.UserSession.VirtualRoleId);
            if (Dt != null && Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0]["ProspectId"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["ProspectId"].ToString().Trim()))
                {
                    BindProspects();
                    ddlProspect.SelectedValue = Dt.Rows[0]["ProspectId"].ToString().Trim();
                    hdfProspectId.Value = Dt.Rows[0]["ProspectId"].ToString().Trim();
                }
                BindActStatuses();
                BindAllStatuses();
                if (BasePage.UserSession.RoleId == 5)
                    ViewState["ContactStatus"] = ddlclrStatus.SelectedValue = Dt.Rows[0]["FCStatusId"].ToString().Trim();
                else
                    ViewState["ContactStatus"] = ddlclrStatus.SelectedValue = Dt.Rows[0]["ContactStatus"].ToString().Trim();
                hdfActivityDocId.Value = Dt.Rows[0]["DocId"].ToString().Trim();
                hdfActivityDoc.Value = Dt.Rows[0]["Filepath"].ToString().Trim();
                hdfContactNotesId.Value = Dt.Rows[0]["CNId"].ToString().Trim();
                ddlAlarm_SelectedIndexChanged(null, null);
                BindConsultants();
                DataTable dtAlertDet = objActivityBM.GetActivityAlertDetailsFromId(Convert.ToInt64(hdfActivityId.Value.Trim()), BasePage.UserSession.VirtualRoleId);
                if (Convert.ToInt64(ddlProspect.SelectedValue.Trim()) > 0)
                    ddlProspect_SelectedIndexChanged(null, null);
                GetMinStartDate();
            }
            else if (!string.IsNullOrEmpty(hdfContactNotesId.Value.Trim()) && Convert.ToInt64(hdfContactNotesId.Value.Trim()) > 0)
            {
                Dt = objActivityBM.GetContactNotesFromId(Convert.ToInt64(hdfContactNotesId.Value.Trim()));
                if (Dt.Rows[0]["ContactId"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["ContactId"].ToString().Trim()))
                {
                    BindProspects();
                    ddlProspect.SelectedValue = Dt.Rows[0]["ContactId"].ToString().Trim();
                    hdfProspectId.Value = Dt.Rows[0]["ContactId"].ToString().Trim();
                }
                ViewState["ContactStatus"] = ddlclrStatus.SelectedValue = Dt.Rows[0]["ContactStatus"].ToString().Trim();
                txtclrRemark.Text = Dt.Rows[0]["Notes"].ToString().Trim();
                if (Dt.Rows[0]["NotesStatus"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["NotesStatus"].ToString().Trim()))
                {
                    ViewState["SelectedStatus"] = ddlclrActStatus.SelectedValue = Dt.Rows[0]["NotesStatus"].ToString().Trim();
                    BindAllStatuses();
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "UserControls_UC_AddActivity.EditData.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 Oct 2013
    /// Description: Send Email To FC Consultant When Status Becomes Tender OR NTU
    /// </summary>
    /// <param name="emilToId"></param>
    /// <param name="noOfLeads"></param>
    /// <param name="Name"></param>
    /// <returns></returns>
    private Boolean SendMail(string emilToId, string Status, string Name, string Lead)
    {
        string FileContent = string.Empty;
        try
        {
            Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
            //objEmailHelper.EmailFromID = BasePage.UserSession.EmailFromID;ConfigurationManager.AppSettings["EmailFromID"].ToString();
            objEmailHelper.EmailSubject = "PF Status Changed";
            //objEmailHelper.SMTPServerIP = ConfigurationManager.AppSettings["SMTPServerIP"].ToString();
            // objEmailHelper.SMTPUserID = ConfigurationManager.AppSettings["SMTPUserID"].ToString();
            // objEmailHelper.SMTPUserPwd = ConfigurationManager.AppSettings["SMTPUserPwd"].ToString();
            objEmailHelper.EmailToID = emilToId;
            FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear, " + Name.Trim() + "<br /><br />Please be advised that,PF Status for the lead " + Lead.Trim() + ", which is assigned to you has been made to" + Status.Trim() + ".<br /><br /> Thanks you<br /> PFSales Team</span>";
            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "EMail sent successfully", "PF Status Changed", "Add-Edit Activity User Control");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "PF Status Changed", "Add-Edit Activity User Control");
                return false;
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + "LeadAllocation.SendMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, BasePage.UserSession.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "PF Status Changed", "Add-Edit Activity User Control");
            return false;
        }
    }
    #endregion
}
