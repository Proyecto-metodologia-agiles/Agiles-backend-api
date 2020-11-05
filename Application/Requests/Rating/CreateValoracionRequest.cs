using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Requests.Rating
{
    public class CreateValoracionRequest
    {
        [MaxLength(1000)]
        public string Observation { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(1000)]
        public string Valoration { get; set; }
       
        public int ProjectId { set; get; }
    }
}
