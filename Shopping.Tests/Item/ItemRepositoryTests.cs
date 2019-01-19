using Shopping.Database;
using Shopping.InputModels;
using Shopping.Repository;
using Shopping.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Tests;
using Xunit;

namespace Shopping.Tests
{
    public static partial class ItemTests
    {
        public class Repository : IDisposable
        {
            private Mockup mockup = new Mockup().SetupGlobal().SetupModel();

            public Repository()
            {

            }

            public void Dispose()
            {
                mockup.Dispose();
            }

            [Fact]
            async Task Add()
            {
                var repo = mockup.Get<IItemRepository>();
                var result = await repo.Add(ItemTests.CreateInput());
                Assert.NotNull(result);
            }

            [Fact]
            async Task AddRange()
            {
                var repo = mockup.Get<IItemRepository>();
                await repo.AddRange(new ItemInput[] { ItemTests.CreateInput(), ItemTests.CreateInput(), ItemTests.CreateInput() });
            }

            [Fact]
            async Task Delete()
            {
                var dbContext = mockup.Get<AppDbContext>();
                var repo = mockup.Get<IItemRepository>();
                await repo.AddRange(new ItemInput[] { ItemTests.CreateInput(), ItemTests.CreateInput(), ItemTests.CreateInput() });
                var result = await repo.Add(ItemTests.CreateInput());
                Assert.Equal<int>(4, dbContext.Items.Count());
                await repo.Delete(result.ItemId);
                Assert.Equal<int>(3, dbContext.Items.Count());
            }

            [Fact]
            async Task Get()
            {
                var dbContext = mockup.Get<AppDbContext>();
                var repo = mockup.Get<IItemRepository>();
                await repo.AddRange(new ItemInput[] { ItemTests.CreateInput(), ItemTests.CreateInput(), ItemTests.CreateInput() });
                var result = await repo.Add(ItemTests.CreateInput());
                Assert.Equal<int>(4, dbContext.Items.Count());
                var getResult = await repo.Get(result.ItemId);
                Assert.NotNull(getResult);
            }

            [Fact]
            async Task HasItemsEmpty()
            {
                var repo = mockup.Get<IItemRepository>();
                Assert.False(await repo.HasItems());
            }

            [Fact]
            async Task HasItems()
            {
                var repo = mockup.Get<IItemRepository>();
                await repo.AddRange(new ItemInput[] { ItemTests.CreateInput(), ItemTests.CreateInput(), ItemTests.CreateInput() });
                Assert.True(await repo.HasItems());
            }

            [Fact]
            async Task List()
            {
                //This could be more complete
                var repo = mockup.Get<IItemRepository>();
                await repo.AddRange(new ItemInput[] { ItemTests.CreateInput(), ItemTests.CreateInput(), ItemTests.CreateInput() });
                var query = new ItemQuery();
                var result = await repo.List(query);
                Assert.Equal(query.Limit, result.Limit);
                Assert.Equal(query.Offset, result.Offset);
                Assert.Equal(3, result.Total);
                Assert.NotEmpty(result.Items);
            }

            [Fact]
            async Task Update()
            {
                var repo = mockup.Get<IItemRepository>();
                var result = await repo.Add(ItemTests.CreateInput());
                Assert.NotNull(result);
                var updateResult = await repo.Update(result.ItemId, ItemTests.CreateInput());
                Assert.NotNull(updateResult);
            }
        }
    }
}