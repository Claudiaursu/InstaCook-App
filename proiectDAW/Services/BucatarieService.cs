using proiectDAW.Models.DTOs;
using proiectDAW.Models.One_To_Many;
using proiectDAW.Repositories.DatabaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Services
{
    public class BucatarieService : IBucatarieService
    {
        public IBucatarieRepository _bucatarieRepository;

        public BucatarieService(IBucatarieRepository bucatarieRepository)
        {
            _bucatarieRepository = bucatarieRepository;  
        }

        public Bucatarie FindById(Guid id)
        {
            return _bucatarieRepository.FindById(id);
        }

        public BucatarieDTO createBucatarie(Bucatarie bucatarie)
        {
            _bucatarieRepository.Create(bucatarie);
            _bucatarieRepository.Save();
            BucatarieDTO bucatarieDTO = new BucatarieDTO()
            {
                Nume_Bucatarie = bucatarie.Nume_Bucatarie,
                Descriere_Bucatarie = bucatarie.Descriere_Bucatarie,
                Regiune_Glob = bucatarie.Regiune_Glob,
            };
            return bucatarieDTO;
        }

        public List<BucatarieDTO> getAll()
        {
            List<BucatarieDTO> bucatariiDTO = new List<BucatarieDTO>();
            List<Bucatarie> bucatarii = _bucatarieRepository.getAll();
            bucatarii.ForEach(bucatarie =>
            {
                BucatarieDTO bucatarieDTO = new BucatarieDTO()
                {
                    Nume_Bucatarie = bucatarie.Nume_Bucatarie,
                    Descriere_Bucatarie = bucatarie.Descriere_Bucatarie,
                    Regiune_Glob = bucatarie.Regiune_Glob
                };
                bucatariiDTO.Add(bucatarieDTO);
            });
            return bucatariiDTO;
        }

        public BucatarieDTO updateBucatarie(Guid id, Bucatarie bucatarie)
        {


            _bucatarieRepository.updateBucatarie(bucatarie);
            _bucatarieRepository.Save();
            BucatarieDTO bucatarieDTO = new BucatarieDTO()
            {
                Nume_Bucatarie = bucatarie.Nume_Bucatarie,
                Descriere_Bucatarie = bucatarie.Descriere_Bucatarie,
                Regiune_Glob = bucatarie.Regiune_Glob
            };
            return bucatarieDTO;
        }
        public void Save()
        {
            _bucatarieRepository.Save();
        }

        public BucatarieDTO deleteBucatarie(Bucatarie bucatarie)
        {
            _bucatarieRepository.Delete(bucatarie);
            BucatarieDTO bucatarieDTO = new BucatarieDTO()
            {
                Nume_Bucatarie = bucatarie.Nume_Bucatarie,
                Descriere_Bucatarie = bucatarie.Descriere_Bucatarie,
                Regiune_Glob = bucatarie.Regiune_Glob
            };
            return bucatarieDTO;
        }
    }
}
