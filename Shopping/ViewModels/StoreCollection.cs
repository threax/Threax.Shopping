using Halcyon.HAL.Attributes;
using Shopping.Controllers.Api;
using Shopping.Models;
using Shopping.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;

namespace Shopping.ViewModels
{
    [HalModel]
    [CacheEndpointDoc]
    [HalSelfActionLink(typeof(StoresController), nameof(StoresController.List))]
    [HalActionLink(typeof(StoresController), nameof(StoresController.Get), DocsOnly = true)] //This provides access to docs for showing items
    [HalActionLink(typeof(StoresController), nameof(StoresController.List), DocsOnly = true)] //This provides docs for searching the list
    [HalActionLink(typeof(StoresController), nameof(StoresController.Update), DocsOnly = true)] //This provides access to docs for updating items if the ui has different modes
    [HalActionLink(typeof(StoresController), nameof(StoresController.Add))]
    [DeclareHalLink(typeof(StoresController), nameof(StoresController.List), PagedCollectionView<Object>.Rels.Next, ResponseOnly = true)]
    [DeclareHalLink(typeof(StoresController), nameof(StoresController.List), PagedCollectionView<Object>.Rels.Previous, ResponseOnly = true)]
    [DeclareHalLink(typeof(StoresController), nameof(StoresController.List), PagedCollectionView<Object>.Rels.First, ResponseOnly = true)]
    [DeclareHalLink(typeof(StoresController), nameof(StoresController.List), PagedCollectionView<Object>.Rels.Last, ResponseOnly = true)]
    public partial class StoreCollection : PagedCollectionViewWithQuery<Store, StoreQuery>
    {
        public StoreCollection(StoreQuery query, int total, IEnumerable<Store> items) : base(query, total, items)
        {
            
        }
    }
}