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
    public class Leaves_BLL
    {

        Leaves objleaveproperty;
        Leaves_DAL objleavedal;
        public Leaves_BLL()
        {

        }
        public Leaves_BLL(Leaves leaves)
        {
            objleaveproperty = leaves;
        }

        public bool Insert()
        {
            objleavedal = new Leaves_DAL(objleaveproperty);
            return objleavedal.Insert();
        }
        
        public DataTable GetAllEmployeeLeaves()
        {
            objleavedal = new Leaves_DAL();
            return objleavedal.GetAllEmployeeLeaves();
        }
        public DataTable ViewLeaveHistory()
        {
            objleavedal = new Leaves_DAL(objleaveproperty);
            return objleavedal.ViewLeaveHistory();
        }

        public bool RejectLeave()
        {
            objleavedal = new Leaves_DAL(objleaveproperty);
            return objleavedal.RejectLeave();
        }

        public DataTable SelectOne()
        {
            objleavedal = new Leaves_DAL(objleaveproperty);
            return objleavedal.SelectOne();
        }

        public bool AcceptLeave()
        {
            objleavedal = new Leaves_DAL(objleaveproperty);
            return objleavedal.AcceptLeave();
        }
    }
}
