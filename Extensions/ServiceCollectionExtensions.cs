using TaskManagerApp.IRepositories;
using TaskManagerApp.IServices;
using TaskManagerApp.Repositories;
using TaskManagerApp.Services;

namespace TaskManagerApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependentServices(this IServiceCollection service)
        {
            service.AddScoped<ITaskRepository, TaskRepository>();
            service.AddScoped<ITaskService, TaskService>();
            service.AddScoped<IImageService, ImageService>();
            service.AddScoped<IImageRepository, ImageRepository>();
            return service;
        }
    }
}
