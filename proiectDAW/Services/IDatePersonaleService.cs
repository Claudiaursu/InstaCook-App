using proiectDAW.Models.DTOs;
using proiectDAW.Models.One_To_One;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Services
{
    public interface IDatePersonaleService
    {
        DatePersonaleDTO createDatePersonale(string email, string tara, string telefon);
        DatePersonaleDTO create(Date_Personale date);

    }
}
