using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.ModelDTO
{
    /// <summary>
    /// Represents the data model for an employee request.
    /// </summary>
    public class EmployeeRequest
    {
        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters")]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the patronymic name of the employee.
        /// </summary>
        [StringLength(50, ErrorMessage = "Patronymic must not exceed 50 characters")]
        public string Patronymic { get; set; }

        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100, ErrorMessage = "Email must not exceed 100 characters")]
        public string Email { get; set; }

    }
}
