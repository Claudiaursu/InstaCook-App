using proiectDAW.Models;
using proiectDAW.Models.DTOs;
using proiectDAW.Models.One_To_One;
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
        public IDatePersonaleRepository _datePersonaleRepository;

        public UtilizatorService(IUtilizatorRepository utilizatorRepository, IDatePersonaleRepository datePersonaleRepository)
        {
            _utilizatorRepository = utilizatorRepository;
            _datePersonaleRepository = datePersonaleRepository;
        }


        public UtilizatorDTO getUtilizatorByName(string nume, string prenume)
        {
            Utilizator utiliz = _utilizatorRepository.GetByFullName(nume, prenume);
            UtilizatorDTO utilizDTO = new UtilizatorDTO()
            {
                Nume = utiliz.Nume_Utilizator,
                Prenume = utiliz.Prenume_Utilizator,
                NrPuncte = utiliz.Total_Puncte,
                Email = ""
            };
            return utilizDTO;
        }

        
        public UtilizatorDTO getUtilizatorByNameWithDate(string nume, string prenume)
        {
            Utilizator utiliz = _utilizatorRepository.GetByFullNameIncludingDatePersonale(nume, prenume);
            UtilizatorDTO utilizDTO = new UtilizatorDTO()
            {
                Nume = utiliz.Nume_Utilizator,
                Prenume = utiliz.Prenume_Utilizator,
                NrPuncte = utiliz.Total_Puncte,
                Email = utiliz.Date_Personale.Email,
                Telefon = utiliz.Date_Personale.Telefon,
                Tara_Origine = utiliz.Date_Personale.Tara_Origine
            };
            return utilizDTO;
        }

        public UtilizatorDTO createUtilizator(Utilizator utiliz)
        {
            Date_Personale datePers = _datePersonaleRepository.CreateDatePersonale(utiliz.Date_Personale.Email, utiliz.Date_Personale.Tara_Origine, utiliz.Date_Personale.Telefon);
            _utilizatorRepository.Save();

            utiliz.Date_PersonaleId = datePers.Id;

            _utilizatorRepository.Create(utiliz);
            _utilizatorRepository.Save();
            UtilizatorDTO utilizDTO = new UtilizatorDTO()
            {
                Nume = utiliz.Nume_Utilizator,
                Prenume = utiliz.Prenume_Utilizator,
                NrPuncte = utiliz.Total_Puncte,
                Email = utiliz.Date_Personale.Email,
                Tara_Origine = utiliz.Date_Personale.Tara_Origine,
                Telefon = utiliz.Date_Personale.Telefon
            };
            return utilizDTO;
        }

        public List<UtilizatorDTO> getAll()
        {
            List<UtilizatorDTO> usersDTO = new List<UtilizatorDTO>(); 
            List<Utilizator> allUsers = _utilizatorRepository.GetAllWithInclude();
            allUsers.ForEach(utilizator =>
            {
                UtilizatorDTO userDTO = new UtilizatorDTO()
                {
                    Nume = utilizator.Nume_Utilizator,
                    Prenume = utilizator.Prenume_Utilizator,
                    NrPuncte = utilizator.Total_Puncte,
                    Email = utilizator.Date_Personale.Email,
                    Tara_Origine = utilizator.Date_Personale.Tara_Origine,
                    Telefon = utilizator.Date_Personale.Telefon
                };
                usersDTO.Add(userDTO);
            });
            return usersDTO;
        }

        public Utilizator FindById(Guid id)
        {
            return _utilizatorRepository.FindById(id);
        }

        public void Save()
        {
            _utilizatorRepository.Save();
        }

    }
}
