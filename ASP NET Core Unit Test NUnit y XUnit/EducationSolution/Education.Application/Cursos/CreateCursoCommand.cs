using Education.Persistence;
using Edutacion.Domain;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.Cursos
{
    public class CreateCursoCommand
    {
        
        public class CreateCursoCommandRequest : IRequest {
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public DateTime FechaPublicacion { get; set; }
            public decimal Precio { get; set; }
        }

        public class CreatecursoCommandRequestValidation : AbstractValidator<CreateCursoCommandRequest> {
            
            public CreatecursoCommandRequestValidation()
            {
                RuleFor(x => x.Descripcion);
                RuleFor(x => x.Titulo);
            }

        }

        public class CreatecursoCommandHandler : IRequestHandler<CreateCursoCommandRequest>
        {

            private readonly EducationDbContext _context;

            public CreatecursoCommandHandler(EducationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateCursoCommandRequest request, CancellationToken cancellationToken)
            {
                
                var curso = new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Titulo = request.Titulo,
                    Descripcion = request.Descripcion,
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = request.FechaPublicacion,
                    Precio = request.Precio,
                };

                await _context.AddAsync(curso);
                var valor = await _context.SaveChangesAsync();

                if(valor > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el curso");

            }
        }

    }
}
