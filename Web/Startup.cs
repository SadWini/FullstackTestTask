using Domain.Interfaces;
using Domain.Web;
using Infrastracture;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using FluentValidation;
using Npgsql;

namespace Web;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder => builder
                        .WithOrigins("http://localhost:3000") // Allow only the React app
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        services.AddControllers();
        services.AddSwaggerGen(c=>{
            c.EnableAnnotations();
        });

        services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(_configuration.GetConnectionString("ApiDatabase")));
        services.AddScoped<IOrderRepository, OrderRepository>();
        
        services.AddValidatorsFromAssemblyContaining<OrderValidator>();
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors("AllowReactApp");
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.UseMiddleware<LoggerMiddleware>();

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}