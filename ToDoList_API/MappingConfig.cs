using AutoMapper;
using ToDoList_API.Models;
using ToDoList_API.Models.DTO;

namespace ToDoList_API
{
	public class MappingConfig : Profile
	{
        public MappingConfig()
        {
            CreateMap<ToDoListM, ToDoListMDTO>().ReverseMap();
			CreateMap<ToDoListM, ToDoListCreateDTO>().ReverseMap();
			CreateMap<ToDoListM, ToDoListUpdateDTO>().ReverseMap();
		}
    }
}
