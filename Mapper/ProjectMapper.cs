

using BusinessLogic.DomainModels;
using DataAccess.Entities;
using Mapper.Abstract;

namespace Mappers
{
    public static class ProjectMapper
    {
        public static ProjectEntity ToEntity(this Project project)
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
    }
}