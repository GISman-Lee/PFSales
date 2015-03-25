using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using log4net;
using System.Data;
using Mechsoft.PFSales.BusinessEntity;
using Mechsoft.PFSales.BusinessManager;
using Mechsoft.GeneralUtilities;

public partial class ForgotPassword : System.Web.UI.Page
{
    #region Private variables
    ILog logger = LogManager.GetLogger(typeof(Login));
    Employee objEmp = new Employee();
    EmployeeBM objEmpBM = new EmployeeBM();
    MasterBM objMstBM = new MasterBM();
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.DefaultButton = lnkbtnSubmit.UniqueID;
        if (!IsPostBack)
        {

            txtUserName.Focus();
            if (Request.QueryString["mode"] != null && Request.QueryString["mode"].ToString() != string.Empty)
            {
                if (Request.QueryString["mode"].ToString() == "wrong")
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.ltlWrongCharacter.Trim();
                    dvsererror.Visible = true;
                }
            }
        }
    }
    protected void lnkbtnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.Session["CaptchaImageText"] != null && !string.IsNullOrEmpty(this.Session["CaptchaImageText"].ToString()))
            {
                if (this.txtimgcode.Text != this.Session["CaptchaImageText"].ToString())
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.ltlWrongCharacter.Trim();
                    dvsererror.Visible = true;
                    Image1.ImageUrl = "~/CImage.aspx?id=" + Guid.NewGuid() + "";
                    txtimgcode.Text = String.Empty;
                    txtimgcode.Focus();
                    return;
                }
                DataTable dtLoginDtls = new DataTable();
                objEmp.Email = txtUserName.Text.Trim();
                dtLoginDtls = objEmpBM.GetForgotLoginDtls(objEmp);
                if (dtLoginDtls != null && dtLoginDtls.Rows.Count > 0)
                {
                    string strEmailTo = txtUserName.Text.Trim();
                    string strUserName = dtLoginDtls.Rows[0]["UserName"].ToString();
                    string strDecryptPassword = Cls_Encryption.DecryptTripleDES(dtLoginDtls.Rows[0]["Password"].ToString());
                    string strPassword = strDecryptPassword;
                    string strName = dtLoginDtls.Rows[0]["Name"].ToString();
                    if (SendMail(strEmailTo, strUserName, strPassword, strName))
                    {
                        lblSerSucMsg.Text = Resources.PFSalesResource.ltlLoginDetailsSent.Trim();
                        dvaserSuccess.Visible = true;
                        lblSerErrMsg.Text = string.Empty;
                        dvsererror.Visible = false;
                        txtUserName.Text = string.Empty;
                        txtimgcode.Text = string.Empty;
                        hrefLogin.Visible = true;
                    }
                    else
                    {
                        lblSerSucMsg.Text = string.Empty;
                        dvaserSuccess.Visible = false;
                        lblSerErrMsg.Text = Resources.PFSalesResource.msgStatusError.Trim();
                        dvsererror.Visible = true;
                        hrefLogin.Visible = false;
                    }
                }
                else
                {
                    lblSerSucMsg.Text = string.Empty;
                    dvaserSuccess.Visible = false;
                    lblSerErrMsg.Text = Resources.PFSalesResource.IncorrectUname.Trim();
                    dvsererror.Visible = true;
                    hrefLogin.Visible = false;
                    txtUserName.Focus();
                }
            }
            else if (this.Session["CaptchaImageText"] == null)
            {
                Response.Redirect("~/ForgotPassword.aspx", false);
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + ". Error" + ex.StackTrace); throw ex;
        }
    }
    protected void lnkbtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserLogin.aspx");
    }
    protected void lnkbtnRefresh_Click(object sender, EventArgs e)
    {
        Image1.ImageUrl = "~/CImage.aspx?id=" + Guid.NewGuid() + "";
    }
    #endregion

    #region Methods
    private Boolean SendMail(string emilToId, string UserName, string Password, string Name)
    {
        string FileContent = string.Empty;
        Cls_GenericEmailHelper objEmailHelper = new Cls_GenericEmailHelper();
        try
        {
            objEmp.FName = string.Empty;
            objEmp.Password = string.Empty;
            DataSet dsUserDetails = objEmpBM.GetLoginDetails(objEmp);
            if (dsUserDetails != null && dsUserDetails.Tables.Count > 0)
            {
                DataTable dtSmTpDetails = dsUserDetails.Tables[1];
                if (dtSmTpDetails != null && dtSmTpDetails.Rows.Count > 0)
                {
                    objEmailHelper.EmailFromID = dtSmTpDetails.Rows[0]["EmailFromID"].ToString().Trim();//ConfigurationManager.AppSettings["EmailFromID"].ToString();
                    objEmailHelper.EmailSubject = "Forgot Password Details";
                    objEmailHelper.SMTPServerIP = dtSmTpDetails.Rows[0]["SMTPServerIP"].ToString().Trim();//ConfigurationManager.AppSettings["SMTPServerIP"].ToString();
                    objEmailHelper.SMTPUserID = dtSmTpDetails.Rows[0]["SMTPUserID"].ToString().Trim();//ConfigurationManager.AppSettings["SMTPUserID"].ToString();
                    objEmailHelper.SMTPUserPwd = dtSmTpDetails.Rows[0]["SMTPUserPwd"].ToString().Trim();// ConfigurationManager.AppSettings["SMTPUserPwd"].ToString();
                    objEmailHelper.EmailContentType = dtSmTpDetails.Rows[0]["EmailContentType"].ToString().Trim();//"Html";
                    objEmailHelper.EmailToID = emilToId;
                    //objEmailHelper.EmailCcID = "pravin.gholap@mechsoftgroup.com";
                    FileContent = "Hi " + Name.Trim() + "<br /><br />Your Login Id is " + UserName.Trim() + "<br />Password is " + Password.Trim() + "<br /><br />Log In Link <a href='" + ConfigurationManager.AppSettings["LoginUrl"].ToString() + "'>Click Here To Login</a>";
                    objEmailHelper.EmailBody = FileContent;
                    if (objEmailHelper.SendEmail().ToLower().Contains("success"))
                    {
                        objMstBM.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), "EMail sent successfully", "Forgot Password Details", "Forgot Password");
                        return true;
                    }
                    else
                    {
                        objMstBM.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), "Error sending mail, Try again later !", "Forgot Password Details", "Forgot Password");
                        return false;
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message + ". Error" + ex.StackTrace);
            objMstBM.SaveEmailDetails(emilToId, objEmailHelper.EmailFromID.Trim(), FileContent.Trim(), Convert.ToString(ex.InnerException).Trim(), "Forgot Password Details", "Forgot Password");
            return false;
        }
    }
    #endregion
}
