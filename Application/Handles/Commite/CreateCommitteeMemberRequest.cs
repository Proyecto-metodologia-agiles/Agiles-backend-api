using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Handles.Commite
{
    public class CreateCommitteeMemberRequest
    {
      
        
        public string FullName { set; get; } = string.Empty;

      
        public string Email { set; get; } = string.Empty;

        
        
        public string Phone { set; get; } = string.Empty;

        
      
        public string Password { set; get; } = string.Empty;

       
        public string Identification { set; get; } = string.Empty;
    }
}
