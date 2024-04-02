using ASPMVCAssign.Models.EmployeeEntities;
using Microsoft.EntityFrameworkCore;

namespace ASPMVCAssign.EmployeeData
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Employee> EmployeeInfoData { get; set; }
    }
}
