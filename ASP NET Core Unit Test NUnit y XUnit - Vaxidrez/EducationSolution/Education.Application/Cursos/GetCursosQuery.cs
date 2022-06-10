using AutoMapper;
using Education.Application.DTO;
using Education.Persistence;
using Edutacion.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.Cursos
{
    public class GetCursosQuery
    {
        
        public class GetCursoQueryRequest : IRequest<List<CursoDTO>> { }

        public class GetCursoQueryHandler : IRequestHandler<GetCursoQueryRequest, List<CursoDTO>>
        {

            private readonly EducationDbContext _context;
            private readonly IMapper _mapper;

            public GetCursoQueryHandler(EducationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CursoDTO>> Handle(GetCursoQueryRequest request, CancellationToken cancellationToken)
            {
                var cursos = await _context.Cursos.ToListAsync();
                var cursosDTO = _mapper.Map<List<Curso>, List<CursoDTO>>(cursos);
                return cursosDTO;
            }

        }

    }
}
