using BusinessLogic.Services;
using BusinessLogic.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.ModelDTO;
using ProjectTracker.ModelDTO.Mappers;

namespace ProjectTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeControllers : ControllerBase
    {
        private readonly IEmployeesService _employeeService;

        public EmployeeControllers(IEmployeesService employeesService)
        {
            _employeeService = employeesService;
        }

        /// <summary>
        /// Retrieves employee data by their identifier.
        /// </summary>
        /// <param name="id">The employee identifier.</param>
        /// <returns>The employee data or a message "Employee with the specified Id not found" if the employee is not found.</returns>
        [HttpGet("")]
        public async Task<IActionResult> GetEmployeeByUserName(string userName)
        {
            var employee = await _employeeService.GetEmployeeByUserNameAsync(userName);
            if (employee == null)
            {
                return NotFound("Employee with the specified userName not found");
            }
            return Ok(employee);
        }

        /// <summary>
        /// Deletes an employee by their identifier.
        /// </summary>
        /// <param name="id">The employee identifier.</param>
        /// <returns>Returns NoContent (204) if the employee is successfully deleted, and NotFound (404) if the employee with the specified Id is not found.</returns>
        [HttpDelete("{userName}")]
        public async Task<IActionResult> DeleteEmployeeByUserName(string userName)
        {
            if (await _employeeService.DeleteEmployeeByUserNameAsync(userName))
            {
                return NoContent();
            }
            return NotFound("Employee with the specified userName not found");
        }

        /// <summary>
        /// Updates employee data.
        /// </summary>
        /// <param name="employee">The employee data to update.</param>
        /// <returns>Returns BadRequest (400) if the employee data is missing. Returns NotFound (404) if the employee with the specified Id is not found. Returns Ok (200) upon successful update.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(EmployeeUpdate employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            var noObjectFound = await _employeeService.UpdateEmployeeAsync(employee.ToModel());

            if (noObjectFound == false)
            {
                return NotFound("Employee with the specified Id not found");
            }
            return Ok();
        }

       

        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        /// <returns>A list of all employees.</returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return Ok(employees);
        }


    }
}
