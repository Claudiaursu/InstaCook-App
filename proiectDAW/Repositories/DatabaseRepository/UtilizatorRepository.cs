using Microsoft.EntityFrameworkCore;
using proiectDAW.Data;
using proiectDAW.Models;
using proiectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Repositories.DatabaseRepository
{
    public class UtilizatorRepository : GenericRepository<Utilizator>, IUtilizatorRepository
    {
        public UtilizatorRepository(ProjectContext context) : base(context)
        {

        }
        
        public List<Utilizator> GetAllWithInclude()
        {
            return _table.Include(x => x.Colectii).ToList();
        }

        public Utilizator GetByFullName(string nume, string prenume)
        {
            return _table.FirstOrDefault(x => x.Nume_Utilizator.ToLower().Equals(nume.ToLower()) &&
            x.Prenume_Utilizator.ToLower().Equals(prenume.ToLower()));

        }

        public Utilizator GetByFullNameIncludingColectii(string nume, string prenume)
        {
            return _table.Include(x => x.Colectii).FirstOrDefault(x => x.Nume_Utilizator.ToLower().Equals(nume.ToLower()) &&
            x.Prenume_Utilizator.ToLower().Equals(prenume.ToLower()));
        }

        public Utilizator GetByFullNameIncludingDatePersonale(string nume, string prenume)
        {
            return _table.Include(x => x.Date_Personale).FirstOrDefault(x => x.Nume_Utilizator.ToLower().Equals(nume.ToLower()) &&
            x.Prenume_Utilizator.ToLower().Equals(prenume.ToLower()));
        }
    }
}
