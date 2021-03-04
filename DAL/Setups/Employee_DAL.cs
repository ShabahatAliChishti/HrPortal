using HrProperty.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Employee_DAL : DBInteraction
    {
        EmployeeProperty objEmpProp;
        Depandants_Property objdepandant;
        public Employee_DAL()
        {

        }

        public Employee_DAL(EmployeeProperty objEmp_prop)
        {
            objEmpProp = objEmp_prop;
        }
        public Employee_DAL(Depandants_Property dpndnt)
        {
            objdepandant = dpndnt;
        }

        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Employee_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@EmployeType_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.EmpType_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastEducation_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LastEdu_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Designation_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Designation_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Department_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Department_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Reference_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Reference_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Salary_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Salary_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Balance_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Balance_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@EmployeeName", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.EmpName));
                cmdToExecute.Parameters.Add(new SqlParameter("@Govt_ID", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.GovtId));
                cmdToExecute.Parameters.Add(new SqlParameter("@SSN_No", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.SSNno));
                cmdToExecute.Parameters.Add(new SqlParameter("@Driving_License_No", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LicenseNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@Image_path", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.ImgPath));
                cmdToExecute.Parameters.Add(new SqlParameter("@JoiningDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.JoiningDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Deputation_Location", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.DeputationLoc));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastEducationDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LastEducationDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastEmployer_Name", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LastEmployerName));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastEmployer_Add", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LastEmployerAdd));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastEmployer_Contact", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LastEmployerContact));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastEmployer_FromDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LastEmployerFromDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastEmployer_ToDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LastEmployerToDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@HomeAddress", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.HomeAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@Home_ContactNo", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.HomeContact));
                cmdToExecute.Parameters.Add(new SqlParameter("@Emergency_ContactNo", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.EmergencyPersonContact));
                cmdToExecute.Parameters.Add(new SqlParameter("@Emergency_Person_Name", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.EmergencyPersonName));
                cmdToExecute.Parameters.Add(new SqlParameter("@Emergency_Person_Relationship", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.EmergencyPersonRelation));
                cmdToExecute.Parameters.Add(new SqlParameter("@BloodGroup", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.BloodGroup));
                cmdToExecute.Parameters.Add(new SqlParameter("@ModeOfTraveling", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.ModeOfTraveling));
                cmdToExecute.Parameters.Add(new SqlParameter("@VehichleNo", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.VehicleNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit, 4, ParameterDirection.Input, false, 1, 1, "", DataRowVersion.Proposed, objEmpProp.IsActive));
                cmdToExecute.Parameters.Add(new SqlParameter("@U_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.U_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@basesalry", SqlDbType.Float, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.BaseSalary));
                cmdToExecute.Parameters.Add(new SqlParameter("@allow1", SqlDbType.Float, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Allownce1));
                cmdToExecute.Parameters.Add(new SqlParameter("@allow2", SqlDbType.Float, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Allownce2));
                cmdToExecute.Parameters.Add(new SqlParameter("@allow3", SqlDbType.Float, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Allownce3));
                cmdToExecute.Parameters.Add(new SqlParameter("@totalsalry", SqlDbType.Float, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.TotalSalary));
                cmdToExecute.Parameters.Add(new SqlParameter("@leaveblnce", SqlDbType.Float, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LeaveBalances));
                cmdToExecute.Parameters.Add(new SqlParameter("@benefit1", SqlDbType.Float, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Benefit1));
                cmdToExecute.Parameters.Add(new SqlParameter("@benefit2", SqlDbType.Float, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Benefit2));
                cmdToExecute.Parameters.Add(new SqlParameter("@BankAccountNo", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.BankAccountNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@Attendance_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Attndnc_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@lastinstitue", SqlDbType.Text, 400, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LastInstitueName));
                cmdToExecute.Parameters.Add(new SqlParameter("@Employee_Id", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Employee_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@AnnualLeaves", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Annual_Leaves));
                cmdToExecute.Parameters.Add(new SqlParameter("@SickLeaves", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Sick_Leaves));
                cmdToExecute.Parameters.Add(new SqlParameter("@CasualLeaves", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Casual_Leaves));

                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                


                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();

                _errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;
                if (_errorCode == 0)
                {
                    // Throw error.
                    //throw new Exception("Stored Procedure 'pr_PRODUCT_SETUP_Insert' reported the ErrorCode: " + _errorCode);
                    return false;
                }


                //ObjProductSetupProperty.ID = (SqlInt32)cmdToExecute.Parameters["@iID"].Value;
                //ObjProductSetupProperty.ErrorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("tbl_Employee::Insert::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
        }

        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Employees_GetAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Employee_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }
                // Execute query.
                adapter.Fill(toReturn);
                //  _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'pr_PRODUCT_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Employee_SETUP::SelectAll::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }

        public override DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Employees_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Employee_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@EmployeType_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Id));

                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }
                // Execute query.
                adapter.Fill(toReturn);
                //  _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'pr_PRODUCT_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                if (toReturn.Rows.Count > 0)
                {
                    objEmpProp.Id = (Int32)toReturn.Rows[0]["ID"];
                    if (toReturn.Rows[0]["EmployeType_Id"] != DBNull.Value)
                    {
                        objEmpProp.EmpType_Id = (Int32)toReturn.Rows[0]["EmployeType_Id"];
                    }
                    else
                    {
                        objEmpProp.EmpType_Id = 0;
                    }
                    ////toReturn.Rows[0]["Product_Type_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Type_ID"];
                    if (toReturn.Rows[0]["LastEducation_Id"] != DBNull.Value)
                    {
                        objEmpProp.LastEdu_Id = (Int32)toReturn.Rows[0]["LastEducation_Id"];
                    }
                    else
                    {
                        objEmpProp.LastEdu_Id = 0;
                    }


                    if (toReturn.Rows[0]["Designation_Id"] != DBNull.Value)
                    {
                        objEmpProp.Designation_Id = (Int32)toReturn.Rows[0]["Designation_Id"];
                    }
                    else
                    {
                        objEmpProp.Designation_Id = 0;
                    }
                    ////toReturn.Rows[0]["Packing_Unit_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Packing_Unit_ID"];

                    if (toReturn.Rows[0]["Department_Id"] != DBNull.Value)
                    {
                        objEmpProp.Department_id = (Int32)toReturn.Rows[0]["Department_Id"];
                    }
                    else
                    {
                        objEmpProp.Department_id = 0;
                    }
                    // toReturn.Rows[0]["Mobile_No"] == DBNull.Value ? string.Empty : (string)toReturn.Rows[0]["Mobile_No"];
                    if (toReturn.Rows[0]["Reference_Id"] != DBNull.Value)
                    {
                        objEmpProp.Reference_id = (Int32)toReturn.Rows[0]["Reference_Id"];
                    }
                    else
                    {
                        objEmpProp.Reference_id =0;
                    }

                    
                    objEmpProp.EmpName= toReturn.Rows[0]["EmployeeName"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["EmployeeName"];
                    objEmpProp.GovtId = toReturn.Rows[0]["Govt_ID"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Govt_ID"];
                    objEmpProp.SSNno = toReturn.Rows[0]["SSN_No"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["SSN_No"];
                    objEmpProp.LicenseNo = toReturn.Rows[0]["Driving_License_No"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Driving_License_No"];
                    objEmpProp.ImgPath = toReturn.Rows[0]["Image_path"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Image_path"];
                    objEmpProp.JoiningDate = (DateTime)toReturn.Rows[0]["JoiningDate"];
                    objEmpProp.DeputationLoc = toReturn.Rows[0]["Deputation_Location"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Deputation_Location"];
                    objEmpProp.LastEmployerName = toReturn.Rows[0]["LastEmployer_Name"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["LastEmployer_Name"];
                    objEmpProp.LastEmployerAdd = toReturn.Rows[0]["LastEmployer_Add"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["LastEmployer_Add"];
                    objEmpProp.LastEmployerContact = toReturn.Rows[0]["LastEmployer_Contact"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["LastEmployer_Contact"];
                    objEmpProp.LastInstitueName = toReturn.Rows[0]["Last_Institue_Name"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Last_Institue_Name"];


                    //objEmpProp.LastEducationDate =Convert.ToDateTime(toReturn.Rows[0]["LastEducationDate"]==DBNull?)== DBNull.Value.ToString() ? String.Empty : (string)toReturn.Rows[0]["Driving_License_No"];
                    //objEmpProp.LastEmployerFromDate = (DateTime)toReturn.Rows[0]["LastEmployer_FromDate"];// == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Driving_License_No"];
                    //objEmpProp.LastEmployerToDate = (DateTime)toReturn.Rows[0]["LastEmployer_ToDate"];//== DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Driving_License_No"];
                    objEmpProp.HomeAddress = toReturn.Rows[0]["HomeAddress"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["HomeAddress"];
                    objEmpProp.HomeContact = toReturn.Rows[0]["Home_ContactNo"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Home_ContactNo"];
                    objEmpProp.EmergencyPersonContact = toReturn.Rows[0]["Emergency_ContactNo"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Emergency_ContactNo"];
                    objEmpProp.EmergencyPersonName = toReturn.Rows[0]["Emergency_Person_Name"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Emergency_Person_Name"];
                    objEmpProp.EmergencyPersonRelation = toReturn.Rows[0]["Emergency_Person_Relationship"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Emergency_Person_Relationship"];
                    objEmpProp.BloodGroup = toReturn.Rows[0]["BloodGroup"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["BloodGroup"];
                    objEmpProp.ModeOfTraveling = toReturn.Rows[0]["ModeOfTraveling"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["ModeOfTraveling"];
                    objEmpProp.VehicleNo = toReturn.Rows[0]["VehichleNo"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["VehichleNo"];
                    objEmpProp.Status = toReturn.Rows[0]["Status"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Status"];
                    objEmpProp.U_id = (Int32)toReturn.Rows[0]["U_id"];// toReturn.Rows[0]["Status"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Status"];
                    objEmpProp.IsActive= (bool)toReturn.Rows[0]["IsActive"];

                    if (toReturn.Rows[0]["BaseSalary"] != DBNull.Value)
                    {
                        objEmpProp.BaseSalary = float.Parse(toReturn.Rows[0]["BaseSalary"].ToString());
                    }
                    else
                    {
                        objEmpProp.BaseSalary = 0;
                    }

                    if (toReturn.Rows[0]["Allownce1"] != DBNull.Value)
                    {
                        objEmpProp.Allownce1 = float.Parse(toReturn.Rows[0]["Allownce1"].ToString());
                    }
                    else
                    {
                        objEmpProp.Allownce1 =0;
                    }
                    if (toReturn.Rows[0]["Allownce2"] != DBNull.Value)
                    {
                        objEmpProp.Allownce2 = float.Parse(toReturn.Rows[0]["Allownce2"].ToString());
                    }
                    else
                    {
                        objEmpProp.Allownce2 =0;
                    }
                    if (toReturn.Rows[0]["Allownce3"] != DBNull.Value)
                    {
                        objEmpProp.Allownce3 = float.Parse(toReturn.Rows[0]["Allownce3"].ToString());
                    }
                    else
                    {
                        objEmpProp.Allownce3 = 0;
                    }
                    if (toReturn.Rows[0]["TotalSalary"] != DBNull.Value)
                    {
                        objEmpProp.TotalSalary = float.Parse(toReturn.Rows[0]["TotalSalary"].ToString());

                    }
                    else
                    {
                        objEmpProp.TotalSalary = 0;

                    }
                    if (toReturn.Rows[0]["LeaveBalnces"] != DBNull.Value)
                    {
                        objEmpProp.LeaveBalances = float.Parse(toReturn.Rows[0]["LeaveBalnces"].ToString());

                    }
                    else
                    {
                        objEmpProp.LeaveBalances = 0;

                    }
                    if (toReturn.Rows[0]["Benefit1"] != DBNull.Value)
                    {
                        objEmpProp.Benefit1 = float.Parse(toReturn.Rows[0]["Benefit1"].ToString());

                    }
                    else
                    {
                        objEmpProp.Benefit1 = 0;

                    }
                    if (toReturn.Rows[0]["Benefit2"] != DBNull.Value)
                    {
                        objEmpProp.Benefit2 = float.Parse(toReturn.Rows[0]["Benefit2"].ToString());

                    }
                    else
                    {
                        objEmpProp.Benefit2 = 0;
                    }
                    

                    objEmpProp.Employee_ID = toReturn.Rows[0]["Employee_Id"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Employee_Id"];

                    objEmpProp.BankAccountNo = toReturn.Rows[0]["BankAccountNo"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["BankAccountNo"];
                    if (toReturn.Rows[0]["Attendance_Id"] != DBNull.Value)
                    {
                        objEmpProp.Attndnc_id = (Int32)toReturn.Rows[0]["Attendance_Id"];

                    }
                    else
                    {
                        objEmpProp.Attndnc_id = 0;
                    }

                   

                    if (toReturn.Rows[0]["LastEducationDate"] != DBNull.Value)
                    {
                    objEmpProp.LastEducationDate =Convert.ToDateTime(toReturn.Rows[0]["LastEducationDate"]);

                    }
                    if (toReturn.Rows[0]["LastEmployer_FromDate"] != DBNull.Value)
                    {
                        objEmpProp.LastEmployerFromDate = Convert.ToDateTime(toReturn.Rows[0]["LastEmployer_FromDate"]);

                    }
                    if (toReturn.Rows[0]["LastEmployer_ToDate"] != DBNull.Value)
                    {
                        objEmpProp.LastEmployerToDate = Convert.ToDateTime(toReturn.Rows[0]["LastEmployer_ToDate"]);

                    }

                    if (toReturn.Rows[0]["Annual_Leaves"] != DBNull.Value)
                    {
                        objEmpProp.Annual_Leaves = Convert.ToInt32(toReturn.Rows[0]["Annual_Leaves"]);

                    }

                    if (toReturn.Rows[0]["Sick_Leaves"] != DBNull.Value)
                    {
                        objEmpProp.Sick_Leaves = Convert.ToInt32(toReturn.Rows[0]["Sick_Leaves"]);

                    }
                    if (toReturn.Rows[0]["Casual_Leaves"] != DBNull.Value)
                    {
                        objEmpProp.Casual_Leaves = Convert.ToInt32(toReturn.Rows[0]["Casual_Leaves"]);

                    }

                    //objEmpProp.LastEducationDate =Convert.ToDateTime(toReturn.Rows[0]["LastEducationDate"]==DBNull?)== DBNull.Value.ToString() ? String.Empty : (string)toReturn.Rows[0]["Driving_License_No"];
                    //objEmpProp.LastEmployerFromDate = (DateTime)toReturn.Rows[0]["LastEmployer_FromDate"];// == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Driving_License_No"];
                    //objEmpProp.LastEmployerToDate = (DateTime)toReturn.Rows[0]["LastEmployer_ToDate"];//== DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Driving_License_No"];



                    ////toReturn.Rows[0]["Product_Form_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Form_ID"];
                    //ObjCustomerProperty.CustomerPhone = toReturn.Rows[0]["Phone_No"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Phone_No"];
                    ////toReturn.Rows[0]["Product_Code"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["Product_Code"];
                    //ObjCustomerProperty.customerEmail = toReturn.Rows[0]["Email"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Email"];
                    //ObjCustomerProperty.CustomerAddress = (string)toReturn.Rows[0]["Address"];

                    //ObjCustomerProperty.Status = (string)toReturn.Rows[0]["Status"];
                    //ObjCustomerProperty.CreatedDate = (DateTime)toReturn.Rows[0]["Date_Created"];
                    //  toReturn.Rows[0]["Product_Parent_Code"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Parent_Code"];

                }




                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Employee_SETUP::SelectAll::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }

        public override bool Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Employee_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@employee_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@EmployeType_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.EmpType_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastEducation_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LastEdu_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Designation_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Designation_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Department_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Department_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Reference_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Reference_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Salary_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Salary_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Balance_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Balance_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@EmployeeName", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.EmpName));
                cmdToExecute.Parameters.Add(new SqlParameter("@Govt_ID", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.GovtId));
                cmdToExecute.Parameters.Add(new SqlParameter("@SSN_No", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.SSNno));
                cmdToExecute.Parameters.Add(new SqlParameter("@Driving_License_No", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LicenseNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@Image_path", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.ImgPath));
                cmdToExecute.Parameters.Add(new SqlParameter("@JoiningDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.JoiningDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Deputation_Location", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.DeputationLoc));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastEducationDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LastEducationDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastEmployer_Name", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LastEmployerName));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastEmployer_Add", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LastEmployerAdd));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastEmployer_Contact", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LastEmployerContact));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastEmployer_FromDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LastEmployerFromDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastEmployer_ToDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LastEmployerToDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@HomeAddress", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.HomeAddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@Home_ContactNo", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.HomeContact));
                cmdToExecute.Parameters.Add(new SqlParameter("@Emergency_ContactNo", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.EmergencyPersonContact));
                cmdToExecute.Parameters.Add(new SqlParameter("@Emergency_Person_Name", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.EmergencyPersonName));
                cmdToExecute.Parameters.Add(new SqlParameter("@Emergency_Person_Relationship", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.EmergencyPersonRelation));
                cmdToExecute.Parameters.Add(new SqlParameter("@BloodGroup", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.BloodGroup));
                cmdToExecute.Parameters.Add(new SqlParameter("@ModeOfTraveling", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.ModeOfTraveling));
                cmdToExecute.Parameters.Add(new SqlParameter("@VehichleNo", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.VehicleNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit, 4, ParameterDirection.Input, false, 1, 1, "", DataRowVersion.Proposed, objEmpProp.IsActive));
                cmdToExecute.Parameters.Add(new SqlParameter("@U_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.U_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@basesalry", SqlDbType.Float, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.BaseSalary));
                cmdToExecute.Parameters.Add(new SqlParameter("@allow1", SqlDbType.Float, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Allownce1));
                cmdToExecute.Parameters.Add(new SqlParameter("@allow2", SqlDbType.Float, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Allownce2));
                cmdToExecute.Parameters.Add(new SqlParameter("@allow3", SqlDbType.Float, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Allownce3));
                cmdToExecute.Parameters.Add(new SqlParameter("@totalsalry", SqlDbType.Float, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.TotalSalary));
                cmdToExecute.Parameters.Add(new SqlParameter("@leaveblnce", SqlDbType.Float, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LeaveBalances));
                cmdToExecute.Parameters.Add(new SqlParameter("@benefit1", SqlDbType.Float, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Benefit1));
                cmdToExecute.Parameters.Add(new SqlParameter("@benefit2", SqlDbType.Float, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Benefit2));
                cmdToExecute.Parameters.Add(new SqlParameter("@BankAccountNo", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.BankAccountNo));
                cmdToExecute.Parameters.Add(new SqlParameter("@Attendance_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Attndnc_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@lastinstituename", SqlDbType.Text, 400, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.LastInstitueName));
                cmdToExecute.Parameters.Add(new SqlParameter("@AnnualLeaves", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Annual_Leaves));
                cmdToExecute.Parameters.Add(new SqlParameter("@SickLeaves", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Sick_Leaves));
                cmdToExecute.Parameters.Add(new SqlParameter("@CasualLeaves", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Casual_Leaves));


                cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));


                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                // Execute query.
                this.StartTransaction();
                cmdToExecute.Transaction = this.Transaction;
                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                // _iD = (Int32)cmdToExecute.Parameters["@iID"].Value;
                //_errorCode = cmdToExecute.Parameters["@ErrorCode"].Value;

                if (objEmpProp.DepandantsList != null)
                {
                  


                    

                    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    sbc.ColumnMappings.Clear();

                    sbc.DestinationTableName = "tbl_Depandants";
                    sbc.ColumnMappings.Clear();
                    
                    sbc.ColumnMappings.Add("Depand_Name", "Depand_Name");
                    sbc.ColumnMappings.Add("RelationShip", "RelationShip");
                    sbc.ColumnMappings.Add("Dob", "Dob");
                    sbc.ColumnMappings.Add("Medical", "Medical");
                    sbc.ColumnMappings.Add("Nic", "Nic");
                    sbc.ColumnMappings.Add("Employee_Primary_Id", "Employee_Primary_Id");
                    sbc.ColumnMappings.Add("Employee_Key", "Employee_Key");
                    //sbc.DestinationTableName = dt.TableName;
                    sbc.WriteToServer(objEmpProp.DepandantsList);

                }

                this.Commit();
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    this.RollBack();
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_Insert' reported the ErrorCode: " + _errorCode);

                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("tbl_Employee::Insert::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
        }

        public bool UpdateStatus()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Status_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objEmpProp.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objEmpProp.Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objEmpProp.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@operationBy", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objEmpProp.U_id));

                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                //_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                //// some error occured. Bubble it to caller and encapsulate Exception object
                //objErrorTrace.Error_Msg = (SqlString)ex.Message;
                //objErrorTrace.Error_Proc = "sp_POS_SETUP_UpdateStatus";
                //objErrorTrace.Insert();
                //HttpContext.Current.Response.Redirect("~/Error.aspx");


                ////Send Email To Application Developer's
                //MailMessage mailMessage = new MailMessage();
                //mailMessage.To.Add("adeel.riaz@armtech.com.pk");
                //mailMessage.To.Add("ammar.ali@armtech.com.pk");
                //mailMessage.To.Add("Zahid.Ghaffar@armtech.com.pk");
                //mailMessage.From = new MailAddress("Error@SSS.com");
                //mailMessage.Subject = "Error in sp_CURRENCY_SETUP_Insert";
                //mailMessage.Body = (String)objErrorTrace.Error_Msg;
                //SmtpClient smtpClient = new SmtpClient("180.92.128.165", 25);
                //smtpClient.Send(mailMessage);

                return false;

            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
        }
        public DataTable SelecDepandanttOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetDepandantsOfEmployee]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Employee_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Employee_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objdepandant.Employee_Primary_Id));

                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }
                // Execute query.
                adapter.Fill(toReturn);
                //  _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

               



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Employee_SETUP::SelectAll::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }




        public DataTable CheckEmployeeID()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Check_Employee_Id]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Employee_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Employee_ID", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.Employee_ID));

                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }
                // Execute query.
                adapter.Fill(toReturn);
                //  _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'pr_PRODUCT_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
 
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Employee_SETUP::SelectAll::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }
    }
}
