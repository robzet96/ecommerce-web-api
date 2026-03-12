using ecommerce_web_api.Data;
using ecommerce_web_api.Models;
using ecommerce_web_api.Repositories;
using ecommerce_web_api.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace ecommerce_web_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICrudRepository<Product>, ProductRepository>();
            builder.Services.AddScoped<ICrudRepository<Order>, OrderRepository>();

            builder.Services.AddScoped<ICrudService<Product>, ProductService>();
            builder.Services.AddScoped<ICrudService<Order>, OrderService>();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
                ));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
