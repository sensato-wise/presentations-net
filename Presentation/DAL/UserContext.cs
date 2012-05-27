using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Presentation.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;

namespace Presentation.Model
{
    
    public class UserContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserDetailsModel> UserDetails { get; set; }
        public DbSet<PresentationModel> Presentation { get; set; }
        public DbSet<Tag> Tags { get; set; }

        // added by algol                
        public DbSet<RatingsModel> Ratings { get; set; }
        public DbSet<SlideModel> Slides { get; set; }
    }
}