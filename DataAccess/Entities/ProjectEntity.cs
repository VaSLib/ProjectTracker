namespace DataAccess.Entities
{
    /// <summary>
    /// Represents a project entity in the data store.
    /// </summary>
    public class ProjectEntity
    {
        /// <summary>
        /// Unique identifier for the project.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of the company that is the customer for the project.
        /// </summary>
        public string CustomerCompanyName { get; set; }

        /// <summary>
        /// Name of the company that is the performer for the project.
        /// </summary>
        public string PerformerCompanyName { get; set; }

        /// <summary>
        /// Start date of the project.
        /// </summary>
        public DateTime ProjectStartDate { get; set; }

        /// <summary>
        /// Finish date of the project.
        /// </summary>
        public DateTime ProjectFinishDate { get; set; }

        /// <summary>
        /// Priority of the project.
        /// </summary>
        public int ProjectPriority { get; set; }

        /// <summary>
        /// List of employees associated with the project.
        /// </summary>
        public List<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();

        /// <summary>
        /// List of tasks associated with the project.
        /// </summary>
        public List<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
    }
}
