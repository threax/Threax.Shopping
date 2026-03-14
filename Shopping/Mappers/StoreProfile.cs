using System;
using System.Collections.Generic;
using System.Text;
using Threax.AspNetCore.Models;
using Shopping.InputModels;
using Shopping.Database;
using Shopping.ViewModels;

namespace Shopping.Mappers
{
    public partial class AppMapper
    {
        public StoreEntity MapStore(StoreInput src, StoreEntity dest)
        {
            //dest.StoreId ignored
            dest.Name = src.Name;
            dest.Created = GetCreated(dest.Created);
            dest.Modified = DateTime.UtcNow;

            return dest;
        }

        public Store MapStore(StoreEntity src, Store dest)
        {
            dest.StoreId = src.StoreId;
            dest.Name = src.Name;
            dest.Created = src.Created;
            dest.Modified = src.Modified;

            return dest;
        }
    }
}