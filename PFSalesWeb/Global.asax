<%@ Application Language="C#" %>
<%@ Import Namespace="Mechsoft.GeneralUtilities" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.IO" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        log4net.Config.DOMConfigurator.Configure();
        RegisterCacheEntry();
    }
    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        Application["StartTime"] = Convert.ToDateTime(Application["StartTime"]).AddSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["WaitSeconds"]));
        RegisterCacheEntry();
    }
    void Application_End(object sender, EventArgs e)
    {
    }
    void Application_Error(object sender, EventArgs e)
    {
    }
    void Session_Start(object sender, EventArgs e)
    {
    }
    void Session_End(object sender, EventArgs e)
    {
    }
    private bool RegisterCacheEntry()
    {
        HttpContext.Current.Cache.Add(ConfigurationManager.AppSettings["DummyCacheItemKey"], "DummyPage", null,
            DateTime.MaxValue, TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["WaitSeconds"])),
            CacheItemPriority.Normal,
            new CacheItemRemovedCallback(CacheItemRemovedCallback));
        return true;
    }
    public void CacheItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
    {
            SendSurveyData();
    }
    private void SendSurveyData()
    {
        Cls_ReminderProcess objproc = new Cls_ReminderProcess();
        objproc.BindEmailAlerts();
        objproc.GetPFRawDataToInsert();
        objproc.SendEmailBeforeLast3Days();
        objproc.GetAllProspAllocatedAft5Days();
    }
</script>

