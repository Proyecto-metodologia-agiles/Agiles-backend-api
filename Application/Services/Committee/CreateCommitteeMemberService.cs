using Application.Base;
using Application.Handles.Commite;
using Domain.Contracts;
using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Committee
{
    public class CreateCommitteeMemberService : Service<CommitteeMember>
    {

        private readonly IUnitOfWork _unitOfWork;
        
        

        public CreateCommitteeMemberService(IUnitOfWork unitOfWork, IGenericRepository<CommitteeMember> genericRepository) : base(unitOfWork, genericRepository)
        {
            _unitOfWork = unitOfWork;
            
        }


        public CreateCommitteeMemberResponse Create(CreateCommitteeMemberRequest request)
        {

            CommitteeMember committee = CommitteeMember.Build(request.FullName, request.Email, request.Phone.ToString(), request.Password,request.Identification.ToString());



            //validad que todo los datos de envio son correctos
            EnumStatusRegisterCommitteMember valid = committee.IsValid(); 



            if(valid == EnumStatusRegisterCommitteMember.Success)
            {
                //valida que no exista duplicados
                if (_unitOfWork.CommitteeMemberRepository.
                Any(x => x.Email == committee.Email &&
                    x.FullName == committee.FullName &&
                    x.Phone == committee.Phone))
                {

                    return new CreateCommitteeMemberResponse
                    {
                        Message = "ingresados corresponden a un registro existente",
                        RegisterValid = EnumStatusRegisterCommitteMember.Duplicate,
                        Status = false
                    };
                }

                //el servicio base crea el registro
                committee = Create(committee);

                if(committee == null)
                {
                    return new CreateCommitteeMemberResponse
                    {
                        Message = "Ocurrio un error al momento, de crear el registro",
                        RegisterValid = EnumStatusRegisterCommitteMember.Error,
                        Status = false
                    };
                }
                return new CreateCommitteeMemberResponse
                {
                    Message = "Registro exitoso",
                    RegisterValid = EnumStatusRegisterCommitteMember.Success,
                    Status = true,
                    CommitteeMember = committee
                };

            }
            return new CreateCommitteeMemberResponse
            {
                Message = "faltan campos de carácter obligatorio",
                RegisterValid = EnumStatusRegisterCommitteMember.SomeIsEmpty,
                Status = false
            };
        }

    }
}
