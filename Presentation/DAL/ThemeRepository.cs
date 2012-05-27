using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Presentation.Model;
using System.Data.Entity;
using Presentation.Models;

namespace Presentation.DAL
{
    public class ThemeRepository : IThemeRepository 
    {
        private UserContext context;
        private DbSet<UserModel> dbUsers;
        public ThemeRepository()
        {
            this.context = new UserContext();
            this.dbUsers = context.Set<UserModel>();
        }

        public int GetThemeByName(string Name)
        {            
            var user = dbUsers.Where(i => i.Name == Name).First();            
            if ( user == null ) return -1;
            context.Entry(user).Reload();
            return user.ThemeId;
        }
        public void SetThemeByName(string Name,int value)
        {
            var user = dbUsers.Where(i => i.Name == Name).First();
            if (user == null) return;
            user.ThemeId = value;
            context.Entry(user).State = System.Data.EntityState.Modified;
            context.SaveChanges();            
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}