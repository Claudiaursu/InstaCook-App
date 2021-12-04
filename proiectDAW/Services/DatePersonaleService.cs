using proiectDAW.Models.DTOs;
using proiectDAW.Models.One_To_One;
using proiectDAW.Repositories.DatabaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Services
{
    public class DatePersonaleService : IDatePersonaleService
    {
        public IDatePersonaleRepository _datePersonaleRepository;

        public DatePersonaleService(IDatePersonaleRepository datePersonaleRepository)
        {
            _datePersonaleRepository = datePersonaleRepository;
        }

        public DatePersonaleDTO create(Date_Personale date)
        {
            _datePersonaleRepository.Create(date);
            _datePersonaleRepository.Save();
            DatePersonaleDTO dateDTO = new DatePersonaleDTO()
            {
                Email = date.Email,
                Tara_Origine = date.Tara_Origine,
                Telefon = date.Telefon
            };
            return dateDTO;
        }

        public DatePersonaleDTO createDatePersonale(string email, string tara, string telefon)
        {
            Date_Personale datePersonale = new Date_Personale()
            {
                Email = email,
                Tara_Origine = tara,
                Telefon = telefon
            };
            _datePersonaleRepository.Create(datePersonale);
            DatePersonaleDTO dateDTO = new DatePersonaleDTO()
            {
                Email = email,
                Tara_Origine = tara,
                Telefon = telefon
            };
            return dateDTO;
        }
    }
}
