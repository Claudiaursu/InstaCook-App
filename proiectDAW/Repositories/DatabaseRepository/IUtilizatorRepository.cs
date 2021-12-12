using proiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proiectDAW.Repositories.GenericRepository;

namespace proiectDAW.Repositories.DatabaseRepository
{
    public interface IUtilizatorRepository : IGenericRepository<Utilizator>
    {
        Utilizator GetByFullName(string nume, string prenume);
        Utilizator GetByFullNameIncludingColectii(string nume, string prenume);
        List<Utilizator> GetAllWithInclude();
        Utilizator GetByFullNameIncludingDatePersonale(string nume, string prenume);
        Utilizator GetByUsername(string username);
    }
}
