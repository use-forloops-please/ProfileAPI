using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProfileAPI.Models;

namespace ProfileAPI.Data
{
    public class ProfileContext : DbContext
    {
        public ProfileContext(DbContextOptions<ProfileContext> options)
            : base(options)
        {
        }

        public DbSet<Header> Headers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
