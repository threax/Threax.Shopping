using Halcyon.HAL.Attributes;
using Shopping.Controllers;
using Shopping.Models;
using Shopping.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;
using Threax.AspNetCore.Models;
using System.ComponentModel.DataAnnotations;

namespace Shopping.InputModels
{
    [HalModel]
    [CacheEndpointDoc]
    public partial class StoreQuery : PagedCollectionQuery, IStoreQuery
    {
        /// <summary>
        /// Lookup a store by id.
        /// </summary>
        public Guid? StoreId { get; set; }

        /// <summary>
        /// Populate an IQueryable. Does not apply the skip or limit.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>The query passed in populated with additional conditions.</returns>
        public Task<IQueryable<StoreEntity>> Create(IQueryable<StoreEntity> query)
        {
            if (StoreId != null)
            {
                query = query.Where(i => i.StoreId == StoreId);
            }
            else
            {
                //Customize query further
            }

            return Task.FromResult(query);
        }
    }
}