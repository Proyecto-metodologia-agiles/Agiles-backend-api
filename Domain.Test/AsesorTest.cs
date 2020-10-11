
using Domain.Entities;
using NUnit.Framework;


namespace Domain.Test
{
    public class AsesorTest
    {
        [SetUp]
        public void Setup() 
        {
       
        }

        [Test]
        public void RegistroAsesorCorrecto() 
        {
            var asesor = new Asesor();
            asesor.Name = "Kevin";
            asesor.Last_Name = "Acosta";
            asesor.Password = "kevinjal15";
            asesor.Email = "kevin.20099@gotmail.com";
            asesor.Identification = "1010133966";
            asesor.Direction = "KRA 17 CLL 11 CENTRO";
            asesor.Phone = "3046666264";
            asesor.Type_Asser = "METODOLOGICO";

            Assert.AreEqual(asesor.Validar_Asesor(asesor), "Registrado correctamente");

        }

        [Test]
        public void RegistroAsesorIncorrecto() 
        {
            var asesor = new Asesor();
            asesor.Name = "Alex";
            asesor.Last_Name = "Acosta";
            asesor.Password = "123456";
            asesor.Email = "alexacosta@gmail.com";
            asesor.Direction = "KRA 31 CLL 12";
            asesor.Phone = "312358934";
            asesor.Type_Asser = "TEMATICO";

            Assert.AreEqual(asesor.Validar_Asesor(asesor), "Digite los campos primordiales para su registro");

        }

    }
}
