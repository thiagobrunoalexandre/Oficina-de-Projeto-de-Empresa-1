using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Alge
{
    public static class AppHttpContext
    {
        static IServiceProvider services = null;

        public static IServiceProvider Services
        {
            get { return services; }
            set
            {
                if (services != null)
                {
                    throw new Exception("Can't set once a value has already been set.");
                }
                services = value;
            }
        }

        public static HttpContext Current
        {
            get
            {
                IHttpContextAccessor httpContextAccessor = services.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
                return httpContextAccessor?.HttpContext;
            }
        }

        public static string IP
        {
            get
            {
                return Current.Connection.RemoteIpAddress == null ? "x.x.x.x" : Current.Connection.RemoteIpAddress.ToString();
            }
        }

        public static string Browser
        {
            get
            {
                return UserAgent;
            }
        }

        public static string UserAgent
        {
            get
            {
                if (Current.Request.Headers.ContainsKey("User-Agent"))
                {
                    return Current.Request.Headers["User-Agent"].ToString();
                }
                return "";
            }
        }

        public static string Url
        {
            get
            {
                string url = ($"{Current.Request.Scheme}://{Current.Request.Host}{Current.Request.Path}{Current.Request.QueryString}");
                return url;
            }
        }

    }
}
