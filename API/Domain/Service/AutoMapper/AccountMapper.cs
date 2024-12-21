using AutoMapper;
using Domain.DTOs.AccountDTO;
using Domain.Entities;

public class AccountMapper: Profile
{
    public AccountMapper()
    {
        CreateMap<Account, AccountOutputDTO>()
           .ForMember(dest => dest.AvatarURL, opt => opt.MapFrom(src => src.avatar_url));
    }
}
