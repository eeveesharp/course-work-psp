using matallurgical_plant.Services;
using matallurgical_plant.Services.Emplimentation;
using matallurgical_plant.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matallurgical_plant
{
    public static class Di
    {
        public static void IoC(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IContractService, ContractService>();
            services.AddTransient<IProviderService, ProviderService>();
        }
    }
}
