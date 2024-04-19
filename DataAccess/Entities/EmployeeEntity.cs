
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities
{
    /// <summary>
    /// Represents an employee entity in the data store.
    /// </summary>
    public class EmployeeEntity:IdentityUser<Guid>
    {

        /// <summary>
        /// Name of the employee.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Surname of the employee.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Patronymic (middle name) of the employee.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Email address of the employee.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// List of projects associated with the employee.
        /// </summary>
        public List<ProjectEntity> Projects { get; set; }

    }
}

