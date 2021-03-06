﻿using System;
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
        // added by algol                
        void AddNewVote(Guid UserId, int PresentationId, int Rating);
        string GetUserNameById(Guid id);
        bool IsRatedByUserId(int PresentationId, Guid UserId);
        string GetAverageRating(int PresentationId);
        int GetUserRating(int PresentationId, Guid UserId);
    }
}