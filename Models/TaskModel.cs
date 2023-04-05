

namespace TaskManagerApp.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public bool HasImage { get; set; }
        public int? ImageId { get; set; }
    }
}
