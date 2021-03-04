using BLL.Setups;
using HrProperty;
using HrProperty.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HrPortal.Controllers.Department
{
    public class DepartmentController : Controller
    {
        Department_BLL objDepartmentSetups;
        Department_Property objDeptProp;
        // GET: Department
        [Authorize]
        public ActionResult AddDepartment()
        {
            return View();
        }

        public ActionResult ViewDepartment()
        {
            return View();
        }

        //get All Departments
        [HttpGet]
        public JsonResult getDepartments()
        {
            objDepartmentSetups = new Department_BLL();
            DataTable Department = objDepartmentSetups.ViewAll();
            var DepartmentsJson = JsonConvert.SerializeObject(Department);
            var deserilize = JsonConvert.DeserializeObject(DepartmentsJson);
            return Json(new { Department = DepartmentsJson }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
       
        public JsonResult AddDepartment(Department_Property department)
        {
            //customer.CustomerCode = ViewBag.CustomerCode;


            if (ModelState.IsValid)
            {
                if (department.Department_Id <= 0)
                {
                    department.CreatedDate = DateTime.Now;
                    department.Status = "Active";
                    department.ISActive = true;
                    department.UserId = SessionManager.CurrentUser.ID;
                    objDepartmentSetups = new Department_BLL(department);
                    var flag = objDepartmentSetups.Insert();
                    if (flag)
                    {
                        return Json(new { success = true, statuscode = 200, msg = "Successfully inserted" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, statuscode = 500, msg = "Failed" }, JsonRequestBehavior.AllowGet);
                    }
                }

                else
                {
                    department.CreatedDate = DateTime.Now;
                    department.Status = "Active";
                    department.ISActive = true;
                    department.UserId = SessionManager.CurrentUser.ID;
                    objDepartmentSetups = new Department_BLL(department);
                    var flag = objDepartmentSetups.Update();
                    if (flag)
                    {
                        return Json(new { success = true, statuscode = 200, msg = "Successfully Updated" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, statuscode = 500, msg = "Failed" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }

            else
            {
                return Json(new { success = false, statuscode = 500, msg = "Please Enter According To Instructions" }, JsonRequestBehavior.AllowGet);
            }


        }


        public JsonResult DeleteDepartment(int id)
        {
            objDeptProp = new Department_Property();
            objDeptProp.Department_Id = id;
            objDeptProp.TableName = "tblDepartment";
            objDeptProp.Status = "Deleted";
            // objDeptProp.U_id = SessionManager.CurrentUser.ID;
            objDepartmentSetups = new Department_BLL(objDeptProp);
            var flag = objDepartmentSetups.UpdateStatus();
            if (flag)
            {

                return Json(new { success = true, statuscode = 200, msg = "Successfull" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = false, statuscode = 500, msg = "Failed" }, JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult ShowDepartment(int id)
        {
            objDeptProp = new Department_Property();
            objDeptProp.Department_Id = id;
            objDeptProp.TableName = "tblDepartment";
            objDepartmentSetups = new Department_BLL(objDeptProp);
            DataTable dt = objDepartmentSetups.SelectOne();
            ViewBag.Department = dt;
            return View("AddDepartment", objDeptProp);
        }


    }
}