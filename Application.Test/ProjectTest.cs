using Infrastructure;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Test
{
    public class ProjectTest
    {
        ProyectoContext _context;
        UnitOfWork unitOfWork;


        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ProyectoContext>().UseSqlServer("Server=.\\;Database=ProyectoBd;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
            _context = new ProyectoContext(options);
            unitOfWork = new UnitOfWork(_context);
        }


        public void UploadTest()
        {
            // arrange
        }
    }
}
