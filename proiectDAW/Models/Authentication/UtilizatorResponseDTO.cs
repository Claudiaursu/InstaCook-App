using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Models.Authentication
{
    public class UtilizatorResponseDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Nume_Utilizator { get; set; }
        public string Prenume_Utilizator { get; set; }
        public string Token { get; set; }

        public UtilizatorResponseDTO(Utilizator utilizator, string token)
        {
            Id = utilizator.Id;
            Username = utilizator.Username;
            Nume_Utilizator = utilizator.Nume_Utilizator;
            Prenume_Utilizator = utilizator.Prenume_Utilizator;
            Token = token;

        }
    }
}
