
using Domain.Entities;
using Domain.Entities.Enums;
using NUnit.Framework;

namespace Domain.Test
{
    public class CommiteMemberTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void RegistroMiembroCorrecto()
        {
            var miembro_comite = new CommitteeMember();
            miembro_comite.FullName = "Kevin Acosta";
            miembro_comite.Password = "kevinjal15";
            miembro_comite.Email = "kevin.20099@gotmail.com";
            miembro_comite.Identification = "1010133966";
            miembro_comite.Phone = "3046666264";
     

            Assert.AreEqual(miembro_comite.IsValid(), EnumStatusRegisterCommitteMember.Success);

        }

        [Test]
        public void RegistroMiembroIncorrecto()
        {
            var miembro_comite = new CommitteeMember();
            miembro_comite.FullName = "Kevin Acosta";
            miembro_comite.Password = "hfhf";
            miembro_comite.Email = "kevin.20099.com";
            miembro_comite.Identification = "1010133966";
            miembro_comite.Phone = "3046666264";

            Assert.AreEqual(miembro_comite.IsValid(), EnumStatusRegisterCommitteMember.SomeIsEmpty);
        }

        [Test]
        public void RegistroMiembroIncorrectoTelefonoIncorrecto()
        {
            var miembro_comite = new CommitteeMember();
            miembro_comite.FullName = "Kevin Acosta";
            miembro_comite.Password = "hfhf";
            miembro_comite.Email = "kevin.20099.com";
            miembro_comite.Identification = "1010133966";
            miembro_comite.Phone = "12";

            Assert.AreEqual(miembro_comite.IsValid(), EnumStatusRegisterCommitteMember.SomeIsEmpty);
        }

        [Test]
        public void RegistroMiembroSinUnDato()
        {
            var miembro_comite = new CommitteeMember();
            miembro_comite.FullName = "Kevin Acosta";
            miembro_comite.Password = "hfhf";
            miembro_comite.Email = "kevin.20099.com";
            miembro_comite.Identification = "1010133966";
          
            Assert.AreEqual(miembro_comite.IsValid(), EnumStatusRegisterCommitteMember.SomeIsEmpty);
        }
    }
}
