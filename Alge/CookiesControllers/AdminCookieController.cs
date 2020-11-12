using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alge.Classes_Cookies
{
    public static class AdminCookieController
    {
        const string ADMIN_LOGADO_EMAIL = "adminEmail";
        const string ADMIN_LOGADO_ID = "adminId";

        public static int AdminID
        {
            set
            {
                AppHttpContext.Current.Session.SetInt32(ADMIN_LOGADO_ID, value);
            }
            get
            {
                return AppHttpContext.Current.Session.GetInt32(ADMIN_LOGADO_ID) ?? 0;
            }
        }

        public static string AdminEmail
        {
            set
            {
                AppHttpContext.Current.Session.SetString(ADMIN_LOGADO_EMAIL, value);
            }
            get
            {
                return AppHttpContext.Current.Session.GetString(ADMIN_LOGADO_EMAIL) ?? null;
            }
        }

        public static void ClearSession()
        {
            AppHttpContext.Current.Session.Clear();
        }
    }
}
