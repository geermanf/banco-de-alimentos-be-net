using AutoMapper;
using BancoDeAlimentos.DTOs;
using BancoDeAlimentos.DTOs.Request;
using BancoDeAlimentos.Entities;
using BancoDeAlimentos.Entities.Common;
using BancoDeAlimentos.Entities.Enum;
using BancoDeAlimentos.Repositories;
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

        public OrganizationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
            _unitOfWork.Complete();
        }

        //public InternalUserDto Update(InternalUserRequest updateInternalUserRequest)
        //{
        //    InternalUser internalUser = _unitOfWork.InternalUserRepository.FindEntity(x.Key == updateInternalUserRequest.Key, source => source.Include(a => a.Role).ThenInclude(b => b.RolePermission));
        //    internalUser.ThrowNotFoundIfNull();

        //    _mapper.Map(updateInternalUserRequest, internalUser);
        //    _unitOfWork.InternalUserRepository.Update(internalUser);
        //    _unitOfWork.Complete();

        //    return _mapper.Map<InternalUserDto>(internalUser);
        //}




        //public void Remove(string key)
        //{
        //    InternalUser internalUser = _unitOfWork.InternalUserRepository.FindEntity(x => x.InternalUserType == InternalUserType.ActiveDirectory && x.Key == key);
        //    internalUser.ThrowNotFoundIfNull();

        //    _unitOfWork.InternalUserRepository.Remove(internalUser.Id);
        //    _unitOfWork.Complete();
        //}
    }
}