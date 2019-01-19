using AutoMapper;
using Shopping.Database;
using Shopping.InputModels;
using Shopping.Repository;
using Shopping.Models;
using Shopping.ViewModels;
using System;
using Threax.AspNetCore.Tests;
using Xunit;
using System.Collections.Generic;

namespace Shopping.Tests
{
    public static partial class StoreTests
    {
        public static StoreInput CreateInput(String seed = "", String Name = default(String))
        {
            return new StoreInput()
            {
                Name = Name != null ? Name : $"Name {seed}",
            };
        }


        public static StoreEntity CreateEntity(String seed = "", Guid? StoreId = default(Guid?), String Name = default(String))
        {
            return new StoreEntity()
            {
                StoreId = StoreId.HasValue ? StoreId.Value : Guid.NewGuid(),
                Name = Name != null ? Name : $"Name {seed}",
            };
        }


        public static Store CreateView(String seed = "", Guid? StoreId = default(Guid?), String Name = default(String))
        {
            return new Store()
            {
                StoreId = StoreId.HasValue ? StoreId.Value : Guid.NewGuid(),
                Name = Name != null ? Name : $"Name {seed}",
            };
        }


        public static void AssertEqual(IStore expected, IStore actual)
        {
           Assert.Equal(expected.Name, actual.Name);
        }

    }
}