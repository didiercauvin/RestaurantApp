using Microsoft.Extensions.DependencyInjection.Extensions;
using Neo4j.Driver.V1;
using RestaurantApp.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Neo4jService
    {
        public static IServiceCollection AddNeo4jDriver(this IServiceCollection services, string connectionString, string username, string password)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            
            services.TryAdd(ServiceDescriptor.Transient<IDriver>(x => GraphDatabase.Driver(connectionString, AuthTokens.Basic(username, password))));

            return services;
        }
    }
}
