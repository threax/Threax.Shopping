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
    public static partial class StoreTests
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
                var input = StoreTests.CreateInput();
                var entity = mapper.MapStore(input, new StoreEntity());

                //Make sure the id does not copy over
                Assert.Equal(default(Guid), entity.StoreId);
                AssertEqual(input, entity);
            }

            [Fact]
            void EntityToView()
            {
                var mapper = mockup.Get<AppMapper>();
                var entity = StoreTests.CreateEntity();
                var view = mapper.MapStore(entity, new Store());

                Assert.Equal(entity.StoreId, view.StoreId);
                AssertEqual(entity, view);
            }
        }
    }
}