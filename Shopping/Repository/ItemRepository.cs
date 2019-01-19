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
    public partial class ItemRepository : IItemRepository
    {
        private AppDbContext dbContext;
        private AppMapper mapper;

        public ItemRepository(AppDbContext dbContext, AppMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ItemCollection> List(ItemQuery query)
        {
            var dbQuery = await query.Create(this.Entities);

            var total = await dbQuery.CountAsync();
            dbQuery = dbQuery.Skip(query.SkipTo(total)).Take(query.Limit);
            var results = await dbQuery.ToListAsync();

            return new ItemCollection(query, total, results.Select(i => mapper.MapItem(i, new Item())));
        }

        public async Task<Item> Get(Guid itemId)
        {
            var entity = await this.Entity(itemId);
            return mapper.MapItem(entity, new Item());
        }

        public async Task<Item> Add(ItemInput item)
        {
            var entity = mapper.MapItem(item, new ItemEntity());
            this.dbContext.Add(entity);
            await SaveChanges();
            return mapper.MapItem(entity, new Item());
        }

        public async Task<Item> Update(Guid itemId, ItemInput item)
        {
            var entity = await this.Entity(itemId);
            if (entity != null)
            {
                mapper.MapItem(item, entity);
                await SaveChanges();
                return mapper.MapItem(entity, new Item());
            }
            throw new KeyNotFoundException($"Cannot find item {itemId.ToString()}");
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

        public virtual async Task<bool> HasItems()
        {
            return await Entities.CountAsync() > 0;
        }

        public virtual async Task AddRange(IEnumerable<ItemInput> items)
        {
            var entities = items.Select(i => mapper.MapItem(i, new ItemEntity()));
            this.dbContext.Items.AddRange(entities);
            await SaveChanges();
        }

        protected virtual async Task SaveChanges()
        {
            await this.dbContext.SaveChangesAsync();
        }

        private DbSet<ItemEntity> Entities
        {
            get
            {
                return dbContext.Items;
            }
        }

        private Task<ItemEntity> Entity(Guid itemId)
        {
            return Entities.Where(i => i.ItemId == itemId).FirstOrDefaultAsync();
        }
    }
}