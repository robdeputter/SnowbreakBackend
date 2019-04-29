using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.SwaggerGeneration.Processors.Security;
using Snowboard_MTB_WEB4.Data;
using Snowboard_MTB_WEB4.Model;
using Snowboard_WEB4.Data;
using Snowboard_WEB4.Data.Repositories;
using Snowboard_WEB4.Model;

namespace Snowboard_MTB_WEB4
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
            services.AddDbContext<SnowbreakDbContext>(options =>
              options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddScoped<SnowbreakDataInitializer>();
            services.AddScoped<IEvenementRepository, EvenementRepository>();
            services.AddScoped<IRankingRepository, RankingRepository>();
            services.AddScoped<IGebiedRepository, GebiedRepository>();
            services.AddScoped<IGebruikerRepository, GebruikerRepository>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddOpenApiDocument(c =>
            {
                c.DocumentName = "apidocs"; c.Title = "Snowbreak API"; c.Version = "v1";
                c.Description = "The Snowbreak API documentation description.";
                c.DocumentProcessors.Add(new SecurityDefinitionAppender("JWT Token", new SwaggerSecurityScheme
                {
                    Type = SwaggerSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = SwaggerSecurityApiKeyLocation.Header,
                    Description = "Copy 'Bearer' + valid JWT token into field"
                }));
                c.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT Token"));
            });
            services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder =>
                builder.AllowAnyOrigin()));

            services.AddIdentity<IdentityUser, IdentityRole>(cfg => cfg.User.RequireUniqueEmail = true)
                .AddEntityFrameworkStores<SnowbreakDbContext>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true//Ensure token hasn't expired
                };
            });

            //Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                //Password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                //Lockout
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                //User
                options.User.AllowedUserNameCharacters =
                                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SnowbreakDataInitializer sbdInit)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseMvc();

            app.UseSwaggerUi3();
            app.UseSwagger();

            app.UseCors("AllowAllOrigins");

            sbdInit.InitializeData().Wait();


        }
    }
}
