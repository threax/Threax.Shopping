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
    public static partial class ItemTests
    {
        private static Mockup SetupModel(this Mockup mockup)
        {
            mockup.Add<IItemRepository>(m => new ItemRepository(m.Get<AppDbContext>(), m.Get<AppMapper>()));

            return mockup;
        }
    }
}