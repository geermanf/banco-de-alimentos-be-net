using BancoDeAlimentos.Constants;
using BancoDeAlimentos.DTOs;
using BancoDeAlimentos.DTOs.Request;
using BancoDeAlimentos.Entities;
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
        [HttpGet("GetAllApproved")]
        public async Task<IActionResult> GetAllApproved()
        {
            _logger.LogInformation("");

            IEnumerable<Organization> organizations = _organizationService.GetAllApproved();

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
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery]string key)
        {
            _logger.LogInformation("");

            Organization organization = _organizationService.Get(key);

            _logger.LogInformation("");

            return Ok(organization);
        }

        [Authorize]
        [HttpPost("editAmountOfPeople")]
        public async Task<IActionResult> EditAmountOfPeople(EditAmountOfPeopleRequest request)
        {
            _logger.LogInformation("");

            _organizationService.EditAmountOfPeople(request);

            _logger.LogInformation("");

            return Ok();
        }

        [Authorize]
        [HttpPost("reject")]
        public async Task<IActionResult> Reject([FromBody]EditStatusRequest request)
        {
            _logger.LogInformation("");

            _organizationService.EditStatus(request.Key, "Rejected");

            _logger.LogInformation("");

            return Ok();
        }

        [Authorize]
        [HttpPost("approve")]
        public async Task<IActionResult> Approve([FromBody]EditStatusRequest request)
        {
            _logger.LogInformation("");

            _organizationService.EditStatus(request.Key, "Approved");

            _logger.LogInformation("");

            return Ok();
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