using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class UserEditModel
    {
         public string UserName;
         public UserDetailsModel UserDetailsModel;
         public UserEditModel(string UserName, UserDetailsModel UserDetailsModel)
         {
             this.UserName = UserName;
             this.UserDetailsModel = UserDetailsModel;
         }
    }
}