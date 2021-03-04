using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProperty.Models
{
    public class Login_Record_Property
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _Employee_ID;
        public int Employee_ID
        {
            get { return _Employee_ID; }
            set { _Employee_ID = value; }
        }

        private DateTime _Login_Time;
        public DateTime Login_Time
        {
            get { return _Login_Time; }
            set { _Login_Time = value; }
        }

        private DateTime _Logout_out;
        public DateTime Logout_out
        {
            get { return _Logout_out; }
            set { _Logout_out = value; }
        }

        private string _Location_Name;
        public string Location_Name
        {
            get { return _Location_Name; }
            set { _Location_Name = value; }
        }

        private string _latitude;
        public string latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        private string _longitude;
        public string longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
    }
}
