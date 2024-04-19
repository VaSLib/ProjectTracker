using BusinessLogic.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.ModelDTO;
using ProjectTracker.ModelDTO.Mappers;
namespace ProjectTracker.Controllers
{
    /// <summary>
    /// Controller for managing projects.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectControllers : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectControllers(IProjectService projectService)
        {
            _projectService = projectService;
        }

        /// <summary>
        /// Returns a sorted list of projects according to the specified parameters.
        /// </summary>
        /// <param name="projectFilterOptions">Parameters for filtering and sorting projects.</param>
        /// <returns>Returns a list of sorted projects.</returns>
        [HttpGet("sort")]
        public async Task<IActionResult> SortProjects([FromQuery] ProjectFilterOptionsRequest projectFilterOptions)
        {
            var projects = await _projectService.GetProjectsAsync(projectFilterOptions.ToModel());
            return Ok(projects);
        }

        /// <summary>
        /// Adds a new project.
        /// </summary>
        /// <param name="project">Data of the new project to add.</param>
        /// <returns>Returns the Id of the new project upon successful addition.</returns>
        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectRequest project)
        {
            if (project == null)
            {
                return BadRequest();
            }

            var newProjectId = await _projectService.AddProjectAsync(project.ToModel());
            return Ok(newProjectId);
        }

        /// <summary>
        /// Updates project data.
        /// </summary>
        /// <param name="project">The project data to update.</param>
        /// <returns>Returns BadRequest (400) if the project data is missing. Returns NotFound (404) if the project with the specified Id is not found. Returns Ok (200) upon successful update.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProject(ProjectUpdate project)
        {
            if (project == null)
            {
                return BadRequest();
            }

            var noObjectFound = await _projectService.UpdateProjectAsync(project.ToModel());

            if (noObjectFound == true)
            {
                return NotFound("Project with the specified Id not found");
            }
            return Ok();
        }

        /// <summary>
        /// Deletes a project by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the project.</param>
        /// <returns>Returns NoContent (204) if the project is successfully deleted, and NotFound (404) if the project with the specified Id is not found.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectById(int id)
        {
            if (await _projectService.DeleteProjectByIdAsync(id))
            {
                return NoContent();
            }
            return NotFound("Project with the specified Id not found");
        }

        /// <summary>
        /// Retrieves a project by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the project.</param>
        /// <returns>The requested project or a NotFound error if the project is not found.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound("Project with the specified Id not found");
            }
            return Ok(project);
        }

        /// <summary>
        /// Adds an employee to a project.
        /// </summary>
        [HttpPut("{UserName}-{idProject}")]
        public async Task<IActionResult> AddEmployeeToProject(string UserName, int idProject)
        {
            var notFound = await _projectService.AddEmployeeToProjectAsync(UserName, idProject);
            if (notFound)
            {
                return NotFound("The project or employee with the specified ID was not found");
            }
            return Ok();
        }

        /// <summary>
        /// Retrieves employees associated with a project.
        /// </summary>
        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployeesToProject(int idProject)
        {
            var employees = await _projectService.GetEmployeesToProjectAsync(idProject);
            return Ok(employees);
        }

        /// <summary>
        /// Deletes an employee from a project.
        /// </summary>
        [HttpPut("delete/{UserName}/{idProject}")]
        public async Task<IActionResult> DeleteEmployeeToProject(string UserName, int idProject)
        {
            var deleted = await _projectService.DeleteEmployeeToProjectAsync(UserName, idProject);
            if (!deleted)
            {
                return NotFound("The project or employee with the specified ID was not found");
            }
            return Ok();
        }

        /// <summary>
        /// Deletes a task from a project.
        /// </summary>
        [HttpPut("deleteTask/{idTask}/{idProject}")]
        public async Task<IActionResult> DeleteTaskToProject(int idTask, int idProject)
        {
            var deleted = await _projectService.DeleteTaskToProjectAsync(idTask, idProject);
            if (!deleted)
            {
                return NotFound("The project or task with the specified ID was not found");
            }
            return Ok();
        }
    }
}
