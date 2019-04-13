using CodeBattle.Interfaces;
using CodeBattle.Models;
using CodeBattle.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeBattle
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; set; }

        public Startup(IConfiguration configuration)
        {
            AppConfiguration = configuration;
        }
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
            // Инициализация сервиса SignalR
            services.AddSignalR(hubOptions =>
            {
                // Возвращает клиенту детальное описание возникшей ошибки 
                //(при ее возникновении)
                hubOptions.EnableDetailedErrors = true;
            });
            // конфигурация IOptions
            services.Configure<_Options>(options =>
            {
                options.Connection_str = "mongodb://localhost:27017";
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<MapService>();
            services.AddScoped<ICodeBattle<Player>, PlayerService>();
            services.AddScoped<ICodeBattle<User>, RegService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseSignalR(routes =>
            {
                routes.MapHub<SignalR>("/signalr",
                    options => {
                        // Настраивает транспорт WebSocket.
                        options.Transports = HttpTransportType.LongPolling | HttpTransportType.WebSockets;
                    });
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "PlayerController",
                    template: "{controller}/{id?}");
            });
        }
    }
}
