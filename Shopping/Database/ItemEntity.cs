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

namespace Shopping.Database 
{
    public partial class ItemEntity : IItem, IItemId, ICreatedModified
    {
        [Key]
        public Guid ItemId { get; set; }

        [Required(ErrorMessage = "Description must have a value.")]
        [MaxLength(1000, ErrorMessage = "Description must be less than 1000 characters.")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Store Id must have a value.")]
        public Guid StoreId { get; set; }

        public StoreEntity Store { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
}
