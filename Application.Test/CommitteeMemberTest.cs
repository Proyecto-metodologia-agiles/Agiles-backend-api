using Application.Services.Committee;
using Domain.Contracts;
using Domain.Entities;
using Domain.Entities.Enums;
using Infrastructure;
using Infrastructure.Base;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Test
{
    [TestFixture]
    class CommitteeMemberTest
    {


        
        private CreateCommitteeMemberService _createService;
        private ProyectoContext _proyectoContext;
        private IUnitOfWork _unitOfWork;


       [SetUp]
       public void SetUp()
        {
            /*
            _proyectoContext = new ProyectoContext();
            _unitOfWork = new UnitOfWork(_proyectoContext);
            _createService = new CreateCommitteeMemberService(_unitOfWork, _unitOfWork.CommitteeMemberRepository);
        
            */
            }


        /*
         * ESCENARIO 1: registro exitoso de miembro del comité 
         * DADO QUE se han digitado los siguientes datos: Nombre completo: Carlos Arturo Pérez Ponce, 
         * email: caperez@unicesar.edu.co, número telefónico: 19546850 y nivel:  
         * CUANDO el miembro del comité de clic en registrar ENTONCES se registrará de forma exitosa.
         */

        [Test]
        public void CreateMember1Success()
        {

            var response = _createService.Create(new Handles.Commite.CreateCommitteeMemberRequest
            {
                /*
                FullName = "Carlos Arturo Pérez Ponce",
                Email = "caperez@unicesar.edu.co",
                Phone = "3107093452",
                Level = "1"
                */
            });
            Assert.AreEqual(response.RegisterValid, EnumStatusRegisterCommitteMember.Success);
            Assert.AreEqual(response.Status, true);
        }




        /*
         * ESCENARIO 2: registro incompleto de miembro del comité 
         * DADO QUE se han digitado los siguientes datos: Nombre completo: Carlos Arturo Pérez Ponce y nivel:  
         * CUANDO el miembro del comité de clic en registrar ENTONCES será notificado que faltan campos 
         * de carácter obligatorio y no se guarda el registro.
         */
        [Test]
        public void CreateMember2Error()
        {
            var response = _createService.Create(new Handles.Commite.CreateCommitteeMemberRequest
            {
                /*
                FullName = "Carlos Arturo Pérez Ponce",
                //Email = "caperez@unicesar.edu.co",
                Phone = "3107093452",
                Level = "1" */
            });
            Assert.AreEqual(response.RegisterValid, EnumStatusRegisterCommitteMember.SomeIsEmpty);
            Assert.AreEqual(response.Status, false);
        }


        /*
         *ESCENARIO 3: registro duplicado de miembro del comité 
         *DADO QUE se han digitado los siguientes datos: Nombre completo: Carlos Arturo Pérez Ponce,
         *email: caperez@unicesar.edu.co, número telefónico: 3107093452 y nivel: 
         *CUANDO el miembro del comité de clic en registrar ENTONCES será notificado que los datos
         *ingresados corresponden a un registro y no se guarda el registro.
         */
        [Test]
        public void CreateMember3Duplicate()
        {
            var response = _createService.Create(new Handles.Commite.CreateCommitteeMemberRequest
            { /*
                FullName = "Carlos Arturo Pérez Ponce",
                Email = "caperez@unicesar.edu.co",
                Phone = "3107093452",
                Level = "1"
                */
            });
            Assert.AreEqual(response.RegisterValid, EnumStatusRegisterCommitteMember.Duplicate);
            Assert.AreEqual(response.Status, false);
        }


        
    }
}
