using DataAccess.Entities;

namespace BusinessLogic.Models.Mappers
{
    public static class Mapper
    {
        /// <summary>
        /// Converts a Project model to a ProjectEntity entity.
        /// </summary>
        public static ProjectEntity ToEntity(this ProjectBL project)
        {
            return new ProjectEntity
            {
                Name = project.Name,
                CustomerCompanyName = project.CustomerCompanyName,
                PerformerCompanyName = project.PerformerCompanyName,
                ProjectStartDate = project.ProjectStartDate,
                ProjectFinishDate = project.ProjectFinishDate,
                ProjectPriority = project.ProjectPriority
                
            };
        }

        /// <summary>
        /// Converts a ProjectEntity entity to a Project model.
        /// </summary>
        public static ProjectBL ToProject(this ProjectEntity projectEntity)
        {
            return new ProjectBL
            {
                Id = projectEntity.Id,
                Name = projectEntity.Name,
                CustomerCompanyName = projectEntity.CustomerCompanyName,
                PerformerCompanyName = projectEntity.PerformerCompanyName,
                ProjectStartDate = projectEntity.ProjectStartDate,
                ProjectFinishDate = projectEntity.ProjectFinishDate,
                ProjectPriority = projectEntity.ProjectPriority
            };
        }
    }
}

