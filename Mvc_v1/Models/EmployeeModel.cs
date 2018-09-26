using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_v1.Models
{
    public class EmployeeModel : BaseModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [StringLength(40)]
        //[Display(Name = "Email address")]
        [EmailAddress(ErrorMessage ="InvalidAddress")]
        public string Email { get; set; }
        [Required(ErrorMessage = "DoE is required")]
        [DataType(DataType.Date)]
        //[Display(Name = "Date of employment")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfEmployment { get; set; }

        public long DepartmentId { get; set; }
    }
}