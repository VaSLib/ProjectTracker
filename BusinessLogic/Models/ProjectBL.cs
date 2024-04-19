namespace BusinessLogic.Models
{
    /// <summary>
    /// Represents a project for Bl.
    /// </summary>
    public class ProjectBL
    {
        /// <summary>
        /// Gets or sets the unique identifier of the project.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer company associated with the project.
        /// </summary>
        public string CustomerCompanyName { get; set; }

        /// <summary>
        /// Gets or sets the name of the performer company associated with the project.
        /// </summary>
        public string PerformerCompanyName { get; set; }

        /// <summary>
        /// Gets or sets the start date of the project.
        /// </summary>
        public DateTime ProjectStartDate { get; set; }

        /// <summary>
        /// Gets or sets the finish date of the project.
        /// </summary>
        public DateTime ProjectFinishDate { get; set; }

        /// <summary>
        /// Gets or sets the priority of the project.
        /// </summary>
        public int ProjectPriority { get; set; }

        /// <summary>
        /// Gets or sets the list of employees associated with the project.
        /// </summary>
        public List<EmployeeBL> Employees { get; set; }
    }
}

