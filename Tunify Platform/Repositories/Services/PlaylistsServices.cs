using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class PlaylistsServices : IPlayLists
    {
        public Task<Playlists> AddPlaylist(Playlists Playlist)
        {
            throw new NotImplementedException();
        }

        public Task<Playlists> DeletePlaylist(Playlists Playlist)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Playlists>> GetAllPlaylists()
        {
            throw new NotImplementedException();
        }

        public Task<Playlists> GetPlaylist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Playlists> UpdatePlaylist(Playlists Playlist)
        {
            throw new NotImplementedException();
        }
    }
}
