using proiectDAW.Models.Base;
using proiectDAW.Models.Many_To_Many;
using proiectDAW.Models.One_To_Many;
using proiectDAW.Models.One_To_One;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Models
{
    public class Utilizator : BaseEntity
    {
        public string Nume_Utilizator { get; set; }
        public string Prenume_Utilizator { get; set; }

        public Date_Personale Date_Personale { get; set; }
        public Guid Date_PersonaleId { get; set; }

        public int Total_Puncte { get; set; }
        public bool Admin { get; set; }

        //un utilizator are mai multe colectii
        public ICollection<Colectie> Colectii { get; set; }

        //many to many cu retete: reactii
        public ICollection<Reactie_Reteta> Reactii_Retete { get; set; }

    }
}
