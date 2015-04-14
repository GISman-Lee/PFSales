using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mechsoft.PFSales.BusinessEntity
{
    public class clsMaster
    {
        private Int32 _ProspSourceId;
        public Int32 ProspSourceId
        {
            get { return _ProspSourceId; }
            set { _ProspSourceId = value; }
        }

        private Int64 _CreatedById;
        public Int64 CreatedById
        {
            get { return _CreatedById; }
            set { _CreatedById = value; }
        }

        private string _ProspSource;
        public string ProspSource
        {
            get { return _ProspSource; }
            set { _ProspSource = value; }
        }

        private string _Desc;
        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }

        private bool _IsDeleted;
        public bool IsDeleted
        {
            get { return _IsDeleted; }
            set { _IsDeleted = value; }
        }

        private string _Finance;
        public string Finance
        {
            get { return _Finance; }
            set { _Finance = value; }
        }

        private Int32 _FinanceId;
        public Int32 FinanceId
        {
            get { return _FinanceId; }
            set { _FinanceId = value; }
        }

        private Boolean _IsFleetLead;
        public Boolean IsFleetLead
        {
            get { return _IsFleetLead; }
            set { _IsFleetLead = value; }
        }

        private Int32 _WUHId;
        public Int32 WUHId
        {
            get { return _WUHId; }
            set { _WUHId = value; }
        }

        private DateTime _FromDate;
        public DateTime FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        private DateTime _ToDate;
        public DateTime ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }

        private string _ValueforAnswer;
        public string ValueforAnswer
        {
            get { return _ValueforAnswer; }
            set { _ValueforAnswer = value; }
        }
    }

    public class Roles
    {
        private Int64 _RoleId;
        public Int64 RoleId
        {
            get { return _RoleId; }
            set { _RoleId = value; }
        }

        private Int32 _Id;
        public Int32 Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _RoleName;
        public string RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private Boolean _IsActive;
        public Boolean IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        private Int64 _CreatedById;
        public Int64 CreatedById
        {
            get { return _CreatedById; }
            set { _CreatedById = value; }
        }

        private Boolean _IsDeleted;
        public Boolean IsDeleted
        {
            get { return _IsDeleted; }
            set { _IsDeleted = value; }
        }

        private string _Code;
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
    }

    public class City
    {
        private Int64 _StateId;
        public Int64 StateId
        {
            get { return _StateId; }
            set { _StateId = value; }
        }

        private string _Suburb;
        public string Suburb
        {
            get { return _Suburb; }
            set { _Suburb = value; }
        }

        private string _PCode;
        public string PCode
        {
            get { return _PCode; }
            set { _PCode = value; }
        }

        private Int64 _CreatedById;
        public Int64 CreatedById
        {
            get { return _CreatedById; }
            set { _CreatedById = value; }
        }

        private Boolean _IsDeleted;
        public Boolean IsDeleted
        {
            get { return _IsDeleted; }
            set { _IsDeleted = value; }
        }

       
    }

    public class clsResource
    {
        private Int64 _ResourceId;
        public Int64 ResourceId
        {
            get { return _ResourceId; }
            set { _ResourceId = value; }
        }

        private string _Resource;
        public string Resource
        {
            get { return _Resource; }
            set { _Resource = value; }
        }

        private string _Desc;
        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }

        private string _ResourcePath;
        public string ResourcePath
        {
            get { return _ResourcePath; }
            set { _ResourcePath = value; }
        }

        private string _ReDocFor;
        public string ReDocFor
        {
            get { return _ReDocFor; }
            set { _ReDocFor = value; }
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

        private bool _IsActive;
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        private bool _IsDeleted;
        public bool IsDeleted
        {
            get { return _IsDeleted; }
            set { _IsDeleted = value; }
        }

        
    }


}
