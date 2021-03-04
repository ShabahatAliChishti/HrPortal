using DAL.Setups;
using HrProperty.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Setups
{
    public class Project_BLL
    {
        Project_DAL objProjectDAl;
        Project_Property objprojectproperty;
        Project_Employee_Working_hours_Property objProject_Employee_Working_hours_Property;
        Milestone_Details_Property objMileStone;
        private Project_DAL objProjDAL;

        TimeLine_Property objTimeline;
        public Project_BLL()
        {

        }
        public Project_BLL(Project_Property property)
        {
            objprojectproperty = property;
        }
        public Project_BLL(Milestone_Details_Property property)
        {
            objMileStone = property;
        }
        public Project_BLL(TimeLine_Property property)
        {
            objTimeline = property;
        }
        public bool CheckProjectID()
        {
            objProjDAL = new Project_DAL(objprojectproperty);
            DataTable dt = objProjDAL.CheckProjectID();
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Insert()
        {
            objProjectDAl = new Project_DAL(objprojectproperty);
            return objProjectDAl.Insert();
        }


        public bool Update()
        {
            objProjectDAl = new Project_DAL(objprojectproperty);
            return objProjectDAl.Update();
        }





        public bool InsertTask()
        {
            objProjectDAl = new Project_DAL(objprojectproperty);
            return objProjectDAl.InsertTAsk();
        }

        public bool InsertMileStone()
        {
            objProjectDAl = new Project_DAL(objprojectproperty);
            return objProjectDAl.InsertMilesStone(objMileStone.MilestoneDetails);
        }

        public DataTable SelectAll()
        {
            objProjectDAl = new Project_DAL(objprojectproperty);
            return objProjectDAl.SelectAll();
        }

        public DataTable SelectProjectNew()
        {
            objProjectDAl = new Project_DAL(objprojectproperty);
            return objProjectDAl.SelectAll();
        }

        public DataTable SelectUnAssignedProjects()
        {
            objProjectDAl = new Project_DAL(objprojectproperty);
            return objProjectDAl.SelectUnAssignedProjects();
        }


        public DataTable SelectAssignedProjects()
        {
            objProjectDAl = new Project_DAL(objprojectproperty);
            return objProjectDAl.SelectAssignedProjects();
        }
        public DataTable SelectAssignedCompletedProjectsForEmployee()
        {
            objProjectDAl = new Project_DAL(objprojectproperty);
            return objProjectDAl.SelectAssignedCompletedProjectsForEmployee();
        }

        public DataSet SelectOne()
        {
            objProjectDAl = new Project_DAL(objprojectproperty);
            return objProjectDAl.SelectOne();
        }
        public bool Starttime(Project_Employee_Working_hours_Property empproject)
        {
            objProject_Employee_Working_hours_Property = empproject;
            objProjectDAl = new Project_DAL(objprojectproperty);
            return objProjectDAl.StartTime(objProject_Employee_Working_hours_Property);
        }

        public bool EndTime(Project_Employee_Working_hours_Property empproject)
        {
            objProject_Employee_Working_hours_Property = empproject;
            objProjectDAl = new Project_DAL(objprojectproperty);
            return objProjectDAl.EndTask(objProject_Employee_Working_hours_Property);
        }

        public string GetStartDate(Project_Employee_Working_hours_Property empproject)
        {
            string startdate = "";
            objProject_Employee_Working_hours_Property = empproject;
            objProjectDAl = new Project_DAL(objprojectproperty);
            DataTable dt = objProjectDAl.GetStartDate(objProject_Employee_Working_hours_Property);
            foreach (DataRow dr in dt.Rows)
            {
                startdate = dr["starttime"].ToString();
            }
            return startdate;
        }
        public DataTable SelectOneEdit()
        {
            objProjectDAl = new Project_DAL(objprojectproperty);
            return objProjectDAl.SelectOneEdit();
        }
        public bool UpdateStatus()
        {
            objProjectDAl = new Project_DAL(objprojectproperty);
            return objProjectDAl.UpdateStatus();
        }


        public DataTable GetAllMilestone()
        {
            objProjectDAl = new Project_DAL(objprojectproperty);
            return objProjectDAl.GetAllMilestone();
        }
        public DataTable GetDetailsForProjectEstimation()
        {
            objProjectDAl = new Project_DAL(objprojectproperty);
            return objProjectDAl.GetDetailsForProjectEstimation();
        }

        public DataTable GetAllMilestoneById()
        {
            objProjectDAl = new Project_DAL(objprojectproperty);
            return objProjectDAl.GetAllMilestoneByProjectID();
        }
        public DataTable GetMilestoneById()
        {
            objProjectDAl = new Project_DAL(objTimeline);
            return objProjectDAl.GetMilestoneById();
        }
        public DataTable GetAllTaskByIdMilesToneID()
        {
            objProjectDAl = new Project_DAL(objTimeline);
            return objProjectDAl.GetAllTaskByIdMilesToneID();
        }


        public TimeLine_Property getTable(DataTable proTimeLine)
        {
            foreach (DataRow dr in proTimeLine.Rows)
            {

                objTimeline.ID = Convert.ToInt32(dr["ID"].ToString());

                objTimeline.TimeLineName = dr["TimeLineName"].ToString();
                objTimeline.Status = dr["Status"].ToString();
                if (dr["Is_Completed"].ToString() != "")
                {
                    objTimeline.Is_Completed = Convert.ToBoolean(dr["Is_Completed"].ToString());
                }
                if (dr["Is_Started"].ToString() != "")
                {
                    objTimeline.Is_Started = Convert.ToBoolean(dr["Is_Started"].ToString());
                }
                if (dr["IsActive"].ToString() != "")
                {
                    objTimeline.IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
                }
                if (dr["Date_Created"].ToString() != "")
                {
                    objTimeline.Date_Created = Convert.ToDateTime(dr["Date_Created"].ToString());
                }
                if (dr["Expected_Completed_Date"].ToString() != "")
                {
                    objTimeline.Expected_Completed_Date = Convert.ToDateTime(dr["Expected_Completed_Date"].ToString());
                }
                if (dr["Start_Date"].ToString() != "")
                {
                    objTimeline.Start_Date = Convert.ToDateTime(dr["Start_Date"].ToString());
                }
                if (dr["EndDate"].ToString() != "")
                {
                    objTimeline.EndDate = Convert.ToDateTime(dr["EndDate"].ToString());
                }
                if (dr["Last_Updated_date"].ToString() != "")
                {
                    objTimeline.Last_Updated_date = Convert.ToDateTime(dr["Last_Updated_date"].ToString());
                }
                if (dr["CreatedBy"].ToString() != "")
                {
                    objTimeline.CreatedBy = Convert.ToInt32(dr["CreatedBy"].ToString());
                }
                if (dr["Updated_By"].ToString() != "")
                {
                    objTimeline.Updated_By = Convert.ToInt32(dr["Updated_By"].ToString());
                }
                if (dr["Project_Id"].ToString() != "")
                {
                    objTimeline.Project_ID = Convert.ToInt32(dr["Project_Id"].ToString());
                }
                //Project_Property objProjectType_Property = new Project_Property();
                //objProjectType_Property.Project_Name = dr["Project_Name"].ToString();
                //objProjectType_Property.Project_Id = Convert.ToInt32(dr["Project_Id"].ToString());
                //ProjectType_PropertylistItems.Add(objProjectType_Property);
            }
            return objTimeline;
        }
    }

}
