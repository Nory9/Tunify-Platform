using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;
using Tunify_Platform.Repositories.Services;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            var ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");

            // Identity configuration  
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<AppDbContext>();

            //// configue swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Tunify",
                    Description = "This is a platform for music",
                    Version = "1.0.0"
                });
            });



            builder.Services.AddDbContext<AppDbContext>(optionsX => optionsX.UseSqlServer(ConnectionStringVar));
            builder.Services.AddScoped<IUser, UsersServices>();
            builder.Services.AddScoped<IPlaylists, PlaylistsServices>();
            builder.Services.AddScoped<ISongs, SongsServices>();
            builder.Services.AddScoped<IArtists, ArtistsServices>();
            builder.Services.AddScoped<IAccountU, AccountServices>();




            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tunify API V1");
                c.RoutePrefix = string.Empty;
            });

            app.MapControllers();
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
