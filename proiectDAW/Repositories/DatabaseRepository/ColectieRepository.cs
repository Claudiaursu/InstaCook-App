using proiectDAW.Data;
using proiectDAW.Models.One_To_Many;
using proiectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Repositories.DatabaseRepository
{
    public class ColectieRepository : GenericRepository<Colectie>, IColectieRepository
    {
        public ColectieRepository(ProjectContext context) : base(context)
        {

        }

        public List<Colectie> GetAllColectionsForUser(Guid utilizId)
        {
            var colectiiUser = _table.Where(x => x.UtilizatorId == utilizId).ToList();
            return colectiiUser;
        }
    }
}
