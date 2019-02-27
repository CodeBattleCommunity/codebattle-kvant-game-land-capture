using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Extensions.DependencyInjection;

namespace CodeBattle
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Инициализация сервиса SignalR
            services.AddSignalR(hubOptions =>
            {
                // Возвращает клиенту детальное описание возникшей ошибки 
                //(при ее возникновении)
                hubOptions.EnableDetailedErrors = true;

                // Если в течение этого периода сервер не отправит никаких сообшений,
                // то автоматически отправляется ping-сообщение для поддержания подключения открытым
                // (1 minute)
                hubOptions.KeepAliveInterval = System.TimeSpan.FromMinutes(1); //
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSignalR(routes =>
            {
                routes.MapHub<SignalR>("/signalr",
                    options => {
                        // Максимальный размер буфера в байтах, в который сервер помещает получаемые от клиента данные. (64)
                        options.ApplicationMaxBufferSize = 64;
                        // Максимальный размер буфера в байтах, в который сервер помещает данные для отправки клиенту. (64)
                        options.TransportMaxBufferSize = 64;
                        // Устанавливает периодичность опроса (1 minute)
                        options.LongPolling.PollTimeout = System.TimeSpan.FromMinutes(1);
                        // Настраивает транспорт WebSocket.
                        options.Transports = HttpTransportType.LongPolling | HttpTransportType.WebSockets;
                    });
            });
        }
    }
}
