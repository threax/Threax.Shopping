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
        public ItemEntity MapItem(ItemInput src, ItemEntity dest)
        {
            //dest.ItemId ignored
            dest.Description = src.Description;
            dest.StoreId = src.StoreId;
            dest.Created = GetCreated(dest.Created);
            dest.Modified = DateTime.UtcNow;

            return dest;
        }

        public Item MapItem(ItemEntity src, Item dest)
        {
            dest.ItemId = src.ItemId;
            dest.Description = src.Description;
            dest.StoreId = src.StoreId;
            dest.Created = src.Created;
            dest.Modified = src.Modified;

            return dest;
        }
    }
}