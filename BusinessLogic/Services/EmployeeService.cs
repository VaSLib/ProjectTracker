using BusinessLogic.Models;
using BusinessLogic.Models.Mappers;
using BusinessLogic.Services.Abstract;
using DataAccess.DataBase;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Service for handling employee-related operations.
    /// </summary>
    public class EmployeeService : IEmployeesService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<EmployeeEntity> _userManager;

        public EmployeeService(ApplicationDbContext dbContext, UserManager<EmployeeEntity> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }



        public async Task<bool> DeleteEmployeeByUserNameAsync(string UserName)
        {
            var employee = await _dbContext.EmployeeEntities.FindAsync(UserName);
            if (employee != null)
            {
                _dbContext.EmployeeEntities.Remove(employee);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<EmployeeBL>> GetEmployeesAsync()
        { 
            var employeeEntities = await _dbContext.EmployeeEntities.ToListAsync();

            if (employeeEntities== null)
            {
                return new List<EmployeeBL>();
            }

            var employeeList = new List<EmployeeBL>();

            foreach (var item in employeeEntities)
            {
                employeeList.Add(item.ToEmployeeBL());
            }

            return employeeList;
        }

        public async Task<EmployeeBL> GetEmployeeByUserNameAsync(string UserName)
        {
            var employeeEntity = await _userManager.FindByNameAsync(UserName);
            if (employeeEntity == null)
            {
                return null;
            }

            var emoloyee = employeeEntity.ToEmployeeBL();

            return emoloyee;
        }

        public async Task<bool> UpdateEmployeeAsync( EmployeeBL updatedEmployee)
        {
            var existingEmployee = await _userManager.FindByNameAsync(updatedEmployee.UserName);


            if (existingEmployee == null)
            {
                return false;
            }
            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Surname = updatedEmployee.Surname;
            existingEmployee.Email = updatedEmployee.Email;
            existingEmployee.Patronymic = updatedEmployee.Patronymic;
           
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
