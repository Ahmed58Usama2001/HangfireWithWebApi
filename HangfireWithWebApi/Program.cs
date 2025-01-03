
using ApplicationLayer.Mappings;
using ApplicationLayer.Services;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HangfireWithWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Register Repositories and Unit of Work
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register Services
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
