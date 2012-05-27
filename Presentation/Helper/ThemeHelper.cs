using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Presentation.DAL;

namespace System.Web.Mvc
{
    public static class ThemeHelper
    {
          private static IThemeRepository themeRepository;
          static ThemeHelper()
          {
              themeRepository = new ThemeRepository();    
          }
          public static string ThemeCss(string UserName)
          {
              int theme;
              if (UserName == "") theme = 1; else
                theme = themeRepository.GetThemeByName(UserName);
              string adr = "/Content/themeDefault/Site.css";
              switch (theme)
              {
                  case 2:
                      adr = "/Content/themeGray/Site.css";
                      break;
                  case 3:
                      adr = "/Content/themeGreen/Site.css";
                      break;
              }
              return adr;
          }
    }
}