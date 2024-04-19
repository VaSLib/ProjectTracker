namespace BusinessLogic.Models
{
    /// <summary>
    /// Represents a employee for BL.
    /// </summary>

    public class EmployeeBL
    {
        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        public string UserName { get; set; }
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
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the list of projects associated with the employee.
        /// </summary>
        public List<ProjectBL> Projects { get; set; } 
    }


}
