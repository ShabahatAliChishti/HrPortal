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

namespace HrPortal.Controllers.Designation
{
    public class DesignationController : Controller
    {
        Designation_Property objDesignationProperty;
        Designation_BLL objDesignationBLL;
        // GET: Designation
        [Authorize]
        public ActionResult DesignationView()
        {
            return View();
        }
        public JsonResult GetDesignation()
        {
            objDesignationBLL = new Designation_BLL();
            DataTable Designation = objDesignationBLL.SelectAll();
            var DesignationJson = JsonConvert.SerializeObject(Designation);
            var deserilize = JsonConvert.DeserializeObject(DesignationJson);
            //objDesignationBLL.Dispose();
            return Json(new { Designation = DesignationJson }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddDesignation()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddDesignation(Designation_Property designationproperty)
        {
            //customer.CustomerCode = ViewBag.CustomerCode;


            if (ModelState.IsValid)
            {
                if (designationproperty.Designation_Id <= 0|| designationproperty.Designation_Id==null)
                {
                    designationproperty.CreatedDate = DateTime.Now;
                    designationproperty.Status = "Active";
                    designationproperty.ISActive = true;
                    designationproperty.UserId = SessionManager.CurrentUser.ID;
                    objDesignationBLL = new Designation_BLL(designationproperty);
                    var flag = objDesignationBLL.Insert();
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
                    objDesignationBLL = new Designation_BLL(designationproperty);
                    var flag = objDesignationBLL.Update();
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

        public JsonResult DeleteDesignation(int id)
        {
            objDesignationProperty = new Designation_Property();
            objDesignationProperty.Designation_Id = id;
            //objDesignationProperty.TableName = "tblEmployeeType";
            objDesignationProperty.Status = "Deleted";
            // objDesignationProperty.U_id = SessionManager.CurrentUser.ID;
            objDesignationBLL = new Designation_BLL(objDesignationProperty);
            var flag = objDesignationBLL.UpdateStatus();
            if (flag)
            {

                return Json(new { success = true, statuscode = 200, msg = "Successfull" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = false, statuscode = 500, msg = "Failed" }, JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult ShowDesignation(int id)
        {
            objDesignationProperty = new Designation_Property();
            objDesignationProperty.Designation_Id = id;
            //objDesignationProperty.TableName = "tblEmployeeType";
            objDesignationBLL = new Designation_BLL(objDesignationProperty);
            DataTable dt = objDesignationBLL.SelectOne();
            ViewBag.EmployeeType = dt;
            return View("AddDesignation", objDesignationProperty);
        }
    }
}