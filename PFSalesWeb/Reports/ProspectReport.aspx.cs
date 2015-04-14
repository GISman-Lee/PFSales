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

public partial class Reports_ProspectReport : BasePage
{
    #region Private Variables
    ILog Logger = LogManager.GetLogger(typeof(Reports_ProspectReport));
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = "ActivityType";
            ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;
            BindMyActivities();
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 July 2013
    /// Description: Page Index Changing Event of Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvActivities_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvActivities.PageIndex = e.NewPageIndex;
        BindMyActivities();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 July 2013
    /// Description: Sorting Event of Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvActivities_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = e.SortExpression;
        DefineSortDirection();
        BindMyActivities();
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
        try
        {
            htmlToPdf();
        }
        catch (Exception)
        {

            throw;
        }
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
        try
        {
            ExportToExcelsheet();
        }
        catch (Exception)
        {

            throw;
        }
    }
    #endregion

    #region Methods
    private void BindMyActivities()
    {
        try
        {
            //DataTable dtACtivities = objActManager.GetMyAllActivities(BasePage.UserSession.UserId);
            //if (dtACtivities.Rows.Count > 0)
            //{
            //    DataView dtView = dtACtivities.DefaultView;
            //    dtView.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
            //    gvActivities.DataSource = dtACtivities;
            //    gvActivities.DataBind();
            //    ViewState["MainData"] = dtACtivities;
            //}
            //else
            //{
            //    gvActivities.DataSource = null;
            //    gvActivities.DataBind();
            //}
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void ExportToExcelsheet()
    {
        try
        {
            HttpContext context = HttpContext.Current;
            if (ViewState["MainData"] != null)
            {

                DataTable dt = (DataTable)ViewState["MainData"];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        context.Response.Write(Environment.NewLine);
                        context.Response.Write("\t");

                        foreach (DataColumn column in dt.Columns)
                        {
                            context.Response.Write(column.ColumnName + "\t");
                        }
                        context.Response.Write(Environment.NewLine);

                        foreach (DataRow row in dt.Rows)
                        {
                            context.Response.Write("\t");
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                context.Response.Write(row[i].ToString() + "\t");
                            }

                            context.Response.Write(Environment.NewLine);
                        }
                    }
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", "attachment;filename=MyActivities");
                    context.Response.End();
                    context.Response.Clear();
                }
            
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + ". Error" + ex.StackTrace);
        }
    }
    /// <summary>
    /// Created By: Jagruti Thoke
    /// Created Date: 10 May 2012
    /// Description: htmlToPdf
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
                        first.AppendHtml("<td><h4>");
                        first.AppendHtml(dt.Columns[i].ToString() + "</h4></td>");
                    }
                    first.AppendHtml("</tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        first.AppendHtml("<tr>");
                        foreach (DataColumn col in dt.Columns)
                        {
                            first.AppendHtml("<td>");
                            first.AppendHtml(row[col].ToString() + "</td>");
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
            Logger.Error(ex.Message + ". Error" + ex.StackTrace);
        }
    }
    /// <summary>
    /// Created By: Jagruti Thoke
    /// Created Date: 10 May 2012
    /// Description: Define The Sort Direction For Sorting Gridview Records
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
        catch (Exception ex) { Logger.Error(ex.Message + ". Error" + ex.StackTrace); }
    }
    #endregion

}
