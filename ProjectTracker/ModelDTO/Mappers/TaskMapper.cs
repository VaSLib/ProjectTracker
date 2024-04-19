using Azure.Core;
using BusinessLogic.Models;
using System.Threading.Tasks;

namespace ProjectTracker.ModelDTO.Mappers
{
    /// <summary>
    /// Provides static methods to map DTO objects to business logic objects and vice versa for tasks.
    /// </summary>
    public static class TaskMapper
    {
        /// <summary>
        /// Maps a TaskRequest object to a TaskBL object.
        /// </summary>
        /// <param name="task">The TaskRequest object to map.</param>
        /// <returns>The mapped TaskBL object.</returns>
        public static TaskBL ToModel(this TaskRequest task)
        {
            return new TaskBL
            {
                Name = task.Name,
                AuthorUserName = task.AuthorUserName,
                ExecutorUserName = task.ExecutorUserName,
                Comment = task.Comment,
                Priority = task.Priority,
                Status = task.Status,
                ProjectId = task.ProjectId,
            };
        }

        /// <summary>
        /// Maps a TaskUpdate object to a TaskBL object.
        /// </summary>
        /// <param name="task">The TaskUpdate object to map.</param>
        /// <returns>The mapped TaskBL object.</returns>
        public static TaskBL ToModel(this TaskUpdate task)
        {
            return new TaskBL
            {
                Id = task.Id,
                Name = task.Name,
                AuthorUserName = task.AuthorUserName,
                ExecutorUserName = task.ExecutorUserName,
                Comment = task.Comment,
                Priority = task.Priority,
                Status = task.Status
            };
        }

        /// <summary>
        /// Maps a TaskFilterOptionsRequest object to a TaskFilterOptionsBL object.
        /// </summary>
        /// <param name="request">The TaskFilterOptionsRequest object to map.</param>
        /// <returns>The mapped TaskFilterOptionsBL object.</returns>
        public static TaskFilterOptionsBL ToModel(this TaskFilterOptionsRequest request)
        {
            return new TaskFilterOptionsBL
            {
                AuthorUserName = request.AuthorUserName,
                ExecutorUserName = request.ExecutorUserName,
                Name = request.Name,
                SortBy = request.SortBy,
                Status = request.Status,
                Type = request.Type,
            };
        }
    }
}
