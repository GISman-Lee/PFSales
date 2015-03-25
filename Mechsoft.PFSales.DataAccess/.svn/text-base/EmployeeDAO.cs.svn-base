using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Data;
using Mechsoft.PFSales.BusinessEntity;
using System.Data.Common;
using Mechsoft.GeneralUtilities;

namespace Mechsoft.PFSales.DataAccess
{
    public class EmployeeDAO
    {
        #region Global Variables
        ILog logger = LogManager.GetLogger(typeof(EmployeeDAO));
        #endregion

        #region Methods
        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 16 May 2013
        /// Description: Add Update Delete Employee
        /// </summary>
        /// <param name="objEmp"></param>
        /// <returns></returns>
        public Int64 AddUpdateDeleteEmployee(Employee objEmp)
        {
            DbCommand objCmd = null;
            Int64 Result = 0;
            Int64 UserId = 0;
            DbConnection objConn = null;
            DbTransaction objTran = null;
            try
            {
                objConn = Cls_DataAccess.getInstance().GetConnection();
                objConn.Open();
                objTran = objConn.BeginTransaction();

                if (objEmp.DesigId == 0 && !string.IsNullOrEmpty(objEmp.Designation.Trim()))
                {
                    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddDesignations");
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objEmp.DesigId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Designation", DbType.String, objEmp.Designation);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objEmp.CreatedById);
                    Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                }
                if ((Result > 0 && objEmp.DesigId == 0 && !string.IsNullOrEmpty(objEmp.Designation.Trim())) || objEmp.DesigId > 0)
                {
                    if (objEmp.DesigId == 0 && !string.IsNullOrEmpty(objEmp.Designation.Trim()) && Result > 0)
                        objEmp.DesigId = Result;
                    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddUpdateEmployee");
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objEmp.EmpId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "EmpKey", DbType.String, objEmp.EmpKey);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Title", DbType.Int64, objEmp.Title);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FName", DbType.String, objEmp.FName);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "MName", DbType.String, objEmp.MName);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "LName", DbType.String, objEmp.LName);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Gender", DbType.Int16, objEmp.Gender);
                    if (objEmp.DOB != DateTime.MinValue)
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "DOB", DbType.DateTime, objEmp.DOB);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Phone", DbType.String, objEmp.Phone);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "PhoneExt", DbType.String, objEmp.PhoneExt);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedPhone", DbType.Int64, objEmp.formatedPhoNo);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Mobile", DbType.String, objEmp.Mobile);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedMobile", DbType.Int64, objEmp.formatedMobNo);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Fax", DbType.String, objEmp.Fax);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedFax", DbType.Int64, objEmp.formatedFax);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email1", DbType.String, objEmp.Email);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email2", DbType.String, objEmp.Email1);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Add1", DbType.String, objEmp.Add1);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Add2", DbType.String, objEmp.Add2);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Add3", DbType.String, objEmp.Add3);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CityId", DbType.Int64, objEmp.CityId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "PostalCode", DbType.String, objEmp.PostalCode);
                    if (objEmp.DOJ != DateTime.MinValue)
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "DOJ", DbType.DateTime, objEmp.DOJ);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Role", DbType.Int32, objEmp.RoleId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "DesignationId", DbType.Int64, objEmp.DesigId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "PhotoFilePath", DbType.String, objEmp.PhotoPath);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsNewEmployee", DbType.Boolean, objEmp.IsNewEmployee);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "RepUserId", DbType.Int64, objEmp.RepUserId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objEmp.CreatedById);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objEmp.IsDeleted);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsInFleetTeam", DbType.Boolean, objEmp.IsInFleetTeam);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "QuoteUserId", DbType.Int64, objEmp.QuoteUserId);
                    Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                    if (Result > 0 && objEmp.IsDeleted == false)
                    {
                        if (objEmp.EmpId > 0)
                            Result = objEmp.EmpId;
                        objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddUpdateUser");
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objEmp.UseId);
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "EmpId", DbType.Int64, Result);
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, (objEmp.FName + " " + objEmp.MName + " " + objEmp.LName).Trim().Replace("  ", " "));
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "UserName", DbType.String, objEmp.Email);
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "Password", DbType.String, objEmp.Password);
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objEmp.CreatedById);
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "RoleId", DbType.Int32, objEmp.RoleId);
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActive", DbType.Boolean, objEmp.IsActive);
                        Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                        if (Result > 0)
                        {
                            if (objEmp.UseId > 0)
                                UserId = objEmp.UseId;
                            else
                                UserId = Result;
                            if (objEmp.IsNewEmployee)
                            {
                                if (objEmp.EmpId == 0)
                                {
                                    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddVirtualRole");
                                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "RoleId", DbType.Int32, objEmp.RoleId);
                                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActive", DbType.Boolean, objEmp.IsActive);
                                    Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                                    if (Result > 0)
                                    {
                                        if (objEmp.UserVID == 0)
                                        {
                                            objEmp.UserVID = Result;
                                            objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddVirtualRoleUserMapping");
                                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "VirtualRoleId", DbType.Int32, objEmp.UserVID);
                                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "UserId", DbType.Int64, UserId);
                                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objEmp.CreatedById);
                                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActive", DbType.Boolean, objEmp.IsActive);
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
                                            objTran.Commit();
                                            return Result;
                                        }
                                    }
                                    else
                                    {
                                        objTran.Rollback();
                                        return Result;
                                    }
                                }
                                else
                                {
                                    if (objEmp.UserVID == 0)
                                    {
                                        objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddVirtualRole");
                                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "RoleId", DbType.Int32, objEmp.RoleId);
                                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActive", DbType.Boolean, objEmp.IsActive);
                                        Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                                        if (Result > 0)
                                        {
                                            objEmp.UserVID = Result;
                                            objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddVirtualRoleUserMapping");
                                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "VirtualRoleId", DbType.Int32, objEmp.UserVID);
                                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "UserId", DbType.Int64, UserId);
                                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objEmp.CreatedById);
                                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActive", DbType.Boolean, objEmp.IsActive);
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
                                    else
                                    {
                                        objTran.Commit();
                                        return Result;
                                    }
                                }
                            }
                            else
                            {
                                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateVirtualRoleUserMapping");
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "VirtualRoleId", DbType.Int32, objEmp.VirtualRoleId);
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "UserId", DbType.Int64, UserId);
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objEmp.CreatedById);
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
                        }
                        else
                        {
                            objTran.Rollback();
                            return Result;
                        }
                    }
                    else
                    {
                        if (Result > 0 && objEmp.IsDeleted == true)
                        {
                            objTran.Commit();
                            return Result;
                        }
                        else if (Result < 0)
                        {
                            objTran.Rollback();
                            return Result;
                        }
                        else
                        {
                            objTran.Rollback();
                            return Result;
                        }
                    }
                }
                else
                {
                    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddUpdateEmployee");
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objEmp.EmpId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "EmpKey", DbType.String, objEmp.EmpKey);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Title", DbType.Int64, objEmp.Title);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FName", DbType.String, objEmp.FName);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "MName", DbType.String, objEmp.MName);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "LName", DbType.String, objEmp.LName);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Gender", DbType.Int16, objEmp.Gender);
                    if (objEmp.DOB != DateTime.MinValue)
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "DOB", DbType.DateTime, objEmp.DOB);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Phone", DbType.String, objEmp.Phone);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "PhoneExt", DbType.String, objEmp.PhoneExt);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedPhone", DbType.Int64, objEmp.formatedPhoNo);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Mobile", DbType.String, objEmp.Mobile);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedMobile", DbType.Int64, objEmp.formatedMobNo);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Fax", DbType.String, objEmp.Fax);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "FormatedFax", DbType.Int64, objEmp.formatedFax);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email1", DbType.String, objEmp.Email);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Email2", DbType.String, objEmp.Email1);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Add1", DbType.String, objEmp.Add1);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Add2", DbType.String, objEmp.Add2);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Add3", DbType.String, objEmp.Add3);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CityId", DbType.Int64, objEmp.CityId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "PostalCode", DbType.String, objEmp.PostalCode);
                    if (objEmp.DOJ != DateTime.MinValue)
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "DOJ", DbType.DateTime, objEmp.DOJ);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "Role", DbType.Int32, objEmp.RoleId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "DesignationId", DbType.Int64, objEmp.DesigId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "PhotoFilePath", DbType.String, objEmp.PhotoPath);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsNewEmployee", DbType.Boolean, objEmp.IsNewEmployee);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "RepUserId", DbType.Int64, objEmp.RepUserId);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objEmp.CreatedById);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsDeleted", DbType.Boolean, objEmp.IsDeleted);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsInFleetTeam", DbType.Boolean, objEmp.IsInFleetTeam);
                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "QuoteUserId", DbType.Int64, objEmp.QuoteUserId);
                    Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                    if (Result > 0 && objEmp.IsDeleted == false)
                    {
                        //if (objEmp.EmpId > 0)
                        //    Result = objEmp.EmpId;
                        objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddUpdateUser");
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.Int64, objEmp.UseId);
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "EmpId", DbType.Int64, Result);
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "Name", DbType.String, (objEmp.FName + " " + objEmp.MName + " " + objEmp.LName).Trim().Replace("  ", " "));
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "UserName", DbType.String, objEmp.Email);
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "Password", DbType.String, objEmp.Password);
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objEmp.CreatedById);
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "RoleId", DbType.Int32, objEmp.RoleId);
                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActive", DbType.Boolean, objEmp.IsActive);
                        Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                        if (Result > 0)
                        {
                            if (objEmp.UseId > 0)
                                UserId = objEmp.UseId;
                            else
                                UserId = Result;
                            if (objEmp.IsNewEmployee)
                            {
                                if (objEmp.EmpId == 0)
                                {
                                    objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddVirtualRole");
                                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "RoleId", DbType.Int32, objEmp.RoleId);
                                    Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActive", DbType.Boolean, objEmp.IsActive);
                                    Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                                    if (Result > 0)
                                    {
                                        if (objEmp.UserVID == 0)
                                        {
                                            objEmp.UserVID = Result;
                                            objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddVirtualRoleUserMapping");
                                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "VirtualRoleId", DbType.Int32, objEmp.UserVID);
                                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "UserId", DbType.Int64, UserId);
                                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objEmp.CreatedById);
                                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActive", DbType.Boolean, objEmp.IsActive);
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
                                            objTran.Commit();
                                            return Result;
                                        }
                                    }
                                    else
                                    {
                                        objTran.Rollback();
                                        return Result;
                                    }
                                }
                                else
                                {
                                    if (objEmp.UserVID == 0)
                                    {
                                        objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddVirtualRole");
                                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "RoleId", DbType.Int32, objEmp.RoleId);
                                        Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActive", DbType.Boolean, objEmp.IsActive);
                                        Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, objTran));
                                        if (Result > 0)
                                        {
                                            objEmp.UserVID = Result;
                                            objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_AddVirtualRoleUserMapping");
                                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "VirtualRoleId", DbType.Int32, objEmp.UserVID);
                                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "UserId", DbType.Int64, UserId);
                                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objEmp.CreatedById);
                                            Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActive", DbType.Boolean, objEmp.IsActive);
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
                                    else
                                    {
                                        objTran.Commit();
                                        return Result;
                                    }
                                }
                            }
                            else
                            {
                                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_UpdateVirtualRoleUserMapping");
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "VirtualRoleId", DbType.Int32, objEmp.VirtualRoleId);
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "UserId", DbType.Int64, UserId);
                                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, objEmp.CreatedById);
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
                        }
                        else
                        {
                            objTran.Rollback();
                            return Result;
                        }
                    }
                    else
                    {
                        if (Result > 0 && objEmp.IsDeleted == true)
                        {
                            objTran.Commit();
                            return Result;
                        }
                        else if (Result < 0)
                        {
                            objTran.Rollback();
                            return Result;
                        }
                        else
                        {
                            objTran.Rollback();
                            return Result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objTran.Rollback();
                logger.Error(ex.Message + "EmployeeDAO.AddUpdateDeleteEmployee Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 16 May 2013
        /// Description: Get All Employees
        /// </summary>
        /// <param name="objEmp"></param>
        /// <returns></returns>
        public DataTable GetAllEmployee(Employee objEmp)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllEmployee");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FName", DbType.String, objEmp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Role", DbType.Int32, objEmp.RoleId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeDAO.GetAllEmployee Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 16 May 2013
        /// Description: Get Employee Details From Employee Id
        /// </summary>
        /// <param name="objEmp"></param>
        /// <returns></returns>
        public DataTable GetEmployeeFromId(Int64 EmpId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetEmpDetFromId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.String, EmpId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeDAO.GetEmployeeFromId Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 13 Aug 2013
        /// Description: Get Employee Details From Virtual RoleId
        /// </summary>
        /// <param name="objEmp"></param>
        /// <returns></returns>
        public DataTable GetEmpDetFromVirId(Int64 EmpId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetEmpDetFromVirId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Id", DbType.String, EmpId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeDAO.GetEmpDetFromVirId Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date : 17 May 2013
        /// Desc :Get Login Details Of User.
        /// <param name="ObjUser"></param>
        /// <returns>DataTable</returns>
        /// </summary>
        public DataSet GetUserLoginDetails(Employee objEmp)
        {
            DataSet dsLoginDtls = null;
            DbCommand objCommand = null;
            try
            {
                objCommand = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetUserLoginDetails");
                Cls_DataAccess.getInstance().AddInParameter(objCommand, "UserName", DbType.String, objEmp.FName);
                Cls_DataAccess.getInstance().AddInParameter(objCommand, "Password", DbType.String, objEmp.Password);
                dsLoginDtls = Cls_DataAccess.getInstance().GetDataSet(objCommand);
                return dsLoginDtls;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeDAO.GetUserLoginDetails Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date : 28 May 2013
        /// Desc :Get Login Details Of User for forgots Password.
        /// <param name="objEmp"></param>
        /// <returns>DataTable</returns>
        /// </summary>
        public DataTable GetForgotLoginDtls(Employee objEmp)
        {
            DataTable dtLoginDtls = null;
            DbCommand objCommand = null;
            try
            {
                objCommand = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "SP_GetForgotPassOfUser");
                Cls_DataAccess.getInstance().AddInParameter(objCommand, "UserName", DbType.String, objEmp.Email);
                dtLoginDtls = Cls_DataAccess.getInstance().GetDataTable(objCommand);
                return dtLoginDtls;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date : 12 July 2013
        /// Description :Get All Employees For Allocator's Report
        /// </summary>
        /// <param name="Fname"></param>
        /// <param name="RoleId"></param>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public DataTable GetAllEmpForReport(string Fname, int RoleId, DateTime FromDate, DateTime ToDate)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllEmpForReport");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FName", DbType.String, Fname);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Role", DbType.Int32, RoleId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FromDate", DbType.DateTime, FromDate);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "ToDate", DbType.DateTime, ToDate);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeDAO.GetAllEmpForReport Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 1 Aug 2013
        /// Description : For Changing Password Of User When it Changed From Quote 
        /// </summary>
        /// <param name="QuoteUserId"></param>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="CreatedById"></param>
        /// <returns></returns>
        public Int64 ChangePassword(Int64 QuoteUserId, string UserName, string password, Int64 CreatedById)
        {
            try
            {
                DbCommand objCmd = null;
                Int64 Result = 0;
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_ChangePassword");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "QuoteUserId", DbType.Int64, QuoteUserId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "UserName", DbType.String, UserName);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "Password", DbType.String, password);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, CreatedById);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex) 
            {
                logger.Error(ex.Message + "EmployeeDAO.ChangePassword Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 1 Aug 2013
        /// Description : For Changing Activation Status Of User When it Changed From Quote 
        /// </summary>
        /// <param name="QuoteUserId"></param>
        /// <param name="IsActive"></param>
        /// <param name="CreatedById"></param>
        /// <returns></returns>
        public Int64 ChangeIsActiveStatus(Int64 QuoteUserId, Boolean IsActive, Int64 CreatedById)
        {
            try
            {
                DbCommand objCmd = null;
                Int64 Result = 0;
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_ChangeIsActiveStatus");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "QuoteUserId", DbType.Int64, QuoteUserId);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "IsActive ", DbType.Boolean, IsActive);
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "CreatedById", DbType.Int64, CreatedById);
                Result = Convert.ToInt64(Cls_DataAccess.getInstance().ExecuteScaler(objCmd, null));
                return Result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeDAO.ChangeIsActiveStatus Error:" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 21 August 2013
        /// Description: Get All Consultants
        /// </summary>
        /// <param name="FName"></param>
        /// <returns></returns>
        public DataTable GetAllConsultants(string FName)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetAllConsultants");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "FName", DbType.String, FName);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeDAO.GetAllConsultants Error:" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Created By: Pravin Gholap
        /// Created Date: 04 Feb 2014
        /// Description: Get Employee & User Details From Quote User Id
        /// </summary>
        /// <returns></returns>
        public DataTable GetDetailsFromQuoteUserId(Int64 QuoteUserId)
        {
            DbCommand objCmd = null;
            DataTable DtResult = new DataTable();
            try
            {
                objCmd = Cls_DataAccess.getInstance().GetCommand(CommandType.StoredProcedure, "sp_GetDetailsFromQuoteUserId");
                Cls_DataAccess.getInstance().AddInParameter(objCmd, "QuoteUserId", DbType.Int64, QuoteUserId);
                DtResult = Cls_DataAccess.getInstance().GetDataTable(objCmd, null);
                return DtResult;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "EmployeeDAO.GetDetailsFromQuoteUserId Error:" + ex.StackTrace);
                return null;
            }
        }
        #endregion
    }
}
