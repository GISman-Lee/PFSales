using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using System.Data;
using Mechsoft.PFSales.BusinessEntity;
using Mechsoft.PFSales.BusinessManager;
using System.Text;

public partial class User_Controls_UC_Header : System.Web.UI.UserControl
{
    #region Private Variables
    /// <summary>
    /// Created By: Pravin Gholap
    /// Date: 22 May 2013
    /// Description: Declare Private Variables and Create objects of Classes.
    /// </summary>
    ILog Logger = LogManager.GetLogger(typeof(User_Controls_UC_Header));
    MasterBM ObjMstrManager;
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel pnlContentPlace = (Panel)(this.Page.Master).FindControl("pnlContentPlace");
        Panel pnlNoAccess = (Panel)(this.Page.Master).FindControl("pnlNoAccess");
        if (!IsPostBack)
        {
            GenerateMenu();
            //#region Check Page Access

            //String PageUrl = Request.RawUrl;
            //char[] splitArr = { '/' };
            //String[] rowUrl = PageUrl.Split(splitArr, 3);
            //PageUrl = "/" + rowUrl[2];
            //int indexOfQS = PageUrl.LastIndexOf(".aspx?");
            //if (indexOfQS > 0)
            //    PageUrl = PageUrl.Substring(0, indexOfQS + 5);
            //try
            //{
            //    MasterBM ObjMstrManager1 = new MasterBM();
            //    if ((PageUrl.Trim() != "/ViewMyContacts.aspx" && BasePage.UserSession.RoleId == 5) || (PageUrl.Trim() != "/ViewMyContacts.aspx" && BasePage.UserSession.RoleId == 3) || (PageUrl.Trim() != "/LeadAllocation.aspx" && BasePage.UserSession.RoleId == 1))
            //    {
            //        if ((!PageUrl.Trim().Contains("/Prospects.aspx")))//PageUrl.Trim().Contains("/ManageActivities.aspx")
            //        {
            //            if ((!PageUrl.Trim().Contains("/ManageActivities.aspx")))
            //            {
            //                DataSet dsPage = ObjMstrManager1.CheckPageAccess(BasePage.UserSession.RoleId, PageUrl);
            //                Boolean IsValidPage = false;

            //                if (dsPage != null && dsPage.Tables[0] != null && dsPage.Tables[0].Rows.Count > 0)
            //                {
            //                    if (Convert.ToInt64(dsPage.Tables[0].Rows[0][0]) > 0)
            //                        IsValidPage = true;
            //                    else
            //                        IsValidPage = false;
            //                }

            //                if (!IsValidPage)
            //                {
            //                    pnlContentPlace.Visible = false;
            //                    pnlNoAccess.Visible = true;

            //                    return;
            //                }
            //                else
            //                {
            //                    pnlContentPlace.Visible = true;
            //                    pnlNoAccess.Visible = false;
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.Error(ex.Message + "User_Controls_UC_Header ,Page_Load. Check Access.error" + ex.StackTrace);
            //    Response.Redirect("~/UserLogin.aspx", false);
            //}
            //#endregion
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 22 May 2013
    /// Description: Logout Button Click
    /// </summary>
    protected void lnkbtnLogout_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/UserLogin.aspx", false);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "User_Controls_UC_Header ,lnkbtnSignOut_Click.error" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 27 May 2013
    /// Description: Generate Menues According To Access Rights
    /// </summary>
    public void GenerateMenu()
    {
        DataTable dtPages = null;
        try
        {
            Int64 ParentId = 0;
            Int64 RoleId = BasePage.UserSession.RoleId;
            Int64 AccessTypeId = Convert.ToInt64(AccessType.User);

            if (Session["dtAllPages"] == null)
            {
                dtPages = GetPages(ParentId, RoleId, AccessTypeId);
                Session["dtAllPages"] = dtPages;
            }
            else
            {
                dtPages = (DataTable)Session["dtAllPages"];
            }
            // DataTable dt1 = new DataTable();
            //dt1 = dtPages;
            ///dtPages.Merge(dt1, true);
            //for (int i = 0; i < 8;i++ )
            //{
            //    //dt1.NewRow();
            //    dt1.ImportRow(dtPages.Rows[i]);
            //}

            DataTable dtParent = null;
            dvHtmlMenu.InnerHtml = "";
            if (dtPages != null)
            {
                DataView dv = dtPages.DefaultView;
                dv.RowFilter = "IsInternalLink=0 AND ParentID=0";
                dv.Sort = "Displayorder ASC";
                dtParent = dv.ToTable();
            }
            int NoOfSecParents = 0;
            DataTable dtSecParent = null;
            string Completed = "no";
            StringBuilder strMenu = new StringBuilder();


            strMenu.Append("<ul id='headerMenu' class='megamenu'>");
            foreach (DataRow Dr in dtParent.Rows)
            {
                if (Convert.ToString(Dr["PageUrl"]) != "#")
                {
                    if (Convert.ToString(Dr["PageName"]).Trim().ToUpper() == "HOME")
                    {

                        strMenu.Append("<li><a ");
                        if (BasePage.UserSession.RoleId == 3 || BasePage.UserSession.RoleId == 5)
                            strMenu.Append("OnClick='javascript:void(0)' href='" + ResolveUrl("~/" + "/ViewMyContacts.aspx" + "'>"));
                        else if (BasePage.UserSession.RoleId == 1)
                            strMenu.Append("OnClick='javascript:void(0)' href='" + ResolveUrl("~/" + "/LeadAllocation.aspx" + "'>"));
                        else
                            strMenu.Append("OnClick='javascript:void(0)' href='" + ResolveUrl("~/" + "/ViewMyContacts.aspx" + "'>"));
                        strMenu.Append(Convert.ToString(Dr["PageName"]) + "</a>");
                    }
                    else if (Convert.ToString(Dr["PageName"]).Trim().ToUpper() == "CALENDAR")
                    {
                        strMenu.Append("<li><a ");
                        if (BasePage.UserSession.RoleId == 3 || BasePage.UserSession.RoleId == 5)
                        {
                            strMenu.Append("OnClick='javascript:void(0)' href='" + ResolveUrl("~/" + "/ActivityCall.aspx" + "'>"));
                            strMenu.Append("My Calendar" + "</a>");
                        }
                        else if (BasePage.UserSession.RoleId == 1)
                        {
                            strMenu.Append("OnClick='javascript:void(0)' href='" + ResolveUrl("~/" + "/ActivityCall.aspx" + "'>"));
                            strMenu.Append(Convert.ToString(Dr["PageName"]) + "</a>");
                        }
                        else
                        {
                            strMenu.Append("OnClick='javascript:void(0)' href='" + ResolveUrl("~/" + "/ActivityCall.aspx" + "'>"));
                            strMenu.Append(Convert.ToString(Dr["PageName"]) + "</a>");
                        }
                    }
                    else if (Convert.ToString(Dr["PageName"]).Trim().ToUpper() == "MY CONTACTS")
                    {
                        strMenu.Append("<li><a ");
                        if (BasePage.UserSession.RoleId == 3 || BasePage.UserSession.RoleId == 5)
                        {
                            strMenu.Append("OnClick='javascript:void(0)' href='" + ResolveUrl("~/" + "/ViewMyContacts.aspx" + "'>"));
                            strMenu.Append(Convert.ToString(Dr["PageName"]) + "</a>");
                        }
                        else if (BasePage.UserSession.RoleId == 1)
                        {
                            strMenu.Append("OnClick='javascript:void(0)' href='" + ResolveUrl("~/" + "/SearchProspect.aspx" + "'>"));
                            strMenu.Append(Convert.ToString(Dr["PageName"]) + "</a>");
                        }
                        else
                        {
                            strMenu.Append("OnClick='javascript:void(0)' href='" + ResolveUrl("~/" + "/ViewMyContacts.aspx" + "'>"));
                            strMenu.Append(Convert.ToString(Dr["PageName"]) + "</a>");
                        }
                    }
                    else
                    {
                        strMenu.Append("<li><a ");
                        strMenu.Append("OnClick='javascript:void(0)' href='" + ResolveUrl("~/" + Dr["PageUrl"].ToString()) + "'>");
                        strMenu.Append(Convert.ToString(Dr["PageName"]) + "</a>");
                    }
                }
                else
                {
                    strMenu.Append("<li><a ");
                    strMenu.Append("OnClick='javascript:void(0)' href='#'>");
                    strMenu.Append(Convert.ToString(Dr["PageName"]) + "</a>");

                }

                DataView dvSecParent = dtPages.DefaultView;
                dvSecParent.RowFilter = "IsInternalLink=0 AND ParentID=" + Convert.ToString(Dr["ID"]).Trim();
                dvSecParent.Sort = "Displayorder ASC";
                dtSecParent = dvSecParent.ToTable();
                DataTable dtChild = null;
                strMenu.Append("<div style='width: auto;'>");
                if (dtSecParent.Rows.Count > 0)
                {

                    strMenu.Append("<ul class='list-content' style='float: left; padding-right: 10px; width: 176px;'>");
                    strMenu.Append("<li>");
                    strMenu.Append("<ul class='subtab'>");
                    foreach (DataRow SecRow in dtSecParent.Rows)
                    {

                        if (Convert.ToString(SecRow["PageUrl"]).Trim() == "#")
                        {
                            strMenu.Append("<li><a href='");
                            strMenu.Append(ResolveUrl("~/" + Convert.ToString(SecRow["PageUrl"]).Trim()) + "' " + ">" + Convert.ToString(SecRow["PageName"]).Trim() + "</a></li>");
                        }
                        else
                        {
                            if (Convert.ToString(SecRow["PageName"]).Trim().ToUpper() != "MANAGE ACTIVITY")
                            {
                                strMenu.Append("<li><a href='");
                                strMenu.Append(ResolveUrl("~/" + Convert.ToString(SecRow["PageUrl"]).Trim()) + "' " + ">" + Convert.ToString(SecRow["PageName"]).Trim() + "</a></li>");
                            }
                        }

                        //if (SecRow["PageUrl"].ToString() == "#")
                        //{
                        //    NoOfSecParents = NoOfSecParents + 1;
                        //}
                        //if (NoOfSecParents > 1)
                        //{
                        //    if (Completed == "no")
                        //    {
                        //        strMenu.Append("</ul>");
                        //        strMenu.Append("<ul class='list-content' style='border: 0px; float: left; padding-left: 10px;'>");
                        //        Completed = "Yes";
                        //    }
                        //}
                    }
                    strMenu.Append("</ul>");
                    strMenu.Append("</li></ul>");
                    NoOfSecParents = 0;
                    Completed = "no";

                }
                strMenu.Append("</div>");
                strMenu.Append("</li>");
                // strMenu.Append("</li>");
            }
            //LinkButton lnkBtnLogout = new LinkButton();
            //lnkBtnLogout.Text = "Logout";

            //dvHtmlMenu.Controls.Add(lnkBtnLogout);
            strMenu.Append("</ul>");
            strMenu.Append("<div class='logout'><a ID='lnkbtnLogout' runat='server' onclick='fireServerButtonEvent();'>Logout</a></div><div class='clear'></div>");
            //strMenu.Append("<a class='logout' onclick='fireServerButtonEvent();' id='lnkBtnLogOut'>");
            //strMenu.Append("<img id='img' runat=server src='" + ResolveUrl("~/App_Themes/Default/Images/logout.png") + "' alt='LogOut' />");
            //strMenu.Append("</a>");


            dvHtmlMenu.InnerHtml = Convert.ToString(strMenu);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "User_Controls_UC_Header ,GenerateMenu.error" + ex.StackTrace);
            Response.Redirect("~/UserLogin.aspx", false);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 27 May 2013
    /// Description: Generate Menues According To Access Rights
    /// </summary>
    /// <param name="ParentId"></param>
    /// <param name="RoleId"></param>
    /// <param name="AccessTypeId"></param>
    /// <returns></returns>
    private DataTable GetPages(Int64 ParentId, Int64 RoleId, Int64 AccessTypeId)
    {
        DataTable dtSubPage = null;
        ObjMstrManager = new MasterBM();
        dtSubPage = ObjMstrManager.GetMenu(ParentId, RoleId, AccessTypeId);
        return dtSubPage;
    }

    #endregion
}
