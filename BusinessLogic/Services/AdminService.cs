using BusinessLogic.Models;
using BusinessLogic.Models.Mappers;
using BusinessLogic.Services.Abstract;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BusinessLogic.Services
{
    public class AdminService:IAdminService
    {
        private readonly UserManager<EmployeeEntity> _userManager;
        private readonly SignInManager<EmployeeEntity> _signInManager;

        public AdminService(
            UserManager<EmployeeEntity> userManager,
            SignInManager<EmployeeEntity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> LoginEmployeeAsync(LoginEmployeeBL model)
        {

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return false;
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                return true;
            }

            return false;

        }

        public async Task<bool> RegisterEmployeeAsync(string userName, string password,string role, EmployeeBL employeeBL)
        {
            var user = employeeBL.ToEntity();
            user.UserName = userName;
            var result = await _userManager.CreateAsync(user,password);

            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));

                return true;
            }
            return false;
        }

        public async Task LogOff()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
