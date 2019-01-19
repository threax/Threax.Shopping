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
    public partial interface IStore 
    {
        String Name { get; set; }

    }

    public partial interface IStoreId
    {
        Guid StoreId { get; set; }
    }    

    public partial interface IStoreQuery
    {
        Guid? StoreId { get; set; }

    }
}