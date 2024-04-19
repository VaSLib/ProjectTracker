using BusinessLogic.Models;

namespace BusinessLogic.Services.Abstract
{
    /// <summary>
    /// Interface for project-related services.
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// Adds a new project asynchronously.
        /// </summary>
        /// <param name="project">The project to add.</param>
        /// <returns>The ID of the newly added project.</returns>
        Task<int> AddProjectAsync(ProjectBL project);

        /// <summary>
        /// Updates an existing project asynchronously.
        /// </summary>
        /// <param name="project">The project to update.</param>
        /// <returns>True if the project was updated successfully, otherwise false.</returns>
        Task<bool> UpdateProjectAsync(ProjectBL project);

        /// <summary>
        /// Retrieves a list of projects asynchronously based on the specified filter options.
        /// </summary>
        /// <param name="projectFilterOptions">Filter options for retrieving projects.</param>
        /// <returns>A list of projects based on the filter options.</returns>
        Task<List<ProjectBL>> GetProjectsAsync(ProjectFilterOptionsBL projectFilterOptions);

        /// <summary>
        /// Retrieves a project asynchronously by its ID.
        /// </summary>
        /// <param name="id">The ID of the project to retrieve.</param>
        /// <returns>The project with the specified ID.</returns>
        Task<ProjectBL> GetProjectByIdAsync(int id);

        /// <summary>
        /// Deletes a project asynchronously by its ID.
        /// </summary>
        /// <param name="id">The ID of the project to delete.</param>
        /// <returns>True if the project was deleted successfully, otherwise false.</returns>
        Task<bool> DeleteProjectByIdAsync(int id);

        /// <summary>
        /// Adds an employee to a project asynchronously.
        /// </summary>
        /// <param name="idEmployee">The ID of the employee to add.</param>
        /// <param name="idProject">The ID of the project to add the employee to.</param>
        /// <returns>True if the employee was added to the project successfully, otherwise false.</returns>
        Task<bool> AddEmployeeToProjectAsync(string userName, int idProject);

        /// <summary>
        /// Retrieves a list of employees associated with a project asynchronously.
        /// </summary>
        /// <param name="idProject">The ID of the project.</param>
        /// <returns>A list of employees associated with the project.</returns>
        Task<List<EmployeeBL>> GetEmployeesToProjectAsync(int idProject);

        /// <summary>
        /// Deletes an employee from a project asynchronously.
        /// </summary>
        /// <param name="idEmployee">The ID of the employee to delete.</param>
        /// <param name="idProject">The ID of the project from which to delete the employee.</param>
        /// <returns>True if the employee was deleted from the project successfully, otherwise false.</returns>
        Task<bool> DeleteEmployeeToProjectAsync(string userName, int idProject);

        /// <summary>
        /// Deletes a task from a project asynchronously.
        /// </summary>
        /// <param name="idTask">The ID of the task to delete.</param>
        /// <param name="idProject">The ID of the project from which to delete the task.</param>
        /// <returns>True if the task was deleted from the project successfully, otherwise false.</returns>
        Task<bool> DeleteTaskToProjectAsync(int idTask, int idProject);
    }
}
