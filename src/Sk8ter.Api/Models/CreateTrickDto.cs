using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Sk8ter.Application.Common.Mappings;
using Sk8ter.Application.Tricks.Commands.CreateTrick;
using Sk8ter.Domain.Enums;

namespace Sk8ter.Api.Models;

public class CreateTrickDto : IMapFrom<CreateTrickCommand>
{
    public string Name { get; set; }
    public Difficulty Difficulty { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateTrickDto, CreateTrickCommand>()
            .ForMember(command => command.Name, opt => opt.MapFrom(dto => dto.Name))
            .ForMember(command => command.Difficulty, opt => opt.MapFrom(dto => dto.Difficulty));
    }
}