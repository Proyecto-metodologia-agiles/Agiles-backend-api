using Domain.Contracts;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;


namespace Application.Services.Studens
{
    public class consultStudentService
    {
        readonly IUnitOfWork _unitOfWork;


        public consultStudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<Estudiante> GetAll()
        {
            var res = _unitOfWork.EstudianteRepository.FindBy();
            _unitOfWork.Dispose();
            return res.ToList();
        }

        public Estudiante GetId(int id)
        {
            var ConsultarID = _unitOfWork.EstudianteRepository.Find(id);
            _unitOfWork.Dispose();
            return ConsultarID;
        }

        public List<Estudiante> GetEstate0()
        {
            var res = _unitOfWork.EstudianteRepository.FindBy();
            List<Estudiante> estudiantes_sin_proyecto = new List<Estudiante>();
            foreach (var itemlist in res.ToList())
            {
                if (itemlist.Estado==0)
                {
                    estudiantes_sin_proyecto.Add(itemlist);
                }
            }
            _unitOfWork.Dispose();
            return estudiantes_sin_proyecto;
        }
    }
}
