using AutoMapper;
using Education.Application.DTO;
using Edutacion.Domain;

namespace Education.Aplication.Helper
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<Curso, CursoDTO>();
        }
    }
}
