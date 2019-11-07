using BancoDeAlimentos.DTOs;
using BancoDeAlimentos.DTOs.Request;
using BancoDeAlimentos.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeAlimentos.Services
{
    public interface IDeliveryService
    {
        IEnumerable<Product> GetStock();
    }
}
