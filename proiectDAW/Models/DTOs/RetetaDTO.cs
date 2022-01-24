using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Models.DTOs
{
    public class RetetaDTO
    {
        public string Titlu_Reteta { get; set; }
        public string Ingrediente { get; set; }
        public string Instructiuni { get; set; }
        public string Cale_Poza { get; set; }
        public bool Participa_Concurs { get; set; }

    }
}
