using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Core.Statics
{
    public static class DataPatterns
    {
        public const string DateFormat = "yyyy / MM / dd";
        public const string FullDateFormat = "yyyy / MM / dd - hh:mm tt";
        public const string EmailRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        public const string PasswordRegex = @"^(?=(.*[a-z]){3,})(?=(.*[A-Z]){1,})(?=(.*[0-9]){1,})(?=(.*[!@#$%^&*()\-__+.]){1,}).{10,}$
";
    }
}
