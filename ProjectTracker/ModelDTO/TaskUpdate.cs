using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.ModelDTO
{
    /// <summary>
    /// Represents the data model for updating a task.
    /// </summary>
    public class TaskUpdate
    {
        /// <summary>
        /// Gets or sets the Id of the task.
        /// </summary>
        [Required(ErrorMessage = "Id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Id must be a positive number")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the task.
        /// </summary>
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Id of the author of the task.
        /// </summary>
        public string AuthorUserName { get; set; }

        /// <summary>
        /// Gets or sets the Id of the executor of the task.
        /// </summary>
        public string ExecutorUserName { get; set; }

        /// <summary>
        /// Gets or sets the status of the task.
        /// </summary>
        [EnumDataType(typeof(TaskStatus), ErrorMessage = "Invalid TaskStatus value")]
        public TaskStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the comment for the task.
        /// </summary>
        [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters")]
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the priority of the task.
        /// </summary>
        [Required(ErrorMessage = "Priority is required")]
        [Range(1, 10, ErrorMessage = "Priority must be between 1 and 10")]
        public int Priority { get; set; }
    }

}
