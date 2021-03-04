using BLL.Setups;
using HrProperty;
using HrProperty.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HrPortal.Controllers.Account
{
    public class AccountController : Controller
    {
        User_Property  objUserProperty;
        User_BLL objUserBLL;
        Login_Records_BLL objloginrecordbll;
        Login_Record_Property objloginrecordproperty;
        // GET: Account
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Dashboard");
            }
            else
            {

                return View();
            }
        }


        [HttpPost]
        public JsonResult Login(User_Property objUserPropertyNew)
        {
            objUserProperty = new User_Property();
            objUserProperty.UserName = objUserPropertyNew.UserName.Trim();
            objUserProperty.Password = objUserPropertyNew.Password.Trim();
            objUserProperty.PageSize = 9999999;
            objUserProperty.PageNum = 1;
            

            objUserBLL = new User_BLL(objUserProperty);

            DataTable userDT = objUserBLL.ViewAll();

            if (userDT.Rows.Count == 0)
            {
                //lblError.Visible = true;
                //lblError.Text = "Invalid Username Or Password";
                return Json(new { success = true, Login = false, statuscode = 404, msg = "Invaid Credentials" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    SessionManager.CurrentUser.ID = Convert.ToInt32(userDT.Rows[0]["ID"].ToString());
                    //SessionManager.CurrentUser.LocationID = Convert.ToInt32(userDT.Rows[0]["Location_Setup_ID"].ToString());
                    //SessionManager.CurrentUser.Code = Convert.ToInt32(userDT.Rows[0]["code"].ToString());
                    //SessionManager.CurrentUser.DistributorID = Convert.ToInt32(userDT.Rows[0]["DistributorID"].ToString());
                    //SessionManager.CurrentUser.CompanyID = Convert.ToInt32(userDT.Rows[0]["CompanyID"].ToString());
                    SessionManager.CurrentUser.UserName = userDT.Rows[0]["UserName"].ToString();
                    SessionManager.CurrentUser.FirstName = userDT.Rows[0]["FirstName"].ToString();
                    SessionManager.CurrentUser.LastName = userDT.Rows[0]["LastName"].ToString();
                    SessionManager.CurrentUser.Email = userDT.Rows[0]["Email"].ToString();
                    SessionManager.CurrentUser.Password = userDT.Rows[0]["Password"].ToString();
                    //SessionManager.CurrentUser.Active = Convert.ToInt32(userDT.Rows[0]["IsActive"].ToString());
                    SessionManager.CurrentUser.InsertBy = Convert.ToInt32(userDT.Rows[0]["CreatedBy"].ToString());
                    SessionManager.CurrentUser.InsertionDate = Convert.ToDateTime(userDT.Rows[0]["DateCreated"]);
                    SessionManager.CurrentUser.EmployeeID = Convert.ToInt32(userDT.Rows[0]["EmployeeID"]);
                    Session["RoleID"] = Convert.ToInt32(userDT.Rows[0]["RoleId"].ToString());
                    Session["Emp_ID"]= Convert.ToInt32(userDT.Rows[0]["EmployeeID"]);

                    //objUserRegionProperty = new User_Region_Property();
                    //objUserRegionProperty.UserId = Convert.ToInt32(SessionManager.CurrentUser.ID);
                    //objUserRegionBLL = new User_Region_BLL(objUserRegionProperty);

                    //DataTable dtRegionalUserLocations = objUserRegionBLL.GetRegionalUserLocationByUserIdBLL();
                    //if (dtRegionalUserLocations.Rows.Count > 0)
                    //{
                    //    SessionManager.CurrentUser.IsRegionalUser = true;
                    //    SessionManager.CurrentUser.RegionalLocationsDT = dtRegionalUserLocations;
                    //    locations = new List<string>();
                    //    for (int i = 0; i < dtRegionalUserLocations.Rows.Count; i++)
                    //    {
                    //        locations.Add(Convert.ToString(dtRegionalUserLocations.Rows[i]["Location_Code"] + " - " + dtRegionalUserLocations.Rows[i]["Location_Name"]));
                    //    }
                    //    SessionManager.CurrentUser.RegionalLocations = locations;
                    //}
                    //else
                    //{
                    //    SessionManager.CurrentUser.IsRegionalUser = false;
                    //    SessionManager.CurrentUser.RegionalLocations = null;
                    //}
                    //Response.Redirect("/myHomePage.aspx");
                    objloginrecordproperty = new Login_Record_Property();
                    objloginrecordproperty.Employee_ID = Convert.ToInt32(userDT.Rows[0]["EmployeeID"]);
                    objloginrecordproperty.Login_Time = DateTime.Now;
                    objloginrecordproperty.Location_Name = "";
                    objloginrecordproperty.latitude = objUserPropertyNew.Latitude;
                    objloginrecordproperty.longitude = objUserPropertyNew.Longitude;
                    objloginrecordbll = new Login_Records_BLL(objloginrecordproperty);
                    var flag = objloginrecordbll.Insert();


                    FormsAuthentication.SetAuthCookie(objUserPropertyNew.UserName, objUserPropertyNew.RemeberMe);
                    //return RedirectToAction("Profile");
                    return Json(new { success = true, Login = true, statuscode = 200, msg = "Login Successfull" }, JsonRequestBehavior.AllowGet);

                }
                catch (Exception ex)
                {
                    //Trace.Write("Testtt");
                    //Trace.Write(ex.Message);
                    //lblError.Visible = true;
                    //lblError.Text = "Invalid Username Or Password";
                    return Json(new { success = false, Login = false, statuscode = 500, msg = "err" + ex }, JsonRequestBehavior.AllowGet);

                }

            }
        }


        public ActionResult Logout()
        {
            objloginrecordproperty = new Login_Record_Property();
            objloginrecordbll = new Login_Records_BLL(objloginrecordproperty);
            objloginrecordproperty.Employee_ID = Convert.ToInt32(Session["Emp_ID"]);
            objloginrecordbll.UpdateLogoutTime();


            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}