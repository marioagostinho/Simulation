using AutoMapper;
using Simulation.Application.Dtos;
using Simulation.Domain.Entities;

namespace Simulation.Application.MappingProfiles
{
    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            CreateMap<Asset, AssetDto>()
                .ReverseMap();
        }
    }
}
