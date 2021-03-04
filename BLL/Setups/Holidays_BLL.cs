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
   public class Holidays_BLL
    {
        General_Holiday_Property objgnrlhldy;
        Holidays_DAL objholidayDAL;
        public Holidays_BLL()
        {

        }
        public Holidays_BLL(General_Holiday_Property holiday)
        {
            objgnrlhldy = holiday; 

        
        }

        public bool Insert()
        {
            objholidayDAL = new Holidays_DAL(objgnrlhldy);
            return objholidayDAL.Insert();
        }

        public int SelectOne()
        {
            objholidayDAL = new Holidays_DAL(objgnrlhldy);
            DataTable dt= objholidayDAL.SelectOne();
            int holidays = 0;
            foreach(DataRow dr in dt.Rows)
            {
                holidays = Convert.ToInt32(dr["holiday"].ToString());
            }

            return holidays;
        }
    }
}
