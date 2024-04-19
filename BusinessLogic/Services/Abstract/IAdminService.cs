using BusinessLogic.Models;

namespace BusinessLogic.Services.Abstract
{
    /// <summary>
    /// Interface for admin-related services.
    /// </summary>
    public interface IAdminService
    {
        /// <summary>
        /// Logs in an employee asynchronously.
        /// </summary>
        /// <param name="model">The login credentials of the employee.</param>
        /// <returns>True if the employee is successfully logged in, otherwise false.</returns>
        Task<bool> LoginEmployeeAsync(LoginEmployeeBL model);

        /// <summary>
        /// Registers a new employee asynchronously.
        /// </summary>
        /// <param name="userName">The username of the new employee.</param>
        /// <param name="password">The password of the new employee.</param>
        /// <param name="role">The role of the new employee.</param>
        /// <param name="employeeBL">The data of the new employee.</param>
        /// <returns>True if the employee is registered successfully, otherwise false.</returns>
        Task<bool> RegisterEmployeeAsync(string userName, string password, string role, EmployeeBL employeeBL);

        /// <summary>
        /// Logs off the current session asynchronously.
        /// </summary>
        Task LogOff();
    }
}
