using Domain.Contracts;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;


namespace Application.Services.Studens
{
    public class ConsultMemberService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultMemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<CommitteeMember> GetAll()
        {
            var res = _unitOfWork.CommitteeMemberRepository.FindBy();
            _unitOfWork.Dispose();
            return res.ToList();
        }

        public CommitteeMember GetId(int id)
        {
            var ConsultarID = _unitOfWork.CommitteeMemberRepository.Find(id);
            _unitOfWork.Dispose();
            return ConsultarID;
        }

    }
}
