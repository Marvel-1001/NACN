using AutoMapper;
using BackEndAPI.DTOs;
using BackEndAPI.Models;
using System.Globalization;

namespace BackEndAPI.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //mapping
            #region Membertype
            CreateMap<MemberType, MemberTypeDTO>().ReverseMap();
            #endregion

            #region Member
            CreateMap<Member, MemberDTO>()
                .ForMember(destiny =>
                    destiny.MembertypeName,
                    opt => opt.MapFrom(origin => origin.IdMembertypeNavigation.Name)
                )
                .ForMember(destiny =>
                    destiny.FinancialYear,
                    opt => opt.MapFrom(origin => origin.FinancialYear.Value.ToString("dd/MM/yyyy"))
                );

            CreateMap<MemberDTO, Member>()
                .ForMember(destiny =>
                    destiny.IdMembertypeNavigation,
                    opt => opt.Ignore()
                 );
               
            #endregion
        }
    }
}
