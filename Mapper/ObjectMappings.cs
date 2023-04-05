using AutoMapper;
using TaskManagerApp.DataModels;
using TaskManagerApp.Models;

namespace TaskManagerApp.Mapper
{
    public class ObjectMappings : Profile
    {
        public ObjectMappings()
        {
            this.CreateMap<ImageDataModel, ImageModel>().ReverseMap();
            this.CreateMap<TaskDataModel, TaskModel>().ReverseMap();
        }
    }
}
