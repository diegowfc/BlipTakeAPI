using AutoMapper;
using Domain.DTOs.RepositoryDTO;
using Domain.Entities.Repository;

public class RepositoryMapper: Profile
{
    public RepositoryMapper()
    {
        CreateMap<Repository, RepositoryDTO>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
           .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description));
    }
}
