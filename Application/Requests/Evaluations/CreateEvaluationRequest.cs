using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Requests.Evaluations
{
    public class CreateEvaluacionRequest
    {
        [MaxLength(1000)]
        public string Observation { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public DateTime Date { get; set; }

        //public int Id { set; get; }
    }
}
