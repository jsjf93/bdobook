using System;
using System.Net.Http;
using BDOBook.Application.Middleware;
using BDOBook.Data;
using BDOBook.Services;
using BDOBook.Services.Interfaces;
using FileContextCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BDOBook
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options => options.UseFileContextDatabase(location: "..\\_database"));
            services.AddRazorPages();

            var apiToken = Configuration.GetValue<string>("NewsApiKey");
            var httpClientFactory = services.AddHttpClient(
                nameof(NewsService),
                client =>
                {
                    client.BaseAddress = new Uri("https://api.thenewsapi.com/v1/news/");
                });

            services.AddSingleton<INewsService>(ctx => new NewsService(apiToken, ctx.GetRequiredService<IHttpClientFactory>()));

            services.AddSingleton<SecurityHeadersMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<SecurityHeadersMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
