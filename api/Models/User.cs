﻿namespace BulbasaurAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        public Guid GUID { get; set; }

        public string Username { get; set; }


        public string Password { get; set; }

        public Person Person { get; set; }
    }
}