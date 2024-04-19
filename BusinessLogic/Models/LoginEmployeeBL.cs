namespace BusinessLogic.Models
{
    /// <summary>
    /// Represents login credentials for an employee.
    /// </summary>
    public class LoginEmployeeBL
    {
        /// <summary>
        /// Gets or sets the username of the employee.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password of the employee.
        /// </summary>
        public string Password { get; set; }
    }
}
