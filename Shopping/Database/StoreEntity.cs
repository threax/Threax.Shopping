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
    public partial class StoreEntity : IStore, IStoreId, ICreatedModified
    {
        [Key]
        public Guid StoreId { get; set; }

        [Required(ErrorMessage = "Name must have a value.")]
        [MaxLength(1000, ErrorMessage = "Name must be less than 1000 characters.")]
        public String Name { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
}
