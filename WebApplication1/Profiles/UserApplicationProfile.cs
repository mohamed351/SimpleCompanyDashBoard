using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Profiles
{
    public class UserApplicationProfile:Profile
    {
        public UserApplicationProfile()
        {

            this.CreateMap<RegistrationViewModel, ApplicationUser>()
            .ForMember(a => a.UserName, a => a.MapFrom(a => a.UserName))
            .ForMember(a => a.Email, a => a.MapFrom(a => a.Email))
            .ForMember(a => a.PhoneNumber, a => a.MapFrom(a => a.Phone));

            //this.CreateMap<ApplicationUser, RegistrationViewModel>().ReverseMap()
            //  .ForMember(a => a.UserName, a => a.MapFrom(a => a.UserName))
            //  .ForMember(a => a.Email, a => a.MapFrom(a => a.Email))
            //  .ForMember(a => a.PhoneNumber, a => a.MapFrom(a => a.Phone));

        }
    }
}
