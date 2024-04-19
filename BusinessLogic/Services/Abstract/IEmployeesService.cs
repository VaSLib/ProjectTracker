using BusinessLogic.Models;

namespace BusinessLogic.Services.Abstract
{
    /// <summary>
    /// Defines the contract for employee-related operations.
    /// </summary>
    public interface IEmployeesService
    {
        

        /// <summary>
        /// Updates an existing employee asynchronously.
        /// </summary>
        /// <param name="employee">The employee to update.</param>
        /// <returns>True if the employee was successfully updated; otherwise, false.</returns>
        Task<bool> UpdateEmployeeAsync(EmployeeBL employee);

        /// <summary>
        /// Retrieves a list of all employees asynchronously.
        /// </summary>
        /// <returns>A list of employees.</returns>
        Task<List<EmployeeBL>> GetEmployeesAsync();

        /// <summary>
        /// Retrieves an employee by their unique identifier asynchronously.
        /// </summary>
        /// <param name="employeeId">The unique identifier of the employee.</param>
        /// <returns>The employee with the specified identifier.</returns>
        Task<EmployeeBL> GetEmployeeByUserNameAsync(string UserName );

        /// <summary>
        /// Deletes an employee by their unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the employee to delete.</param>
        /// <returns>True if the employee was successfully deleted; otherwise, false.</returns>
        Task<bool> DeleteEmployeeByUserNameAsync(string UserName);
    }
}
