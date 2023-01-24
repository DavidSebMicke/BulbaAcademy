﻿namespace BulbasaurAPI.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; } = new();
    }
}