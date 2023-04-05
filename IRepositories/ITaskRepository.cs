using TaskManagerApp.DataModels;

namespace TaskManagerApp.IRepositories
{
    public interface ITaskRepository
    {
        Task<List<TaskDataModel>> GetAllTasks();
        Task<TaskDataModel> GetTaskById(int id);
        Task<bool> CreateNewTask(TaskDataModel data);
        Task<bool> UpdateTask(TaskDataModel data);
        Task<bool> DeleteTask(int id);
    }
}
