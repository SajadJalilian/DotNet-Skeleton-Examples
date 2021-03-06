using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consumer.Consumer;
using Consumer.Persistence;
using Consumer.Persistence.Repository;
using Consumer.Persistence.Repository.Interfaces;
using Contracts.Models;
using MassTransit;
using MediatR;
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

namespace Consumer
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Consumer", Version = "v1" });
            });
            
            // MediatR
            services.AddSingleton<IStudentRepo, StudentRepo>();
            services.AddMediatR(typeof(Startup).Assembly);
            
            // Masstransit
            services.AddMassTransit(config => {

                config.AddConsumer<StudentBusRequestConsumer>();

                config.UsingRabbitMq((ctx, cfg) => {
                    cfg.Host("amqp://guest:guest@localhost:5672");

                    cfg.ReceiveEndpoint("student-queue", c => {
                        c.ConfigureConsumer<StudentBusRequestConsumer>(ctx);
                    });
                });
            });

            services.AddMassTransitHostedService();
            
            services.AddDbContext<AppDbContext>(x =>
                x.UseNpgsql("Host=localhost;Port=5432;Database=cqrs_masstransit;Username=blue;Password=blue"));
            
            // services.AddDbContext<AppDbContext>(options =>
            //     options.UseNpgsql(Configuration.GetConnectionString("BloggingContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Consumer v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}