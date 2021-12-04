using proiectDAW.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Services
{
    public interface IUtilizatorService
    {
        UtilizatorDTO getUtilizatorByName(string nume, string prenume);
    }
}
