using AutoMapper;
using Sk8ter.Application.Common.Mappings;
using Sk8ter.Application.Tricks.Commands.UpdateTrick;
using Sk8ter.Domain.Enums;

namespace Sk8ter.Api.Models;

public class UpdateTrickDto : IMapFrom<UpdateTrickCommand>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Difficulty Difficulty { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateTrickDto, UpdateTrickCommand>()
            .ForMember(command => command.Id, opt => opt.MapFrom(dto => dto.Id))
            .ForMember(command => command.Name, opt => opt.MapFrom(dto => dto.Name))
            .ForMember(command => command.Difficulty, opt => opt.MapFrom(dto => dto.Difficulty));
    }
}