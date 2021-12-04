using proiectDAW.Data;
using proiectDAW.Models.One_To_One;
using proiectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Repositories.DatabaseRepository
{
    public class DatePersonaleRepository : GenericRepository<Date_Personale>, IDatePersonaleRepository
    {
        public DatePersonaleRepository(ProjectContext context) : base(context)
        {

        }

        public Date_Personale CreateDatePersonale(string email, string tara, string telefon)
        {
            Date_Personale dateNoi = new Date_Personale()
            {
                Email = email,
                Tara_Origine = tara,
                Telefon = telefon
            };
            this.Create(dateNoi);
            this.Save();
            return dateNoi;
        }
    }
}
