﻿using Microsoft.AspNetCore.Identity;
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

        private jwtTokenServices_ _jwtTokenService;

        public AccountServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, jwtTokenServices_ jwtTokenServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenServices;
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
                    //Retrive Token after validation(LogIn) [Minutes for testing its shoukd be hours]
                    Token = await _jwtTokenService.GenerateToken(user, System.TimeSpan.FromMinutes(8))

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

                await _userManager.AddToRolesAsync(user, registerDTO.Role);
                return new AccountDTO()
                {
                    Id = user.Id,
                    Name = user.UserName,
                    Role = await _userManager.GetRolesAsync(user)

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
