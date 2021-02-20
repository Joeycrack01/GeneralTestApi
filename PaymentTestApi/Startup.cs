using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediSmartTestApi.Utilities;
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
using PaymentTestApi.ApplicationService;
using PaymentTestApi.ApplicationService.CheapPaymentGatewayService;
using PaymentTestApi.ApplicationService.ExpensivePaymentGatewayService;
using PaymentTestApi.ApplicationService.PremiumPaymentService;
using PaymentTestApi.ApplicationService.ProcessPayment;
using PaymentTestApi.ApplicationService.ProcessPaymentProvider;
using PaymentTestApi.ApplicationService.ValidatePaymentRequest;

namespace MediSmartTestApi
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
            services.AddControllers().AddNewtonsoftJson();
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connection, x => x.MigrationsAssembly("PaymentTestApi")));
            services.AddScoped<IPaymentProcessorProvider, ExpensivePaymentGatewayProvider>();
            services.AddScoped<IPaymentProcessorProvider, CheapPaymentGatewayProvider>();
            services.AddScoped<IPaymentProcessorProvider, PremiumPaymentGatewayProvider>();
            services.AddScoped<ICheapPaymentGateway, CheapPaymentGateway>();
            services.AddScoped<IExpensivePaymentGateway, ExpensivePaymentGateway>();
            services.AddScoped<IPremiumPaymentGateway, PremiumPaymentGateway>();
            services.AddScoped<IValidatePaymentRequest, ValidatePaymentRequest>();
            services.AddScoped<IProcessPaymentService, ProcessPaymentService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Filed Interview Test",
                    Description = "Filed Interview Test Api",
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();

            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Medi Smart Test");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
