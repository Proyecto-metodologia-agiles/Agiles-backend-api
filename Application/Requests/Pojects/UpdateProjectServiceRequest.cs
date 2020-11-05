using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

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
