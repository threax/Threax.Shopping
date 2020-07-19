using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;
using Shopping.Models;
using Shopping.Controllers.Api;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Shopping.ViewModels 
{
    [HalModel]
    [CacheEndpointDoc]
    [HalSelfActionLink(typeof(StoresController), nameof(StoresController.Get))]
    [HalActionLink(typeof(StoresController), nameof(StoresController.Update))]
    [HalActionLink(typeof(StoresController), nameof(StoresController.Delete))]
    public partial class Store : IStore, IStoreId, ICreatedModified
    {
        public Guid StoreId { get; set; }

        public String Name { get; set; }

        [UiOrder(0, 2147483646)]
        public DateTime Created { get; set; }

        [UiOrder(0, 2147483647)]
        public DateTime Modified { get; set; }

    }
}
