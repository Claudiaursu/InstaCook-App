using proiectDAW.Models.One_To_Many;
using proiectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Repositories.DatabaseRepository
{
    public interface IColectieRepository : IGenericRepository<Colectie>
    {
        List<Colectie> GetAllColectionsForUser(Guid id);
        void updateColectie(Colectie colectie);
        Colectie FindByTitlu(String titlu);
    }
}
