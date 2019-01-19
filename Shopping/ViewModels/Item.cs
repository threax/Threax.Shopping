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
    [HalSelfActionLink(typeof(ItemsController), nameof(ItemsController.Get))]
    [HalActionLink(typeof(ItemsController), nameof(ItemsController.Update))]
    [HalActionLink(typeof(ItemsController), nameof(ItemsController.Delete))]
    public partial class Item : IItem, IItemId, ICreatedModified
    {
        public Guid ItemId { get; set; }

        public String Description { get; set; }

        [ValueProvider(typeof(Shopping.Services.StoreValueProvider))]
        public Guid StoreId { get; set; }

        [UiOrder(0, 2147483646)]
        public DateTime Created { get; set; }

        [UiOrder(0, 2147483647)]
        public DateTime Modified { get; set; }

    }
}
