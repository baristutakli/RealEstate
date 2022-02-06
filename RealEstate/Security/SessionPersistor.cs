using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.Security
{
    public static class SessionPersister
    {
        static string emailSessionVar = "email";

        public static string Email
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sessionVar = HttpContext.Current.Session[emailSessionVar];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[emailSessionVar] = value;
            }
        }
    }
}