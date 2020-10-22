using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Requests.Pojects
{
    public class UpdateProjectServiceRequest
    {
        [Required]
        public int Id { set; get; }

        [Required]
        
        public IFormFile Archive { get; set; }
    }
}
