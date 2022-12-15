﻿using Microsoft.EntityFrameworkCore;
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

        // Entity class database:

        public DbSet<Profile> profile { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Tasks> tasks { get; set; }
        public DbSet<Message> messages { get; set; }

        public DbSet<Dashboard> dashBoards { get; set; }
        public DbSet<TaskBoard> taskBoards { get; set; }

        public DbSet<Contactus> contact { get; set; }
        // SQL Connection:
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
<<<<<<< HEAD
            dbContextOptionsBuilder.UseSqlServer("Data Source=VDC01LTC2235;Initial Catalog = TheOffice1;Integrated Security = True;");
=======
            dbContextOptionsBuilder.UseSqlServer("Data Source=VDC01LTC2235;Initial Catalog = TheOffice2;Integrated Security = True;");
>>>>>>> fb3f0d99ccdc41457d78ae7d68293daf3b347d3d
        }
    }
}
