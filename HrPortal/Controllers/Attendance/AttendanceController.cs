using BLL.Setups;
using ExcelDataReader;
using HrProperty.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using excel = Microsoft.Office.Interop.Excel;


namespace HrPortal.Views
{
    public class AttendanceController : Controller
    {

        Attendance_Property objattendanceproperty;
        Attendance_BLL objattendancebll;
        // GET: Attendance
        [Authorize]
        public ActionResult ImportAttendance()
        {
            return View();
        }


        [HttpPost]
        public JsonResult UploadAttendance(HttpPostedFileBase ExcelFileAttendence)
        {
            ViewBag.msg = "";
            try
            {

                if (SaveExcelFile(ExcelFileAttendence))
                {
                    objattendanceproperty = new Attendance_Property();
                    objattendanceproperty.tbl_Attendance = ToDataTable(ReadExcelFile(ExcelFileAttendence.FileName));
                    objattendancebll = new Attendance_BLL();
                    var flag = objattendancebll.Insert(objattendanceproperty.tbl_Attendance);
                    if (flag)
                    {
                        ViewBag.msg = "Success";
                    }
                    else
                    {
                        ViewBag.msg = "Contact Administrator";
                    }

                }

                return Json(new { success = true, msg = ViewBag.msg }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "Contact Administrator" }, JsonRequestBehavior.AllowGet);
            }
        }

