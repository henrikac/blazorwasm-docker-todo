using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<TodoCreateDto, Todo>();
        }
    }
}