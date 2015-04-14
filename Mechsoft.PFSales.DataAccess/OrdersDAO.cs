using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mechsoft.PFSales.BusinessEntity;
using System.Data.Common;
using Mechsoft.GeneralUtilities;
using log4net;

namespace Mechsoft.PFSales.DataAccess
{
    public class OrdersDAO
    {
        #region Global Variables
        ILog logger = LogManager.GetLogger(typeof(OrdersDAO));
        #endregion

        #region Methods
        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 27 Feb 2014
        /// Description: Add Order Details
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public Int64 AddOrder(clsOrders ObjOrder)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            DbConnection objConn = null;
            DbTransaction objTran = null;
            try
            {
                objConn = Cls_DataAccess.getInstance().GetConnection();
                objConn.Open();
                objTran = objConn.BeginTransaction();
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddTradeIn");
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, ObjTradeIn.ProspId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId", DbType.Int64, ObjOrder.ProspectId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "BuildPlateDate", DbType.DateTime, ObjOrder.BuildPlateDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ComplianceDate", DbType.DateTime, ObjOrder.ComplianceDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "RegType", DbType.String, ObjOrder.RegType);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Make", DbType.String, ObjOrder.Make);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MakeId", DbType.Int32, ObjOrder.MakeId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Model", DbType.String, ObjOrder.Model);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ModelId", DbType.Int32, ObjOrder.ModelId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Series", DbType.String, ObjOrder.Series);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Finance", DbType.String, ObjOrder.Finance);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ReferredBy", DbType.String, ObjOrder.ReferredBy);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Transmission", DbType.String, ObjOrder.Transmission);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "BodyStyle", DbType.String, ObjOrder.Color);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SupplyingDealer", DbType.String, ObjOrder.SupplyingDealer);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTradeIn", DbType.Boolean, ObjOrder.IsTradeIn);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsMemFeeCharge", DbType.Boolean, ObjOrder.IsMemFeeCharge);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CardType", DbType.String, ObjOrder.CardType);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CardNo", DbType.String, ObjOrder.CardNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "DepositeAmount", DbType.Double, ObjOrder.DepositeAmount);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "DepositeTakenBy", DbType.String, ObjOrder.DepositeTakenBy);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ExpDate", DbType.DateTime, ObjOrder.ExpDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CVNo", DbType.String, ObjOrder.CVNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SpecialConditions", DbType.String, ObjOrder.SpecialConditions);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, ObjOrder.IsDeleted);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, ObjOrder.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ModifiedById", DbType.Int64, ObjOrder.ModifiedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedDate", DbType.DateTime, ObjOrder.CreatedDate);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "ModifiedDate", DbType.DateTime, ObjTradeIn.ModifiedDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "DeliveryDate", DbType.DateTime, ObjOrder.DeliveryDate);
                #region Hide
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "ExteriorColor", DbType.String, ObjOrder.ExteriorColor);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "InteriorColor", DbType.String, ObjOrder.InteriorColor);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsABS", DbType.Boolean, ObjTradeIn.IsABS);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsXenonLights", DbType.Boolean, ObjOrder.IsXenonLights);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsPowerSteer", DbType.Boolean, ObjTradeIn.IsPowerSteer);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsProtectionProduct", DbType.Boolean, ObjOrder.IsProtectionProduct);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActiveCruiseControl", DbType.Boolean, ObjOrder.IsActiveCruiseControl);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTowBar", DbType.Boolean, ObjOrder.IsTowBar);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsPowerWindows", DbType.Boolean, ObjTradeIn.IsPowerWindows);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsElectricSeats", DbType.Boolean, ObjOrder.IsElectricSeats);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsBullBar", DbType.Boolean, ObjOrder.IsBullBar);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsCentralLocking", DbType.Boolean, ObjTradeIn.IsCentralLocking);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTint", DbType.Boolean, ObjOrder.IsTint);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsSunroof", DbType.Boolean, ObjOrder.IsSunroof);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsRoofRacks", DbType.Boolean, ObjOrder.IsRoofRacks);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "CD", DbType.Int32, ObjTradeIn.CD);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "AirBags", DbType.String, ObjTradeIn.AirBags);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTV", DbType.Boolean, ObjOrder.IsTV);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsLeather", DbType.Boolean, ObjOrder.IsLeather);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsSideSteps", DbType.Boolean, ObjOrder.IsSideSteps);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsSatNav", DbType.Boolean, ObjOrder.IsSatNav);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsAlarm", DbType.Boolean, ObjTradeIn.IsAlarm);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsThirdRowSeats", DbType.Boolean, ObjOrder.IsThirdRowSeats);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeInNo", DbType.Int64, ObjOrder.TradeInNo);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "RateCondition", DbType.Int32, ObjOrder.RateCondition);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "Paint", DbType.String, ObjOrder.Paint);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "Breaks", DbType.String, ObjOrder.Breaks);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "Tyres", DbType.String, ObjOrder.Tyres);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "ACDetails", DbType.String, ObjOrder.ACDetails);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "RimAlloysDetails", DbType.String, ObjOrder.RimAlloysDetails);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "Headlights", DbType.String, ObjOrder.Headlights);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "Upholstery", DbType.String, ObjOrder.Upholstery);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "SpareTyre", DbType.String, ObjOrder.SpareTyre);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "VehicleCondition", DbType.String, ObjOrder.VehicleCondition);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "DamageDetails", DbType.String, ObjOrder.DamageDetails);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "Owners", DbType.Int32, ObjOrder.Owners);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "TyreHistory", DbType.String, ObjOrder.TyreHistory);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "ServiceHistory", DbType.String, ObjOrder.ServiceHistory);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "Payout", DbType.String, ObjOrder.Payout);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsPanoramic", DbType.Boolean, ObjOrder.IsPanoramic);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTimingBeltChanged", DbType.Boolean, ObjOrder.IsTimingBeltChanged);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "WheelsAlloys", DbType.String, ObjOrder.WheelsAlloys);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsLaneChangeAssist", DbType.Boolean, ObjOrder.IsLaneChangeAssist);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsBluetoothFactory", DbType.Boolean, ObjOrder.IsBluetoothFactory);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsReverseCamera", DbType.Boolean, ObjOrder.IsReverseCamera);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsFourByFour", DbType.Boolean, ObjOrder.IsFourByFour);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTwoByTwo", DbType.Boolean, ObjOrder.IsTwoByTwo);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "FuelType", DbType.String, ObjOrder.FuelType);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "Door", DbType.String, ObjOrder.Door);
                #endregion
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
                    #region Hide
                    //for (int i = 0; i < objProsp.LstProspContact.Count; i++)
                    //{
                    //    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddProspContact");
                    //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objProsp.LstProspContact[i].ProspContactId);
                    //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspId", DbType.Int64, Result);
                    //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ContactId", DbType.Int64, objProsp.LstProspContact[i].ContactId);
                    //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsPrimary", DbType.Boolean, objProsp.LstProspContact[i].IsPrimary);
                    //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objProsp.CreatedById);
                    //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objProsp.IsDeleted);
                    //    Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                    //    if (Result < 0)
                    //    {
                    //        objTran.Rollback();
                    //        return Result;
                    //    }
                    //}
                    #endregion
                    //if (Result > 0)
                    //{
                    objTran.Commit();
                    return Result;
                    //}
                    //else
                    //{
                    //    objTran.Rollback();
                    //    return Result;
                    //}
                }
                else
                {
                    objTran.Rollback();
                    return Result;
                }
            }
            catch (Exception ex)
            {
                objTran.Rollback();
                logger.Error(ex.Message + "ProspectsDAO.AddTradeIn Error:" + ex.StackTrace);
                return 0;
            }
        }
        #endregion
    }
}
