using Shopping.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Shopping.Services
{
    public class StoreValueProvider : LabelValuePairProvider
    {
        private IStoreRepository repo;

        public StoreValueProvider(IStoreRepository repo)
        {
            this.repo = repo;
        }

        protected override Task<IEnumerable<ILabelValuePair>> GetSources()
        {
            return repo.GetLabels();
        }
    }
}
