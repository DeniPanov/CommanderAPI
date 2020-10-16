namespace Commander.Profiles
{
    using AutoMapper;
    using Commander.Dtos;
    using Commander.Models;

    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // source => destination
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}
