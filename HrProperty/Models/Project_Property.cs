using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProperty.Models
{
    public class Project_Property
    {
        public string Proj_Id { get; set; }
        private int _Project_Id;
        public int Project_Id
        {
            get { return _Project_Id; }
            set { _Project_Id = value; }
        }

        private int _Client_id;
        [Required(ErrorMessage ="Please Enter Client Name")]
        public int Client_id
        {
            get { return _Client_id; }
            set { _Client_id = value; }
        }

        private int _Project_Type;
        [Required(ErrorMessage = "Please Select a Project Type")]

        public int Project_Type
        {
            get { return _Project_Type; }
            set { _Project_Type = value; }
        }

        private int _Resource_Id;
        [Required(ErrorMessage = "Please Select an Employee")]

        public int Resource_Id
        {
            get { return _Resource_Id; }
            set { _Resource_Id = value; }
        }

        private int _Department_ID;
        [Required(ErrorMessage = "Please Select a Department")]

        public int Department_ID
        {
            get { return _Department_ID; }
            set { _Department_ID = value; }
        }

        private string _Project_Name;
        [Required(ErrorMessage = "This Field is Required")]

        public string Project_Name
        {
            get { return _Project_Name; }
            set { _Project_Name = value; }
        }

        private DateTime _Start_Date;
        [Required(ErrorMessage = "Please Enter a Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime Start_Date
        {
            get { return _Start_Date; }
            set { _Start_Date = value; }
        }

        private DateTime _Work_Date;
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Work_Date
        {
            get { return _Work_Date; }
            set { _Work_Date = value; }
        }

        private string _Task_Description;
        [Required(ErrorMessage = "Please Enter Project Description")]
        public string Task_Description
        {
            get { return _Task_Description; }
            set { _Task_Description = value; }
        }

        private decimal _Employee_Cost;
        public decimal Employee_Cost
        {
            get { return _Employee_Cost; }
            set { _Employee_Cost = value; }
        }

        private decimal _Budget_Cost;
        [Required(ErrorMessage = "Please Enter a Budget Cost")]

        public decimal Budget_Cost
        {
            get { return _Budget_Cost; }
            set { _Budget_Cost = value; }
        }

        private decimal _Allocated_time;
        [Required(ErrorMessage = "Please Enter Allocated Time")]
        public decimal Allocated_time
        {
            get { return _Allocated_time; }
            set { _Allocated_time = value; }
        }

        private decimal _Start_Time;
        public decimal Start_Time
        {
            get { return _Start_Time; }
            set { _Start_Time = value; }
        }

        private decimal _End_Time;
        public decimal End_Time
        {
            get { return _End_Time; }
            set { _End_Time = value; }
        }

        private decimal _Total_spend_Time;
        public decimal Total_spend_Time
        {
            get { return _Total_spend_Time; }
            set { _Total_spend_Time = value; }
        }

        private decimal _Actual_Cost;
        public decimal Actual_Cost
        {
            get { return _Actual_Cost; }
            set { _Actual_Cost = value; }
        }

        private decimal _Varrience;
        public decimal Varrience
        {
            get { return _Varrience; }
            set { _Varrience = value; }
        }

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _Remarks;
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        public DateTime DateCreated { get; set; }

        public int CreatedBy { get; set; }
        public DateTime LastUpdatedat { get; set; }
        public int Updated_By { get; set; }

        public bool Is_Active { get; set; }
        public bool In_Progress { get; set; }
        public bool Is_Completed { get; set; }

        [Required(ErrorMessage = "Please Enter Expected Completed Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]        
        public DateTime Expected_completedDate { get; set; }
        public DateTime Completed_date { get; set; }

        public List<Project_Property> Project_Item { get; set; }
        [Required(ErrorMessage = "Please Enter a Project Name")]
        public int P_Id { get; set; }

        public int MileStone_Id { get; set; }
    }
}
