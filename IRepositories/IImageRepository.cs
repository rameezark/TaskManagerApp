using TaskManagerApp.DataModels;

namespace TaskManagerApp.IRepositories
{
    public interface IImageRepository
    {
        Task<int> CreateNewImage(ImageDataModel data);
        Task<ImageDataModel> GetImageById(int id);
    }
}
