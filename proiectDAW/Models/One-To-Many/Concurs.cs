using proiectDAW.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Models.One_To_Many
{
    public class Concurs : BaseEntity
    {
        public string Titlu_Concurs{ get; set; }
        public DateTime Data_Inceput { get; set; }
        public DateTime Data_Sfarsit { get; set; }
        public string Stadiu { get; set; }
        public int Puncte_Oferite { get; set; }
        public string Nume_Castigator { get; set; }

        //un concurs poate apartine unei singure bucatarii
        public Bucatarie Bucatarie { get; set; }
        public Guid BucatarieId { get; set; }
    }
}
