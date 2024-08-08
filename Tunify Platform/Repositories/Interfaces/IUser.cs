using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(int id, User user);
        Task<User> DeleteUser(User user);
    }
}
