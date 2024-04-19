using BusinessLogic.Models;

namespace BusinessLogic.Services.Abstract
{
    /// <summary>
    /// Interface for managing tasks.
    /// </summary>
    public interface ITaskService
    {
        /// <summary>
        /// Adds a new task asynchronously.
        /// </summary>
        /// <param name="task">The task to add.</param>
        /// <returns>The ID of the newly added task.</returns>
        Task<int> AddTaskAsync(TaskBL task);

        /// <summary>
        /// Deletes a task by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the task to delete.</param>
        /// <returns>True if the task is deleted successfully, otherwise false.</returns>
        Task<bool> DeleteTaskByIdAsync(int id);

        /// <summary>
        /// Retrieves a list of tasks based on filtering options asynchronously.
        /// </summary>
        /// <param name="taskFilterOptions">Options to filter and sort tasks.</param>
        /// <returns>A list of tasks that match the filter criteria.</returns>
        Task<List<TaskBL>> GetTasksAsync(TaskFilterOptionsBL taskFilterOptions);

        /// <summary>
        /// Retrieves a task by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the task to retrieve.</param>
        /// <returns>The task with the specified ID, or null if not found.</returns>
        Task<TaskBL> GetTaskByIdAsync(int id);

        /// <summary>
        /// Updates an existing task asynchronously.
        /// </summary>
        /// <param name="updatedTask">The updated task data.</param>
        /// <returns>True if the task is updated successfully, otherwise false.</returns>
        Task<bool> UpdateTaskAsync(TaskBL updatedTask);
    }
}

