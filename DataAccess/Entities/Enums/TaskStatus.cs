using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Enums
{
    /// <summary>
    /// Represents the status of a task.
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// Task is yet to be started.
        /// </summary>
        ToDo,

        /// <summary>
        /// Task is currently in progress.
        /// </summary>
        InProgress,

        /// <summary>
        /// Task has been completed.
        /// </summary>
        Done
    }
}

