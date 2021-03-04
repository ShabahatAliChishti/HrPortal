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
    public class Client_DAL  : DBInteraction
    {
        Client_Property objClientProp;
        public Client_DAL()
        {
               
        }

        public Client_DAL(Client_Property clientProp)
        {
            objClientProp =  clientProp;
        }

        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetAllClients]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Department_SETUP");
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
                throw new Exception("Client_SETUP::SelectAll::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_Client_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@Client_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objClientProp.Client_name ));
                cmdToExecute.Parameters.Add(new SqlParameter("@Client_No", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objClientProp.Client_no));
                cmdToExecute.Parameters.Add(new SqlParameter("@Client_Mobile", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objClientProp.Client_mobile_no));
                cmdToExecute.Parameters.Add(new SqlParameter("@Client_Address", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objClientProp.Clientaddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objClientProp.Status ));
                cmdToExecute.Parameters.Add(new SqlParameter("@Isactive", SqlDbType.Bit, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objClientProp.Is_active ));                
                cmdToExecute.Parameters.Add(new SqlParameter("@user_id", SqlDbType.Int, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objClientProp.User_id ));
                

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
                throw new Exception("Client_SETUP::Insert::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_Client_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objClientProp.Client_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Client_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objClientProp.Client_name));
                cmdToExecute.Parameters.Add(new SqlParameter("@Client_No", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objClientProp.Client_no));
                cmdToExecute.Parameters.Add(new SqlParameter("@Client_Mobile", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objClientProp.Client_mobile_no));
                cmdToExecute.Parameters.Add(new SqlParameter("@Client_Address", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objClientProp.Clientaddress));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objClientProp.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@Isactive", SqlDbType.Bit, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objClientProp.Is_active));
                cmdToExecute.Parameters.Add(new SqlParameter("@user_id", SqlDbType.Int, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objClientProp.User_id));


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
                throw new Exception("Client_SETUP::Insert::Error occured.", ex);
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
            DataTable toReturn = new DataTable("Client_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            string colName = "ClientID";

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@tblName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objClientProp.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objClientProp.Client_id));
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
                    objClientProp.Client_id = (Int32)toReturn.Rows[0]["ClientID"];
                    objClientProp.Client_name = (String)toReturn.Rows[0]["Client_Name"];
                    objClientProp.Client_mobile_no = (String)toReturn.Rows[0]["Client_Mobile"];
                    objClientProp.Client_no = (String)toReturn.Rows[0]["Client_No"];
                    objClientProp.Clientaddress = (String)toReturn.Rows[0]["Client_Address"];
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
            string colName = "ClientID";
            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objClientProp.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objClientProp.Client_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objClientProp.Status));
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
