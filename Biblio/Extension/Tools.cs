using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblio.Extension
{
    public static class Tools
    {
        public static bool IsNumeric(this string s)
        {
            float output;
            return float.TryParse(s, out output);
        }
    }
}