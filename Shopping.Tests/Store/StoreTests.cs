using AutoMapper;
using Shopping.Database;
using Shopping.InputModels;
using Shopping.Repository;
using Shopping.Models;
using Shopping.ViewModels;
using Shopping.Mappers;
using System;
using Threax.AspNetCore.Tests;
using Xunit;
using System.Collections.Generic;

namespace Shopping.Tests
{
    public static partial class StoreTests
    {
        private static Mockup SetupModel(this Mockup mockup)
        {
            mockup.Add<IStoreRepository>(m => new StoreRepository(m.Get<AppDbContext>(), m.Get<AppMapper>()));

            return mockup;
        }
    }
}