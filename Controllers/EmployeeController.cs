using ASPMVCAssign.EmployeeData;
using ASPMVCAssign.Models;
using ASPMVCAssign.Models.EmployeeEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.WebSockets;

namespace ASPMVCAssign.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> AddEmployee(AddEmployeeViewModel viewModel)
        {
            var employee = new Employee
            {
                EmployeeId = viewModel.EmployeeId,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                BirthDate = viewModel.BirthDate,
                Email = viewModel.Email,
                EmploymentDate = viewModel.EmploymentDate,
                Address = viewModel.Address,
                City = viewModel.City,
                State = viewModel.State,
                Country = viewModel.Country,
            };

            await dbContext.EmployeeInfoData.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return View(); 
        }

        [HttpGet]
        public async Task<IActionResult>EmployeeList() {
        var employees =await dbContext.EmployeeInfoData.ToListAsync();
            return View(employees);
        }
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int EmployeeId)
        {
            var employee = await dbContext.EmployeeInfoData.FindAsync(EmployeeId);
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult>EditEmployee(Employee viewModel)
        {
            var employee = await dbContext.EmployeeInfoData.FindAsync(viewModel.EmployeeId);

            if (employee is not null)
            {
                employee.EmployeeId = viewModel.EmployeeId;
                employee.FirstName = viewModel.FirstName;
                employee.LastName = viewModel.LastName;
                employee.BirthDate = viewModel.BirthDate;
                employee.Email = viewModel.Email;
                employee.EmploymentDate = viewModel.EmploymentDate;
                employee.Address = viewModel.Address;
                employee.City = viewModel.City;
                employee.State = viewModel.State;
                employee.Country = viewModel.Country;
                await dbContext.SaveChangesAsync(); 
            }    
            return RedirectToAction("EditEmployee","Employee");
        }
    }
}
