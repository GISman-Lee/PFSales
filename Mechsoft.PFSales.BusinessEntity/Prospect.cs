using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mechsoft.PFSales.BusinessEntity
{
    public class Prospect
    {
        private Int64 _CreatedById;
        public Int64 CreatedById
        {
            get { return _CreatedById; }
            set { _CreatedById = value; }
        }

        private Int32 _CarMake;
        public Int32 CarMake
        {
            get { return _CarMake; }
            set { _CarMake = value; }
        }

        private string _Make;
        public string Make
        {
            get { return _Make; }
            set { _Make = value; }
        }

        private Int64 _ProspId;
        public Int64 ProspId
        {
            get { return _ProspId; }
            set { _ProspId = value; }
        }

        private Int32 _Title;
        public Int32 Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _FName;
        public string FName
        {
            get { return _FName; }
            set { _FName = value; }
        }

        private string _MName;
        public string MName
        {
            get { return _MName; }
            set { _MName = value; }
        }

        private string _LName;
        public string LName
        {
            get { return _LName; }
            set { _LName = value; }
        }

        private string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private string _Mobile;
        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }

        private string _Fax;
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _Email1;
        public string Email1
        {
            get { return _Email1; }
            set { _Email1 = value; }
        }

        private string _Add1;
        public string Add1
        {
            get { return _Add1; }
            set { _Add1 = value; }
        }

        private string _Add2;
        public string Add2
        {
            get { return _Add2; }
            set { _Add2 = value; }
        }

        private string _Add3;
        public string Add3
        {
            get { return _Add3; }
            set { _Add3 = value; }
        }

        private string _PostalCode;
        public string PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }

        private string _InputDate;
        public string InputDate
        {
            get { return _InputDate; }
            set { _InputDate = value; }
        }

        private string _AltContact;
        public string AltContact
        {
            get { return _AltContact; }
            set { _AltContact = value; }
        }

        private Int64 _CityId;
        public Int64 CityId
        {
            get { return _CityId; }
            set { _CityId = value; }
        }

        private string _City;
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        private bool _IsDeleted;
        public bool IsDeleted
        {
            get { return _IsDeleted; }
            set { _IsDeleted = value; }
        }

        private string _ProspKey;
        public string ProspKey
        {
            get { return _ProspKey; }
            set { _ProspKey = value; }
        }

        private Int64 _ConsultId;
        public Int64 ConsultId
        {
            get { return _ConsultId; }
            set { _ConsultId = value; }
        }

        private string _MemberNo;
        public string MemberNo
        {
            get { return _MemberNo; }
            set { _MemberNo = value; }
        }

        private string _FConsultant;
        public string FConsultant
        {
            get { return _FConsultant; }
            set { _FConsultant = value; }
        }

        private Int64 _StatusId;
        public Int64 StatusId
        {
            get { return _StatusId; }
            set { _StatusId = value; }
        }

        private Int64 _SourceId;
        public Int64 SourceId
        {
            get { return _SourceId; }
            set { _SourceId = value; }
        }

        private string _Ids;
        public string Ids
        {
            get { return _Ids; }
            set { _Ids = value; }
        }

        private string _FCIds;
        public string FCIds
        {
            get { return _FCIds; }
            set { _FCIds = value; }
        }

        public List<ProspectContacts> LstProspContact { get; set; }

        private Int64 _formatedPhoNo;
        public Int64 formatedPhoNo
        {
            get { return _formatedPhoNo; }
            set { _formatedPhoNo = value; }
        }

        private Int64 _formatedMobNo;
        public Int64 formatedMobNo
        {
            get { return _formatedMobNo; }
            set { _formatedMobNo = value; }
        }

        private Int64 _formatedFax;
        public Int64 formatedFax
        {
            get { return _formatedFax; }
            set { _formatedFax = value; }
        }

        private Int64 _formatedAltCon;
        public Int64 formatedAltCon
        {
            get { return _formatedAltCon; }
            set { _formatedAltCon = value; }
        }

        private Int16 _Finance;
        public Int16 Finance
        {
            get { return _Finance; }
            set { _Finance = value; }
        }

        private int _StateId;
        public int StateId
        {
            get { return _StateId; }
            set { _StateId = value; }
        }

        private string _State;
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        private string _LeadSource;
        public string LeadSource
        {
            get { return _LeadSource; }
            set { _LeadSource = value; }
        }

        private Boolean _IsFinance;
        public Boolean IsFinance
        {
            get { return _IsFinance; }
            set { _IsFinance = value; }
        }

        private Boolean _TradeIn;
        public Boolean TradeIn
        {
            get { return _TradeIn; }
            set { _TradeIn = value; }
        }

        private Boolean _IsActive;
        public Boolean IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        private string _TradeInMkModel;
        public string TradeInMkModel
        {
            get { return _TradeInMkModel; }
            set { _TradeInMkModel = value; }
        }

        private string _Comment;
        public string Comment
        {
            get { return _Comment; }
            set { _Comment = value; }
        }

        private List<LeadAssignment> _lstAllocation;
        public List<LeadAssignment> lstAllocation
        {
            get { return _lstAllocation; }
            set { _lstAllocation = value; }
        }

        private DateTime? _FromDate;
        public DateTime? FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        private DateTime? _ToDate;
        public DateTime? ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }

        private string _Model;
        public string Model
        {
            get { return _Model; }
            set { _Model = value; }
        }

        private Int32 _ModelId;
        public Int32 ModelId
        {
            get { return _ModelId; }
            set { _ModelId = value; }
        }

        private Boolean _IsFleetLead;
        public Boolean IsFleetLead
        {
            get { return _IsFleetLead; }
            set { _IsFleetLead = value; }
        }

        private Int32 _WhereDidUHear;
        public Int32 WhereDidUHear
        {
            get { return _WhereDidUHear; }
            set { _WhereDidUHear = value; }
        }

        private Boolean _Used;
        public Boolean Used
        {
            get { return _Used; }
            set { _Used = value; }
        }

        private string _ValueforAnswer;
        public string ValueforAnswer
        {
            get { return _ValueforAnswer; }
            set { _ValueforAnswer = value; }
        }

        private string _IsFinanceSource;
        public string IsFinanceSource
        {
            get { return _IsFinanceSource; }
            set { _IsFinanceSource = value; }
        }

        private int _IsDuplicate;
        public int IsDuplicate
        {
            get { return _IsDuplicate; }
            set { _IsDuplicate = value; }
        }

        private Int64 _FConsultId;
        public Int64 FConsultId
        {
            get { return _FConsultId; }
            set { _FConsultId = value; }
        }

        private Int64 _PageSize;
        public Int64 PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }

        private Int64 _PageIndex;
        public Int64 PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }

        private Int64 _FCStatusId;
        public Int64 FCStatusId
        {
            get { return _FCStatusId; }
            set { _FCStatusId = value; }
        }
    }

    public class ProspectContacts
    {
        private Int64 _ProspContactId;
        public Int64 ProspContactId
        {
            get { return _ProspContactId; }
            set { _ProspContactId = value; }
        }

        private Int64 _ContactId;
        public Int64 ContactId
        {
            get { return _ContactId; }
            set { _ContactId = value; }
        }

        private bool _IsPrimary;
        public bool IsPrimary
        {
            get { return _IsPrimary; }
            set { _IsPrimary = value; }
        }

        private bool _IsDeleted;
        public bool IsDeleted
        {
            get { return _IsDeleted; }
            set { _IsDeleted = value; }
        }
    }

    public class LeadAssignment
    {
        private Int64 _ConsultantId;
        public Int64 ConsultantId
        {
            get { return _ConsultantId; }
            set { _ConsultantId = value; }
        }

        private Int32 _Noofleads;
        public Int32 Noofleads
        {
            get { return _Noofleads; }
            set { _Noofleads = value; }
        }

        private string _ConsultantEmail;
        public string ConsultantEmail
        {
            get { return _ConsultantEmail; }
            set { _ConsultantEmail = value; }
        }

        private string _ConsultantName;
        public string ConsultantName
        {
            get { return _ConsultantName; }
            set { _ConsultantName = value; }
        }

        private string _ConsultFName;
        public string ConsultFName
        {
            get { return _ConsultFName; }
            set { _ConsultFName = value; }
        }

        private Boolean _IsFleetTeamLead;
        public Boolean IsFleetTeamLead
        {
            get { return _IsFleetTeamLead; }
            set { _IsFleetTeamLead = value; }
        }
    }

    public class Entity
    {
        private Int64 _ID;
        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _SMSTo;
        public string SMSTo
        {
            get { return _SMSTo; }
            set { _SMSTo = value; }
        }

        private string _SMSText;
        public string SMSText
        {
            get { return _SMSText; }
            set { _SMSText = value; }
        }

        private Int64 _SMSFrom;
        public Int64 SMSFrom
        {
            get { return _SMSFrom; }
            set { _SMSFrom = value; }
        }
    }

    public class TradeIn
    {
        private Int64 _Id;
        public Int64 Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private Int64 _ProspectId;
        public Int64 ProspectId
        {
            get { return _ProspectId; }
            set { _ProspectId = value; }
        }

        private Int32 _CD;
        public Int32 CD
        {
            get { return _CD; }
            set { _CD = value; }
        }

        private Int32 _Owners;
        public Int32 Owners
        {
            get { return _Owners; }
            set { _Owners = value; }
        }

        private Int32 _RateCondition;
        public Int32 RateCondition
        {
            get { return _RateCondition; }
            set { _RateCondition = value; }
        }

        private Int32 _TradeInNo;
        public Int32 TradeInNo
        {
            get { return _TradeInNo; }
            set { _TradeInNo = value; }
        }

        private Boolean _IsAC;
        public Boolean IsAC
        {
            get { return _IsAC; }
            set { _IsAC = value; }
        }

        private Boolean _IsReverseSensor;
        public Boolean IsReverseSensor
        {
            get { return _IsReverseSensor; }
            set { _IsReverseSensor = value; }
        }

        private Boolean _IsReverseCamera;
        public Boolean IsReverseCamera
        {
            get { return _IsReverseCamera; }
            set { _IsReverseCamera = value; }
        }

        private Boolean _IsABS;
        public Boolean IsABS
        {
            get { return _IsABS; }
            set { _IsABS = value; }
        }

        private Boolean _IsXenonLights;
        public Boolean IsXenonLights
        {
            get { return _IsXenonLights; }
            set { _IsXenonLights = value; }
        }

        private Boolean _IsPowerSteer;
        public Boolean IsPowerSteer
        {
            get { return _IsPowerSteer; }
            set { _IsPowerSteer = value; }
        }

        private Boolean _IsProtectionProduct;
        public Boolean IsProtectionProduct
        {
            get { return _IsProtectionProduct; }
            set { _IsProtectionProduct = value; }
        }

        private Boolean _IsActiveCruiseControl;
        public Boolean IsActiveCruiseControl
        {
            get { return _IsActiveCruiseControl; }
            set { _IsActiveCruiseControl = value; }
        }

        private Boolean _IsBluetoothFactory;
        public Boolean IsBluetoothFactory
        {
            get { return _IsBluetoothFactory; }
            set { _IsBluetoothFactory = value; }
        }

        private Boolean _IsTowBar;
        public Boolean IsTowBar
        {
            get { return _IsTowBar; }
            set { _IsTowBar = value; }
        }
        private Boolean _IsPanoramic;
        public Boolean IsPanoramic
        {
            get { return _IsPanoramic; }
            set { _IsPanoramic = value; }
        }

        private Boolean _IsTimingBeltChanged;
        public Boolean IsTimingBeltChanged
        {
            get { return _IsTimingBeltChanged; }
            set { _IsTimingBeltChanged = value; }
        }

        private Boolean _IsPowerWindows;
        public Boolean IsPowerWindows
        {
            get { return _IsPowerWindows; }
            set { _IsPowerWindows = value; }
        }

        private Boolean _IsFourByFour;
        public Boolean IsFourByFour
        {
            get { return _IsFourByFour; }
            set { _IsFourByFour = value; }
        }


        private Boolean _IsTwoByTwo;
        public Boolean IsTwoByTwo
        {
            get { return _IsTwoByTwo; }
            set { _IsTwoByTwo = value; }
        }

        private Boolean _IsElectricSeats;
        public Boolean IsElectricSeats
        {
            get { return _IsElectricSeats; }
            set { _IsElectricSeats = value; }
        }


        private Boolean _IsBullBar;
        public Boolean IsBullBar
        {
            get { return _IsBullBar; }
            set { _IsBullBar = value; }
        }

        private Boolean _IsCentralLocking;
        public Boolean IsCentralLocking
        {
            get { return _IsCentralLocking; }
            set { _IsCentralLocking = value; }
        }

        private Boolean _IsTint;
        public Boolean IsTint
        {
            get { return _IsTint; }
            set { _IsTint = value; }
        }

        private Boolean _IsSunroof;
        public Boolean IsSunroof
        {
            get { return _IsSunroof; }
            set { _IsSunroof = value; }
        }

        private Boolean _IsRoofRacks;
        public Boolean IsRoofRacks
        {
            get { return _IsRoofRacks; }
            set { _IsRoofRacks = value; }
        }

        private Boolean _IsTV;
        public Boolean IsTV
        {
            get { return _IsTV; }
            set { _IsTV = value; }
        }

        private Boolean _IsLeather;
        public Boolean IsLeather
        {
            get { return _IsLeather; }
            set { _IsLeather = value; }
        }

        private Boolean _IsSideSteps;
        public Boolean IsSideSteps
        {
            get { return _IsSideSteps; }
            set { _IsSideSteps = value; }
        }

        private Boolean _IsSatNav;
        public Boolean IsSatNav
        {
            get { return _IsSatNav; }
            set { _IsSatNav = value; }
        }

        private Boolean _IsAlarm;
        public Boolean IsAlarm
        {
            get { return _IsAlarm; }
            set { _IsAlarm = value; }
        }

        private Boolean _IsThirdRowSeats;
        public Boolean IsThirdRowSeats
        {
            get { return _IsThirdRowSeats; }
            set { _IsThirdRowSeats = value; }
        }

        private Boolean _IsLaneChangeAssist;
        public Boolean IsLaneChangeAssist
        {
            get { return _IsLaneChangeAssist; }
            set { _IsLaneChangeAssist = value; }
        }

        private Boolean _IsDeleted;
        public Boolean IsDeleted
        {
            get { return _IsDeleted; }
            set { _IsDeleted = value; }
        }

        private DateTime? _BuildPlateDate;
        public DateTime? BuildPlateDate
        {
            get { return _BuildPlateDate; }
            set { _BuildPlateDate = value; }
        }

        private DateTime? _ComplianceDate;
        public DateTime? ComplianceDate
        {
            get { return _ComplianceDate; }
            set { _ComplianceDate = value; }
        }

        private string _Make;
        public string Make
        {
            get { return _Make; }
            set { _Make = value; }
        }

        private Int32 _MakeId;
        public Int32 MakeId
        {
            get { return _MakeId; }
            set { _MakeId = value; }
        }

        private string _Model;
        public string Model
        {
            get { return _Model; }
            set { _Model = value; }
        }

        private Int32 _ModelId;
        public Int32 ModelId
        {
            get { return _ModelId; }
            set { _ModelId = value; }
        }

        private string _Series;
        public string Series
        {
            get { return _Series; }
            set { _Series = value; }
        }

        private string _EngineType;
        public string EngineType
        {
            get { return _EngineType; }
            set { _EngineType = value; }
        }

        private string _WheelsAlloys;
        public string WheelsAlloys
        {
            get { return _WheelsAlloys; }
            set { _WheelsAlloys = value; }
        }

        private string _Odometer;
        public string Odometer
        {
            get { return _Odometer; }
            set { _Odometer = value; }
        }

        private string _Transmission;
        public string Transmission
        {
            get { return _Transmission; }
            set { _Transmission = value; }
        }

        private string _BodyStyle;
        public string BodyStyle
        {
            get { return _BodyStyle; }
            set { _BodyStyle = value; }
        }

        private string _Door;
        public string Door
        {
            get { return _Door; }
            set { _Door = value; }
        }

        private string _FuelType;
        public string FuelType
        {
            get { return _FuelType; }
            set { _FuelType = value; }
        }

        private string _ExteriorColor;
        public string ExteriorColor
        {
            get { return _ExteriorColor; }
            set { _ExteriorColor = value; }
        }

        private string _InteriorColor;
        public string InteriorColor
        {
            get { return _InteriorColor; }
            set { _InteriorColor = value; }
        }

        private string _RegoExpires;
        public string RegoExpires
        {
            get { return _RegoExpires; }
            set { _RegoExpires = value; }
        }

        private string _AirBags;
        public string AirBags
        {
            get { return _AirBags; }
            set { _AirBags = value; }
        }

        private string _OtherOptions;
        public string OtherOptions
        {
            get { return _OtherOptions; }
            set { _OtherOptions = value; }
        }

        private string _GlassWork;
        public string GlassWork
        {
            get { return _GlassWork; }
            set { _GlassWork = value; }
        }

        private string _Engine;
        public string Engine
        {
            get { return _Engine; }
            set { _Engine = value; }
        }

        private string _BodyPanels;
        public string BodyPanels
        {
            get { return _BodyPanels; }
            set { _BodyPanels = value; }
        }

        private string _TransmissionDetails;
        public string TransmissionDetails
        {
            get { return _TransmissionDetails; }
            set { _TransmissionDetails = value; }
        }

        private string _Paint;
        public string Paint
        {
            get { return _Paint; }
            set { _Paint = value; }
        }

        private string _Breaks;
        public string Breaks
        {
            get { return _Breaks; }
            set { _Breaks = value; }
        }

        private string _Tyres;
        public string Tyres
        {
            get { return _Tyres; }
            set { _Tyres = value; }
        }

        private string _ACDetails;
        public string ACDetails
        {
            get { return _ACDetails; }
            set { _ACDetails = value; }
        }

        private string _RimAlloysDetails;
        public string RimAlloysDetails
        {
            get { return _RimAlloysDetails; }
            set { _RimAlloysDetails = value; }
        }

        private string _Headlights;
        public string Headlights
        {
            get { return _Headlights; }
            set { _Headlights = value; }
        }

        private string _Upholstery;
        public string Upholstery
        {
            get { return _Upholstery; }
            set { _Upholstery = value; }
        }

        private string _SpareTyre;
        public string SpareTyre
        {
            get { return _SpareTyre; }
            set { _SpareTyre = value; }
        }

        private string _VehicleCondition;
        public string VehicleCondition
        {
            get { return _VehicleCondition; }
            set { _VehicleCondition = value; }
        }

        private string _DamageDetails;
        public string DamageDetails
        {
            get { return _DamageDetails; }
            set { _DamageDetails = value; }
        }

        private string _TyreHistory;
        public string TyreHistory
        {
            get { return _TyreHistory; }
            set { _TyreHistory = value; }
        }

        private string _ServiceHistory;
        public string ServiceHistory
        {
            get { return _ServiceHistory; }
            set { _ServiceHistory = value; }
        }

        private string _Payout;
        public string Payout
        {
            get { return _Payout; }
            set { _Payout = value; }
        }

        private string _OtherDescription;
        public string OtherDescription
        {
            get { return _OtherDescription; }
            set { _OtherDescription = value; }
        }

        private Int64 _CreatedById;
        public Int64 CreatedById
        {
            get { return _CreatedById; }
            set { _CreatedById = value; }
        }


        private Int64 _ModifiedById;
        public Int64 ModifiedById
        {
            get { return _ModifiedById; }
            set { _ModifiedById = value; }
        }

        private DateTime? _ModifiedDate;
        public DateTime? ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }

        private DateTime? _DeliveryDate;
        public DateTime? DeliveryDate
        {
            get { return _DeliveryDate; }
            set { _DeliveryDate = value; }
        }

        private DateTime? _CreatedDate;
        public DateTime? CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }



    }
}

