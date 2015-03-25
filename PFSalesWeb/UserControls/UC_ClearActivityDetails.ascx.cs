using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using System.IO;
using System.Data;
using Mechsoft.PFSales.BusinessManager;

public partial class UserControls_UC_ClearActivityDetails : System.Web.UI.UserControl
{
    #region Global Variables
    ILog Logger = LogManager.GetLogger(typeof(UserControls_UC_ClearActivityDetails));
    ActivityBM objActivityBM = new ActivityBM();
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkbtnclrActDetAttachment);
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 4 July 2013
    /// Description: Close Clear Activity Details Pop Up
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnclrActDetAttachment_Click(object sender, EventArgs e)
    {
        try
        {
            DownloadFile(((LinkButton)sender).CommandArgument.ToString());
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SearchProspect.lnkbtnclrActDetAttachment_Click.Error:" + ex.StackTrace);
        }
    }
    #endregion

    #region Methods

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 4 July 2013
    /// Description: Download Files
    /// </summary>
    /// <param name="FileName"></param>
    private void DownloadFile(string FileName)
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
    /// Created Date: 6 July 2013
    /// Description: Bind Clear Activity Details
    /// </summary>
    /// <param name="ActivityId"></param>
    /// <param name="prospectName"></param>
    public void Binddata(Int64 ActivityId, string prospectName)
    {
        DataTable Dt1 = objActivityBM.GetActivityDetFromId(ActivityId, BasePage.UserSession.VirtualRoleId);
        if (Dt1 != null && Dt1.Rows.Count > 0)
        {
            lblClrActDetProsp.Text = prospectName.Trim();// lblSelectedProsp.Text.Trim();
            lblClrActDetActType.Text = Dt1.Rows[0]["ActivityType"].ToString().Trim();
            lblClrActDetReg.Text = Dt1.Rows[0]["name"].ToString().Trim();
            lblClrActDetPrio.Text = Dt1.Rows[0]["Priority"].ToString().Trim();
            lblClrActDetSDate.Text = Convert.ToDateTime(Dt1.Rows[0]["start"].ToString().Trim()).ToString("g").Substring(0, 10);
            lblClrActDetSTime.Text = Dt1.Rows[0]["start"].ToString().Trim().Substring(11, 5);
            lblClrActDetEDate.Text = Convert.ToDateTime(Dt1.Rows[0]["end"].ToString().Trim()).ToString("g").Substring(0, 10);
            lblClrActDetETime.Text = Dt1.Rows[0]["end"].ToString().Trim().Substring(11, 5);
            lblClrActDetLoc.Text = Dt1.Rows[0]["Location"].ToString().Trim();
            LblClrActDetActStatus.Text = Dt1.Rows[0]["ActivityStatus"].ToString().Trim();
            LblClrActDetRemark.Text = Dt1.Rows[0]["ClearRemark"].ToString().Trim();
            if (!string.IsNullOrEmpty(Dt1.Rows[0]["ClearFilePath"].ToString().Trim()))
            {
                lnkbtnclrActDetAttachment.Text = Resources.PFSalesResource.Download.Trim();
                lnkbtnclrActDetAttachment.ToolTip = Resources.PFSalesResource.DownloadAttachment.Trim();
                lnkbtnclrActDetAttachment.CommandArgument = Dt1.Rows[0]["ClearFilePath"].ToString().Trim();
                lnkbtnclrActDetAttachment.Enabled = true;
            }
            else
            {
                lnkbtnclrActDetAttachment.Text = Resources.PFSalesResource.NoAttachment.Trim();
                lnkbtnclrActDetAttachment.ToolTip = Resources.PFSalesResource.NoAttachment.Trim();
                lnkbtnclrActDetAttachment.Enabled = false;
            }
            lblclrActDetStatus.Text = Dt1.Rows[0]["ProspectStatus"].ToString().Trim();
            lblclrActDetClearedDate.Text = Dt1.Rows[0]["ClearedDate"].ToString().Trim();

        }
    }
    #endregion
}
