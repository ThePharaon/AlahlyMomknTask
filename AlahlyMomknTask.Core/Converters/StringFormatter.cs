using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Core.Converters
{
    public static class StringFormatter
    {
        public static string FormatString(string text, object arg1)
        => string.Format(text, arg1);
        
        public static string FormatString(string text, object arg1, object arg2)
        => string.Format(text, arg1, arg2);

        public static string FormatString(string text, object arg1, object arg2, object arg3)
        => string.Format(text, arg1, arg2, arg3);
        
    }
}
