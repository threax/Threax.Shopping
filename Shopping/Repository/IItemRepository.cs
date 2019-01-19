using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shopping.InputModels;
using Shopping.ViewModels;
using Shopping.Models;
using Threax.AspNetCore.Halcyon.Ext;

namespace Shopping.Repository
{
    public partial interface IItemRepository
    {
        Task<Item> Add(ItemInput value);
        Task AddRange(IEnumerable<ItemInput> values);
        Task Delete(Guid id);
        Task<Item> Get(Guid itemId);
        Task<bool> HasItems();
        Task<ItemCollection> List(ItemQuery query);
        Task<Item> Update(Guid itemId, ItemInput value);
    }
}