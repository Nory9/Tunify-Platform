using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IArtists
    {
        Task<IEnumerable<Artists>> GetAllArtists();
        Task<Artists> GetArtist(int id);
        Task<Artists> AddArtist(Artists Artist);
        Task<Artists> UpdateArtist(int id, Artists Artist);
        Task<Artists> DeleteArtist(Artists Artist);
    }
}
