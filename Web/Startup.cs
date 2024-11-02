using Domain.Interfaces;
using Domain.Web;
using Infrastracture;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
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
        services.AddControllers();
        services.AddSwaggerGen(c=>{
            c.EnableAnnotations();
        });
        

        services.AddSingleton<IOrderRepository, OrderRepository>();

        services.AddValidatorsFromAssemblyContaining<OrderValidator>();
        var connectionString = _configuration["PostgreSql:ConnectionString"];
        var dbPassword = _configuration["PostgreSql:DbPassword"];
        var builder = new NpgsqlConnectionStringBuilder(connectionString)
        {
            Password = dbPassword
        };
        services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.ConnectionString));
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseMiddleware<LoggerMiddleware>();

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}