﻿using System.Collections.Generic;
using Domain;
using Iti.ValueObjects;
using SampleApp.Application.Dto;

namespace SampleApp.Application.Interfaces
{
    public interface IFooAppService
    {
        FooReferenceDto ReferenceFor(FooId id);
        FooSummaryDto SummaryFor(FooId id);
        FooJunkDto JunkFor(FooId id);
        FooDto Get(FooId id);
        List<FooDto> GetList();

        FooId CreateFoo(string name, List<Bar> bars,
            SimpleAddress simpleAddress = null,
            SimplePersonName simplePersonName = null,
            PhoneNumber phoneNumber = null);
        void Remove(FooId id);

        void SetName(FooId id, string newName);
        void RemoveBar(FooId id, string name);
        void AddBar(FooId id, string name);
        void SetAllBarNames(FooId id, string name);
        void SetAddress(FooId id, SimpleAddress simpleAddress);
    }
}