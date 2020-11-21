using Domain.Contracts;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;


namespace Application.Services.Studens
{
    public class ConsultAsesorService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultAsesorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<Asesor> GetAll()
        {
            var res = _unitOfWork.AsesorRepository.FindBy();
            _unitOfWork.Dispose();
            return res.ToList();
        }

        public List<Asesor> GetMetodologic()
        {
            var res = _unitOfWork.AsesorRepository.FindBy();
            _unitOfWork.Dispose();
            List<Asesor> metodologicos = new List<Asesor>();
            foreach (var itemlist in res.ToList())
            {
                if (itemlist.Type_Asser.Equals("Metodológico"))
                {
                    metodologicos.Add(itemlist);
                }
            }
            return metodologicos;
        }

        public List<Asesor> GetThematic()
        {
            var res = _unitOfWork.AsesorRepository.FindBy();
            _unitOfWork.Dispose();
            List<Asesor> tematicos = new List<Asesor>();
            foreach (var itemlist in res.ToList())
            {
                if (itemlist.Type_Asser.Equals("Temático"))
                {
                    tematicos.Add(itemlist);
                }
            }
            return tematicos;
        }

        public Asesor GetId(int id)
        {
            var ConsultarID = _unitOfWork.AsesorRepository.Find(id);
            _unitOfWork.Dispose();
            return ConsultarID;
        }


        public ProyectosAsociadosResponse GetProyectosAsociados(int id)
        {
            ProyectosAsociadosResponse response = new ProyectosAsociadosResponse();
            var res = _unitOfWork.AsesorRepository.FindBy(x => x.Id == id)?.FirstOrDefault();
            
            if(res != null)
            {
                var projects = _unitOfWork.ProyectoRepository.FindBy(x => x.Metodologic_Advisor.Id == id || x.Thematic_Advisor.Id == id).ToList();
                if (projects.Count() != 0) {
                    _unitOfWork.Dispose();
                    response.mensaje = "Usted tiene " + projects.Count() + " proyectos asociados";
                    response.projects = projects;
                    return response;
                }
                else
                {
                    response.mensaje = "Usted tiene " + projects.Count() + " proyectos asociados";
                    response.projects = null;
                    return response;
                }
            }
            else
            {
                return null;
            }
        } 
    }

    public class ProyectosAsociadosResponse
    {
        public List<Proyecto> projects { get; set; }
        public string  mensaje { get; set; }
    }
}

