using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Handles.Commite
{
    public class CreateCommitteeMemberRequest
    {
      
        [MaxLength(50)]
        [MinLength(3)]
        [Required]
        public string FullName { set; get; } = string.Empty;

        
        [MaxLength(50)]
        [MinLength(3)]
        [Required]
        [EmailAddress]
        public string Email { set; get; } = string.Empty;

        
        [MaxLength(10)]
        [MinLength(5)]
        [Required]
        [Phone]
        public string Phone { set; get; } = string.Empty;

        
        [MaxLength(3)]
        [MinLength(1)]
        [Required]
        public string Level { set; get; } = string.Empty;
    }
}
