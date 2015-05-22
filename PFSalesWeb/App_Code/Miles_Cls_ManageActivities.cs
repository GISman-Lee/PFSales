using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using Mechsoft.GeneralUtilities;
using System.Data;

/// <summary>
/// Summary description for Miles_Cls_ManageActivities
/// </summary>
public class Miles_Cls_ManageActivities
{
    Cls_DataAccess DataAccess = Cls_DataAccess.getInstance();

	public Miles_Cls_ManageActivities()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void ConfirmOrder(string CustomerID, string DealerID, string ProspectId, string DeliveryDate)
    {
        try
        {
            DbCommand objCmd = null;

            objCmd = DataAccess.GetCommand(System.Data.CommandType.StoredProcedure, "SpConfirmOrder");

            DataAccess.AddInParameter(objCmd, "CustomerID", DbType.Int64, Convert.ToInt64(CustomerID));
            DataAccess.AddInParameter(objCmd, "DealerID", DbType.Int32, Convert.ToInt32(DealerID));
            DataAccess.AddInParameter(objCmd, "ProspectId", DbType.Int64, Convert.ToInt64(ProspectId));
            DataAccess.AddInParameter(objCmd, "DeliveryDate", DbType.DateTime, Convert.ToDateTime(DeliveryDate));

            DataAccess.ExecuteNonQuery(objCmd);
        }
        catch (Exception ex) { }
    }

    public DataTable SearchCustomerByProspectId(string ProspectId)
    {
        DbCommand objCmd = null;
        DataTable dt = null;
        try
        {
            objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "SpSearchCustomerByProspectId");
            Cls_DataAccess.getInstance().AddInParameter(objCmd, "@ProspectId", DbType.Int64, Convert.ToInt64(ProspectId));
            dt = Cls_DataAccess.getInstance().GetDataTable(objCmd);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
}