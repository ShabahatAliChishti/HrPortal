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

namespace HrPortal.Controllers.Employee
{
    public class EmployeeTypeController : Controller
    {
        EmployeeType_BLL objemptypebll;
        EmployeeTypeProperty objemptypeproperty;
        // GET: EmployeeType
        [Authorize]
        public ActionResult ViewEmployeeType()
        {
            return View();
        }
        [Authorize]
        public ActionResult AddEmployeeType()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getEmployeeType()
        {
            objemptypebll = new EmployeeType_BLL();
            DataTable dt=objemptypebll.SelectAll();
            var serializedempType = JsonConvert.SerializeObject(dt);
            var deserializedemptype = JsonConvert.DeserializeObject(serializedempType);
            return Json(new {emptype= serializedempType }, JsonRequestBehavior.AllowGet);

        }

        [Authorize]
        [HttpPost]
        public JsonResult AddEmployeeType(EmployeeTypeProperty emptype)
        {
            if (ModelState.IsValid)
            {
                if (emptype.EmployeeTypeID <= 0 || emptype.EmployeeTypeID==null)
                {
                    emptype.InsertionDate = DateTime.Now;
                    emptype.Status = "Active";
                    emptype.IsActive = true;
                    emptype.InsertBy = SessionManager.CurrentUser.ID;
                    objemptypebll = new EmployeeType_BLL(emptype);
                    var flag = objemptypebll.Insert();
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
                    objemptypebll = new EmployeeType_BLL(emptype);
                    var flag = objemptypebll.Update();
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

        public JsonResult DeleteEmployeeType(int id)
        {
            objemptypeproperty = new EmployeeTypeProperty();
            objemptypeproperty.EmployeeTypeID = id;
            objemptypeproperty.TableName = "tblEmployeeType";
            objemptypeproperty.Status = "Deleted";
           // objemptypeproperty.U_id = SessionManager.CurrentUser.ID;
            objemptypebll= new EmployeeType_BLL(objemptypeproperty);
            var flag = objemptypebll.UpdateStatus();
            if (flag)
            {

                return Json(new { success = true, statuscode = 200, msg = "Successfull" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = false, statuscode = 500, msg = "Failed" }, JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult ShowEmployeeType(int id)
        {
            objemptypeproperty = new EmployeeTypeProperty();
            objemptypeproperty.EmployeeTypeID = id;
            objemptypeproperty.TableName = "tblEmployeeType";
            objemptypebll = new EmployeeType_BLL(objemptypeproperty);
            DataTable dt = objemptypebll.SelectOne();
            ViewBag.EmployeeType = dt;            
            return View("AddEmployeeType", objemptypeproperty);
        }
    }
}