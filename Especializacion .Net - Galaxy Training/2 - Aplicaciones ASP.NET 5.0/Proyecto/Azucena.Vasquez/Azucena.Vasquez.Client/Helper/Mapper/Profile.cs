using Azucena.Vasquez.Client.Models;
using Azucena.Vasquez.Infrastructure.Data.University.Entities;

namespace Azucena.Vasquez.Client.Helper.Mapper
{
    public class Profile : AutoMapper.Profile
    {
        public Profile() {

            CreateMap<Users, UserViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<UserViewModel, Users>();

            CreateMap<ScoresViewModel, Scores>()
                .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
            CreateMap<Scores, ScoresViewModel>()
                .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

            CreateMap<Courses, CoursesViewModel>();
            CreateMap<CoursesViewModel, Courses>();

            CreateMap<Infrastructure.Data.University.Entities.Roles, RolesViewModel>();
            CreateMap<RolesViewModel, Infrastructure.Data.University.Entities.Roles>();

            CreateMap<UserRoles, UserRolesViewModel>();
            CreateMap<UserRolesViewModel, UserRoles>();

        }
        
    }
}
