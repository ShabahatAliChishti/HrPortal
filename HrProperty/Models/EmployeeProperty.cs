using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HrProperty.Models
{
    

    public class EmployeeProperty
    {
        #region ClassDeclarations

        private int _id,   _reference_id, _salary_id, _balance_Id;
        private string _empName, _govtId, _SSNno, _licenseNo, _imgPath, _deputationLoc, _lastEmployerName, _lastEmployerAdd,
            _lastEmployerContact, _homeAddress, _homeContact, _emergencyPersonName, _emergencyPersonRelation, _emergencyPersonContact
            , _bloodGroup, _modeOfTraveling, _vehicleNo, _status, _bankAccountNo;
        private bool _isActive;
        private DateTime? _joiningDate, _lastEducationDate, _lastEmployerFromDate, _lastEmployerToDate,_created_date;
        private int? _u_id, _lastEdu_Id, _empType_Id,  _designation_Id, _department_id, _attndnc_id;

        private float? _base_salry, _allownce1, _allownce2, _allownce3,_totol_salary,_leave_balance, _benefit1, _benefit2;


        #endregion
        public string Employee_ID { get; set; }
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public int? U_id
        {
            get
            {
                return _u_id;
            }

            set
            {
                _u_id = value;
            }
        }
        
        public int? EmpType_Id
        {
            get
            {
                return _empType_Id;
            }

            set
            {
                _empType_Id = value;
            }
        }
      
        public int? LastEdu_Id
        {
            get
            {
                return _lastEdu_Id;
            }

            set
            {
                _lastEdu_Id = value;
            }
        }
      
        public int? Designation_Id
        {
            get
            {
                return _designation_Id;
            }

            set
            {
                _designation_Id = value;
            }
        }
       
        public int? Department_id
        {
            get
            {
                return _department_id;
            }

            set
            {
                _department_id = value;
            }
        }

        public int Reference_id
        {
            get
            {
                return _reference_id;
            }

            set
            {
                _reference_id = value;
            }
        }

        public int Salary_id
        {
            get
            {
                return _salary_id;
            }

            set
            {
                _salary_id = value;
            }
        }

        public int Balance_Id
        {
            get
            {
                return _balance_Id;
            }

            set
            {
                _balance_Id = value;
            }
        }
        [Required(ErrorMessage = "The Emp Name field is required")]

        public string EmpName
        {
            get
            {
                return _empName;
            }

            set
            {
                _empName = value;
            }
        }
        [Required(ErrorMessage = "The Govt Id field is required")]
        public string GovtId
        {
            get
            {
                return _govtId;
            }

            set
            {
                _govtId = value;
            }
        }

        public string SSNno
        {
            get
            {
                return _SSNno;
            }

            set
            {
                _SSNno = value;
            }
        }

        public string LicenseNo
        {
            get
            {
                return _licenseNo;
            }

            set
            {
                _licenseNo = value;
            }
        }

        public string ImgPath
        {
            get
            {
                return _imgPath;
            }

            set
            {
                _imgPath = value;
            }
        }

        public string DeputationLoc
        {
            get
            {
                return _deputationLoc;
            }

            set
            {
                _deputationLoc = value;
            }
        }

        public string LastEmployerName
        {
            get
            {
                return _lastEmployerName;
            }

            set
            {
                _lastEmployerName = value;
            }
        }

        public string LastEmployerAdd
        {
            get
            {
                return _lastEmployerAdd;
            }

            set
            {
                _lastEmployerAdd = value;
            }
        }

        public string LastEmployerContact
        {
            get
            {
                return _lastEmployerContact;
            }

            set
            {
                _lastEmployerContact = value;
            }
        }
        [Required(ErrorMessage = "The Home Address field is required")]
        public string HomeAddress
        {
            get
            {
                return _homeAddress;
            }

            set
            {
                _homeAddress = value;
            }
        }
        [Required(ErrorMessage = "The Home Contact field is required")]
        public string HomeContact
        {
            get
            {
                return _homeContact;
            }

            set
            {
                _homeContact = value;
            }
        }

        public string EmergencyPersonName
        {
            get
            {
                return _emergencyPersonName;
            }

            set
            {
                _emergencyPersonName = value;
            }
        }

        public string EmergencyPersonRelation
        {
            get
            {
                return _emergencyPersonRelation;
            }

            set
            {
                _emergencyPersonRelation = value;
            }
        }

        [Required(ErrorMessage = "The Emergency Contact field is required")]
        public string EmergencyPersonContact
        {
            get
            {
                return _emergencyPersonContact;
            }

            set
            {
                _emergencyPersonContact = value;
            }
        }

        public string BloodGroup
        {
            get
            {
                return _bloodGroup;
            }

            set
            {
                _bloodGroup = value;
            }
        }

        public string ModeOfTraveling
        {
            get
            {
                return _modeOfTraveling;
            }

            set
            {
                _modeOfTraveling = value;
            }
        }

        public string VehicleNo
        {
            get
            {
                return _vehicleNo;
            }

            set
            {
                _vehicleNo = value;
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
                return _isActive;
            }

            set
            {
                _isActive = value;
            }
        }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? JoiningDate
        {
            get
            {
                return _joiningDate;
            }

            set
            {
                _joiningDate = value;
            }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LastEducationDate
        {
            get
            {
                return _lastEducationDate;
            }

            set
            {
                _lastEducationDate = value;
            }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LastEmployerFromDate
        {
            get
            {
                return _lastEmployerFromDate;
            }

            set
            {
                _lastEmployerFromDate = value;
            }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LastEmployerToDate
        {
            get
            {
                return _lastEmployerToDate;
            }

            set
            {
                _lastEmployerToDate = value;
            }
        }

        public DateTime? CreatedDate
        {
            get
            {
                return _created_date;
            }

            set
            {
                _created_date = value;
            }
        }

        [DataType(DataType.Upload)]
        public HttpPostedFileWrapper ImageFile { get; set; }

        
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid float Number")]
        public float? BaseSalary
        {
            get
            {
                return _base_salry;
            }

            set
            {
                _base_salry = value;
            }
        }
        
        public float? Allownce1
        {
            get
            {
                return _allownce1;
            }

            set
            {
                _allownce1 = value;
            }
        }
        
        public float? Allownce2
        {
            get
            {
                return _allownce2;
            }

            set
            {
                _allownce2 = value;
            }
        }
        
        public float? Allownce3
        {
            get
            {
                return _allownce3;
            }

            set
            {
                _allownce3 = value;
            }
        }
        [Required(ErrorMessage = "Total Salary is Required")]
        public float? TotalSalary
        {
            get
            {
                return _totol_salary;
            }

            set
            {
                _totol_salary = value;
            }
        }
        [Required(ErrorMessage = "Total Package is Required")]
        public float? Total_Package { get; set; }

        public float? LeaveBalances
        {
            get
            {
                return _leave_balance;
            }

            set
            {
                _leave_balance = value;
            }
        }

        public string TableName { get; set; }

        public int? Attndnc_id
        {
            get
            {
                return _attndnc_id;
            }

            set
            {
                _attndnc_id = value;
            }
        }

        public float? Benefit1
        {
            get
            {
                return _benefit1;
            }

            set
            {
                _benefit1 = value;
            }
        }

        public float? Benefit2
        {
            get
            {
                return _benefit2;
            }

            set
            {
                _benefit2 = value;
            }
        }

        public string BankAccountNo
        {
            get
            {
                return _bankAccountNo;
            }

            set
            {
                _bankAccountNo = value;
            }
        }


        public string LastInstitueName { get; set; }

        public bool EmployeeLogin { get; set; }

        public string Depandants { get; set; }

        public int Annual_Leaves { get; set; }
        public int Casual_Leaves { get; set; }

        public int Sick_Leaves { get; set; }
        public DataTable DepandantsList { get; set; }
    }
}
