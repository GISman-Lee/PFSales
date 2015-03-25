using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mechsoft.GeneralUtilities;

public partial class DummyPage : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime t1 = DateTime.Now;

        DateTime t2 = Convert.ToDateTime("5:12:00 PM");

        int i = DateTime.Compare(t1, t2);
        if (i==0)
        {
            Cls_ReminderProcess objproc = new Cls_ReminderProcess();
            objproc.BindEmailAlerts();
        }
    }
}
