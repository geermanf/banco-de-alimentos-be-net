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
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService _deliveryService;
        private readonly ILogger<DeliveryController> _logger;

        public DeliveryController(IDeliveryService deliveryService, ILogger<DeliveryController> logger)
        {
            _deliveryService = deliveryService;
            _logger = logger;
        }

        [Authorize]
        [HttpGet("GetStock")]
        public async Task<IActionResult> GetStock()
        {
            _logger.LogInformation("");

            IEnumerable<Product> stock = _deliveryService.GetStock();

            _logger.LogInformation("");

            return Ok(stock);
        }

        [Authorize]
        [HttpGet("GetAllDone")]
        public async Task<IActionResult> GetAllDone()
        {
            _logger.LogInformation("");

            IEnumerable<DeliveryDto> deliveries = _deliveryService.GetAllDone();

            _logger.LogInformation("");

            return Ok(deliveries);
        }

        [Authorize]
        [HttpGet("GetAllPending")]
        public async Task<IActionResult> GetAllPending()
        {
            _logger.LogInformation("");

            IEnumerable<DeliveryDto> deliveries = _deliveryService.GetAllPending();

            _logger.LogInformation("");

            return Ok(deliveries);
        }

        [Authorize]
        [HttpGet("GetAllDoneByOrganizationKey/{key}")]
        public async Task<IActionResult> GetAllDoneByOrganizationKey(string key)
        {
            _logger.LogInformation("");

            IEnumerable<DeliveryDto> deliveries = _deliveryService.GetAllDoneByOrganizationKey(key);

            _logger.LogInformation("");

            return Ok(deliveries);
        }

        [Authorize]
        [HttpGet("GetAllPendingByOrganizationKey/{key}")]
        public async Task<IActionResult> GetAllPendingByOrganizationKey(string key)
        {
            _logger.LogInformation("");

            IEnumerable<DeliveryDto> deliveries = _deliveryService.GetAllPendingByOrganizationKey(key);

            _logger.LogInformation("");

            return Ok(deliveries);
        }

        [Authorize]
        [HttpGet("GetProductsByKey/{key}")]
        public async Task<IActionResult> GetProductsByKey(string key)
        {
            _logger.LogInformation("");

            IEnumerable<ProductDeliveryDto> products = _deliveryService.GetProductsByKey(key);

            _logger.LogInformation("");

            return Ok(products);
        }

        [Authorize]
        [HttpPost("ConfirmDelivery")]
        public async Task<IActionResult> ConfirmDelivery([FromBody]ConfirmDeliveryRequest request)
        {
            _logger.LogInformation("");

            _deliveryService.ConfirmDelivery(request);

            _logger.LogInformation("");

            return Ok();
        }

        [Authorize]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterNewDelivery([FromBody]RegisterNewDeliveryRequest request)
        {
            _logger.LogInformation("");

            _deliveryService.RegisterNewDelivery(request);

            _logger.LogInformation("");

            return Ok();
        }

    }
}