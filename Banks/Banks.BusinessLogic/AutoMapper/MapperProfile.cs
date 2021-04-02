using AutoMapper;
using Banks.Entities;
using Banks.Entities.Entities;
using Banks.ViewModels.ViewModels.Account;
using Banks.ViewModels.ViewModels.Users;

namespace Banks.API.AutoMapper
{
    /// <summary>       
    /// Configuring mapper on some classes.
    /// </summary>
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Account, AccountGetAllAccountViewModelItem>()
                .ForMember (x => x.ClientFullName, opt => opt
                  .MapFrom(src => $"{src.Client.FirstName} { src.Client.LastName}"))
            .ForMember(x => x.BankId, opt => opt
              .MapFrom(src => src.Client.BankId))
            .ForMember(x => x.Code, opt => opt
              .MapFrom(src => src.Client.Code))
            .ForMember(x => x.Account, opt => opt
              .MapFrom(src => src.Number));

            CreateMap<CreateAccountViewModel, Account>()
                .ForMember(x => x.Number, opt => opt.MapFrom(src => src.Currency.ToString()+src.Number.ToString()))
                .ForMember(x => x.Currency, opt => opt.MapFrom(src => src.Currency));

            CreateMap<Account, GetByIdAccountViewModel>()
                .ForMember(x => x.ClientFullName, opt => opt
                  .MapFrom(src =>$"{src.Client.FirstName} { src.Client.LastName}"))
                .ForMember(x => x.Currency, opt => opt.MapFrom(src => src.Currency.ToString()));

            CreateMap<UpdateAccountViewModel, Account>()                
                .ForMember(x => x.Currency, opt => opt.MapFrom(src => src.Currency));

            CreateMap<User, JwtViewModel>();
        }
    }
}
