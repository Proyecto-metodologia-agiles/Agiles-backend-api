using Domain.Entities;
using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handles.Commite
{
    public class CreateCommitteeMemberResponse
    {
        public string Message { set; get; }

        public bool Status { set; get; }
        public EnumStatusRegisterCommitteMember RegisterValid { set; get; }

        public CommitteeMember CommitteeMember { set; get; }
    }
}
