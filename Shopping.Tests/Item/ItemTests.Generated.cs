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
    public static partial class ItemTests
    {
        public static ItemInput CreateInput(String seed = "", String Description = default(String), Guid StoreId = default(Guid))
        {
            return new ItemInput()
            {
                Description = Description != null ? Description : $"Description {seed}",
                StoreId = StoreId,
            };
        }


        public static ItemEntity CreateEntity(String seed = "", Guid? ItemId = default(Guid?), String Description = default(String), Guid StoreId = default(Guid))
        {
            return new ItemEntity()
            {
                ItemId = ItemId.HasValue ? ItemId.Value : Guid.NewGuid(),
                Description = Description != null ? Description : $"Description {seed}",
                StoreId = StoreId,
            };
        }


        public static Item CreateView(String seed = "", Guid? ItemId = default(Guid?), String Description = default(String), Guid StoreId = default(Guid))
        {
            return new Item()
            {
                ItemId = ItemId.HasValue ? ItemId.Value : Guid.NewGuid(),
                Description = Description != null ? Description : $"Description {seed}",
                StoreId = StoreId,
            };
        }


        public static void AssertEqual(IItem expected, IItem actual)
        {
           Assert.Equal(expected.Description, actual.Description);
           Assert.Equal(expected.StoreId, actual.StoreId);
        }

    }
}