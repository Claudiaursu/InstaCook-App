using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Models.DTOs
{
    public class UtilizatorDTO
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Username { get; set; }
        public int NrPuncte { get; set; }
        public string Email {get; set; }
        public string Tara_Origine { get; set; }
        public string Telefon { get; set; }
    }
}
