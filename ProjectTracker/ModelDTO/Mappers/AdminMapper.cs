using BusinessLogic.Models;


namespace ProjectTracker.ModelDTO.Mappers
{
    /// <summary>
    /// Provides static methods to map DTO objects to business logic objects for admin-related functionality.
    /// </summary>
    public static class AdminMapper
    {
        /// <summary>
        /// Maps a LoginRequest object to a LoginEmployeeBL object.
        /// </summary>
        /// <param name="model">The LoginRequest object to map.</param>
        /// <returns>The mapped LoginEmployeeBL object.</returns>
        public static LoginEmployeeBL ToModel(this LoginRequest model)
        {
            return new LoginEmployeeBL()
            {
                UserName = model.UserName,
                Password = model.Password,
            };
        }

        /// <summary>
        /// Maps a RegisterRequest object to an EmployeeBL object.
        /// </summary>
        /// <param name="registerRequest">The RegisterRequest object to map.</param>
        /// <returns>The mapped EmployeeBL object.</returns>
        public static EmployeeBL ToModel(this RegisterRequest registerRequest)
        {
            return new EmployeeBL()
            {
                UserName = registerRequest.UserName,
                Email = registerRequest.Email,
                Name = registerRequest.Name,
                Patronymic = registerRequest.Patronymic,
                Surname = registerRequest.Surname,
            };
        }
    }
}
