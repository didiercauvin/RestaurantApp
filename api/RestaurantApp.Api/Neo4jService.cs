using Microsoft.Extensions.DependencyInjection.Extensions;
using Neo4j.Driver.V1;
using RestaurantApp.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Neo4jService
    {
        public static IServiceCollection AddNeo4jDriver(this IServiceCollection services, IConfigurationRoot config)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.TryAdd(ServiceDescriptor.Transient<IDriver>(x => GraphDatabase.Driver(config["Neo4j:connectionString"], AuthTokens.Basic(config["Neo4j:username"], config["Neo4j:password"]))));

            return services;
        }
    }
}
