using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerApp.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
