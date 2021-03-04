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
    public class User_DAL:DBInteraction
    {
        User_Property objUserProperty;

        public User_DAL()
        {
        }

        public User_DAL(User_Property objUser_Property)
        {
            objUserProperty = objUser_Property;
            
        }

        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_USER_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("USER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.AddWithValue("@id", objUserProperty.ID);
                //cmdToExecute.Parameters.AddWithValue("@code", objUserProperty.Code);
                //cmdToExecute.Parameters.AddWithValue("@distributorCode", objUserProperty.DistributorCode);
                //cmdToExecute.Parameters.AddWithValue("@companyID", objUserProperty.CompanyID);
                cmdToExecute.Parameters.AddWithValue("@userName", objUserProperty.UserName);
                cmdToExecute.Parameters.AddWithValue("@firstName", objUserProperty.FirstName);
                cmdToExecute.Parameters.AddWithValue("@lastName", objUserProperty.LastName);
                cmdToExecute.Parameters.AddWithValue("@email", objUserProperty.Email);
                cmdToExecute.Parameters.AddWithValue("@password", objUserProperty.Password);
                cmdToExecute.Parameters.AddWithValue("@active", objUserProperty.Active);
                cmdToExecute.Parameters.AddWithValue("@insertBy", objUserProperty.InsertBy);
                cmdToExecute.Parameters.AddWithValue("@insertionDate", objUserProperty.InsertionDate);
                cmdToExecute.Parameters.AddWithValue("@PageNum", objUserProperty.PageNum);
                cmdToExecute.Parameters.AddWithValue("@PageSize", objUserProperty.PageSize);
                cmdToExecute.Parameters.AddWithValue("@sortColumn", objUserProperty.SortColumn);
                cmdToExecute.Parameters.AddWithValue("@Status", objUserProperty.Status);
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objUserProperty.TotalRowsNum));


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
                //_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;
                objUserProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value); //Convert.ToInt32(adapter.SelectCommand.Parameters["@TotalRowsNum"].Value);
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    return toReturn;
                }

                return toReturn;
            }
            catch (Exception ex)
            {

                //objErrorTrace.Error_Msg = (SqlString)ex.Message;
                //objErrorTrace.Error_Proc = "sp_USER_SelectAll";
                //objErrorTrace.Insert();

                //HttpContext.Current.Response.Redirect("~/Error.aspx");


                return toReturn;

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


        public  DataTable GetAllUsers()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetAllUsers]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("User_SETUP");
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

            cmdToExecute.CommandText = "dbo.[sp_User_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objUserProperty.FirstName));
                cmdToExecute.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objUserProperty.LastName));
                cmdToExecute.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objUserProperty.UserName));
                cmdToExecute.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objUserProperty.Password));
                cmdToExecute.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objUserProperty.Email));
                cmdToExecute.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objUserProperty.Active));
                cmdToExecute.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.Int, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objUserProperty.Operated_By));
                cmdToExecute.Parameters.Add(new SqlParameter("@DateCreated", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DateTime.Now));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objUserProperty.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@RoleId", SqlDbType.Int, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objUserProperty.Roleid));
                cmdToExecute.Parameters.Add(new SqlParameter("@empid", SqlDbType.Int, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objUserProperty.EmpID));

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

        public DataTable CheckUserExistance()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_CheckUserName]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("User_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objUserProperty.UserName));
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
    }
}
