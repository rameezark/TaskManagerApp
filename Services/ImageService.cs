using AutoMapper;
using TaskManagerApp.DataModels;
using TaskManagerApp.IRepositories;
using TaskManagerApp.IServices;
using TaskManagerApp.Models;
using TaskManagerApp.Repositories;

namespace TaskManagerApp.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        public ImageService(IImageRepository imageRepository, IMapper mapper)
        {
            this._imageRepository = imageRepository;
            this._mapper = mapper;
        }

        public async Task<int> CreateNewImage(ImageModel data) =>
          await _imageRepository.CreateNewImage(this._mapper.Map<ImageDataModel>(data));

        public async Task<ImageModel> GetImageById(int id) =>
           this._mapper.Map<ImageModel>(await _imageRepository.GetImageById(id));
    }
}
