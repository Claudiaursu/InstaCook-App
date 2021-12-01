using proiectDAW.Models.Base;
using proiectDAW.Models.One_To_Many;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Models.Many_To_Many
{
    public class Reteta : BaseEntity
    {
        public string Titlu_Reteta { get; set; }
        public string Ingrediente { get; set; }
        public string Instructiuni { get; set; }
        public string Cale_Poza { get; set; }
        public bool Participa_Concurs { get; set; }

        // o reteta apartine unei singure colectii
        public Colectie Colectie { get; set; }
        public Guid ColectieId { get; set; }

        // o reteta apartine unei singure colectii
        public Bucatarie Bucatarie { get; set; }
        public Guid BucatarieId { get; set; }

        //many to many cu utilizator: reactii
        public ICollection<Reactie_Reteta> Reactii_Retete { get; set; }


    }
}
