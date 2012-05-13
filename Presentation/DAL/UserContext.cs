using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Presentation.Models;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Model
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<PresentationModel> Presentation { get; set; }
    }

}