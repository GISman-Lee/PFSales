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
using System.Threading;

public partial class Reports_ProspectReport : BasePage
{
    #region Private Variables
    ILog Logger = LogManager.GetLogger(typeof(Reports_ProspectReport));
    Prospect objProsp = new Prospect();
    ProspectBM objProspBM = new ProspectBM();
    MasterBM objMstBM = new MasterBM();
    Thread t3 = null;
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = "CreatedDate";
            ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;
            BindAllStatuses();
            BindAllSources();
            BindAllMakes();
            BindAllStates();
            txtTotEntFrmDate.Text = DateTime.Now.AddDays(-15).ToShortDateString();
            txtTotEntToDate.Text = DateTime.Now.ToShortDateString();
            BindGrid();
            Page.MaintainScrollPositionOnPostBack = true;
            txtserprospName.Focus();
        }
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
    /// Created Date: 10 July 2013
    /// Description: Export to pdf button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnPdf_Click(object sender, EventArgs e)
    {
        htmlToPdf();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 July 2013
    /// Description: Export to excel button click.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnExcel_Click(object sender, EventArgs e)
    {
        ExportToExcelsheet();
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
    /// Description: Selected Index Changed Event Of Prospect Status's Drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
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
        pagerParent.CurrentIndex = 1;
        BindGrid();
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
        ddlCarMake.SelectedValue = ddlSource.SelectedValue = ddlStatus.SelectedValue = "0";
        ddlStatus.Focus();
        ddlserState.SelectedValue = "0";
        ddlserState_SelectedIndexChanged(null, null);
        txtTotEntFrmDate.Text = DateTime.Now.AddDays(-15).ToShortDateString();
        txtTotEntToDate.Text = DateTime.Now.ToShortDateString(); txtEmail1.Text = string.Empty;
        BindGrid();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 June 2013
    /// Description: Selected Index Changed Event of Source's Drop Down List.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlSource_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindAllCities();
        BindGrid();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 Aug 2013
    /// Description: Selected Index Changed Event of State's Drop Down List.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlserState_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
        BindAllCities();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 Aug 2013
    /// Description: Selected Index Changed Event of Makes's Drop Down List.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlCarMake_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 Aug 2013
    /// Description: Selected Index Changed Event Of City's Drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlserCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
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

            BindGrid();

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message);
            //throw ex;
        }
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
            objProsp.FName = txtserprospName.Text.Trim();
            objProsp.StatusId = Convert.ToInt64(ddlStatus.SelectedValue.Trim());
            objProsp.MemberNo = txtMemNo.Text.Trim();
            objProsp.CarMake = Convert.ToInt32(ddlCarMake.SelectedValue.Trim());
            objProsp.Email = txtEmail1.Text.Trim();
            objProsp.StateId = Convert.ToInt32(ddlserState.SelectedValue.Trim());
            objProsp.CityId = Convert.ToInt32(ddlserCity.SelectedValue.Trim());
            objProsp.Phone = string.Empty;
            if (!string.IsNullOrEmpty(txtTotEntFrmDate.Text.Replace("__/__/____", "")))
                objProsp.FromDate = Convert.ToDateTime(txtTotEntFrmDate.Text.Trim());
            else
                objProsp.FromDate = DateTime.MinValue;
            if (!string.IsNullOrEmpty(txtTotEntToDate.Text.Replace("__/__/____", "")))
                objProsp.ToDate = Convert.ToDateTime(txtTotEntToDate.Text.Trim());
            objProsp.SourceId = Convert.ToInt32(ddlSource.SelectedValue.Trim());
            objProsp.PageIndex = pagerParent.CurrentIndex;
            objProsp.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue.Trim());
            objProsp.Comment = Convert.ToString(ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION]);
            objProsp.CreatedById = BasePage.UserSession.VirtualRoleId;
            if (BasePage.UserSession.RoleId == 3)
                objProsp.ValueforAnswer = "PF";
            else if (BasePage.UserSession.RoleId == 5)
                objProsp.ValueforAnswer = "FC";
            else if (BasePage.UserSession.RoleId == 1)
                objProsp.ValueforAnswer = "";
            else
                objProsp.ValueforAnswer = string.Empty;
            DataSet Ds = objProspBM.GetAllProspForConsult(objProsp);
            DataTable Dt = Ds.Tables[0];
            if (Dt != null & Dt.Rows.Count > 0)
            {
                DataView dV = Dt.DefaultView;
                if (BasePage.UserSession.RoleId == 3)
                {
                    dV.RowFilter = "ConsultantId=" + BasePage.UserSession.VirtualRoleId.ToString().Trim();
                }
                dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
                //ViewState["MainData"] = 
                gvprosp.DataSource = Dt;
                gvprosp.DataBind();
                ViewState["TotalCount"] = Dt.Rows.Count;
                objProsp.PostalCode = objProsp.FCIds = objProsp.Ids = string.Empty;
                objProsp.CreatedById = objProsp.Finance = 0;
                t3 = new Thread(saveDataToViewState);
                t3.Start();
            }
            else
            {
                gvprosp.DataSource = null;
                gvprosp.DataBind();
                ViewState["TotalCount"] = "0";
            }
            pagerParent.PageSize = gvprosp.PageSize;
            if (Ds.Tables[1].Rows.Count > 0)
            {
                pagerParent.ItemCount = Convert.ToDouble(Ds.Tables[1].Rows[0][0]);
            }
            else
                pagerParent.ItemCount = 0;
            t3.Join(10);

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Reports_ProspectReport.BindGrid.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 July 2013
    /// Description: Export to excel function.
    /// </summary>
    public void ExportToExcelsheet()
    {
        try
        {
            if (Session["MyProspData"] != null)
            {

                string path = Server.MapPath("Reports") + "\\ProspectReport.xls";
                string szConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=No'";
                OleDbConnection conn = new OleDbConnection(szConn);
                conn.Open();

                // Select
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", conn);
                OleDbDataAdapter adpt = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpt.Fill(ds);

                //foreach (DataRow dr in ds.Tables[0].Rows)
                //{
                //    string data = string.Format("F1:{0}, F2:{1}, F3:{2}, F4:(3), F5:(4)", dr[0], dr[1], dr[2], dr[3], dr[4]);
                //}

                // Update
                int TotalCnt = ds.Tables[0].Rows.Count - 11;

                //string TrxnDatePeriod = lblTransPeriod.Text.Substring(lblTransPeriod.Text.IndexOf(":") + 1);
                //cmd = new OleDbCommand("UPDATE [Sheet1$] SET F2='" + TrxnDatePeriod + "' WHERE F1='Transaction Report :'", conn);
                //cmd.ExecuteNonQuery();

                //cmd = new OleDbCommand("UPDATE [Sheet1$] SET F2='" + Convert.ToDateTime(System.DateTime.Now.Date).ToString("dd MMM yyyy") + "' WHERE F1='Date :'", conn);
                //cmd.ExecuteNonQuery();

                //cmd = new OleDbCommand("UPDATE [Sheet1$] SET F2='" + ((Label)gvprosp.Rows[0].FindControl("lblCompanyName")).Text + "' WHERE F1='Dealer Company :'", conn);
                //cmd.ExecuteNonQuery();

                //cmd = new OleDbCommand("UPDATE [Sheet1$] SET F2='" + ((Label)gvprosp.Rows[0].FindControl("lblName")).Text + "' WHERE F1='Contact Name :'", conn);
                //cmd.ExecuteNonQuery();

                //// Trxn Details
                //cmd = new OleDbCommand("UPDATE [Sheet1$] SET F2='" + lblTopup_1.Text + "' WHERE F1='Amount Credit as Top Up :'", conn);
                //cmd.ExecuteNonQuery();

                //cmd = new OleDbCommand("UPDATE [Sheet1$] SET F2='" + lblReported_1.Text + "' WHERE F1='Amount Credit for Reported Lead Cost :'", conn);
                //cmd.ExecuteNonQuery();

                //cmd = new OleDbCommand("UPDATE [Sheet1$] SET F2='" + lblCharge_1.Text + "' WHERE F1='Amount Debit as Lead Cost :'", conn);
                //cmd.ExecuteNonQuery();

                //cmd = new OleDbCommand("UPDATE [Sheet1$] SET F2='" + lblAvailable_1.Text + "' WHERE F1='Total Available Balance :'", conn);
                //cmd.ExecuteNonQuery();
                DataTable dt = (DataTable)Session["MyProspData"];
                int cnt = 3;
                foreach (DataRow dr in dt.Rows)
                {

                    string lblEnquiryDate = dr["EnquiryDate"].ToString().Trim();
                    string lblprospName = dr["Name"].ToString().Trim().Replace("'", "\'");
                    lblprospName = lblprospName.Replace("'", "");
                    string lblstatus = dr["status"].ToString().Trim();
                    string lblMake = dr["Make"].ToString().Trim();
                    string lblPhone = dr["Phone"].ToString().Trim();
                    string lblRefSource = dr["RefSource"].ToString().Trim();
                    string lblIsAllocated = dr["IsAllocated"].ToString().Trim();
                    //Label lblEnquiryDate = (Label)gr.FindControl("lblEnquiryDate");
                    //Label lblprospName = (Label)gr.FindControl("lblprospName");
                    //Label lblstatus = (Label)gr.FindControl("lblstatus");
                    //Label lblMake = (Label)gr.FindControl("lblMake");
                    //Label lblPhone = (Label)gr.FindControl("lblPhone");
                    //Label lblStates = (Label)gr.FindControl("lblStates");
                    //Label lblCity = (Label)gr.FindControl("lblCity");
                    cmd = new OleDbCommand("UPDATE [Sheet1$B" + cnt + ":H" + cnt + "] SET F1='" + lblEnquiryDate + "',F2='" + lblprospName + "',F3='" + lblstatus + "',F4='" + lblMake + "',F5='" + lblPhone + "',F6='" + lblRefSource + "',F7='" + lblIsAllocated + "'", conn);
                    cmd.ExecuteNonQuery();
                    cnt++;
                    // Insert
                    //cmd = new OleDbCommand("INSERT INTO [Sheet1$](F1,F2,F3,F4,F5) VALUES ('" + lblDate.Text + "','" + lblLeadName.Text + "','" + lblStatus.Text + "','" + lblAmount.Text.Substring(1).Trim() + "','" + lblAmountStatus.Text + "')", conn);
                    //cmd.ExecuteNonQuery();
                }

                for (int i = cnt; i < TotalCnt + 3; i++)
                {
                    cmd = new OleDbCommand("UPDATE [Sheet1$B" + i + ":H" + i + "] SET F1='',F2='',F3='',F4='',F5='',F6='',F7=''", conn);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();

                System.IO.FileInfo file = new System.IO.FileInfo(path);

                Response.ContentType = "application/Excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=ProspectReport.xls");
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.WriteFile(file.FullName);
                Response.End();
                Response.Clear();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Reports_ProspectReport.ExportToExcelsheet.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 July 2013
    /// Description: Export to PDF function.
    /// </summary>
    private void htmlToPdf()
    {
        try
        {
            HtmlToPdfBuilder builder = new HtmlToPdfBuilder(PageSize.LETTER);
            HtmlPdfPage first = builder.AddPage();
            DataTable dt = new DataTable();
            if (Session["MyProspData"] != null)
            {
                dt = (DataTable)Session["MyProspData"];
                //Outer table 
                first.AppendHtml("<table cellpadding='2' cellspacing='2' border='1' align='center' widht='100%' ><tr><td align='center'>");
                //Spacing table
                first.AppendHtml("<table cellpadding='2' cellspacing='2' widht='100%' border='1'>");
                // For Header Of the DataTable print first
                first.AppendHtml("<tr>");
                // builder.AddStyle("<tr", "background:gray; color:White;>");
                // For Datarow is printed row by row....
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (dt.Columns[i].ColumnName.Trim().ToUpper() == "ENQUIRYDATE" || dt.Columns[i].ColumnName.Trim().ToUpper() == "NAME" || dt.Columns[i].ColumnName.Trim().ToUpper() == "STATUS" || dt.Columns[i].ColumnName.Trim().ToUpper() == "MAKE" || dt.Columns[i].ColumnName.Trim().ToUpper() == "PHONE" || dt.Columns[i].ColumnName.Trim().ToUpper() == "REFSOURCE" || dt.Columns[i].ColumnName.Trim().ToUpper() == "ISALLOCATED")
                        {
                            first.AppendHtml("<td><h4>");
                            first.AppendHtml(dt.Columns[i].ToString() + "</h4></td>");
                        }
                    }
                    first.AppendHtml("</tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        first.AppendHtml("<tr>");
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName.Trim().ToUpper() == "ENQUIRYDATE" || col.ColumnName.Trim().ToUpper() == "NAME" || col.ColumnName.Trim().ToUpper() == "STATUS" || col.ColumnName.Trim().ToUpper() == "MAKE" || col.ColumnName.Trim().ToUpper() == "PHONE" || col.ColumnName.Trim().ToUpper() == "REFSOURCE" || col.ColumnName.Trim().ToUpper() == "ISALLOCATED")
                            {
                                first.AppendHtml("<td>");
                                first.AppendHtml(row[col].ToString() + "</td>");
                            }
                        }
                        first.AppendHtml("</tr>");
                    }
                }
                first.AppendHtml("</table>");
                first.AppendHtml("</td></tr></table>");
                builder.AddStyle("h1", "text-align:right;font-family: Arial, Helvetica, sans-serif, Verdana;font-size: 9px;font-weight: bold;text-decoration: none;color: #ffffff;vertical-align:top;");
                builder.AddStyle("h2", "vertical-align:top;top:0px;font-family: Arial, Helvetica, sans-serif, verdana;font-size: 8px;text-decoration: none;color: #333333;padding-left:5px; text-align:right; direction:rtl;");
                builder.AddStyle("h3", "vertical-align:top; font-family: Arial, Helvetica, sans-serif, verdana;font-size: 8px;text-decoration: none;color: #333333; padding-left:18px; text-align:right; ");
                builder.AddStyle("h5", "text-align:right;font-family: Arial, Helvetica, sans-serif, Verdana;font-size: 8px;text-decoration: none;color: #FFFFFF;vertical-align:top;font-style: italic;");
                builder.AddStyle("td", "vertical-align:top;top:0px;font-family: Arial, Helvetica, sans-serif, verdana;font-size: 8.5px;text-decoration: none;color: #333333;padding-left:5px; text-align:left;background-color:Blue; ");
                builder.AddStyle("th", "vertical-align:top;top:0px;  font-weight:bold; font-family: Arial, Helvetica, sans-serif, verdana;font-size: 9px;text-decoration: none;color: #333333;padding-left:5px;text-align:left;");
                builder.AddStyle("img", "vertical-align:top;top:0px;");
                builder.AddStyle("h4", "vertical-align:top; font-family: Arial, Helvetica, sans-serif, verdana;font-size: 9px;text-decoration: none;color: #333333; background-color:Blue;");
                builder.AddStyle("table", "vertical-align:top;  left:0; align:left; text-align:left;");
                byte[] file = builder.RenderPdf();
                System.IO.File.WriteAllBytes(HttpContext.Current.Server.MapPath("~/Report.pdf"), file);
                Response.AddHeader("Content-Disposition", "attachment; filename=ProspectReport.pdf");
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile("~/Report.pdf");
                // Response.End();
            }

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Reports_ProspectReport.htmlToPdf.Error:" + ex.StackTrace);
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

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Get All Statuses
    /// </summary>
    private void BindAllStatuses()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllStatus(1, 1);// Hard Coded Entity Id & Process Id
            Cls_BinderHelper.BindDropdownList(ddlStatus, "Status", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Reports_ProspectReport.BindAllStatuses.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 July 2013
    /// Description: Get All Sources
    /// </summary>
    private void BindAllSources()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllSources(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlSource, "RefSource", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Reports_ProspectReport.BindAllSources.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Get All Makes
    /// </summary>
    private void BindAllMakes()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllMakes(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlCarMake, "Make", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SearchProspect.BindAllMakes.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 9 July 2013
    /// Description: Get All State
    /// </summary>
    private void BindAllStates()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllState(string.Empty, 1);
            Cls_BinderHelper.BindDropdownList(ddlserState, "StateName", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SearchProspect.BindAllStates.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 Aug 2013
    /// Description: Get All Cities
    /// </summary>
    private void BindAllCities()
    {
        try
        {
            DataTable Dt = objMstBM.GetAllCity(string.Empty, Convert.ToInt64(ddlserState.SelectedValue.Trim()));
            Cls_BinderHelper.BindDropdownList(ddlserCity, "CityName", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Prospects.BindAllCities.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 25 Oct 2013
    /// Description: Save Data To View State
    /// </summary>
    private void saveDataToViewState()
    {
        try
        {
            DataTable Dt = new DataTable();
            Dt = objProspBM.GetAllProspForAdminExport(objProsp);
            if (Dt != null & Dt.Rows.Count > 0)
            {
                Session["TotalRowCount"] = Dt.Rows.Count;
                gvprosp.DataSource = Dt;
                DataTable dtTemp1 = new DataTable();
                dtTemp1 = Dt.Copy();
                dtTemp1.Columns.Add("RowNo");
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    dtTemp1.Rows[i]["RowNo"] = i + 1;
                }
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
