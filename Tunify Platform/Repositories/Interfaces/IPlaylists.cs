using Microsoft.AspNetCore.Mvc;
using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IPlaylists
    {
        Task<IEnumerable<Playlists>> GetAllPlaylists();
        Task<Playlists> GetPlaylist(int id);
        Task<Playlists> AddPlaylist(Playlists playlist);
        Task<Playlists> UpdatePlaylist(int id, Playlists Playlist);
        Task<Playlists> DeletePlaylist(Playlists playlist);

        Task<IActionResult> AddSongsToPlaylist(int song_id, int playlist_id);
    }
}
