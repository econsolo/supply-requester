using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SupplyRequester.Apresentation.Configuration.Business;
using SupplyRequester.Apresentation.Configuration.Filter;
using SupplyRequester.Apresentation.Configuration.Infrastructure;
using SupplyRequester.Apresentation.Configuration.Middleware;
using SupplyRequester.Util.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SupplyRequester.Apresentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions<SupplyRequesterSettings>().Configure<IConfiguration>((settings, configuration) =>
            {
                configuration.Bind(settings);
            });

            ConfigureSwaggerGen(services);

            InjectDependencies(services);

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<AuthorizationMiddleware>();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Supply Requester");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InjectDependencies(IServiceCollection services)
        {
            services.InjectMappers();
            services.InjectServices();
            services.InjectRepositories();
        }

        private void ConfigureSwaggerGen(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Supply Requester",
                        Version = "v1",
                        Description = "Supply Requester for homes",
                        Contact = new OpenApiContact
                        {
                            Name = "Erick Cônsolo",
                            Url = new Uri("https://github.com/econsolo")
                        }
                    });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Security Token by SupplyRequester",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });


                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "Authorization",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });

                c.OperationFilter<SwaggerOperationFilter>();
            });
        }
    }
}
