using AppToDoList.Models;
using AppToDoList.Models.VMs;
using AutoMapper;

namespace AppToDoList.Maps
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AppTaskCreateVM, AppTask>().ReverseMap();

            CreateMap<AppTask, AppTaskListVM>().ReverseMap();
        }
    }
}
