using AutoMapper;
using TaskManagerApp.DataModels;
using TaskManagerApp.IRepositories;
using TaskManagerApp.IServices;
using TaskManagerApp.Models;

namespace TaskManagerApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            this._taskRepository = taskRepository;
            this._mapper = mapper;
        }

        public async Task<List<TaskModel>> GetAllTasks() =>
            this._mapper.Map<List<TaskModel>>(await this._taskRepository.GetAllTasks());
        public async Task<TaskModel> GetTaskById(int id) =>
            this._mapper.Map<TaskModel>(await _taskRepository.GetTaskById(id));

        public async Task<bool> CreateNewTask(TaskModel data) =>
            await _taskRepository.CreateNewTask(this._mapper.Map<TaskDataModel>(data));
        public async Task<bool> UpdateTask(TaskModel data) =>
            await _taskRepository.UpdateTask(this._mapper.Map<TaskDataModel>(data));

        public async Task<bool> DeleteTask(int id) =>
            await _taskRepository.DeleteTask(id);
    }
}
