using AutoMapper;
using Education.Application.DTO;
using Edutacion.Domain;

namespace Education.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Curso, CursoDTO>();
        }
    }
}
