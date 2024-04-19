using BusinessLogic.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using DataAccess.DataBase;
using BusinessLogic.Models;
using BusinessLogic.Models.Mappers;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Service class for managing projects.
    /// </summary>

    public class ProjectService : IProjectService
    {

        private readonly ApplicationDbContext _dbContext;

        private readonly UserManager<EmployeeEntity> _userManager;

        public ProjectService(ApplicationDbContext dbContext, UserManager<EmployeeEntity> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<int> AddProjectAsync(ProjectBL project)
        {

            var newProject = project.ToEntity();
            _dbContext.ProjectEntities.Add(newProject);
            await _dbContext.SaveChangesAsync();

            return newProject.Id;
        }

        public async Task<bool> DeleteProjectByIdAsync(int id)
        {
            var project = await _dbContext.ProjectEntities.FindAsync(id);
            if (project != null)
            {
                _dbContext.ProjectEntities.Remove(project);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ProjectBL>> GetProjectsAsync(ProjectFilterOptionsBL projectFilterOptions)
        {
            var queryProject = _dbContext.ProjectEntities.AsQueryable();

            if (projectFilterOptions.DateFrom != null)
            {
                queryProject = queryProject.Where(p => p.ProjectStartDate >= projectFilterOptions.DateFrom);
            }
            if (projectFilterOptions.DateTo != null)
            {
                queryProject = queryProject.Where(p => p.ProjectStartDate <= projectFilterOptions.DateTo);
            }

            if (projectFilterOptions.MinPriority != null)
            {
                queryProject = queryProject.Where(p => p.ProjectPriority >= projectFilterOptions.MinPriority);
            }
            if (projectFilterOptions.MaxPriority != null)
            {
                queryProject = queryProject.Where(p => p.ProjectPriority <= projectFilterOptions.MaxPriority);
            }


            switch (projectFilterOptions.SortBy)
            {
                case "name":
                    queryProject = projectFilterOptions.Type == true ? queryProject.OrderBy(p => p.Name) : queryProject.OrderByDescending(p => p.Name);
                    break;
                case "startDate":
                    queryProject = projectFilterOptions.Type == true ? queryProject.OrderBy(p => p.ProjectStartDate) : queryProject.OrderByDescending(p => p.ProjectStartDate);
                    break;
                case "priority":
                    queryProject = projectFilterOptions.Type == true ? queryProject.OrderBy(p => p.ProjectPriority) : queryProject.OrderByDescending(p => p.ProjectPriority);
                    break;
                default:
                    queryProject = projectFilterOptions.Type == true ? queryProject.OrderBy(p => p.Id) : queryProject.OrderByDescending(p => p.Id);
                    break;
            }
            var ListProjectEntity = await queryProject.ToListAsync();

            var ListProject = new List<ProjectBL>();

            foreach (var item in ListProjectEntity)
            {
                ListProject.Add(item.ToProject());
            }



            return ListProject;

        }

        public async Task<bool> UpdateProjectAsync(ProjectBL updatedProject)
        {
            var existingProject = await _dbContext.ProjectEntities.FindAsync(updatedProject.Id);


            if (existingProject == null)
            {
                return true;
            }
            existingProject.Name = updatedProject.Name;
            existingProject.CustomerCompanyName = updatedProject.CustomerCompanyName;
            existingProject.PerformerCompanyName = updatedProject.PerformerCompanyName;
            existingProject.ProjectStartDate = updatedProject.ProjectStartDate;
            existingProject.ProjectFinishDate = updatedProject.ProjectFinishDate;
            existingProject.ProjectPriority = updatedProject.ProjectPriority;

            await _dbContext.SaveChangesAsync();
            return false;
        }

        public async Task<ProjectBL> GetProjectByIdAsync(int id)
        {
            var project = await _dbContext.ProjectEntities.FindAsync(id);
            if (project == null)
            {
                return null;
            }

            return project.ToProject();
        }

        //////////////////////////////////////////////////

        public async Task<bool> AddEmployeeToProjectAsync(string userName, int idProject)
        {
            var project = await _dbContext.ProjectEntities.FindAsync(idProject);
            var employee = await _userManager.FindByNameAsync(userName);
            if (project == null)
            {
                return true;
            }
            if (employee == null)
            {
                return true;
            }
            project.Employees.Add(employee);
            _dbContext.SaveChanges();
            return false;

        }

        public async Task<List<EmployeeBL>> GetEmployeesToProjectAsync(int idProject)
        {
            var project = await _dbContext.ProjectEntities
                                            .Where(p => p.Id == idProject)
                                            .Include(p => p.Employees)
                                            .FirstOrDefaultAsync();

            if (project != null)
            {
                var employees = project.Employees
                                       .Select(employee => new EmployeeBL
                                       {
                                           Name = employee.Name,
                                           Surname = employee.Surname,
                                           Email = employee.Email,
                                           Patronymic = employee.Patronymic,
                                       })
                                       .ToList();

                return employees;
            }

            return null; 
        }

        public async Task<bool> DeleteEmployeeToProjectAsync(string userName, int idProject)
        {
            var project = await _dbContext.ProjectEntities.Include(p => p.Employees)
                                                          .FirstOrDefaultAsync(p => p.Id == idProject);
            var employee = await _userManager.FindByNameAsync(userName);

            if (project == null || employee == null)
            {
                return false; 
            }

            project.Employees.Remove(employee);

            await _dbContext.SaveChangesAsync(); 

            return true; 
        }

        public async Task<bool> DeleteTaskToProjectAsync(int idTask, int idProject)
        {
            var project = await _dbContext.ProjectEntities.Include(p => p.Tasks)
                                                          .FirstOrDefaultAsync(p => p.Id == idProject);
            var task = await _dbContext.TaskEntities.FindAsync(idTask);

            if (project == null || task == null)
            {
                return false;
            }

            project.Tasks.Remove(task);

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
