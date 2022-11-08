using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Pharmacy_Management_System
{
    class RegExp
    {
        public static bool checkForEmail(string email)
        {
            bool IsValid = false;
            Regex r = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (r.IsMatch(email))
                IsValid = true;
            return IsValid;
        }

        public static bool checkForNo(string p)
        {
            bool IsValid = false;
            Regex r = new Regex(@"\+[0-9]{3}\s+[0-9]{3}\s+[0-9]{5}\s+[0-9]{3}");
            if (r.IsMatch(p))
                IsValid = true;
            return IsValid;
        }

        public static bool checkForNIC(string p)
        {
            bool IsValid = false;
            Regex r = new Regex(@"^\d{9}(x|v)$");
            if (r.IsMatch(p))
                IsValid = true;
            return IsValid;
        }
    }
}
