using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Requests.Pojects
{
    public class UpdateProjectServiceResponse
    {
        public string Message { set; get; }

        public bool Status { set; get; }


        public Proyecto Proyecto { set; get; }

    }
}
