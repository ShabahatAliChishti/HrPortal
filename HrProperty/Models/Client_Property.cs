using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProperty.Models
{
    [Serializable]
    public class Client_Property
    {
        #region Class Member Declarations

        private int _client_id;
        private int? _user_id ;
        private string _client_name, _clientaddress, _client_no, _client_mobile_no, _status, _column_name;
        private DateTime _date_created;
        private bool _is_active;
        private string _tableName;

        public int Client_id
        {
            get
            {
                return _client_id;
            }

            set
            {
                _client_id = value;
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

        [Required(ErrorMessage ="Please Enter Client Name")]
        public string Client_name
        {
            get
            {
                return _client_name;
            }

            set
            {
                _client_name = value;
            }
        }

        [Required(ErrorMessage = "Please Enter Client Address")]
        public string Clientaddress
        {
            get
            {
                return _clientaddress;
            }

            set
            {
                _clientaddress = value;
            }
        }


        [Required(ErrorMessage = "Please Enter Client Number")]
        public string Client_no
        {
            get
            {
                return _client_no;
            }

            set
            {
                _client_no = value;
            }
        }


        [Required(ErrorMessage = "Please Enter Client Mobile Number")]
        public string Client_mobile_no
        {
            get
            {
                return _client_mobile_no;
            }

            set
            {
                _client_mobile_no = value;
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

        public string Column_name
        {
            get
            {
                return _column_name;
            }

            set
            {
                _column_name = value;
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

        public string TableName
        {
            get
            {
                return _tableName;
            }

            set
            {
                _tableName = value;
            }
        }

        #endregion
    }
}
