using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mechsoft.GeneralUtilities;
using System.Data;
using System.Threading;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using Mechsoft.PFSales.BusinessEntity;

/// <summary>
/// Summary description for BasePage
/// </summary>

public class BasePage : Page
{
    public BasePage()
        : base()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool IsRefreshed
    {
        get
        {
            if (Convert.ToString(Session["RefreshTimeStamp"]) == Convert.ToString(ViewState["RefreshTimeStamp"]))
            {
                Session["RefreshTimeStamp"] = HttpContext.Current.Server.UrlDecode(System.DateTime.Now.ToString());
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected override void OnPreLoad(EventArgs e)
    {
        base.OnPreLoad(e);
    }

    protected override void OnLoad(EventArgs e)
    {
        if (BasePage.UserSession == null)
        {
            Session["userChoiceUrl"] = Convert.ToString(Request.RawUrl);
            if (Page.IsCallback)
            {
                string script = string.Format("document.location.href = '{0}');", "~/UserLogin.aspx");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "redirect", script, true);
            }
            else
            {
                Response.Redirect("~/UserLogin.aspx", true);
            }
        }
        if (!Page.IsPostBack)
        {
            Session["RefreshTimeStamp"] = HttpContext.Current.Server.UrlDecode(System.DateTime.Now.ToString());
        }
        base.OnLoad(e);
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        ViewState["RefreshTimeStamp"] = Session["RefreshTimeStamp"];
    }

    protected override void OnAbortTransaction(EventArgs e)
    {
        base.OnAbortTransaction(e);
    }

    protected override void OnError(EventArgs e)
    {
        //do error handling
        base.OnError(e);
    }

    public void Response1(string url)
    {
        System.Web.HttpContext.Current.Response.Redirect(GetCategory(url));
    }

    public string GetCategory(string myXmlString)
    {
        string Mapurl = "";
        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath(@"~/urlconfg.xml"));
        string ss = doc.InnerXml;
        if (ss.Contains(myXmlString.Substring(0, myXmlString.IndexOf('.'))))
        {
            int s = myXmlString.IndexOf('?');
            int t = myXmlString.IndexOf('=');
            Mapurl = myXmlString.Substring(0, myXmlString.IndexOf('.')) + ";" + myXmlString.Substring(t + 1, myXmlString.Length - (t + 1));
            XmlNodeList xnList = doc.SelectNodes("/rewriter/rewrite[@to='" + myXmlString.Substring(0, myXmlString.IndexOf('?')) + "?" + myXmlString.Substring(s + 1, (t - s)) + "=$1']");
            string fileName = "data.xml";
            XPathDocument doc1 = new XPathDocument(Server.MapPath(@"~/urlconfg.xml"));
            XPathNavigator nav = doc1.CreateNavigator();
            // Compile a standard XPath expression
            XPathExpression expr;
            //  /catalog/cd[price>10.0]
            expr = nav.Compile("/rewriter/rewrite[@to='~/masters/" + myXmlString.Substring(0, myXmlString.IndexOf('?')) + "?" + myXmlString.Substring(s + 1, (t - s - 1)) + "=$1']");
            XPathNodeIterator iterator = nav.Select(expr);
            // Iterate on the node set
            //listBox1.Items.Clear();
            try
            {
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    //listBox1.Items.Add("price: " + nav2.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            XmlNode menu = doc.SelectSingleNode("rewriter");
            XmlNode newSub = doc.CreateNode(XmlNodeType.Element, "rewrite", null);
            XmlAttribute xa = doc.CreateAttribute("url");
            xa.Value = myXmlString;
            XmlAttribute xb = doc.CreateAttribute("to");
            xb.Value = myXmlString;
            newSub.Attributes.Append(xa);
            newSub.Attributes.Append(xb);
            menu.AppendChild(newSub);
            doc.PreserveWhitespace = false;
            XmlTextWriter wrtr = new XmlTextWriter(Server.MapPath(@"~/urlconfg.xml"), Encoding.Unicode);
            doc.WriteTo(wrtr);
            wrtr.Close();
        }
        return Mapurl;
    }

    public void Response1(string url, bool Isproced)
    {
        System.Web.HttpContext.Current.Response.Redirect(GetCategory(url), Isproced);
    }

    public static UserSessionInfo UserSession
    {
        get
        {
            return SessionHandler.GetSessionValue(SessionKeys.USER_SESSION_OBJECT_KEY) as UserSessionInfo;
        }
    }

    #region Setting Culture : (Language)
    public const string LanguageDropDownID = "ctl00$ddlLanguage"; //"ctl00_cphHeader_Header1_ddlLanguage";
    public const string PostBackEventTarget = "__EVENTTARGET";
    public const string ThemeDropDownID = "ctl00$ddlTheme"; //"ctl00_cphHeader_Header1_ddlLanguage";
    public const string ddlEmployeeLevel = "ctl00$ucHeader$ddlEmployeeLevel";

    /// <summary>
    /// Created By : Archana on 26 April 2011
    /// Details : Setting UICulture according to language selected by user
    /// </summary>
    protected override void InitializeCulture()
    {
        try
        {
            //if (Master != null && Master.MasterPageFile != null)
            //{
            //    ContentPlaceHolder ctls = (ContentPlaceHolder)Master.NamingContainer.FindControl("ContentPlaceHolder1");
            //    if (ctls != null) setlangforinput(ctls.Controls);
            //}
            //If Language Dropdown event is not null i.e. Index



            if (Request[PostBackEventTarget] != null)
            {
                string controlID = Request[PostBackEventTarget];
                if (controlID.Equals(LanguageDropDownID))
                {
                    string selectedValue = Convert.ToString(Request.Form[Request[PostBackEventTarget]]);
                    switch (selectedValue)
                    {
                        case "en-US"://United Kingdom : English
                            SetCulture("en-US");
                            break;
                        case "hi-IN": //Hindi
                            SetCulture("hi-IN");
                            break;
                        case "fr-FR"://French
                            SetCulture("fr-FR");
                            break;
                        case "de-DE"://German
                            SetCulture("de-DE");
                            break;
                        case "ar-AE"://Arebic
                            SetCulture("ar-AE");
                            break;
                        case "ja-JP"://Japanese
                            SetCulture("ja-JP");
                            break;
                        case "zh-CN"://Chinese
                            SetCulture("zh-CN");
                            break;
                        default: break;
                    }
                }
                if (controlID.Equals(ddlEmployeeLevel))
                {
                    string selectedValue = Convert.ToString(Request.Form[Request[PostBackEventTarget]]);
                    string[] str = selectedValue.Split('-');
                    if (str.Length > 1)
                    {
                        BasePage.UserSession.HierarchyMappingId = Convert.ToInt64(str[0].ToString());
                        BasePage.UserSession.EntityHierarchyId = Convert.ToInt64(str[1].ToString());
                        //UserSessionInfo session = new UserSessionInfo();
                        // this.Page.Load+=new EventHandler(Page_Load);

                        // this.Master.LoadControl(typeof(Page), null);
                    }
                }
            }
            if (Session["language"] != null)
            {
                Thread.CurrentThread.CurrentUICulture = (CultureInfo)Session["language"];
            }
            System.Globalization.DateTimeFormatInfo _dtFormatInfo = new System.Globalization.DateTimeFormatInfo();
            if (Resources.PFSalesResource.Setdateformat == "dd/MM/yyyy")
            {
                this.Page.Culture = "en-GB";
            }
            else if (Resources.PFSalesResource.Setdateformat == "MM/dd/yyyy")
            {
                this.Page.Culture = "en-US";
            }
            base.InitializeCulture();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void setlangforinput(ControlCollection ctls)
    {
        foreach (Control ctrl in ctls)
        {
            if (ctrl is TextBox)
            {
                TextBox tx1 = (TextBox)ctrl;
                setLanguagesForInput(tx1.ClientID);
            }
            if (ctrl is AjaxControlToolkit.HTMLEditor.Editor)
            {
                AjaxControlToolkit.HTMLEditor.Editor editor = (AjaxControlToolkit.HTMLEditor.Editor)ctrl;
                setLanguagesForInput(editor.ClientID);
            }
            if (ctrl.HasControls())
            {
                setlangforinput(ctrl.Controls);
            }
        }
    }
    protected void setLanguagesForInput(string CntrlClntId)
    {
        StringBuilder MechsoftMultilingual = new StringBuilder();
        StringBuilder MechsoftMultilingual_init_script = new StringBuilder();
        ClientScriptManager cs = this.Page.ClientScript;

        string MechsoftsrcLanguage = "ENGLISH";
        string MechsoftdestiLanguage = "MARATHI";
        string Mechsoftkeyboardlayoutcode = "MARATHI";

        if (!cs.IsClientScriptBlockRegistered("MechsoftMultilingual"))
        {
            cs.RegisterClientScriptInclude("google_Api", "http://www.google.com/jsapi");
            if (false)
            {
                MechsoftMultilingual.Append("google.load('elements', '1', {packages: 'keyboard'});");
                MechsoftMultilingual.Append("var kbd;");
                MechsoftMultilingual.Append("function ToggleKeyboard() { if (kbd.isVisible()) { kbd.setVisible(false); } else { kbd.setVisible(true); }}");
            }
            MechsoftMultilingual.Append("google.load('elements', '1', {packages: 'transliteration'}); ");
            cs.RegisterClientScriptBlock(this.GetType(), "MechsoftMultilingual", MechsoftMultilingual.ToString(), true);
        }

        MechsoftMultilingual_init_script.Append("function OnLoad_" + CntrlClntId + "() {");
        MechsoftMultilingual_init_script.Append("TTB_Options_" + CntrlClntId + " = {sourceLanguage:google.elements.transliteration.LanguageCode." + MechsoftsrcLanguage + ",destinationLanguage:[google.elements.transliteration.LanguageCode." + MechsoftdestiLanguage + "],shortcutKey: 'ctrl+g',transliterationEnabled: true }; ");
        MechsoftMultilingual_init_script.Append("TTB_Control_" + CntrlClntId + " = new google.elements.transliteration.TransliterationControl(TTB_Options_" + CntrlClntId + ");");
        MechsoftMultilingual_init_script.Append("TTB_Control_" + CntrlClntId + ".makeTransliteratable(['" + CntrlClntId + "']); ");

        if (true)
        {
            MechsoftMultilingual_init_script.Append("kbd = new google.elements.keyboard.Keyboard([google.elements.keyboard.LayoutCode." + Mechsoftkeyboardlayoutcode + "],['" + CntrlClntId + "']); ");
            MechsoftMultilingual_init_script.Append("kbd.setVisible(false); ");
            MechsoftMultilingual_init_script.Append("document.getElementById('" + CntrlClntId + "').onkeyup=function(e){ var event = window.event || e ; if(event.keyCode == 17) {  isCtrl=false; } }; document.getElementById('" + this.ClientID + "').onkeydown=function(e) { var event = window.event || e ; if(event.keyCode == 17) { isCtrl=true; } if(event.keyCode == 77 && isCtrl == true) { ToggleKeyboard(); return false; } }; ");
            MechsoftMultilingual_init_script.Append("document.getElementById('" + CntrlClntId + "').onfocus=function(e){ kbd.setLayout(google.elements.keyboard.LayoutCode." + Mechsoftkeyboardlayoutcode + ");};");
        }
        // MechsoftMultilingual_init_script.Append("document.getElementById('" + CntrlClntId + "').title='" + this.TextBox1.ToolTipText + "'; ");
        MechsoftMultilingual_init_script.Append(" } ");
        MechsoftMultilingual_init_script.Append("google.setOnLoadCallback(OnLoad_" + CntrlClntId + "); ");
        cs.RegisterStartupScript(Type.GetType("System.String"), "init_" + CntrlClntId, MechsoftMultilingual_init_script.ToString(), true);
    }

    protected void SetCulture(string CultureName)
    {
        try
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(CultureName);//(CultureInfo)Session["language"];
            Session["language"] = Thread.CurrentThread.CurrentUICulture;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
}

