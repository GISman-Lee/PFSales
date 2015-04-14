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
    public class ProspectsDAO
    {
        #region Global Variables
        ILog logger = LogManager.GetLogger(typeof(ProspectsDAO));
        #endregion

        #region Methods
        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 May 2013
        /// Description: Add Prospects Details
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public Int64 AddProspect(Prospect objProsp)
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
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddProspects");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objProsp.ProspId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspKey", DbType.String, objProsp.ProspKey);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FName", DbType.String, objProsp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MName", DbType.String, objProsp.MName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "LName", DbType.String, objProsp.LName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Title", DbType.Int32, objProsp.Title);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CarMake", DbType.Int32, objProsp.CarMake);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Phone", DbType.String, objProsp.Phone);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedPhone", DbType.Int64, objProsp.formatedPhoNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Mobile", DbType.String, objProsp.Mobile);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedMobile", DbType.Int64, objProsp.formatedMobNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "AltContact", DbType.String, objProsp.AltContact);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedAltNo", DbType.Int64, objProsp.formatedAltCon);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Fax", DbType.String, objProsp.Fax);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedFax", DbType.Int64, objProsp.formatedFax);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email1", DbType.String, objProsp.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email2", DbType.String, objProsp.Email1);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Add1", DbType.String, objProsp.Add1);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Add2", DbType.String, objProsp.Add2);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Add3", DbType.String, objProsp.Add3);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CityId", DbType.Int64, objProsp.CityId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PostalCode", DbType.String, objProsp.PostalCode);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MemberNo", DbType.String, objProsp.MemberNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultId", DbType.Int64, objProsp.ConsultId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FConsultant", DbType.String, objProsp.FConsultant);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StatusId", DbType.Int64, objProsp.StatusId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SourceId", DbType.Int16, objProsp.SourceId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Finance", DbType.Int16, objProsp.Finance);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Leadsource", DbType.String, objProsp.LeadSource);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Model", DbType.String, objProsp.Model);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ModelId", DbType.Int32, objProsp.ModelId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objProsp.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StateId", DbType.Int32, objProsp.StateId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeInMkModel", DbType.String, objProsp.TradeInMkModel);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Comment", DbType.String, objProsp.Comment);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeIn", DbType.Boolean, objProsp.TradeIn);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objProsp.IsDeleted);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsFleetLead", DbType.Boolean, objProsp.IsFleetLead);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "WhereDidUHear", DbType.Int32, objProsp.WhereDidUHear);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Used", DbType.Int32, objProsp.Used);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDuplicate", DbType.String, objProsp.IsDuplicate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FConsultantantID", DbType.Int64, objProsp.FConsultId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FCStatusId", DbType.Int64, objProsp.FCStatusId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsFinanceSource", DbType.String, objProsp.IsFinanceSource);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
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
                logger.Error(ex.Message + "ProspectsDAO.AddProspect Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 19 Feb 2014
        /// Description: Add Prospects & Trade In Details
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public Int64 AddProspectTradeIn(Prospect objProsp, TradeIn ObjTradeIn)
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
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddProspects");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objProsp.ProspId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspKey", DbType.String, objProsp.ProspKey);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FName", DbType.String, objProsp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MName", DbType.String, objProsp.MName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "LName", DbType.String, objProsp.LName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Title", DbType.Int32, objProsp.Title);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CarMake", DbType.Int32, objProsp.CarMake);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Phone", DbType.String, objProsp.Phone);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedPhone", DbType.Int64, objProsp.formatedPhoNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Mobile", DbType.String, objProsp.Mobile);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedMobile", DbType.Int64, objProsp.formatedMobNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "AltContact", DbType.String, objProsp.AltContact);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedAltNo", DbType.Int64, objProsp.formatedAltCon);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Fax", DbType.String, objProsp.Fax);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedFax", DbType.Int64, objProsp.formatedFax);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email1", DbType.String, objProsp.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email2", DbType.String, objProsp.Email1);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Add1", DbType.String, objProsp.Add1);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Add2", DbType.String, objProsp.Add2);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Add3", DbType.String, objProsp.Add3);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CityId", DbType.Int64, objProsp.CityId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PostalCode", DbType.String, objProsp.PostalCode);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MemberNo", DbType.String, objProsp.MemberNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultId", DbType.Int64, objProsp.ConsultId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FConsultant", DbType.String, objProsp.FConsultant);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StatusId", DbType.Int64, objProsp.StatusId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SourceId", DbType.Int16, objProsp.SourceId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Finance", DbType.Int16, objProsp.Finance);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Leadsource", DbType.String, objProsp.LeadSource);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Model", DbType.String, objProsp.Model);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ModelId", DbType.Int32, objProsp.ModelId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objProsp.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StateId", DbType.Int32, objProsp.StateId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeInMkModel", DbType.String, objProsp.TradeInMkModel);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Comment", DbType.String, objProsp.Comment);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeIn", DbType.Boolean, objProsp.TradeIn);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objProsp.IsDeleted);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsFleetLead", DbType.Boolean, objProsp.IsFleetLead);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "WhereDidUHear", DbType.Int32, objProsp.WhereDidUHear);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Used", DbType.Int32, objProsp.Used);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDuplicate", DbType.String, objProsp.IsDuplicate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FConsultantantID", DbType.Int64, objProsp.FConsultId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FCStatusId", DbType.Int64, objProsp.FCStatusId);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
                    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddTradeIn");
                    //Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, ObjTradeIn.ProspId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId", DbType.Int64, Result);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "BuildPlateDate", DbType.DateTime, ObjTradeIn.BuildPlateDate);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ComplianceDate", DbType.DateTime, ObjTradeIn.ComplianceDate);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Make", DbType.String, ObjTradeIn.Make);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "MakeId", DbType.Int32, ObjTradeIn.MakeId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Model", DbType.String, ObjTradeIn.Model);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ModelId", DbType.Int32, ObjTradeIn.ModelId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Series", DbType.String, ObjTradeIn.Series);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "EngineType", DbType.String, ObjTradeIn.EngineType);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Odometer", DbType.String, ObjTradeIn.Odometer);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Transmission", DbType.String, ObjTradeIn.Transmission);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "BodyStyle", DbType.String, ObjTradeIn.BodyStyle);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ExteriorColor", DbType.String, ObjTradeIn.ExteriorColor);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "InteriorColor", DbType.String, ObjTradeIn.InteriorColor);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "RegoExpires", DbType.String, ObjTradeIn.RegoExpires);
                    //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsAC", DbType.Boolean, ObjTradeIn.IsAC);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsReverseSensor", DbType.Boolean, ObjTradeIn.IsReverseSensor);
                    //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsABS", DbType.Boolean, ObjTradeIn.IsABS);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsXenonLights", DbType.Boolean, ObjTradeIn.IsXenonLights);
                    //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsPowerSteer", DbType.Boolean, ObjTradeIn.IsPowerSteer);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsProtectionProduct", DbType.Boolean, ObjTradeIn.IsProtectionProduct);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActiveCruiseControl", DbType.Boolean, ObjTradeIn.IsActiveCruiseControl);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTowBar", DbType.Boolean, ObjTradeIn.IsTowBar);
                    //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsPowerWindows", DbType.Boolean, ObjTradeIn.IsPowerWindows);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsElectricSeats", DbType.Boolean, ObjTradeIn.IsElectricSeats);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsBullBar", DbType.Boolean, ObjTradeIn.IsBullBar);
                    //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsCentralLocking", DbType.Boolean, ObjTradeIn.IsCentralLocking);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTint", DbType.Boolean, ObjTradeIn.IsTint);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsSunroof", DbType.Boolean, ObjTradeIn.IsSunroof);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsRoofRacks", DbType.Boolean, ObjTradeIn.IsRoofRacks);
                    //Cls_DataAccess.getInstance().AddInParameter(objCmd, "CD", DbType.Int32, ObjTradeIn.CD);
                    //Cls_DataAccess.getInstance().AddInParameter(objCmd, "AirBags", DbType.String, ObjTradeIn.AirBags);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTV", DbType.Boolean, ObjTradeIn.IsTV);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsLeather", DbType.Boolean, ObjTradeIn.IsLeather);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsSideSteps", DbType.Boolean, ObjTradeIn.IsSideSteps);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsSatNav", DbType.Boolean, ObjTradeIn.IsSatNav);
                    //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsAlarm", DbType.Boolean, ObjTradeIn.IsAlarm);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsThirdRowSeats", DbType.Boolean, ObjTradeIn.IsThirdRowSeats);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "OtherOptions", DbType.String, ObjTradeIn.OtherOptions);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "RateCondition", DbType.Int32, ObjTradeIn.RateCondition);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "GlassWork", DbType.String, ObjTradeIn.GlassWork);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "BodyPanels", DbType.String, ObjTradeIn.BodyPanels);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Engine", DbType.String, ObjTradeIn.Engine);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "TransmissionDetails", DbType.String, ObjTradeIn.TransmissionDetails);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Paint", DbType.String, ObjTradeIn.Paint);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Breaks", DbType.String, ObjTradeIn.Breaks);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Tyres", DbType.String, ObjTradeIn.Tyres);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ACDetails", DbType.String, ObjTradeIn.ACDetails);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "RimAlloysDetails", DbType.String, ObjTradeIn.RimAlloysDetails);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Headlights", DbType.String, ObjTradeIn.Headlights);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Upholstery", DbType.String, ObjTradeIn.Upholstery);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "SpareTyre", DbType.String, ObjTradeIn.SpareTyre);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "VehicleCondition", DbType.String, ObjTradeIn.VehicleCondition);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "DamageDetails", DbType.String, ObjTradeIn.DamageDetails);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Owners", DbType.Int32, ObjTradeIn.Owners);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "TyreHistory", DbType.String, ObjTradeIn.TyreHistory);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ServiceHistory", DbType.String, ObjTradeIn.ServiceHistory);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Payout", DbType.String, ObjTradeIn.Payout);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "OtherDescription", DbType.String, ObjTradeIn.OtherDescription);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, ObjTradeIn.IsDeleted);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, ObjTradeIn.CreatedById);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeIn", DbType.Int64, ObjTradeIn.TradeInNo);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ModifiedById", DbType.Int64, ObjTradeIn.ModifiedById);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedDate", DbType.DateTime, ObjTradeIn.CreatedDate);
                    //Cls_DataAccess.getInstance().AddInParameter(objCmd, "ModifiedDate", DbType.DateTime, ObjTradeIn.ModifiedDate);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "DeliveryDate", DbType.DateTime, ObjTradeIn.DeliveryDate);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsPanoramic", DbType.Boolean, ObjTradeIn.IsPanoramic);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTimingBeltChanged", DbType.Boolean, ObjTradeIn.IsTimingBeltChanged);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "WheelsAlloys", DbType.String, ObjTradeIn.WheelsAlloys);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsLaneChangeAssist", DbType.Boolean, ObjTradeIn.IsLaneChangeAssist);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsBluetoothFactory", DbType.Boolean, ObjTradeIn.IsBluetoothFactory);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsReverseCamera", DbType.Boolean, ObjTradeIn.IsReverseCamera);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsFourByFour", DbType.Boolean, ObjTradeIn.IsFourByFour);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTwoByTwo", DbType.Boolean, ObjTradeIn.IsTwoByTwo);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FuelType", DbType.String, ObjTradeIn.FuelType);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Door", DbType.String, ObjTradeIn.Door);

                    Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                    if (Result > 0)
                    {
                        objTran.Commit();
                        return Result;
                    }
                    else
                    {
                        objTran.Rollback();
                        return Result;
                    }
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
                logger.Error(ex.Message + "ProspectsDAO.AddProspectTradeIn Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 18 Feb 2014
        /// Description: Add TradeIn Details
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public Int64 AddTradeIn(TradeIn ObjTradeIn)
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
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId", DbType.Int64, ObjTradeIn.ProspectId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "BuildPlateDate", DbType.DateTime, ObjTradeIn.BuildPlateDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ComplianceDate", DbType.DateTime, ObjTradeIn.ComplianceDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Make", DbType.String, ObjTradeIn.Make);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MakeId", DbType.Int32, ObjTradeIn.MakeId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Model", DbType.String, ObjTradeIn.Model);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ModelId", DbType.Int32, ObjTradeIn.ModelId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Series", DbType.String, ObjTradeIn.Series);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "EngineType", DbType.String, ObjTradeIn.EngineType);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Odometer", DbType.String, ObjTradeIn.Odometer);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Transmission", DbType.String, ObjTradeIn.Transmission);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "BodyStyle", DbType.String, ObjTradeIn.BodyStyle);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ExteriorColor", DbType.String, ObjTradeIn.ExteriorColor);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "InteriorColor", DbType.String, ObjTradeIn.InteriorColor);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "RegoExpires", DbType.String, ObjTradeIn.RegoExpires);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsAC", DbType.Boolean, ObjTradeIn.IsAC);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsReverseSensor", DbType.Boolean, ObjTradeIn.IsReverseSensor);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsABS", DbType.Boolean, ObjTradeIn.IsABS);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsXenonLights", DbType.Boolean, ObjTradeIn.IsXenonLights);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsPowerSteer", DbType.Boolean, ObjTradeIn.IsPowerSteer);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsProtectionProduct", DbType.Boolean, ObjTradeIn.IsProtectionProduct);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActiveCruiseControl", DbType.Boolean, ObjTradeIn.IsActiveCruiseControl);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTowBar", DbType.Boolean, ObjTradeIn.IsTowBar);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsPowerWindows", DbType.Boolean, ObjTradeIn.IsPowerWindows);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsElectricSeats", DbType.Boolean, ObjTradeIn.IsElectricSeats);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsBullBar", DbType.Boolean, ObjTradeIn.IsBullBar);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsCentralLocking", DbType.Boolean, ObjTradeIn.IsCentralLocking);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTint", DbType.Boolean, ObjTradeIn.IsTint);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsSunroof", DbType.Boolean, ObjTradeIn.IsSunroof);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsRoofRacks", DbType.Boolean, ObjTradeIn.IsRoofRacks);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "CD", DbType.Int32, ObjTradeIn.CD);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "AirBags", DbType.String, ObjTradeIn.AirBags);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTV", DbType.Boolean, ObjTradeIn.IsTV);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsLeather", DbType.Boolean, ObjTradeIn.IsLeather);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsSideSteps", DbType.Boolean, ObjTradeIn.IsSideSteps);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsSatNav", DbType.Boolean, ObjTradeIn.IsSatNav);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsAlarm", DbType.Boolean, ObjTradeIn.IsAlarm);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsThirdRowSeats", DbType.Boolean, ObjTradeIn.IsThirdRowSeats);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "OtherOptions", DbType.String, ObjTradeIn.OtherOptions);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "RateCondition", DbType.Int32, ObjTradeIn.RateCondition);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "GlassWork", DbType.String, ObjTradeIn.GlassWork);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "BodyPanels", DbType.String, ObjTradeIn.BodyPanels);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Engine", DbType.String, ObjTradeIn.Engine);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TransmissionDetails", DbType.String, ObjTradeIn.TransmissionDetails);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Paint", DbType.String, ObjTradeIn.Paint);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Breaks", DbType.String, ObjTradeIn.Breaks);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Tyres", DbType.String, ObjTradeIn.Tyres);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ACDetails", DbType.String, ObjTradeIn.ACDetails);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "RimAlloysDetails", DbType.String, ObjTradeIn.RimAlloysDetails);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Headlights", DbType.String, ObjTradeIn.Headlights);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Upholstery", DbType.String, ObjTradeIn.Upholstery);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SpareTyre", DbType.String, ObjTradeIn.SpareTyre);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "VehicleCondition", DbType.String, ObjTradeIn.VehicleCondition);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "DamageDetails", DbType.String, ObjTradeIn.DamageDetails);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Owners", DbType.Int32, ObjTradeIn.Owners);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TyreHistory", DbType.String, ObjTradeIn.TyreHistory);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ServiceHistory", DbType.String, ObjTradeIn.ServiceHistory);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Payout", DbType.String, ObjTradeIn.Payout);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "OtherDescription", DbType.String, ObjTradeIn.OtherDescription);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, ObjTradeIn.IsDeleted);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, ObjTradeIn.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeInNo", DbType.Int64, ObjTradeIn.TradeInNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ModifiedById", DbType.Int64, ObjTradeIn.ModifiedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedDate", DbType.DateTime, ObjTradeIn.CreatedDate);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "ModifiedDate", DbType.DateTime, ObjTradeIn.ModifiedDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "DeliveryDate", DbType.DateTime, ObjTradeIn.DeliveryDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsPanoramic", DbType.Boolean, ObjTradeIn.IsPanoramic);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTimingBeltChanged", DbType.Boolean, ObjTradeIn.IsTimingBeltChanged);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "WheelsAlloys", DbType.String, ObjTradeIn.WheelsAlloys);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsLaneChangeAssist", DbType.Boolean, ObjTradeIn.IsLaneChangeAssist);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsBluetoothFactory", DbType.Boolean, ObjTradeIn.IsBluetoothFactory);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsReverseCamera", DbType.Boolean, ObjTradeIn.IsReverseCamera);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsFourByFour", DbType.Boolean, ObjTradeIn.IsFourByFour);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTwoByTwo", DbType.Boolean, ObjTradeIn.IsTwoByTwo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FuelType", DbType.String, ObjTradeIn.FuelType);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Door", DbType.String, ObjTradeIn.Door);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
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

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 18 Feb 2014
        /// Description: Add TradeIn Details
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public Int64 UpdateTradeIn(TradeIn ObjTradeIn)
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
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateTradeIn");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, ObjTradeIn.Id);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId", DbType.Int64, ObjTradeIn.ProspectId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "BuildPlateDate", DbType.DateTime, ObjTradeIn.BuildPlateDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ComplianceDate", DbType.DateTime, ObjTradeIn.ComplianceDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Make", DbType.String, ObjTradeIn.Make);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MakeId", DbType.Int32, ObjTradeIn.MakeId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Model", DbType.String, ObjTradeIn.Model);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ModelId", DbType.Int32, ObjTradeIn.ModelId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Series", DbType.String, ObjTradeIn.Series);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "EngineType", DbType.String, ObjTradeIn.EngineType);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Odometer", DbType.String, ObjTradeIn.Odometer);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Transmission", DbType.String, ObjTradeIn.Transmission);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "BodyStyle", DbType.String, ObjTradeIn.BodyStyle);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ExteriorColor", DbType.String, ObjTradeIn.ExteriorColor);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "InteriorColor", DbType.String, ObjTradeIn.InteriorColor);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "RegoExpires", DbType.String, ObjTradeIn.RegoExpires);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsAC", DbType.Boolean, ObjTradeIn.IsAC);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsReverseSensor", DbType.Boolean, ObjTradeIn.IsReverseSensor);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsABS", DbType.Boolean, ObjTradeIn.IsABS);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsXenonLights", DbType.Boolean, ObjTradeIn.IsXenonLights);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsPowerSteer", DbType.Boolean, ObjTradeIn.IsPowerSteer);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsProtectionProduct", DbType.Boolean, ObjTradeIn.IsProtectionProduct);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActiveCruiseControl", DbType.Boolean, ObjTradeIn.IsActiveCruiseControl);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTowBar", DbType.Boolean, ObjTradeIn.IsTowBar);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsPowerWindows", DbType.Boolean, ObjTradeIn.IsPowerWindows);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsElectricSeats", DbType.Boolean, ObjTradeIn.IsElectricSeats);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsBullBar", DbType.Boolean, ObjTradeIn.IsBullBar);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsCentralLocking", DbType.Boolean, ObjTradeIn.IsCentralLocking);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTint", DbType.Boolean, ObjTradeIn.IsTint);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsSunroof", DbType.Boolean, ObjTradeIn.IsSunroof);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsRoofRacks", DbType.Boolean, ObjTradeIn.IsRoofRacks);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "CD", DbType.Int32, ObjTradeIn.CD);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "AirBags", DbType.String, ObjTradeIn.AirBags);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTV", DbType.Boolean, ObjTradeIn.IsTV);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsLeather", DbType.Boolean, ObjTradeIn.IsLeather);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsSideSteps", DbType.Boolean, ObjTradeIn.IsSideSteps);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsSatNav", DbType.Boolean, ObjTradeIn.IsSatNav);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsAlarm", DbType.Boolean, ObjTradeIn.IsAlarm);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsThirdRowSeats", DbType.Boolean, ObjTradeIn.IsThirdRowSeats);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "OtherOptions", DbType.String, ObjTradeIn.OtherOptions);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "RateCondition", DbType.Int32, ObjTradeIn.RateCondition);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "GlassWork", DbType.String, ObjTradeIn.GlassWork);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "BodyPanels", DbType.String, ObjTradeIn.BodyPanels);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Engine", DbType.String, ObjTradeIn.Engine);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TransmissionDetails", DbType.String, ObjTradeIn.TransmissionDetails);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Paint", DbType.String, ObjTradeIn.Paint);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Breaks", DbType.String, ObjTradeIn.Breaks);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Tyres", DbType.String, ObjTradeIn.Tyres);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ACDetails", DbType.String, ObjTradeIn.ACDetails);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "RimAlloysDetails", DbType.String, ObjTradeIn.RimAlloysDetails);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Headlights", DbType.String, ObjTradeIn.Headlights);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Upholstery", DbType.String, ObjTradeIn.Upholstery);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SpareTyre", DbType.String, ObjTradeIn.SpareTyre);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "VehicleCondition", DbType.String, ObjTradeIn.VehicleCondition);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "DamageDetails", DbType.String, ObjTradeIn.DamageDetails);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Owners", DbType.Int32, ObjTradeIn.Owners);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TyreHistory", DbType.String, ObjTradeIn.TyreHistory);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ServiceHistory", DbType.String, ObjTradeIn.ServiceHistory);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Payout", DbType.String, ObjTradeIn.Payout);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "OtherDescription", DbType.String, ObjTradeIn.OtherDescription);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, ObjTradeIn.IsDeleted);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, ObjTradeIn.CreatedById);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeInNo", DbType.Int64, ObjTradeIn.TradeInNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ModifiedById", DbType.Int64, ObjTradeIn.ModifiedById);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedDate", DbType.DateTime, ObjTradeIn.CreatedDate);
                //Cls_DataAccess.getInstance().AddInParameter(objCmd, "ModifiedDate", DbType.DateTime, ObjTradeIn.ModifiedDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "DeliveryDate", DbType.DateTime, ObjTradeIn.DeliveryDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsPanoramic", DbType.Boolean, ObjTradeIn.IsPanoramic);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTimingBeltChanged", DbType.Boolean, ObjTradeIn.IsTimingBeltChanged);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "WheelsAlloys", DbType.String, ObjTradeIn.WheelsAlloys);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsLaneChangeAssist", DbType.Boolean, ObjTradeIn.IsLaneChangeAssist);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsBluetoothFactory", DbType.Boolean, ObjTradeIn.IsBluetoothFactory);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsReverseCamera", DbType.Boolean, ObjTradeIn.IsReverseCamera);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsFourByFour", DbType.Boolean, ObjTradeIn.IsFourByFour);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsTwoByTwo", DbType.Boolean, ObjTradeIn.IsTwoByTwo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FuelType", DbType.String, ObjTradeIn.FuelType);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Door", DbType.String, ObjTradeIn.Door);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
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

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 20 Feb 2014
        /// Description: Get Total TradeIn Count Of Prospect
        /// </summary>
        /// <param name="ProspectId"></param>
        /// <returns></returns>
        public DataTable GetTradeInCount(Int64 ProspectId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetTradeInCount");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId", DbType.Int64, ProspectId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetTradeInCount Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 20 Feb 2014
        /// Description: Get Total TradeIn Count Of Prospect
        /// </summary>
        /// <param name="ProspectId"></param>
        /// <returns></returns>>
        public DataTable GetAllTradeInProspect(Prospect objProsp)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetProspTradeIn");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId", DbType.Int64, objProsp.ProspId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetAllTradeInProspect Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 20 Feb 2014
        /// Description: Get Total TradeIn Count Of Prospect
        /// </summary>
        /// <param name="TradeInId"></param>
        /// <returns></returns>>
        public DataTable GetTradeInFromId(Int64 TradeInId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetTradeInDetFromId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.String, TradeInId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetTradeInFromId Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 May 2013
        /// Description: Update Prospect Details
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Int64 UpdateProspect(Prospect objProsp)
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
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateProspects");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objProsp.ProspId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspKey", DbType.String, objProsp.ProspKey);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FName", DbType.String, objProsp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MName", DbType.String, objProsp.MName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "LName", DbType.String, objProsp.LName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Title", DbType.Int32, objProsp.Title);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CarMake", DbType.Int32, objProsp.CarMake);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Phone", DbType.String, objProsp.Phone);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedPhone", DbType.Int64, objProsp.formatedPhoNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Mobile", DbType.String, objProsp.Mobile);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedMobile", DbType.Int64, objProsp.formatedMobNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "AltContact", DbType.String, objProsp.AltContact);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedAltNo", DbType.Int64, objProsp.formatedAltCon);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Fax", DbType.String, objProsp.Fax);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedFax", DbType.Int64, objProsp.formatedFax);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email1", DbType.String, objProsp.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email2", DbType.String, objProsp.Email1);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Add1", DbType.String, objProsp.Add1);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Add2", DbType.String, objProsp.Add2);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Add3", DbType.String, objProsp.Add3);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CityId", DbType.Int64, objProsp.CityId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PostalCode", DbType.String, objProsp.PostalCode);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MemberNo", DbType.String, objProsp.MemberNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultId", DbType.Int64, objProsp.ConsultId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FConsultant", DbType.String, objProsp.FConsultant);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StatusId", DbType.Int64, objProsp.StatusId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SourceId", DbType.Int16, objProsp.SourceId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Finance", DbType.Int16, objProsp.Finance);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Leadsource", DbType.String, objProsp.LeadSource);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Model", DbType.String, objProsp.Model);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ModelId", DbType.Int32, objProsp.ModelId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objProsp.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objProsp.IsDeleted);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StateId", DbType.Int32, objProsp.StateId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeInMkModel", DbType.String, objProsp.TradeInMkModel);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Comment", DbType.String, objProsp.Comment);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeIn", DbType.Boolean, objProsp.TradeIn);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsFleetLead", DbType.Boolean, objProsp.IsFleetLead);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "WhereDidUHear", DbType.Int32, objProsp.WhereDidUHear);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Used", DbType.Int32, objProsp.Used);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FConsultantantID", DbType.Int64, objProsp.FConsultId);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
                    //for (int i = 0; i < objProsp.LstProspContact.Count; i++)
                    //{
                    //    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateProspContact");
                    //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objProsp.LstProspContact[i].ProspContactId);
                    //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspId", DbType.Int64, objProsp.ProspId);
                    //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ContactId", DbType.Int64, objProsp.LstProspContact[i].ContactId);
                    //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsPrimary", DbType.Boolean, objProsp.LstProspContact[i].IsPrimary);
                    //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objProsp.CreatedById);
                    //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objProsp.LstProspContact[i].IsDeleted);
                    //    Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                    //    if (Result < 0)
                    //    {
                    //        objTran.Rollback();
                    //        return Result;
                    //    }
                    //}
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
                logger.Error(ex.Message + "ProspectsDAO.UpdateProspect Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 May 2013
        /// Description: Delete Prospect Details
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Int64 DeleteProspect(Prospect objProsp)
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
                //for (int i = 0; i < objProsp.LstProspContact.Count; i++)
                //{
                //    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_DeleteProspContact");
                //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objProsp.LstProspContact[i].ProspContactId);
                //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objProsp.CreatedById);
                //    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objProsp.IsDeleted);
                //    Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                //    if (Result < 0 && Result == -9)
                //    {
                //        objTran.Rollback();
                //        return Result;
                //    }
                //}
                //if (Result > 0 && objProsp.IsDeleted == true)
                //{
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_DeleteProspects");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objProsp.ProspId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objProsp.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objProsp.IsDeleted);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
                    objTran.Commit();
                    return Result;
                }
                else
                {
                    objTran.Rollback();
                    return Result;
                }
                //}
                //else
                //{
                //    objTran.Rollback();
                //    return Result;
                //}
            }
            catch (Exception ex)
            {
                objTran.Rollback();
                logger.Error(ex.Message + "ProspectsDAO.DeleteProspect Error:" + ex.StackTrace);
                return 0;
            }
        }

        ///// <summary>
        ///// Created By: Pravin Gholap
        ///// Created Date: 23 May 2013
        ///// Description: Get All Prospects
        ///// </summary>
        ///// <param name="objProsp"></param>
        ///// <returns></returns>
        //public DataTable GetAllProspects(Prospect objProsp)
        //{
        //    DbCommand objCmd = null;
        //    DataTable DtResult = new DataTable();
        //    try
        //    {
        //        objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllProspects");
        //        objCmd.CommandTimeout = 100;
        //        Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, objProsp.FName);
        //        Cls_DataAccess.getInstance().AddInParameter(objCmd, "Status", DbType.Int64, objProsp.StatusId);
        //        Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email", DbType.String, objProsp.Email);
        //        DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
        //        return DtResult;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex.Message + "ProspectsDAO.GetAllProspects Error:" + ex.StackTrace);
        //        return null;
        //    }
        //}

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 May 2013
        /// Description: Get All Prospects
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataSet GetAllProspects(Prospect objProsp)
        {
            DbCommand objCmd = null;
            DataSet DsResult = new DataSet();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllProspects");
                objCmd.CommandTimeout = 100;
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, objProsp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Status", DbType.Int64, objProsp.StatusId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email", DbType.String, objProsp.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageIndex", DbType.Int64, objProsp.PageIndex);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageSize", DbType.Int64, objProsp.PageSize);
                DsResult = Cls_DataAccess.getInstance().GetDataSet(objCmd);
                return DsResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetAllProspects Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Chetan Shejole
        /// Created Date: 26 Sep 2014
        /// Description: Get All Prospects to bind dropdown
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataSet GetAllProspects_BindDrop(Prospect objProsp)
        {
            DbCommand objCmd = null;
            DataSet DsResult = new DataSet();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllProspects_BindDrop");
                objCmd.CommandTimeout = 100;
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, objProsp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Status", DbType.Int64, objProsp.StatusId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email", DbType.String, objProsp.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageIndex", DbType.Int64, objProsp.PageIndex);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageSize", DbType.Int64, objProsp.PageSize);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultId", DbType.Int64, objProsp.ConsultId);
                DsResult = Cls_DataAccess.getInstance().GetDataSet(objCmd);
                return DsResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetAllProspects_BindDrop Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 May 2013
        /// Description: Get Prospect Details From Prospect Id
        /// </summary>
        /// <param name="ProspId"></param>
        /// <returns></returns>
        public DataTable GetProspectsFromId(Int64 ProspId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetProspDetFromId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.String, ProspId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetProspectsFromId Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 24 May 2013
        /// Description: Get Prospect Contact Details From Prospect Id
        /// </summary>
        /// <param name="ProspId"></param>
        /// <returns></returns>
        public DataTable GetProspConDetailFromProspId(Int64 ProspId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetProspContDetFromProId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspId", DbType.String, ProspId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetProspConDetailFromProspId Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 30 May 2013
        /// Description: Add Prospects Details From Service
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Int64 AddProspectFromServ(Prospect objProsp)
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
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddProspectsFromServ");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspKey", DbType.String, objProsp.ProspKey);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FName", DbType.String, objProsp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MName", DbType.String, objProsp.MName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "LName", DbType.String, objProsp.LName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CarMake", DbType.Int32, objProsp.CarMake);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Phone", DbType.String, objProsp.Phone);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Mobile", DbType.String, objProsp.Mobile);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email1", DbType.String, objProsp.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CityId", DbType.Int64, objProsp.CityId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StateId", DbType.Int32, objProsp.StateId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PostalCode", DbType.String, objProsp.PostalCode);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "LeadSource", DbType.String, objProsp.LeadSource);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Finance", DbType.Boolean, objProsp.IsFinance);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeIn", DbType.Boolean, objProsp.TradeIn);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActive", DbType.Boolean, objProsp.IsActive);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeInMkModel", DbType.String, objProsp.TradeInMkModel);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Comment", DbType.String, objProsp.Comment);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Model", DbType.String, objProsp.Model);
                if (objProsp.ValueforAnswer.Trim().ToUpper() != "PLEASE CHOOSE")
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "WhereDidUHear", DbType.String, objProsp.ValueforAnswer);
                if (objProsp.Used != false)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Used", DbType.Int32, objProsp.Used);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsFinanceSource", DbType.String, objProsp.IsFinanceSource);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDuplicate", DbType.String, objProsp.IsDuplicate);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
                    objTran.Commit();
                    return Result;
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
                logger.Error(ex.Message + "ProspectsDAO.AddProspectFromServ Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 3 June 2013
        /// Description: Get Total Enquiry Count From Date Range
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public DataTable GetTotalLeadCount(DateTime FromDate, DateTime ToDate)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetTotalEnqCount");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, FromDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, ToDate);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetTotalLeadCount Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 3 June 2013
        /// Description: Get Total Unallocated Enquiry Count From Date Range
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public DataTable GetUnAlocatedEnqCount(DateTime FromDate, DateTime ToDate)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetUnAlocatedEnqCount");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, FromDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, ToDate);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetUnAlocatedEnqCount Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 3 June 2013
        /// Description: Get Oldest Enquiry Date
        /// </summary>
        public DataTable GetOldestEnquiryDate()
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetOldestEnquiryDate");
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetOldestEnquiryDate Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 3 June 2013
        /// Description: Assign Leads To Consultant In Bulk
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable AssignLeadsToConsultant(Prospect objProsp)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            int Result = 0;
            //DbConnection objConn = null;
            //DbTransaction objTran = null;
            DataTable dtFinalresult = new DataTable();
            try
            {
                //objConn = Cls_DataAccess.getInstance().GetConnection();
                //objConn.Open();
                dtFinalresult = CreateTable();
                //objTran = objConn.BeginTransaction();
                for (int i = 0; i < objProsp.lstAllocation.Count; i++)
                {
                    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AssignLeadsToConsultant");
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultantId", DbType.Int64, objProsp.lstAllocation[i].ConsultantId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "NoOfLeads", DbType.Int32, objProsp.lstAllocation[i].Noofleads);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, objProsp.FromDate);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, objProsp.ToDate);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objProsp.CreatedById);
                    DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                    Result = DtResult.Rows.Count;
                    if (DtResult != null && DtResult.Rows.Count > 0)
                    {
                        for (int j = 0; j < DtResult.Rows.Count; j++)
                        {
                            DataRow dr = dtFinalresult.NewRow();
                            dr["Id"] = DtResult.Rows[j]["Id"].ToString().Trim();
                            dr["ProspectName"] = DtResult.Rows[j]["Name"].ToString().Trim();
                            dr["Mobile"] = DtResult.Rows[j]["Mobile"].ToString().Trim();
                            dr["Email"] = DtResult.Rows[j]["Email1"].ToString().Trim();
                            dr["ConsultantName"] = DtResult.Rows[j]["ConsultantName"].ToString().Trim();
                            dr["ConsultMobile"] = DtResult.Rows[j]["ConsultMobile"].ToString().Trim();
                            dr["ConsultEmail"] = DtResult.Rows[j]["ConsultEmail"].ToString().Trim();
                            dr["ConsultPhone"] = DtResult.Rows[j]["ConsultPhone"].ToString().Trim();
                            dr["EnquiryDate"] = DtResult.Rows[j]["EnquiryDate"].ToString().Trim();
                            dr["ProspFName"] = DtResult.Rows[j]["FirstNName"].ToString().Trim();
                            dr["Ext"] = DtResult.Rows[j]["Ext"].ToString().Trim();
                            dr["ConsultName"] = DtResult.Rows[j]["ConsultName"].ToString().Trim();
                            dr["ConsultantId"] = DtResult.Rows[j]["ConsultantId"].ToString().Trim();
                            dtFinalresult.Rows.Add(dr);
                        }
                    }
                    //if (Result > 0)
                    //{
                    //    objTran.Commit();
                    //    return Result;
                    //}
                }
                return dtFinalresult;
                //if (Result > 0)
                //{
                //    objTran.Commit();
                //    return Result;
                //}
                //else
                //{
                //    objTran.Rollback();
                //    return Result;
                //}
            }
            catch (Exception ex)
            {
                //objTran.Rollback();
                logger.Error(ex.Message + "ProspectsDAO.AssignLeadsToConsultant Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 4 June 2013
        /// Description: Get Unallocated Enquiry Details
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <param name="Flag"></param>
        /// <returns></returns>
        public DataTable GetUnalocatedProspDet(DateTime FromDate, DateTime ToDate, string Flag, Int64 ConsultantId, string FCFlag)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetUnalocatedProspDet");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, FromDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, ToDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Flag", DbType.String, Flag);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultantId", DbType.Int64, ConsultantId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FCFlag ", DbType.String, FCFlag);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetUnalocatedProspDet Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 4 June 2013
        /// Description: Get Prospects Details which are assigned to given consultant
        /// <param name="VirtualRoleId"></param>
        /// </summary>
        public DataTable GetProspDetAssignedToConsult(Int64 VirtualRoleId, DateTime FromDate, DateTime ToDate, Int64 ProspectId)
        {
            DbCommand objCmd = null;
            DataSet DtResult = new DataSet();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetProspDetAssignedToConsult");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "VirtualRoleId", DbType.Int64, VirtualRoleId);
                if (FromDate != DateTime.MinValue)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, FromDate);
                if (ToDate != DateTime.MinValue)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, ToDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId", DbType.Int64, ProspectId);
                DtResult = Cls_DataAccess.getInstance().GetDataSet(objCmd);//GetDataTable(objCmd, null);
                return DtResult.Tables[0];
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetProspDetAssignedToConsult Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 6 June 2013
        /// Description:Return blank DataTable 
        /// </summary>
        /// <returns>DataTable</returns>
        private DataTable CreateTable()
        {
            try
            {
                DataTable Dt = new DataTable();
                DataColumn Dc1 = new DataColumn("Id");
                DataColumn Dc2 = new DataColumn("ProspectName");
                DataColumn Dc3 = new DataColumn("Mobile");
                DataColumn Dc4 = new DataColumn("Email");
                DataColumn Dc5 = new DataColumn("ConsultantName");
                DataColumn Dc6 = new DataColumn("ConsultMobile");
                DataColumn Dc7 = new DataColumn("ConsultEmail");
                DataColumn Dc8 = new DataColumn("ConsultPhone");
                DataColumn Dc9 = new DataColumn("EnquiryDate");
                DataColumn Dc10 = new DataColumn("ProspFName");
                DataColumn Dc11 = new DataColumn("Ext");
                DataColumn Dc12 = new DataColumn("ConsultName");
                DataColumn Dc13 = new DataColumn("ConsultantId");
                DataColumn Dc14 = new DataColumn("IsFleetLead");
                Dt.Columns.Add(Dc1);
                Dt.Columns.Add(Dc2);
                Dt.Columns.Add(Dc3);
                Dt.Columns.Add(Dc4);
                Dt.Columns.Add(Dc5);
                Dt.Columns.Add(Dc6);
                Dt.Columns.Add(Dc7);
                Dt.Columns.Add(Dc8);
                Dt.Columns.Add(Dc9);
                Dt.Columns.Add(Dc10);
                Dt.Columns.Add(Dc11);
                Dt.Columns.Add(Dc12);
                Dt.Columns.Add(Dc13);
                Dt.Columns.Add(Dc14);
                return Dt;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.CreateTable Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 10 June 2013
        /// Description: Get All Prospects For Consult View
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataSet GetAllProspForConsult(Prospect objProsp)
        {
            DbCommand objCmd = null;
            DataSet DsResult = new DataSet();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllProspForConsultTest");
                objCmd.CommandTimeout = 100;
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, objProsp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Status", DbType.String, objProsp.Ids);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MemNo", DbType.String, objProsp.MemberNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Make", DbType.Int32, objProsp.CarMake);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email", DbType.String, objProsp.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StateId", DbType.Int32, objProsp.StateId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CityId", DbType.Int32, objProsp.CityId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ReferenceSource", DbType.Int32, objProsp.SourceId);
                if (objProsp.FromDate != DateTime.MinValue)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, objProsp.FromDate);
                if (objProsp.ToDate != DateTime.MinValue)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, objProsp.ToDate);
                if (objProsp.CreatedById != null && objProsp.CreatedById != 0)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "VirtualRoleId", DbType.Int64, objProsp.CreatedById);
                if (!string.IsNullOrEmpty(objProsp.ValueforAnswer.Trim()))
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultType", DbType.String, objProsp.ValueforAnswer);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PhNum", DbType.String, objProsp.Phone);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PotalCode", DbType.String, objProsp.PostalCode);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageIndex", DbType.Int64, objProsp.PageIndex);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageSize", DbType.Int64, objProsp.PageSize);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SortColumn", DbType.String, objProsp.Comment);
                DsResult = Cls_DataAccess.getInstance().GetDataSet(objCmd);
                return DsResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetAllProspForConsult Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 July 2013
        /// Description: Update Prospect's Is Mail Sent's Field's Status
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="CreatedById"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public Int64 UpdateOneTimeMailStatus(Int64 Id, Int64 CreatedById, Boolean Status, string mailContent, Boolean MailSuccess)
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
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateOneTimeMailStatus");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, Id);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Status", DbType.Boolean, Status);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MailContent", DbType.String, mailContent);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MailSentSuccess", DbType.Boolean, MailSuccess);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
                    objTran.Commit();
                    return Result;
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
                logger.Error(ex.Message + "ProspectsDAO.UpdateOneTimeMailStatus Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 24 July 2013
        /// Description: Get All Fleet Team Leads For Assignments
        /// </summary>
        /// <returns></returns>
        public DataTable GetTeamLeadsForAssignments()
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetTeamLeadsForAssignments");
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetTeamLeadsForAssignments Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 24 July 2013
        /// Description: To Get Fleet Team Lead Consultant To Assign
        /// </summary>
        /// <returns></returns>
        public DataTable GetTeamLeadConsultToAssign()
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetTeamLeadConsultToAssign");
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetTeamLeadConsultToAssign Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 24 June 2013
        /// Description: Assign Fleet Team Leads To Consultant
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable AssignFleetTeamLeads(Prospect objProsp)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            int Result = 0;
            DataTable dtFinalresult = new DataTable();
            try
            {
                dtFinalresult = CreateTable();
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AssignFleetTeamLeads");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultantId", DbType.Int64, objProsp.ConsultId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId", DbType.Int64, objProsp.ProspId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objProsp.CreatedById);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                Result = DtResult.Rows.Count;
                if (DtResult != null && DtResult.Rows.Count > 0)
                {
                    for (int j = 0; j < DtResult.Rows.Count; j++)
                    {
                        DataRow dr = dtFinalresult.NewRow();
                        dr["Id"] = Convert.ToString(DtResult.Rows[j]["Id"]).Trim();
                        dr["ProspectName"] = Convert.ToString(DtResult.Rows[j]["Name"]).Trim();
                        dr["Mobile"] = Convert.ToString(DtResult.Rows[j]["Mobile"]).Trim();
                        dr["Email"] = Convert.ToString(DtResult.Rows[j]["Email1"]).Trim();
                        dr["ConsultantName"] = Convert.ToString(DtResult.Rows[j]["ConsultantName"]).Trim();
                        dr["ConsultMobile"] = Convert.ToString(DtResult.Rows[j]["ConsultMobile"]).Trim();
                        dr["ConsultEmail"] = Convert.ToString(DtResult.Rows[j]["ConsultEmail"]).Trim();
                        dr["ConsultPhone"] = Convert.ToString(DtResult.Rows[j]["ConsultPhone"]).Trim();
                        dr["EnquiryDate"] = Convert.ToString(DtResult.Rows[j]["EnquiryDate"]).Trim();
                        dr["ProspFName"] = Convert.ToString(DtResult.Rows[j]["FirstNName"]).Trim();
                        dr["Ext"] = Convert.ToString(DtResult.Rows[j]["Ext"]).Trim();
                        dr["ConsultName"] = Convert.ToString(DtResult.Rows[j]["ConsultName"]).Trim();
                        dr["ConsultantId"] = Convert.ToString(DtResult.Rows[j]["ConsultantId"]).Trim();
                        dr["IsFleetLead"] = Convert.ToString(DtResult.Rows[j]["IsFleetLead"]).Trim();
                        dtFinalresult.Rows.Add(dr);
                    }
                }
                return dtFinalresult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.AssignFleetTeamLeads Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 5 Aug 2013
        /// Description: Remove Prospect Details From Allocation 
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public Int64 RemoveFromAllocation(Prospect objProsp)
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
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_RemoveFromAllocation");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objProsp.ProspId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objProsp.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsRemoved", DbType.Boolean, objProsp.IsDeleted);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
                    objTran.Commit();
                    return Result;
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
                logger.Error(ex.Message + "ProspectsDAO.RemoveFromAllocation Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Manoj
        /// Created Date: 10 Aug 2013
        /// Description: Allocate lead to consultant through Clain Process
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Int64 AllocateLeadThroughClaim(Prospect objProsp)
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
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AllocateLeadThroughClaim");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objProsp.ProspId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultId", DbType.Int64, objProsp.ConsultId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objProsp.CreatedById);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
                    objTran.Commit();
                    return Result;
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
                logger.Error(ex.Message + "ProspectsDAO.AllocateLeadThroughClaim Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 18 Aug 2013
        /// Description: Allocate lead to consultant through Clain Process
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="FinConvienceNotes"></param>
        /// <param name="CreatedById"></param>
        /// <returns></returns>
        public Int64 SetFinanceRequired(Int64 Id, string FinConvienceNotes, Int64 CreatedById)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_SetFinanceRequired");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, Id);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FinConvienceNotes", DbType.String, FinConvienceNotes);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, CreatedById);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.SetFinanceRequired Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 17 Aug 2013
        /// Description: To Get FC's Fleet Team Lead Consultant To Assign
        /// </summary>
        /// <returns></returns>
        public DataTable GetFCTeamLeadConsultToAssign()
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetFCTeamLeadConsultToAssign");
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetFCTeamLeadConsultToAssign Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 17 Aug 2013
        /// Description: Get All FC's Fleet Team Leads For Assignments
        /// </summary>
        /// <returns></returns>
        public DataTable GetFCTeamLeadsForAssignments()
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetFCTeamLeadsForAssignments");
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetFCTeamLeadsForAssignments Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 17 Aug 2013
        /// Description: Get Total FC Enquiry Count From Date Range
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public DataTable GetFCTotalEnqCount(DateTime FromDate, DateTime ToDate)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetFCTotalEnqCount");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, FromDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, ToDate);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetFCTotalEnqCount Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 17 June 2013
        /// Description: Get Total Unallocated FC Enquiry Count From Date Range
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public DataTable GetFCUnAlocatedEnqCount(DateTime FromDate, DateTime ToDate)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetFCUnAlocatedEnqCount");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, FromDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, ToDate);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetFCUnAlocatedEnqCount Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 17 Aug 2013
        /// Description: Assign FC's Fleet Team Leads To Consultant
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable AssignFCFleetTeamLeads(Prospect objProsp)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            int Result = 0;
            DataTable dtFinalresult = new DataTable();
            try
            {
                dtFinalresult = CreateTable();
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AssignFCFleetTeamLeads");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultantId", DbType.Int64, objProsp.ConsultId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId", DbType.Int64, objProsp.ProspId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objProsp.CreatedById);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                Result = DtResult.Rows.Count;
                if (DtResult != null && DtResult.Rows.Count > 0)
                {
                    for (int j = 0; j < DtResult.Rows.Count; j++)
                    {
                        DataRow dr = dtFinalresult.NewRow();
                        dr["Id"] = DtResult.Rows[j]["Id"].ToString().Trim();
                        dr["ProspectName"] = DtResult.Rows[j]["Name"].ToString().Trim();
                        dr["Mobile"] = DtResult.Rows[j]["Mobile"].ToString().Trim();
                        dr["Email"] = DtResult.Rows[j]["Email1"].ToString().Trim();
                        dr["ConsultantName"] = DtResult.Rows[j]["ConsultantName"].ToString().Trim();
                        dr["ConsultMobile"] = DtResult.Rows[j]["ConsultMobile"].ToString().Trim();
                        dr["ConsultEmail"] = DtResult.Rows[j]["ConsultEmail"].ToString().Trim();
                        dr["ConsultPhone"] = DtResult.Rows[j]["ConsultPhone"].ToString().Trim();
                        dr["EnquiryDate"] = DtResult.Rows[j]["EnquiryDate"].ToString().Trim();
                        dr["ProspFName"] = DtResult.Rows[j]["FirstNName"].ToString().Trim();
                        dr["Ext"] = DtResult.Rows[j]["Ext"].ToString().Trim();
                        dr["ConsultName"] = DtResult.Rows[j]["ConsultName"].ToString().Trim();
                        dr["ConsultantId"] = DtResult.Rows[j]["ConsultantId"].ToString().Trim();
                        dtFinalresult.Rows.Add(dr);
                    }
                }
                return dtFinalresult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.AssignFCFleetTeamLeads Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 17 Aug 2013
        /// Description: Get Prospects Details which are assigned to given FC consultant
        /// <param name="VirtualRoleId"></param>
        /// </summary>
        public DataTable GetFCProspDetAssignedToConsult(Int64 VirtualRoleId, DateTime FromDate, DateTime ToDate, Int64 ProspectId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetFCProspDetAssignedToConsult");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "VirtualRoleId", DbType.Int64, VirtualRoleId);
                if (FromDate != DateTime.MinValue)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, FromDate);
                if (ToDate != DateTime.MinValue)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, ToDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId", DbType.Int64, ProspectId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetFCProspDetAssignedToConsult Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 17 August 2013
        /// Description: Assign Leads To FC Consultant In Bulk
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable AssignLeadsToFCConsultant(Prospect objProsp)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            int Result = 0;
            //DbConnection objConn = null;
            //DbTransaction objTran = null;
            DataTable dtFinalresult = new DataTable();
            try
            {
                //objConn = Cls_DataAccess.getInstance().GetConnection();
                //objConn.Open();
                dtFinalresult = CreateFCTable();
                //objTran = objConn.BeginTransaction();
                for (int i = 0; i < objProsp.lstAllocation.Count; i++)
                {
                    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AssignLeadsToFCConsultant");
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultantId", DbType.Int64, objProsp.lstAllocation[i].ConsultantId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "NoOfLeads", DbType.Int32, objProsp.lstAllocation[i].Noofleads);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, objProsp.FromDate);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, objProsp.ToDate);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objProsp.CreatedById);
                    DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                    Result = DtResult.Rows.Count;
                    if (DtResult != null && DtResult.Rows.Count > 0)
                    {
                        for (int j = 0; j < DtResult.Rows.Count; j++)
                        {
                            DataRow dr = dtFinalresult.NewRow();
                            dr["Id"] = DtResult.Rows[j]["Id"].ToString().Trim();
                            dr["ProspectName"] = DtResult.Rows[j]["Name"].ToString().Trim();
                            dr["Mobile"] = DtResult.Rows[j]["Mobile"].ToString().Trim();
                            dr["Email"] = DtResult.Rows[j]["Email1"].ToString().Trim();
                            dr["ConsultantName"] = DtResult.Rows[j]["ConsultantName"].ToString().Trim();
                            dr["ConsultMobile"] = DtResult.Rows[j]["ConsultMobile"].ToString().Trim();
                            dr["ConsultEmail"] = DtResult.Rows[j]["ConsultEmail"].ToString().Trim();
                            dr["ConsultPhone"] = DtResult.Rows[j]["ConsultPhone"].ToString().Trim();
                            dr["EnquiryDate"] = DtResult.Rows[j]["EnquiryDate"].ToString().Trim();
                            dr["ProspFName"] = DtResult.Rows[j]["FirstNName"].ToString().Trim();
                            dr["Ext"] = DtResult.Rows[j]["Ext"].ToString().Trim();
                            dr["ConsultName"] = DtResult.Rows[j]["ConsultName"].ToString().Trim();
                            dr["ConsultantId"] = DtResult.Rows[j]["ConsultantId"].ToString().Trim();
                            dr["RefConsultFullName"] = DtResult.Rows[j]["RefConsultFullName"].ToString().Trim();
                            dr["RefConsultName"] = DtResult.Rows[j]["RefConsultName"].ToString().Trim();
                            dr["IsFinanceSource"] = DtResult.Rows[j]["IsFinanceSource"].ToString().Trim();
                            dr["RefConsultMobile"] = DtResult.Rows[j]["RefConsultMobile"].ToString().Trim();
                            dr["RefConsultEmail"] = DtResult.Rows[j]["RefConsultEmail"].ToString().Trim();
                            dr["RefConsultPhone"] = DtResult.Rows[j]["RefConsultPhone"].ToString().Trim();
                            dtFinalresult.Rows.Add(dr);
                        }
                    }
                    //if (Result > 0)
                    //{
                    //    objTran.Commit();
                    //    return Result;
                    //}
                }
                return dtFinalresult;
                //if (Result > 0)
                //{
                //    objTran.Commit();
                //    return Result;
                //}
                //else
                //{
                //    objTran.Rollback();
                //    return Result;
                //}
            }
            catch (Exception ex)
            {
                //objTran.Rollback();
                logger.Error(ex.Message + "ProspectsDAO.AssignLeadsToFCConsultant Error:" + ex.StackTrace);
                return null;
            }
        }

        public DataTable IsQuoteExist(Prospect prospect)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "usp_IsQuoteExist");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspId", DbType.Int64, prospect.ProspId);
                return Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.IsQuoteExist Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 18 Aug 2013
        /// Description: Get Prospect's FC Details From Prospect Id
        /// </summary>
        /// <param name="ProspId"></param>
        /// <returns></returns>
        public DataTable GetProspFCDetFromProId(Int64 ProspId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetProspFCDetFromProId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspId", DbType.String, ProspId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetProspFCDetFromProId Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Kalpana Shinde
        /// Created Date: 21 Aug 2013
        /// Description: Get all not yet called PF and FC
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>  
        /// <param name="VirtualRoleId"></param>
        /// <param name="ConsultType"></param>  
        /// <returns></returns>
        public DataSet GetAllNYCForPFAndFC(DateTime FromDate, DateTime ToDate, Int64 ConsultantId, string FCFlag, string Flag, Int64 PageIndex, Int64 PageSize, string SortColumn)
        {
            DbCommand objCmd = null;
            DataSet DsResult = new DataSet();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllNYCForPFAndFC");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, FromDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, ToDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Flag", DbType.String, Flag);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "VirtualRoleId", DbType.Int64, ConsultantId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultType ", DbType.String, FCFlag);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageIndex", DbType.Int64, PageIndex);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageSize ", DbType.Int64, PageSize);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SortColumn ", DbType.String, SortColumn);
                DsResult = Cls_DataAccess.getInstance().GetDataSet(objCmd);
                return DsResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetAllNYCForPFAndFC Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 27 Aug 2013
        /// Description: Add Prospects Details From Service From PrivateFleet.com.au
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public Int64 AddProspectsFromPFServ(Prospect objProsp)
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
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddProspectsFromPFServ");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspKey", DbType.String, objProsp.ProspKey);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FName", DbType.String, objProsp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MName", DbType.String, objProsp.MName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "LName", DbType.String, objProsp.LName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Make", DbType.String, objProsp.Make);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Phone", DbType.String, objProsp.Phone);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Mobile", DbType.String, objProsp.Mobile);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email1", DbType.String, objProsp.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "City", DbType.String, objProsp.City);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "State", DbType.String, objProsp.State);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PostalCode", DbType.String, objProsp.PostalCode);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "LeadSource", DbType.String, objProsp.LeadSource);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Finance", DbType.Boolean, objProsp.IsFinance);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeIn", DbType.Boolean, objProsp.TradeIn);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActive", DbType.Boolean, objProsp.IsActive);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeInMkModel", DbType.String, objProsp.TradeInMkModel);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Comment", DbType.String, objProsp.Comment);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Model", DbType.String, objProsp.Model);
                if (objProsp.ValueforAnswer.Trim().ToUpper() != "PLEASE CHOOSE")
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "WhereDidUHear", DbType.String, objProsp.ValueforAnswer);
                if (objProsp.Used != false)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Used", DbType.Boolean, objProsp.Used);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsFinanceSource", DbType.String, objProsp.IsFinanceSource);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDuplicate", DbType.String, objProsp.IsDuplicate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "AlternateNo", DbType.String, objProsp.AltContact);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
                    objTran.Commit();
                    return Result;
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
                logger.Error(ex.Message + "ProspectsDAO.AddProspectsFromPFServ Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Kalpana Shinde
        /// Created Date: 29 Aug 2013
        /// Description: Get All Lead Details for View
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable GetProspectStats(Prospect objProsp)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetProspectStats");
                //if (objProsp.FromDate != DateTime.MinValue)
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, objProsp.FromDate);
                //if (objProsp.ToDate != DateTime.MinValue)
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, objProsp.ToDate);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetProspectStats Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 31 August 2013
        /// Description:Return blank DataTable 
        /// </summary>
        /// <returns>DataTable</returns>
        private DataTable CreateFCTable()
        {
            try
            {
                DataTable Dt = new DataTable();
                DataColumn Dc1 = new DataColumn("Id");
                DataColumn Dc2 = new DataColumn("ProspectName");
                DataColumn Dc3 = new DataColumn("Mobile");
                DataColumn Dc4 = new DataColumn("Email");
                DataColumn Dc5 = new DataColumn("ConsultantName");
                DataColumn Dc6 = new DataColumn("ConsultMobile");
                DataColumn Dc7 = new DataColumn("ConsultEmail");
                DataColumn Dc8 = new DataColumn("ConsultPhone");
                DataColumn Dc9 = new DataColumn("EnquiryDate");
                DataColumn Dc10 = new DataColumn("ProspFName");
                DataColumn Dc11 = new DataColumn("Ext");
                DataColumn Dc12 = new DataColumn("ConsultName");
                DataColumn Dc13 = new DataColumn("ConsultantId");
                DataColumn Dc14 = new DataColumn("RefConsultFullName");
                DataColumn Dc15 = new DataColumn("RefConsultName");
                DataColumn Dc16 = new DataColumn("IsFinanceSource");
                DataColumn Dc17 = new DataColumn("RefConsultMobile");
                DataColumn Dc18 = new DataColumn("RefConsultEmail");
                DataColumn Dc19 = new DataColumn("RefConsultPhone");
                Dt.Columns.Add(Dc1);
                Dt.Columns.Add(Dc2);
                Dt.Columns.Add(Dc3);
                Dt.Columns.Add(Dc4);
                Dt.Columns.Add(Dc5);
                Dt.Columns.Add(Dc6);
                Dt.Columns.Add(Dc7);
                Dt.Columns.Add(Dc8);
                Dt.Columns.Add(Dc9);
                Dt.Columns.Add(Dc10);
                Dt.Columns.Add(Dc11);
                Dt.Columns.Add(Dc12);
                Dt.Columns.Add(Dc13);
                Dt.Columns.Add(Dc14);
                Dt.Columns.Add(Dc15);
                Dt.Columns.Add(Dc16);
                Dt.Columns.Add(Dc17);
                Dt.Columns.Add(Dc18);
                Dt.Columns.Add(Dc19);
                return Dt;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.CreateTable Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 2 Sept 2013
        /// Description: Save Details Of SMS Sending 
        /// </summary>
        /// <param name="SMSTo"></param>
        /// <param name="SMSText"></param>
        /// <param name="SMSFrom"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool sendSMS(string SMSTo, string SMSText, Int64 SMSFrom, string status)
        {
            DbCommand objCmd = null;
            int result = 0;
            try
            {
                //Get command object
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "SpSaveSMSDetails");

                //Add parameters
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SMSTo", DbType.String, SMSTo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SMSText", DbType.String, SMSText);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SMSFrom", DbType.Int64, SMSFrom);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "status", DbType.String, status);

                //Execute command
                result = Cls_DataAccess.getInstance().ExecuteNonQuery(objCmd, null);

                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                logger.Error("ProspectsDAO.sendSMS Error: " + ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 3 Sept 2013
        /// Description: Get Value Of the Key from Config Table
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public DataTable GetConfigValues(string key)
        {
            DbCommand objCmd = null;
            DataTable dtResult;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "USP_GetConfigValue");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Key", DbType.String, key);
                dtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd);
                return dtResult;
            }
            catch (Exception ex)
            {
                logger.Error("ProspectsDAO.GetConfigValues Error: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 6 Sept 2013
        /// Description: Get NonSynchronized Data To Insert To Main Data Table Of Prospects
        /// </summary>
        /// <returns></returns>
        public DataTable GetLeadToCRMFromPF()
        {
            DbCommand objCmd = null;
            DataTable dtResult;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetLeadToCRMFromPF");
                dtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd);
                return dtResult;
            }
            catch (Exception ex)
            {
                logger.Error("ProspectsDAO.GetLeadToCRMFromPF Error: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 5 Sep 2013
        /// Description: Add Prospects Details From PrivateFleet.Com.Au
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public Int64 AddProspectsFromPFToCRM(Prospect objProsp)
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
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddProspectsFromPFToCRM");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspKey", DbType.String, objProsp.ProspKey);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FName", DbType.String, objProsp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MName", DbType.String, objProsp.MName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "LName", DbType.String, objProsp.LName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CarMake", DbType.Int32, objProsp.CarMake);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Phone", DbType.String, objProsp.Phone);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Mobile", DbType.String, objProsp.Mobile);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email1", DbType.String, objProsp.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CityId", DbType.Int64, objProsp.CityId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StateId", DbType.Int32, objProsp.StateId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PostalCode", DbType.String, objProsp.PostalCode);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "LeadSource", DbType.String, objProsp.LeadSource);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Finance", DbType.Boolean, objProsp.IsFinance);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeIn", DbType.Boolean, objProsp.TradeIn);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActive", DbType.Boolean, objProsp.IsActive);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeInMkModel", DbType.String, objProsp.TradeInMkModel);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Comment", DbType.String, objProsp.Comment);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Model", DbType.String, objProsp.Model);
                if (objProsp.ValueforAnswer.Trim().ToUpper() != "PLEASE CHOOSE")
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "WhereDidUHear", DbType.String, objProsp.ValueforAnswer);
                if (objProsp.Used != false)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Used", DbType.Int32, objProsp.Used);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsFinanceSource", DbType.String, objProsp.IsFinanceSource);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDuplicate", DbType.String, objProsp.IsDuplicate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ActualMake", DbType.String, objProsp.Make);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "AlternateNo", DbType.String, objProsp.AltContact);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Address", DbType.String, objProsp.Add1);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
                    objTran.Commit();
                    return Result;
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
                logger.Error(ex.Message + "ProspectsDAO.AddProspectsFromPFToCRM Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 6 Sep 2013
        /// Description: For Updation of Synchroniztion Flag In Raw Data Table
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="IdFromPF"></param>
        /// <returns></returns>
        public Int64 UpdateIsSynchronized(string flag, Int64 IdFromPF)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateIsSynchronized");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SynchronizeFlag", DbType.String, flag);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IdFromPF", DbType.Int64, IdFromPF);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null).ToString().Trim());
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.UpdateIsSynchronized Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 13 Sept 2013
        /// Description: Add Prospects Details From Fincar
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public Int64 AddProspectsFromFinCar(Prospect objProsp)
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
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddProspectsFromFinCar");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspKey", DbType.String, objProsp.ProspKey);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FName", DbType.String, objProsp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MName", DbType.String, objProsp.MName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "LName", DbType.String, objProsp.LName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CarMake", DbType.Int32, objProsp.CarMake);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Phone", DbType.String, objProsp.Phone);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Mobile", DbType.String, objProsp.Mobile);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email1", DbType.String, objProsp.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CityId", DbType.Int64, objProsp.CityId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StateId", DbType.Int32, objProsp.StateId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PostalCode", DbType.String, objProsp.PostalCode);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "LeadSource", DbType.String, objProsp.LeadSource);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Finance", DbType.Boolean, objProsp.IsFinance);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeIn", DbType.Boolean, objProsp.TradeIn);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActive", DbType.Boolean, objProsp.IsActive);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeInMkModel", DbType.String, objProsp.TradeInMkModel);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Comment", DbType.String, objProsp.Comment);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Model", DbType.String, objProsp.Model);
                if (objProsp.ValueforAnswer.Trim().ToUpper() != "PLEASE CHOOSE")
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "WhereDidUHear", DbType.String, objProsp.ValueforAnswer);
                if (objProsp.Used != false)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Used", DbType.Int32, objProsp.Used);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsFinanceSource", DbType.String, objProsp.IsFinanceSource);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDuplicate", DbType.String, objProsp.IsDuplicate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Address1", DbType.String, objProsp.Add1);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Address2", DbType.String, objProsp.Add2);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
                    objTran.Commit();
                    return Result;
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
                logger.Error(ex.Message + "ProspectsDAO.AddProspectsFromFinCar Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 12 Oct 2013
        /// Description: Get All Prospects For Admin View
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataSet GetAllProspForAdmin(Prospect objProsp)
        {
            DbCommand objCmd = null;
            DataSet DsResult = new DataSet();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllProspForAdmin");
                objCmd.CommandTimeout = 100;
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, objProsp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Status", DbType.String, objProsp.Ids);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FCStatus", DbType.String, objProsp.FCIds);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MemNo", DbType.String, objProsp.MemberNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Make", DbType.Int32, objProsp.CarMake);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email", DbType.String, objProsp.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StateId", DbType.Int32, objProsp.StateId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CityId", DbType.Int32, objProsp.CityId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ReferenceSource", DbType.Int32, objProsp.SourceId);
                if (objProsp.FromDate != DateTime.MinValue)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, objProsp.FromDate);
                if (objProsp.ToDate != DateTime.MinValue)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, objProsp.ToDate);
                if (objProsp.CreatedById != null && objProsp.CreatedById != 0)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "VirtualRoleId", DbType.Int64, objProsp.CreatedById);
                if (!string.IsNullOrEmpty(objProsp.ValueforAnswer.Trim()))
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultType", DbType.String, objProsp.ValueforAnswer);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PhNum", DbType.String, objProsp.Phone);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PotalCode", DbType.String, objProsp.PostalCode);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageIndex", DbType.Int64, objProsp.PageIndex);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageSize", DbType.Int64, objProsp.PageSize);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Finance", DbType.Int16, objProsp.Finance);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SortColumn", DbType.String, objProsp.Comment);
                DsResult = Cls_DataAccess.getInstance().GetDataSet(objCmd);
                return DsResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetAllProspForAdmin Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 21 Oct 2013
        /// Description: Resssign Leads To Consultant In Bulk
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable ReassignLeadsToConsultant(Prospect objProsp)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            int Result = 0;
            //DbConnection objConn = null;
            //DbTransaction objTran = null;
            DataTable dtFinalresult = new DataTable();
            try
            {
                //objConn = Cls_DataAccess.getInstance().GetConnection();
                //objConn.Open();
                dtFinalresult = CreateTable();
                //objTran = objConn.BeginTransaction();
                for (int i = 0; i < objProsp.lstAllocation.Count; i++)
                {
                    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_ReAssignLeadsToConsultant");
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultantId", DbType.Int64, objProsp.lstAllocation[i].ConsultantId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "NoOfLeads", DbType.Int32, objProsp.lstAllocation[i].Noofleads);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objProsp.CreatedById);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "LeadIds", DbType.String, objProsp.Ids);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Flag", DbType.String, objProsp.FConsultant);
                    DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                    Result = DtResult.Rows.Count;
                    if (DtResult != null && DtResult.Rows.Count > 0)
                    {
                        for (int j = 0; j < DtResult.Rows.Count; j++)
                        {
                            DataRow dr = dtFinalresult.NewRow();
                            dr["Id"] = DtResult.Rows[j]["Id"].ToString().Trim();
                            dr["ProspectName"] = DtResult.Rows[j]["Name"].ToString().Trim();
                            dr["Mobile"] = DtResult.Rows[j]["Mobile"].ToString().Trim();
                            dr["Email"] = DtResult.Rows[j]["Email1"].ToString().Trim();
                            dr["ConsultantName"] = DtResult.Rows[j]["ConsultantName"].ToString().Trim();
                            dr["ConsultMobile"] = DtResult.Rows[j]["ConsultMobile"].ToString().Trim();
                            dr["ConsultEmail"] = DtResult.Rows[j]["ConsultEmail"].ToString().Trim();
                            dr["ConsultPhone"] = DtResult.Rows[j]["ConsultPhone"].ToString().Trim();
                            dr["EnquiryDate"] = DtResult.Rows[j]["EnquiryDate"].ToString().Trim();
                            dr["ProspFName"] = DtResult.Rows[j]["FirstNName"].ToString().Trim();
                            dr["Ext"] = DtResult.Rows[j]["Ext"].ToString().Trim();
                            dr["ConsultName"] = DtResult.Rows[j]["ConsultName"].ToString().Trim();
                            dr["ConsultantId"] = DtResult.Rows[j]["ConsultantId"].ToString().Trim();
                            dtFinalresult.Rows.Add(dr);
                        }
                    }
                    //if (Result > 0)
                    //{
                    //    objTran.Commit();
                    //    return Result;
                    //}
                }
                return dtFinalresult;
                //if (Result > 0)
                //{
                //    objTran.Commit();
                //    return Result;
                //}
                //else
                //{
                //    objTran.Rollback();
                //    return Result;
                //}
            }
            catch (Exception ex)
            {
                //objTran.Rollback();
                logger.Error(ex.Message + "ProspectsDAO.ReassignLeadsToConsultant Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 25 Oct 2013
        /// Description: Get All Prospects For Admin View for export
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable GetAllProspForAdminExport(Prospect objProsp)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllProspForAdminExport");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, objProsp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Status", DbType.String, objProsp.Ids);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FCStatus", DbType.String, objProsp.FCIds);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MemNo", DbType.String, objProsp.MemberNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Make", DbType.Int32, objProsp.CarMake);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email", DbType.String, objProsp.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StateId", DbType.Int32, objProsp.StateId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CityId", DbType.Int32, objProsp.CityId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ReferenceSource", DbType.Int32, objProsp.SourceId);
                if (objProsp.FromDate != DateTime.MinValue)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, objProsp.FromDate);
                if (objProsp.ToDate != DateTime.MinValue)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, objProsp.ToDate);
                if (objProsp.CreatedById != null && objProsp.CreatedById != 0)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "VirtualRoleId", DbType.Int64, objProsp.CreatedById);
                if (!string.IsNullOrEmpty(objProsp.ValueforAnswer.Trim()))
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultType", DbType.String, objProsp.ValueforAnswer);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PhNum", DbType.String, objProsp.Phone);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PotalCode", DbType.String, objProsp.PostalCode);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageIndex", DbType.Int64, objProsp.PageIndex);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageSize", DbType.Int64, objProsp.PageSize);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Finance", DbType.Int16, objProsp.Finance);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SortColumn", DbType.String, objProsp.Comment);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetAllProspForAdminExport Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 28 Oct 2013
        /// Description: For Getting Data For Email To Send Before 3 Working Days Of Month
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable GetDataForAutoEmailBefore3Days()
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetDataForAutoEmailBefore3Days");
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetDataForAutoEmailBefore3Days Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 14 Nov 2013
        /// Description: For Marking Lead Status as Dead or NTU
        /// </summary>
        /// <param name="ProspectId"></param>
        /// <param name="Status"></param>
        /// <param name="Leadtype"></param>
        /// <param name="CreatedById"></param>
        /// <returns></returns>
        public Int64 ChangeStatusToDorN(Int64 ProspectId, string Status, string Leadtype, Int64 CreatedById)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_ChangeStatusToDorN");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId", DbType.Int64, ProspectId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Staus", DbType.String, Status);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "LeadType", DbType.String, Leadtype);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, CreatedById);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null).ToString().Trim());
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.ChangeStatusToDorN Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 14 Nov 2013
        /// Description: Assign Leads To Consultant In Bulk
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable BulkAssignLeadsToConsultant(Prospect objProsp)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            int Result = 0;
            //DbConnection objConn = null;
            //DbTransaction objTran = null;
            DataTable dtFinalresult = new DataTable();
            try
            {
                //objConn = Cls_DataAccess.getInstance().GetConnection();
                //objConn.Open();
                dtFinalresult = CreateTable();
                //objTran = objConn.BeginTransaction();
                for (int i = 0; i < objProsp.lstAllocation.Count; i++)
                {
                    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_BulkAssignLeadsToConsultant");
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultantId", DbType.Int64, objProsp.lstAllocation[i].ConsultantId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "NoOfLeads", DbType.Int32, objProsp.lstAllocation[i].Noofleads);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objProsp.CreatedById);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "LeadIds", DbType.String, objProsp.Ids);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Flag", DbType.String, objProsp.FConsultant);
                    DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                    Result = DtResult.Rows.Count;
                    if (DtResult != null && DtResult.Rows.Count > 0)
                    {
                        for (int j = 0; j < DtResult.Rows.Count; j++)
                        {
                            DataRow dr = dtFinalresult.NewRow();
                            dr["Id"] = DtResult.Rows[j]["Id"].ToString().Trim();
                            dr["ProspectName"] = DtResult.Rows[j]["Name"].ToString().Trim();
                            dr["Mobile"] = DtResult.Rows[j]["Mobile"].ToString().Trim();
                            dr["Email"] = DtResult.Rows[j]["Email1"].ToString().Trim();
                            dr["ConsultantName"] = DtResult.Rows[j]["ConsultantName"].ToString().Trim();
                            dr["ConsultMobile"] = DtResult.Rows[j]["ConsultMobile"].ToString().Trim();
                            dr["ConsultEmail"] = DtResult.Rows[j]["ConsultEmail"].ToString().Trim();
                            dr["ConsultPhone"] = DtResult.Rows[j]["ConsultPhone"].ToString().Trim();
                            dr["EnquiryDate"] = DtResult.Rows[j]["EnquiryDate"].ToString().Trim();
                            dr["ProspFName"] = DtResult.Rows[j]["FirstNName"].ToString().Trim();
                            dr["Ext"] = DtResult.Rows[j]["Ext"].ToString().Trim();
                            dr["ConsultName"] = DtResult.Rows[j]["ConsultName"].ToString().Trim();
                            dr["ConsultantId"] = DtResult.Rows[j]["ConsultantId"].ToString().Trim();
                            dtFinalresult.Rows.Add(dr);
                        }
                    }
                    //if (Result > 0)
                    //{
                    //    objTran.Commit();
                    //    return Result;
                    //}
                }
                return dtFinalresult;
                //if (Result > 0)
                //{
                //    objTran.Commit();
                //    return Result;
                //}
                //else
                //{
                //    objTran.Rollback();
                //    return Result;
                //}
            }
            catch (Exception ex)
            {
                //objTran.Rollback();
                logger.Error(ex.Message + "ProspectsDAO.ReassignLeadsToConsultant Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 25 Oct 2013
        /// Description: Get All Prospects For Admin View for export
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable GetAllProspForConsultExport(Prospect objProsp)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllProspForConsultExport");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, objProsp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Status", DbType.String, objProsp.Ids);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MemNo", DbType.String, objProsp.MemberNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Make", DbType.Int32, objProsp.CarMake);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email", DbType.String, objProsp.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StateId", DbType.Int32, objProsp.StateId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CityId", DbType.Int32, objProsp.CityId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ReferenceSource", DbType.Int32, objProsp.SourceId);
                if (objProsp.FromDate != DateTime.MinValue)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, objProsp.FromDate);
                if (objProsp.ToDate != DateTime.MinValue)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, objProsp.ToDate);
                if (objProsp.CreatedById != null && objProsp.CreatedById != 0)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "VirtualRoleId", DbType.Int64, objProsp.CreatedById);
                if (!string.IsNullOrEmpty(objProsp.ValueforAnswer.Trim()))
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultType", DbType.String, objProsp.ValueforAnswer);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PhNum", DbType.String, objProsp.Phone);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PotalCode", DbType.String, objProsp.PostalCode);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageIndex", DbType.Int64, objProsp.PageIndex);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageSize", DbType.Int64, objProsp.PageSize);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Finance", DbType.Int16, objProsp.Finance);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SortColumn", DbType.String, objProsp.Comment);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetAllProspForConsultExport Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 22 Nov 2013
        /// Description: For Updation of Synchroniztion Flag In Raw Data Table
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="IdFromPF"></param>
        /// <returns></returns>
        public Int64 BulkNTULeads(string flag, string Ids, Int64 CreatedById)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_BulkNTULeads");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Flag", DbType.String, flag);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "LeadIds", DbType.String, Ids);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, CreatedById);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null).ToString().Trim());
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.BulkNTULeads Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 2 Dec 2013
        /// Description: For addition fleet team Leads
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public Int64 AddFleetTeamLeads(Prospect objProsp)
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
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddFleetTeamLeads");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objProsp.ProspId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspKey", DbType.String, objProsp.ProspKey);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FName", DbType.String, objProsp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MName", DbType.String, objProsp.MName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "LName", DbType.String, objProsp.LName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Title", DbType.Int32, objProsp.Title);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CarMake", DbType.Int32, objProsp.CarMake);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Phone", DbType.String, objProsp.Phone);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedPhone", DbType.Int64, objProsp.formatedPhoNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Mobile", DbType.String, objProsp.Mobile);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedMobile", DbType.Int64, objProsp.formatedMobNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "AltContact", DbType.String, objProsp.AltContact);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedAltNo", DbType.Int64, objProsp.formatedAltCon);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Fax", DbType.String, objProsp.Fax);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedFax", DbType.Int64, objProsp.formatedFax);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email1", DbType.String, objProsp.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email2", DbType.String, objProsp.Email1);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Add1", DbType.String, objProsp.Add1);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Add2", DbType.String, objProsp.Add2);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Add3", DbType.String, objProsp.Add3);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CityId", DbType.Int64, objProsp.CityId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PostalCode", DbType.String, objProsp.PostalCode);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "MemberNo", DbType.String, objProsp.MemberNo);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultId", DbType.Int64, objProsp.ConsultId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FConsultant", DbType.String, objProsp.FConsultant);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StatusId", DbType.Int64, objProsp.StatusId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SourceId", DbType.Int16, objProsp.SourceId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Finance", DbType.Int16, objProsp.Finance);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Leadsource", DbType.String, objProsp.LeadSource);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Model", DbType.String, objProsp.Model);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ModelId", DbType.Int32, objProsp.ModelId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objProsp.CreatedById);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "StateId", DbType.Int32, objProsp.StateId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeInMkModel", DbType.String, objProsp.TradeInMkModel);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Comment", DbType.String, objProsp.Comment);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "TradeIn", DbType.Boolean, objProsp.TradeIn);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objProsp.IsDeleted);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsFleetLead", DbType.Boolean, objProsp.IsFleetLead);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "WhereDidUHear", DbType.Int32, objProsp.WhereDidUHear);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Used", DbType.Int32, objProsp.Used);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDuplicate", DbType.String, objProsp.IsDuplicate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FConsultantantID", DbType.Int64, objProsp.FConsultId);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                if (Result > 0)
                {
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
                logger.Error(ex.Message + "ProspectsDAO.AddFleetTeamLeads Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Kalpana Shinde
        /// Created Date: 21 Aug 2013
        /// Description: Get all not yet called PF and FC
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>  
        /// <param name="VirtualRoleId"></param>
        /// <param name="ConsultType"></param>  
        /// <returns></returns>
        public DataTable GetAllNYCForPFAndFCForView(DateTime FromDate, DateTime ToDate, Int64 ConsultantId, string FCFlag, string Flag)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllNYCForPFAndFCForView");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, FromDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, ToDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Flag", DbType.String, Flag);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "VirtualRoleId", DbType.Int64, ConsultantId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ConsultType ", DbType.String, FCFlag);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetAllNYCForPFAndFCForView Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 15 Jan 2014
        /// Description: For Addition/Updation of Used Car Details
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="ProspectId"></param>
        /// <param name="SecurityCode"></param>
        /// <param name="Series"></param>
        /// <param name="Year"></param>
        /// <param name="BodyType"></param>
        /// <param name="BodyTypeOther"></param>
        /// <param name="Transmission"></param>
        /// <param name="Engine_Size_Type"></param>
        /// <param name="Budget"></param>
        /// <param name="KM"></param>
        /// <param name="CreatedById"></param>
        /// <returns>Int64</returns>
        public Int64 AddUsedCarDetails(Int64 Id, Int64 ProspectId, string SecurityCode, string Series, string Year, string BodyType, string BodyTypeOther, string Transmission, string Engine_Size_Type, string Budget, string KM, Int64 CreatedById)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "SP_AddUsedCarDetails");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, Id);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectID", DbType.Int64, ProspectId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SecurityCode", DbType.String, SecurityCode);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Series", DbType.String, Series);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Year", DbType.String, Year);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "BodyType", DbType.String, BodyType);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "BodyTypeOther", DbType.String, BodyTypeOther);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Transmission", DbType.String, Transmission);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Engine_Size_Type", DbType.String, Engine_Size_Type);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Budget", DbType.String, Budget);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "KM", DbType.String, KM);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, CreatedById);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null).ToString().Trim());
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.AddUsedCarDetails Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 12 March 2014
        /// Description: Get All Prospects which were allocated before 5 days
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllProspAllocatedBef5Days()
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllProspAllocatedBef5Days");
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetAllProspAllocatedBef5Days Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 7 March 2014
        /// Description: Get All Fleet Team Leads
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataSet GetAllFleetTeamProspects(Prospect objProsp)
        {
            DbCommand objCmd = null;
            DataSet DsResult = new DataSet();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllFleetTeamProspects");
                objCmd.CommandTimeout = 100;
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, objProsp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Status", DbType.Int64, objProsp.StatusId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email", DbType.String, objProsp.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageIndex", DbType.Int64, objProsp.PageIndex);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageSize", DbType.Int64, objProsp.PageSize);
                DsResult = Cls_DataAccess.getInstance().GetDataSet(objCmd);
                return DsResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetAllFleetTeamProspects Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 19 March 2014
        /// Description: Get All Leads For Report
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataSet GetProspectsForReport(Prospect objProsp)
        {
            DbCommand objCmd = null;
            DataSet DsResult = new DataSet();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetProspectsForReport");
                objCmd.CommandTimeout = 100;
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, objProsp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email", DbType.String, objProsp.Email);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageIndex", DbType.Int64, objProsp.PageIndex);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "PageSize", DbType.Int64, objProsp.PageSize);
                if (objProsp.FromDate != DateTime.MinValue)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, objProsp.FromDate);
                if (objProsp.ToDate != DateTime.MinValue)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, objProsp.ToDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SortColumn", DbType.String, objProsp.Comment);
                DsResult = Cls_DataAccess.getInstance().GetDataSet(objCmd);
                return DsResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetProspectsForReport Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 23 March 2014
        /// Description: Get All Leads For Report to Export to excel
        /// </summary>
        /// <param name="objProsp"></param>
        /// <returns></returns>
        public DataTable GetProspectsForReportToExcel(Prospect objProsp)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetProspectsForReportToExcel");
                objCmd.CommandTimeout = 100;
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, objProsp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email", DbType.String, objProsp.Email);
                if (objProsp.FromDate != DateTime.MinValue)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, objProsp.FromDate);
                if (objProsp.ToDate != DateTime.MinValue)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, objProsp.ToDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "SortColumn", DbType.String, objProsp.Comment);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd,null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetProspectsForReportToExcel Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 22 Oct 2014
        /// Description: Get Get Process Last RunDate
        /// </summary>
        public DataTable GetRemProcessLastRunDate(string Process)
        {
            DbCommand objCmd = null;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetRemProcessLastRunDate");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "@Process", DbType.String, Process);
                return (Cls_DataAccess.getInstance().GetDataTable(objCmd, null));

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetProspectsForReportToExcel Error:" + ex.StackTrace);
                return null;
            }
        }


        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 22 Oct 2014
        /// Description: For Updation of Used Car Details
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Int64</returns>
        public Int64 UpdateRemProcessLastRunDate(string Process)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateRemProcessLastRunDate");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "@Process", DbType.String, Process);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.UpdateRemProcessLastRunDate Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By:Ayyaj Mujawar
        /// Created Date:02 Dec 2014
        /// Description: To Get Count Of Duplicate Emails
        /// </summary>
        /// <param name="EmailId"></param>
        /// <param name="Flag"></param>
        /// <returns></returns>
        public int CheckIsAddedByFC(Int64 ProspID)
        {
            DbCommand objCmd = null;
            int Result = 0;
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_CheckIsAddedByFC");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "@ProspectId", DbType.Int64, ProspID);
                Result = Convert.ToInt32(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectDAO.CheckIsAddedByFC Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Ayyaj Mujawar
        /// Created Date: 12 Dec 2014
        /// Description: Get count of Prospects Details which are assigned to given consultant
        /// <param name="VirtualRoleId"></param>
        /// </summary>
        public DataTable GetCountProspDetAssignedToConsult(Int64 VirtualRoleId, DateTime FromDate, DateTime ToDate, Int64 ProspectId)
        {
            DbCommand objCmd = null;
            DataSet DtResult = new DataSet();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetCountProspDetAssignedToConsult");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "VirtualRoleId", DbType.Int64, VirtualRoleId);
                if (FromDate != DateTime.MinValue)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, FromDate);
                if (ToDate != DateTime.MinValue)
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, ToDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ProspectId", DbType.Int64, ProspectId);
                DtResult = Cls_DataAccess.getInstance().GetDataSet(objCmd);//GetDataTable(objCmd, null);
                return DtResult.Tables[0];
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "ProspectsDAO.GetCountProspDetAssignedToConsult Error:" + ex.StackTrace);
                return null;
            }
        }

        #endregion
    }
}
