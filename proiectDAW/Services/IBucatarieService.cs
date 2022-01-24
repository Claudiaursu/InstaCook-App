using proiectDAW.Models.DTOs;
using proiectDAW.Models.One_To_Many;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Services
{
    public interface IBucatarieService
    {
        BucatarieDTO createBucatarie(Bucatarie bucatarie);
        List<BucatarieDTO> getAll();
        BucatarieDTO deleteBucatarie(Bucatarie bucatarie);
        void Save();
        BucatarieDTO updateBucatarie(Guid id, Bucatarie bucatarie);

        Bucatarie FindById(Guid id);
    }
}
