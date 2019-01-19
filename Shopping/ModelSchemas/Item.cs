using Shopping.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Models;

namespace Shopping.ModelSchemas
{
    public class Item
    {
        [Required(ErrorMessage = "You must include a description.")]
        [MaxLength(1000, ErrorMessage = "The description must be less than 1000 characters.")]
        public String Description { get; set; }

        [Required(ErrorMessage = "You must include a store.")]
        [DefineValueProvider(typeof(StoreValueProvider))]
        [Queryable]
        public Guid StoreId { get; set; }
    }
}
