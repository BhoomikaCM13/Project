using Microsoft.EntityFrameworkCore;
using OfficeEntity;
using System;
using System.Collections.Generic;

namespace OfficeDL
{
    public class Office_Context :DbContext
    {
        public Office_Context()
        {
        }

        public Office_Context(DbContextOptions<Office_Context> options) : base(options)
        {

        }
       
        public DbSet<Profile> profile { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Tasks> tasks { get; set; }
        public DbSet<Message> messages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Data Source=VDC01LTC2235;Initial Catalog = final;Integrated Security = True;");
        }
    }
}
