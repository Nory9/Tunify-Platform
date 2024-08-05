using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;

namespace Tunify_Platform.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options) {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Subscripions> Subscripions { get; set; }
        public DbSet<Songs> songs { get; set; }
        public DbSet<Playlists> Playlists { get; set; }
        public DbSet<Artists> Artists { get; set; }
        public DbSet<Albums> Albums { get; set; }
        public DbSet<PlaylistSongs> PlaylistSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Name = "nory",
                    Email = "noormisk94@gmail.com",
                    Join_Date = "2-2-2022",
                    Subscription_ID = 1,
                },
                new User
                {
                    UserId = 2,
                    Name = "misk",
                    Email = "noormisk94@gmail.com",
                    Join_Date = "2-2-2022",
                    Subscription_ID = 2,
                },
                new User
                {
                    UserId = 3,
                    Name = "noor",
                    Email = "misk94@gmail.com",
                    Join_Date = "2-2-2022",
                    Subscription_ID = 3,
                },
                new User
                {
                    UserId = 4,
                    Name = "aya",
                    Email = "aya94@gmail.com",
                    Join_Date = "2-2-2022",
                    Subscription_ID = 4,
                }
                );

            modelBuilder.Entity<Songs>().HasData(
                new Songs
                {
                    Album_Id = 1,
                    SongsId = 1,
                    Artist_Id = 1,
                    Title = "love",
                    Duration = "2:00m",
                    Genre = "romance"
                },
                new Songs
                {
                    Album_Id = 1,
                    SongsId = 2,
                    Artist_Id = 2,
                    Title = "alo",
                    Duration = "2:54m",
                    Genre = "romance"
                },
                new Songs
                {
                    Album_Id = 1,
                    SongsId = 3,
                    Artist_Id = 1,
                    Title = "pain",
                    Duration = "3:30m",
                    Genre = "romance"
                },
                new Songs
                {
                    Album_Id = 1,
                    SongsId = 4,
                    Artist_Id = 1,
                    Title = "aloo",
                    Duration = "3:50m",
                    Genre = "romance"
                }
                );

            modelBuilder.Entity<Playlists>().HasData(
                new Playlists
                {
                    PlaylistsId = 1,
                    User_Id = 1,
                    Created_Date = "20-2-2024",
                    Playlists_Name = "love is pain"
                },
                new Playlists
                {
                    PlaylistsId = 2,
                    User_Id = 1,
                    Created_Date = "04-7-2024",
                    Playlists_Name = "painHub"
                }
                );
        }

    }
}
