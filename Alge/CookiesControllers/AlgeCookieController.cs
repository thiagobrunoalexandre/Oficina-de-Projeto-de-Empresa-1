using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alge
{
    public static class AlgeCookieController
    {
        const string USER_LOGADO_EMAIL = "userLogadoEmail";
        const string USER_LOGADO_ID = "userLogadoId";
        const string USER_STATUS = "UserStatus";
        const string USER_LOGGED_BY_ADMIN = "LoggedByAdmin";
        

        public static int UserID
        {
            set
            {
                AppHttpContext.Current.Session.SetInt32(USER_LOGADO_ID, value);
            }
            get
            {
                return AppHttpContext.Current.Session.GetInt32(USER_LOGADO_ID) ?? 0;
            }
        }

        public static string UserEmail
        {
            set
            {
                AppHttpContext.Current.Session.SetString(USER_LOGADO_EMAIL, value);
            }
            get
            {
                return AppHttpContext.Current.Session.GetString(USER_LOGADO_EMAIL);
            }


        }

        public static string UserStatus
        {
            set
            {
                AppHttpContext.Current.Session.SetString(USER_STATUS, value);
            }
            get
            {
                return AppHttpContext.Current.Session.GetString(USER_STATUS);
            }

        }

        public static bool LoggedByAdmin
        {
            set
            {
                int loggedByAdmin = value == true ? 1 : 0;
                AppHttpContext.Current.Session.SetInt32(USER_LOGGED_BY_ADMIN, loggedByAdmin);
            }
            get
            {
                return AppHttpContext.Current.Session.GetInt32(USER_LOGGED_BY_ADMIN) == null ? false : Convert.ToBoolean(AppHttpContext.Current.Session.GetInt32(USER_LOGGED_BY_ADMIN));
            }
        }

       
        public static void ClearSession()
        {
            AppHttpContext.Current.Session.Remove(USER_LOGADO_EMAIL);
            AppHttpContext.Current.Session.Remove(USER_LOGADO_ID);
            AppHttpContext.Current.Session.Remove(USER_STATUS);
            AppHttpContext.Current.Session.Remove(USER_LOGGED_BY_ADMIN);

        }
    }
}