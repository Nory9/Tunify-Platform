﻿namespace Tunify_Platform.DTOs
{
    public class RegisterDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public IList<string> Role { get; set; }
    }
}
