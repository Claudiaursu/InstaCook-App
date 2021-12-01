using proiectDAW.Models.Base;
using proiectDAW.Models.Many_To_Many;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Models.One_To_Many
{
    public class Bucatarie : BaseEntity
    {
        public string Nume_Bucatarie { get; set; }
        public string Descriere_Bucatarie { get; set; }
        public string Regiune_Glob { get; set; }
        public ICollection<Reteta> Retete { get; set; }
        public ICollection<Concurs> Concursuri { get; set; }
    }
}
