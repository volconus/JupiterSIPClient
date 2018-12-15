using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JupiterSIPClient1
{
    class validate
    {
        internal static bool isEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\.\-]+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }

        internal static bool notNull(string email)
        {            
            if (email == "" || email == null)
                return false;
            else
                return true;
        }


    }
}
