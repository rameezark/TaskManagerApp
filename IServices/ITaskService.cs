using TaskManagerApp.Models;

namespace TaskManagerApp.IServices
{
    public interface ITaskService
    {
        Task<List<TaskModel>> GetAllTasks();
        Task<TaskModel> GetTaskById(int id);
        Task<bool> CreateNewTask(TaskModel data);
        Task<bool> UpdateTask(TaskModel data);
        Task<bool> DeleteTask(int id);
    }
}
