using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.ModelDTO
{
    /// <summary>
    /// Represents the data model for filtering task options.
    /// </summary>
    public class TaskFilterOptionsRequest
    {
        /// <summary>
        /// Gets or sets the name for filtering tasks.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the status for filtering tasks.
        /// </summary>
        public TaskStatus? Status { get; set; }

        /// <summary>
        /// Gets or sets the author ID for filtering tasks.
        /// </summary>
        public string AuthorUserName { get; set; }

        /// <summary>
        /// Gets or sets the Id of the executor of the task.
        /// </summary>
        public string ExecutorUserName { get; set; }

        /// <summary>
        /// Gets or sets the field to sort tasks by.
        /// </summary>
        [StringLength(100, ErrorMessage = "SortBy cannot exceed 100 characters")]
        public string SortBy { get; set; }

        /// <summary>
        /// Gets or sets the type of sorting (ascending or descending).
        /// </summary>
        public bool Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskFilterOptionsRequest"/> class with default values.
        /// </summary>
        public TaskFilterOptionsRequest()
        {
            Name = string.Empty;
            Status = null;
            SortBy = string.Empty;
            Type = true;
        }
    }
}

