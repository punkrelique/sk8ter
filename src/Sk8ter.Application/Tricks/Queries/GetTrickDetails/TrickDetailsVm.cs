using AutoMapper;
using Sk8ter.Application.Common.Mappings;
using Sk8ter.Domain.Entities;
using Sk8ter.Domain.Enums;

namespace Sk8ter.Application.Tricks.Queries.GetTrickDetails;

public class TrickDetailsVm : IMapFrom<Trick>
{
    public int Id { get; set; }
    public int Name { get; set; }
    public Difficulty Difficulty { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Trick, TrickDetailsVm>()
            .ForMember(trickVm => trickVm.Id, opt => opt.MapFrom(trick => trick.Id))
            .ForMember(trickVm => trickVm.Name, opt => opt.MapFrom(trick => trick.Name))
            .ForMember(trickVm => trickVm.Difficulty, opt => opt.MapFrom(trick => trick.Difficulty));
    }
}