using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;

namespace Shopping.Models 
{
    public partial interface IItem 
    {
        String Description { get; set; }

        Guid StoreId { get; set; }

    }

    public partial interface IItemId
    {
        Guid ItemId { get; set; }
    }    

    public partial interface IItemQuery
    {
        Guid? ItemId { get; set; }
        Guid? StoreId { get; set; }


    }
}