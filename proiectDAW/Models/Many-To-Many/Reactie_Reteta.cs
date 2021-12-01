using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Models.Many_To_Many
{
    public class Reactie_Reteta
    {
        public Guid RetetaId { get; set; }
        public Reteta Reteta { get; set; }

        public Guid UtilizatorId { get; set; }
        public Utilizator Utilizator { get; set; }

        public string Reactie { get; set; }
    }
}
