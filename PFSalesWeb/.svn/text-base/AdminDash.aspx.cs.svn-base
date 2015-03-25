using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using Mechsoft.PFSales.BusinessEntity;
using Mechsoft.PFSales.BusinessManager;
using System.Data;

public partial class AdminDash : BasePage
{
    #region Global Variables
    Activity objActivity = new Activity();
    ActivityBM objActivityBM = new ActivityBM();
    ILog Logger = LogManager.GetLogger(typeof(AdminDash));
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Form.DefaultButton = linkbtnSearch.UniqueID;
            BindNotifications();
            BindTodaysActivities();
            Session["FromDashProspectId"] = Session["FromDashMemNo"] = string.Empty;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 4 July 2013
    /// Description: Go to search prospect page from notification
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnNotification_Click(object sender, EventArgs e)
    {
        GridViewRow GvRow = (GridViewRow)(((LinkButton)sender).NamingContainer);
        if (GvRow != null)
        {
            HiddenField hdfprospId = (HiddenField)GvRow.FindControl("hdfprospId");
            if (hdfprospId != null && !string.IsNullOrEmpty(hdfprospId.Value.Trim()))
            {
                Session["FromDashProspectId"] = hdfprospId.Value.Trim();
            }
            Response.Redirect("SearchProspect.aspx?FromDashBoard=1");
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date:4 July 2013
    /// Description: Go to search prospect page from today's Activity
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnActivities_Click(object sender, EventArgs e)
    {
        GridViewRow GvRow = (GridViewRow)(((LinkButton)sender).NamingContainer);
        if (GvRow != null)
        {
            HiddenField hdfActivityTypeId = (HiddenField)GvRow.FindControl("hdfActivityTypeId");
            if (hdfActivityTypeId != null && !string.IsNullOrEmpty(hdfActivityTypeId.Value.Trim()))
            {
                DataTable Dt = objActivityBM.GetProspIdForTodayAct(Convert.ToInt16(hdfActivityTypeId.Value.Trim()));
                if (Dt != null && Dt.Rows.Count > 0)
                    Session["FromDashProspectId"] = Dt.Rows[0][0].ToString().Trim();
            }
            Response.Redirect("SearchProspect.aspx?FromDashBoard=1");
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date:4 July 2013
    /// Description:Refresh Dash Board After Every 1 Min
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Timer_Tick(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 4 July 2013
    /// Description:Search Button Click  
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void linkbtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Session["FromDashMemNo"] = txtSearch.Text.Trim();
            Response.Redirect("SearchProspect.aspx?FromDashBoard=1");
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AdminDash.linkbtnSearch_Click.Error:" + ex.StackTrace);
        }
    }
    #endregion

    #region Methods

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 4 July 2013
    /// Description: Bind Notification Data
    /// </summary>
    private void BindNotifications()
    {
        try
        {
            DataTable Dt = objActivityBM.GetAdminNotifications();
            if (Dt != null & Dt.Rows.Count > 0)
            {
                DataView dV = Dt.DefaultView;
                gvNotifications.DataSource = Dt;
                gvNotifications.DataBind();
            }
            else
            {
                gvNotifications.DataSource = null;
                gvNotifications.DataBind();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AdminDash.BindNotifications.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 4 July 2013
    /// Description: Bind Todays Activities
    /// </summary>
    private void BindTodaysActivities()
    {
        try
        {
            DataTable Dt = objActivityBM.GetTodaysAdminActivity();
            if (Dt != null & Dt.Rows.Count > 0)
            {
                DataView dV = Dt.DefaultView;
                gvActivities.DataSource = Dt;
                gvActivities.DataBind();
            }
            else
            {
                gvActivities.DataSource = null;
                gvActivities.DataBind();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AdminDash.BindTodaysActivities.Error:" + ex.StackTrace);
        }
    }
    #endregion
}
