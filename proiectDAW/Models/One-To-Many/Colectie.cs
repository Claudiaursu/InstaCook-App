using proiectDAW.Models.Base;
using proiectDAW.Models.Many_To_Many;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Models.One_To_Many
{
    public class Colectie : BaseEntity
    {
        public string Titlu_Colectie { get; set; }
        public string Descriere_Colectie { get; set; }
        public bool Publica{ get; set; }
        public string Cale_Poza { get; set; }
        
        // o colectie apartine unui singur utilizator
        public Utilizator Utilizator { get; set; }
        public Guid UtilizatorId { get; set; }

        // o colectie are mai multe retete
        public ICollection<Reteta> Retete { get; set; }

    }
}
