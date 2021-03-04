using BLL.Setups;
using HrProperty.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HrPortal.Controllers.Leave
{
    public class LeaveController : Controller
    {

        Leaves_BLL objLeaveSetups;
        Leaves objleaveproperty;
        public ActionResult ApplyforLeave()
        {
            GetEmployeeInfo();
            return View();
        }
        [HttpPost]
        public JsonResult ApplyLeave(Leaves leav)
        {
            try
            {
                int employeeId = Convert.ToInt32(Session["Emp_ID"]);
                leav.Date_Applied = DateTime.Now;
                leav.Is_Approved = false;
                leav.Is_Rejected = false;
                leav.Employee_Id = employeeId;
                objLeaveSetups = new Leaves_BLL(leav);
                var flag = objLeaveSetups.Insert();
                if (flag)
                {
                    return Json(new { Success = true, msg = "Applied successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Success = false, msg = "Failed" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }


        }
        public ActionResult ViewLeaves()
        {
            return View();

        }

        [HttpGet]
        public JsonResult ViewLeaveshistory()
        {
            try
            {
                Leaves objleaeve = new Leaves();
                int employeeId = Convert.ToInt32(Session["Emp_ID"]);

                objleaeve.Employee_Id = employeeId;
                objLeaveSetups = new Leaves_BLL(objleaeve);
                DataTable dt = objLeaveSetups.ViewLeaveHistory();
                var serializeddata = JsonConvert.SerializeObject(dt);
                return Json(new { Success = true, msg = "successfully", data = serializeddata }, JsonRequestBehavior.AllowGet);

                // return Json(new { Success = false, msg = "Failed" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { Success = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }


        }
        public ActionResult ViewEmployeeLeaves()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ViewappliedLeaves()
        {
            try
            {
               
                objLeaveSetups = new Leaves_BLL();
                DataTable dt = objLeaveSetups.GetAllEmployeeLeaves();
                var serializeddata = JsonConvert.SerializeObject(dt);
                return Json(new { Success = true, msg = "successfully", data = serializeddata }, JsonRequestBehavior.AllowGet);

                // return Json(new { Success = false, msg = "Failed" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { Success = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }


        }

        public JsonResult RejectLeave(int id)
        {
            objleaveproperty = new Leaves();
            objleaveproperty.Id = id;
            
            objLeaveSetups = new Leaves_BLL(objleaveproperty);
            var flag=objLeaveSetups.RejectLeave();
            if (flag)
            {
                return Json(new { success = true, msg = "Rejected" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, msg = "Failed" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult AccpetLeave(int id)
        {
            objleaveproperty = new Leaves();
            objleaveproperty.Id = id;

            objLeaveSetups = new Leaves_BLL(objleaveproperty);
            DataTable dt = objLeaveSetups.SelectOne();
            objleaveproperty.LeaveType = Convert.ToInt32(dt.Rows[0]["LeaveType"].ToString());
            objleaveproperty.TotalDays = Convert.ToInt32(dt.Rows[0]["TotalDays"].ToString());
            objleaveproperty.Employee_Id = Convert.ToInt32(dt.Rows[0]["Employee_Id"].ToString());
            if (objleaveproperty.LeaveType == 1)
            {//casual
                int currentcasualvalues= Convert.ToInt32(dt.Rows[0]["Casual_Leaves"].ToString());
                int newcasualvalues = currentcasualvalues - objleaveproperty.TotalDays;
                objleaveproperty.TotalDays = newcasualvalues;
            }
            else
            {//annual
                int currentannualvalues = Convert.ToInt32(dt.Rows[0]["Annual_Leaves"].ToString());
                int newannualvalues = currentannualvalues - objleaveproperty.TotalDays;
                objleaveproperty.TotalDays = newannualvalues;
            }
            objLeaveSetups = new Leaves_BLL(objleaveproperty);
            var flag = objLeaveSetups.AcceptLeave();

            return Json(new { success = true, msg = "successfully" }, JsonRequestBehavior.AllowGet);
        }

        public void GetEmployeeInfo()
        {
            int employeeId = Convert.ToInt32(Session["Emp_ID"]);
            EmployeeProperty objemployeeproperty = new EmployeeProperty();
            objemployeeproperty.Id = employeeId;
            Employee_BLL objEmployeeBll = new Employee_BLL(objemployeeproperty);
            DataTable dt = objEmployeeBll.SelectOne();
            List<EmployeeProperty> EmployeeProperty = new List<EmployeeProperty>();
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeProperty objEmployeeProperty = new EmployeeProperty();
                objEmployeeProperty.Casual_Leaves = Convert.ToInt32(dr["Casual_Leaves"].ToString());
                objEmployeeProperty.Annual_Leaves = Convert.ToInt32(dr["Annual_Leaves"].ToString());
                EmployeeProperty.Add(objEmployeeProperty);
            }
            ViewBag.EmployeeInfo = EmployeeProperty;

        }
    }
}