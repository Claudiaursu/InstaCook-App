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
            return _table.Include(x => x.Date_Personale).ToList();
        }

        public Utilizator GetByFullName(string nume, string prenume)
        {
            return _table.FirstOrDefault(x => x.Nume_Utilizator.ToLower().Equals(nume.ToLower()) &&
            x.Prenume_Utilizator.ToLower().Equals(prenume.ToLower()));

        }

        public Utilizator GetByUsername(string username)
        {
            return _table.FirstOrDefault(x => x.Username.ToLower().Equals(username.ToLower()));
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

        public Utilizator GetByIdIncludingDatePersonale(Guid Id)
        {
            return _table.Include(x => x.Date_Personale).FirstOrDefault(x => x.Id.ToString().Equals(Id.ToString()));
        }

        /*
        public void orderByPoints()
        {

        }
        */

        public void GroupBy()
        {
            var groupedUsers = _table.GroupBy(u => u.Date_Personale.Tara_Origine);

            foreach(var userGroupByCountry in groupedUsers)
            {
                Console.WriteLine("tara utilizator: "+ userGroupByCountry.Key);
                foreach(Utilizator u in userGroupByCountry)
                {
                    Console.WriteLine(u.Nume_Utilizator);
                }
            }
        }
    }
}
