using HealthyME.Data;
using HealthyME.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthyME.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly HEMDbContext _dbContext;

        public EmployeeController(HEMDbContext dbContext)
        {
           _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployeeList()
        {
            var employees = await _dbContext.Employees.ToListAsync();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            employee.Id = Guid.NewGuid();
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute]Guid id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(x =>x.Id == id);

            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id,[FromBody] Employee updatEmployee)
        {
           var employee =  await _dbContext.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            employee.Name = updatEmployee.Name;
            employee.Email = updatEmployee.Email;
            employee.Salary = updatEmployee.Salary;
            employee.Phone = updatEmployee.Phone;
            employee.Department = updatEmployee.Department;

            await _dbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();

            return Ok(employee);
        }
    }
}
