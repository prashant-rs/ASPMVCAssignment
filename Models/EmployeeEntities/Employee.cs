using System.ComponentModel.DataAnnotations;

namespace ASPMVCAssign.Models.EmployeeEntities
{
    public class Employee
    {
        //Guid EmpUniqueId { get; set; }
        [Key]
        public int EmployeeId { get; set; }
        //Guid EUniqueId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
       
        public string Email { get; set; }
        public DateOnly EmploymentDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
