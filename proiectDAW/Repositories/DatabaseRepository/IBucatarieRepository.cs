using proiectDAW.Models;
using proiectDAW.Models.One_To_Many;
using proiectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Repositories.DatabaseRepository
{
    public interface IBucatarieRepository : IGenericRepository<Bucatarie>
    {
        void GroupBy();
        List<Bucatarie> getAll();
        void updateBucatarie(Bucatarie bucatarie);
    }
}
