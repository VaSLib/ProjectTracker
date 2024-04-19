using BusinessLogic.Models;
using DataAccess.Entities;

namespace ProjectTracker.ModelDTO.Mappers
{
    public static class EmployeeMapper
    {
        /// <summary>
        /// Maps EmployeeRequest data to EmployeeBL model.
        /// </summary>
        /// <param name="employee">EmployeeRequest data.</param>
        /// <returns>EmployeeBL model.</returns>
        public static EmployeeBL ToModel (this EmployeeRequest employee)
        {
            return new EmployeeBL
            {
                Name = employee.Name,
                Surname = employee.Surname,
                Email = employee.Email,
                Patronymic = employee.Patronymic
            };
        }
        /// <summary>
        /// Maps EmployeeUpdate data to EmployeeBL model.
        /// </summary>
        /// <param name="employee">EmployeeUpdate data.</param>
        /// <returns>EmployeeBL model.</returns>
        public static EmployeeBL ToModel(this EmployeeUpdate employee)
        {
            return new EmployeeBL
            {
                UserName = employee.UserName,
                Name = employee.Name,
                Surname = employee.Surname,
                Email = employee.Email,
                Patronymic = employee.Patronymic
            };
        }

    }
}