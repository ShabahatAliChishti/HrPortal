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
    public class Login_Records_BLL
    {
        Login_Record_Property objloginrecordproperty;
        Login_Records_DAL objloginrecoddal;

        public Login_Records_BLL()
        {

        }

        public Login_Records_BLL(Login_Record_Property objloginrcrds)
        {
            objloginrecordproperty = objloginrcrds;
        }

        public bool Insert()
        {
            objloginrecoddal = new Login_Records_DAL(objloginrecordproperty);
            return objloginrecoddal.Insert();
        }
        public bool Update()
        {
            objloginrecoddal = new Login_Records_DAL(objloginrecordproperty);
            return true;
        }

        public DataTable Select()
        {
            objloginrecoddal = new Login_Records_DAL(objloginrecordproperty);
            return new DataTable();
        }

        public DataTable GetEmployeLoginRecords()
        {
            objloginrecoddal = new Login_Records_DAL(objloginrecordproperty);
            return objloginrecoddal.GetEMployeeLoginRecords();
        }

        public bool UpdateLogoutTime()
        {
            objloginrecoddal = new Login_Records_DAL(objloginrecordproperty);
            return objloginrecoddal.UpdateLogoutTime();
        }
    }
}
