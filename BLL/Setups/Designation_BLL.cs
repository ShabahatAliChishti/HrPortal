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
    public class Designation_BLL
    {
        Designation_Property objdesignationproperty;
        Designation_DAL objDesignationDAL;


        public Designation_BLL()
        {

        }


        public Designation_BLL(Designation_Property designation)
        {
            objdesignationproperty = designation;
        }


        public DataTable SelectAll()
        {
            objDesignationDAL = new Designation_DAL(objdesignationproperty);
            return objDesignationDAL.SelectAll();
        }
        public bool Insert()
        {
            objDesignationDAL = new Designation_DAL(objdesignationproperty);
            return objDesignationDAL.Insert();
        }

        public bool Update()
        {
            objDesignationDAL = new Designation_DAL(objdesignationproperty);
            return objDesignationDAL.Update();
        }


        public bool UpdateStatus()
        {
            objDesignationDAL = new Designation_DAL(objdesignationproperty);
            return objDesignationDAL.UpdateStatus();
        }

        public DataTable SelectOne()
        {
            objDesignationDAL = new Designation_DAL(objdesignationproperty);
            return objDesignationDAL.SelectOne();
        }

        //public void Dispose()
        //{
        //    this.Dispose();
        //}
    }
}
