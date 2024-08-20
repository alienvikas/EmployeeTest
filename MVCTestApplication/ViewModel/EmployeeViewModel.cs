using System.ComponentModel.DataAnnotations;

namespace MVCTestApplication.ViewModel
{
    public class EmployeeViewModel
    {
        public int? Id { get; set; }
        public string? EmployeeId { get; set; }
        public string? EmployeeFullName { get; set; }
        public string? Gender { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? DateOfBirth { get; set; }
        public string? Salary { get; set; }
    }
}
