using Microsoft.EntityFrameworkCore;
using TaskManagerApp.DataModels;

namespace TaskManagerApp.Repositories
{
    public class TaskDbContext :DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> context) : base(context)
        {

        }

        public DbSet<TaskDataModel> TaskDataModel { get; set; }
        public DbSet<ImageDataModel> ImageDataModel { get; set; }
    }
}
