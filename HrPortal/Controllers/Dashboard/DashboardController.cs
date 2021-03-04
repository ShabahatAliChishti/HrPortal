using BLL.Setups;
using HrProperty.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HrPortal.Controllers
{
    public class DashboardController : Controller
    {
        LinkMenu objmenu;
        MenuSetup objmenusetups;
        // GET: Dashboard
        [Authorize]
        public ActionResult Dashboard()
        {
            if (Session["RoleID"] != null)
            {

                return View();
            }
            else
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "Account");
            }
        }


        public ActionResult Dashboard2()
        {
            return View();
        }
        public ActionResult Dashboard3()
        {
            return View();
        }
        public ActionResult Dashboard4()
        {
            return View();
        }
        public ActionResult Dashboard5()
        {
            return View();
        }
        public ActionResult Dashboard6()
        {
            return View();
        }
        public ActionResult Dashboard7()
        {
            return View();
        }

        public JsonResult GetMenus()
        {
            if (Session["RoleID"].ToString() == "1")
            {
                objmenusetups = new MenuSetup();
               
                var SerialzeMenu =JsonConvert.SerializeObject(objmenusetups.GetMenus());
                return Json(new {data= SerialzeMenu }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                objmenusetups = new MenuSetup();

                var SerialzeMenu = JsonConvert.SerializeObject(objmenusetups.GetMenus());
                return Json(SerialzeMenu, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetChildMenu(int id)
        {
                objmenu = new LinkMenu();
                objmenu.Parent_MenuId = id;
                objmenusetups = new MenuSetup(objmenu);

                var SerialzeMenu = JsonConvert.SerializeObject(objmenusetups.GetChildMenus());
                return Json(new { data = SerialzeMenu }, JsonRequestBehavior.AllowGet);
           
        }

    }
}