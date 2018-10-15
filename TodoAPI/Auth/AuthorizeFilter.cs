using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TodoAPI.Auth
{
    public class AuthorizeFilter : IAuthorizationFilter
    {
        private readonly string realm;

        public AuthorizeFilter(string realm = null)
        {
            this.realm = realm;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string authHeader = context.HttpContext.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                var encodedPass = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();
                var decodedPass = Encoding.UTF8.GetString(Convert.FromBase64String(encodedPass));
                var username = decodedPass.Split(':', 2)[0];
                var password = decodedPass.Split(':', 2)[1];

                if (IsAuthorized(username, password))
                    return;
            }
            // pede o login
            context.HttpContext.Response.Headers["WWW-Authenticate"] = "Basic";

            //adiciona o realm
            if (!string.IsNullOrWhiteSpace(realm))
                context.HttpContext.Response.Headers["WWW-Authenticate"] += $" realm=\"{realm}\"";

            context.Result = new UnauthorizedResult();
        }

        public bool IsAuthorized(string username, string password)
        {
            return (username.Equals("admin") && password.Equals("admin"));
        }
    }
}
