using AutoFixture;
using AutoMapper;
using Education.Aplication.Helper;
using Education.Application.Cursos;
using Education.Persistence;
using Edutacion.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Aplication.Cursos
{
    [TestFixture]
    public class CreateCursoCommandNUnitTests
    {

        private CreateCursoCommand.CreatecursoCommandHandler handlerCursoCreate;

        [SetUp]
        public void Setup()
        {

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

            handlerCursoCreate = new CreateCursoCommand.CreatecursoCommandHandler(educationDbContextFake);

        }

        [Test]
        public async Task CreateCursoCommand_InputCurso_ReturnsNumber()
        {

            CreateCursoCommand.CreateCursoCommandRequest request = new();
            request.FechaPublicacion = DateTime.UtcNow.AddDays(59);
            request.Titulo = "Libro de pruebas automaticas en NET";
            request.Descripcion = "Aprende a crear unit test desde cero";
            request.Precio = 99;

            var resultados = await handlerCursoCreate.Handle(request, new System.Threading.CancellationToken());

            Assert.That(resultados, Is.EqualTo(Unit.Value));

        }

    }
}
