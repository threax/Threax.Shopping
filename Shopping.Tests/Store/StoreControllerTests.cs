using Shopping.Controllers.Api;
using Shopping.InputModels;
using Shopping.Repository;
using Shopping.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Threax.AspNetCore.Tests;
using Xunit;

namespace Shopping.Tests
{
    public static partial class StoreTests
    {
        public class Controller : IDisposable
        {
            private Mockup mockup = new Mockup().SetupGlobal().SetupModel();

            public Controller()
            {
                mockup.Add<StoresController>(m => new StoresController(m.Get<IStoreRepository>())
                {
                    ControllerContext = m.Get<ControllerContext>()
                });
            }

            public void Dispose()
            {
                mockup.Dispose();
            }

            [Fact]
            async Task List()
            {
                var totalItems = 3;

                var controller = mockup.Get<StoresController>();

                for (var i = 0; i < totalItems; ++i)
                {
                    Assert.NotNull(await controller.Add(StoreTests.CreateInput()));
                }

                var query = new StoreQuery();
                var result = await controller.List(query);
                Assert.Equal(query.Limit, result.Limit);
                Assert.Equal(query.Offset, result.Offset);
                Assert.Equal(3, result.Total);
                Assert.NotEmpty(result.Items);
            }

            [Fact]
            async Task Get()
            {
                var totalItems = 3;

                var controller = mockup.Get<StoresController>();

                for (var i = 0; i < totalItems; ++i)
                {
                    Assert.NotNull(await controller.Add(StoreTests.CreateInput()));
                }

                //Manually add the item we will look back up
                var lookup = await controller.Add(StoreTests.CreateInput());
                var result = await controller.Get(lookup.StoreId);
                Assert.NotNull(result);
            }

            [Fact]
            async Task Add()
            {
                var controller = mockup.Get<StoresController>();

                var result = await controller.Add(StoreTests.CreateInput());
                Assert.NotNull(result);
            }

            [Fact]
            async Task Update()
            {
                var controller = mockup.Get<StoresController>();

                var result = await controller.Add(StoreTests.CreateInput());
                Assert.NotNull(result);

                var updateResult = await controller.Update(result.StoreId, StoreTests.CreateInput());
                Assert.NotNull(updateResult);
            }

            [Fact]
            async Task Delete()
            {
                var controller = mockup.Get<StoresController>();

                var result = await controller.Add(StoreTests.CreateInput());
                Assert.NotNull(result);

                var listResult = await controller.List(new StoreQuery());
                Assert.Equal(1, listResult.Total);

                await controller.Delete(result.StoreId);

                listResult = await controller.List(new StoreQuery());
                Assert.Equal(0, listResult.Total);
            }
        }
    }
}