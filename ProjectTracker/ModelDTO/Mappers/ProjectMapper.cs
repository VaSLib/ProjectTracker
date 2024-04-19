using BusinessLogic.Models;

namespace ProjectTracker.ModelDTO.Mappers
{
    /// <summary>
    /// Provides methods to map DTOs (Data Transfer Objects) to corresponding domain models.
    /// </summary>
    public static class ProjectMapper
    {
        /// <summary>
        /// Maps a <see cref="ProjectRequest"/> object to a <see cref="ProjectBL"/> model.
        /// </summary>
        public static ProjectBL ToModel(this ProjectRequest request)
        {
            return new ProjectBL
            {
                Name = request.Name,
                CustomerCompanyName = request.CustomerCompanyName,
                PerformerCompanyName = request.PerformerCompanyName,
                ProjectStartDate = request.ProjectStartDate,
                ProjectFinishDate = request.ProjectFinishDate,
                ProjectPriority = request.ProjectPriority
            };
        }

        /// <summary>
        /// Maps a <see cref="ProjectUpdate"/> object to a <see cref="ProjectBL"/> model.
        /// </summary>
        public static ProjectBL ToModel(this ProjectUpdate request)
        {
            return new ProjectBL
            {
                Id = request.Id,
                Name = request.Name,
                CustomerCompanyName = request.CustomerCompanyName,
                PerformerCompanyName = request.PerformerCompanyName,
                ProjectStartDate = request.ProjectStartDate,
                ProjectFinishDate = request.ProjectFinishDate,
                ProjectPriority = request.ProjectPriority
            };
        }

        /// <summary>
        /// Maps a <see cref="ProjectFilterOptionsRequest"/> object to a <see cref="ProjectFilterOptionsBL"/> model.
        /// </summary>
        public static ProjectFilterOptionsBL ToModel(this ProjectFilterOptionsRequest request)
        {
            return new ProjectFilterOptionsBL
            {
                DateFrom = request.DateFrom,
                DateTo = request.DateTo,
                MaxPriority = request.MaxPriority,
                MinPriority = request.MinPriority,
                SortBy = request.SortBy,
                Type = request.Type,
            };
        }
    }
}