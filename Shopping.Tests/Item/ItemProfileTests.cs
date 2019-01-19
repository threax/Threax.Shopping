using AutoMapper;
using Shopping.Database;
using Shopping.ViewModels;
using Shopping.Mappers;
using Shopping.Models;
using System;
using Threax.AspNetCore.Tests;
using Xunit;

namespace Shopping.Tests
{
    public static partial class ItemTests
    {
        public class Profile : IDisposable
        {
            private Mockup mockup = new Mockup().SetupGlobal().SetupModel();

            public Profile()
            {

            }

            public void Dispose()
            {
                mockup.Dispose();
            }

            [Fact]
            void InputToEntity()
            {
                var mapper = mockup.Get<AppMapper>();
                var input = ItemTests.CreateInput();
                var entity = mapper.MapItem(input, new ItemEntity());

                //Make sure the id does not copy over
                Assert.Equal(default(Guid), entity.ItemId);
                AssertEqual(input, entity);
            }

            [Fact]
            void EntityToView()
            {
                var mapper = mockup.Get<AppMapper>();
                var entity = ItemTests.CreateEntity();
                var view = mapper.MapItem(entity, new Item());

                Assert.Equal(entity.ItemId, view.ItemId);
                AssertEqual(entity, view);
            }
        }
    }
}