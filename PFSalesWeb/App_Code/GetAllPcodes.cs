using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Mechsoft.PFSales.BusinessManager;
using System.Data;

/// <summary>
/// Summary description for GetAllPcodes
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class GetAllPcodes : System.Web.Services.WebService
{

    public GetAllPcodes()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    [System.Web.Script.Services.ScriptMethod]
    public string[] GetPcodeList(String prefixText, int count)
    {
        MasterBM objMstBM = new MasterBM();
        DataTable Dt = new DataTable();
        if (Session["StateId"] != null && !string.IsNullOrEmpty(Convert.ToString(Session["StateId"]).Trim()))
            Dt = objMstBM.GetAllPCodes(prefixText, Convert.ToInt64(Session["StateId"]));
        else
            Dt = objMstBM.GetAllCity(string.Empty, 0);
        string[] strArray = new string[Dt.Rows.Count];
        int i = 0;
        if (Dt.Rows.Count > 0 && Dt != null)
        {
            foreach (DataRow dr in Dt.Rows)
            {
                strArray.SetValue(dr["PCode"].ToString(), i);
                i++;
            }
        }
        return strArray;

    }
}

