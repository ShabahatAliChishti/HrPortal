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
   public class User_BLL
    {
        User_DAL objUserDAl;
        User_Property objUserProperty;

        public User_BLL()
        {

        }

        public User_BLL(User_Property userProperty)
        {
            objUserProperty = userProperty;
        }

        public DataTable ViewAll()
        {
            objUserDAl = new User_DAL(objUserProperty);
            return objUserDAl.SelectAll();
        }

        public DataTable GetAllUsers()
        {
            objUserDAl = new User_DAL(objUserProperty);
            return objUserDAl.GetAllUsers();
        }

        public bool Insert()
        {
            objUserDAl = new User_DAL(objUserProperty);
            return objUserDAl.Insert();
        }

        public DataTable CheckUserExistance()
        {
            objUserDAl = new User_DAL(objUserProperty);
            return objUserDAl.CheckUserExistance();
        }
    }
}
