using DataAccess.Entities;
namespace BusinessLogic.Models.Mappers
{
    /// <summary>
    /// Mapper class for converting between Employee and EmployeeEntity.
    /// </summary>
    public static class EmployeeMapper
    {
        /// <summary>
        /// Converts an Employee object to its corresponding EmployeeEntity.
        /// </summary>
        public static EmployeeEntity ToEntity(this EmployeeBL employee)
        {
            return new EmployeeEntity
            {
                Name = employee.Name,
                Surname = employee.Surname,
                Email = employee.Email,
                Patronymic = employee.Patronymic
            };
        }

        /// <summary>
        /// Converts an EmployeeEntity object to its corresponding Employee.
        /// </summary>
        public static EmployeeBL ToEmployeeBL(this EmployeeEntity employee)
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
