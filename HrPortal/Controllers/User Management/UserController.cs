using BLL.Setups;
using HrProperty;
using HrProperty.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HrPortal.Controllers.Account
{
    public class UserController : Controller
    {
        Role_BLL objRoleBLL;
        Role_Property objRoleProp;
        User_Property objUserProp;
        User_BLL objUserBll;
        // GET: User
        public ActionResult AddUser()
        {
            GetRoles();
            GetEmployee();
            return View();
        }

        public void GetRoles()
        {
            Role_BLL objRoleBLL = new Role_BLL();
            DataTable dt = objRoleBLL.SelectAll();
            List<Role_Property> rolePropListItems = new List<Role_Property>();
            foreach (DataRow dr in dt.Rows)
            {
                Role_Property objRoleProp = new Role_Property();
                objRoleProp.RoleName = dr["RoleName"].ToString();
                objRoleProp.Role_id = Convert.ToInt32(dr["RoleId"].ToString());
                rolePropListItems.Add(objRoleProp);
            }
            ViewBag.RolelistItems = rolePropListItems;

        }

        


        [HttpPost]
        public JsonResult AddUser(User_Property objUserProp)
         {
           
            if (ModelState.IsValid)
            {
                if (objUserProp.ID <= 0 || objUserProp.ID == null)
                {
                    

                    objUserProp.Status = "Active";
                    objUserProp.Active = 1;
                    objUserProp.Operated_By = SessionManager.CurrentUser.ID;
                    objUserBll = new User_BLL(objUserProp);
                    DataTable d = objUserBll.CheckUserExistance();
                    if(d.Rows.Count>0)
                    {
                        return Json(new { success = false, statuscode = 501, msg = "Failed" }, JsonRequestBehavior.AllowGet);
                        
                    }
                    var flag = objUserBll.Insert();
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
                    //objClientBLL = new Client_BLL(objClientProp);
                    //var flag = objClientBLL.Update();
                    //if (flag)
                    //{
                    //    return Json(new { success = true, statuscode = 200, msg = "Successfully inserted" }, JsonRequestBehavior.AllowGet);
                    //}
                    //else
                    //{
                    //    return Json(new { success = false, statuscode = 500, msg = "Failed" }, JsonRequestBehavior.AllowGet);
                    //}
                    return Json(new { success = false, statuscode = 500, msg = "Failed" }, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return Json(new { success = false, statuscode = 500, msg = "Please Enter According To Instructions" }, JsonRequestBehavior.AllowGet);
            }
        }


        [Authorize]
        public ActionResult ViewUser()
        {
            return View();
        }
        [HttpGet]

        public JsonResult GetUsers()
        {
            objUserBll = new User_BLL();
            DataTable User = objUserBll.GetAllUsers();
            var UserJson = JsonConvert.SerializeObject(User);
            var deserilize = JsonConvert.DeserializeObject(UserJson);
            return Json(new { User = UserJson }, JsonRequestBehavior.AllowGet);
        }
        public void GetEmployee()
        {
            Employee_BLL objemployeeBLL = new Employee_BLL();
            DataTable dt = objemployeeBLL.SelectAll();
            List<EmployeeProperty> objEmployeePropertylistItems = new List<EmployeeProperty>();
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeProperty objEmployeeProperty = new EmployeeProperty();
                objEmployeeProperty.EmpName = dr["EmployeeName"].ToString();
                objEmployeeProperty.Id = Convert.ToInt32(dr["ID"].ToString());
                objEmployeePropertylistItems.Add(objEmployeeProperty);
            }
            ViewBag.EmployeelistItems = objEmployeePropertylistItems;
        }

    }
}