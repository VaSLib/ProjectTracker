using DataAccess.Entities;

namespace BusinessLogic.Models.Mappers
{
    /// <summary>
    /// Provides methods to map between TaskBL and TaskEntity objects.
    /// </summary>
    public static class TaskMapper
    {
        /// <summary>
        /// Converts a TaskBL object to a TaskEntity object.
        /// </summary>
        /// <param name="task">The TaskBL object to convert.</param>
        /// <returns>The TaskEntity object converted from the TaskBL object.</returns>
        public static TaskEntity ToEntity(this TaskBL task)
        {
            return new TaskEntity
            {
                Name = task.Name,
                Status = task.Status,
                AuthorUserName = task.AuthorUserName,
                Comment = task.Comment,
                ExecutorUserName = task.ExecutorUserName,
                Priority = task.Priority,
                ProjectId = task.ProjectId,
            };
        }

        /// <summary>
        /// Converts a TaskEntity object to a TaskBL object.
        /// </summary>
        /// <param name="task">The TaskEntity object to convert.</param>
        /// <returns>The TaskBL object converted from the TaskEntity object.</returns>
        public static TaskBL ToTaskBL(this TaskEntity task)
        {
            return new TaskBL
            {
                Id = task.Id,
                Name = task.Name,
                AuthorUserName = task.AuthorUserName,
                ExecutorUserName = task.ExecutorUserName,
                Priority = task.Priority,
                Comment = task.Comment,
                Status = task.Status,
                ProjectId = task.ProjectId,
            };
        }
    }
}
