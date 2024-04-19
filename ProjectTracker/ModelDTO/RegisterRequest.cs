using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.ModelDTO
{
    public class RegisterRequest
    {
        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the patronymic name of the employee.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the list of projects associated with the employee.
        /// </summary>
    }
}
