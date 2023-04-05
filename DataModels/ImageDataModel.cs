using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerApp.DataModels
{
    public class ImageDataModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
