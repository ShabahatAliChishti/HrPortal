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
    public class Attendance_BLL
    {
        Attendance_Property objAttendanceProperty;
        Attendance_DAL objAttendanceDAL;
        public Attendance_BLL()
        {

        }

        public Attendance_BLL(Attendance_Property attendance_property)
        {
            objAttendanceProperty = attendance_property;
        }

        public bool Insert(DataTable dt)
        {
            objAttendanceDAL = new Attendance_DAL(objAttendanceProperty);
            return objAttendanceDAL.Insert(dt);
        }

        public DataTable SelectEmployeeAttendance(string from,string to,int attndnceid)
        {
            objAttendanceDAL = new Attendance_DAL();
            return objAttendanceDAL.SelectEmployeeAttendance(from,to,attndnceid);
        }
        
    }

}
