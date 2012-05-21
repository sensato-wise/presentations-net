using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Presentation.Models;

namespace Presentation.DAL
{
    public interface IPresentationRepository : IDisposable
    {
        IEnumerable<PresentationModel> GetPresentations(Guid userId);
        IEnumerable<PresentationModel> GetPresentations(string searchString);
        IEnumerable<PresentationModel> GetAllPresentations();
        PresentationModel GetPresentation(int id);
        PresentationModel CreatePresentation();
        Guid GetUserGUID(string name);
        void DeletePresentation(int id);
        void UpdatePresentation(PresentationModel presentation);
        void InsertPresentation(PresentationModel presentation);
        void Save();

        string GetUserNameById(Guid id);
    }
}