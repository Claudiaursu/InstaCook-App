using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using proiectDAW.Models;
using proiectDAW.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Utilities
{
    public class AuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Rol> _roluri;
        public AuthorizationAttribute(params Rol[] roluri)
        {
            _roluri = roluri;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var unauthorizedStatusCodeObject = new JsonResult(new { Message = "Unauthorized" })
            { StatusCode = StatusCodes.Status401Unauthorized };

            // might not be necessary to check the role; some endpoints just need authorization
            if (_roluri == null)
            {
                context.Result = unauthorizedStatusCodeObject;
            }

            var user = (Utilizator)context.HttpContext.Items["Utilizator"];
            if (user == null || !_roluri.Contains(user.Rol))
            {
                context.Result = unauthorizedStatusCodeObject;
            }
        }
    }
}
