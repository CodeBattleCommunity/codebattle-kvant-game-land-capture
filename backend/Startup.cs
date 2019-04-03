using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using VueCliMiddleware;

using CodeBattle.PointWar.Server.Models;
using System.Collections.Generic;
using CodeBattle.PointWar.Server.Services;
using CodeBattle.PointWar.Server.Interfaces;

namespace CodeBattle.PointWar.Server
{
  public class Startup
  {

    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      // In production, the files will be served from this directory
      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "wwwroot/dist";
      });

      services.Configure<CookiePolicyOptions>(options =>
      {
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddCors(options => options.AddPolicy("CorsPolicy",
      builder =>
      {
        builder.AllowAnyMethod().AllowAnyHeader()
                     .WithOrigins("http://localhost:5001")
                     .AllowCredentials();
      }));

      // Инициализация сервиса SignalR
      services.AddSignalR(hubOptions =>
      {
              // Возвращает клиенту детальное описание возникшей ошибки 
              //(при ее возникновении)
              hubOptions.EnableDetailedErrors = true;
      });

      services.AddScoped<ICodeBattle<Map>, MapService>();
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
        app.UseHttpsRedirection();
      }

      app.UseStaticFiles();
      app.UseSpaStaticFiles();

      app.UseHttpsRedirection();
      app.UseCookiePolicy();
      app.UseCors("CorsPolicy");

      app.UseMvc(routes =>
      {
        routes.MapRoute(
            name: "default",
            template: "{controller}/{action=Index}/{id?}"
        );
      });

      app.UseSignalR(routes =>
      {
        routes.MapHub<Bot>("/command",
                  options =>
              {
                      // Настраивает транспорт WebSocket.
                      options.Transports = HttpTransportType.LongPolling | HttpTransportType.WebSockets;
              });
      });

      app.UseSpa(spa =>
      {
        spa.Options.SourcePath = "wwwroot";
#if DEBUG
        if (env.IsDevelopment())
        {
          //spa.UseVueCli(npmScript: "serve", port: 8080, regex: "Compiled ");
          spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
        }
#endif
      });
    }
  }
}
