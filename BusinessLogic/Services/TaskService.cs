using BusinessLogic.Models;
using BusinessLogic.Models.Mappers;
using BusinessLogic.Services.Abstract;
using DataAccess.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Service for managing tasks.
    /// </summary>
    public class TaskService:ITaskService
    {
        private readonly ApplicationDbContext _dbContext;

        public TaskService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddTaskAsync(TaskBL task)
        {

            var newTask = task.ToEntity();
            _dbContext.TaskEntities.Add(newTask);
            await _dbContext.SaveChangesAsync();

            return newTask.Id;
        }




        public async Task<bool> DeleteTaskByIdAsync(int id)
        {
            var task = await _dbContext.TaskEntities.FindAsync(id);
            if (task != null)
            {
                _dbContext.TaskEntities.Remove(task);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<TaskBL>> GetTasksAsync(TaskFilterOptionsBL taskFilterOptions)
        {
            var query = _dbContext.TaskEntities.AsQueryable();

            if (!string.IsNullOrEmpty(taskFilterOptions.Name))
            {
                query = query.Where(t => t.Name.Contains(taskFilterOptions.Name));
            }
            if (taskFilterOptions.Status != null)
            {
                query = query.Where(t => t.Status == taskFilterOptions.Status);
            }
            if (taskFilterOptions.AuthorUserName != null)
            {
                query = query.Where(t => t.AuthorUserName == taskFilterOptions.AuthorUserName);
            }
            if (taskFilterOptions.ExecutorUserName != null)
            {
                query = query.Where(t => t.ExecutorUserName == taskFilterOptions.ExecutorUserName);
            }

            switch (taskFilterOptions.SortBy)
            {
                case "name":
                    query = taskFilterOptions.Type == true ? query.OrderBy(t => t.Name) : query.OrderByDescending(t => t.Name);
                    break;
                case "status":
                    query = taskFilterOptions.Type == true ? query.OrderBy(t => t.Status) : query.OrderByDescending(t => t.Status);
                    break;
                case "priority":
                    query = taskFilterOptions.Type == true ? query.OrderBy(t => t.Priority) : query.OrderByDescending(t => t.Priority);
                    break;
                default:
                    query = taskFilterOptions.Type == true ? query.OrderBy(t => t.Id) : query.OrderByDescending(t => t.Id);
                    break;
            }

            var taskEntities = await query.ToListAsync();

            var tasks = taskEntities.Select(t => t.ToTaskBL()).ToList();

            return tasks;
        }


        public async Task<TaskBL> GetTaskByIdAsync(int id)
        {
            var taskEntity = await _dbContext.TaskEntities.FindAsync(id);
            if (taskEntity == null)
            {
                return null;
            }

            var task = taskEntity.ToTaskBL(); 
            return task;
        }


        public async Task<bool> UpdateTaskAsync(TaskBL updatedTask)
        {
            var existingTask = await _dbContext.TaskEntities.FindAsync(updatedTask.Id);


            if (existingTask == null)
            {
                return true;
            }
            existingTask.Name = updatedTask.Name;
            existingTask.AuthorUserName = updatedTask.AuthorUserName;
            existingTask.ExecutorUserName = updatedTask.ExecutorUserName;
            existingTask.Status = updatedTask.Status;
            existingTask.Comment = updatedTask.Comment;
            existingTask.Priority = updatedTask.Priority;

            await _dbContext.SaveChangesAsync();
            return false;
        }
    }
}
