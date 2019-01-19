using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shopping.InputModels;
using Shopping.ViewModels;
using Shopping.Models;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Shopping.Repository
{
    public partial interface IStoreRepository
    {
        Task<Store> Add(StoreInput value);
        Task AddRange(IEnumerable<StoreInput> values);
        Task Delete(Guid id);
        Task<Store> Get(Guid storeId);
        Task<bool> HasStores();
        Task<StoreCollection> List(StoreQuery query);
        Task<Store> Update(Guid storeId, StoreInput value);
        Task<IEnumerable<ILabelValuePair>> GetLabels();
    }
}