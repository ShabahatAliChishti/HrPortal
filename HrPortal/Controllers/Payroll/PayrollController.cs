using BLL.Setups;
using HrProperty.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HrPortal.Controllers.Payroll
{
    public class PayrollController : Controller
    {
        Payroll_BLL objpayrollbll;
        Holidays_BLL objholidaybll;
        // GET: Payroll
        public ActionResult Calculate()
        {
            return View();
        }

        public JsonResult GetEmployeeForPayroll()
        {
            objpayrollbll = new Payroll_BLL();
            DataTable dtemplist = objpayrollbll.GetEmployeeForPayroll();
            var emplist = JsonConvert.SerializeObject(dtemplist);
            var deserilize = JsonConvert.DeserializeObject(emplist);
            //objDesignationBLL.Dispose();
            return Json(new { Designation = emplist }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CalculateResult(int Id)
        {
            Payroll_Property objpayroll = new Payroll_Property();
            objpayroll.attendance_id = Id;
            return View(objpayroll);
        }



        [HttpPost]
        public JsonResult CalculateResult(Payroll_Property payroll)
        {
            try
            {
                General_Holiday_Property objholiday = new General_Holiday_Property();
                objholiday.holiday_month = payroll.month;
                objholiday.holiday_year = payroll.year;
                Holidays_BLL objholidaybll = new Holidays_BLL(objholiday);
                payroll.GeneralHolidays = objholidaybll.SelectOne();
                var startDate = new DateTime(payroll.year, payroll.month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);
                payroll.fromDate = startDate;
                payroll.ToDate = endDate;

                

                objpayrollbll = new Payroll_BLL(payroll);
                DateTime Firstdate = payroll.fromDate;
                DateTime EndDate = payroll.ToDate;
                int TotalDays = Convert.ToInt32((EndDate - Firstdate).TotalDays);
                int businessdays = countWeekDays(Firstdate, EndDate)-(payroll.GeneralHolidays);
               
                int regularHolidays = (TotalDays - businessdays) + payroll.GeneralHolidays;

                payroll.totalDays = TotalDays;
                payroll.businessDays = businessdays;
                payroll.regularHolidays = regularHolidays;
                
                     



                var payrolllst =JsonConvert.SerializeObject(objpayrollbll.GetDetailsForPayroll());
                int daysWorked = payroll.daysWorked;
                return Json(new { success = true, statuscode = 500, data= payrolllst }, JsonRequestBehavior.AllowGet);

                

            }
            catch (Exception ex)
            {
                return Json(new { success = false, statuscode = 500, msg = "Please Enter According To Instructions" }, JsonRequestBehavior.AllowGet);
            }
        }

        public static int countWeekDays(DateTime d0, DateTime d1)
        {
            int ndays = 1 + Convert.ToInt32((d1 - d0).TotalDays);
            int nsaturdays = (ndays + Convert.ToInt32(d0.DayOfWeek)) / 7;
            return ndays - 2 * nsaturdays
                   - (d0.DayOfWeek == DayOfWeek.Sunday ? 1 : 0)
                   + (d1.DayOfWeek == DayOfWeek.Saturday ? 1 : 0);
        }


        public ActionResult AddHolidays()
        {
            return View(); 
        }
        [HttpPost]
        public JsonResult AddHolidays(General_Holiday_Property General_Holiday)
        {
            General_Holiday.is_active = true;
            objholidaybll = new Holidays_BLL(General_Holiday);
            var flag = objholidaybll.Insert();
            if (flag)
            {
                return Json(new { msg = "success", success = true }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { msg = "success", success = false }, JsonRequestBehavior.AllowGet);


            }
        }

        [HttpPost]
        public JsonResult GetCheckedResult(int[] attendanceidarray, int year,int month)
        {
            try
            {
                General_Holiday_Property objholiday = new General_Holiday_Property();
                Payroll_Property payroll = new Payroll_Property();
                objholiday.holiday_month = month;
                objholiday.holiday_year = year;
                Holidays_BLL objholidaybll = new Holidays_BLL(objholiday);
                payroll.GeneralHolidays = objholidaybll.SelectOne();
                var startDate = new DateTime(year, month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);
                payroll.fromDate = startDate;
                payroll.ToDate = endDate;
                payroll.attendanceidstring = string.Join(",", attendanceidarray);


                objpayrollbll = new Payroll_BLL(payroll);
                DateTime Firstdate = payroll.fromDate;
                DateTime EndDate = payroll.ToDate;
                int TotalDays = Convert.ToInt32((EndDate - Firstdate).TotalDays);
                int businessdays = countWeekDays(Firstdate, EndDate) - (payroll.GeneralHolidays);

                int regularHolidays = (TotalDays - businessdays) + payroll.GeneralHolidays;

                payroll.totalDays = TotalDays;
                payroll.businessDays = businessdays;
                payroll.regularHolidays = regularHolidays;





                var payrolllst = JsonConvert.SerializeObject(objpayrollbll.GetDetailsForPayroll());
                int daysWorked = payroll.daysWorked;
                return Json(new { success = true, statuscode = 500, data = payrolllst }, JsonRequestBehavior.AllowGet);
                //return View();


            }
            catch (Exception ex)
            {
                return Json(new { success = false, statuscode = 500, msg = "Please Enter According To Instructions" }, JsonRequestBehavior.AllowGet);
            }
        }



 
        public ActionResult GetPayrollMultiple(int[] attendanceidarray, int year, int month)
        {
            try
             {
                General_Holiday_Property objholiday = new General_Holiday_Property();
                Payroll_Property payroll = new Payroll_Property();
                objholiday.holiday_month = month;
                objholiday.holiday_year = year;
                Holidays_BLL objholidaybll = new Holidays_BLL(objholiday);
                payroll.GeneralHolidays = objholidaybll.SelectOne();
                var startDate = new DateTime(year, month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);
                payroll.fromDate = startDate;
                payroll.ToDate = endDate;
                payroll.attendanceidstring = string.Join(",", attendanceidarray);


                objpayrollbll = new Payroll_BLL(payroll);
                DateTime Firstdate = payroll.fromDate;
                DateTime EndDate = payroll.ToDate;
                int TotalDays = Convert.ToInt32((EndDate - Firstdate).TotalDays);

                //Since salary is calcualted on 30 days we are making days 30 if any month have less then 30 days
                if (TotalDays < 30)
                {
                    TotalDays = 30;
                }

                int businessdays = countWeekDays(Firstdate, EndDate) - (payroll.GeneralHolidays);

                int regularHolidays = (TotalDays - businessdays) + payroll.GeneralHolidays;

                payroll.totalDays = TotalDays;
                payroll.businessDays = businessdays;
                payroll.regularHolidays = regularHolidays;




                var payrolllst = JsonConvert.SerializeObject(objpayrollbll.GetDetailsForPayrollMultiple());
                int daysWorked = payroll.daysWorked;
                //ViewBag.payrollmultiple=
                //return Json(new { success = true, statuscode = 500, data = payrolllst }, JsonRequestBehavior.AllowGet);
                ViewBag.FooObj = payrolllst;
                return View();


            }
            catch (Exception ex)
            {
                return View();
                //return Json(new { success = false, statuscode = 500, msg = "Please Enter According To Instructions" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}