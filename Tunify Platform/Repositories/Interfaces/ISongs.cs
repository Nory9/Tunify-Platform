using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface ISongs
    {
        Task<IEnumerable<Songs>> GetAllSongs();
        Task<Songs> GetSong(int id);
        Task<Songs> AddSong(Songs song);
        Task<Songs> UpdateSong(int id, Songs song);
        Task<Songs> DeleteSong( Songs song);
    }
}
