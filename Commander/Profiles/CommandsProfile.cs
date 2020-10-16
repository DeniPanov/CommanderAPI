namespace Commander.Profiles
{
    using AutoMapper;
    using Commander.Dtos;
    using Commander.Models;

    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDto>();
        }
    }
}
