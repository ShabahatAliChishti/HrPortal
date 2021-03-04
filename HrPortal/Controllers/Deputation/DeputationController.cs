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

namespace HrPortal.Controllers.Deputation
{
    public class DeputationController : Controller
    {
        Deputation_BLL objDepuBLL;
        Deputation_Property objDepuProp;
        // GET: Deputation
        public ActionResult ViewDeputation()
        {
            return View();
        }

        public JsonResult GetDeputations()
        {
            objDepuBLL = new Deputation_BLL();
            DataTable dt = objDepuBLL.SelectAll();
            var JsonDeputations = JsonConvert.SerializeObject(dt);
            return Json(new { Deputation = JsonDeputations, msg = "OK" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddDeputation()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddDeputation(Deputation_Property objDep)
        {
            if (ModelState.IsValid)
            {
                if (objDep.Id <= 0)
                {
                    objDep.Date_Created = DateTime.Now;
                    objDep.Status = "Active";
                    objDep.is_Active = true;
                    objDep.Inserted_By = Convert.ToInt32(SessionManager.CurrentUser.ID);
                    objDepuBLL = new Deputation_BLL(objDep);
                    var flag = objDepuBLL.Insert();
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
                    objDep.Date_Created = DateTime.Now;
                    objDep.Status = "Active";
                    objDep.is_Active = true;
                    objDep.Inserted_By = Convert.ToInt32(SessionManager.CurrentUser.ID);
                    objDepuBLL = new Deputation_BLL(objDep);
                    var flag = objDepuBLL.Update();
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

        public ActionResult ShowDepartment(int id)
        {
            objDepuProp = new Deputation_Property();
            objDepuProp.Id = id;            
            objDepuBLL = new Deputation_BLL(objDepuProp);
            DataTable dt = objDepuBLL.SelectOne();
            ViewBag.Deputation = dt;
            return View("AddDeputation", objDepuProp);
        }

        public JsonResult DeleteDeputation(int id)
        {
            objDepuProp = new Deputation_Property();
            objDepuProp.Id = id;
            objDepuBLL = new Deputation_BLL(objDepuProp);
            var flag = objDepuBLL.DeleteDeputation();
            if (flag)
            {

                return Json(new { success = true, statuscode = 200, msg = "Successfull" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = false, statuscode = 500, msg = "Failed" }, JsonRequestBehavior.AllowGet);

            }
        }

    }

}
