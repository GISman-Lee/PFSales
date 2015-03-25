using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using Mechsoft.PFSales.BusinessEntity;
using Mechsoft.PFSales.BusinessManager;
using Mechsoft.GeneralUtilities;
using System.Data;
using System.Data.OleDb;
using iTextSharp.text;

public partial class SchedularReport : BasePage
{
    #region Private Variables
    ILog Logger = LogManager.GetLogger(typeof(SchedularReport));
    Prospect objProsp = new Prospect();
    ProspectBM objProspBM = new ProspectBM();
    MasterBM objMstBM = new MasterBM();
    EmployeeBM objEmpBM = new EmployeeBM();
    ActivityBM objActBM = new ActivityBM();
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.DefaultButton = lnkbtnSearch.UniqueID;
        if (!IsPostBack)
        {
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = "Name";
            ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;
            BindConsultant();
            BindGrid();
            Page.MaintainScrollPositionOnPostBack = true;
            ddlConsultant.Focus();
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 July 2013
    /// Description: Page Index Changing Event of Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvScheduler_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvScheduler.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 July 2013
    /// Description: Sorting Event of Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvScheduler_Soring(object sender, GridViewSortEventArgs e)
    {
        ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = e.SortExpression;
        DefineSortDirection();
        BindGrid();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 July 2013
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
    /// Created Date: 11 July 2013
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
    /// Created Date: 11 July 2013
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
                gvScheduler.PageSize = intAllCount;
            }
            else
            {
                gvScheduler.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue.Trim());
            }
            BindGrid();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SchedularReport.ddlPageSize_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 July 2013
    /// Description: Selected Index Changed Event Of Prospect Status's Drop Down List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlConsultant_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 July 2013
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
    /// Created Date: 11 July 2013
    /// Description: Clear Button Click. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnClear_Click(object sender, EventArgs e)
    {
        ddlConsultant.SelectedValue = "0";
        ddlConsultant.Focus();
        BindGrid();
    }
    #endregion

    #region Methods

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 June 2013
    /// Description: Bind Grid View Data
    /// </summary>
    private void BindGrid()
    {
        try
        {
            DataTable Dt = objActBM.GetUpcomingSchedular(Convert.ToInt64(ddlConsultant.SelectedValue.Trim()));

            if (Dt != null & Dt.Rows.Count > 0)
            {
                DataView dV = Dt.DefaultView;
                dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
                ViewState["MainData"] = gvScheduler.DataSource = Dt;
                gvScheduler.DataBind();
                ViewState["TotalCount"] = Dt.Rows.Count;
            }
            else
            {
                gvScheduler.DataSource = null;
                gvScheduler.DataBind();
                ViewState["TotalCount"] = "0";
            }

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SchedularReport.BindGrid.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 July 2013
    /// Description: Export to excel function.
    /// </summary>
    public void ExportToExcelsheet()
    {
        try
        {
            if (ViewState["MainData"] != null)
            {

                string path = Server.MapPath("Reports") + "\\UpcomingSchedular.xls";
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

                //cmd = new OleDbCommand("UPDATE [Sheet1$] SET F2='" + ((Label)gvScheduler.Rows[0].FindControl("lblCompanyName")).Text + "' WHERE F1='Dealer Company :'", conn);
                //cmd.ExecuteNonQuery();

                //cmd = new OleDbCommand("UPDATE [Sheet1$] SET F2='" + ((Label)gvScheduler.Rows[0].FindControl("lblName")).Text + "' WHERE F1='Contact Name :'", conn);
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
                DataTable dt = (DataTable)ViewState["MainData"];
                int cnt = 3;
                foreach (DataRow dr in dt.Rows)
                {

                    string Name = dr["Name"].ToString().Trim();
                    string ActivityType = dr["Consultant"].ToString().Trim();
                    string StartDateTime = dr["StartDateTime"].ToString().Trim();
                    string ProspName = dr["ProspName"].ToString().Trim();
                    string Status = dr["Status"].ToString().Trim();
                    //Label lblEnquiryDate = (Label)gr.FindControl("lblEnquiryDate");
                    //Label lblprospName = (Label)gr.FindControl("lblprospName");
                    //Label lblstatus = (Label)gr.FindControl("lblstatus");
                    //Label lblMake = (Label)gr.FindControl("lblMake");
                    //Label lblPhone = (Label)gr.FindControl("lblPhone");
                    //Label lblStates = (Label)gr.FindControl("lblStates");
                    //Label lblCity = (Label)gr.FindControl("lblCity");
                    cmd = new OleDbCommand("UPDATE [Sheet1$B" + cnt + ":E" + cnt + "] SET F1='" + Name + "',F2='" + ActivityType + "',F3='" + StartDateTime + "',F4='" + Status + "'", conn);
                    cmd.ExecuteNonQuery();
                    cnt++;
                    // Insert
                    //cmd = new OleDbCommand("INSERT INTO [Sheet1$](F1,F2,F3,F4,F5) VALUES ('" + lblDate.Text + "','" + lblLeadName.Text + "','" + lblStatus.Text + "','" + lblAmount.Text.Substring(1).Trim() + "','" + lblAmountStatus.Text + "')", conn);
                    //cmd.ExecuteNonQuery();
                }

                for (int i = cnt; i < TotalCnt + 3; i++)
                {
                    cmd = new OleDbCommand("UPDATE [Sheet1$B" + i + ":E" + i + "] SET F1='',F2='',F3='',F4=''", conn);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();

                System.IO.FileInfo file = new System.IO.FileInfo(path);

                Response.ContentType = "application/Excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=UpcomingSchedular.xls");
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.WriteFile(file.FullName);
                Response.End();
                Response.Clear();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SchedularReport.BindGrid.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 July 2013
    /// Description: Export to PDF function.
    /// </summary>
    private void htmlToPdf()
    {
        try
        {
            HtmlToPdfBuilder builder = new HtmlToPdfBuilder(PageSize.LETTER);
            HtmlPdfPage first = builder.AddPage();
            DataTable dt = new DataTable();
            if (ViewState["MainData"] != null)
            {
                dt = (DataTable)ViewState["MainData"];
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
                        if (dt.Columns[i].ColumnName.Trim().ToUpper() == "NAME"  || dt.Columns[i].ColumnName.Trim().ToUpper() == "STARTDATETIME" || dt.Columns[i].ColumnName.Trim().ToUpper() == "CONSULTANT" || dt.Columns[i].ColumnName.Trim().ToUpper() == "PHONE")
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
                            if (col.ColumnName.Trim().ToUpper() == "NAME"  || col.ColumnName.Trim().ToUpper() == "STARTDATETIME" || col.ColumnName.Trim().ToUpper() == "CONSULTANT" || col.ColumnName.Trim().ToUpper() == "STATUS")
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
                Response.AddHeader("Content-Disposition", "attachment; filename=UpcomingSchedular.pdf");
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile("~/Report.pdf");
                // Response.End();
            }

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SchedularReport.htmlToPdf.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 July 2013
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
            Logger.Error(ex.Message + "SchedularReport.DefineSortDirection.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 11 July 2013
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
            Logger.Error(ex.Message + "SchedularReport.BindConsultant.Error:" + ex.StackTrace);
        }
    }
    #endregion
}
