using AutoMapper;
using BancoDeAlimentos.DTOs;
using BancoDeAlimentos.DTOs.Request;
using BancoDeAlimentos.Entities;
using BancoDeAlimentos.Entities.Common;
using BancoDeAlimentos.Entities.Enum;
using BancoDeAlimentos.Repositories;
using BancoDeAlimentos.Services.BusinessLogic;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace BancoDeAlimentos.Services.Implementation
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly EmailSender _emailSender;

        public DeliveryService(IUnitOfWork unitOfWork, IMapper mapper, EmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public IEnumerable<Product> GetStock()
        {
            return _unitOfWork.ProductRepository.GetAll();
        }

        public IEnumerable<DeliveryDto> GetAllDone()
        {
            var deliveries = _unitOfWork.DeliveryRepository.GetAll(d => d.Include(de => de.Organization).Include(de => de.ProductDeliverys).ThenInclude(pd => pd.Product))
                                                .Where(d => d.Status == DeliveryStatus.Done);
            return Dto(deliveries);
        }
        public IEnumerable<DeliveryDto> GetAllPending()
        {
            var deliveries = _unitOfWork.DeliveryRepository.GetAll(d => d.Include(de => de.Organization).Include(de => de.ProductDeliverys).ThenInclude(pd => pd.Product))
                                                .Where(d => d.Status == DeliveryStatus.Pending);
            return Dto(deliveries);
        }

        public IEnumerable<DeliveryDto> GetAllDoneByOrganizationKey(string key)
        {
            var deliveries = _unitOfWork.DeliveryRepository.GetAll(d => d.Include(de => de.Organization).Include(de => de.ProductDeliverys).ThenInclude(pd => pd.Product))
                                                .Where(d => d.Organization.Key == key && d.Status == DeliveryStatus.Done);
            return Dto(deliveries);
        }
        public IEnumerable<DeliveryDto> GetAllPendingByOrganizationKey(string key)
        {
            var deliveries = _unitOfWork.DeliveryRepository.GetAll(d => d.Include(de => de.Organization).Include(de => de.ProductDeliverys).ThenInclude(pd => pd.Product))
                                                .Where(d => d.Organization.Key == key && d.Status == DeliveryStatus.Pending);
            return Dto(deliveries);
        }

        public IEnumerable<ProductDeliveryDto> GetProductsByKey(string key)
        {
            var products = _unitOfWork.DeliveryRepository.FindEntity(e => e.Key == key,d => d.Include(de => de.ProductDeliverys).ThenInclude(pd => pd.Product)).ProductDeliverys;
            return Dto(products);
        }

        public void RegisterNewDelivery(RegisterNewDeliveryRequest request)
        {
            var delivery = _mapper.Map<Delivery>(request);

            delivery.ProductDeliverys = _unitOfWork.ProductRepository
                        .Find(p => request.ProductsDeliveries.ToList().Select(pd => pd.Key).Contains(p.Key))
                        .Select(p => new ProductDelivery()
                        {
                            Delivery = delivery,
                            ProductId = p.Id,
                            Product = p,
                            Quantity = request.ProductsDeliveries.FirstOrDefault(pd => pd.Key == p.Key).Quantity
                        }
                        ).ToList();

            delivery.Organization = _unitOfWork.OrganizationRepository.FindEntity(o => o.Key == request.OrganizationKey);

            _unitOfWork.DeliveryRepository.Add(delivery);

            _unitOfWork.Complete();
        }

        public void ConfirmDelivery(ConfirmDeliveryRequest request)
        {
            var delivery = _unitOfWork.DeliveryRepository.FindEntity(x => x.Key == request.Key, d => d.Include(de => de.ProductDeliverys).ThenInclude(pd => pd.Product));
            delivery.ThrowNotFoundIfNull();

            delivery.Status = DeliveryStatus.Done;
            delivery.EffectiveDate = request.EffectiveDate;
            delivery.ExpiredProducts = request.ExpiredProducts;
            _unitOfWork.DeliveryRepository.Update(delivery);

            this.UpdateStock(delivery);

            _unitOfWork.Complete();
        }



        private void UpdateStock(Delivery delivery)
        {
            delivery.ProductDeliverys.ToList().ForEach(pd => pd.Product.Stock = pd.Product.Stock - pd.Quantity);
            //var products = delivery.ProductDeliverys.Select(pd => pd.Product);
            //_unitOfWork.ProductRepository.Update(products);
        }



        protected IEnumerable<DeliveryDto> Dto(IEnumerable<Delivery> source)
        {
            return _mapper.Map<IEnumerable<DeliveryDto>>(source);
        }

        protected IEnumerable<ProductDeliveryDto> Dto(IEnumerable<ProductDelivery> source)
        {
            return _mapper.Map<IEnumerable<ProductDeliveryDto>>(source);
        }

    }
}