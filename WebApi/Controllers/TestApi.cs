using Application.Services.Advisorys;
using Domain.Contracts;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Mailers.Entities;
using Infrastructure.Mailers.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestApi : ControllerBase
    {
        readonly ProyectoContext _context;
        readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;

        public TestApi(IOptions<AppSettings> appSettings, ProyectoContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _appSettings = appSettings.Value;
        }

        [HttpGet("[action]")]
        public ActionResult<dynamic> Get()
        {

            //return Ok(_appSettings);

            ObjectMailer objectMailer = new ObjectMailer()
			{
				Smtp = new SMTP
				{

					Name = _appSettings.Mailer.SmtName,
					Host = _appSettings.Mailer.SmtpServer,
					UserName = _appSettings.Mailer.SmtpUser,
					Password = _appSettings.Mailer.SmtpPass,
					Port = _appSettings.Mailer.SmtpPort,
					Ssl = _appSettings.Mailer.EnableSsl
				},
                MailerFroms = new List<MailerFrom>
                {
                    new MailerFrom
                    {
                        Email = "carloscastilla31@gmail.com",
                        Name = "carlos castilla"
                    }
                },
                Subject = "Ejemplo",
                TextBody = "ejemplo",
				Templante = "",
				
			};
			return Ok(SendMailer.Send(objectMailer));
        }


        

    }
}
