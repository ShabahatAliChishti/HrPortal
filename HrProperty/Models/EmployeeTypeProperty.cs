using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProperty.Models
{
    [Serializable()]
    public  class EmployeeTypeProperty
    {
        #region Class Member Declarations

        int? _employee_type_id;
        string _employee_type,_status, _tableName;
        int? _active;
        int? _insertBy;
        DateTime? _insertionDate;
        bool _is_active;

      
       
       



        #endregion

        #region Class Property Declarations
        
        public int? EmployeeTypeID
        {
            get
            {
                return _employee_type_id;
            }
            set
            {
                _employee_type_id = value;
            }
        }





        [Required]
        public string EmployeeType
        {
            get
            {
                return _employee_type;
            }
            set
            {
                _employee_type = value;
            }
        }


        public int? InsertBy
        {
            get
            {
                return _insertBy;
            }
            set
            {
                _insertBy = value;
            }
        }
        
        public DateTime? InsertionDate
        {
            get
            {
                return _insertionDate;
            }
            set
            {
                _insertionDate = value;
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

        public bool IsActive
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
