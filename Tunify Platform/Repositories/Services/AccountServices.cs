using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tunify_Platform.DTOs;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class AccountServices : IAccountU
    {

        private UserManager<ApplicationUser> _userManager; 
        private SignInManager<ApplicationUser> _signInManager;

        public AccountServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AccountDTO> Login(string Name, string Password)
        {
            var user =await  _userManager.FindByNameAsync(Name);

            bool checkPassword =  await _userManager.CheckPasswordAsync(user, Password);

            if (checkPassword) {

                return new AccountDTO
                {

                    Name = user.UserName,
                    Id = user.Id,

                };
            }
            return null;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<AccountDTO> Register(RegisterDTO registerDTO, ModelStateDictionary modelDictionary)
        {
            var user = new ApplicationUser
            {

                UserName = registerDTO.Name,
                Email = registerDTO.Email
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password); // to hash the password

            if (result.Succeeded) {

                return new AccountDTO
                {

                    Name = user.UserName,
                    Id = user.Id
                };
            
            }

            foreach (var error in result.Errors) {

                var errorCode = error.Code.Contains("Pass") ? nameof(registerDTO) :
                    error.Code.Contains("Email") ? nameof(registerDTO) :
                    error.Code.Contains("Name") ? nameof(registerDTO) : " ";
            }

            return null;
        }
    }
}
