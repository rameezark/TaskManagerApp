using Microsoft.EntityFrameworkCore;
using TaskManagerApp.DataModels;
using TaskManagerApp.IRepositories;

namespace TaskManagerApp.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly TaskDbContext _dbContext;
        public ImageRepository(TaskDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<int> CreateNewImage(ImageDataModel data)
        {
            try
            {
                _dbContext.Add(data);
                await this._dbContext.SaveChangesAsync();
                return data.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ImageDataModel> GetImageById(int id) =>
          await _dbContext.ImageDataModel.Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}
