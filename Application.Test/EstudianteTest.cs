using NUnit.Framework;
using System.Collections;
using Domain.Entities;
using Application.Services;
using Infrastructure;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Test
{
    public class EstudianteTest
    {
        ProyectoContext _context;
        UnitOfWork unitOfWork;


        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ProyectoContext>().UseSqlServer("Server=.\\;Database=ProyectoBd;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
            _context = new ProyectoContext(options);
            unitOfWork = new UnitOfWork(_context);
        }

        [TestCaseSource("Creations")]
        public void Create(CrearEstudianteRequest request, string expected)
        {
            CrearEstudianteServive service = new CrearEstudianteServive(unitOfWork);
            var response = service.GuardarEstudiante(request);
            Assert.AreEqual(response.Mensaje, expected);
        }

        private static IEnumerable Creations()
        {
            yield return new TestCaseData(
                new CrearEstudianteRequest
                {
                    NombreCompleto = "fabian andres quintero mendez",
                    Cedula = 12345,
                    Correo ="grovveip@gmail.com",
                    Password = "12345",
                    Celular = 304206576,
                    Edad = 19,
                    Semestre = "2"
                },
                "Registrado Correctamente"
            ).SetName("CreateOk");

            yield return new TestCaseData(
                new CrearEstudianteRequest
                {
                    NombreCompleto = "fabian andres quintero mendez",
                    Cedula = 12345,
                    Correo = "grovveip@gmail.com",
                    Password = "12345",
                    Celular = 304206576,
                    Edad = 19,
                    Semestre = "2"
                },
                "El estudiante con ese numero de cedula ya esta registrado"
            ).SetName("CreateFail");

            yield return new TestCaseData(
             new CrearEstudianteRequest
             {
                 NombreCompleto = "fabian andres quintero mendez",
                 Correo = "grovveip@gmail.com",
                 Password = "12345",
                 Celular = 304206576,
                 Edad = 19,
                 Semestre = "2"
             },
             "Digite los campos primordiales para su registro"
         ).SetName("CreateFailFaltaId");
        }
    }
}
