using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Presentation.Model;
using System.Data.Entity;
using Presentation.Models;
using System.Data;
using System.Web.Mvc;

namespace Presentation.DAL
{
    public class PresentationRepository : IPresentationRepository
    {
        private UserContext context;
        private DbSet<PresentationModel> dbSet;

        public PresentationRepository(UserContext content)
        {
            this.context = content;
            this.dbSet = content.Set<PresentationModel>();
        }


        public IEnumerable<Models.PresentationModel> GetPresentations(Guid userId)
        {
            var presentations = dbSet.Where(i => i.UserId == userId);
            return presentations.ToList();
        }

        public IEnumerable<PresentationModel> GetAllPresentations()
        {
            var presentation = context.Presentation.ToList();
            return presentation;
        }

        public Models.PresentationModel GetPresentation(int id)
        {
            return context.Presentation.Find(id);
        }

        public Models.PresentationModel CreatePresentation()
        {
            return new PresentationModel();
        }

        public void DeletePresentation(int id)
        {
            PresentationModel presentation = context.Presentation.Find(id);
            if (presentation != null)
                context.Presentation.Remove(presentation);
        }

        public void UpdatePresentation(Models.PresentationModel presentation)
        {
            context.Entry(presentation).State = EntityState.Modified;
        }

        public void InsertPresentation(Models.PresentationModel presentation)
        {
                context.Presentation.Add(presentation);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public Guid GetUserGUID(string name)
        {
            DbSet<UserModel> dbSet = context.Set<UserModel>();
            var users = dbSet.Where(i => i.Name == name).ToList();
            if (users != null)
            {
                UserModel user = users[0];
                return user.UserId;
            }
            else
                return Guid.Empty;
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