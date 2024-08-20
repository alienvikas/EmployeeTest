using System.ComponentModel.DataAnnotations;

namespace MVCTestApplication.Models
{
    public class EmployeeModel
    {
        [Display(Name = "id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee id is required")]
        [Display(Name = "Employee Id")]
        public string? EmployeeId { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First name")]
        public string? FirstName { get; set; }
        [Display(Name = "Middle name")]
        public string? MiddleName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last name")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Date of birth is required")]
        [Display(Name = "Date of birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        public string? Salary { get; set; }
        public string? FullName
        {
            get
            {
                return $"{FirstName} {MiddleName} {LastName}";
            }
        }
    }
}
