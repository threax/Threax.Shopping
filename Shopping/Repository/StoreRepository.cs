using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.Database;
using Shopping.InputModels;
using Shopping.ViewModels;
using Shopping.Models;
using Shopping.Mappers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;

namespace Shopping.Repository
{
    public partial class StoreRepository : IStoreRepository
    {
        private AppDbContext dbContext;
        private AppMapper mapper;

        public StoreRepository(AppDbContext dbContext, AppMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<StoreCollection> List(StoreQuery query)
        {
            var dbQuery = await query.Create(this.Entities);

            var total = await dbQuery.CountAsync();
            dbQuery = dbQuery.Skip(query.SkipTo(total)).Take(query.Limit);
            var results = await dbQuery.ToListAsync();

            return new StoreCollection(query, total, results.Select(i => mapper.MapStore(i, new Store())));
        }

        public async Task<Store> Get(Guid storeId)
        {
            var entity = await this.Entity(storeId);
            return mapper.MapStore(entity, new Store());
        }

        public async Task<Store> Add(StoreInput store)
        {
            var entity = mapper.MapStore(store, new StoreEntity());
            this.dbContext.Add(entity);
            await SaveChanges();
            return mapper.MapStore(entity, new Store());
        }

        public async Task<Store> Update(Guid storeId, StoreInput store)
        {
            var entity = await this.Entity(storeId);
            if (entity != null)
            {
                mapper.MapStore(store, entity);
                await SaveChanges();
                return mapper.MapStore(entity, new Store());
            }
            throw new KeyNotFoundException($"Cannot find store {storeId.ToString()}");
        }

        public async Task Delete(Guid id)
        {
            var entity = await this.Entity(id);
            if (entity != null)
            {
                Entities.Remove(entity);
                await SaveChanges();
            }
        }

        public virtual async Task<bool> HasStores()
        {
            return await Entities.CountAsync() > 0;
        }

        public virtual async Task AddRange(IEnumerable<StoreInput> stores)
        {
            var entities = stores.Select(i => mapper.MapStore(i, new StoreEntity()));
            this.dbContext.Stores.AddRange(entities);
            await SaveChanges();
        }

        protected virtual async Task SaveChanges()
        {
            await this.dbContext.SaveChangesAsync();
        }

        private DbSet<StoreEntity> Entities
        {
            get
            {
                return dbContext.Stores;
            }
        }

        private Task<StoreEntity> Entity(Guid storeId)
        {
            return Entities.Where(i => i.StoreId == storeId).FirstOrDefaultAsync();
        }
    }
}