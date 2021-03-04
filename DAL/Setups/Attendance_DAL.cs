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
    public class Attendance_DAL:DBInteraction
    {
        Attendance_Property objAttendanceProperty;

        public Attendance_DAL()
        {

        }

        public Attendance_DAL(Attendance_Property attendanceproperty)
        {
            objAttendanceProperty = attendanceproperty;
        }

        public bool Insert(DataTable dt)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            //cmdToExecute.CommandText = "dbo.[sp_Attendance_Insert]";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;

            //// Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                //cmdToExecute.Parameters.Add(new SqlParameter("@Emp_Id", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objAttendanceProperty.EmployeeId));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Attendance_Date", SqlDbType.Date, 40, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objAttendanceProperty.Attendance_Date));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Time_In", SqlDbType.Time, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objAttendanceProperty.Time_In));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Time_Out", SqlDbType.Time, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objAttendanceProperty.Time_Out));
                //cmdToExecute.Parameters.Add(new SqlParameter("@total_hours", SqlDbType.Float, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objAttendanceProperty.Total_Hours));

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

                this.StartTransaction();

                SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                sbc.ColumnMappings.Clear();

                sbc.DestinationTableName = "tbl_Attendance";
                sbc.ColumnMappings.Clear();
                sbc.ColumnMappings.Add("EmployeeId", "Employee_id");
                sbc.ColumnMappings.Add("Attendance_Date", "Attendance_Date");
                sbc.ColumnMappings.Add("Time_In", "Time_In");
                sbc.ColumnMappings.Add("Time_Out", "Time_Out");
                sbc.ColumnMappings.Add("Total_Hours", "Total_hours");
                //sbc.DestinationTableName = dt.TableName;
                sbc.WriteToServer(dt);

                // Execute query.
                //_rowsAffected = cmdToExecute.ExecuteNonQuery();

                //_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    //throw new Exception("Stored Procedure 'pr_PRODUCT_SETUP_Insert' reported the ErrorCode: " + _errorCode);
                //    return false;
                //}
                this.Commit();

                //ObjProductSetupProperty.ID = (SqlInt32)cmdToExecute.Parameters["@iID"].Value;
                //ObjProductSetupProperty.ErrorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                return true;
            }
            catch (Exception ex)
            {
                this.RollBack();
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("tbl_attendance::Insert::Error occured.", ex);
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

        public  DataTable SelectEmployeeAttendance(string from,string to,int attndnceid)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Get_Employee_Atttendance]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Employee_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@startdate", SqlDbType.Date, 400, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, from));
                cmdToExecute.Parameters.Add(new SqlParameter("@enddate", SqlDbType.Date, 400, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, to));
                cmdToExecute.Parameters.Add(new SqlParameter("@employeeattndnceid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,attndnceid));

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

    }
}
