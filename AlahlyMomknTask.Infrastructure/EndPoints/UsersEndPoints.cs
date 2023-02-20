using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Infrastructure.EndPoints
{
    public class UsersEndPoints
    {
        public const string Login = BaseEndPoints.UserController + "Login";
        public const string CheckTokenValidation = BaseEndPoints.UserController + "CheckTokenValidation";
    }
}
