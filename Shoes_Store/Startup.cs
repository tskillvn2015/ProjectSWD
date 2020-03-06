using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Shoes_Store.Data.EF;
using Shoes_Store.Data.Interfaces;
using Shoes_Store.Data.Repositories;
using Shoes_Store.Data.Service;
using Swashbuckle.AspNetCore.Swagger;

namespace Shoes_Store
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
            //Validate Token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    //what to validate
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    //setup validate data
                    ValidIssuer = Configuration["Tokens:Issuer"],
                    IssuerSigningKey = key
                };
            });

            services.AddDbContext<ShoeserDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ShoeserSolutionDb"]));
            //DI
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                  options.SerializerSettings.ContractResolver =
                     new DefaultContractResolver());


            //Swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Shoeser Project Project",
                    Description = "Shoeser API Swagger surface",
                });

                //First we define the security scheme
                s.AddSecurityDefinition("Bearer", //Name the security scheme
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.",
                        Type = SecuritySchemeType.Http, //We set the scheme type to http since we're using bearer authentication
                        Scheme = "bearer" //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
                    });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement{
                {
                    new OpenApiSecurityScheme{
                        Reference = new OpenApiReference{
                            Id = "Bearer", //The name of the previously defined security scheme.
                            Type = ReferenceType.SecurityScheme
                        }
                    },new List<string>()
                }
                });
            });
            //////////////////////////
            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //middleWare Exception handle
            app.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                    if (ex == null) return;

                    var error = new
                    {
                        message = ex.Message
                    };

                    context.Response.ContentType = "application/json";
                    context.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
                    context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { Configuration["AllowedHosts"] });

                    using (var writer = new StreamWriter(context.Response.Body))
                    {
                        new JsonSerializer().Serialize(writer, error);
                        await writer.FlushAsync().ConfigureAwait(false);
                    }
                });
            });
            /////////////////////////////////////////////////
            ///
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //swagger
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((document, request) =>
                {
                    var paths = document.Paths.ToDictionary(item => item.Key.ToLowerInvariant(), item => item.Value);
                    document.Paths.Clear();
                    foreach (var pathItem in paths)
                    {
                        document.Paths.Add(pathItem.Key, pathItem.Value);
                    }
                });
            });

            // Enable the Swagger UI middleware and the Swagger generator
            app.UseSwaggerUI(s => { s.SwaggerEndpoint("/swagger/v1/swagger.json", "Project API v1.1"); });
            /////////////////////////////

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
