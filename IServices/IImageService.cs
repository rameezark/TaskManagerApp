using TaskManagerApp.Models;

namespace TaskManagerApp.IServices
{
    public interface IImageService
    {
        Task<int> CreateNewImage(ImageModel data);
        Task<ImageModel> GetImageById(int id);
    }
}
