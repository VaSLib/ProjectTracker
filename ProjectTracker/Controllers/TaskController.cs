using BusinessLogic.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.ModelDTO;
using ProjectTracker.ModelDTO.Mappers;

namespace ProjectTracker.Controllers
{
    /// <summary>
    /// Controller for managing tasks.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Adds a new task.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddTask(TaskRequest task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            var newProjectId = await _taskService.AddTaskAsync(task.ToModel());
            return Ok(newProjectId);
        }

        /// <summary>
        /// Gets a task by its identifier.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound("Task with the specified Id not found");
            }
            return Ok(task);
        }

        /// <summary>
        /// Deletes a task by its identifier.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskById(int id)
        {
            if (await _taskService.DeleteTaskByIdAsync(id))
            {
                return NoContent();
            }
            return NotFound("Task with the specified Id not found");
        }

        /// <summary>
        /// Updates a task.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateTask(TaskUpdate task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            var noObjectFound = await _taskService.UpdateTaskAsync(task.ToModel());

            if (noObjectFound == true)
            {
                return NotFound("Task with the specified Id not found");
            }
            return Ok();
        }

        /// <summary>
        /// Gets all tasks based on the provided filter options.
        /// </summary>
        [HttpGet("all")]
        public async Task<IActionResult> GetTasks([FromQuery] TaskFilterOptionsRequest taskFilterOptionsRequest)
        {
            var task = await _taskService.GetTasksAsync(taskFilterOptionsRequest.ToModel());
            return Ok(task);
        }
    }
}
