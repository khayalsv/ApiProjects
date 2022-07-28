using FluentValidation.AspNetCore;
using KSApi.Data;
using KSApi.Middlewares;
using KSApi.Repository;
using KSApi.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KSApi
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

            services.AddControllers().AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<Startup>();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KSApi", Version = "v1" });
            });

            services.AddSingleton<IUser, User>();

            services.AddSingleton<ISingletonOperation, Operation>();
            services.AddScoped<IScopedOperation, Operation>();
            services.AddTransient<ITransientOperation, Operation>();


            services.Configure<PositionOptions>(Configuration.GetSection(PositionOptions.Position));

            services.AddDbContext<MyContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

         
            services.AddTransient<IStudentRepository, StudentRepository>();

            services.AddTransient(typeof(IRepository<,>), typeof(EfRepository<,>));

            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "example.com",
                        ValidAudience = "example.com",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SigningKey"]))
                    };
                });



            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));

                options.AddPolicy("SuperUser",
                    policy => policy.RequireClaim(ClaimTypes.Role, "Admin")
                                    .RequireClaim(ClaimTypes.Role, "User"));

                options.AddPolicy(
                    "OneOfTheRoles",
                    policy => policy.RequireAssertion(
                        context => context.User.HasClaim(claim => claim.Type == ClaimTypes.Role &&
                                                                  claim.Value is "Admin" or "User"))
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KSApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseMiddleware<JwtMiddleware>();

            app.UseAuthentication();
         

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
