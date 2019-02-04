using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Resort.WebUI.Controllers;
using Resort.WebUI.Services;
using Swashbuckle.AspNetCore.Swagger;


namespace Resort.WebUI
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
            // Google API for OAuth2
            services.AddAuthentication().AddGoogle(options =>
            {
                // Provide the Google Client ID
                options.ClientId = Configuration ["Google:ClientId"];
                // Provide the Google Secret
                options.ClientSecret = Configuration ["Google:ClientSecret"];
                options.Scope.Add("https://www.googleapis.com/auth/plus.login");
                options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
                options.SaveTokens = true;
                options.Events.OnCreatingTicket = ctx =>
                {
                    List<AuthenticationToken> tokens = ctx.Properties.GetTokens() 
                        as List<AuthenticationToken>;
                    tokens.Add(new AuthenticationToken()
                    {
                        Name = "TicketCreated", 
                        Value = DateTime.UtcNow.ToString()
                    });
                    ctx.Properties.StoreTokens(tokens);
                    return Task.CompletedTask;
                };
            });

            services.AddTransient<IMessageService, FileMessageService>();
            // configure token generation
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();
            
            // configure identity options
            services.Configure<IdentityOptions>(o => {
                o.SignIn.RequireConfirmedEmail = true;
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "vKirirom", Version = "v1" });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin API V1");
            });
            app.UseCors(b => b.WithOrigins("https://localhost:5001")
                .AllowAnyOrigin()
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseIdentity();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
