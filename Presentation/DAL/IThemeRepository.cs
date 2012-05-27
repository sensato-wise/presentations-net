using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.DAL
{
    public interface IThemeRepository : IDisposable
    {      
          int GetThemeByName(string Name);
          void SetThemeByName(string Name, int value);
    }
}
