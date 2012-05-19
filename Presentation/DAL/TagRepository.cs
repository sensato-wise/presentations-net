using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Presentation.Model;

namespace Presentation.DAL
{
    public class TagRepository : ITagsRepository
    {
        private UserContext context;

        public TagRepository()
        {
            context = new UserContext();
        }

        public IEnumerable<Models.Tag> GetTags()
        {
            return context.Tags.ToList();
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