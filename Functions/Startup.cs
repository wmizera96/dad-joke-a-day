using Functions.Core;
using Functions.Infrastructure;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Persistence;
using System;

[assembly: FunctionsStartup(typeof(Functions.Startup))]

namespace Functions
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<RapidApiOptions>().Configure<IConfiguration>((options, configuration) =>
            {
                configuration.GetSection(nameof(RapidApiOptions)).Bind(options);
            });

            builder.Services.AddOptions<ConnectionStringsOptions>().Configure<IConfiguration>((options, configuration) => {
                configuration.GetSection(nameof(ConnectionStringsOptions)).Bind(options);
            });


            builder.Services.AddHttpClient<IJokeService, JokeService>((provider, client) =>
            {
                var options = provider.GetService<IOptions<RapidApiOptions>>();
                client.BaseAddress = new Uri(options.Value.Endpoint);
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", options.Value.Host);
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", options.Value.ApiKey);
            });

            builder.Services.AddDbContext<DataContext>((provider, options) => {
                var connectionStrings = provider.GetService<IOptions<ConnectionStringsOptions>>();
                options.UseSqlServer(connectionStrings.Value.SqlServer);
            });
        }
    }
}
