using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProperty.Models
{
    public class ProjectType_Property
    {
        #region Class Member Declarations

        int? _project_type_id;
        string _project_type, _status;
        int? _active;
        int? _insertBy;
        DateTime? _insertionDate;
        bool _is_active;

        public int? Project_type_id
        {
            get
            {
                return _project_type_id;
            }

            set
            {
                _project_type_id = value;
            }
        }
        [Required(ErrorMessage ="Please Enter a Project Type")]
        public string Project_type
        {
            get
            {
                return _project_type;
            }

            set
            {
                _project_type = value;
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

        public int? Active
        {
            get
            {
                return _active;
            }

            set
            {
                _active = value;
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

        public string TableName { get; set; }





        #endregion
    }
}
