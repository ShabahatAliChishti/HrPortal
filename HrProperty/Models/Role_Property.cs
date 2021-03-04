using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProperty.Models
{
    public class Role_Property
    {
        #region Class Member Declarations

        private int? _role_id;
        private int? _user_id;

        private string _roleName, _status;
        private DateTime _date_created;
        private bool _is_active;

        public int? Role_id
        {
            get
            {
                return _role_id;
            }

            set
            {
                _role_id = value;
            }
        }

        public int? User_id
        {
            get
            {
                return _user_id;
            }

            set
            {
                _user_id = value;
            }
        }

        public string RoleName
        {
            get
            {
                return _roleName;
            }

            set
            {
                _roleName = value;
            }
        }

        public string Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
            }
        }

        public DateTime Date_created
        {
            get
            {
                return _date_created;
            }

            set
            {
                _date_created = value;
            }
        }

        public bool Is_active
        {
            get
            {
                return _is_active;
            }

            set
            {
                _is_active = value;
            }
        }


        #endregion
    }
}
