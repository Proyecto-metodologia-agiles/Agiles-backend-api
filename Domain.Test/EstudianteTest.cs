using Domain.Entities;
using NUnit.Framework;

namespace Domain.Test
{
    public class EstudianteTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RegistroEstudianteCorrecto()
        {
            var estudiante = new Estudiante();
            estudiante.Cedula = "111";
            estudiante.Celular = "3090908989";
            estudiante.Correo = "gsgsgsg@gmail.com";
            estudiante.Edad = 21;
            estudiante.NombreCompleto = "fabian quintero";
            estudiante.Password = "jdhsfhbsdbhf3534";
            estudiante.Estado = "Prueba";
            Assert.AreEqual(estudiante.ValidarEstudiante(estudiante), "Registrado correctamente");
        }

        [Test]
        public void RegistroEstudianteIncorrecto()
        {
            var estudiante = new Estudiante();
            estudiante.Celular = "3090908989";
            estudiante.Correo = "gsgsgsg@gmail.com";
            estudiante.Edad = 21;
            estudiante.NombreCompleto = "fabian quintero";
            estudiante.Password = "jdhsfhbsdbhf3534";
            estudiante.Estado = "Prueba";
            Assert.AreEqual(estudiante.ValidarEstudiante(estudiante), "Digite los campos primordiales para su registro");
        }

    }
}
