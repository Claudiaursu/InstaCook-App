using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Models.DTOs
{
    public class ColectieDTO
    {
        public string Titlu_Colectie { get; set; }
        public string Descriere_Colectie { get; set; }
        public bool Publica { get; set; }
        public string Cale_Poza { get; set; }
    }
}
