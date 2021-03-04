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

namespace HrPortal.Controllers.Client
{
    public class ClientController : Controller
    {
        Client_BLL objClientBLL;
        Client_Property objClientProp;
        // GET: Client
        public ActionResult ViewClient()
        {
            return View();
        }

        [Authorize]
        public ActionResult AddClient()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getClients()
        {
            objClientBLL = new Client_BLL();
            DataTable dt = objClientBLL.ViewAll();
            var clientJson = JsonConvert.SerializeObject(dt);
            var deserialize = JsonConvert.DeserializeObject(clientJson);
            return Json(new { client = clientJson}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddClient(Client_Property objClientProp)
        {
            if(ModelState.IsValid)
            {
                if(objClientProp.Client_id <= 0)
                {
                    objClientProp.Status = "Active";
                    objClientProp.Is_active = true;
                    objClientProp.User_id = SessionManager.CurrentUser.ID;
                    objClientBLL = new Client_BLL(objClientProp);
                    var flag = objClientBLL.Insert();
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
                    objClientProp.Status = "Active";
                    objClientProp.Is_active = true;
                    objClientProp.User_id = SessionManager.CurrentUser.ID;
                    objClientBLL = new Client_BLL(objClientProp);
                    var flag = objClientBLL.Update();
                    if (flag)
                    {
                        return Json(new { success = true, statuscode = 200, msg = "Successfully inserted" }, JsonRequestBehavior.AllowGet);
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

        public JsonResult DeleteClient(int id)
        {
            objClientProp = new Client_Property();
            objClientProp.Client_id = id;
            objClientProp.TableName = "tblClient";
            objClientProp.Status = "Deleted";
            // objClientProp.U_id = SessionManager.CurrentUser.ID;
            objClientBLL = new Client_BLL(objClientProp);
            var flag = objClientBLL.UpdateStatus();
            if (flag)
            {

                return Json(new { success = true, statuscode = 200, msg = "Successfull" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = false, statuscode = 500, msg = "Failed" }, JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult ShowClient(int id)
        {
            objClientProp = new Client_Property();
            objClientProp.Client_id = id;
            objClientProp.TableName = "tblClient";
            objClientBLL = new Client_BLL(objClientProp);
            DataTable dt = objClientBLL.SelectOne();
            ViewBag.Client = dt;
            return View("AddClient", objClientProp);
        }

    }
}