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
            return _unitOfWork.ProductRepository.GetAll(); ;
        }
        
    }
}