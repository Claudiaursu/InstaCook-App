using proiectDAW.Models.One_To_One;
using proiectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Repositories.DatabaseRepository
{
    public interface IDatePersonaleRepository: IGenericRepository<Date_Personale>
    {
        Date_Personale CreateDatePersonale(string telefon, string email, string tara);
    }
}
