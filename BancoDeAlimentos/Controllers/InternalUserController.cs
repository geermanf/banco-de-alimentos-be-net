using BancoDeAlimentos.Constants;
using BancoDeAlimentos.DTOs;
using BancoDeAlimentos.DTOs.Request;
using BancoDeAlimentos.Infrastructure;
using BancoDeAlimentos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancoDeAlimentos.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class InternalUserController : Controller
    {
        private readonly IInternalUserService _internalUserService;
        private readonly IOrganizationService _organizationService;
        private TokenHelper _tokenHelper;
        private readonly ILogger<InternalUserController> _logger;

        public InternalUserController(IInternalUserService internalUserService, IOrganizationService organizationService, TokenHelper tokenHelper, ILogger<InternalUserController> logger)
        {
            _internalUserService = internalUserService;
            _organizationService = organizationService;
            _tokenHelper = tokenHelper;
            _logger = logger;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]InternalUserLoginRequest internalUserLoginRequest)
        {
            try
            {
                InternalUserResponse internalUser = _internalUserService.GetInternalUserInformation(internalUserLoginRequest);
                if (internalUser == null)
                    return Unauthorized();

                var tokenString = _tokenHelper.GenerateToken(internalUser);

                var organization = _organizationService.GetOrganizationByEmail(internalUser.Email);
                return Ok(new
                {
                    Token = tokenString,
                    IsOrganization = internalUser.IsOrganization,
                    Organization = organization
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [Authorize]
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("");

            IEnumerable<InternalUserDto> internalUsers = _internalUserService.GetAll();

            _logger.LogInformation("");

            return Ok(internalUsers);
        }

        [Authorize]
        [HttpGet("{key}")]
        public async Task<IActionResult> Get(String key)
        {
            _logger.LogInformation("");

            InternalUserDto internalUser = _internalUserService.Get(key);

            _logger.LogInformation("");

            return Ok(internalUser);
        }


        //[Authorize]
        //[HttpPut()]
        //public async Task<IActionResult> Update([FromBody]UpdateInternalUserRequest updateInternalUserRequest)
        //{
        //    _logger.LogInformation("");

        //    InternalUserDto internalUser = _internalUserService.Update(updateInternalUserRequest);

        //    _logger.LogInformation("");
        //    return Ok(internalUser);
        //}

        //[Authorize]
        //[HttpPost()]
        //public OkObjectResult Create([FromBody]CreateInternalUserRequest createInternalUserRequest)
        //{
        //    _logger.LogInformation("");

        //    InternalUserDto internalUser = _internalUserService.Create(createInternalUserRequest);

        //    _logger.LogInformation("");
        //    return Ok(internalUser);
        //}

        //[Authorize]
        //[HttpDelete()]
        //public async Task<IActionResult> Delete([FromQuery]string key)
        //{
        //    _logger.LogInformation("");
        //    _internalUserService.Remove(key);
        //    _logger.LogInformation("");
        //    return Ok();
        //}

    }
}