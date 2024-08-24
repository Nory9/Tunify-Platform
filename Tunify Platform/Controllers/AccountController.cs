using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Identity.Client;
using Tunify_Platform.DTOs;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountU _accountService;
      
        public AccountController(IAccountU context) {

            _accountService = context; 
        
        }

        [HttpPost("Register")]
        public async Task<ActionResult<AccountDTO>> Register(RegisterDTO registerDTO) {

            var user  = await _accountService.Register(registerDTO,this.ModelState);

            if (ModelState.IsValid)
            {
                return user;
            }

            if (user == null) { 

                return Unauthorized();
            
            }
            return BadRequest();
        }


        [HttpPost("Login")]
        public async Task<ActionResult<AccountDTO>> Login(LoginDTO loginDTO){

            var user = await _accountService.Login(loginDTO.Name, loginDTO.Password);

            if (user != null)
                return user;

            return BadRequest();    
        
        }

        [HttpPost("Logout")]

        public async Task<IActionResult> Logout() { 
        
            await _accountService.Logout();
            return Ok("logout");
        
        }


    }
}
