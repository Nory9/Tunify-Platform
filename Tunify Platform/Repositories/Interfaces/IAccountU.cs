using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tunify_Platform.DTOs;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IAccountU
    {
        public Task<AccountDTO> Register(RegisterDTO registerDTO, ModelStateDictionary modelDictionary);

        public Task<AccountDTO> Login(string Name, string Password);

        public  Task Logout();
        
    }
}
