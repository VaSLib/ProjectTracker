using DataAccess.Entities;

namespace BusinessLogic.Models
{
    /// <summary>
    /// Represents a task business logic entity.
    /// </summary>
    public class TaskBL
    {
        /// <summary>
        /// Gets or sets the unique identifier for the task.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the task.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ID of the author of the task.
        /// </summary>
        public string AuthorUserName { get; set; }

        /// <summary>
        /// Gets or sets the author of the task.
        /// </summary>
        public EmployeeEntity? Author { get; set; }

        

        /// <summary>
        /// Gets or sets the Id of the executor of the task.
        /// </summary>
        public string ExecutorUserName { get; set; }

        /// <summary>
        /// Gets or sets the executor of the task.
        /// </summary>
        public EmployeeEntity? Executor { get; set; }

        /// <summary>
        /// Gets or sets the status of the task.
        /// </summary>
        public TaskStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the ID of the project associated with the task.
        /// </summary>
        public int? ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the project associated with the task.
        /// </summary>
        public ProjectEntity? Project { get; set; }

        /// <summary>
        /// Gets or sets the comment related to the task.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the priority of the task.
        /// </summary>
        public int Priority { get; set; }
    }
}
