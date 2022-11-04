using System.ComponentModel.DataAnnotations;

namespace Employee.model
{
    public class Emp_Model
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
