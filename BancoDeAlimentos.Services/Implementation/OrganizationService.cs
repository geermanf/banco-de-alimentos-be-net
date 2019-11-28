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
    public class OrganizationService : IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly EmailSender _emailSender;

        public OrganizationService(IUnitOfWork unitOfWork, IMapper mapper, EmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public Organization Get(string key)
        {
            var organization = _unitOfWork.OrganizationRepository.FindEntity(x => x.Key == key);
            organization.ThrowNotFoundIfNull();

            return organization;
        }

        public IEnumerable<Organization> GetAllAwaiting()
        {
            IEnumerable<Organization> organizations =
                _unitOfWork.OrganizationRepository.GetAll(o => o.Status == "Awaiting");

            return organizations;
        }

        public IEnumerable<Organization> GetAllApproved()
        {
            IEnumerable<Organization> organizations =
                _unitOfWork.OrganizationRepository.GetAll(o => o.Status == "Approved");

            return organizations;
        }

        public Organization GetOrganizationByEmail(string email)
        {
            var organization = _unitOfWork.OrganizationRepository.FindEntity(
               x => x.ResponsableEmail == email);

            return organization;
        }

        public Organization RegisterNewOrganization(RegisterOrganizationRequest request)
        {
            var organization = _unitOfWork.OrganizationRepository.FindEntity(x => x.ResponsableEmail == request.ResponsableEmail || x.OrganizationName == request.OrganizationName);
            organization.ThrowIfNotNull();

            organization = _mapper.Map<Organization>(request);
            organization.Status = "Awaiting";

            _unitOfWork.OrganizationRepository.Add(organization);

            _emailSender.SendAwaitingRequestEmail(organization);

            _unitOfWork.Complete();

            return organization;
        }

        public void EditAmountOfPeople(EditAmountOfPeopleRequest request)
        {
            var organization = _unitOfWork.OrganizationRepository.FindEntity(x => x.Key == request.Key);
            organization.ThrowNotFoundIfNull();

            organization.Adults = request.Adults;
            organization.Children = request.Children;
            _unitOfWork.OrganizationRepository.Update(organization);
            _unitOfWork.Complete();
        }

        public void EditStatus(string key, string status)
        {
            var organization = _unitOfWork.OrganizationRepository.FindEntity(x => x.Key == key);
            organization.ThrowNotFoundIfNull();

            organization.Status = status;
            _unitOfWork.OrganizationRepository.Update(organization);

            if (status == "Rejected")
            {
                _emailSender.SendRejectedRequestEmail(organization);

            }
            else if (status == "Approved")
            {
                _emailSender.SendApprovedRequestEmail(organization);
            }

            _unitOfWork.Complete();
        }

    }
}