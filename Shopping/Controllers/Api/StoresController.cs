using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopping.Repository;
using Threax.AspNetCore.Halcyon.Ext;
using Shopping.ViewModels;
using Shopping.InputModels;
using Shopping.Models;
using Microsoft.AspNetCore.Authorization;

namespace Shopping.Controllers.Api
{
    [Route("api/[controller]")]
    [ResponseCache(NoStore = true)]
    [Authorize(AuthenticationSchemes = AuthCoreSchemes.Bearer, Roles = Roles.EditStores)]
    public partial class StoresController : Controller
    {
        private IStoreRepository repo;

        public StoresController(IStoreRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [HalRel(CrudRels.List)]
        public async Task<StoreCollection> List([FromQuery] StoreQuery query)
        {
            return await repo.List(query);
        }

        [HttpGet("{StoreId}")]
        [HalRel(CrudRels.Get)]
        public async Task<Store> Get(Guid storeId)
        {
            return await repo.Get(storeId);
        }

        [HttpPost]
        [HalRel(CrudRels.Add)]
        [AutoValidate("Cannot add new store")]
        public async Task<Store> Add([FromBody]StoreInput store)
        {
            return await repo.Add(store);
        }

        [HttpPut("{StoreId}")]
        [HalRel(CrudRels.Update)]
        [AutoValidate("Cannot update store")]
        public async Task<Store> Update(Guid storeId, [FromBody]StoreInput store)
        {
            return await repo.Update(storeId, store);
        }

        [HttpDelete("{StoreId}")]
        [HalRel(CrudRels.Delete)]
        public async Task Delete(Guid storeId)
        {
            await repo.Delete(storeId);
        }
    }
}