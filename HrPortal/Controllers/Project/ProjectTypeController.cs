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

namespace HrPortal.Controllers.Project
{
    public class ProjectTypeController : Controller
    {
        ProjectType_BLL objProjTypeBLL;
        ProjectType_Property objProjTypeProp;

        [Authorize]
        public ActionResult ViewAllProjectType()
        {
            return View();
        }

        [Authorize]
        public ActionResult AddProjectType()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddProjectType(ProjectType_Property projecttype)
        {
            if (ModelState.IsValid)
            {

                if (projecttype.Project_type_id <= 0 || projecttype.Project_type_id == null)
                {
                    projecttype.InsertionDate = DateTime.Now;
                    projecttype.Status = "Active";
                    projecttype.Is_active = true;
                    projecttype.InsertBy = SessionManager.CurrentUser.ID;
                    objProjTypeBLL = new ProjectType_BLL(projecttype);
                    var flag = objProjTypeBLL.Insert();
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
                    objProjTypeBLL = new ProjectType_BLL(projecttype);
                    var flag = objProjTypeBLL.Insert();
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


        public JsonResult getProjectType()
        {
            objProjTypeBLL = new ProjectType_BLL();
            DataTable Designation = objProjTypeBLL.SelectAll();
            var projecttype = JsonConvert.SerializeObject(Designation);
            var deserilize = JsonConvert.DeserializeObject(projecttype);
            //objDesignationBLL.Dispose();
            return Json(new { ptype = projecttype }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowProjectType(int id)
        {
            objProjTypeProp = new ProjectType_Property();
            objProjTypeProp.Project_type_id = id;
            objProjTypeProp.TableName = "tblProjectType";
            objProjTypeBLL = new ProjectType_BLL(objProjTypeProp);
            DataTable dt = objProjTypeBLL.SelectOne();
            ViewBag.Client = dt;
            return View(objProjTypeBLL);
        }

    }
}