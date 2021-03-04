using BLL.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Setups;
using HrProperty.Models;
using System.Data;

namespace BLL.Setups
{
   public class Department_BLL
    {
        Department_DAL objDepartment_DAL;
        Department_Property objDepartmentproperty;
        public Department_BLL()
        {

        }
        public Department_BLL(Department_Property deprtment)
        {
            objDepartmentproperty = deprtment;
        }

        public DataTable ViewAll()
        {
            objDepartment_DAL = new Department_DAL();
            return objDepartment_DAL.SelectAll();
            
        }
      
        public bool Insert()
        {
            objDepartment_DAL = new Department_DAL(objDepartmentproperty);
            return objDepartment_DAL.Insert();

        }

        public bool Update()
        {
            objDepartment_DAL = new Department_DAL(objDepartmentproperty);
            return objDepartment_DAL.Update();

        }

        public bool UpdateStatus()
        {
            objDepartment_DAL = new Department_DAL(objDepartmentproperty);
            return objDepartment_DAL.UpdateStatus();

        }

        public DataTable SelectOne()
        {
            objDepartment_DAL = new Department_DAL(objDepartmentproperty);
            return objDepartment_DAL.SelectOne();

        }
    }
}
