using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using proiectDAW.Services;
using proiectDAW.Utilities.JWTUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Utilities
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JWTMiddleware(IOptions<AppSettings> appSettings, RequestDelegate next)
        {
            _appSettings = appSettings.Value;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IUtilizatorService utilizatorService, IJWTUtils jWTUtils)
        {
            var token = httpContext.Request.Headers["Autorization"].FirstOrDefault()?.Split(' ').Last();

            var userId = jWTUtils.ValidateJWTToken(token);

            if (userId != Guid.Empty)
            {
                httpContext.Items["Utilizator"] = utilizatorService.FindById(userId);
            }

            await _next(httpContext);
        }
    }
}
