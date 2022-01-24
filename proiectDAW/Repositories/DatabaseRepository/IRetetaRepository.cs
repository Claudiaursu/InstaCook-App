using proiectDAW.Models.Many_To_Many;
using proiectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Repositories.DatabaseRepository
{
   public interface IRetetaRepository : IGenericRepository<Reteta>
    {
        List<Reteta> getAllFromCollection(Guid colId);
        void updateReteta(Reteta reteta);
    }
}
