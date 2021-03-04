using HrProperty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL.Setups
{
    public class Employee_BLL 
    {
        private EmployeeProperty objEmpProp;
        private Employee_DAL objEmpDAL;
        private Depandants_Property objdepandant;    
        
        public Employee_BLL()
        {
                
        }

        public Employee_BLL(EmployeeProperty objEmp_Prop)
        {
            objEmpProp = objEmp_Prop;
        }

        public Employee_BLL(Depandants_Property depandant)
        {
            objdepandant = depandant;
        }

        public bool Insert()
        {
            objEmpDAL = new Employee_DAL(objEmpProp);
            return objEmpDAL.Insert();
        }

        public bool Update()
        {
            objEmpDAL = new Employee_DAL(objEmpProp);
            return objEmpDAL.Update();
        }
        public bool UpdateStatus()
        {
            objEmpDAL = new Employee_DAL(objEmpProp);
            return objEmpDAL.UpdateStatus();
        }

        public DataTable SelectAll()
        {
            objEmpDAL = new Employee_DAL();
            return objEmpDAL.SelectAll();
        }
        public DataTable SelectOne()
        {
            objEmpDAL = new Employee_DAL(objEmpProp);
            return objEmpDAL.SelectOne();
        }

        public DataTable SelectDepandant()
        {
            objEmpDAL = new Employee_DAL(objdepandant);
            return objEmpDAL.SelecDepandanttOne();
        }

        public bool CheckEmployeeID()
        {
            objEmpDAL = new Employee_DAL(objEmpProp);
            DataTable dt= objEmpDAL.CheckEmployeeID();
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public int GetEmployeeAttendanceId()
        {
            int employattndnceid = 0;
            objEmpDAL = new Employee_DAL(objEmpProp);
            foreach(DataRow dr in objEmpDAL.SelectOne().Rows)
            {
                employattndnceid = Convert.ToInt32(dr["Attendance_Id"].ToString());
            }
            return employattndnceid;
        }
    }
}
