using proiectDAW.Models;
using BC = BCrypt.Net.BCrypt;
using proiectDAW.Models.Authentication;
using proiectDAW.Models.DTOs;
using proiectDAW.Models.One_To_One;
using proiectDAW.Repositories.DatabaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proiectDAW.Utilities.JWTUtils;

namespace proiectDAW.Services
{
    public class UtilizatorService : IUtilizatorService
    {
        public IUtilizatorRepository _utilizatorRepository;
        public IDatePersonaleRepository _datePersonaleRepository;
        public IJWTUtils _ijwtUtils;

        public UtilizatorService(IUtilizatorRepository utilizatorRepository, IDatePersonaleRepository datePersonaleRepository, IJWTUtils ijwtUtils)
        {
            _utilizatorRepository = utilizatorRepository;
            _datePersonaleRepository = datePersonaleRepository;
            _ijwtUtils = ijwtUtils;
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

        public UtilizatorDTO getUtilizatorByUsername(string username)
        {
            Utilizator utiliz = _utilizatorRepository.GetByUsername(username);
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
                Tara_Origine = utiliz.Date_Personale.Tara_Origine,
                Username = utiliz.Username
            };
            return utilizDTO;
        }

        public UtilizatorDTO createUtilizator(Utilizator utiliz)
        {
            Date_Personale datePers = _datePersonaleRepository.CreateDatePersonale(utiliz.Date_Personale.Email, utiliz.Date_Personale.Tara_Origine, utiliz.Date_Personale.Telefon);
            _utilizatorRepository.Save();

            utiliz.Date_PersonaleId = datePers.Id;
            utiliz.ParolaHashed = BC.HashPassword(utiliz.ParolaHashed);

            _utilizatorRepository.Create(utiliz);
            _utilizatorRepository.Save();
            UtilizatorDTO utilizDTO = new UtilizatorDTO()
            {
                Nume = utiliz.Nume_Utilizator,
                Prenume = utiliz.Prenume_Utilizator,
                NrPuncte = utiliz.Total_Puncte,
                Email = utiliz.Date_Personale.Email,
                Tara_Origine = utiliz.Date_Personale.Tara_Origine,
                Telefon = utiliz.Date_Personale.Telefon,
                Username = utiliz.Username
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
                    Telefon = utilizator.Date_Personale.Telefon,
                    Username = utilizator.Username
                };
                usersDTO.Add(userDTO);
            });
            return usersDTO;
        }

        public Utilizator FindById(Guid id)
        {
            return _utilizatorRepository.FindById(id);
        }

        public UtilizatorDTO FindByIdWithData(Guid id)
        {
            Utilizator utiliz = _utilizatorRepository.GetByIdIncludingDatePersonale(id);

            UtilizatorDTO utilizDTO = new UtilizatorDTO()
            {
                Nume = utiliz.Nume_Utilizator,
                Prenume = utiliz.Prenume_Utilizator,
                NrPuncte = utiliz.Total_Puncte,
                Email = utiliz.Date_Personale.Email,
                Telefon = utiliz.Date_Personale.Telefon,
                Tara_Origine = utiliz.Date_Personale.Tara_Origine,
                Username = utiliz.Username
            };
            return utilizDTO;
        }

        public void Save()
        {
            _utilizatorRepository.Save();
        }

        public UtilizatorResponseDTO Authenticate(UtilizatorRequestDTO request)
        {
            var user = _utilizatorRepository.GetByUsername(request.Username);
            if (user == null || !BC.Verify(request.Parola, user.ParolaHashed))
            {
                return null;
            }
            //generam un jwt token (jwt = json web token)
            var token = _ijwtUtils.GenerateJWTToken(user);
            return new UtilizatorResponseDTO(user, token);

        }

        public UtilizatorDTO deleteUser(Utilizator utilizator)
        {
            _utilizatorRepository.Delete(utilizator);
            UtilizatorDTO utilizatorDTO = new UtilizatorDTO()
            {
                Nume = utilizator.Nume_Utilizator,
                Prenume = utilizator.Prenume_Utilizator,
                NrPuncte = utilizator.Total_Puncte,
                Email = utilizator.Date_Personale.Email,
                Telefon = utilizator.Date_Personale.Telefon,
                Tara_Origine = utilizator.Date_Personale.Tara_Origine,
                Username = utilizator.Username
            };
            return utilizatorDTO;
        }
    }
}
