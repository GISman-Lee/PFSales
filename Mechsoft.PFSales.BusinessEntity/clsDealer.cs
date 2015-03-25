using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mechsoft.PFSales.BusinessEntity
{
   public class clsDealer
   {
       private Int64 _CreatedById;
       public Int64 CreatedById
       {
           get { return _CreatedById; }
           set { _CreatedById = value; }
       }

       private Int16 _CarMake;
       public Int16 CarMake
       {
           get { return _CarMake; }
           set { _CarMake = value; }
       }

       private Int64 _DealerId;
       public Int64 DealerId
       {
           get { return _DealerId; }
           set { _DealerId = value; }
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

       private string _PostalCode;
       public string PostalCode
       {
           get { return _PostalCode; }
           set { _PostalCode = value; }
       }

       private string _Notes;
       public string Notes
       {
           get { return _Notes; }
           set { _Notes = value; }
       }

       private Int32 _CityId;
       public Int32 CityId
       {
           get { return _CityId; }
           set { _CityId = value; }
       }

       private bool _IsDeleted;
       public bool IsDeleted
       {
           get { return _IsDeleted; }
           set { _IsDeleted = value; }
       }

       private string _DKey;
       public string DKey
       {
           get { return _DKey; }
           set { _DKey = value; }
       }

       private Int32 _SecStateId;
       public Int32 SecStateId
       {
           get { return _SecStateId; }
           set { _SecStateId = value; }
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

       private int _StateId;
       public int StateId
       {
           get { return _StateId; }
           set { _StateId = value; }
       }

       private string _Company;
       public string Company
       {
           get { return _Company; }
           set { _Company = value; }
       }

       private List<DealerMake> _lstDMMapping;
       public List<DealerMake> lstDMMapping
       {
           get { return _lstDMMapping; }
           set { _lstDMMapping = value; }

       }

       private string _Add1;
       public string Add1
       {
           get { return _Add1; }
           set { _Add1 = value; }
       }
   }

   public class DealerMake
   {
       private Int64 _DealerMakeId;
       public Int64 DealerMakeId
       {
           get { return _DealerMakeId; }
           set { _DealerMakeId = value; }
       }

       private Int16 _MakeId;
       public Int16 MakeId
       {
           get { return _MakeId; }
           set { _MakeId = value; }
       }

       private bool _IsDeleted;
       public bool IsDeleted
       {
           get { return _IsDeleted; }
           set { _IsDeleted = value; }
       }

       private Int32 _DealerId;
       public Int32 DealerId
       {
           get { return _DealerId; }
           set { _DealerId = value; }
       }
   }
}
