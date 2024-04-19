using BusinessLogic.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.ModelDTO;
using ProjectTracker.ModelDTO.Mappers;

namespace ProjectTracker.Controllers
{
    /// <summary>
    /// Controller for managing admin-related functionalities.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminSevice;

        public AdminController(IAdminService adminSevice)
        {
            _adminSevice = adminSevice;
        }

        /// <summary>
        /// Logs in an employee.
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> LoginEmployeeAsync([FromQuery] LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest();
            }

            var result = await _adminSevice.LoginEmployeeAsync(loginRequest.ToModel());

            if (result == false)
            {
                return NotFound("");
            }
            return Ok();
        }

        /// <summary>
        /// Registers a new employee.
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterEmployeeAsync([FromQuery] RegisterRequest registerRequest)
        {
            var result = await _adminSevice.RegisterEmployeeAsync(registerRequest.UserName, registerRequest.Password, registerRequest.Role, registerRequest.ToModel());
            if (result == false)
            {
                return BadRequest(registerRequest);
            }
            return Ok();
        }

        /// <summary>
        /// Logs off an employee.
        /// </summary>
        [HttpPost("logOff")]
        public async Task<IActionResult> LogOff()
        {
            await _adminSevice.LogOff();
            return Ok();
        }
    }
}
