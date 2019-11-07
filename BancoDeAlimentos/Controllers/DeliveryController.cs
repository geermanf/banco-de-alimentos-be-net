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
        
    }
}