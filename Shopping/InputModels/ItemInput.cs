using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Shopping.Models;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Shopping.InputModels 
{
    [HalModel]
    public partial class ItemInput : IItem
    {
        [Required(ErrorMessage = "Description must have a value.")]
        [MaxLength(1000, ErrorMessage = "Description must be less than 1000 characters.")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Store Id must have a value.")]
        [ValueProvider(typeof(Shopping.Services.StoreValueProvider))]
        public Guid StoreId { get; set; }

    }
}
