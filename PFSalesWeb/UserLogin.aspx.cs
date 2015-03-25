using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using System.Configuration;
using Mechsoft.GeneralUtilities;
using System.Data;
using Mechsoft.PFSales.BusinessEntity;
using Mechsoft.PFSales.BusinessManager;
using System.Data.SqlClient;

public partial class UserLogin : System.Web.UI.Page
{
    #region Global Variables
    ILog Logger = LogManager.GetLogger(typeof(UserLogin));
    Employee objEmp = new Employee();
    EmployeeBM objEmpBM = new EmployeeBM();
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.DefaultButton = lnkbtnSubmit.UniqueID;
        if (txtUsername.Text != "")
        {
            Page.Form.DefaultFocus = txtPassword.UniqueID;
        }
        else
        {
            Page.Form.DefaultFocus = txtUsername.UniqueID;
        }
        if (!IsPostBack)
        {
            ClearControls();
            if (Request.Cookies["UName"] != null)
            {
                txtUsername.Text = Request.Cookies["UName"].Value;
            }
            if (Request.Cookies["PWD"] != null)
            {
                txtPassword.Attributes.Add("value", Request.Cookies["PWD"].Value);
            }

            if (Request.Cookies["UName"] != null && Request.Cookies["PWD"] != null)
            {
                chkRememberMe.Checked = true;
            }
            lblSerErrMsg.Text = string.Empty;
            dvsererror.Visible = false;
            if (Request.QueryString["UserId"] != null && !string.IsNullOrEmpty(Request.QueryString["UserId"].ToString().Trim()))
            {
                SetLoginDetailsFromQuote(Convert.ToInt64(Request.QueryString["UserId"].ToString().Trim()));
            }
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 May 2013
    /// Description: Cancel Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 May 2013
    /// Description: Button Click Event Of Submit Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnSubmit_Click(object sender, EventArgs e)
    {
        if (this.ValidateLogin())
        {
            String UserChoiceUrl = Convert.ToString(Session["userChoiceUrl"]);
            Session["userChoiceUrl"] = null;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 18 May 2013
    /// Description: Go To Forgot Password Page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnForgotPass_Click(object sender, EventArgs e)
    {
        Response.Redirect("ForgotPassword.aspx");
    }

    #endregion

    #region Methods
    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 May 2013
    /// Description: Clear Values Of All Controls
    /// </summary>
    private void ClearControls()
    {
        txtUsername.Text = string.Empty;
        txtPassword.Text = string.Empty;
        txtPassword.Attributes.Add("value", string.Empty);
        chkRememberMe.Checked = false;
        lblSerErrMsg.Text = string.Empty;
        dvsererror.Visible = false;
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 May 2013
    /// Description: Validate Login For Entered User Credentials
    /// </summary>
    /// <returns></returns>
    private Boolean ValidateLogin()
    {
        try
        {
            objEmp.FName = txtUsername.Text.Trim();
            string strPassword = txtPassword.Text.Trim();
            objEmp.Password = strPassword.Trim();
            //objEmp.Password = Cls_Encryption.EncryptTripleDES(strPassword.Trim());
            DataSet dsUserDetails = objEmpBM.GetLoginDetails(objEmp);
            if (dsUserDetails != null && dsUserDetails.Tables.Count > 0)
            {
                DataTable dtUserDetails = dsUserDetails.Tables[0];
                UserLoginListItem userdetail = null;
                if (dtUserDetails != null && dtUserDetails.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtUserDetails.Rows[0]["IsActive"]))
                    {
                        userdetail = new UserLoginListItem();
                        userdetail.Id = Int64.Parse(dtUserDetails.Rows[0]["Id"].ToString());
                        userdetail.Name = Convert.ToString(dtUserDetails.Rows[0]["Name"]);
                        userdetail.RoleId = Int64.Parse(dtUserDetails.Rows[0]["RoleID"].ToString());
                        userdetail.RoleName = Convert.ToString(dtUserDetails.Rows[0]["RoleName"]);
                        userdetail.VirtualRoleId = Int64.Parse(dtUserDetails.Rows[0]["VirtualRoleId"].ToString()); ;
                        userdetail.RoleCode = Convert.ToString(dtUserDetails.Rows[0]["RoleCode"]);
                        userdetail.UserEmail = Convert.ToString(dtUserDetails.Rows[0]["Email1"]);
                        userdetail.FullName = Convert.ToString(dtUserDetails.Rows[0]["FullName"]).Trim();
                        userdetail.MobileNo = Convert.ToString(dtUserDetails.Rows[0]["Mobile"]).Trim();
                        userdetail.PhExtension = Convert.ToString(dtUserDetails.Rows[0]["PhoneExt"]).Trim();
                        userdetail.UserEntityId = Convert.ToInt64(dtUserDetails.Rows[0]["QuoteUserId"].ToString().Trim());
                        DataTable dtSmtpDetails = dsUserDetails.Tables[1];
                        if (dtSmtpDetails != null && dtSmtpDetails.Rows.Count > 0)
                        {
                            userdetail.EmailFromID = dtSmtpDetails.Rows[0]["EmailFromID"].ToString().Trim();
                            userdetail.EmailContentType = dtSmtpDetails.Rows[0]["EmailContentType"].ToString().Trim();
                            userdetail.EmailAttachmentsNo = dtSmtpDetails.Rows[0]["EmailAttachmentsNo"].ToString().Trim();
                            userdetail.EmailAttachmentsSize = dtSmtpDetails.Rows[0]["EmailAttachmentsSize"].ToString().Trim();
                            userdetail.EmailTypeBlocked = dtSmtpDetails.Rows[0]["EmailTypeBlocked"].ToString().Trim();
                            userdetail.SMTPServerIP = dtSmtpDetails.Rows[0]["SMTPServerIP"].ToString().Trim();
                            userdetail.SMTPUserID = dtSmtpDetails.Rows[0]["SMTPUserID"].ToString().Trim();
                            userdetail.SMTPUserPwd = dtSmtpDetails.Rows[0]["SMTPUserPwd"].ToString().Trim();
                        }
                    }
                    else
                    {
                        //lblSerErrMsg.Text = "Sorry!!! Your Login Is Deactivated, Please Contact to Admin for Further Details.";
                        //dvsererror.Visible = true;
                        //ScriptManager.RegisterStartupScript(Page, this.GetType(), "ShowPopUp", "popup();", true);
                        return false;
                    }

                }
                if (userdetail != null)
                {
                    lblSerErrMsg.Text = string.Empty;
                    dvsererror.Visible = false;
                    if (chkRememberMe.Checked == true)
                    {
                        Response.Cookies["UName"].Value = objEmp.FName;
                        Response.Cookies["PWD"].Value = strPassword;
                        Response.Cookies["UName"].Expires = DateTime.Now.AddMonths(12);
                        Response.Cookies["PWD"].Expires = DateTime.Now.AddMonths(12);
                    }
                    else
                    {
                        Response.Cookies["UName"].Expires = DateTime.Now.AddMonths(-1);
                        Response.Cookies["PWD"].Expires = DateTime.Now.AddMonths(-1);
                    }
                    this.setValueToSession(userdetail);
                    Session["Test"] = "Pravin";
                    GotoDashBoard(userdetail.RoleId);
                    return true;
                }
                else
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.loginFailMsg;
                    dvsererror.Visible = true;
                    //lblMsg.Text = Resources.MechResource.loginFailMsg;
                    //ScriptManager.RegisterStartupScript(Page, this.GetType(), "ShowPopUp", "popup();", true);
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Focus();
                    txtPassword.Attributes.Add("value", string.Empty);
                    chkRememberMe.Checked = false;
                    return false;
                }
                //string s = BasePage.UserSession.RoleName;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + ". Error" + ex.StackTrace); return false;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 May 2013
    /// Description: Set Values To Session
    /// </summary>
    /// <param name="userdetail"></param>
    private void setValueToSession(UserLoginListItem userdetail)
    {
        try
        {
            UserSessionInfo session = new UserSessionInfo();
            session.BranchId = userdetail.BranchId;
            session.BranchName = userdetail.BranchName;
            session.UserEmail = userdetail.UserEmail;
            session.RoleId = userdetail.RoleId;
            session.UserId = userdetail.Id;
            session.FName = userdetail.Name;
            session.FullName = userdetail.FullName;
            session.RoleName = userdetail.RoleName;
            session.OrgEstablishmentDate = userdetail.OrgEstablishmentDate;
            session.VirtualRoleId = userdetail.VirtualRoleId;
            session.LoginDetailId = userdetail.LoginDetailId;
            session.RoleCode = userdetail.RoleCode;
            session.UserEntityId = userdetail.UserEntityId;
            session.StudentId = userdetail.StudId;
            session.UserEntityId = userdetail.UserEntityId;
            session.EmailFromID = userdetail.EmailFromID;
            session.EmailContentType = userdetail.EmailContentType;
            session.EmailAttachmentsNo = userdetail.EmailAttachmentsNo;
            session.EmailAttachmentsSize = userdetail.EmailAttachmentsSize;
            session.EmailTypeBlocked = userdetail.EmailTypeBlocked;
            session.SMTPServerIP = userdetail.SMTPServerIP;
            session.SMTPUserID = userdetail.SMTPUserID;
            session.SMTPUserPwd = userdetail.SMTPUserPwd;
            session.MobileNo = userdetail.MobileNo;
            session.PhExtension = userdetail.PhExtension;
            session.UserEntityId = userdetail.UserEntityId;
            SessionHandler.SetSessionValue(SessionKeys.USER_SESSION_OBJECT_KEY, session);
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + ". Error" + ex.StackTrace); throw ex;
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Dat: 17 May 2013
    /// Description: Go to perticular landing page according to role id of user
    /// </summary>
    /// <param name="RoleId"></param>
    private void GotoDashBoard(Int64 RoleId)
    {
        try
        {
            switch (RoleId)
            {
                case 1://Admin
                    Response.Redirect("LeadAllocation.aspx", false);//AdminDash.aspx
                    break;
                case 2://Employee
                    Response.Redirect("LeadAllocation.aspx", false);
                    break;
                case 3://Consultant
                    Response.Redirect("ViewMyContacts.aspx", false);//ConsultantDash.aspx
                    break;
                case 5://Consultant
                    Response.Redirect("ViewMyContacts.aspx", false);//ConsultantDash.aspx
                    break;
                default://Other
                    Response.Redirect("SearchProspect.aspx", false);
                    break;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "GotoDashBoard.Error" + ex.StackTrace);
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 29 July 2013
    /// Description: Get Login Details From Quote System & Add to Session of this application
    /// </summary>
    /// <param name="UserId"></param>
    private void SetLoginDetailsFromQuote(Int64 UserId)
    {
        SqlConnection con = new SqlConnection(@ConfigurationManager.AppSettings["QuoteDB"].ToString().Trim());
        try
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SpGetUserDetails",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", UserId);
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                string Uname = dt.Rows[0]["Username"].ToString().Trim();
                string Pass = dt.Rows[0]["Password"].ToString().Trim();
                ValidateLoginFromQuote(Uname, Pass);
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + "GotoDashBoard.Error" + ex.StackTrace);
        }
        finally
        {
            con.Close();
        }
    }

    /// <summary>
    /// Created By: Pravin Gholap
    /// Created Date: 17 May 2013
    /// Description: Validate Login For Entered User Credentials
    /// </summary>
    /// <returns></returns>
    private Boolean ValidateLoginFromQuote(string Uname, string Pass)
    {
        try
        {
            objEmp.FName = Uname.Trim();
            objEmp.Password = Pass;//Cls_Encryption.EncryptTripleDES(Pass.Trim());
            DataSet dsUserDetails = objEmpBM.GetLoginDetails(objEmp);
            if (dsUserDetails != null && dsUserDetails.Tables.Count > 0)
            {
                DataTable dtUserDetails = dsUserDetails.Tables[0];
                UserLoginListItem userdetail = null;
                if (dtUserDetails != null && dtUserDetails.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtUserDetails.Rows[0]["IsActive"]))
                    {
                        userdetail = new UserLoginListItem();
                        userdetail.Id = Int64.Parse(dtUserDetails.Rows[0]["Id"].ToString());
                        userdetail.Name = Convert.ToString(dtUserDetails.Rows[0]["Name"]);
                        userdetail.RoleId = Int64.Parse(dtUserDetails.Rows[0]["RoleID"].ToString());
                        userdetail.RoleName = Convert.ToString(dtUserDetails.Rows[0]["RoleName"]);
                        userdetail.VirtualRoleId = Int64.Parse(dtUserDetails.Rows[0]["VirtualRoleId"].ToString()); ;
                        userdetail.RoleCode = Convert.ToString(dtUserDetails.Rows[0]["RoleCode"]);
                        userdetail.UserEmail = Convert.ToString(dtUserDetails.Rows[0]["Email1"]);
                        userdetail.FullName = Convert.ToString(dtUserDetails.Rows[0]["FullName"]).Trim();
                        userdetail.MobileNo = Convert.ToString(dtUserDetails.Rows[0]["Mobile"]).Trim();
                        userdetail.PhExtension = Convert.ToString(dtUserDetails.Rows[0]["PhoneExt"]).Trim();
                        userdetail.UserEntityId = Convert.ToInt64(dtUserDetails.Rows[0]["QuoteUserId"].ToString().Trim());
                        DataTable dtSmtpDetails = dsUserDetails.Tables[1];
                        if (dtSmtpDetails != null && dtSmtpDetails.Rows.Count > 0)
                        {
                            userdetail.EmailFromID = dtSmtpDetails.Rows[0]["EmailFromID"].ToString().Trim();
                            userdetail.EmailContentType = dtSmtpDetails.Rows[0]["EmailContentType"].ToString().Trim();
                            userdetail.EmailAttachmentsNo = dtSmtpDetails.Rows[0]["EmailAttachmentsNo"].ToString().Trim();
                            userdetail.EmailAttachmentsSize = dtSmtpDetails.Rows[0]["EmailAttachmentsSize"].ToString().Trim();
                            userdetail.EmailTypeBlocked = dtSmtpDetails.Rows[0]["EmailTypeBlocked"].ToString().Trim();
                            userdetail.SMTPServerIP = dtSmtpDetails.Rows[0]["SMTPServerIP"].ToString().Trim();
                            userdetail.SMTPUserID = dtSmtpDetails.Rows[0]["SMTPUserID"].ToString().Trim();
                            userdetail.SMTPUserPwd = dtSmtpDetails.Rows[0]["SMTPUserPwd"].ToString().Trim();
                        }
                    }
                    else
                    {
                        //lblSerErrMsg.Text = "Sorry!!! Your Login Is Deactivated, Please Contact to Admin for Further Details.";
                        //dvsererror.Visible = true;
                        //ScriptManager.RegisterStartupScript(Page, this.GetType(), "ShowPopUp", "popup();", true);
                        return false;
                    }

                }
                if (userdetail != null)
                {
                    lblSerErrMsg.Text = string.Empty;
                    dvsererror.Visible = false;
                    if (chkRememberMe.Checked == true)
                    {
                        Response.Cookies["UName"].Value = objEmp.FName;
                        Response.Cookies["PWD"].Value = Pass.Trim();
                        Response.Cookies["UName"].Expires = DateTime.Now.AddMonths(12);
                        Response.Cookies["PWD"].Expires = DateTime.Now.AddMonths(12);
                    }
                    else
                    {
                        Response.Cookies["UName"].Expires = DateTime.Now.AddMonths(-1);
                        Response.Cookies["PWD"].Expires = DateTime.Now.AddMonths(-1);
                    }
                    this.setValueToSession(userdetail);
                    Session["Test"] = "Pravin";
                    GotoDashBoard(userdetail.RoleId);
                    return true;
                }
                else
                {
                    lblSerErrMsg.Text = Resources.PFSalesResource.loginFailMsg;
                    dvsererror.Visible = true;
                    //lblMsg.Text = Resources.MechResource.loginFailMsg;
                    //ScriptManager.RegisterStartupScript(Page, this.GetType(), "ShowPopUp", "popup();", true);
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Focus();
                    txtPassword.Attributes.Add("value", string.Empty);
                    chkRememberMe.Checked = false;
                    return false;
                }
                //string s = BasePage.UserSession.RoleName;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message + ". Error" + ex.StackTrace); return false;
        }
    }
    #endregion
}
