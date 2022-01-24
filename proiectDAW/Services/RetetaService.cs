using proiectDAW.Models.DTOs;
using proiectDAW.Models.Many_To_Many;
using proiectDAW.Repositories.DatabaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Services
{
    public class RetetaService : IRetetaService
    {
        public IRetetaRepository _retetaRepository;

        public RetetaService(IRetetaRepository retetaRepository)
        {
            _retetaRepository = retetaRepository;
        }

        public List<RetetaDTO> getReteteFromCollection(Guid colId)
        {
            List<RetetaDTO> reteteDTO = new List<RetetaDTO>();
            List<Reteta> allRetete = _retetaRepository.getAllFromCollection(colId);
            allRetete.ForEach(reteta =>
            {
                RetetaDTO retetaDTO = new RetetaDTO()
                {
                    Titlu_Reteta = reteta.Titlu_Reteta,
                    Ingrediente = reteta.Ingrediente,
                    Instructiuni = reteta.Instructiuni,
                    Cale_Poza = reteta.Instructiuni,
                    Participa_Concurs = reteta.Participa_Concurs,
                };
                reteteDTO.Add(retetaDTO);
            });
            return reteteDTO;
        }

        public RetetaDTO createReteta(Reteta reteta, Guid colId)
        {
            reteta.ColectieId = colId;
            //colectie.DateCreated = new DateTime();
            _retetaRepository.Create(reteta);
            _retetaRepository.Save();

            RetetaDTO retetaDTO = new RetetaDTO()
            {
                Titlu_Reteta = reteta.Titlu_Reteta,
                Ingrediente = reteta.Ingrediente,
                Instructiuni = reteta.Instructiuni,
                Cale_Poza = reteta.Instructiuni,
                Participa_Concurs = reteta.Participa_Concurs,
            };
            return retetaDTO;
        }

        public RetetaDTO deleteReteta(Reteta reteta)
        {
            _retetaRepository.Delete(reteta);
            RetetaDTO retetaDTO = new RetetaDTO()
            {
                Titlu_Reteta = reteta.Titlu_Reteta,
                Ingrediente = reteta.Ingrediente,
                Instructiuni = reteta.Instructiuni,
                Cale_Poza = reteta.Instructiuni,
                Participa_Concurs = reteta.Participa_Concurs,
            };
            return retetaDTO;
        }

        public Reteta FindById(Guid retetaId)
        {
            return _retetaRepository.FindById(retetaId);
        }

        public void Save()
        {
            _retetaRepository.Save();
        }
    }
}
