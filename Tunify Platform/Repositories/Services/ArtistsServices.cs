using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class ArtistsServices : IArtists
    {
        public Task<User> AddArtist(Artists Artist)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteArtist(Artists Artist)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Artists>> GetAllArtists()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetArtist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateArtist(Artists Artist)
        {
            throw new NotImplementedException();
        }
    }
}
