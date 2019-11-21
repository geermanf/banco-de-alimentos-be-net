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

        public IEnumerable<ProductDeliveryDto> GetProductsByKey(string key)
        {
            var products = _unitOfWork.DeliveryRepository.FindEntity(e => e.Key == key,d => d.Include(de => de.ProductDeliverys).ThenInclude(pd => pd.Product)).ProductDeliverys;
            return Dto(products);
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