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
   public  class Payroll_BLL
    {
        Payroll_DAL objPayrollDAl;
        Payroll_Property objpayrollproperty;
        public Payroll_BLL()
        {

        }

        public Payroll_BLL(Payroll_Property payroll)
        {
            objpayrollproperty = payroll;
        }

        public DataTable GetEmployeeForPayroll()
        {
            objPayrollDAl = new Payroll_DAL();
            return objPayrollDAl.GetEmployeeForPayroll();
        }
        public DataTable GetDetailsForPayroll()
        {
            objPayrollDAl = new Payroll_DAL(objpayrollproperty);
            return objPayrollDAl.GetDetailsForPayroll();
        }
        public DataTable GetDetailsForPayrollMultiple()
        {
            objPayrollDAl = new Payroll_DAL(objpayrollproperty);
            return objPayrollDAl.GetDetailsForPayrollMultiple();
        }

    }
}
