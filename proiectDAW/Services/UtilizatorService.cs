using proiectDAW.Models;
using proiectDAW.Models.DTOs;
using proiectDAW.Repositories.DatabaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Services
{
    public class UtilizatorService : IUtilizatorService
    {
        public IUtilizatorRepository _utilizatorRepository;

        public UtilizatorService(IUtilizatorRepository utilizatorRepository)
        {
            _utilizatorRepository = utilizatorRepository;
        }

        public UtilizatorDTO getUtilizatorByName(string nume, string prenume)
        {
            Utilizator utiliz = _utilizatorRepository.GetByFullName(nume, prenume);
            UtilizatorDTO utilizDTO = new UtilizatorDTO()
            {
                Nume = utiliz.Nume_Utilizator,
                Prenume = utiliz.Prenume_Utilizator
            };
            return utilizDTO;
        }
    }
}
