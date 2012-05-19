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
        private DbSet<Tag> dbSetTag;

        public PresentationRepository(UserContext content)
        {
            this.context = content;
            this.dbSet = content.Set<PresentationModel>();
            this.dbSetTag = content.Set<Tag>();
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
            ParseTags(presentation);
            context.Presentation.Add(presentation);
        }

        private void ParseTags(PresentationModel presentation)
        {
            var tags = presentation.Tags.Split(',');
            int tagId;
            for (int i = 0; i < tags.Length; ++i)
            {
                if (!IsTagExist(tags[i], out tagId))
                    AddNewTag(tags[i], out tagId);
                InsertTag(i, tagId, presentation);
            }
        }

        private void InsertTag(int tagNumber, int tagId, PresentationModel presentation)
        {
            if (tagId > 0)
            {
                switch (tagNumber)
                {
                    case 0: presentation.Tag1 = tagId; break;
                    case 1: presentation.Tag2 = tagId; break;
                    case 2: presentation.Tag3 = tagId; break;
                    case 3: presentation.Tag4 = tagId; break;
                    case 4: presentation.Tag5 = tagId; break;
                }
            }
        }


        private bool AddNewTag(string tagName, out int tagId)
        {
            Tag tag = new Tag();
            tag.Name = tagName;
            try
            {
                context.Tags.Add(tag);
                context.SaveChanges();
                IsTagExist(tagName, out tagId);
                return true;
            }
            catch (Exception e)
            {
                tagId = default(int);
                return false;
            }
        }

        private bool IsTagExist(string tagName, out int id)
        {
            var tags = dbSetTag.Where(i => i.Name.Equals(tagName)).ToList();
            if (tags.Count > 0)
            {
                Tag tag = tags[0];
                id = tag.Id;
                return true;
            }
            else
            {
                id = default(int);
                return false;
            }
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