namespace BusinessLogic.Models
{
    /// <summary>
    /// Represents filter options for tasks.
    /// </summary>
    public class TaskFilterOptionsBL
    {
        /// <summary>
        /// Gets or sets the name to filter tasks.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the status to filter tasks.
        /// </summary>
        public TaskStatus? Status { get; set; }

        /// <summary>
        /// Gets or sets the ID of the author to filter tasks.
        /// </summary>
        public string AuthorUserName { get; set; }

        /// <summary>
        /// Gets or sets the Id of the executor of the task.
        /// </summary>
        public string ExecutorUserName { get; set; }

        /// <summary>
        /// Gets or sets the field to sort the tasks by.
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to sort in ascending order.
        /// </summary>
        public bool Type { get; set; }
    }
}

