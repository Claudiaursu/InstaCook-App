using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Models.Authentication
{
    public class UtilizatorRequestDTO
    {
        public string Username { get; set; }
        public string Nume_Utilizator { get; set; }
        public string Prenume_Utilizator { get; set; }
        public string Parola { get; set; }

    }
}
