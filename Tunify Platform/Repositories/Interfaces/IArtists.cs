using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IArtists
    {
        Task<IEnumerable<Artists>> GetAllArtists();
        Task<User> GetArtist(int id);
        Task<User> AddArtist(Artists Artist);
        Task<User> UpdateArtist(Artists Artist);
        Task<User> DeleteArtist(Artists Artist);
    }
}
