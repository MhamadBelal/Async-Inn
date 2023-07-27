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

            builder.Services.AddTransient<IHotel, HotelsSevice>();
            builder.Services.AddTransient<IRoom, RoomsService>();
            builder.Services.AddTransient<IAmenity, AmenitiesService>();

            string connString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AsyncInnDbContext>(options=> options.UseSqlServer(connString));

            var app = builder.Build();


            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}