using Microsoft.EntityFrameworkCore;
using OfficeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeData
{
    public class OfficeDbContext:DbContext
    {
        public OfficeDbContext()
        {

        }
        public OfficeDbContext(DbContextOptions<OfficeDbContext> options) : base(options)
        {

        }
        public DbSet<Message> messages { get; set; }
        public DbSet<Profile> profiles { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Tasks> tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Data Source=VDC01LTC2207;Initial Catalog=Office2;Integrated Security=True;");
        }


    }

}
