using System;
using Microsoft.AspNetCore.Mvc;

namespace TodoAPI.Auth
{

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class AuthorizeAttribute : TypeFilterAttribute
        {
            public AuthorizeAttribute(string realm = null)
                : base(typeof(AuthorizeFilter))
            {
                Arguments = new object[]
                {
                realm
                };
            }
        }
    
}
