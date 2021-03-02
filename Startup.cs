using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using ShopRUs_API.Helpers;
using ShopRUs_API.ShopRu.DataAccess.DBContext;
using ShopRUs_API.ShopRu.DataAccess.helper;
using ShopRUs_API.ShopRu.DataAccess.Interface;
using ShopRUs_API.ShopRu.ServiceLayer.Services;

namespace ShopRUs_API
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
            services.AddControllers();

            //register the interfaces
            services.AddScoped<ICustomer, CustomerRepository>();
            services.AddTransient<IDiscount, DiscountRepository>();
            services.AddTransient<Iinvoice, InvoiceRepository>();

            services.AddTransient<Microsoft.Extensions.Logging.ILogger>(provider =>
               provider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<AnyClass>>());

            //important for json serialization Support -- input and output json formatter
            services.AddControllers()
                     .AddNewtonsoftJson(options =>
                     {
                         options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                         options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                     });

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection2")));

            //Swagger configuration 
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                       
                    Title = "ShopRUs API Service",
                    Version = "v2",
                    Description = "A Retail Api that provides Discounts to their customers base on different types, " +
                    "create customer, get List of Customers, create Discount, get specific discounts and the likes.",
                });

                // -- provided security is implemented

                //For Authorization Key Button to come up, and to activate token from SwaggerUI
                options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });

                //Helps to tell swagger which of our actions require Authorization. 
                options.OperationFilter<AuthenticationRequirementsOperationFilter>();

                services.AddMvcCore().AddApiExplorer();  // Service Needed for swagger to work with .netcoremvc

                services.AddMvc()
                    .AddControllersAsServices();

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            //Middleware for swagger 
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "ShopRUs Api"));
        }
    }
}
