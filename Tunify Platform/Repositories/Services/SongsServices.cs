using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class SongsServices : ISongs
    {
        private readonly AppDbContext _context;

        public SongsServices(AppDbContext context)
        {
            _context = context;
        }

            public async Task<Songs> AddSong(Songs song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task<Songs> DeleteSong(Songs song)
        {
            _context.Songs.Remove(song);    
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task<IEnumerable<Songs>> GetAllSongs()
        {
            var AllSongs = await _context.Songs.ToListAsync();
            return AllSongs;
        }

        public async Task<Songs> GetSong(int id)
        {
            var song= await _context.Songs.FindAsync(id);
            return song;
           
        }

        public async Task<Songs> UpdateSong(int id, Songs song)
        {
            var existingSong = await _context.Songs.FindAsync(id);
            existingSong = song;
            await _context.SaveChangesAsync();
            return existingSong;
        }
    }
}
