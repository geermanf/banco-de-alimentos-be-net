using BancoDeAlimentos.Configuration;
using BancoDeAlimentos.Constants;
using BancoDeAlimentos.Repositories;
using BancoDeAlimentos.Repositories.Implementation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoDeAlimentos.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Route("api")]
    [ApiController]
    public class HomeController : Controller
    {
        private ApiInformation ApiInformation =>
       _configuration.GetSection(ConfigurationSections.ApiInformation).Get<ApiInformation>();

        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("alive")]
        public ActionResult Alive()
        {
            return Ok("Ok");
        }

        [HttpGet("version")]
        public ActionResult Version()
        {
            return Ok(ApiInformation.ApiVersion);
        }

        [HttpGet("migrate")]
        public ActionResult Migrate()
        {
            _unitOfWork.CreateMigrations();

            return Ok("Migrations applied");
        }
    }
}
