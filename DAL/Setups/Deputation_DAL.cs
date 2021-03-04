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
    public class Deputation_DAL : DBInteraction
    {
        Deputation_Property objDeputation;
        public Deputation_DAL()
        {

        }

        public Deputation_DAL(Deputation_Property objDep)
        {
             objDeputation = objDep ;
        }

        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Deputation_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Deputation_SETUP");
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
                throw new Exception("DEputation_SETUP::SelectAll::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_Deputation_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                //cmdToExecute.Parameters.Add(new SqlParameter("@EmployeType_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.EmpType_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Deputationlocation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Deputation_Location));
                cmdToExecute.Parameters.Add(new SqlParameter("@longitute", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Longitude));
                cmdToExecute.Parameters.Add(new SqlParameter("@latitude", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Latitude));
                cmdToExecute.Parameters.Add(new SqlParameter("@isactive", SqlDbType.Bit, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.is_Active));
                cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@insertedby", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Inserted_By));
                cmdToExecute.Parameters.Add(new SqlParameter("@date_created", SqlDbType.Date, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Date_Created));


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
                throw new Exception("tbl_ProjectType::Insert::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_Deputation_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                //cmdToExecute.Parameters.Add(new SqlParameter("@EmployeType_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.EmpType_Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@Deputationlocation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Deputation_Location));
                cmdToExecute.Parameters.Add(new SqlParameter("@longitute", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Longitude));
                cmdToExecute.Parameters.Add(new SqlParameter("@latitude", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Latitude));
                cmdToExecute.Parameters.Add(new SqlParameter("@isactive", SqlDbType.Bit, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.is_Active));
                cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Id));
                cmdToExecute.Parameters.Add(new SqlParameter("@date_created", SqlDbType.Date, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Date_Created));
                cmdToExecute.Parameters.Add(new SqlParameter("@insertedby", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Inserted_By));

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
                throw new Exception("tbl_ProjectType::Insert::Error occured.", ex);
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



        public  bool DeleteDeputation()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Deputation_Delete]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                //cmdToExecute.Parameters.Add(new SqlParameter("@EmployeType_Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objEmpProp.EmpType_Id));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Deputationlocation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Deputation_Location));
                //cmdToExecute.Parameters.Add(new SqlParameter("@longitute", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Longitude));
                //cmdToExecute.Parameters.Add(new SqlParameter("@latitude", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Latitude));
                //cmdToExecute.Parameters.Add(new SqlParameter("@isactive", SqlDbType.Bit, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.is_Active));
                //cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Id));
                //cmdToExecute.Parameters.Add(new SqlParameter("@date_created", SqlDbType.Date, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Date_Created));
                //cmdToExecute.Parameters.Add(new SqlParameter("@insertedby", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Inserted_By));

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
                throw new Exception("tbl_ProjectType::Insert::Error occured.", ex);
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
            DataTable toReturn = new DataTable("Department_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            string colName = "Id";

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@tblName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "tbl_deputation"));
                cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objDeputation.Id));
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
                    objDeputation.Id = (Int32)toReturn.Rows[0]["Id"];
                    objDeputation.Deputation_Location = (String)toReturn.Rows[0]["Deputation_Location"];
                    objDeputation.Latitude = (String)toReturn.Rows[0]["Latitude"];
                    objDeputation.Longitude = (String)toReturn.Rows[0]["Longitude"];
                    //objEmpPropobjDeputation.EmpType_Id = (Int32)toReturn.Rows[0]["EmployeType_Id"];
                    //////toReturn.Rows[0]["Product_Type_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Type_ID"];
                    //objEmpProp.LastEdu_Id = (Int32)toReturn.Rows[0]["LastEducation_Id"];
                    //////toReturn.Rows[0]["Packing_Unit_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Packing_Unit_ID"];
                    //objEmpProp.Designation_Id = (Int32)toReturn.Rows[0]["Designation_Id"];// toReturn.Rows[0]["Mobile_No"] == DBNull.Value ? string.Empty : (string)toReturn.Rows[0]["Mobile_No"];
                    //objEmpProp.Department_id = (Int32)toReturn.Rows[0]["Department_Id"];
                    //objEmpProp.Reference_id = (Int32)toReturn.Rows[0]["Reference_Id"];
                    //objEmpProp.EmpName = toReturn.Rows[0]["EmployeeName"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["EmployeeName"];
                    //objEmpProp.GovtId = toReturn.Rows[0]["Govt_ID"] == DBNull.Value ? String.Empty : (string)toReturn.Rows[0]["Govt_ID"];
                    

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



    }
}
