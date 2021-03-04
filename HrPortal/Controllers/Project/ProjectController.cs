using HrProperty.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Setups;
using Newtonsoft.Json;
using HrProperty;
using System.Reflection;

namespace HrPortal.Controllers.Project
{

    public class ProjectController : Controller
    {
        Project_Property objProjectProperty;
        Project_BLL objProjectBll;
        private static Random random = new Random();
        // GET: Project
        public ActionResult AddProject()
        {
            GetDepartments();
            GetClients();
            GetProjectType();
            GetEmployee();
            ViewBag.projcttype = null;
            objProjectProperty = new Project_Property();
            objProjectProperty.Project_Id = 0;
           
            objProjectProperty.Start_Date =DateTime.Now;
            objProjectProperty.Expected_completedDate = DateTime.Now;

            string projectid = RandomString(8);

            if (CheckProjectID(projectid))
            {
                AddProject();
            }
            else
            {
                objProjectProperty.Proj_Id = projectid;
                return View("ProjectAdd", objProjectProperty);
            }
            return View("ProjectAdd", objProjectProperty);
        }


        public bool CheckProjectID(string projid)
        {
            objProjectProperty = new Project_Property();
            objProjectProperty.Proj_Id = projid;
            objProjectBll = new Project_BLL(objProjectProperty);
            return objProjectBll.CheckProjectID();

        }
        public ActionResult ShowProject(int id)
        {
            GetDepartments();
            GetClients();
            GetProjectType();
            GetEmployee();
            objProjectProperty = new Project_Property();
            objProjectProperty.Project_Id = id;
            //objClientProp.TableName = "tblClient";
            objProjectBll = new Project_BLL(objProjectProperty);
            DataTable dt = objProjectBll.SelectOneEdit();
            ViewBag.Project = dt;
            ViewBag.strtdate = objProjectProperty.Start_Date.ToString("yyyy-MM-dd");
            ViewBag.wdate = objProjectProperty.Work_Date;
            ViewBag.projcttype = objProjectProperty.Project_Type;
            return View("ProjectAdd", objProjectProperty);
        }

        public ActionResult ViewProject()
        {

            return View();
        }
        public ActionResult AddTimeLine()
        {
            TimeLine_Property objtimeline = new TimeLine_Property();
            objtimeline.Project_Item = GetProjects();
            objProjectProperty = new Project_Property();
            objProjectBll = new Project_BLL(objProjectProperty);
            DataTable projects = objProjectBll.SelectAll();
            List<Project_Property> ProjectType_PropertylistItems = new List<Project_Property>();
            foreach (DataRow dr in projects.Rows)
            {
                Project_Property objProjectType_Property = new Project_Property();
                objProjectType_Property.Project_Name = dr["Project_Name"].ToString();
                objProjectType_Property.Project_Id = Convert.ToInt32(dr["Project_Id"].ToString());
                ProjectType_PropertylistItems.Add(objProjectType_Property);
            }


            objtimeline.Project_Item = ProjectType_PropertylistItems;
            return View(objtimeline);
        }


        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public ActionResult ShowTimeLine(int id)
        {

            TimeLine_Property objtimeline = new TimeLine_Property();
            objtimeline.Project_Item = GetProjects();
            objtimeline.ID = id;
            //objProjectProperty = new Project_Property();
            //objProjectBll = new Project_BLL(objProjectProperty);
            //DataTable projects = objProjectBll.SelectAll();
            objProjectBll = new Project_BLL(objtimeline);
            DataTable proTimeLine = objProjectBll.GetMilestoneById();
            objtimeline = objProjectBll.getTable(proTimeLine);
        
            return View(objtimeline);
        }

