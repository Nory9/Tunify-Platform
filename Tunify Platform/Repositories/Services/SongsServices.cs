using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class SongsServices : ISongs
    {
        public Task<Songs> AddSongs(Songs song)
        {
            throw new NotImplementedException();
        }

        public Task<Songs> DeleteSongs(Songs song)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Songs>> GetAllSongs()
        {
            throw new NotImplementedException();
        }

        public Task<Songs> GetSongs(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Songs> UpdateSong(Songs song)
        {
            throw new NotImplementedException();
        }
    }
}
