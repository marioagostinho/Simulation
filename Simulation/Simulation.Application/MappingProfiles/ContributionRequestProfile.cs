using AutoMapper;
using Simulation.Application.Dtos;
using Simulation.Domain.Entities;

namespace Simulation.Application.MappingProfiles
{
    public class ContributionRequestProfile : Profile
    {
        public ContributionRequestProfile()
        {
            CreateMap<ContributionRequest, ContributionRequestDto>()
                .ReverseMap();
        }
    }
}
