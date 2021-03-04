using HrProperty;
using HrProperty.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Setups
{
   public class Designation_DAL:DBInteraction
    {
        Designation_Property objdesignationproperty;
        public Designation_DAL()
        {

        }
        public Designation_DAL(Designation_Property designation)
        {
            objdesignationproperty = designation;
        }

        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Designation_GetAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Designation_SETUP");
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
                throw new Exception("Desigantion_SETUP::SelectAll::Error occured.", ex);
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

        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Designation_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@designation", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objdesignationproperty.Designation));
                cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objdesignationproperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@isactive", SqlDbType.Bit, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objdesignationproperty.ISActive));
                cmdToExecute.Parameters.Add(new SqlParameter("@Datecreated", SqlDbType.Date, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objdesignationproperty.CreatedDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@user_id", SqlDbType.Int, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objdesignationproperty.UserId));
                //cmdToExecute.Parameters.Add(new SqlParameter("@datecreated", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjCustomerProperty.CreatedDate));
                //cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjCustomerProperty.Status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@isactice", SqlDbType.Bit, 4, ParameterDirection.Input, false, 1, 1, "", DataRowVersion.Proposed, ObjCustomerProperty.ISActive));
                //cmdToExecute.Parameters.Add(new SqlParameter("@userid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjCustomerProperty.UserId));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iSmall_Unit", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_Unit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iSmall_Weight", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_Weight));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iSmall_UOM_Length", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_UOM_Length));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iSmall_UOM_Width", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_UOM_Width));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iSmall_UOM_Height", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_UOM_Height));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iDozen_Unit", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_Unit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iDozen_Weight", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_Weight));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iDozen_UOM_Length", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_UOM_Length));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iDozen_UOM_Width", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_UOM_Width));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iDozen_UOM_Height", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_UOM_Height));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iConversion_Unit", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_Unit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iConversion_Weight", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_Weight));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iConversion_UOM_Length", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_UOM_Length));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iConversion_UOM_Width", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_UOM_Width));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iConversion_UOM_Height", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_UOM_Height));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sPriceApplyOn", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.PriceApplyOn));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sSKU_Previous_Code", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.SKU_Previous_Code));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iGST", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.GST));
                //cmdToExecute.Parameters.Add(new SqlParameter("@bGST_Free_SKU", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.GST_Free_SKU));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iGST_Schedule_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.GST_Schedule_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@dcSale_Price", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ObjProductSetupProperty.Sale_Price));
                //cmdToExecute.Parameters.Add(new SqlParameter("@dcPurchase_Price", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ObjProductSetupProperty.Purchase_Price));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iSale_Days", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Sale_Days));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iStop_Days", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Stop_Days));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iQty_Limit", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Qty_Limit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@dcValue_Limit", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ObjProductSetupProperty.Value_Limit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@bIs_Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Is_Active));
                //cmdToExecute.Parameters.Add(new SqlParameter("@daDefined_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Defined_Date));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sDefined_By", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Defined_By));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                //cmdToExecute.Parameters.Add(new SqlParameter("@bIs_Final_Product", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Is_Final_Product));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iTax_Applicable", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.TAX_Applicable));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iProduct_Index", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_index));

                //cmdToExecute.Parameters.Add(new SqlParameter("@Record_Table_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Record_Table_Name));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Operation));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Operated_By", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Operated_By));



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

                //_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    //throw new Exception("Stored Procedure 'pr_PRODUCT_SETUP_Insert' reported the ErrorCode: " + _errorCode);
                //    return false;
                //}


                //ObjProductSetupProperty.ID = (SqlInt32)cmdToExecute.Parameters["@iID"].Value;
                //ObjProductSetupProperty.ErrorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Department_SETUP::Insert::Error occured.", ex);
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
        public override bool Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Designation_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objdesignationproperty.Designation_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@designation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objdesignationproperty.Designation));
                //cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objdesignationproperty.Status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@isactive", SqlDbType.Bit, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objdesignationproperty.ISActive));
                //cmdToExecute.Parameters.Add(new SqlParameter("@datecreated", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objdesignationproperty.CreatedDate));
                //cmdToExecute.Parameters.Add(new SqlParameter("@uid", SqlDbType.Int, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objdesignationproperty.UserId));
                //cmdToExecute.Parameters.Add(new SqlParameter("@customer_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjCustomerProperty.CustomerName));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjCustomerProperty.CustomerAddress));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Phone_No", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjCustomerProperty.CustomerPhone));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Mobile_No", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjCustomerProperty.CustomerMobile));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjCustomerProperty.customerEmail));
                //cmdToExecute.Parameters.Add(new SqlParameter("@User_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjCustomerProperty.UserId));

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




                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                //throw new Exception("PRODUCT_SETUP::Update::Error occured.", ex);
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

        public override DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SelectOne]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Designation_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            string colName = "DesignationID";
            string tblName = "tblDesignation";

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@tblName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, tblName));
                cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objdesignationproperty.Designation_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@colName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, colName));

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
                    objdesignationproperty.Designation_Id = (Int32)toReturn.Rows[0]["DesignationID"];
                    objdesignationproperty.Designation = (String)toReturn.Rows[0]["Designation"];
                    //objEmpProp.EmpType_Id = (Int32)toReturn.Rows[0]["EmployeType_Id"];
                    //////toReturn.Rows[0]["Product_Type_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Type_ID"];
                    //objEmpProp.LastEdu_Id = (Int32)toReturn.Rows[0]["LastEducation_Id"];
                    //////toReturn.Rows[0]["Packing_Unit_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Packing_Unit_ID"];
                    //objEmpProp.Designation_Id = (Int32)toReturn.Rows[0]["Designation_Id"];// toReturn.Rows[0]["Mobile_No"] == DBNull.Value ? string.Empty : (string)toReturn.Rows[0]["Mobile_No"];
                    //objEmpProp.Department_id = (Int32)toReturn.Rows[0]["Department_Id"];
                    //objEmpProp.Reference_id = (Int32)toReturn.Rows[0]["Reference_Id"];
                    //objEmpProp.EmpName = toReturn.Rows[0]["EmployeeName"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["EmployeeName"];
                    //objEmpProp.GovtId = toReturn.Rows[0]["Govt_ID"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Govt_ID"];
                    //objEmpProp.SSNno = toReturn.Rows[0]["SSN_No"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["SSN_No"];
                    //objEmpProp.LicenseNo = toReturn.Rows[0]["Driving_License_No"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Driving_License_No"];
                    //objEmpProp.ImgPath = toReturn.Rows[0]["Image_path"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Image_path"];
                    //objEmpProp.JoiningDate = (DateTime)toReturn.Rows[0]["JoiningDate"];
                    //objEmpProp.DeputationLoc = toReturn.Rows[0]["Deputation_Location"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Deputation_Location"];
                    ////objEmpProp.LastEducationDate =Convert.ToDateTime(toReturn.Rows[0]["LastEducationDate"]==DBNull?)== DBNull.Value.ToString() ? String.Empty : (string)toReturn.Rows[0]["Driving_License_No"];
                    //objEmpProp.LastEmployerName = toReturn.Rows[0]["LastEmployer_Name"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["LastEmployer_Name"];
                    //objEmpProp.LastEmployerAdd = toReturn.Rows[0]["LastEmployer_Add"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["LastEmployer_Add"];
                    //objEmpProp.LastEmployerContact = toReturn.Rows[0]["LastEmployer_Contact"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["LastEmployer_Contact"];
                    ////objEmpProp.LastEmployerFromDate = (DateTime)toReturn.Rows[0]["LastEmployer_FromDate"];// == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Driving_License_No"];
                    ////objEmpProp.LastEmployerToDate = (DateTime)toReturn.Rows[0]["LastEmployer_ToDate"];//== DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Driving_License_No"];
                    //objEmpProp.HomeAddress = toReturn.Rows[0]["HomeAddress"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["HomeAddress"];
                    //objEmpProp.HomeContact = toReturn.Rows[0]["Home_ContactNo"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Home_ContactNo"];
                    //objEmpProp.EmergencyPersonContact = toReturn.Rows[0]["Emergency_ContactNo"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Emergency_ContactNo"];
                    //objEmpProp.EmergencyPersonName = toReturn.Rows[0]["Emergency_Person_Name"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Emergency_Person_Name"];
                    //objEmpProp.EmergencyPersonRelation = toReturn.Rows[0]["Emergency_Person_Relationship"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Emergency_Person_Relationship"];
                    //objEmpProp.BloodGroup = toReturn.Rows[0]["BloodGroup"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["BloodGroup"];
                    //objEmpProp.ModeOfTraveling = toReturn.Rows[0]["ModeOfTraveling"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["ModeOfTraveling"];
                    //objEmpProp.VehicleNo = toReturn.Rows[0]["VehichleNo"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["VehichleNo"];
                    //objEmpProp.Status = toReturn.Rows[0]["Status"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Status"];
                    //objEmpProp.U_id = (Int32)toReturn.Rows[0]["U_id"];// toReturn.Rows[0]["Status"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Status"];
                    //objEmpProp.IsActive = (bool)toReturn.Rows[0]["IsActive"];
                    //objEmpProp.BaseSalary = float.Parse(toReturn.Rows[0]["BaseSalary"].ToString());
                    //objEmpProp.Allownce1 = float.Parse(toReturn.Rows[0]["Allownce1"].ToString());
                    //objEmpProp.Allownce2 = float.Parse(toReturn.Rows[0]["Allownce2"].ToString());
                    //objEmpProp.Allownce3 = float.Parse(toReturn.Rows[0]["Allownce3"].ToString());
                    //objEmpProp.TotalSalary = float.Parse(toReturn.Rows[0]["TotalSalary"].ToString());
                    //objEmpProp.LeaveBalances = float.Parse(toReturn.Rows[0]["LeaveBalnces"].ToString());
                    //objEmpProp.Benefit1 = float.Parse(toReturn.Rows[0]["Benefit1"].ToString());
                    //objEmpProp.Benefit2 = float.Parse(toReturn.Rows[0]["Benefit2"].ToString());
                    //objEmpProp.BankAccountNo = toReturn.Rows[0]["BankAccountNo"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["BankAccountNo"];
                    //objEmpProp.Attndnc_id = (Int32)toReturn.Rows[0]["Attendance_Id"];

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

        public bool UpdateStatus()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Status_Update_Delete]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            string colName = "DesignationID";
            string tblName = "tblDesignation";
            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, tblName));
                cmdToExecute.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objdesignationproperty.Designation_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objdesignationproperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@operationBy", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, SessionManager.CurrentUser.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@ColName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, colName));

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

    }
}
