using AutoMapper;
using ToDoList_WEB.Models.DTO;

namespace ToDoList_WEB
{
	public class MappingConfig : Profile
	{
        public MappingConfig()
        {
            CreateMap<ToDoListMDTO, ToDoListCreateDTO>().ReverseMap();
			CreateMap<ToDoListMDTO, ToDoListUpdateDTO>().ReverseMap();
		}
    }
}
