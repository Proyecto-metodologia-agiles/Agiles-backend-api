﻿using Domain.Contracts;
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
                if (itemlist.Type_Asser.Equals("Metodologico"))
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
                if (itemlist.Type_Asser.Equals("Tematico"))
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

    }
}

