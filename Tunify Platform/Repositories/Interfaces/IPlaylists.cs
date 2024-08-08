using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IPlayLists
    {
        Task<IEnumerable<Playlists>> GetAllPlaylists();
        Task<Playlists> GetPlaylist(int id);
        Task<Playlists> AddPlaylist(Playlists Playlist);
        Task<Playlists> UpdatePlaylist(Playlists Playlist);
        Task<Playlists> DeletePlaylist(Playlists Playlist);
    }
}
