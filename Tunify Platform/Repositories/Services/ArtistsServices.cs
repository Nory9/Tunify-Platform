using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class ArtistsServices : IArtists
    {
        private readonly AppDbContext _context;
        public ArtistsServices(AppDbContext context) { 
        
            _context = context;
        }
        public async Task<Artists> AddArtist(Artists artist)
        {
            _context.Artists.Add(artist);  
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task<Artists> DeleteArtist(Artists Artist)
        {
            _context.Artists.Remove(Artist);
            await _context.SaveChangesAsync();
            return Artist;
        }

        public async Task<IEnumerable<Artists>> GetAllArtists()
        {
            var AllArtists = await _context.Artists.ToListAsync();
            return AllArtists;
        }

        public async Task<Artists> GetArtist(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            return artist;
        }

        public async Task<Artists> UpdateArtist(int id, Artists Artist)
        {
            var existingArtist = await _context.Artists.FindAsync(id);
            existingArtist=Artist;
            await _context.SaveChangesAsync();
            return existingArtist;
        }
    }
}
