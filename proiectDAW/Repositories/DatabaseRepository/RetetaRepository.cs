using proiectDAW.Data;
using proiectDAW.Models.Many_To_Many;
using proiectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Repositories.DatabaseRepository
{
    public class RetetaRepository : GenericRepository<Reteta>, IRetetaRepository
    {
        public RetetaRepository(ProjectContext context) : base(context)
        {

        }

        //LINQ
        public List<Reteta> getAllFromCollection(Guid colId)
        {
            //var retete = from r in _table
            //             where r.ColectieId.ToString() == colId.ToString()
            //             select r;
            //return retete.ToList();
            return _table.ToList();
        }

        public void updateReteta(Reteta reteta)
        {
            _table.Update(reteta);
        }
    }
}