        public bool SaveExcelFile(HttpPostedFileBase ExcelFileAttendence)
        {
            try
            {
                var file = ExcelFileAttendence;
                // var filename = Path.GetFileName(ExcelFileAttendence.FileName);
                var filename = ExcelFileAttendence.FileName;
                ExcelFileAttendence.SaveAs(Server.MapPath("/ExcelFiles/" + filename));
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private List<Attendance_Property> ReadExcelFile(string filename)
        {
            try
            {

                int rowstart, EmployeeID, AttendanceDate, timein, timeout, timein1, timeout1;
                rowstart = Convert.ToInt32(ConfigurationManager.AppSettings["RowStartReading"].ToString());
                EmployeeID = Convert.ToInt32(ConfigurationManager.AppSettings["EmployeeID"].ToString());
                AttendanceDate = Convert.ToInt32(ConfigurationManager.AppSettings["AttendanceDate"].ToString());
                timein = Convert.ToInt32(ConfigurationManager.AppSettings["TimeIn"].ToString());
                timeout = Convert.ToInt32(ConfigurationManager.AppSettings["TimeOut"].ToString());
                timein1 = Convert.ToInt32(ConfigurationManager.AppSettings["TimeIn1"].ToString());
                timeout1 = Convert.ToInt32(ConfigurationManager.AppSettings["TimeOut1"].ToString());

                List<Attendance_Property> Listattendance = new List<Attendance_Property>();
                Attendance_Property attendance;
                string filepath = Server.MapPath("/ExcelFiles/" + filename).ToString();



                excel.Application xlApp = new excel.Application();
                excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filepath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                excel._Worksheet xlWorksheet = (excel._Worksheet)xlWorkbook.Sheets[2];
                excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                for (int i = rowstart; i <= rowCount; i++)
                {
                    //for (int j = 1; j <= colCount; j++)
                    //{
                    //attendance = new Attendance_Property();
                    //new line
                    //if (j == 1)
                    //    Console.Write("\r\n");

                    //write the value to the console
                    //if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    ////Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");
                    //{
                    //    attendance.EmployeeId= xlRange.Cells[i, j].Value2.ToString();
                    //}


                    //}
                    attendance = new Attendance_Property();

                    //forEmployeeID
                    if (xlRange.Cells[i, EmployeeID] != null && xlRange.Cells[i, EmployeeID].Value2 != null)
                    {
                        attendance.EmployeeId = xlRange.Cells[i, EmployeeID].Value2.ToString();
                    }
                    //forattendancedate
                    if (xlRange.Cells[i, AttendanceDate] != null && xlRange.Cells[i, AttendanceDate].Value2 != null)
                    {
                        String date = xlRange.Cells[i, AttendanceDate].Value2.ToString();

                        string newdate = DateTime.ParseExact(date, "yy-MM-dd", CultureInfo.CurrentCulture).ToString("yyyy/MM/dd");
                        attendance.Attendance_Date = Convert.ToDateTime(newdate);// DateTime.ParseExact(xlRange.Cells[i, AttendanceDate].Value2.ToString(), "yyyy/MM/dd", null);
                        //attendance.Attendance_Date =Convert.ToDateTime(xlRange.Cells[i, AttendanceDate].Value2.ToString());
                    }
                    string punchin, punchin1, punchout, punchout1, d;
                    punchin = xlRange.Cells[i, timein].Value2.ToString();
                    punchin1 = xlRange.Cells[i, timein1].Value2.ToString();
                    punchout = xlRange.Cells[i, timeout].Value2.ToString();
                    punchout1 = xlRange.Cells[i, timeout1].Value2.ToString();
                    d = xlRange.Cells[i, AttendanceDate].Value2.ToString();


                    //punch in
                    if (punchin != null && punchin != "" && punchin != " ")
                    {
                        attendance.Time_In = punchin.ToString();
                    }
                    if (punchin1 != null && punchin1 != "" && punchin1 != " " && (attendance.Time_In == null || attendance.Time_In == " "))
                    {
                        attendance.Time_In = punchin1.ToString();
                    }
                    if ((attendance.Time_In == null || attendance.Time_In == " ") && punchout != "")
                    {
                        attendance.Time_In = punchout.ToString();
                    }

                    //PUNCHOUT

                    if (punchout1 != null && punchout1 != "" && punchout1 != " ")
                    {
                        attendance.Time_Out = punchout1.ToString();
                    }
                    if ((attendance.Time_Out == null || attendance.Time_Out == " ") && (punchout != " " || punchout != ""))
                    {
                        attendance.Time_Out = punchout.ToString();
                    }
                    if ((punchout1 == null || punchout1 == "" || punchout1 == " ") && (punchout == null || punchout == "" || punchout == " "))
                    {
                        attendance.Time_Out = "19:00";
                    }

                    //if (d == "19-10-11" && attendance.EmployeeId == "3")
                    //{

                    //    if (punchout1 != null && punchout1 != "" && punchout1 != " ")
                    //    {
                    //        attendance.Time_Out = punchout1.ToString();
                    //    }
                    //    if ((attendance.Time_Out == null || attendance.Time_Out == " ") && (punchout != " " || punchout != ""))
                    //    {
                    //        attendance.Time_Out = punchout.ToString();
                    //    }
                    //    if((punchout1 == null || punchout1 == "" && punchout1 == " ") && (punchout == null || punchout == "" && punchout == " "))
                    //    {
                    //        attendance.Time_Out = "19:00";
                    //    }

                    //}
                    //else
                    //{
                    //    if (punchout1 != null && punchout1 != "" && punchout1 != " ")
                    //    {
                    //        attendance.Time_Out = punchout1.ToString();
                    //    }
                    //    if ((attendance.Time_Out == null || attendance.Time_Out == " ") && (punchout != " " || punchout != ""))
                    //    {
                    //        attendance.Time_Out = punchout.ToString();
                    //    }
                    //    if ((punchout1 == null || punchout1 == "" && punchout1 == " ") && (punchout == null || punchout == "" && punchout == " "))
                    //    {
                    //        attendance.Time_Out = "19:00";
                    //    }

                    //}



                    //}

                    ////talha time out
                    //if (xlRange.Cells[i, timeout1] != null && xlRange[i, timeout1].Value2 != null)
                    //{
                    //    DateTime timeOut = Convert.ToDateTime(xlRange.Cells[i, timeout1].Value2.ToString());
                    //}
                    //else
                    //{
                    //    DateTime timeOut = Convert.ToDateTime(xlRange.Cells[i, timeout].Value2.ToString());
                    //}

                    decimal dec = Convert.ToDecimal(TimeSpan.Parse((Convert.ToDateTime(attendance.Time_Out) - Convert.ToDateTime(attendance.Time_In)).ToString()).TotalHours);
                    //var totalhours =TimeSpan.TryParse((Convert.ToDateTime(attendance.Time_Out) - Convert.ToDateTime(attendance.Time_In)).ToString(), CultureInfo.InvariantCulture);
                    //attendance.Total_Hours = Convert.ToDecimal(totalhours.)
                    attendance.Total_Hours = dec;
                    Listattendance.Add(attendance);

                }

                return Listattendance;


            }


            catch (Exception ex)
            {
                using (var tw = new StreamWriter(Server.MapPath("/ExcelFiles/" + "abc.txt"), true))
                {
                    tw.WriteLine(ex.Message);
                }
                return new List<Attendance_Property>();
            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }


        public FileResult DownloadAttendance(int year, int month)
        {
            int employeeid = Convert.ToInt32(Session["Emp_ID"].ToString());
            string from = year + "-" + month + "-" + 01;
            string to = year + "-" + month + "-" + 31;
            EmployeeProperty emp = new EmployeeProperty();
            emp.Id = employeeid;
            Employee_BLL empbll = new Employee_BLL(emp);
            int empattendanceid = empbll.GetEmployeeAttendanceId();

            objattendancebll = new Attendance_BLL();
            DataTable dt = objattendancebll.SelectEmployeeAttendance(from, to, empattendanceid);
            string fullName = Server.MapPath("~" + "/AttendanceFiles/Attendance Report" + from + to + employeeid);
            bool flag = WriteDataTableToExcel(dt, "Attendance Report" + employeeid, fullName);
            if (flag)
            {
                try
                {


                    byte[] fileBytes = System.IO.File.ReadAllBytes(fullName + ".xlsx");
                    string fileName = Path.GetFileName(fullName + ".xlsx");
                    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
                }
                catch (Exception ex)
                {
                    //StringBuilder sb = new StringBuilder();
                    //sb.Append("log something");

                    //File.AppendAllText(filePath + "log.txt", sb.ToString());
                    //sb.Clear();
                    byte[] fileBytes = new byte[1];
                    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "");
                }
            }
            else
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(fullName);
                string fileName = Path.GetFileName("");

                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "abc Else Case");
            }

        }

