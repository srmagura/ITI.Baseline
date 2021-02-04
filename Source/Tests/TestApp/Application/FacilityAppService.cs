﻿using AutoMapper;
using ITI.Baseline.Util.Validation;
using ITI.Baseline.ValueObjects;
using ITI.DDD.Application;
using ITI.DDD.Application.UnitOfWork;
using ITI.DDD.Auth;
using ITI.DDD.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Application.Dto;
using TestApp.Application.Interfaces;
using TestApp.Application.Interfaces.QueryInterfaces;
using TestApp.Application.Interfaces.RepositoryInterfaces;
using TestApp.Domain;
using TestApp.Domain.Identities;
using TestApp.Domain.ValueObjects;

namespace TestApp.Application
{
    public class FacilityAppService : ApplicationService, IFacilityAppService
    {
        private readonly IFacilityQueries _facilityQueries;
        private readonly IFacilityRepository _facilityRepo;

        public FacilityAppService(
            IUnitOfWork uow, 
            ILogger logger, 
            IAuthContext auth,
            IFacilityQueries facilityQueries,
            IFacilityRepository facilityRepo
        ) : base(uow, logger, auth)
        {
            _facilityQueries = facilityQueries;
            _facilityRepo = facilityRepo;
        }

        public FacilityDto? Get(FacilityId id)
        {
            return Query(
                () => { },
                () => _facilityQueries.Get(id)
            );
        }

        public FacilityId Add(
            string name
        )
        {
            return Command(
                () => { },
                () =>
                {
                    var facility = new Facility(
                        name, 
                        null
                    );                
                    _facilityRepo.Add(facility);
                    return facility.Id;
                }
            );
        }
  
        public void SetContact(FacilityId id, FacilityContactDto? contact)
        {
            Command(
                () => { },
                () => {
                    var facility = _facilityRepo.Get(id)
                        ?? throw new ValidationException("Facility");

                    facility.SetContact(contact?.ToValueObject());
                }
            );
        }
    }
}
