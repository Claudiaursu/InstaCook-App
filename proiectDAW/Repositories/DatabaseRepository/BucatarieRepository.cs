using proiectDAW.Data;
using proiectDAW.Models.One_To_Many;
using proiectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Repositories.DatabaseRepository
{
    public class BucatarieRepository : GenericRepository<Bucatarie>, IBucatarieRepository
    {
        public BucatarieRepository(ProjectContext context) : base(context)
        {

        }

        //LINQ
        public List<Bucatarie> getAll()
        {
            var bucatarii = from b in _table
                         select b;
            return bucatarii.ToList();
        }

        public void GroupBy()
        {
            var bucGrupate = _table.GroupBy(u => u.Regiune_Glob);

            foreach (var bucatarieByCountry in bucGrupate)
            {
                Console.WriteLine("Regiune bucatarie: " + bucatarieByCountry.Key);
                foreach (Bucatarie b in bucatarieByCountry)
                {
                    Console.WriteLine(b.Nume_Bucatarie);
                }
            }
        }
        public void updateBucatarie(Bucatarie bucatarie)
        {
            _table.Update(bucatarie);
        }
    }
}
