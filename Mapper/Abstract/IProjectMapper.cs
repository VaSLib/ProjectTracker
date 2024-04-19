
using BusinessLogic.DomainModels;
using DataAccess.Entities;

namespace Mapper.Abstract
{
    public interface IProjectMapper
    {
        ProjectEntity ToEntity(Project project);
    }
}
