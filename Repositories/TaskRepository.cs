using Microsoft.EntityFrameworkCore;
using TaskManagerApp.DataModels;
using TaskManagerApp.IRepositories;

namespace TaskManagerApp.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _dbContext;
        public TaskRepository(TaskDbContext dbContext)
        {
            this._dbContext = dbContext;
            _dbContext.ChangeTracker.Clear();
        }
        public async Task<List<TaskDataModel>> GetAllTasks() => 
            await this._dbContext.TaskDataModel.ToListAsync();
        public async Task<TaskDataModel> GetTaskById(int id) => 
            await _dbContext.TaskDataModel.Where(x=>x.Id == id).FirstOrDefaultAsync();

        public async Task<bool> CreateNewTask(TaskDataModel data)
        {
            try
            {
                _dbContext.Add(data);
                await this._dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateTask(TaskDataModel data)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Update(data);
                await this._dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteTask(int id)
        {
            try
            {
                var data = _dbContext.TaskDataModel.Where(x => x.Id == id).FirstOrDefault();
                if (data!=null)
                {
                    _dbContext.TaskDataModel.Remove(data);
                    await this._dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
