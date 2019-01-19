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
    public static partial class ItemTests
    {
        public class Controller : IDisposable
        {
            private Mockup mockup = new Mockup().SetupGlobal().SetupModel();

            public Controller()
            {
                mockup.Add<ItemsController>(m => new ItemsController(m.Get<IItemRepository>())
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

                var controller = mockup.Get<ItemsController>();

                for (var i = 0; i < totalItems; ++i)
                {
                    Assert.NotNull(await controller.Add(ItemTests.CreateInput()));
                }

                var query = new ItemQuery();
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

                var controller = mockup.Get<ItemsController>();

                for (var i = 0; i < totalItems; ++i)
                {
                    Assert.NotNull(await controller.Add(ItemTests.CreateInput()));
                }

                //Manually add the item we will look back up
                var lookup = await controller.Add(ItemTests.CreateInput());
                var result = await controller.Get(lookup.ItemId);
                Assert.NotNull(result);
            }

            [Fact]
            async Task Add()
            {
                var controller = mockup.Get<ItemsController>();

                var result = await controller.Add(ItemTests.CreateInput());
                Assert.NotNull(result);
            }

            [Fact]
            async Task Update()
            {
                var controller = mockup.Get<ItemsController>();

                var result = await controller.Add(ItemTests.CreateInput());
                Assert.NotNull(result);

                var updateResult = await controller.Update(result.ItemId, ItemTests.CreateInput());
                Assert.NotNull(updateResult);
            }

            [Fact]
            async Task Delete()
            {
                var controller = mockup.Get<ItemsController>();

                var result = await controller.Add(ItemTests.CreateInput());
                Assert.NotNull(result);

                var listResult = await controller.List(new ItemQuery());
                Assert.Equal(1, listResult.Total);

                await controller.Delete(result.ItemId);

                listResult = await controller.List(new ItemQuery());
                Assert.Equal(0, listResult.Total);
            }
        }
    }
}