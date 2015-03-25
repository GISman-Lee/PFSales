using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mechsoft.PFSales.BusinessEntity;
using Mechsoft.PFSales.BusinessManager;
using log4net;
using System.IO;
using System.Configuration;
using System.Data;
using Mechsoft.GeneralUtilities;
using System.Reflection;

public partial class UserControls_UC_ClearActivity : System.Web.UI.UserControl
{

    #region Global Variables
    ActivityBM objActivityBM = new ActivityBM();
    ClearActivity objclrActivity = new ClearActivity();
    MasterBM objMstBM = new MasterBM();
    ILog Logger = LogManager.GetLogger(typeof(UserControls_UC_ClearActivity));
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindAllStatuses();
            BindActStatuses(2);
            Page.MaintainScrollPositionOnPostBack = true;
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
        }
        ScriptManager.GetCurrent(Page).RegisterPostBackControl(lnkbtnclrSaveAct);
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 July 2013
    /// Description: Clear controls in the pop up of clearing the activity
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnclrSaveAct_Click(object sender, EventArgs e)
    {
        try
        {
            Page.Validate("ClearActt");
            if (Page.IsValid)
            {
                objclrActivity.Id = 0;
                objclrActivity.ActivityId = Convert.ToInt64(hdfclrActId.Value.Trim());
                objclrActivity.ProspectId = Convert.ToInt64(hdfclrActProsp.Value.Trim());
                objclrActivity.Remark = txtclrRemark.Text.Trim();
                SaveActDoc(fpclrAttachment);
                objclrActivity.FilePath = hdfActivityDoc.Value.Trim();
                if (ddlclrStatus.SelectedValue.Trim() != "0")
                    objclrActivity.Status = Convert.ToInt32(ddlclrStatus.SelectedValue.Trim());
                objclrActivity.ActStatus = Convert.ToInt32(ddlclrActStatus.SelectedValue.Trim());
                objclrActivity.CreatedById = BasePage.UserSession.VirtualRoleId;
                objclrActivity.IsDeleted = false;
                Int64 Result = 0;
                Result = objActivityBM.AddClearActivity(objclrActivity);

                System.Web.UI.Control divSuc = (System.Web.UI.Control)this.Parent.FindControl("dvaserSuccess");
                Label lblSuc = (Label)(System.Web.UI.Control)this.Parent.FindControl("lblSerSucMsg");
                System.Web.UI.Control divErr = (System.Web.UI.Control)this.Parent.FindControl("dvsererror");
                Label lblErr = (Label)(System.Web.UI.Control)this.Parent.FindControl("lblSerErrMsg");


                if (Result > 0)
                {
                    //lblclrSerSucMsg.Text = Resources.PFSalesResource.ActivityCleared.Trim();
                    //dvclrserSuccess.Visible = true;
                    //lblclrSerErrMsg.Text = string.Empty;
                    //dvclrsererror.Visible = false;

                    lblSuc.Text = Resources.PFSalesResource.ActivityCleared.Trim();
                    divSuc.Visible = true;
                    lblErr.Text = string.Empty;
                    divErr.Visible = false;
                }
                else if (Result == -5)
                {
                    //lblclrSerErrMsg.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                    //dvclrserSuccess.Visible = false;
                    //lblclrSerSucMsg.Text = string.Empty;
                    //dvclrsererror.Visible = true;

                    lblErr.Text = Resources.PFSalesResource.RecordAlreadyExist.Trim();
                    divSuc.Visible = false;
                    lblSuc.Text = string.Empty;
                    divErr.Visible = true;
                }
                else
                {
                    //lblclrSerErrMsg.Text = Resources.PFSalesResource.ActivityNotCleared.Trim();
                    //dvclrserSuccess.Visible = false;
                    //lblclrSerSucMsg.Text = string.Empty;
                    //dvclrsererror.Visible = true;

                    lblErr.Text = Resources.PFSalesResource.ActivityNotCleared.Trim();
                    divSuc.Visible = false;
                    lblSuc.Text = string.Empty;
                    divErr.Visible = true;
                }
                System.Web.UI.WebControls.Panel pnlToHide = null;
                Control ctl = this.Parent;
                while (true)
                {
                    pnlToHide = (System.Web.UI.WebControls.Panel)ctl.FindControl("pnlClearAct");
                    if (pnlToHide == null)
                    {
                        if (ctl.Parent == null)
                        {
                            return;
                        }
                        ctl = ctl.Parent;
                        continue;
                    }
                    break;
                }
                pnlToHide.Visible = false;



                MethodInfo methods1 = (this.Parent.Parent.Page).GetType().GetMethod("BindMangeActivity");// ((Page)this.Parent).GetType().GetMethod("BindMangeActivity");
                if (methods1 != null)
                {
                    object[] objParam = new object[] { Convert.ToInt64(hdfclrActProsp.Value.Trim()) };
                    methods1.Invoke((this.Parent.Parent.Page), objParam);
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SearchProspect.lnkbtnclrSaveAct_Click.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 July 2013
    /// Description: Clear controls in the pop up of clearing the activity
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnclrCancel_Click(object sender, EventArgs e)
    {
        ddlclrActStatus.SelectedValue = ddlclrStatus.SelectedValue = "0";
        txtclrRemark.Text = string.Empty;
    }
    #endregion

    #region Methods

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 May 2013
    /// Description: Save Employees Photo
    /// </summary>
    public void SaveActDoc(FileUpload fpattachment)
    {
        try
        {

            if (fpattachment.HasFile)
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
                double intBroseFileSizeInKB = fpattachment.PostedFile.ContentLength / 0x400;
                double dAllowFileSizeLimitInKB = Convert.ToDouble(ConfigurationManager.AppSettings["FileSize"]) * 1024;
                if (intBroseFileSizeInKB >= dAllowFileSizeLimitInKB)
                {
                    //Response.Write("<Script>alert(\"Cannot Upload File. Max size allowed is 100 Kb.\");</Script>");
                    lblclrSerErrMsg.Text = Resources.PFSalesResource.MaxSizeValidation.Trim();
                    dvclrsererror.Visible = true;
                    return;
                }
                //Allowed File Extentions
                intLastIndexOfDot = fpattachment.FileName.LastIndexOf(".");
                strFileExtension = fpattachment.FileName.Substring(intLastIndexOfDot + 1, fpattachment.FileName.Length - intLastIndexOfDot - 1);
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
                string strFileName = System.IO.Path.GetFileNameWithoutExtension(fpattachment.PostedFile.FileName) + Guid.NewGuid() + System.IO.Path.GetExtension(fpattachment.PostedFile.FileName);
                fpattachment.PostedFile.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["ActivityDoc"]) + strFileName);
                //After u[dating show photo in image.
                hdfActivityDoc.Value = ConfigurationManager.AppSettings["ActivityDoc"] + strFileName;
                //lnkbtnRemove.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "ActivityCallendar.BindDesignations.SavePhoto.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 3 July 2013
    /// Description: Get Activity Statuses
    /// </summary>
    /// <param name="ProsessId"></param>
    public void BindActStatuses(Int16 ProsessId)
    {
        try
        {
            DataTable Dt = objMstBM.GetAllStatus(2, ProsessId);// Hard Coded Entity Id & Process Id
            Cls_BinderHelper.BindDropdownList(ddlclrActStatus, "Status", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SearchProspect.BindAllStatuses.Error:" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 6 July 2013
    /// Description: Get Activity Statuses
    /// </summary>
    public void ClearAll()
    {
        dvclrsererror.Visible = dvclrserSuccess.Visible = false;
        lblclrSerErrMsg.Text = lblclrSerSucMsg.Text = string.Empty;
        ddlclrActStatus.SelectedValue = ddlclrStatus.SelectedValue = "0";
        txtclrRemark.Text = string.Empty;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 6 July 2013
    /// Description: Bind Clear Activity Data
    /// </summary>
    public void BindClearData(string prospectName, HiddenField hdfManProspStatusId)
    {
        try
        {
            DataTable Dt = objActivityBM.GetActivityDetFromId(Convert.ToInt64(hdfclrActId.Value.Trim()), BasePage.UserSession.VirtualRoleId);
            if (Dt != null && Dt.Rows.Count > 0)
            {
                switch (Convert.ToInt16(Dt.Rows[0]["ActivityTypeId"].ToString().Trim()))
                {
                    case 1:
                        BindActStatuses(2);
                        break;
                    //case 2:
                    //    BindActStatuses(3);
                    //    break;
                    //case 3:
                    //    BindActStatuses(4);
                    //    break;
                    //case 4:
                    //    BindActStatuses(5);
                    //    break;
                    //case 5:
                    //    BindActStatuses(6);
                    //    break;
                }
                lblclrActProspect.Text = prospectName.Trim();
                lblclrActType.Text = Dt.Rows[0]["ActivityType"].ToString().Trim();
                lblActReg.Text = Dt.Rows[0]["name"].ToString().Trim();
                lblActPrio.Text = Dt.Rows[0]["Priority"].ToString().Trim();
                lblclrStartDate.Text = Convert.ToDateTime(Dt.Rows[0]["start"].ToString().Trim()).ToString("g").Substring(0, 10);
                lblclrStartTime.Text = Dt.Rows[0]["start"].ToString().Trim().Substring(11, 5);
                lblclrEndDate.Text = Convert.ToDateTime(Dt.Rows[0]["end"].ToString().Trim()).ToString("g").Substring(0, 10);
                lblclrEndTime.Text = Dt.Rows[0]["end"].ToString().Trim().Substring(11, 5);
                lblclrLocation.Text = Dt.Rows[0]["Location"].ToString().Trim();
                //if (!string.IsNullOrEmpty(hdfManProspStatusId.Value.Trim()))
                //{
                //    ListItem selectedclrStatus = ddlclrStatus.Items.FindByValue(hdfManProspStatusId.Value.Trim());
                //    if (selectedclrStatus != null)
                //        selectedclrStatus.Selected = true;
                ddlclrStatus.SelectedValue = hdfManProspStatusId.Value.Trim();
                //}
                ddlclrActStatus.Focus();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SearchProspect.BindAllStatuses.Error:" + ex.StackTrace);
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
            Cls_BinderHelper.BindDropdownList(ddlclrStatus, "Status", "Id", Dt);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "SearchProspect.BindAllStatuses.Error:" + ex.StackTrace);
        }
    }
    #endregion
}
