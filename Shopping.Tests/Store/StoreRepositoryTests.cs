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
    public static partial class StoreTests
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
                var repo = mockup.Get<IStoreRepository>();
                var result = await repo.Add(StoreTests.CreateInput());
                Assert.NotNull(result);
            }

            [Fact]
            async Task AddRange()
            {
                var repo = mockup.Get<IStoreRepository>();
                await repo.AddRange(new StoreInput[] { StoreTests.CreateInput(), StoreTests.CreateInput(), StoreTests.CreateInput() });
            }

            [Fact]
            async Task Delete()
            {
                var dbContext = mockup.Get<AppDbContext>();
                var repo = mockup.Get<IStoreRepository>();
                await repo.AddRange(new StoreInput[] { StoreTests.CreateInput(), StoreTests.CreateInput(), StoreTests.CreateInput() });
                var result = await repo.Add(StoreTests.CreateInput());
                Assert.Equal<int>(4, dbContext.Stores.Count());
                await repo.Delete(result.StoreId);
                Assert.Equal<int>(3, dbContext.Stores.Count());
            }

            [Fact]
            async Task Get()
            {
                var dbContext = mockup.Get<AppDbContext>();
                var repo = mockup.Get<IStoreRepository>();
                await repo.AddRange(new StoreInput[] { StoreTests.CreateInput(), StoreTests.CreateInput(), StoreTests.CreateInput() });
                var result = await repo.Add(StoreTests.CreateInput());
                Assert.Equal<int>(4, dbContext.Stores.Count());
                var getResult = await repo.Get(result.StoreId);
                Assert.NotNull(getResult);
            }

            [Fact]
            async Task HasStoresEmpty()
            {
                var repo = mockup.Get<IStoreRepository>();
                Assert.False(await repo.HasStores());
            }

            [Fact]
            async Task HasStores()
            {
                var repo = mockup.Get<IStoreRepository>();
                await repo.AddRange(new StoreInput[] { StoreTests.CreateInput(), StoreTests.CreateInput(), StoreTests.CreateInput() });
                Assert.True(await repo.HasStores());
            }

            [Fact]
            async Task List()
            {
                //This could be more complete
                var repo = mockup.Get<IStoreRepository>();
                await repo.AddRange(new StoreInput[] { StoreTests.CreateInput(), StoreTests.CreateInput(), StoreTests.CreateInput() });
                var query = new StoreQuery();
                var result = await repo.List(query);
                Assert.Equal(query.Limit, result.Limit);
                Assert.Equal(query.Offset, result.Offset);
                Assert.Equal(3, result.Total);
                Assert.NotEmpty(result.Items);
            }

            [Fact]
            async Task Update()
            {
                var repo = mockup.Get<IStoreRepository>();
                var result = await repo.Add(StoreTests.CreateInput());
                Assert.NotNull(result);
                var updateResult = await repo.Update(result.StoreId, StoreTests.CreateInput());
                Assert.NotNull(updateResult);
            }
        }
    }
}