        [HttpPost]
        public JsonResult AddProject(Project_Property Project)
        {
            if (ModelState.IsValid)
            {
                //add new employee
                if (Project.Project_Id == null || Project.Project_Id <= 0)
                {
                    Project.DateCreated = DateTime.Now;

                    Project.Status = "Active";
                    Project.Is_Active = true;
                    Project.In_Progress = false;
                    Project.Is_Completed = false;

                    Project.Remarks = "";
                    objProjectBll = new Project_BLL(Project);
                    var flag = objProjectBll.Insert();
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

                    Project.DateCreated = DateTime.Now;

                    Project.Status = "Active";
                    Project.Is_Active = true;
                    Project.In_Progress = false;
                    Project.Is_Completed = false;

                    objProjectBll = new Project_BLL(Project);
                    var flag = objProjectBll.Update();
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
            //when model state is not valid
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToList();
                return Json(new { success = false, statuscode = 500, msg = "Please Enter According To Instructions" }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult AssignedProjects()
        {
            return View();
        }


        [HttpGet]
        public JsonResult getAssignedProjects()
        {
            objProjectProperty = new Project_Property();
            objProjectProperty.Resource_Id = Convert.ToInt32(SessionManager.CurrentUser.EmployeeID);
            objProjectBll = new Project_BLL(objProjectProperty);

            DataTable projects = objProjectBll.SelectAssignedProjects();
            var projectsJson = JsonConvert.SerializeObject(projects);
            var deserilize = JsonConvert.DeserializeObject(projectsJson);
            return Json(new { projectlist = projectsJson }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getProjects()
        {
            objProjectProperty = new Project_Property();

            objProjectBll = new Project_BLL(objProjectProperty);

            DataTable projects = objProjectBll.SelectAll();
            var projectsJson = JsonConvert.SerializeObject(projects);
            var deserilize = JsonConvert.DeserializeObject(projectsJson);
            return Json(new { projectlist = projectsJson }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AssignedProjectDetails(int id)
        {
            objProjectProperty = new Project_Property();
            objProjectProperty.Project_Id = id;
            objProjectBll = new Project_BLL(objProjectProperty);

            DataTable dt = objProjectBll.SelectOne().Tables[1];
            ViewBag.starttime = dt.Rows.Count > 0 ? false : true;
            return View(objProjectProperty);
        }

        public JsonResult startTime(int id)
        {
            Project_Employee_Working_hours_Property objprojectempworking = new Project_Employee_Working_hours_Property();
            objprojectempworking.projectid = id;
            objprojectempworking.status = "Started";
            objprojectempworking.IsCompleted = false;
            var empid = Convert.ToInt32(SessionManager.CurrentUser.EmployeeID);
            objprojectempworking.employeeid = empid;
            objprojectempworking.starttime = DateTime.Now;

            objProjectBll = new Project_BLL();
            objProjectBll.Starttime(objprojectempworking);
            return Json(new { success = true, statuscode = 200, msg = "Successfully inserted" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EndTime(Project_Employee_Working_hours_Property empprojectwork)
        {
            Project_Employee_Working_hours_Property objprojectempworking = new Project_Employee_Working_hours_Property();
            objprojectempworking.projectid = empprojectwork.projectid;

            objprojectempworking.status = empprojectwork.status;
            var empid = Convert.ToInt32(SessionManager.CurrentUser.EmployeeID);
            objprojectempworking.employeeid = empid;
            objprojectempworking.TaskCompleted = empprojectwork.TaskCompleted;
            objprojectempworking.endtime = DateTime.Now;// TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));
            objProjectBll = new Project_BLL();
            string startdate = objProjectBll.GetStartDate(objprojectempworking);
            var hours = (DateTime.Now - Convert.ToDateTime(startdate)).TotalHours;
            objprojectempworking.totaltime = Convert.ToDecimal(Math.Round(hours, 2));
            objProjectBll.EndTime(objprojectempworking);
            return Json(new { success = true, statuscode = 200, msg = "Successfully inserted" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CompletedProjects()
        {
            return View();
        }

        public JsonResult GetCompletedProjects()
        {
            objProjectProperty = new Project_Property();
            objProjectProperty.Resource_Id = Convert.ToInt32(SessionManager.CurrentUser.EmployeeID);
            objProjectBll = new Project_BLL(objProjectProperty);

            DataTable projects = objProjectBll.SelectAssignedCompletedProjectsForEmployee();
            var projectsJson = JsonConvert.SerializeObject(projects);
            var deserilize = JsonConvert.DeserializeObject(projectsJson);
            return Json(new { projectlist = projectsJson }, JsonRequestBehavior.AllowGet);
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
        public void GetClients()
        {
            Client_BLL Client_BLL = new Client_BLL();
            DataTable dt = Client_BLL.ViewAll();
            List<Client_Property> Client_PropertylistItems = new List<Client_Property>();
            foreach (DataRow dr in dt.Rows)
            {
                Client_Property objclient = new Client_Property();
                objclient.Client_name = dr["Client_Name"].ToString();
                objclient.Client_id = Convert.ToInt32(dr["ClientID"].ToString());
                Client_PropertylistItems.Add(objclient);
            }
            ViewBag.ClientlistItems = Client_PropertylistItems;
        }
        public void GetProjectType()
        {
            ProjectType_BLL objProjectTypeBLL = new ProjectType_BLL();
            DataTable dt = objProjectTypeBLL.SelectAll();
            List<ProjectType_Property> ProjectType_PropertylistItems = new List<ProjectType_Property>();
            foreach (DataRow dr in dt.Rows)
            {
                ProjectType_Property objProjectType_Property = new ProjectType_Property();
                objProjectType_Property.Project_type = dr["ProjectType"].ToString();
                objProjectType_Property.Project_type_id = Convert.ToInt32(dr["ProjectTypeId"].ToString());
                ProjectType_PropertylistItems.Add(objProjectType_Property);
            }
            ViewBag.Project_Type = ProjectType_PropertylistItems;
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

        public void GetMilestones()
        {
            Project_BLL objprojectbll = new Project_BLL();
            DataTable dt = objprojectbll.GetAllMilestone();
            List<TimeLine_Property> objTimeLine_PropertyList = new List<TimeLine_Property>();
            foreach (DataRow dr in dt.Rows)
            {
                TimeLine_Property objTimeLineProperty = new TimeLine_Property();
                objTimeLineProperty.ID = Convert.ToInt32(dr["ID"].ToString());
                objTimeLineProperty.TimeLineName = dr["TimeLineName"].ToString();
                objTimeLineProperty.Project_ID = Convert.ToInt32(dr["Project_Id"].ToString());
                objTimeLine_PropertyList.Add(objTimeLineProperty);
            }
            ViewBag.MileStoneItems = objTimeLine_PropertyList;
        }


        public List<Project_Property> GetProjects()
        {
            Project_BLL objprojectbll = new Project_BLL();
            DataTable dt = objprojectbll.SelectUnAssignedProjects();
            List<Project_Property> objProject_Property = new List<Project_Property>();
            foreach (DataRow dr in dt.Rows)
            {
                Project_Property objprojctpropert = new Project_Property();
                objprojctpropert.Project_Id = Convert.ToInt32(dr["Project_Id"].ToString());
                objprojctpropert.Project_Name = dr["Project_Name"].ToString();
                objProject_Property.Add(objprojctpropert);
            }
            return objProject_Property;
        }

        public JsonResult DeleteProject(int id)
        {
            objProjectProperty = new Project_Property();
            objProjectProperty.Project_Id = id;
            // objProjectProperty.TableName = "tblClient";
            objProjectProperty.Status = "Deleted";
            // objClientProp.U_id = SessionManager.CurrentUser.ID;
            objProjectBll = new Project_BLL(objProjectProperty);
            var flag = objProjectBll.UpdateStatus();
            if (flag)
            {

                return Json(new { success = true, statuscode = 200, msg = "Successfull" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = false, statuscode = 500, msg = "Failed" }, JsonRequestBehavior.AllowGet);

            }
        }

       


        




        public JsonResult AddTimeLineDetails(IEnumerable<Milestone_Details_Property> timeline)
        {

            Milestone_Details_Property objmilestone = new Milestone_Details_Property();
            objmilestone.MilestoneDetails = ToDataTable(timeline);
            objProjectBll = new Project_BLL(objmilestone);
            var flag = objProjectBll.InsertMileStone();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewMilesStone(int id)
        {
            objProjectProperty = new Project_Property();
            objProjectProperty.Project_Id = id;
            objProjectBll = new Project_BLL(objProjectProperty);
            DataTable dt = objProjectBll.GetAllMilestoneById();
            var Milestones = JsonConvert.SerializeObject(dt);
            ViewBag.Milestone = Milestones;
            return View();
        }


        public ActionResult AddTask()
        {
            Project_Property objtimeline = new Project_Property();
            ProjectType_BLL objProjectTypeBLL = new ProjectType_BLL();

            objProjectProperty = new Project_Property();
            objProjectBll = new Project_BLL(objProjectProperty);
            DataTable projects = objProjectBll.SelectAll();
            List<Project_Property> ProjectType_PropertylistItems = new List<Project_Property>();
            foreach (DataRow dr in projects.Rows)
            {
                Project_Property objProjectType_Property = new Project_Property();
                objProjectType_Property.Project_Name = dr["Project_Name"].ToString();
                objProjectType_Property.Project_Id = Convert.ToInt32(dr["Project_Id"].ToString());
                ProjectType_PropertylistItems.Add(objProjectType_Property);
            }

            objtimeline.Start_Date = DateTime.Now;
            objtimeline.Expected_completedDate = DateTime.Now;
           
            objtimeline.Project_Item = ProjectType_PropertylistItems;
            GetEmployee();
            GetMilestones();
            return View(objtimeline);
        }


        [HttpPost]
        public JsonResult AddTask(Project_Property Project)
        {

            if (ModelState.IsValid)
            {
                EmployeeProperty objempproperty = new EmployeeProperty();
                objempproperty.Id = Project.Resource_Id;
                Employee_BLL objemployeebll = new Employee_BLL(objempproperty);
                DataTable dt = objemployeebll.SelectOne();
                foreach (DataRow dr in dt.Rows)
                {
                    Project.Employee_Cost = Math.Round(Convert.ToDecimal(dr["TotalSalary"].ToString()) / 270, 2);
                }
                //add new employee
                if (Project.Project_Id == null || Project.Project_Id <= 0)
                {
                    Project.DateCreated = DateTime.Now;

                    Project.Status = "Active";
                    Project.Is_Active = true;
                    Project.In_Progress = false;
                    Project.Is_Completed = false;

                    Project.Remarks = "";

                    //Project.Employee_Cost=
                    objProjectBll = new Project_BLL(Project);
                    var flag = objProjectBll.InsertTask();
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

                    Project.DateCreated = DateTime.Now;

                    Project.Status = "Active";

                    objProjectBll = new Project_BLL(Project);
                    var flag = objProjectBll.Insert();
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
            //when model state is not valid
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToList();
                return Json(new { success = false, statuscode = 500, msg = "Please Enter According To Instructions" }, JsonRequestBehavior.AllowGet);
            }

        }


        public ActionResult ViewMilesStoneTasks(int id)
        {
            TimeLine_Property objtimeline = new TimeLine_Property();


            objtimeline.ID = id;
            objProjectBll = new Project_BLL(objtimeline);
            DataTable dt = objProjectBll.GetAllTaskByIdMilesToneID();
            var Tasklist = JsonConvert.SerializeObject(dt);
            ViewBag.Tasklist = Tasklist;
            return View();
        }

        //Methods To Push in Utiltity

        public static DataTable ToDataTable<T>(IEnumerable<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }


        public ActionResult GetProjectEstimationDetails(int id)
        {
            objProjectProperty = new Project_Property();
            objProjectProperty.P_Id = id;
            objProjectBll = new Project_BLL(objProjectProperty);
            var estimation = JsonConvert.SerializeObject(objProjectBll.GetDetailsForProjectEstimation());

            ViewBag.FooObj = estimation;
            return View();
        }
    }
}