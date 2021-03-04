using BLL.Setups;
using BLL.Setups;
using HrPortal.Models;
using HrProperty;
using HrProperty.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace HrPortal.Controllers
{
    public class EmployeeController : Controller
    {
        Employee_BLL objEmployeeBll;
        EmployeeProperty objemployeeproperty;
        Login_Records_BLL objLoginRecordsBLL;
        Login_Record_Property objLoginRecordsProperty;
        private static Random random = new Random();

        // GET: Employee
        [Authorize]
        public ActionResult AddEmployee()
        {
            GetDesignations();
            GetDepartments();
            GetEmptype();

            
            string employeeid = RandomString(8);
            if (CheckEmployeeID(employeeid))
            {
                AddEmployee();
            }
            else
            {
                objemployeeproperty = new EmployeeProperty()
                {
                    Attndnc_id = 0,
                    Benefit1 = 0,
                    Benefit2 = 0,
                    Allownce1 = 0,
                    Allownce2 = 0,
                    Allownce3 = 0,
                    Total_Package = 0,
                    TotalSalary = 0
                };
                objemployeeproperty.Employee_ID = employeeid;
            }
            
            return View(objemployeeproperty);
        }

        public bool CheckEmployeeID(string empid)
        {
            objemployeeproperty = new EmployeeProperty();
            objemployeeproperty.Employee_ID = empid;
            objEmployeeBll = new Employee_BLL(objemployeeproperty);
            return objEmployeeBll.CheckEmployeeID();

        }


        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public void GetDesignations()
        {
            Designation_BLL designation = new Designation_BLL();
            DataTable dt = designation.SelectAll();
            List<Designation_Property> Designation_PropertylistItems = new List<Designation_Property>();
            foreach (DataRow dr in dt.Rows)
            {
                Designation_Property objdesignation = new Designation_Property();
                objdesignation.Designation = dr["Designation"].ToString();
                objdesignation.Designation_Id = Convert.ToInt32(dr["DesignationID"].ToString());
                Designation_PropertylistItems.Add(objdesignation);
            }
            ViewBag.DesignationlistItems = Designation_PropertylistItems;
        }
        public void GetDepartments()
        {
            Department_BLL Department_BLL = new Department_BLL();
            DataTable dt = Department_BLL.ViewAll();
            List<Department_Property> Department_PropertylistItems = new List<Department_Property>();
            foreach (DataRow dr in dt.Rows)
            {
                Department_Property objdepartment = new Department_Property();
                objdepartment.DepartmentName = dr["Department_Name"].ToString();
                objdepartment.Department_Id = Convert.ToInt32(dr["DepartmentID"].ToString());
                Department_PropertylistItems.Add(objdepartment);
            }
            ViewBag.DepartmentlistItems = Department_PropertylistItems;
        }
        public void GetEmptype()
        {
            EmployeeType_BLL EmployeeType_BLL = new EmployeeType_BLL();
            DataTable dt = EmployeeType_BLL.SelectAll();
            List<EmployeeTypeProperty> EmptypelistItems = new List<EmployeeTypeProperty>();
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeTypeProperty objEmployeeTypeProperty = new EmployeeTypeProperty();
                objEmployeeTypeProperty.EmployeeType = dr["EmployeeType"].ToString();
                objEmployeeTypeProperty.EmployeeTypeID = Convert.ToInt32(dr["EmployeeTypeID"].ToString());
                EmptypelistItems.Add(objEmployeeTypeProperty);
            }
            ViewBag.EmpTypelistItems = EmptypelistItems;
        }


        public void GetDeputaion()
        {
            Deputation_BLL Deputaion_BLL = new Deputation_BLL();
            DataTable dt = Deputaion_BLL.SelectAll();
            List<Deputation_Property> DeputationList = new List<Deputation_Property>();
            foreach (DataRow dr in dt.Rows)
            {
                Deputation_Property objEmployeeTypeProperty = new Deputation_Property();
                objEmployeeTypeProperty.Deputation_Location = dr["Deputation_Location"].ToString();
                objEmployeeTypeProperty.Id = Convert.ToInt32(dr["Id"].ToString());
                DeputationList.Add(objEmployeeTypeProperty);
            }
            ViewBag.DeputationLocation = DeputationList;
        }

        [Authorize]
        public ActionResult ViewEmployee()
        {
            return View();
        }
        [HttpGet]

        public JsonResult GetEmployees()
        {
            objEmployeeBll = new Employee_BLL();
            DataTable Employee = objEmployeeBll.SelectAll();
            var EmployeeJson = JsonConvert.SerializeObject(Employee);
            var deserilize = JsonConvert.DeserializeObject(EmployeeJson);
            return Json(new { Employee = EmployeeJson,Employeedeserialize= deserilize }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        public JsonResult AddEmployee(EmployeeProperty empployeepropertys)
        {
            //if (ModelState.IsValid)
            //{
                //add new employee
                if(empployeepropertys.Id==null ||empployeepropertys.Id<=0)
                {
                    if (empployeepropertys.ImageFile != null)
                    {
                        var file = empployeepropertys.ImageFile;
                        UploadProfilePicture(empployeepropertys);
                    }
                    empployeepropertys.CreatedDate = DateTime.Now;
                    empployeepropertys.IsActive = true;
                    empployeepropertys.Status = "Active";
                    empployeepropertys.U_id = SessionManager.CurrentUser.ID;
                    objEmployeeBll = new Employee_BLL(empployeepropertys);
                    var flag=objEmployeeBll.Insert();
                    if (flag)
                    {
                        return Json(new { success = true, statuscode = 200, msg = "Successfully inserted" }, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        return Json(new { success = false, statuscode = 500, msg = "Failed" }, JsonRequestBehavior.AllowGet);

                    }
                }
                //when id <0 update case
                else
                {
                    if (empployeepropertys.ImageFile != null)
                    {
                        UploadProfilePicture(empployeepropertys);
                    }
                    empployeepropertys.CreatedDate = DateTime.Now;
                    empployeepropertys.IsActive = true;
                    empployeepropertys.Status = "Active";
                    objEmployeeBll = new Employee_BLL(empployeepropertys);
                    empployeepropertys.U_id = SessionManager.CurrentUser.ID;
                    if (empployeepropertys.Depandants != null)
                    {
                        try
                        {
                         var Depandant = JsonConvert.SerializeObject(empployeepropertys.Depandants);
                           // List<RootObject> l = new List<RootObject>();
                            // List<Depandants_Property> myDeserializedObjList = (List<Depandants_Property>)JsonConvert.DeserializeObject(empployeepropertys.Depandants);
                            List<RootObject> l = JsonConvert.DeserializeObject<List<RootObject>>(empployeepropertys.Depandants);

                            var targetList = l.Select(x => new Depandants_Property()
                                                  { ID = x.ID,
                                                    Depand_Name=x.Depand_Name,
                                                      RelationShip=x.RelationShip,
                                                      Dob=Convert.ToDateTime(x.Dob),
                                                      Medical=Convert.ToBoolean(x.Medical),
                                                      Nic=x.Nic,
                                                      Employee_Primary_Id=x.Employee_Primary_Id,
                                                      Employee_Key=x.Employee_Key
                                                  })
                                                  .ToList();
                            empployeepropertys.DepandantsList = UtilityClass.ToDataTable(targetList);
                        }
                        catch(Exception ex)
                        {

                        }
                        
                    }
                    var flag = objEmployeeBll.Update();
                    if (flag)
                    {
                        return Json(new { success = true, statuscode = 200, msg = "Successfully inserted" }, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        return Json(new { success = false, statuscode = 500, msg = "Failed" }, JsonRequestBehavior.AllowGet);

                    }
                }


            //}
            //when model state is not valid
            //else
            //{
            //    return Json(new { success = false, statuscode = 500, msg = "Please Enter According To Instructions" }, JsonRequestBehavior.AllowGet);
         //   }

        }



        public void UploadProfilePicture(EmployeeProperty empprofilepic)
        {
            var file = empprofilepic.ImageFile;
            string filename = "";
            string filepath = "";
            try
            {

                
                filename = System.IO.Path.GetFileName(System.IO.Path.GetRandomFileName() + file.FileName);
                file.SaveAs(Server.MapPath("/ProfileImages/" + filename));

                filepath = "/ProfileImages/" + filename;
                //file.SaveAs(Server.MapPath(filepath));
                string fullPath = Request.MapPath(empprofilepic.ImgPath);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                
                empprofilepic.ImgPath = filepath;


                
            }
            catch (Exception ex)
            {
               
            }
        }


        public JsonResult DeleteEmployee(int id)
        {
            objemployeeproperty = new EmployeeProperty();
            objemployeeproperty.Id = id;
            objemployeeproperty.TableName = "tbl_Employee";
            objemployeeproperty.Status = "Deleted";
            objemployeeproperty.U_id = SessionManager.CurrentUser.ID;
            objEmployeeBll = new Employee_BLL(objemployeeproperty);
            var flag = objEmployeeBll.UpdateStatus();
            if (flag)
            {

                return Json(new { success = true, statuscode = 200, msg = "Successfull" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = false, statuscode = 500, msg = "Failed" }, JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult ShowEmployee(int id)
        {
            objemployeeproperty = new EmployeeProperty();
            objemployeeproperty.Id = id;
            objEmployeeBll = new Employee_BLL(objemployeeproperty);
            DataTable dt = objEmployeeBll.SelectOne();
            ViewBag.Employee = dt;
            ViewBag.EmployeeID = objemployeeproperty.Id;
            GetDesignations();
            GetDepartments();
            GetDeputaion();
            GetEmptype();
            return View("AddEmployee", objemployeeproperty);
        }

        public ActionResult ShowEmployeeInfo()
        {
            objemployeeproperty = new EmployeeProperty();
            objemployeeproperty.Id = Convert.ToInt32(Session["Emp_ID"].ToString());
            objemployeeproperty.EmployeeLogin = true;
            objEmployeeBll = new Employee_BLL(objemployeeproperty);
            DataTable dt = objEmployeeBll.SelectOne();
            ViewBag.Employee = dt;
            ViewBag.EmployeeID = objemployeeproperty.Id;
            GetDesignations();
            GetDepartments();
            GetDeputaion();
            GetEmptype();
            return View("AddEmployee", objemployeeproperty);
        }

        [HttpGet]
        public JsonResult GetEmployeeByID(int id)
        {
            objemployeeproperty = new EmployeeProperty();
            objemployeeproperty.Id = id;
            objEmployeeBll = new Employee_BLL(objemployeeproperty);
            DataTable dt = objEmployeeBll.SelectOne();
            if (dt.Rows.Count > 0)
            {
                var Empserialize = JsonConvert.SerializeObject(dt);

                return Json(new { status = true, code = 200, message = "No user Found",data=Empserialize }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new {status=true,code=404,message="No user Found",data="" }, JsonRequestBehavior.AllowGet);
            }
           
        }


        [HttpGet]
        public JsonResult GetEmployeesDepandants(int id)
        {
            Depandants_Property dpndnt = new Depandants_Property();
            dpndnt.Employee_Primary_Id = id;
            objEmployeeBll = new Employee_BLL(dpndnt);
            
            DataTable depandants = objEmployeeBll.SelectDepandant();
            var EmployeeDepandant = JsonConvert.SerializeObject(depandants);
            var deserilize = JsonConvert.DeserializeObject(EmployeeDepandant);
            return Json(new { Employee = EmployeeDepandant }, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult ShowAttendance()
        {
            return View();
        }


        public ActionResult ViewLoginRecords(int id)
        {
            
            objLoginRecordsProperty = new Login_Record_Property();
            objLoginRecordsProperty.Employee_ID = id;
            objLoginRecordsBLL = new Login_Records_BLL(objLoginRecordsProperty);
            DataTable dt = objLoginRecordsBLL.GetEmployeLoginRecords();
            ViewBag.EmployeeRecords =JsonConvert.SerializeObject(dt);

            return View();
        }



    }
}