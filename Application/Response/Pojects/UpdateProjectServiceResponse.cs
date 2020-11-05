using Domain.Entities;

namespace Application.Requests.Pojects
{
    public class UpdateProjectServiceResponse
    {
        public string Message { set; get; }

        public bool Status { set; get; }


        public Proyecto Proyecto { set; get; }

    }
}
