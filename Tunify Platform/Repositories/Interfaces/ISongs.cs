using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface ISongs
    {
        Task<IEnumerable<Songs>> GetAllSongs();
        Task<Songs> GetSongs(int id);
        Task<Songs> AddSongs(Songs song);
        Task<Songs> UpdateSong(Songs song);
        Task<Songs> DeleteSongs(Songs song);
    }
}
