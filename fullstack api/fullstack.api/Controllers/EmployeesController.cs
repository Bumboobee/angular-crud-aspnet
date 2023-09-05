using fullstack.api.Data;
using fullstack.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fullstack.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly FullStackDbContext _fullStackDbContext;
        public EmployeesController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _fullStackDbContext.Employees.ToListAsync();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            employee.Id = Guid.NewGuid();

            await _fullStackDbContext.Employees.AddAsync(employee);
            await _fullStackDbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee = await _fullStackDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee updateEmployee)
        {
            var employee = await _fullStackDbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            employee.Name = updateEmployee.Name;
            employee.Email = updateEmployee.Email;
            employee.Phone = updateEmployee.Phone;
            employee.Salary = updateEmployee.Salary;
            employee.Department = updateEmployee.Department;

            await _fullStackDbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _fullStackDbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _fullStackDbContext.Employees.Remove(employee);
            await _fullStackDbContext.SaveChangesAsync();

            return Ok();
        }   
    }
}
