using BancoDeAlimentos.DTOs;
using BancoDeAlimentos.DTOs.Request;
using BancoDeAlimentos.Entities;
using System;
using System.Collections.Generic;

namespace BancoDeAlimentos.Services
{
    public interface IDeliveryService
    {
        IEnumerable<Product> GetStock();

        IEnumerable<DeliveryDto> GetAllDone();

        IEnumerable<DeliveryDto> GetAllPending();

        IEnumerable<ProductDeliveryDto> GetProductsByKey(string key);

        IEnumerable<DeliveryDto> GetAllDoneByOrganizationKey(string key);

        IEnumerable<DeliveryDto> GetAllPendingByOrganizationKey(string key);

        void ConfirmDelivery(ConfirmDeliveryRequest request);

        void RegisterNewDelivery(RegisterNewDeliveryRequest request);
    }
}
