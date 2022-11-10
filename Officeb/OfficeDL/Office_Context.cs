using Microsoft.EntityFrameworkCore;
using OfficeEntity;
using System;
using System.Collections.Generic;

namespace OfficeDL
{
    public class Office_Context :DbContext
    {
        public Office_Context(DbContextOptions<Office_Context> options) : base(options)
        {

        }
        //public DbSet<user> user { get; set; }
        //public DbSet<Comment> comments { get; set; }
        public DbSet<Profile> profile { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Data Source=VDC01LTC2235;Initial Catalog = offic ;Integrated Security = True;");
        }
    }
}
