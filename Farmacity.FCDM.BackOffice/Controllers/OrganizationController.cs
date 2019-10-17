using Farmacity.FCDM.BackOffice.Constants;
using Farmacity.FCDM.BackOffice.DTOs;
using Farmacity.FCDM.BackOffice.DTOs.Request;
using Farmacity.FCDM.BackOffice.Entities;
using Farmacity.FCDM.BackOffice.Infrastructure;
using Farmacity.FCDM.BackOffice.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmacity.FCDM.BackOffice.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : Controller
    {
        private readonly IInternalUserService _internalUserService;
        private readonly IOrganizationService _organizationService;
        private TokenHelper _tokenHelper;
        private readonly ILogger<InternalUserController> _logger;

        public OrganizationController(IOrganizationService organizationService, IInternalUserService internalUserService, TokenHelper tokenHelper, ILogger<InternalUserController> logger)
        {
            _organizationService = organizationService;
            _internalUserService = internalUserService;
            _tokenHelper = tokenHelper;
            _logger = logger;
        }

        [HttpPost, Route("Register")]
        public IActionResult Register([FromBody]RegisterOrganizationRequest request)
        {
            _logger.LogInformation("");

            _organizationService.RegisterNewOrganization(request);

            _internalUserService.Create(request.ResponsableEmail, request.Password);

            _logger.LogInformation("");

            return Ok();
        }

        [Authorize]
        [HttpGet("GetAllConfirmed")]
        public async Task<IActionResult> GetAllConfirmed()
        {
            _logger.LogInformation("");

            IEnumerable<Organization> organizations = _organizationService.GetAllConfirmed();

            _logger.LogInformation("");

            return Ok(organizations);
        }

        [Authorize]
        [HttpGet("GetAllAwaiting")]
        public async Task<IActionResult> GetAllAwaiting()
        {
            _logger.LogInformation("");

            IEnumerable<Organization> organizations = _organizationService.GetAllAwaiting();

            _logger.LogInformation("");

            return Ok(organizations);
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