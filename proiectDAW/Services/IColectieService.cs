using proiectDAW.Models.DTOs;
using proiectDAW.Models.One_To_Many;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Services
{
    public interface IColectieService
    {
        List<ColectieDTO> getAllForUser(Guid id);
        ColectieDTO createColectie(Colectie colectie, Guid utilizId);
        ColectieDTO updateColectie(Guid id, Colectie colectie);
        Colectie FindById(Guid colectionId);
        void Save();

        ColectieDTO deleteColectie(Colectie colectie);
    }
}
