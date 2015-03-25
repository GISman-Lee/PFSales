using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Mechsoft.GeneralUtilities;
using AccessControlUnit;
using System.Xml;
using Mechsoft.PFSales.BusinessManager;
using System.Reflection;

public partial class PageAccess : BasePage
{
    //MasterManager objManager = new MasterManager();
    //ManageRole objRole = new ManageRole();
    MasterBM objMstBM = new MasterBM();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.DefaultButton = lnkbtnSearch.UniqueID;
        if (!IsPostBack)
        {
            tvSHAvailable.Attributes.Add("onclick", "OnTreeClick(event)");
            FillRoles();
        }
    }

    protected void lnkSearch_Click(object sender, EventArgs e)
    {
        pnlDisp.Visible = true;
        dvaserSuccess.Visible = false;
        lblSerSucMsg.Text = string.Empty;
    }

    protected void lnkClear_Click(object sender, EventArgs e)
    {
        pnlDisp.Visible = false;
        ddlRole.SelectedValue = "0";
        dvaserSuccess.Visible = false;
        lblSerSucMsg.Text = string.Empty;
    }

    private void FillRoles()
    {
        //objRole.RoleId = 0;
        //objRole.RoleName = "";
        //DataTable dtRoles = objManager.GetRoleList(objRole);
        //Cls_BinderHelper.BindDropdownList(ddlRole, "Role", "RoleId", dtRoles);
        try
        {
            DataTable Dt = objMstBM.GetAllRoles(string.Empty);
            Cls_BinderHelper.BindDropdownList(ddlRole, "Role", "RoleId", Dt);
        }
        catch (Exception ex)
        {

        }
    }

    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillTree(Convert.ToInt32(ddlRole.SelectedValue));
        pnlDisp.Visible = true;
        dvaserSuccess.Visible = false;
        lblSerSucMsg.Text = string.Empty;
    }

    public void FillTree(Int32 RoleId)
    {
        //lblSavemsg.Text = "";

        Cls_Page objPage = new Cls_Page();
        Cls_PageActionDetails objMapping = new Cls_PageActionDetails();

        DataSet ds = new DataSet();
        DataTable dtParent = null;
        DataTable dtChild = null;
        DataTable dtChild1 = null;
        DataTable dtActions = null;
        DataTable dtActAccess = null;

        try
        {
            Cls_Access objAccess = new Cls_Access();
            Cls_ActionAccess objActAccess = new Cls_ActionAccess();

            objAccess.AccessFor = RoleId;// Convert.ToInt32(ddlRoles.SelectedValue);
            objAccess.AccessTypeId = 1;
            DataTable dtAccess = objAccess.GetPageAccess();

            tvSHAvailable.Visible = true;
            DataTable dtPages = objPage.GetAllActivePages();
            DataView dV = dtPages.DefaultView;
            dV.Sort = string.Format("{0} {1}", "DisplayOrder", "asc");
            Session["AllActivePages"] = dtPages;
            DataView dv = dtPages.DefaultView;

            //Add datatable containing parent menu items
            dv.RowFilter = "ParentID = 0";
            ds.Tables.Add(dv.ToTable());

            //Add datatable containing child menu items
            dv = dtPages.DefaultView;
            dv.RowFilter = "ParentID <> 0";
            ds.Tables.Add(dv.ToTable());

            ////Add datatable containing child menu items
            //dv = dtPages.DefaultView;
            //dv.RowFilter = "ParentID <> 0 AND PageUrl ";
            //ds.Tables.Add(dv.ToTable());

            //clear existing items
            tvSHAvailable.Nodes.Clear();

            dtParent = ds.Tables[0];
            foreach (DataRow dr in dtParent.Rows)
            {
                //Add parent node to treeview
                TreeNode rootNode = new TreeNode();

                rootNode.Text = dr["PageName"].ToString();
                rootNode.Value = dr["ID"].ToString();
                rootNode.NavigateUrl = "";

                //check if logged in user-role has access to this node or not
                DataView dvAccess = dtAccess.DefaultView;
                dvAccess.RowFilter = "ID = " + rootNode.Value;
                if (dvAccess.ToTable().Rows.Count > 0)
                    rootNode.Checked = true;
                else
                    rootNode.Checked = false;
                if (RoleId == 1 && rootNode.Text.ToUpper() == "ROLE MANAGEMENT")
                {
                    rootNode.Checked = true;
                    rootNode.SelectAction = TreeNodeSelectAction.None;
                    rootNode.ShowCheckBox = false;
                }

                //Get datatable containing child pages for this root node
                dv = ds.Tables[1].DefaultView;
                dv.RowFilter = "ParentID = " + rootNode.Value;
                dtChild = dv.ToTable();

                foreach (DataRow drChild in dtChild.Rows)
                {
                    dtActAccess = null;

                    TreeNode childNode = new TreeNode();
                    childNode.Text = drChild["PageName"].ToString();
                    childNode.Value = drChild["ID"].ToString();
                    childNode.NavigateUrl = "";

                    childNode.Checked = false;
                    if (dtAccess != null)
                    {
                        //check if logged in user-role has access to this node or not
                        dvAccess = dtAccess.DefaultView;
                        dvAccess.RowFilter = "ID = " + childNode.Value;
                        if (dvAccess.ToTable().Rows.Count > 0)
                        {
                            childNode.Checked = true;
                            //get action access information
                            objActAccess.AccessId = Convert.ToInt32(dvAccess.ToTable().Rows[0]["AccessID"]);
                            dtActAccess = objActAccess.GetActionAccess();

                        }
                    }
                    if (RoleId == 1 && childNode.Text.ToUpper() == "PAGE ACCESS")
                    {
                        childNode.Checked = true;
                        childNode.SelectAction = TreeNodeSelectAction.None;
                        childNode.ShowCheckBox = false;
                    }
                    // *** Added by pravin *** //
                    //Get datatable containing child pages for this root node
                    dv = ds.Tables[1].DefaultView;
                    dv.RowFilter = "ParentID = " + childNode.Value;
                    dtChild1 = dv.ToTable();

                    foreach (DataRow drChild1 in dtChild1.Rows)
                    {
                        dtActAccess = null;

                        TreeNode childNode1 = new TreeNode();
                        childNode1.Text = drChild1["PageName"].ToString();
                        childNode1.Value = drChild1["ID"].ToString();
                        childNode1.NavigateUrl = "";

                        childNode1.Checked = false;
                        if (dtAccess != null)
                        {
                            //check if logged in user-role has access to this node or not
                            dvAccess = dtAccess.DefaultView;
                            dvAccess.RowFilter = "ID = " + childNode1.Value;
                            if (dvAccess.ToTable().Rows.Count > 0)
                            {
                                childNode1.Checked = true;
                                //get action access information
                                objActAccess.AccessId = Convert.ToInt32(dvAccess.ToTable().Rows[0]["AccessID"]);
                                dtActAccess = objActAccess.GetActionAccess();
                            }
                        }
                        childNode.ChildNodes.Add(childNode1);
                        //Get datatable containing active actions mapped to this page
                        objMapping.PageId = Convert.ToInt32(childNode1.Value);
                        dtActions = objMapping.GetActivePageActions();

                        foreach (DataRow drAction in dtActions.Rows)
                        {
                            TreeNode actionNode = new TreeNode();
                            actionNode.Text = drAction["Action"].ToString();
                            actionNode.Value = drAction["ActionID"].ToString();
                            actionNode.NavigateUrl = "";

                            actionNode.Checked = false;
                            if (dtActAccess != null)
                            {
                                //check if logged in user-role has access to this node or not
                                DataView dvActAccess = dtActAccess.DefaultView;
                                dvActAccess.RowFilter = "ActionID = " + actionNode.Value;
                                if (dvActAccess.ToTable().Rows.Count > 0)
                                    actionNode.Checked = true;
                            }

                            childNode1.ChildNodes.Add(actionNode);

                        }
                    }
                    //*******************************************//

                    rootNode.ChildNodes.Add(childNode);

                    //Get datatable containing active actions mapped to this page
                    objMapping.PageId = Convert.ToInt32(childNode.Value);
                    dtActions = objMapping.GetActivePageActions();

                    foreach (DataRow drAction in dtActions.Rows)
                    {
                        TreeNode actionNode = new TreeNode();
                        actionNode.Text = drAction["Action"].ToString();
                        actionNode.Value = drAction["ActionID"].ToString();
                        actionNode.NavigateUrl = "";

                        actionNode.Checked = false;
                        if (dtActAccess != null)
                        {
                            //check if logged in user-role has access to this node or not
                            DataView dvActAccess = dtActAccess.DefaultView;
                            dvActAccess.RowFilter = "ActionID = " + actionNode.Value;
                            if (dvActAccess.ToTable().Rows.Count > 0)
                                actionNode.Checked = true;
                        }

                        childNode.ChildNodes.Add(actionNode);

                    }
                }
                tvSHAvailable.Nodes.Add(rootNode);
            }
            tvSHAvailable.ExpandAll();
        }
        catch (Exception ex)
        {
            throw new Exception("FillTree Method : " + ex.Message);
        }
        finally
        {
        }
    }

    protected void lnkSave_Click(object sender, EventArgs e)
    {
        SavePageAccessforRole(Convert.ToInt32(ddlRole.SelectedValue));
        UserControl ucHeader = (UserControl)this.Master.FindControl("UC_Header1");
        if (ucHeader != null)
        {
            Session["dtAllPages"] = null;
            MethodInfo methods = ucHeader.GetType().GetMethod("GenerateMenu");
            methods.Invoke(ucHeader, null);
        }
    }

    public void SavePageAccessforRole(Int32 RoleId)
    {
        Cls_Access objAccess = new Cls_Access();

        //build datatable
        DataTable dtSelected = new DataTable();
        dtSelected.Columns.Add("XMLPageID");
        dtSelected.Columns.Add("ActionID");
        DataTable dtAllActivePages = Session["AllActivePages"] as DataTable;
        DataView dv = dtAllActivePages.DefaultView;
        //iterate through parent pages
        foreach (TreeNode rootNode in tvSHAvailable.Nodes)
        {
            if (rootNode.Checked)
            {
                DataRow drParent = dtSelected.NewRow();
                drParent["XMLPageID"] = rootNode.Value;
                drParent["ActionID"] = 0;
                dtSelected.Rows.Add(drParent);
            }
            //if parent page has child pages
            if (rootNode.ChildNodes.Count > 0)
            {
                //iterate through child pages
                foreach (TreeNode childNode in rootNode.ChildNodes)
                {
                    if (childNode.Checked)
                    {
                        DataRow drChild = dtSelected.NewRow();
                        drChild["XMLPageID"] = childNode.Value;
                        drChild["ActionID"] = 0;
                        dtSelected.Rows.Add(drChild);
                    }
                    //if child page has actions
                    if (childNode.ChildNodes.Count > 0)
                    {
                        //iterate through actions
                        foreach (TreeNode childNode1 in childNode.ChildNodes)
                        {
                            if (childNode1.ChildNodes.Count > 0)
                            {
                                foreach (TreeNode actionNode1 in childNode1.ChildNodes)
                                {

                                    if (actionNode1.Checked)
                                    {
                                        DataRow drAction = dtSelected.NewRow();
                                        drAction["XMLPageID"] = childNode1.Value;
                                        drAction["ActionID"] = actionNode1.Value;
                                        dtSelected.Rows.Add(drAction);
                                    }
                                }
                            }
                            else
                            {
                                dv.RowFilter = "ID = " + childNode1.Value + " AND PageName = '" + childNode1.Text.Trim() + "'";
                                if (childNode1.Checked && dv.Count > 0 && !String.IsNullOrEmpty(dv[0]["pageurl"].ToString()))
                                {
                                    DataRow drAction = dtSelected.NewRow();
                                    drAction["XMLPageID"] = childNode1.Value;
                                    drAction["ActionID"] = 0;// childNode1.Value;
                                    dtSelected.Rows.Add(drAction);
                                }
                                else if (childNode1.Checked)
                                {
                                    DataRow drChild = dtSelected.NewRow();
                                    drChild["XMLPageID"] = childNode.Value;
                                    drChild["ActionID"] = childNode1.Value;
                                    dtSelected.Rows.Add(drChild);
                                }
                            }
                        }
                    }
                }
            }
        }
        objAccess.AccessFor = RoleId;
        objAccess.AccessTypeId = 1;
        objAccess.XmlDocument = ConvertDataTableToXML(dtSelected).InnerXml;
        objAccess.SetAccess();
        //ddlRoles_SelectedIndexChanged(null, null);
        Session["datasave"] = "1";
        //lblSavemsg.Text = Resources.SASResource.DataSaved;
        //lblSavemsg.CssClass = "successmsg";
        Session["dtPages"] = null;
        Session["dtPagesAction"] = null;
        lblSerSucMsg.Text = "Saved Successfully";
       
        dvaserSuccess.Visible = true;
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "xvxcvvc", "popup();", true);
        // Response.Redirect("RoleAccess.aspx");
        tvSHAvailable.Focus();
    }

    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        //tvSHAvailable.CheckedNodes = false;

        foreach (TreeNode Node in tvSHAvailable.Nodes)
        {
            Node.Checked = false;
            UncheckChilds(Node);
            dvaserSuccess.Visible = false;
            lblSerSucMsg.Text = string.Empty;
        }

    }

    private void UncheckChilds(TreeNode Node)
    {
        foreach (TreeNode cNode in Node.ChildNodes)
        {
            cNode.Checked = false;
            UncheckChilds(cNode);
        }

    }

    public XmlDocument ConvertDataTableToXML(DataTable dtSelected)
    {

        XmlDocument _XMLDoc = new XmlDocument();

        DataSet ds = new DataSet("Selectedds");
        DataTable dt = new DataTable("Selecteddt");

        dt = dtSelected;
        ds.Tables.Add(dt);

        _XMLDoc.LoadXml(ds.GetXml());
        return _XMLDoc;
    }
}
