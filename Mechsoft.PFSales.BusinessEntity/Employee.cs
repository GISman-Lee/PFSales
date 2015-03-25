using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mechsoft.PFSales.BusinessEntity
{
    public class Employee
    {
        private Int64 _CreatedById;
        public Int64 CreatedById
        {
            get { return _CreatedById; }
            set { _CreatedById = value; }
        }

        private Int64 _UseId;
        public Int64 UseId
        {
            get { return _UseId; }
            set { _UseId = value; }
        }

        private Int64 _EmpId;
        public Int64 EmpId
        {
            get { return _EmpId; }
            set { _EmpId = value; }
        }

        private Int64 _Title;
        public Int64 Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
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

        private DateTime _DOB;
        public DateTime DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }

        private string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private string _PhoneExt;
        public string PhoneExt
        {
            get { return _PhoneExt; }
            set { _PhoneExt = value; }
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

        private DateTime _DOJ;
        public DateTime DOJ
        {
            get { return _DOJ; }
            set { _DOJ = value; }
        }

        private string _PhotoPath;
        public string PhotoPath
        {
            get { return _PhotoPath; }
            set { _PhotoPath = value; }
        }

        private Int64 _CityId;
        public Int64 CityId
        {
            get { return _CityId; }
            set { _CityId = value; }
        }

        private int _RoleId;
        public int RoleId
        {
            get { return _RoleId; }
            set { _RoleId = value; }
        }

        private Int64 _DesigId;
        public Int64 DesigId
        {
            get { return _DesigId; }
            set { _DesigId = value; }
        }

        private bool _IsDeleted;
        public bool IsDeleted
        {
            get { return _IsDeleted; }
            set { _IsDeleted = value; }
        }

        private bool _IsActive;
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        private bool _IsNewEmployee;
        public bool IsNewEmployee
        {
            get { return _IsNewEmployee; }
            set { _IsNewEmployee = value; }
        }

        private Int64 _RepUserId;
        public Int64 RepUserId
        {
            get { return _RepUserId; }
            set { _RepUserId = value; }
        }

        private Int16 _Gender;
        public Int16 Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        private Int64 _VirtualRoleId;
        public Int64 VirtualRoleId
        {
            get { return _VirtualRoleId; }
            set { _VirtualRoleId = value; }
        }

        private string _EmpKey;
        public string EmpKey
        {
            get { return _EmpKey; }
            set { _EmpKey = value; }
        }

        private Int64 _UserVID;
        public Int64 UserVID
        {
            get { return _UserVID; }
            set { _UserVID = value; }
        }

        private List<FieldFormatMapping> _lstFFMapping;
        public List<FieldFormatMapping> lstFFMapping
        {
            get { return _lstFFMapping; }
            set { _lstFFMapping = value; }
        }

        private string _Designation;
        public string Designation
        {
            get { return _Designation; }
            set { _Designation = value; }
        }

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

        private Boolean _IsInFleetTeam;
        public Boolean IsInFleetTeam
        {
            get { return _IsInFleetTeam; }
            set { _IsInFleetTeam = value; }
        }

        private Int64 _QuoteUserId;
        public Int64 QuoteUserId
        {
            get { return _QuoteUserId; }
            set { _QuoteUserId = value; }
        }
    }

    public class UserLoginListItem
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public Int64 RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleCode { get; set; }
        public Int64 BranchId { get; set; }
        public string BranchName { get; set; }
        public Int64 OrganizationId { get; set; }
        public DateTime OrgEstablishmentDate { get; set; }
        public string OrganizationName { get; set; }
        public Int64 StudentId { get; set; }
        public Int64 ParentId { get; set; }
        public Int64 EmployeeId { get; set; }
        public Int64 VirtualRoleId { get; set; }
        public Int64 LoginDetailId { get; set; }
        public Int64 UserEntityId { get; set; }
        public Int64 StudId { get; set; }
        public Int64 EntityActualValue { get; set; }
        public Int64 EntityHierarchyId { get; set; }
        public Int64 EntityParentValueId { get; set; }
        public Int64 HierarchyMappingId { get; set; }
        public string EmailFromID { get; set; }
        public string EmailContentType { get; set; }
        public string EmailAttachmentsNo { get; set; }
        public string EmailAttachmentsSize { get; set; }
        public string EmailTypeBlocked { get; set; }
        public string SMTPServerIP { get; set; }
        public string SMTPUserID { get; set; }
        public string SMTPUserPwd { get; set; }
        public string UserEmail { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        public string PhExtension { get; set; }
    }

    public class UserSessionInfo
    {
        public Int64 UserId { get; set; }
        public Int64 StudentId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public Int64 RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleCode { get; set; }
        public Int64 BranchId { get; set; }
        public string BranchName { get; set; }
        public Int64 OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public Int64 EmployeeId { get; set; }
        public Int64 ParentId { get; set; }
        public DateTime OrgEstablishmentDate { get; set; }
        public Int64 VirtualRoleId { get; set; }
        public Int64 LoginDetailId { get; set; }
        public Int64 UserEntityId { get; set; }
        public Int64 EntityActualValue { get; set; }
        public Int64 EntityHierarchyId { get; set; }
        public Int64 EntityParentValueId { get; set; }
        public Int64 HierarchyMappingId { get; set; }
        public String RoleDetails { get; set; }
        public string EmailFromID { get; set; }
        public string EmailContentType { get; set; }
        public string EmailAttachmentsNo { get; set; }
        public string EmailAttachmentsSize { get; set; }
        public string EmailTypeBlocked { get; set; }
        public string SMTPServerIP { get; set; }
        public string SMTPUserID { get; set; }
        public string SMTPUserPwd { get; set; }
        public string FName { get; set; }
        public string MobileNo { get; set; }
        public string PhExtension { get; set; }
    }

    public enum AccessType
    {
        Role,
        User,
    }

    public class FieldFormatMapping
    {
        private string _tblName;
        public string tblName
        {
            get { return _tblName; }
            set { _tblName = value; }
        }

        private string _fieldName;
        public string fieldName
        {
            get { return _fieldName; }
            set { _fieldName = value; }
        }

        private Int64 _PhFormatId;
        public Int64 PhFormatId
        {
            get { return _PhFormatId; }
            set { _PhFormatId = value; }
        }

    }
}
