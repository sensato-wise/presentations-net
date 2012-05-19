using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Presentation.Models;

namespace Presentation.DAL
{
    public interface ITagsRepository : IDisposable
    {
        IEnumerable<Tag> GetTags();
    }
}