﻿namespace ContactList.Domain.Models.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Contact>? Contacts { get; set; }
    }
}
