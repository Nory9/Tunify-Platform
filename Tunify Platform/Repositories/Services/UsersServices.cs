using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class UsersServices : IUser
    {
        private readonly AppDbContext _context;

        public UsersServices(AppDbContext context) { 
         
            _context= context;
        }
        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
           await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUser(User user)
        {

          _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
           var allUsers= await _context.Users.ToListAsync();
            return allUsers;
        }

        public async Task<User> GetUser(int id)
        {
            var user =  await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<User> UpdateUser(int id, User user)
        {
            var UserToUpdate =await _context.Users.FindAsync(id);
            UserToUpdate = user;
            await _context.SaveChangesAsync();
            return UserToUpdate;

        }
    }
}
