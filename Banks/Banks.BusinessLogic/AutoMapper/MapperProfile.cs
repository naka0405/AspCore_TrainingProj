using AutoMapper;
using Banks.Entities;
using Banks.ViewModels.Models;

namespace Banks.API.AutoMapper
{
    public class MapperProfile:Profile 
    {
        public MapperProfile()
        {
            CreateMap<Account, AccountVM>()
                .ForMember(x => x.ClientFullName, opt => opt
                  .MapFrom(src => src.Client.FirstName + " " + src.Client.LastName))
                .ReverseMap();                
        }
    }
}
