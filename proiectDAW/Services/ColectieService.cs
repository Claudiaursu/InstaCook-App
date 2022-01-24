using proiectDAW.Models.DTOs;
using proiectDAW.Models.One_To_Many;
using proiectDAW.Repositories.DatabaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

namespace proiectDAW.Services
{
    public class ColectieService : IColectieService
    {
        public IColectieRepository _colectieRepository;

        public ColectieService(IColectieRepository colectieRepository, IDatePersonaleRepository datePersonaleRepository)
        {
            _colectieRepository = colectieRepository;
        }

        public Colectie FindById(Guid colectionId)
        {
            return _colectieRepository.FindById(colectionId);
        }

        public List<ColectieDTO> getAllForUser(Guid id)
        {
            var colectii = _colectieRepository.GetAllColectionsForUser(id);
            List<ColectieDTO> colectiiDTO = new List<ColectieDTO>();

            colectii.ForEach(elem =>
            {
                ColectieDTO colDTO = new ColectieDTO()
                {
                    Titlu_Colectie = elem.Titlu_Colectie,
                    Descriere_Colectie = elem.Descriere_Colectie,
                    Publica = elem.Publica,
                    Cale_Poza = elem.Cale_Poza
                };
                colectiiDTO.Add(colDTO);
            });
            return colectiiDTO;
        }

        public ColectieDTO createColectie(Colectie colectie, Guid utilizId)
        {
            colectie.UtilizatorId = utilizId;
            //colectie.DateCreated = new DateTime();
            _colectieRepository.Create(colectie);
            _colectieRepository.Save();

            ColectieDTO colectieDTO = new ColectieDTO()
            {
                Titlu_Colectie = colectie.Titlu_Colectie,
                Descriere_Colectie = colectie.Descriere_Colectie,
                Publica = colectie.Publica,
                Cale_Poza = colectie.Cale_Poza
            };
            return colectieDTO;
        }

        public ColectieDTO updateColectie(Guid id, Colectie colectie)
        {


            _colectieRepository.updateColectie(colectie);
            _colectieRepository.Save();
            ColectieDTO colectieDTO = new ColectieDTO()
            {
                Titlu_Colectie = colectie.Titlu_Colectie,
                Descriere_Colectie = colectie.Descriere_Colectie,
                Publica = colectie.Publica,
                Cale_Poza = colectie.Cale_Poza
            };
            return colectieDTO;
        }
        public void Save()
        {
            _colectieRepository.Save();
        }

        public ColectieDTO deleteColectie(Colectie colectie)
        {
            _colectieRepository.Delete(colectie);
            ColectieDTO colectieDTO = new ColectieDTO()
            {
                Titlu_Colectie = colectie.Titlu_Colectie,
                Descriere_Colectie = colectie.Descriere_Colectie,
                Publica = colectie.Publica,
                Cale_Poza = colectie.Cale_Poza
            };
            return colectieDTO;
        }

    }
}
