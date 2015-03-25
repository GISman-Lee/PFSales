using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mechsoft.PFSales.BusinessManager;
using log4net;
using Mechsoft.PFSales.BusinessEntity;
using Mechsoft.GeneralUtilities;
using System.Data;
using System.Configuration;
using System.IO;

public partial class Resource : BasePage
{
    #region Global Variables
    MasterBM objMstBM = new MasterBM();
    clsMaster objMaster = new clsMaster();
    clsResource ObjResource = new clsResource();
    ILog Logger = LogManager.GetLogger(typeof(Resource));

    DataTable dtDoc = new DataTable();
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = "ReDocName";
            ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION] = Cls_Constant.VIEWSTATE_DESC;
            if (BasePage.UserSession.RoleId == 1)
            {
                grvDocs.Columns[3].Visible = true;
                grvDocs.Columns[4].Visible = true;
                lnkbtnAddSource.Visible = true;
            }

            BindGrid();
            //txtPrSource.Focus();
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Page Index Changing Event Of Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSource_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvDocs.PageIndex = e.NewPageIndex;
            BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ReferalSource.gvSource_PageIndexChanging Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Sorting Event For Grid View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSource_Soring(object sender, GridViewSortEventArgs e)
    {
        try
        {
            ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION] = e.SortExpression;
            DefineSortDirection();
            BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddResource.gvSource_Soring Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Row Data Bound Event Of Prospect Source's GridView
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grvDocs_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    LinkButton lnkBtnDelete = (LinkButton)e.Row.FindControl("lnkbtnDelete");
            //    if (lnkBtnDelete != null)
            //    {
            //        string lblName = ((Label)e.Row.FindControl("lblRefSource")).Text.Trim();
            //        if (lblName != null && !string.IsNullOrEmpty(lblName))
            //            lnkBtnDelete.Attributes.Add("onclick", "javascript:return confirm('" + Resources.PFSalesResource.PrSrcDeleteConfirm.Trim() + " " + lblName + "?')");
            //    }
            //}
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ReferalSource.gvSource_RowDataBound.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Edit Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            ClearMsg();
            Int64 PSId = Convert.ToInt64(((LinkButton)sender).CommandArgument.Trim());
            ViewState["PSId"] = PSId;
            if (PSId > 0)
            {
                fupDocs.Visible = false;
                //lblResrcDoc.Visible = false;
                rfvEmpPhoto.Enabled = false;
                lblResrcDoctxt.Visible = true;
                DataTable dt = objMstBM.GetResrcDetFromId(PSId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtResrcName.Text = dt.Rows[0]["ReDocName"].ToString().Trim();
                    txtDesc.Text = dt.Rows[0]["ReDocDesc"].ToString().Trim();
                    lblResrcDoctxt.Text = dt.Rows[0]["ReDocPath"].ToString().Trim().Replace("~/Documents/Resources/","");
                    //if (dt.Rows[0]["IsFleetTeamLead"].ToString().Trim().ToUpper() == "YES")
                    //    chkIsFleetLead.Checked = true;
                    //else
                    //    chkIsFleetLead.Checked = false;
                    txtResrcName.Focus();
                    lnkbtnSave.Text = Resources.PFSalesResource.update.Trim();
                    lnkbtnSave.ToolTip = Resources.PFSalesResource.UpdateResrc.Trim();
                    lnkbtnFinalClear.Text = Resources.PFSalesResource.Cancel.Trim();
                    lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.BackToSearch.Trim();
                    lblAddSourceHead.Text = Resources.PFSalesResource.UpdateResrc.Trim();
                    pnlAddSource.Visible = true;
                    pnlSearchSource.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ReferalSource.lnkbtnEdit_Click Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Add New Prospect Source Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnAddSource_Click(object sender, EventArgs e)
    {
        try
        {
            pnlAddSource.Visible = true;
            pnlSearchSource.Visible = false;
            ViewState["PSId"] = 0;
            lnkbtnSave.Text = Resources.PFSalesResource.Save.Trim();
            lnkbtnSave.ToolTip = Resources.PFSalesResource.SaveResource.Trim();
            lnkbtnFinalClear.Text = Resources.PFSalesResource.Clear.Trim();
            lnkbtnFinalClear.ToolTip = Resources.PFSalesResource.Clear.Trim();
            lblAddSource.Text = Resources.PFSalesResource.AddResrc.Trim();
            ClearMsg();
            ClearAll();
            txtResrcName.Focus();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ReferalSource.lnkbtnAddSource_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Back To Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnBackToSearch_Click(object sender, EventArgs e)
    {
        ViewState["PSId"] = 0;
        BindGrid();
        pnlSearchSource.Visible = true;
        pnlAddSource.Visible = false;
        ClearMsg();
        txtPrSource.Focus();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Delete Prospect Source Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Int64 PSId = Int64.Parse(((LinkButton)sender).CommandArgument.Trim());
            Int64 Result = 0;
            ObjResource.ResourceId = PSId;
            ObjResource.CreatedById = BasePage.UserSession.VirtualRoleId;
            ObjResource.IsDeleted = true;
            DataTable dt = objMstBM.GetResrcDetFromId(PSId);
            Result = objMstBM.DeleteResource(ObjResource);
            if (Result > 0)
            {
                if (System.IO.File.Exists(Server.MapPath(dt.Rows[0]["ReDocPath"].ToString().Trim())))
                {
                    System.IO.File.Delete(Server.MapPath(dt.Rows[0]["ReDocPath"].ToString().Trim()));
                }
                lblSerSucMsg.Text = Resources.PFSalesResource.RecordDeleted.Trim();
                lblSerErrMsg.Text = string.Empty;
                dvadderror.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                dvaserSuccess.Visible = true;
            }
            else if (Result == -9)
            {
                lblSerErrMsg.Text = Resources.PFSalesResource.refrentialIntegrity.Trim();
                lblSerSucMsg.Text = string.Empty;
                dvaserSuccess.Visible = dvadderror.Visible = dvaddSucc.Visible = false;
                dvsererror.Visible = true;
            }
            else
            {
                lblSerErrMsg.Text = Resources.PFSalesResource.RecordNotDeleted.Trim();
                lblSerSucMsg.Text = string.Empty;
                dvaserSuccess.Visible = dvadderror.Visible = dvaddSucc.Visible = false;
                dvsererror.Visible = true;
            }
            txtResrcName.Focus();
            BindGrid();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ReferalSource.lnkbtnDelete_Click.Error:" + ex.StackTrace);
        }

    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Clear Add Prospect Source Panel Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnFinalClear_Click(object sender, EventArgs e)
    {
        if (ViewState["PSId"] != null && !string.IsNullOrEmpty(ViewState["PSId"].ToString().Trim()) && Convert.ToInt64(ViewState["PSId"].ToString().Trim()) > 0)
        {
            ClearAll();
            pnlAddSource.Visible = false;
            pnlSearchSource.Visible = true;
        }
        else if (ViewState["PSId"] != null && !string.IsNullOrEmpty(ViewState["PSId"].ToString().Trim()) && Convert.ToInt64(ViewState["PSId"].ToString().Trim()) == 0)
            ClearAll();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Clear Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnClear_Click(object sender, EventArgs e)
    {
        txtPrSource.Text = string.Empty;
        txtPrSource.Focus();
        BindGrid();
        ClearMsg();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Button Click Event Of Save Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Int64 Result = 0;
            if (ViewState["PSId"] != null && BasePage.UserSession != null)
            {
                ObjResource.ResourceId = Convert.ToInt32(ViewState["PSId"].ToString().Trim());
                ObjResource.Resource = txtResrcName.Text.Trim();
                ObjResource.Desc = txtDesc.Text.Trim();


                if (ViewState["PSId"].ToString().Trim() == "0")
                {
                    //if (fupDocs.PostedFile.ContentLength > 0)
                    if (fupDocs.HasFile)
                    {
                        int intLastIndexOfDot = 0;
                        string strFileExtension = "";

                        //TODO: logic for file extension check
                        //dtDoc = (DataTable)Session["dtDocFiles"];
                        //DataRow dr = dtDoc.NewRow();

                        string fileExt = System.IO.Path.GetExtension(fupDocs.PostedFile.FileName);

                        byte[] imageBytes = new byte[fupDocs.PostedFile.InputStream.Length];
                        fupDocs.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length);
                        string fileName = System.IO.Path.GetFileName(fupDocs.PostedFile.FileName.ToString());

                        double intBroseFileSizeInKB = fupDocs.PostedFile.ContentLength / 0x400;
                        double dAllowFileSizeLimitInKB = Convert.ToDouble(ConfigurationManager.AppSettings["FileSize"]) * 1024;
                        if (intBroseFileSizeInKB >= dAllowFileSizeLimitInKB)
                        {
                            //Response.Write("<Script>alert(\"Cannot Upload File. Max size allowed is 100 Kb.\");</Script>");
                            lblAddErrMsg.Text = Resources.PFSalesResource.MaxSizeValidation.Trim();
                            dvadderror.Visible = true;
                            return;
                        }
                        else
                        {
                            if (!File.Exists(Server.MapPath((ConfigurationManager.AppSettings["ResourceDoc"] + fileName).ToString())))
                            {
                                intLastIndexOfDot = fileName.LastIndexOf(".");
                                strFileExtension = fileName.Substring(intLastIndexOfDot + 1, fileName.Length - intLastIndexOfDot - 1);
                                string dt = System.DateTime.Now.ToString("ddMMMyyyyhhmmsss");//"{0:F FF FFF FFFF}"
                                //byte[] imageBytes;
                                //imageBytes = (byte[])dtDoc.Rows[i]["fileBytes"];
                                fileName = System.IO.Path.GetFileNameWithoutExtension(fileName) + dt + System.IO.Path.GetExtension(fileName);//Guid.NewGuid()
                                //their is no uploading..just writing out the bytes to the directory on the web server.
                                //System.IO.File.WriteAllBytes(Server.MapPath(string.Format("~/Documents/{0}", fileName)), imageBytes);
                                System.IO.File.WriteAllBytes(Server.MapPath(string.Format(ConfigurationManager.AppSettings["ResourceDoc"] + "{0}", fileName)), imageBytes);

                                ObjResource.CreatedById = BasePage.UserSession.VirtualRoleId;
                                //ObjResource.Resource = txtResrcName.Text.Trim();
                                //ObjResource.Desc = txtDesc.Text.Trim();
                                ObjResource.ResourcePath = ConfigurationManager.AppSettings["ResourceDoc"] + fileName;
                                ObjResource.IsDeleted = false;
                                ObjResource.IsActive = true;
                                ObjResource.ReDocFor = "C";
                            }
                            Result = objMstBM.AddResource(ObjResource);

                            if (Result > 0)
                            {
                                lblSerSucMsg.Text = Resources.PFSalesResource.PrSrcAddedSucc.Trim();
                                lblSerErrMsg.Text = string.Empty;
                                dvadderror.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                                dvaserSuccess.Visible = true;
                                BindGrid();
                                pnlAddSource.Visible = false;
                                pnlSearchSource.Visible = true;
                                txtPrSource.Focus();
                            }
                            else if (Result == -5)
                            {
                                lblAddErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                                lblAddSucMsg.Text = string.Empty;
                                dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                                dvadderror.Visible = true;
                                txtResrcName.Focus();
                            }
                            else
                            {
                                lblAddErrMsg.Text = Resources.PFSalesResource.PrSrcNotAdded.Trim();
                                lblAddSucMsg.Text = string.Empty;
                                dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                                dvadderror.Visible = true;
                                txtResrcName.Focus();
                            }


                        }

                    }


                }
                else
                {
                    ObjResource.ModifiedById = BasePage.UserSession.VirtualRoleId;
                    ObjResource.IsDeleted = false;
                    ObjResource.IsActive = true;
                    ObjResource.ReDocFor = "C";

                    Result = objMstBM.UpdateReource(ObjResource);
                    if (Result > 0)
                    {
                        lblSerSucMsg.Text = Resources.PFSalesResource.PrSrcDeatilsUpdated.Trim();
                        lblSerErrMsg.Text = string.Empty;
                        dvadderror.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvaserSuccess.Visible = true;
                        BindGrid();
                        pnlAddSource.Visible = false;
                        pnlSearchSource.Visible = true;
                        txtPrSource.Focus();
                        rfvEmpPhoto.Enabled = true;
                    }
                    else if (Result == -5)
                    {
                        lblAddErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                        lblAddSucMsg.Text = string.Empty;
                        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvadderror.Visible = true;
                        txtResrcName.Focus();
                    }
                    else
                    {
                        lblAddErrMsg.Text = Resources.PFSalesResource.PrSrcDeatilsNotUpdated.Trim();
                        lblAddSucMsg.Text = string.Empty;
                        dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
                        dvadderror.Visible = true;
                        txtResrcName.Focus();
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ReferalSource.lnkbtnSave_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 June 2013
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
                grvDocs.PageSize = intAllCount;
            }
            else
            {
                grvDocs.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue.Trim());
            }
            BindGrid();
            ClearMsg();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ReferalSource.ddlPageSize_SelectedIndexChanged.Error:" + ex.StackTrace);
        }
    }


    /// <summary>
    /// Created By: Ayyaj Mujawar   
    /// Created Date: 01 April 2014
    /// Description:Download Added File From List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnDownload_Click(object sender, EventArgs e)
    {

        //try
        //{
        //    dtDoc = (DataTable)Session["dtDocFiles"];

        //    foreach (DataRow dr in dtDoc.Rows)
        //    {
        //        //Int64 RequestId =

        string FilePath = ((LinkButton)sender).CommandArgument.ToString().Trim();

        if (File.Exists(Server.MapPath(FilePath.ToString().Trim())))
        {
            DownloadFile(FilePath.ToString());
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, Page.GetType(), "21", "Javascript:alert('Please first save documnet & then download it')", true);
        }



        //    }
        //    Session["dtDocFiles"] = dtDoc;
        //    this.bindGridDoc();
        //    //lblCurrentFileCount.Text = "Current Files To Upload: " + dsPhotosFiles.Tables[0].Rows.Count;
        //}
        //catch (Exception ex)
        //{

        //    Logger.Error(ex.Message + MethodBase.GetCurrentMethod().ToString() + ".Error:" + ex.StackTrace);
        //}

    }

    protected void btnUploadFiles_Click(object sender, EventArgs e)
    {

        //try
        //{
        //    Int64 Result = 0;
        //    int count_suc = 0;
        //    int count_uns = 0;

        //    dtDoc = (DataTable)Session["dtDocFiles"];
        //    int intLastIndexOfDot = 0;
        //    string strFileExtension = "";
        //    for (int i = 0; i < dtDoc.Rows.Count; i++)
        //    {
        //        //TODO:logic to save image path and description to database

        //        string fileName = System.IO.Path.GetFileName(dtDoc.Rows[i]["filePath"].ToString());
        //        intLastIndexOfDot = fileName.LastIndexOf(".");
        //        strFileExtension = fileName.Substring(intLastIndexOfDot + 1, fileName.Length - intLastIndexOfDot - 1);

        //        byte[] imageBytes;
        //        imageBytes = (byte[])dtDoc.Rows[i]["fileBytes"];
        //        fileName = System.IO.Path.GetFileNameWithoutExtension(fileName) + Guid.NewGuid() + System.IO.Path.GetExtension(fileName);
        //        //their is no uploading..just writing out the bytes to the directory on the web server.
        //        //System.IO.File.WriteAllBytes(Server.MapPath(string.Format("~/Documents/{0}", fileName)), imageBytes);
        //        System.IO.File.WriteAllBytes(Server.MapPath(string.Format(ConfigurationManager.AppSettings["OrderDoc"] + "{0}", fileName)), imageBytes);
        //        objOrderDoc.ProspectId = Convert.ToInt64(ViewState["ProspectId"].ToString().Trim());
        //        objOrderDoc.DocName = fileName;
        //        objOrderDoc.DocPath = ConfigurationManager.AppSettings["OrderDoc"] + fileName;
        //        objOrderDoc.IsActive = true;
        //        objOrderDoc.CreatedById = BasePage.UserSession.VirtualRoleId;
        //        objOrderDoc.ModifiedById = BasePage.UserSession.VirtualRoleId;
        //        objOrderDoc.DocFor = "O";
        //        Result = objOrdersBM.AddDoc(objOrderDoc);
        //        if (Result > 0)
        //        {
        //            count_suc = count_suc + 1;


        //        }
        //        else
        //        {
        //            count_uns = count_uns + 1;

        //        }

        //        if (count_uns > 0)
        //        {
        //            lblAddErrMsg.Text = count_uns + " Documents not updated";
        //            lblAddSucMsg.Text = string.Empty;
        //            dvaserSuccess.Visible = dvaddSucc.Visible = dvsererror.Visible = false;
        //            dvadderror.Visible = true;
        //            //txtAddName.Focus();
        //            ddlTitle.Focus();
        //        }

        //    }

        //    //TODO: show success message logic

        //    //clear out rows of dataset not the whole dataset
        //    dtDoc.Rows.Clear();
        //    this.bindGridDoc();
        //    //lblCurrentFileCount.Text = "Current Files To Upload: " + "0";

        //}
        //catch (Exception ex)
        //{
        //    //TODO: show error message of which file did not get uploaded
        //    throw new Exception(ex.Message);
        //}

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
            DataTable Dt = objMstBM.GetAllResource(txtPrSource.Text.Trim());
            if (Dt != null & Dt.Rows.Count > 0)
            {
                DataView dV = Dt.DefaultView;
                dV.Sort = string.Format("{0} {1}", ViewState[Cls_Constant.VIEWSTATE_SORTEXPRESSION].ToString(), ViewState[Cls_Constant.VIEWSTATE_SORTDIRECTION].ToString());
                grvDocs.DataSource = Dt;
                ViewState["TotalCount"] = Dt.Rows.Count;
                grvDocs.DataBind();
            }
            else
            {
                grvDocs.DataSource = null;
                grvDocs.DataBind();
                ViewState["TotalCount"] = "0";
            }

        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "AddEmployee.BindGrid.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Crearted By:Pravin Gholap
    /// Created Date:10 June 2013
    /// Description:Define the sort direction for sorting the grid view
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
            Logger.Error(ex.Message + "AddEmployee.DefineSortDirection.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Clear Add Employee Panel
    /// </summary>
    private void ClearAll()
    {
        txtResrcName.Text = txtDesc.Text = string.Empty;
        //chkIsFleetLead.Checked = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 10 June 2013
    /// Description: Clear All Message's Text
    /// </summary>
    private void ClearMsg()
    {
        lblAddErrMsg.Text = lblAddSucMsg.Text = lblSerErrMsg.Text = lblSerSucMsg.Text = string.Empty;
        dvadderror.Visible = dvaddSucc.Visible = dvaserSuccess.Visible = dvsererror.Visible = false;
    }



    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date: 10 Oct 2014
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
            //HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }

    /// <summary>
    /// Created By: Ayyaj Mujawar
    /// Created Date: 10 Oct 2014
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
    #endregion
}
