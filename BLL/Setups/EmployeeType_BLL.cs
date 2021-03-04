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
   public  class EmployeeType_BLL
    {
        EmployeeType_DAL objEmployeeTypeDAL;
        EmployeeTypeProperty objemployeeproperty;

        public EmployeeType_BLL()
        {

        }
        public EmployeeType_BLL(EmployeeTypeProperty emptypeproperty)
        {
            objemployeeproperty = emptypeproperty;
        }
        public DataTable SelectAll()
        {
            objEmployeeTypeDAL = new EmployeeType_DAL(objemployeeproperty);
            return objEmployeeTypeDAL.SelectAll();

        }

        public bool Insert()
        {
            objEmployeeTypeDAL = new EmployeeType_DAL(objemployeeproperty);
            return objEmployeeTypeDAL.Insert();
        }

        public bool Update()
        {
            objEmployeeTypeDAL = new EmployeeType_DAL(objemployeeproperty);
            return objEmployeeTypeDAL.Update();
        }

        public bool UpdateStatus()
        {
            objEmployeeTypeDAL = new EmployeeType_DAL(objemployeeproperty);
            return objEmployeeTypeDAL.UpdateStatus();
        }

        public DataTable SelectOne()
        {
            objEmployeeTypeDAL = new EmployeeType_DAL(objemployeeproperty);
            return objEmployeeTypeDAL.SelectOne();
        }
    }
}
