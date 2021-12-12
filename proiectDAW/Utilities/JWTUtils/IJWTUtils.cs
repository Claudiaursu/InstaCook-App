using proiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Utilities.JWTUtils
{
    public interface IJWTUtils
    {
         string GenerateJWTToken(Utilizator utiliz);
         Guid ValidateJWTToken(string token);
    }
}
