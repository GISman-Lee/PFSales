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
using Mechsoft.GeneralUtilities;

public partial class Claim101 : System.Web.UI.Page
{

    #region Variables

    ILog Logger = LogManager.GetLogger(typeof(Claim101));
    MasterBM objMstBM = new MasterBM();

    #endregion

    #region Page Load

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            Logger.Error("Claim101 Page_Load Error - " + ex.Message);
        }
    }

    #endregion

    #region Events

    protected void lnkbtnClaim101_Click(object sender, EventArgs e)
    {
        try
        {
            BindGrid();

        }
        catch (Exception ex)
        {
            Logger.Error("Claim101 lnkbtnClaim101_Click Error - " + ex.Message);
        }
    }


    #endregion

    #region Methods

    /// <summary>
    /// Created By: Manoj
    /// Created Date: 10 Aug 2013
    /// Description: Bind Grid View Data
    /// </summary>
    private void BindGrid()
    {
        Prospect objProsp = new Prospect();
        ProspectBM objProspBM = new ProspectBM();
        try
        {
            objProsp.FName = string.Empty;
            objProsp.StatusId = 0;
            objProsp.Email = txtEmailId.Text.Trim();
            objProsp.PageIndex = 1;
            objProsp.PageSize = 0;
            DataSet Ds = objProspBM.GetAllProspects(objProsp);
            if (Ds != null && Ds.Tables.Count > 0)
            {
                DataTable Dt = Ds.Tables[0];
                if (Dt != null && Dt.Rows.Count == 1)
                {
                    if (Convert.ToInt32(Dt.Rows[0]["ConsultantId"]) == 0)
                    {
                        // Not allocated. Allocate this lead to logged in consultant.
                        objProsp.ProspId = Convert.ToInt64(Dt.Rows[0]["Id"].ToString().Trim());
                        objProsp.ConsultId = BasePage.UserSession.VirtualRoleId;
                        objProsp.CreatedById = BasePage.UserSession.VirtualRoleId;
                        Int64 Result = objProspBM.AllocateLeadThroughClaim(objProsp);
                        if (Result > 0)
                        {
                            lblSerSucMsg.Text = Resources.PFSalesResource.Belowleadallocatedtoyou.Trim();
                            lblSerErrMsg.Text = string.Empty;
                            dvaserSuccess.Visible = true;
                            dvsererror.Visible = false;
                            SendMail(BasePage.UserSession.UserEmail, BasePage.UserSession.FName);
                            Ds = objProspBM.GetAllProspects(objProsp);
                            if (Ds != null && Ds.Tables.Count > 0)
                            {
                                Dt = Ds.Tables[0];
                                if (Dt != null && Dt.Rows.Count > 0)
                                {
                                    SendProspectMail(Dt.Rows[0]["EmailId"].ToString().Trim(), Dt.Rows[0]["Name"].ToString().Trim(), Dt.Rows[0]["ConsultantFName"].ToString().Trim(), Dt.Rows[0]["ConsultantPhone"].ToString().Trim() + " " + Dt.Rows[0]["PhoneExt"].ToString().Trim(), Dt.Rows[0]["ConsultantEmail"].ToString().Trim(), Dt.Rows[0]["LeadEnquiryDate"].ToString().Trim());
                                    gvprosp.DataSource = Dt;
                                    gvprosp.DataBind();
                                }
                            }
                        }
                    }
                    else if (Convert.ToInt32(Dt.Rows[0]["ConsultantId"]) > 0)
                    {
                        // Display the record in grid viw and show msg already allocatred 
                        // Bcoz virtual role ID equal to Consultant id for consultant only
                        if (Convert.ToInt32(Dt.Rows[0]["ConsultantId"]) == BasePage.UserSession.VirtualRoleId)
                        {
                            lblSerSucMsg.Text = Resources.PFSalesResource.Thisleadalreadyalloctoyou.Trim();
                            lblSerErrMsg.Text = string.Empty;
                            dvaserSuccess.Visible = true;
                            dvsererror.Visible = false;
                            gvprosp.DataSource = Dt;
                            gvprosp.DataBind();
                        }
                        else
                        {
                            // mail to markellis@privatefleet.com.au
                            lblSerSucMsg.Text = string.Empty;
                            lblSerErrMsg.Text = Resources.PFSalesResource.Thisleadalreadyassign.Trim();
                            dvaserSuccess.Visible = false;
                            dvsererror.Visible = true;
                            sendMailToArkellis(Dt);
                        }
                    }
                }
                else if (Dt == null || Dt.Rows.Count == 0)
                {
                    lblSerSucMsg.Text = string.Empty;
                    Session["EmailFromClaim101"] = txtEmailId.Text.Trim();
                    lblSerErrMsg.Text = "Client is not recorded in the system. Please " + "<b><a href='AddProspects.aspx'>click here</a></b>" + " to add a new contact";
                    dvaserSuccess.Visible = false;
                    dvsererror.Visible = true;
                    gvprosp.DataSource = null;
                    gvprosp.DataBind();
                }
                else if (Dt != null & Dt.Rows.Count > 0)
                {
                    gvprosp.DataSource = Dt;
                    gvprosp.DataBind();
                }
                else
                {
                    gvprosp.DataSource = null;
                    gvprosp.DataBind();
                }
            }
            txtEmailId.Text = string.Empty;
        }
        catch (Exception ex)
        {
            Logger.Error("Claim101 BindGrid Error - " + ex.Message);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 23 May 2013
    /// Description: Clear All Message's Text
    /// </summary>
    private void ClearMsg()
    {
        lblSerErrMsg.Text = lblSerSucMsg.Text = string.Empty;
        dvaserSuccess.Visible = dvsererror.Visible = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 14 June 2013
    /// Description: Send Email To Consultant 
    /// </summary>
    /// <param name="emilToId"></param>
    /// <param name="Name"></param>
    /// <returns></returns>
    private Boolean SendMail(string emilToId, string ConsultantName)
    {
        string FileContent = string.Empty;
        Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
        try
        {
            objEmailHelper.EmailSubject = "Lead Assignment";
            objEmailHelper.EmailToID = emilToId;
            FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear " + ConsultantName.Trim() + ",<br /><br /> Please be advised that leads have been allocated.<br /><br /> Thanks you<br /> Quotacon</span>";
            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBM.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), "EMail sent successfully", "Lead Assignment", "Claim 101");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Lead Assignment", "Claim 101");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Claim101.SendMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Lead Assignment", "Claim 101");
            return false;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 14 June 2013
    /// Description: Send Email To Prospects 
    /// </summary>
    /// <param name="emilToId"></param>
    /// <param name="Name"></param>
    /// <param name="ConsultantName"></param>
    /// <param name="ConsultMobile"></param>
    /// <param name="ConsultEmail"></param>
    /// <param name="EnquiryDate"></param>
    /// <returns></returns>
    private Boolean SendProspectMail(string emilToId, string ProspectName, string ConsultantName, string ConsultPhone, string ConsultEmail, string EnquiryDate)
    {
        Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
        string FileContent = string.Empty;
        try
        {
            objEmailHelper.EmailSubject = "Lead Assignment";
            objEmailHelper.EmailToID = emilToId;
            if (!string.IsNullOrEmpty(BasePage.UserSession.UserEmail))
                objEmailHelper.EmailFromID = BasePage.UserSession.UserEmail;
            FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear " + ProspectName.Trim() + ",<br /><br /> With reference to your enquiry made on " + EnquiryDate.Trim() + " here we have asigned a consultant for you. Please find the consultant's details as given below<br /><br /><b>&nbsp;&nbsp; Name: </b>" + ConsultantName.Trim() + "<br/><b>&nbsp;&nbsp; Phone No.: </b>" + ConsultPhone.Trim() + "<br/><b>&nbsp;&nbsp; Email: </b>" + ConsultEmail.Trim() + "<br/><br/>Regards <br /> PF Sales</span>";
            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBM.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), "EMail sent successfully", "Lead Assignment", "Claim 101");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Lead Assignment", "Claim 101");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Claim101.SendProspectMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Lead Assignment", "Claim 101");
            return false;
        }
    }

    private Boolean sendMailToArkellis(DataTable dtTemp)
    {
        Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
        string FileContent = string.Empty;
        try
        {
            objEmailHelper.EmailSubject = "Claim 101";
            objEmailHelper.EmailToID = "markellis@privatefleet.com.au";
            FileContent = "<span style='font-family:Calibri;font-size:14px;color:#1E4996;'>Dear Mark Ellis, <br /><br /> Please check below lead which have two competing consultent.<br /> Lead Name - " + dtTemp.Rows[0]["Name"].ToString().Trim() + "<br/> Lead Email - " + dtTemp.Rows[0]["EmailId"].ToString().Trim() + "<br/> Consultant 1 - " + dtTemp.Rows[0]["Consultant"].ToString().Trim() + "<br/> Consultant 2 - " + BasePage.UserSession.FName + "<br /><br /> Thanks you<br /> PF Sales Team</span>";
            objEmailHelper.EmailBody = FileContent;
            if (objEmailHelper.SendEmail().ToLower().Contains("success"))
            {
                objMstBM.SaveEmailDetails("markellis@privatefleet.com.au", objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), "EMail sent successfully", "Claim 101", "Claim 101");
                return true;
            }
            else
            {
                objMstBM.SaveEmailDetails("markellis@privatefleet.com.au", objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Claim 101", "Claim 101");
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "Claim101.SendMail.Error:" + ex.StackTrace);
            objMstBM.SaveEmailDetails("markellis@privatefleet.com.au", objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Claim 101", "Claim 101");
            return false;
        }
    }

    #endregion
}
