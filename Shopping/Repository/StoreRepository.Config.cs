using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Threax.ReflectedServices;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shopping.Repository;

namespace Shopping.Repository.Config
{
    public partial class StoreRepositoryConfig : IServiceSetup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            OnConfigureServices(services);

            services.TryAddScoped<IStoreRepository, StoreRepository>();
        }

        partial void OnConfigureServices(IServiceCollection services);
    }
}