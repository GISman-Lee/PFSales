using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using System.Data;
using Mechsoft.PFSales.BusinessManager;

public partial class ActivityCallendar : BasePage
{
    #region Global Variables
    ILog Logger = LogManager.GetLogger(typeof(ActivityCallendar));
    ActivityBM objActivityBM = new ActivityBM();
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindHours();
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
            pnlCallendar.Visible = false;
            pnlCallDetails.Visible = true;
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
            if (sender != null)
            {
                // Do not work for past date
                //if (e.Day.Date >= DateTime.Now.Date)
                //{
                DataTable objDates = BindActivities();
                string s = e.Day.Date.ToShortDateString();
                if (objDates != null)
                {
                    if (objDates.Rows.Count > 0)
                    {
                        foreach (DataRow row in objDates.Rows)
                        {
                            string scheduledDate = Convert.ToDateTime(row["StartDateTime"]).ToString("g").Substring(0, 10);//.ToShortDateString();
                            if (scheduledDate.Equals(s))
                            {
                                e.Cell.ForeColor = System.Drawing.Color.Black;
                                if (e.Day.IsOtherMonth == true)
                                { }
                                else
                                {
                                    e.Cell.BackColor = System.Drawing.Color.FromName("#DCF0FE");
                                    e.Cell.BorderColor = System.Drawing.Color.FromName("#5B8BC9");
                                    e.Cell.BorderStyle = BorderStyle.Solid;
                                    e.Cell.BorderWidth = Unit.Parse("1px");
                                    e.Cell.ForeColor = System.Drawing.Color.FromName("#367CAD");
                                    e.Cell.Width = Unit.Parse("14%");
                                    e.Cell.ToolTip = row["Name"].ToString().Trim();
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
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ActivityCallendar.calActivity_DayRender.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 June 2013
    /// Description: View Activity Details on Calender
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConsultantDash.aspx");
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 June 2013
    /// Description: Row Data Bound Event Of GridView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvHours_onRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].Attributes.Add("onClick", "ShowPopup();");
            e.Row.Cells[1].Style["cursor"] = "pointer";
        }
    }

    protected void gvHours_onRowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    #endregion

    #region Methods
    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 28 Jun 2013
    /// Descreption: create blank table
    /// </summary>
    /// <returns></returns>
    private DataTable CreateTable()
    {
        try
        {
            DataTable dtTable = new DataTable();
            DataColumn dc1 = new DataColumn("Hours");
            dtTable.Columns.Add(dc1);
            return dtTable;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ActivityCallendar.createTable.Error:" + ex.StackTrace);
            return null;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 28 Jun 2013
    /// Descreption: Bind Hours To Grid
    /// </summary>
    private void BindHours()
    {
        DataTable dt = CreateTable();
        for (int i = 0; i < 25; i++)
        {
            DataRow dr = dt.NewRow();
            dr["Hours"] = i;
            dt.Rows.Add(dr);
        }
        gvHours.DataSource = dt;
        gvHours.DataBind();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 Jun 2013
    /// Descreption: Bind Activities To Callendar
    /// </summary>
    private DataTable BindActivities()
    {
        try
        {
            DataTable Dt = objActivityBM.GetMyActivities(BasePage.UserSession.VirtualRoleId);
            return Dt;
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ActivityCallendar.BindActivities.Error:" + ex.StackTrace);
            return null;
        }
    }
    #endregion
}
