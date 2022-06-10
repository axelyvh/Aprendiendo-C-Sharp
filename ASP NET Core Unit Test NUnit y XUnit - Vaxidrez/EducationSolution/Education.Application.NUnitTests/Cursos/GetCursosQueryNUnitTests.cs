using AutoFixture;
using AutoMapper;
using Education.Aplication.Helper;
using Education.Application.Cursos;
using Education.Persistence;
using Edutacion.Domain;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Education.Aplication.Cursos
{
    [TestFixture]
    public class GetCursosQueryNUnitTests
    {

        private GetCursosQuery.GetCursoQueryHandler handlerAllCursos;

        [SetUp]
        public void Setup() {

            var fixture = new Fixture();
            var cursoRecords = fixture.CreateMany<Curso>().ToList();

            cursoRecords.Add(fixture.Build<Curso>().With(tr => tr.CursoId, Guid.Empty).Create());

            var options = new DbContextOptionsBuilder<EducationDbContext>()
                          .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}")
                          .Options;

            var educationDbContextFake = new EducationDbContext(options);
            educationDbContextFake.Cursos.AddRange(cursoRecords);
            educationDbContextFake.SaveChanges();

            var mapConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingTest()); 
            });

            var mapper = mapConfig.CreateMapper();

            handlerAllCursos = new GetCursosQuery.GetCursoQueryHandler(educationDbContextFake, mapper);

        }

        [Test]
        public async Task GetCursoQueryHandler_ConsultaCursos_ReturnsTrue() {

            // 1. Emular al context que representa la instancia de EF - Listo

            // 2. Emular al mapping profile - Listo

            // 3. Instanciar un objeto de la clase GetCursosQueryHandler y pasarle como parametros los objectos context y mapping
            // GetCursosQueryHandler(context, mapping) => handle

            GetCursosQuery.GetCursoQueryRequest request = new();
            var resultados = await handlerAllCursos.Handle(request, new System.Threading.CancellationToken());

            Assert.IsNotNull(resultados);

        }

    }
}
