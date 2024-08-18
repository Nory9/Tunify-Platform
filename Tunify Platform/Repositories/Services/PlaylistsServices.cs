using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class PlaylistsServices : IPlaylists
    {
        private readonly AppDbContext _context;

        public PlaylistsServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Playlists> AddPlaylist(Playlists Playlist)
        {
            _context.Playlists.Add(Playlist);
            await _context.SaveChangesAsync();
            return Playlist;
        }

        public async Task<Playlists> DeletePlaylist(Playlists playlist)
        {
            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();
            return playlist;
        }

        public async Task<IEnumerable<Playlists>> GetAllPlaylists()
        {
            var allPlaylists = await _context.Playlists.ToListAsync();
            return allPlaylists;
        }

        public async Task<Playlists> GetPlaylist(int id)
        {
            var palylist = await _context.Playlists.FindAsync(id);
            return palylist;
        }

        public async Task<Playlists> UpdatePlaylist(int id,Playlists Playlist)
        {
            var PlaylistToUpdate = await _context.Playlists.FindAsync(id);
            PlaylistToUpdate = Playlist;
            await _context.SaveChangesAsync();
            return PlaylistToUpdate;

        }

        // to add a song to a playlist
        public async Task<IActionResult> AddSongsToPlaylist(int song_id, int playlist_id) { 
        
            PlaylistSongs playlistSongs =new PlaylistSongs() { 
                Song_Id = song_id,  
                Playlist_Id = playlist_id
            };
            await _context.PlaylistSongs.AddAsync(playlistSongs);
            await _context.SaveChangesAsync();
            return new JsonResult(playlistSongs); //?
        }

    }
}
