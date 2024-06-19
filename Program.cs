
using Microsoft.EntityFrameworkCore;
using WebAPIWishList.Data;
using WebAPIWishList.Interfaces;
using WebAPIWishList.Repository;

namespace WebAPIWishList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IWishListRepository, WishListRepository>();
            builder.Services.AddDbContext<WLContext>(options => {
                options.UseNpgsql(builder.Configuration.GetConnectionString("WishListDataBase"));
            });

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
