﻿namespace Tunify_Platform.DTOs
{
    public class AccountDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Token { get; set; }
        public IList<string> Role { get; set; }

    }
}
