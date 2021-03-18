using AutoMapper;
using Banks.Entities;
using Banks.ViewModels.Models;
using Banks.ViewModels.ViewModels.Account;

namespace Banks.API.AutoMapper
{
    /// <summary>       
    /// Configuring mapper on some classes
    /// </summary>
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Account, AccountGetAllAccountViewModelItem>()
                .ForMember(x => x.ClientFullName, opt => opt
                  .MapFrom(src => src.Client.FirstName + " " + src.Client.LastName))
            .ForMember(x => x.BankId, opt => opt
              .MapFrom(src => src.Client.BankId))
            .ForMember(x => x.Code, opt => opt
              .MapFrom(src => src.Client.Code))
            .ForMember(x => x.Account, opt => opt
              .MapFrom(src => src.Number))
                .ReverseMap();

            CreateMap<CreateAccountViewModel, Account>()
                .ForMember(x => x.Number, opt => opt.MapFrom(src => src.Account))
                .ForMember(x => (int)x.Currency, opt => opt.MapFrom(src => src.CurrencyCode))
                .ReverseMap();

            CreateMap<DeleteAccountViewModel, Account>();

            CreateMap<Account, GetByIdAccountViewModel>()
                .ForMember(x => x.ClientFullName, opt => opt
                  .MapFrom(src => src.Client.FirstName + " " + src.Client.LastName))
                .ForMember(x => x.Currency, opt => opt.MapFrom(src => src.Currency.ToString()));

            CreateMap<UpdateAccountViewModel, Account>()                
                .ForMember(x => (int)x.Currency, opt => opt.MapFrom(src => src.Currency));
        }
    }
}
