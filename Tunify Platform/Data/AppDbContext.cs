using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;

namespace Tunify_Platform.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Subscripions> Subscripions { get; set; }
        public DbSet<Songs> Songs { get; set; }
        public DbSet<Playlists> Playlists { get; set; }
        public DbSet<Artists> Artists { get; set; }
        public DbSet<Albums> Albums { get; set; }
        public DbSet<PlaylistSongs> PlaylistSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define composite key for PlaylistSongs
            modelBuilder.Entity<PlaylistSongs>().HasKey(k => new { k.Song_Id, k.Playlist_Id });

            // Configure relationships
            modelBuilder.Entity<PlaylistSongs>().HasOne(k => k.Songs)
                .WithMany(s => s.PlaylistSongs)
                .HasForeignKey(k => k.Song_Id);

            modelBuilder.Entity<PlaylistSongs>().HasOne(k => k.Playlists)
                .WithMany(k => k.PlaylistSongs)
                .HasForeignKey(k => k.Playlist_Id);

            modelBuilder.Entity<Artists>().HasMany(k => k.Songs)
                .WithOne(k => k.Artists)
                .HasForeignKey(k => k.Artist_Id);

            // Seed data for Artists
            modelBuilder.Entity<Artists>().HasData(
                new Artists
                {
                    ArtistsId = 1,
                    Name = "Jadal",
                    Bio = "If not me then who? If not now then when?"
                },
                new Artists
                {
                    ArtistsId = 2,
                    Name = "Oasis",
                    Bio = "Rock and Roll band from Manchester"
                },
                new Artists
                {
                    ArtistsId = 3,
                    Name = "Adele",
                    Bio = "Singer-songwriter known for her deep, soulful voice"
                },
                new Artists
                {
                    ArtistsId = 4,
                    Name = "Coldplay",
                    Bio = "British rock band known for their melodic songs"
                }
            );

            // Seed data for Songs
            modelBuilder.Entity<Songs>().HasData(
                new Songs
                {
                    Album_Id = 1,
                    SongsId = 1,
                    Artist_Id = 1,
                    Title = "Love",
                    Duration = "2:00m",
                    Genre = "Romance"
                },
                new Songs
                {
                    Album_Id = 1,
                    SongsId = 2,
                    Artist_Id = 2,
                    Title = "Alo",
                    Duration = "2:54m",
                    Genre = "Romance"
                },
                new Songs
                {
                    Album_Id = 1,
                    SongsId = 3,
                    Artist_Id = 1,
                    Title = "Pain",
                    Duration = "3:30m",
                    Genre = "Romance"
                },
                new Songs
                {
                    Album_Id = 1,
                    SongsId = 4,
                    Artist_Id = 1,
                    Title = "Aloo",
                    Duration = "3:50m",
                    Genre = "Romance"
                }
            );

            // Seed data for Playlists
            modelBuilder.Entity<Playlists>().HasData(
                new Playlists
                {
                    PlaylistsId = 1,
                    User_Id = 1,
                    Created_Date = "20-2-2024",
                    Playlists_Name = "Love is Pain"
                },
                new Playlists
                {
                    PlaylistsId = 2,
                    User_Id = 1,
                    Created_Date = "04-7-2024",
                    Playlists_Name = "PainHub"
                }
            );

            // Seed data for Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Name = "Nory",
                    Email = "noormisk94@gmail.com",
                    Join_Date = "2-2-2022",
                    Subscription_ID = 1,
                },
                new User
                {
                    UserId = 2,
                    Name = "Misk",
                    Email = "noormisk94@gmail.com",
                    Join_Date = "2-2-2022",
                    Subscription_ID = 2,
                },
                new User
                {
                    UserId = 3,
                    Name = "Noor",
                    Email = "misk94@gmail.com",
                    Join_Date = "2-2-2022",
                    Subscription_ID = 3,
                },
                new User
                {
                    UserId = 4,
                    Name = "Aya",
                    Email = "aya94@gmail.com",
                    Join_Date = "2-2-2022",
                    Subscription_ID = 4,
                }
            );

            seedRole(modelBuilder, "Admin");
            seedRole(modelBuilder, "User");
        }


        private void seedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            // Seed the role
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            modelBuilder.Entity<IdentityRole>().HasData(role);

            // Add claims for the role if any permissions are provided
            if (permissions != null && permissions.Length > 0)
            {
                var roleClaims = permissions.Select(permission => new IdentityRoleClaim<string>
                {
                    RoleId = role.Id,
                    ClaimType = "Permission",
                    ClaimValue = permission
                }).ToArray();

                modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
            }
        }

    }
}