        public bool WriteDataTableToExcel(DataTable dataTable, string worksheetName, string saveAsLocation)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                //  get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;

                // loop through each row and add values to our sheet
                int rowcount = 1;

                foreach (DataRow datarow in dataTable.Rows)
                {
                    rowcount += 1;
                    for (int i = 1; i <= dataTable.Columns.Count; i++)
                    {
                        // on the first iteration we add the column headers
                        if (rowcount == 3)
                        {
                            excelSheet.Cells[2, i] = dataTable.Columns[i - 1].ColumnName;
                        }
                        // Filling the excel file 
                        excelSheet.Cells[rowcount, i] = datarow[i - 1].ToString();
                    }
                }

                //now save the workbook and exit Excel

                if (System.IO.File.Exists(saveAsLocation))
                {
                    System.IO.File.Delete(saveAsLocation);
                }

                excelworkBook.SaveAs(saveAsLocation);
                excelworkBook.Close();
                excel.Quit();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }
        }


        public JsonResult GetAttendanceRepotrt(int year, int month)
        {
            int employeeid = Convert.ToInt32(Session["Emp_ID"].ToString());
            string from = year + "-" + month + "-" + 01;
            string to = year + "-" + month + "-" + 31;
            EmployeeProperty emp = new EmployeeProperty();
            emp.Id = employeeid;
            Employee_BLL empbll = new Employee_BLL(emp);
            int empattendanceid = empbll.GetEmployeeAttendanceId();

            objattendancebll = new Attendance_BLL();
            DataTable dt = objattendancebll.SelectEmployeeAttendance(from, to, empattendanceid);
            var dtserialize = JsonConvert.SerializeObject(dt);
            return Json(new { data = dtserialize }, JsonRequestBehavior.AllowGet);
        }
    }
}