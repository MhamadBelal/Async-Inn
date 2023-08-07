using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AsyncInn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            builder.Services.AddTransient<IHotel, HotelsSevice>();
            builder.Services.AddTransient<IRoom, RoomsService>();
            builder.Services.AddTransient<IAmenity, AmenitiesService>();
            builder.Services.AddTransient<IHotelRoom, HotelRoomRepository>();

            string connString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AsyncInnDbContext>(options=> options.UseSqlServer(connString));

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "AsyncInn API",
                    Version = "v1",
                });
            });

            var app = builder.Build();

            app.UseSwagger(options =>
            {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(aptions =>
            {
                aptions.SwaggerEndpoint("/api/v1/swagger.json", "AsyncInn API");
                aptions.RoutePrefix = "docs";
            });

            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}